using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Web.UI;

namespace EbSite.ControlData
{
    public enum RepeaterIndexType
    {
        内容列表,
        分类列表
    }

    [DefaultProperty("Text"), ToolboxData("<{0}:RepeaterIndex runat=server></{0}:RepeaterIndex>")]
    public class RepeaterIndex : System.Web.UI.WebControls.Repeater
    {
        /// <summary>
        /// 指定调用的分类ID，如果为空，将调用全部一级分类,用逗号分开
        /// </summary>
        public string ClassIDs { get; set; }
        private RepeaterIndexType _DataType = RepeaterIndexType.内容列表;

        public RepeaterIndexType DataType
        {
            get
            {
                return _DataType;
            }
            set
            {
                _DataType = value;
            }
        }
    }
}
