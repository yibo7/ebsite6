using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.BLL;
using EbSite.Base.Modules;


namespace EbSite.Modules.BBS.UserPages.Controls.BBS
{
    public partial class BBS_hf : MPUCBaseSaveForUser
    {
        public override string Permission
        {
            get
            {
                return "2";
            }
        }
        override protected string KeyColumnName
        {
            get
            {
                return "ReplyID";
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {

            }
        }
        override protected void InitModifyCtr()
        {
            ModuleCore.BLL.TopicReplies.Instance.InitModifyCtr(SID, phCtrList);
        }


        override protected void SaveModel()
        {
            if (string.IsNullOrEmpty(ebReplyContent.Text))
            {
                base.ShowTipsPop("请输入内容!");
            }
            else
            {
                string num = Request.QueryString["num"];
                string tId = Request.QueryString["tId"];
                string rId = Request.QueryString["rId"];
                string ReferenceFlag = "";
                string ReferenceContent = "";
                string ReplyContent = "";
                if (!string.IsNullOrEmpty(num) && !string.IsNullOrEmpty(rId
                                                       ))
                {
                    ModuleCore.Entity.TopicReplies bbstr = ModuleCore.BLL.TopicReplies.Instance.GetEntity(int.Parse(rId));
                    if (bbstr.ReferenceFlag == 0)
                    {
                        //ReferenceFlag = rId;
                        //ReferenceContent = "<div class='reBorder'><span class='reUser'>" + bbstr.UserName +
                        //                   "</span>&nbsp;说：<p class='reContent'>" + bbstr.ReplyContent +
                        //                   "</p></div> <span class='reUser'>" + UserRealname +
                        //                   "</span>&nbsp;说：<p class='reContent'>" + ebReplyContent.Text + "</p>";
                        //ReplyContent = "<div class='reBorder'><span class='reUser'>" + bbstr.UserName +
                        //               "</span>&nbsp;说：<p class='reContent'>" + bbstr.ReplyContent +
                        //               "</p></div> <span class='reUser'>" + UserRealname +
                        //               "</span><p class='reContent'>" + ebReplyContent.Text + "</p>";
                    }
                    else
                    {
                        //ReferenceFlag = rId;
                        //ReferenceContent = "<div class='reBorder'>" + bbstr.ReferenceContent +
                        //                   "</div> <span class='reUser'>" + UserRealname +
                        //                   "</span>&nbsp;说：<p class='reContent'>" + ebReplyContent.Text + "</p>";
                        //ReplyContent = "<div class='reBorder'>" + bbstr.ReferenceContent + "</div><span class='reUser'>" +
                        //               UserRealname + "</span><p class='reContent'>" + ebReplyContent.Text + "</p>";
                    }
                }
                else
                {
                    ReferenceFlag = "0";
                    ReferenceContent = "";
                    ReplyContent = ebReplyContent.Text;
                }
                Base.BLL.OtherColumn cl = new OtherColumn("TopicID", tId);
                lstOtherColumn.Add(cl);
                cl = new OtherColumn("UserID", UserID.ToString());
                lstOtherColumn.Add(cl);
                cl = new OtherColumn("ReplyContent", ReplyContent);
                lstOtherColumn.Add(cl);
                //cl = new OtherColumn("UserName", UserRealname);
                //lstOtherColumn.Add(cl);
                cl = new OtherColumn("IsGoodCount", Convert.ToString(0));
                lstOtherColumn.Add(cl);
                cl = new OtherColumn("IsBadCount", Convert.ToString(0));
                lstOtherColumn.Add(cl);
                cl = new OtherColumn("DeleteFlag", Convert.ToString(0));
                lstOtherColumn.Add(cl);
                cl = new OtherColumn("AuditFlag", Convert.ToString(0));
                lstOtherColumn.Add(cl);
                cl = new OtherColumn("ReferenceFlag", ReferenceFlag);
                lstOtherColumn.Add(cl);
                cl = new OtherColumn("ReferenceContent", ReferenceContent);
                lstOtherColumn.Add(cl);
                cl = new OtherColumn("CreatedTime", DateTime.Now.ToString());
                lstOtherColumn.Add(cl);
                cl = new OtherColumn("CreatedIP", Core.Utils.GetClientIP());
                lstOtherColumn.Add(cl);
                cl = new OtherColumn("UpdatedTime", DateTime.Now.ToString());
                lstOtherColumn.Add(cl);
                ModuleCore.BLL.TopicReplies.Instance.SaveEntityFromCtr(phCtrList, lstOtherColumn);
                HuiFuCount();
                SendMsg();
                base.ColseGreyBox(true);
            }
        }

        protected void HuiFuCount()
        {
            string tId = Request.QueryString["tId"];
            ModuleCore.Entity.Topics bbst = ModuleCore.BLL.Topics.Instance.GetEntity(int.Parse(tId));
            bbst.ReplyCount = bbst.ReplyCount + 1;
            ModuleCore.BLL.Topics.Instance.Update(bbst);
        } 
      
        protected void SendMsg()
        {
            string tId = Request.QueryString["tId"];
            ModuleCore.Entity.Topics bbst = ModuleCore.BLL.Topics.Instance.GetEntity(int.Parse(tId));
            //string sMsg = UserRealname + "回复了您发表的" + bbst.TopicTitle + "帖子,注意查看!";
            //Base.EntityAPI.username entityUsers = Base.Host.Instance.GetUser(int.Parse(bbst.UserID.ToString()));
            //base.SendMsg(sMsg, sMsg, entityUsers.Username, entityUsers.Realname,"系统消息","系统消息",false,"","");
        }
    }
}