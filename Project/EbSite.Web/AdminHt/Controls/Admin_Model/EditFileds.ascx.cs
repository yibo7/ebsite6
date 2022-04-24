using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.ControlPage;
using EbSite.BLL;
using EbSite.BLL.ModelBll;
using EbSite.Entity;

namespace EbSite.Web.AdminHt.Controls.Admin_Model
{
    public partial class EditFileds : EditFiledsBase
    {


        protected void Page_Load(object sender, EventArgs e)
        {
            //ctbTag.EndLiteral = llTagEnd;
            //ctbTag.Items = "字段参数#tg1|其他参数#tg2";
            if (!IsPostBack)
            {
                BindData();

            }

        }

    }
}