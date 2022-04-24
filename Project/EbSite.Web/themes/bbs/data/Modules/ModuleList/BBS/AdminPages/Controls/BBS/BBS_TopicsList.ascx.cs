using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.Modules;


namespace EbSite.Modules.BBS.AdminPages.Controls.BBS
{
    public partial class BBS_TopicsList : MPUCBaseList
    {
        protected ModuleCore.Entity.Channels bbsC;
        protected string pid = "";
        protected string sid = "";
        public override string Permission
        {
            get
            {
                return "7";
            }
        }
        override protected string AddUrl
        {
            get
            {
                return "NetDisk.aspx?t=2&mid=" + ModuleID;
            }
        }
        public string TagCls
        {
            get
            {
                return Request["cls"];
            }
        }

        override protected object LoadList(out int iCount)
        {
            string cId = Request.QueryString["ChannelId"];
            bbsC = ModuleCore.BLL.Channels.Instance.GetEntity(int.Parse(cId));
            WinBox8.Href = "BBS.aspx?t=13&bkId=" + bbsC.id + "&mid=" + ModuleID;
            List<ModuleCore.Entity.Topics> bbstList = ModuleCore.BLL.Topics.Instance.GetListPagesByChannelId(pcPage.PageIndex, pcPage.PageSize, out iCount, bbsC.id.ToString());
            rpList.DataSource = bbstList;
            rpList.DataBind();
            return bbstList;
        }

        override protected object SearchList(out int iCount)
        {
            iCount = 0;
            return null;
        }
        override protected void Delete(object iID)
        {

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                InitrpQZZD();
                InitrpBKZD();
            }
            pid = Convert.ToString(base.MenuID);
            sid = Convert.ToString(base.ModuleID);
        }

        protected void InitrpQZZD()
        {
            rpQZZD.DataSource = ModuleCore.BLL.Topics.Instance.getListArrayByQZZD();
            rpQZZD.DataBind();
        }

        protected void InitrpBKZD()
        {
            rpBKZD.DataSource = ModuleCore.BLL.Topics.Instance.getListArrayByBKZD(bbsC.id.ToString());
            rpBKZD.DataBind();
        }

        protected string GetBs(string tId)
        {
            ModuleCore.Entity.Topics topic = ModuleCore.BLL.Topics.Instance.GetEntity(int.Parse(tId));
            if (topic.ViewCount >= 50)
            {
                return "topicIcon flagHot";
            }
            else
            {
                return "topicIcon flagCommon";
            }
        }

        protected string TitleCss(string tId)
        {
            ModuleCore.Entity.Topics bbst = ModuleCore.BLL.Topics.Instance.GetEntity(int.Parse(tId));
            if (bbst.TitleBoldFlag == 1 && bbst.TitleColorFlag == 1)
            {
                return "<h1 class='topicTitle' style='color:#" + bbst.TitleColorCode + "'>" + bbst.TopicTitle + "</h1>";
            }
            else if (bbst.TitleBoldFlag == 1 && bbst.TitleColorFlag == 0)
            {
                return "<h1 class='topicTitle'>" + bbst.TopicTitle + "</h1>";
            }
            else if (bbst.TitleColorFlag == 1 && bbst.TitleBoldFlag == 0)
            {
                return "<font style='color:#" + bbst.TitleColorCode + "'>" + bbst.TopicTitle + "</font>";
            }
            else
            {
                return bbst.TopicTitle;
            }
        }
    }
}