using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EbSite.Web.AdminHt
{
    public partial class Admin_KuaiDi : EbSite.Base.Page.ManagePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            base.SetContolsPath("Admin_KuaiDi");
        }
        /// <summary>
        /// 添加控件
        /// </summary>
        protected override void AddControl()
        {
            if (PageType == 1)  //添加打印模板
            {
                base.LoadAControl("PrinterManageAdd.ascx");
            }
            else if(PageType==2)
            {
                base.LoadAControl("SenderMsgAdd.ascx");
            }
            else if(PageType==3)
            {
                base.LoadAControl("FastPrint.ascx");//FastPrintShow.ascx
            }
            else
            {
                base.AddControl();
            }

        }
    }
}