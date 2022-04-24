using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using EbSite.Core.FSO;

namespace EbSite.BLL
{
    public class SpaceTabsDefault : EbSite.Base.Datastore.XMLProviderBase<Entity.SpaceTabsDefault>
    {
        public static readonly SpaceTabsDefault Instance = new SpaceTabsDefault();
        /// <summary>
        /// 重写菜单的保存路径-绝对
        /// </summary>
        public override string SavePath
        {
            get
            {
                return HttpContext.Current.Server.MapPath(IISPath + "home/datastore/SpaceTabsDefault/");
            }
        }
        private SpaceTabsDefault()
        {
            if (!FObject.IsExist(SavePath, FsoMethod.Folder))
            {
                FObject.Create(SavePath, FsoMethod.Folder);
            }
        }
        public List<Entity.SpaceTabsDefault> GetDefaultTabsByUserGroup(int UserGroupID)
        {
            List<Entity.SpaceTabsDefault> lst = new List<Entity.SpaceTabsDefault>();

            foreach (Entity.SpaceTabsDefault spaceTabsDefault in base.FillList())
            {
                if(spaceTabsDefault.UserGroupID==UserGroupID)
                    lst.Add(spaceTabsDefault);
            }
            return lst;
        }
    }
}
