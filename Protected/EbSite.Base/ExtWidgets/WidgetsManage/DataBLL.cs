using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Web;
using System.Xml;
using EbSite.Core.DataStore;

namespace EbSite.Base.ExtWidgets.WidgetsManage
{
    public class DataBLL : DataBLLBase
    {
        public static readonly DataBLL Instance = new DataBLL();
        public DataBLL()
        {
            
        }
        public DataBLL(int siteid)
        {
            SiteID = siteid;
        }

        public override ExtensionType ExtensionTp
        {
            get
            {
                return ExtensionType.Widget;
            }
        }
        /// <summary>
        /// 用来保存数据列表的文件名称,不带后缀
        /// </summary>
        override public string DefualtZoneName
        {
            get
            {
                return "WidgetsZoneList";
            }
        }

        /// <summary>
        /// 显示控件的名称
        /// </summary>
        override public string AscxName_Show
        {
            get
            {
                return "widget.ascx";
            }
        }
        /// <summary>
        /// 编辑控件的名称
        /// </summary>
        override public string AscxName_Edit
        {
            get
            {
                return "edit.ascx";
            }
        }
       
        /// <summary>
        /// 控件的存放目录
        /// </summary>
        override public string AscxFilePath
        {
            get
            {
                if (SiteID==0)
                {
                    return EbSite.Base.Host.Instance.CurrentSite.GetPathWidgetsWidgetList();
                }
                else
                {
                    return EbSite.Base.Host.Instance.GetSite(SiteID).GetPathWidgetsWidgetList(); 
                }
                
            }
        }
        override public string FilePath
        {
            get
            {

                return "Widgets";
            }
        }
       
        public void UpdataTitle(string sID, string sTitle)
        {
            bool isChanged = false;
            XmlDocument doc = RetrieveXml(DefualtZoneName);
            XmlNode node = doc.SelectSingleNode("//widget[@id=\"" + sID + "\"]");
            if (node.Attributes["title"].InnerText != sTitle)
            {
                node.Attributes["title"].InnerText = sTitle;
                isChanged = true;
            }

            if (isChanged)
                SaveXmlDocument(doc, DefualtZoneName);
        }

    }
}
