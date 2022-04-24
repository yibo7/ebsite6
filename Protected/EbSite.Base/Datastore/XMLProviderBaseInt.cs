using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web;
using System.Web.UI.WebControls;
using System.Xml;
using EbSite.Base.BLL;
using EbSite.Base.Entity;
using EbSite.Core;
using EbSite.Core.FSO;
using EbSite.Entity;

namespace EbSite.Base.Datastore
{

    [Serializable]
    public class XMLProviderBaseInt<TYPE> : Base<TYPE, int> where TYPE : XmlEntityBase<int>, new()
    {
        protected HttpContext httpContext;
        public XMLProviderBaseInt()
        {
            httpContext = HttpContext.Current;

        }
        public int GetMaxID
        {
            get
            {
                int iMaxID = 0;

                if(lstDataList.Count()>0)
                {
                    iMaxID = (from model in lstDataList select model.id).Max();
                              
                }
                return iMaxID+1;
            }
        }
        public override int Add(TYPE tpMd)
        {
            if (!Directory.Exists(this.SavePath))
            {
                Directory.CreateDirectory(this.SavePath);
            }
            XmlEntityBase<int> ModelData = tpMd;// as XmlEntityBase
           
            if(tpMd.id==0)
            {
                tpMd.id = GetMaxID;
            }
            string outputFileName = string.Concat(this.SavePath, tpMd.id, ".xml");
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            using (XmlWriter writer = XmlWriter.Create(outputFileName, settings))
            {
                writer.WriteStartDocument(true);
                writer.WriteStartElement(this._DataFolder);
                foreach (PropertyInfo info in ModelData.GetFieldInfos())
                {
                    string name = info.Name;
                    if (!object.Equals(name, "GetFieldInfos") && !object.Equals(name, "GetColumNames"))
                    {
                        object obstr3 = info.GetValue(ModelData, null);
                        if (!Equals(obstr3, null))
                        {
                            writer.WriteElementString(name, obstr3.ToString());
                        }
                        else
                        {
                            writer.WriteElementString(name, "");
                        }

                    }
                }
                writer.WriteEndElement();
            }
            base.InvalidateCache();
            return ModelData.id;
        }

        public override void Delete(int ID)
        {
            string path = this.SavePath + ID + ".xml";
            if (File.Exists(path))
            {
                File.Delete(path);
            }
            base.InvalidateCache();
        }
        public List<TYPE> FillList()
        {
            return IFillList().ToList();
        }

        public IEnumerable<TYPE> IFillList()
        {
            List<TYPE> cacheItem = new List<TYPE>();
            foreach (string str2 in Directory.GetFiles(this.SavePath, "*.xml", SearchOption.TopDirectoryOnly))
            {
                FileInfo info = new FileInfo(str2);
                string dID = info.Name.Replace(".xml", string.Empty);
                TYPE entity = this.GetEntity(int.Parse(dID));
                cacheItem.Add(entity);
            }
            var ddd = (from mds in cacheItem orderby mds.id descending select mds).ToList(); 
            //IEnumerable<TYPE> query = cacheItem.OrderByDescending(d => d.id);
            return ddd;

        }
        /// <summary>
        /// 检测是否存在某个记录
        /// </summary>
        /// <param name="ID">记录ID</param>
        /// <returns></returns>
        public bool IsHave(Guid ID)
        {
            string filename = string.Concat(this.SavePath, ID, ".xml");
            return Core.FSO.FObject.IsExist(filename, FsoMethod.File);
        }
        public void  CopyData(int id)
        {
            TYPE md = GetEntity(id);
            md.id = GetMaxID;
            Add(md);
        }

        public override TYPE GetEntity(int id)
        {
            if (id > 0)
            {
                string filename = string.Concat(this.SavePath, id, ".xml");
                XmlDocument document = new XmlDocument();
                document.Load(filename);
                Type type = typeof(TYPE);
                TYPE mdData  = (TYPE)Activator.CreateInstance(type);
                List<PropertyInfo> properties = mdData.GetFieldInfos();//.GetType().GetProperties();
                foreach (PropertyInfo info in properties)
                {
                    string name = info.Name;
                    if (!object.Equals(name, "GetFieldInfos") && !object.Equals(name, "GetColumNames"))
                    {
                        string xpath = string.Format("{0}/{1}", this._DataFolder, name);
                        if (!object.Equals(document.SelectSingleNode(xpath), null))
                        {
                            string innerText = document.SelectSingleNode(xpath).InnerText;

                            if (object.Equals(info.PropertyType, typeof(int)))
                            {
                                //int dataid = int.Parse(innerText);
                                int dataid = Core.Utils.StrToInt(innerText,0);
                                info.SetValue(mdData, Convert.ChangeType(dataid, info.PropertyType), null);
                            }
                            if (object.Equals(info.PropertyType, typeof(Guid)))
                            {
                                Guid dataid = new Guid(innerText);
                                info.SetValue(mdData, Convert.ChangeType(dataid, info.PropertyType), null);
                            }
                            else
                            {
                                info.SetValue(mdData, Convert.ChangeType(innerText, info.PropertyType), null);
                            }
                        }
                    }
                }
                return mdData;
            }
            else
            {
                return null;
            }

        }

