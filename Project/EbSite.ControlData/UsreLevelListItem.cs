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
    public class UsreLevelListItem : UsreLevelList
    {
        public UsreLevelListItem()
        {
            this.Load += new EventHandler(OnlaodData);

            
           
        }
        private void OnlaodData(object sender, EventArgs e)
        {
            Items.Insert(0, new ListItem("允许所有用户级别", "-1"));
            Items.Insert(1, new ListItem("禁止所有用户级别", "0"));
        }
         
    }
}
