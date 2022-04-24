using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using EbSite.Core.FSO;

namespace EbSite.BLL
{
    public class FastMenuClass : EbSite.Base.Datastore.XMLProviderBaseInt<Entity.FastMenuClass>
    {
        public static readonly FastMenuClass Instance = new FastMenuClass();
        /// <summary>
        /// 重写菜单的保存路径-绝对
        /// </summary>
        public override string SavePath
        {
            get
            {
                return EbSite.Base.Host.Instance.CurrentSite.GetPathFastMenuClass(1);
                //return HttpContext.Current.Server.MapPath(string.Concat(IISPath, "datastore/ErrInfo/"));
            }
        }
        private FastMenuClass()
        {
            if (!FObject.IsExist(SavePath, FsoMethod.Folder))
            {
                FObject.Create(SavePath, FsoMethod.Folder);
            }

        }
    }
}
