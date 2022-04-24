using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI.WebControls;
using EbSite.Base.CusttomTable;
using EbSite.Core.FSO;
using EbSite.Entity;

namespace EbSite.BLL.ModelBll
{

    public class CusttomFiledsBLLForm : CusttomFiledsBLL<StringDictionary>
    {
        private int SiteID;
        public CusttomFiledsBLLForm(Guid mid, int _SiteID)
            : base(mid,_SiteID)
        {
            SiteID = _SiteID;
        }

        private ModelClass mc
        {
            get
            {
                ModelInterface bllModel = new FormModel(SiteID);
                return bllModel.GeModelByID(ModuleID);
            }
        }
        override protected void LoadDataLayer()
        {
            //这里保存在xml文件里,如果要保存在数据库，要重写一个数据库处理的StringDictionaryBehavior
            SettingsBehavior = new StringDictionaryBehavior();
        }
        /// <summary>
        /// 生成guidview控件的列
        /// </summary>
        private void BuilderGvColumn(Control.GridView gv, string ColumFiledName, string ColumShowName)
        {
            BoundField bf = new BoundField();
            bf.DataField = ColumFiledName;
            bf.HeaderText = ColumShowName;
            gv.Columns.Insert(0, bf);

        }
        public List<FileInfo> GetDataIDS()
        {
            string p = string.Concat(EbSite.Base.Host.Instance.CurrentSite.GetPathModelsCusttomFiledForm(0), ModuleID, "/");
            return Core.FSO.FObject.GetFileListByTypes(p, new string[] { "xml" });
        }
        public DataTable GetDataTable(Control.GridView gv)
        {

            List<ColumFiledConfigs> lsUsedFileds = mc.GetUsedFileds();

            List<StringDictionary> lstModel = new List<StringDictionary>();


            foreach (FileInfo fileInfo in GetDataIDS())
            {
                string id = fileInfo.Name.Replace(".xml", "");
                StringDictionary xx = this.GetEntity((new Guid(id)));
                xx["id"] = id;
                lstModel.Add(xx);
            }



            DataTable dt = new DataTable();
            dt.Columns.Add("id");
            foreach (ColumFiledConfigs configs in lsUsedFileds)
            {
                dt.Columns.Add(configs.ColumFiledName);
                BuilderGvColumn(gv, configs.ColumFiledName, configs.ColumShowName);
            }
            foreach (StringDictionary dictionary in lstModel)
            {
                DataRow dr = dt.NewRow();
                dr["id"] = dictionary["id"];
                foreach (ColumFiledConfigs configs in lsUsedFileds)
                {
                    dr[configs.ColumFiledName] = dictionary[configs.ColumFiledName];
                }
                dt.Rows.Add(dr);
            }

            return dt;
        }
        override public void Save(Guid did, StringDictionary data)
        {
            SettingsBehavior.SaveSettings(SavePath, did.ToString(), data);

        }
        protected override string SaveForlder
        {
            get
            {
                return "Form";
            }
        }
    }
}
