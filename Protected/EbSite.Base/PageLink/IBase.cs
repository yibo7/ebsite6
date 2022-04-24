using System;
using System.Collections.Generic;

using System.Text;
using EbSite.Core.HttpModules;
using EbSite.Entity;

namespace EbSite.Base.PageLink
{
    public abstract class IBase
    {

        #region 供静态页面使用

        private bool _isShowDefault = false;

        /// <summary>
        /// 设置是否显示默认文件名称，如/music/2562/default.html,不设置为目录路径,如/music/2562/
        /// </summary>
        public bool isShowDefault
        {
            get
            {
                return _isShowDefault;
            }
            set
            {
                _isShowDefault = value;
            }
        }
        /// <summary>
        /// 获取默认文件名称
        /// </summary>
        protected string sDefaultName
        {
            get
            {
                if (!isShowDefault)
                {

                    if (!string.IsNullOrEmpty(Base.Configs.HtmlConfigs.ConfigsControl.Instance.DefualtName.Trim()))
                    {
                        return "/";
                    }
                    return string.Empty;
                }
                else
                {
                    return string.Concat("/", Base.Configs.HtmlConfigs.ConfigsControl.Instance.DefualtName);
                }
            }
        }
        /// <summary>
        /// 生成静态页面时不用 IISPath
        /// </summary>
        protected string IISPathFormHtml
        {
            get
            {
                if (!isShowDefault)
                {
                    return SiteFolder;
                }
                else
                {
                    if (SiteID > 1)
                    {
                        return CurrentSite.SiteFolder;
                    }
                    else
                    {
                        return "";
                    }

                }
            }
        }
        protected string PageSplit
        {
            get
            {
                return Base.Configs.HtmlConfigs.ConfigsControl.Instance.PageSplit;
            }
        }

