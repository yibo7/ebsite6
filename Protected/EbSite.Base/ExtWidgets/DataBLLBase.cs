using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Web;
using System.Xml;
using EbSite.Core.DataStore;
using EbSite.Entity;

namespace EbSite.Base.ExtWidgets
{
    public abstract class DataBLLBase
    {

        private int _SiteID = 0;
        /// <summary>
        /// 站点ID，一般情况下不用理会，只有在部件需要跨站点调用时才使用，指定一个SiteID,将会到指定站点下寻找部件配置文本
        /// </summary>
        public int SiteID
        {
            get
            {
                return _SiteID;
            }
            set
            {
                _SiteID = value;
            }
        }
        /// <summary>
        /// 扩展类别，在底层用来做相关处理，如xml的保存目录
        /// </summary>
        public abstract ExtensionType ExtensionTp { get; }
        /// <summary>
        /// 给出一个默认的 用来保存数据列表的文件名称,不带后缀
        /// </summary>
        abstract public string DefualtZoneName { get; }
        /// <summary>
        /// 显示控件的名称
        /// </summary>
        abstract public string AscxName_Show { get; }
        /// <summary>
        /// 编辑控件的名称
        /// </summary>
        abstract public string AscxName_Edit { get; }
        /// <summary>
        /// 控件的存放目录
        /// </summary>
        abstract public string AscxFilePath { get; }

        /// <summary>
        /// 控件的存放文件夹
        /// </summary>
        abstract public string FilePath { get; }

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="id"></param>
        public  void Delete(string id)
        {
            XmlDocument doc = GetXmlDocument(DefualtZoneName);
            XmlNode node = doc.SelectSingleNode("//widget[@id=\"" + id + "\"]");
            if (node != null)
            {
                // remove widget reference in the widget zone
                node.ParentNode.RemoveChild(node);
                SaveXmlDocument(doc, DefualtZoneName);

                //删除widget扩展存储文件 remove widget itself
                Core.DataStore.Providers.XmlProviders.RemoveFromDataStore(ExtensionTp, id,SiteID);
                HttpContext.Current.Cache.Remove("eb_widget_" + id);
                EditBase.OnSaved();
                 //WidgetEditBase.OnSaved();
            }
        }

        #region 获取文件Url

        /// <summary>
        /// 获取一个部件的物理路径-这里默认获取的是主系统的
        /// </summary>
        /// <param name="stype">部件控件类型</param>
        /// <returns></returns>
        public string GetPath_Show(string stype)
        {
            return string.Concat(GetPath(stype, string.Concat(AscxFilePath, "/")), AscxName_Show);
            //return string.Concat(GetPath(stype, string.Concat(EbSite.Base.AppStartInit.IISPath, AscxFilePath, "/")), AscxName_Show);
        }

        /// <summary>
        /// 获取一个部件的物理路径
        /// </summary>
        /// <param name="stype">部件控件类型</param>
        /// <param name="gModuleID">模块ID</param>
        /// <returns></returns>
        public string GetPath_Show(string stype, Guid gModuleID)
        {
            //EbSite.BLL.ModulesBll.Modules modle = new EbSite.BLL.ModulesBll.Modules(SiteID);
            ModuleInfo md = EbSite.BLL.ModulesBll.Modules.Instance.GetEntity(gModuleID);
            return string.Concat(GetPath(stype, string.Concat(md.SetupPath, FilePath,"/")), AscxName_Show);
        }

