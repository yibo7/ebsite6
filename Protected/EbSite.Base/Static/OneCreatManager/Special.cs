

using System.Text;
using System.Threading;
using EbSite.Base.EBSiteEventArgs;
using EbSite.BLL.GetLink;
using EbSite.Control.xsPage;
//using EbSite.Core.GetLink;

namespace EbSite.Base.Static.OneCreatManager
{
    public class Special : HtmlBase
    {
        public static readonly Special Instance = new Special();
        private int _iSpecialD;
        /// <summary>
        /// 分类ID
        /// </summary>
        public int iSpecialD
        {
            set
            {
                _iSpecialD = value;
            }
            get
            {
                return _iSpecialD;
            }
        }private int _iPageIndex;
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

        /// <summary>
        /// 重写生成办法
        /// </summary>
        /// <returns></returns>
        public override string MakeHtml(int SiteID)
        {
            ////获取分类列表动态地址
            //base.sUrl = HrefFactory.GetAspxInstance(SiteID).GetSpecialHref(iSpecialD, iPageIndex);
            ////获取分类列表静态地址，也就是生成路径
            //base.sFilePath = HrefFactory.GetHtmlInstance(SiteID).GetSpecialHref(iSpecialD, iPageIndex);
            
            //获取分类列表动态地址
            base.sUrl = LinkSpecial.Instance.GetAspxInstance(SiteID).GetSpecialHref(iSpecialD, iPageIndex);
            //获取分类列表静态地址，也就是生成路径
            base.sFilePath = LinkSpecial.Instance.GetHtmlInstance(SiteID).GetSpecialHref(iSpecialD, iPageIndex);

            //开始生成面页
            string sHtmlContent = string.Empty;
            string rs = base.CreatHtmls(ref sHtmlContent);
            if (rs.IndexOf("成功") > 0)
            {
                MakedEventArgs mea = new MakedEventArgs(iSpecialD, sHtmlContent,0);
                EbSite.Base.EBSiteEvents.OnSpecialMaked(null, mea);
            }

           

            return "生成完毕";
        }

    }
}
