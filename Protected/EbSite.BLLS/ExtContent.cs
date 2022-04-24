using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using EbSite.Base.ControlPage;
using EbSite.Core.FSO;
using EbSite.Entity;

namespace EbSite.BLL
{
    public class ExtContent
    {
        public List<ContentExtBase> GetCtrs(Guid ModuleID,Page pg)
        {
            string ModulePath =  EbSite.BLL.ModulesBll.Modules.Instance.GetModelPath(ModuleID);
             List<ContentExtBase> rtList = new List<ContentExtBase>();
           
            if(!string.IsNullOrEmpty(ModulePath))
            {
                ModulePath =  string.Concat(ModulePath, "/ExtContent/");
                if (Core.FSO.FObject.IsExist(HttpContext.Current.Server.MapPath(ModulePath), FsoMethod.Folder))
                {
                   FileInfo[] fs =  Core.FSO.FObject.GetFileListByType(ModulePath, "ascx");
                    foreach (FileInfo fileInfo in fs)
                    {
                        string sPath = string.Concat("~/", ModulePath, fileInfo.Name);
                        ContentExtBase uc = (ContentExtBase)pg.LoadControl(sPath);
                        rtList.Add(uc);

                    }
                }
                if (rtList.Count > 0)
                {
                    rtList = (from i in rtList orderby i.OrderID select i).ToList();
                }
            }
            return rtList;
        }
    }
}
