using System;
using System.Web;
using System.Web.Hosting;
using System.Reflection;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Web.UI.WebControls;
using System.Xml.Serialization;
using EbSite.Control;
using EbSite.Core;

namespace EbSite.Base.Extension.Manager
{

    /// <summary>
    /// Extension Manager - top level object in the hierarchy
    /// Holds collection of extensions and methods to manipulate
    /// extensions
    /// </summary>
    [XmlRoot]
    public class ExtensionManager : ManagerExtBase
    {
        public static readonly ExtensionManager Instance = new ExtensionManager();
        public override Core.DataStore.SettingsBase GetExtensionSettings(string key)
        {
            return new EbSite.Core.DataStore.ExtensionSettings(key);
        }
        public override string CacheKey
        {
            get
            {
                return "Extensions";
            }
        }

        /// <summary>
        /// If extensions not in the cache will load
        /// from the XML file. If file not exists
        /// will load from assembly using reflection
        /// </summary>
        override protected void LoadExtensions()
        {
            //如果还没有缓存插件配置文件
            if (HttpContext.Current.Cache[CacheKey] == null)
            {
                ArrayList codeAssemblies = Utils.CodeAssemblies();
                foreach (Assembly a in codeAssemblies)
                {
                    Type[] types = a.GetTypes();
                    foreach (Type type in types)
                    {
                        object[] attributes = type.GetCustomAttributes(typeof(ExtensionAttribute), false);
                        foreach (object attribute in attributes)
                        {
                            ExtensionAttribute xa = (ExtensionAttribute)attribute;
                            // try to load from storage
                            ManagedExtension x = DataStoreExtension(type.Name);
                            // if nothing, crete new extension
                            //如果为null,说明还没有生成此插件相关的配置文件,要先生成
                            if (x == null)
                            {
                                x = new ManagedExtension(type.Name, xa.Version, xa.Description, xa.Author);
                                _newExtensions.Add(type.Name);
                                //保存配置到数据库或xml
                                SaveToStorage(x);
                            }
                            else
                            {
                                // update attributes from assembly
                                x.Version = xa.Version;
                                x.Description = xa.Description;
                                x.Author = xa.Author;
                                x.Priority = xa.Priority;
                            }
                            _extensions.Add(x);
                        }
                    }
                }

                //SaveToStorage();
                SaveToCache();
            }
        }

        public void LoadAppCode()
        {
            ArrayList codeAssemblies = Utils.CodeAssemblies();
            List<SortedExtension> sortedExtensions = new List<SortedExtension>();

            foreach (Assembly a in codeAssemblies)
            {
                Type[] types = a.GetTypes();
                foreach (Type type in types)
                {
                    object[] attributes = type.GetCustomAttributes(typeof(ExtensionAttribute), false);
                    foreach (object attribute in attributes)
                    {
                        if (attribute.GetType().Name == "ExtensionAttribute")
                        {
                            ExtensionAttribute ext = (ExtensionAttribute)attribute;
                            sortedExtensions.Add(new SortedExtension(ext.Priority, type.Name, type.FullName));
                        }
                    }
                }

                sortedExtensions.Sort(delegate(SortedExtension e1, SortedExtension e2)
                {
                    if (e1.Priority == e2.Priority)
                        return string.CompareOrdinal(e1.Name, e2.Name);
                    return e1.Priority.CompareTo(e2.Priority);
                });

                foreach (SortedExtension x in sortedExtensions)
                {
                    if (ExtensionEnabled(x.Name))//检查是否开启，或是否存在，不存在生成一个xml文件
                    {
                        //通过反射动态生成一个类实例
                        a.CreateInstance(x.Type);
                    }
                }
            }
        }



        //#region old

        //#region Constructor
        ///// <summary>
        ///// Default constructor, requred for serialization to work
        ///// </summary>
        //public ExtensionManager() { }
        //#endregion

        //#region Private members
        ////private static string _fileName = HostingEnvironment.MapPath(BlogSettings.Instance.StorageLocation + "extensions.xml");
        //private static List<ManagedExtension> _extensions = new List<ManagedExtension>();
        ////private static BlogProviderSection _section = (BlogProviderSection)ConfigurationManager.GetSection("BlogEngine/blogProvider");
        //private static StringCollection _newExtensions = new StringCollection();
        //#endregion

