using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using EbSite.Base;
using EbSite.Base.EBSiteEventArgs;
using EbSite.BLL.GetLink;
using EbSite.Control;
using EbSite.Core.HttpModules;
using EbSite.Entity;
using Repeater = System.Web.UI.WebControls.Repeater;

namespace EbSite.Web.Pages
{
    public partial class list : EbSite.Base.Page.ILCSBase
    {

        protected int OrderBy
        {
            get
            {
                if (!Equals(rpGetClassList, null))
                {
                    if (rpGetClassList.OrderBy != EContentOrderBy.默认排序)
                    {
                        return (int)rpGetClassList.OrderBy;
                    }
                }

                if (!string.IsNullOrEmpty(Request["odb"]))
                {
                    return int.Parse(Request["odb"]);
                }
                else
                {
                    return 0;
                }
            }
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
        /// <summary>
        /// 获取当前分类的父对象,如果是一级分类，返回自身
        /// </summary>
        protected Entity.NewsClass PModel
        {
            get
            {
                if (Model.ParentID > 0)
                    return BLL.NewsClass.GetModelByCache(Model.ParentID);
                else
                    return Model;
            }
        }

        protected Entity.NewsClass Model = new Entity.NewsClass();
        protected void Page_Load(object sender, EventArgs e)
        {
            
            Base.EBSiteEventArgs.ClassPageLoadingEventArgs Argsing = new Base.EBSiteEventArgs.ClassPageLoadingEventArgs(HttpContext.Current, this.Page, GetSiteID, GetClassID);
            Base.EBSiteEvents.OnClassPageLoadingEvent(null, Argsing);

            if (!IsPostBack)
            {
                if (GetClassID > 0)
                {
                    Model = BLL.NewsClass.GetModelByCache(GetClassID);
                }
                else
                {
                    Model.ClassName = "所有分类";

                }
               
                inithead();
                bindinfo();
                intpages();
                //BindSubClass();

                Base.EBSiteEventArgs.ClassPageLoadEventArgs Args = new Base.EBSiteEventArgs.ClassPageLoadEventArgs(Model, HttpContext.Current, this.Page, GetSiteID, GetClassID);
                Base.EBSiteEvents.OnClassPageLoadEvent(null, Args);



               
            }
        }

        protected override void MobileMeta()
        {
            #region 添加手机版定向

            HtmlMeta meta = new HtmlMeta();
            meta.HttpEquiv = "mobile-agent";
            meta.Content = string.Concat("format=xhtml; url=", EbSite.Base.Host.Instance.MGetClassHref(Model.ID, PageIndex));
            this.Header.Controls.Add(meta);
            HtmlMeta meta2 = new HtmlMeta();
            meta2.HttpEquiv = "mobile-agent";
            meta2.Content = string.Concat("format=html5; url=", EbSite.Base.Host.Instance.MGetClassHref(Model.ID, PageIndex));
            this.Header.Controls.Add(meta2);
            HtmlMeta meta3 = new HtmlMeta();
            meta3.HttpEquiv = "mobile-agent";
            meta3.Content = string.Concat("format=wml; url=", EbSite.Base.Host.Instance.MGetClassHref(Model.ID, PageIndex));
            this.Header.Controls.Add(meta3);

            #endregion 添加手机版定向
        }

        private void rpGetClassList_ItemBound(object sender, RepeaterItemEventArgs e)
        {

            ClassRepeaterItemEventArgs cie = new ClassRepeaterItemEventArgs(e, HttpContext.Current, GetClassID, GetSiteID);
            Base.EBSiteEvents.OnClassItemBound(sender, cie);
            if (cie.IsStop)
                return;

            if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
            {
                Repeater rpContrent = e.Item.FindControl("rpContrent") as Repeater;
                if (!Equals(rpContrent, null))
                {
                    EbSite.Entity.NewsClass md = e.Item.DataItem as EbSite.Entity.NewsClass;
                    if (!Equals(md, null))
                    {
                        rpContrent.DataSource = NewsContentBll.GetListNewOfNewsClass(md.ID,12,false, false, "", GetSiteID);
                        rpContrent.DataBind();
                    }

                }

                Repeater rpSub = e.Item.FindControl("rpSub") as Repeater;
                if (!Equals(rpSub, null))
                {
                    EbSite.Entity.NewsClass md = e.Item.DataItem as EbSite.Entity.NewsClass;
                    if (!Equals(md, null))
                    {
                        rpSub.DataSource = EbSite.BLL.NewsClass.GetSubClass(md.ID, 0, GetSiteID);
                        rpSub.DataBind();
                    }

                }
                
            }



        }

        protected void bindinfo()
        {
            //绑定分类下的内容列表
            if (!Equals(rpGetClassList, null))
            {

                if (!rpGetClassList.IsDataFromClass)
                {

                    rpGetClassList.DataSource = NewsContentBll.GetListForListPage(PageIndex, iPageSize,
                                                                                         GetClassID, OrderBy, out iSearchCount, base.GetSiteID, this.Context);
                }
                else //IsDataFromClass 加入了rpGetSubClassList控件这个好像已经没有意义，完全可以用rpGetSubClassList代替
                {
                    rpGetClassList.ItemDataBound += new RepeaterItemEventHandler(rpGetClassList_ItemBound);
                    int pid = GetClassID;
                    if (rpGetClassList.ParentClassID > 0)
                        pid = rpGetClassList.ParentClassID;

                    rpGetClassList.DataSource = BLL.NewsClass.GetOrderListPages_SubClass(PageIndex, iPageSize,
                                                                                         pid, out iSearchCount,
                                                                                         base.GetSiteID);
                }


                //rpGetClassList.ItemDataBound += new RepeaterItemEventHandler(rpGetClassList_ItemBound);
                //int pid = GetClassID;
                //if (rpGetClassList.ParentClassID > 0)
                //    pid = rpGetClassList.ParentClassID;

                //rpGetClassList.DataSource = BLL.NewsClass.GetOrderListPages_SubClass(PageIndex, iPageSize,pid, out iSearchCount,base.GetSiteID);

                rpGetClassList.DataBind();
            }

            //绑定分类列表
            if (!Equals(rpGetSubClassList, null))
            {

                rpGetSubClassList.ItemDataBound += new RepeaterItemEventHandler(rpGetClassList_ItemBound);

                SubClassBindingEventArgs Args = new SubClassBindingEventArgs(GetClassID, "", this.Context, GetSiteID, "");
                Base.EBSiteEvents.OnSubClassBinding(null, Args);

                if (!Args.IsStopBind)
                {
                    if (rpGetSubClassList.ModelID == Guid.Empty)
                    {
                        rpGetSubClassList.DataSource = BLL.NewsClass.GetSubClass(GetClassID, 0, Args.Where, Args.OrderBy, GetSiteID);
                    }
                    else
                    {
                        rpGetSubClassList.DataSource = BLL.NewsClass.GetModelIdParentClass(0, Args.Where, Args.OrderBy, GetSiteID, rpGetSubClassList.ModelID);
                    }
                    rpGetSubClassList.DataBind();

                    if (rpGetSubClassList.Items.Count == 0)
                    {
                        rpGetSubClassList.Visible = false;
                    }
                }

               

            }

        }

        public int PageIndex
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
                if (!Equals(pgCtr, null) && pgCtr.PageSize > 0)
                {
                    return pgCtr.PageSize;
                }
                else
                {
                    return Base.Configs.ContentSet.ConfigsControl.Instance.PageSizeClass;
                }

            }

        }
        virtual protected void intpages()
        {
            if (!Equals(pgCtr, null))
            {

                //这有点不好理解,以重构
                //pgCtr.ReWritePatchUrl = string.Concat(GetClassID, "-{0}-", OrderBy, HrefFactory.GetInstance(GetSiteID).ClassLinkRw); //{0} 页码
                if (string.IsNullOrEmpty(pgCtr.ReWritePatchUrl)) //外面可以自定义
                {

                    if (UrlRules.ClassRuleHtmlNames2.ContainsKey(GetClassID))
                    {

                        pgCtr.ReWritePatchUrl = string.Concat(UrlRules.ClassRuleHtmlNames2[GetClassID],"{0}/");
                        pgCtr.FirstPageUrl = UrlRules.ClassRuleHtmlNames2[GetClassID];
                    }

                    else if (GetSiteID == 1)
                    {
                        //pgCtr.ReWritePatchUrl = string.Concat(IISPath, GetClassID, "-{0}-", OrderBy, HostApi.ClassLinkRw(GetSiteID)); //{0} 页码
                        pgCtr.ReWritePatchUrl = string.Concat(IISPath, HostApi.ClassLinkRw(GetSiteID).Replace("{分类ID}", GetClassID.ToString()).Replace("{排序类别}", OrderBy.ToString()).Replace("{页码}", "{0}"));

                        pgCtr.FirstPageUrl = HostApi.GetClassHref(Model.ID, Model.HtmlName, 1);
                    }
                           
                    else
                    {
                        //pgCtr.ReWritePatchUrl = string.Concat(IISPath, CurrentSite.SiteFolder, "/", GetClassID, "-{0}-", OrderBy, HostApi.ClassLinkRw(GetSiteID)); //{0} 页码
                        pgCtr.ReWritePatchUrl = string.Concat(IISPath, CurrentSite.SiteFolder, "/", HostApi.ClassLinkRw(GetSiteID).Replace("{分类ID}", GetClassID.ToString()).Replace("{排序类别}", OrderBy.ToString()).Replace("{页码}", "{0}"));
                        pgCtr.FirstPageUrl = HostApi.GetClassHref(Model.ID, Model.HtmlName, 1);
                    }
                            

                    // /6-{0}-0{分类ID}a{页码}b{排序类别}l.html
                }


                pgCtr.AllCount = iSearchCount;
                pgCtr.PageSize = iPageSize;
                pgCtr.OtherPram = string.Format("cid,{0}", GetClassID);
                pgCtr.CurrentClass = "CurrentPageCoder";
                pgCtr.ParentClass = "PagesClass";
            }

        }

