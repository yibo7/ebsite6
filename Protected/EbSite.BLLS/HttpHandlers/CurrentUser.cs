using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Services;
using EbSite.Base;
using EbSite.Base.Static;
using EbSite.Core;
using EbSite.Core.FSO;

namespace EbSite.BLL.HttpHandlers
{
    /// <summary>
    /// Summary description for $codebehindclassname$
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class CurrentUser : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            //EbSite.Base.Host.Instance.InsertLog("还没有开始", "");
            context.Response.ContentType = "text/plain";

            string UrlReferrer = Utils.GetUrlReferrer();
            if (string.IsNullOrEmpty(UrlReferrer) || Utils.IsCrossSitePost(UrlReferrer, Utils.GetHost())) //禁止跨站
            {
                return;
            }

            string sCurrentUserName = EbSite.Base.Host.Instance.UserName;
            int iUserID = EbSite.Base.Host.Instance.UserID;

            if (!string.IsNullOrEmpty(sCurrentUserName) && iUserID > 0)
            {


                string CacheKey = string.Concat("CurrentUser-", iUserID);
                string uinfo = Base.Host.CacheApp.GetCacheItem<string>(CacheKey, "CurrentUser");// as string;
                if (string.IsNullOrEmpty(uinfo))
                {
                    //查 手机号，Email,头像 
                    bool iTel = false;
                    EbSite.Base.EntityAPI.MembershipUserEb mdCurrentUser = EbSite.Base.Host.Instance.CurrentUser;
                    string tel = mdCurrentUser.MobileNumber;
                    bool iEmail = false;
                    string email = mdCurrentUser.emailAddress;

                    string headerurl = EbSite.Base.Host.Instance.EBMembershipInstance.GetAvatarFileName(EbSite.Base.AppStartInit.UserID, 1);
                    bool iHeader = Core.FSO.FObject.IsExist(HttpContext.Current.Server.MapPath(headerurl), FsoMethod.File);
                    if (!string.IsNullOrEmpty(tel))
                    {
                        iTel = true;
                    }
                    if (!string.IsNullOrEmpty(email))
                    {
                        iEmail = true;
                    }
                    //用户昵称|用户id|是否添写手机|是否添写email|是否添写头像|是否提示手机|是否提示email|是否提示头像|手机提示语|Email提示语|头像提示语
                    bool iTTel = EbSite.Base.Configs.UserSetConfigs.ConfigsControl.Instance.IsTel;


                    bool iTEmail = EbSite.Base.Configs.UserSetConfigs.ConfigsControl.Instance.IsEmail;
                    bool iTHeader = EbSite.Base.Configs.UserSetConfigs.ConfigsControl.Instance.IsHeader;

                    string TSTel = EbSite.Base.Configs.UserSetConfigs.ConfigsControl.Instance.TelHint;
                    string TSEmail = EbSite.Base.Configs.UserSetConfigs.ConfigsControl.Instance.EmailHint;
                    string TSHeader = EbSite.Base.Configs.UserSetConfigs.ConfigsControl.Instance.HeaderHint;

                    //bool IsUpload = EbSite.Base.Host.Instance.IsAllowUpload(mdCurrentUser.UserLevel.ToString());
                    //用户昵称|用户ID|手机号码|Email,
                    uinfo = string.Concat(AppStartInit.UserNiName, "|", AppStartInit.UserID, "|", iTel, "|",
                               iEmail, "|", iHeader, "|", iTTel, "|", iTEmail, "|", iTHeader, "|", TSTel, "|", TSEmail, "|", TSHeader);

                    if (!string.IsNullOrEmpty(uinfo))
                        EbSite.Base.Host.CacheApp.AddCacheItem(CacheKey, uinfo, 15, ETimeSpanModel.FZ, "CurrentUser");
                }
                context.Response.Write(uinfo);

            }
            else
            {
                context.Response.Write("no");
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}
