using System;
using System.Collections.Specialized;
using EbSite.Base.ExtWidgets.ModelCtr;

namespace EbSite.ExtensionsCtrls.ClassListBox
{
    public partial class Edit : ModelCtrlEditBase
    {
        public override void LoadData()
        {
            if (!this.Page.IsPostBack)
            {
                StringDictionary settings = base.GetSettings();
                if (!object.Equals(settings, null))
                {
                    drpParentClass.DataTextField = "classname";
                    drpParentClass.DataValueField = "id";
                    drpParentClass.DataSource = BLL.NewsClass.GetContentClassesTree(EbSite.BLL.AdminUser.GetCurrentSiteID(EbSite.Base.Host.Instance.UserID));
                    drpParentClass.DataBind();
                    this.txtClassNum.Text = settings["ClassNum"];
                    this.txtCustomItems.Text = settings["CustomItems"];

                    this.txtValueRule.Text = settings["ValueRule"];
                    this.txtTextRule.Text = settings["TextRule"];
                    this.txtOnchange.Text = settings["Onchange"];
                    drpParentClass.SelectedValue = settings["pid"];
                }
            }
        }

        public override void Save()
        {
            StringDictionary settings = base.GetSettings();
            settings["ClassNum"] = this.txtClassNum.Text.Trim();
            settings["CustomItems"] = this.txtCustomItems.Text.Trim();
            settings["ValueRule"] = this.txtValueRule.Text.Trim();
            settings["TextRule"] = this.txtTextRule.Text.Trim();
            settings["Onchange"] = this.txtOnchange.Text.Trim();
            settings["pid"] = drpParentClass.SelectedValue;
            

            this.SaveSettings(settings);
        }

    }
}