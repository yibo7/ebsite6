using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.Modules;
using EbSite.Base.Plugin;

namespace EbSite.Modules.UserBaseInfo.UserPages.Controls.Friends
{
    public partial class FriendList : MPUCBaseListForUserRp
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (UserID < 1)
            {
                Tips("请先登录", "本页面需要登录内能访问!");
            }
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
                return new Guid("3592269c-9b74-4f85-b82e-19e08b30e435");
            }
        }
        public override string PageName
        {
            get
            {
                return "好友列表";
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
  
        public int iLoadCount = 0;
        override protected object LoadList(out int iCount)
        {
            iCount = 0;
            return EbSite.BLL.FriendList.GetList_All(UserID, 0);

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

        override protected void BindToolBar()
        {
            base.BindToolBar(true,true);
            ucToolBar.AddBnt("添加", "/images/menus/add.gif", "", false, "OpenAddPage()", "");
        }
        #endregion
    }
}