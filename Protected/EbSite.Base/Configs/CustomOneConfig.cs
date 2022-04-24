using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Web;
using EbSite.Base.Configs.ConfigsBase;
using EbSite.Core.FSO;
using EbSite.Entity;

namespace EbSite.Base.Configs
{
    

    /// <summary>
    /// 处理任何一个设置文件
    /// </summary>
    /// <typeparam name="T">设置文件的实体类型</typeparam>
    public class CustomOneConfig<T>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ConfigPathAndFileName">设置文件的路径</param>
        public CustomOneConfig(string ConfigPathAndFileName)
        {
            if (Instance == null)
            {
                string sPath = ConfigPathAndFileName;
                if (!Core.FSO.FObject.IsExist(sPath,FsoMethod.File))
                {
                    FObject.WriteFile(sPath, "");
                }
                Instance = new ConfigsManager<T>(sPath);
                
            }


        }

        private ConfigsManager<T> Instance;

        private T _ConfigsEntity;
        public T ConfigsEntity()
        {
            if(_ConfigsEntity!=null)
            {
                return _ConfigsEntity;
            }
            else
            {
                _ConfigsEntity = Instance.LoadConfig();
                return _ConfigsEntity;
            }

        }
       
        public  void SaveConfig()
        {
            Instance.Save(ConfigsEntity());
        }
        public void SaveConfig(T Configs)
        {
            Instance.Save(Configs);
        }


    }
}
