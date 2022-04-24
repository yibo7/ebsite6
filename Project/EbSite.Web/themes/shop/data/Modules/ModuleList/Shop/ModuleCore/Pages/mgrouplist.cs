using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EbSite.Modules.Shop.ModuleCore.Cart;

namespace EbSite.Modules.Shop.ModuleCore.Pages
{
    public class mgrouplist : BasePageM
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

        public int Cid
        {
            get {
                if (!string.IsNullOrEmpty(Request.QueryString["cid"]))
                {
                    return EbSite.Core.Utils.StrToInt(Request.QueryString["cid"], -1);
                }
                else
                {
                    return -1;
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = "团购商品";
            if (!IsPostBack)
            {
                ModuleCore.BLL.GroupBuy.Instance.AutoSetGroupStaus();
                inithead();
                binglist();
            }
        }
        private void binglist()
        {
            string strWhere = ""; //0.正在进行中 1.成功结束 2.失败结束 3.还未开始 4.结束未处理   string strWhere = "Status=0 and";
            string strFile = "BuyPrice";
            if (Cid == 1)
            {
                strWhere = string.Format("{0}<=100 ", strFile);
            }
            else if (Cid == 2)
            {
                strWhere = string.Format("{0}>100 and {0}<=200 ", strFile);
            }
            else if (Cid == 3)
            {
                strWhere = string.Format("{0}>200 and {0}<=500 ", strFile);
            }
            else if (Cid == 4)
            {
                strWhere = string.Format("{0}>500 and {0}<=1000 ", strFile);
            }
            else if (Cid == 5)
            {
                strWhere = string.Format("{0}>1000 ", strFile);
            }
            //strWhere = strWhere.Remove(strWhere.Length - 3, 3);
            //GetListPages(PageIndex, iPageSize,strWhere,"",out iSearchCount);

            //rpList.DataSource = ModuleCore.BLL.GroupBuy.Instance.GetListArray(0, strWhere, "edateline desc");//结束时间排序
            rpList.DataSource = ModuleCore.BLL.GroupBuy.Instance.GetListPages(PageIndex, iPageSize, strWhere,"", "edateline desc", out iSearchCount);//结束时间排序
            rpList.DataBind();

          
            BindPage();

        }


        virtual protected void BindPage()
        {
            if (!Equals(pgCtr, null))
            {

                pgCtr.ReWritePatchUrl = ShopLinkApi.GroupListSplitPage(GetSiteID, Cid);
                pgCtr.AllCount = iSearchCount;
                pgCtr.PageSize = iPageSize;
                pgCtr.CurrentClass = "CurrentPageCoder";
                pgCtr.ParentClass = "PagesClass";
            }
        }
        public static string GetEndDays(object endDate,string pjName)
        {
            if (endDate != null)
            {
                DateTime dtEnd = (DateTime)endDate;
                int subDays = dtEnd.Subtract(DateTime.Now).Days;
                if (subDays >= 0)
                {
                    return subDays.ToString() + "天以上";
                }
            }
            if (string.IsNullOrEmpty(pjName))
            {
               return  endDate + " 此团购结束！";
            }
            return string.Concat(endDate + " 此",pjName,"结束！");
        }

        public static string GetEndDays(object endDate)
        {
            return GetEndDays(endDate, "");
        }
        public string GetBuyCounts(object groupID)
        {
            if (groupID != null)
            {
                int gid = EbSite.Core.Utils.ObjectToInt(groupID, 0);
                if (gid > 0)
                {
                    return ModuleCore.BLL.GroupBuy.Instance.GetOrderCount(gid).ToString();
                }
            }
            return "0";
        }
        private void inithead()
        {
            //base.SeoTitle = Args.SeoTitle;
            //base.SeoKeyWord = Args.SeoKeyWord;
            //base.SeoDes = Args.SeoDes;
        }
        protected string GetNav(string Nav)
        {
            return string.Format("<a href='{0}'>{1}</a>{2}<a href='{3}'>团购</a>", HostApi.GetMainIndexHref(GetSiteID), SiteName, Nav, ShopLinkApi.GroupList(GetSiteID));

        }
       
    }
}