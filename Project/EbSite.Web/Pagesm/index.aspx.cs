using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base;
using EbSite.Entity;

namespace EbSite.Web.Pagesm
{
    public partial class index : EbSite.Base.Page.BasePageMobile
    {
        override protected string MTitle
        {
            get
            {
                return SiteName;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            inithead();
            BindData();

            //yhl 2013-12-20
            Base.EBSiteEventArgs.IndexPageLoadEventArgs Args = new Base.EBSiteEventArgs.IndexPageLoadEventArgs(GetSiteID, this.Page);
            Base.EBSiteEvents.OnIndexPageLoadEvent(null, Args);
        }
        private void inithead()
        {
            //string seoClassTitle = string.Concat(SiteName, "-首页");
            //base.SeoTitle = seoClassTitle;
            base.SeoTitle = GetSeoWord(SeoSite.SeoSiteIndexTitle, "");
            base.SeoKeyWord = GetSeoWord(SeoSite.SeoSiteIndexKeyWord, "");
            base.SeoDes = GetSeoWord(SeoSite.SeoSiteIndexDes, "");
        }

        

        //private  int Key
        //{
        //    get { int iKey = 0;
        //        if (!string.IsNullOrEmpty(Request.QueryString["t"]))
        //        {
        //            return EbSite.Core.Utils.StrToInt(Request.QueryString["t"], 0);
        //        }

            //        return iKey;
            //    }
            //}

        protected int iSearchCount = 0;
        private int iPageSize
        {
            get
            {
                if (pgCtr.PageSize > 0)
                {
                    return pgCtr.PageSize;
                }
                else
                {
                    return Base.Configs.ContentSet.ConfigsControl.Instance.PageSizeClass;
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
        private void intpages()
        {
            if (!Equals(pgCtr, null))
            {

                //这有点不好理解,以重构
                if (string.IsNullOrEmpty(pgCtr.ReWritePatchUrl)) //外面可以自定义
                    pgCtr.ReWritePatchUrl = string.Concat(IISPath, "{0}-", Base.Configs.ContentSet.ConfigsControl.Instance.IndexPathRw); //{0} 页码

                pgCtr.AllCount = iSearchCount;
                pgCtr.PageSize = iPageSize;
                pgCtr.CurrentClass = "CurrentPageCoder";
                pgCtr.ParentClass = "PagesClass";
            }

        }
        public string GetCutTitle(string sCtent,int iLength)
        {
            return sCtent.Length > iLength ? sCtent.Substring(0, iLength) + "..." : sCtent;
        }
        public int iCount;
        private void BindData()
        {
            if (!Equals(rpList, null))
            {
               // rpList.DataSource = BLL.NewsContent.Un_GetListForListPage(PageIndex, iPageSize, 0, 0, out iSearchCount, GetSiteID, this.Context,EbSite.BLL.DataSettings.Content.Instance.GetConfigCurrent.ContentTables);
               
                rpList.DataSource = EbSite.BLL.NewsContent.Un_GetListPages(pgCtr.PageIndex, pgCtr.PageSize, "", "", true,
                                                                      false, out iSearchCount, base.GetSiteID, BLL.DataSettings.Content.Instance.GetConfigCurrent.ContentTables, "", this.Context);
                   
                rpList.DataBind();
                
                iCount = iSearchCount;
                intpages();
            }

           

        }
        //override protected void ShowCopyright()
        //{

        //    //if (!Equals(llFootInfo, null))
        //    //{
        //    //    string cnzz = string.Empty;
        //    //    if (!EbSite.Base.Configs.ContentSet.ConfigsControl.Instance.IsStopCnzz)
        //    //    {
        //    //        cnzz = Core.CNZZ.GetJs();
        //    //    }

        //    //    llFootInfo.Text = string.Concat("By eBSite", AppStartInit.ASSEMBLY_VERSION);
        //    //}
        //    //else
        //    //{
        //    //    throw new Exception("当前模板缺少ID为llFootInfo的Literal控件,您可以在模板底部添加以下代码:<asp:Literal ID=\"llFootInfo\" runat=\"server\"></asp:Literal>");
        //    //}
        //}
    }
}