using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.Modules;
namespace EbSite.Modules.BBS.AdminPages
{
    public partial class PostManage : MPage
    {
        override public Guid ModuleMenuID
        {
            get
            {
                return new Guid("d90673ea-e25f-4356-b16a-aac8c021c162");
            }
        }
        override public  string PageName
        {
            get
            {
                return "管理回帖";
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