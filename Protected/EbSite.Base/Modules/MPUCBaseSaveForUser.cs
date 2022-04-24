
using EbSite.Base.ControlPage;

using EbSite.Base.Page;
using System;
namespace EbSite.Base.Modules
{

    public abstract class MPUCBaseSaveForUser : MPUCBaseSave
    {
        /// <summary>
        /// 获取当前模块所在的相对路径
        /// </summary>
        protected string GetCurrentModulePath
        {
            get
            {
                return EbSite.BLL.ModulesBll.Modules.Instance.GetModelPath(ModuleID);
            }
        }
        protected MPUCBaseSaveForUser()
        {
        }
        
        /// <summary>
        /// 检测当前用户是否具有某个权限ID
        /// </summary>
        /// <param name="LimitID">权限Id</param>
        /// <returns></returns>
        override protected bool IsHaveLimit(string LimitID)
        {
           
            return HostApi.IsHaveLimitForUser(EbSite.Base.AppStartInit.UserID, int.Parse(LimitID), ModuleID);
        }
    }
}

