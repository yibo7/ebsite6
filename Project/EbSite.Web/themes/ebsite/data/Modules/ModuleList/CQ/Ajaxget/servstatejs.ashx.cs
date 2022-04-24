using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EbSite.Base.EntityAPI;
using EbSite.Modules.CQ.ModuleCore.BLL;
using EbSite.Modules.CQ.ModuleCore.Entity;

namespace EbSite.Modules.CQ.Ajaxget
{
    /// <summary>
    /// Summary description for servstatejs
    /// </summary>
    public class servstatejs : IHttpHandler
    {
        //public int RandServerID()
        //{
        //    List<EbSite.Modules.CQ.ModuleCore.Entity.ServiceInfo> ls = EbSite.Modules.CQ.ModuleCore.BLL.Service.Instance.FillList();

        //    List<EbSite.Modules.CQ.ModuleCore.Entity.ServiceInfo> onlinenls;
        //    List<EbSite.Modules.CQ.ModuleCore.Entity.ServiceInfo> nonls;
        //    onlinenls = (from i in ls where i.IsOnline == true orderby Guid.NewGuid() select i).Take(1).ToList();
        //    if (onlinenls.Count > 0)
        //    {
        //        return onlinenls[0].id;
        //    }
        //    else
        //    {
        //        nonls = (from i in ls where i.IsOnline == false orderby Guid.NewGuid() select i).Take(1).ToList();
        //        if (nonls.Count > 0)
        //        {
        //            return nonls[0].id;
        //        }
        //    }
        //    return 0;
        //}
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            context.Response.Write(string.Concat("var RandUserID=" +  ModuleCore.BLL.Service.Instance.ServerForFree(0) + ";var ebservstate=", Core.ListJson.Obj2Json(GetServicerOnline())));
        }
        public List<ListItemModel> GetServicerOnline()
        {
            List<ListItemModel> lst = new List<ListItemModel>();

            List<ModuleCore.Entity.ServiceInfo> lstServ = Service.Instance.FillList();

            foreach (ServiceInfo serviceInfo in lstServ)
            {
                ListItemModel md = new ListItemModel(serviceInfo.id.ToString(), serviceInfo.IsOnline ? "1" : "0");
                lst.Add(md);
            }

            return lst;
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