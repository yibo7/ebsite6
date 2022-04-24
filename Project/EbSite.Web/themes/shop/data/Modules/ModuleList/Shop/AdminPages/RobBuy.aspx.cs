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
    /// 限时抢购
    /// </summary>
    public partial class RobBuy : MPage
    {
        override public Guid ModuleMenuID
        {
            get
            {
                return new Guid("8bab1cba-435f-4314-b8ab-fa11893af8ad");
            }
        }
        public override string PageName
        {
            get
            {
                return "限时抢购";
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected override void AddControl()
        {
            if (PageType == 0)//添加
            {
                base.LoadAControl("RobBuyAdd.ascx");
            }
           
            else
            {
                base.AddControl();
            }
        }
    }
}