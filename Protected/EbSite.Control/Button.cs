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
    [DefaultProperty("Text"), ToolboxData("<{0}:Button runat=server></{0}:Button>")]
    public class Button : System.Web.UI.WebControls.Button
    {

        private bool _confirm = false;
        private string _Tips_Complete = "";
        private string _Tips_Msg = "";

        public Button()
        {
            base.Load += new EventHandler(this.ButtonLoad);
            base.Click += new EventHandler(this.bnt_Click); 

        }

        protected void bnt_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.Tips_CompleteMsg))
            {
                Utils.RunClientJs(this, "showpop(\"" + this.Tips_CompleteMsg + "\")");
            }
        }

        public void ButtonLoad(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.CssClass))
                this.CssClass = "btn btn-primary";

            if (string.IsNullOrEmpty(this.OnClientClick))
            {
                string getTipsStr = "";
                if (this.Confirm)
                {
                    if (!string.IsNullOrEmpty(this.Tips_Msg))
                    {
                        getTipsStr = "var IsCF =  confirm('确认要" + base.Text + "?');if(IsCF){" + this.GetTipsStr + ";};return IsCF;";
                    }
                    else
                    {
                        getTipsStr = "return confirm('确认要" + base.Text + "?');";
                    }
                }
                else if (!string.IsNullOrEmpty(this.Tips_Msg))
                {
                    getTipsStr = this.GetTipsStr;
                }
                if (!string.IsNullOrEmpty(this.ValidationGroup))
                {
                    string sTipsjs = "if(!isok){ tips('某个输入格式不对',2);return  isok;};";
                    if (!string.IsNullOrEmpty(getTipsStr))
                    {
                        getTipsStr = string.Format("javascript:var isok = ValidateGP('{0}');{2} tips('{1}',1,300); return  isok;", this.ValidationGroup, this.Tips_Msg, sTipsjs);
                    }
                    else
                    {
                        getTipsStr = string.Format("javascript:var isok = ValidateGP('{0}');{1} tips('执行中...',1,300); return isok;", this.ValidationGroup, sTipsjs);
                    }
                }
                if (!string.IsNullOrEmpty(getTipsStr))
                {
                    this.OnClientClick = getTipsStr;
                }
            }



            if (!string.IsNullOrEmpty(HintInfo))
            {
                this.ToolTip = HintInfo;
                this.Attributes.Add("data-toggle", "tooltip");
            }
        }

        [Bindable(true), Category("Appearance"), DefaultValue("false")]
        public bool Confirm
        {
            get
            {
                return this._confirm;
            }
            set
            {
                this._confirm = value;
            }
        }

        [Bindable(true), Category("Appearance"), DefaultValue("false")]
        public bool IsTipsButtonRight { get; set; }

        private string GetTipsStr
        {
            get
            {
                if (!IsTipsButtonRight)
                {
                    return string.Format("OpenTipsToCenter('','{0}',200,100)", Tips_Msg);
                    
                }
                else
                {
                    return string.Format("CustomTipsWithCl(this,'{0}')", this.Tips_Msg);
                }
                
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
        [DefaultValue(""), Bindable(true), Category("Appearance")]
        public string Tips_CompleteMsg
        {
            get
            {
                return this._Tips_Complete;
            }
            set
            {
                this._Tips_Complete = value;
            }
        }

        [DefaultValue(""), Category("Appearance"), Bindable(true)]
        public string Tips_Msg
        {
            get
            {
                return this._Tips_Msg;
            }
            set
            {
                this._Tips_Msg = value;
            }
        }

        

    }

}