using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;

namespace EbSite.Web.AdminHt.ajaxget
{
    /// <summary>
    /// Summary description for $codebehindclassname$
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class GetMenu : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            if (EbSite.Base.AppStartInit.UserID > 0)
            {
                StringBuilder sb = new StringBuilder("[");
                if (!string.IsNullOrEmpty(context.Request["pid"]))
                {


                    Guid pid = new Guid(context.Request["pid"]);
                    string sUsName = EbSite.Base.Host.Instance.UserName;
                    List<Entity.Menus> plst = BLL.Menus.Instance.GetMenusByParentID(pid, sUsName);
                    if (plst.Count > 0)
                    {
                        foreach (Entity.Menus ptree in plst)
                        {
                            sb.Append("{");
                            sb.Append("\"MenuTitle\":\"" + ptree.MenuNameResource + "\",");
                            sb.Append("\"img\":\"" + ptree.ImageurlShow + "\",");
                            sb.Append("\"Items\":[ ");

                            List<Entity.Menus> slst = BLL.Menus.Instance.GetMenusByParentID(ptree.id, sUsName);
                            foreach (Entity.Menus stree in slst)
                            {
                                sb.Append("{");
                                sb.Append("\"ItemName\":\"" + stree.MenuNameResource + "\",");
                                sb.Append("\"url\":\"" + stree.Url + "\",");
                                sb.Append("\"img\":\"" + stree.ImageurlShow + "\"");
                                sb.Append("},");
                            }
                            sb.Remove(sb.Length - 1, 1);


                            sb.Append("]},");

                        }
                        sb.Remove(sb.Length - 1, 1);


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
