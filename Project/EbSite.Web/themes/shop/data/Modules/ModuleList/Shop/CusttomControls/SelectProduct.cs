using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EbSite.Modules.Shop.CusttomControls
{

    public enum SelectProductType : int
    {
        不含有商品规格的商品 = 1,
        全部商品 = 2
        
    }
    [DefaultEvent("Click"), DefaultProperty("Text"), ToolboxData("<{0}:SelectProduct runat=server></{0}:SelectProduct>")]
    public class SelectProduct : WebControl, INamingContainer, IPostBackDataHandler
    {
        #region 实现IPostBackDataHandler
        /// <summary>
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
        /// 商品名称
        /// </summary>
        public string ProductName
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
        /// 商品ID
        /// </summary>
        public string ProductId
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
        /// 是否调 不 含有商品规格的商品  false:全部  |true :调没有规格的商品
        /// </summary>
        //public bool IsDataNorms
        //{
        //    get
        //    {
        //        object obj2 = this.ViewState["IsDataNorms"];
        //        if (!object.Equals(obj2, null))
        //        {
        //            return ((obj2 != null) && ((bool)obj2));
        //        }
        //        return false;
        //    }
        //    set
        //    {
        //        this.ViewState["IsDataNorms"] = value;
        //    }
        //}
        public SelectProductType SelProduct
        {
            get
            {
                object objA = this.ViewState["IsDataNorms"];
                if (!object.Equals(objA, null))
                {
                    return (SelectProductType)objA;
                }
                return SelectProductType.全部商品;
            }
            set
            {
                this.ViewState["IsDataNorms"] = value;
            }
        }
        private System.Web.UI.WebControls.TextBox _RealNames = new System.Web.UI.WebControls.TextBox();
        private HiddenField _uIDs = new HiddenField();
        protected override void CreateChildControls()
        {
            Controls.Clear();
            //初始化子控件

            _RealNames.TextMode = TextBoxMode.MultiLine;
            _RealNames.Width = base.Width;
            _RealNames.Height = base.Height;
            _RealNames.ID = "RealNames";
            _RealNames.CssClass = "TextBoxDefault";
            _uIDs.ID = "uIDs";
            Controls.Add(_RealNames);
            Controls.Add(_uIDs);

        }
        /// <summary>
        /// 输出html,在浏览器中显示控件
        /// </summary>
        /// <param name="output"></param>
        protected override void Render(HtmlTextWriter output)
        {


            _RealNames.ReadOnly = true;
            _RealNames.Width = base.Width;
            _RealNames.Height = base.Height;
            string sID = string.Concat("slU", ClientID);
            _RealNames.Attributes.Add("onclick", string.Format("OpenCenterUser('{0}')", sID));
            _RealNames.RenderControl(output);
            _uIDs.RenderControl(output);

            output.Write(string.Format("<div id=\"{0}\" style=\"padding:5px;width:485px;height:490px; display:none\"  title=\"选择商品\">", sID));

            string mpath = EbSite.Base.Host.Instance.GetModulePath(new Guid("cfccc599-4585-43ed-ba31-fdb50024714b"));

            string IsDataNorms = "false";
            if (SelProduct == SelectProductType.不含有商品规格的商品)
            {
                IsDataNorms = "True";
            }

            output.Write(string.Format("<iframe scrolling='no' src=\"{0}CusttomControls/SelectProductPg.aspx?rn={1}&ids={2}&isnor={3}\" width=\"440\" height=\"480\" frameborder=\"0\"  marginwidth=\"0\" marginheight=\"0\"  ></iframe>", mpath, _RealNames.ClientID, _uIDs.ClientID, IsDataNorms));
            output.Write("</div>");

        }
    }
}