using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI.WebControls;
using DropDownList = EbSite.Control.DropDownList;

namespace EbSite.Web.PublicControl
{
    public class ModulesMues : DropDownList
    {
        public ModulesMues()
        {
            this.DataTextField = "MenuName";
            this.DataValueField = "id";
            this.DataSource = BLL.MenusForUser.Instance.GetListArray("");
            this.DataBind();

            this.Items.Insert(0, new ListItem("系统默认", ""));
        }
    }
}