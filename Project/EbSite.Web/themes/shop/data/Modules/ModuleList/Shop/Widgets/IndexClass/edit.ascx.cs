using System;
using System.Collections.Specialized;
using System.Text;
using System.Web.UI.WebControls;

using EbSite.Base.ExtWidgets.WidgetsManage;

namespace EbSite.Modules.Shop.Widgets.IndexClass
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
                    string sClassItem = settings["ClassItem"];
                    BindClass();
                    if (!string.IsNullOrEmpty(sClassItem))
                    {

                            string[] aItems = sClassItem.Split(',');
                            foreach (ListItem li in cblClass.Items)
                            {
                                if (Core.Strings.Validate.InArray(li.Value, aItems))
                                {
                                    li.Selected = true;
                                }
                            }
                        
                    }
                }

            }
        }

        private void BindClass()
        {
            cblClass.DataValueField = "ID";
            cblClass.DataTextField = "ClassName";
            cblClass.DataSource =EbSite.BLL.NewsClass.GetContentClassesTree(SettingInfo.Instance.GetSiteID);
            cblClass.DataBind();

        }
        private string GetItems()
        {
          
                StringBuilder sb = new StringBuilder();

                foreach (ListItem li in cblClass.Items)
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
        public override void Save()
        {
            base.Save();
            StringDictionary settings = GetSettings();
            string sClassID = string.Empty;
            sClassID = GetItems();
            settings["ClassItem"] = sClassID;
            SaveSettings(settings);
        }

    }
}