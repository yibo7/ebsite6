using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.Modules;
using EbSite.Base.Plugin;
using EbSite.Base.Plugin.Manager;
using EbSite.Modules.Shop.ModuleCore.Cart;
using EbSite.Modules.Shop.ModuleCore.Entity;

namespace EbSite.Modules.Shop.UserPages.Controls.Buy
{
    public partial class ToPay : MPUCBaseListForUserRp
    {
        public override bool EnableTagLink
        {
            get
            {
                return false;
            }
        }
        private int GetOrderID
        {
            get
            {
                if (!string.IsNullOrEmpty(Request["oid"]))
                {
                    return int.Parse(Request["oid"]);
                }
                return 0;
            }
        }
        protected ModuleCore.Entity.Buy_Orders mdOrder = new Buy_Orders();
       
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        public override string PageName
        {
            get
            {
                return "3.订单支付";
            }
        }
        public override string TipsText
        {
            get
            {
                return "请选择以下支付方式";
            }
        }
        public override bool IsAddToAdminMenus
        {
            get
            {
                return true;
            }
        }
        public override int OrderID
        {
            get
            {
                return 4;
            }
        }
        /// <summary>
        /// 此权限ID不为空，将要求用户登录后才能访问此页面
        /// </summary>
        public override string Permission
        {
            get
            {
                return "";
            }
        }
       
        override public Guid ModuleMenuID
        {
            get
            {
                return new Guid("579ce925-18b0-4060-a7ec-eb35f5df51b5");
            }
        }
        override protected object LoadList(out int iCount)
        {
            iCount = 0;
            if (GetOrderID > 0)
            {
                ModuleCore.Entity.Buy_Orders md = ModuleCore.BLL.Buy_Orders.Instance.GetEntity(GetOrderID);
                if (md != null)
                {

                    mdOrder = md;
                    ProfileCommon profile = (ProfileCommon)HttpContext.Current.Profile;
                    profile.ShopCart.Clear();
                }

            }
            //decimal dPrice = mdOrder.Price;
            
            //string sOrderName = string.Concat(Core.Strings.GetString.MakeName(), "-", mdOrder.id);
            string sOrderName = string.Concat(CurrentSite.SiteName, "[订单号:", mdOrder.OrderId, "]");

            List<PaymentUseingInfo> lstRz1 = PluginManager.Instance.GetPayments(sOrderName, mdOrder.Amount.ToString(), mdOrder.OrderId.ToString());
            return lstRz1;

        }

        override protected object SearchList(out int iCount)
        {
            iCount = 0;
            return null;
        }
        override protected void Delete(object iID)
        {

        }
        
       
    }
}