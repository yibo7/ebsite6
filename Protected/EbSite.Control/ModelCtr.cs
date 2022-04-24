using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Web.UI;

namespace EbSite.Control.Data
{
    [DefaultProperty("Text"), ToolboxData("<{0}:ModelCtr runat=server></{0}:ModelCtr>")]
    public class ModelCtr : DropDownList
    {
        public ModelCtr()
        {
            DataTextField = "Title";
            DataValueField = "ID";
            DataSource = Base.ExtWidgets.ModelCtr.DataBLL.Instance.GetList();
            DataBind();
        }
    }
}
