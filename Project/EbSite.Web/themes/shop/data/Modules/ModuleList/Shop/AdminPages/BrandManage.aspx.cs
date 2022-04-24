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
    public partial class BrandManage : MPage
    {
        override public Guid ModuleMenuID
        {
            get
            {
                return new Guid("2b276c1a-02ae-4b83-936c-6ba32ceda379");
            }
        }
        public override string PageName
        {
            get
            {
                return "品牌管理";
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