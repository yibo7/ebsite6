using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.ControlPage;
using EbSite.BLL;
using EbSite.Control;
using EbSite.Web.AdminHt.Controls.Admin_Class;

namespace EbSite.Web.AdminHt.Controls.Admin_Content
{
    public partial class AddContent : EbSite.Base.ControlPage.UserControlBaseSave
    {
        public override string Permission
        {
            get
            {
                return "61";
            }
        }
        private Entity.NewsClass ClassModel;

        private Entity.NewsContent ModifyModel;
        private void InitModifyModel()
        {
            Entity.NewsContent Model = null;
            if (ID > -1)
            {
                Model = NewsContentInstModify.GetModel(ID,GetSiteID);
                //drpClass.Enabled = false;

            }
            ModifyModel = Model;



        }

        private void InitClass()
        {

            Entity.NewsClass cModel;
            if (ID > -1)
            {
                cModel = BLL.NewsClass.GetModelByCache(ModifyModel.ClassID);
            }
            else
            {
                if (ClassID > 0)
                {
                    cModel = BLL.NewsClass.GetModelByCache(ClassID);
                }
                else
                {
                    Tips("出错了！", "找不到对应的分类，如果还没有添加分类请添加", Request.RawUrl);
                    return;
                }

            }
            ClassModel = cModel;
            Guid _ContentModelID = ClassModel.ContentModelID;

            mcMd = ModelBll.GeModelByID(_ContentModelID);

            llClassName.Text = ClassModel.ClassName;

        }

        private List<ContentExtBase> exCtrls;

        private void ShowModuleCtrs()
        {
            //初始提交客户端事件+扩展的客户端事件
            StringBuilder script = new StringBuilder("<script language=\"javascript\">function postsubmitcheck(){var isok =  ValidateGP('savedata');if(!isok){ tips('某个输入格式不对',2);return isok;}; ");



            exCtrls = md.GetCtrs(ClassModel.ModuleID, this.Page);
            StringBuilder sb = new StringBuilder("<div class=\"row\"><div   class=\"col-lg-2 tagext\">");
            foreach (ContentExtBase ctr in exCtrls)
            {
                sb.AppendFormat("<div name=\"{0}\" >{0}</div>", ctr.PageName);
            }
            sb.Append("</div><div class=\"col-lg-10\">");
            ModuleCtrs.Controls.Add(Page.ParseControl(sb.ToString()));
            foreach (ContentExtBase ctr in exCtrls)
            {

                ModuleCtrs.Controls.Add(Page.ParseControl(string.Format("<div style=\"display:none\" id=\"{0}\">", ctr.PageName)));
                ModuleCtrs.Controls.Add(ctr);
                ModuleCtrs.Controls.Add(Page.ParseControl("</div>"));

                ctr.DataInit(ModifyModel, ClassModel);
                if (!string.IsNullOrEmpty(ctr.OnClientClick))
                    script.Append(string.Concat("isok =  ", ctr.OnClientClick, ";if(!isok){ tips('某个输入格式不对',2); return isok;};"));

            }
            ModuleCtrs.Controls.Add(Page.ParseControl("</div></div>"));
            if (exCtrls.Count > 0)
            {
                RunJs("InitTags()");

            }
            else
            {
                Notes nt = new Notes();
                nt.Text = "没有可用的扩展功能,如果您在添加分类的时候关联了模块，并且模块提供了对此的扩展控件，将可以在这里使用";
                ModuleCtrs.Controls.Add(nt);
            }

            script.Append(" tips('正在提交...',1,300);  return isok; }</script>");
            ClientScriptManager cs = this.Page.ClientScript;
            cs.RegisterStartupScript(this.Page.GetType(), "message", script.ToString());

            bntSave.OnClientClick = "return postsubmitcheck()";

        }



