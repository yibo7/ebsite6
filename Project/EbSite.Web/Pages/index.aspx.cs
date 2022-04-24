using System;
using System.Web;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using EbSite.BLL;
using EbSite.BLL.GetLink;
using EbSite.Base;
using EbSite.Base.EBSiteEventArgs;
using EbSite.ControlData;

namespace EbSite.Web.Pages
{
    public partial class index : EbSite.Base.Page.ILCSBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                inithead();
                //首页也可以绑定所有数据列表
                bindinfo();
                
                Base.EBSiteEventArgs.IndexPageLoadEventArgs Args = new Base.EBSiteEventArgs.IndexPageLoadEventArgs(GetSiteID, this.Page);
                Base.EBSiteEvents.OnIndexPageLoadEvent(null, Args);



            }

        }

        protected override void MobileMeta()
        {
            #region 添加手机版定向

            HtmlMeta meta = new HtmlMeta();
            meta.HttpEquiv = "mobile-agent";
            meta.Content = string.Concat("format=xhtml; url=" + Host.Instance.Domain, EbSite.Base.Host.Instance.MGetIndexHref());
            this.Header.Controls.Add(meta);
            HtmlMeta meta2 = new HtmlMeta();
            meta2.HttpEquiv = "mobile-agent";
            meta2.Content = string.Concat("format=html5; url=" + Host.Instance.Domain, EbSite.Base.Host.Instance.MGetIndexHref());
            this.Header.Controls.Add(meta2);
            HtmlMeta meta3 = new HtmlMeta();
            meta3.HttpEquiv = "mobile-agent";
            meta3.Content = string.Concat("format=wml; url=" + Host.Instance.Domain, EbSite.Base.Host.Instance.MGetIndexHref());
            this.Header.Controls.Add(meta3);

            #endregion 添加手机版定向
        }

        private void bindinfo()
        {
            if (!Equals(rpGetClassList, null))
            {

                rpGetClassList.ItemDataBound += new RepeaterItemEventHandler(rpGetClassList_ItemBound);
                if (rpGetClassList.DataType == RepeaterIndexType.内容列表)
                {
                    //rpGetClassList.DataSource =EbSite.Base.AppStartInit.NewsContentInstDefault.GetListForListPage(PageIndex, iPageSize, 0, 0, out iSearchCount, GetSiteID, this.Context);
                    int icount = 0;
                    rpGetClassList.DataSource = EbSite.BLL.NewsContent.Un_GetListPages(PageIndex, iPageSize, "", "", true,
                                                                          false, out icount, base.GetSiteID, BLL.DataSettings.Content.Instance.GetConfigCurrent.ContentTables, "", this.Context);

                    rpGetClassList.DataBind();
                    iSearchCount = icount;
                }
                else
                {
                    int pid = Core.Utils.StrToInt(Request["pid"], 0);

                    string sWhere = string.Empty;
                    string sOrderBy = string.Empty;
                    SubClassBindingEventArgs Args = new SubClassBindingEventArgs(pid, sWhere, this.Context, GetSiteID, sOrderBy);
                    Base.EBSiteEvents.OnSubClassBinding(null, Args);
                    if (!Args.IsStopBind)
                    {
                        if (pid > 0)
                        {
                            rpGetClassList.DataSource = BLL.NewsClass.GetSubClass(pid, 0, sWhere, sOrderBy, GetSiteID);
                        }
                        else
                        {
                            string GetFromIds = rpGetClassList.ClassIDs;//用逗号分开
                            if (!string.IsNullOrEmpty(GetFromIds))
                            {
                                rpGetClassList.DataSource = BLL.NewsClass.GetParentClass(0, string.Concat("id in(", GetFromIds, ")"), sOrderBy, GetSiteID);
                                //rpGetClassList.ItemDataBound += new RepeaterItemEventHandler(rpGetClassList_ItemBoundContent);
                            }
                            else
                            {
                                rpGetClassList.DataSource = BLL.NewsClass.GetParentClass(0, sWhere, sOrderBy, GetSiteID);
                                //rpGetClassList.ItemDataBound += new RepeaterItemEventHandler(rpGetClassList_ItemBoundContent);
                            }
                            rpGetClassList.ItemDataBound += new RepeaterItemEventHandler(rpGetClassList_ItemBoundContent);
                        }

                        rpGetClassList.DataBind();
                    }



                }


                intpages();
            }

        }
        public void rpGetClassList_ItemBound(object sender, RepeaterItemEventArgs e)
        {
            Base.EBSiteEvents.OnIndexItemBound(sender, e);

        }
        public void rpGetClassList_ItemBoundContent(object sender, RepeaterItemEventArgs e)
        {

            if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
            {
                Repeater rpContent = e.Item.FindControl("rpContent") as Repeater;
                if (!Equals(rpContent, null))
                {
                    EbSite.Entity.NewsClass md = e.Item.DataItem as EbSite.Entity.NewsClass;
                    if (!Equals(md, null))
                    {
                        NewsContentSplitTable NewsContentInst = EbSite.Base.AppStartInit.GetNewsContentInst(md.ID);
                        rpContent.DataSource = NewsContentInst.GetListHot(md.ID, 16, "n", true, false, "", GetSiteID);
                        rpContent.DataBind();
                    }

                }
            }

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
        private int iPageSize
        {
            get
            {
                if (!Equals(pgCtr, null)&&pgCtr.PageSize > 0)
                {
                    return pgCtr.PageSize;
                }
                else
                {
                    return Base.Configs.ContentSet.ConfigsControl.Instance.PageSizeClass;
                }

            }

        }
        private void intpages()
        {
            if (!Equals(pgCtr, null))
            {

                //这有点不好理解,以重构
                if (string.IsNullOrEmpty(pgCtr.ReWritePatchUrl)) //外面可以自定义
                    pgCtr.ReWritePatchUrl = string.Concat(IISPath, "{0}-", Base.Configs.ContentSet.ConfigsControl.Instance.IndexPathRw); //{0} 页码
                pgCtr.FirstPageUrl = IISPath;
                pgCtr.AllCount = iSearchCount;
                pgCtr.PageSize = iPageSize;
                pgCtr.CurrentClass = "CurrentPageCoder";
                pgCtr.ParentClass = "PagesClass";
            }

        }

        private void inithead()
        {
            //base.SeoTitle = GetSeoWord(Base.Configs.ContentSet.ConfigsControl.Instance.SeoSiteIndexTitle, "");
            //base.SeoKeyWord = GetSeoWord(Base.Configs.ContentSet.ConfigsControl.Instance.SeoSiteIndexKeyWord, "");
            //base.SeoDes = GetSeoWord(Base.Configs.ContentSet.ConfigsControl.Instance.SeoSiteIndexDes, "");

            base.SeoTitle = GetSeoWord(SeoSite.SeoSiteIndexTitle, "");
            base.SeoKeyWord = GetSeoWord(SeoSite.SeoSiteIndexKeyWord, "");
            base.SeoDes = GetSeoWord(SeoSite.SeoSiteIndexDes, "");
        }
        protected string GetNav(string Nav, bool IsAddCurrent)
        {
            return EbSite.BLL.NewsClass.GetNav(Nav, 0, true, GetSiteID, 0);
        }
        override protected string GetNav(string Nav, bool IsAddCurrent, int FilterClassID)
        {
            return EbSite.BLL.NewsClass.GetNav("", 0, true, GetSiteID, FilterClassID);
        }

    }
}
