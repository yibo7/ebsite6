using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.UI;
using EbSite.Control;

namespace EbSite.Modules.Wenda.Ctrs
{

    /// <summary>
    /// 编辑器
    /// </summary>
    [DefaultEvent("Click"), DefaultProperty("Text"), ToolboxData("<{0}:BmAskClass runat=server></{0}:BmAskClass>")]
    public class BmAskClass : DropDownListMore
    {

        public BmAskClass()
        {
            base.ApiName = ServiceApiName.webservice;
            base.ApiFunctionName = "BmGetClass";
            base.ModuleID = "4e0edb7e-1b30-41ad-9f74-d63c80458c35";
        }
    }
}