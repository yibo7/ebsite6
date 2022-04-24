using EbSite.Base.ControlPage;

namespace EbSite.Base.Modules
{
    using EbSite.Base.Page;
    using System;

    public abstract class MPUCBaseShow<TYPE> : UserControlBaseShow<TYPE>
    {
        public Host HostApi
        {
            get
            {
                return Host.Instance;
            }
        }
        /// <summary>
        /// 检测当前用户是否具有某个权限ID
        /// </summary>
        /// <param name="LimitID">权限Id</param>
        /// <returns></returns>
        override protected bool IsHaveLimit(string LimitID)
        {
            return HostApi.IsHaveLimit(EbSite.Base.AppStartInit.UserID, int.Parse(LimitID), ModuleID);
        }
        protected string GetModulePath
        {
            get
            {
                return HostApi.GetModulePath(ModuleID);
            }
        }
        /// <summary>
        /// 获取当前模块的ID
        /// </summary>
        protected Guid ModuleID
        {
            get
            {
                if (!string.IsNullOrEmpty(Request["mid"]))
                {
                    return new Guid(Request["mid"]);
                }
                else
                {
                    Tips("出错了", "找不到相应的模块数据，请确认访问路径是否正确！");
                }
                return Guid.Empty;
            }
        }
    }
}

