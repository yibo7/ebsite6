
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using System.Web;
using System.Web.UI;

namespace EbSite.Control
{

     
    [DefaultEvent("Click"), ToolboxData("<{0}:UEditor runat=server></{0}:UEditor>"), DefaultProperty("Text")]
    public class UEditor : System.Web.UI.Control, IUserContrlBase//, IPostBackEventHandler
    {    

           
        protected override void OnPreRender(EventArgs e)
        {
            if (!this.Page.ClientScript.IsClientScriptBlockRegistered("UEditor"))
            {
                this.Page.ClientScript.RegisterClientScriptInclude("UEditorconfig", string.Format("{0}js/ueditor/ueditor.config.js", Base.AppStartInit.IISPath));
                this.Page.ClientScript.RegisterClientScriptInclude("UEditorueditor", string.Format("{0}js/ueditor/ueditor.all.min.js", Base.AppStartInit.IISPath));
                this.Page.ClientScript.RegisterClientScriptInclude("UEditorlang", string.Format("{0}js/ueditor/lang/zh-cn/zh-cn.js", Base.AppStartInit.IISPath));
                this.Page.ClientScript.RegisterClientScriptInclude("UEditorplugins", string.Format("{0}js/ueditor/plugins.js", Base.AppStartInit.IISPath));

            }
             
            
            base.OnPreRender(e);
        }

        public int Width { get; set; }
        public int Height { get; set; }
        private string _CtrValue;

        public string Text
        {
            get
            {
                if (Page.IsPostBack)
                {
                    return Page.Request.Form[this.ID];
                }
                return _CtrValue;
            }
            set
            {
                _CtrValue = value;
            }
        }

        public string CtrValue
        {
            get
            {
                if (Page.IsPostBack)
                {
                    return Page.Request.Form[this.ID];
                }
                return _CtrValue;
            }
            set
            {
                _CtrValue = value;
            }
        }

        protected override void Render(HtmlTextWriter output)
        {
            if (!string.IsNullOrEmpty(this.ID))
            {
                string sWidth = "width:100%";
                string sHeight = "height:100%";
                if (Width > 0)
                {
                    sWidth = string.Format("width:{0}px", Width);
                }
                if (Height > 0)
                {
                    sHeight = string.Format("height:{0}px", Height);
                }

                output.Write("<script id=\"{0}\" name=\"{0}\" type=\"text/plain\" style=\"{1};{2} \">{3}</script>", this.ID, sWidth, sHeight, CtrValue);
                output.Write("<script type=\"text/javascript\">");
                output.Write("var {0} = UE.getEditor('{0}');", this.ID);
                output.Write("</script>");
            }
            else
            {
                output.Write("<font color=#ff0000>请给UEditor控件设置一个ID</font>");
            }
            

        }
         
    }

    

}
