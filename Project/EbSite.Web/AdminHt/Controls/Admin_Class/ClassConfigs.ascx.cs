using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.BLL;

namespace EbSite.Web.AdminHt.Controls.Admin_Class
{
    public partial class ClassConfigs : Base.ControlPage.UserControlBaseSave
    {

        public override string Permission
        {
            get
            {
                return "59";
            }
        }
        override protected string KeyColumnName
        {
            get
            {
              return  "id";
            }
        }

        //private Entity.NewsClass cm = null;
        override protected void InitModifyCtr()
        {
            int iClassID = int.Parse(SID);
            bool isDefault = false;
            int iUsedClassCount = 0;
            bool IsSetTo = false;
            Entity.ClassConfigs Model = BLL.ClassConfigs.Instance.GetClassConfigsByClassID(iClassID,out isDefault,out  iUsedClassCount,out IsSetTo);
            hfConfigId.Value = Model.id.ToString();
            ViewState["ClassHtmlNameRule"] = Model.ClassHtmlNameRule;
            ViewState["isDefault"] = isDefault;
            ViewState["IsSetTo"] = IsSetTo;
            if (isDefault)
            {
                cbIsAddNew.Visible = true;
                bntSave.OnClientClick = "javascript:return confirm('此分类使用的是当前站点默认配置，更改可能会影响其他分类，如果不想影响别的分类设置，你可以选择保存到新的配置再保存，确认保存？')";
            }
            else if(iUsedClassCount > 1)
            {
                cbIsAddNew.Visible = true;
                cbIsAddNew.Text =string.Format("javascript:return confirm('此配置已经被{0}个分类引用，更改可能会影响其他分类，如果不想影响别的分类设置，你可以选择保存到新的配置再保存，确认保存？')", iUsedClassCount) ;// string.Format("此配置已经被{0}个分类引用，更改可能会影响其他分类，是否保存到一个新分类配置", iUsedClassCount);
            }

            //if (BLL.ClassConfigs.Instance.IsHaveClassConfigsByClassID(iClassID))
            //{
            //    Model = BLL.ClassConfigs.Instance.GetClassConfigsByClassID(iClassID);    
            //}
            //else
            //{
            //    Model = BLL.ClassConfigs.Instance.GetClassConfigs(GetSiteID);    
            //}


            if (!string.IsNullOrEmpty(Model.ContentHtmlName))
            {
                rnHtmlContent.Text = Model.ContentHtmlName;
            }
            else //默认调用配置里的命名规则
            {
                rnHtmlContent.Text = Base.Configs.HtmlConfigs.ConfigsControl.Instance.ContentHtmlRule;
            }


            if (!string.IsNullOrEmpty(Model.ClassHtmlNameRule))
                rnHtmlName.Text = Model.ClassHtmlNameRule;
            if (!string.IsNullOrEmpty(Model.ContentHtmlName))
                rnHtmlContent.Text = Model.ContentHtmlName;

            //cbConfigsToSub.Visible = true;


            this.PageSize.Text = Model.PageSize.ToString();
           // this.ListTemID.SelectedValue = Model.ListTemID.ToString();
            this.ClassModelID.SelectedValue = Model.ClassModelID.ToString();
            this.ClassTemID.SelectedValue = Model.ClassTemID.ToString();
            this.ContentTemID.SelectedValue = Model.ContentTemID.ToString();
            this.ContentModelID.SelectedValue = Model.ContentModelID.ToString();
            this.IsCanAddSub.Checked = Model.IsCanAddSub;
            this.IsCanAddContent.Checked = Model.IsCanAddContent;


            //子分类
            this.SubClassAddName.Text = Model.SubClassAddName;
            SubClassTemID.SelectedValue = Model.SubClassTemID.ToString();
            SubClassModelID.SelectedValue = Model.SubClassModelID.ToString();
            SubIsCanAddSub.Checked = Model.SubIsCanAddSub;
            SubIsCanAddContent.Checked = Model.SubIsCanAddContent;
            SubDefaultContentTemID.SelectedValue = Model.SubDefaultContentTemID.ToString();//子分类内容模板ID
            SubDefaultContentModelID.SelectedValue = Model.SubDefaultContentModelID.ToString();//子分类内容模型ID
            BingModule.SelectedValue = Model.ModuleID.ToString();

            ClassTemIDMobile.SelectedValue = Model.ClassTemIdMobile.ToString();
            ContentTemIDMobile.SelectedValue = Model.ContentTemIdMobile.ToString();


        }
        override protected void SaveModel()
        {
            Entity.ClassConfigs Model = new Entity.ClassConfigs();

            Model.ClassHtmlNameRule = rnHtmlName.Text.Trim();
            Model.ContentHtmlName = rnHtmlContent.Text.Trim();

            Model.PageSize = int.Parse(this.PageSize.Text.Trim());
           // Model.ListTemID = new Guid(this.ListTemID.SelectedValue);
            Model.ClassModelID = new Guid(this.ClassModelID.SelectedValue);
            Model.ClassTemID = new Guid(this.ClassTemID.SelectedValue);
            Model.ContentTemID = new Guid(this.ContentTemID.SelectedValue);
            Model.ContentModelID = new Guid(this.ContentModelID.SelectedValue);

            Model.IsCanAddSub = this.IsCanAddSub.Checked;
            Model.IsCanAddContent = this.IsCanAddContent.Checked;


            //子分类设置
            Model.SubClassAddName = this.SubClassAddName.Text.Trim();//子分类添加名称
            Model.SubClassTemID = new Guid(SubClassTemID.SelectedValue);//子分类模板ID
            Model.SubClassModelID = new Guid(SubClassModelID.SelectedValue);//子分类模型ID
            Model.SubIsCanAddSub = SubIsCanAddSub.Checked;
            Model.SubIsCanAddContent = SubIsCanAddContent.Checked;
            Model.SubDefaultContentTemID = new Guid(SubDefaultContentTemID.SelectedValue);//子分类内容模板ID
            Model.SubDefaultContentModelID = new Guid(SubDefaultContentModelID.SelectedValue);//子分类内容模型ID
            Model.ModuleID = new Guid(BingModule.SelectedValue);

            Model.ClassTemIdMobile = new Guid(ClassTemIDMobile.SelectedValue);
            Model.ContentTemIdMobile = new Guid(ContentTemIDMobile.SelectedValue);

            Model.AddTime = DateTime.Now;
            Model.id = int.Parse(hfConfigId.Value);

            int iClassID = int.Parse(SID);
            string sClassHtmlNameRule = ViewState["ClassHtmlNameRule"] as string;//获取之前的classhtmlnamerule,可知是否则修改过
            bool isDefault = bool.Parse(ViewState["isDefault"].ToString());
            bool IsSetTo = bool.Parse(ViewState["IsSetTo"].ToString());
            EbSite.BLL.ClassConfigs.Instance.UpdateClassConfigs(Model, iClassID, GetSiteID, !Equals(Model.ClassHtmlNameRule, sClassHtmlNameRule), cbIsAddNew.Checked, cbConfigsToSub.Checked, isDefault, IsSetTo);

            Response.Redirect(Request.RawUrl);
        }
        override protected void InitDivsteptips()
        {
            if (!Equals(divsteptips, null))
            {
                Entity.NewsClass cm = null;
                if (!string.IsNullOrEmpty(SID))
                    cm = BLL.NewsClass.GetModel(int.Parse(SID));

                divsteptips.InnerHtml = string.Format("正在设置分类:<b>{0}</b> [<a onclick=\"javascript:history.go(-1);\">返回</a>]",Equals(cm,null)?"新添加分类默认设置": cm.ClassName);
            }
                
        }

