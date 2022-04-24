using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Amib.Threading;
using EbSite.Base;
using EbSite.Base.Configs.SysConfigs;

namespace EbSite.Web
{
    public partial class errhttp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (ConfigsControl.Instance.IsOpen404Log)
            {
                IWorkItemResult wir = ThreadPoolManager.Instance.QueueWorkItem(new WorkItemCallback(Host.Instance.Write404Log), HttpContext.Current);
            }

            Response.Status = "404 Not Found";
          
        }
        
    }
}