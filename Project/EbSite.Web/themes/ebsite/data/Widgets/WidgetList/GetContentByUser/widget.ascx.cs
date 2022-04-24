
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Reflection;
using System.Web.UI;
using EbSite.BLL;
using EbSite.Base.ExtWidgets.WidgetsManage;

namespace EbSite.Widgets.GetContentByUser
{
    public partial class widget : WidgetBase
    {
        private string sKeyWord
        {
            get
            {
                return Request["k"];
            }
        }
        public override void LoadData()
        {

            if (!base.IsPostBack)
            {
                
                string TemPath = "";
                int SiteID = GetSiteID;//yhl 2012-02-14
                StringDictionary settings = GetSettings();
             
                if (settings.ContainsKey("txtTem"))
                {

                    TemPath = settings["txtTem"];
                }
                //if (settings.ContainsKey("SiteID"))
                //{
                //    SiteID = int.Parse(settings["SiteID"]);
                //}

                TemPath = base.TemBll.GetTemPath(TemPath);
                if (!string.IsNullOrEmpty(TemPath))
                {
                    rpList.ItemTemplate = LoadTemplate(TemPath);
                }
                bool IsImg = false;
                if(settings.ContainsKey("IsImage"))
                {
                    IsImg = bool.Parse(settings["IsImage"]);
                }

                int iTOP = 10;
                if (settings.ContainsKey("txtTOP"))
                {
                    iTOP = int.Parse(settings["txtTOP"]);
                }

                int iUserFrom = 0;
                if (settings.ContainsKey("UserFrom"))
                {
                    iUserFrom = int.Parse(settings["UserFrom"]);
                }
                string sType = "";
                if (settings.ContainsKey("UserFrom"))
                {
                    sType = settings["drpType"];
                }
                

                int iUserID = 0;

                if(iUserFrom==0)
                {
                    iUserID = EbSite.Base.AppStartInit.UserID;
                }
                else
                {
                    if(iID>0)
                    {
                        iUserID = NewsContentInst.GetModel(iID,GetSiteID).UserID;
                    }
                }
                if (SiteID == 0)//自动适应
                {
                    rpList.DataSource = NewsContentInst.GetListByUser(iTOP, iUserID, sType, IsImg, base.GetSiteID);
                }
                else
                {
                    rpList.DataSource = NewsContentInst.GetListByUser(iTOP, iUserID, sType, IsImg, SiteID);
                }
                rpList.DataBind();
                
            }
        }
        /// <summary>
        /// 获取当前内容ID
        /// </summary>
        protected int iID
        {
            get
            {
                if(!string.IsNullOrEmpty(Request["id"]))
                {
                   int i =0;
                   if (int.TryParse(Request["id"], out i))
                   {
                       return int.Parse(Request["id"]);
                   } 
                    
                }
                return 0;
            }
        }
       
        public override string Name
        {
            get { return "GetContentByUser"; }
        }

        public override bool IsEditable
        {
            get { return true; }
        }

        /// <summary>
        /// 获取当前内容ID
        /// </summary>
        protected int iClassID
        {
            get
            {
                if (!string.IsNullOrEmpty(Request["cid"]))
                {
                    return int.Parse(Request["cid"]);
                }
                return 0;
            }
        }
        private NewsContentSplitTable NewsContentInst
        {
            get
            {
                return EbSite.Base.AppStartInit.GetNewsContentInst(iClassID);
            }
        }
    }
}