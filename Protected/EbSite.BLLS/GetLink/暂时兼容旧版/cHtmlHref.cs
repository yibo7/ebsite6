
//using EbSite.Base.PageLink;
//using EbSite.BLL;

//namespace EbSite.BLL.GetLink
//{
//    public class cHtmlHref : ILink
//    {

//        public cHtmlHref(int _SiteID)
//        {
//            this.SiteID = _SiteID;
//        }

//        #region 电脑版

//        //const double CacheDuration = 60.0;
//        //private static readonly string[] MasterCacheKeyArray = { "cHtmlHref" };
//        //private static BllCacheComm bllCache;
//        //public cHtmlHref()
//        //{
//        //    bllCache = new BllCacheComm(CacheDuration, MasterCacheKeyArray);
//        //}
//        private bool _isShowDefault = false;
        
//        /// <summary>
//        /// 设置是否显示默认文件名称，如/music/2562/default.html,不设置为目录路径,如/music/2562/
//        /// </summary>
//        public bool isShowDefault
//        {
//            get
//            {
//                return _isShowDefault;
//            }
//            set
//            {
//                _isShowDefault = value;
//            }
//        }
//        /// <summary>
//        /// 获取默认文件名称
//        /// </summary>
//        private string sDefaultName
//        {
//            get
//            {
//                if (!isShowDefault)
//                {

//                    if (!string.IsNullOrEmpty(Base.Configs.HtmlConfigs.ConfigsControl.Instance.DefualtName.Trim()))
//                    {
//                        return "/";
//                    }
//                    return string.Empty;
//                }
//                else
//                {
//                    return string.Concat("/", Base.Configs.HtmlConfigs.ConfigsControl.Instance.DefualtName);
//                }
//            }
//        }
//        /// <summary>
//        /// 生成静态页面时不用 IISPath
//        /// </summary>
//        private string IISPathFormHtml
//        {
//            get
//            {
//                if (!isShowDefault)
//                {
//                    return SiteFolder;
//                }
//                else
//                {
//                    if (SiteID > 1)
//                    {
//                        return CurrentSite.SiteFolder;
//                    }
//                    else
//                    {
//                        return "";
//                    }

//                }
//            }
//        }
//        private string PageSplit
//        {
//            get
//            {
//                return Base.Configs.HtmlConfigs.ConfigsControl.Instance.PageSplit;
//            }
//        }
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
//            return string.Concat(IISPathFormHtml, sDefaultName);
//        }


//        public override string TagsList(int p, int OrderBy)
//        {
//            return string.Concat(IISPathFormHtml, Base.Configs.HtmlConfigs.ConfigsControl.Instance.TagsList, "odb", p, sDefaultName);
//            //return string.Concat(IISPath, TaglistLink, "?p=", p, "&odb=", OrderBy);
//        }


//        public override string GetContentLink(object iID, object HtmlPath)
//        {
//            //string CacheKey = string.Concat("GetContentLink-", iID);
//            //string sHtmlUrl = bllCache.GetCacheItem(CacheKey) as string;
//            //if (string.IsNullOrEmpty(sHtmlUrl))
//            //{
//            string sUrl = HtmlPath.ToString();
//            sUrl = sUrl.Replace(HtmlReNameRule.KeyID.ToLower(), iID.ToString());
//            sUrl = string.Concat(IISPathFormHtml, sUrl, sDefaultName);
//            //bllCache.AddCacheItem(CacheKey, sHtmlUrl);
//            //}
//            return sUrl;
//        }
//        public override string GetContentLink(object iID)
//        {
//            //string CacheKey = string.Concat("GetContentLink-", iID);
//            //string sHtmlUrl = bllCache.GetCacheItem(CacheKey) as string;
//            //if (string.IsNullOrEmpty(sHtmlUrl))
//            //{
//            string sUrl = "/";
//            if (!Equals(iID, null))
//            {
//                EbSite.Entity.NewsContent model = BLL.NewsContent.GetModel(int.Parse(iID.ToString()));
//                if (!Equals(model, null))
//                {
//                    sUrl = model.HtmlName;
//                    if (!string.IsNullOrEmpty(sUrl))
//                    {
//                        sUrl = sUrl.Replace(HtmlReNameRule.KeyID.ToLower(), iID.ToString());
//                        sUrl = string.Concat(IISPathFormHtml, sUrl, sDefaultName);
//                    }

//                }

//            }



//            //}

//            return sUrl;// string.Concat(sHtmlUrl, sDefaultName);
//        }

//        /// <summary>
//        /// 获取标签列表地址-分页 
//        /// </summary>
//        /// <returns></returns>
//        public override string TagsList(int p)
//        {

//            string sUrl = Base.Configs.HtmlConfigs.ConfigsControl.Instance.TagsList;

//            if (p > 1)
//            {
//                sUrl = string.Concat(sUrl, "/", PageSplit, p);
//            }

//            return string.Concat(IISPathFormHtml, sUrl, sDefaultName);
//        }
//        public override string TagsSearchList(object id, int p)
//        {

