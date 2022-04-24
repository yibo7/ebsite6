using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.UI.WebControls;

namespace EbSite.Web.AdminHt.Controls.Admin_Class
{
    abstract public class BaseAddClass : EbSite.Base.ControlPage.UserControlBaseSave
    {
        //protected global::System.Web.UI.WebControls.CheckBox cbIsContinu;
        public BaseAddClass()
        {

            this.Load += new EventHandler(BasePage_Load);
        }
        private void BasePage_Load(object sender, EventArgs e)
        {
            //ctbTag.EndLiteral = llTagEnd;
            //ctbTag.Items = string.Format("分类信息#tg1|SEO优化设置#tg2|模型与模板#tg3|可选设置#tg4|子分类设置#tg5");

            //StringBuilder sb = new StringBuilder();

            //sb.Append("基本数据#tg1");
            //sb.Append("|SEO优化设置#tg2");
            //sb.Append("|可选设置#tg3");

            //if (!Base.Configs.HideItem.ConfigsControl.Instance.Seo)
            //    sb.Append("|SEO优化设置#tg2");

            //if (!Base.Configs.HideItem.ConfigsControl.Instance.Mt)
            //    sb.Append("|可选设置#tg3");

            //if (!Base.Configs.HideItem.ConfigsControl.Instance.Sel)
            //    sb.Append("|模型与模板#tg4");
            //if (!Base.Configs.HideItem.ConfigsControl.Instance.Sub)
            //    sb.Append("|子分类设置#tg5");



            //ctbTag.Items = sb.ToString();

        }

        public override string Permission
        {
            get
            {
                return "55";
            }
        }
        protected int cid
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
        protected int pid
        {
            get
            {
                if (!string.IsNullOrEmpty(Request["pid"]))
                {
                    return int.Parse(Request["pid"]);
                }
                return 0;
            }
        }
        protected Guid Modelid
        {
            get
            {
                if (!string.IsNullOrEmpty(Request["modelid"]))
                {
                    return new Guid(Request["modelid"]);
                }
                return Guid.Empty;
            }
        }
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

        //protected global::System.Web.UI.WebControls.Literal llTagEnd;
        //protected global::EbSite.Control.CustomTagsBox ctbTag;
       
        protected global::System.Web.UI.WebControls.Label lbClassName;
        
        protected global::EbSite.Control.TextBox SeoTitle;
        protected global::EbSite.Control.TextBox SeoKeyWord;
        protected global::EbSite.Control.TextBox SeoDescription;
        
        protected global::EbSite.Control.TextBox hits;
        protected global::EbSite.Control.TextBox dayHits;
        protected global::EbSite.Control.TextBox weekHits;
        protected global::EbSite.Control.TextBox monthhits;
        protected global::EbSite.Control.TextBox HtmlName;
        protected global::EbSite.Control.TextBox OutLike;
        protected global::System.Web.UI.WebControls.CheckBox IsHtmlNameReWrite;
        protected global::EbSite.Control.TextBox ContentHtmlPath;
        protected global::System.Web.UI.WebControls.CheckBox IsHtmlNameReWriteContent;

        //protected global::EbSite.Control.TextBox OutLike;


        //protected global::System.Web.UI.WebControls.CheckBox cbConfigsToSub;
        //protected global::EbSite.Control.TextBox PageSize;
        //protected global::EbSite.Control.DropDownList ListTemID;
        //protected global::EbSite.ControlData.ClassModels ClassModelID;
        //protected global::EbSite.ControlData.ClassTemps ClassTemID;


        //protected global::EbSite.ControlData.ContentTemps ContentTemID;
        //protected global::EbSite.ControlData.ContentModels ContentModelID;
        //protected global::EbSite.Control.CheckBox IsCanAddSub;
        //protected global::EbSite.Control.CheckBox IsCanAddContent;
        
