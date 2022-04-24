using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Web;
using System.Web.UI;
using EbSite.Base.Page;
using EbSite.Base.Static;
using EbSite.BLL.ModulesBll;
using EbSite.Control;
using EbSite.Entity.Module;

namespace EbSite.Base.Modules
{
    public abstract class MPageForUerBase : MPage
    {
       //new protected string ThemeCss
       // {
       //     get { return ""; }
       // }
        /// <summary>
        /// 获取当前模块所在的皮肤目录名称
        /// </summary>
        protected string ModuleThemeName
        {
            get
            {
                string CacheKey = string.Concat("MTN", Request.Path);
                string obdata = Host.CacheRawApp.GetCacheItem<string>(CacheKey, "MPageForUerBase");// as string;
                if (obdata == null)
                {
                    obdata = EbSite.Core.Strings.GetString.CutMiddleStr(Request.Path, "themes/", "/data");
                    if (!Equals(obdata, null))
                        Host.CacheRawApp.AddCacheItem(CacheKey, obdata, 1, ETimeSpanModel.XS, "MPageForUerBase");
                }

                return obdata;

            }
        }
        /// <summary>
        /// 获取当前模块所属性的站点ID
        /// </summary>
      virtual  protected int ModuleSiteID
        {
            get
            {
                return EbSite.BLL.Sites.Instance.GetSiteIDByThemePath(ModuleThemeName);
            }
        }
        override public EbSite.Entity.Sites CurrentSite
        {
            get
            {
                return HostApi.GetSite(ModuleSiteID);
            }
        }
        /// <summary>
        /// 检测当前用户是否具有某个权限ID
        /// </summary>
        /// <param name="LimitID">权限Id</param>
        /// <returns></returns>
        override protected bool IsHaveLimit(string LimitID)
        {

            return HostApi.IsHaveLimitForUser(EbSite.Base.AppStartInit.UserID, int.Parse(LimitID), ModuleID);
        }
        override protected void InitMasterCtr()
        {

        }
        override protected bool IsCloseTags
        {
            get
            {
                return true;
            }
        }

        //protected override void BindTopTags()
        //{
        //}

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
