using System;
using System.Collections.Generic;
using System.Linq;
using EbSite.Base;
using EbSite.Base.ControlPage;
using EbSite.Entity;

namespace EbSite.Web.AdminHt.Controls.Admin_Configs
{
    public partial class HtmlConfigs : UserControlBaseSave
    {
        public override string Permission
        {
            get
            {
                return "150";
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
            throw new NotImplementedException();
        }
        override protected void SaveModel()
        {
            Base.Configs.HtmlConfigs.ConfigsControl.Instance.CreateSleep = int.Parse(txtCreateSleep.Text);
            //EbSite.Base.Configs.HtmlConfigs.ConfigsControl.Instance.sHtmlFolder = txtsHtmlFolder.Text.Trim();
            Base.Configs.HtmlConfigs.ConfigsControl.Instance.DefualtName = txtDefualtName.Text.Trim();

            Base.Configs.HtmlConfigs.ConfigsControl.Instance.TagsList = txtTagList.Text;
            Base.Configs.HtmlConfigs.ConfigsControl.Instance.TagsSearchList = txtTagSearch.Text;

            Base.Configs.HtmlConfigs.ConfigsControl.Instance.ClassHtmlRule = rnrClass.Text.Trim();
            Base.Configs.HtmlConfigs.ConfigsControl.Instance.ContentHtmlRule = rnrContent.Text.Trim();

            Base.Configs.HtmlConfigs.ConfigsControl.Instance.HtmlTimeSpan = int.Parse(txtTimeSpan.Text);
            Base.Configs.HtmlConfigs.ConfigsControl.Instance.HtmlTimeSpanModel = int.Parse(drpTimeSpanModel.SelectedValue);

            Base.Configs.HtmlConfigs.ConfigsControl.Instance.SpecialHtmlRule = rnrSpecial.Text.Trim();

            Base.Configs.HtmlConfigs.ConfigsControl.Instance.PageSplit = txtPageSplit.Text.Trim();
            //Base.Configs.HtmlConfigs.ConfigsControl.Instance.PageHtmlModel = int.Parse(drpPageHtmlModel.SelectedValue);
            

            EbSite.Base.Configs.HtmlConfigs.ConfigsControl.SaveConfig();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                initConfig();
            }
        }
        protected void initConfig()
        {

            txtCreateSleep.Text = Base.Configs.HtmlConfigs.ConfigsControl.Instance.CreateSleep.ToString();
            txtTimeSpan.Text = Base.Configs.HtmlConfigs.ConfigsControl.Instance.HtmlTimeSpan.ToString();
            txtDefualtName.Text = Base.Configs.HtmlConfigs.ConfigsControl.Instance.DefualtName;
            txtTagList.Text = Base.Configs.HtmlConfigs.ConfigsControl.Instance.TagsList;
            txtTagSearch.Text = Base.Configs.HtmlConfigs.ConfigsControl.Instance.TagsSearchList;

            rnrClass.Text = Base.Configs.HtmlConfigs.ConfigsControl.Instance.ClassHtmlRule;
            rnrContent.Text = Base.Configs.HtmlConfigs.ConfigsControl.Instance.ContentHtmlRule;
            rnrSpecial.Text = Base.Configs.HtmlConfigs.ConfigsControl.Instance.SpecialHtmlRule;

            txtPageSplit.Text = Base.Configs.HtmlConfigs.ConfigsControl.Instance.PageSplit;
            drpTimeSpanModel.SelectedValue = Base.Configs.HtmlConfigs.ConfigsControl.Instance.HtmlTimeSpanModel.ToString();

            //drpPageHtmlModel.SelectedValue = Base.Configs.HtmlConfigs.ConfigsControl.Instance.PageHtmlModel.ToString();

        }
         

        protected void btnTagSearchUpdateRule_Click(object sender, EventArgs e)
        {
            string rule = txtTagSearch.Text.Trim();
            BLL.TagKey.UpdateAllHtmlRule(rule);
        }

        protected void btnTagSearchMakeName_Click(object sender, EventArgs e)
        {
            string rule = txtTagSearch.Text.Trim();
            BLL.TagKey.MakeHtmlName(GetSiteID);
        }
         
        protected void bntUpdateSpecial_Click(object sender, EventArgs e)
        {
            string NewRule = rnrSpecial.Text.Trim();
            BLL.SpecialClass.UpdateRuleToAllSpecial(NewRule, base.GetSiteID);
        }

        protected void bntReMakeHtmlNameClass_Click(object sender, EventArgs e)
        {
            BLL.NewsClass.MakeHtmlName(0, base.GetSiteID);
        }

        protected void bntReMakeHtmlNameContent_Click(object sender, EventArgs e)
        {
            foreach (var li in GetModelTable())
            {
                EbSite.BLL.NewsContentSplitTable NewsContentBll = AppStartInit.GetNewsContentInst(li);
                NewsContentBll.MakeHtmlName(0, base.GetSiteID);
            }

        }
        protected void bntReMakeHtmlNameSpecial_Click(object sender, EventArgs e)
        {
            BLL.SpecialClass.MakeHtmlName(base.GetSiteID);
        }

        //YHL 2014-2-11 得到当前站点下的 模型中所有表的名称 做为 清理，规零，分类名称对应。
        private List<string> GetModelTable()
        {
            List<EbSite.Entity.ModelClass> ls = EbSite.BLL.WebModel.Instance.ModelClassList;
            List<string> nls = new List<string>();
            foreach (var li in ls)
            {
                if (string.IsNullOrEmpty(li.TableName))
                {
                    li.TableName = "newscontent"; //默认为 系统的
                }
                int icount = (from i in nls select i == "newscontent").Count();
                if (icount == 0)
                    nls.Add(li.TableName);
            }

            return nls;
        }

    }
}