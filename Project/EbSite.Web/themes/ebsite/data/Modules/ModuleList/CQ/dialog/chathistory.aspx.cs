using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace EbSite.Modules.CQ.dialog
{
    public partial class chathistory :Base.Page.BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int salerID = UserID;
                int userID = 0;
                if (Request.Params["uid"] != null)
                {
                    userID = Core.Utils.StrToInt(Request.Params["uid"],-1);
                }
                if (userID<1)
                {
                    userID = Core.Utils.StrToInt(Request.Params["u"].Replace("游客-", "").Trim(), 0);
                }
                if (salerID > 0 && userID > 0)
                {
                    DataTable dt = EbSite.BLL.Tool_ChatList.Instance.GetChatList(salerID, userID);
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        this.DataList.DataSource = dt;
                        this.DataList.DataBind();
                    }
                    else
                    {
                        this.DataList.DataSource = null;
                        this.DataList.DataBind();
                    }
                }
            }
        }
    }
}