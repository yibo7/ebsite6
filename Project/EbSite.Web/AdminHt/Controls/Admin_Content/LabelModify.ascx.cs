using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.ControlPage;
using EbSite.BLL;

namespace EbSite.Web.AdminHt.Controls.Admin_Content
{
    public partial class LabelModify : UserControlBaseSave
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public override string Permission
        {
            get
            {
                return "64";
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
            Entity.TagKey md =  BLL.TagKey.GetModel(int.Parse(SID));
            txtKeyName.Text = md.TagName;

            rnHtmlName.Text = md.HtmlNameRule;
            txtSeoLableDes.Text = md.SeoDescription;
            txtSeoLableTitle.Text = md.SeoTitle;
            txtSeoLableKeyWord.Text = md.SeoKeyWord;
            
        }
        override protected void SaveModel()
        {
            Entity.TagKey md = BLL.TagKey.GetModel(int.Parse(SID));

            md.TagName = txtKeyName.Text.Trim();
            md.HtmlNameRule = rnHtmlName.Text;
            md.SeoDescription = txtSeoLableDes.Text;
            md.SeoTitle = txtSeoLableTitle.Text;
            md.SeoKeyWord = txtSeoLableKeyWord.Text;
            md.HtmlName = HtmlReNameRule.GetName(md.HtmlNameRule, md.TagName, "");//从当前规则转换文件名

            BLL.TagKey.Update(md);


        }
    }
}