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
    public partial class ExportData : MPage
    {
        override public Guid ModuleMenuID
        {
            get
            {
                return new Guid("02250f53-79cc-43fd-ac7a-a4209ca04c4e");
            }
        }
        public override string PageName
        {
            get
            {
                return "数据导出导入";
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