using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EbSite.Base.Entity;
using EbSite.BLL.User;

namespace EbSite.Entity
{
    [Serializable]
    public class Sites : XmlEntityBase<int>
    {

        public bool IsNoSys { get; set; }
        /// <summary>
        /// 站点排序ID
        /// </summary>
        public int OrderID { get; set; }
        /// <summary>
        /// 父级站点ID
        /// </summary>
        public int ParentID { get; set; }
        /// <summary>
        /// 站点名称
        /// </summary>
        public string SiteName { get; set; }
        /// <summary>
        /// 站点文件夹，生成html时保存的目录,也可以为空，将生成到根目录
        /// </summary>
        public string SiteFolder { get; set; }
        /// <summary>
        /// 分类是否内容化
        /// </summary>
        public bool IsClassContent { get; set; }
        /// <summary>
        /// 首页采用模板ID
        /// </summary>
        public Guid IndexTemID { get; set; }

        public int LinkTypeContent { get; set; }
        public int LinkTypeClass { get; set; }
        public int LinkTypeOrther { get; set; }
        public int LinkTypeSpecial { get; set; }
        public int LinkTypeTags { get; set; }

        private string _AdminTheme = "default";
        private string _PageTheme = "default";
        private string _MobileTheme = "default";
        /// <summary>
        /// 手机版皮肤
        /// </summary>
        public string MobileTheme
        {
            get
            {
                return _MobileTheme;
            }
            set
            {
                _MobileTheme = value;
            }
        }
        /// <summary>
        /// 后台样式皮肤
        /// </summary>
        public string AdminTheme
        {
            get
            {
                return _AdminTheme;
            }
            set
            {
                _AdminTheme = value;
            }
        }
        /// <summary>
        /// 前台样式皮肤
        /// </summary>
        public string PageTheme
        {
            get
            {
                return _PageTheme;
            }
            set
            {
                _PageTheme = value;
            }
        }

        public void Update()
        {
            EbSite.BLL.Sites.Instance.Update(this);
        }

        #region 电脑版通用方法

        /// <summary>
        /// 获取站点下的某个模板页面相对路径（iispath）
        /// </summary>
        /// <param name="sPageName">Name of the s page.</param>
        /// <returns>System.String.</returns>
        public string ThemesPath(string sPageName)
        {
            return string.Concat(Base.AppStartInit.IISPath, "themes/", PageTheme, "/", sPageName).Trim();
        }
        public string ThemesPathNoIISPath(string sPageName)
        {
            return string.Concat("themes/", PageTheme, "/", sPageName);
        }
        public string GetCurrentThemesPath(int SiteID)
        {
            return ThemesPath("");
        }
        public string GetCurrentPageUrl(string sPageName)
        {
            return ThemesPath(string.Concat("pages/", sPageName));
        }
        public string GetCurrentDefualtUcMasterMobile()
        {
            return string.Concat(Base.AppStartInit.IISPath, "themesm/", MobileTheme, "/pages/uccmdcontrol.Master");
        }
        /// <summary>
        /// 获取默认的用户控件面板母板页
        /// </summary>
        /// <returns></returns>
        public string GetCurrentDefualtUcMaster()
        {
            string sTem = UserGroupProfile.ManageIndexMasterNameByUserID(EbSite.Base.AppStartInit.UserID);//"UserPagesTem.Master";

            return string.Concat(Base.AppStartInit.IISPath, "themes/", PageTheme, "/pages/", string.IsNullOrEmpty(sTem) ? "UserPagesTem.Master" : sTem);
        }
        ///// <summary>
        ///// 获取默认的用户控件面板母板页
        ///// </summary>
        ///// <returns></returns>
        //public string GetCurrentDefualtUcMasterBox()
        //{
        //    return string.Concat(Base.AppStartInit.IISPath, "themes/", PageTheme, "/pages/UserPagesTemBox.Master");
        //}

        #endregion

        #region 手机版通用方法
        public string MThemesPath(string sPageName)
        {
            return string.Concat(Base.AppStartInit.IISPath, "themesm/", MobileTheme, "/", sPageName);
        }
        public string MGetCurrentThemesPath()
        {
            return MThemesPath("");
        }
        public string MGetCurrentPageUrl(string sPageName)
        {
            return MThemesPath(string.Concat("pages/", sPageName));
        }
        #endregion


        #region 获取皮肤下数据相关路径
        //public string GetPathUpload()
        //{
        //    return ThemesPath(""); 
        //}

