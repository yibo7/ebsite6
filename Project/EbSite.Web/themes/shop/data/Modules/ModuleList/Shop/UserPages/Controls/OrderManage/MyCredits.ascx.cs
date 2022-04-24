using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base;
using EbSite.Base.Modules;

namespace EbSite.Modules.Shop.UserPages.Controls.OrderManage
{
    public partial class MyCredits : MPUCBaseListForUserRp
    {

        public override Guid ModuleMenuID
        {
            get
            {
                return new Guid("a99761f4-c219-4b1e-bdc1-3e1450a4ba57");
            }
        }
      
        public override string PageName
        {
            get
            {

                return "我的积分";
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
        /// 此权限ID不为空，将要求用户登录后才能访问此页面
        /// </summary>
        public override string Permission
        {
            get
            {
                return "2";
            }
        }
      

        public int iLoadCount = 0;
        override protected object LoadList(out int iCount)
        {
            return ModuleCore.BLL.pointdetails.Instance.GetListPages(this.pcPage.PageIndex, this.pcPage.PageSize, "UserId=" + base.UserID, "",
                                                                  out iCount);
        }

        override protected object SearchList(out int iCount)
        {

            iCount = 0;
            return null;
        }
        
        override protected void Delete(object iID)
        {
           

        }

        #region 工具栏的初始化
       

        protected Label Lb = new Label();
        protected Label LbScore = new Label();
        override protected void BindToolBar()
        {

            base.BindToolBar(true, true);
            //ucToolBar.AddLine();
            Lb.ID = "Lb";
            Lb.Text = "您当前的有效积分为";
            ucToolBar.AddCtr(Lb);
            LbScore.ID = "LbScore";
            if (EbSite.Base.Host.Instance.UserID > 0)
            {
                 LbScore.Text = EbSite.Base.Host.Instance.GetUserCreditsByID(EbSite.Base.Host.Instance.UserID).ToString()+"分";
            }
           ucToolBar.AddCtr(LbScore);

        }
        #endregion

        #region 工具栏事件扩展

       
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {

        }
         //兑换礼品 = 1,
         //   购物奖励 = 2,
         //   退款扣积分 = 3,
         //   关闭订单返还积分=4,
         //   关闭订单扣除奖励积分=5
          //兑换优惠券=6
        public string TypeName(string id)
        {
            string s = "";
            switch (id)
            {
                case  "1":
                    s = "兑换礼品";
                    break;
                case "2":
                    s = "购物奖励";
                    break;
                case "3":
                    s = "退款扣积分";
                    break;
                case "4":
                    s = "关闭订单返还积分";
                    break;
                case "5":
                    s = "关闭订单扣除奖励积分";
                    break;
                case "6":
                    s = "兑换优惠券";
                    break;
            }
            return s;
        }
    }
}