using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Web.UI;
using EbSite.Core;

namespace EbSite.Control
{
    public enum BoxValidateType
    {
        不作验证 = 0,
        金额 = 1,
        电子邮箱email = 2,
        手机号 = 3,
        QQ号 = 4,
        网址Url = 5,
        正整数 = 6,
        IP地址 = 7,
        身份证 = 8,
        邮政编码 = 9,
        电话号码加区号 = 10,
        账号字母开头数字下划线 = 11,
        匹配正整数 = 12,
        负整数 = 13,
        整数 = 14,
        大于等于0整数包括0 = 15,
        小于等于0整数包括0 = 16,
        匹配正浮点数 = 17,
        匹配负浮点数 = 18,
        匹配由26个英文字母组成的字符串 = 19,
        匹配由26个英文字母的大写组成的字符串 = 20,
        匹配由26个英文字母的小写组成的字符串 = 21,
        匹配由数字和26个英文字母组成的字符串 = 22,
        匹配由数字26个英文字母或者下划线组成的字符串 = 23,
        日期格式为yyyymmdd = 24,
        禁止输入特殊字符 = 25,


        
    }

    [Designer("System.Web.UI.Design.WebControls.PreviewControlDesigner, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"), ToolboxData("<{0}:TextBoxVl runat=server></{0}:TextBoxVl>"), DefaultProperty("Text")]
    public class TextBoxVl : TextBox, IUserContrlBase
    {
        public string CtrValue
        {
            get
            {
                return this.Text;
            }
            set
            {
                this.Text = value;
            }
        }

        public void AddAttributes(string key, string valuestr)
        {
            base.Attributes.Add(key, valuestr);
        }

        protected override void CreateChildControls()
        {
        }

        protected override void OnPreRender(EventArgs e)
        {
            if (!this.Page.ClientScript.IsClientScriptBlockRegistered("TextBoxVl"))
            {
                this.Page.ClientScript.RegisterClientScriptInclude("TextBoxVl", string.Format("{0}js/plugin/validatebox/js.js", Base.AppStartInit.IISPath));
                this.Page.ClientScript.RegisterClientScriptBlock(this.Page.GetType(), "TextBoxVl", string.Format("<link type=\"text/css\" href=\"{0}js/plugin/validatebox/css.css\" rel=\"stylesheet\" />", Base.AppStartInit.IISPath));
                this.Page.ClientScript.RegisterClientScriptBlock(this.Page.GetType(), "TextBoxVl2", "<script>jQuery(function($) {InitTextBoxVl('" + this.Page.Form.ClientID + "');});function ValidateGP(gName) { return ValidateByGPName('" + this.Page.Form.ClientID + "',gName);};</script>");
            }
            int validateType = (int)this.ValidateType;
            if (validateType > 0)
            {
                this.AddAttributes("valtype", validateType.ToString());
            }

            if (!string.IsNullOrEmpty(this.ValidationGroup))
            {
                this.AddAttributes("vglp", this.ValidationGroup);
            }
            else
            {
                this.Page.ClientScript.RegisterOnSubmitStatement(base.GetType(), "ValidateForm", string.Format("return ValidateForm('{0}');", this.Page.Form.ClientID));
            }

            if (!string.IsNullOrEmpty(this.Msg))
            {
                this.AddAttributes("msg", this.Msg);
            }
            if (!string.IsNullOrEmpty(this.MsgErr))
            {
                this.AddAttributes("errmsg", this.MsgErr);
            }
            if (!this.IsAllowNull)
            {
                this.AddAttributes("isnull", "0");
            }
            base.OnPreRender(e);
        }

        public bool IsAllowNull
        {
            get
            {
                object objA = this.ViewState["IsAllowNull"];
                if (!object.Equals(objA, null))
                {
                    return bool.Parse(objA.ToString());
                }
                return true;
            }
            set
            {
                this.ViewState["IsAllowNull"] = value;
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

        public string MsgErr
        {
            get
            {
                object objA = this.ViewState["MsgErr"];
                if (!object.Equals(objA, null))
                {
                    return objA.ToString();
                }
                return "";
            }
            set
            {
                this.ViewState["MsgErr"] = value;
            }
        }

        public BoxValidateType ValidateType
        {
            get
            {
                object objA = this.ViewState["ValidateType"];
                if (!object.Equals(objA, null))
                {
                    return (BoxValidateType)objA;
                }
                return BoxValidateType.不作验证;
            }
            set
            {
                this.ViewState["ValidateType"] = value;
            }
        }
    }
}
