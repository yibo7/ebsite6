using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using EbSite.Base.Modules;
using EbSite.Core;

namespace EbSite.Modules.UserBaseInfo
{
    public class ConfigInfo
    {
        private string _FavoriteName = "收藏夹";
        /// <summary>
        /// 收藏名称
        /// </summary>
        public string FavoriteName
        {
            get
            {
                return _FavoriteName;
            }
            set
            {
                _FavoriteName = value;
            }
        }


        private string _UseMyDemainGroup = "-1";
        /// <summary>
        /// 可以使用个性域名的用户级别
        /// </summary>
        public string UseMyDemainGroup
        {
            get
            {
                return _UseMyDemainGroup;
            }
            set
            {
                _UseMyDemainGroup = value;
            }
        }



        private string _AllowModifyDefaultTabGroup = "-1";
        /// <summary>
        /// 允许操作默认空间菜单的用户级别
        /// </summary>
        public string AllowModifyDefaultTabGroup
        {
            get
            {
                return _AllowModifyDefaultTabGroup;
            }
            set
            {
                _AllowModifyDefaultTabGroup = value;
            }
        }



        private string _AllowModifyTabGroup = "-1";
        /// <summary>
        /// 允许修改空间菜单的用户级别
        /// </summary>
        public string AllowModifyTabGroup
        {
            get
            {
                return _AllowModifyTabGroup;
            }
            set
            {
                _AllowModifyTabGroup = value;
            }
        }



        private string _AllowAddTabGroup = "-1";
        /// <summary>
        /// 允许添加空间菜单的用户级别
        /// </summary>
        public string AllowAddTabGroup
        {
            get
            {
                return _AllowAddTabGroup;
            }
            set
            {
                _AllowAddTabGroup = value;
            }
        }



        private string _AllowOrderTabGroup = "-1";
        /// <summary>
        /// 允许排序空间菜单的用户级别
        /// </summary>
        public string AllowOrderTabGroup
        {
            get
            {
                return _AllowOrderTabGroup;
            }
            set
            {
                _AllowOrderTabGroup = value;
            }
        }



        private string _UseThemeGroup = "-1";
        /// <summary>
        /// 允许更换皮肤的用户级别
        /// </summary>
        public string UseThemeGroup
        {
            get
            {
                return _UseThemeGroup;
            }
            set
            {
                _UseThemeGroup = value;
            }
        }



        private string _UseLayout = "-1";
        /// <summary>
        /// 允许更换版式的用户级别
        /// </summary>
        public string UseLayout
        {
            get
            {
                return _UseLayout;
            }
            set
            {
                _UseLayout = value;
            }
        }



        private string _UseWidgets = "-1";
        /// <summary>
        /// 允许更换部件的用户级别
        /// </summary>
        public string UseWidgets
        {
            get
            {
                return _UseWidgets;
            }
            set
            {
                _UseWidgets = value;
            }
        }

        private string _AllowOpenSiteGroup = "-1";
        /// <summary>
        /// 允许开通个人空间的用户级别
        /// </summary>
        public string AllowOpenSiteGroup
        {
            get
            {
                return _AllowOpenSiteGroup;
            }
            set
            {
                _AllowOpenSiteGroup = value;
            }
        }
    }

    public class Configs
    {
        public readonly static Configs Instance = new Configs();
        private JsonFile<ConfigInfo> iniParser;
        public ConfigInfo Model;
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

            iniParser = new JsonFile<ConfigInfo>(sPath);
            Model = iniParser.Model;
        }

        public void Save()
        {
            iniParser.Save();

        }
         
         

    }
}