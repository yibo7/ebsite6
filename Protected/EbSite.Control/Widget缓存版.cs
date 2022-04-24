//using System;
//using System.IO;
//using System.Web;
//using System.Web.UI;
//using System.Web.UI.WebControls;
//using EbSite.Base.ExtWidgets.WidgetsManage;
//using EbSite.Base.Static;
//using EbSite.Core.DataStore;
//using EbSite.Core.FSO;

//namespace EbSite.Control
//{
//    public class Widget : UserControl
//    {
//        //protected override void Render(HtmlTextWriter writer)
//        //{
//        //    string ddd = writer.InnerWriter.ToString();
//        //    writer.Write(ddd);
//        //    //base.Render(writer);
//        //}
//        public virtual ExtensionType ExtensionTp
//        {
//            get
//            {
//                return ExtensionType.Widget;
//            }
//        }
//        private Guid _BoxStyleID;
//        /// <summary>
//        /// 边框样式ID
//        /// </summary>
//        public Guid BoxStyleID
//        {
//            get
//            {
//                return _BoxStyleID;
//            }
//            set
//            {
//                _BoxStyleID = value;
//            }
//        }

//        private int _ThemeID;
//        /// <summary>
//        /// 当前空间皮肤ID(个人主页)，或当前页面所在皮肤ID(网站)
//        /// </summary>
//        public int ThemeID
//        {
//            get
//            {
//                return _ThemeID;
//            }
//            set
//            {
//                _ThemeID = value;
//            }
//        }

//        private string _CustomDropDownListPram;
//        /// <summary>
//        /// 自定义样式名称
//        /// </summary>
//        public string CustomDropDownListPram
//        {
//            get
//            {
//                return _CustomDropDownListPram;
//            }
//            set
//            {
//                _CustomDropDownListPram = value;
//            }
//        }

//        private string _CustomColors;
//        /// <summary>
//        /// 自定义颜色列表值
//        /// </summary>
//        public string CustomColors
//        {
//            get
//            {
//                return _CustomColors;
//            }
//            set
//            {
//                _CustomColors = value;
//            }
//        }
//        private string _GetTextBoxValue;
//        /// <summary>
//        /// 自定义文件框值
//        /// </summary>
//        public string GetTextBoxValue
//        {
//            get
//            {
//                return _GetTextBoxValue;
//            }
//            set
//            {
//                _GetTextBoxValue = value;
//            }
//        }

        
        
//        public string WidgetName;
//        private Guid _WidgetID;

//        public Guid WidgetID
//        {
//            get
//            {
//                return _WidgetID;
//            }
//            set
//            {
//                _WidgetID = value;
//            }
//        }

//        private int _SiteID = 0;
//        /// <summary>
//        /// 站点ID，一般情况下不用理会，只有在部件需要跨站点调用时才使用，指定一个SiteID,将会到指定站点下寻找部件配置文本
//        /// </summary>
//        public int SiteID
//        {
//            get
//            {
//                return _SiteID;
//            }
//            set
//            {
//                _SiteID = value;
//            }
//        }

//        private ETimeSpanModel _TimeSpanModel = ETimeSpanModel.天;
//        public ETimeSpanModel CacheTimeSpanModel
//        {
//            get
//            {
//                return _TimeSpanModel;
//            }
//            set
//            {
//                _TimeSpanModel = value;
//            }
//        }
//        private int _TimeSpan = 0;
//        public int CacheTimeSpan
//        {
//            get
//            {
//                return _TimeSpan;
//            }
//            set
//            {
//                _TimeSpan = value;
//            }
//        }

//        #region 共空间模块使用
//        public virtual string TitleLink
//        {
//            get { return ""; }
//        }
//        private string _Title;
//        public string Title
//        {
//            get { return _Title; }
//            set { _Title = value; }
//        }

//        private string _WidgetType;
//        public string WidgetType
//        {
//            get { return _WidgetType; }
//            set { _WidgetType = value; }
//        }
//        private bool _ShowTitle;
//        public bool ShowTitle
//        {
//            get { return _ShowTitle; }
//            set { _ShowTitle = value; }
//        }

        
//        #endregion

