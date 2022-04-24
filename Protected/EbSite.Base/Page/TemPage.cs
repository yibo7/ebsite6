
using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;
using System.Web;
using Amib.Threading;
using EbSite.Base.EBSiteEventArgs;
using EbSite.Base.Static;
using EbSite.BLL;
using EbSite.Core;
using EbSite.Core.FSO;

namespace EbSite.Base.Page
{
    public enum EMakeType:int
    {
        /// <summary>
        /// 分类页
        /// </summary>
        FLY,
        /// <summary>
        /// 专题页
        /// </summary>
        ZTY,
        /// <summary>
        /// 内容页
        /// </summary>
        NRY,
        /// <summary>
        /// 标签页
        /// </summary>
        BQY,
        /// <summary>
        /// 带参首页
        /// </summary>
        DCSY,
        /// <summary>
        /// 移动分类页
        /// </summary>
        YDFLY,
        /// <summary>
        /// 移动首页
        /// </summary>
        YDSY,
        /// <summary>
        /// 移动内容页
        /// </summary>
        YDNRY,
        /// <summary>
        /// 移动专题页
        /// </summary>
        YDZTY,
        /// <summary>
        /// 通用讨论
        /// </summary>
        TYTL

    }
    public abstract class TemPage : System.Web.UI.Page
    {
        public Host HostApi
        {
            get
            {
                return Host.Instance;
            }
        }
        public TemPage()
        {
            base.Load += new EventHandler(this.TemPage_Load);
        }
        protected void TemPage_Load(object sender, EventArgs e)
        {
            if (Configs.SysConfigs.ConfigsControl.Instance.IsMobileRedirect)
            {
                if (Core.Utils.IsMobileDevice(this.Context))
                {
                    if (MakeType == EMakeType.NRY)
                    {
                        string cid = Request["cid"];

                        Response.Status = "301 moved permanently";
                        Response.AddHeader("location", HostApi.MGetContentLink(DataID, cid, 0));

                        //Response.Redirect(HostApi.MGetContentLink(DataID, cid, 0));
                        //Response.End();
                    }
                    else if (MakeType == EMakeType.FLY)
                    {
                        string cid = Request["cid"];

                        Response.Status = "301 moved permanently";
                        Response.AddHeader("location", HostApi.MGetContentLink(DataID, cid, 0));

                        //Response.Redirect(HostApi.MGetClassHref(cid, 1));
                        //Response.End();
                    }
                }
            }
            
        }
        

        /// <summary>
        /// 在自动静态下，获取缓存文件Url
        /// </summary>
        protected abstract string GetCacheUrl{ get;}
        protected abstract EMakeType MakeType { get; }
        protected abstract int DataID { get; }
        /// <summary>
        /// 获取当前请求的真正模板路径
        /// </summary>
        protected abstract string GetTemUrl{ get;}
        protected int GetSiteID
        {
            get
            {
                if (!string.IsNullOrEmpty(Request.QueryString["site"]))
                {
                    return int.Parse(Request.QueryString["site"]);
                }
                return 1;
            }
        }
        //YHL 2014-2-11 给内容页使用
        protected int GetClassID
        {
            get
            {
                if (!string.IsNullOrEmpty(Request.QueryString["cid"]))
                {
                    return int.Parse(Request.QueryString["cid"]);
                }
                return 0;
            }
        }
        protected void PageLoadBll()
        {
            if (IsNoAAutoHtml()) //如果不属于自动静态请求，直接定向到模板文件
            {
                
                RedirectPathAspx(GetTemUrl);
            }
            else
            {
                string FullCacheUrl = string.Empty;
                string cacheurl = GetCacheUrl;
                if (!cacheurl.StartsWith("/"))
                {
                    FullCacheUrl = string.Concat(EbSite.Base.Host.Instance.IISPath, AppStartInit.CacheFolder, GetCacheUrl);//防止多次调用
                }
                else
                {
                    FullCacheUrl = cacheurl;
                }


                //真实保存目录
                string thissavepath = HttpContext.Current.Server.MapPath(FullCacheUrl);

                string sREFERER = Utils.GetReferer(HttpContext.Current);
                HtmlInfo html = GetCacheUrl_MH(thissavepath, DataID, MakeType, Request.Url.Query, sREFERER, FullCacheUrl);
                TemCacheingEventArgs tcea = new TemCacheingEventArgs(html,this.Context);
                EbSite.Base.EBSiteEvents.OnTemCacheing(this,tcea);


                if (!tcea.IsStop)
                {
                    //为了减少对GetTemUrl请求，这里先做判断

                    //如果缓存文件不存在，要生成一个，比如第一访问就不会存在
                    if (!Core.FSO.FObject.IsExist(thissavepath, FsoMethod.File))
                    {
                        //无法逃避在当前线程请求模板
                        string Temp = string.Concat(GetTemUrl, Request.Url.Query);
                        EbSite.Base.Static.HtmlPool.GetCacheUrl_M(thissavepath, Temp, true);
                        Server.Transfer(Temp);
                    }
                    else //如果缓存文件存在，将有两种情况，一种是没有过期，直接返回缓存文件url,一种，已经过期
                    {
                        if (EbSite.Base.Static.HtmlPool.IsHtmlOverdue(thissavepath)) //判断缓存文件是否已经过期
                        {
                            //string Temp = string.Concat(GetTemUrl, Request.Url.Query);
                            //FullCacheUrl = string.Concat(GetTemUrl, Request.Url.Query);
                            //避免在当前线程请求模板，占用资源
                            //string sREFERER = Utils.GetReferer(HttpContext.Current);

                            //HtmlInfo html = GetCacheUrl_MH(thissavepath, DataID, MakeType, Request.Url.Query, sREFERER);

                            IWorkItemResult wir = ThreadPoolManager.Instance.QueueWorkItem(new WorkItemCallback(html.ToHtml), null);
                        }
                        Server.Transfer(FullCacheUrl);
                    }
                }

                

            }
            
        }
        protected void RedirectPathAspx(string sTemUrl)
        {

            if (!string.IsNullOrEmpty(sTemUrl))
            {
                 
                Server.Transfer(sTemUrl);
                
            }
            else
            {
                TransferErr();
            }
        }
     
