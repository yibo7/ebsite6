using System;
using System.Web.UI.HtmlControls;
using EbSite.BLL;
using EbSite.BLL.GetLink;
using EbSite.Base;

namespace EbSite.Web.Pages
{
    public partial class tags : EbSite.Base.Page.CustomPage
    {
        protected int OrderBy
        {
            get
            {
                if (!string.IsNullOrEmpty(Request["odb"]))
                {
                    return int.Parse(Request["odb"]);
                }
                else
                {
                    return 1;
                }
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                inithead();
                DataBind();
                intpages();
               

               

            }
        }
        /// <summary>
        /// 手机版不需要输出适配
        /// </summary>
        override protected void MobileMeta()
        {
            #region 添加手机版定向

            HtmlMeta meta = new HtmlMeta();
            meta.HttpEquiv = "mobile-agent";
            meta.Content = string.Concat("format=xhtml; url=", EbSite.Base.Host.Instance.MGetTagsHref(this.pgCtr.PageIndex));
            this.Header.Controls.Add(meta);
            HtmlMeta meta2 = new HtmlMeta();
            meta2.HttpEquiv = "mobile-agent";
            meta2.Content = string.Concat("format=html5; url=", EbSite.Base.Host.Instance.MGetTagsHref(this.pgCtr.PageIndex));
            this.Header.Controls.Add(meta2);
            HtmlMeta meta3 = new HtmlMeta();
            meta3.HttpEquiv = "mobile-agent";
            meta3.Content = string.Concat("format=wml; url=" , EbSite.Base.Host.Instance.MGetTagsHref(this.pgCtr.PageIndex));
            this.Header.Controls.Add(meta3);

            #endregion 添加手机版定向
        }
        protected string GetOrbderByClass(int odb)
        {

            string sCss = "";

            if (odb == OrderBy)
            {
                sCss = "thisiterm";
            }

            return sCss;
        }
        private void DataBind()
        {

            this.rpList.DataSource = TagKey.GetListPages(PageIndex, iPageSize, iTop, out iSearchCount, base.GetSiteID);
            this.rpList.DataBind();
        }
        private int PageIndex
        {
            get
            {
                if (!string.IsNullOrEmpty(Request.QueryString["p"]))
                    return Convert.ToInt32(Request.QueryString["p"]);
                else
                    return 1;
            }
        }

        protected int iSearchCount = 0;
        protected int iPageSize
        {
            get
            {

                 if (pgCtr.PageSize > 0)
                {
                    return pgCtr.PageSize;
                }
                else
                {
                    return Base.Configs.ContentSet.ConfigsControl.Instance.PageSizeTagList;
                }
                
            }

        }
        private int iTop
        {
            get
            {
                if (!string.IsNullOrEmpty(Request["odb"]))
                {
                    return int.Parse(Request["odb"]);
                }
                return 1;
            }
        }
        virtual protected void intpages()
        {
 

            pgCtr.ReWritePatchUrl = string.Concat(IISPath,"{0}", HostApi.TaglistLinkRw(GetSiteID)); //{0} 页码
            pgCtr.AllCount = iSearchCount;
            pgCtr.PageSize = iPageSize;
            pgCtr.CurrentClass = "CurrentPageCoder";
            pgCtr.ParentClass = "PagesClass"; 
        }

        private void inithead()
        {
            
            base.SeoTitle = GetSeoWord(SeoSite.SeoTagIndexTitle, "");
            base.SeoKeyWord = GetSeoWord(SeoSite.SeoTagIndexKeyWord, "");
            base.SeoDes = GetSeoWord(SeoSite.SeoTagIndexDes, "");

        }

        protected string GetNav(string Nav)
        {
            return GetNav(Nav, true, 0);
        }
        protected string GetNav(string Nav, bool IsAddCurrent)
        {
            return GetNav(Nav, IsAddCurrent, 0);
        }
        override protected string GetNav(string Nav, bool IsAddCurrent, int FilterClassID)
        {
            return string.Concat("<a href='", BLL.GetLink.LinkOrther.Instance.GetInstance(GetSiteID).GetMainIndexHref(), "'>", SiteName, "</a>", Nav, "<a href='", Request.RawUrl, "'>", "标签列表</a>");
        }
    }
}