        override protected void OnBasePageLoading()
        {
            BindData();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                

                //if (string.IsNullOrEmpty(SID))
                //{

                //    if (EbSite.BLL.ClassConfigs.Instance.IsHaveClassConfigs(GetSiteID))
                //    {
                //        Entity.ClassConfigs Model = EbSite.BLL.ClassConfigs.Instance.GetClassConfigs(GetSiteID);


                //        rnHtmlContent.Text = Model.ContentHtmlName;

                //        rnHtmlName.Text = Model.ClassHtmlNameRule;

                //        rnHtmlContent.Text = Model.ContentHtmlName;

                //        cbConfigsToSub.Visible = true;


                //        this.PageSize.Text = Model.PageSize.ToString();
                //       // this.ListTemID.SelectedValue = Model.ListTemID.ToString();
                //        this.ClassModelID.SelectedValue = Model.ClassModelID.ToString();
                //        this.ClassTemID.SelectedValue = Model.ClassTemID.ToString();
                //        this.ContentTemID.SelectedValue = Model.ContentTemID.ToString();
                //        this.ContentModelID.SelectedValue = Model.ContentModelID.ToString();
                //        this.IsCanAddSub.Checked = Model.IsCanAddSub;
                //        this.IsCanAddContent.Checked = Model.IsCanAddContent;


                //        //子分类
                //        this.SubClassAddName.Text = Model.SubClassAddName;
                //        SubClassTemID.SelectedValue = Model.SubClassTemID.ToString();
                //        SubClassModelID.SelectedValue = Model.SubClassModelID.ToString();
                //        SubIsCanAddSub.Checked = Model.SubIsCanAddSub;
                //        SubIsCanAddContent.Checked = Model.SubIsCanAddContent;
                //        SubDefaultContentTemID.SelectedValue = Model.SubDefaultContentTemID.ToString();//子分类内容模板ID
                //        SubDefaultContentModelID.SelectedValue = Model.SubDefaultContentModelID.ToString();//子分类内容模型ID
                //        BingModule.SelectedValue = Model.ModuleID.ToString();

                //        ClassTemIDMobile.SelectedValue = Model.ClassTemIdMobile.ToString();
                //        ContentTemIDMobile.SelectedValue = Model.ContentTemIdMobile.ToString();
                //    }
                //    else
                //    {
                //        divsteptips.InnerHtml = "当前站点还没有创建默认分类配置，请点击保存";
                //    }

                //}
            }
            
        }

        protected void BindData()
        {
            //ListTemID.DataTextField = "Title";
            //ListTemID.DataValueField = "id";
            //ListTemID.DataSource = EbSite.BLL.ContentTem.Instance.FillList();
            //ListTemID.DataBind();
            //ListTemID.Items.Insert(0, new ListItem("默认模板", Guid.Empty.ToString()));

            SubClassModelID.Items.Insert(0, new ListItem("选择模型", Guid.Empty.ToString()));

            SubDefaultContentModelID.Items.Insert(0, new ListItem("选择模型", Guid.Empty.ToString()));

            SubClassTemID.Items.Insert(0, new ListItem("选择模板", Guid.Empty.ToString()));

            SubDefaultContentTemID.Items.Insert(0, new ListItem("选择模板", Guid.Empty.ToString()));

            rnHtmlName.Text = Base.Configs.HtmlConfigs.ConfigsControl.Instance.ClassHtmlRule;
            rnHtmlContent.Text = Base.Configs.HtmlConfigs.ConfigsControl.Instance.ContentHtmlRule;
        }

        protected void lbDelete_Click(object sender, EventArgs e)
        {
            int classid = int.Parse(SID);
            BLL.ClassConfigs.Instance.DeleteByClassID(classid);

            Response.Redirect(Request.RawUrl);
        }
    }
}