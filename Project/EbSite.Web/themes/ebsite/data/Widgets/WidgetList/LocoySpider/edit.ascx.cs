using System;
using System.Collections.Specialized;
using System.Text;
using System.Web.UI.WebControls;
using EbSite.BLL;
using EbSite.Base.ExtWidgets.WidgetsManage;
using EbSite.Widgets.LocoySpider.Serializable;

namespace EbSite.Widgets.LocoySpider
{
    public partial class edit : WidgetEditBase
    {
        public override void LoadData()
        {
            if (!IsPostBack)
            {
                DataBindClass();
            }
           
            CustomControls();
            if(!IsPostBack)
            {
                
                StringDictionary settings = GetSettings();
                if (!Equals(settings, null))
                {
                    string sColumns = settings["Columns"];
                    StringBuilder sb = new StringBuilder();
                    if(!string.IsNullOrEmpty(sColumns))
                    {
                        string[] ac = sColumns.Split(',');

                        foreach (string s in ac)
                        {
                            sb.AppendFormat("'{0}'", s);
                            sb.Append(",");
                        }
                        if (sb.Length > 1) sb.Remove(sb.Length - 1, 1);
                        Columns = sb.ToString();
                    }
                    
                }

                ConfigsControl mdSerializable = new ConfigsControl(DataID.ToString());

                Entity.NewsContent md = mdSerializable.Instance;
                if (!Equals(md, null))
                    BLL.WebModel.Instance.InitModifyCtr(phCustomControls, md);
            }
        }

        protected string Columns;
        /// <summary>
        /// NewsTitle|标题,SmallPic|缩略图,ContentInfo|内容 
        /// </summary>
        protected string GetColumns
        {
            get
            {
                if(!string.IsNullOrEmpty(Request.Form["cl"]))
                {
                    return Request.Form["cl"];
                }
                return "";
            }
        }
        private void DataBindClass()
        {
            drpClass.DataValueField = "ID";
            drpClass.DataTextField = "ClassName";
            drpClass.DataSource = BLL.NewsClass.GetContentClassesTree(base.GetSiteID);
            drpClass.DataBind();
        }
        private void CustomControls()
        {
            string sClassID = drpClass.SelectedValue;

            if (!string.IsNullOrEmpty(sClassID))
            {
               int ClassID = int.Parse(sClassID);

               Entity.NewsClass ClassModel = null;

               if (ClassID > 0)
               {
                   ClassModel = BLL.NewsClass.GetModelByCache(ClassID);
               }

               rnHtmlContent.Text = ClassModel.ContentHtmlName;


               //获取当前分类所属的模型
               EbSite.Entity.ModelClass mcmd = BLL.WebModel.Instance.GeModelByID(ClassModel.ContentModelID);
               //根据模型来输出要展示的控件
               BLL.WebModel.Instance.BindCustomControlsForSpider(phCustomControls, this, mcmd, true);

               BLL.WebModel.Instance.InheritClassConfigs(phCustomControls, ClassModel);
            }
             
        }

       
        public override void Save()
        {
            base.Save();
            StringDictionary settings = GetSettings();
            settings["Columns"] = GetColumns;
            SaveSettings(settings);

            Entity.NewsContent ThisModel = new Entity.NewsContent();
            //获取默认数据
            ThisModel.ClassID = int.Parse(drpClass.SelectedValue);
            //目前还不把ContentHtmlNameRule 放到模型里，因为要给ContentHtmlNameRule 单独建立一个ContentHtmlNameRule 选择控件
            ThisModel.ContentHtmlNameRule = rnHtmlContent.Text.Trim();

            ThisModel.AddTime = DateTime.Now;

            //获取自定义字段的值

            BLL.WebModel.Instance.InitSaveCtr(phCustomControls, ref ThisModel);
            ThisModel.ClassName = drpClass.SelectedItem.Text;
            ThisModel.HtmlName = HtmlReNameRule.GetName(ThisModel.ContentHtmlNameRule, ThisModel.NewsTitle, ThisModel.ClassName); ;//从当前规则转换文件名
            ThisModel.IsAuditing = true;

            ConfigsControl mdSerializable = new ConfigsControl(DataID.ToString());
            mdSerializable.SaveConfig(ThisModel);

        }

        protected void drpClass_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        protected void bntInitModel_Click(object sender, EventArgs e)
        {
           string sID =  txtIDs.Text.Trim();
            
            if(!string.IsNullOrEmpty(sID))
            {
                foreach (ListItem liListItem in drpClass.Items)
                {
                    liListItem.Selected = false;
                }

                int iID = int.Parse(sID);
                Entity.NewsClass md =   NewsClass.GetModel(iID);
                ListItem li = new ListItem(md.ClassName, sID);
                li.Selected = true;
                drpClass.Items.Add(li);
            }

        }
    }
}