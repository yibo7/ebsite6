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
    [DefaultProperty("Text"), ToolboxData("<{0}:ContentTempsMobile runat=server></{0}:ContentTemps>")]
    public class ContentTempsMobile : DropDownList
    {
        public ContentTempsMobile()
        {

            BindD();
           
        }
        public void BindD()
        {
            DataValueField = "ID";
            DataTextField = "TemName";
            DataSource =  TempFactory.InstanceMobile.GetListByType(2);  //  2是内容
            DataBind();
           
        }
         
    }
}
