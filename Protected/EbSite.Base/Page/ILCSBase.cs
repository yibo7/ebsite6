using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EbSite.Base.Page
{
    public class ILCSBase : CustomPage
    {

        protected int GetContentPageIndex
        {
            get
            {
                if (!string.IsNullOrEmpty(Request["pi"]))
                {
                    return int.Parse(Request["pi"]);
                }
                else
                {
                    return 0;
                }
            }
        }
        protected int GetClassID
        {
            get
            {
                if (!string.IsNullOrEmpty(Request["cid"]))
                {
                    return int.Parse(Request["cid"]);
                }
                else
                {
                    return 0;
                }
            }
        }
        protected Guid GetModelID
        {
            get
            {
                if (!string.IsNullOrEmpty(Request["modelid"]))
                {
                    return new Guid(Request["modelid"]);
                }
                else
                {
                    return Guid.Empty;
                }
            }
        }
       virtual protected EbSite.BLL.NewsContentSplitTable NewsContentBll
        {
            get
            {

                return AppStartInit.GetNewsContentInst(GetClassID);
            }
        }

        
        //override protected void ShowCopyright()
        //{

        //    if (!Equals(llFootInfo, null))
        //    {
        //        string cnzz = string.Empty;
        //        if (!Configs.ContentSet.ConfigsControl.Instance.IsStopCnzz)
        //        {
        //            cnzz = Core.CNZZ.GetJs();
        //        }

        //        llFootInfo.Text = string.Concat("<span>", Copyright, "</span><span>由eBSite", AppStartInit.ASSEMBLY_VERSION, "<a href='", AppStartInit.OfficialsUrl, "'>建站系统</a>修改完成,[<a target=_blank href='", IISPath, "sitemapindex.xml'>网站地图</a>]</span>", string.Concat(KeepUserState(), cnzz));
        //    }
        //    //else
        //    //{
        //    //    throw new Exception("当前模板缺少ID为llFootInfo的Literal控件,您可以在模板底部添加以下代码:<asp:Literal ID=\"llFootInfo\" runat=\"server\"></asp:Literal>");
        //    //}
        //}
    }
}
