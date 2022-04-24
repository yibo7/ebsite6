using System;
using System.Collections.Generic;
using System.Web;
using EbSite.Base.Entity;

namespace EbSite.Modules.CQ.ModuleCore.Entity
{
    [Serializable]
    public class ChatPlugin : XmlEntityBase<int>
    {
        /// <summary>
        /// 插件名称
        /// </summary>
        public string PluginTitle { get; set; }
        /// <summary>
        /// 插件url
        /// </summary>
        public string Url { get; set; }
        public string Info { get; set; }
        public DateTime _LastDateTime = DateTime.Now;
        public DateTime LastDateTime
        {
            get
            {
                return _LastDateTime;
            }
            set
            {
                _LastDateTime = value;
            }
        }
        
        
    }
}