        #endregion

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
                    return string.Concat(EbSite.Base.AppStartInit.IISPath, CurrentSite.SiteFolder, "/");
                }
                else
                {
                    return EbSite.Base.AppStartInit.IISPath;
                }

            }
        }
        protected string IISPath
        {
            get
            {
                return EbSite.Base.AppStartInit.IISPath;
            }
        }

        




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
        /// 所有分类页面
        /// </summary>
        public string ClassLinkAll
        {
            get
            {
                return Base.Configs.ContentSet.ConfigsControl.Instance.ListPath;// CurrentSite.GetCurrentPageUrl();
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


       
        public string UserDefaultInfo
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

        public string Payment
        {
            get
            {
                return CurrentSite.GetCurrentPageUrl(Base.Configs.ContentSet.ConfigsControl.Instance.Payment);
            }
        }

        public string Delivery
        {
            get
            {
                return CurrentSite.GetCurrentPageUrl(Base.Configs.ContentSet.ConfigsControl.Instance.Delivery);
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

        //cqs 2013-7-11

        public string Frdlink
        {
            get
            {
                return CurrentSite.GetCurrentPageUrl(Base.Configs.ContentSet.ConfigsControl.Instance.Frdlink);
            }
        }

        public string UccIndex
        {
            get
            {
                string UccIndexPageName = EbSite.BLL.User.UserGroupProfile.ManageIndexPageNameByUserID(EbSite.Base.AppStartInit.UserID);

                return CurrentSite.GetCurrentPageUrl(string.IsNullOrEmpty(UccIndexPageName) 
                    ? Base.Configs.ContentSet.ConfigsControl.Instance.UccIndex : UccIndexPageName);
                //return CurrentSite.GetCurrentPageUrl(Base.Configs.ContentSet.ConfigsControl.Instance.UccIndex);
            }
        }
        public string UserInfo(object UserID)
        {
            string UserInfoPage = EbSite.BLL.User.UserGroupProfile.UserInfoPageNameByUserID(UserID);

            return CurrentSite.GetCurrentPageUrl(string.IsNullOrEmpty(UserInfoPage) ? Base.Configs.ContentSet.ConfigsControl.Instance.UserInfo : UserInfoPage);
            
        }
        public string FrdlinkPost
        {
            get
            {
                return CurrentSite.GetCurrentPageUrl(Base.Configs.ContentSet.ConfigsControl.Instance.FrdlinkPost);
            }
        }
        public string VotePost
        {
            get
            {
                return CurrentSite.GetCurrentPageUrl(Base.Configs.ContentSet.ConfigsControl.Instance.VotePost);
            }
        }
        public string VoteView
        {
            get
            {
                return CurrentSite.GetCurrentPageUrl(Base.Configs.ContentSet.ConfigsControl.Instance.VoteView);
            }
        }
        //public string Album
        //{
        //    get
        //    {
        //        return CurrentSite.GetCurrentPageUrl(Base.Configs.ContentSet.ConfigsControl.Instance.Album);
        //    }
        //}
        public string Top
        {
            get
            {
                return CurrentSite.GetCurrentPageUrl(Base.Configs.ContentSet.ConfigsControl.Instance.Top);
            }
        }
        public string UserOnline
        {
            get
            {
                return CurrentSite.GetCurrentPageUrl(Base.Configs.ContentSet.ConfigsControl.Instance.UserOnline);
            }
        }


        #endregion

        #region 所有重写页面 不带参数  这些属性要在方法里调用，所以不用加iispath

       
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

        public string ClassLinkAllRw
        {
            get
            {
                return Base.Configs.ContentSet.ConfigsControl.Instance.ListPathAllRw;
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

        //cqs2013 7 11

        public string VotePostRw
        {
            get
            {
                return Base.Configs.ContentSet.ConfigsControl.Instance.VotePostRw;
            }
        }
        public string TopRw
        {
            get
            {
                return Base.Configs.ContentSet.ConfigsControl.Instance.TopRw;
            }
        }
        public string VoteViewRw
        {
            get
            {
                return Base.Configs.ContentSet.ConfigsControl.Instance.VoteViewRw;
            }
        }

        public string UserInfoRw
        {
            get
            {
                return Base.Configs.ContentSet.ConfigsControl.Instance.UserInfoRw;
            }
        }
        #region 以下为url带iispath


        //cqs 2013-7-11

        public string FrdlinkRw
        {
            get
            {
                return   string.Concat(IISPath, Base.Configs.ContentSet.ConfigsControl.Instance.FrdlinkRw);
            }
        }
        
        public string FrdlinkPostRw
        {
            get
            {
                return string.Concat(IISPath, Base.Configs.ContentSet.ConfigsControl.Instance.FrdlinkPostRw);
            }
        }


 
        public string UserOnlineRw
        {
            get
            {
                return string.Concat(IISPath, Base.Configs.ContentSet.ConfigsControl.Instance.UserOnlineRw);
            }
        }
        //end

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
        public string PaymentRw
        {
            get
            {
                return string.Concat(IISPath, Base.Configs.ContentSet.ConfigsControl.Instance.PaymentRw);
            }
        }

        public string DeliveryRw
        {
            get
            {
                return string.Concat(IISPath, Base.Configs.ContentSet.ConfigsControl.Instance.DeliveryRw);
            }
        }

        public string GetModulePathRw(string RwPath)
        {
            return string.Concat(IISPath, Base.Configs.SysConfigs.ConfigsControl.Instance.UserPath, RwPath, ".ashx");

        }

        #endregion


        #endregion 这些页面都是以动态Url展示的页面，所以放在基类统一调用

        



        //public string GetFrdlink(int itype, int PageIndex)
        //{
        //    return string.Concat(IISPath, "top.ashx?t=", itype, "&p=", PageIndex);
        //}
        //public string GetFrdlinkPost(int itype, int PageIndex)
        //{
        //    return string.Concat(IISPath, "top.ashx?t=", itype, "&p=", PageIndex);
        //}



        public string GetRemark(string id,int classid,int contentid)
        {
            return EbSite.Base.Host.Instance.GetDiscussHref(id, 1, SiteID, 0, classid, contentid);
            //return CurrentSite.GetCurrentPageUrl(string.Concat("discuss_", id, ".aspx?cid=", id, "&mk=", mk, "&site=", SiteID));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="mk"></param>
        /// <param name="itype">类别 1.盖楼式评论,2.好评系统 3.一问一答</param>
        /// <returns></returns>
        public string GetRemark(string id,   int itype, int ipage, int classid, int contentid)
        {
            return EbSite.Base.Host.Instance.GetDiscussHref(id, itype, SiteID, ipage, classid, contentid);
            //if (itype=="1")
            //{
            //    return GetRemark( id, mk);
            //}
            //else if(itype=="3")
            //{
            //    return CurrentSite.GetCurrentPageUrl(string.Concat("ask_", id, ".aspx?cid=", id, "&mk=", mk, "&site=", SiteID));
            //}
            //else
            //{
            //    return CurrentSite.GetCurrentPageUrl(string.Concat("pj_", id, ".aspx?cid=", id, "&mk=", mk, "&site=", SiteID));
            //}
           
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
                return string.Concat(IISPath,Base.Configs.ContentSet.ConfigsControl.Instance.MIndexPath);
            }
        }
        /// <summary>
        /// 获取分类页相对路径(不带参)
        /// </summary>
        public string MClassLink
        {
            get
            {
                return string.Concat(IISPath,Base.Configs.ContentSet.ConfigsControl.Instance.MListPath);
            }
        }
        /// <summary>
        /// 获取内容页相对路径(不带参)
        /// </summary>
        public string MContentLink
        {
            get
            {
                return string.Concat(IISPath, Base.Configs.ContentSet.ConfigsControl.Instance.MContentPath);
            }
        }
        /// <summary>
        /// 获取专题页相对路径(不带参)
        /// </summary>
        public string MSpecialLink
        {
            get
            {
                return string.Concat(IISPath, Base.Configs.ContentSet.ConfigsControl.Instance.MSpecialPath);
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
        public string MUccUserInfo
        {
            get
            {
                return CurrentSite.MGetCurrentPageUrl(Base.Configs.ContentSet.ConfigsControl.Instance.MUccUserInfo);
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
                return Base.Configs.ContentSet.ConfigsControl.Instance.MIndexPathRw;// string.Concat(AppStartInit.MPathUrl, Base.Configs.ContentSet.ConfigsControl.Instance.MIndexPathRw);
            }
        }
        public string MIndexLinkNoPramRw
        {
            get
            {
                return  string.Concat(AppStartInit.MPathUrl, Base.Configs.ContentSet.ConfigsControl.Instance.MIndexPathRw);
            }
        }
        /// <summary>
        /// 获取分类页相对路径(不带参)
        /// </summary>
        public string MClassLinkRw
        {
            get
            {
                return Base.Configs.ContentSet.ConfigsControl.Instance.MListPathRw;//string.Concat(AppStartInit.MPathUrl,);
            }
        }
        /// <summary>
        /// 获取内容页相对路径(不带参)
        /// </summary>
        public string MContentLinkRw
        {
            get
            {
                return Base.Configs.ContentSet.ConfigsControl.Instance.MContentPathRw;// string.Concat(AppStartInit.MPathUrl,);
            }
        }
        /// <summary>
        /// 获取专题页相对路径(不带参)
        /// </summary>
        public string MSpecialLinkRw
        {
            get
            {
                return Base.Configs.ContentSet.ConfigsControl.Instance.MSpecialPathRw;//string.Concat(AppStartInit.MPathUrl,);
            }
        }
        /// <summary>
        /// 获取专题页相对路径(不带参)
        /// </summary>
        public string MTaglistLinkRw
        {
            get
            {
                return string.Concat(AppStartInit.MPathUrl,Base.Configs.ContentSet.ConfigsControl.Instance.MTaglistRw);
            }
        }
        /// <summary>
        /// 获取专题搜索页相对路径(不带参)
        /// </summary>
        public string MTagsSearchListLinkRw
        {
            get
            {

                return string.Concat(AppStartInit.MPathUrl,Base.Configs.ContentSet.ConfigsControl.Instance.MTagSearchRw);
            }
        }

        public string MSearchRw
        {
            get
            {
                return string.Concat(AppStartInit.MPathUrl, Base.Configs.ContentSet.ConfigsControl.Instance.MSearchRw);
            }
        }

        public string MLoginRw
        {
            get
            {
                return string.Concat(AppStartInit.MPathUrl, Base.Configs.ContentSet.ConfigsControl.Instance.MLoginRw);
            }
        }

        public string MLostpasswordRw
        {
            get
            {
                return string.Concat(AppStartInit.MPathUrl, Base.Configs.ContentSet.ConfigsControl.Instance.MLostpasswordRw);
            }
        }

        public string MRegRw
        {
            get
            {
                return string.Concat(AppStartInit.MPathUrl, Base.Configs.ContentSet.ConfigsControl.Instance.MRegRw);
            }
        }

        public string MUccIndexRw
        {
            get
            {
                return string.Concat(AppStartInit.MPathUrl, Base.Configs.ContentSet.ConfigsControl.Instance.MUccIndexRw);
            }
        }
        public string MUccUserInfoRw
        {
            get
            {
                return string.Concat(AppStartInit.MPathUrl, Base.Configs.ContentSet.ConfigsControl.Instance.MUccUserInfoRw);
            }
        }
        #endregion



        #endregion


    }
}
