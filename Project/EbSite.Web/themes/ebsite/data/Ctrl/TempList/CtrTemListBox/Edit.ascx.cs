using System;
using System.Collections;
using System.Collections.Specialized;
using System.Configuration;
using System.Data;

using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

using EbSite.Base.ExtWidgets.ModelCtr;

namespace EbSite.ExtensionsCtrls.CtrTemListBox
{
    public partial class Edit : ModelCtrlEditBase
    {
        public override void LoadData()
        {
            if (!Page.IsPostBack)
            {
                BindTemClass();
                StringDictionary settings = GetSettings();
                if (!Equals(settings, null))
                {

                    rbList.SelectedValue = settings["drpBoxType"];


                }

            }
        }
        private void BindTemClass()
        {
            rbList.DataTextField = "Title";
            rbList.DataValueField = "id";
            rbList.DataSource = BLL.Ctrtem.TemClass.FillCtrTemClasss();
            rbList.DataBind();
        }
        public override void Save()
        {
            StringDictionary settings = GetSettings();

            settings["drpBoxType"] = rbList.SelectedValue;

            SaveSettings(settings);
        }
    }
}