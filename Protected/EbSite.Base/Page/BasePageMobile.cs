
using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.Hosting;
using System.Web.Routing;
using System.Web.Security;
using System.Web.UI.HtmlControls;
using EbSite.BLL;
using EbSite.BLL.User;
using EbSite.Base.Configs.SysConfigs;
using EbSite.Core;

namespace EbSite.Base.Page
{
    public class BasePageMobile : BasePage
    {

        public BasePageMobile()
        {
            base.Load += new EventHandler(this.BasePageMobile_Load);
        }
        /// <summary>
        /// LOAD事件处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        virtual protected void BasePageMobile_Load(object sender, EventArgs e)
        {
            SeoTitle = MTitle;
        }
        virtual protected string MTitle
        {
            get
            {
                return SiteName;
            }
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
