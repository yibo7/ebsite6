using System;
using System.Collections.Generic;

using System.Text;
using EbSite.Entity;

namespace EbSite.Base.PageLink
{
    public abstract class ILink
    {
        public int _SiteID = 1;
        public int SiteID
        {
            get
            {
                return _SiteID;
            }
            set
            {
                _SiteID = value;
            }
        }
        public EbSite.Entity.Sites CurrentSite
        {
            get
            {
               return EbSite.BLL.Sites.Instance.GetEntity(SiteID);
            }
        }
        protected string SiteFolder
        {
            get
            {
                if (SiteID > 1)
                {
                    return string.Concat(Base.AppStartInit.IISPath, CurrentSite.SiteFolder, "/");
                }
                else
                {
                    return Base.AppStartInit.IISPath;
                }

            }
        }
        protected string IISPath
        {
            get
            {
                return Base.AppStartInit.IISPath;
            }
        }

        #region 接口

        #region 手机版


        /// <summary>
        /// 获取主站首页地址
        /// </summary>
        /// <returns></returns>
        abstract public string MGetMainIndexHref();
        /// <summary>
        /// 获取标签列表地址-用来获取分类，生成静态面页用
        /// </summary>
        /// <returns></returns>
        abstract public string MTagsList(int p);
        /// <summary>
        /// 获取标签-按排序号
        /// </summary>
        /// <param name="p"></param>
        /// <param name="OrderBy">1 为最新标签 2为热门标签</param>
        /// <returns></returns>
        abstract public string MTagsList(int p, int OrderBy);
        /// <summary>
        /// 获取标签搜索结果列表地址
        /// </summary>
        /// <returns></returns>
        abstract public string MTagsSearchList(object id, int p);
        /// <summary>
        /// 获取内容页面地址
        /// </summary>
        /// <param name="HtmlPath">内容html命名</param>
        /// <returns></returns>
        abstract public string MGetContentLink(object iID, object HtmlPath);
        abstract public string MGetContentLink(object iID);

        /// <summary>
        /// 获取分类页面连接-最新排序
        /// </summary>
        /// <param name="HtmlPath">分类html命名</param>
        /// <returns></returns>
        abstract public string MGetClassHref(object iID, object HtmlPath, int pIndex);
        abstract public string MGetClassHref(object iID, object HtmlPath, int pIndex, string OutLink);
        abstract public string MGetClassHref(int iID, int Index);
        /// <summary>
        /// 获取列表-按排序号
        /// </summary>
        /// <param name="iID"></param>
        /// <param name="Index"></param>
        /// <param name="OrderBy">排序，0默认按ID排序，1按点击率排序，2按收藏排序，3按评论数排序，4好评或星级或顶一下排序，5按发布日期排序</param>
        /// <returns></returns>
        abstract public string MGetClassHref_OrderBy(int iID, int Index, int OrderBy);

        /// <summary>
        /// 获取专题连接
        /// </summary>
        /// <param name="iID">专题ID</param>
        /// <param name="Index">分页码</param>
        /// <returns></returns>
        abstract public string MGetSpecialHref(int iID, int Index);

        #endregion

        #region 电脑版


        /// <summary>
        /// 获取主站首页地址
        /// </summary>
        /// <returns></returns>
        abstract public string GetMainIndexHref();
        /// <summary>
        /// 获取标签列表地址-用来获取分类，生成静态面页用
        /// </summary>
        /// <returns></returns>
        abstract public string TagsList(int p);
        /// <summary>
        /// 获取标签-按排序号
        /// </summary>
        /// <param name="p"></param>
        /// <param name="OrderBy">1 为最新标签 2为热门标签</param>
        /// <returns></returns>
        abstract public string TagsList(int p, int OrderBy);
        /// <summary>
        /// 获取标签搜索结果列表地址
        /// </summary>
        /// <returns></returns>
        abstract public string TagsSearchList(object id, int p);
        /// <summary>
        /// 获取内容页面地址
        /// </summary>
        /// <param name="HtmlPath">内容html命名</param>
        /// <returns></returns>
        abstract public string GetContentLink(object iID, object HtmlPath);
        abstract public string GetContentLink(object iID);