        /// <summary>
        /// 获取一个部件的物理路径-这里默认获取的是主系统的
        /// </summary>
        /// <param name="stype">部件控件类型</param>
        /// <returns></returns>
        public string GetPath_Edit(string stype)
        {
            return string.Concat(GetPath(stype,  AscxFilePath + "/"), AscxName_Edit);
        }
        /// <summary>
        /// 获取一个部件的物理路径
        /// </summary>
        /// <param name="stype">部件控件类型</param>
        /// <param name="gModuleID">模块ID</param>
        /// <returns></returns>
        public string GetPath_Edit(string stype, Guid gModuleID)
        {
            ModuleInfo md = EbSite.BLL.ModulesBll.Modules.Instance.GetEntity(gModuleID);

            //return string.Concat(GetPath(stype, md.SetupPath + AscxFilePath+"/"), AscxName_Edit);
            return string.Concat(GetPath(stype, string.Concat(md.SetupPath, FilePath, "/")), AscxName_Edit);
        }

        /// <summary>
        /// 获取相对路径
        /// </summary>
        /// <param name="stype"></param>
        /// <param name="sPathUrl"></param>
        /// <returns></returns>
        protected string GetPath(string stype, string sPathUrl)
        {

            string sPath = "";
            if (!string.IsNullOrEmpty(stype))
            {
                sPath = string.Concat(sPathUrl , stype , "/");
            }
            return sPath;

        }
        #endregion

        #region 获取部件数据
        //public abstract List<Entity.WidgetShow> GetList(string _ZoneName);
        public List<WidgetShow> GetListByType(string _TypeName) //GetWidgetByType
        {
            List<WidgetShow> lst = GetList(DefualtZoneName);
            List<WidgetShow> lstNew = new List<WidgetShow>();
            foreach (WidgetShow lstEntity in lst)
            {
                if (Equals(lstEntity.TypeWidget, _TypeName))
                {
                    lstNew.Add(lstEntity);
                }
            }

            return lstNew;

        }

        public EbSite.Entity.WidgetShow GetEntityByID(Guid ID) //GetWidgetByID
        {
            
            return GetEntityByID(ID, DefualtZoneName);
        }

        public EbSite.Entity.WidgetShow GetEntityByID(Guid ID, string _ZoneName) //GetWidgetByID
        {
            List<EbSite.Entity.WidgetShow> lst = GetList(_ZoneName);
            EbSite.Entity.WidgetShow model = null;
            foreach (WidgetShow widget in lst)
            {
                if (widget.DataID == ID)
                {
                    model = widget;
                    break;
                }
            }
            return model; 
        }
        public List<EbSite.Entity.WidgetShow> GetListForUser()
        {
            List<string> lstIDs = new List<string>();
            lstIDs.Add("8693da83-38f3-4fc0-9eea-714de639227c");
            lstIDs.Add("af2d45eb-0e3a-4deb-bbe2-4a97c5b54dee");

            lstIDs.Add("6d84d961-8fba-4bcc-82fe-f0f9043f8fc5");
            lstIDs.Add("e0e3acd0-a7ba-426e-9baa-3223b763cf84");
            lstIDs.Add("d8705cdc-3501-43b3-9cc4-8ba9608d315b");
            lstIDs.Add("78740116-ad37-412a-bed3-988fea974d0a");
            lstIDs.Add("9552eabc-b186-432f-8384-f8266d986eef");
            lstIDs.Add("1cc0fd08-8ffa-4eb6-902e-811f2253af83");
            lstIDs.Add("bdec2947-cc6b-4e9a-abf2-56cb7d77387e");
            lstIDs.Add("e878b3c7-6edc-466a-95da-61cb910cec68");
            lstIDs.Add("f0703d50-830c-48c1-b546-0d6909ad4dc1");
            lstIDs.Add("327f0ac7-c9bf-49aa-a7da-8a58c6b2d56a");
            lstIDs.Add("6b5a08c3-09f4-4f03-be4d-126c2a45f422");
            lstIDs.Add("b7a8434a-00d5-4851-a19c-58838f13b4e3");
            lstIDs.Add("984bf82e-c06d-4f7f-9c45-7d78c336ebf6");
            lstIDs.Add("6a2e4d61-0152-452a-97fc-d214bd759087");
            lstIDs.Add("8429e021-525d-401f-b39c-e9a37cb9260c");
            lstIDs.Add("5c125a7b-d5f1-4c7a-aecd-03955c982529");
            lstIDs.Add("71579f18-a40c-42fb-aa8c-73ee820ad3f3");
            lstIDs.Add("050d33d0-4d7b-43c0-b625-d5beea701b4f");
            lstIDs.Add("009c1902-703f-4f2e-9f89-1d3c4c11be8c");
            lstIDs.Add("9f7e612e-a6fd-40c2-bb59-02f990fb05b1");
            lstIDs.Add("f98e51b1-6bbd-453e-9551-379157afee7a");
            lstIDs.Add("fccd3217-55dd-4ab8-acad-04f59d7953c2");
            lstIDs.Add("57fbc60a-0fe3-4934-a97e-1d48ae9f8321");
            lstIDs.Add("df00ebc7-4295-4eda-8a40-58d1c393f11d");

            List<EbSite.Entity.WidgetShow> lst = new List<WidgetShow>();
            XmlDocument XML_DOCUMENT = RetrieveXml(DefualtZoneName);
            lst = _GetList(XML_DOCUMENT, lstIDs);
            return lst;
        }
        public List<EbSite.Entity.WidgetShow> GetList()
        {
            return GetList(DefualtZoneName);
        }