        //protected global::EbSite.Control.TextBox SubClassAddName;
        //protected global::EbSite.ControlData.ClassModels SubClassModelID;
        //protected global::EbSite.ControlData.ClassTemps SubClassTemID;
        //protected global::EbSite.Control.CheckBox SubIsCanAddSub;
        //protected global::EbSite.Control.CheckBox SubIsCanAddContent;
        //protected global::EbSite.ControlData.ModuleList BingModule;
        //protected global::EbSite.ControlData.ContentModels SubDefaultContentModelID;
        //protected global::EbSite.ControlData.ContentTemps SubDefaultContentTemID;

        //protected global::EbSite.Control.UcReNameRule rnHtmlName;
        //protected global::EbSite.Control.UcReNameRule rnHtmlContent;


        private EbSite.Entity.ModelClass mcMd;
        /// <summary>
        /// 初始数据，并获取当前分类
        /// </summary>
        protected void BindData()
        {
            if (cid > 0)  //修改分类
            {
                Entity.NewsClass cmd = BLL.NewsClass.GetModel(cid);

                mcMd = BLL.ClassModel.Instance.GeModelByID(cmd.ClassModelID);//获取其父类设置的子类模型 
                if (pid > 0 && !Equals(lbClassName, null))  //父分类信息
                {

                    Entity.NewsClass pmd = BLL.NewsClass.GetModel(pid);
                    lbClassName.Text = pmd.ClassName;
                    
                }
                
                //if (cbIsContinu != null)
                //    cbIsContinu.Checked = true;

            }
            else //添加分类，所以调系统配置默认模型
            {
                if (pid > 0)  //添加子分类
                {
                    Entity.NewsClass pmd = BLL.NewsClass.GetModel(pid);
                    if (!Equals(lbClassName, null))
                        lbClassName.Text = pmd.ClassName;
                    if (Equals(pmd.SubClassModelID, Guid.Empty))
                    {
                        //如果没有设置子分类的模型，将默认载入父类模型
                        mcMd = BLL.ClassModel.Instance.GeModelByID(pmd.ClassModelID); 
                    }
                    else
                    {
                        //子分类设置
                        mcMd = BLL.ClassModel.Instance.GeModelByID(pmd.SubClassModelID);//获取其父类设置的子类模型 
                    }
                   

                }
                else //添加一级分类
                {
                  
                      if (Modelid != Guid.Empty)
                          mcMd = BLL.ClassModel.Instance.GeModelByID(Modelid);
                    else
                        throw new Exception("找不到模型，请在分类管理->数据整理->设置默认一级分类的模型  选择适应模型点保存，然后重试此操作");
                   // mcMd = BLL.ClassModel.Instance.GeModelByID(Base.Configs.ContentSet.ConfigsControl.Instance.DefaultClassID);
                     

                }

            }
            //根据模型来输出要展示的控件
            BLL.ClassModel.Instance.BindCustomControlsByModelID(this, mcMd, true);
             

        }
        protected List<PlaceHolder> lstPlaceHolder
        {
            get
            {
                return mcMd.GetFiledPlaceHolder(this);
            }
        }
        protected void InitModify()
        {

            if (cid > 0)
            {
                Entity.NewsClass cm = BLL.NewsClass.GetModelByCache(cid);
                foreach (PlaceHolder ph in lstPlaceHolder)
                {
                    BLL.ClassModel.Instance.InitModifyCtr(ph, cm);
                }

                this.SeoTitle.Text = cm.SeoTitle.Trim();
                this.SeoKeyWord.Text = cm.SeoKeyWord;
                this.SeoDescription.Text = cm.SeoDescription;

                this.hits.Text = cm.hits.ToString();
                this.dayHits.Text = cm.dayHits.ToString();
                this.weekHits.Text = cm.weekHits.ToString();
                this.monthhits.Text = cm.monthhits.ToString();
                this.HtmlName.Text = cm.HtmlName;
                this.OutLike.Text = cm.OutLike;
                this.IsHtmlNameReWrite.Checked = cm.IsHtmlNameReWrite;

                ContentHtmlPath.Text = cm.ContentHtmlPath;
                IsHtmlNameReWriteContent.Checked = cm.IsHtmlNameReWriteContent;


            }
           
        }
    }
}