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
    public partial class CreditProduct : MPage
    {
        override public Guid ModuleMenuID
        {
            get
            {
                return new Guid("625dcf9b-4a6b-4ff8-9254-7ea7fa8e80f6");
            }
        }
        public override string PageName
        {
            get
            {
                return "积分商城";
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected override void AddControl()
        {
            if (PageType == 0)//添加
            {
                base.LoadAControl("AddProduct.ascx");
            }
            else if (PageType ==3)//添加
            {
                base.LoadAControl("AddClass.ascx");
            }
            else
            {
                base.AddControl();
            }
        }
    }
}