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
    public class Content  
    {
        public static readonly Content Instance = new Content();
        /// <summary>
        /// 重写菜单的保存路径-绝对
        /// </summary>
        public  string SavePath
        {
            get
            {
                return string.Concat(EbSite.Base.Host.Instance.CurrentSite.GetPathDataSettingsContent(1), "set.config");
            }
        }
        private EbSite.Base.Configs.CustomOneConfig<Entity.DataSettingInfoForContent> cf
        {
            get
            {
                string CacheKey = "DataSettingsCategory-" + Base.Host.Instance.GetSiteID;
                CustomOneConfig<Entity.DataSettingInfoForContent> cfl = Base.Host.CacheRawApp.GetCacheItem<CustomOneConfig<Entity.DataSettingInfoForContent>>(CacheKey, "cf");// as CustomOneConfig<Entity.DataSettingInfoForContent>;
                if (cfl == null)
                {
                    cfl = new CustomOneConfig<DataSettingInfoForContent>(SavePath);
                    Base.Host.CacheRawApp.AddCacheItem(CacheKey, cfl, 10, ETimeSpanModel.FZ, "cf");
                }
                return cfl;
            }
        }
        private Content()
        {
            //cf = new CustomOneConfig<DataSettingInfoForContent>(SavePath);
        }
        public Entity.DataSettingInfoForContent GetConfigCurrent
        {
            get
            {

                return cf.ConfigsEntity();
            }
        }
        public void Update(Entity.DataSettingInfoForContent md)
        {
            cf.SaveConfig(md);
        }

        //public Entity.DataSettingInfoForContent GetBySite(int SiteID)
        //{
        //    DataSettingInfoForContent md = new DataSettingInfoForContent();

        //    foreach (DataSettingInfoForContent ct in lstDataList)
        //    {
        //        if (ct.SiteID == SiteID)
        //        {
        //            md = ct;
        //            break;
        //        }
        //    }
        //    if (md.id == Guid.Empty)
        //    {
        //        md.SiteID = SiteID;
        //        md.AdminSearchFileds = "NewsTitle|标题,ContentInfo|内容";
        //        md.SearchFileds = "NewsTitle,ContentInfo,Annex1,Annex2,Annex3,Annex4,Annex5,Annex6,Annex7,Annex8,Annex8,Annex10 ";
        //        md.SearchFileds_So = "NewsTitle,ContentInfo,Annex1,Annex2,Annex3,Annex4,Annex5,Annex6,Annex7,Annex8,Annex8,Annex10 ";
        //        md.SearchFileds_Tagv = "NewsTitle,ContentInfo,Annex1,Annex2,Annex3,Annex4,Annex5,Annex6,Annex7,Annex8,Annex8,Annex10 ";
        //        md.SearchFileds_Widget = "NewsTitle,ContentInfo,Annex1,Annex2,Annex3,Annex4,Annex5,Annex6,Annex7,Annex8,Annex8,Annex10 ";
        //        Add(md);
        //    }
        //    return md;
        //}

    }
}
