using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.Modules;
using EbSite.Modules.Shop.ModuleCore.Entity;

namespace EbSite.Modules.Shop.UserPages.Controls.Buy
{
    public partial class ReceiveUserInfo : MPUCBaseSaveForUser
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            txtUserName.Text = base.UserNiname;
        }
        public override bool EnableTagLink
        {
            get
            {
                return false;
            }
        }
        
        public override string PageName
        {
            get
            {
                return "2.订单提交";
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
                return 2;
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
        override protected string KeyColumnName
        {
            get
            {
                return "id";
            }
        }
        override public Guid ModuleMenuID
        {
            get
            {
                return new Guid("3cad0800-1f61-4774-9efd-fe5ce560c4da");
            }
        }

        override protected void InitModifyCtr()
        {

            //EbSite.BLL.SpaceSetting.Instance.InitModifyCtr(SID, phCtrList);
        }
        protected void bntSave2_OnClick(object sender,EventArgs e)
        {
           // ModuleCore.Entity.Buy_Orders mdOrder = new ModuleCore.Entity.Buy_Orders();
           // mdOrder.ReceiveName = txtUserName.Text;
           // mdOrder.ReceiveSex = int.Parse(rblCH.SelectedValue);
           // mdOrder.ReceiveAddress = txtAress.Text;
           // mdOrder.ReceivePostCode = txtPostCode.Text;
           // mdOrder.ReceiveTel = txtTel.Text;
           // mdOrder.ReceiveMobile = txtMobile.Text;
           // mdOrder.ReceiveEmail = txtEmail.Text;
           // mdOrder.UserName = UserName;
           // mdOrder.Date = DateTime.Now;
           //int iOrderID =  ModuleCore.BLL.Buy_Order.Instance.AddOrder(mdOrder);

           //RunJs("gotonext(" + iOrderID + ");");
        }
        override protected void SaveModel()
        {
           
            //gotonext
        }
    }
}