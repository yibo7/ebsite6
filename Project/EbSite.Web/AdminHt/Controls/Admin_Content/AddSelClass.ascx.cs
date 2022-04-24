using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Web.UI.WebControls;
using EbSite.Base.ControlPage;
using EbSite.BLL;
using EbSite.Web.AdminHt.Controls.Admin_Class;

namespace EbSite.Web.AdminHt.Controls.Admin_Content
{
    public partial class AddSelClass : EbSite.Base.ControlPage.UserControlBaseSave 
    {
        public override string Permission
        {
            get
            {
                return "61";
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

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

         override protected void SaveModel()
         {
            
         }
    }
}