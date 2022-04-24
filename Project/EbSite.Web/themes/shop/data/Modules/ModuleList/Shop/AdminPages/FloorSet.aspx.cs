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
    /// 赠品
    /// </summary>
    public partial class FloorSet : MPage
    {
        override public Guid ModuleMenuID
        {
            get
            {
                return new Guid("474c0eda-f726-4cd9-b619-757798c233f1");
            }
        }
        public override string PageName
        {
            get
            {
                return "首页楼层设置";
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected override void AddControl()
        {
            if (PageType == 0)//添加
            {
                base.LoadAControl("AddFloor.ascx");
            }
            else if (PageType == 1)//设置楼层分类
            {
                base.LoadAControl("BigClassList.ascx");
            }
            else if (PageType ==2)//设置楼层分类
            {
                base.LoadAControl("SetFloorBigClass.ascx");
            }
            else if (PageType ==3)//设置楼层分类
            {
                base.LoadAControl("ChildClassList.ascx");
            }
            else if (PageType == 4)//设置楼层子分类
            {
                base.LoadAControl("SetFloorChildClass.ascx");
            }
            else if (PageType ==5)//设置广告链接
            {
                base.LoadAControl("AdvLinkList.ascx");
            }
            else if (PageType == 6)//设置广告链接
            {
                base.LoadAControl("SetAdvLink.ascx");
            }
            else if (PageType == 7)//设置广告链接
            {
                base.LoadAControl("AdvGoodsList.ascx");
            }
            else if (PageType ==8)//设置广告链接
            {
                base.LoadAControl("SetGoodsList.ascx");
            }
            else if (PageType ==9)//设置广告链接
            {
                base.LoadAControl("BrandList.ascx");
            }
            else if (PageType ==10)//设置品牌列表
            {
                base.LoadAControl("SetBrandList.ascx");
            }
            else if (PageType ==11)//设置商品列表
            {
                base.LoadAControl("GoodsList.ascx");
            }
            else if (PageType == 12)//设置商品列表
            {
                base.LoadAControl("SetAdvGoods.ascx");
            }
            else if (PageType == 13) //手机版 楼层设计
            {
                base.LoadAControl("MobileDesignFloor.ascx");
            }
            else if (PageType == 14) //手机版 楼层设计
            {
                base.LoadAControl("AddMFloor.ascx");
            }
            else if (PageType == 15) //手机版 楼层设计
            {
                base.LoadAControl("MAdvLinkList.ascx");
            }
            else if (PageType == 16) //手机版 楼层设计
            {
                base.LoadAControl("MSetAdvLink.ascx");
            }
            else if (PageType == 17) //手机版 楼层设计
            {
                base.LoadAControl("MAdvChildList.ascx");
            }
            else if (PageType == 18) //手机版 楼层设计
            {
                base.LoadAControl("MSetAdvChild.ascx");
            }
            else
            {
                base.AddControl();
            }
        }
    }
}