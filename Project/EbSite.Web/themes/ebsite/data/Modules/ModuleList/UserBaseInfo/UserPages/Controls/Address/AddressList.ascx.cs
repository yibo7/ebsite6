using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.Modules;
using EbSite.Base.Plugin;

namespace EbSite.Modules.UserBaseInfo.UserPages.Controls.Address
{
    public partial class AddressList : MPUCBaseListForUserRp
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if(UserID<1)
            {
                Tips("请先登录", "本页面需要登录内能访问!");
            }
        }
       
      
        public override Guid ModuleMenuID
        {
            get
            {
                
                return new Guid("a20e4ef2-6061-4813-ab67-d5a932586309");
            }
        }
        protected override Guid MenuAddID
        {
            get
            {
                return new Guid("2517cc88-cbb5-4b00-ac5c-32285c9b9889");
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
                return "";
            }
        }

        public override bool IsCloseTagsItem
        {
            get
            {
                return false;
            }
        }
        public int iLoadCount = 0;
        override protected object LoadList(out int iCount)
        {
            iCount = 0;
            List<EbSite.Entity.Address> ls =EbSite.BLL.Address.Instance.GetListPages(pcPage.PageIndex, pcPage.PageSize,"UserID=" + base.UserID, "", "id desc",out iCount);
            iLoadCount = iCount;
            return ls;
            
        }
        
        override protected object SearchList(out int iCount)
        {
            iCount = 0;
            return null;
        }
      
        override protected void Delete(object iID)
        {
            EbSite.BLL.Address.Instance.Delete(int.Parse(iID.ToString()));
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