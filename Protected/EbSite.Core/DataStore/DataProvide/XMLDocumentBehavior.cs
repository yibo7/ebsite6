using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using EbSite.Core.DataStore.Providers;
//using EbSite.Core.WidgetsManage.Providers;

namespace EbSite.Core.DataStore
{
    public class XMLDocumentBehavior : ISettingsBehavior
    {
        //private static ProviderSection _section = (ProviderSection)ConfigurationManager.GetSection("BlogEngine/blogProvider");

        /// <summary>
        /// Default constructor
        /// </summary>
        public XMLDocumentBehavior(int SiteID)
        {
            siteid = SiteID;
        }

        private int siteid = 0;
        /// <summary>
        /// Saves XML document to data storage
        /// </summary>
        /// <param name="exType">Extension Type</param>
        /// <param name="exId">Extension ID</param>
        /// <param name="settings">Settings as XML document</param>
        /// <returns>True if saved</returns>
        public bool SaveSettings(ExtensionType exType, string exId, object settings)
        {
            try
            {
                XmlDocument xml = (XmlDocument)settings;
                XmlProviders.SaveToDataStore(exType, exId, xml, siteid);
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Gets settings from data store
        /// </summary>
        /// <param name="exType">Extension Type</param>
        /// <param name="exId">Extension ID</param>
        /// <returns>Settings as Stream</returns>
        public object GetSettings(ExtensionType exType, string exId)
        {
            WidgetData wd = new WidgetData();
            XmlDocument xml = new XmlDocument();

            Stream stm = (Stream)XmlProviders.LoadFromDataStore(exType, exId, siteid);
            if (stm != null)
            {
                XmlSerializer x = new XmlSerializer(typeof(XmlDocument));
                xml = (XmlDocument)x.Deserialize(stm);
                stm.Close();
            }

            return xml;
        }
    }
    /// <summary>
    /// Wrap around xml document
    /// </summary>
    [Serializable()]
    public class WidgetData
    {
        /// <summary>
        /// Defatul constructor
        /// </summary>
        public WidgetData() { }

        private string settings = string.Empty;
        /// <summary>
        /// Settings data
        /// </summary>
        public string Settings { get { return settings; } set { settings = value; } }
    }

}
