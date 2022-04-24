using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.ExtWidgets.WidgetsManage;
using EbSite.BLL.Ctrtem;
using EbSite.Modules.Wenda.Widgets.GetSolve.Controls;

namespace EbSite.Modules.Wenda.Widgets.GetSolve
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
        /// <summary>
        /// 自动适应内容ID
        /// </summary>
        private int GetContentId
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
        
        public override void LoadData()
        {
            if (!base.IsPostBack)
            {
                StringDictionary settings = GetSettings();
                if (settings.ContainsKey("drpType"))
                {
                    string sType = settings["drpType"];

                    if(!string.IsNullOrEmpty(sType))
                    {
                        ucClassData.DataModel = (EbSite.Modules.Wenda.Widgets.GetSolve.Controls.DataListType)int.Parse(sType);    
                    }
                }
                if (settings.ContainsKey("CountImg"))
                {
                    string sType = settings["CountImg"];
                    ucClassData.ImgTop = int.Parse(sType);
                }
                if (settings.ContainsKey("CountTitle"))
                {
                    string sType = settings["CountTitle"];
                    ucClassData.TitleTop = int.Parse(sType);
                }
                if (settings.ContainsKey("TemTitle") && !string.IsNullOrEmpty(settings["TemTitle"]))
                {
                    string sTem = settings["TemTitle"];
                    sTem = TemListInstace.TemBll(GetSiteID).GetTemPath(sTem);
                    if (!string.IsNullOrEmpty(sTem))
                    ucClassData.TitleTemPath = sTem;
                }

                if (settings.ContainsKey("ListModel"))
                {
                    int iListModel = int.Parse(settings["ListModel"]);
                    ucClassData.LstModel = (ListModel)iListModel;
                }


                if (settings.ContainsKey("TemImg") && !string.IsNullOrEmpty(settings["TemImg"]))
                {
                    string sTem = settings["TemImg"];
                    sTem = TemListInstace.TemBll(GetSiteID).GetTemPath(sTem);
                    if (!string.IsNullOrEmpty(sTem))
                    ucClassData.ImgTemPath = sTem;
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
                        iClassID = BLL.NewsContent.GetModel(GetContentId).ClassID;
                    }

                    ucClassData.iClassID = iClassID;
                }
                if (settings.ContainsKey("IsShowNum"))
                {
                    string sIsShowNum = settings["IsShowNum"];
                    if (!string.IsNullOrEmpty(sIsShowNum))
                        ucClassData.IsShowNum = bool.Parse(sIsShowNum);

                }
                if (settings.ContainsKey("IsGetSub"))
                {
                    string sIsGetSub = settings["IsGetSub"];
                    if (!string.IsNullOrEmpty(sIsGetSub))
                        ucClassData.IsGetSub = bool.Parse(sIsGetSub);

                }
            }
        }

        public override string Name
        {
            get { return "GetSolve"; }
        }

        public override bool IsEditable
        {
            get { return true; }
        }
    }
}