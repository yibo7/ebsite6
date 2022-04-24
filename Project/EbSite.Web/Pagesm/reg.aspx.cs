using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base;
using EbSite.Base.Page;
using EbSite.Core.Strings;

namespace EbSite.Web.Pagesm
{
    public partial class reg : EbSite.Base.Page.BasePageMobile
    {
        override protected string MTitle
        {
            get
            {
                return "用户注册";
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            SeoTitle = "用户注册";
           // btnAddUser.Click += btnAddUser_Click;
        }
        /// <summary>
        /// 邀请人的用户ID  杨欢乐 2011-12-31 添加
        /// </summary>
        private int YQUserID
        {
            get
            {
                if (!string.IsNullOrEmpty(Request["vuid"]))
                {
                    string gid = Request["vuid"];

                    return int.Parse(gid);
                }
                else
                {
                    return -1;
                }
            }
        }

        /// <summary>
        /// 获取用户组ID，如果此ID大于0那么默认当前注册的用户将归于当前用户组
        /// </summary>
        private int GetGroupID
        {
            get
            {
                if (!string.IsNullOrEmpty(Request["gid"]))
                {
                    string gid = Request["gid"];

                    return BLL.User.UserGroupProfile.GroupIDDecode(gid);
                }
                else
                {
                    return BLL.User.UserGroupProfile.GroupIDDecode("hY7Z0/iDL3I=");
                }
            }
        }
        protected void btnAddUser_Click(object sender, EventArgs e)
        {
            if (txtPassWord.Text.Trim() != txtCfPassWord.Text.Trim())
            {
                cJavascripts.MessageShowBack("两次密码输入不一致!");
            }
            else
            {
                string rturl = "";
                RegStatus ms;
                string Ip = EbSite.Core.Utils.GetClientIP();
                int UserID = EbSite.Base.Host.Instance.RegUser(txtEmail.Text, txtPassWord.Text, txtCfPassWord.Text,
                                                               txtEmail.Text, false, GetGroupID, out ms, out rturl,
                                                               YQUserID, Base.Host.Instance.GetReurl, "", 0, Ip,
                                                               "手机reg.aspx提交注册");


                if (UserID > 0) //注册成功,开始登录
                {
                    //Response.Redirect(rturl);
                    Response.Redirect(HostApi.MUccIndexRw);

                }
                else
                {
                    if (RegStatus.已经存在此帐号 == ms)
                    {
                        cJavascripts.MessageShowBack("已经存在此用户名,请换一个用户名再注册!");
                    }
                    if (RegStatus.已经存在此Email == ms)
                    {
                        cJavascripts.MessageShowBack("已经存在此Email,请换一个Email再注册!");
                    }
                }
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