        //#region Public members
        ///// <summary>
        ///// Used to hold exeption thrown when extension can not be serialized because of
        ///// file access permission. Not serializable, used by UI to show error message.
        ///// </summary>
        //[XmlIgnore]
        //public static Exception FileAccessException = null;
        ///// <summary>
        ///// Collection of extensions
        ///// </summary>
        //[XmlElement]
        //public static List<ManagedExtension> Extensions { get { return _extensions; } }
        ///// <summary>
        ///// 检测某个插件的设置是启用还是关闭
        ///// </summary>
        ///// <param name="extensionName"></param>
        ///// <returns>如果启用就返回 True</returns>
        //public static bool ExtensionEnabled(string extensionName)
        //{
        //    bool val = true;
        //    LoadExtensions();//读取插件配置文件
        //    _extensions.Sort(delegate(ManagedExtension p1, ManagedExtension p2) { return String.Compare(p1.Name, p2.Name); });

        //    foreach (ManagedExtension x in _extensions)
        //    {
        //        if (x.Name == extensionName)
        //        {
        //            if (x.Enabled == false)
        //            {
        //                val = false;
        //            }
        //            break;
        //        }
        //    }
        //    return val;
        //}
        ///// <summary>
        ///// Only change status on first load;
        ///// This allows to enable/disable extension on
        ///// initial load and then be able to override it with
        ///// change status from admin interface
        ///// </summary>
        ///// <param name="extension">Extension Name</param>
        ///// <param name="enabled">Enable/disable extension on initial load</param>
        //public static void SetStatus(string extension, bool enabled)
        //{
        //    if (IsNewExtension(extension))
        //    {
        //        ChangeStatus(extension, enabled);
        //    }
        //}
        ///// <summary>
        ///// Method to change extension status
        ///// </summary>
        ///// <param name="extension">Extensio Name</param>
        ///// <param name="enabled">If true, enables extension</param>
        //public static void ChangeStatus(string extension, bool enabled)
        //{
        //    foreach (ManagedExtension x in _extensions)
        //    {
        //        if (x.Name == extension)
        //        {
        //            x.Enabled = enabled;
        //            Core.DataStore.ExtensionSettings xs = new Core.DataStore.ExtensionSettings(x.Name);
        //            xs.SaveSettings(x);
        //            SaveToCache();
        //            //修改web.configs的办法让应用程序重新启动
        //            //string ConfigPath = HttpContext.Current.Request.PhysicalApplicationPath + "web.config";
        //            //File.SetLastWriteTimeUtc(ConfigPath, DateTime.UtcNow);
        //            break;
        //        }
        //    }
        //}
        ///// <summary>
        ///// A way to let extension author to use custom
        ///// admin page. Will show up as link on extensions page
        ///// </summary>
        ///// <param name="extension">Extension Name</param>
        ///// <param name="url">Path to custom admin page</param>
        //public static void SetAdminPage(string extension, string url)
        //{
        //    foreach (ManagedExtension x in _extensions)
        //    {
        //        if (x.Name == extension)
        //        {
        //            x.AdminPage = url;
        //            SaveToStorage();
        //            SaveToCache();
        //            break;
        //        }
        //    }
        //}
        ///// <summary>
        ///// Tell if manager already has this extension
        ///// </summary>
        ///// <param name="type">Extension Type</param>
        ///// <returns>True if already has</returns>
        //public static bool Contains(Type type)
        //{
        //    foreach (ManagedExtension extension in _extensions)
        //    {
        //        if (extension.Name == type.Name)
        //            return true;
        //    }

        //    return false;
        //}
        ///// <summary>
        ///// Show of hide settings in the admin/extensions list
        ///// </summary>
        ///// <param name="extensionName">Extension name</param>
        ///// <param name="flag">True of false</param>
        //public static void ShowSettings(string extensionName, bool flag)
        //{
        //    foreach (ManagedExtension extension in _extensions)
        //    {
        //        if (extension.Name == extensionName)
        //        {
        //            extension.ShowSettings = flag;
        //            Save();
        //            break;
        //        }
        //    }
        //}
        //#endregion

