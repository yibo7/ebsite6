using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.BLL.GetLink;
using EbSite.BLL.User;

namespace EbSite.Web
{
    public partial class activate : EbSite.Base.Page.BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Title = "激活帐号";
            string strAct = Request["act"];
            if(!string.IsNullOrEmpty(strAct))
            {   
                int RoleID;
                bool isok = BLL.User.MembershipUserEb.Instance.IsActivateOK(strAct, out RoleID);
                if(isok)
                { 
                    //BLL.User.UserGroupProfile.
                    string RetunUrl = EbSite.BLL.User.MembershipUserEb.Instance.GetActivatedReturnUrl(RoleID, "");
                    if (!string.IsNullOrEmpty(RetunUrl))
                        Response.Redirect(RetunUrl);
                    else
                    {
                        
                        Tips("帐号已经激活", "恭喜，帐号已经激活，您可以正常登录网站,如果系统不能成功返回，<a href='" + HostApi.LoginRw + "'>请点击这里登录网站</a>", HostApi.LoginRw);
                        //Tips("帐号已经激活", "恭喜，帐号已经激活，您可以正常登录网站,如果系统不能成功返回，<a href='" + HrefFactory.GetMainInstance.LoginRw + "'>请点击这里登录网站</a>", HrefFactory.GetMainInstance.LoginRw);
                    }
                    
                }
                else
                {
                    Tips("失败", "抱歉，帐号激活失败，确认注册时间是否在24小时内");
                }
            }
        }
    }
}