using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ComponentModel;




namespace EbSite.Control
{
	/// <summary>
	/// CheckBoxList 控件。
	/// </summary>
	[DefaultProperty("Text"), ToolboxData("<{0}:CheckBoxList runat=server></{0}:CheckBoxList>")]
    public class CheckBoxList : System.Web.UI.WebControls.CheckBoxList,  IPostBackDataHandler
	{
        /// <summary>
        /// 构造函数
        /// </summary>
		public CheckBoxList(): base()
		{
			//this.BorderStyle=BorderStyle.Dotted; 
			//this.BorderWidth=1; 
			//this.Font.Size=10; 
			this.RepeatColumns=2;
			this.Width=Unit.Percentage(100);
			//this.Font.Size=FontUnit.Smaller;
			this.RepeatDirection=RepeatDirection.Vertical;
			this.RepeatLayout = RepeatLayout.Table;
            this.CssClass = "buttonlist";
            
		}
        protected override void OnInit(EventArgs e)
        {
            if (!string.IsNullOrEmpty(HintInfo))
            {
                this.ToolTip = HintInfo;
                this.Attributes.Add("data-toggle", "tooltip");
            } 
            base.OnInit(e);
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

        //private int _hintLeftOffSet = 0;

        ///// <summary>
        ///// 提示框左侧偏移量
        ///// </summary>
        //[Bindable(true), Category("Appearance"), DefaultValue(0)]
        //public int HintLeftOffSet
        //{
        //    get { return _hintLeftOffSet; }
        //    set { _hintLeftOffSet = value; }
        //}

        //private int _hintTopOffSet = 0;

        ///// <summary>
        ///// 提示框顶部偏移量
        ///// </summary>
        //[Bindable(true), Category("Appearance"), DefaultValue(0)]
        //public int HintTopOffSet
        //{
        //    get { return _hintTopOffSet; }
        //    set { _hintTopOffSet = value; }
        //}

        //private string _hintShowType = "up";//或"down"

        ///// <summary>
        ///// 提示框风格,up(上方显示)或down(下方显示)
        ///// </summary>
        //[Bindable(true), Category("Appearance"), DefaultValue("up")]
        //public string HintShowType
        //{
        //    get { return _hintShowType; }
        //    set { _hintShowType = value; }
        //}

        //private int _hintHeight = 50;

        ///// <summary>
        ///// 提示框高度
        ///// </summary>
        //[Bindable(true), Category("Appearance"), DefaultValue(130)]
        //public int HintHeight
        //{
        //    get { return _hintHeight; }
        //    set { _hintHeight = value; }
        //}

        /// <summary> 
        /// 输出html,在浏览器中显示控件
        /// </summary>
        /// <param name="output"> 要写出到的 HTML 编写器 </param>
        protected override void Render(HtmlTextWriter output)
        {
            //if (this.HintInfo != "")
            //{
            //    output.WriteBeginTag("span id=\"" + this.ClientID + "\"  onmouseover=\"TipsAutoClose(this," + this.HintLeftOffSet + "," + this.HintTopOffSet + ",'" + this.HintTitle + "','" + this.HintInfo + "','" + this.HintHeight + "','" + this.HintShowType + "');\" onmouseout=\"hidehintinfo();\">");
            //}

            base.Render(output);

            if (this.HintInfo != "")
            {
                output.WriteEndTag("span");
            }

        }

	}
}
