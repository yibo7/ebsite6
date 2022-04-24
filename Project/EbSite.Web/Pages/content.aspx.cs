using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Amib.Threading;
using EbSite.BLL.User;
using EbSite.Base;
using EbSite.BLL;
using EbSite.Core;
using EbSite.Entity;

namespace EbSite.Web.Pages
{
    public partial class content : EbSite.Base.Page.ILCSBase
    {
        protected Entity.NewsContent Model = new Entity.NewsContent();

        protected virtual EbSite.Base.ThemeType eThemeType
        {
            get { return ThemeType.PC; }
        }

        protected string BarCodeImgUrl
        {
            get { return ""; //已经不使用，请不要使用
            }
        }
        protected Entity.NewsContent UpModel
        {
            get
            {
                Entity.NewsContent mdModel = NewsContentBll.UpModel(iRequestID, Fields, base.GetSiteID);

                if (!Equals(mdModel, null))
                    return mdModel;
                else
                {
                    return Model;
                }
            }
        }
        override protected EbSite.BLL.NewsContentSplitTable NewsContentBll
        {
            get
            {
                if (!Equals(GetModelID, Guid.Empty))
                {
                    return AppStartInit.GetNewsContentInst(GetModelID,GetSiteID);
                }
                return base.NewsContentBll;
            }
        }
        protected Entity.NewsContent NextModel
        {
            get
            {
                Entity.NewsContent mdNextModel = NewsContentBll.NextModel(iRequestID, Fields, base.GetSiteID);

                if (!Equals(mdNextModel, null))
                    return mdNextModel;
                else
                {
                    return Model;
                }

            }
        }
        /// <summary>
        /// 上一记录，下一记录 要查询的字段，可由用户后台设置
        /// </summary>
        protected string Fields = "id,newstitle,ClassName,addtime,classid,HtmlName";
        protected EbSite.Base.EntityAPI.MembershipUserEb UserInfos
        {
            get
            {
                Base.EntityAPI.MembershipUserEb _UserInfos =  MembershipUserEb.Instance.GetEntity(Model.UserID);
                if (_UserInfos!=null)
                    return _UserInfos;
                else
                {
                    return new Base.EntityAPI.MembershipUserEb();
                }
            }
        }

        protected string ShowInfo = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        { 
            Base.EBSiteEventArgs.ContentPageLoadingEventArgs Argsing = new Base.EBSiteEventArgs.ContentPageLoadingEventArgs(HttpContext.Current, this.Page, GetSiteID, iRequestID, GetClassID);
            Base.EBSiteEvents.OnContentPageLoading(null, Argsing);
            if (!IsPostBack)
            {
                if (iRequestID > -1)
                {
                    Model = NewsContentBll.GetModel(iRequestID, GetClassID, GetSiteID);

                    #region 展示内容前的一些处理

                    if (Equals(Model, null))
                    {
                        if (Base.Configs.SysConfigs.ConfigsControl.Instance.IsOpen404Log)
                        {
                            IWorkItemResult wir = ThreadPoolManager.Instance.QueueWorkItem(new WorkItemCallback(Host.Instance.Write404LogMsg), string.Format("由于内容Model为null引发的404,{0}", GetRequestInfo()));
                        }
                        //EbSite.Log.Factory.GetInstance().ErrorLog(string.Format("由于内容Model为null引发的404,发生在:{0}", Request.RawUrl));
                        Response.Status = "404 Not Found";
                        Response.End();
                    }
                    else if (!Model.IsAuditing)
                    {
                        //Tips("未审核内容","所访问的内容未审核，请等待审核后再访问！");
                        //EbSite.Log.Factory.GetInstance().ErrorLog(string.Format("由于内容未审核引发的404,发生在:{0}",Request.RawUrl));

                        AdminPrincipal apAdmin = AppStartInit.CheckAdmin(); //只允许管理员预览未审核的文章
                        if (Equals(apAdmin, null))
                        {
                            if (Base.Configs.SysConfigs.ConfigsControl.Instance.IsOpen404Log)
                            {
                                IWorkItemResult wir = ThreadPoolManager.Instance.QueueWorkItem(new WorkItemCallback(Host.Instance.Write404LogMsg), string.Format("由于内容未审核引发的404,{0}", GetRequestInfo()));
                            }

                            Response.Status = "404 Not Found";
                            Response.End();
                        }

                    }


                    #endregion
                     
                    BindPageInfo();

                    inithead();

                    Base.EBSiteEventArgs.ContentPageLoadEventArgs Args = new Base.EBSiteEventArgs.ContentPageLoadEventArgs(Model, HttpContext.Current, this.Page, GetSiteID, iRequestID, GetClassID);
                    Base.EBSiteEvents.OnContentPageLoadEvent(null, Args);
                    
 
                }

                BindRemark();


            }
        }

