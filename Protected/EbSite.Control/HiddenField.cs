using System;
using System.Collections;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.ComponentModel;
using EbSite.Control;


namespace EbSite.Control
{


    [DefaultProperty("Text"), ToolboxData("<{0}:HiddenField runat=server></{0}:HiddenField>"), Designer("System.Web.UI.Design.WebControls.PreviewControlDesigner, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
    public class HiddenField : System.Web.UI.WebControls.HiddenField, IUserContrlBase
    {
        public string CtrValue
        {
            get
            {
                return this.Value;
            }
            set
            {
                this.Value = value;
            }
        }
        

    }

    

}
