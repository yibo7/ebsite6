using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.Modules;

namespace EbSite.Modules.Wenda.UserPages.Controls.MyAskManage
{
    public partial class MyAskList : MPUCBaseListForUserRp
    {
        public override Guid ModuleMenuID
        {
            get
            {
                return new Guid("3d28edf0-4a32-4aaa-a508-191c62dbcbd0");
            }
        }
        public override string PageName
        {
            get
            {
                return "我的提问";
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
        //public override bool IsCloseTagsTitle
        //{
        //    get
        //    {
        //        return true;
        //    }
        //}
        public override int OrderID
        {
            get
            {
                return 1;
            }
        }

        protected string GetModifyUrl
        {
            get
            {
                return "?box=1&t=0&id=";
            }
        }

        protected int iLoadCount = 0;
        override protected object LoadList(out int iCount)
        {

            
          
            string strsql = " userid =" + base.UserID;
            List<Entity.NewsContent> ls = Base.AppStartInit.NewsContentInstDefault.GetListPages(pcPage.PageIndex, iPageSize, strsql, out iCount, GetSiteID);
            iLoadCount =iCount;
            return ls;
        }

        override protected object SearchList(out int iCount)
        {
            iCount = 0;
            return null;
        }
        override protected void Delete(object iID)
        {
            Base.AppStartInit.NewsContentInstDefault.Delete(int.Parse(iID.ToString()),GetSiteID);
        }
    }
}