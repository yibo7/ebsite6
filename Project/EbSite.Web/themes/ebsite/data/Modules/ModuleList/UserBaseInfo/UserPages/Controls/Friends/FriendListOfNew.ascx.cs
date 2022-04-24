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
    public partial class FriendListOfNew : MPUCBaseListForUserRp
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (UserID > 0)
            {
                if (!string.IsNullOrEmpty(Request["opt"]) && !string.IsNullOrEmpty(Request["id"]))
               {
                   int iopt = int.Parse(Request["opt"]);
                   int dataid = int.Parse(Request["id"]);
                   if (iopt == 1)//通过
                   {
                        BLL.FriendList.GetModel(dataid).Allow();

                   }
                   else if (iopt == 2)//拒绝
                   {
                       BLL.FriendList.DataDelete(dataid);
                   }
                   else
                   {
                       Tips("出错了", "传入的地址有误!"); 
                   }

                    Response.Redirect(GetUrl);

               }
            }
            else
            {
                Tips("请先登录", "本页面需要登录内能访问!"); 
            }
        }

        public override int OrderID
        {
            get
            {
                return 2;
            }
        }
        public override Guid ModuleMenuID
        {
            get
            {
                return new Guid("bcf131f0-a9aa-4597-9fd4-8350ebffe171");
            }
        }
        public override string PageName
        {
            get
            {
                return "新朋友";
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

        override protected object LoadList(out int iCount)
        {
            iCount = 0;
           return EbSite.BLL.FriendList.GetList_ByMyAllow(UserID);
          
            
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