        public List<EbSite.Entity.WidgetShow> GetList(string _ZoneName)
        {

            List<EbSite.Entity.WidgetShow> lst = new List<WidgetShow>();
            XmlDocument XML_DOCUMENT = RetrieveXml(_ZoneName);
            lst = _GetList(XML_DOCUMENT,null);
            return lst;
            
            #region 加载当前皮肤下的部件数据
            //XmlDocument XML_DOCUMENT2 = RetrieveXmlForCurrentTheme(_ZoneName);
            //List<EbSite.Entity.WidgetShow> lst = _GetList(XML_DOCUMENT2);
            //#endregion
            //#region 加载系统自带部件数据列表
            //List<EbSite.Entity.WidgetShow> lst2 = new List<WidgetShow>();
            //    XmlDocument XML_DOCUMENT = RetrieveXml(_ZoneName);
            //    lst2 = _GetList(XML_DOCUMENT);
                //XmlNodeList zone = XML_DOCUMENT.SelectNodes("//widget");
                //if (zone != null)
                //{
                //    for (int i = (zone.Count - 1); i >= 0; i--) //反向排序
                //    {
                //        EbSite.Entity.WidgetShow mdWidget = new WidgetShow();
                //        XmlNode widget = zone[i];
                //        mdWidget.DataID = new Guid(widget.Attributes["id"].InnerText);
                //        mdWidget.Title = widget.Attributes["title"].InnerText;
                //        //mdWidget.ShowTitle = false;//目前没用到
                //        //mdWidget.Demo = widget.Attributes["demo"].InnerText;
                //        mdWidget.TypeWidget = widget.InnerText;
                //        XmlNode xnModulID = widget.Attributes["modulid"];
                //        if (xnModulID != null)
                //            mdWidget.ModulID = new Guid(xnModulID.InnerText);
                //        if (!Equals(widget.Attributes["IsNoSysTem"], null))
                //        {
                //            mdWidget.IsNoSysTem = bool.Parse(widget.Attributes["IsNoSysTem"].InnerText);
                //        }
                //        lst.Add(mdWidget);
                //    }
                //}
            #endregion
          
                //lst.AddRange(lst2);
                //return lst;
        }
        private List<EbSite.Entity.WidgetShow> _GetList(XmlDocument XML_DOCUMENT,List<string> NoInIDs)
        {
            List<EbSite.Entity.WidgetShow> lst = new List<WidgetShow>();
            XmlNodeList zone = XML_DOCUMENT.SelectNodes("//widget");
            if (zone != null)
            {
                for (int i = (zone.Count - 1); i >= 0; i--) //反向排序
                {
                    
                    EbSite.Entity.WidgetShow mdWidget = new WidgetShow();
                    XmlNode widget = zone[i];
                    bool isok = true;
                    if (NoInIDs!=null)
                    {
                        if (NoInIDs.Contains(widget.Attributes["id"].InnerText))
                        {
                            isok = false;
                        }
                        
                    }
                    if (isok)
                    {
                        mdWidget.DataID = new Guid(widget.Attributes["id"].InnerText);
                        mdWidget.Title = widget.Attributes["title"].InnerText;
                        //mdWidget.ShowTitle = false;//目前没用到
                        //mdWidget.Demo = widget.Attributes["demo"].InnerText;
                        mdWidget.TypeWidget = widget.InnerText;
                        XmlNode xnModulID = widget.Attributes["modulid"];
                        if (xnModulID != null)
                            mdWidget.ModulID = new Guid(xnModulID.InnerText);

                        if (!Equals(widget.Attributes["IsNoSysTem"], null))
                        {
                            mdWidget.IsNoSysTem = bool.Parse(widget.Attributes["IsNoSysTem"].InnerText);
                        }
                        if (!Equals(widget.Attributes["ThemePath"], null))
                        {
                            //mdWidget.ThemePath = widget.Attributes["ThemePath"].InnerText;
                        }
                        //if (!Equals(widget.Attributes["cachekey"], null))
                        //{
                        //    mdWidget.CacheKey = widget.Attributes["cachekey"].InnerText;
                        //}
                        
                        lst.Add(mdWidget);
                    }
                    
                }
            }
            return lst;
        }

