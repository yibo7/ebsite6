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
    [DefaultProperty("Text"), ToolboxData("<{0}:ModuleList runat=server></{0}:ModuleList>")]
    public class ModuleList : DropDownList
    {
        public ModuleList()
        {

            BindD();
           
        }
        
        private void BindD()
        {


            DataTextField = "ModuleName";
            DataValueField = "id";
            DataSource = EbSite.BLL.ModulesBll.Modules.Instance.FillList(); 
            DataBind();
            this.Items.Insert(0, new ListItem("选择模块", Guid.Empty.ToString()));
        }
         
    }
}
