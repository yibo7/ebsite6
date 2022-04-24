using System;
using System.Web;
using Amib.Threading;
using EbSite.BLL.GetLink;
using EbSite.Base;
using EbSite.Base.Configs.SysConfigs;
using EbSite.Core.Strings;
using EbSite.Pages;

namespace EbSite.Web.Pages
{
    public partial class Search : EbSite.Base.Page.SearchBase
    {
        /// <summary>
        /// 搜索类别 0为内容,1为标签
        /// </summary>
        protected int SearchType
        {
            get
            {
                if (!string.IsNullOrEmpty(Request.QueryString["ty"]))
                    return Convert.ToInt32(Request.QueryString["ty"]);
                else
                    return 0;
            }
        }
        private void bindinfo()
        {
            int iCount = 0;
            
            rpGetList.DataSource = Query(out  iCount, ""); 
            rpGetList.DataBind();
            base.iSearchCount = iCount;
            intpages();
            
            
        }
        
        protected void Page_Load(object sender, EventArgs e)
        {
            
            base.KeyWord = Request.QueryString["k"];
            if (!IsPostBack && !string.IsNullOrEmpty(KeyWord))
            {

                if (SearchType == 1)
                {
                    
                    Response.Redirect(string.Concat(IISPath, Base.PageLink.GetBaseLinks.Get(base.GetSiteID).TagsSearchListLinkRw, "?tg=", KeyWord,"&site=",GetSiteID));
                }
                bindinfo();
                SeoTitle = string.Concat(KeyWord, "-", SiteName);


            }
        }
        private void intpages()
        {
            if (!Equals(pgCtr, null))
            {
                pgCtr.AllCount = iSearchCount;
                pgCtr.PageSize = iPageSize;
                pgCtr.OtherPram = string.Format("k,{0}|ty,{1}|site,{2}", base.KeyWord, SearchType, base.HostApi.GetSiteID);
                pgCtr.CurrentClass = "CurrentPageCoder";
                pgCtr.ParentClass = "PagesClass";
            }
           

        }


    }
}
