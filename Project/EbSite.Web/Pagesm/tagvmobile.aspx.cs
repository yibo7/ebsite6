using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base;
using EbSite.Base.Configs.SysConfigs;

namespace EbSite.Web.Pagesm
{
    public partial class tagvmobile : Pages.tagv
    {
        protected string MTitle
        {
            get
            {
                return SiteName;
            }
        }
        /// <summary>
        /// 手机版不需要输出适配
        /// </summary>
        protected override void MobileMeta()
        {
        }
        override protected void MobileGo()
        { 
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
            string rp = string.Empty;
            string sOtherPram;
            if (TagID > 0)
            {
                rp = "/" + string.Concat(GetSiteID, "-", TagID, "-{0}", Base.Configs.ContentSet.ConfigsControl.Instance.MTagSearchRw); 
                sOtherPram = string.Format("tid,{0}", TagID);
            }
            else
            { 
                pgCtr.Linktype = LinkType.Aspx;
                sOtherPram = string.Format("tg,{0}|site,{1}", TagName, GetSiteID);
            }

            if (string.IsNullOrEmpty(pgCtr.ReWritePatchUrl)) //外面可以自定义
                pgCtr.ReWritePatchUrl = rp;

            pgCtr.AllCount = iSearchCount;
            pgCtr.PageSize = iPageSize;
            pgCtr.OtherPram = sOtherPram;
            pgCtr.CurrentClass = "CurrentPageCoder";
            pgCtr.ParentClass = "PagesClass";

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