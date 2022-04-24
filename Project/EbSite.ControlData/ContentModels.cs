using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Web.UI;
using EbSite.Control;

namespace EbSite.ControlData
{
    /// <summary>
    /// 内容模型
    /// </summary>
    [DefaultProperty("Text"), ToolboxData("<{0}:ContentModels runat=server></{0}:ContentModels>")]
    public class ContentModels : DropDownList
    {
        public ContentModels()
        {

            BindD();
           
        }
        public void BindD()
        {
            DataTextField = "ModelName";
            DataValueField = "ID";
            DataSource = BLL.WebModel.Instance.ModelClassList;//Base.ExtWidgets.ModelCtr.DataBLL.Instance.GetList();
            DataBind();
        }
         
    }
}
