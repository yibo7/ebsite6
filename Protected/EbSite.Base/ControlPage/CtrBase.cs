using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;
using EbSite.Base.Static;

namespace EbSite.Base.ControlPage
{
    abstract public class CtrBase : System.Web.UI.UserControl
    {

        #region 模块页面专用的
        /// <summary>
        /// 获取当前模块所在的皮肤目录名称
        /// </summary>
        protected string ModuleThemeName
        {
            get
            {
                string CacheKey = string.Concat("MTN", Request.Path);
                string obdata = Host.CacheRawApp.GetCacheItem<string>(CacheKey, "CtrBase");// as string;
                if (obdata == null)
                {
                    obdata = EbSite.Core.Strings.GetString.CutMiddleStr(Request.Path, "themes/", "/data");
                    if (!Equals(obdata, null))
                        Host.CacheRawApp.AddCacheItem(CacheKey, obdata, 1, ETimeSpanModel.XS, "CtrBase");
                }

                return obdata;

            }
        }
        /// <summary>
        /// 获取当前模块所属性的站点ID
        /// </summary>
        protected int ModuleSiteID
        {
            get
            {
                return EbSite.BLL.Sites.Instance.GetSiteIDByThemePath(ModuleThemeName);
            }
        }

        #endregion

        public EbSite.Entity.Sites CurrentSite
        {
            get
            {
                return Host.Instance.CurrentSite;
            }
        }

        /// <summary>
        /// 获取当前站点ID，要求当前页面的url有参数site,没有参数site将获取后台默认站点
        /// </summary>
        protected int GetSiteID
        {
            get
            {
                return Host.Instance.GetSiteID;
            }
        }
        ///// <summary>
        ///// YHL 2013-05-07 每个站点的描述
        ///// </summary>
        //protected EbSite.Base.EntityCustom.SeoSite SeoSite
        //{
        //    get
        //    {
        //        List<EbSite.Base.EntityCustom.SeoSite> ls = EbSite.BLL.SeoSites.Instance.FillList();
        //        int siteid = GetSiteID;
        //        List<EbSite.Base.EntityCustom.SeoSite> md = (from i in ls where i.SiteID == siteid select i).ToList();
        //        if (md.Count > 0)
        //            return md[0];
        //        return null;
        //    }
        //}
        /// <summary>
        /// 功能说明或相关说明
        /// </summary>
        abstract public string TipsText { get; }
        /// <summary>
        /// 获取来路地址
        /// </summary>
        protected string GetFromURL
        {
            get
            {
                return Request.UrlReferrer.ToString();
            }
        }
        /// <summary>
        /// 是否关闭左框架，目前只应用在用户后台
        /// </summary>
        abstract public bool IsCloseLeft { get; }
        /// <summary>
        /// 是否关闭左框架，目前只应用在用户后台
        /// </summary>
        abstract public bool IsCloseTagsTitle { get; }
        /// <summary>
        /// 是否关闭左框架，目前只应用在用户后台
        /// </summary>
        abstract public bool IsCloseTagsItem { get; }
        /// <summary>
        /// 当前页面访问权限ID,默认为空不作权限验证
        /// </summary>
        public virtual string Permission
        {
            get
            {
                return "";
            }
        }
        
        protected void CloseWinBox()
        {
            EbSite.Core.Strings.cJavascripts.RunClientJs(this, "ColseGreyBox();");
        }
        protected void RunJs(string js)
        {
            string sJs = string.Concat("$(document).ready(function() {", js, "});");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "okjs", sJs, true);
        }

        //YHL 2014-1-17 配合 手机没登录跳转 手机登录 页面
        protected bool CurrentUserIsLogin
        {
            get
            {
                string UserName = AppStartInit.UserName;
                string UserPass = AppStartInit.UserPass;
                bool islogin = false;
                if (!string.IsNullOrEmpty(UserName) && !string.IsNullOrEmpty(UserPass))
                {
                    //由于cookie里的密码已经加密，所以这里false
                    islogin = EbSite.BLL.User.MembershipUserEb.Instance.ValidateUserSimple(UserName, UserPass);

                }
                return islogin;
            }
        }

        /// <summary>
        /// 验证当前用户是否已经登录,如果还未登录，跳转到登录页面 控件,页面基类都存在此代码，如果改动要同步改动
        /// </summary>
        virtual protected void CheckCurrentUserIsLogin()
        {
            if (!CurrentUserIsLogin)
            {
                EbSite.Base.AppStartInit.UserLoginReurl();
            }
        }


    }
}
