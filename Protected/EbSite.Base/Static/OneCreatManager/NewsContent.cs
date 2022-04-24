
using System;
using EbSite.Base.EBSiteEventArgs;
using EbSite.BLL.GetLink;

//using EbSite.Core.GetLink;

namespace EbSite.Base.Static.OneCreatManager
{
    /// <summary>
    /// 生成内容页面
    /// </summary>
    public class NewsContent : HtmlBase 
    {
        public static readonly NewsContent Instance = new NewsContent();
        private long _iContentID;
        /// <summary>
        /// 内容的ID
        /// </summary>
        public long ContentID
        {
            get
            {
                return _iContentID;
            }
            set
            {
                _iContentID = value;
            }
        }
        //public int ClassID {get;set;}

        public Guid ModelID { get; set; }
        public int ClassID = 0;
        public  NewsContent()
        {
            
        }

        public override  string MakeHtml(int SiteID)
        {

            //base.sFilePath = LinkContent.Instance.GetHtmlInstance(SiteID).GetContentLink(ContentID, ModelID);
            //base.sUrl = LinkContent.Instance.GetAspxInstance(SiteID).GetContentLink(ContentID, ModelID);

            base.sFilePath = LinkContent.Instance.GetHtmlInstance(SiteID).GetContentLink(ContentID,ClassID,0);
            base.sUrl = LinkContent.Instance.GetAspxInstance(SiteID).GetContentLink(ContentID, ClassID, 0);

            string sHtmlContent = string.Empty;
            string rs = base.CreatHtmls(ref sHtmlContent);
            if (rs.IndexOf("成功")>0)
            {

                MakedEventArgs mea = new MakedEventArgs(ContentID, sHtmlContent, ClassID);
                EbSite.Base.EBSiteEvents.OnContentMaked(null, mea);
            }
            return rs;
        }
        
    }
}
