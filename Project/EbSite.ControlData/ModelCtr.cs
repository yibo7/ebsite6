using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Web.UI;
using EbSite.Control;

namespace EbSite.ControlData
{
    [DefaultProperty("Text"), ToolboxData("<{0}:ModelCtr runat=server></{0}:ModelCtr>")]
    public class ModelCtr : DropDownList
    {
        public ModelCtr()
        {

            BindD();
           
        }
        public void BindD()
        {
            DataTextField = "Title";
            DataValueField = "DataID";
            DataSource = Base.ExtWidgets.ModelCtr.DataBLL.Instance.GetList();
            DataBind();
        }
         
    }
}
