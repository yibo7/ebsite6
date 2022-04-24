using System;
using System.Data;
using System.IO;
using System.Linq;
using EbSite.Core.FSO;
using Newtonsoft.Json; 

namespace EbSite.Core
{
    public class JsonFile<T> where T:new() 
    {

        public T Model;
        private string sPath = "";
        public string Id = "";//此Id应用于报表制作中
        public JsonFile(string spath)
        {
            sPath = spath;
            if (FSO.FObject.IsExist(sPath, FsoMethod.File))
            {
                string json = FSO.FObject.ReadFile(sPath);
                Model =  JsonConvert.DeserializeObject<T>(json);
                Id = Core.Utils.MD5(Path.GetFileName(sPath));
            }
            else
            {
                Model = new T();
                Id = Guid.NewGuid().ToString();
            }
        }
         

        public void Save()
        {
           string json  = JsonConvert.SerializeObject(Model);
            FSO.FObject.WriteFileUtf8(sPath, json);
        }
    }
}