        //#region Private methods
        ///// <summary>
        ///// If extensions not in the cache will load
        ///// from the XML file. If file not exists
        ///// will load from assembly using reflection
        ///// </summary>
        //static void LoadExtensions()
        //{
        //    //如果还没有缓存插件配置文件
        //    if (HttpContext.Current.Cache["Extensions"] == null)
        //    {
        //        ArrayList codeAssemblies = Utils.CodeAssemblies();
        //        foreach (Assembly a in codeAssemblies)
        //        {
        //            Type[] types = a.GetTypes();
        //            foreach (Type type in types)
        //            {
        //                object[] attributes = type.GetCustomAttributes(typeof(ExtensionAttribute), false);
        //                foreach (object attribute in attributes)
        //                {
        //                    ExtensionAttribute xa = (ExtensionAttribute)attribute;
        //                    // try to load from storage
        //                    ManagedExtension x = DataStoreExtension(type.Name);
        //                    // if nothing, crete new extension
        //                    //如果为null,说明还没有生成此插件相关的配置文件,要先生成
        //                    if (x == null)
        //                    {
        //                        x = new ManagedExtension(type.Name, xa.Version, xa.Description, xa.Author);
        //                        _newExtensions.Add(type.Name);
        //                        //保存配置到数据库或xml
        //                        SaveToStorage(x);
        //                    }
        //                    else
        //                    {
        //                        // update attributes from assembly
        //                        x.Version = xa.Version;
        //                        x.Description = xa.Description;
        //                        x.Author = xa.Author;
        //                        x.Priority = xa.Priority;
        //                    }
        //                    _extensions.Add(x);
        //                }
        //            }
        //        }

        //        //SaveToStorage();
        //        SaveToCache();
        //    }
        //}
        ///// <summary>
        ///// 从指定插件名称获取一个插件对象
        ///// </summary>
        ///// <param name="name">Extension name</param>
        ///// <returns>Extension</returns>
        //static ManagedExtension DataStoreExtension(string name)
        //{
        //    ManagedExtension ex = null;
        //    EbSite.Core.DataStore.ExtensionSettings xs = new EbSite.Core.DataStore.ExtensionSettings(name);
        //    XmlSerializer serializer = new XmlSerializer(typeof(ManagedExtension));
        //    object o = xs.GetSettings();

        //    if (o != null)
        //    {
        //        if (o.GetType().Name == "FileStream")
        //        {
        //            Stream stm = (FileStream)o;
        //            ex = (ManagedExtension)serializer.Deserialize(stm);
        //            stm.Close();
        //        }
        //        else
        //        {
        //            if (!string.IsNullOrEmpty((string)o))
        //            {
        //                using (StringReader reader = new StringReader(o.ToString()))
        //                {
        //                    ex = (ManagedExtension)serializer.Deserialize(reader);
        //                }
        //            }
        //        }
        //    }
        //    return ex;
        //}
        //#endregion

        //#region Settings
        ///// <summary>
        ///// Method to get settings collection
        ///// </summary>
        ///// <param name="extensionName">Extension Name</param>
        ///// <returns>Collection of settings</returns>
        //public static ExtensionSettings GetSettings(string extensionName)
        //{
        //    foreach (ManagedExtension x in _extensions)
        //    {
        //        foreach (ExtensionSettings setting in x.Settings)
        //        {
        //            if (setting != null)
        //            {
        //                if (setting.Name == extensionName)
        //                {
        //                    return setting;
        //                }
        //            }
        //        }
        //    }

