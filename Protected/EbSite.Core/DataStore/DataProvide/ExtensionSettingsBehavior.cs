using System;
using System.Collections.Generic;
using System.Text;
using EbSite.Core.DataStore.Providers;

namespace EbSite.Core.DataStore
{
    /// <summary>
    /// Incapsulates behavior for saving and retreaving
    /// extension settings
    /// </summary>
    public class ExtensionSettingsBehavior : ISettingsBehavior
    {
        
        /// <summary>
        /// Default constructor
        /// </summary>
        public ExtensionSettingsBehavior()
        {
           
        }

        /// <summary>
        /// Saves extension to database or file system
        /// </summary>
        /// <param name="exType">Extension Type</param>
        /// <param name="exId">Extension ID</param>
        /// <param name="settings">Extension object</param>
        /// <returns>True if saved</returns>
        public bool SaveSettings(ExtensionType exType, string exId, object settings)
        {
            try
            {
                XmlProviders.SaveToDataStore(exType, exId, settings);
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Retreaves extension object from database or file system
        /// </summary>
        /// <param name="exType">Extension Type</param>
        /// <param name="exId">Extension ID</param>
        /// <returns>Extension object as Stream</returns>
        public object GetSettings(ExtensionType exType, string exId)
        {
            return XmlProviders.LoadFromDataStore(exType, exId);
        }
    }
}
