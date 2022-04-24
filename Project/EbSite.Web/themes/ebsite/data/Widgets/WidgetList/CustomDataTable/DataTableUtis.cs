using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.BLL.ModelBll;

namespace EbSite.Widgets.CustomDataTable
{
    public class DataTableModel
    {
        private string _TitleName;
        private string _ColumnName;
        private string _CtrID;


        public string TitleName
        {
            get
            {
                return _TitleName;
            }
            set
            {
                _TitleName = value;
            }
        }
        public string ColumnName
        {
            get
            {
                return _ColumnName;
            }
            set
            {
                _ColumnName = value;
            }
        }
        public string CtrID
        {
            get
            {
                return _CtrID;
            }
            set
            {
                _CtrID = value;
            }
        }
    }

    public class DataTableUtis : ModelBase<DataRow> 
    {
        public DataTableUtis(int _SiteID) : base(_SiteID)
        {
            
        }
        public override string WebModelName
        {
            get
            {
                return "DataTableUtis";
            }
        }

        public static  DataTableUtis Instance
        {
            get
            {
                return new DataTableUtis(EbSite.Base.Host.Instance.GetSiteID);
            }
        }
       
        //public override List<EbSite.Entity.ModelClass> ModelClassList
        //{
        //    get
        //    {
        //        return null;
        //    }
        //}
        public override string[] aColums
        {

            get { return null; }
        }
        public override void InitModifyCtr(PlaceHolder ph, DataRow ModifyModel)
        {
            foreach (System.Web.UI.Control uc in ph.Controls)
            {
                if (Equals(uc.ID, null)) continue;
                string sValue = ModifyModel[uc.ID].ToString();
                SetValueFromControl(uc, sValue);
            }
            
        }
       
        //public override void Save()
        //{
            
        //}
        public override void InitSaveCtr(PlaceHolder ph, ref DataRow ModifyModel)
        {
            foreach (System.Web.UI.Control uc in ph.Controls)
            {
                if (Equals(uc.ID, null)) continue;
                string sValue = "";
                
                sValue = GetValueFromControl(uc);

                ModifyModel[uc.ID] = sValue;

            }
        }
    }
}
