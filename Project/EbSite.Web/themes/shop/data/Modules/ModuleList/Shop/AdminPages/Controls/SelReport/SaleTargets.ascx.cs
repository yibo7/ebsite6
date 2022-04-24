using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.ControlPage;
using EbSite.Base.Modules;

namespace EbSite.Modules.Shop.AdminPages.Controls.SelReport
{
    public partial class SaleTargets : MPUCBaseList
    {
        public override string PageName
        {
            get
            {
                return "销售指标";
            }
        }
        /// <summary>
        /// 是否添加到管理页面菜单之中
        /// </summary>
        public override bool IsAddToAdminMenus
        {
            get
            {
                return true;
            }
        }
        /// <summary>
        /// 权限全部
        /// </summary>
        public override string Permission
        {
            get
            {
                return "61";
            }
        }
     
        

        public override int OrderID
        {
            get
            {
                return 1;
            }
        }
        /// <summary>
        /// 菜单ID
        /// </summary>
        public override Guid ModuleMenuID
        {
            get
            {
                return new Guid("4b3bd1ed-0101-40ac-aa78-794e8456c2f2");
            }
        }
        override protected string AddUrl
        {
            get
            {
                return "";
            }
        }
       
      
        override protected object LoadList(out int iCount)
        {
            iCount = 0;
            return null;
        }

        override protected object SearchList(out int iCount)
        {
            iCount = 0;
            return null;
        }
        override protected void Delete(object iID)
        {
            
        }
        

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                decimal orderPrice = 0;
                int memberQuantity = 0;
                int viewTimes = 0;
                int orderQuantity = 0;
                int haveOrderMember = 0;
                //ModuleCore.BLL.Buy_Orders.Instance.GetOrderConverRate(out orderPrice,out memberQuantity,out viewTimes,out orderQuantity,out haveOrderMember);

                //this.litOrderTotalPrice.Text = orderPrice.ToString();
                //this.litOrderTotalPrice1.Text = orderPrice.ToString();

                //this.litMemberQuantity.Text = memberQuantity.ToString();
                //this.litMemberQuantity2.Text = memberQuantity.ToString();
                //this.litMemberQuantity3.Text = memberQuantity.ToString();

                //this.litViewTimes.Text = viewTimes.ToString();
                //this.litViewTimes2.Text = viewTimes.ToString();

                //this.litTotalOrderQuantity.Text = orderQuantity.ToString();
                //this.litTotalOrderQuantity2.Text = orderQuantity.ToString();

                //this.litHaveOrderMember.Text = haveOrderMember.ToString();


                //this.litMemberPrice.Text = (Math.Round(orderPrice / memberQuantity,2)).ToString();
                //this.litTimesPrice.Text = (Math.Round(orderPrice / viewTimes, 2)).ToString();

                //this.litOrderRate.Text = (Math.Round((double)orderQuantity/viewTimes, 2)*100).ToString();

                //this.litMemberBuyRate.Text = (Math.Round((double)haveOrderMember / memberQuantity, 2) * 100).ToString();

                //this.litMemberOrderQuantity.Text = (Math.Round((double)orderQuantity / memberQuantity, 2)).ToString();
            }
        }
    }
}