        /// <summary>
        /// 获取一个站点下的data相对路径.
        /// </summary>
        /// <returns>System.String.</returns>
        public string GetPathData()
        {
            return string.Concat(ThemesPath(""), "data/");
        }
        public string GetPathDataNoIISPath()
        {
            return string.Concat(ThemesPathNoIISPath(""), "data/");
        }


        public string GetPathCtrlSetupData(int it)
        {
            if (it == 0)
            {
                return string.Concat(GetPathData(), "Ctrl/SetupData/");
            }
            else
            {
                return System.IO.Path.Combine(System.Web.HttpRuntime.AppDomainAppPath, string.Concat(GetPathDataNoIISPath(), "Ctrl/SetupData/"));
            }
        }
        public string GetPathCtrlTempList(int it)
        {
            if (it == 0)
            {
                return string.Concat(GetPathData(), "Ctrl/TempList/");
            }
            else
            {
                return System.IO.Path.Combine(System.Web.HttpRuntime.AppDomainAppPath, string.Concat(GetPathDataNoIISPath(), "Ctrl/TempList/"));
            }
        }

        public string GetPathDataSettingsClass(int it)
        {
            //return string.Concat(GetPathData(), "DataSettings/Class/");

            if (it == 0)
            {
                return string.Concat(GetPathData(), "DataSettings/Class/");
            }
            else
            {
                return System.IO.Path.Combine(System.Web.HttpRuntime.AppDomainAppPath, string.Concat(GetPathDataNoIISPath(), "DataSettings/Class/"));
            }
        }
        public string GetPathDataSettingsContent(int it)
        {
            if (it == 0)
            {
                return string.Concat(GetPathData(), "DataSettings/Content/");
            }
            else
            {
                return System.IO.Path.Combine(System.Web.HttpRuntime.AppDomainAppPath, string.Concat(GetPathDataNoIISPath(), "DataSettings/Content/"));
            }
            //return string.Concat(GetPathData(), "DataSettings/Content/");
        }
        public string GetPathDbDemoDataClass()
        {
            return string.Concat(GetPathData(), "DbDemoData/Class/");
        }
        public string GetPathDbDemoDataContent()
        {
            return string.Concat(GetPathData(), "DbDemoData/Content/");
        }
        public string GetPathModelsCusttomFiledClass()
        {
            return string.Concat(GetPathData(), "Models/CusttomFiled/Class/");
        }
        public string GetPathModelsCusttomFiledContent()
        {
            return string.Concat(GetPathData(), "Models/CusttomFiled/Content/");
        }
        public string GetPathModelsCusttomFiledUserInfo()
        {
            return string.Concat(GetPathData(), "Models/CusttomFiled/UserInfo/");
        }
        public string GetPathModelsCusttomFiled(int it)
        {
            if (it == 0)
            {
                return string.Concat(GetPathData(), "Models/CusttomFiled/");
            }
            else
            {
                return System.IO.Path.Combine(System.Web.HttpRuntime.AppDomainAppPath, string.Concat(GetPathDataNoIISPath(), "Models/CusttomFiled/"));
            }
        }
        public string GetPathFastMenu(int it)
        {
            if (it == 0)
            {
                return string.Concat(GetPathData(), "FastMenu/");
            }
            else
            {
                return System.IO.Path.Combine(System.Web.HttpRuntime.AppDomainAppPath, string.Concat(GetPathDataNoIISPath(), "FastMenu/"));
            }
        }
        public string GetPathFastMenuClass(int it)
        {
            if (it == 0)
            {
                return string.Concat(GetPathData(), "FastMenuClass/");
            }
            else
            {
                return System.IO.Path.Combine(System.Web.HttpRuntime.AppDomainAppPath, string.Concat(GetPathDataNoIISPath(), "FastMenuClass/"));
            }
        }
        public string GetPathModelsCusttomFiledForm(int it)
        {
            if (it == 0)
            {
                return string.Concat(GetPathData(), "Models/CusttomFiled/Form/");
            }
            else
            {
                return System.IO.Path.Combine(System.Web.HttpRuntime.AppDomainAppPath, string.Concat(GetPathDataNoIISPath(), "Models/CusttomFiled/Form/"));
            }
        }

