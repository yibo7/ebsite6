using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using DropDownList = EbSite.Control.DropDownList;

namespace EbSite.Web.WebCore.PublicControl
{
    public class TemMethod : DropDownList
    {
        public TemMethod()
        {
            this.Attributes.Add("onchange", "InserField(this)");
            this.HintInfo = "公共函数库里的默认调用代码为非控件内部调用代码，如果是在控件内绑定，请将=号改成#号";
            this.DataTextField = "Title";
            this.DataValueField = "GetCode";
            this.DataSource = BLL.TemMethod.Instance.FillList();
            this.DataBind();
            this.Items.Insert(0, new ListItem("选择函数", ""));
        }
    }
}