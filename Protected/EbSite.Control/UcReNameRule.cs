using System;
using System.Collections;
using System.Data;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.ComponentModel;

namespace EbSite.Control
{
    /// <summary>
    /// 编辑器
    /// </summary>
    [DefaultEvent("Click"), DefaultProperty("Text"), ToolboxData("<{0}:UcReNameRule runat=server></{0}:UcReNameRule>")]
    public class UcReNameRule : WebControl, INamingContainer, IPostBackDataHandler
    {
        #region 实现IPostBackDataHandler
        // <summary>
        /// 引发PostBack事件
        /// </summary>
        public void RaisePostDataChangedEvent()
        {
        }
        /// <summary>
        /// 加载提交信息
        /// </summary>
        /// <param name="postDataKey"></param>
        /// <param name="postCollection"></param>
        /// <returns></returns>
        public bool LoadPostData(string postDataKey, System.Collections.Specialized.NameValueCollection postCollection)
        {

            string presentValue = this._txtRule.Text;
            string postedValue = postCollection[postDataKey];

            if (!presentValue.Equals(postedValue))//如果回发数据不等于原有数据
            {
                this._txtRule.Text = postedValue;
                return true;
            }
            return false;

        }
        #endregion
        public string Text
        {
            get
            {

                return _txtRule.Text;
            }
            set
            {
                _txtRule.Text = value;
            }

        }
        private TextBox _txtRule = new TextBox();
        private EasyuiDialog _WinBox;
        //private HiddenField _Value = new HiddenField();
        protected override void CreateChildControls()
        {
            Controls.Clear();
            //初始化子控件
            //_txtRule = new TextBox();
            _txtRule.Width = base.Width;
            _txtRule.Height = base.Height;
            _txtRule.ID = "RuleVlue";

            _WinBox = new EasyuiDialog();
            _WinBox.Text = "选择";
            
            _WinBox.Width = 500;
            _WinBox.Height = 180;

            Controls.Add(_txtRule);
            Controls.Add(_WinBox);
           // Controls.Add(_Value);
            
           
        }



        /// <summary>
        /// 输出html,在浏览器中显示控件
        /// </summary>
        /// <param name="output"></param>
        protected override void Render(HtmlTextWriter output)
        {
            _txtRule.RenderControl(output);
            _WinBox.Href = Base.AppStartInit.IISPath+ "CustomPages/ReNameRule.aspx?uc=" + _txtRule.ClientID;
            _WinBox.RenderControl(output);
            //_Value.RenderControl(output);

            
        }

        



    }
   
}
