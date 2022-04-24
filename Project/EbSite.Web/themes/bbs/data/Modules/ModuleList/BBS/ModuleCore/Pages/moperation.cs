using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using EbSite.Base.Page;
using EbSite.Entity;

namespace EbSite.Modules.BBS.ModuleCore.Pages
{
    public class moperation : EbSite.Base.Page.BasePage
    {

        protected global::System.Web.UI.WebControls.Button btnSavePost;
        protected global::System.Web.UI.WebControls.Button btnDel;
        protected global::System.Web.UI.WebControls.Button btnMovePost;
        protected global::System.Web.UI.WebControls.RadioButtonList rblTop;
        protected global::System.Web.UI.WebControls.ListBox lstbPostLab;
        protected global::System.Web.UI.WebControls.RadioButtonList rbllTitleFont;
        protected global::EbSite.Control.ColorPicker cpTitleColor;
        protected global::EbSite.ControlData.SelectClass selClass;
        protected global::System.Web.UI.WebControls.CheckBox isUpdatePostTime;
        
        private int ClassID
        {
            get
            {
                if (!string.IsNullOrEmpty(Request["cid"]))
                {
                    int.Parse(Request["cid"]);
                }
                return 0;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (UserID > 0 && Comm.IsHaveLimit(ClassID))
            {
                Page.Title = "管理帖子";
               
                if (!IsPostBack)
                {
                    //ViewState["AbsolutePath"] = Request.UrlReferrer.AbsolutePath;
                    
                }
            }
            else
            {
                Tips("您没有操作权限","您没有登录或没有管理帖子权限！",HostApi.LoginRw);
            }
            btnSavePost.Click += new EventHandler(btnSavePost_Click);
            btnDel.Click += new EventHandler(btnDel_Click);
            btnMovePost.Click += new EventHandler(btnMovePost_Click);
        }
        protected string GetNav(string Nav, bool IsAddIndex)
        {
            EbSite.Entity.Sites md = EbSite.Base.Host.Instance.CurrentSite;
            return string.Format("<a href=\"{0}/\">{1}</a>-管理帖子&nbsp;&nbsp;[<a href=\"javascript:history.go(-1)\">返回</a>]", md.SiteFolder, md.SiteName);
        }
        override protected string GetNav(string Nav, bool IsAddIndex, int FilterClassID)
        {
            EbSite.Entity.Sites md = EbSite.Base.Host.Instance.CurrentSite;
            return string.Format("<a href=\"{0}/\">{1}</a>-管理帖子&nbsp;&nbsp;[<a href=\"javascript:history.go(-1)\">返回</a>]", md.SiteFolder, md.SiteName);
        }

        protected void btnMovePost_Click(object sender, EventArgs e)
        {

            string sPostID = Request["postid"];
            if (!string.IsNullOrEmpty(sPostID))
            {
                int newClassID = Core.Utils.StrToInt(selClass.Value, 0);
                string sClassName = EbSite.BLL.NewsClass.GetModel(newClassID).ClassName;
                string[] aPostID = sPostID.Split(',');
                foreach (string s in aPostID)
                {
                    int contentID = int.Parse(s);


                    EbSite.Entity.NewsContent md = EbSite.Base.AppStartInit.GetNewsContentInst(ClassID).GetModel(contentID,GetSiteID);
                    md.ClassID = newClassID;
                    md.ClassName = sClassName;
                    if (isUpdatePostTime.Checked)
                    {
                        md.AddTime = DateTime.Now;
                    }
                    EbSite.Base.AppStartInit.GetNewsContentInst(newClassID).Update(md); 
                }

                Response.Redirect(HostApi.GetClassHref(newClassID,1));

            }

        }

        protected void btnDel_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request["postid"]) && !string.IsNullOrEmpty(Request["cid"])) 
            {

                string sCids = Request["cid"];

                string sPostID = Request["postid"];
                if (!string.IsNullOrEmpty(sPostID))
                {
                    string[] aPostID = sPostID.Split(',');
                    foreach (string s in aPostID)
                    {
                        EbSite.Base.AppStartInit.GetNewsContentInst(ClassID).Delete(s);
                    }
                    
                }


                Tips("操作成功", "帖子删除成功!", HostApi.GetClassHref(int.Parse(sCids), 1));
            }
        }

        protected void btnSavePost_Click(object sender, EventArgs e)
        {

            if (!string.IsNullOrEmpty(Request["postid"]) && !string.IsNullOrEmpty(Request["cid"])) //回复
            {
                string sCids = Request["cid"];
                string sPostID = Request["postid"];
                int SetTop = Core.Utils.StrToInt(rblTop.SelectedValue,-1);
                int PostLab = Core.Utils.StrToInt(lstbPostLab.SelectedValue,-1);
                int iTitleFont = Core.Utils.StrToInt(rbllTitleFont.SelectedValue,-1);
                string sTitleColor = cpTitleColor.Color;

                if (!string.IsNullOrEmpty(sPostID))
                {
                    BLL.TopicReplies.Instance.UpdatePost(SetTop, PostLab, iTitleFont, sTitleColor, sPostID, UserID, UserNiName, ClassID);
                }
                Tips("操作成功", "帖子操作成功!", HostApi.GetClassHref(int.Parse(sCids), 1));
            }
           
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