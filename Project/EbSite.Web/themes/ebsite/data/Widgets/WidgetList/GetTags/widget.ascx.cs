
using System.Collections.Specialized;
using EbSite.Base.ExtWidgets.WidgetsManage; 

namespace EbSite.Widgets.GetTags
{
    public partial class widget : WidgetBase
    {
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
        private int GetContentID
        {
            get
            {
                if (!string.IsNullOrEmpty(Request["id"]))
                {
                    return int.Parse(Request["id"]);
                }
                else
                {
                    return 0;
                }
            }
        }
        ///// <summary>
        ///// 自动适应内容ID
        ///// </summary>
        //private int GetContentId
        //{
        //    get
        //    {
        //        if (!string.IsNullOrEmpty(Request["id"]))
        //        {
        //            return int.Parse(Request["id"]);
        //        }
        //        else
        //        {
        //            return 0;
        //        }
        //    }
        //}
        public override void LoadData()
        {
            if (!base.IsPostBack)
            {
                StringDictionary settings = GetSettings();
                int iTop = 0;
                //int SiteID = GetSiteID;
                //if (settings.ContainsKey("SiteID"))
                //{
                //    SiteID = int.Parse(settings["SiteID"]);
                //}
                if (settings.ContainsKey("Count"))
                {
                    string sCount = settings["Count"];

                    iTop = int.Parse(sCount);
                }
                if (settings.ContainsKey("Tem"))
                {
                    string sTem = settings["Tem"];
                    sTem = base.TemBll.GetTemPath(sTem);
                    if (!string.IsNullOrEmpty(sTem))
                    {

                        rpList.ItemTemplate = LoadTemplate(sTem);
                    }
                }
                int iType = 0;
                int iClassID = 0;
                if (settings.ContainsKey("cid"))
                {
                    string sClassID = settings["cid"];

                    iType = int.Parse(sClassID);

                    if (iType == -1|| iType==-2)
                    {
                        iClassID = GetClassID;
                    }
                   

                }

                int iNum = 0;

                if (settings.ContainsKey("Num"))
                {
                    string sNum = settings["Num"];

                    iNum = Core.Utils.StrToInt(sNum, 0);

                }

                //txtNum.Text = settings["Num"];


                if (settings.ContainsKey("ListModel"))
                    {
                        int iListModel = int.Parse(settings["ListModel"]);

                        if (iType == -2)
                        {
                            rpList.DataSource = BLL.TagKey.GetTagsIDByContentID(GetContentID, iClassID, iListModel, iTop, base.GetSiteID, iNum);
                        }
                        else
                        {
                            if (iListModel == 1) //最新标签
                            {
                                rpList.DataSource = BLL.TagKey.GetTagKeys_New(iTop, iClassID, base.GetSiteID, iNum);
                            }
                            else if (iListModel == 2)//热门标签
                            {
                                rpList.DataSource = BLL.TagKey.GetTagKeys_Hot(iTop, iClassID, base.GetSiteID, iNum);

                            }
                        }

                        
                    }
                

                
                rpList.DataBind();
            }
        }

        public override string Name
        {
            get { return "GetTags"; }
        }

        public override bool IsEditable
        {
            get { return true; }
        }

        protected string GetTagColor()
        {
            string color = BLL.TagColor.Instance.GetColor(10);
            return "style =' color:#" + color + "'";
        }
    }
}