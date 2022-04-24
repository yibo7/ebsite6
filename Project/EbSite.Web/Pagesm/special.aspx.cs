using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base;

namespace EbSite.Web.Pagesm
{
    public partial class special : Pages.special
    {
        protected string MTitle
        {
            get
            {
                return "专题";
            }
        }
        /// <summary>
        /// 手机版不需要输出适配
        /// </summary>
        override protected void MobileMeta()
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
        override protected void inithead()
        {
            if (GetSpecialID > 0)
            {
                SeoTitle = GetSeoWord((string.IsNullOrEmpty(Model.SeoTitle)) ? SeoSite.SeoSpecialTitle : Model.SeoTitle, Model.SpecialName);
            }
            else
            {
                SeoTitle = "所有专题";
            }
            

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
        //    else
        //    {
        //        throw new Exception("当前模板缺少ID为llFootInfo的Literal控件,您可以在模板底部添加以下代码:<asp:Literal ID=\"llFootInfo\" runat=\"server\"></asp:Literal>");
        //    }
        //}


        override protected void BindPages()
        {
            if (!Equals(pgCtr, null))
            {
                if (string.IsNullOrEmpty(pgCtr.ReWritePatchUrl)) //外面aspx页面上可以自定义
                {
                    int siteid = GetSiteID;
                    pgCtr.ReWritePatchUrl = string.Concat(GetSpecialID, "-{0}-", siteid, HostApi.MSpecialLinkRw(GetSiteID)); //{0} 页码
                }
                pgCtr.AllCount = iSearchCount;
                pgCtr.PageSize = iPageSize;
                pgCtr.OtherPram = string.Format("sid,{0}", GetSpecialID);
                pgCtr.CurrentClass = "CurrentPageCoder";
                pgCtr.ParentClass = "PagesClass";
            }

        }
    }
}