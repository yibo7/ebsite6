using System;
using System.Collections;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.ComponentModel;
using EbSite.Control;


namespace EbSite.Control
{
    public enum CodeMode
    {
        Css,
        Htmlmixed,
        Javascript,
        Plsql,
        Tiddlywiki,
        Xml,
        Xmlpure,
        Aspx,
        CJavaCsharp
    }

    public enum CodeMirrorThemes
    {
        Cobalt,
        Default,
        Eclipse,
        Elegant,
        Neat,
        Night

    }

    [DefaultProperty("Text"), ToolboxData("<{0}:CodeMirror runat=server></{0}:CodeMirror>"), Designer("System.Web.UI.Design.WebControls.PreviewControlDesigner, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
    public class CodeMirror :TextBox
    {
        public CodeMirror()
        {
            this.TextMode = TextBoxMode.MultiLine;
        }
        //protected override void OnPreRender(EventArgs e)
        //{

        //    if (!Page.ClientScript.IsClientScriptBlockRegistered("CodeMirror_Lib"))
        //    {
        //        //string sCssAndJs =
        //        //  string.Format(
        //        //      "<link type=\"text/css\" href=\"{0}js/plugin/CodeMirror/lib/codemirror.css\" rel=\"stylesheet\" /><script type=\"text/javascript\" src=\"{0}js/plugin/CodeMirror/lib/codemirror.js\"></script><link type=\"text/css\" href=\"{0}js/plugin/CodeMirror/theme/default.css\" rel=\"stylesheet\" />", Base.AppStartInit.IISPath);
                

        //        StringBuilder sb = new StringBuilder();
        //        sb.AppendFormat("<link type=\"text/css\" href=\"{0}js/plugin/CodeMirror/lib/codemirror.css\" rel=\"stylesheet\" /><script type=\"text/javascript\" src=\"{0}js/plugin/CodeMirror/lib/codemirror.js\"></script>", Base.AppStartInit.IISPath);
        //        sb.AppendFormat("<link type=\"text/css\" href=\"{0}js/plugin/CodeMirror/theme/default.css\" rel=\"stylesheet\" />", Base.AppStartInit.IISPath);
        //        if (!IsShowTools)
        //        {
        //            if (Themes != CodeMirrorThemes.Default)
        //                sb.AppendFormat("<link type=\"text/css\" href=\"{0}js/plugin/CodeMirror/theme/{1}.css\" rel=\"stylesheet\" />", Base.AppStartInit.IISPath, Themes);
                
        //        }
        //        else
        //        {
        //            sb.AppendFormat("<link type=\"text/css\" href=\"{0}js/plugin/CodeMirror/theme/night.css\" rel=\"stylesheet\" />", Base.AppStartInit.IISPath);
        //            sb.AppendFormat("<link type=\"text/css\" href=\"{0}js/plugin/CodeMirror/theme/neat.css\" rel=\"stylesheet\" />", Base.AppStartInit.IISPath);
        //            sb.AppendFormat("<link type=\"text/css\" href=\"{0}js/plugin/CodeMirror/theme/elegant.css\" rel=\"stylesheet\" />", Base.AppStartInit.IISPath);
        //            sb.AppendFormat("<link type=\"text/css\" href=\"{0}js/plugin/CodeMirror/theme/cobalt.css\" rel=\"stylesheet\" />", Base.AppStartInit.IISPath);
        //            sb.AppendFormat("<link type=\"text/css\" href=\"{0}js/plugin/CodeMirror/theme/eclipse.css\" rel=\"stylesheet\" />", Base.AppStartInit.IISPath);
        //            sb.Append("<script>function selectTheme(node) {var theme = node.options[node.selectedIndex].innerHTML;editor.setOption(\"theme\", theme);}</script>");
        //        }
               
        //        Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "CodeMirror_Lib", sb.ToString());


        //    }
        //   if (Codemode == CodeMode.Htmlmixed)
        //    {
        //        RegisterJs(CodeMode.Xml);
        //        RegisterJs(CodeMode.Javascript);
        //        RegisterJs(CodeMode.Css);
        //        RegisterJs(CodeMode.Htmlmixed);
        //    }
        //    else if (Codemode == CodeMode.Aspx)
        //    {
                
        //        //RegisterJs(CodeMode.Xml);
        //        //RegisterJs(CodeMode.Javascript);
        //        //RegisterJs(CodeMode.Css);
        //        //RegisterJs(CodeMode.CJavaCsharp);
        //        RegisterJs(CodeMode.Htmlmixed);
        //    }
        //    else
        //    {
        //        RegisterJs(Codemode);
        //    }

        //    if(IsReSize)
        //    {
        //        if (!Page.ClientScript.IsClientScriptBlockRegistered("CodeMirror_Resize"))
        //        {
        //            string sResize = "<style type=\"text/css\">.CodeMirror {border: 1px solid #eee;}.CodeMirror-scroll {height: auto;overflow-y: hidden;overflow-x: auto;width: 100%;}</style>";
        //            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "CodeMirror_Resize", sResize);
        //        }
                
        //    }
        //    if (IsComplete)
        //    {
        //        if (!Page.ClientScript.IsClientScriptBlockRegistered("IsComplete"))
        //        {
        //            StringBuilder sb = new StringBuilder();
        //            sb.AppendFormat("<script type=\"text/javascript\" src=\"{0}js/plugin/CodeMirror/complete/html.js\"></script>", Base.AppStartInit.IISPath);
        //            sb.Append("<style type=\"text/css\"> .completions {position: absolute; z-index: 10; overflow: hidden; -webkit-box-shadow: 2px 3px 5px rgba(0,0,0,.2); -moz-box-shadow: 2px 3px 5px rgba(0,0,0,.2); box-shadow: 2px 3px 5px rgba(0,0,0,.2); }.completions select { background: #fafafa; outline: none; border: none; padding: 0;  margin: 0;font-family: monospace; }  .CodeMirror { border: 1px solid #eee; }</style> ");
        //            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "IsComplete", sb.ToString());
        //        }
        //    }

        //    base.OnPreRender(e);
        //}
        public CodeMirrorThemes Themes
        {
            get
            {
                object str = this.ViewState["Themes"];
                if (str != null)
                {
                    return (CodeMirrorThemes)str;
                }
                else
                {
                    return CodeMirrorThemes.Eclipse;
                }
            }
            set
            {
                this.ViewState["Themes"] = value;
            }
        }
        public CodeMode Codemode
        {
            get
            {
                object str = this.ViewState["Codemode"];
                if (str != null)
                {
                    return (CodeMode)str;
                }
                else
                {
                    return CodeMode.Htmlmixed;
                }
            }
            set
            {
                this.ViewState["Codemode"] = value;
            }
        }
        public bool IsReSize
        {
            get
            {
                object objA = this.ViewState["IsReSize"];
                if (!object.Equals(objA, null))
                {
                    return bool.Parse(objA.ToString());
                }
                return true;
            }
            set
            {
                this.ViewState["IsReSize"] = value;
            }
        }
        public bool IsLineNumber
        {
            get
            {
                object objA = this.ViewState["IsLineNumber"];
                if (!object.Equals(objA, null))
                {
                    return bool.Parse(objA.ToString());
                }
                return true;
            }
            set
            {
                this.ViewState["IsLineNumber"] = value;
            }
        }
        public bool IsComplete
        {
            get
            {
                object objA = this.ViewState["IsComplete"];
                if (!object.Equals(objA, null))
                {
                    return bool.Parse(objA.ToString());
                }
                return true;
            }
            set
            {
                this.ViewState["IsComplete"] = value;
            }
        }
        public bool IsShowTools
        {
            get
            {
                object objA = this.ViewState["IsShowTools"];
                if (!object.Equals(objA, null))
                {
                    return bool.Parse(objA.ToString());
                }
                return true;
            }
            set
            {
                this.ViewState["IsShowTools"] = value;
            }
        }
        private void RegisterJs(CodeMode cm)
        {
            string jspath = "js/plugin/CodeMirror/mode/{0}/{0}.js";
           
            if (cm == CodeMode.CJavaCsharp)
            {
                jspath = string.Format(jspath, "clike");
            }
            else if (cm == CodeMode.Htmlmixed)
            {
                jspath = string.Format(jspath, "htmlmixed");
            }
            else if (cm == CodeMode.Css)
            {
                jspath = string.Format(jspath, "css");
            }
            else if (cm == CodeMode.Javascript)
            {
                jspath = string.Format(jspath, "javascript");
            }
            else if (cm == CodeMode.Plsql)
            {
                jspath = string.Format(jspath, "plsql");
            }
            else if (cm == CodeMode.Tiddlywiki)
            {
                if (!Page.ClientScript.IsClientScriptBlockRegistered("Tiddlywikicss"))
                {
                    string sCssAndJs =
                   string.Format(
                       "<link type=\"text/css\" href=\"{0}js/plugin/CodeMirror/mode/tiddlywiki/tiddlywiki.css\" rel=\"stylesheet\" />", Base.AppStartInit.IISPath);
                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "CodeMirror_Lib", sCssAndJs);
                }
                jspath = string.Format(jspath, "tiddlywiki");
            }
            else if (cm == CodeMode.Xml)
            {
                jspath = string.Format(jspath, "xml");
            }
            else if (cm == CodeMode.Xmlpure)
            {
                jspath = string.Format(jspath, "xmlpure");
            }
            string sKey = string.Concat("CJavaCsharp", cm);
            if (!Page.ClientScript.IsClientScriptBlockRegistered(sKey))
            {
                string sCssAndJs =
                  string.Format(
                      "<script type=\"text/javascript\" src=\"{0}{1}\"></script>", Base.AppStartInit.IISPath, jspath);
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), sKey, sCssAndJs);
            }
           
        }
        //protected override void Render(HtmlTextWriter output)
        //{
        //    if (IsShowTools)
        //    {
        //        output.Write("<table style=\" width:100%;\"><tr><td>");
        //        output.Write("<input type=\"button\" value=\"新窗口打开\" onclick=\"window.open(location.href)\" />");
        //        output.Write("皮肤:<select onchange=\"selectTheme(this)\"><option selected>default</option><option>night</option><option>neat</option><option>elegant</option><option>cobalt</option><option>eclipse</option></select>");
        //        output.Write("</td></tr></table>");
        //    }
            

