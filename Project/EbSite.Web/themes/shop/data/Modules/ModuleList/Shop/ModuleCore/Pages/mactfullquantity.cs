using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EbSite.Modules.Shop.ModuleCore.Cart;

namespace EbSite.Modules.Shop.ModuleCore.Pages
{
    public class mactfullquantity : mactfullmoney
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
       new   protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = "优惠活动";
            if (!IsPostBack)
            {
                inithead();
                intpages();
                BindClass();

               
            }
        }
        protected  int ActivitieID
        {
            get
            {
                return EbSite.Core.Utils.StrToInt(Request["id"], 0);
            }
        }
        private void intpages()
        {
            if (!Equals(rpList,null))
            {
               
                Model = ModuleCore.BLL.Promotions.Instance.GetEntity(ActivitieID);
                rpList.DataSource = ModuleCore.BLL.Promotions.Instance.GetShowList(PageIndex, iPageSize, ActivitieID, out iSearchCount);
                rpList.DataBind();
            }
            BindPage();

        }

        virtual  protected void BindPage()
        {
            if (!Equals(pgCtr, null))
            {
                pgCtr.ReWritePatchUrl = ShopLinkApi.ActFullQuantitySplitPage(GetSiteID, ActivitieID);// string.Concat(GetClassID, "-{0}-", OrderBy, HostApi.ClassLinkRw(GetSiteID)); //{0} 页码
                pgCtr.AllCount = iSearchCount;
                pgCtr.PageSize = iPageSize;
                pgCtr.CurrentClass = "CurrentPageCoder";
                pgCtr.ParentClass = "PagesClass";
            }
        }
        public static string GetBigImgUrl(string BigImgUrl)
        {
            int iListIndex = BigImgUrl.LastIndexOf("-");
            int iListIndex2 = BigImgUrl.LastIndexOf(".");
            string strEX = BigImgUrl.Substring(iListIndex, BigImgUrl.Length - iListIndex);
            string strEX2 = BigImgUrl.Substring(iListIndex2, BigImgUrl.Length - iListIndex2);
            return BigImgUrl.Replace(strEX, string.Concat("-big", strEX2));
        }
        
        private void inithead()
        {
            //base.SeoTitle = Args.SeoTitle;
            //base.SeoKeyWord = Args.SeoKeyWord;
            //base.SeoDes = Args.SeoDes;
        }
       override protected string GetNav(string Nav)
        {
            int ActivitieID = EbSite.Core.Utils.StrToInt(Request["id"], 0);
            int isiteid = GetSiteID;
            if (ActivitieID > 0)
            {
                return string.Format("<a href='{0}'>{1}</a>{2}<a href='{3}'>满量优惠活动</a>{2}<a href='{4}'>{5}</a>", HostApi.GetMainIndexHref(isiteid), SiteName, Nav, ShopLinkApi.ActFullQuantity(isiteid, 0), ShopLinkApi.ActFullQuantity(isiteid, ActivitieID), Model.TitleName);
            }
            else
            {
                return string.Format("<a href='{0}'>{1}</a>{2}<a href='{3}'>满量优惠活动</a>", HostApi.GetMainIndexHref(isiteid), SiteName, Nav, ShopLinkApi.ActFullQuantity(isiteid, 0));
            }

        }
       
    }
}