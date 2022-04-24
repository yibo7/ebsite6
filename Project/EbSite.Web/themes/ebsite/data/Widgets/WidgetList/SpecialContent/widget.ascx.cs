
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using EbSite.Base;
using EbSite.Base.ExtWidgets.WidgetsManage;
using EbSite.Data.Interface;

namespace EbSite.Widgets.SpecialContent
{
    public partial class widget : WidgetBase
    {
        public override void LoadData()
        {

            if (!base.IsPostBack)
            {
                int iTop = 10;
                string TemPath = "";
                int iDataType = 0; //0全部,1推荐,2有图片,3有标签 

                int iOrderType = 0;  //0最新,1最老,2访问最多,3今日访问最多,4本周访问最多,5本月访问最多,6评论最多,7收藏最多,8随机

                StringDictionary settings = GetSettings();
                if (settings.ContainsKey("txtCount"))
                {
                    iTop = int.Parse(settings["txtCount"]);

                } 
                if (settings.ContainsKey("txtTem"))
                {

                    TemPath = settings["txtTem"];
                }
                if (settings.ContainsKey("datatype"))
                {

                    iDataType = int.Parse(settings["datatype"]);
                }
                if (settings.ContainsKey("ordertype"))
                {

                    iOrderType = int.Parse(settings["ordertype"]);
                }
                string sWhere = string.Format("id in(SELECT NewsID FROM {0}specialnews WHERE SpecialClassID={1})", Base.Configs.BaseCinfigs.ConfigsControl.Instance.TablePrefix, GetSpecialID) ;

                if (iDataType == 1)
                {
                    sWhere = string.Format("{0} AND IsGood=1", sWhere);
                }
                else if (iDataType == 2)
                {
                    sWhere = string.Format("{0} AND SmallPic<>''", sWhere);
                }
                else if (iDataType == 3)
                {
                    sWhere = string.Format("{0} AND TagIDs<>''", sWhere);
                }

                string sOrderBy = "ID DESC";
                //0最新,1最老,2访问最多,3今日访问最多,4本周访问最多,5本月访问最多,6评论最多,7收藏最多,8随机
                if (iOrderType == 1)
                {
                    sOrderBy = "ID ASC";
                }
                else if (iOrderType == 2)
                {
                    sOrderBy = "Hits DESC";
                }
                else if (iOrderType == 3)
                {
                    sOrderBy = "dayHits DESC";
                }
                else if (iOrderType == 4)
                {
                    sOrderBy = "weekHits DESC ";
                }
                else if (iOrderType == 5)
                {
                    sOrderBy = "monthhits DESC";
                }
                else if (iOrderType == 6)
                {
                    sOrderBy = "CommentNum DESC";
                }
                else if (iOrderType == 7)
                {
                    sOrderBy = "Advs DESC";
                }
                //else if (iOrderType == 8)
                //{
                //    sOrderBy = "Advs DESC";
                //}

                rpDataList.DataSource = Base.AppStartInit.NewsContentInstDefault.GetListArray(sWhere, iTop, sOrderBy, "", GetSiteID);
                TemPath = base.TemBll.GetTemPath(TemPath);
                if (!string.IsNullOrEmpty(TemPath))
                {

                    rpDataList.ItemTemplate = LoadTemplate(TemPath);
                }
                rpDataList.DataBind();
                
            }
        }
        protected int GetSpecialID
        {
            get
            {
                if (!string.IsNullOrEmpty(Request["sid"]))
                {
                    return int.Parse(Request["sid"]);
                }
                else
                {
                    return 0;
                }
            }
        }
        public override string Name
        {
            get { return "SpecialContent"; }
        }

        public override bool IsEditable
        {
            get { return true; }
        }

         
        
    }
}