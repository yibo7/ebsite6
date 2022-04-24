using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base;
using EbSite.Base.ExtWidgets.WidgetsManage;
using EbSite.Base.Modules;
using EbSite.Base.Page;
using EbSite.BLL.User;
using System.Web.Security;
using EbSite.Base.Configs.SysConfigs;
using EbSite.Core;
using EbSite.Core.Strings;


namespace EbSite.Widgets.RemarkAskPg
{
    public partial class widget : WidgetBase
    {
        public override void LoadData()
        {
            if (!base.IsPostBack)
            {
                BindData();
            }
        }
        protected int ClassID
        {
            get
            {
                if (!string.IsNullOrEmpty(Request["classid"]))
                {
                    return int.Parse(Request["classid"]);
                }
                else
                {
                    return 0;
                }
            }
        }

        protected int ContentID
        {
            get
            {
                if (!string.IsNullOrEmpty(Request["contentid"]))
                {
                    return int.Parse(Request["contentid"]);
                }
                else
                {
                    return 0;
                }
            }
        }
        protected int iSearchCount = 0;
        private void AddPost()
        {
            if (ConfigsControl.Instance.IsOpenSafeCoder_PL && !UserIdentity.ValidateSafeCode(this.txtSafeCoder.Text.Trim()))
            {
                cJavascripts.MessageShowBack("所填写的验证码与所给的不符");

            }
            else
            {
                EbSite.Entity.Remark Model = new EbSite.Entity.Remark();
                Model.Body = this.txtContent.Text.Trim();
                if (!string.IsNullOrEmpty(Model.Body))
                {
                    Model.DateAndTime = DateTime.Now;
                    Model.Discourage = 0;
                    Model.Information = 0;
                    Model.Ip = Utils.GetClientIP();
                  
                    Model.Support = 0;
                    Model.UserName = AppStartInit.UserName;
                    Model.UserNiName = AppStartInit.UserNiName;
                    Model.UserID = AppStartInit.UserID;
                    Model.IsNiName = this.cbNiName.Checked;
                    Model.RemarkClassID = this.cid;
                    Model.ClassID = ClassID;
                    Model.ContentID = ContentID;

                   
                    EbSite.BLL.Remark.Add(Model,false);
                    if (ConfigsControl.Instance.AuditingComment)
                    {
                        cJavascripts.MessageShowRBack("发表成功,但还在审核中...");
                    }
                    base.Response.Redirect(base.Request.UrlReferrer.ToString());
                }
            }
        }

        private void BindData()
        {
            List<EbSite.Entity.Remark> lst = EbSite.BLL.Remark.GetModelList(this.cid, true, 1, this.iPageSize, ClassID, ContentID, out this.iSearchCount, "isasked=true");

            this.rpComment.DataSource = lst;
            this.rpComment.DataBind();
            
        }

        protected void btnLogIn_Click(object sender, EventArgs e)
        {
            string sUserName = this.txtUserName.Text.Trim();
            string sUserPass = UserIdentity.PassWordEncode(this.txtPass.Text.Trim());
            if (Membership.ValidateUser(sUserName, sUserPass))
            {
                EbSite.Base.EntityAPI.MembershipUserEb ucf = BLL.User.MembershipUserEb.Instance.GetEntity(sUserName);
                UserIdentity.WriteUserIdentity(ucf.id.ToString(), sUserName, ucf.NiName, sUserPass,1,ucf.GroupID.ToString());
                base.Response.Redirect(base.Request.UrlReferrer.ToString());
            }
            else
            {
                cJavascripts.MessageShowBack("用户名或密码不对！");
            }
        }

        protected void btnPl_Click(object sender, EventArgs e)
        {
            if ((this.cid >0) )
            {
                if (!string.IsNullOrEmpty(AppStartInit.UserName))
                {
                    this.AddPost();
                }
                else if (this.cbNiName.Checked)
                {
                    this.AddPost();
                }
                else
                {
                    cJavascripts.MessageShowBack("您还没登录，可以选择匿名发表或登录后再发表!");
                }
            }
        }

       
       

        // 商家 在后台回答时，要把 Information 改成 提问的ID ,同时把提问的Information =-1;
        public override string Name
        {
            get { return "RemarkAskPg"; }
        }

        /// <summary>
        /// 评论留言的类别，如内容，用户或是网站，能过这个id来区分，可的后台添加
        /// </summary>
        public int cid
        {
            get
            {
                StringDictionary settings = GetSettings();
                if (settings.ContainsKey("txtCid"))
                {
                    return int.Parse(settings["txtCid"]);
                }
                return 0;
            }
        }
      
       
        

        public string ThemeUrl
        {
            get
            {
                StringDictionary settings = GetSettings();
                if (settings.ContainsKey("sitename"))
                {
                    return settings["sitename"];
                }
                return "default";
            }
           
             
        }
        private int iPageSize
        {
            get
            {
                return 5;
            }

        }
       
      
        public override bool IsEditable
        {
            get { return true; }
        }

    }

}