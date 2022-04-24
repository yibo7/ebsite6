
using EbSite.Base.EBSiteEventArgs;
using EbSite.BLL.GetLink;

//using EbSite.Core.GetLink;

namespace EbSite.Base.Static.OneCreatManager
{
    /// <summary>
    /// 生成标签列表面页
    /// </summary>
    public class TagList : HtmlBase
    {
        public static readonly TagList Instance = new TagList();
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
        public override string MakeHtml(int SiteID)
        {
            base.sUrl = LinkTags.Instance.GetAspxInstance(SiteID).TagsList(iPageIndex);
            base.sFilePath = LinkTags.Instance.GetHtmlInstance(SiteID).TagsList(iPageIndex);
            string sHtmlContent = string.Empty;
            string rs = base.CreatHtmls(ref sHtmlContent);
            if (rs.IndexOf("成功") > 0)
            {
                MakedEventArgs mea = new MakedEventArgs(iPageIndex, sHtmlContent,0);
                EbSite.Base.EBSiteEvents.OnSpecialMaked(null, mea);
            }
           return rs;
        }
    }

}