        private string GetRequestInfo()
        {
           string   path = Request.RawUrl;
            string hostIP = Request.ServerVariables["REMOTE_ADDR"];
            string useragent = Request.ServerVariables["http_user_agent"];
            string fullurl = Request.Url.AbsoluteUri;

            return string.Format("发生页面{0},IP{1}\n来源:{2}\nUserAgent:{3}", path, hostIP, fullurl, useragent);
        }
        override protected void MobileMeta()
        {
            #region 添加手机版定向

            HtmlMeta meta = new HtmlMeta();
            meta.HttpEquiv = "mobile-agent";
            meta.Content = string.Concat("format=xhtml; url=", EbSite.Base.Host.Instance.MGetContentLink(Model.ID, Model.ClassID, 0));
            this.Header.Controls.Add(meta);
            HtmlMeta meta2 = new HtmlMeta();
            meta2.HttpEquiv = "mobile-agent";
            meta2.Content = string.Concat("format=html5; url=", EbSite.Base.Host.Instance.MGetContentLink(Model.ID, Model.ClassID, 0));
            this.Header.Controls.Add(meta2);
            HtmlMeta meta3 = new HtmlMeta();
            meta3.HttpEquiv = "mobile-agent";
            meta3.Content = string.Concat("format=wml; url=", EbSite.Base.Host.Instance.MGetContentLink(Model.ID, Model.ClassID, 0));
            this.Header.Controls.Add(meta3);

            #endregion 添加手机版定向
        }
        protected Entity.ContentPageInfo CPINext;
        protected Entity.ContentPageInfo CPIUP;
        private string PageTitle;
        private void BindPageInfo()
        {
            int pageindex = GetContentPageIndex;
            //bool isHtml = true; //是否html,从2016-11-24 开始，不再支持UBB
            ////不是很精准，暂时这样判断
            //if (Model.ContentInfo.IndexOf("<") > -1&& Model.ContentInfo.IndexOf("[/code]") == -1)
            //{
            //    isHtml = true;
            //}
            
            if (!string.IsNullOrEmpty(Model.ContentInfo) && (Model.ContentInfo.IndexOf(AppStartInit.ContentPageSplit)>-1))//如果是分页
            {
                List<Entity.ContentPageInfo> lst = NewsContentBll.GetPageInfos(Model.ContentInfo, ref ShowInfo, Model.ID, Model.ClassID, pageindex, eThemeType);
               
                if (lst.Count > 1)
                {

                    int nextindex = pageindex + 1;
                    if (nextindex < lst.Count)
                    {
                        CPINext = lst[nextindex];
                    }
                    int upindex = pageindex - 1;
                    if (upindex >=0)
                    {
                        CPIUP = lst[upindex];
                    }

                    if (!Equals(rpPageInfo, null))
                    {
                        rpPageInfo.DataSource = lst;
                        rpPageInfo.DataBind();
                    }

                }

                ShowInfo = ShowInfo.Replace("[eba]", "").Replace("[/eba]", "");
                 
            }
            else if(pageindex==0) //如果非分页，当然pageindex不能大于0,大于0当作404处理
            {
                ShowInfo = Model.ContentInfo;// isHtml? Model.ContentInfo:UBB.UBBToHtml(Model.ContentInfo);

                if (!string.IsNullOrEmpty(ShowInfo) &&(ShowInfo.IndexOf("[eba]") > -1))//非分页模式下可以是描点跳转,如果是，执行以下处理
                {
                    List<string> strsList = NewsContentBll.GetContentTitles(ShowInfo);

                    List<Entity.ContentPageInfo> lst = new List<ContentPageInfo>();

                    for (int i=0; i<strsList.Count;i++)
                    {
                        Entity.ContentPageInfo mdInfo = new ContentPageInfo();
                        mdInfo.Title =Core.Strings.GetString.CleanHtml(strsList[i]);
                        mdInfo.Href = string.Format("javascript:gotoeba({0})",i);
                        lst.Add(mdInfo);
                    }

                    if (!Equals(rpPageInfo, null))
                    {
                        rpPageInfo.DataSource = lst;
                        rpPageInfo.DataBind();
                    }
                    
                    ShowInfo = ShowInfo.Replace("[eba]", "<a class='ebacss'></a>").Replace("[/eba]", "");
                }
                
            }
            else
            {
                
                Response.Status = "404 Not Found";
                Response.End();
            }

            ////如果是手机版，还要将内容处理一下，如果将图片替换成小图片
            //if (eThemeType == ThemeType.MOBILE && !string.IsNullOrEmpty(ShowInfo))
            //{
            //    ShowInfo = HostApi.GetMobileContent(ShowInfo);
            //}

            Base.EBSiteEventArgs.ContentShowEventArgs Args = new Base.EBSiteEventArgs.ContentShowEventArgs(HttpContext.Current, this.Page, GetSiteID, iRequestID, GetClassID, ShowInfo, eThemeType);
            Base.EBSiteEvents.OnContentShowEvent(null, Args);

            ShowInfo =  Args.ShowInfo;

        }
        protected string GetNav(string Nav)
        {
            return BLL.NewsClass.GetNav(Nav, Model.ClassID, true, GetSiteID,0);
        }
        protected string GetNav(string Nav, bool IsAddIndex)
        {
            return BLL.NewsClass.GetNav(Nav, Model.ClassID, IsAddIndex, GetSiteID, 0);
        }
        override protected string GetNav(string Nav, bool IsAddIndex, int FilterClassID)
        {
            return BLL.NewsClass.GetNav(Nav, Model.ClassID, IsAddIndex, GetSiteID, FilterClassID);
        }
        private void inithead()
        {
            //string seoClassTitle = Base.Configs.ContentSet.ConfigsControl.Instance.SeoContentTitle;
            //string seoKeyWord = Base.Configs.ContentSet.ConfigsControl.Instance.SeoContentKeyWord;
            //string seoDes = Base.Configs.ContentSet.ConfigsControl.Instance.SeoContentDes;

            string seoClassTitle = SeoSite.SeoContentTitle;
            string seoKeyWord = Model.Keywords;
            if(string.IsNullOrEmpty(seoKeyWord))
                seoKeyWord = SeoSite.SeoContentKeyWord;

            string seoDes = Model.Description;

            if(string.IsNullOrEmpty(seoDes))
                seoDes = SeoSite.SeoContentDes;


            string newstitle = Model.NewsTitle;
            if (!string.IsNullOrEmpty(PageTitle))
                newstitle = string.Concat(newstitle, "_", PageTitle);

                GetSeoWord(ref seoClassTitle, ref seoKeyWord, ref seoDes, newstitle, Model.ClassName, Model.ClassID, Model.TagIDs, Model.ContentInfo);
            base.SeoTitle = seoClassTitle;

            base.SeoKeyWord = seoKeyWord;
            base.SeoDes = seoDes;
            
            
        }
        override protected string KeepUserState()
        {
            return base.KeepUserState(string.Format("ebid={0}&ebcid={1}", iRequestID,GetClassID));
        }

        protected int iRequestID
        {
            get
            {
                if (!string.IsNullOrEmpty(Request["id"]))
                {
                    return int.Parse(Request["id"]);
                }
                else
                {

                    return -1;
                }
            }
        }
        #region 评论处理

        private void BindRemark()
        {
            if (!Equals(rpComment, null))
            {
                List<EbSite.Entity.Remark> lst = EbSite.BLL.Remark.GetModelList(rpComment.RemarkClassID, true, 1, rpComment.PageSize, GetClassID, iRequestID);

                rpComment.DataSource = lst;
                rpComment.DataBind();
            }

        }
        protected void rpComment_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            //HeaderTemplate，，ItemTemplate，SeparatorTemplate）
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Repeater rep = e.Item.FindControl("rpCommentSubList") as Repeater;//找到里层的repeater对象
                EbSite.Entity.Remark row = (EbSite.Entity.Remark)e.Item.DataItem;//找到分类Repeater关联的数据项 
                List<EbSite.Entity.RemarkSublist> lst = EbSite.BLL.RemarkSublist.GetModelList(row.ID);
                if (lst.Count > 0)
                {
                    rep.DataSource = lst;
                    rep.DataBind();
                }


            }
        }

        #endregion



    }

    

}
