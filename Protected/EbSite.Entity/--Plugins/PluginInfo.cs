//using System;
//using EbSite.Base.Entity;
//using EbSite.Base.Plugin.Base;

//namespace EbSite.Entity
//{
//    [Serializable]
//    public class PluginInfo : XmlEntityBase
//    {
//        private string name, typeName, version, author, authorUrl, updateStatus, configsInfo, help,basetype;
//        private bool enabled = true;
//        //private bool selecTed = true;
//        public PluginInfo()
//        {

//        }

//        /// <summary>
//        /// 
//        /// </summary>
//        /// <param name="info"></param>
//        /// <param name="typeName"></param>
//        /// <param name="updateStatus"></param>
//        /// <param name="disabled"></param>
//        /// <param name="selected"></param>
//        /// <param name="configsinfo"></param>
//        public PluginInfo(ProviderInfo info, string typeName, string updateStatus, bool enaBled, string sHelp,string sbasetype)
//        {
//            name = info.Name;
//            this.typeName = typeName;
//            version = info.Version;
//            author = info.Author;
//            authorUrl = info.Url;
//            this.updateStatus = updateStatus;
//            this.help = sHelp;
//            this.enabled = !enaBled;
//            //this.selecTed = selected;
//            this.basetype = sbasetype;
//        }
//        public string BaseType
//        {
//            get { return basetype; }
//            set { basetype = value; }
//        }
//        public string Help
//        {
//            get { return help; }
//            set { help = value; }
//        }
//        /// <summary>
//        /// 插件是否已经启用
//        /// </summary>
//        public bool Enabled
//        {
//            get { return enabled; }
//            set { enabled = value; }
//        }
//        ///// <summary>
//        ///// 是否选择
//        ///// </summary>
//        //public bool Selected
//        //{
//        //    get { return selecTed; }
//        //    set { selecTed = value; }
//        //}
//        /// <summary>
//        /// 插件的配置信息
//        /// </summary>
//        public string ConfigsInfo
//        {
//            get { return configsInfo; }
//            set { configsInfo = value; }
//        }
//        /// <summary>
//        /// 获取插件名称
//        /// </summary>
//        public string Name
//        {
//            get { return name; }
//            set { name = value; }
//        }

//        /// <summary>
//        /// 获取插件类型
//        /// </summary>
//        public string TypeName
//        {
//            get { return typeName; }
//            set { typeName = value; }
//        }

//        /// <summary>
//        /// 获取插件版本
//        /// </summary>
//        public string Version
//        {
//            get { return version; }
//            set { version = value; }
//        }

//        /// <summary>
//        /// 获取插件开发者
//        /// </summary>
//        public string Author
//        {
//            get { return author; }
//            set { author = value; }
//        }

//        /// <summary>
//        /// 获取插件开发者URL.
//        /// </summary>
//        public string AuthorUrl
//        {
//            get { return authorUrl; }
//            set { authorUrl = value; }
//        }

//        /// <summary>
//        /// 获取插件的更新状态，如是不有新版本
//        /// </summary>
//        public string UpdateStatus
//        {
//            get { return updateStatus; }
//            set { updateStatus = value; }
//        }

//        ///// <summary>
//        ///// 获取额外的CSS类。
//        ///// </summary>
//        //public string AdditionalClass {
//        //    get { return additionalClass; }
//        //}

//    }
//}
