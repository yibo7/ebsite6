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
    /// <summary>
    /// 分类页面的列表版式列表
    /// </summary>
    [DefaultProperty("Text"), ToolboxData("<{0}:ClassListTem runat=server></{0}:ClassListTem>")]
    public class ClassListTem : DropDownList
    {
        public ClassListTem()
        {

            BindD();
           
        }
        public void BindD()
        {
            
            DataTextField = "Title";
            DataValueField = "ID";
            DataSource = BLL.Ctrtem.TemListInstace.TemBll(0).SelectCtrTemLists_ByClassID(new Guid("5f1ae5b4-440f-406f-ad13-54b9ba3378d0")); ;//Base.ExtWidgets.ModelCtr.DataBLL.Instance.GetList();
            DataBind();
            this.Items.Insert(0, new ListItem("不选择版式", Guid.Empty.ToString()));
        }
         
    }
}
