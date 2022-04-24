
//using System;
//using System.Web;
//using EbSite.Base.Configs.ConfigsBase;
//using EbSite.Core;
//using EbSite.Core.Strings;

//namespace EbSite.Base.Modules.Configs
//{
   

//    public class ConfigsControl<TYPE> where TYPE : class , new()
//    {
//        protected string _ConfigName;
//        protected string _ModuleFolder;
//        private object _SyncRoot;
//        private ConfigsManager<TYPE> BaseInstance;
//        //private CacheManager cm;
//        private string filename;

//        public ConfigsControl(string ModuleFolder, string ConfigName)
//        {
//            this._SyncRoot = new object();
//            this.filename = null;
//            //this.cm = new CacheManager(new string[] { GetString.GetFileName(ConfigName) });
//            this._ModuleFolder = ModuleFolder;
//            this._ConfigName = ConfigName;
//            InitData();
//        }
//        public ConfigsControl()
//        {
//            this._SyncRoot = new object();
//            this.filename = null;
           
            
//        }
//        public void InitData()
//        {
//            if (object.Equals(this.BaseInstance, null))
//            {
//                this.BaseInstance = new ConfigsManager<TYPE>(this.GetBaseConfigsPath);
//            }
//        }
//        public void SaveConfig()
//        {
//            this.BaseInstance.Save(this.Instance);
//        }

//        public void SaveConfig(TYPE Configs)
//        {
//            this.BaseInstance.Save(Configs);
//        }

//        private string GetBaseConfigsPath
//        {
//            get
//            {
//                if (object.Equals(HttpContext.Current, null))
//                {
//                    throw new Exception("配置文件找不到！");
//                }
//                this.filename = string.Format("{0}{1}/{2}",EbSite.Base.Configs.SysConfigs.ConfigsControl.Instance.sMapPath, this._ModuleFolder, this._ConfigName);
//                //在虚拟目录下有问题
//                //HttpContext.Current.Server.MapPath(string.Format("{0}/{1}", this._ModuleFolder, this._ConfigName));
//                //Log.Factory.GetInstance().InfoLog("fffff:" + filename);
//                return this.filename;
//            }
//        }

//        public TYPE Instance
//        {
//            get
//            {
//                return this.BaseInstance.LoadConfig();
//                //string rawKey = string.Concat("inst", typeof(TYPE).FullName);
//                //TYPE cacheItem = (TYPE)this.cm.GetCacheItem(rawKey);
//                //if (object.Equals(cacheItem, null))
//                //{
//                //    lock (this._SyncRoot)
//                //    {
//                //        if (object.Equals(cacheItem, null))
//                //        {
//                //            cacheItem = this.BaseInstance.LoadConfig();
//                //            this.cm.AddCacheItem(rawKey, cacheItem);
//                //        }
//                //    }
//                //}
//                //return cacheItem;
//            }
//        }
//    }
//}