       virtual protected bool IsNoAAutoHtml()
        {
            return ( EbSite.BLL.Sites.Instance.GetSiteLinkType(GetSiteID) != Configs.SysConfigs.LinkType.AutoHtml ||Request.Url.Query.LastIndexOf("&$html$") > -1);
        }
        //private bool GetIsUtf8
        //{
        //    get
        //    {
        //        if(MakeType==EMakeType.移动首页||MakeType==EMakeType.移动分类页)
        //        {
        //            return true;
        //        }
        //        return false;
        //    }
        //}
        protected void TransferErr()
        {
            AppStartInit.TipsPageRender("找不到相应的模板!!", "找不到相应的模板，请查看是否已经创建相应模板。", "");
        }

        //生成一个文件并返回真实地址
        public HtmlInfo GetCacheUrl_MH(string CachePath, int dataID, EMakeType mtype, string sQuery,string sReferer,string FullCacheUrl)
        {
            HtmlInfo html = new HtmlInfo();
            html.dID = dataID;
             html.MakeType = mtype;
            html.SavePath = CachePath;
            html.QueryStr = sQuery;
            html.ThemeName = Base.Host.Instance.CurrentSite.PageTheme;
            html.Authority = HttpContext.Current.Request.Url.Authority;
            html.IsUtf8 = true;
            html.SiteID = GetSiteID;
            html.CID = GetClassID;
            html.sReferer = sReferer;
            html.FullCacheUrl = FullCacheUrl;
            return html;
            //IWorkItemResult wir = ThreadPoolManager.Instance.QueueWorkItem(new WorkItemCallback(html.ToHtml), null);

        }
        /// <summary>
        /// 在这里处理模板请求，只是为了不占用当前访问线程,以提供更好的用户体验，但代码看起来会乱些
        /// </summary>
         public class HtmlInfo
         {
             private static object _SyncRoot = new object();
             public int CID { get; set; }//YHL 2014-2-11
             public int SiteID { get; set; }
             public string SavePath { get; set; }
             public string QueryStr { get; set; }
             public string ThemeName { get; set; }
             public string Authority { get; set; }
             public bool IsUtf8 { get; set; }
             public int dID { get; set; }
            public string FullCacheUrl { get; set; }
            /// <summary>
            /// 来路页面
            /// </summary>
            /// <value>The s referer.</value>
            public string sReferer { get; set; }
             /// <summary>
             /// 生成类别,0为分类，1为专题，2为内容
             /// </summary>
            public EMakeType MakeType { get; set; }

