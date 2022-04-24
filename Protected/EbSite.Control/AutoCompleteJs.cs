using System;
using System.Collections;
using System.Collections.Specialized;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.ComponentModel;
using EbSite.Control;
using EbSite.Core;


namespace EbSite.Control
{


    [DefaultProperty("Text"), ToolboxData("<{0}:AutoCompleteJs runat=server></{0}:AutoCompleteJs>"), Designer("System.Web.UI.Design.WebControls.PreviewControlDesigner, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
    public class AutoCompleteJs : EbSite.Control.WebControl, IUserContrlBase, INamingContainer, IPostBackDataHandler
    {
        public void RaisePostDataChangedEvent()
        {
        }
        public bool LoadPostData(string postDataKey, NameValueCollection postCollection)
        {
            string str = this.txtBox.Text;
            string str2 = postCollection[postDataKey];
            if (!str.Equals(str2))
            {
                this.txtBox.Text = str2;
                return true;
            }
            return false;
        }
        public string CtrValue
        {
            get
            {
                return this.txtBox.Text;
            }
            set
            {
                this.txtBox.Text = value;
            }
        }
        public string Text
        {
            get
            {
                return this._hfText.Value;
            }
            set
            {
                this._hfText.Value = value;
            }
        }
        public string Msg
        {
            get
            {
                object objA = this.ViewState["Msg"];
                if (!object.Equals(objA, null))
                {
                    return objA.ToString();
                }
                return "";
            }
            set
            {
                this.ViewState["Msg"] = value;
            }
        }

        public string ClassID
        {
            get
            {
                return this._hfClassID.Value;
            }
            set
            {
                this._hfClassID.Value = value;
            }
        }

        public string ClassName
        {
            get
            {
                return this._hfClassName.Value;
            }
            set
            {
                this._hfClassName.Value = value;
            }
        }

        public string DataID
        {
            get
            {
                return this._hfID.Value;
            }
            set
            {
                this._hfID.Value = value;
            }
        }

        private HiddenField _hfClassID = new HiddenField();
        private HiddenField _hfClassName = new HiddenField();
        private HiddenField _hfID = new HiddenField();
        private HiddenField _hfText = new HiddenField();
        /// <summary>
        /// 只用来显示，没有传值作用，因为js会在载入时重置
        /// </summary>
        private TextBox txtBox = new TextBox();
        protected override void CreateChildControls()
        {
            this.Controls.Clear();
            this._hfClassID.ID = string.Concat("cid" , this.ID);
            this.Controls.Add(this._hfClassID);

            this._hfClassName.ID = string.Concat("cna", this.ID);
            this.Controls.Add(this._hfClassName);

            this._hfID.ID = string.Concat("id", this.ID);
            this.Controls.Add(this._hfID);

            this.txtBox.ID = string.Concat("mid", this.ID);
            this.Controls.Add(this.txtBox);

            this._hfText.ID = string.Concat("txt", this.ID);
            this.Controls.Add(this._hfText);
        }
       
        protected override void OnPreRender(EventArgs e)
        {

            //if (!Page.ClientScript.IsClientScriptBlockRegistered("AutoCompleteJs"))
            //{
            //    string sCssAndJs =
            //        string.Format(
            //            "<link type=\"text/css\" href=\"{0}js/plugin/AutoComplete/css.css\" rel=\"stylesheet\" /><script type=\"text/javascript\" src=\"{0}js/plugin/AutoComplete/js.js\"></script>", Base.AppStartInit.IISPath);

            //    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "AutoCompleteJs", sCssAndJs);
            //}

            if (!this.Page.ClientScript.IsClientScriptBlockRegistered("AutoCompleteJs"))
            {
                this.Page.ClientScript.RegisterClientScriptInclude("AutoCompleteJs", string.Format("{0}js/plugin/AutoComplete/js.js", Base.AppStartInit.IISPath));
                this.Page.ClientScript.RegisterClientScriptBlock(base.GetType(), "AutoCompleteJscss", string.Format("<link type=\"text/css\" href=\"{0}js/plugin/AutoComplete/css.css\" rel=\"stylesheet\" />", Base.AppStartInit.IISPath));
            }
           
            
            base.OnPreRender(e);
        }
        public AutoCompleteJs()
        {
            base.CssClass = "TextBoxDefault";

        }

        /// <summary>
        /// js回调方法,用户选择了一个选择后会回调，返回参数 function funback(id, name, subid, subname)
        /// 设置时只调用为 方法名 funback
        /// </summary>
        public string BackFun
        {
            get
            {
                object objA = this.ViewState["BackFun"];
                if (!object.Equals(objA, null))
                {
                    return objA.ToString();
                }
                return "null";
            }
            set
            {
                this.ViewState["BackFun"] = value;
            }
        }

        /// <summary>
        /// 如datajson/hotbrand.js
        /// </summary>
        public string HotDataJsPath
        {
            get
            {
                object objA = this.ViewState["HotDataJsPath"];
                if (!object.Equals(objA, null))
                {
                    return  objA.ToString();
                }
                return "";
            }
            set
            {
                this.ViewState["HotDataJsPath"] = value;
            }
        }
        /// <summary>
        /// datajson/data.js
        /// </summary>
        public string DataJsPath
        {
            get
            {
                object objA = this.ViewState["DataJsPath"];
                if (!object.Equals(objA, null))
                {
                    return objA.ToString();
                }
                return "";
            }
            set
            {
                this.ViewState["DataJsPath"] = value;
            }
        }

        protected override void Render(HtmlTextWriter output)
        {
            
            if(!string.IsNullOrEmpty(DataJsPath))
            {
                string hotdataname = Core.Strings.GetString.GetFileNameNoEx(HotDataJsPath);
                string dataname = Core.Strings.GetString.GetFileNameNoEx(DataJsPath);

                this._hfClassID.RenderControl(output);
                this._hfClassName.RenderControl(output);
                this._hfID.RenderControl(output);
                txtBox.RenderControl(output);
                _hfText.RenderControl(output);
                
                output.Write("<script type=\"text/javascript\">");

                output.Write(" $(document).ready(function () {");
                output.Write("$.getScript(\"" + HotDataJsPath + "\", function () {");
                output.Write("     $.getScript(\"" + DataJsPath + "\", function () {");
                output.Write("         $(\"#" + txtBox.ClientID + "\").suggest(" + dataname + ", {");
                output.Write("            hotList: " + hotdataname + ",");
                output.Write("            defaultValue: \"全拼|简拼|中文\",");
                output.Write("            openFocusTip: true,");
                output.Write("            emptyDisplayHot: true,valueids:{\"acid\":\"" + _hfID.ClientID + "\",\"aclassid\":\"" + _hfClassID.ClientID + "\",\"aclassname\":\"" + _hfClassName.ClientID + "\",\"txtid\":\"" + _hfText.ClientID + "\"}   ");
                output.Write("        }");
                if (!string.IsNullOrEmpty(BackFun))
                {
                    output.Write(",");
                    output.Write(BackFun);
                }
                output.Write("        );");
                output.Write("     });");
                output.Write("  });");
                output.Write(" });");

                output.Write("</script>");
            }
            else
            {
                throw new Exception("引用了AutoCompleteJs控件，但未指定js数据源");
            }
            //base.Render(output);
            
        }

    }

    

}
