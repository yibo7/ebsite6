using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.Modules;

namespace EbSite.Modules.Shop.AdminPages
{
    /// <summary>
    /// 降价通知
    /// </summary>
    public partial class DownNotice : MPage
    {
        override public Guid ModuleMenuID
        {
            get
            {
                return new Guid("1910b4e5-699a-4638-914e-a5eb02eeba56");
            }
        }
        public override string PageName
        {
            get
            {
                return "降价通知";
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected override void AddControl()
        {
            if (PageType == 0)//添加
            {
                base.LoadAControl("ShowDown.ascx");
            }
            else if(PageType==1)
            {
                base.LoadAControl("SendMsg.ascx");
            }
            else
            {
                base.AddControl();
            }
        }
    }
}