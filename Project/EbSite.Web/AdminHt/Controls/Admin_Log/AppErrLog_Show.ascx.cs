using System;
using System.Collections;
using System.Configuration;
using System.Data;

using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using EbSite.Base.ControlPage;
using EbSite.Core.Strings;
using EbSite.Entity;

namespace EbSite.Web.AdminHt.Controls.Admin_Log
{
    public partial class AppErrLog_Show : UserControlBase
    {
        private int LogID
        {
            get
            {
                if(!string.IsNullOrEmpty(Request["id"]))
                {
                    return int.Parse(Request["id"]);
                }
                else
                {
                    return 0;
                }
            }
        }
        private string type
        {
            get
            {
                return Request["type"];
            }
        }

        
        protected void Page_Load(object sender, EventArgs e)
        {
            //Entity.Logs mdLogs = new Logs(); 
            //if(string.IsNullOrEmpty(type))
            //{
            //    mdLogs = BLL.AppErrLog.SelectLogs(LogID);
                
            //}
            //else
            //{
            //    mdLogs = BLL.HTMLLog.SelectLogs(LogID);
            //}
            if (LogID>0)
            {
                Entity.Logs mdLogs = BLL.Logs.Instance.GetEntity(LogID);
                llInfo.Text = cConvert.strEncode(mdLogs.Description);
            }
            
        }
    }
}