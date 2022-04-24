
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Reflection;
using System.Web.UI;
using EbSite.Base.ExtWidgets.WidgetsManage;
using EbSite.Entity.SearchCustom;

namespace EbSite.Widgets.SearchKeyWordMatch
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
                int SiteID = GetSiteID;
                StringDictionary settings = GetSettings();
             
                if (settings.ContainsKey("txtTem"))
                {

                    TemPath = settings["txtTem"];
                }
                //if (settings.ContainsKey("SiteID"))
                //{

                //    SiteID =int.Parse( settings["SiteID"]);
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


                BandList(iTOP, settings["drpType"], IsImg, SiteID);
                
            }
        }
        /// <summary>
        /// 获取部件ID
        /// </summary>
        protected string CID
        {
            get
            {
                return Request["cid"];
            }
        }
        private void BandList(int iTOP, string sType, bool IsImg, int SiteID)
        {

            if(!string.IsNullOrEmpty(sKeyWord)) //一般搜索
            {
                if (SiteID == 0)
                {
                    rpList.DataSource = EbSite.Base.AppStartInit.NewsContentInstDefault.GetListHotByKeyWord(sKeyWord, iTOP, sType, IsImg, "", base.GetSiteID);

                }
                else
                {
                    rpList.DataSource =EbSite.Base.AppStartInit.NewsContentInstDefault.GetListHotByKeyWord(sKeyWord, iTOP, sType, IsImg, "", SiteID);

                }
               rpList.DataBind();


            }
            else  //获取父页面的SearchModel
            {

                SearchModel sm = Session["SearchModel"] as SearchModel; 
                
                if(!Equals(sm,null))
                {

                    rpList.DataSource = BLL.SearchCustom.Utils.SearchResult(iTOP, sm, sType);
                    rpList.DataBind();
                }
            }

        }
        public override string Name
        {
            get { return "SearchKeyWordMatch"; }
        }

        public override bool IsEditable
        {
            get { return true; }
        }

        
    }
}