using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.Modules;
using EbSite.Base.Plugin;

namespace EbSite.Modules.UserBaseInfo.UserPages.Controls.MAddress
{
    public partial class AddressList : MPUCBaseListForUserRpMobile
    {
      
        public override bool IsAddToAdminMenus
        {
            get
            {
                return true;
            }
        }
        override protected Guid MenuAddID
        {
            get { return new Guid("08e54c45-f5ea-4c19-9a1a-e7e4afde3910"); }
        }
        override protected Guid MenuShowID
        {
            get { return new Guid("6836309c-c063-4226-a39e-a8d71e7c527d"); }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        public override int OrderID
        {
            get
            {
                return 1;
            }
        }

      
        public override Guid ModuleMenuID
        {
            get
            {
                return new Guid("fbe55c59-171b-4ae9-a3de-3c461e458cb0");
            }
        }
        public override string PageName
        {
            get
            {
                return "常用地址";
            }
        }

        /// <summary>
        /// 此权限ID不为空，将要求用户登录后才能访问此页面
        /// </summary>
        public override string Permission
        {
            get
            {
                return "10";
            }
        }


        override protected object LoadList(out int iCount)
        {
            return EbSite.BLL.Address.Instance.GetListPages(pcPage.PageIndex, pcPage.PageSize, "userid="+base.UserID, "id desc", out iCount);
            
        }
        
        override protected object SearchList(out int iCount)
        {
            return EbSite.BLL.Address.Instance.GetListPages(pcPage.PageIndex, pcPage.PageSize, string.Format(" AddressInfo like '%{0}%' ", SearchKey), "id desc", out iCount);
        }
      
        override protected void Delete(object iID)
        {
            EbSite.BLL.Address.Instance.Delete(int.Parse(iID.ToString()));
        }

        #region 工具栏的初始化

        override protected void BindToolBar()
        {
            base.BindToolBar(true,true);
            ucToolBar.AddSubMenu("分享给朋友",  "", false, "", "");
            ucToolBar.AddSubMenu("推荐给好友", "", false, "", "");
        }
        #endregion

        #region 工具栏事件扩展

        //protected override void ucToolBar_ItemClick(object source, Control.ItemClickArgs e)
        //{
        //    base.ucToolBar_ItemClick(source, e);
        //    switch (e.ItemTag)
        //    {
        //        case "good":
        //            break;
        //    }
        //}

        #endregion
    }
}