        /// <summary>
        /// 获取分类页面连接-最新排序
        /// </summary>
        /// <param name="HtmlPath">分类html命名</param>
        /// <returns></returns>
        abstract public string GetClassHref(object iID, object HtmlPath, int pIndex);
        abstract public string GetClassHref(object iID, object HtmlPath, int pIndex, string OutLink);
        abstract public string GetClassHref(int iID, int Index);
        /// <summary>
        /// 获取列表-按排序号
        /// </summary>
        /// <param name="iID"></param>
        /// <param name="Index"></param>
        /// <param name="OrderBy">排序，0默认按ID排序，1按点击率排序，2按收藏排序，3按评论数排序，4好评或星级或顶一下排序，5按发布日期排序</param>
        /// <returns></returns>
        abstract public string GetClassHref_OrderBy(int iID, int Index, int OrderBy);

        /// <summary>
        /// 获取专题连接
        /// </summary>
        /// <param name="iID">专题ID</param>
        /// <param name="Index">分页码</param>
        /// <returns></returns>
        abstract public string GetSpecialHref(int iID, int Index);
        /// <summary>
        /// 个人收藏专辑连接
        /// </summary>
        /// <param name="iID">专辑ID</param>
        /// <param name="Index">页码</param>
        /// <returns></returns>
        abstract public string UserAlbumHref(int iID, int Index);
        /// <summary>
        /// 首页有分页列表情况
        /// </summary>
        /// <param name="Index"></param>
        /// <returns></returns>
        abstract public string IndexForPage(int Index);

        abstract public string GetFormUrl(string modelid);
        /// <summary>
        /// 获取第三方登录回调地址
        /// </summary>
        /// <param name="apptype">插件app名称，如 QQ,SINA</param>
        /// <returns></returns>
        abstract public string GetLoginApiBackUrl(string apptype);
        #endregion

        #endregion




        #region 电脑版

        #region 所有原生真实页面 不带参数
        public string CustomSearch
        {
            get
            {
                return CurrentSite.GetCurrentPageUrl(Base.Configs.ContentSet.ConfigsControl.Instance.CustomSearch);
            }
        }
        /// <summary>
        /// 获取首页相对路径
        /// </summary>
        public string IndexLink
        {
            get
            {
                return string.Concat(IISPath, Base.Configs.ContentSet.ConfigsControl.Instance.IndexPath);
            }
        }

        /// <summary>
        /// 获取分类页相对路径(不带参)
        /// </summary>
        public string ClassLink
        {
            get
            {
                return Base.Configs.ContentSet.ConfigsControl.Instance.ListPath;
            }
        }
        /// <summary>
        /// 获取表单页相对路径(不带参)
        /// </summary>
        public string CustomForm
        {
            get
            {
                return Base.Configs.ContentSet.ConfigsControl.Instance.CustomForm;
            }
        }
        /// <summary>
        /// 获取内容页相对路径(不带参)
        /// </summary>
        public string ContentLink
        {
            get
            {
                return Base.Configs.ContentSet.ConfigsControl.Instance.ContentPath;
            }
        }
        /// <summary>
        /// 获取专题页相对路径(不带参)
        /// </summary>
        public string SpecialLink
        {
            get
            {
                return Base.Configs.ContentSet.ConfigsControl.Instance.SpecialPath;
            }
        }
        /// <summary>
        /// 获取专题页相对路径(不带参)
        /// </summary>
        public string TaglistLink
        {
            get
            {
                return CurrentSite.GetCurrentPageUrl(Base.Configs.ContentSet.ConfigsControl.Instance.Taglist);
            }
        }
        /// <summary>
        /// 获取专题搜索页相对路径(不带参)
        /// </summary>
        public string TagsSearchListLink
        {
            get
            {
                return CurrentSite.GetCurrentPageUrl(Base.Configs.ContentSet.ConfigsControl.Instance.TagSearch);
                //return Base.Configs.ContentSet.ConfigsControl.Instance.TagSearch;
            }
        }
        public string Search
        {
            get
            {
                return CurrentSite.GetCurrentPageUrl(Base.Configs.ContentSet.ConfigsControl.Instance.Search);
            }
        }
        public string UserAlbum
        {
            get
            {
                return CurrentSite.GetCurrentPageUrl(Base.Configs.ContentSet.ConfigsControl.Instance.UserAlbum);
            }
        }

