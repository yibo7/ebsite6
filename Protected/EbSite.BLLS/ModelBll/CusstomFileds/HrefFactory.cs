using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using EbSite.Base;
using EbSite.Base.EntityAPI;
using EbSite.Base.Static;
using EbSite.Core;

namespace EbSite.BLL.ModelBll.CusstomFileds
{
    public class HrefFactory
    {
       // public static CacheManager CacheApp;
        const double cachetime = 1;//
        private const string cacheHrefFactory = "hreffactory";//private static readonly string[] MasterCacheKeyArray = { "CusstomFileds" };
        //static HrefFactory()
        //{
        //    CacheApp = new CacheManager(CacheDuration, MasterCacheKeyArray);
        //}

        public static CusttomFiledsBLL<List<DataFiled>> GetInstContent(Guid ModelID, int SiteID)
        {
            string rawKey = string.Concat("GetInstContent", ModelID);
            CusttomFiledsBLL<List<DataFiled>> _Instance = Host.CacheRawApp.GetCacheItem<CusttomFiledsBLLContent>(rawKey, cacheHrefFactory);
            if (_Instance == null)
            {
                _Instance = new CusttomFiledsBLLContent(ModelID, SiteID);
                Host.CacheRawApp.AddCacheItem(rawKey, _Instance, cachetime, ETimeSpanModel.T, cacheHrefFactory);// CacheApp.AddCacheItem(rawKey, _Instance);
            }

            return _Instance; 
        }

        //静态工厂方法
        public static CusttomFiledsBLL<StringDictionary> GetInstance(Guid ModelID, ModelType mt, int SiteID)
        {
            string rawKey = string.Concat("CusttomFiledsBLL", ModelID, "-", mt);
            CusttomFiledsBLL<StringDictionary> _Instance;
            if (mt == ModelType.FLMX)
            {
                _Instance = Host.CacheRawApp.GetCacheItem<CusttomFiledsBLLClass>(rawKey, cacheHrefFactory);//CacheApp.GetCacheItem(rawKey) as CusttomFiledsBLLClass;
                if (_Instance == null)
                {
                    _Instance = new CusttomFiledsBLLClass(ModelID, SiteID);
                    Host.CacheRawApp.AddCacheItem(rawKey, _Instance, cachetime, ETimeSpanModel.T, cacheHrefFactory);// CacheApp.AddCacheItem(rawKey, _Instance);
                }
            }
            else if (mt == ModelType.YHMX)
            {
                _Instance = Host.CacheRawApp.GetCacheItem<CusttomFiledsBLLUser>(rawKey, cacheHrefFactory); //CacheApp.GetCacheItem(rawKey) as CusttomFiledsBLLUser;
                if (_Instance == null)
                {
                    _Instance = new CusttomFiledsBLLUser(ModelID, SiteID);
                    Host.CacheRawApp.AddCacheItem(rawKey, _Instance, cachetime, ETimeSpanModel.T, cacheHrefFactory); //CacheApp.AddCacheItem(rawKey, _Instance);
                }
            }
            else if (mt == ModelType.BDMX)
            {
                _Instance = Host.CacheRawApp.GetCacheItem<CusttomFiledsBLLForm>(rawKey,cacheHrefFactory) ;
                if (_Instance == null)
                {
                    _Instance = new CusttomFiledsBLLForm(ModelID,SiteID);
                   Host.CacheRawApp.AddCacheItem(rawKey, _Instance,cachetime, ETimeSpanModel.T, cacheHrefFactory);
                }
            }
            else
            {
                throw new Exception("找不到模型类型！");
            }

           
            return _Instance; 

        }
       
    }
}
