using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Web;
using System.Xml;
using EbSite.Core.DataStore;

namespace EbSite.Base.ExtWidgets.HomeWidgetManage
{
    public class DataBLL : WidgetsManage.DataBLL
    {
        public static readonly DataBLL Instance = new DataBLL();

        public override ExtensionType ExtensionTp
        {
            get
            {
                return ExtensionType.HomeWidget;
            }
        }

    }
}
