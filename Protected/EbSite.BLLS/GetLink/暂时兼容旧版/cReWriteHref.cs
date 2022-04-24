
//using EbSite.Base.PageLink;

//namespace EbSite.BLL.GetLink
//{
//    public class cReWriteHref : ILink
//    {
//        public cReWriteHref(int _SiteID)
//        {
//            this.SiteID = _SiteID;
//        }

//        #region 电脑版
//        public override string GetFormUrl(string modelid)
//        {
//            return string.Concat(IISPath, modelid, "-", SiteID, CustomFormRw);
//        }
//        /// <summary>
//        /// 获取主站首页地址
//        /// </summary>
//        /// <returns></returns>
//        public override string GetMainIndexHref()
//        {
//            return IndexLink;
//        }
//        public override string GetContentLink(object iId, object HtmlPath)
//        {
//            return string.Concat(SiteFolder, iId, ContentLinkRw); 
//        }
//        public override string GetContentLink(object iId)
//        {
//            return string.Concat(SiteFolder, iId, ContentLinkRw); 
//        }
//        public override string TagsList(int p)
//        {
//            return string.Concat(SiteFolder, p, TaglistLinkRw);
//        }
//        public override string TagsList(int p, int OrderBy)
//        {
//            return string.Concat(SiteFolder, p, "-", OrderBy, TaglistLinkRw);
//        }
//        public override string TagsSearchList(object id, int p)
//        {
//            return string.Concat(SiteFolder, id, "-", p, TagsSearchListLinkRw); 
//        }
//        public override string GetClassHref(object iId, object HtmlPath, int pIndex)
//        {
//            return string.Concat(SiteFolder, iId, "-", pIndex, "-0", ClassLinkRw); 
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
//        public override string GetClassHref(int iId, int Index)
//        {
//            return string.Concat(SiteFolder, iId, "-", Index, "-0", ClassLinkRw); 
//        }
//        public override string GetClassHref_OrderBy(int iId, int Index, int OrderBy)
//        {
//            return string.Concat(SiteFolder, iId, "-", Index, "-", OrderBy, ClassLinkRw);
//        }

//        public override string GetSpecialHref(int iid, int index)
//        {
//            return string.Concat(SiteFolder, iid, "-", index, SpecialLinkRw);
//        }
//        public override string UserAlbumHref(int id, int index)
//        {
//            return string.Concat(SiteFolder, id, "-", index, UserAlbumRw);
//        }
//        public override string IndexForPage(int index)
//        {
//            return string.Concat("{0}-", Base.Configs.ContentSet.ConfigsControl.Instance.IndexPathRw, "?site=", SiteID);
//        }
//        public override string GetLoginApiBackUrl(string apptype)
//        {
//            return string.Concat(SiteFolder, apptype, "-", LoginbindRw);
//        }
//        #endregion

//        #region 手机版 暂时用动态

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
//            return string.Concat(SiteFolder, MContentLink, "?id=", iId);
//        }
//        public override string MGetContentLink(object iId)
//        {
//            return string.Concat(SiteFolder, MContentLink, "?id=", iId);
//        }
//        public override string MTagsList(int p)
//        {
//            return string.Concat(SiteFolder, MTaglistLink, "?p=", p);
//        }
//        public override string MTagsList(int p, int OrderBy)
//        {
//            return string.Concat(SiteFolder, MTaglistLink, "?p=", p, "&odb=", OrderBy);
//        }
//        public override string MTagsSearchList(object id, int p)
//        {
//            return string.Concat(SiteFolder, MTagsSearchListLink, "?tid=", id, "&p=", p);
//        }
//        public override string MGetClassHref(object iId, object HtmlPath, int pIndex)
//        {
//            return string.Concat(SiteFolder, MClassLink, "?cid=", iId, "&p=", pIndex);
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
//            return string.Concat(SiteFolder, MClassLink, "?cid=", iId, "&p=", Index, "&odb=", OrderBy);
//        }
//        public override string MGetClassHref(int iId, int Index)
//        {
//            return string.Concat(SiteFolder, MClassLink, "?cid=", iId, "&p=", Index);
//        }
//        public override string MGetSpecialHref(int iid, int index)
//        {
//            return string.Concat(SiteFolder, MSpecialLink, "?sid=", iid, "&p=", index);
//        }
//        #endregion

//    }
//}
