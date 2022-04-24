
using System.Collections.Generic;
using System.Collections.Specialized;
using EbSite.Base.Static;
using EbSite.BLL;
using EbSite.Base.ExtWidgets.WidgetsManage;

namespace EbSite.Widgets.GetContent
{
    public partial class widget : WidgetBase
    {
        override public string CacheKey
        {
            get
            {
                return string.Concat(GetClassID, GetContentId);
            }
        } 
        /// <summary>
        /// 自动适应分类ID
        /// </summary>
        private int GetClassID
        {
            get
            {
                if (!string.IsNullOrEmpty(Request["cid"]))
                {
                    return int.Parse(Request["cid"]);
                }
                else
                {
                    return 0;
                }
            }
        }
        /// <summary>
        /// 自动适应内容ID
        /// </summary>
        private int GetContentId
        {
            get
            {
                if (!string.IsNullOrEmpty(Request["id"]))
                {
                    int dc = 0;
                    if (int.TryParse(Request["id"], out dc))
                    {
                        return int.Parse(Request["id"]);
                    }
                    return 0;
                }
                else
                {
                    return 0;
                }
            }
        }
        
        public override void LoadData()
        {
            if (!base.IsPostBack)
            {
                StringDictionary settings = GetSettings();
                
                DataListType DataModel = DataListType.最新数据;

                int iTop = 10;

                int DataClassID = 0;

                bool IsGetSub = false;

                bool IsGetImgData = false;//是否只查询有图片的内容

                string TemPath = "";

                if (settings.ContainsKey("drpType"))
                {
                    string sType = settings["drpType"];

                    if(!string.IsNullOrEmpty(sType))
                    {
                        DataModel = (DataListType)int.Parse(sType);    
                    }
                }
          
                if (settings.ContainsKey("Count"))
                {
                    string sType = settings["Count"];
                    iTop = int.Parse(sType);
                }

              

                if (settings.ContainsKey("ClassID"))
                {
                    string sClassID = settings["ClassID"];

                    int iClassID = int.Parse(sClassID);

                    if (iClassID == -1)
                    {
                        iClassID = GetClassID;
                    }
                    if (iClassID == -2)
                    {
                        //自动适应内容 本页面 肯定有 ClassID
                        NewsContentSplitTable NewsContentInst = EbSite.Base.AppStartInit.GetNewsContentInst(GetClassID);//2014-2-11 
                        iClassID = NewsContentInst.GetModel(GetContentId, GetSiteID).ClassID;
                    }

                    DataClassID = iClassID;
                }
             
                if (settings.ContainsKey("IsGetSub"))
                {
                    string sIsGetSub = settings["IsGetSub"];
                    if (!string.IsNullOrEmpty(sIsGetSub))
                        IsGetSub = bool.Parse(sIsGetSub);

                }
                if (settings.ContainsKey("IsGetSmallImg"))
                {
                    string sIsGetSmallImg = settings["IsGetSmallImg"];
                    if (!string.IsNullOrEmpty(sIsGetSmallImg))
                        IsGetImgData = bool.Parse(sIsGetSmallImg);

                }

                if (settings.ContainsKey("TemTitle") && !string.IsNullOrEmpty(settings["TemTitle"]))
                {
                    TemPath = settings["TemTitle"];
                   // sTem = base.TemBll.GetTemPath(sTem);
                    //if (!string.IsNullOrEmpty(sTem))
                        // ucClassData.TitleTemPath = sTem;
                        
                }
                //if (settings.ContainsKey("CtrTem"))
                //{
                //    TemPath = settings["CtrTem"];
                //}

                TemPath = base.TemBll.GetTemPath(TemPath);
                if (!string.IsNullOrEmpty(TemPath))
                {
                    rpContent.ItemTemplate = LoadTemplate(TemPath);
                }
                
                rpContent.DataSource = GetData(GetSiteID, DataModel, iTop, DataClassID, IsGetSub, IsGetImgData);
                rpContent.DataBind();
            }
        }

        public override string Name
        {
            get { return "GetContent"; }
        }

        public override bool IsEditable
        {
            get { return true; }
        }
   
        private List<Entity.NewsContent> GetData(int SiteID, DataListType DataModel, int iTop, int iClassID, bool IsGetSub, bool IsHaveImg)
        {
            NewsContentSplitTable NewsContentInst = EbSite.Base.AppStartInit.GetNewsContentInst(iClassID);
            if (SiteID < 1)
            {
                Response.Write("<font color=#ff0000>站点ID为0,可能没有设置相关站点</font>");
                return null;
            }


            //string Fields = NewsContentSplitTable.DefualtFileds;

            string Fields = string.Empty;
                  //if (!string.IsNullOrEmpty(BLL.DataSettings.Content.Instance.GetConfigCurrent.SearchFileds_Widget))
                  //{
                  //    Fields = Fields + "," + BLL.DataSettings.Content.Instance.GetConfigCurrent.SearchFileds_Widget;
                  //}
                  //string CacheKey = string.Concat("GetClassData-", DataModel, "-", iTop, "-", iClassID, "-", SiteID);
                  List <Entity.NewsContent> lst = null;
            if (DataModel == DataListType.调用推荐数据)
                {

                    lst = NewsContentInst.GetListGood(iTop, iClassID, IsGetSub, IsHaveImg, Fields, SiteID);
                }
                else if (DataModel == DataListType.调用总排行数据)
                {
                    lst = NewsContentInst.GetListHot(iClassID, iTop, "", IsGetSub, IsHaveImg, Fields, SiteID);
                }
                else if (DataModel == DataListType.调用本周热门数据)
                {
                    lst = NewsContentInst.GetListHot(iClassID, iTop, "w", IsGetSub, IsHaveImg, Fields, SiteID);
                }
                else if (DataModel == DataListType.收藏率排行)
                {
                    lst = NewsContentInst.GetListHot(iClassID, iTop, "adv", IsGetSub, IsHaveImg, Fields, SiteID);
                }
                else if (DataModel == DataListType.今日点击排行)
                {
                    lst = NewsContentInst.GetListHot(iClassID, iTop, "d", IsGetSub, IsHaveImg, Fields, SiteID);
                }
                else if (DataModel == DataListType.本月点击排行)
                {
                    lst = NewsContentInst.GetListHot(iClassID, iTop, "m", IsGetSub, IsHaveImg, Fields, SiteID);
                }
                else if (DataModel == DataListType.评论最多的内容)
                {
                    lst = NewsContentInst.GetListHot(iClassID, iTop, "ch", IsGetSub, IsHaveImg, Fields, SiteID);
                }
                else if (DataModel == DataListType.好评被顶最多的内容)
                {
                    lst = NewsContentInst.GetListHot(iClassID, iTop, "fh", IsGetSub, IsHaveImg, Fields, SiteID);
                }
                else
                {
                    lst = NewsContentInst.GetListNewOfNewsClass(iClassID, iTop, IsGetSub, IsHaveImg, Fields, SiteID);
                }
            return lst;
        }
    }

    public enum DataListType
    {

        最新数据 = 1,

        调用推荐数据 = 2,

        调用总排行数据 = 3,

        调用本周热门数据 = 4,

        收藏率排行 = 5,

        评论最多的内容 = 6,

        好评被顶最多的内容 = 7,

        今日点击排行 = 8,

        本月点击排行 = 9
    }
    
    
}
