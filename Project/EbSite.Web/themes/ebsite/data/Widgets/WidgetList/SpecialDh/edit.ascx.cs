using System;
using System.Collections.Specialized;

using System.Text;
using System.Web.UI.WebControls;
using System.Collections.Generic;
using EbSite.Base.ExtWidgets.WidgetsManage;

namespace EbSite.Widgets.SpecialDh
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
                    string sClassItem = settings["SpecialItem"];
                    BindClass();
                    if (!string.IsNullOrEmpty(sClassItem))
                    {
                        string[] aItems = sClassItem.Split(',');
                        foreach (ListItem li in cblSpecial.Items)
                        {
                            if (Core.Strings.Validate.InArray(li.Value, aItems))//aItems.Contains(li.Value)
                            {
                                li.Selected = true;
                            }
                        }

                    }

                    drpTem.CtrlValue = settings["tem"];

                    txtCount.Text = settings["count"];

                    drpDataType.SelectedValue = settings["DataType"];
                    drpOrderBy.SelectedValue = settings["OrderBy"];


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
             

            settings["SpecialItem"] = GetItems();
            settings["tem"] = drpTem.CtrlValue;
            settings["count"] = txtCount.Text;

            settings["DataType"] = drpDataType.SelectedValue;
            settings["OrderBy"] = drpOrderBy.SelectedValue;

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
    }
}