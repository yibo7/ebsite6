using System;
using System.Collections.Specialized;
using System.Web.UI;
using EbSite.Core.DataStore;

namespace EbSite.Base.ExtWidgets.ModelCtr
{
    public abstract class ModelCtrlEditBase : EditBase
    {
        public ModelCtrlEditBase()
        {
            base.Extensiontype = ExtensionType.Ctrl;
        }
        //public override ExtensionType ExtensionTp
        //{
        //    get
        //    {
        //        return ExtensionType.Ctrl;
        //    }
        //}
        public abstract void Save();
    }
}
