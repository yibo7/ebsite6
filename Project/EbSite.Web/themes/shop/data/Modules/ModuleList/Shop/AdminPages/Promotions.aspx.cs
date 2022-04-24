using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.Modules;

namespace EbSite.Modules.Shop.AdminPages
{
    public partial class Promotions : MPage
    {
        override public Guid ModuleMenuID
        {
            get
            {
                return new Guid("488df078-d362-4c1a-8519-5b9b8c31c6df");
            }
        }
        public override string PageName
        {
            get
            {
                return "促销活动";
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected override void AddControl()
        {
            if (PageType == 0)//添加
            {
                base.LoadAControl("Add.ascx");
            }
            else if (PageType == 1) //显示
            {
                base.LoadAControl("Show.ascx");
            }
            else if (PageType == 14) //显示
            {
                base.LoadAControl("PromotionsAdd.ascx");
            }
            else if (PageType ==34)//满额打折添加
            {
                base.LoadAControl("PromoAddProduct.ascx");
            }
            else if (PageType ==42)//满额打折添加
            {
                base.LoadAControl("BuySomeAdd.ascx");
            }
            else if (PageType ==46)//满额打折添加
            {
                base.LoadAControl("FullDiscountAdd.ascx");
            }
            else if (PageType ==50)//满额打折添加
            {
                base.LoadAControl("QuotaFreeAdd.ascx");
            }
            else
            {
                base.AddControl();
            }
        }
    }
}