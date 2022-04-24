using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EbSite.Base.Entity;

namespace EbSite.Entity
{
    [Serializable]
    public class Themes : XmlEntityBase<Guid>
    {
        private int _SiteID = 0;
        public int SiteID
        {
            get { return _SiteID; }
            set { _SiteID = value; }
        }
        //public bool IsUsed { get; set; }
        //public string ThemesName { get; set; }

        public string FullPath { get; set; }
        /// <summary>
        /// 皮肤目录也就是名称，如ebsite
        /// </summary>
        public string ThemePath { get; set; }
        private string _IndexUrl = "";
        public string IndexUrl
        {
            get
            {
                return string.Concat(FullPath, "pages/index.aspx");
            }
            set
            {
                _IndexUrl = value;
            }
        }
        private string _SmallImg ="";
        public string SmallImg
        {
            get
            {
                return string.Concat(FullPath, "SmallImg.jpg");
            }
            set
            {
                _SmallImg = value;
            }
        }

        private string _BigImg;
        public string BigImg
        {
            get
            {
                return string.Concat(FullPath, "BigImg.jpg");
            }
            set
            {
                _BigImg = value;
            }
        }
       
        public DateTime AddDate { get; set; }

        //#region 获取皮肤下数据相关路径

        //    public string GetPathData()
        //    {
        //        return string.Concat(FullPath, "data/");
        //    }
        //    public string GetPathCtrlData()
        //    {
        //        return string.Concat(GetPathData(), "CtrlData/");
        //    }

        //    public string GetPathDataSettingsClass()
        //    {
        //        return string.Concat(GetPathData(), "DataSettings/Class/");
        //    }
        //    public string GetPathDataSettingsContent()
        //    {
        //        return string.Concat(GetPathData(), "DataSettings/Content/");
        //    }
        //    public string GetPathDbDemoDataClass()
        //    {
        //        return string.Concat(GetPathData(), "DbDemoData/Class/");
        //    }
        //    public string GetPathDbDemoDataContent()
        //    {
        //        return string.Concat(GetPathData(), "DbDemoData/Content/");
        //    }
        //    public string GetPathModelsCusttomFiledClass()
        //    {
        //        return string.Concat(GetPathData(), "Models/CusttomFiled/Class/");
        //    }
        //    public string GetPathModelsCusttomFiledContent()
        //    {
        //        return string.Concat(GetPathData(), "Models/CusttomFiled/Content/");
        //    }
        //    public string GetPathModelsCusttomFiledUserInfo()
        //    {
        //        return string.Concat(GetPathData(), "Models/CusttomFiled/UserInfo/");
        //    }
        //    public string GetPathModelsSetupData()
        //    {
        //        return string.Concat(GetPathData(), "Models/SetupData/");
        //    }
        //    public string GetPathModulesModuleList()
        //    {
        //        return string.Concat(GetPathData(), "Models/ModuleList/");
        //    }
        //    public string GetPathPluginsDLL()
        //    {
        //        return string.Concat(GetPathData(), "Plugins/DLL/");
        //    }
        //    public string GetPathPluginsSetupData()
        //    {
        //        return string.Concat(GetPathData(), "Plugins/SetupData/");
        //    }
        //    public string GetPathTemDataIncSetupdata()
        //    {
        //        return string.Concat(GetPathData(), "TemData/incsetupdata/");
        //    }
        //    public string GetPathTemDataTemSetupData()
        //    {
        //        return string.Concat(GetPathData(), "TemData/temsetupdata/");
        //    }
        //    public string GetPathWidgetsSetupData()
        //    {
        //        return string.Concat(GetPathData(), "Widgets/SetupData/");
        //    }
        //    public string GetPathWidgetsTableData()
        //    {
        //        return string.Concat(GetPathData(), "Widgets/TableData/");
        //    }
        //    public string GetPathWidgetsWidgetBoxStyle()
        //    {
        //        return string.Concat(GetPathData(), "Widgets/WidgetBoxStyle/");
        //    }
        //    public string GetPathWidgetsWidgetList()
        //    {
        //        return string.Concat(GetPathData(), "Widgets/WidgetList/");
        //    }

        //#endregion

    }
}
