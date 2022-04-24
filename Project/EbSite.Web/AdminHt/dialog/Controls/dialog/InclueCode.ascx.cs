using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.BLL;
using EbSite.Base;
using EbSite.Base.ControlPage;
using EbSite.Web.AdminHt.Controls.Admin_Tem;

namespace EbSite.Web.AdminHt.dialog.Controls.dialog
{
    public partial class InclueCode : BaseList
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
                TemBll.IncBll.RefeshInc();
                List<EbSite.Entity.Templates> ls = TemBll.IncBll.IncsList;
                RepInclude.DataSource = ls;
                RepInclude.DataBind();
            }
        }
    }
}