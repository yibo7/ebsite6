using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Web;
using EbSite.Base.Configs.ConfigsBase;

namespace EbSite.Base.Configs.BaseCinfigs
{
    public class ConfigsControl
    {

        private static ConfigsManager<ConfigsInfo> BaseInstance;
        private static object _SyncRoot = new object();
        private static ConfigsInfo _ConfigsEntity;
        static public ConfigsInfo Instance
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
        public static void SaveConfig()
        {
            BaseInstance.Save(Instance);
        }
        public static void SaveConfig(ConfigsInfo Configs)
        {
            BaseInstance.Save(Configs);
        }
        static ConfigsControl()
        {
            if (BaseInstance == null)
                BaseInstance = new ConfigsManager<ConfigsInfo>(GetBaseConfigsPath);
        }
        private static string filename = null;
        static private string GetBaseConfigsPath
        {
            get
            {
                if (filename == null)
                {
                    HttpContext context = HttpContext.Current;
                    if (context != null)
                    {
                        filename = context.Server.MapPath("~/Base.config");
                        if (!File.Exists(filename))
                        {
                            filename = context.Server.MapPath("~/Base.config");
                        }
                    }
                    else
                    {
                        filename = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Base.config");

                        //AppDomain.CurrentDomain.BaseDirectory 如: E:\\myweb\\EbSite\\EbSite\\project\\web\\
                    }

                    if (!File.Exists(filename))
                    {
                        throw new Exception("发生错误: 虚拟目录或网站根目录下没有正确的Base.config文件");
                    }
                }
                return filename;
            }
        }

    }
}
