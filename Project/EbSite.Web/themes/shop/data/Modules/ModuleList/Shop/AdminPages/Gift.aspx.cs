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
    /// 赠品
    /// </summary>
    public partial class Gift : MPage
    {
        override public Guid ModuleMenuID
        {
            get
            {
                return new Guid("0bcded68-1ba7-43cc-9bf0-d1fbb1d5436f");
            }
        }
        public override string PageName
        {
            get
            {
                return "赠品";
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected override void AddControl()
        {
            if (PageType == 0)//添加
            {
                base.LoadAControl("AddGift.ascx");
            }
           
            else
            {
                base.AddControl();
            }
        }
    }
}