using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Web.UI;
using EbSite.Core;

namespace EbSite.Control
{

    [DefaultProperty("Text"), ToolboxData("<{0}:EasyuiDialog runat=server></{0}:EasyuiDialog>")]
    public class EasyuiDialog : WebControl
    {
        private string _Href = "";
        private string _HrefImg = "";
        private string _Text = "";
        private string _Title = "";

        public EasyuiDialog()
        {
            base.Width = 800;
            base.Height = 400;
            this.Title = "窗口名称";
        }

        protected override void OnPreRender(EventArgs e)
        {
            string iISPath = Base.AppStartInit.IISPath;
            if (!this.Page.ClientScript.IsClientScriptIncludeRegistered("EasyuiDialog"))
            {
                this.Page.ClientScript.RegisterClientScriptInclude("EasyuiDialog", string.Format("{0}js/plugin/EasyuiDialog/js.js", iISPath));
            }
            base.OnPreRender(e);
        }

        protected override void Render(HtmlTextWriter output)
        {
            if (this.Visible)
            {
                if (!LinkOnly)
                {
                    StringBuilder builder = new StringBuilder();
                    builder.AppendFormat(" edhref=\"{0}\"", this.Href);
                    builder.AppendFormat(" edwidth=\"{0}\"", this.Width);
                    builder.AppendFormat(" edheight=\"{0}\"", this.Height);
                    if (string.IsNullOrEmpty(this.Title))
                    {
                        builder.AppendFormat(" edtitle=\"{0}\"", this.Text);
                    }
                    else
                    {
                        builder.AppendFormat(" edtitle=\"{0}\"", this.Title);
                    }
                    if (this.IsColseReLoad)
                    {
                        builder.Append(" edrefesh=\"true\"");
                    }
                    else
                    {
                        builder.Append(" edrefesh=\"false\"");
                    }
                    if (this.IsModal)
                    {
                        builder.Append(" edmodal=\"true\"");
                    }
                    if (this.IsMaximizable)
                    {
                        builder.Append(" edmax=\"true\"");
                    }
                    if (this.IsMinimizable)
                    {
                        builder.Append(" edmin=\"true\"");
                    }
                    if (this.IsCollapsible)
                    {
                        builder.Append(" edcoll=\"true\"");
                    }
                    if (this.IsFull)
                    {
                        builder.Append(" isfull=\"true\"");
                    }

                     
                    builder.AppendFormat(" savetext=\"{0}\"", this.SaveText);
                    output.Write(string.Format(this.Text, builder.ToString()));
                }
                else
                {
                    output.Write(string.Format("<a href='{0}'>{1}</a>",Href, Text));
                }
                
            }
        }

        [DefaultValue(""), Bindable(true), Category("Appearance")]
        public string Href
        {
            get
            {
                return this._Href;
            }
            set
            {
                this._Href = value;
            }
        }

        [DefaultValue(""), Category("Appearance"), Bindable(true)]
        public string HrefImg
        {
            get
            {
                return this._HrefImg;
            }
            set
            {
                this._HrefImg = value;
            }
        }

        public bool IsCollapsible
        {
            get
            {
                object obj2 = this.ViewState["Collapsible"];
                return ((obj2 != null) && ((bool)obj2));
            }
            set
            {
                this.ViewState["Collapsible"] = value;
            }
        }

        public bool IsColseReLoad
        {
            get
            {
                object obj2 = this.ViewState["IsColseReLoad"];
                return ((obj2 != null) && ((bool)obj2));
            }
            set
            {
                this.ViewState["IsColseReLoad"] = value;
            }
        }
        public string SaveText
        {
            get
            {
                object obj2 = this.ViewState["SaveText"];
                if(!Equals(obj2,null))
                return obj2.ToString();
                return string.Empty;
            }
            set
            {
                this.ViewState["SaveText"] = value;
            }
        }
        /// <summary>
        /// 是否显示最小化按钮
        /// </summary>
        public bool IsMaximizable
        {
            get
            {
                object obj2 = this.ViewState["Maximizable"];
                return ((obj2 != null) && ((bool)obj2));
            }
            set
            {
                this.ViewState["Maximizable"] = value;
            }
        }
        /// <summary>
        /// 是否最大化
        /// </summary>
        public bool IsFull
        {
            get
            {
                object obj2 = this.ViewState["IsFull"];
                return ((obj2 != null) && ((bool)obj2));
            }
            set
            {
                this.ViewState["IsFull"] = value;
            }
        }
        /// <summary>
        /// 是否显示最大化按钮
        /// </summary>
        public bool IsMinimizable
        {
            get
            {
                object obj2 = this.ViewState["Minimizable"];
                return ((obj2 != null) && ((bool)obj2));
            }
            set
            {
                this.ViewState["Minimizable"] = value;
            }
        }

        public bool IsModal
        {
            get
            {
                object obj2 = this.ViewState["IsModal"];
                return ((obj2 != null) && ((bool)obj2));
            }
            set
            {
                this.ViewState["IsModal"] = value;
            }
        }

        public WinBoxLinkModel LinkModel
        {
            get
            {
                object objA = this.ViewState["LinkModel"];
                if (!object.Equals(objA, null))
                {
                    return (WinBoxLinkModel)objA;
                }
                return WinBoxLinkModel.文本连接;
            }
            set
            {
                this.ViewState["LinkModel"] = value;
            }
        }

        //private bool _LinkOnly = false;
        /// <summary>
        /// 只连接
        /// </summary>
        public bool LinkOnly
        {
            get
            {
                object objA = this.ViewState["LinkOnly"];
                if (!object.Equals(objA, null))
                {
                    return (bool)objA;
                }
                return false;
            }
            set {
                this.ViewState["LinkOnly"] = value;
            }
        }

        [Bindable(true), Category("Appearance"), DefaultValue("")]
        public string Text
        {
            get
            {
                if (this.LinkModel == WinBoxLinkModel.按钮)
                {
                    return ("<input type=\"submit\" id=\"" + this.ClientID + "\"  value=\"" + this._Text + "\" class=\"EasyuiDialog AdminButton\" {0} />");
                }
                if (this.LinkModel == WinBoxLinkModel.图片连接)
                {
                    return ("<img id=\"" + this.ClientID + "\" class=\"EasyuiDialog\"  style=\"border:solid 0px #ccc\" src=\"" + this.HrefImg + "\" {0} />");
                }
                if (this.LinkModel == WinBoxLinkModel.连接按钮)
                {
                    return (("<span id=\"" + this.ClientID + "\" class='btn btn-primary' {0} >") + this._Text + "</span>");
                }


                return (("<span style=\"cursor:pointer\" class=\"EasyuiDialog\" id=\"" + this.ClientID + "\" {0} >") + this._Text + "</span>");
            }
            set
            {
                this._Text = value;
            }
        }

        [Bindable(true), Category("Appearance"), DefaultValue("")]
        public string Title
        {
            get
            {
                return this._Title;
            }
            set
            {
                this._Title = value;
            }
        }
    }
}
