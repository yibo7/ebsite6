using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Web;
using EbSite.Base.CusttomTable;
using EbSite.Core.FSO;

namespace EbSite.BLL.ModelBll
{

    public class CusttomFiledsBLLClass: CusttomFiledsBLL<StringDictionary>
    {

        //public static readonly CusttomFiledsBLLClass Instance = new CusttomFiledsBLLClass();
        protected override string SaveForlder
        {
            get { return "Class"; }
        }
        public CusttomFiledsBLLClass(Guid mid, int _SiteID)
            : base(mid, _SiteID) 
        {
            ModelConfigs = ClassModel.InstanceObj(_SiteID).GeModelByID(mid);
        }
        override protected void LoadDataLayer()
        {
            //这里保存在xml文件里,如果要保存在数据库，要重写一个数据库处理的StringDictionaryBehavior
            SettingsBehavior = new StringDictionaryBehavior();
        }
        override public void Save(long did, StringDictionary data)
        {
            SettingsBehavior.SaveSettings(SavePath, did.ToString(), data);

        }
    }
}
