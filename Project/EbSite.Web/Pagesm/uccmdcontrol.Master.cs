using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base;
using EbSite.Entity.Module;

namespace EbSite.Web.Pagesm
{
    public partial class uccmdcontrol : System.Web.UI.MasterPage
    {
        protected string MTitle
        {
            get { return ""; }
        }
        protected Host HostApi
        {
            get
            {
                return Host.Instance;
            }
        }
        protected string IISPath
        {
            get
            {
                return HostApi.IISPath;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
         protected string GetMenuUrl(object id)
        {
            return string.Format("?mukey={0}", id);
        }
    }
}