        //新加


        public string UccIndex
        {
            get
            {

                return CurrentSite.GetCurrentPageUrl(Base.Configs.ContentSet.ConfigsControl.Instance.UccIndex);
            }
        }

        //public string Uhome
        //{
        //    get
        //    {

        //        return string.Concat(IISPath, Base.Configs.ContentSet.ConfigsControl.Instance.Uhome);
        //    }
        //}

        public string LoginBind
        {
            get
            {
                return CurrentSite.GetCurrentPageUrl(Base.Configs.ContentSet.ConfigsControl.Instance.LoginBind);
            }
        }

        public string Reg
        {
            get
            {
                return CurrentSite.GetCurrentPageUrl(Base.Configs.ContentSet.ConfigsControl.Instance.Reg);
            }
        }

        public string Remark
        {
            get
            {
                return CurrentSite.GetCurrentPageUrl(Base.Configs.ContentSet.ConfigsControl.Instance.Remark);
            }
        }

        public string Lostpassword
        {
            get
            {
                return CurrentSite.GetCurrentPageUrl(Base.Configs.ContentSet.ConfigsControl.Instance.Lostpassword);
            }
        }

        public string Login
        {
            get
            {
                return CurrentSite.GetCurrentPageUrl(Base.Configs.ContentSet.ConfigsControl.Instance.Login);
            }
        }
        #endregion

        #region 所有重写页面 不带参数

       
        public string CustomFormRw
        {
            get
            {
                return Base.Configs.ContentSet.ConfigsControl.Instance.CustomFormRw;
            }
        }
        /// <summary>
        /// 获取分类页相对路径(不带参)
        /// </summary>
        public string ClassLinkRw
        {
            get
            {
                return Base.Configs.ContentSet.ConfigsControl.Instance.ListPathRw;
            }
        }
        /// <summary>
        /// 获取内容页相对路径(不带参)
        /// </summary>
        public string ContentLinkRw
        {
            get
            {
                return Base.Configs.ContentSet.ConfigsControl.Instance.ContentPathRw;
            }
        }
        /// <summary>
        /// 获取专题页相对路径(不带参)
        /// </summary>
        public string SpecialLinkRw
        {
            get
            {
                return Base.Configs.ContentSet.ConfigsControl.Instance.SpecialPathRw;
            }
        }
        /// <summary>
        /// 获取专题页相对路径(不带参)
        /// </summary>
        public string TaglistLinkRw
        {
            get
            {
                return Base.Configs.ContentSet.ConfigsControl.Instance.TaglistRw;
            }
        }
        /// <summary>
        /// 获取专题搜索页相对路径(不带参)
        /// </summary>
        public string TagsSearchListLinkRw
        {
            get
            {

                return Base.Configs.ContentSet.ConfigsControl.Instance.TagSearchRw;
            }
        }
        public string UserAlbumRw
        {
            get
            {
                return Base.Configs.ContentSet.ConfigsControl.Instance.UserAlbumRw;
            }
        }
        public string LoginbindRw
        {
            get
            {
                return Base.Configs.ContentSet.ConfigsControl.Instance.LoginbindRw;
            }
        }


