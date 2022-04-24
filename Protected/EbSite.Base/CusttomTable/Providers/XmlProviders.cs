using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Web.Hosting;
using System.Xml.Serialization;
using EbSite.Core.DataStore;

namespace EbSite.Base.CusttomTable.Providers
{
    static public class  XmlProviders
    {
        #region Data Store  
    /// <summary>
    /// 读取
    /// </summary>
    /// <param name="SavePath"></param>
    /// <param name="exId"></param>
    /// <returns></returns>
        public static object LoadFromDataStore(string SavePath, string exId)
        {
            string _fileName = string.Concat(SavePath,"\\" ,exId ,".xml");
            StreamReader reader = null;
            Stream str = null;
            try
            {
                if (!Directory.Exists(SavePath))
                    Directory.CreateDirectory(SavePath);

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

      /// <summary>
      /// 保存
      /// </summary>
      /// <param name="SavePath"></param>
      /// <param name="exId"></param>
      /// <param name="settings"></param>
        public static void SaveToDataStore(string SavePath, string exId, object settings)
        {
            string _fileName = string.Concat(SavePath, "\\", exId, ".xml");
            try
            {
                if (!Directory.Exists(SavePath))
                    Directory.CreateDirectory(SavePath);

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
       /// 删除
       /// </summary>
       /// <param name="SavePath"></param>
       /// <param name="exId"></param>
        public static void RemoveFromDataStore(string SavePath, string exId)
        {
            string _fileName = string.Concat(SavePath, "\\", exId, ".xml");
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

        #endregion
    }
}
