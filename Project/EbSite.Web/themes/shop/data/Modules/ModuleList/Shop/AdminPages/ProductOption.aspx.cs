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
    /// 订单可选项
    /// </summary>
    public partial class ProductOption : MPage
    {
        //override public Guid ModuleMenuID
        //{
        //    get
        //    {
        //        return new Guid("ce89eeaf-020a-4c0e-8124-9e290d956bac");
        //    }
        //}
        public override string PageName
        {
            get
            {
                return "订单可选项";
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected override void AddControl()
        {
            if (PageType ==54)//添加
            {
                base.LoadAControl("OrderOptionAdd.ascx");
            }
            else if (PageType ==57) //显示
            {
                base.LoadAControl("Add_Sec.ascx");
            }
            else if (PageType ==58) //显示
            {
                base.LoadAControl("OptionItemList.ascx");
            }
            else
            {
                base.AddControl();
            }
        }
    }
}