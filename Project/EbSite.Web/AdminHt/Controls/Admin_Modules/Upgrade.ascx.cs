using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Entity;

namespace EbSite.Web.AdminHt.Controls.Admin_Modules
{
    public partial class Upgrade : BasePage
    {
        public override string Permission
        {
            get
            {
                return "237";
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ucPageTags.Title = "模块升级";
                if (string.IsNullOrEmpty(Model.UpdateUrl))
                {
                    bntUpdate.Text = "不提供在线升级";
                    bntUpdate.Enabled = false;
                    if (!string.IsNullOrEmpty(Model.AuthorUrl))
                    lbInfo.Text = string.Format("此模块不提供在线升级,您可以进入开发者的网站查找最新版本，<a href='{0}' target=_blank ><b>点击这里进入模块官网</b></a>", Model.AuthorUrl);
                }
                else
                {
                    bntUpdate.Visible = false;
                }
            }
        }
        protected void bntUpdate_Click(object sender, EventArgs e)
        {

        }
    }
}