        #region 以下为url带iispath
        public string CustomSearchRw
        {
            get
            {
                return string.Concat(IISPath, Base.Configs.ContentSet.ConfigsControl.Instance.CustomSearchRw);
            }
        }
        public string IndexLinkRw
        {
            get
            {
                return string.Concat(IISPath, Base.Configs.ContentSet.ConfigsControl.Instance.IndexPathRw);
            }
        }
        public string SearchRw
        {
            get
            {
                return string.Concat(IISPath, Base.Configs.ContentSet.ConfigsControl.Instance.SearchRw);
            }
        }
        public string UccIndexRw
        {
            get
            {
                return string.Concat(IISPath, Base.Configs.ContentSet.ConfigsControl.Instance.UccIndexRw);
            }
        }

        public string UhomeRw
        {
            get
            {
                return string.Concat(IISPath, Base.Configs.ContentSet.ConfigsControl.Instance.UhomeRw);
            }
        }



        public string RegRw
        {
            get
            {
                return string.Concat(IISPath, Base.Configs.ContentSet.ConfigsControl.Instance.RegRw);
            }
        }


        public string LostpasswordRw
        {
            get
            {
                return string.Concat(IISPath, Base.Configs.ContentSet.ConfigsControl.Instance.LostpasswordRw);
            }
        }

        public string LoginRw
        {
            get
            {
                return string.Concat(IISPath, Base.Configs.ContentSet.ConfigsControl.Instance.LoginRw);
            }
        }

        public string GetModulePathRw(string RwPath)
        {
            return string.Concat(IISPath, Base.Configs.SysConfigs.ConfigsControl.Instance.UserPath, RwPath, ".ashx");

        }

        #endregion


        #endregion
       
        public string GetRemark(string id,string mk)
        {
            return CurrentSite.GetCurrentPageUrl(string.Concat("discuss_", id, ".aspx?cid=", id, "&mk=", mk));
        }
        public string GetRemark(string id, string mk,string itype)
        {
            if (itype=="1")
            {
                return GetRemark( id, mk);
            }
            else
            {
                return CurrentSite.GetCurrentPageUrl(string.Concat("pj_", id, ".aspx?cid=", id, "&mk=", mk));
            }
           
        }
        public string GetErrPage(string id)
        {
            return string.Concat(EbSite.Base.Host.Instance.IISPath, "ebtips.aspx?id=", id);
        }
        public string GetErrPageRw(string id)
        {
            return string.Concat(IISPath, "err",id,".ashx");
        }
        #endregion

        #region 手机版

            #region 真实页面

        /// <summary>
        /// 获取首页相对路径
        /// </summary>
        public string MIndexLink
        {
            get
            {
                return CurrentSite.MGetCurrentPageUrl(Base.Configs.ContentSet.ConfigsControl.Instance.MIndexPath);
            }
        }
        /// <summary>
        /// 获取分类页相对路径(不带参)
        /// </summary>
        public string MClassLink
        {
            get
            {
                return CurrentSite.MGetCurrentPageUrl(Base.Configs.ContentSet.ConfigsControl.Instance.MListPath);
            }
        }
        /// <summary>
        /// 获取内容页相对路径(不带参)
        /// </summary>
        public string MContentLink
        {
            get
            {
                return CurrentSite.MGetCurrentPageUrl(Base.Configs.ContentSet.ConfigsControl.Instance.MContentPath);
            }
        }
        /// <summary>
        /// 获取专题页相对路径(不带参)
        /// </summary>
        public string MSpecialLink
        {
            get
            {
                return CurrentSite.MGetCurrentPageUrl(Base.Configs.ContentSet.ConfigsControl.Instance.MSpecialPath);
            }
        }
        /// <summary>
        /// 获取专题页相对路径(不带参)
        /// </summary>
        public string MTaglistLink
        {
            get
            {
                return CurrentSite.MGetCurrentPageUrl(Base.Configs.ContentSet.ConfigsControl.Instance.MTaglist);
            }
        }
        /// <summary>
        /// 获取专题搜索页相对路径(不带参)
        /// </summary>
        public string MTagsSearchListLink
        {
            get
            {
                return CurrentSite.MGetCurrentPageUrl(Base.Configs.ContentSet.ConfigsControl.Instance.MTagSearch);
                //return Base.Configs.ContentSet.ConfigsControl.Instance.TagSearch;
            }
        }
        public string MSearch
        {
            get
            {
                return CurrentSite.MGetCurrentPageUrl(Base.Configs.ContentSet.ConfigsControl.Instance.MSearch);
            }
        }



