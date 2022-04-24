using System;
using System.ComponentModel;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EbSite.Control
{

    public enum DatePickerModel:int
    {
        日期模式,
        数字模式
    }

    [DefaultEvent("Click"), DefaultProperty("Text"), ToolboxData("<{0}:DatePicker runat=server></{0}:DatePicker>")]
    public class DatePicker : TextBox
    {


        protected DropDownList drpHours;
        protected DropDownList drpMin;
        public DatePicker()
        {
            base.CssClass = "ebdatepickerbox form-control";
            //工具条引用不需要样式TextBoxDefault，工具条里引用好像不执行 OnInit
        }
        protected override void OnInit(EventArgs e)
        {
            base.CssClass = "ebdatepickerbox TextBoxDefault form-control";

            if (this.IsShowTime)
            {
                drpHours = new DropDownList();
                drpMin = new DropDownList();
                int num;
                string str;
                ListItem item;
                for (num = 0; num < 0x18; num++)
                {
                    str = num.ToString();
                    item = new ListItem(str, str);
                    this.drpHours.Items.Add(item);
                }
                for (num = 0; num < 60; num++)
                {
                    str = num.ToString();
                    item = new ListItem(str, str);
                    this.drpMin.Items.Add(item);
                }
                this.InitData();
                this.Controls.Add(this.drpHours);
                this.Controls.Add(this.drpMin);
            }

            base.OnInit(e);
        }

        private void InitData()
        {
            object objA = this.ViewState["DtValue"];
            if (!object.Equals(objA, null) && !string.IsNullOrEmpty(objA.ToString()))
            {
                DateTime time = DateTime.Parse(objA.ToString());
                if (this.IsShowTime)
                {
                    Hours = time.Hour.ToString();
                    Minute = time.Minute.ToString();
                    //this.drpHours.SelectedValue = time.Hour.ToString();
                    //this.drpMin.SelectedValue = time.Minute.ToString();
                }
                base.Text = time.ToString("yyyy-MM-dd");
            }
        }

        protected override void OnPreRender(EventArgs e)
        {
            if (!this.Page.ClientScript.IsClientScriptIncludeRegistered("DatePickerSet"))
            {
                string url = string.Format("{0}js/plugin/ui/datepicker/js.js", EbSite.Base.Host.Instance.IISPath);
                this.Page.ClientScript.RegisterClientScriptInclude("DatePickerSet", url);
            }
            base.OnPreRender(e);
        }

        protected override void Render(HtmlTextWriter output)
        {
            base.Render(output);
            if (this.IsShowTime)
            {
                output.Write("小时：");
                this.drpHours.RenderControl(output);
                output.Write("分钟：");
                this.drpMin.RenderControl(output);
            }
            //string str = "ob" + base.UniqueID;
            //output.Write("<script>var " + str + " =  document.getElementsByName(\"" + base.UniqueID + "\");$(function(){$(" + str + ").datepicker();});</script>");
        }

        [DefaultValue("false"), Description("是否显示时间。")]
        public bool IsShowTime
        {
            get
            {
                object objA = this.ViewState["IsShowTime"];
                return (!object.Equals(objA, null) && bool.Parse(objA.ToString()));
            }
            set
            {
                this.ViewState["IsShowTime"] = value;
            }
        }

        private DatePickerModel _TimeModel = DatePickerModel.日期模式;
        public DatePickerModel TimeModel
        {
            get { return _TimeModel; }
            set { _TimeModel = value; }
        }
        public string Value
        {
            get
            {
                if (TimeModel == DatePickerModel.日期模式)
                {
                    string text = base.Text;
                    if (string.IsNullOrEmpty(text))
                    {
                        return text;
                    }
                    if (this.IsShowTime)
                    {
                        DateTime time = DateTime.Parse(text);
                        return (time.ToString("yyyy-MM-dd") + " " + this.Hours + ":" + this.Minute);
                    }
                    return DateTime.Parse(text).ToString("yyyy-MM-dd");
                }
                else
                {
                    string text = base.Text;
                    if (string.IsNullOrEmpty(text))
                    {
                        return text;
                    }

                    string datetime = string.Empty;

                    if (this.IsShowTime)
                    {
                        DateTime time = DateTime.Parse(text);
                        datetime = (time.ToString("yyyy-MM-dd") + " " + this.Hours + ":" + this.Minute);
                    }
                    else
                    {
                        datetime = DateTime.Parse(text).ToString("yyyy-MM-dd");
                    }
                    return Core.SqlDateTimeInt.GetSecond(DateTime.Parse(datetime)).ToString();
                }
               
            }
            set
            {
                if (TimeModel == DatePickerModel.日期模式)
                {
                    this.ViewState["DtValue"] = value;
                }
                else
                {
                    if (Core.Utils.IsNumeric(value))
                    {
                        this.ViewState["DtValue"] = Core.SqlDateTimeInt.GetDateTime(int.Parse(value));
                    }
                    
                }
                this.InitData();
            }
        }
        public string Hours
        {
            get
            {
                this.EnsureChildControls();
                return this.drpHours.SelectedValue;
            }
            set
            {

                this.drpHours.SelectedValue = value;
            }
        }
        public string Minute
        {
            get
            {
                this.EnsureChildControls();
                return this.drpMin.SelectedValue;
            }
            set
            {

                this.drpMin.SelectedValue = value;
            }
        }
    }

    ///// <summary>
    ///// 编辑器
    ///// </summary>
    //[DefaultEvent("Click"), DefaultProperty("Text"), ToolboxData("<{0}:DatePicker runat=server></{0}:DatePicker>")]
    //public class DatePicker : WebControl, INamingContainer, IPostBackDataHandler
    //{
    //    #region 实现IPostBackDataHandler
    //    // <summary>
    //    /// 引发PostBack事件
    //    /// </summary>
    //    public void RaisePostDataChangedEvent()
    //    {
    //    }
    //    /// <summary>
    //    /// 加载提交信息
    //    /// </summary>
    //    /// <param name="postDataKey"></param>
    //    /// <param name="postCollection"></param>
    //    /// <returns></returns>
    //    public bool LoadPostData(string postDataKey, System.Collections.Specialized.NameValueCollection postCollection)
    //    {
    //        //string presentValue = this._AllValue.Value;
    //        //string postedValue = postCollection[postDataKey];

    //        //if (!presentValue.Equals(postedValue))//如果回发数据不等于原有数据
    //        //{
    //        //    this._AllValue.Value = postedValue;
    //        //    return true;
    //        //}
    //        //return false;

    //        return false;

    //    }
    //    #endregion



    //    #region Property
    //     [DefaultValue("false"), Category("Appearance"), Bindable(true)]
    //    public bool IsDisplayinline
    //    {
    //        get
    //        {
    //            object str = this.ViewState["IsDisplayinline"];
    //            if (str==null)
    //            {
    //                return false;
    //            }
    //            else
    //            {
    //                return bool.Parse(str.ToString());
    //            }
    //        }
    //        set
    //        {
    //            this.ViewState["IsDisplayinline"] = value;
    //        }
    //    }

    //    /// <summary>
    //    /// 日期
    //    /// </summary>

    //    public string Value
    //    {
    //        get
    //        {

    //            return DateTextBox.Text;
    //        }
    //        set
    //        {
    //            DateTextBox.Text = value;

    //        }

    //    }
    //    #endregion


    //    protected EbSite.Control.TextBox DateTextBox = new EbSite.Control.TextBox();

    //    protected override void CreateChildControls()
    //    {
    //        Controls.Clear();

    //        Controls.Add(DateTextBox);

    //    }



    //    protected override void OnPreRender(EventArgs e)
    //    {
    //        //if (!Page.ClientScript.IsClientScriptBlockRegistered("DatePickerSet"))
    //        //{
    //        //    string sCssAndJs =
    //        //        string.Format(
    //        //            "<link type=\"text/css\" href=\"{0}js/plugin/ui/base.css\" rel=\"stylesheet\" /><link type=\"text/css\" href=\"{0}js/plugin/ui/datepicker/css.css\" rel=\"stylesheet\" /><link type=\"text/css\" href=\"{0}js/plugin/ui/theme.css\" rel=\"stylesheet\" /><script type=\"text/javascript\" src=\"{0}js/plugin/ui/datepicker/js.js\"></script>", Base.AppStartInit.IISPath);

    //        //    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "DatePickerSet", sCssAndJs);
    //        //}

    //        base.OnPreRender(e);
    //    }
    //    /// <summary>
    //    /// 输出html,在浏览器中显示控件
    //    /// </summary>
    //    /// <param name="output"></param>
    //    protected override void Render(HtmlTextWriter output)
    //    {
    //        DateTextBox.Width = base.Width;
    //        DateTextBox.Height = base.Height; 
    //        if (IsDisplayinline) DateTextBox.Attributes.Add("style", "display:none");
    //        DateTextBox.RenderControl(output);
    //        string sID = string.Concat("ob", DateTextBox.UniqueID);
    //        if (!IsDisplayinline)
    //        {
    //            output.Write("<script>");
    //            output.Write("In.ready('datepicker', function () {");
    //            output.Write(string.Concat("var ", sID, " =  document.getElementsByName(\"", DateTextBox.UniqueID, "\");$(function(){$(", sID, ").datepicker();});"));
    //            output.Write("});");
    //            output.Write("</script>");
    //        }
    //        else
    //        {
    //            output.Write(string.Concat("<div id=\"", this.ClientID, "\"></div>"));
    //            output.Write("<script>");
    //            output.Write("In.ready('datepicker', function () {");
    //            output.Write(string.Concat("var ", sID, " =  document.getElementsByName(\"", DateTextBox.UniqueID, "\");$(function () {$('#", this.ClientID, "').datepicker({onSelect: function(dateText, inst){$(", sID, ").val(dateText); }});});$(document).ready(function() {$(", sID, ").val($('#", this.ClientID, "').val());});"));
    //            output.Write("});");
    //            output.Write("</script>");
    //        }

    //        //string sID = string.Concat("ob", DateTextBox.ClientID);
    //        //if (!IsDisplayinline)
    //        //{
    //        //    output.Write(string.Concat("<script>var ", sID, " =  document.getElementsByName(\"", DateTextBox.ClientID, "\");$(function(){$(", sID, ").datepicker();});</script>"));
    //        //}
    //        //else
    //        //{
    //        //    output.Write(string.Concat("<div id=\"", this.ClientID, "\"></div><script>var ", sID, " =  document.getElementsByName(\"", DateTextBox.ClientID, "\");$(function () {$('#", this.ClientID, "').datepicker({onSelect: function(dateText, inst){$(", sID, ").val(dateText); }});});$(document).ready(function() {$(", sID, ").val($('#", this.ClientID, "').val());});</script>"));
    //        //}
            

    //    }

    //}

}