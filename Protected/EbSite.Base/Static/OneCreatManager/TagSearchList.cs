using System;
using EbSite.Base.EBSiteEventArgs;
using EbSite.BLL.GetLink;
using EbSite.Control;
using EbSite.Control.xsPage;
//using EbSite.Core.GetLink;

namespace EbSite.Base.Static.OneCreatManager
{
    /// <summary>
    /// 生成标签搜索面页
    /// </summary>
    public class TagSearchList : HtmlBase
    {
        public static readonly TagSearchList Instance = new TagSearchList();
        private TagSearchList()
        {
           
        }
        public override string MakeHtml(int SiteID)
        {
            //base.sUrl = HrefFactory.GetAspxInstance(SiteID).TagsSearchList(TagID, iPageIndex);
            //base.sFilePath = HrefFactory.GetHtmlInstance(SiteID).TagsSearchList(TagID, iPageIndex);

            base.sUrl = LinkTags.Instance.GetAspxInstance(SiteID).TagsSearchList(TagID, iPageIndex);
            base.sFilePath = LinkTags.Instance.GetHtmlInstance(SiteID).TagsSearchList(TagID, iPageIndex);

            string sHtmlContent = string.Empty;
            string rs = base.CreatHtmls(ref sHtmlContent);
            if (rs.IndexOf("成功") > 0)
            {
                MakedEventArgs mea = new MakedEventArgs(iPageIndex, sHtmlContent,0);
                EbSite.Base.EBSiteEvents.OnTagListMaked(null, mea);
            }
            return rs;

        }
        private int _TagID;
        /// <summary>
        /// 当前页码
        /// </summary>
        public int TagID
        {
            set
            {
                _TagID = value;
            }
            get
            {
                return _TagID;
            }
        }
        private int _iPageIndex;
        /// <summary>
        /// 当前页码
        /// </summary>
        public int iPageIndex
        {
            set
            {
                _iPageIndex = value;
            }
            get
            {
                return _iPageIndex;
            }
        }
        
        

    }

}
