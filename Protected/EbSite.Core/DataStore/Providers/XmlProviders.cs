using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Web.Hosting;
using System.Xml.Serialization;
using EbSite.Core.DataStore;

namespace EbSite.Core.DataStore.Providers
{
    static public class  XmlProviders
    {
        #region Data Store  
        public static object LoadFromDataStore(ExtensionType exType, string exId)
        {
            return  LoadFromDataStore(exType, exId, 0);
        }

        /// <summary>
        /// Loads settings from data storage
        /// </summary>
        /// <param name="exType">Extension Type</param>
        /// <param name="exId">Extension ID</param>
        /// <returns>Settings as stream</returns>
        public static object LoadFromDataStore(ExtensionType exType, string exId,int SiteID)
        {
            //E:\\web\\EbSite\\Project\\EbSite.Web\\datastore\\widgets\\WidgetsZoneList.xml
            string _fileName = StorageLocation(exType, SiteID) + exId + ".xml";
            StreamReader reader = null;
            Stream str = null;
            try
            {
                if (!Directory.Exists(StorageLocation(exType, SiteID)))
                    Directory.CreateDirectory(StorageLocation(exType, SiteID));

                if (File.Exists(_fileName))
                {
                    reader = new StreamReader(_fileName);
                    str = reader.BaseStream;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return str;
        }
        public static void SaveToDataStore(ExtensionType exType, string exId, object settings)
        {
            SaveToDataStore(exType, exId, settings, 0);
        }

        /// <summary>
        /// Saves settings to data store
        /// </summary>
        /// <param name="exType">Extension Type</param>
        /// <param name="exId">Extensio ID</param>
        /// <param name="settings">Settings object</param>
        public static void SaveToDataStore(ExtensionType exType, string exId, object settings,int SiteID)
        {
            string _fileName = StorageLocation(exType, SiteID) + exId + ".xml";
            try
            {
                if (!Directory.Exists(StorageLocation(exType, SiteID)))
                    Directory.CreateDirectory(StorageLocation(exType, SiteID));

                TextWriter writer = new StreamWriter(_fileName);
                XmlSerializer x = new XmlSerializer(settings.GetType());
                x.Serialize(writer, settings);
                writer.Close();
            }
            catch (Exception e)
            {
                string s = e.Message;
                throw;
            }
        }

        /// <summary>
        /// Removes object from data store
        /// </summary>
        /// <param name="exType">Extension Type</param>
        /// <param name="exId">Extension Id</param>
        public static void RemoveFromDataStore(ExtensionType exType, string exId, int SiteID)
        {
            string _fileName = StorageLocation(exType, SiteID) + exId + ".xml";
            try
            {
                File.Delete(_fileName);
            }
            catch (Exception e)
            {
                string s = e.Message;
                throw;
            }
        }

        ///<summary>
        ///</summary>
        ///<returns></returns>
        //public static string GetStorageLocation()
        //{
        //    switch (exType)
        //    {
        //        case ExtensionType.Extension:
        //            return HostingEnvironment.MapPath(Path.Combine(BlogSettings.Instance.StorageLocation, @"datastore\extensions\"));
        //        case ExtensionType.Widget:
        //            return HostingEnvironment.MapPath(Path.Combine(BlogSettings.Instance.StorageLocation, @"datastore\widgets\"));
        //        case ExtensionType.Theme:
        //            return HostingEnvironment.MapPath(Path.Combine(BlogSettings.Instance.StorageLocation, @"datastore\themes\"));
        //    }
        //    return string.Empty;
        //}

        /// <summary>
        /// Data Store Location
        /// </summary>
        /// <param name="exType">Type of extension</param>
        /// <returns>Path to storage directory</returns>
        private static string StorageLocation(ExtensionType exType,int SiteID)
        {
            switch (exType)
            {
                case ExtensionType.Extension:
                    return HostingEnvironment.MapPath(Path.Combine(EbSite.Base.AppStartInit.IISPath, @"datastore\extensions\"));
                case ExtensionType.Widget:
                    if (SiteID==0)
                        return HostingEnvironment.MapPath(EbSite.Base.Host.Instance.CurrentSite.GetPathWidgetsSetupData());
                    return HostingEnvironment.MapPath(EbSite.Base.Host.Instance.GetSite(SiteID).GetPathWidgetsSetupData());
                  
                case ExtensionType.Ctrl:
                    if (SiteID == 0)
                        return HostingEnvironment.MapPath(EbSite.Base.Host.Instance.CurrentSite.GetPathCtrlSetupData(0));
                    return HostingEnvironment.MapPath(EbSite.Base.Host.Instance.GetSite(SiteID).GetPathCtrlSetupData(0));
                    
                case ExtensionType.HomeWidget:
                    return HostingEnvironment.MapPath(Path.Combine(EbSite.Base.AppStartInit.IISPath, string.Concat(@"home\datastore\widgets\", EbSite.Base.AppStartInit.GetHomeID, @"\")));
                case ExtensionType.PlugIn:
                    return HostingEnvironment.MapPath(Path.Combine(EbSite.Base.AppStartInit.IISPath, @"datastore\PluginInfo\"));
                
            }
            return string.Empty;
        }
        #endregion
    }
}
