using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.Modules;

namespace EbSite.Modules.Shop.AdminPages.Controls.Orders.HelpPage
{
    public partial class OrderLog : MPUCBaseList
    {
        protected long OrderCodeID
        {
            get
            {
                if (Request.Params["id"] != null)
                {
                    return Convert.ToInt64(Request.Params["id"]);
                }
                return 0;
            }
        }

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
            iCount = 0;
            return ModuleCore.BLL.buy_orderlog.Instance.GetListArray(0, string.Concat("orderid=",OrderCodeID), "");

        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}