        public override List<TYPE> GetListArray(int Top, string strWhere, string filedOrder)
        {
            throw new NotImplementedException();
        }

        public List<TYPE> GetListPages(int PageIndex, int PageSize, out int RecordCount)
        {
            List <TYPE>  lst = this.lstDataList.ToList();
            RecordCount = lst.Count;
            return PagedListExpansion.ToPagedList(lst, PageIndex, PageSize);
        }

        public override List<TYPE> GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby, out int RecordCount)
        {
            throw new NotImplementedException();
        }

        public override void Update(TYPE model)
        {
            this.Add(model);
        }

        private string _DataFolder
        {
            get
            {
                if (string.IsNullOrEmpty(this.DataFolder))
                {
                    Type type = typeof(TYPE);
                    return type.Name; //泛型时会在后面加上 `1,不知道为什么
                }
                return this.DataFolder;
            }
        }
        /// <summary>
        /// 保存文件夹及给xml类命名,为空将使用实体类名称,如果实体类是泛型一定要重写，否则会有出错 如 
        /// </summary>
        public virtual string DataFolder
        {
            get
            {
                return "";
            }
        }

        public IEnumerable<TYPE> lstDataList
        {
            get
            {
                return this.FillList();
            }
        }

        public virtual string SavePath
        {
            get
            {
                string str = "datastore";
                return string.Concat(new object[] { Path.Combine(HttpRuntime.AppDomainAppPath, str), @"\", this._DataFolder, Path.DirectorySeparatorChar });
            }
        }

        #region  共用代码

        /// <summary>
        /// 修改时获取当前实例，并载入控件到PlaceHolder
        /// </summary>
        public void InitModifyCtr(int id, PlaceHolder ph)
        {
            if (id > 0)
            {
                TYPE mdEt = GetEntity(id);
                foreach (System.Web.UI.Control uc in ph.Controls)
                {
                    if (Equals(uc.ID, null) || !mdEt.GetColumNames().Contains(uc.ID)) continue;
                    string sValue = mdEt.GetValueForColumn(uc.ID);
                    SetValueFromControl(uc, sValue);
                }
            }
        }
        /// <summary>
        /// 获取控件里的数据映射到一个实体，接着保存这个实例到数据
        /// </summary>
        public int SaveEntityFromCtr(PlaceHolder ph, List<Base.BLL.OtherColumn> lstOtherColumn)
        {
            TYPE mdEntity = GetEntityFromCtr(ph);
            if (!Equals(lstOtherColumn, null) && lstOtherColumn.Count > 0)
            {
                foreach (Base.BLL.OtherColumn column in lstOtherColumn)
                {
                    mdEntity.SetValueForColumn(column.ColumnName, column.ColumnValue);
                }
            }
            if (mdEntity.id > 0)
            {
                Update(mdEntity);
                return 0;
            }
            else
            {
                
               int sid =  Add(mdEntity);
               
                return sid;
            }
        }

        /// <summary>
        /// 从PlaceHolder中获取一个实例
        /// </summary>
        public TYPE GetEntityFromCtr(PlaceHolder ph)
        {
            TYPE mdEt = new TYPE();
            string sKeyID;
            if (GetIDFromCtr(ph, out sKeyID))
            {
                mdEt = GetEntity(int.Parse(sKeyID));
            }
            foreach (System.Web.UI.Control uc in ph.Controls)
            {
                if (Equals(uc.ID, null)) continue;
                string sValue = GetValueFromControl(uc);

                foreach (string column in mdEt.GetColumNames())
                {
                    if (Equals(uc.ID.ToLower(), column.ToLower()))
                    {
                        mdEt.SetValueForColumn(column, sValue);
                        break;
                    }
                }

            }
            return mdEt;
        }

        #endregion
    }


}