        //    return null;
        //}
        ///// <summary>
        ///// Returns settings for specified extension
        ///// </summary>
        ///// <param name="extensionName">Extension Name</param>
        ///// <param name="settingName">Settings Name</param>
        ///// <returns>Settings object</returns>
        //public static ExtensionSettings GetSettings(string extensionName, string settingName)
        //{
        //    foreach (ManagedExtension x in _extensions)
        //    {
        //        if (x.Name == extensionName)
        //        {
        //            foreach (ExtensionSettings setting in x.Settings)
        //            {
        //                if (setting != null)
        //                {
        //                    if (setting.Name == settingName)
        //                    {
        //                        return setting;
        //                    }
        //                }
        //            }
        //        }
        //    }
        //    return null;
        //}
        ///// <summary>
        ///// Will save settings (add to extension object, then
        ///// cache and serialize all object hierarhy to XML)
        ///// </summary>
        ///// <param name="settings">Settings object</param>
        //public static void SaveSettings(ExtensionSettings settings)
        //{
        //    SaveSettings(settings.Name, settings);
        //}
        //public static void SaveSettings(string extensionName, ExtensionSettings settings)
        //{


        //    foreach (ManagedExtension x in _extensions)
        //    {
        //        if (x.Name == extensionName)
        //        {
        //            x.SaveSettings(settings);
        //            break;
        //        }
        //    }
        //    Save();
        //}
        ///// <summary>
        ///// Do initial import here.
        ///// If already imported, let extension manager take care of settings
        ///// To reset, blogger has to delete all settings in the manager
        ///// </summary>
        //public static bool ImportSettings(ExtensionSettings settings)
        //{
        //    return ImportSettings(settings.Name, settings);
        //}
        //public static bool ImportSettings(string extensionName, ExtensionSettings settings)
        //{
        //    foreach (ManagedExtension x in _extensions)
        //    {
        //        if (x.Name == extensionName)
        //        {
        //            if (!x.Initialized(settings.Name))
        //                x.InitializeSettings(settings);
        //            break;
        //        }
        //    }
        //    //更新到缓存,但还没保存到数据库或xml
        //    SaveToCache();

        //    return true;
        //}
        ///// <summary>
        ///// Initializes settings by importing default parameters
        ///// </summary>
        ///// <param name="extensionName">Extension Name</param>
        ///// <param name="settings">Settings object</param>
        ///// <returns>Settings object</returns>
        //public static ExtensionSettings InitSettings(string extensionName, ExtensionSettings settings)
        //{
        //    ImportSettings(extensionName, settings);
        //    return GetSettings(extensionName, settings.Name);
        //}
        //#endregion

        //#region Serialization
        ///// <summary>
        ///// Will serialize and cache ext. mgr. object
        ///// </summary>
        //public static void Save()
        //{
        //    SaveToStorage();
        //    SaveToCache();
        //}
        ///// <summary>
        ///// Caches for performance. If manager cached
        ///// and not updates done, chached copy always 
        ///// returned
        ///// </summary>
        //static void SaveToCache()
        //{
        //    HttpContext.Current.Cache.Remove("Extensions");
        //    HttpContext.Current.Cache["Extensions"] = _extensions;
        //}
        ///// <summary>
        ///// Saves ext. manager object to XML file
        ///// or database table using provider model
        ///// </summary>
        ///// <returns>True if successful</returns>
        //public static bool SaveToStorage()
        //{
        //    foreach (ManagedExtension ext in _extensions)
        //    {
        //        Core.DataStore.ExtensionSettings xs = new Core.DataStore.ExtensionSettings(ext.Name);

        //        xs.SaveSettings(ext);
        //    }
        //    return true;
        //}
        ///// <summary>
        ///// 保存一个插件配置文件  Save individual extension to storage
        ///// </summary>
        ///// <param name="ext">Extension</param>
        ///// <returns>True if saved</returns>
        //public static bool SaveToStorage(ManagedExtension ext)
        //{
        //    Core.DataStore.ExtensionSettings xs = new Core.DataStore.ExtensionSettings(ext.Name);
        //    xs.SaveSettings(ext);
        //    return true;
        //}

        //#endregion

        ///// <summary>
        ///// Extension is "new" if it is loaded from assembly
        ///// but not yet saved to the disk. This state is needed
        ///// so that we can initialize extension and its settings
        ///// on the first load and then override it from admin
        ///// </summary>
        ///// <param name="name">Extension name</param>
        ///// <returns>True if new</returns>
        //private static bool IsNewExtension(string name)
        //{
        //    if (_newExtensions.Contains(name))
        //        return true;
        //    else
        //        return false;
        //}
        //public static void StarPlugin()
        //{
        //    ArrayList codeAssemblies = Utils.CodeAssemblies();
        //    List<SortedExtension> sortedExtensions = new List<SortedExtension>();

