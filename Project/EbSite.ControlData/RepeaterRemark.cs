using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Web.UI;

namespace EbSite.ControlData
{ 
    [DefaultProperty("Text"), ToolboxData("<{0}:RepeaterRemark runat=server></{0}:RepeaterRemark>")]
    public class RepeaterRemark : System.Web.UI.WebControls.Repeater
    {
        /// <summary>
        /// 指定调用评论分类ID
        /// </summary>
        public int RemarkClassID { get; set; }

        /// <summary>
        /// 每页显示多少
        /// </summary>
        /// <value>The size of the page.</value>
        public int PageSize { get; set; }

    }
}
