//using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Web;
//using System.Web.Mvc;
//using System.Web.Mvc.Html;
//using System.Web.Optimization;
//using System.Web.UI;
//using System.Web.UI.WebControls;
//using EbSite.Base;
//using EbSite.Base.Configs.SysConfigs;
//using EbSite.Base.ExtWidgets.WidgetsManage;
//using EbSite.Base.Static;
//using EbSite.Control.xsPage;
//using EbSite.Core.DataStore;

//namespace EbSite.Mvc
//{
//    public class WebViewPage<T> : System.Web.Mvc.WebViewPage<T> where T : Models.ModelBae
//    {
        
//        public WebViewPage()
//        {
            
//        }

//        #region 常用属性

//        public Host HostApi
//        {
//            get
//            {
//                return Host.Instance;
//            }
//        }
//        public string ThemePage
//        {
//            get
//            {
//                return string.Concat(HostApi.CurrentSite.ThemesPath("pages"), "/");
//            }
//        }
//        public string MThemePage
//        {
//            get
//            {
//                return HostApi.CurrentSite.MGetCurrentPageUrl("");
//            }
//        }
//        public string ThemeCss
//        {
//            get
//            {
//                return string.Concat(Host.Instance.CurrentSite.ThemesPath("css"), "/");
//            }
//        }
//        public string MThemeCss
//        {
//            get
//            {
//                return string.Concat(HostApi.CurrentSite.MThemesPath("css"), "/");
//            }
//        }
//        public int CountUserOnline
//        {
//            get { return EbSite.BLL.User.UserOnline.GetCountAllUser(); }
//        }

//        /// <summary>
//        /// 获取当前站点ID，要求当前页面的url有参数site,没有参数site将获取后台默认站点
//        /// </summary>
//        protected int GetSiteID
//        {
//            get
//            {
//                return HostApi.GetSiteID;
//            }
//        }
//        protected string SiteName
//        {
//            get
//            {
//                return HostApi.CurrentSite.SiteName;
//            }
//        }
//        /// <summary>
//        /// 站点域名
//        /// </summary>
//        protected string DomainName
//        {
//            get
//            {
//                return AppStartInit.DomainName;
//            }
//        }
//        /// <summary>
//        /// 版权信息
//        /// </summary>
//        protected string Copyright
//        {
//            get
//            {
//                return AppStartInit.Copyright;
//            }
//        }


//        protected int UserID = AppStartInit.UserID;
//        protected string UserNiName = AppStartInit.UserNiName;
//        protected string UserName = AppStartInit.UserName;

//        /// <summary>
//        /// 网站安装目录
//        /// </summary>
//        protected static string IISPath
//        {
//            get
//            {
//                return EbSite.Base.AppStartInit.IISPath;
//            }
//        }
//        /// <summary>
//        /// 系统后台存放目录名称
//        /// </summary>
//        protected string AdminPath
//        {
//            get
//            {
//                return EbSite.Base.AppStartInit.AdminPath;
//            }
//        }
//        #endregion

//        public IHtmlString RenderPageCode(int PageIndex, int AllCount, int PageSize, string CssClass, string CurrentClass, string ParentClass, string UrlRule)
//        {
//            return RenderPageCode(LinkType.AspxRewrite, PageIndex, AllCount, PageSize, "", "", 5, "", "", "", "", null,
//                UrlRule);
//        }

//        public IHtmlString RenderPageCode(LinkType Linkt, int PageIndex, int AllCount, int PageSize,string UpPageText,string NextPageText,int ShowCodeNum,string CssClass,string CurrentClass,string ParentClass,string FirstPageUrl, Hashtable htPram, string ReWritePatchUrl)
//        { 

//            XsPages pgJzList = null;//从工厂生成一个页码对象

//            if (LinkType.Html == Linkt)
//            {
//                pgJzList =  new HtmlPages();
//            }
//            else if (LinkType.Aspx == Linkt)
//            {
//                pgJzList =  new cAspxPages();
//            }
//            else
//            {
//                pgJzList = new cAutoHtmlPages();
//            }

//            pgJzList.iCurrentPage = PageIndex;               //设置当前页码
//            pgJzList.iTotalCount = AllCount;             //记录总数
//            pgJzList.iPageSize = PageSize;                 //一首显示多少条
//            pgJzList.ReWritePatchUrl = ReWritePatchUrl;
//            pgJzList.htPrams = htPram;
//            pgJzList.NextPageHtml = UpPageText;
//            pgJzList.NextPageHtml = NextPageText;
//            pgJzList.ShowCodeNum = ShowCodeNum;
//            pgJzList.PageClassName = CssClass;
//            pgJzList.CurrentCss = CurrentClass;
//            pgJzList.ParentClassName = ParentClass;
//            pgJzList.FirstPageUrl = FirstPageUrl;
//            //显示页码代码
//            return MvcHtmlString.Create(pgJzList.showpages());
//        }

