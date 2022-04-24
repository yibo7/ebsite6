using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using DropDownList = EbSite.Control.DropDownList;

namespace EbSite.ControlData
{
    [DefaultProperty("Text"), ToolboxData("<{0}:UsreLevelList runat=server></{0}:UsreLevelList>")]
    public class UsreLevelList : DropDownList
    {
        public UsreLevelList()
        {

            BindD();
           
        }
        
        private void BindD()
        {
            List<Entity.UserLevel> ls = EbSite.BLL.UserLevel.Instance.GetListArray("");
            List<Entity.UserLevel> nls = (from li in ls
                                          orderby li.id
                                          //descending
                                          select li).ToList();
            ////
            AppendDataBoundItems = true;
            //if (IsInsertItem)
            //{
            //    Items.Insert(0, new ListItem("允许所有用户级别", "-1"));
            //    Items.Insert(1, new ListItem("禁止所有用户级别", "0"));
            //}
           

            DataTextField = "LevelName";
            DataValueField = "id";
            DataSource = nls;
            DataBind();
        }
         
    }
}
