using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.ControlPage;

namespace EbSite.Web.AdminHt.Controls.Admin_WelCome
{
    public partial class CNZZ : Base
    {
        public override string Permission
        {
            get
            {
                return "314";
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                //if (EbSite.Core.CNZZ.IsHaveID)
                //{

                //    CnzzWeb.Attributes.Add("src", Core.CNZZ.InfoUrl);
                //    cnzzinfo.Visible = false;
                //    CnzzWeb.Visible = true;
                //}
                //else
                //{
                //    CnzzWeb.Visible = false;
                //    cnzzinfo.Visible = true;
                //    cnzzinfo.Text =
                //        "您没有安装官方站长工具模块，所以无法使用此功能，请到到官方网站<a href='http://www.ebsite.net' target=_blank >下载模块</a><br>或者模块已经安装，但未生成帐号，请到站长工具模块生成帐号！";
                //}
            }
        }
    }
}