        /// <summary>
        /// 模块地安装路径.
        /// </summary>
        /// <param name="it">It.</param>
        /// <returns>System.String.</returns>
        public string GetPathModelsSetupData(int it)
        {
            if (it == 0)
            {
                return string.Concat(GetPathData(), "Models/SetupData/");
            }
            else
            {
                return System.IO.Path.Combine(System.Web.HttpRuntime.AppDomainAppPath, string.Concat(GetPathDataNoIISPath(), "Models/SetupData/"));
            }
            //return string.Concat(GetPathData(), "Models/SetupData/");
        }



        public string GetPathModulesModuleList(int it)
        {
            if (it == 0)
            {
                return string.Concat(GetPathData(), "Modules/ModuleList/");
            }
            else
            {
                return System.IO.Path.Combine(System.Web.HttpRuntime.AppDomainAppPath, string.Concat(GetPathDataNoIISPath(), "Modules/ModuleList/"));
            }
            //return string.Concat(GetPathData(), "Modules/ModuleList/");
        }
        public string GetPathModulesSetupData(int it)
        {
            if (it == 0)
            {
                return string.Concat(GetPathData(), "Modules/SetupData/");
            }
            else
            {
                return System.IO.Path.Combine(System.Web.HttpRuntime.AppDomainAppPath, string.Concat(GetPathDataNoIISPath(), "Modules/SetupData/"));
            }
            //return string.Concat(GetPathData(), "Modules/SetupData/");
        }
        public string GetPathPluginsDLL()
        {
            return string.Concat(GetPathData(), "Plugins/DLL/");
        }
        public string GetPathPluginsSetupData()
        {
            return string.Concat(GetPathData(), "Plugins/SetupData/");
        }
        public string GetPathTemDataIncSetupdata()
        {
            return string.Concat(GetPathData(), "TemData/incsetupdata/");
        }
        public string GetPathTemDataTemSetupData()
        {
            return string.Concat(GetPathData(), "TemData/temsetupdata/");
        }


        public string GetPathClassCustom(int it)
        {

            if (it == 0)
            {
                return string.Concat(GetPathData(), "ClassCustom/");
            }
            else
            {
                return System.IO.Path.Combine(System.Web.HttpRuntime.AppDomainAppPath, string.Concat(GetPathDataNoIISPath(), "ClassCustom/"));
            }
        }

        public string GetPathRemarkClass(int it)
        {

            if (it == 0)
            {
                return string.Concat(GetPathData(), "RemarkClass/");
            }
            else
            {
                return System.IO.Path.Combine(System.Web.HttpRuntime.AppDomainAppPath, string.Concat(GetPathDataNoIISPath(), "RemarkClass/"));
            }
        }


        public string GetPathWidgetsSetupData()
        {
            return string.Concat(GetPathData(), "Widgets/SetupData/");
        }


        public string GetPathWidgetsTableData()
        {
            return string.Concat(GetPathData(), "Widgets/TableData/");
        }
        public string GetPathWidgetsWidgetBoxStyle()
        {
            return string.Concat(GetPathData(), "Widgets/WidgetBoxStyle/");
        }
        public string GetPathWidgetsWidgetList()
        {
            return string.Concat(GetPathData(), "Widgets/WidgetList/");
        }



        public string GetPathWidgetsTemplist(int it)
        {
            if (it == 0)
            {
                return string.Concat(GetPathData(), "Widgets/Templist/");
            }
            else
            {
                return System.IO.Path.Combine(System.Web.HttpRuntime.AppDomainAppPath, string.Concat(GetPathDataNoIISPath(), "Widgets/Templist/"));
            }
        }
        public string GetPathWidgetsTempdata(int it)
        {
            if (it == 0)
            {
                return string.Concat(GetPathData(), "Widgets/Tempdata/");
            }
            else
            {
                return System.IO.Path.Combine(System.Web.HttpRuntime.AppDomainAppPath, string.Concat(GetPathDataNoIISPath(), "Widgets/Tempdata/"));
            }
        }
        /// <summary>
        /// 获取部件模板分类存放目录
        /// </summary>
        /// <param name="it">为0获取相对路径，为1获取绝对路径</param>
        /// <returns></returns>
        public string GetPathWidgetsTempClass(int it)
        {
            if (it == 0)
            {
                return string.Concat(GetPathData(), "Widgets/TempClass/");
            }
            else
            {
                return System.IO.Path.Combine(System.Web.HttpRuntime.AppDomainAppPath, string.Concat(GetPathDataNoIISPath(), "Widgets/TempClass/"));
            }

        }
        #endregion
    }
}
