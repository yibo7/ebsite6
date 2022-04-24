using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EbSite.Core.FSO;
using EbSite.Modules.CQ.ModuleCore.Entity;

namespace EbSite.Modules.CQ.ModuleCore.BLL
{
    public class CustomItems : EbSite.Base.Datastore.XMLProviderBaseInt<CustomItemsInfo>
    {
        public static readonly CustomItems Instance = new CustomItems();
        /// <summary>
        /// 重写菜单的保存路径-绝对
        /// </summary>
        public override string SavePath
        {
            get
            {
                return HttpContext.Current.Server.MapPath(string.Concat(SettingInfo.Instance.GetBaseConfig.Instance.ModulePath, "DataStore/CustomItemsInfo/"));
            }
        }
        public List<Entity.CustomItemsInfo> GetParents()
        {
            return FillList();
        }
        public IEnumerable<Entity.CustomItemsInfo> GetListByParentID(int pid)
        {
            IEnumerable<Entity.CustomItemsInfo> lst = IFillList();

           return lst.Where(p => p.ParentID == pid);
        }
        private CustomItems()
        {

            if (!FObject.IsExist(SavePath, FsoMethod.Folder))
            {
                FObject.Create(SavePath, FsoMethod.Folder);
            }

           
        }

       
    }
}