        EbSite.BLL.ExtContent md;
        protected void Page_Load(object sender, EventArgs e)
        {

            

             md = new ExtContent();
            InitModifyModel();
            InitClass();
            BindData();
            ShowModuleCtrs();
            //在模块扩展里可以获取当前内容Id
            Session["ContentId"] = ID;
            if (ID > -1)
            {
                if (!IsPostBack)
                {

                    foreach (PlaceHolder ph in lstPlaceHolder)
                    {
                        ModelBll.InitModifyCtr(ph, ModifyModel);
                    }


                    ClassID = ModifyModel.ClassID;

                    //if (!string.IsNullOrEmpty(ModifyModel.ContentHtmlNameRule))
                    //    rnHtmlContent.Text = ModifyModel.ContentHtmlNameRule;

                    //HtmlName.Text = ModifyModel.HtmlName;
                    Keywords.Text = ModifyModel.Keywords;
                    Description.Text = ModifyModel.Description;
                    cbUpdateModifyDate.Visible = true;
                   
                    //2012-01-13 yhl operate
                    this.TagIDs.Text = ModifyModel.TagIDs;
                    this.OrderID.Text = ModifyModel.OrderID.ToString();
                    this.hits.Text = ModifyModel.hits.ToString();
                    this.dayHits.Text = ModifyModel.dayHits.ToString();
                    this.weekHits.Text = ModifyModel.weekHits.ToString();
                    this.monthhits.Text = ModifyModel.monthhits.ToString();
                    this.Advs.Text = ModifyModel.Advs.ToString();
                    //this.ContentTemID.SelectedValue = ModifyModel.ContentTemID.ToString();
                    this.IsGood.Checked = ModifyModel.IsGood;
                    this.IsComment.Checked = ModifyModel.IsComment;
                    
                }
            }
            
            //ctbTag.EndLiteral = llTagEnd;
            //ctbTag.Items = string.Format("编辑内容#tg1|初始设置#tg2|相关设置#tg3|扩展功能#tg4");
            //phOrtherFileds
        }
        /// <summary>
        /// 当前内容所属模型
        /// </summary>
        private EbSite.Entity.ModelClass mcMd;
        private List<PlaceHolder> lstPlaceHolder
        {
            get
            {
                return mcMd.GetFiledPlaceHolder(this);
            }
        }

        private WebModel ModelBll
        {
            get { return BLL.WebModel.InstanceObj(GetSiteID); }
        }
        private void BindData()
        {


            //rnHtmlContent.Text = ClassModel.ContentHtmlName;


            //获取当前分类所属的模型
            //EbSite.Entity.ModelClass mcmd = BLL.WebModel.Instance.GeModelByID(ClassModel.ContentModelID);
            //根据模型来输出要展示的控件
            ModelBll.BindCustomControlsByModelID(this, mcMd, true);

            //继承分类设置
            foreach (PlaceHolder ph in mcMd.GetFiledPlaceHolder(this))
            {
                ModelBll.InheritClassConfigs(ph, ClassModel);
            }


        }
        private int _ClassID = -1;
        private int ClassID
        {
            get
            {
                if (!string.IsNullOrEmpty(Request["cid"]))
                {
                    _ClassID = int.Parse(Request["cid"]);

                }

                return _ClassID;
            }
            set
            {
                _ClassID = value;
            }
        }
        new private long ID
        {
            get
            {
                if (!string.IsNullOrEmpty(Request["id"]))
                {
                    return int.Parse(Request["id"]);
                }
                else
                {
                    return -1;
                }
            }
        }

