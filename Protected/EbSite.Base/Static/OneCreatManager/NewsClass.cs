using System;
using EbSite.Base.EBSiteEventArgs;
using EbSite.BLL.GetLink;

//using EbSite.Core.GetLink;

namespace EbSite.Base.Static.OneCreatManager
{
    /// <summary>
    /// 生成分类列表
    /// </summary>
    public class NewsClass : HtmlBase
    {
        public static readonly NewsClass Instance = new NewsClass();

        private int _iClassID;
        /// <summary>
        /// 分类ID
        /// </summary>
        public int iClassID
        {
            set
            {
                _iClassID = value;
            }
            get
            {
                return _iClassID;
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
        //public static event EventHandler<MakedEventArgs> Maked;
        ///// <summary>
        ///// 生成页面生成成功后调用，向外传出当前ID
        ///// </summary>
        ///// <param name="log"></param>
        ///// <param name="arg"></param>
        //public static void OnMaked(object sender, MakedEventArgs arg)
        //{
        //    if (Maked != null)
        //    {
        //        Maked(sender, arg);
        //    }
        //}
        /// <summary>
        /// 重写生成办法
        /// </summary>
        /// <returns></returns>
        public override string MakeHtml(int SiteID)
        {
            ////获取分类列表动态地址
            //base.sUrl = HrefFactory.GetAspxInstance(SiteID).GetClassHref(iClassID, iPageIndex);
            ////获取分类列表静态地址，也就是生成路径
            //base.sFilePath = HrefFactory.GetHtmlInstance(SiteID).GetClassHref(iClassID, iPageIndex);

            //获取分类列表动态地址
            base.sUrl = LinkClass.Instance.GetAspxInstance(SiteID).GetClassHref(iClassID, iPageIndex);
            //获取分类列表静态地址，也就是生成路径
            base.sFilePath = LinkClass.Instance.GetHtmlInstance(SiteID).GetClassHref(iClassID, iPageIndex);

            string sHtmlContent = string.Empty;
            string rs = base.CreatHtmls(ref sHtmlContent);
            if (rs.IndexOf("成功") > 0)
            {
                MakedEventArgs mea = new MakedEventArgs(iClassID, sHtmlContent, iClassID);
               EbSite.Base.EBSiteEvents.OnClassMaked(null, mea);
            }
            return rs;
        }
    }

}
