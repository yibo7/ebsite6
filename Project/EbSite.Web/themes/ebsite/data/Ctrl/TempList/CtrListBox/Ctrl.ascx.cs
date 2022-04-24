using System;
using System.Collections.Specialized;

using EbSite.Base.ExtWidgets.ModelCtr;

namespace EbSite.ExtensionsCtrls.CtrListBox
{
    public partial class Ctrl : ModelCtrlBase
    {
        

        public override void LoadData()
        {
            BindList();
            if (!IsPostBack)
            {
                

                //StringDictionary settings = GetSettings();
                //if (settings.ContainsKey("drpBoxType"))
                //{
                //    string sType = settings["drpBoxType"];
                  
                //}
            }
        }
        private void BindList()
        {
            drpCtrList.DataTextField = "Title";
            drpCtrList.DataValueField = "ID";
            drpCtrList.DataSource = Base.ExtWidgets.ModelCtr.DataBLL.Instance.GetList();
            drpCtrList.DataBind();
        }
        public override void SetValue(string sValue)
        {
            if (!string.IsNullOrEmpty(sValue))
            {
                drpCtrList.SelectedValue = sValue;
            }
            
            
            
        }

        public override string Name
        {
            get { return "CtrListBox"; }
        }

        public override string GetValue()
        {
            return drpCtrList.SelectedValue;
        }
    }
}