//            string sUrl = TagKey.GetHtmlName(int.Parse(id.ToString()));// string.Concat(Base.Configs.HtmlConfigs.ConfigsControl.Instance.TagsSearchList, "/", id);
//            sUrl = sUrl.Replace(HtmlReNameRule.KeyID.ToLower(), id.ToString());//sUrl = sUrl.Replace("{#KeyID#}", id.ToString()).Replace("{#TitleSpell#}", TagKey.GetEname(int.Parse(id.ToString())));

//            if (p > 1)
//            {
//                sUrl = string.Concat(sUrl, "/", PageSplit, p);
//                //sUrl = string.Concat(sUrl, "/", id, PageSplit, p);
//            }
//            sUrl = string.Concat(IISPathFormHtml, sUrl, sDefaultName);

//            return sUrl;

//            //return string.Concat(IISPathFormHtml, Configs.HtmlConfigs.ConfigsControl.Instance.TagsSearchList,"/", id, "A", p, sDefaultName);
//        }
//        public override string GetClassHref(object iID, object HtmlPath, int pIndex)
//        {

//            string sUrl = string.Empty;
//            if (!Equals(HtmlPath, null))
//                sUrl = HtmlPath.ToString();
//            sUrl = sUrl.Replace(HtmlReNameRule.KeyID.ToLower(), iID.ToString());
//            string extension = System.IO.Path.GetExtension(HtmlPath.ToString());//2012-11-14 yhl 添加
//            if (string.IsNullOrEmpty(extension))
//            {
//                if (pIndex > 1)
//                {
//                    sUrl = string.Concat(sUrl, "/", PageSplit, pIndex);//sUrl = string.Concat(sUrl, "/", iID, PageSplit, pIndex);
//                }
//                sUrl = string.Concat(IISPathFormHtml, sUrl, sDefaultName);
//            }
//            else
//            {
//                string FileNameWithOutExtension = System.IO.Path.GetFileNameWithoutExtension(HtmlPath.ToString());//2012-11-26 yhl 添加

//                if (pIndex > 1)
//                {
//                    sUrl = string.Concat(FileNameWithOutExtension, "-", pIndex, extension);//peijiandaquan-2.shtml
//                }
//                sUrl = string.Concat(IISPathFormHtml, sUrl);
//            }
//            return sUrl;
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
//            //string CacheKey = string.Concat("GetClassHref-", iId, "-", Index);
//            //string sHtmlUrl = bllCache.GetCacheItem(CacheKey) as string;
//            //if (string.IsNullOrEmpty(sHtmlUrl))
//            //{
//            string sHtmlUrl = "";
//            Entity.NewsClass Model = BLL.NewsClass.GetModelByCache(iId);
//            if (!Equals(Model, null))
//            {
//                sHtmlUrl = GetClassHref(iId, Model.HtmlName, Index);
//            }
//            else
//            {
//                sHtmlUrl = "/";
//            }
//            //if (!string.IsNullOrEmpty(sHtmlUrl)) bllCache.AddCacheItem(CacheKey, sHtmlUrl);
//            //}

//            return sHtmlUrl;

//        }

//        public override string GetClassHref_OrderBy(int iId, int Index, int OrderBy)
//        {
//            string sUrl = "/classodb/";
//            if (Index > 1)
//            {
//                sUrl = string.Concat(sUrl, iId, "p", Index);
//            }
//            else
//            {
//                sUrl = string.Concat(sUrl, iId);
//            }
//            sUrl = string.Concat(IISPathFormHtml, sUrl, sDefaultName);
//            return sUrl;
//        }

//        public override string GetSpecialHref(int iID, int pIndex)
//        {
//            Entity.SpecialClass Model = BLL.SpecialClass.GetModelByCache(iID);
//            if (!Equals(Model, null))
//            {
//                return GetSpecialHref(iID, Model.HtmlName, pIndex);
//            }
//            else
//            {
//                return "/";
//            }

//        }

//        private string GetSpecialHref(int iID, object HtmlPath, int pIndex)
//        {
//            string sUrl = HtmlPath.ToString();

//            sUrl = sUrl.Replace(HtmlReNameRule.KeyID.ToLower(), iID.ToString());

//            if (pIndex > 1)
//            {
//                //sUrl = string.Concat(sUrl, "/", iID, PageSplit, pIndex);
//                sUrl = string.Concat(sUrl, "/", PageSplit, pIndex);

//            }
//            return string.Concat(IISPathFormHtml, sUrl, sDefaultName);
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
//        public override string UserAlbumHref(int id, int index)
//        {
//            return string.Concat(SiteFolder, id, "-", index, UserAlbumRw);
//        }
//        public override string IndexForPage(int index)
//        {
//            return string.Concat("{0}-", Base.Configs.ContentSet.ConfigsControl.Instance.IndexPathRw, "?site=", SiteID);
//        }
//        #endregion

//    }
//}
