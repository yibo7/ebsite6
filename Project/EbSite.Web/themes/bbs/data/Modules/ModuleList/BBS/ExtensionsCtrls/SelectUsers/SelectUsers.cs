using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EbSite.Modules.BBS.ExtensionsCtrls
{
    [DefaultEvent("Click"), DefaultProperty("Text"), ToolboxData("<{0}:SelectUsers runat=server></{0}:SelectUsers>")]
    public class SelectUsers : WebControl, INamingContainer, IPostBackDataHandler
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
            string presentValue = this._uIDs.Value;
            string postedValue = postCollection[postDataKey];

            if (!presentValue.Equals(postedValue))//如果回发数据不等于原有数据
            {
                this._uIDs.Value = postedValue;
                return true;
            }
            return false;

        }
        #endregion

        #region Property

        /// <summary>
        /// 真实姓名
        /// </summary>
        public string RealNames
        {
            get
            {
                string sValue = _RealNames.Text;

                return sValue;
            }
            set
            {
                _RealNames.Text = value;
            }
        }


        /// <summary>
        /// 用户姓名
        /// </summary>
        public string UserNames
        {
            get
            {
                return _uNames.Value;
            }
            set
            {
                _uNames.Value = value;
            }

        }
        public string UserIDs
        {
            get
            {
                return _uIDs.Value;
            }
            set
            {
                _uIDs.Value = value;
            }

        }



        #endregion



        /// <summary>
        /// 重写<see cref="System.Web.UI.Control.OnPreRender"/>方法。
        /// </summary>
        /// <param name="e">包含事件数据的 <see cref="EventArgs"/> 对象。</param>

        private System.Web.UI.WebControls.TextBox _RealNames = new System.Web.UI.WebControls.TextBox();
        private HiddenField _uIDs = new HiddenField();
        private HiddenField _uNames = new HiddenField();
        protected override void CreateChildControls()
        {
            Controls.Clear();
            //初始化子控件
            if (SelectType == UserSelType.多选)
                _RealNames.TextMode = TextBoxMode.MultiLine;
            _RealNames.Width = base.Width;
            _RealNames.Height = base.Height;
            _RealNames.ID = "RealNames";
            _RealNames.CssClass = "TextBoxDefault";
            _uIDs.ID = "uIDs";
            _uNames.ID = "uNames";
            Controls.Add(_RealNames);
            Controls.Add(_uIDs);
            Controls.Add(_uNames);

        }

        public UserSelType SelectType
        {
            get
            {

                object obj = ViewState["SelectType"];

                if (!Equals(obj, null))
                    return (UserSelType)obj;
                else
                {
                    return UserSelType.多选;
                }


            }
            set
            {
                ViewState["SelectType"] = value;
            }
        }
       
        /// <summary>
        /// 输出html,在浏览器中显示控件
        /// </summary>
        /// <param name="output"></param>
        protected override void Render(HtmlTextWriter output)
        {
            string sSelType = "0";

            if (SelectType == UserSelType.单选)
                sSelType = "1";

            _RealNames.ReadOnly = true;
            _RealNames.Width = base.Width;
            _RealNames.Height = base.Height;
            string sID = string.Concat("slU", ClientID);
            _RealNames.Attributes.Add("onclick", string.Format("OpenCenterUser('{0}')", sID));
            _RealNames.RenderControl(output);
            _uIDs.RenderControl(output);
            _uNames.RenderControl(output);
            output.Write(string.Format("<div id=\"{0}\" style=\"padding:5px;width:500px;height:300px; display:none\"  title=\"选择用户\">", sID));

            output.Write(string.Format("<iframe scrolling='no' src=\"{0}Modules/BBS/ExtensionsCtrls/SelectUsers/PgSelectUsers.aspx?un={1}&rn={2}&ids={3}&slt={4}\"  height=\"6000\" frameborder=\"0\"  marginwidth=\"0\" marginheight=\"0\"  ></iframe>", Base.AppStartInit.IISPath, _uNames.ClientID, _RealNames.ClientID, _uIDs.ClientID, sSelType));
            output.Write("</div>");
        }
    }
    public enum UserSelType
    {
        多选 = 0,
        单选 = 1

    }
}