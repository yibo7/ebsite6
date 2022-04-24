using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EbSite.Modules.Shop.ModuleCore.Cart;

namespace EbSite.Modules.Shop.ModuleCore.Pages
{
    public class mrushlist : BasePageM
    {
        protected global::System.Web.UI.WebControls.Repeater rpList;
        protected global::EbSite.Control.PagesContrl pgCtr;

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
                    return 10;
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

        
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = "限时抢购";
            if (!IsPostBack)
            {
                inithead();
                binglist();
            }
        }
        protected int ClassID
        {
            get
            {
                if (!string.IsNullOrEmpty(Request["cid"]))
                {
                    return EbSite.Core.Utils.StrToInt(Request["cid"], 0);
                }
                return 0;
            }
        }
        private void binglist()
        {
            string strWhere = "";
            int Cid = ClassID;
            if (Cid>0)
            {
                
                string strFile = "CountDownPrice";
                if (Cid == 1)
                {
                    strWhere = string.Format("{0}<=100", strFile);
                }
                else if (Cid == 2)
                {
                    strWhere = string.Format("{0}>100 and {0}<=200", strFile);
                }
                else if (Cid == 3)
                {
                    strWhere = string.Format("{0}>200 and {0}<=500", strFile);
                }
                else if (Cid == 4)
                {
                    strWhere = string.Format("{0}>500 and {0}<=1000", strFile);
                }
                else if (Cid == 5)
                {
                    strWhere = string.Format("{0}>1000", strFile);
                }
            }
            rpList.DataSource = ModuleCore.BLL.CountDownBuy.Instance.GetListPages(PageIndex, iPageSize,strWhere,"",out iSearchCount);
            rpList.DataBind();
            BindPages();

        }
        virtual protected void BindPages()
        {
            if (!Equals(pgCtr, null))
            {

                pgCtr.ReWritePatchUrl = ShopLinkApi.RushListSplitPage(GetSiteID, ClassID);//string.Concat("rushlist-", GetSiteID, "-{0}", ".ashx"); //{0} 页码
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
        public string GetDiscountRate(object oldPrice, object nowPrice)
        {
            string result = "";
            if (oldPrice != null && nowPrice != null)
            {
                decimal l = (decimal)oldPrice;
                decimal n = (decimal)nowPrice;
                if (l > n)
                {
                    result = (Math.Round((l - n) / l, 2) * 10).ToString();
                }
            }
            return result;
        }
        protected string GetNav(string Nav)
        {
            return string.Format("<a href='{0}'>{1}</a>{2}<a href='{3}'>限时抢购</a>", HostApi.GetMainIndexHref(GetSiteID), SiteName, Nav, ShopLinkApi.RushList(GetSiteID));

        }
       
    }
}