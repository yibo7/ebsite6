using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using EbSite.Core.FSO;

namespace EbSite.BLL
{
    public class FastMenu : EbSite.Base.Datastore.XMLProviderBaseInt<Entity.FastMenu>
    {
        public static readonly FastMenu Instance = new FastMenu();
        /// <summary>
        /// 重写菜单的保存路径-绝对
        /// </summary>
        public override string SavePath
        {
            get
            {
                return EbSite.Base.Host.Instance.CurrentSite.GetPathFastMenu(1);
                //return HttpContext.Current.Server.MapPath(string.Concat(IISPath, "datastore/ErrInfo/"));
            }
        }
        private FastMenu()
        {
            if (!FObject.IsExist(SavePath, FsoMethod.Folder))
            {
                FObject.Create(SavePath, FsoMethod.Folder);
            }

        }
    }
}
