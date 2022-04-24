using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base;
using EbSite.Base.Modules;
using EbSite.Control;
using EbSite.Entity;

namespace EbSite.Modules.UserBaseInfo.UserPages.Controls.Favorite
{
    public partial class ClassList : MPUCBaseListForUserRp
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
           
        }
        public override int OrderID
        {
            get
            {
                return 2;
            }
        }
        protected override Guid MenuAddID
        {
            get
            {
                return new Guid("ce3670a8-c31b-4913-bb26-1214717f5df5");
            }
        }
        public override Guid ModuleMenuID
        {
            get
            {
                return new Guid("908b499b-131f-4521-88fa-9c16161ac5bd");
            }
        }
        public override string PageName
        {
            get
            {
                return "收藏分类";
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
                return "9";
            }
        }

       
       override protected string AddUrlType
        {
            get
            {
                return "1";
            }

        }
       protected override string ShowUrlType
       {
           get { return "4"; }
       }
        

        public int iLoadCount = 0;
        override protected object LoadList(out int iCount)
        {
            List<Entity.FavoriteClass> ls = new List<FavoriteClass>();
            iCount = 0;
            ls= BLL.FavoriteClass.GetListPages( pcPage.PageIndex, pcPage.PageSize,"UserID="+base.UserID,"","", out iCount);
            iLoadCount = iCount;
            
            return ls;

        }

        override protected object SearchList(out int iCount)
        {
            iCount = 0;
            return null;
        }
        /// <summary>
        /// 收藏类别0表示内容 1表示分类
        /// </summary>
        private int FavType
        {
            get
            {
                if (!string.IsNullOrEmpty(Request["ft"]))
                {
                    return int.Parse(Request["ft"]);
                }
                return 0;
            }
        }
        override protected void Delete(object iID)
        {
            //删除分类
            BLL.FavoriteClass.Delete(int.Parse(iID.ToString()), AppStartInit.UserName);
            //删除分类下的收藏文件
            List<Entity.Favorite> ls = BLL.Favorite.GetListArr(0, "ClassID=" + iID + " and UserID="+base.UserID, "id desc");
            if(ls.Count>0)
            {
                foreach (Entity.Favorite favorite in ls)
                {
                    BLL.Favorite.DeleteOfContent(favorite.ID,base.UserName);
                }
            }
        }


        #region 工具栏的初始化

        override protected void BindToolBar()
        {

            base.BindToolBar(true, true);
            ucToolBar.AddBnt("添加", "/images/menus/add.gif", "", false, "OpenAddPage()", "");
           


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