

using System;
using System.IO;
using System.Web;
using EbSite.Base.Configs.ConfigsBase;
using EbSite.Core.FSO;

namespace EbSite.Widgets.LocoySpider.Serializable
{
    public class ConfigsControl
    {

        private  ConfigsManager<EbSite.Entity.NewsContent> BaseInstance;
        private  object _SyncRoot = new object();
        private  Entity.NewsContent _ConfigsEntity;

        public  Entity.NewsContent Instance
        {
            get
            {
                if (_ConfigsEntity == null)
                {
                    lock (_SyncRoot)
                    {
                        if (_ConfigsEntity == null)
                        {
                            try
                            {
                                _ConfigsEntity = BaseInstance.LoadConfig();
                            }
                            catch (Exception)
                            {

                                return null;
                            }
                            
                        }
                    }
                }

                return _ConfigsEntity;
            }
        }
        public ConfigsControl(string CtrID)
        {
            if (BaseInstance == null)
            {
                string sPath = GetBaseConfigsPath(CtrID);
                if(!FObject.IsExist(sPath,FsoMethod.File))
                {
                    FObject.WriteFileUtf8(sPath, "");
                }
                BaseInstance = new ConfigsManager<Entity.NewsContent>(sPath);
                
            }
                

        }
        public  void SaveConfig()
        {
            BaseInstance.Save(Instance);
        }
        public void SaveConfig(Entity.NewsContent it)
        {
            BaseInstance.Save(it);
        }
        
        private  string GetBaseConfigsPath(string CtrID)
        {
            string filename = null;
            if (!Equals(HttpContext.Current, null))
            {
                filename = HttpContext.Current.Server.MapPath(string.Concat("~/Widgets/LocoySpider/Data/", CtrID, "/NewsContent.config"));
            }
            else
            {
                filename = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, string.Concat("\\Widgets\\LocoySpider\\Data\\", CtrID, "\\NewsContent.config"));
            }

            return filename;
        }
    }
}
