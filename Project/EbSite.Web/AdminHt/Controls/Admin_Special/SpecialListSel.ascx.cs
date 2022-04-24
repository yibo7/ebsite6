using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using EbSite.Base.ControlPage;
using EbSite.Base.Static.BatchCreatManager;

//using EbSite.Core.Static.BatchCreatManager;

namespace EbSite.Web.AdminHt.Controls.Admin_Special
{
    public partial class SpecialListSel : EbSite.Base.ControlPage.UserControlBaseSave
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
                return "56";
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


        override protected void SaveModel()
        {


        }

        


    }
}