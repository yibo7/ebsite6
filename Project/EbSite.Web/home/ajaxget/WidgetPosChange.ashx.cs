using System;
using System.Collections.Generic;
using System.Web;

namespace EbSite.Web.home.ajaxget
{
    /// <summary>
    /// Summary description for WidgetPosChange
    /// </summary>
    public class WidgetPosChange : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            if (!string.IsNullOrEmpty(context.Request.QueryString["zd"]))
            {
                string[] aWidgets = context.Request.QueryString["zd"].Split('|');
                foreach (string sWidget in aWidgets)
                {
                    string[] aWidgetDatas =sWidget.Split('=');
                    if (aWidgetDatas.Length == 2)
                    {
                        string Layout = aWidgetDatas[0];
                        string[] aWidgetData = aWidgetDatas[1].Split(',');
                        int OrderNum = 0;
                        foreach (string sWt in aWidgetData)
                        {
                            string[] WidgetTabID = sWt.Split('*');

                            if (!string.IsNullOrEmpty(WidgetTabID[0]) && !string.IsNullOrEmpty(WidgetTabID[1]))
                            {
                                Guid WidgetID = new Guid(WidgetTabID[0]);
                                int tabwidgetid = int.Parse(WidgetTabID[1]);
                                EbSite.BLL.SpaceTabWidget.Instance.UpdateChange(tabwidgetid, Layout, WidgetID, OrderNum);
                                OrderNum++;
                            }
                        }
                    }
                    

                }
            } //删除 添加  -- 有空另外创建一个文件处理
            //else if ((!string.IsNullOrEmpty(context.Request.QueryString["addid"]) || !string.IsNullOrEmpty(context.Request.QueryString["delid"])) && !string.IsNullOrEmpty(context.Request.QueryString["tid"]))
            else if (!string.IsNullOrEmpty(context.Request.QueryString["addid"]) && !string.IsNullOrEmpty(context.Request.QueryString["tid"]))
            {
                
                int iTabID = int.Parse(context.Request.QueryString["tid"]);
                string[] aAddIDs = context.Request.QueryString["addid"].Split(',');
                if(aAddIDs.Length>0)
                    EbSite.BLL.SpaceTabWidget.Instance.AddWidgetToTab(EbSite.Base.AppStartInit.UserID, iTabID, aAddIDs);
                //string aDelIDs = context.Request.QueryString["delid"];
                //if (!string.IsNullOrEmpty(aDelIDs))
                //    EbSite.BLL.SpaceTabWidget.Instance.DelWidgetFromTab(EbSite.Base.AppStartInit.UserID, iTabID, aDelIDs);
                context.Response.Write("ok");
                
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}