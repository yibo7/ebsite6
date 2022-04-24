using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using EbSite.Base.Modules;
using EbSite.Core;

namespace EbSite.Modules.Wenda
{
    public class ConfigInf
    {
        private bool _IsAllowUserAdd = false;
        /// <summary>
        /// 是否允许申请友情连接
        /// </summary>
        public bool IsAllowUserAdd
        {
            get
            {
                return _IsAllowUserAdd;
            }
            set
            {
                _IsAllowUserAdd = value;
            }
        }

        private string _HaveOtherPrice = "a";
        public string HaveOtherPrice
        {
            get { return _HaveOtherPrice; }
            set { _HaveOtherPrice = value; }
        }

        private string _txtCatalog = "qft.ashx";
        /// <summary>
        /// 快速发帖子
        /// </summary>
        public string txtCatalog
        {
            get { return _txtCatalog; }
            set { _txtCatalog = value; }
        }


        private string _contentpath;
        /// <summary>
        /// 内容显示连接地址相对
        /// </summary>
        public string ContentPath
        {
            get { return _contentpath; }
            set { _contentpath = value; }
        }

        private string _txtReplay = "qht.ashx";
        /// <summary>
        /// 快速回帖子
        /// </summary>
        public string txtReplay
        {
            get { return _txtReplay; }
            set { _txtReplay = value; }
        }
    }

    public class Configs
    {
        public readonly static Configs Instance = new Configs();
        private JsonFile<ConfigInf> iniParser;
        public ConfigInf Model;
        private Configs()
        {
             
            string sPath = string.Concat(SettingInfo.Instance.ModuleInfo.SetupPath, @"/SettingInfo.json");

            HttpContext context = HttpContext.Current;
            if (context != null)
            {
                sPath = context.Server.MapPath(sPath);

            }
            else
            {
                sPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, sPath);
                 
            }

            iniParser = new JsonFile<ConfigInf>(sPath);
            Model = iniParser.Model;
        }

        public void Save()
        {
            iniParser.Save();

        }
         
         

    }
}