using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.Modules;

namespace EbSite.Modules.Shop.AdminPages
{
    /// <summary>
    /// 促销活动
    /// </summary>
    public partial class SalesActivities : MPage
    {
        override public Guid ModuleMenuID
        {
            get
            {
                return new Guid("cbd1d47f-d9f4-4bf3-8e62-f12b3c1131df");
            }
        }
        public override string PageName
        {
            get
            {
                return "团购活动";
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected override void AddControl()
        {
            if (PageType == 0)//添加促销
            {
                base.LoadAControl("PromotionsEdit.ascx");
            }
            else if (PageType == 18)
            {
                base.LoadAControl("GroupBuyEdit.ascx");
            }
            else if (PageType == 34) //显示
            {
                base.LoadAControl("PromoAddProduct.ascx");
            }
            else if (PageType == 1) //抢购 添加
            {
                base.LoadAControl("RobBuyAdd.ascx");
            }
            else if(PageType==2)//优惠券添加
            {
                base.LoadAControl("CouponsAdd.ascx");
            }
            else if(PageType==3)//优惠券 显示
            {
                base.LoadAControl("CouponsShow.ascx");
            }
            else
            {
                base.AddControl();
            }
        }
    }
}