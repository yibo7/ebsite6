using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.ControlPage;

namespace EbSite.Web.AdminHt.Controls.Admin_Spider
{
    public partial class VisitTime : UserControlBase
    {
        #region 权限

        public override string Permission
        {
            get
            {
                return "163";
            }
        } 
        #endregion
         

    }
}