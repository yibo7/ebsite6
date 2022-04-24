using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using EbSite.Core.FSO;
using EbSite.Entity.Module;

namespace EbSite.BLL.ModulesBll
{

    abstract public class LimitRole<LimitType> : Base.Datastore.XMLProviderBase<LimitRoleInfo<LimitType>>
    {
        protected string _sLimitRolePath;
        /// <summary>
        /// 重写菜单的保存路径-绝对
        /// </summary>
        public override string SavePath
        {
            get
            {
                return HttpContext.Current.Server.MapPath(MenuPath);
            }
        }
        /// <summary>
        /// 菜单的相对保存路径
        /// </summary>
       abstract public string MenuPath{ get;}

        public LimitRole(Guid ModuleID)
        {
            base.Id = ModuleID;
            _sLimitRolePath = Modules.Instance.GetModelPath(ModuleID);
            if (!FObject.IsExist(SavePath, FsoMethod.Folder))
            {
                FObject.Create(SavePath, FsoMethod.Folder);
            }
        }
        public LimitRole()
        {
            
            if (!FObject.IsExist(SavePath, FsoMethod.Folder))
            {
                FObject.Create(SavePath, FsoMethod.Folder);
            }
        }
        /// <summary>
        /// 检测某个角色下是否存在某个权限
        /// </summary>
        /// <param name="iRoleID">角色ID</param>
        /// <param name="LimitID">权限ID</param>
        /// <returns></returns>
        public bool IsHave(int iRoleID, LimitType LimitID)
        {
            List<LimitRoleInfo<LimitType>> lst = GetLimitsByRoleID(iRoleID);

            foreach (LimitRoleInfo<LimitType> info in lst)
            {
                if (info.LimitID.Equals(LimitID))
                    return true;
            }
            return false;
        }
        /// <summary>
        /// 获取某个角色下的权限对应关系
        /// </summary>
        /// <param name="iRoleID"></param>
        /// <returns></returns>
        public List<LimitRoleInfo<LimitType>> GetLimitsByRoleID(long iRoleID)
        {
            List<LimitRoleInfo<LimitType>> lst = new List<LimitRoleInfo<LimitType>>();
            string CacheRawKey = string.Format("mddata{0}r{1}{2}", base.Id, iRoleID, DataFolder);
            List<LimitRoleInfo<LimitType>> cacheItem = base.GetCacheItem<List<LimitRoleInfo<LimitType>>>(CacheRawKey);
            if (object.Equals(cacheItem, null))
            {
                foreach (LimitRoleInfo<LimitType> limitInfo in FullData)
                {
                    if (Equals(limitInfo.RoleID, iRoleID))
                    {
                        lst.Add(limitInfo);
                    }
                }
                cacheItem = lst;
                base.AddCacheItem(CacheRawKey, cacheItem);
            }
            return cacheItem;
        }
        private List<LimitRoleInfo<LimitType>> FullData
        {
            get
            {
                return base.lstDataList;
                //string CacheRawKey = string.Format("mddata{0}{1}", base.Id, DataFolder);
                //List<LimitRoleInfo<LimitType>> cacheItem = base.GetCacheItem(CacheRawKey) as List<LimitRoleInfo<LimitType>>;
                //if (object.Equals(cacheItem, null))
                //{
                //    cacheItem = base.lstDataList;
                //    base.AddCacheItem(CacheRawKey, cacheItem);
                //}
                //return cacheItem;
            }
        }
        public void AddList(List<LimitRoleInfo<LimitType>> lst, int iRoleID)
        {
            //删除原来所有权限
            foreach (LimitRoleInfo<LimitType> limitRoleInfo in base.lstDataList)
            {
                if (limitRoleInfo.RoleID == iRoleID)
                    Delete(limitRoleInfo.id);
            }
            //添加新权限对应关系
            foreach (LimitRoleInfo<LimitType> info in lst)
            {
                base.Add(info);
            }
        }
    }
}