        //    foreach (Assembly a in codeAssemblies)
        //    {
        //        Type[] types = a.GetTypes();
        //        foreach (Type type in types)
        //        {
        //            object[] attributes = type.GetCustomAttributes(typeof(ExtensionAttribute), false);
        //            foreach (object attribute in attributes)
        //            {
        //                if (attribute.GetType().Name == "ExtensionAttribute")
        //                {
        //                    ExtensionAttribute ext = (ExtensionAttribute)attribute;
        //                    sortedExtensions.Add(new SortedExtension(ext.Priority, type.Name, type.FullName));
        //                }
        //            }
        //        }

        //        sortedExtensions.Sort(delegate(SortedExtension e1, SortedExtension e2)
        //        {
        //            if (e1.Priority == e2.Priority)
        //                return string.CompareOrdinal(e1.Name, e2.Name);
        //            return e1.Priority.CompareTo(e2.Priority);
        //        });

        //        foreach (SortedExtension x in sortedExtensions)
        //        {
        //            if (ExtensionManager.ExtensionEnabled(x.Name))//检查是否开启，或是否存在，不存在生成一个xml文件
        //            {
        //                //通过反射动态生成一个类实例
        //                a.CreateInstance(x.Type);
        //            }
        //        }
        //    }
        //}
        //#region 展示控件处理--cqs



        //private static void AddLabel(string txt, string cls, PlaceHolder ph)
        //{
        //    if (string.Equals(txt, "唯一ID")) return;

        //    Label lbl = new Label();
        //    lbl.Width = new Unit("100");
        //    lbl.Text = txt;
        //    if (!string.IsNullOrEmpty(cls)) lbl.CssClass = cls;
        //    ph.Controls.Add(lbl);

        //    Literal br = new Literal();
        //    br.Text = "<br />";
        //    ph.Controls.Add(br);
        //}


        //public static void AddCtrToPH(ExtensionSettings _settings, PlaceHolder ph)
        //{
        //    foreach (ExtensionParameter par in _settings.Parameters)
        //    {

        //        if (par.ParamType != ParameterType.Boolean)
        //        {
        //            AddLabel(par.Label, "", ph);
        //        }

        //        if (par.ParamType == ParameterType.Boolean)
        //        {

        //            // add checkbox
        //            EbSite.Control.CheckBox cb = new EbSite.Control.CheckBox();
        //            cb.Checked = false;
        //            cb.ID = par.Name;
        //            cb.CssClass = "mgrCheck";
        //            ph.Controls.Add(cb);
        //            AddLabel(par.Label, "mgrCheckLbl", ph);
        //        }
        //        else if (par.ParamType == ParameterType.DropDown)
        //        {
        //            // add dropdown
        //            EbSite.Control.DropDownList dd = new EbSite.Control.DropDownList();
        //            foreach (string item in par.Values)
        //            {
        //                dd.Items.Add(item);
        //            }
        //            dd.SelectedValue = par.SelectedValue;
        //            dd.ID = par.Name;
        //            dd.Width = 250;
        //            ph.Controls.Add(dd);
        //        }
        //        else if (par.ParamType == ParameterType.ListBox)
        //        {
        //            EbSite.Control.ListBox lb = new EbSite.Control.ListBox();
        //            lb.Rows = par.Values.Count;
        //            foreach (string item in par.Values)
        //            {
        //                lb.Items.Add(item);
        //            }
        //            lb.SelectedValue = par.SelectedValue;
        //            lb.ID = par.Name;
        //            lb.Width = 250;
        //            ph.Controls.Add(lb);
        //        }
        //        else if (par.ParamType == ParameterType.RadioGroup)
        //        {
        //            EbSite.Control.RadioButtonList rbl = new EbSite.Control.RadioButtonList();
        //            foreach (string item in par.Values)
        //            {
        //                rbl.Items.Add(item);
        //            }
        //            rbl.SelectedValue = par.SelectedValue;
        //            rbl.ID = par.Name;
        //            rbl.RepeatDirection = RepeatDirection.Horizontal;
        //            rbl.CssClass = "mgrRadioList";
        //            ph.Controls.Add(rbl);

