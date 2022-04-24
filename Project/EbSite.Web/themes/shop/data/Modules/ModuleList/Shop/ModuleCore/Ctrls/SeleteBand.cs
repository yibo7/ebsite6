using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.UI;
using EbSite.Control;

namespace EbSite.Modules.Shop.ModuleCore.Ctrls
{
     [DefaultEvent("Click"), DefaultProperty("Text"), ToolboxData("<{0}:SeleteBrand runat=server></{0}:SeleteBrand>")]
    public class SeleteBrand : DropDownListMore
    {
         public SeleteBrand()
        {
            base.ApiName = ServiceApiName.webservice;
            base.ApiFunctionName = "GetSubBrand";
            base.Size = 5;
            base.ModuleID = "cfccc599-4585-43ed-ba31-fdb50024714b";
            
        }
    }
}