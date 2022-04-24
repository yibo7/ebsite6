using System;
using System.Collections.Specialized;
using System.Web.UI;

using EbSite.Base.ExtWidgets.WidgetsManage;

namespace EbSite.Widgets.PageImgBox
{
    public partial class widget : WidgetBase
    {
        public override void LoadData()
        {
            
        }
        protected string BuilderJs()
        {
            string sHtml = "<script>ContentImgShow({0},{1},{2});</script> ";

            StringDictionary settings = GetSettings();
            string sObjID = "null";
            string sWidth = "";
            string sHeigth = "";
            if (settings.ContainsKey("ObjID"))
            {

                if (!string.IsNullOrEmpty(settings["ObjID"])) sObjID = string.Format("\"{0}\"", settings["ObjID"]);
            }
            if (settings.ContainsKey("Width"))
            {
                if (!Equals(settings["Width"],"0"))
                    sWidth = settings["Width"];

                sWidth = string.Format("\"{0}\"", sWidth);
            }
            if (settings.ContainsKey("Height"))
            {
                if (!Equals(settings["Height"], "0"))
                    sHeigth = settings["Height"];
                sHeigth = string.Format("\"{0}\"", sHeigth);
            }

            return string.Format(sHtml, sObjID, sWidth, sHeigth);
        }
        public override string Name
        {
            get { return "PageImgBox"; }
        }

        public override bool IsEditable
        {
            get { return true; }
        }
    }
}