        //        }
        //        else if (par.ParamType == ParameterType.StringMax)
        //        {
        //            // add textbox
        //            EbSite.Control.TextBox bx = new EbSite.Control.TextBox();
        //            bx.Text = string.Empty;
        //            bx.ID = par.Name;
        //            bx.Width = new Unit(300);
        //            bx.Height = 200;
        //            bx.TextMode = System.Web.UI.WebControls.TextBoxMode.MultiLine;
        //            bx.MaxLength = par.MaxLength;

        //            ph.Controls.Add(bx);
        //        }
        //        else if (par.ParamType == ParameterType.StringHtml)
        //        {

        //            // add textbox
        //            EbSite.Control.Editor eb = new EbSite.Control.Editor();

        //            //eb.Value = string.Empty;
        //            eb.ID = par.Name;
        //            eb.EditorTools = EditorToolsType.标准模式;
        //            eb.Size = par.MaxLength;
        //            ph.Controls.Add(eb);

        //        }
        //        else if (par.ParamType == ParameterType.Upload)
        //        {

        //            // add textbox
        //            EbSite.Control.SWFUpload eb = new EbSite.Control.SWFUpload();

        //            //eb.Value = string.Empty;
        //            eb.ID = par.Name;
        //            eb.Width = par.MaxLength;
        //            ph.Controls.Add(eb);

        //        }
        //        else
        //        {
        //            // add textbox
        //            EbSite.Control.TextBox bx = new EbSite.Control.TextBox();
        //            bx.Text = string.Empty;
        //            bx.ID = par.Name;
        //            bx.Width = new Unit(250);
        //            bx.MaxLength = par.MaxLength;
        //            if (par.Name == "ID")
        //            {
        //                bx.Visible = false;
        //                bx.Text = Guid.NewGuid().ToString();
        //            }
        //            ph.Controls.Add(bx);
        //        }

        //        Literal br2 = new Literal();
        //        br2.Text = "<br />";
        //        ph.Controls.Add(br2);
        //    }
        //}

        //public static ExtensionSettings GetSettingsFromPH(ExtensionSettings _settings, PlaceHolder ph, int iModifyRowID)
        //{
        //    foreach (System.Web.UI.Control ctl in ph.Controls)
        //    {
        //        if (ctl is IUserContrlBase)
        //        {
        //            IUserContrlBase icb = (IUserContrlBase)ctl;
        //            if (_settings.IsScalar || iModifyRowID > -1)
        //            {
        //                _settings.UpdateScalarValue(ctl.ID, icb.CtrValue);
        //            }

        //            else
        //            {
        //                _settings.AddValue(ctl.ID, icb.CtrValue);
        //            }

        //        }

        //        //两种数据更新类型，一个是文本类UpdateScalarValue，一个是选择类UpdateSelectedValue

        //        //if (ctl.GetType().Name == "TextBox")
        //        //{
        //        //    TextBox txt = (TextBox)ctl;

        //        //    if (_settings.IsScalar)
        //        //        _settings.UpdateScalarValue(txt.ID, txt.Text);
        //        //    else
        //        //        _settings.AddValue(txt.ID, txt.Text);
        //        //}
        //        //else if (ctl.GetType().Name == "CheckBox")
        //        //{
        //        //    System.Web.UI.WebControls.CheckBox cbx = (System.Web.UI.WebControls.CheckBox)ctl;
        //        //    _settings.UpdateScalarValue(cbx.ID, cbx.Checked.ToString());
        //        //}
        //        //else if (ctl.GetType().Name == "DropDownList")
        //        //{
        //        //    DropDownList dd = (DropDownList)ctl;
        //        //    _settings.UpdateSelectedValue(dd.ID, dd.SelectedValue);
        //        //}
        //        //else if (ctl.GetType().Name == "ListBox")
        //        //{
        //        //    ListBox lb = (ListBox)ctl;
        //        //    _settings.UpdateSelectedValue(lb.ID, lb.SelectedValue);
        //        //}
        //        //else if (ctl.GetType().Name == "RadioButtonList")
        //        //{
        //        //    RadioButtonList rbl = (RadioButtonList)ctl;
        //        //    _settings.UpdateSelectedValue(rbl.ID, rbl.SelectedValue);
        //        //}
        //        //else if (ctl.GetType().Name == "Editor")
        //        //{
        //        //    Editor rbl = (Editor)ctl;
        //        //    //_settings.UpdateScalarValue(rbl.ID, rbl.Value);

