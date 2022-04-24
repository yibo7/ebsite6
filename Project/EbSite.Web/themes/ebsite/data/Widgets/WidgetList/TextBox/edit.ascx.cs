using System;
using System.Collections.Specialized;
using System.Web.UI.WebControls;
using EbSite.Base.ExtWidgets.WidgetsManage;

namespace EbSite.Widgets.TextBox
{
    public partial class edit : WidgetEditBase
    {
        public override void LoadData()
        {
            if (!Page.IsPostBack)
            {
                StringDictionary settings = GetSettings();
                if (!Equals(settings, null))
                {
                     string sContent = settings["content"];
                    if(settings.ContainsKey("BoxType"))
                    {
                        drpBoxType.SelectedValue = settings["BoxType"];
                        string sV = drpBoxType.SelectedValue;
                        if (sV == "1")
                        {
                            txtContent.Width = 300;
                            txtContent.Visible = true;
                            txtText.Visible = false;
                            txtContent.Text = sContent;
                        }
                        else if (sV == "2")
                        {
                            txtContent.Width = 500;
                            txtContent.TextMode = TextBoxMode.MultiLine; ;
                            txtContent.Height = 250;
                            txtContent.Visible = true;
                            txtText.Visible = false;
                            txtContent.Text = sContent;
                        }
                        else
                        {
                            txtContent.Visible = false;
                            txtText.Visible = true;
                            txtText.Text = sContent;
                        }
                    }
                    else
                    {
                        if (!Equals(drpBoxType,null))
                        drpBoxType.SelectedValue = "0";
                    }
                    
                }
                    
            }

        }
        public override void Save()
        {
            base.Save();
            StringDictionary settings = GetSettings();
            string sContent = "";
            string sV = drpBoxType.SelectedValue;
            if (sV == "1" || sV == "2")
            {
               
               sContent =  txtContent.Text ;
            }
            else
            {

                sContent = txtText.Text;
            }
            settings["content"] = sContent;
            settings["BoxType"] = drpBoxType.SelectedValue;
            
            SaveSettings(settings);
        }

        protected void drpBoxType_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sV = drpBoxType.SelectedValue;
            if(sV=="1")
            {
                txtContent.Width = 300;
                txtContent.Visible = true;
                txtText.Visible = false;
            }
            else if (sV == "2")
            {
                txtContent.Width = 500;
                txtContent.TextMode = TextBoxMode.MultiLine;;
                txtContent.Height = 250;
                txtContent.Visible = true;
                txtText.Visible = false;
            }
            else
            {
                txtContent.Visible = false;
                txtText.Visible = true;
            }
        }
    }
}