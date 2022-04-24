using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base;

namespace EbSite.Web.Pagesm
{
    public partial class tagsmobile : Pages.tags
    {
        protected string MTitle
        {
            get
            {
                return SiteName;
            }
        }
        protected override void AddHeaderPram()
        {
            base.MobileAddHeaderPram();
        }
        protected override void InitStyle()
        {
            base.MobileInitStyle();
        }
        override protected void intpages()
        {
            if (!Equals(pgCtr, null))
            {

                pgCtr.ReWritePatchUrl = string.Concat(IISPath,GetSiteID, "-{0}", Base.Configs.ContentSet.ConfigsControl.Instance.MTaglistRw); //{0} 页码
                pgCtr.AllCount = iSearchCount;
                pgCtr.PageSize = iPageSize;
                pgCtr.CurrentClass = "CurrentPageCoder";
                pgCtr.ParentClass = "PagesClass"; 
            }

        }

        /// <summary>
        /// 手机版不需要输出适配
        /// </summary>
        protected override void MobileMeta()
        {
        }

        //override protected void ShowCopyright()
        //{

        //    if (!Equals(llFootInfo, null))
        //    {
        //        string cnzz = string.Empty;
        //        if (!EbSite.Base.Configs.ContentSet.ConfigsControl.Instance.IsStopCnzz)
        //        {
        //            cnzz = Core.CNZZ.GetJs();
        //        }

        //        llFootInfo.Text = string.Concat("By eBSite", AppStartInit.ASSEMBLY_VERSION);
        //    }
        //    //else
        //    //{
        //    //    throw new Exception("当前模板缺少ID为llFootInfo的Literal控件,您可以在模板底部添加以下代码:<asp:Literal ID=\"llFootInfo\" runat=\"server\"></asp:Literal>");
        //    //}
        //}
    }
}