
using EbSite.BLL.GetLink;

namespace EbSite.Base
{
    /// <summary>
    /// 手机版连接
    /// </summary>
    public partial class Host 
    {

        
        public string MobileBarcode
        {
            get
            {
                return string.Concat(IISPath, "barcode/site", GetSiteID, ".gif");
            }
        }

        public void GoToLoginM()
        {
            AppStartInit.MUserLoginReurl();
        }
        #region 手机版连接
        /// <summary>
        /// 用户信息详细页
        /// </summary>
        public string MUccUserInfoRw
        {
            get
            {
                return Base.PageLink.GetBaseLinks.GetDefault.MUccUserInfoRw;
            }
        }
        public string MUccIndexRw
        {
            get
            {
                return Base.PageLink.GetBaseLinks.GetDefault.MUccIndexRw;
            }
        }
       
        public string MSearchRw
        {
            get
            {
                return PageLink.GetBaseLinks.Get(GetSiteID).MSearchRw;
            }
        }
        public string MLostpasswordRw
        {
            get
            {
                return Base.PageLink.GetBaseLinks.GetDefault.MLostpasswordRw;
            }
        }

        public string MLoginRw
        {
            get
            {

                return Base.PageLink.GetBaseLinks.GetDefault.MLoginRw;

            }
        }
        ///// <summary>
        ///// 默认分类列表
        ///// </summary>
        //public string MClassRw
        //{
        //    get
        //    {
        //        return string.Concat(AppStartInit.MPathUrl,Base.PageLink.GetBaseLinks.GetDefault.MClassLinkRw);
                

        //    }
        //}
        public string MLogOutRw
        {
            get
            {
                return string.Concat(IISPath, "LogOut.aspx?t=m");
            }
        }

        public string MTaglistLinkRw(int siteid)
        {

            return Base.PageLink.GetBaseLinks.Get(siteid).MTaglistLinkRw;
            
        }

        public string MTagsSearchListLinkRw(int siteid)
        {

            return Base.PageLink.GetBaseLinks.Get(siteid).MTagsSearchListLinkRw;
            
        }

        public string MRegRw
        {
            get
            {
                return Base.PageLink.GetBaseLinks.GetDefault.MRegRw;
            }
        }

        public string MGetSpecialHref()
        {
            return LinkMobile.Instance(GetSiteID).GetSpecialHref();

        }
        public string MGetSpecialHref(object id,int PageIndex,int SiteId)
        {
            return LinkMobile.Instance(SiteId).GetSpecialHref(id, PageIndex);

        }
        public string MGetSpecialHref(object id, int PageIndex)
        {
            return LinkMobile.Instance(GetSiteID).GetSpecialHref(id, PageIndex);

        }
        public string MGetIndexHref()
        {
            return LinkMobile.Instance(GetSiteID).GetIndexHref();

        }
        public string MGetClassHref(object iId, int PageIndex, int OrderBy)
        {
            return LinkMobile.Instance(GetSiteID).GetClassHref(iId, PageIndex, OrderBy);
        }
        //yhl 2013-12-2 没有Url中没有 site时使用。
        public string MGetClassHref(object iID, int PageIndex, int OrderBy, int SiteID)
        {
            return LinkMobile.Instance(SiteID).GetClassHref(iID, PageIndex, OrderBy);
        }
        public string MGetClassHref()
        {
            return LinkMobile.Instance(GetSiteID).GetClassHref();
        }

        public string MGetClassHref(int iId, int PageIndex,int SiteId)
        {
            return LinkMobile.Instance(SiteId).GetClassHref(iId, PageIndex);
        }
        public string MGetClassHref(object iId, int PageIndex)
        {
            return LinkMobile.Instance(GetSiteID).GetClassHref(iId, PageIndex);
        }
        //public string MGetContentLink(object iID)
        //{
        //    return LinkMobile.Instance(GetSiteID).GetContentLink(iID);
        //}

        public string MGetContentLink(object iID, object ClassID)
        {
            return MGetContentLink(iID, ClassID, 0);
        }

        public string MGetContentLink(object iID,object ClassID,int PageIndex)
        {
            return LinkMobile.Instance(GetSiteID).GetContentLink(iID, ClassID, PageIndex);
        }
        //模块个人后台 使用
        //public string MGetContentLink(object iID,int SiteID)
        //{
        //    return LinkMobile.Instance(SiteID).GetContentLink(iID);
        //}
        public string MGetTagsHref(int PageIndex)
        {
            return LinkMobile.Instance(GetSiteID).GetTagsHref(PageIndex);

        }
        public string MGetTagvHref(object ID,int PageIndex)
        {
            return LinkMobile.Instance(GetSiteID).GetTagvHref(ID, PageIndex);
            
        }

        public string MClassLinkRw(int isiteid)
        {
            return Base.PageLink.GetBaseLinks.Get(isiteid).MClassLinkRw;
        }

        public string MSpecialLinkRw(int isiteid)
        {
            return Base.PageLink.GetBaseLinks.Get(isiteid).MSpecialLinkRw;
        }
        #endregion



    }
}
