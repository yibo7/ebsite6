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
    /// 品牌管理
    /// </summary>
    public partial class SelReport : MPage
    {
        override public Guid ModuleMenuID
        {
            get
            {
                return new Guid("28263e81-6239-4253-91c1-941f2a080f1a");
            }
        }
        public override string PageName
        {
            get
            {
                return "销售报表";
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected override void AddControl()
        {
            if (PageType == 0)//添加
            {
                base.LoadAControl("BrandAdd.ascx");
            }
          
            else
            {
                base.AddControl();
            }
        }
    }
}