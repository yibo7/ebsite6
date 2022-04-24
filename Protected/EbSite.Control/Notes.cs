using System;
using System.Collections;
using System.Data;
using System.Text;
using System.Text.RegularExpressions;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.ComponentModel;

namespace EbSite.Control
{
    /// <summary>
    /// 提示信息控件
    /// </summary>
    [DefaultEvent("Click"), DefaultProperty("Text"), ToolboxData("<{0}:Notes runat=server></{0}:Notes>")]
    public class Notes : System.Web.UI.WebControls.WebControl
    {
        public Notes()
        {
            
        }
        #region Property 

       
        [Bindable(true), Category("Appearance"), DefaultValue("")]
        public string Text
        {
            get
            {
                if (base.ViewState["Text"] != null)
                {
                    return (String)base.ViewState["Text"];
                }
                else
                {
                    return "";
                }
            }
            set
            {
                base.ViewState["Text"] = value;
            }
        }

        [Bindable(true), Category("Appearance"), DefaultValue("")]
        public string BgColor
        {
            get
            {
                if (base.ViewState["BgColor"] != null)
                {
                    return (String)base.ViewState["BgColor"];
                }
                else
                {
                    return "#FFF2E3";
                }
            }
            set
            {
                base.ViewState["BgColor"] = value;
            }
        }

        #endregion

        /// <summary>
        /// 输出html,在浏览器中显示控件
        /// </summary>
        /// <param name="output"></param>
        protected override void Render(HtmlTextWriter output)
        {
            if(this.Visible)
            {
               

                //StringBuilder sb = new StringBuilder();

                //sb.AppendFormat("<div onclick='$(this).hide()' style=\"width:{2}; height:{0};line-height:{0}; text-align:left; padding-left:10px;  background-color:{1};  border:1px dotted #ccc  \">", Height, BgColor, Width);
                //sb.AppendFormat("<table><tr><td style='width:16px'><img  width='16' height='16' border='0' src='{0}images/notes.gif'/></td><td style='width:100%;color:#5E5E5E;'>", EbSite.Base.AppStartInit.IISPath);
                //sb.Append(Text);
                ////sb.AppendFormat("<img width='16' onclick='$(this).parent().parent().parent().parent().parent().hide()' height='16' border='0' style=\"cursor:pointer;\" src='{0}images/off.gif'/>&nbsp;", EbSite.Base.AppStartInit.IISPath);
                //sb.Append("</td></tr></table>");
                //sb.Append("</div>");

                output.Write("<div class='alert alert-success'>{0}</div>", Text);
            }
            
        }

    }
}
