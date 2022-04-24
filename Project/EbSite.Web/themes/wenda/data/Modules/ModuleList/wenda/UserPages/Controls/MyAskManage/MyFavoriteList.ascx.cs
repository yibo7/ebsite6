using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.Modules;
using EbSite.Entity;

namespace EbSite.Modules.Wenda.UserPages.Controls.MyAskManage
{
    public partial class MyFavoriteList : MPUCBaseListForUserRp
    {
        public override Guid ModuleMenuID
        {
            get
            {
                return new Guid("382a55c7-5c40-4b75-97c6-ce271117d9d3");
            }
        }
        public override string PageName
        {
            get
            {
                return "我的收藏";
            }
        }
        /// <summary>
        /// 是否添加到管理页面菜单之中
        /// </summary>
        public override bool IsAddToAdminMenus
        {
            get
            {
                return false;
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
                return 4;
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
            string strsql = "UserID=" + base.UserID;
            List<Entity.Favorite> ls = EbSite.BLL.Favorite.GetListPages(pcPage.PageIndex, iPageSize, strsql, out iCount, 0);
            iLoadCount = iCount;
            string xstr = "";
            foreach (Favorite favorite in ls)
            {
                xstr += favorite.ContentID + ",";
            }
            if (xstr.Length > 0)
            {
                xstr = xstr.Remove(xstr.Length - 1, 1);
            }
            else
            {
                xstr = "0";
            }

            List<Entity.NewsContent> nls = Base.AppStartInit.NewsContentInstDefault.GetListArray("id in(" + xstr + ")", 0, "", "", 2);

            return nls;

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