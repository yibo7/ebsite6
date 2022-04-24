using System.Web;
using EbSite.Base.Modules;
using System;
using EbSite.Base.Static;

namespace EbSite.Base.Modules.Configs
{
    public abstract class ModulesConfigsBase
    {
        abstract public Guid CurrentModelID { get; }
    }
    
    /// <summary>
    /// 自定义配置基类 对应模块下的 Setting.config
    /// </summary>
    /// <typeparam name="ConfigType"></typeparam>
    [Serializable]
    public abstract class Configs : ModulesConfigsBase// where ConfigType : class , new()
    {
        public EbSite.Entity.ModuleInfo ModuleInfo
        {
            get
            {
               return EbSite.BLL.ModulesBll.Modules.Instance.GetEntity(CurrentModelID);
            }
        }

        public Configs()
        {
            //this._IsUserSysConn = false;
        }
        ///// <summary>
        ///// 获取模块的基础设置类
        ///// </summary>
        //public ConfigsControl<ConfigsBaseInfo> GetBaseConfig
        //{
        //    get
        //    {
        //        string rawKey = string.Concat("GetEntity-", CurrentModelID);
        //        ConfigsControl<ConfigsBaseInfo> etEntity = Host.CacheRawApp.GetCacheItem<ConfigsControl<ConfigsBaseInfo>>(rawKey, "GetBaseConfig");// as ConfigsControl<ConfigsBaseInfo>;
        //        if (Equals(etEntity, null))
        //        {
        //            if (!string.IsNullOrEmpty(this.GetModulePath))
        //            {
        //                etEntity = new ConfigsControl<ConfigsBaseInfo>(this.GetModulePath, "/DataStore/Configs/Base.config");
        //                if (!Equals(etEntity, null))
        //                    Host.CacheRawApp.AddCacheItem(rawKey, etEntity, 1, ETimeSpanModel.XS, "GetBaseConfig");
        //            }

        //        }
        //        return etEntity;
        //    }
        //}
        public int GetSiteID
        {
            get
            {
               return EbSite.BLL.ModulesBll.Modules.Instance.GetSiteIDByModuleID(CurrentModelID);
            }
        } 
        
        /// <summary>
        /// 获取模块的安装路径
        /// </summary>
        private string GetModulePath
        {
            get
            {
                string sPath = string.Empty;

               sPath =  EbSite.BLL.ModulesBll.Modules.Instance.GetModelPath(CurrentModelID);
                
                return sPath;
 
            }
        }

        ///// <summary>
        ///// 获取自定义配置实例
        ///// </summary>
        //public ConfigsControl<ConfigType> GetSysConfig
        //{
        //    get
        //    {

        //        if (!string.IsNullOrEmpty(this.GetModulePath))
        //        {
        //            return new ConfigsControl<ConfigType>(this.GetModulePath, "/DataStore/Configs/Setting.config");
        //        }
        //        return null;
        //    }
        //}
        
        public Host HostApi
        {
            get
            {
                return Host.Instance;
            }
        }
        ///// <summary>
        ///// 安装之前执行此方法
        ///// </summary>
        //virtual public  void Installing()
        //{
            
        //}
        ///// <summary>
        ///// 卸载之前执行此方法
        ///// </summary>
        //virtual public void Uninstalling()
        //{
            
        //}
         
    }
}

