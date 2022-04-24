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
    public partial class MyCoupons : MPUCBaseListForUserRp
    {

        public override Guid ModuleMenuID
        {
            get
            {
                return new Guid("ef829fbf-ec13-4370-8677-387f3e1ace07");
            }
        }
       
        public override string PageName
        {
            get
            {

                return "我的优惠券";
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
                return "3";
            }
        }
        
       
        override protected object LoadList(out int iCount)
        {
            iCount = 0;
            return EbSite.BLL.CouponItems.Instance.Union_GetListArray(0, " b.EndDateTime>NOW() and Status=0 and a.UserId=" + base.UserID, "");
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
        protected DropDownList DrpList = new DropDownList();
        protected System.Web.UI.WebControls.TextBox tb = new TextBox();
        override protected void BindToolBar()
        {

            base.BindToolBar(true, true);
            //ucToolBar.AddLine();
            Lb.ID = "Lb";
            Lb.Text = "优惠券号码";
            ucToolBar.AddCtr(Lb);
            tb.ID = "tb";
            ucToolBar.AddCtr(tb);
           

            ucToolBar.AddBnt("添加", IISPath + "images/menus/add.gif", "add");
        }
        #endregion

        #region 工具栏事件扩展

        protected override void ucToolBar_ItemClick(object source, Control.ItemClickArgs e)
        {
            base.ucToolBar_ItemClick(source, e);
            switch (e.ItemTag)
            {
                case "add":
                    string ClaimCode = ucToolBar.GetItemVal(tb);
                    if (string.IsNullOrEmpty(ClaimCode))
                    {
                       TipsAlert("请添写优惠券号码!");
                    }
                    else
                    {
                        //先验证存在吗？
                        //有没有分配出去
                        //分给此用户
                        EbSite.Entity.CouponItems md = EbSite.BLL.CouponItems.Instance.GetEntity(ClaimCode);
                        if (!Equals(md, null))
                        {
                            if (md.UserId > 0)
                            {
                                TipsAlert("你输入的优惠券号码无效，请重试!");
                            }
                            else
                            {
                                md.UserId = base.UserID;
                                md.Update();
                             
                                TipsAlert("操作成功！");
                            }

                           
                        }
                        else
                        {
                            TipsAlert("你输入的优惠券号码无效，请重试!");
                        }
                    }
                    break;
            }
        }

        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}