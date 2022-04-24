using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.Modules;


namespace EbSite.Modules.BBS.AdminPages.Controls.BBS
{
    public partial class BBS_Topics_show : MPUCBaseShow<ModuleCore.Entity.Topics>
    {
        private int num = 0;
       // protected username users;
        protected string tpxx;
        protected int xx;
        protected int Rs;
        protected string ssid;
        protected string ppid;
        protected string channid;
        public override string Permission
        {
            get
            {
                return "8";
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
          limet();
            sTid();
            ssid = Request.QueryString["mid"];
            ppid = Request.QueryString["muid"];
            string sid = Request.QueryString["id"];
            string biaoshi = Request.QueryString["bs"];
            channid = Request.QueryString["ChannelId"];
            if (string.IsNullOrEmpty(biaoshi))
            {
                LiuLanCount();
                Response.Redirect("BBS.aspx?muid=" + ppid + "&mid=" + ssid + "&t=14&bs=1&id=" + sid);
            }
            if (!IsPostBack)
            {
                InitrpHF();
                Ts();
                InitTp();
            }
          //  users = Base.Host.Instance.GetUser(long.Parse(Model.UserID.ToString()));
            TbZ();
            //WinBox10.Href = "BBS.aspx?t=15&tId=" + Model.id+"&mid="+ModuleID;
            //WinBox89.Href = "BBS.aspx?t=13&id=" + Model.id + "&mid=" + ModuleID;
           
       
            if (Model.UserID == UserID)
            {
               // WinBox89.Visible = true;
                num = 1;
            }
            else
            {
               // WinBox89.Visible = false;
            }
            ModuleCore.Entity.ChannelMasters bbscm = ModuleCore.BLL.ChannelMasters.Instance.GetEntityByChannelId(int.Parse(Model.ChannelID.ToString()));
            if (bbscm != null)
            {
                if (UserID == bbscm.UserID)
                {
                    if (num == 0)
                    {
                       // WinBox5.Visible = true;
                    }
                    else
                    {
                     //   WinBox5.Visible = false;
                    }
                    lbSC.Visible = true;
                }
                else
                {
                   // WinBox5.Visible = false;
                    lbSC.Visible = false;
                }
            }
            else
            {
              //  WinBox5.Visible = false;
                lbSC.Visible = false;
            }
            GetTopicsCount();
        }

        protected string IsBZ(string uId)
        {
            ModuleCore.Entity.ChannelMasters bbsCm = ModuleCore.BLL.ChannelMasters.Instance.GetEntityByUId(int.Parse(uId));
            if (bbsCm != null)
            {
                return "<img class='left master' alt='论坛版主' src='../../../themes/Green/bbs/master.png'/>";
            }
            else
            {
                return "";
            }
        }

        protected void TbZ()
        {
            ModuleCore.Entity.ChannelMasters bbsCm = ModuleCore.BLL.ChannelMasters.Instance.GetEntityByUId(int.Parse(Model.UserID.ToString()));
            if (bbsCm != null)
            {
                lbBZ.Text = "<img class='left master' alt='论坛版主' src='../../../themes/Green/bbs/master.png'/>";
            }
            else
            {
                lbBZ.Text = "";
            }
        }
        protected void InitrpHF()
        {
            rpHF.DataSource = ModuleCore.BLL.TopicReplies.Instance.GetListArrayByTopicId(Model.id);
            rpHF.DataBind();
        }

        protected void Ts()
        {
            string num = Request.QueryString["num"];
            if (!string.IsNullOrEmpty(num))
            {
                base.ShowTipsPop("发表成功!");
            }
        }
        protected override void Delete()
        {
            ModuleCore.BLL.Topics.Instance.Delete(int.Parse(GetKeyID));
        }
        protected override ModuleCore.Entity.Topics LoadModel()
        {
            ModuleCore.Entity.Topics md = ModuleCore.BLL.Topics.Instance.GetEntity(int.Parse(GetKeyID));
            if (Equals(md, null)) md = new ModuleCore.Entity.Topics();//防止删除后的页面出错
            return md;
        }

        protected void btnFT_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty((ebHT.Text)))
            {
                base.ShowTipsPop("请输入内容!");
            }
            else
            {
                ModuleCore.Entity.TopicReplies bbstr = new ModuleCore.Entity.TopicReplies();
                bbstr.AuditFlag = 0;
                bbstr.CompanyID = Model.CompanyID;
                bbstr.CreatedIP = Core.Utils.GetClientIP();
                bbstr.CreatedTime = DateTime.Now;
                bbstr.DeleteFlag = 0;
                bbstr.IsBadCount = 0;
                bbstr.IsGoodCount = 0;
                bbstr.ReferenceContent = "";
                bbstr.ReferenceFlag = 0;
                bbstr.ReplyContent = ebHT.Text;
                bbstr.TopicID = Model.id;
                bbstr.UpdatedTime = DateTime.Now;
                bbstr.UserID = int.Parse(UserID.ToString());
                bbstr.UserName = UserName;
                bbstr.CompanyID = 0;
                ModuleCore.BLL.TopicReplies.Instance.Add(bbstr);
                HuiFuCount();
                InitrpHF();
                Ts();
                InitTp();
                ebHT.Text = "";
                SendMsg();
                //Response.Redirect("BBS.aspx?t=14&bs=1&num=1&id="+Model.TopicID);
            }
        }
        int l = 1;
        protected int Louc()
        {
            l = l + 1;
            return l;
        }

