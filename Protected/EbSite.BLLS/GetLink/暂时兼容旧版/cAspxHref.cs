
//using EbSite.Base.PageLink;

//namespace EbSite.BLL.GetLink
//{
//    public class cAspxHref : ILink
//    {
//        public cAspxHref(int _SiteID)
//        {
//            this.SiteID = _SiteID;
//        }
        
//        #region 电脑版
//        /// <summary>
//        /// 获取主站首页地址
//        /// </summary>
//        /// <returns></returns>
//        public override string GetMainIndexHref()
//        {
//            if(SiteID>1)
//            {
//                return string.Concat(IndexLink, "?site=", SiteID);
                
//            }
//            else
//            {
//                return IndexLink;
//            }
            
//        }
//        public override string GetFormUrl(string modelid)
//        {
//            return string.Concat(IISPath, CustomForm, "?site=", SiteID, "&mid=", modelid);
//        }
//        public override string GetContentLink(object iId, object HtmlPath)
//        {
//            return string.Concat(IISPath, ContentLink, "?id=", iId, "&site=", SiteID);
//        }
//        public override string GetContentLink(object iId)
//        {
//            return string.Concat(IISPath, ContentLink, "?id=", iId, "&site=", SiteID);
//        }
//        public override string TagsList(int p)
//        {
//            return string.Concat(IISPath, TaglistLink, "?p=", p, "&site=", SiteID);
//        }
//        public override string TagsList(int p, int OrderBy)
//        {
//            return string.Concat(IISPath, TaglistLink, "?p=", p, "&odb=", OrderBy, "&site=", SiteID);
//        }
//        public override string TagsSearchList(object id, int p)
//        {
//            return string.Concat(IISPath, TagsSearchListLink, "?tid=", id, "&p=", p, "&site=", SiteID);
//        }
//        public override string GetClassHref(object iId, object HtmlPath, int pIndex)
//        {
//            return string.Concat(IISPath, ClassLink, "?cid=", iId, "&p=", pIndex, "&site=", SiteID);
//        }


//        public override string GetClassHref(object iId, object HtmlPath, int pIndex, string OutLink)
//        {
//            if (string.IsNullOrEmpty(OutLink))
//            {
//                return GetClassHref(iId, HtmlPath, pIndex);
//            }
//            else
//            {
//                return OutLink;
//            }

//        }

//        public override string GetClassHref_OrderBy(int iId, int Index, int OrderBy)
//        {
//            return string.Concat(IISPath, ClassLink, "?cid=", iId, "&p=", Index, "&odb=", OrderBy,"&site=",SiteID);
//        }

//        public override string GetClassHref(int iId, int Index)
//        {
//            return string.Concat(IISPath, ClassLink, "?cid=", iId, "&p=", Index, "&site=", SiteID);
//        }
//        public override string GetSpecialHref(int iid, int index)
//        {
//            return string.Concat(IISPath, SpecialLink, "?sid=", iid, "&p=", index, "&site=", SiteID);
//        }
//        public override string UserAlbumHref(int id, int index)
//        {
//            return string.Concat(IISPath, UserAlbum, "?al=", id, "&p=", index, "&site=", SiteID);
//        }

//        public override string IndexForPage(int index)
//        {
//            return string.Concat(base.IndexLink, "?p=", index, "&site=", SiteID);
//        }
//        public override string GetLoginApiBackUrl(string apptype)
//        {
//            return string.Concat(base.LoginBind, "?t=", apptype);
//        }
//        #endregion

//        #region 手机版

//        /// <summary>
//        /// 获取主站首页地址
//        /// </summary>
//        /// <returns></returns>
//        public override string MGetMainIndexHref()
//        {
//            return MIndexLink;
//        }
//        public override string MGetContentLink(object iId, object HtmlPath)
//        {
//            return string.Concat(IISPath, MContentLink, "?id=", iId);
//        }
//        public override string MGetContentLink(object iId)
//        {
//            return string.Concat(IISPath, MContentLink, "?id=", iId);
//        }
//        public override string MTagsList(int p)
//        {
//            return string.Concat(IISPath, MTaglistLink, "?p=", p);
//        }
//        public override string MTagsList(int p, int OrderBy)
//        {
//            return string.Concat(IISPath, MTaglistLink, "?p=", p, "&odb=", OrderBy);
//        }
//        public override string MTagsSearchList(object id, int p)
//        {
//            return string.Concat(IISPath, MTagsSearchListLink, "?tid=", id, "&p=", p);
//        }
//        public override string MGetClassHref(object iId, object HtmlPath, int pIndex)
//        {
//            return string.Concat(IISPath, MClassLink, "?cid=", iId, "&p=", pIndex);
//        }
//        public override string MGetClassHref(object iId, object HtmlPath, int pIndex, string OutLink)
//        {
//            if (string.IsNullOrEmpty(OutLink))
//            {
//                return MGetClassHref(iId, HtmlPath, pIndex);
//            }
//            else
//            {
//                return OutLink;
//            }

//        }
//        public override string MGetClassHref_OrderBy(int iId, int Index, int OrderBy)
//        {
//            return string.Concat(IISPath, MClassLink, "?cid=", iId, "&p=", Index, "&odb=", OrderBy);
//        }
//        public override string MGetClassHref(int iId, int Index)
//        {
//            return string.Concat(IISPath, MClassLink, "?cid=", iId, "&p=", Index);
//        }
//        public override string MGetSpecialHref(int iid, int index)
//        {
//            return string.Concat(IISPath, MSpecialLink, "?sid=", iid, "&p=", index);
//        }
//        #endregion

//    }
//}
