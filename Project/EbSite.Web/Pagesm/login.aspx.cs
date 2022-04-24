using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base;
using EbSite.Base.Page;

namespace EbSite.Web.Pagesm
{
    public partial class login : EbSite.Base.Page.BasePageMobile
    {
        override protected string MTitle
        {
            get
            {
                return "用户登录";
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            SeoTitle = "用户登录";

            lbLogin.Click += lbLogin_Click;
        }

        protected void lbLogin_Click(object sender, EventArgs e)
        {
            string sUserName = txtUserName.Text.Trim();
            string sPass = txtUserPass.Text.Trim();

            ToLogin(sUserName, sPass);
        }
        private void ToLogin(string sUserName, string sPass)
        {
            if (BLL.User.UserIdentity.IsOverErrLoginNum())
            {
                lbErrInfo.Text = "对不起，你错误登录了" + Base.Configs.SysConfigs.ConfigsControl.Instance.ErrLoginNum + "次，系统登录锁定！!";
                //Response.Write("<script>alert('" + isErr + "')</script>");

            }

            string sErr = "";
            EbSite.Base.EntityAPI.MembershipUserEb ucf = BLL.User.MembershipUserEb.Instance.ValidateUser(sUserName, sPass, -1, out sErr);

            if (!Equals(ucf, null) && string.IsNullOrEmpty(sErr)) //登录成功
            {

                AppStartInit.LoginToReurl(HostApi.MUccIndexRw);
            }
            else
            {
                BLL.User.UserIdentity.AddErrLoginNum();
                lbErrInfo.Text = sErr;
                // Response.Write("<script>alert('" + sErr + "')</script>");
            }
        }

      
        #region 解决重写url后，保持postback地址不改变的问题

        //// <summary>
        ///  重写默认的HtmlTextWriter方法，修改form标记中的value属性，使其值为重写的URL而不是真实URL。
        /// </summary>
        /// <param name="writer"></param>
        protected override void Render(HtmlTextWriter writer)
        {
            if (writer is System.Web.UI.Html32TextWriter)
            {
                writer = new FormFixerHtml32TextWriter(writer.InnerWriter);
            }
            else
            {
                writer = new FormFixerHtmlTextWriter(writer.InnerWriter);
            }

            base.Render(writer);
        }
        #endregion
    }
}