using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base;

namespace EbSite.Web.Pagesm
{
    public partial class content : Pages.content
    {
        protected string MTitle
        {
            get
            {
               return SiteName;
            }
        }
        override protected  EbSite.Base.ThemeType eThemeType
        {
            get { return ThemeType.MOBILE; }
        }

        /// <summary>
        /// 手机版不需要输出适配
        /// </summary>
        override protected   void MobileMeta()
        {

        }

        protected override void AddHeaderPram()
        {
            base.MobileAddHeaderPram();
        }
        protected override void InitStyle()
        {
            base.MobileInitStyle();
        } 
    }
}