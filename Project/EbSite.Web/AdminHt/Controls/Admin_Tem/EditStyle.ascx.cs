using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EbSite.Web.AdminHt.Controls.Admin_Tem
{
    public partial class EditStyle : BaseAdd
    {
        public override string Permission
        {
            get
            {
                return "240";
            }
        }
        protected override void SaveModel()
        {
            
            string name = Request.QueryString["Na"];
            string url = string.Concat(IISPath, TemBll.ThemesFolder, "/", TemBll._ThemeName, "/css/");
            // txtTem.Text = Core.FSO.FObject.ReadFile(Server.MapPath(url + name));
            Core.FSO.FObject.WriteFile(Server.MapPath(url + name), txtTem.Text, false);
        }
        protected override void InitModifyCtr()
        {
            throw new NotImplementedException();
        }
        protected override string KeyColumnName
        {
            get { throw new NotImplementedException(); }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Base.Host.Instance.CurrentSite.PageTheme != null)
                {
                    thememName.InnerHtml = "当前编辑样式所在皮肤:<font color=red>" + TemBll._ThemeName + "</font>";
                }

            }
            string name = Request.QueryString["Na"];
            //string url = "/themes/" + Base.Host.Instance.CurrentSite.PageTheme + "/css/";
            string url = string.Concat(IISPath, TemBll.ThemesFolder, "/", TemBll._ThemeName, "/css/");
            txtTem.Text = Core.FSO.FObject.ReadFile(Server.MapPath(url + name));

        }
    }
}