        //protected username GetUsers(string UId)
        //{
        //    return EbOA.Base.Host.Instance.GetUser(long.Parse(UId));
        //}

        protected string ifSc(string tId)
        {
            ModuleCore.Entity.Topics bbst = ModuleCore.BLL.Topics.Instance.GetEntity(int.Parse(tId));
            ModuleCore.Entity.ChannelMasters bbscm = ModuleCore.BLL.ChannelMasters.Instance.GetEntityByChannelId(int.Parse(bbst.ChannelID.ToString()));
            if (bbscm != null)
            {
                if (bbscm.UserID == UserID)
                {
                    return "删除";
                }
                else
                {
                    return "";
                }
            }
            else
            {
                return "";
            }
        }

        protected void btn_Click(object sender, EventArgs e)
        {
            string trId = Request.Form["hName"];
            ModuleCore.BLL.TopicReplies.Instance.Delete(int.Parse(trId));
            InitrpHF();
            base.ShowTipsPop("删除成功!");
        }

        protected void GetTopicsCount()
        {
            int AllTopics = ModuleCore.BLL.Topics.Instance.GetListArrayByUserId(Convert.ToString(UserID), "").Count;
            int GoodTopics = ModuleCore.BLL.Topics.Instance.GetListArrayByUserId(Convert.ToString(UserID), "GoodFlag").Count;
            lbAllTopic.Text = Convert.ToString(AllTopics);
            lbgoodTopic.Text = Convert.ToString(GoodTopics);
        }

        protected int GetTopicsCountByUid(string uId, string word)
        {
            return ModuleCore.BLL.Topics.Instance.GetListArrayByUserId(uId, word).Count;
        }

        protected void LiuLanCount()
        {
            ModuleCore.Entity.Topics bbst = ModuleCore.BLL.Topics.Instance.GetEntity(Model.id);
            bbst.ViewCount = bbst.ViewCount + 1;
            ModuleCore.BLL.Topics.Instance.Update(bbst);
        }

        protected void HuiFuCount()
        {
            ModuleCore.Entity.Topics bbst = ModuleCore.BLL.Topics.Instance.GetEntity(Model.id);
            bbst.ReplyCount = bbst.ReplyCount + 1;
            ModuleCore.BLL.Topics.Instance.Update(bbst);
        }

