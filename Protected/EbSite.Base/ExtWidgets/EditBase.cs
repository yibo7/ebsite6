using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using System.Web;
using EbSite.Core.DataStore;

namespace EbSite.Base.ExtWidgets
{
    public abstract class EditBase : Base
    {
        
        
        public static event EventHandler<EventArgs> Saved;
        /// <summary>
        /// Occurs when the class is Saved
        /// </summary>
        public static void OnSaved()
        {
            if (Saved != null)
            {
                Saved(null, new EventArgs());
            }
        }
        
        /// <summary>
        /// Saves settings to data store
        /// </summary>
        /// <param name="settings">Settings</param>
        protected virtual void SaveSettings(StringDictionary settings)
        {
            if (ExtensionTp == ExtensionType.HomeWidget)
            {
                settings["BoxStyleID"] = BoxStyleSaveId.ToString();
                settings["CustomDropDownListPram"] = CustomDropDownListPramSaveValue;
                settings["CustomColor"] = CustomColorSaveValue;
                settings["CustomTextBoxPram"] = CustomTextBoxSaveValue;
            }

            string cacheId = "eb_widget_" + DataID;

            WidgetSettings ws = new WidgetSettings(DataID.ToString(), GetSiteID);
            ws.ExType = ExtensionTp;
            ws.SaveSettings(settings);

            HttpRuntime.Cache[cacheId] = settings;
        }
       
    }
}
