using System;
using System.Data;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.UI.WebControls;
using EbSite.Base.Configs.ConfigsBase;
using EbSite.Modules.Wenda.ModuleCore.Entity;
namespace EbSite.Modules.Wenda.ModuleCore.BLL
{
    /// <summary>
    /// 业务逻辑类Config 的摘要说明。
    /// </summary>
    public class ConfigControl 
    {
        private static ConfigsManager<ModuleCore.Entity.ConfigInfo> BaseInstance;
        private static object _SyncRoot = new object();
        private static ConfigInfo _ConfigsEntity;
       
        static public ConfigInfo Instance
        {
            get
            {
                if (_ConfigsEntity == null)
                {
                    lock (_SyncRoot)
                    {
                        if (_ConfigsEntity == null)
                        {
                            _ConfigsEntity = BaseInstance.LoadConfig();
                        }
                    }
                }

                return _ConfigsEntity;
            }
        }
        static ConfigControl()
        {
            if (BaseInstance == null)
                BaseInstance = new ConfigsManager<ConfigInfo>(GetBaseConfigsPath);

        }
        public static void SaveConfig()
        {
            BaseInstance.Save(Instance);
        }
        public static void SaveConfig(ConfigInfo Configs)
        {
            BaseInstance.Save(Configs);
        }

        private static string filename = null;
        private static string GetBaseConfigsPath
        {
            get
            {
                if (filename == null)
                {
                    //SettingInfo.Instance.ModuleInfo.SetupPath
                    string mpath = SettingInfo.Instance.ModuleInfo.SetupPath;//EbSite.Base.Host.Instance.GetModulePath(new Guid("4e0edb7e-1b30-41ad-9f74-d63c80458c35"));
                    if (!Equals(HttpContext.Current, null))
                    {
                   
                    filename = HttpContext.Current.Server.MapPath("~/" + mpath + "/DataStore/Configs/AskConfig.config");
                    }
                    else
                    {
                        filename = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "" + mpath + "\\DataStore\\Configs\\AskConfig.config");
                    }
                     
                }
                return filename;
            }

        }
    }
}

