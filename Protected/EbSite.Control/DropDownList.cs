using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ComponentModel;
namespace EbSite.Control
{
	/// <summary>
	/// 下拉列表控件。
	/// </summary>
	[DefaultProperty("Text"), ToolboxData("<{0}:DropDownList runat=server></{0}:DropDownList>")]
    public class DropDownList : System.Web.UI.WebControls.DropDownList, IUserContrlBase
	{
		/// <summary>
		/// 构造函数
		/// </summary>
		public DropDownList(): base()
		{
            base.CssClass = "form-control";
        }
        protected override void OnInit(EventArgs e)
        {
            if (!string.IsNullOrEmpty(HintInfo))
            {
                this.ToolTip = HintInfo;
                this.Attributes.Add("data-toggle", "tooltip");
                //base.Attributes.Add("onmouseover", string.Format("TipsAutoClose(this,'{0}')", HintInfo));
            }
                
            base.OnInit(e);
        }
	    public string CtrValue
	    {
	        get
	        {
	            return this.SelectedValue;
	        }
            set
	        {
                this.SelectedValue = value;
	        }
	    }
        /// <summary>
        /// 当某选项被选中后,获取焦点的控件ID(如提交按钮等)
        /// </summary>
		[Bindable(true),Category("Appearance"),DefaultValue("")] 
		public string SetFocusButtonID
		{
			get
			{
				object o = ViewState[this.ClientID+"_SetFocusButtonID"];
				return (o==null)?"":o.ToString(); 
			}
			set
			{
				ViewState[this.ClientID+"_SetFocusButtonID"] = value;
				if(value!="")
				{
					this.Attributes.Add("onChange","document.getElementById('"+value+"').focus();");
				}
			}
		}


        //private string _hintTitle = "";
        ///// <summary>
        ///// 提示框标题
        ///// </summary>
        //[Bindable(true), Category("Appearance"), DefaultValue("")]
        //public string HintTitle
        //{
        //    get { return _hintTitle; }
        //    set { _hintTitle = value; }
        //}


        private string _hintInfo = "";
        /// <summary>
        /// 提示框内容
        /// </summary>
        [Bindable(true), Category("Appearance"), DefaultValue("")]
        public string HintInfo
        {
            get { return _hintInfo; }
            set { _hintInfo = value; }
        }


        /// <summary> 
        /// 输出html,在浏览器中显示控件
        /// </summary>
        /// <param name="output"> 要写出到的 HTML 编写器 </param>
        protected override void Render(HtmlTextWriter output)
        {
            //if (this.HintInfo != "")
            //{
            //    output.WriteBeginTag("span id=\"" + this.ClientID + "\"  onmouseover=\"showhintinfo(this," + this.HintLeftOffSet + "," + this.HintTopOffSet + ",'" + this.HintTitle + "','" + this.HintInfo + "','" + this.HintHeight + "','" + this.HintShowType + "');\" onmouseout=\"hidehintinfo();\">");
            //}

            base.Render(output);

            //if (this.HintInfo != "")
            //{
            //    output.WriteEndTag("span");
            //}
        }
	
	}

}
