using System;
using System.Collections.Generic;

using System.Web;
using EbSite.Core.FSO;
using EbSite.Entity;

namespace EbSite.BLL
{
    public class LayoutPane : EbSite.Base.Datastore.XMLProviderBase<Entity.LayoutPaneInfo>
    {
        public static readonly LayoutPane Instance = new LayoutPane();
        /// <summary>
        /// 重写菜单的保存路径-绝对
        /// </summary>
        public override string SavePath
        {
            get
            {
                return HttpContext.Current.Server.MapPath(IISPath + "home/datastore/LayoutPane/");
            }
        }
        private LayoutPane()
        {
            //string sPath = HttpContext.Current.Server.MapPath(IISPath + "home/datastore/LayoutPane/");
            if (!FObject.IsExist(SavePath, FsoMethod.Folder))
            {
                FObject.Create(SavePath, FsoMethod.Folder);
            }
        }
    }
}