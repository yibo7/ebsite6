using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.Services.Protocols;
using EbSite.Base.Configs.SysConfigs;
using EbSite.Core;

namespace EbSite.Base
{
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ScriptService]
    public class WebServiceBase : System.Web.Services.WebService
    {
        public EbSoapHeader SecurityKey = new EbSoapHeader();
        protected  readonly string NoAllowTips = "您没有访问WEB服务的权限！";
       /// <summary>
        /// 判断用户是否有权限访问web服务
       /// </summary>
        /// <param name="IsCheckUserLogin">是否验证登录</param>
       /// <returns></returns>
        protected bool IsAllow(bool IsCheckUserLogin, bool IsCheckAdminLogin)
       {
           
                bool isok = false;

               if(ConfigsControl.Instance.WebServiceRequestModel==0) //无验证
               {
                   isok = true;
               }
               else if (ConfigsControl.Instance.WebServiceRequestModel == 1) //验证安全码
               {
                   string stUrlReferrer = Utils.GetUrlReferrer();
                   string sHost = Utils.GetHost();
                   isok = !Utils.IsCrossSitePost(stUrlReferrer, sHost);//是否跨域

                   //if (!Equals(SecurityKey, null))  //在jquery ajax里请求有问题，暂时不开启
                   //{

                   //    isok = (SecurityKey.SafeKey == ConfigsControl.Instance.WebServiceSafeCode);

                   //    string stUrlReferrer = Utils.GetUrlReferrer();
                   //    string sHost = Utils.GetHost();
                   //    isok = !Utils.IsCrossSitePost(stUrlReferrer, sHost);//是否跨域
                   //}
                  
               }

               if(isok)
               {
                   if (IsCheckUserLogin)
                   {
                       isok = EbSite.Base.Host.Instance.UserID>0;
                   }
               }
               return isok;
            
        }
        protected bool IsAllow(bool IsCheckUserLogin)
        {
            return IsAllow(IsCheckUserLogin,false);
        }

        [WebMethod]
        [SoapHeader("SecurityKey")]
        public string IISPath()
        {
            return Base.AppStartInit.IISPath;
        }
        [WebMethod]
        [SoapHeader("SecurityKey")]
        public string UserName()
        {
           return Host.Instance.UserName;
        }
        [WebMethod]
        [SoapHeader("SecurityKey")]
        public int UserID()
        {
            return Host.Instance.UserID;
        }
        [WebMethod(EnableSession = true)]
        [SoapHeader("SecurityKey")]
        public string GetManagerID()
        {
            return Host.Instance.GetManagerID;

        }
        
    }

    public class EbSoapHeader : System.Web.Services.Protocols.SoapHeader
    {

        private string userName = string.Empty;
        private string passWord = string.Empty;

        /// <summary>
        /// 构造函数
        /// </summary>
        public EbSoapHeader()
        {

        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <param name="passWord">密码</param>
        public EbSoapHeader(string userName, string passWord)
        {
            this.userName = userName;
            this.passWord = passWord;
        }

        /// <summary>
        /// 获取或设置用户用户名
        /// </summary>
        public string UserName
        {
            get { return userName; }
            set { userName = value; }

        }

        /// <summary>
        /// 获取或设置用户密码
        /// </summary>
        public string PassWord
        {
            get { return passWord; }
            set { passWord = value; }
        }
    }
}
