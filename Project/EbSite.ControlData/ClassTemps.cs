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
    /// 分类模板
    /// </summary>
    [DefaultProperty("Text"), ToolboxData("<{0}:ClassTemps runat=server></{0}:ClassTemps>")]
    public class ClassTemps : DropDownList
    {
        public ClassTemps()
        {

            BindD();
           
        }
        public void BindD()
        {

           DataValueField = "ID";
           DataTextField = "TemName";
           DataSource = TempFactory.Instance.GetListByType(1); //  BLL.Templates; 1是分类
           DataBind();
           
        }
         
    }
}
