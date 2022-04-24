using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using EbSite.BLL;

namespace EbSite.Web.AdminHt.ajaxget
{
    /// <summary>
    /// Summary description for GetClassManageSel
    /// </summary>
    public class GetClassManageSel : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            StringBuilder sb = new StringBuilder("[");
            if (!string.IsNullOrEmpty(context.Request["cid"]))
            {
                int dc = 0;
                if (!int.TryParse(context.Request["cid"], out dc))
                {
                    context.Response.Write("");
                }
                else
                {
                    int pid = Core.Utils.StrToInt(context.Request["cid"], 0);
                    Entity.NewsClass md = BLL.NewsClass.GetModel(pid);
                    if (!Equals(md, null))
                    {
                        string url = EbSite.Base.Host.Instance.GetClassHref(pid, md.HtmlName, 1);//前台页面路径

                        //YHL 2014-2-11 
                        NewsContentSplitTable NewsContentInst=   EbSite.Base.AppStartInit.GetNewsContentInst(md.ID);

                        int contentCount = NewsContentInst.GetCount("classid=" + md.ID, md.SiteID);// 查看内容 总数
                        int childClassCount = EbSite.BLL.NewsClass.GetCount(md.ID, md.SiteID);//子分类的个数
                        string ctUrl = "Admin_Content.aspx?t=1&cid="+pid; //查看内容路径



                        sb.Append("{");
                        sb.Append("\"id\":\"" + md.ID + "\",");
                        sb.Append("\"classname\":\"" + md.ClassName + "\",");
                        sb.Append("\"Url\": \"" + url + "\",");
                        sb.Append("\"CtCount\": \"" + contentCount + "\",");
                        sb.Append("\"ChildCount\": \"" + childClassCount + "\",");
                        sb.Append("\"CtUrl\": \"" + ctUrl + "\",");

                        sb.Remove(sb.Length - 1, 1);
                        sb.Append("}");
                    }
                }
                sb.Append("]");
                context.Response.Write(sb.ToString());
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}