        private void inithead()
        {
            ClassMetaEventArgs Args = new ClassMetaEventArgs(base.SeoTitle, base.SeoKeyWord, base.SeoDes, GetClassID, PModel.SiteID, this.Context);
            Base.EBSiteEvents.OnClassMeta(null, Args);
            if (!Args.StopSytemMeta)
            {

                string seoClassTitle = Model.SeoTitle;// SeoSite.SeoClassTitle;
                if (string.IsNullOrEmpty(seoClassTitle))
                    seoClassTitle = SeoSite.SeoClassTitle;

                string seoKeyWord = Model.SeoKeyWord;//SeoSite.SeoClassKeyWord;
                if (string.IsNullOrEmpty(seoKeyWord))
                    seoKeyWord = SeoSite.SeoClassKeyWord;

                string seoDes = Model.SeoDescription;
                if (string.IsNullOrEmpty(seoDes))
                    seoDes = SeoSite.SeoClassDes;

                //string seoDes = SeoSite.SeoClassDes;
                GetSeoWord(ref seoClassTitle, ref seoKeyWord, ref seoDes, Model.ClassName, Model.ID);
                if (!Equals(Model.ClassName, "所有分类"))
                    base.SeoTitle = seoClassTitle;
                else
                {
                    base.SeoTitle = GetSeoWord(SeoSite.SeoSiteIndexTitle, "");
                }
                base.SeoKeyWord = seoKeyWord;
                base.SeoDes = seoDes;
            }
            else
            {
                base.SeoTitle = Args.SeoTitle;
                base.SeoKeyWord = Args.SeoKeyWord;
                base.SeoDes = Args.SeoDes;
            }

        }
        override protected string KeepUserState()
        {
            return base.KeepUserState(string.Format("ebclassid={0}", GetClassID));
        }
        protected string GetNav()
        {
            return GetNav(">>", true, 0);
        }
        protected string GetNav(string Nav)
        {
            return GetNav(Nav, true, 0);
        }
        protected string GetNav(string Nav, int FilterClassID)
        {
            return GetNav(Nav, true, FilterClassID);
        }
        protected string GetNav(string Nav, bool IsAddCurrent)
        {
            return GetNav(Nav, IsAddCurrent, 0);
        }
        override protected string GetNav(string Nav, bool IsAddCurrent, int FilterClassID)
        {
            return BLL.NewsClass.GetNav(Nav, GetClassID, IsAddCurrent, GetSiteID, FilterClassID);
        }


    }


}
