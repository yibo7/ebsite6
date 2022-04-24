using System;
using System.Collections.Generic;
using System.Collections.Specialized;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.ExtWidgets.ModelCtr;

namespace EbSite.Modules.Wenda.ExtensionsCtrls.AskClassLink
{
    public partial class Ctrl : ModelCtrlBase
    {

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
        }
        public override void LoadData()
        {
            
            StringDictionary settings = GetSettings();
          //  BindAreaList(1, 0);
           
        }
        //private void DisplayNone(System.Web.UI.WebControls.DropDownList ddl)
        //{
        //    ddl.Attributes.Add("style", "display:display");
        //}
     

        public override void SetValue(string sValue)
        {
            
           

        }
        public override string Name
        {
            get { return "AskClassLink"; }
        }
        public override string GetValue()
        {
            return "";
        }

    }
}