using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Web;
using EbSite.Base.CusttomTable;
using EbSite.Base.DataProfile;
using EbSite.Base.EntityAPI;
using EbSite.Core.FSO;
using EbSite.Data.Interface;
using EbSite.Entity;

namespace EbSite.BLL.ModelBll
{

    public class CusttomFiledsBLLContent : CusttomFiledsBLL<List<DataFiled>>
    {
        //protected override string SaveForlder
        //{
        //    get { return "Content"; }
        //}
        public CusttomFiledsBLLContent(Guid mid,int _SiteID)
            : base(mid,_SiteID) 
        {
            ModelConfigs =   WebModel.InstanceObj(_SiteID).GeModelByID(mid);
           base.SavePath = ModelConfigs.TableName;
        }

        override protected  void LoadDataLayer()
        {
            //这里保存在xml文件里,如果要保存在数据库，要重写一个数据库处理的StringDictionaryBehavior
            SettingsBehavior = DbProviderCms.GetInstance().CusstomFiledContent();
        }

        private ColumFiledConfigs GetColumFiledConfigs(string FiledName)
        {
            List<ColumFiledConfigs> lst = ModelConfigs.GetUsedFileds();
            foreach(var cf in lst)
            {
                if(cf.ColumFiledName.ToLower().Equals(FiledName.ToLower()))
                {
                    return cf;
                }
            }
            //ColumFiledConfigs md = lst.Single(d => d.ColumFiledName == FiledName);

            throw new Exception(string.Format("要模型的可用字段中找不到字段名称为{0}的字段！",FiledName));

        }
        override public void Save(long did, StringDictionary data)
        {
            List<DataFiled> lst = new List<DataFiled>();

             foreach (DictionaryEntry de in data)
                {
                    lst.Add(new DataFiled(de.Key.ToString(), de.Value.ToString(), GetColumFiledConfigs(de.Key.ToString())));
                }
            SettingsBehavior.SaveSettings(SavePath, did.ToString(), lst);

        }
    }
}
