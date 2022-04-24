using System;
using System.Collections.Generic;

using System.Web;
using EbSite.Core.FSO;
using EbSite.Entity;

namespace EbSite.BLL
{
    public class HomeWidget : EbSite.Base.Datastore.XMLProviderBase<HomeWidgetInfo>
    {
        public static readonly HomeWidget Instance = new HomeWidget();
        /// <summary>
        /// 重写菜单的保存路径-绝对
        /// </summary>
        public override string SavePath
        {
            get
            {
                return HttpContext.Current.Server.MapPath(IISPath + "home/datastore/WidgetsTem/");
            }
        }
        private HomeWidget()
        {

            if (!FObject.IsExist(SavePath, FsoMethod.Folder))
            {
                FObject.Create(SavePath, FsoMethod.Folder);
            }
        }
    }
}