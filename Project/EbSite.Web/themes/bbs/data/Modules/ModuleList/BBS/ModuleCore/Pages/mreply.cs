using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using EbSite.Base.Page;
using EbSite.Entity;

namespace EbSite.Modules.BBS.ModuleCore.Pages
{
    public class mreply : EbSite.Base.Page.BasePage
    {

        protected global::System.Web.UI.WebControls.Button btnSavePost;
        protected global::EbSite.Control.UEditor edtContentInfo;
        protected global::System.Web.UI.WebControls.Literal llReference;
        protected global::System.Web.UI.WebControls.HiddenField hfRfUid;
        protected global::System.Web.UI.WebControls.HiddenField RePath;

        private int EditPostID
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
        private int PostID
        {
            get
            {
                if (!string.IsNullOrEmpty(Request["postid"]))
                {
                    return int.Parse(Request["postid"]);
                }
                return 0;
            }
        }
        private int RfPostID
        {
            get
            {
                if (!string.IsNullOrEmpty(Request["rfid"]))
                {
                    return int.Parse(Request["rfid"]);
                }
                return 0;
            }
        }
        private int ClassID
        {
            get
            {
                if (!string.IsNullOrEmpty(Request["cid"]))
                {
                    return int.Parse(Request["cid"]);
                }
                return 0;
            }
        }
        private bool IsReSendEmail
        {
            get
            {
                int _IsReSendEmail = 0;
                if (!string.IsNullOrEmpty(Request["rs"]))
                {
                    _IsReSendEmail = int.Parse(Request["rs"]);
                }
                return (_IsReSendEmail==1);
            }
        }
        private int PostUserID
        {
            get
            {
                if (!string.IsNullOrEmpty(Request["puid"]))
                {
                    return int.Parse(Request["puid"]);
                }
                return 0;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if(UserID>0)
            {
                Page.Title = "编辑帖子";
                btnSavePost.Click += new EventHandler(btnSavePost_Click);
                if (!IsPostBack)
                {
                    if (EditPostID>0) //编辑
                    {
                        Entity.TopicReplies md = ModuleCore.BLL.TopicReplies.Instance.GetEntity(long.Parse(Request["id"]), ClassID);

                        bool IsAllowEdit = false;
                        if (Comm.IsHaveLimit(ClassID))
                        {
                            IsAllowEdit = true;
                        }
                        else
                        {
                            if (md.UserID == UserID)
                            {
                                IsAllowEdit = true;
                            }
                        }

                        if (!IsAllowEdit)
                        {
                            Tips("没有权限", "您没有编辑帖子的权限！");
                            return;
                        }
                        
                        edtContentInfo.CtrValue = md.ReplyContent;
                        RePath.Value = Request.UrlReferrer.AbsolutePath;
                        //ViewState["postuid"] = md.UserID;
                    }

                    if (PostID > 0 && RfPostID>0) //引用
                    {

                        //int iReferenceContentID = Core.Utils.StrToInt(Request["rfid"], 0);
                        ModuleCore.Entity.TopicReplies mdReferenceContent = BLL.TopicReplies.Instance.GetEntity(RfPostID, ClassID);
                        string sReference =Core.Strings.GetString.ClearHtml(mdReferenceContent.ReplyContent) ;//Core.Strings.GetString.NoUbb(mdReferenceContent.ReplyContent);
                        sReference = Core.Strings.GetString.CutLenEnd(sReference, 150);
                        llReference.Text = sReference;

                        hfRfUid.Value = mdReferenceContent.UserID.ToString();
                    }

                }
            }
            else
            {
                Tips("您没有登录","请登录后再访问此页面！",HostApi.LoginRw);
            }
            
        }
        protected string GetNav(string Nav, bool IsAddIndex)
        {
            EbSite.Entity.Sites md = EbSite.Base.Host.Instance.CurrentSite;
            return string.Format("<a href=\"{0}/\">{1}</a>-发表回复&nbsp;&nbsp;[<a href=\"javascript:history.go(-1)\">返回</a>]", md.SiteFolder, md.SiteName);
        }
        override protected string GetNav(string Nav, bool IsAddIndex, int FilterClassID)
        {
            EbSite.Entity.Sites md =  EbSite.Base.Host.Instance.CurrentSite;
            return string.Format("<a href=\"{0}/\">{1}</a>-发表回复&nbsp;&nbsp;[<a href=\"javascript:history.go(-1)\">返回</a>]", md.SiteFolder, md.SiteName);
        }
        protected void btnSavePost_Click(object sender, EventArgs e)
        {
            Session["isupdatecahe"] = true;//在静态缓存时可以及时更新
            if (EditPostID == 0)
            {
                //int ipostid = Core.Utils.StrToInt(Request["postid"], 0);
                string sContent = edtContentInfo.CtrValue;
                string ReferenceContent = string.Empty;
                int icount = Core.Utils.StrToInt(Request["count"], 0);
                int PageSize = Core.Utils.StrToInt(Request["endindex"], 0);
                if (!string.IsNullOrEmpty(Request["rfid"])) //引用
                {
                    ReferenceContent = llReference.Text;

                }
                int iendindex = getEndPageIndex(icount, PageSize);
                bool isok = false;
                string url = ModuleCore.BLL.TopicReplies.Instance.AddHf(PostID, sContent, ReferenceContent, icount, GetSiteID, iendindex, out isok, ClassID);

                if (isok)
                {
                    #region 发送邮件通知

                    //string postuid = ViewState["postuid"] as string;
                    if (IsReSendEmail)
                    {
                        if (PostUserID > 0 && PostUserID != UserID)
                        {
                            string Purl = string.Format("http://{0}/{1}", Request.Url.Authority, url);

                            HostApi.SendEmailPoolByUserID(PostUserID, string.Format("{0}回复了您在{1}的帖子", UserNiName, SiteName), string.Format("您在{0}的帖子,由{1}在{2}时回复,邀请您及时关注回应，<a target=\"_blank\" href=\"{3}\">点这里去看看</a>！", SiteName, UserNiName, DateTime.Now, Purl));
                        }

                    }

                    if (RfPostID > 0) //引用
                    {

                        if (!string.IsNullOrEmpty(hfRfUid.Value))
                        {
                            string Purl = string.Format("http://{0}/{1}", Request.Url.Authority, url);
                            int irfuid = int.Parse(hfRfUid.Value);
                            HostApi.SendEmailPoolByUserID(irfuid, string.Format("有人回复了您的帖子:{0}", ReferenceContent), string.Format("您在{0}的帖子《{1}》,由{2}在{3}时回复,邀请您及时关注回应，<a target=\"_blank\" href=\"{4}\">点这里去看看</a>！", SiteName, ReferenceContent, UserNiName, DateTime.Now, Purl));
                        }
                    }

                    #endregion
                }
                
                

               //Log.Factory.GetInstance().InfoLog(url);
                Response.Redirect(url);


            }
            else
            {
                ModuleCore.BLL.TopicReplies.Instance.EditeReply(EditPostID, edtContentInfo.CtrValue, ClassID);
                Tips("帖子编辑成功", "恭喜,帖子编辑成功", RePath.Value);
            }
            
        }
        private int getEndPageIndex(int pAllCount, int pPageSize)
        {
            var iPageIndex = 1;
            if (pAllCount <= 0 || pPageSize <= 0)
            {
                iPageIndex = 1;
            }
            else
            {
                iPageIndex = ((pAllCount + 1 + pPageSize) - 1) / pPageSize;
            }
            return iPageIndex;

        }

        #region 解决重写url后，保持postback地址不改变的问题

        //// <summary>
        ///  重写默认的HtmlTextWriter方法，修改form标记中的value属性，使其值为重写的URL而不是真实URL。
        /// </summary>
        /// <param name="writer"></param>
        protected override void Render(HtmlTextWriter writer)
        {
            if (writer is System.Web.UI.Html32TextWriter)
            {
                writer = new FormFixerHtml32TextWriter(writer.InnerWriter);
            }
            else
            {
                writer = new FormFixerHtmlTextWriter(writer.InnerWriter);
            }

            base.Render(writer);
        }
        #endregion
    }
}