using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.IO;
using System.Text;
using System.Xml.Serialization;
using EbSite.Base.CusttomTable.Providers;

namespace EbSite.Base.CusttomTable
{
    public class StringDictionaryBehavior : ISettingsBehavior<StringDictionary>
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public StringDictionaryBehavior() { }


        public bool SaveSettings(string SavePath, string exId, StringDictionary settings)
        {
            try
            {
                StringDictionary sd = (StringDictionary)settings;
                SerializableStringDictionary ssd = new SerializableStringDictionary();

                foreach (DictionaryEntry de in sd)
                {
                    ssd.Add(de.Key.ToString(), de.Value.ToString());
                }

                XmlProviders.SaveToDataStore(SavePath, exId, ssd);
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }


        public StringDictionary GetSettings(string SavePath, string exId)
        {
            SerializableStringDictionary ssd = null;
            StringDictionary sd = new StringDictionary();
            XmlSerializer serializer = new XmlSerializer(typeof(SerializableStringDictionary));

            Stream stm = (Stream)XmlProviders.LoadFromDataStore(SavePath, exId);
            if (stm != null)
            {
                ssd = (SerializableStringDictionary)serializer.Deserialize(stm);
                stm.Close();
                sd = (StringDictionary)ssd;
            }

            return sd;
        }
    }
}
