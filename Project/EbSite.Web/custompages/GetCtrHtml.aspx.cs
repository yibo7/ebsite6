using System;
using EbSite.Control;

namespace EbSite.Web.CustomPages
{
    public partial class GetCtrHtml : System.Web.UI.Page
    {
        /// <summary>
        /// 获取控件ID
        /// </summary>
        private string sID
        {
            get
            {
                if(!string.IsNullOrEmpty(Request["widgetid"]))
                {
                    return Request["widgetid"];
                }
                return "";
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                if (!string.IsNullOrEmpty(sID))
                {
                     
                    ModelCtr.WidgetID = new Guid(sID);
                    

                }
                else
                {
                    Response.End();
                }
                
            }
        }
    }
}
