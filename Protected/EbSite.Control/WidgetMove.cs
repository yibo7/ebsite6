using System;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.ExtWidgets.WidgetsManage;

namespace EbSite.Control
{
    public class WidgetMove : Widget
    {
        private string _CtrID;
        public string CtrID
        {
            get
            {
                return _CtrID;
            }
            set
            {
                _CtrID = value;
            }
        }

        private bool _IsManager;
        public bool IsManager
        {
            get
            {
                return _IsManager;
            }
            set
            {
                _IsManager = value;
            }
        }

        
        //protected override void Render(HtmlTextWriter output)
        //{
           

        //    StringBuilder sb = new StringBuilder();
        //    string sManager = "";
        //    if (IsManager)
        //        sManager = "movable removable editable closeconfirm collapsable";
        //    sb.AppendFormat("<div id=\"{0}\"  t=\"{1}\" twid=\"{2}\" class=\"widget   {3}\">", WidgetID, WidgetType, CtrID, sManager);
        //    if (!string.IsNullOrEmpty(TitleLink))
        //        Title = string.Format("<a href=\"{0}\">{1}</a>", TitleLink, Title);
        //    sb.AppendFormat("<div class=\"widget-header\"><span class='widgettitle_text'>{0}<span></div>", Title);
        //    sb.Append("<div class=\"widget-content\">"); 
        //    output.Write(sb.ToString());
        //    base.Render(output);
        //    output.Write("</div>");
        //    output.Write("</div>");
        //}
    }
}
