using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EbSite.Base.Entity;

namespace EbSite.Modules.Wenda.ModuleCore.Entity
{
 /// <summary>
 /// 随机发帖子，ip 地址范围
 /// </summary>
    public class IpInfo 
    {
       
        private string _ips;
        /// <summary>
        /// ip地址区域
        /// </summary>
        public string  Ips
        {
            get { return _ips; }
            set { _ips = value; }
        }
       
       

    }
}