        protected void InitTp()
        {
            if (Model.tag == 0)
            {
                List<ModuleCore.Entity.Votes> bbsvList = ModuleCore.BLL.Votes.Instance.GetListArrayByTopicId(Model.id.ToString());
                if (bbsvList.Count > 0)
                {
                    ModuleCore.Entity.Votes bbsv = bbsvList[0];
                    ViewState["voteId"] = bbsv.id;
                    Rs = Convert.ToInt32(bbsv.VoteCount);
                    xx = int.Parse(bbsv.OptionFlag.ToString());
                    List<ModuleCore.Entity.VoteOptions> bbsvoList = ModuleCore.BLL.VoteOptions.Instance.GetListArrayByVoteId(bbsv.id.ToString());
                    gvXZ.DataSource = bbsvoList;
                    gvXZ.DataBind();
                    for (int i = 0; i < bbsvoList.Count; i++)
                    {
                        if (i < (bbsvoList.Count - 1))
                        {
                            tpxx = tpxx + "['" + bbsvoList[i].OptionName + "'," + Convert.ToString(bbsvoList[i].VoteCount) + "]" + ",";
                        }
                        else
                        {
                            tpxx = tpxx + "['" + bbsvoList[i].OptionName + "'," + Convert.ToString(bbsvoList[i].VoteCount) + "]";
                        }
                    }
                    divTp.Visible = true;
                }
            }
        }

        protected void lbTP_Click(object sender, EventArgs e)
        {
            int voteId = Convert.ToInt32(ViewState["voteId"]);
            List<ModuleCore.Entity.Voters> bbsvoers = ModuleCore.BLL.Voters.Instance.GetListArrayVoteID(voteId.ToString());
            bool b = false;
            for (int j = 0; j < bbsvoers.Count; j++)
            {
                if (bbsvoers[j].UserID == Convert.ToInt32(UserID))
                {
                    b = true;
                    break;
                }
            }

            if (b == true)
            {
                base.ShowTipsPop("您以投票!");
            }
            else
            {
                for (int i = 0; i < gvXZ.Rows.Count; i++)
                {
                    CheckBox cb = gvXZ.Rows[i].FindControl("cbXZ") as CheckBox;
                    if (cb.Checked)
                    {
                        string voId = (gvXZ.Rows[i].FindControl("lbId") as Label).Text;
                        ModuleCore.Entity.VoteOptions bbsv = ModuleCore.BLL.VoteOptions.Instance.GetEntity(int.Parse(voId));
                        bbsv.VoteCount = bbsv.VoteCount + 1;
                        ModuleCore.BLL.VoteOptions.Instance.Update(bbsv);
                    }
                }
                ModuleCore.Entity.Voters bbsver = new ModuleCore.Entity.Voters();
                bbsver.CompanyID = 0;
                bbsver.CreatedIP = Core.Utils.GetClientIP();
                bbsver.CreatedTime = DateTime.Now;
                bbsver.UserHeadImageUrl = "";
                bbsver.UserID = int.Parse(UserID.ToString());
                bbsver.UserName = UserName;
                bbsver.VoteContent = "";
                bbsver.VoteID = voteId;
                ModuleCore.BLL.Voters.Instance.Add(bbsver);
                ModuleCore.Entity.Votes bbsVotes = ModuleCore.BLL.Votes.Instance.GetEntity(voteId);
                bbsVotes.VoteCount = bbsVotes.VoteCount + 1;
                ModuleCore.BLL.Votes.Instance.Update(bbsVotes);
            }
            InitTp();
        }

        protected void lbSC_Click(object sender, EventArgs e)
        {
            string tId = lbSC.Attributes["ttid"];
            ModuleCore.BLL.Topics.Instance.Delete(int.Parse(tId));
        }

        protected void sTid()
        {
            lbSC.Attributes.Add("ttid", Model.id.ToString());
        }

        protected void SendMsg()
        {
            //string sMsg = UserRealname + "回复了您发表的" + Model.TopicTitle + "帖子,注意查看!";
            //username entityUsers = 
            //    Base.Host.Instance.GetUser(int.Parse(Model.UserID.ToString()));
            //base.SendMsg(sMsg, sMsg, entityUsers.Username, entityUsers.Realname, "系统消息", "系统消息", false, "", "");
        }


        protected void limet() {
            //if (Base.Host.Instance.IsHavePermission("20")) {
            //    ShowTipsPop("有权限");
            //}else{
            //    ShowTipsPop("没权限");
            //}
        }
    }
}