        #endregion


        #region 自定义 获取部件类型列表

        /// <summary>
        /// 获取所有部件模型列表-不包括模块部件
        /// </summary>
        /// <returns></returns>
        public List<WidGetEntity> GetTemList()
        {
            return GetTemList(AscxFilePath);
            //return GetTemList(EbSite.Base.AppStartInit.IISPath + AscxFilePath);
        }
        /// <summary>
        /// 查找当前皮肤下的部件
        /// </summary>
        /// <returns></returns>
        public List<WidGetEntity> GetTemListForCurrentTheme(EbSite.Entity.Sites  Tm)
        {

            return GetTemList(Tm.GetPathWidgetsWidgetList());
        }
        /// <summary>
        /// 相对路径
        /// </summary>
        /// <param name="sPath"></param>
        /// <returns></returns>
        private List<WidGetEntity> GetTemList(string sPathUrl)
        {
            List<WidGetEntity> lst = new List<WidGetEntity>();
            DirectoryInfo di = new DirectoryInfo(HttpContext.Current.Server.MapPath(sPathUrl));
            foreach (DirectoryInfo dir in di.GetDirectories())
            {
                string sReadMePath = Path.Combine(dir.FullName, "areadme.txt");
                string sWidgetPath = Path.Combine(dir.FullName, AscxName_Show);
                if (File.Exists(sWidgetPath))
                {
                    WidGetEntity md = new WidGetEntity();

                    md.TypeName = dir.Name;
                    if (File.Exists(sReadMePath))
                        md.ReadMe = Core.FSO.FObject.ReadFile(sReadMePath);

                    lst.Add(md);
                }

            }
            return lst;
        }
        /// <summary>
        /// 获取部件类型列表-模块里的
        /// </summary>
        /// <param name="sModulID"></param>
        /// <returns></returns>
        public List<WidGetEntity> GetTemList(Guid sModulID)
        {

            ModuleInfo md =EbSite.BLL.ModulesBll.Modules.Instance.GetEntity(sModulID);
            string s = string.Concat(md.SetupPath,FilePath, "/");
            //return GetTemList(md.SetupPath + AscxFilePath);
            return GetTemList(s);
        }
        
        #endregion

