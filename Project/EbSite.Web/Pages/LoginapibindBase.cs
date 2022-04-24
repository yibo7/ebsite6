using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EbSite.Base.Plugin;

namespace EbSite.Web.Pages
{
    public class LoginapibindBase : EbSite.Base.Page.CustomPage
    {
        protected IUserLoginApi LoginApi;
        public LoginapibindBase()
        {

            this.Load += new EventHandler(LoginapibindBase_Load);
           
        }
        private void LoginapibindBase_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request["t"]))
            {
                LoginApi = Factory.GetLoginApi(Request["t"]);
                if (!Equals(LoginApi,null))
                {
                    Tips("出错了", string.Format("找不到名称为[{0}]的登录插件", Request["t"]));
                }
            }
            else
            {
                Tips("出错了", "传入的登录接口名称有误！");
            }

        }
    }
}