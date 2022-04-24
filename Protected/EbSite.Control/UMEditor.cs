
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using System.Web;
using System.Web.UI;

namespace EbSite.Control
{

     
    [DefaultEvent("Click"), ToolboxData("<{0}:UMEditor runat=server></{0}:UMEditor>"), DefaultProperty("Text")]
    public class UMEditor : System.Web.UI.Control, IUserContrlBase//, IPostBackEventHandler
    {    

           
        protected override void OnPreRender(EventArgs e)
        {
            if (!this.Page.ClientScript.IsClientScriptBlockRegistered("UMEditor"))
            {
                this.Page.ClientScript.RegisterClientScriptBlock(base.GetType(), "UMEditorCSS", string.Format("<link type=\"text/css\" href=\"{0}js/umeditor/themes/default/css/umeditor.css\" rel=\"stylesheet\" />", Base.AppStartInit.IISPath));
                
                this.Page.ClientScript.RegisterClientScriptInclude("UEditorconfig", string.Format("{0}js/umeditor/umeditor.config.js", Base.AppStartInit.IISPath));
                this.Page.ClientScript.RegisterClientScriptInclude("UEditorueditor", string.Format("{0}js/umeditor/umeditor.min.js", Base.AppStartInit.IISPath));
                 

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
                output.Write("var {0} = UM.getEditor('{0}');", this.ID);
                output.Write("</script>");
            }
            else
            {
                output.Write("<font color=#ff0000>请给UMEditor控件设置一个ID</font>");
            }
            

        }
         
    }

    

}