//        private Base.ExtWidgets.WidgetsManage.DataBLL DAL
//        {
//            get
//            {
//                if(ExtensionTp==ExtensionType.HomeWidget)
//                {
//                    return Base.ExtWidgets.HomeWidgetManage.DataBLL.Instance;
//                }
//                else
//                {
//                    if (SiteID==0)
//                    {
//                        return Base.ExtWidgets.WidgetsManage.DataBLL.Instance;
//                    }
//                    else
//                    {
//                        return new DataBLL(SiteID);
//                    }
                   
//                }
//            }
//        }
//       private string GetCachePath(string cachekey)
//        {
//            return HttpContext.Current.Server.MapPath(string.Concat(EbSite.Base.Host.Instance.IISPath, "cacheforwidget/", cachekey, ".txt"));
//        }
//       private void ToCacheHtml(string sPath, string sContent)
//        {
           
               
//                FObject.WriteFile(sPath, sContent);
//                //Core.Utils.TestDebug(control.CacheKey + writer.InnerWriter.ToString());
            
//        }
//       //private WidgetBase LoadWidgetCtr(Entity.WidgetShow mdWidget)
//       //{
//       //    string fileName = "";
//       //    if (mdWidget.ModulID == Guid.Empty)
//       //    {
//       //        fileName = DAL.GetPath_Show(mdWidget.TypeWidget);
//       //    }
//       //    else
//       //    {
//       //        fileName = DAL.GetPath_Show(mdWidget.TypeWidget, mdWidget.ModulID);
//       //    }
//       //    return (WidgetBase)Page.LoadControl(fileName);
//       //}
//        protected override void OnLoad(EventArgs e)
//        {
//            Entity.WidgetShow mdWidget = DAL.GetEntityByID(WidgetID);
//            if (!Equals(mdWidget,null))
//            {
//                WidgetBase control = null;
//                try
//                {
//                    string fileName = "";
//                    if (mdWidget.ModulID == Guid.Empty)
//                    {
//                        fileName = DAL.GetPath_Show(mdWidget.TypeWidget);
//                    }
//                    else
//                    {
//                        fileName = DAL.GetPath_Show(mdWidget.TypeWidget, mdWidget.ModulID);
//                    }
//                    control =  (WidgetBase)Page.LoadControl(fileName);
//                    //control.DataID = WidgetID;
//                }
//                catch (Exception ex)
//                {
//                    Literal lit = new Literal();
//                    lit.Text = string.Format("<p style=\"color:red\">ID为{0}:<br>{1}<p>", WidgetID, ex.Message);
//                    this.Controls.Add(lit);
//                }
//                if(!Equals(control,null))
//                {
//                    string sPath = GetCachePath(string.Concat(WidgetID,"_",control.CacheKey));
                   
//                    bool isloadctr = true;
//                    if (CacheTimeSpan > 0)
//                    {

//                        if (Core.FSO.FObject.IsExist(sPath, FsoMethod.File))
//                        {
//                            if (!EbSite.Base.Static.HtmlPool.IsHtmlOverdue(sPath, CacheTimeSpan, (int)CacheTimeSpanModel)) //判断缓存文件是否已经过期
//                            {
//                                Literal lit = new Literal();
//                                lit.Text = FObject.ReadFile(sPath);
//                                this.Controls.Add(lit);
//                                isloadctr = false;
//                            }
//                        }
//                    }

//                    if (isloadctr)
//                    {
                        
//                        control.Extensiontype = ExtensionTp;
//                        control.GetSiteID = SiteID;

//                        control.DataID = mdWidget.DataID;
//                        control.ID = control.DataID.ToString().Replace("-", string.Empty);
//                        control.Title = mdWidget.Title;

//                        if (control.IsEditable)
//                            control.ShowTitle = false;
//                        else
//                            control.ShowTitle = control.DisplayHeader;

//                        control.LoadData();

//                        if (CacheTimeSpan > 0)
//                        {
//                            StringWriter tw = new StringWriter();
//                            HtmlTextWriter writer = new HtmlTextWriter(tw);
//                            control.RenderControl(writer);
//                            ToCacheHtml(sPath, writer.InnerWriter.ToString());
//                        }

//                        this.Controls.Add(control);
                        
