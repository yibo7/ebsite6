using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.BLL;
using EbSite.Base.ControlPage;
using EbSite.Base.Modules;
using EbSite.Modules.BBS.ModuleCore.Entity;

namespace EbSite.Modules.BBS.AdminPages.Controls.BBSmanagement
{
    public partial class bbsconfigs_add : MPUCBaseSave
    {

        public override string Permission
        {
            get
            {
                return "15";
            }
        }
        override protected string KeyColumnName
        {
            get
            {
                return "id";
            }
        }
        /// <summary>
        /// 版块列表
        /// </summary>
        private void binddata()
        {
            drpPatentID.DataTextField = "ChannelName";
            drpPatentID.DataValueField = "Id";
            drpPatentID.DataSource = ModuleCore.BLL.Channels.Instance.GetTree(0);
            drpPatentID.DataBind();
        }
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                binddata();
                if (string.IsNullOrEmpty(SID))
                {
                    divImg.Attributes.Add("style", "display:none");
                }
            }
        }
        override protected void InitModifyCtr()
        {
            ModuleCore.BLL.Channels.Instance.InitModifyCtr(SID, phCtrList);
            ModuleCore.Entity.Channels bbsC = ModuleCore.BLL.Channels.Instance.GetEntity(int.Parse(SID));

            if (!string.IsNullOrEmpty(bbsC.ChannelImageUrl))
            {
                imgTu.Src = bbsC.ChannelImageUrl;
                ViewState["ciu"] = imgTu.Src;
                ViewState["num"] = "yes";
            }
            if (!string.IsNullOrEmpty(bbsC.ParentID.ToString()))
                drpPatentID.SelectedValue = bbsC.ParentID.ToString();

        }

        override protected void SaveModel()
        {
            string ChannelImageUrl = "";
            if (!string.IsNullOrEmpty(Convert.ToString(ViewState["ciu"])) && txUp.ValueItems.Count == 0)
            {
                ChannelImageUrl = Convert.ToString(ViewState["ciu"]);
            }
            else
            {
                if (txUp.ValueItems.Count > 0)
                {
                    ChannelImageUrl = txUp.ValueItems[0].FileNewName;
                }
                else
                {
                    ChannelImageUrl = "/images/noimg.gif";
                }
            }
            string TopicCount = "", ReplyCount = "", PostCount = "", TodayPostCount = "", LatestBBSTopicID = "", LatestBBSTopicUserID = "", CompanyID = "", ChannelFlag = "", ReadFlag = "", WriteFlag = "", ChannelLinkFlag = "", CreatedTime = "", SatisticsTime = "", LatestBBSTopicRepliedTime = "";
            if (string.IsNullOrEmpty(Convert.ToString(ViewState["num"])))
            {
                TopicCount = Convert.ToString(0);
                ReplyCount = Convert.ToString(0);
                PostCount = Convert.ToString(0);
                TodayPostCount = Convert.ToString(0);
                LatestBBSTopicID = Convert.ToString(0);
                LatestBBSTopicUserID = Convert.ToString(0);
                CompanyID = Convert.ToString(0);
                ChannelFlag = Convert.ToString(0);
                ReadFlag = Convert.ToString(0);
                WriteFlag = Convert.ToString(0);
                ChannelLinkFlag = Convert.ToString(0);
                CreatedTime = DateTime.Now.ToString();
                SatisticsTime = DateTime.Now.ToString();
                LatestBBSTopicRepliedTime = DateTime.Now.ToString();
            }
            else
            {
                EbSite.Modules.BBS.ModuleCore.Entity.Channels bbsc = EbSite.Modules.BBS.ModuleCore.BLL.Channels.Instance.GetEntity(int.Parse(SID));
                TopicCount = Convert.ToString(bbsc.TopicCount);
                ReplyCount = Convert.ToString(bbsc.ReplyCount);
                PostCount = Convert.ToString(bbsc.PostCount);
                TodayPostCount = Convert.ToString(bbsc.TodayPostCount);
                LatestBBSTopicID = Convert.ToString(bbsc.LatestBBSTopicID);
                LatestBBSTopicUserID = Convert.ToString(bbsc.LatestBBSTopicUserID);
                CompanyID = Convert.ToString(bbsc.CompanyID);
                ChannelFlag = Convert.ToString(bbsc.ChannelFlag);
                ReadFlag = Convert.ToString(bbsc.ReadFlag);
                WriteFlag = Convert.ToString(bbsc.WriteFlag);
                ChannelLinkFlag = Convert.ToString(bbsc.ChannelLinkFlag);
                CreatedTime = Convert.ToString(bbsc.CreatedTime);
                SatisticsTime = Convert.ToString(bbsc.SatisticsTime);
                LatestBBSTopicRepliedTime = Convert.ToString(bbsc.LatestBBSTopicRepliedTime);
            }
            EbSite.Base.BLL.OtherColumn cl = new OtherColumn("ChannelImageUrl", ChannelImageUrl);
            lstOtherColumn.Add(cl);
            cl = new OtherColumn("CreatedTime", CreatedTime);
            lstOtherColumn.Add(cl);
            cl = new OtherColumn("UpdatedTime", DateTime.Now.ToString());
            lstOtherColumn.Add(cl);
            cl = new OtherColumn("TopicCount", TopicCount);
            lstOtherColumn.Add(cl);
            cl = new OtherColumn("ReplyCount", ReplyCount);
            lstOtherColumn.Add(cl);
            cl = new OtherColumn("PostCount", PostCount);
            lstOtherColumn.Add(cl);
            cl = new OtherColumn("TodayPostCount", TodayPostCount);
            lstOtherColumn.Add(cl);
            cl = new OtherColumn("SatisticsTime", SatisticsTime);
            lstOtherColumn.Add(cl);
            cl = new OtherColumn("ChannelFlag", ChannelFlag);
            lstOtherColumn.Add(cl);
            cl = new OtherColumn("ReadFlag", ReadFlag);
            lstOtherColumn.Add(cl);
            cl = new OtherColumn("WriteFlag", WriteFlag);
            lstOtherColumn.Add(cl);
            cl = new OtherColumn("ChannelLinkFlag", ChannelLinkFlag);
            lstOtherColumn.Add(cl);
            cl = new OtherColumn("ChannelLinkUrl", "");
            lstOtherColumn.Add(cl);
            cl = new OtherColumn("LatestBBSTopicID", LatestBBSTopicID);
            lstOtherColumn.Add(cl);
            cl = new OtherColumn("LatestBBSTopicTitle", "");
            lstOtherColumn.Add(cl);
            cl = new OtherColumn("LatestBBSTopicUserID", LatestBBSTopicUserID);
            lstOtherColumn.Add(cl);
            cl = new OtherColumn("LatestBBSTopicUserName", "");
            lstOtherColumn.Add(cl);
            cl = new OtherColumn("LatestBBSTopicRepliedTime", LatestBBSTopicRepliedTime);
            lstOtherColumn.Add(cl);
            cl = new OtherColumn("CompanyID", CompanyID);
            lstOtherColumn.Add(cl);
            cl = new OtherColumn("ParentID", drpPatentID.SelectedValue);
            lstOtherColumn.Add(cl);

            EbSite.Modules.BBS.ModuleCore.BLL.Channels.Instance.SaveEntityFromCtr(phCtrList, lstOtherColumn);
            base.ColseGreyBox(true);
        }
    }
}