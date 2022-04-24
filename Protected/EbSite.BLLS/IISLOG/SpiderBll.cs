using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using EbSite.Base.Entity;
using EbSite.Core.FSO;

namespace EbSite.BLL.IISLOG
{
    public class SpiderBll : EbSite.Base.Datastore.XMLProviderBaseInt<SpiderEntity>
    {
       public static readonly SpiderBll Instance = new SpiderBll();
        /// <summary>
        /// 重写菜单的保存路径-绝对
        /// </summary>
        public override string SavePath
        {
            get
            {
                return HttpContext.Current.Server.MapPath(string.Concat(IISPath, "datastore/Spider/"));
            }
        }
        private SpiderBll()
        {
            if (!FObject.IsExist(SavePath, FsoMethod.Folder))
            {
                FObject.Create(SavePath, FsoMethod.Folder);
            }
        }
    }
}
