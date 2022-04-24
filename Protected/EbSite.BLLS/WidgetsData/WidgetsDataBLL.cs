using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Web.Hosting;
using System.Xml;
using EbSite.Entity;
namespace EbSite.BLL
{
	/// <summary>
	/// 业务逻辑类CountData 的摘要说明。
	/// </summary>
    public class WidgetsDataBLL
	{
	    public  DataTable dt;
        private List<string> _Columns ;
	    private string _TableName;
        
        /// <summary>
        /// 初始化列名称
        /// </summary>
        /// <param name="Columns">列名称集合</param>
        /// <param name="TableName">数据表名称</param>
        public WidgetsDataBLL(List<string> Columns,string TableName)
		{
            dt = new DataTable();
            _Columns = Columns;
            _Columns.Add("AddDate");
            _TableName = TableName;
            dt.Columns.Add("id");
            foreach (string column in Columns)
            {
                dt.Columns.Add(column);
            }
            if (!Directory.Exists(CurrentLogsFolder))
                Directory.CreateDirectory(CurrentLogsFolder);

		}
	    private string CurrentLogsFolder
	    {
	        get
	        {
                //string p = System.IO.Path.Combine(System.Web.HttpRuntime.AppDomainAppPath, "datastore");
                //return string.Concat(p, "\\WidgetsTable\\", _TableName, Path.DirectorySeparatorChar);
                //保存到当前皮肤下
                //string sP = string.Concat(EbSite.BLL.ThemesPC.Instance.GetCurrentUsedTheme.ThemePath, "\\data\\Widgets\\TableData");
                
                
                //string sP = string.Concat(EbSite.Base.Host.Instance.CurrentSite.PageTheme, "\\data\\Widgets\\TableData");
                
                //string p = System.IO.Path.Combine(System.Web.HttpRuntime.AppDomainAppPath, sP);
                //return string.Concat(p, "\\WidgetsTable\\", _TableName, Path.DirectorySeparatorChar);

                return HostingEnvironment.MapPath(string.Concat(EbSite.Base.Host.Instance.CurrentSite.GetPathWidgetsTableData(), "/", _TableName,"/"));

	        }
	    }
        /// <summary>
        /// 查询一条记录
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public  DataRow SelectData(Guid id)
        {
            string fileName = CurrentLogsFolder + id.ToString() + ".xml";
            XmlDocument doc = new XmlDocument();
            doc.Load(fileName);
            DataRow dr = dt.NewRow();
            dr["id"] = id.ToString();
            foreach (string column in _Columns)
            {
                if (!Equals(doc.SelectSingleNode(string.Format("data/{0}", column)),null))
                dr[column] = doc.SelectSingleNode(string.Format("data/{0}", column)).InnerText;
            }
           
            return dr;
        }
        /// <summary>
        /// 添加插入一条记录
        /// </summary>
        /// <param name="ID">记录id</param>
        /// <param name="ColumnValues">记录值，注意，这里的值务必要与类初始化时的列对应</param>
        private void InsertData(Guid ID,List<string> ColumnValues)
        {
            

            string fileName = CurrentLogsFolder + ID + ".xml";
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;

            using (XmlWriter writer = XmlWriter.Create(fileName, settings))
            {
                writer.WriteStartDocument(true);
                writer.WriteStartElement("data");
                for (int i = 0; i < _Columns.Count; i++)
                {
                    writer.WriteElementString(_Columns[i], ColumnValues[i]);   
                }
                writer.WriteEndElement();
            }
        }
        /// <summary>
        /// 添加插入一条记录
        /// </summary>
        /// <param name="ColumnValues">记录值，注意，这里的值务必要与类初始化时的列对应</param>
        public Guid InsertData(List<string> ColumnValues)
        {
            Guid ID = Guid.NewGuid();
            InsertData(ID, ColumnValues);
            return ID;
        }
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="ID">记录id</param>
        /// <param name="ColumnValues">记录值，注意，这里的值务必要与类初始化时的列对应</param>
        public void Update(Guid ID,List<string> ColumnValues)
        {
            InsertData(ID,ColumnValues);
        }
        /// <summary>
        /// 更新某条数据的某个列值
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="sColumnName">列名称</param>
        /// <param name="sValue">列对应的值</param>
        public void Update(Guid ID, string sColumnName,string sValue)
        {
            DataRow dr =  SelectData(ID);
            List<string> lst = new List<string>();
            foreach (string column in _Columns)
            {
                if (Equals(sColumnName,column))
                {
                    lst.Add(sValue);
                }
                else
                {
                    lst.Add(dr[column].ToString());    
                }
                

            }

            Update(ID, lst);
        }
        public  void Delete(Guid ID)
        {
            string fileName = CurrentLogsFolder + ID + ".xml";
            if (File.Exists(fileName))
                File.Delete(fileName);

            //if (Logs.Pages.Contains(page))
            //    Logs.Pages.Remove(page);
        }

        public  DataTable Fills()
        {
            
            foreach (string file in Directory.GetFiles(CurrentLogsFolder, "*.xml", SearchOption.TopDirectoryOnly))
            {
                FileInfo info = new FileInfo(file);
                string id = info.Name.Replace(".xml", string.Empty);


                DataRow dr = SelectData(new Guid(id));
                dt.Rows.Add(dr);
            }

            return dt;
        }
		
	}
}

