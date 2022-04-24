using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.Modules;

namespace EbSite.Modules.Shop.AdminPages.Controls.DownNotice
{
    public partial class SendMsg : MPUCBaseSave
    {
        public override string Permission
        {
            get
            {
                return "100";
            }
        }
        override protected string KeyColumnName
        {
            get
            {
                return "id";
            }
        }
        public override string PageName
        {
            get
            {
                return "发送短信";
            }
        }
        override protected void InitModifyCtr()
        {

        }
        protected override void SaveModel()
        {
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}