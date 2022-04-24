using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.Configs.ContentSet;
using EbSite.Base.ControlPage;
using EbSite.Base.Modules;

namespace EbSite.Web.AdminHt.Controls.Admin_SEO
{
    public partial class gather : UserControlBaseSave
    {
        
        public override string Permission
        {
            get
            {
                return "283";
            }
        }
        override protected string KeyColumnName
        {
            get
            {
                return "id";
            }
        }
        override protected void InitDivsteptips()
        {
        }

        protected void Page_Load(object sender, EventArgs e)
        {
             

        }

        override protected void InitModifyCtr()
        {

        }
        override protected void SaveModel()
        {
            
        }

        
    }
}