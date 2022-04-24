using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.Modules;

namespace EbSite.Modules.Shop.AdminPages
{
   
    public partial class RelatedProduct : MPage
    {
        override public Guid ModuleMenuID
        {
            get
            {
                return new Guid("6705cc56-47e6-4926-9586-4945d3dcf84d");
            }
        }
        public override string PageName
        {
            get
            {
                return "相关商品";
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
            else if(PageType==1)
            {
                base.LoadAControl("OptimalAdd.ascx");
            }
            else if(PageType==2)
            {
                base.LoadAControl("RecommendAdd.ascx");
            }
            else
            {
                base.AddControl();
            }
        }
    }
}