using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.Page;
using EbSite.BLL.GetLink;
using EbSite.BLL.User;
using EbSite.Entity;

namespace EbSite.Web.Pages
{
    /// <summary>
    /// 个人收藏专辑列表页面
    /// </summary>
    public partial class album : BasePage
    {
        protected int CUserID = 0;
        /// <summary>
        /// 当前专辑ID
        /// </summary>
        protected int GetAlbumID
        {
            get
            {
               return Core.Utils.StrToInt(Request["al"], 0);
            }
        }
        ///// <summary>
        ///// 当前用户ID
        ///// </summary>
        //protected int CurrentUID
        //{
        //    get
        //    {
        //        return Core.Utils.StrToInt(Request["u"], 0);
        //    }
        //}
   
        private int iPageSize
        {
            get
            {
               if (pgCtr.PageSize > 0)
                {
                    return pgCtr.PageSize;
                }
                else
                {
                    return 15;
                }

            }

        }
        protected Entity.FavoriteClass Model = new Entity.FavoriteClass();
        protected EbSite.Base.EntityAPI.MembershipUserEb AlbumUserInfo;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request["uid"]))
            {
                CUserID =  int.Parse(Request["uid"]);
            }

            if(!IsPostBack)
            {
                if (CUserID > 0)
                {
                    AlbumUserInfo = MembershipUserEb.Instance.GetEntity(CUserID);
                    bindinfo();
                    inithead();
                    intpages();
                }
                else
                {
                    Tips("出错了","请输入正确的访问地址！");
                }
                
            }
        }
        protected int iSearchCount = 0;
        private void bindinfo()
        {
            if (GetAlbumID > 0)
            {
                Model = EbSite.BLL.FavoriteClass.GetModel(GetAlbumID);
            }
            else
            {
                Model = new FavoriteClass();
                Model.ClassName = "默认收藏盒";
            }
            

            rpAlbum.DataSource = EbSite.BLL.FavoriteClass.GetListByUserID(CUserID);
            rpAlbum.DataBind();

            rpContentList.DataSource = EbSite.BLL.Favorite.GetListPages(pgCtr.PageIndex, iPageSize, "", out iSearchCount, GetAlbumID, CUserID);
            rpContentList.DataBind();


        }
        private void intpages()
        {
            if (!Equals(pgCtr, null))
            {

                //这有点不好理解,以重构
                //pgCtr.ReWritePatchUrl = string.Concat(GetAlbumID, "-{0}",  HrefFactory.GetInstance(GetSiteID).UserAlbumRw); //{0} 页码
                pgCtr.ReWritePatchUrl = string.Concat(GetAlbumID, "-{0}", HostApi.UserAlbumRw(GetSiteID)); //{0} 页码
                pgCtr.AllCount = iSearchCount;
                pgCtr.PageSize = iPageSize;
                pgCtr.OtherPram = string.Format("album,{0}", GetAlbumID);
                pgCtr.CurrentClass = "CurrentPageCoder";
                pgCtr.ParentClass = "PagesClass";
            }

        }
        private void inithead()
        {
            //base.SeoTitle = GetSeoWord(Base.Configs.ContentSet.ConfigsControl.Instance.SeoClassTitle, Model.ClassName);
            //base.SeoKeyWord = GetSeoWord(Base.Configs.ContentSet.ConfigsControl.Instance.SeoClassKeyWord, Model.ClassName);
            //base.SeoDes = GetSeoWord(Base.Configs.ContentSet.ConfigsControl.Instance.SeoClassDes, Model.ClassName);

            base.SeoTitle = GetSeoWord(SeoSite.SeoClassTitle, Model.ClassName);
            base.SeoKeyWord = GetSeoWord(SeoSite.SeoClassKeyWord, Model.ClassName);
            base.SeoDes = GetSeoWord(SeoSite.SeoClassDes, Model.ClassName);
        }

        /// <summary>
        /// 获取当前分类的样式
        /// </summary>
        /// <param name="ob">当前分类ID</param>
        /// <param name="sCurrentClassName">当前样式名称</param>
        /// <returns></returns>
        protected string GetCurrentClass(object obid, string sCurrentClassName)
        {
            string sCss = "";

            if (!Equals(obid, null))
            {
                int ID = int.Parse(obid.ToString());

                if (ID == GetAlbumID) //先判断当前分类ID
                {
                    sCss = sCurrentClassName;
                }
            }

            return sCss;
        }
        protected string GetNav(string Nav)
        {
            return GetNav(Nav, true, 0);
        }
        protected string GetNav(string Nav, bool IsAddCurrent)
        {
            return GetNav(Nav, IsAddCurrent, 0);
        }
        override protected string GetNav(string Nav, bool IsAddCurrent, int FilterClassID)
        {
            return string.Concat("<a href='", BLL.GetLink.LinkOrther.Instance.GetInstance(GetSiteID).GetMainIndexHref(), "'>", SiteName, "</a>", Nav, "<a href='",Request.RawUrl,"'>", AlbumUserInfo.NiName, "的收藏夹</a>");
        }
        
    }
}