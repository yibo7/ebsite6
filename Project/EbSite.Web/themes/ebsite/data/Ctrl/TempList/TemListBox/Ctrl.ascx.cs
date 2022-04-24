using System;
using System.Collections.Specialized;
using System.Web.UI.WebControls;
using EbSite.Base.ExtWidgets.ModelCtr;
using EbSite.BLL;

namespace EbSite.ExtensionsCtrls.TemListBox
{
    public partial class Ctrl : ModelCtrlBase
    {
      
        protected string sType;
        public override void LoadData()
        {
           
                StringDictionary settings = GetSettings();
                if (settings.ContainsKey("CustomItems"))
                {
                    string sCustomItems = settings["CustomItems"];
                    foreach (string item in sCustomItems.Split(new char[] { '|' }))
                    {
                        string[] aOne = item.Split(new char[] { ',' });
                        ListItem li = new ListItem(aOne[0], aOne[1]);
                        this.drpTemContent.Items.Add(li);
                    }
                }
                if (settings.ContainsKey("drpBoxType"))
                {
                     sType = settings["drpBoxType"];
                    if(!string.IsNullOrEmpty(sType))
                            BindTemList(int.Parse(sType));
                }
           

            //wbAdd.Href = string.Concat("Admin_Tem.aspx?t=0&t=",sType);
        }
        private void BindTemList(int typeid)
        {
            drpTemContent.DataValueField = "ID";
            drpTemContent.DataTextField = "TemName";
            drpTemContent.DataSource = TempFactory.Instance.GetListByType(typeid);
            drpTemContent.DataBind();
        }
        public override void SetValue(string sValue)
        {
            if (!string.IsNullOrEmpty(sValue))
            {
               // string Themes = "";
               //Themes =  EbSite.BLL.Sites.Instance.GetEntity(GetSiteID).PageTheme;
               if (TempFactory.Instance.IsHaveTem(new Guid(sValue)))
                {
                    drpTemContent.SelectedValue = sValue;
                }
            }
            
            
            
        }

        public override string Name
        {
            get { return "TemListBox"; }
        }

        public override string GetValue()
        {
            return drpTemContent.SelectedValue;
        }
    }
}