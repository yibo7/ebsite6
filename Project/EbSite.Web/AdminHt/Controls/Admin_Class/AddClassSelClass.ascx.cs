using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using EbSite.BLL;
using EbSite.Entity;
using NewsClass = EbSite.Entity.NewsClass;

namespace EbSite.Web.AdminHt.Controls.Admin_Class
{
    public partial class AddClassSelClass : EbSite.Base.ControlPage.UserControlBaseSave
    {

        protected void Page_Load(object sender, EventArgs e)
        {
           
            if (!IsPostBack)
            {
               
            }
           

        }
        override protected string KeyColumnName
        {
            get
            {
                return "id";
            }
        }
        override protected void InitModifyCtr()
        {

        }
        public override string Permission
        {
            get
            {
                return "55";
            }
        }
        protected int cid
        {
            get
            {
                if (!string.IsNullOrEmpty(Request["id"]))
                {
                    return int.Parse(Request["id"]);
                }
                return 0;
            }
        }
        private int iParentID
        {
            get
            {
                return Core.Utils.StrToInt(Request["pid"],0);
            }
        }

        override protected void SaveModel()
        {


        }
    }

}