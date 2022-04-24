using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using System.Web.UI;
using EbSite.Base.Static;
using EbSite.BLL.Ctrtem;
using EbSite.Core.DataStore;
namespace EbSite.Base.ExtWidgets
{
    public abstract class Base : UserControl
    {
        protected TemList TemBll
        {
            get
            {
                return TemListInstace.TemBll(GetSiteID);
            }
        }
        protected string IISPath
        {
            get
            {
               return Host.Instance.IISPath;
            }
        }
        protected int UserID
        {
            get
            {
                return Host.Instance.UserID;
            }
        }
        
        private int siteid = 0;
        /// <summary>
        /// 获取当前站点ID，要求当前页面的url有参数site,没有参数site将获取后台默认站点
        /// </summary>
        public int GetSiteID
        {
            get
            {
                if (siteid==0)
                    return Host.Instance.GetSiteID;
                return siteid;
            }
            set
            {
                siteid = value;
            }
        }
        /// <summary>
        /// 初始化数据
        /// </summary>
        public abstract void LoadData();
        public ExtensionType Extensiontype = ExtensionType.Widget;
        /// <summary>
        /// 扩展类别，在底层用来做相关处理，如xml的保存目录
        /// </summary>
        public  ExtensionType ExtensionTp
        {
            get
            {
                return Extensiontype;
            }
        }
        private Guid _ModulID = Guid.Empty;
        /// <summary>
        /// 如果是属于模块部件，这时记录模块ID，主系统的为 Guid.Empty
        /// </summary>
        public Guid ModulID
        {
            get { return _ModulID; }
            set { _ModulID = value; }
        }
        //private string _ThemePath;
        ///// <summary>
        ///// 部件所在的皮肤 如default,系统自带的部件为空
        ///// </summary>
        //public string ThemePath
        //{
        //    get { return _ThemePath; }
        //    set { _ThemePath = value; }
        //}
        private string _Title;
        /// <summary>
        /// Gets or sets the title of the widget. It is mandatory for all widgets to set the Title.
        /// </summary>
        /// <value>The title of the widget.</value>
        public string Title
        {
            get { return _Title; }
            set { _Title = value; }
        }

        private Guid _DataID;
        public Guid DataID
        {
            get { return _DataID; }
            set { _DataID = value; }
        }

        #region 部件的皮肤相关属性
        public Guid BoxStyleSaveId;
        private Guid _BoxStyleId;
        /// <summary>
        /// 边框样式ID
        /// </summary>
        public Guid BoxStyleId
        {
            get
            {
                return _BoxStyleId;
            }
            set
            {
                _BoxStyleId = value;
            }
        }
        public string CustomColorSaveValue;
        private string _CustomColor;
        /// <summary>
        /// 颜色参数值（多个 颜色选择）
        /// </summary>
        public string CustomColor
        {
            get
            {
                return _CustomColor;
            }
            set
            {
                _CustomColor = value;
            }
        }

        public string CustomDropDownListPramSaveValue;
        private string _CustomDropDownListPram;
        /// <summary>
        /// 皮肤参数值(下拉列表)
        /// </summary>
        public string CustomDropDownListPram
        {
            get
            {
                return _CustomDropDownListPram;
            }
            set
            {
                _CustomDropDownListPram = value;
            }
        }
        public string CustomTextBoxSaveValue;
        private string _CustomTextBoxPram;
        /// <summary>
        /// 自定义文件控件参数值
        /// </summary>
        public string CustomTextBoxPram
        {
            get
            {
                return _CustomTextBoxPram;
            }
            set
            {
                _CustomTextBoxPram = value;
            }
        }
        #endregion


        
        /// <summary>
        /// Get settings from data store
        /// </summary>
        /// <returns>Settings</returns>
        public StringDictionary GetSettings()
        {
            string cacheId = string.Concat("eb_widget_", GetSiteID,"-", DataID);

            

            //if (Host.CacheApp.GetCacheItem(cacheId) == null)
            //{
            //    WidgetSettings ws = new WidgetSettings(DataID.ToString(),GetSiteID);
            //    ws.ExType = ExtensionTp;
            //    Host.CacheApp.AddCacheItem(cacheId, ws.GetSettings());
            //}
            //StringDictionary SD = (StringDictionary)Host.CacheApp.GetCacheItem(cacheId);

            StringDictionary SD = Host.CacheRawApp.GetCacheItem<StringDictionary>(cacheId, "GetSettings");

            if (Equals(SD,null))
            {
                WidgetSettings ws = new WidgetSettings(DataID.ToString(), GetSiteID);
                ws.ExType = ExtensionTp;
                SD = ws.GetSettings() as StringDictionary;
                Host.CacheRawApp.AddCacheItem(cacheId, SD, 1, ETimeSpanModel.FZ, "GetSettings");
            }

            //StringDictionary SD = Host.CacheRawApp.GetCacheItem<StringDictionary>(cacheId, "GetSettings"); 

          

            if (SD["BoxStyleID"]!=null)
            {
                BoxStyleId = new Guid(SD["BoxStyleID"]);
            }
            if (SD["CustomDropDownListPram"] != null)
            {
                CustomDropDownListPram = SD["CustomDropDownListPram"];
            }
            if (SD["CustomColor"] != null)
            {
                CustomColor = SD["CustomColor"];
            }
            if (SD["CustomTextBoxPram"] != null)
            {
                CustomTextBoxPram = SD["CustomTextBoxPram"];
            }
            
            return SD;
        }
    }
}
