
using EbSite.Base.EBSiteEventArgs;
using EbSite.BLL.GetLink;

//using EbSite.Core.GetLink;

namespace EbSite.Base.Static.OneCreatManager
{
    /// <summary>
    /// 生成首页
    /// </summary>
    public class IndexCreate : HtmlBase
    {
        public static readonly IndexCreate Instance = new IndexCreate();
        public override string MakeHtml(int SiteID)
        {
            //base.sUrl = HrefFactory.GetAspxInstance(SiteID).GetMainIndexHref();
            //base.sFilePath = HrefFactory.GetHtmlInstance(SiteID).GetMainIndexHref();

            base.sUrl = LinkOrther.Instance.GetAspxInstance(SiteID).GetMainIndexHref();
            base.sFilePath = LinkOrther.Instance.GetHtmlInstance(SiteID).GetMainIndexHref();
            string sHtmlContent = string.Empty;
            string rs = base.CreatHtmls(ref sHtmlContent);
            if (rs.IndexOf("成功") > 0)
            {
                MakedEventArgs mea = new MakedEventArgs(0, sHtmlContent,0);
                EbSite.Base.EBSiteEvents.OnIndexMaked(null, mea);
            }
            return rs;
        }

     
    }
}