        public Guid ModelID
        {
            get
            {
                if (!string.IsNullOrEmpty(Request.QueryString["modelid"]))
                    return new Guid(Request.QueryString["modelid"]);
                else
                    return Guid.Empty;
            }
        }
        private NewsContentSplitTable NewsContentInstModify
        {
            get
            {
                if (ClassID > 0)
                {
                    return EbSite.Base.AppStartInit.GetNewsContentInst(ClassID);
                }
                else
                {
                    return EbSite.Base.AppStartInit.GetNewsContentInst(ModelID, GetSiteID);
                }
                
            }
        }
        private void AddCt()
        {

            //EbSite.BLL.NewsContentSplitTable NewsContentInst = EbSite.Base.AppStartInit.GetNewsContentInst(ClassID);


            Entity.NewsContent ThisModel = new Entity.NewsContent();

            if (ID > -1) ThisModel = ModifyModel;

            //获取默认数据
            ThisModel.ClassID = ClassModel.ID;
            //目前还不把ContentHtmlNameRule 放到模型里，因为要给ContentHtmlNameRule 单独建立一个ContentHtmlNameRule 选择控件
            //ThisModel.ContentHtmlNameRule = rnHtmlContent.Text.Trim();
            ThisModel.Keywords = Keywords.Text.Trim(); 
            ThisModel.Description = Description.Text.Trim();

            if (cbUpdateModifyDate.Checked)
                ThisModel.AddTime = DateTime.Now;

            //获取字段的值
            foreach (PlaceHolder ph in lstPlaceHolder)
            {
                ModelBll.InitSaveCtr(ph, ref ThisModel);
            }

            //ThisModel.HtmlName = HtmlName.Text;
            ThisModel.ClassName = ClassModel.ClassName;
            if(string.IsNullOrEmpty(ThisModel.HtmlName))
                ThisModel.HtmlName = HtmlReNameRule.GetName(ThisModel.ContentHtmlNameRule, ThisModel.NewsTitle, ThisModel.ClassName); ;//从当前规则转换文件名
            ThisModel.IsAuditing = !Base.Configs.SysConfigs.ConfigsControl.Instance.AuditingContent;
            
            //2012-01-13 yhl operate
            ThisModel.TagIDs = this.TagIDs.Text.Trim();
            ThisModel.OrderID = Core.Utils.StrToInt(this.OrderID.Text.Trim(), 1);
            ThisModel.hits = Core.Utils.StrToInt(this.hits.Text.Trim(), 1);
            ThisModel.dayHits = Core.Utils.StrToInt(this.dayHits.Text.Trim(), 1);
            ThisModel.weekHits = Core.Utils.StrToInt(this.weekHits.Text.Trim(), 1);
            ThisModel.monthhits = Core.Utils.StrToInt(this.monthhits.Text.Trim(), 1);
            ThisModel.Advs = Core.Utils.StrToInt(this.Advs.Text.Trim(), 1);

            //ThisModel.ContentTemID = new Guid(this.ContentTemID.SelectedValue);
            ThisModel.IsGood = this.IsGood.Checked;
            ThisModel.IsComment = this.IsComment.Checked;


            long newid = NewsContentInstModify.AddBLL(ThisModel, ID, true, base.GetSiteID, ClassModel.ContentModelID);

            foreach (ContentExtBase ctr in exCtrls)//触发模块扩展控件事件
            {
                if (ID > 0) //更新
                {
                    ctr.Update(ThisModel);
                }
                else  //添加
                {
                    ThisModel.ID = newid;
                    ctr.Add(ThisModel);
                }
            }

            //if (newid > 0 && (Base.Configs.SysConfigs.ConfigsControl.Instance.Linktype == Base.Configs.SysConfigs.LinkType.Html || Base.Configs.SysConfigs.ConfigsControl.Instance.Linktype == Base.Configs.SysConfigs.LinkType.AutoHtml))

            Base.Configs.SysConfigs.LinkType lt = Sites.Instance.GetSiteLinkType(GetSiteID);

            if (newid > 0 && (lt == Base.Configs.SysConfigs.LinkType.Html)) // || lt == Base.Configs.SysConfigs.LinkType.AutoHtml
            {
                //生成静态页面
                //Base.Static.OneCreatManager.NewsContent ocm = new Base.Static.OneCreatManager.NewsContent(ThisModel.ClassID);

                //ocm.ContentID = newid;
                //string sRz = ocm.MakeHtml(GetSiteID);

                Base.Static.OneCreatManager.NewsContent.Instance.ModelID = ModelID;
                Base.Static.OneCreatManager.NewsContent.Instance.ClassID = ClassID;
                Base.Static.OneCreatManager.NewsContent.Instance.ContentID = newid;
                string sRz = Base.Static.OneCreatManager.NewsContent.Instance.MakeHtml(base.GetSiteID);
            }

            if (cbIsContinu.Checked)
            {
                Session["sKeyWord"] = ClassID;
                if (ID > 0)
                {
                    //base.ColseGreyBox(true);
                }
                else
                {
                    Response.Redirect("Admin_Content.aspx?t=1");
                }

            }

            Session["ContentId"] = newid;

        }

        //protected void drpClass_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    string iClassID = drpClass.SelectedValue;

        //    Response.Redirect(GetMenuLink(1) + "&cid=" + iClassID);
        //}


        override protected string KeyColumnName
        {
            get
            {
                return "id";
            }
        }
        override protected void InitModifyCtr()
        {
        }

        override protected void SaveModel()
        {
            AddCt();
        }
    }
}