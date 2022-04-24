using System;
using System.ComponentModel;
using System.Text;
using System.Web.UI;

namespace EbSite.Control
{
    /// <summary>
    /// Repeater 控件。
    /// </summary>
    [DefaultProperty("Text"), ToolboxData("<{0}:Repeater runat=server></{0}:Repeater>")]
    public class Repeater : System.Web.UI.WebControls.Repeater
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public Repeater()
            : base()
        {

        }

        

    }
}