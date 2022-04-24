using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using EbSite.Base.Page;
using EbSite.BLL;
using EbSite.Entity;
using EbSite.Modules.BBS.ModuleCore.BLL;

namespace EbSite.Modules.BBS.ModuleCore.Pages
{
    public class msavepost : EbSite.Base.Page.BasePage
    {

        protected global::System.Web.UI.WebControls.TextBox txtposttitle;
        protected global::System.Web.UI.WebControls.TextBox txtTags;
        
        protected global::System.Web.UI.WebControls.Button btnSavePost;
        protected global::System.Web.UI.WebControls.CheckBox cbIsReToSendEmail; 
        protected global::EbSite.Control.UEditor edtContentInfo;
        protected EbSite.Entity.NewsClass Model
        {
            get
            {
                if (!string.IsNullOrEmpty(Request["cid"]))
                {
                    return EbSite.BLL.NewsClass.GetModelByCache(Core.Utils.StrToInt(Request["cid"], 0));
                }
                return null;
            }
        }
        private int PostID
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

        virtual protected string GoToLogin
        {
            get { return HostApi.LoginRw; }
        }
        private EbSite.Entity.NewsClass mdClass;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (UserID > 0)
            {
                Page.Title = "保存主题";
                btnSavePost.Click += new EventHandler(btnSavePost_Click);
                mdClass = EbSite.BLL.NewsClass.GetModelByCache(ClassID);
                if (!IsPostBack)
                {

                      
                    bool _IsCanAddContent = EbSite.BLL.ClassConfigs.Instance.GetIsCanAddContent(ClassID);
                    if (_IsCanAddContent)
                    {
                        if (PostID > 0) //修改
                        {
                             
                            EbSite.Entity.NewsContent md = EbSite.Base.AppStartInit.GetNewsContentInst(ClassID).GetModelByCache(PostID, GetSiteID);
                            txtposttitle.Text = md.NewsTitle;
                            edtContentInfo.Text = md.ContentInfo;
                            if (!Equals(txtTags, null))
                            {
                                txtTags.Text = md.TagIDs;
                            }
                            
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
                            if (!Equals(Request.UrlReferrer, null))
                            {
                                ViewState["AbsolutePath"] = Request.UrlReferrer.AbsolutePath;
                            }
                            else
                            {
                                ViewState["AbsolutePath"] = HostApi.GetContentLink(ClassID, GetSiteID);
                            }

                            if (!Equals(cbIsReToSendEmail, null))
                            {
                                cbIsReToSendEmail.Checked = (md.Annex21 == 1);
                            }
                        }
                        if (!Equals(cbIsReToSendEmail, null))
                        {
                            cbIsReToSendEmail.Checked = true;
                        }
                        Session["isupdatecahe"] = true;//在静态缓存时可以及时更新

                    }
                    else
                    {
                        Tips("不可以发表帖子", "当前版块不可以发表帖子！");
                    }

                }
            }
            else
            {
                Response.Redirect(string.Concat(GoToLogin, "?ru=", Request.RawUrl));
            }
            
        }
         protected string GetNav(string Nav, bool IsAddIndex)
        {
            return EbSite.BLL.NewsClass.GetNav(Nav, Model.ID, IsAddIndex, GetSiteID, 0);
        }
        override protected string GetNav(string Nav, bool IsAddIndex, int FilterClassID)
        {
            return EbSite.BLL.NewsClass.GetNav(Nav, Model.ID, IsAddIndex, GetSiteID,FilterClassID);
        }
       virtual protected void btnSavePost_Click(object sender, EventArgs e)
        {
            string sContent = edtContentInfo.CtrValue.Trim();
            string sTags = txtTags.Text.Trim();
            SavePost(sContent, sTags, cbIsReToSendEmail.Checked);
        }

