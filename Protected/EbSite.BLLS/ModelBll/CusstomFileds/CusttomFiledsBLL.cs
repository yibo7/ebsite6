using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using EbSite.Base.CusttomTable;
using EbSite.Core.FSO;
using EbSite.Entity;

namespace EbSite.BLL.ModelBll
{

    abstract public class CusttomFiledsBLL<ITYPE> : ICusttomFiledsBLL<ITYPE>
    {
        protected virtual string SaveForlder
        {
            get { return ""; }
        }
        private string _SavePath = string.Empty;
        protected string SavePath
        {
            get
            {
                if (string.IsNullOrEmpty(_SavePath))
                {
                    if (SaveForlder != "ModelUserFiledData")
                    {
                        return string.Concat(EbSite.Base.Host.Instance.CurrentSite.GetPathModelsCusttomFiled(1), SaveForlder, "\\", ModuleID, "\\");
                    }
                    else //用户模型为共用模型,所以要统一放到主站下
                    {
                        return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, string.Concat("Datastore\\", SaveForlder, "\\", ModuleID, "\\"));
                    }
                }
                return _SavePath;

            }
            set { _SavePath = value; }
        }

        protected Guid ModuleID = Guid.Empty;
        protected int SiteID = 0;
        protected ModelClass ModelConfigs = null;
        public CusttomFiledsBLL(Guid mid,int _SiteID)
        {
            ModuleID = mid;
            SiteID = _SiteID;
          //  ModelConfigs = ClassModel.InstanceObj(_SiteID).GeModelByID(mid);//  WebModel.InstanceObj(_SiteID).GeModelByID(mid);
            LoadDataLayer();
            
            
        }

        virtual protected void LoadDataLayer()
        {
            //这里保存在xml文件里,如果要保存在数据库，要重写一个数据库处理的StringDictionaryBehavior
            //SettingsBehavior = new StringDictionaryBehavior();
        }
        virtual public void Save(long did, StringDictionary data)
        {
            //SettingsBehavior.SaveSettings(SavePath, did.ToString(), data);

        }
         virtual public void Save(Guid did, StringDictionary data)
         {
             
         }
        ///// <summary>
        ///// 给自定义表单用
        ///// </summary>
        ///// <param name="did"></param>
        ///// <param name="data"></param>
        //public void Save(Guid did, StringDictionary data)
        //{

        //    SettingsBehavior.SaveSettings(SavePath, did.ToString(), data);
        //}
        public StringDictionary GetEntity(Guid did)
        {
            return SettingsBehavior.GetSettings(SavePath, did.ToString()) as StringDictionary;
        }
        public StringDictionary GetEntity(int did)
        {
            return SettingsBehavior.GetSettings(SavePath, did.ToString()) as StringDictionary;
        }
        public void  Delete(int did)
        {
            if(Core.FSO.FObject.IsExist(string.Concat(SavePath,did,".xml"),FsoMethod.File))
            {
                FObject.Delete(string.Concat(SavePath,did,".xml"),FsoMethod.File);
            }
        }
        public void Delete(Guid did)
        {
            if (Core.FSO.FObject.IsExist(string.Concat(SavePath, did, ".xml"), FsoMethod.File))
            {
                FObject.Delete(string.Concat(SavePath, did, ".xml"), FsoMethod.File);
            }
        }
    }
}
