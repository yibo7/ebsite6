using System;
using System.Collections.Specialized;

using EbSite.Base.ExtWidgets.ModelCtr;

namespace EbSite.ExtensionsCtrls.CtrTemListBox
{
    public partial class Ctrl : ModelCtrlBase
    {
       
        protected string sType = "";
        public override void LoadData()
        {
           
                StringDictionary settings = GetSettings();
                if (settings.ContainsKey("drpBoxType"))
                {
                     sType = settings["drpBoxType"];
                    if(!string.IsNullOrEmpty(sType))
                    {
                        BindTemList(new Guid(sType));
                    }
                    else
                    {
                        BindTemList(Guid.Empty);
                    }
                   
                        
                }

                //wbAdd.Href = string.Concat("Admin_Ctrtem.aspx?t=2&cid=", sType);
           
        }
        
        private void BindTemList(Guid typeid)
        {
            drpTemList.DataValueField = "ID";
            drpTemList.DataTextField = "Title";
            drpTemList.DataSource = TemBll.SelectCtrTemLists_ByClassID(typeid);
            drpTemList.DataBind();
        }
        public override void SetValue(string sValue)
        {
            if (!string.IsNullOrEmpty(sValue))
            {
                drpTemList.SelectedValue = sValue;
            }
            
            
            
        }

        public override string Name
        {
            get { return "CtrTemListBox"; }
        }

        public override string GetValue()
        {
            return drpTemList.SelectedValue;
        }
    }
}