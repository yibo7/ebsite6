//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Text;
//using System.Threading;
//using System.Web;
//using System.Web.UI;
//using System.Web.UI.WebControls;
//using System.Xml;
//using EbSite.Core.DataStore;

//namespace EbSite.Core.WidgetsManage
//{
//     /// <summary>
//        /// WidgetZone上文已经涉及到，它就是一个Widget的容器。
//        /// WidgetZone继承自PlaceHolder，
//        /// 在OnLoad时会根据DataStore将已经添加的Widget加载到PlaceHolder中,
//        /// 在Render的时候还会去查找安装在widgets目录下的Widget列表。
//        /// 这个WidgetZone在BlogEngine.Net中并不是一个必须的类，
//        /// 你可以将Widget直接放在主界面的某个位置上就可以使用。
//        /// 但是，如果不使用它来管理而直接显示Widget会失去Widget的管理特性，
//        /// 在下一篇制作Theme的文章中我会对其进行详细的说明。

//        /// </summary>
//        public class WidgetZone : PlaceHolder
//        {

//            public WidgetZone()
//            {
                
//                //如果用户修改Widget,将重新载入XML_DOCUMENT
//                WidgetEditBase.Saved += delegate { XML_DOCUMENT = ExtWidgets.WidgetsManage.DataBLL.Instance.RetrieveXml(_ZoneName); };
//            }

//            private XmlDocument XML_DOCUMENT;

//            // For backwards compatibility or if a ZoneName is omitted, provide a default ZoneName.
//         private string _ZoneName = ExtWidgets.WidgetsManage.DataBLL.Instance.DefualtZoneName;
//            /// <summary>
//            /// Gets or sets the name of the data-container used by this instance
//            /// </summary>
//            public string ZoneName
//            {
//                get { return _ZoneName; }
//                set { _ZoneName = Utils.RemoveIllegalCharacters(value); }
//            }

//            protected override void OnInit(EventArgs e)
//            {
//                if (XML_DOCUMENT == null)
//                    XML_DOCUMENT = ExtWidgets.WidgetsManage.DataBLL.Instance.RetrieveXml(_ZoneName);

//                base.OnInit(e);
//            }

//            //private XmlDocument RetrieveXml()
//            //{
//            //    WidgetSettings ws = new WidgetSettings(_ZoneName);
//            //    ws.SettingsBehavior = new XMLDocumentBehavior();
//            //    XmlDocument doc = (XmlDocument)ws.GetSettings();
//            //    return doc;
//            //}

//            /// <summary>
//            /// Raises the <see cref="E:System.Web.UI.Control.Load"></see> event.
//            /// </summary>
//            /// <param name="e">The <see cref="T:System.EventArgs"></see> object that contains the event data.</param>
//            protected override void OnLoad(EventArgs e)
//            {
//                base.OnLoad(e);

//                XmlNodeList zone = XML_DOCUMENT.SelectNodes("//widget");
//                foreach (XmlNode widget in zone)
//                {
//                    string fileName = Base.AppStartInit.IISPath + "widgets/" + widget.InnerText + "/widget.ascx";
//                    try
//                    {
//                        WidgetBase control = (WidgetBase)Page.LoadControl(fileName);
//                        control.DataID = new Guid(widget.Attributes["id"].InnerText);
//                        control.ID = control.DataID.ToString().Replace("-", string.Empty);
//                        control.Title = widget.Attributes["title"].InnerText;
//                        control.Zone = _ZoneName;

//                        if (control.IsEditable)
//                            control.ShowTitle = bool.Parse(widget.Attributes["showTitle"].InnerText);
//                        else
//                            control.ShowTitle = control.DisplayHeader;

//                        control.LoadData();
//                        this.Controls.Add(control);
//                    }
//                    catch (Exception ex)
//                    {
//                        Literal lit = new Literal();
//                        lit.Text = "<p style=\"color:red\">部件 " + widget.InnerText + " 未找到。<p>";
//                        lit.Text += ex.Message;
//                        lit.Text += "<a class=\"delete\" href=\"javascript:void(0)\" onclick=\"BlogEngine.widgetAdmin.removeWidget('" + widget.Attributes["id"].InnerText + "');return false\" title=\"删除部件\">X</a>";

//                        this.Controls.Add(lit);
//                    }
//                }
//            }
            
//            /// <summary>
//            /// Sends server control content to a provided <see cref="T:System.Web.UI.HtmlTextWriter"></see> 
//            /// object, which writes the content to be rendered on the client.
//            /// </summary>
//            /// <param name="writer">
//            /// The <see cref="T:System.Web.UI.HtmlTextWriter"></see> object 
//            /// that receives the server control content.
//            /// </param>
//            protected override void Render(System.Web.UI.HtmlTextWriter writer)
//            {
//                writer.Write("<div id=\"widgetzone_" + _ZoneName + "\" class=\"widgetzone\">");

//                base.Render(writer);

//                writer.Write("</div>");

//                //if (Thread.CurrentPrincipal.IsInRole(BlogSettings.Instance.AdministratorRole))
//                //{
//                //    string selectorId = "widgetselector_" + _ZoneName;
//                //    writer.Write("<select id=\"" + selectorId + "\" class=\"widgetselector\">");
//                //    DirectoryInfo di = new DirectoryInfo(Page.Server.MapPath(Utils.RelativeWebRoot + "widgets"));
//                //    foreach (DirectoryInfo dir in di.GetDirectories())
//                //    {
//                //        if (File.Exists(Path.Combine(dir.FullName, "widget.ascx")))
//                //            writer.Write("<option value=\"" + dir.Name + "\">" + dir.Name + "</option>");
//                //    }

//                //    writer.Write("</select>&nbsp;&nbsp;");
//                //    writer.Write("<input type=\"button\" value=\"加入部件\" onclick=\"BlogEngine.widgetAdmin.addWidget(BlogEngine.$('" + selectorId + "').value, '" + _ZoneName + "')\" />");
//                //    writer.Write("<div class=\"clear\" id=\"clear\">&nbsp;</div>");
//                //}
//            }

        
//    }
//}
