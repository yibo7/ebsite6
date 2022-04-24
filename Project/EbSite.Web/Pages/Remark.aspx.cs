using System;
using System.Collections.Generic;
using System.Data;
using System.Web.Security;
using System.Web.UI.WebControls;
using EbSite.Base;
using EbSite.Base.Configs.SysConfigs;
using EbSite.BLL.User;
using EbSite.Core;
using EbSite.Core.Strings;
using EbSite.Pages;
using EbSite.BLL;

namespace EbSite.Web.Pages
{
    public partial class Remark : EbSite.Base.Page.CustomPage
    {
        /// <summary>
        /// 评论留言的类别ID
        /// </summary>
        private int cid
        {
            get
            {
                if(!string.IsNullOrEmpty(Request["cid"]))
                {
                    return Core.Utils.StrToInt(Request["cid"],0); //int.Parse(Request["cid"]);
                }
                else
                {
                    return 0;
                }
            }

        }

        protected int ClassID
        {
            get
            {
                if (!string.IsNullOrEmpty(Request["classid"]))
                {
                    return Core.Utils.StrToInt(Request["classid"],0);
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
                    return Core.Utils.StrToInt(Request["contentid"],0);
                }
                else
                {
                    return 0;
                }
            }
        }

       
        /// <summary>
        /// 评论对象的唯一标记,如内容将为内容ID，用户留言将会用户名称
        /// </summary>
        //private string MK
        //{
        //    get
        //    {
        //        return Request["mk"];
        //    }
        //}
        private bool IsCloseSend
        {
            get
            {
                if(!string.IsNullOrEmpty(Request["cl"]))
                {
                    return Core.Utils.StrToBool(Request["cl"],false);
                }
                return false;
            }
        }
        /// <summary>
        /// 引用评论
        /// </summary>
        private string QuoteContent
        {
            get
            {
               
                return EbSite.Core.Utils.HtmlEncode(Request.Form["quote"]);
            }
        }

        protected int iSearchCount = 0;
        private int PageIndex
        {
            get
            {
                if (!string.IsNullOrEmpty(Request.QueryString["p"]))
                    return Core.Utils.StrToInt(Request.QueryString["p"],0);
                else
                    return 1;
            }
        }
        private int iPageSize
        {
            get
            {
                if (pgCtr.PageSize > 0)
                {
                    return pgCtr.PageSize;
                }
                else
                {
                    return 5;
                }
               
            }

        }
        private void AddPost()
        {
            if (ConfigsControl.Instance.IsOpenSafeCoder_PL && !UserIdentity.ValidateSafeCode(this.txtSafeCoder.Text.Trim()))
            {
                cJavascripts.MessageShowBack("所填写的验证码与所给的不符");
            }
            else
            {
                if (TimeOutPost.Instance.IsAllow)
                {
                    EbSite.Entity.Remark Model = new EbSite.Entity.Remark();
                    Model.Body = this.txtContent.Text.Trim();
                    if (!string.IsNullOrEmpty(Model.Body))
                    {
                        //Model.Mark = this.MK;
                        Model.DateAndTime = DateTime.Now;
                        Model.Discourage = 0;
                        Model.Information = 0;
                        Model.Ip = Utils.GetClientIP();
                        Model.Quote = this.QuoteContent;
                        Model.Support = 0;
                        Model.UserName = AppStartInit.UserName;
                        Model.UserNiName = AppStartInit.UserNiName;
                        Model.UserID = AppStartInit.UserID;
                        Model.IsNiName = this.cbNiName.Checked;
                        Model.RemarkClassID = this.cid;
                        Model.ClassID = ClassID;
                        Model.ContentID = ContentID;
                        if (!Equals(EvaluationScore, null)) //是否启用评分
                        {
                            Model.EvaluationScore = Core.Utils.StrToInt(EvaluationScore.Value, 0);
                        }


                        EbSite.BLL.Remark.Add(Model, true);

                        TimeOutPost.Instance.UpdateTime();

                        if (ConfigsControl.Instance.AuditingComment)
                        {

                            cJavascripts.MessageShowRBack("发表成功,但还在审核中...");
                        }

                        base.Response.Redirect(base.Request.UrlReferrer.ToString());
                    }
                }
                else
                {
                    cJavascripts.MessageShowRBack(string.Format("请过{0}分钟后再发表！", TimeOutPost.Instance.TimeSpan));
                }
                
            }
        }
       
        private void BindData()
        {
           

            List<EbSite.Entity.Remark> lst =  EbSite.BLL.Remark.GetModelList(this.cid, true, this.PageIndex, this.iPageSize, ClassID, ContentID, out this.iSearchCount,"");

            
            this.rpComment.DataSource = lst;
            this.rpComment.DataBind();
            this.intpages();
        }
         

        protected void btnPl_Click(object sender, EventArgs e)
        {
            if ((this.cid > 0))// && ClassID>0
            {
                if (EbSite.Base.AppStartInit.UserID>0)
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

        private void intpages()
        {
            //string sPram = string.Format("cid,{0}|classid,{1}|classid,{2}", this.cid, this.ClassID,this.ContentID);
            if (!object.Equals(this.pgCtr, null))
            {
                this.pgCtr.AllCount = this.iSearchCount;
                this.pgCtr.CurrentClass = "CurrentPageCoder";
                this.pgCtr.ParentClass = "ParentClass";
                this.pgCtr.PageSize = this.iPageSize;
                //this.pgCtr.OtherPram = sPram;
            }
            if (!object.Equals(this.pgCtr2, null))
            {
                this.pgCtr2.AllCount = this.iSearchCount;
                this.pgCtr2.PageSize = this.iPageSize;
                //this.pgCtr2.OtherPram = sPram;
                this.pgCtr2.CurrentClass = "CurrentPageCoder";
                this.pgCtr2.ParentClass = "ParentClass";
            }
        }

        protected int CommentInCredit
        {
            get { return EbSite.Base.Configs.UserSetConfigs.ConfigsControl.Instance.ToCommentInCredit; }
        }
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!base.IsPostBack)
            {
                this.BindData();
                if(!IsCloseSend)
                {
                    this.IsOpenSafeCoder.Visible = ConfigsControl.Instance.IsOpenSafeCoder_PL;
                }
                else
                {
                    SendPost.Attributes.Add("style", "display: none");
                }
            }
        }

        protected void rpComment_ItemDataBound(object sender, RepeaterItemEventArgs e)
        { 
            //HeaderTemplate，，ItemTemplate，SeparatorTemplate）
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Repeater rep = e.Item.FindControl("rpCommentSubList") as Repeater;//找到里层的repeater对象
                EbSite.Entity.Remark row = (EbSite.Entity.Remark)e.Item.DataItem;//找到分类Repeater关联的数据项 
                List<EbSite.Entity.RemarkSublist> lst = EbSite.BLL.RemarkSublist.GetModelList(row.ID);
                if (lst.Count > 0)
                {
                    rep.DataSource = lst;
                    rep.DataBind();
                }
               

            }
        }
    }
}