       protected void SavePost(string sContent, string sTags,bool IsReToSendEmail)
        {
            if (TimeOutPost.Instance.IsAllow)
            {
                

                string sTitle = txtposttitle.Text.Trim();

                sTitle = Core.Utils.InputFormat(sTitle);

                sContent = Core.Utils.InputFormat(sContent);

                if (!string.IsNullOrEmpty(sContent) && sContent.Length > 2 && !string.IsNullOrEmpty(sTitle) && sTitle.Length >= 2)
                {
                    if (sContent.Length > 506240) //16240 差不多8000个汉字
                    {
                        Tips("帖子内容太长，不能超过506240");
                        return;
                    }

                    if (sTitle.Length > 1000)
                    {
                        Tips("帖子标题太长，不能超过1000");
                        return;
                    }

                    if (PostID == 0)
                    {
                        if (!string.IsNullOrEmpty(Request["cid"]))
                        {


                            if (!Equals(Model, null))
                            {
                                EbSite.Entity.NewsContent mdContent = new EbSite.Entity.NewsContent();
                                mdContent.NewsTitle = sTitle;
                                mdContent.ContentInfo = sContent;
                                mdContent.ClassID = Model.ID;
                                mdContent.ClassName = Model.ClassName;
                                //mdContent.ContentTemID = Model.Configs.ContentTemID;
                                mdContent.Annex1 = Core.Utils.GetClientIP();
                                mdContent.AddTime = DateTime.Now;

                                mdContent.Annex4 = DateTime.Now.ToString();//最后回复时间
                                mdContent.Annex21 = IsReToSendEmail? 1 : 0;


                                Entity.imitateuser mdimitateuser = imitateuser.Instance.GetRandByUserID(UserID);
                                if (!Equals(mdimitateuser, null)) //模拟发帖
                                {
                                    if (mdimitateuser.UserID > 0)
                                    {
                                        mdContent.UserID = mdimitateuser.ImitateUserID;
                                        mdContent.UserName = mdimitateuser.ImitateUserName;
                                        mdContent.UserNiName = mdimitateuser.ImitateUserRealName;
                                        //默认初始化当前用户为最后回复人
                                        mdContent.Annex2 = mdimitateuser.ImitateUserRealName; //最后回复人姓名
                                        mdContent.Annex3 = mdimitateuser.ImitateUserID.ToString();//最后回复人ID
                                    }

                                }
                                else
                                {
                                    mdContent.UserID = UserID;
                                    mdContent.UserName = UserName;
                                    mdContent.UserNiName = UserNiName;
                                    //默认初始化当前用户为最后回复人
                                    mdContent.Annex2 = UserNiName; //最后回复人姓名
                                    mdContent.Annex3 = UserID.ToString();//最后回复人ID
                                }

                                if (!string.IsNullOrEmpty(sTags))
                                {
                                    mdContent.TagIDs = sTags;
                                }

                                mdContent.IsAuditing = !Base.Host.Instance.GetIsAuditing();

                                int siteid = GetSiteID;
                                long postid = EbSite.Base.AppStartInit.GetNewsContentInst(ClassID).AddBLL(mdContent, -1, true, siteid, mdClass.ContentModelID);
                                if (postid > 0)
                                {
                                    BBSClass.UpdateCountAddOne(mdContent.ClassID, true, postid, mdContent.NewsTitle, UserID, UserNiName);
                                    Response.Redirect(HostApi.GetContentLink(postid, siteid, ClassID));
                                    //Tips("帖子发表成功", "恭喜,帖子发表成功", HostApi.GetContentLink(postid, siteid));
                                }


                            }

                        }
                    }
                    else
                    {

                        int siteid = GetSiteID;
                        EbSite.Entity.NewsContent md = EbSite.Base.AppStartInit.GetNewsContentInst(ClassID).GetModelByCache(PostID, siteid);

                        md.NewsTitle = sTitle;
                        md.ContentInfo = sContent;
                        md.AddTime = DateTime.Now;
                        md.Annex10 = string.Format("帖子最后由{0}修改于{1}", UserNiName, DateTime.Now);
                        md.Annex21 = cbIsReToSendEmail.Checked ? 1 : 0;

                        if (!string.IsNullOrEmpty(sTags))
                        {
                            md.TagIDs = sTags;
                        }

                        long postid = EbSite.Base.AppStartInit.GetNewsContentInst(ClassID).AddBLL(md, PostID, true, siteid, mdClass.ContentModelID);

                        //EbSite.Base.AppStartInit.GetNewsContentInst(ClassID).Update(md);
                        Tips("帖子编辑成功", "恭喜,帖子编辑成功", ViewState["AbsolutePath"].ToString());
                    }


                }
                else
                {
                    Tips("帖子长度不够，请不要灌水，谢谢！");
                }

                //执行完成后，更新一下当前时间
                TimeOutPost.Instance.UpdateTime();
            }
            else
            {
                Tips(string.Format("请过{0}分钟后再发表！", TimeOutPost.Instance.TimeSpan));
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