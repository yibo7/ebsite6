using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.ExtWidgets.ModelCtr;

namespace EbSite.Modules.Shop.ExtensionsCtrls.Supplier
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
            List<ModuleCore.Entity.Supplier> ls = ModuleCore.BLL.Supplier.Instance.GetListArray(0, "", "");
            drpList.DataSource = ls;
            drpList.DataValueField = "id";
            drpList.DataTextField = "SupplierName";
            drpList.DataBind();
            //}
        }
        public override string Name
        {
            get { return "Supplier"; }
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