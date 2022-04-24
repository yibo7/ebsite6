using System;
using EbSite.Core;

namespace EbSite.Base.Configs.ConfigsBase
{
    public class ConfigsManager<ConfigModel>
    {
        /// <summary>
        /// 文件修改时间
        /// </summary>
        private bool isChange;
        /// <summary>
        /// 配置文件所在路径
        /// </summary>
        private string _filename;


        const double CacheDuration = 60.0;
        private readonly string[] MasterCacheKeyArray = { "ConfigCache" };
        private CacheRaw ConfigCache;
        /// <summary>
        /// 初始化文件修改时间和对象实例
        /// </summary>
        public ConfigsManager(string filename)
        {
            _filename = filename;

            ConfigCache = new CacheRaw(CacheDuration, MasterCacheKeyArray);
            DateTime dtNew = System.IO.File.GetLastWriteTime(_filename);


            string rawKey = string.Concat("Date-", filename);
            string sOld = ConfigCache.GetCacheItem(rawKey) as string;

            if (sOld == null || (DateTime.Parse(sOld) != dtNew))
            {
                ConfigCache.AddCacheItem(rawKey, dtNew.ToString());
                isChange = true;
            }
            else
            {
                isChange = false;
            }
        }



        /// <summary>
        /// 返回配置类实例
        /// </summary>
        /// <returns></returns>
        public ConfigModel LoadConfig()
        {

            string rawKey = string.Concat("Model-", _filename);
            ConfigModel configinfo = (ConfigModel)ConfigCache.GetCacheItem(rawKey);

            if (configinfo == null || isChange)
            {
                configinfo = DeserializeInfo();
                ConfigCache.AddCacheItem(rawKey, configinfo);
            }
            return configinfo;
        }
        private ConfigModel DeserializeInfo()
        {
            try
            {
                return (ConfigModel)SerializationHelper.Load(typeof(ConfigModel), _filename);
            }
            catch (Exception e)
            {

                throw new Exception(string.Format("配件文件反序列出错，可能是配置文件格式不规范造成,文件:{0},出错信息:{1}", _filename,e.Message));
            }
            
        }

        /// <summary>
        /// 保存配置类实例
        /// </summary>
        /// <returns></returns>
        public bool Save(ConfigModel ConfigInfo)
        {
            //ConfigCache.InvalidateCache();
            return SerializationHelper.Save(ConfigInfo, _filename);
        }
    }
}
