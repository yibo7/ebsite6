using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.BLL;
using EbSite.Base.Modules;


namespace EbSite.Modules.BBS.AdminPages.Controls.BBS
{
    public partial class BBS_Topics_add : MPUCBaseSave
    {
        protected int mm = 0;
        protected int num = 0;
        protected string GetBkId
        {
            get
            {
                return Request.QueryString["bkId"];
            }
        }
        public override string Permission
        {
            get
            {
                return "29";
            }
        }
        override protected string KeyColumnName
        {
            get
            {
                return "TopicID";
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (string.IsNullOrEmpty(SID))
                {

                    gdxz.Items[0].Selected = true;
                }
            }
            IfTp();
        }
        override protected void InitModifyCtr()
        {
            if (!string.IsNullOrEmpty(SID))
            {

            }
            ModuleCore.BLL.Topics.Instance.InitModifyCtr(SID, phCtrList);
            ModuleCore.Entity.Topics bbst = ModuleCore.BLL.Topics.Instance.GetEntity(int.Parse(SID));
            if (bbst.TitleBoldFlag == 1)
            {
                cbBTJC.Checked = true;
            }
            else if (bbst.TitleBoldFlag == 0)
            {
                cbBTJC.Checked = false;
            }

            if (bbst.TitleColorFlag == 1)
            {
                cbBTBS.Checked = true;
                cpYS.Color = bbst.TitleColorCode;
            }
            else if (bbst.TitleColorFlag == 0)
            {
                cbBTBS.Checked = false;
            }
        }


