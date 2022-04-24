using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Web;
using EbSite.Base.Configs.ConfigsBase;
using EbSite.Core.FSO;
using EbSite.Entity;

namespace EbSite.Base.Configs.Model
{


    /// <summary>
    /// 网页模型
    /// </summary>
    public class ConfigsControl
    {
        static public List<EbSite.Entity.ModelClass> GetModelList(string Folder, int SiteID)
        {

            FileInfo[] lstFiles = Core.FSO.FObject.GetFileListByType(GetBaseConfigsPath(Folder, SiteID), "config", true);
            List<EbSite.Entity.ModelClass> lstModelClass = new List<ModelClass>();
            foreach (FileInfo fileInfo in lstFiles)
            {

                string fName = Core.Strings.GetString.GetFileNameNoEx(fileInfo.Name);

                Guid gID = new Guid(fName);
                ConfigsControl md = new ConfigsControl(gID, Folder, SiteID);
                lstModelClass.Add(md.Instance.LoadConfig());
            }

            return lstModelClass;
        }

        static public void DeleteModel(Guid mid, string Folder,int SiteID)
        {
            string sPath = GetBaseConfigsFilePath(mid, Folder, SiteID);
            if (Core.FSO.FObject.IsExist(sPath, FsoMethod.File))
            {
                FObject.Delete(sPath, FsoMethod.File);
            }
        }

        public ConfigsControl(Guid ID, string Folder, int SiteID)
        {
            if (Instance == null)
            {
                string sPath = GetBaseConfigsFilePath(ID, Folder, SiteID);
                if (!Core.FSO.FObject.IsExist(sPath, FsoMethod.File))
                {
                    FObject.WriteFile(sPath, "");
                }
                Instance = new ConfigsManager<EbSite.Entity.ModelClass>(sPath);

            }


        }

        private ConfigsManager<EbSite.Entity.ModelClass> Instance;

        private EbSite.Entity.ModelClass _ConfigsEntity;
        public EbSite.Entity.ModelClass ConfigsEntity()
        {
            if (_ConfigsEntity != null)
            {
                return _ConfigsEntity;
            }
            else
            {
                _ConfigsEntity = Instance.LoadConfig();
                return _ConfigsEntity;
            }

        }

        public void SaveConfig()
        {
            Instance.Save(ConfigsEntity());
        }
        public void SaveConfig(EbSite.Entity.ModelClass Configs)
        {
            Instance.Save(Configs);
        }

        static private string GetBaseConfigsPath(string Folder,int SiteID)
        {
            string filename;
            if (Folder != "ModelUser")
            {
                EbSite.Entity.Sites cs = Host.Instance.GetSite(SiteID);
                string s = cs.GetPathModelsSetupData(1); // /themes/exam/data/Models/SetupData/
                //s = s.Remove(0, 1); 
                //string a = AppDomain.CurrentDomain.BaseDirectory;//D:\\web\\eBSite4.0\\项目\\Project\\EbSite.Web\\
                /*filename = string.Concat(a, s, Folder);*/ //D:\\web\\eBSite4.0\\项目\\Project\\EbSite.Web\\/themes/exam/data/Models/SetupData/ModelContent
                filename = string.Concat(s, Folder);
                filename = filename.Replace("\\", "/");//规范url,在linux下出错  linux 不支持 \\这样的路径
            }
            else  //用户模型为共用模型,所以要统一放到主站下
            {
                filename = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, string.Concat("Datastore\\", Folder));
            }


            //if (!Equals(HttpContext.Current, null))
            //{
            //    filename = HttpContext.Current.Server.MapPath(string.Concat(Host.Instance.CurrentSite.GetPathModelsSetupData(), Folder));
            //}
            //else
            //{
            //    filename = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, string.Concat("Datastore\\WebModel\\", Folder));
            //}
            return filename;


        }
        static private string GetBaseConfigsFilePath(Guid mid, string Folder,int SiteID)
        {

            return string.Concat(GetBaseConfigsPath(Folder, SiteID), "/", mid, ".config");


        }

    }
}