        //        //    if (_settings.IsScalar)
        //        //        _settings.UpdateScalarValue(rbl.ID, rbl.Text);
        //        //    else
        //        //        _settings.AddValue(rbl.ID, rbl.Text);
        //        //}


        //    }
        //    return _settings;
        //}


        ///// <summary>
        ///// 添加时验证数据是否正确
        ///// </summary>
        ///// <returns>True if valid</returns>
        //public static bool IsValidForm(ExtensionSettings _settings, PlaceHolder ph, out string ErrStr)
        //{
        //    bool rval = true;
        //    //ErrorMsg.InnerHtml = string.Empty;
        //    ErrStr = string.Empty;
        //    foreach (System.Web.UI.Control ctl in ph.Controls)
        //    {
        //        if (ctl.GetType().Name == "TextBox")
        //        {
        //            EbSite.Control.TextBox txt = (EbSite.Control.TextBox)ctl;
        //            // check if required
        //            if (_settings.IsRequiredParameter(txt.ID) && string.IsNullOrEmpty(txt.Text.Trim()))
        //            {
        //                ErrStr = "\"" + _settings.GetLabel(txt.ID) + "\" 必须填写";//by Spoony 09.02.11
        //                //ErrorMsg.Visible = true;
        //                rval = false;
        //                break;
        //            }
        //            // check data type
        //            if (!string.IsNullOrEmpty(txt.Text) && !ValidateType(txt.ID, txt.Text, _settings))
        //            {
        //                ErrStr = "\"" + _settings.GetLabel(txt.ID) + "\" 数据类型不正确,必须是 " + _settings.GetParameterType(txt.ID).ToString();//by Spoony 09.02.11
        //                //ErrorMsg.Visible = true;
        //                rval = false;
        //                break;
        //            }
        //            if (!_settings.IsScalar)
        //            {
        //                if (_settings.KeyField == (txt.ID) && _settings.IsKeyValueExists(txt.Text.Trim()))
        //                {
        //                    ErrStr = "\"" + txt.Text + "\" 已经存在";//by Spoony 09.02.11
        //                    //ErrorMsg.Visible = true;
        //                    rval = false;
        //                    break;
        //                }
        //            }
        //        }
        //    }
        //    return rval;
        //}
        ///// <summary>
        ///// 验证输入的数据类型是否正确
        ///// </summary>
        ///// <param name="parameterName"></param>
        ///// <param name="val"></param>
        ///// <param name="_settings"></param>
        ///// <returns></returns>
        //private static bool ValidateType(string parameterName, object val, ExtensionSettings _settings)
        //{
        //    bool retVal = true;
        //    try
        //    {
        //        switch (_settings.GetParameterType(parameterName))
        //        {
        //            case ParameterType.Boolean:
        //                bool.Parse(val.ToString());
        //                break;
        //            case ParameterType.Integer:
        //                int.Parse(val.ToString());
        //                break;
        //            case ParameterType.Long:
        //                long.Parse(val.ToString());
        //                break;
        //            case ParameterType.Float:
        //                float.Parse(val.ToString());
        //                break;
        //            case ParameterType.Double:
        //                double.Parse(val.ToString());
        //                break;
        //            case ParameterType.Decimal:
        //                decimal.Parse(val.ToString());
        //                break;
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        retVal = false;
        //    }
        //    return retVal;
        //}
        ///// <summary>
        ///// 绑定一行数据
        ///// </summary>
        ///// <param name="Parameters"></param>
        ///// <param name="ph"></param>
        //public static void BindScalarToPh(List<ExtensionParameter> Parameters, PlaceHolder ph, int iIndex)
        //{

