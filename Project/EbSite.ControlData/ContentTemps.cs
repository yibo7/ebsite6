using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Web.UI;
using EbSite.BLL;
using EbSite.Control;

namespace EbSite.ControlData
{
    /// <summary>
    /// 内容模板
    /// </summary>
    [DefaultProperty("Text"), ToolboxData("<{0}:ContentTemps runat=server></{0}:ContentTemps>")]
    public class ContentTemps : DropDownList
    {
        public ContentTemps()
        {

            BindD();
           
        }
        public void BindD()
        {
            DataValueField = "ID";
            DataTextField = "TemName";
            DataSource = TempFactory.Instance.GetListByType(2); // BLL.Templates.GetListByType(2); //  2是内容
            DataBind();
           
        }
         
    }
}
