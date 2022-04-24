using System;
using EbSite.Pages;

namespace EbSite.Web.AdminHt
{
    public partial class Admin_PeiSong : EbSite.Base.Page.ManagePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            base.SetContolsPath("Admin_PeiSong");
        }
        /// <summary>
        /// 添加控件
        /// </summary>
        protected override void AddControl()
        {
            if (PageType == 1)  //添加物流公司
            {
                base.LoadAControl("CompanyAdd.ascx");
            }
            else if(PageType==2)
            {
                base.LoadAControl("TemAdd.ascx");
            }
            else if(PageType==3)
            {
                base.LoadAControl("DModelAdd.ascx");
            }
            else if (PageType == 4)
            {
                base.LoadAControl("StoreHouseAdd.ascx");
            }
            else if (PageType == 5)
            {
                base.LoadAControl("SendAreaAdd.ascx");
            }
           
            else
            {
                base.AddControl();
            }

        }

    }
}
