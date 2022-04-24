using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EbSite.Modules.Shop.ModuleCore.Cart;

namespace EbSite.Modules.Shop.ModuleCore.Pages
{
    public class mlist_product : EbSite.Base.Page.BasePage
    {

        protected global::System.Web.UI.WebControls.Repeater rpListProduct;
        protected global::EbSite.Control.PagesContrl pgCtr;

        protected int iSearchCount = 0;
        private int iPageSize
        {
            get
            {
               if (!Equals(pgCtr, null) && pgCtr.PageSize > 0)
                {
                    return pgCtr.PageSize;
                }
                else
                {
                    return 10;
                }

            }

        }
        protected int ClassID
        {
            get
            {
                if (!string.IsNullOrEmpty(Request["cid"]))
                {
                    return int.Parse(Request["cid"]);
                }
                return -1;
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

        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = "商品分类";
            if (!IsPostBack)
            {
                inithead();
                binglist();
            }
        }
        private void binglist()
        {
            rpListProduct.DataSource = Base.AppStartInit.NewsContentInstDefault.GetListPages(PageIndex, iPageSize, " classid=" + ClassID, out iSearchCount, SettingInfo.Instance.GetSiteID);

            rpListProduct.DataBind();
            if (!Equals(pgCtr, null))
            {
              
                pgCtr.ReWritePatchUrl = string.Concat("grouplist-",GetSiteID, "-{0}", ".ashx"); //{0} 页码
                pgCtr.AllCount = iSearchCount;
                pgCtr.PageSize = iPageSize;
                //pgCtr.OtherPram = string.Format("cid,{0}", GetClassID);
                pgCtr.CurrentClass = "CurrentPageCoder";
                pgCtr.ParentClass = "PagesClass";
            }

        }
        private void inithead()
        {
            //base.SeoTitle = Args.SeoTitle;
            //base.SeoKeyWord = Args.SeoKeyWord;
            //base.SeoDes = Args.SeoDes;
        }
       
    }
}