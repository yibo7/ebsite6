using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base;
using EbSite.Base.Modules;

namespace EbSite.Modules.UserBaseInfo.UserPages.Controls.MFavorite
{
    public partial class List : MPUCBaseListForUserRpMobile
    {
        protected void Page_Load(object sender, EventArgs e)
        {
             
        }
        /// <summary>
        /// 查询分类ID
        /// </summary>
        protected int ClassID
        {
            get
            {
                if (!string.IsNullOrEmpty(Request.QueryString["tid"]))
                {
                    return int.Parse(Request.QueryString["tid"]);
                }
                else
                {
                    return 0;
                }
            }
        }
        public override Guid ModuleMenuID
        {
            get
            {
                return new Guid("13722dfd-79d6-452f-a050-9c98e0d7814b");
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
        /// 此权限ID不为空，将要求用户登录后才能访问此页面
        /// </summary>
        public override string Permission
        {
            get
            {
                return "9";
            }
        }
        /// <summary>
        /// 批量删除 在html 代码的数据列表邦定中要在每行绑定一个<input name="ebcheckboxname" value="<%#Eval("id")%>" type="checkbox" />
        /// 注意控件的名称一定要是ebcheckboxname,然后实现此方法就可以实现批量删除
        /// </summary>
        /// <param name="IDs"></param>
       protected override void Deletes(string IDs)
       {
           EbSite.BLL.Favorite.DeleteInIDs(IDs);
       }

        public int iLoadCount = 0;
        override protected object LoadList(out int iCount)
        {
            List<Entity.Favorite> ls = new List<Entity.Favorite>();
            if (ClassID > 0)
            {
                ls= BLL.Favorite.GetListPages(pcPage.PageIndex, pcPage.PageSize,
                                                 "ClassID= " + ClassID + " and UserID=" + base.UserID, "", "adddatetime desc",
                                                 out iCount);
                iLoadCount = iCount;
            }
            else
            {
                ls = BLL.Favorite.GetListPages(pcPage.PageIndex, pcPage.PageSize, "UserID=" + base.UserID, "", "adddatetime desc",
                                                 out iCount);
                iLoadCount = iCount;
            }
            return ls;
        }

        override protected object SearchList(out int iCount)
        {

            //string typeid = ucToolBar.GetItemVal(DrpList);
            //if (!string.IsNullOrEmpty(typeid))
            //{
            //    return BLL.Favorite.GetListPages(pcPage.PageIndex, pcPage.PageSize,
            //                                     "ClassID= " + typeid + " and UserID=" + base.UserID, "",
            //                                     "adddatetime desc", out iCount);
            //}
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
            //删除前先验证当前登录用户
            if (FavType == 0) //删除收藏的内容
            {
                BLL.Favorite.DeleteOfContent(int.Parse(iID.ToString()), AppStartInit.UserName);
            }
            else //删除收藏的分类
            {
                BLL.Favorite.DeleteOfClass(int.Parse(iID.ToString()), AppStartInit.UserName);
            }
            
        }

        public string ClassName(string  id)
        {
            string sinfo = "";
            if(!string.IsNullOrEmpty(id))
            {
                Entity.FavoriteClass md = BLL.FavoriteClass.GetModel(int.Parse(id));
                if(!Equals(md,null))
                {
                    sinfo = md.ClassName;
                }
            }
            return sinfo;
        }
   
    }
}