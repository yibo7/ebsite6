using System;
using System.Collections.Specialized;
using System.Web.UI.WebControls;

using EbSite.Base.ExtWidgets.ModelCtr;

namespace EbSite.ExtensionsCtrls.DropList
{
    public partial class Ctrl : ModelCtrlBase
    {

        public override void LoadData()
        {
            //if(!IsPostBack)
            //{

                 StringDictionary settings = GetSettings();
                 if (settings.ContainsKey("DroItem"))
                 {
                     string sDroItem = settings["DroItem"];

                     string[] aItem = sDroItem.Split('\n');

                     foreach (string s in aItem)
                     {
                         string sv = s.Replace("\r", "").Trim();
                         ListItem li = new ListItem(sv, sv);
                         drpList.Items.Add(li);
                     }
                 }

            //}
        }
        public override string Name
        {
            get { return "DropList"; }
        }
        public override void SetValue(string sValue)
        {
            drpList.SelectedValue = sValue;
        }
        public override string GetValue()
        {
            return drpList.SelectedValue;
        }
    }
}