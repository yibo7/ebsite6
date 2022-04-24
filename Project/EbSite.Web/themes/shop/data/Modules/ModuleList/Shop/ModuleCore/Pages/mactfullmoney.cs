using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EbSite.Modules.Shop.ModuleCore.Cart;

namespace EbSite.Modules.Shop.ModuleCore.Pages
{
    public class mactfullmoney : BasePageM
    {
        protected global::System.Web.UI.WebControls.Repeater rpActFullQuantity;
        protected global::System.Web.UI.WebControls.Repeater rpActFullMoney;
        protected Entity.Promotions Model = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = "优惠活动";
            if (!IsPostBack)
            {
                inithead();
                BindClass();
                int ActivitieID = EbSite.Core.Utils.StrToInt(Request["id"], 0);
                Model = ModuleCore.BLL.Promotions.Instance.GetEntity(ActivitieID);
                if (Equals(Model, null))
                {
                    Tips("活动不存在", "活动不存在!,可能已经被管理员删除!");
                }
                
            }
        }
        protected void BindClass()
        {
            if (!Equals(rpActFullQuantity, null))
            {
                rpActFullQuantity.DataSource = ModuleCore.BLL.Promotions.Instance.GetListArray("PromoteType=2 or PromoteType=4");
                rpActFullQuantity.DataBind();
            }
            if (!Equals(rpActFullMoney, null))
            {
                rpActFullMoney.DataSource = ModuleCore.BLL.Promotions.Instance.GetListArray("PromoteType=1 or PromoteType=3");
                rpActFullMoney.DataBind();
            }
        }
        private void inithead()
        {
            //base.SeoTitle = Args.SeoTitle;
            //base.SeoKeyWord = Args.SeoKeyWord;
            //base.SeoDes = Args.SeoDes;
        }
        virtual protected string GetNav(string Nav)
        {
            int ActivitieID = EbSite.Core.Utils.StrToInt(Request["id"], 0);
            int isiteid = GetSiteID;
            if (ActivitieID > 0)
            {
                return string.Format("<a href='{0}'>{1}</a>{2}<a href='{3}'>满额优惠活动</a>{2}<a href='{4}'>{5}</a>", HostApi.GetMainIndexHref(isiteid), SiteName, Nav, ShopLinkApi.ActFullMoney(isiteid, 0), ShopLinkApi.ActFullMoney(isiteid, ActivitieID), Model.TitleName);
            }
            else
            {
                return string.Format("<a href='{0}'>{1}</a>{2}<a href='{3}'>满额优惠活动</a>", HostApi.GetMainIndexHref(isiteid), SiteName, Nav, ShopLinkApi.ActFullMoney(isiteid, 0));
            }

        }
         
       
    }
}