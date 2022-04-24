using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.Modules;

namespace EbSite.Modules.UserBaseInfo.AdminPages.Controls.Splace
{
    public partial class EditeLayoutPane : MPUCBaseSave
    {
        public override Guid ModuleMenuID
        {
            get
            {
                return new Guid("7482bd0c-f117-4a61-a3a1-54d9c334117d");
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            string fn = Request.QueryString["fn"];
            string fUrl = HttpContext.Current.Server.MapPath(IISPath+"home/layoutpanes/" + fn + ".ascx");
            txtLayoutPane.Text = EbSite.Core.FSO.FObject.ReadFile(fUrl);
              

        }
        protected override void InitModifyCtr()
        {
            //string fn = Request.QueryString["fn"];
            //string fUrl = HttpContext.Current.Server.MapPath("/home/layoutpanes/" + fn + ".ascx");
            //txtLayoutPane.Text = EbSite.Core.FSO.FObject.ReadFile(fUrl);
        }
        protected override void SaveModel()
        {
            string fn = Request.QueryString["fn"];
            string fUrl = HttpContext.Current.Server.MapPath(IISPath+"home/layoutpanes/" + fn + ".ascx");
            EbSite.Core.FSO.FObject.WriteFile(fUrl, this.txtLayoutPane.Text);
            base.ShowTipsPop("编辑成功");
        }
        override protected string KeyColumnName
        {
            get
            {
                return "id";
            }
        }
        
    }
}