using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.MobileControls;
using EbSite.Base.Extension.Manager;
using EbSite.Base.Plugin;
using EbSite.Core;
using EbSite.Core.FSO;  
using EbSite.Entity;
using EbSite.Pages;

namespace EbSite
{
    public partial class Profile : EbSite.Base.Page.BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Write(string.Format("这是1:{0}", Context.User.Identity.Name));
        
        }
         
         
       

    }
}
