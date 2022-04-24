using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Web.UI;

namespace EbSite.Control
{
    [ToolboxData("<{0}:CheckBoxList runat=server></{0}:CheckBoxList>"), DefaultProperty("Text")]
    public class CheckBox : System.Web.UI.WebControls.CheckBox, IUserContrlBase
    {
        /// <summary>
        /// 实现接口
        /// </summary>
        public string CtrValue
        {
            get { return this.Checked.ToString(); }
            set { this.Checked = bool.Parse(value); }
        }
        protected override void OnInit(EventArgs e)
        {
            if (!string.IsNullOrEmpty(HintInfo))
            {
                this.ToolTip = HintInfo;
                this.Attributes.Add("data-toggle", "tooltip"); 
            }
            //if (!string.IsNullOrEmpty(HintInfo))
            //    base.Attributes.Add("onmouseover", string.Format("TipsAutoClose(this,'{0}')", HintInfo));
            base.OnInit(e);
        }
        public string _Value;

        protected override void AddAttributesToRender(HtmlTextWriter writer)
        {
            writer.AddAttribute(HtmlTextWriterAttribute.Value, this.Value);
            base.AddAttributesToRender(writer);
        }

        protected override void RenderContents(HtmlTextWriter output)
        {
            base.RenderContents(output);
        }

        [DefaultValue(""), Localizable(true), Category("Appearance"), Bindable(true)]
        public string Value
        {
            get
            {
                string str = (string)this.ViewState["Value"];
                return (string.IsNullOrEmpty(str) ? "on" : str);
            }
            set
            {
                this.ViewState["Value"] = value;
            }
        }
        public string HintInfo
        {
            get
            {
                object objA = this.ViewState["HintInfo"];
                if (!object.Equals(objA, null))
                {
                    return objA.ToString();
                }
                return "";
            }
            set
            {
                this.ViewState["HintInfo"] = value;
            }
        }
    }
}
