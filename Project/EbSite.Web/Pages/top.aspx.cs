using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EbSite.Web.Pages
{
    public partial class top : EbSite.Base.Page.CustomPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //  排行榜类别，0为所有，1为月，2为周，3为日
            
            int icount = 0;
            List<Entity.NewsContent> ls = BLL.NewsContent.Un_GetListPages(pgCtr.PageIndex, pgCtr.PageSize, "", "", true,
                                                                          false, out icount, base.GetSiteID, BLL.DataSettings.Content.Instance.GetConfigCurrent.ContentTables, OrderBy, this.Context);
            pgCtr.AllCount = icount;
            this.rpTop.DataSource = ls;
            this.rpTop.DataBind();
            intpages();



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
            return string.Concat("<a href='", BLL.GetLink.LinkOrther.Instance.GetInstance(GetSiteID).GetMainIndexHref(), "'>", SiteName, "</a>", Nav, "<a href='", Request.RawUrl, "'>", "数据排行</a>");
        }
        protected string OrderBy
        {
            get
            {
                //0 总排行  1今日排行  2 本周排行 3 本月排行 4  最新数据 5推荐数据
                //为空,总点击排行榜，adv收藏排行,d今日点击排行,w本周点击排行，m本月点击排行，ch按评论最多排行，fh按好评(被顶)最多排行
               
                if (!string.IsNullOrEmpty(Request["t"]))
                {
                    string key =Request["t"];
                    switch (key)
                    {
                        case "0":
                            base.SeoTitle = string.Concat("总排行-", SiteName);
                            return "h";
                           
                        case "1":
                            base.SeoTitle = string.Concat("今日排行-", SiteName);
                            return "d";
                           
                        case "2":
                            base.SeoTitle = string.Concat("本周排行-", SiteName);
                            return "w";
                            
                        case "3":
                            base.SeoTitle = string.Concat("本月排行-", SiteName);
                            return "m";
                            
                        case "4":
                            base.SeoTitle = string.Concat("最新数据-", SiteName);
                            return "";
                           
                        case "5":
                            base.SeoTitle = string.Concat("推荐数据-", SiteName);
                            return "d";
                            
                        default:
                            return "";

                    }
                    
                }
                else
                {
                    return "";
                }
            }
        }

        private void intpages()
        {
            if (!Equals(pgCtr, null))
            {
                pgCtr.ReWritePatchUrl = string.Concat( Core.Utils.StrToInt(Request["t"], 0), "-{0}", HostApi.TopRw(GetSiteID)); //{0} 页码
              //  pgCtr.ReWritePatchUrl = string.Concat(IISPath,Core.Utils.StrToInt(Request["t"], 0),"-{0}", Base.Configs.ContentSet.ConfigsControl.Instance.TopRw); //{0} 页码
                pgCtr.CurrentClass = "CurrentPageCoder";
                pgCtr.ParentClass = "PagesClass";

            }


        }
    }
}