        //    base.Render(output);
            
        //    output.Write(" <script>");
        //    if (IsComplete)
        //    {
        //        string sTextMode = "xml";
        //        if (Codemode == CodeMode.Htmlmixed || Codemode == CodeMode.Aspx)
        //        {
        //            sTextMode = "text/html";
        //        }
        //        else if (Codemode == CodeMode.Css)
        //        {
        //            sTextMode = "css";
        //        }
        //        else if (Codemode == CodeMode.Javascript)
        //        {
        //            sTextMode = "javascript";
        //        }
        //        else if (Codemode == CodeMode.CJavaCsharp)
        //        {
        //            sTextMode = "text/x-csrc";
        //        }
        //        string sThemeName = "default";
        //        if (Themes != CodeMirrorThemes.Default)
        //        {
        //            sThemeName = Themes.ToString().ToLower();
        //        }
        //        output.Write(string.Format("new CompleteCss(\"{0}\",\"{1}\",{2},\"{3}\");", this.ClientID, sTextMode, IsLineNumber.ToString().ToLower(), sThemeName));
        //    }
        //    else
        //    {
        //        output.Write(" var editor = CodeMirror.fromTextArea(document.getElementById(\"");
        //        output.Write(this.ClientID);
        //        output.Write("\"), {");
        //        if (Codemode == CodeMode.Htmlmixed || Codemode == CodeMode.Aspx)
        //        {
        //            output.Write("mode: \"text/html\",");
        //        }

        //        if (IsLineNumber)
        //        {
        //            output.Write("lineNumbers: true");
        //        }

        //        if (Themes != CodeMirrorThemes.Default)
        //        {
        //            output.Write(",theme: \"" + Themes.ToString().ToLower() + "\"");
        //        }
        //        output.Write("});");
        //    }
           
        //    output.Write(" </script>");

         
        //}
       
    }

    

}
