using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.Page;

namespace EbSite.Web.Pagesm
{
    public partial class uccuserinfo : UccBase
    {
        private int iEditType
        {
            get { return Core.Utils.StrToInt(Request["t"], 0); }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (iEditType > 0)
            {
                phBoxShow.Visible = false;
                phEdite.Visible = true;
            }
            else
            {
                EbSite.Base.EntityAPI.MembershipUserEb md = HostApi.CurrentUser;
                ltUserName.Text = md.UserName;
                txtEmail.Text = md.emailAddress;
                ltLastLogin.Text = md.LastLoginDate.ToString();
            }
           
        }

        protected void btnSaveIco_Click(object sender, EventArgs e)
        {
            if (UserID > 0)
            {
                string sFullPath = txtMdPath.CtrValue;

                HostApi.UpdateICO(UserID, sFullPath,this.Context);
                Response.Redirect(Request.RawUrl.Split('?')[0]);
                
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