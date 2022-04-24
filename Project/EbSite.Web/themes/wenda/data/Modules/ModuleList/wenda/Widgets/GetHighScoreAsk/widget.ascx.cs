using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.ExtWidgets.WidgetsManage;

namespace EbSite.Modules.BmAsk.Widgets.GetHighScoreAsk
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

                StringDictionary settings = GetSettings();

                if (settings.ContainsKey("txtTem"))
                {

                    TemPath = settings["txtTem"];
                }

                TemPath = BLL.Ctrtem.TemList.GetTemPath(TemPath);
                if (!string.IsNullOrEmpty(TemPath))
                {
                    rpList.ItemTemplate = LoadTemplate(TemPath);
                }
                bool IsImg = false;
                if (settings.ContainsKey("IsImage"))
                {
                    IsImg = bool.Parse(settings["IsImage"]);
                }

                int iTOP = 10;
                if (settings.ContainsKey("txtTOP"))
                {
                    iTOP = int.Parse(settings["txtTOP"]);
                }

                string Fields = EbSite.BLL.NewsContent.DefualtFileds;
                string sqlWhere = " Annex1>= " + 30; 
                //string sqlWhere = " Annex4 = '" + 2 + "' ";
                //string sqlWhere = " Annex4 = " + 2;

                rpList.DataSource = BLL.NewsContent.GetListArray(sqlWhere, iTOP, "AddTime DESC", "*", 7);  //写死了，因为现在系统不能获取正确的siteid;
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
                if (!string.IsNullOrEmpty(Request["id"]))
                {
                    return int.Parse(Request["id"]);
                }
                return 0;
            }
        }

        public override string Name
        {
            get { return "GetHighScoreAsk"; }
        }

        public override bool IsEditable
        {
            get { return true; }
        }


    }
}