        public string MLogin
        {
            get
            {
                return CurrentSite.MGetCurrentPageUrl(Base.Configs.ContentSet.ConfigsControl.Instance.MLogin);
            }
        }

        public string MLostpassword
        {
            get
            {
                return CurrentSite.MGetCurrentPageUrl(Base.Configs.ContentSet.ConfigsControl.Instance.MLostpassword);
            }
        }

        public string MReg
        {
            get
            {
                return CurrentSite.MGetCurrentPageUrl(Base.Configs.ContentSet.ConfigsControl.Instance.MReg);
            }
        }

        public string MUccIndex
        {
            get
            {
                return CurrentSite.MGetCurrentPageUrl(Base.Configs.ContentSet.ConfigsControl.Instance.MUccIndex);
            }
        }
        #endregion

        #region 重写页面
        /// <summary>
        /// 获取首页相对路径
        /// </summary>
        public string MIndexLinkRw
        {
            get
            {
                return string.Concat(IISPath, Base.Configs.ContentSet.ConfigsControl.Instance.MIndexPathRw);
            }
        }

        /// <summary>
        /// 获取分类页相对路径(不带参)
        /// </summary>
        public string MClassLinkRw
        {
            get
            {
                return Base.Configs.ContentSet.ConfigsControl.Instance.MListPathRw;
            }
        }
        /// <summary>
        /// 获取内容页相对路径(不带参)
        /// </summary>
        public string MContentLinkRw
        {
            get
            {
                return Base.Configs.ContentSet.ConfigsControl.Instance.MContentPathRw;
            }
        }
        /// <summary>
        /// 获取专题页相对路径(不带参)
        /// </summary>
        public string MSpecialLinkRw
        {
            get
            {
                return Base.Configs.ContentSet.ConfigsControl.Instance.MSpecialPathRw;
            }
        }
        /// <summary>
        /// 获取专题页相对路径(不带参)
        /// </summary>
        public string MTaglistLinkRw
        {
            get
            {
                return Base.Configs.ContentSet.ConfigsControl.Instance.MTaglistRw;
            }
        }
        /// <summary>
        /// 获取专题搜索页相对路径(不带参)
        /// </summary>
        public string MTagsSearchListLinkRw
        {
            get
            {

                return Base.Configs.ContentSet.ConfigsControl.Instance.MTagSearchRw;
            }
        }

        public string MSearchRw
        {
            get
            {
                return string.Concat(IISPath, Base.Configs.ContentSet.ConfigsControl.Instance.MSearchRw);
            }
        }

        public string MLoginRw
        {
            get
            {
                return string.Concat(IISPath, Base.Configs.ContentSet.ConfigsControl.Instance.MLoginRw);
            }
        }

        public string MLostpasswordRw
        {
            get
            {
                return string.Concat(IISPath, Base.Configs.ContentSet.ConfigsControl.Instance.MLostpasswordRw);
            }
        }

        public string MRegRw
        {
            get
            {
                return string.Concat(IISPath, Base.Configs.ContentSet.ConfigsControl.Instance.MRegRw);
            }
        }

        public string MUccIndexRw
        {
            get
            {
                return string.Concat(IISPath, Base.Configs.ContentSet.ConfigsControl.Instance.MUccIndexRw);
            }
        }

        #endregion



        #endregion


    }
}