        //    int iColumnIndex = 0;
        //    foreach (System.Web.UI.Control ctl in ph.Controls)
        //    {
        //        if (ctl is IUserContrlBase)
        //        {
        //            //foreach (ExtensionParameter par in Parameters)
        //            //{
        //            ExtensionParameter par = Parameters[iColumnIndex];

        //            if (par.Values != null && par.Values.Count > 0)
        //            {
        //                IUserContrlBase icb = (IUserContrlBase)ctl;
        //                icb.CtrValue = par.Values[iIndex];
        //            }

        //            #region old
        //            //if (ctl.GetType().Name == "CheckBox")
        //            //{
        //            //    System.Web.UI.WebControls.CheckBox cbx = (System.Web.UI.WebControls.CheckBox)ctl;
        //            //    if (cbx.ID.ToLower() == par.Name.ToLower())
        //            //    {
        //            //        if (par.Values != null && par.Values.Count > 0)
        //            //        {
        //            //            cbx.Checked = bool.Parse(par.Values[iIndex]);
        //            //        }
        //            //    }
        //            //}

        //            //if (ctl.GetType().Name == "TextBox")
        //            //{
        //            //    TextBox txt = (TextBox)ctl;
        //            //    if (txt.ID.ToLower() == par.Name.ToLower())
        //            //    {
        //            //        if (par.Values != null)
        //            //        {
        //            //            if (par.Values.Count == 0)
        //            //                txt.Text = string.Empty;
        //            //            else
        //            //                txt.Text = par.Values[iIndex];
        //            //        }
        //            //    }
        //            //}
        //            //if (ctl.GetType().Name == "Editor")
        //            //{
        //            //    EbSite.Control.Editor txt = (EbSite.Control.Editor)ctl;
        //            //    if (txt.ID.ToLower() == par.Name.ToLower())
        //            //    {
        //            //        if (par.Values != null)
        //            //        {
        //            //            if (par.Values.Count == 0)
        //            //                txt.Text = string.Empty;
        //            //            else
        //            //                txt.Text = par.Values[iIndex];
        //            //        }
        //            //    }
        //            //}
        //            #endregion
        //            //}

        //            iColumnIndex++;

        //        }


        //    }
        //}
        //public static void UpdateOneDataOfList(ExtensionSettings _settings, PlaceHolder phAddForm, int iModifyRowIndex, string DataID, out string err)
        //{
        //    err = string.Empty;
        //    StringCollection updateValues = new StringCollection();
        //    foreach (System.Web.UI.Control ctl in phAddForm.Controls)
        //    {
        //        if (ctl is IUserContrlBase)
        //        {
        //            IUserContrlBase icb = (IUserContrlBase)ctl;
        //            updateValues.Add(icb.CtrValue);
        //        }
        //    }

        //    int paramIndex = iModifyRowIndex;

        //    for (int i = 0; i < _settings.Parameters.Count; i++)
        //    {
        //        string parName = _settings.Parameters[i].Name;
        //        if (_settings.IsRequiredParameter(parName) && string.IsNullOrEmpty(updateValues[i]))
        //        {
        //            // throw error if required field is empty
        //            err = "\"" + _settings.GetLabel(parName) + "\" 必须填写";//by Spoony 09.02.11

        //        }
        //        else if (parName == _settings.KeyField && _settings.IsKeyValueExists(updateValues[i]))
        //        {
        //            // check if key value was changed; if not, it's ok to update
        //            if (!_settings.IsOldValue(parName, updateValues[i], paramIndex))
        //            {
        //                // trying to update key field with value that already exists
        //                err = "\"" + updateValues[i] + "\" 已经存在";//by Spoony 09.02.11

        //            }

        //        }
        //        else
        //            _settings.Parameters[i].Values[paramIndex] = updateValues[i];
        //    }

        //    ExtensionManager.SaveSettings(DataID, _settings);
        //}
        //#endregion
        //#endregion



    }
}