using System;
using System.Collections.Specialized;

using EbSite.Base.ExtWidgets.ModelCtr;

namespace EbSite.ExtensionsCtrls.CtrListBox
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

                   // rbList.SelectedValue = settings["drpBoxType"];


                }

            }
        }
        private void BindTemClass()
        {
            //rbList.DataTextField = "Title";
            //rbList.DataValueField = "id";
            //rbList.DataSource = BLL.Ctrtem.TemClass.FillCtrTemClasss();
            //rbList.DataBind();
        }
        public override void Save()
        {
            StringDictionary settings = GetSettings();

            //settings["drpBoxType"] = rbList.SelectedValue;

            SaveSettings(settings);
        }
    }
}