             public string GetUrl
             {
                 get
                 {
                    string sUrl = "";
                    if (MakeType == EMakeType.FLY)
                    {
                        //Guid temId = EbSite.BLL.NewsClass.GetTemID(dID);

                        Guid temId = EbSite.BLL.ClassConfigs.Instance.GetClassTemID(dID);
                        if (temId != Guid.Empty)
                        {
                            sUrl = TempFactory.GetInstance(ThemeName).GetTemPathByCache(temId);
                        }
                    }
                    else if (MakeType == EMakeType.ZTY)
                    {
                        EbSite.Entity.SpecialClass md = EbSite.BLL.SpecialClass.GetModelByCache(dID);
                        ;
                        if (!Equals(md, null))
                        {
                            EbSite.Entity.Templates obTem =
                                TempFactory.GetInstance(ThemeName).GetModelByCache(md.SpecialTemID, SiteID);
                            sUrl = obTem.TemPath;
                        }
                    }
                    else if (MakeType == EMakeType.NRY)
                    {
                        NewsContentSplitTable NewsContentInst = EbSite.Base.AppStartInit.GetNewsContentInst(CID);
                        //YHL 2014-2-11 内容页有ClassID
                        EbSite.Entity.NewsContent mdContent = NewsContentInst.GetModel(dID, SiteID);
                        EbSite.Entity.Templates tm = null;
                        if (!Equals(mdContent, null))
                        {
                            //查询当前内容所在的分类-获取分类的模板

                            //EbSite.Entity.ClassConfigs _ClassConfigs = EbSite.BLL.ClassConfigs.Instance.GeClassConfigsByClassID(mdContent.ClassID);
                            Guid cTempID = EbSite.BLL.ClassConfigs.Instance.GetContentTemID(mdContent.ClassID);
                            if (!Equals(cTempID, Guid.Empty))
                            {
                                tm = TempFactory.GetInstance(ThemeName).GetModelByCache(cTempID, SiteID);
                            }
                            else
                            {
                                EbSite.BLL.HTMLLog.InsertLogs("找不到相应的模板!!",
                                    string.Concat("内容ID为:", mdContent.ID, "的模板为空，其对应的分类ID:", mdContent.ClassID,
                                        "的模板也为空，所以无法创建此页面！"));
                            }

                            if (!Equals(tm, null))
                            {
                                sUrl = tm.TemPath;
                            }
                        }

                    }
                    else if (MakeType == EMakeType.BQY)//标签页面
                    {

                    }
                    else if (MakeType == EMakeType.DCSY) //带参首页
                    {
                        //对于CurrentSite有不明白池中也能调用
                        //Guid IndexTemID = EbSite.Base.Host.Instance.CurrentSite.IndexTemID;
                        EbSite.Entity.Sites mdSite = EbSite.Base.AppStartInit.Sites[SiteID];
                        EbSite.Entity.Templates obTem =
                            TempFactory.GetInstance(mdSite.PageTheme).GetModelByCache(mdSite.IndexTemID, SiteID);
                        if (!Equals(obTem, null))
                        {
                            sUrl = obTem.TemPath;
                        }
                    }
                    //以下手机模板都要调用，暂时这样写死
                    else if (MakeType == EMakeType.YDFLY)
                    {
                        sUrl = AppStartInit.Sites[SiteID].MGetCurrentPageUrl("list.aspx");
                    }
                    else if (MakeType == EMakeType.YDSY)
                    {
                        sUrl = AppStartInit.Sites[SiteID].MGetCurrentPageUrl("index.aspx");
                    }
                    else if (MakeType == EMakeType.YDNRY)
                    {
                        sUrl = AppStartInit.Sites[SiteID].MGetCurrentPageUrl("content.aspx");
                    }
                    else if (MakeType == EMakeType.YDZTY)
                    {
                        sUrl = AppStartInit.Sites[SiteID].MGetCurrentPageUrl("special.aspx");
                    }

                     return sUrl;
                 }
             }

             public object ToHtml(object sender)
             {
                 lock (_SyncRoot)
                 {
                     string fullurl = "";
                //这里会出问题 要处理异常
                try
                {

                    string sUrl = GetUrl;

                    if (!string.IsNullOrEmpty(sUrl))
                    {


                         //fullurl = string.Concat("http://", Authority, string.Concat(sUrl, QueryStr));
                          fullurl = string.Concat(Host.Instance.Domain, string.Concat(sUrl, QueryStr));
                        string shtml = Core.WebUtility.LoadURLString(fullurl);

                            MakeingEventArgs ea = new MakeingEventArgs(shtml);
                            //在生成前对html进行事件处理
                            EbSite.Base.EBSiteEvents.OnHTMLMakeing(null, ea);

                            

                            if (!FObject.IsFileInUse(SavePath))
                        {
                                if (!IsUtf8)
                                {

                                    Core.FSO.FObject.WriteFile(SavePath, ea.Html);

                                }
                                else
                                {
                                    Core.FSO.FObject.WriteFileUtf8(SavePath, ea.Html);
                                }
                           }

                    }

                }
                catch (Exception e)
                {
                    EbSite.BLL.HTMLLog.InsertLogs("在线程池中生成静态页面发生错误(更新文件)",
                        string.Format("来路:{6};原因:1.可能请求的地址无法打开，请检查，2.可能写入文件出错，检查是否有写入权限！，请求静态页的源ID:{0},请求源类型{2},异常信息:{1},{3},{4},请求的网址:{5}", dID,
                            e.Message, MakeType,e.Source,e.StackTrace, fullurl, sReferer));
                    Log.Factory.GetInstance().ErrorLog(string.Format("来路:{6};原因:1.可能请求的地址无法打开，请检查，2.可能写入文件出错，检查是否有写入权限！，请求静态页的源ID:{0},请求源类型{2},异常信息:{1},{3},{4},请求的网址:{5}", dID,
                            e.Message, MakeType, e.Source, e.StackTrace, fullurl, sReferer));

                }
            }

         return 1;
             }
         }
       
    }
}
