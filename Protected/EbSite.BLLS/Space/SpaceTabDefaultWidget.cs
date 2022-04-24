using System;
using System.Collections.Generic;

using System.Web;
using EbSite.Core.FSO;
using EbSite.Entity;

namespace EbSite.BLL
{
    public class SpaceTabDefaultWidget : EbSite.Base.Datastore.XMLProviderBase<SpaceTabDefaultWidgetInfo>
    {
        public static readonly SpaceTabDefaultWidget Instance = new SpaceTabDefaultWidget();
        /// <summary>
        /// 重写菜单的保存路径-绝对
        /// </summary>
        public override string SavePath
        {
            get
            {
                return HttpContext.Current.Server.MapPath(IISPath + "home/datastore/SpaceTabsDefaultWidget/");
            }
        }
        private SpaceTabDefaultWidget()
        {

            if (!FObject.IsExist(SavePath, FsoMethod.Folder))
            {
                FObject.Create(SavePath, FsoMethod.Folder);
            }
        }
    }
}