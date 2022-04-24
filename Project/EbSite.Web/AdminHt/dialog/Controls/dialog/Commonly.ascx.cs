using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.ControlPage;
using EbSite.Web.AdminHt.Controls.Admin_Tem;

namespace EbSite.Web.AdminHt.dialog.Controls.dialog
{
    public partial class Commonly : BaseList
    {
        protected override string AddUrl
        {
            get { throw new NotImplementedException(); }
        }
        protected override void Delete(object ID)
        {
            throw new NotImplementedException();
        }
        protected override object LoadList(out int iCount)
        {
            throw new NotImplementedException();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
              
                RepCommon.DataSource = TemBll.GetAllColumns();
                RepCommon.DataBind();
            }
        }
    }
}