        //private string _ThemePath;
        //public string ThemePath
        //{
        //    get
        //    {
        //        return _ThemePath;
        //    }
        //    set
        //    {
        //        _ThemePath = value;
        //    }
        //}
        /// <summary>
        /// 创建一个部件数据
        /// </summary>
        /// <param name="mdwidget"></param>
        public void AddData(Guid gDataID, string sType, string sTitle, Guid gModulID)
        {
            //记录当前处理的是皮肤部件
            //ThemePath = sThemePath;
            XmlDocument doc = GetXmlDocument(DefualtZoneName);

            if (gDataID != Guid.Empty)
            {
                XmlNode nodeTest = doc.SelectSingleNode("//widget[@id=\"" + gDataID + "\"]");
                if (nodeTest != null) return;
            }


            XmlNode node = doc.CreateElement("widget");
            node.InnerText = sType;

            XmlAttribute id = doc.CreateAttribute("id");
            id.InnerText = gDataID.ToString();
            node.Attributes.Append(id);

            XmlAttribute title = doc.CreateAttribute("title");
            title.InnerText = sTitle;
            node.Attributes.Append(title);

            //这个属性目录没有用到，只有在部件的时候用来是否显示标题，在可视化时可能用到
            //XmlAttribute show = doc.CreateAttribute("showTitle");
            //show.InnerText = "True";
            //node.Attributes.Append(show);
            //这个属性目前不有用到
            //XmlAttribute Demo = doc.CreateAttribute("demo");
            //Demo.InnerText = "";// mdwidget.;
            //node.Attributes.Append(Demo);

            XmlAttribute ModulID = doc.CreateAttribute("modulid");
            ModulID.InnerText = gModulID.ToString();
            node.Attributes.Append(ModulID);

            //XmlAttribute xabCacheKey = doc.CreateAttribute("cachekey");
            //xabCacheKey.InnerText = CacheKey;
            //node.Attributes.Append(xabCacheKey);
            
            
            //XmlAttribute xaThemePath = doc.CreateAttribute("ThemePath");

            //xaThemePath.InnerText = ThemePath;
            //node.Attributes.Append(xaThemePath);

            doc.SelectSingleNode("widgets").AppendChild(node);
            SaveXmlDocument(doc, DefualtZoneName);

            #region old


            //XmlDocument doc = GetXmlDocument(DefualtZoneName);

            //if (mdwidget.DataID != Guid.Empty)
            //{
            //    XmlNode nodeTest = doc.SelectSingleNode("//widget[@id=\"" + mdwidget.ID + "\"]");
            //    if (nodeTest != null) return;
            //}


            //XmlNode node = doc.CreateElement("widget");
            //node.InnerText = mdwidget.Name;

            //XmlAttribute id = doc.CreateAttribute("id");
            //id.InnerText = mdwidget.DataID.ToString();
            //node.Attributes.Append(id);

            //XmlAttribute title = doc.CreateAttribute("title");
            //title.InnerText = mdwidget.Title;
            //node.Attributes.Append(title);

            ////这个属性目录没有用到，只有在部件的时候用来是否显示标题，在可视化时可能用到
            //XmlAttribute show = doc.CreateAttribute("showTitle");
            //show.InnerText = "True";
            //node.Attributes.Append(show);
            ////这个属性目前不有用到
            //XmlAttribute Demo = doc.CreateAttribute("demo");
            //Demo.InnerText = "";// mdwidget.;
            //node.Attributes.Append(Demo);

            //XmlAttribute ModulID = doc.CreateAttribute("modulid");
            //ModulID.InnerText = mdwidget.ModulID.ToString();
            //node.Attributes.Append(ModulID);


            //doc.SelectSingleNode("widgets").AppendChild(node);
            //SaveXmlDocument(doc, DefualtZoneName);

            #endregion

        }
        
        #region xml处理
        public void SaveXmlDocument(XmlDocument doc)
        {
            SaveXmlDocument(doc, DefualtZoneName);
        }