//        //private string GetCacheKey(string cachekey, Guid WidgetID)
//        //{
//        //    if (string.IsNullOrEmpty(cachekey))
//        //    {
//        //        return string.Concat(Request.RawUrl.Replace("/", ""), "_", this.ClientID);
//        //    }
//        //    return string.Concat(WidgetID, "_", cachekey);
//        //}
//        public IHtmlString RenderWidget(string WidgetID, string WidgetName)
//        {
           
//            return RenderWidget(WidgetID, WidgetName, 0);
//        }
//        public IHtmlString RenderWidget(string WidgetID, string WidgetName, int SiteID)
//        {
//            return RenderWidget(new Guid(WidgetID), ExtensionType.Widget, 0, "", ETimeSpanModel.分钟, SiteID);
//        }
//        public IHtmlString RenderWidget(Guid WidgetID, ExtensionType ExtensionTp,int CacheTimeSpan,string CacheKey,ETimeSpanModel CacheTimeSpanModel, int SiteID)
//        {
//            string cachekey = CacheKey;
//            string widgethtmlstring = string.Empty;
//            Base.ExtWidgets.WidgetsManage.DataBLL DAL;
//            if (ExtensionTp == ExtensionType.HomeWidget)
//            {
//                DAL =  Base.ExtWidgets.HomeWidgetManage.DataBLL.Instance;
//            }
//            else
//            {
//                if (SiteID == 0)
//                {
//                    DAL = Base.ExtWidgets.WidgetsManage.DataBLL.Instance;
//                }
//                else
//                {
//                    DAL = new DataBLL(SiteID);
//                }

//            }

//            Entity.WidgetShow mdWidget = DAL.GetEntityByID(WidgetID);
//            if (!Equals(mdWidget, null))
//            {
//                WidgetBase control = null;
//                try
//                {
//                    string fileName = "";
//                    if (mdWidget.ModulID == Guid.Empty)
//                    {
//                        fileName = DAL.GetPath_Show(mdWidget.TypeWidget);
//                    }
//                    else
//                    {
//                        fileName = DAL.GetPath_Show(mdWidget.TypeWidget, mdWidget.ModulID);
//                    }
//                    var page = new Page();
//                    control = (WidgetBase)page.LoadControl(fileName);
//                    //control.DataID = WidgetID;
//                    // /themes/ebsite/data/Widgets/WidgetList/ClassList/widget.ascx
//                }
//                catch (Exception ex)
//                {
                  
//                    widgethtmlstring = string.Format("<p style=\"color:red\">ID为{0}:<br>{1}<p>", WidgetID, ex.Message);
                    
//                }
//                if (!Equals(control, null))
//                {
//                    //string sKey = GetCacheKey(control.CacheKey);

//                    bool isloadctr = true;
//                    if (CacheTimeSpan > 0)
//                    {

//                        string html = EbSite.Base.Host.CacheApp.GetCacheItem<string>(cachekey, "Widget");

//                        if (!string.IsNullOrEmpty(html))
//                        {
//                            widgethtmlstring = html;
                           
//                            isloadctr = false;
//                        } 
//                    }

//                    if (isloadctr)
//                    {

//                        control.Extensiontype = ExtensionTp;
//                        control.GetSiteID = SiteID;

//                        control.DataID = mdWidget.DataID;
//                        control.ID = control.DataID.ToString().Replace("-", string.Empty);
//                        control.Title = mdWidget.Title;

//                        if (control.IsEditable)
//                            control.ShowTitle = false;
//                        else
//                            control.ShowTitle = control.DisplayHeader;

//                        control.LoadData();

//                        StringWriter tw = new StringWriter();
//                        HtmlTextWriter writer = new HtmlTextWriter(tw);
//                        control.RenderControl(writer);
//                        widgethtmlstring = writer.InnerWriter.ToString();
//                        if (CacheTimeSpan > 0)
//                        {
//                            EbSite.Base.Host.CacheApp.AddCacheItem(cachekey, widgethtmlstring, CacheTimeSpan, CacheTimeSpanModel, "Widget"); 
//                        }
                         

//                    }

//                }
//                else
//                {
                   
//                    widgethtmlstring = string.Format("<p style=\"color:red\">ID为{0}:<br>{1}<p>", WidgetID, "找不到此部件LoadWidgetCtr为null！");
                   
//                }



//            }
//            else
//            {
//                widgethtmlstring = string.Format("<p style=\"color:red\">ID为{0}:<br>{1}<p>", WidgetID, "找不到此部件！");
                
//            }

//            return MvcHtmlString.Create(widgethtmlstring);
//        }

//        public IHtmlString RenderScripts()
//        {
//            return  Scripts.Render("~/bundles/main");
//        }

//        public IHtmlString RenderStyle()
//        {
//           return  Styles.Render(string.Concat("~/themescss", GetSiteID));
//        }

//        protected string GetNav(string Nav, bool IsAddCurrent, int FilterClassID)
//         {
//             return Model.GetNav(Nav, IsAddCurrent, FilterClassID);
//         }

         

//        public override void Execute()
//        {
           
//        }


//    }
//}