//                        Title = control.Title;
//                        ShowTitle = control.ShowTitle;
//                        WidgetType = mdWidget.TypeWidget;
//                        BoxStyleID = control.BoxStyleId;
//                        CustomDropDownListPram = control.CustomDropDownListPram;
//                        CustomColors = control.CustomColor;
//                        GetTextBoxValue = control.CustomTextBoxPram;

//                        #region old


//                        //string fileName = "";

//                        //if (mdWidget.ModulID == Guid.Empty)
//                        //{
//                        //    fileName = DAL.GetPath_Show(mdWidget.TypeWidget);
//                        //}
//                        //else
//                        //{
//                        //    fileName = DAL.GetPath_Show(mdWidget.TypeWidget, mdWidget.ModulID);
//                        //}

//                        //if (mdWidget != null)
//                        //{
//                        //    if (mdWidget.ModulID == Guid.Empty)
//                        //    {
//                        //        fileName = DAL.GetPath_Show(mdWidget.TypeWidget);
//                        //    }
//                        //    else
//                        //    {
//                        //        fileName = DAL.GetPath_Show(mdWidget.TypeWidget, mdWidget.ModulID);
//                        //    }
//                        //}
//                        //else
//                        //{
//                        //    Literal lit = new Literal();
//                        //    lit.Text = string.Format("<p style=\"color:red\">ID为{0}:<br>找不到相应的部件,可能当前站点下不存在此部件<p>", WidgetID);
//                        //    this.Controls.Add(lit);
//                        //    return;
//                        //}


//                        //try
//                        //{

//                        //WidgetBase control = (WidgetBase)Page.LoadControl(fileName);
//                        //WidgetBase control =  LoadWidgetCtr(mdWidget);
//                        //control.Extensiontype = ExtensionTp;
//                        //control.GetSiteID = SiteID;

//                        //control.DataID = mdWidget.DataID;
//                        //control.ID = control.DataID.ToString().Replace("-", string.Empty);
//                        //control.Title = mdWidget.Title;

//                        //if (control.IsEditable)
//                        //    control.ShowTitle = false;
//                        //else
//                        //    control.ShowTitle = control.DisplayHeader;

//                        //control.LoadData();
//                        //this.Controls.Add(control);
//                        //if (CacheTimeSpan > 0)
//                        //{
//                        //    ToCacheHtml(sPath, control);
//                        //}


//                        //Title = control.Title;
//                        //ShowTitle = control.ShowTitle;
//                        //WidgetType = mdWidget.TypeWidget;
//                        //BoxStyleID = control.BoxStyleId;
//                        //CustomDropDownListPram = control.CustomDropDownListPram;
//                        //CustomColors = control.CustomColor;
//                        //GetTextBoxValue = control.CustomTextBoxPram;
//                        //}
//                        //catch (Exception ex)
//                        //{
//                        //    Literal lit = new Literal();
//                        //    lit.Text = string.Format("<p style=\"color:red\">ID为{0}:<br>{1}<p>", WidgetID, ex.Message);

//                        //    this.Controls.Add(lit);
//                        //}

//                        #endregion

//                    }

//                }
//                else
//                {
//                    Literal lit = new Literal();
//                    lit.Text = string.Format("<p style=\"color:red\">ID为{0}:<br>{1}<p>", WidgetID, "找不到此部件LoadWidgetCtr为null！");
//                    this.Controls.Add(lit);
//                }
                

                
//            }
//            else
//            {
                
//                Literal lit = new Literal();
//                lit.Text = string.Format("<p style=\"color:red\">ID为{0}:<br>{1}<p>", WidgetID, "找不到此部件！");
//                this.Controls.Add(lit);
//            }
            

//        }
//        /// <summary>
//        /// 获取调用代码
//        /// </summary>
//        /// <param name="sWidgetID"></param>
//        /// <param name="WidgetName"></param>
//        /// <returns></returns>
//        public static string GetWidgetCtrCoder(string sWidgetID, string WidgetName)
//        {
//            return string.Concat("<XS:Widget WidgetName=\"", WidgetName, "\"  WidgetID=\"", sWidgetID, "\" runat=\"server\"/>");
//        }

//    }
//}
