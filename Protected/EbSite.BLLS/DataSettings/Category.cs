using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using EbSite.Base.Configs;
using EbSite.Base.Static;
using EbSite.Core.FSO;
using EbSite.Entity;

namespace EbSite.BLL.DataSettings
{
    public class Category 
    {
        public static readonly Category Instance = new Category();
        /// <summary>
        /// 重写菜单的保存路径-绝对
        /// </summary>
        public  string SavePath
        {
            get
            {
                return string.Concat(EbSite.Base.Host.Instance.CurrentSite.GetPathDataSettingsClass(1),"set.config");
            }
        }

        private EbSite.Base.Configs.CustomOneConfig<Entity.DataSettingInfoForClass> cf
        {
            get
            {
                string CacheKey = string.Concat("DataSettingsCategory-" , Base.Host.Instance.GetSiteID);
                CustomOneConfig<Entity.DataSettingInfoForClass> cfl = Base.Host.CacheRawApp.GetCacheItem<CustomOneConfig<Entity.DataSettingInfoForClass>>(CacheKey, "cf");// as CustomOneConfig<Entity.DataSettingInfoForClass>;
                if (cfl == null)
                {
                    cfl = new CustomOneConfig<DataSettingInfoForClass>(SavePath);
                    Base.Host.CacheRawApp.AddCacheItem(CacheKey, cfl, 10, ETimeSpanModel.FZ, "cf");
                }
                return cfl;
            }
        }
        private Category()
        {

            //cf = new CustomOneConfig<DataSettingInfoForClass>(SavePath);
            //if (!FObject.IsExist(SavePath, FsoMethod.File))
            //{
            //    cf.SaveConfig(new DataSettingInfoForClass());
            //}

        }
       
        public Entity.DataSettingInfoForClass GetConfigCurrent
        {
            get
            {

                return cf.ConfigsEntity();
            }
        }
        public void Update(Entity.DataSettingInfoForClass md)
        {
            cf.SaveConfig(md);
        }
        
    }
}
