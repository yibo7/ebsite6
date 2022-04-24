using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Web.UI;
using EbSite.Control;

namespace EbSite.ControlData
{

    [DefaultEvent("Click"), DefaultProperty("Text"), ToolboxData("<{0}:SelectClass runat=server></{0}:SelectClass>")]
    public class SelectClass : DropDownListMore
    {

        public SelectClass()
        {
            base.ApiName = ServiceApiName.wcf;
            base.ApiFunctionName = "GetSubClassForAdd";
            base.Size = 20;
            //base.SiteID = EbSite.Base
            
        }
    }
}
