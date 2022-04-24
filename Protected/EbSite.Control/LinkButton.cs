using System;
using System.ComponentModel;
using System.Text;
using System.Web.UI;
using EbSite.Core;

namespace EbSite.Control
{
    /// <summary>
    /// 控钮控件。
    /// </summary>
    [DefaultProperty("Text"), ToolboxData("<{0}:LinkButton runat=server></{0}:LinkButton>")]
    public class LinkButton : System.Web.UI.WebControls.LinkButton
    {
        private bool _confirm = false;
        private bool _IsButton = false;
        /// <summary>
        /// 是否以按钮的样式显示
        /// </summary>
        [Bindable(true), Category("Appearance"), DefaultValue("true")]
        public bool IsButton
        {
            get
            {
                return _IsButton;
            }
            set
            {
                _IsButton = value;
            }
        }
        /// <summary>
        /// 是否显示确认框
        /// </summary>
        [Bindable(true), Category("Appearance"), DefaultValue("true")]
        public bool confirm
        {
            get
            {
                return _confirm;
            }
            set
            {
                _confirm = value;
            }
        }
        public LinkButton()
        {
            this.Load += new EventHandler(LinkButtonLoad);
            this.Click += new EventHandler(lb_Click);

        }
        protected void lb_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Tips_CompleteMsg))
                Utils.RunClientJs(this, "showpop(\"" + Tips_CompleteMsg + "\")");
        }
        private string GetTipsStr
        {
            get
            {
                return string.Format("OpenTipsToCenter('{0}','{1}',{2},{3})", Tips_Title, Tips_Msg,
                                     Tips_Width, Tips_Height);
            }
        }
        private string _Tips_Complete = "";
        /// <summary>
        /// 操作完成后的提示
        /// </summary>
        [Bindable(true), Category("Appearance"), DefaultValue("")]
        public string Tips_CompleteMsg
        {
            get
            {
                return _Tips_Complete;
            }
            set
            {
                _Tips_Complete = value;
            }
        }
        private string _Tips_Title = "";
        /// <summary>
        ///操作_标题 为空将不显示标题
        /// </summary>
        [Bindable(true), Category("Appearance"), DefaultValue("")]
        public string Tips_Title
        {
            get
            {
                return _Tips_Title;
            }
            set
            {
                _Tips_Title = value;
            }
        }
        private string _Tips_Msg = "";
        /// <summary>
        /// 是否显示确认框_内容
        /// </summary>
        [Bindable(true), Category("Appearance"), DefaultValue("")]
        public string Tips_Msg
        {
            get
            {
                return _Tips_Msg;
            }
            set
            {
                _Tips_Msg = value;
            }
        }
        private int _Tips_Width = 350;
        /// <summary>
        /// 是否显示确认框_宽度
        /// </summary>
        [Bindable(true), Category("Appearance"), DefaultValue("")]
        public int Tips_Width
        {
            get
            {
                return _Tips_Width;
            }
            set
            {
                _Tips_Width = value;
            }
        }
        private int _Tips_Height = 120;
        /// <summary>
        /// 是否显示确认框
        /// </summary>
        [Bindable(true), Category("Appearance"), DefaultValue("")]
        public int Tips_Height
        {
            get
            {
                return _Tips_Height;
            }
            set
            {
                _Tips_Height = value;
            }
        }
        private string _Tips_TitleBgColor = "#ccc";
        /// <summary>
        /// 是否显示确认框
        /// </summary>
        [Bindable(true), Category("Appearance"), DefaultValue("")]
        public string Tips_TitleBgColor
        {
            get
            {
                return _Tips_TitleBgColor;
            }
            set
            {
                _Tips_TitleBgColor = value;
            }
        }
        private string _Tips_MsgBgColor = "#fff";
        /// <summary>
        /// 是否显示确认框
        /// </summary>
        [Bindable(true), Category("Appearance"), DefaultValue("")]
        public string Tips_MsgBgColor
        {
            get
            {
                return _Tips_MsgBgColor;
            }
            set
            {
                _Tips_MsgBgColor = value;
            }
        }
        public void LinkButtonLoad(object sender, EventArgs e)
        {
            string sOnClientClick = "";
            if (confirm)
            {
                if (!string.IsNullOrEmpty(Tips_Msg))
                {
                    sOnClientClick = "var IsCF =  confirm('确认要" + Tips_Msg + "?');if(IsCF){" + GetTipsStr + ";};return IsCF;";
                }
                else
                {
                    sOnClientClick = "return confirm('确认要" + this.Text + "?');";
                }


            }
            else
            {
                if (!string.IsNullOrEmpty(Tips_Msg)) sOnClientClick = GetTipsStr;
            }
            if (!string.IsNullOrEmpty(sOnClientClick)) this.OnClientClick = sOnClientClick;
            if (IsButton)
            {
                this.CssClass = "AdminButton";

            }
        }

    }
}