        override protected void SaveModel()
        {
            string ViewCount = "", ReplyCount = "", OrderTopFla = "", OrderTopTime = "", OrderTopMasterUserID = "",
            OrderTopMasterUserName = "", RecommendFlag = "", RecommendTime = "", RecommendMasterUserID = "",
            RecommendMasterUserName = "", ReplyStatusFlag = "", ModifyStatusFlag = "", HasImageFlag = "",
            TopicImageUrl = "", IsBadCount = "", IsGoodCount = "", ConclusionFlag = "",
            AuditFlag = "", LatestReplyUserID = "", LatestReplyUserName = "", LatestRepliedTime = "",
            GoodFlag = "", GoodTime = "", GoodDescription = "", GoodImageUrl = "",
            GoodMasterUserID = "", GoodMasterUserName = "", SiteOrderTopFlag = "", SiteOrderTopTime = "",
            SiteOrderTopMasterUserID = "", SiteOrderTopMasterUserName = "", TopicFlag = "", ReferenceID = "",
            DeleteFlag = "", CreatedTime = "", CreatedIP = "", TopicDescription = "",
            TitleBoldFlag = "", TitleBoldTime = "", TitleColorFlag = "", TitleColorCode = "",
            TitleColorTime = "", CompanyID = "", tag = "";
            if (string.IsNullOrEmpty(SID))
            {
                ViewCount = "0"; ReplyCount = "0"; OrderTopFla = "0"; OrderTopTime = DateTime.Now.ToString(); OrderTopMasterUserID = "0";
                OrderTopMasterUserName = ""; RecommendFlag = "0"; RecommendTime = DateTime.Now.ToString(); RecommendMasterUserID = "0";
                RecommendMasterUserName = ""; ReplyStatusFlag = "0"; ModifyStatusFlag = "0"; HasImageFlag = "0";
                TopicImageUrl = ""; IsBadCount = "0"; IsGoodCount = "0"; ConclusionFlag = "0";
                AuditFlag = "0"; LatestReplyUserID = "0"; LatestReplyUserName = ""; LatestRepliedTime = DateTime.Now.ToString();
                GoodFlag = "0"; GoodTime = DateTime.Now.ToString(); GoodDescription = ""; GoodImageUrl = "";
                tag = "0";
                GoodMasterUserID = "0"; GoodMasterUserName = ""; SiteOrderTopFlag = "0"; SiteOrderTopTime = DateTime.Now.ToString();
                SiteOrderTopMasterUserID = "0"; SiteOrderTopMasterUserName = ""; TopicFlag = "0"; ReferenceID = "0";
                DeleteFlag = "0"; CreatedTime = DateTime.Now.ToString(); CreatedIP = Core.Utils.GetClientIP(); TopicDescription = "";
                TitleBoldTime = DateTime.Now.ToString();
                TitleColorTime = DateTime.Now.ToString(); CompanyID = "0";
            }
            else
            {
                ModuleCore.Entity.Topics bbst = ModuleCore.BLL.Topics.Instance.GetEntity(int.Parse(SID));
                ViewCount = Convert.ToString(bbst.ViewCount); ReplyCount = Convert.ToString(bbst.ReplyCount); OrderTopFla = Convert.ToString(bbst.OrderTopFlag); OrderTopTime = Convert.ToString(bbst.OrderTopTime); OrderTopMasterUserID = Convert.ToString(bbst.OrderTopMasterUserID);
                OrderTopMasterUserName = bbst.OrderTopMasterUserName; RecommendFlag = Convert.ToString(bbst.RecommendFlag); RecommendTime = bbst.RecommendTime.ToString(); RecommendMasterUserID = Convert.ToString(bbst.RecommendMasterUserID);
                RecommendMasterUserName = bbst.RecommendMasterUserName; ReplyStatusFlag = Convert.ToString(bbst.ReplyStatusFlag); ModifyStatusFlag = Convert.ToString(bbst.ModifyStatusFlag); HasImageFlag = Convert.ToString(bbst.HasImageFlag);
                TopicImageUrl = bbst.TopicImageUrl; IsBadCount = Convert.ToString(bbst.IsBadCount); IsGoodCount = Convert.ToString(bbst.IsGoodCount); ConclusionFlag = Convert.ToString(bbst.ConclusionFlag);
                AuditFlag = Convert.ToString(bbst.AuditFlag); LatestReplyUserID = Convert.ToString(bbst.LatestReplyUserID); LatestReplyUserName = bbst.LatestReplyUserName; LatestRepliedTime = Convert.ToString(bbst.LatestRepliedTime);
                GoodFlag = Convert.ToString(bbst.GoodFlag); GoodTime = bbst.GoodTime.ToString(); GoodDescription = bbst.GoodDescription; GoodImageUrl = bbst.GoodImageUrl;
                GoodMasterUserID = Convert.ToString(bbst.GoodMasterUserID); GoodMasterUserName = bbst.GoodMasterUserName; SiteOrderTopFlag = Convert.ToString(bbst.SiteOrderTopFlag); SiteOrderTopTime = bbst.SiteOrderTopTime.ToString();
                SiteOrderTopMasterUserID = Convert.ToString(bbst.SiteOrderTopMasterUserID); SiteOrderTopMasterUserName = bbst.SiteOrderTopMasterUserName; TopicFlag = Convert.ToString(bbst.TopicFlag); ReferenceID = Convert.ToString(bbst.ReferenceID);
                DeleteFlag = Convert.ToString(bbst.DeleteFlag); CreatedTime = bbst.CreatedTime.ToString(); CreatedIP = bbst.CreatedIP; TopicDescription = bbst.TopicDescription;
                TitleBoldTime = bbst.TitleBoldTime.ToString();
                tag = Convert.ToString(bbst.tag);
                TitleColorTime = bbst.TitleColorTime.ToString(); CompanyID = Convert.ToString(bbst.CompanyID);
            }

            if (cbBTJC.Checked)
            {
                TitleBoldFlag = "1";
            }
            else
            {
                TitleBoldFlag = "0";
            }

            if (cbBTBS.Checked)
            {
                TitleColorFlag = "1";
                TitleColorCode = cpYS.Color;
            }
            else
            {
                TitleColorFlag = "0";
                TitleColorCode = "";
            }

            string channelID = "";
            string chnnelName = "";
            if (!string.IsNullOrEmpty(GetBkId))
            {
                ModuleCore.Entity.Channels bbsChannels = ModuleCore.BLL.Channels.Instance.GetEntity(int.Parse(GetBkId));
                channelID = bbsChannels.id.ToString();
                chnnelName = bbsChannels.ChannelName;
            }
            else
            {
                ModuleCore.Entity.Topics bbst = ModuleCore.BLL.Topics.Instance.GetEntity(int.Parse(SID));
                channelID = bbst.ChannelID.ToString();
                chnnelName = bbst.ChannelName;
            }
            Base.BLL.OtherColumn cl = new OtherColumn("ChannelID", channelID);
            lstOtherColumn.Add(cl);
            cl = new OtherColumn("ChannelName", chnnelName);
            lstOtherColumn.Add(cl);
            cl = new OtherColumn("TopicDescription", TopicDescription);
            lstOtherColumn.Add(cl);
            cl = new OtherColumn("ViewCount", ViewCount);
            lstOtherColumn.Add(cl);
            cl = new OtherColumn("ReplyCount", ReplyCount);
            lstOtherColumn.Add(cl);
            cl = new OtherColumn("UserID", UserID.ToString());
            lstOtherColumn.Add(cl);
            //cl = new OtherColumn("UserName", UserRealname);
            //lstOtherColumn.Add(cl);
            cl = new OtherColumn("OrderTopFlag", OrderTopFla);
            lstOtherColumn.Add(cl);
            cl = new OtherColumn("OrderTopTime", OrderTopTime);
            lstOtherColumn.Add(cl);
            cl = new OtherColumn("OrderTopMasterUserID", OrderTopMasterUserID);
            lstOtherColumn.Add(cl);
            cl = new OtherColumn("OrderTopMasterUserName", OrderTopMasterUserName);
            lstOtherColumn.Add(cl);
            cl = new OtherColumn("RecommendFlag", RecommendFlag);
            lstOtherColumn.Add(cl);
            cl = new OtherColumn("RecommendTime", RecommendTime);
            lstOtherColumn.Add(cl);
            cl = new OtherColumn("RecommendMasterUserID", RecommendMasterUserID);
            lstOtherColumn.Add(cl);
            cl = new OtherColumn("RecommendMasterUserName", RecommendMasterUserName);
            lstOtherColumn.Add(cl);
            cl = new OtherColumn("ReplyStatusFlag", ReplyStatusFlag);
            lstOtherColumn.Add(cl);
            cl = new OtherColumn("ModifyStatusFlag", ModifyStatusFlag);
            lstOtherColumn.Add(cl);
            cl = new OtherColumn("HasImageFlag", HasImageFlag);
            lstOtherColumn.Add(cl);
            cl = new OtherColumn("TopicImageUrl", TopicImageUrl);
            lstOtherColumn.Add(cl);
            cl = new OtherColumn("IsBadCount", IsBadCount);
            lstOtherColumn.Add(cl);
            cl = new OtherColumn("IsGoodCount", IsGoodCount);
            lstOtherColumn.Add(cl);
            cl = new OtherColumn("ConclusionFlag", ConclusionFlag);
            lstOtherColumn.Add(cl);
            cl = new OtherColumn("AuditFlag", AuditFlag);
            lstOtherColumn.Add(cl);
            cl = new OtherColumn("LatestReplyUserID", LatestReplyUserID);
            lstOtherColumn.Add(cl);
            cl = new OtherColumn("LatestReplyUserName", LatestReplyUserName);
            lstOtherColumn.Add(cl);
            cl = new OtherColumn("LatestRepliedTime", LatestRepliedTime);
            lstOtherColumn.Add(cl);
            cl = new OtherColumn("GoodFlag", GoodFlag);
            lstOtherColumn.Add(cl);
            cl = new OtherColumn("GoodTime", GoodTime);
            lstOtherColumn.Add(cl);
            cl = new OtherColumn("GoodDescription", GoodDescription);
            lstOtherColumn.Add(cl);
            cl = new OtherColumn("GoodImageUrl", GoodImageUrl);
            lstOtherColumn.Add(cl);
            cl = new OtherColumn("GoodMasterUserID", GoodMasterUserID);
            lstOtherColumn.Add(cl);
            cl = new OtherColumn("GoodMasterUserName", GoodMasterUserName);
            lstOtherColumn.Add(cl);
            cl = new OtherColumn("SiteOrderTopFlag", SiteOrderTopFlag);
            lstOtherColumn.Add(cl);
            cl = new OtherColumn("SiteOrderTopTime", SiteOrderTopTime);
            lstOtherColumn.Add(cl);
            cl = new OtherColumn("SiteOrderTopMasterUserID", SiteOrderTopMasterUserID);
            lstOtherColumn.Add(cl);
            cl = new OtherColumn("SiteOrderTopMasterUserName", SiteOrderTopMasterUserName);
            lstOtherColumn.Add(cl);
            cl = new OtherColumn("TopicFlag", TopicFlag);
            lstOtherColumn.Add(cl);
            cl = new OtherColumn("ReferenceID", ReferenceID);
            lstOtherColumn.Add(cl);
            cl = new OtherColumn("DeleteFlag", DeleteFlag);
            lstOtherColumn.Add(cl);
            cl = new OtherColumn("CreatedTime", CreatedTime);
            lstOtherColumn.Add(cl);
            cl = new OtherColumn("CreatedIP", CreatedIP);
            lstOtherColumn.Add(cl);
            cl = new OtherColumn("UpdatedTime", DateTime.Now.ToString());
            lstOtherColumn.Add(cl);
            cl = new OtherColumn("TitleBoldFlag", TitleBoldFlag);
            lstOtherColumn.Add(cl);
            cl = new OtherColumn("TitleBoldTime", TitleBoldTime);
            lstOtherColumn.Add(cl);
            cl = new OtherColumn("TitleColorFlag", TitleColorFlag);
            lstOtherColumn.Add(cl);
            cl = new OtherColumn("TitleColorCode", TitleColorCode);
            lstOtherColumn.Add(cl);
            cl = new OtherColumn("TitleColorTime", TitleColorTime);
            lstOtherColumn.Add(cl);
            cl = new OtherColumn("CompanyID", CompanyID);
            lstOtherColumn.Add(cl);
            cl = new OtherColumn("tag", tag);
            lstOtherColumn.Add(cl);
            long tId = ModuleCore.BLL.Topics.Instance.SaveEntityFromCtr(phCtrList, lstOtherColumn);
            string[] tpArray = hf.Value.Split(',');
            if (cb.Checked)
            {
                ModuleCore.Entity.Votes bbsv = new ModuleCore.Entity.Votes();
                bbsv.CompanyID = 0;
                bbsv.CreatedIP = Core.Utils.GetClientIP();
                bbsv.CreatedTime = DateTime.Now;
                bbsv.UserHeadImageUrl = "";
                bbsv.UserID = int.Parse(UserID.ToString());
                bbsv.UserName = UserName;
                bbsv.BBSTopicID = tId;
                bbsv.ExpiredTime = DateTime.Now;
                bbsv.LockFlag = 0;
                bbsv.OptionCount = 0;
                if (gdxz.Items[0].Selected)
                {
                    bbsv.OptionFlag = 0;
                }
                else if (gdxz.Items[1].Selected)
                {
                    bbsv.OptionFlag = 1;
                }
                bbsv.UpdatedTime = DateTime.Now;
                bbsv.VoteConclusion = "";
                bbsv.VoteCount = 0;
                bbsv.VoteDescription = "";
                bbsv.VoteName = TopicTitle.Text.Trim();
                int vId = ModuleCore.BLL.Votes.Instance.Add(bbsv);
                ModuleCore.Entity.VoteOptions bbsvo = new ModuleCore.Entity.VoteOptions();
                for (int i = 0; i < tpArray.Length; i++)
                {
                    bbsvo.CompanyID = 0;
                    bbsvo.CreatedTime = DateTime.Now;
                    bbsvo.OptionName = tpArray[i];
                    bbsvo.VoteCount = 0;
                    bbsvo.VotePercent = Convert.ToDecimal(0);
                    bbsvo.VoteID = vId;
                    ModuleCore.BLL.VoteOptions.Instance.Add(bbsvo);
                }
            }
            if (!string.IsNullOrEmpty(GetBkId))
            {
                base.ShowTipsPop("发表成功!");
            }
            else
            {
                base.ShowTipsPop("修改成功!");
            }
            num = 1;
        }

        private void IfTp()
        {
            int k = 0;
            List<ModuleCore.Entity.Topics> bbstList = ModuleCore.BLL.Topics.Instance.GetListArray("");
            if (bbstList.Count == 0)
            {
                mm = 1;
                divTP.Visible = false;
            }
            else
            {
                for (int i = 0; i < bbstList.Count; i++)
                {
                    if (bbstList[i].tag == 1)
                    {
                        k = k + 1;
                    }
                }

                if (k == bbstList.Count)
                {
                    mm = 1;
                    divTP.Visible = false;
                }
                else
                {
                    divTP.Visible = true;
                }
            }
        }
    }
}