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
    /// 商品管理
    /// </summary>
    public partial class GoodsManage : MPage
	{
        override public Guid ModuleMenuID
        {
            get
            {
                return new Guid("3343f409-e2f1-4be6-b009-fbdf0cdcd533");
            }
        }
        public override string PageName
        {
            get
            {
                return "商品类型";
            }
        }
		protected void Page_Load(object sender, EventArgs e)
		{
		
		}
		
		protected override void AddControl()
		{
			if (PageType == 0)//添加
			{
                base.LoadAControl("EditGoodsType.ascx");
			}
			else if (PageType == 1) //显示
			{
				base.LoadAControl("Show.ascx");
			}
            else if (PageType ==2) //编辑
            {
                base.LoadAControl("SuppliersEdit.ascx");
            }
            else if (PageType == 3) //显示
            {
                base.LoadAControl("SuppliersShow.ascx");
            }
            else if (PageType == 4)//添加
            {
                base.LoadAControl("AdGoodsType.ascx");
            }
            else if (PageType == 5)//添加
            {
                base.LoadAControl("Ad2GoodsType.ascx");
            }
            else if(PageType==6)
            {
                base.LoadAControl("EditAttributeValues.ascx");
            }
            else if(PageType==7)
            {
                base.LoadAControl("EditAttributeValuesAdd.ascx");
            }
            else if(PageType==8)
            {
                base.LoadAControl("Ad3GoodsType.ascx");
            }
            else if(PageType==9)
            {
                base.LoadAControl("EditNormsValue.ascx");
            }
            else if(PageType==10)
            {
                base.LoadAControl("EditNormsValueAddPic.ascx");
            }
            else if (PageType == 11)
            {
                base.LoadAControl("EditNormsValueAdd.ascx");
            }
            else if(PageType==12) //赠品添加
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