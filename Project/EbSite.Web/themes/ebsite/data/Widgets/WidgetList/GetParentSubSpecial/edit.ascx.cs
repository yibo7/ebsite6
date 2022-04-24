using System;
using System.Collections.Specialized;

using System.Text;
using System.Web.UI.WebControls;
using System.Collections.Generic;
using EbSite.Base.ExtWidgets.WidgetsManage;

namespace EbSite.Widgets.GetParentSubSpecial
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
                    string sClassItem = settings["SpecialID"];
                    BindClass();
                    cblSpecial.SelectedValue = sClassItem;
                    drpTem.CtrlValue = settings["tem"];
                    drpTemSub.CtrlValue = settings["subtem"];
                    //txtParentTop.Text = settings["ptop"];
                    txtSubTop.Text = settings["stop"];
                    rblParentType.SelectedValue = settings["ptype"];
                    string sPItems = settings["pitems"];
                    if(rblParentType.SelectedValue=="1")
                    {
                        cblSpecial.SelectionMode = ListSelectionMode.Multiple;
                        if (!string.IsNullOrEmpty(sPItems)){
                            string[] aItems = sPItems.Split(',');
                            foreach (ListItem li in cblSpecial.Items)
                            {
                                if (Core.Strings.Validate.InArray(li.Value, aItems))
                                {
                                    li.Selected = true;
                                }
                            }

                        }
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(sClassItem))
                            cblSpecial.SelectedValue = sClassItem;
                    }
                   

                }
              

            }


        }
        private void BindClass()
        {
            cblSpecial.DataValueField = "ID";
            cblSpecial.DataTextField = "SpecialName";
            cblSpecial.DataSource = BLL.SpecialClass.GetTree(base.GetSiteID);
            cblSpecial.DataBind();

        }
        public override void Save()
        {
            base.Save();
            StringDictionary settings = GetSettings();
            settings["SpecialID"] = cblSpecial.SelectedValue;
            settings["tem"] = drpTem.CtrlValue;
            settings["subtem"] = drpTemSub.CtrlValue;

            settings["ptype"] = rblParentType.SelectedValue;
            settings["stop"] = txtSubTop.Text;

            if (rblParentType.SelectedValue=="1")
            {
                settings["pitems"] = GetItems();
            }
            
            SaveSettings(settings);
        }
        private string GetItems()
        {
            StringBuilder sb = new StringBuilder();

            foreach (ListItem li in cblSpecial.Items)
            {
                if (li.Selected)
                {
                    sb.Append(li.Value);
                    sb.Append(",");
                }
            }
            if (sb.Length > 1) sb.Remove(sb.Length - 1, 1);
            return sb.ToString();

        }

        protected void rblParentType_SelectedIndexChanged(object sender, EventArgs e)
        {
            cblSpecial.SelectionMode = ListSelectionMode.Multiple;
        }

    }
}