        /// <summary>
        /// Saves the XML document.
        /// </summary>
        /// <param name="doc">The doc.</param>
        /// <param name="zone">The zone to save the Xml Document for.</param>
        public void SaveXmlDocument(XmlDocument doc, string zone)
        {
            WidgetSettings ws = new WidgetSettings(zone,SiteID);
            ws.ExType = ExtensionTp;
            ws.SettingsBehavior = new XMLDocumentBehavior(SiteID);
            ws.SaveSettings(doc);
            HttpContext.Current.Cache[zone] = doc;

        }
        public XmlDocument GetXmlDocument()
        {
            return GetXmlDocument(DefualtZoneName);
        }
        

        /// <summary>
        /// Gets the XML document.
        /// </summary>
        /// <param name="zone">The zone Xml Document to get.</param>
        /// <returns></returns>
        public XmlDocument GetXmlDocument(string ZoneName)
        {
            XmlDocument doc;
            if (HttpContext.Current.Cache[ZoneName] == null)
            {
                WidgetSettings ws = new WidgetSettings(ZoneName, SiteID);
                ws.ExType = ExtensionTp;

                ws.SettingsBehavior = new XMLDocumentBehavior(SiteID);

                doc = (XmlDocument)ws.GetSettings();
                if (doc.SelectSingleNode("widgets") == null)
                {
                    XmlNode widgets = doc.CreateElement("widgets");
                    doc.AppendChild(widgets);
                }
                HttpContext.Current.Cache[ZoneName] = doc;
            }
            return (XmlDocument)HttpContext.Current.Cache[ZoneName];

            //XmlDocument doc;
            //if (HttpContext.Current.Cache[zone] == null)
            //{
            //    WidgetSettings ws = new WidgetSettings(zone);
            //    ws.SettingsBehavior = new XMLDocumentBehavior();
            //    doc = (XmlDocument)ws.GetSettings();
            //    if (doc.SelectSingleNode("widgets") == null)
            //    {
            //        XmlNode widgets = doc.CreateElement("widgets");
            //        doc.AppendChild(widgets);
            //    }
            //    HttpContext.Current.Cache[zone] = doc;
            //}
            //return (XmlDocument)HttpContext.Current.Cache[zone];
        }
        ///// <summary>
        ///// 自动判断获取
        ///// </summary>
        ///// <param name="_ZoneName"></param>
        ///// <returns></returns>
        //public XmlDocument RetrieveXmlAuto(string _ZoneName)
        //{
        //    if (string.IsNullOrEmpty(ThemePath))
        //        return RetrieveXml(_ZoneName);
        //    else
        //    {
        //       return RetrieveXmlForCurrentTheme(_ZoneName);
        //    }
        //}

        /// <summary>
        /// 获取系统自带的部件集合
        /// </summary>
        /// <param name="_ZoneName"></param>
        /// <returns></returns>
        public XmlDocument RetrieveXml(string _ZoneName)
        {
            WidgetSettings ws = new WidgetSettings(_ZoneName, SiteID);
            ws.ExType = ExtensionTp;
            ws.SettingsBehavior = new XMLDocumentBehavior(SiteID);
            XmlDocument doc = (XmlDocument)ws.GetSettings();
            return doc;
        }
        ///// <summary>
        ///// 获取当前皮肤下的数据
        ///// </summary>
        ///// <param name="_ZoneName"></param>
        ///// <returns></returns>
        //public XmlDocument RetrieveXmlForCurrentTheme(string _ZoneName)
        //{
        //    WidgetSettings ws = new WidgetSettings(_ZoneName);
        //    ws.ExType = ExtensionType.CurrentTheme;
        //    ws.SettingsBehavior = new XMLDocumentBehavior();
        //    XmlDocument doc = (XmlDocument)ws.GetSettings();
        //    return doc;
        //}
        #endregion
        

    }
}
