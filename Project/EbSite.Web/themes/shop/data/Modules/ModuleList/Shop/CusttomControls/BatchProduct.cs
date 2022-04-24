using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EbSite.Modules.Shop.CusttomControls
{
    [DefaultProperty("Text"), ToolboxData("<{0}:BatchProduct runat=server></{0}:BatchProduct>")]
    public class BatchProduct : WebControl, INamingContainer, IPostBackDataHandler
    {

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
        #region Property
       
        /// <summary>
        /// 商品信息
        /// </summary>
        public List<InfoProduct> ProductInfo
        {
            get
            {
                string[] strArray = this._uIDs.Value.Split(new char[] { ',' });
                List<InfoProduct> list = new List<InfoProduct>();
                foreach (string str2 in strArray)
                {
                    if (!string.IsNullOrEmpty(str2))
                    {
                        string[] strArray2 = str2.Split(new char[] { ':' });
                        InfoProduct item = new InfoProduct();
                        item.ID =Convert.ToInt32(strArray2[0]);
                        item.PicUrl = strArray2[1];
                        item.Title = strArray2[2];
                     //   item.TypeId = Convert.ToInt32(strArray2[3]);
                        list.Add(item);
                    }
                }
                return list;
            }

        }
        #endregion
        private int _CID = -1;
        private int CID
        {
            get
            {
                if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request["id"]))
                {
                    _CID = int.Parse(System.Web.HttpContext.Current.Request["id"]);
                }
                return _CID;
            }
           
        }
        public OpType OpTools
        {
            get
            {
                object objA = this.ViewState["OpTools"];
                if (!object.Equals(objA, null))
                {
                    return (OpType)objA;
                }
                return OpType.最佳组合;
            }
            set
            {
                this.ViewState["OpTools"] = value;
            }
        }
        private HiddenField _uIDs = new HiddenField();
        protected override void CreateChildControls()
        {
            Controls.Clear();
            //初始化子控件
            _uIDs.ID = "uIDs";
          
            Controls.Add(_uIDs);
        }
        /// <summary>
        /// 输出html,在浏览器中显示控件
        /// </summary>
        /// <param name="output"></param>
        protected override void Render(HtmlTextWriter output)
        {
            string tag = "1";
            _uIDs.RenderControl(output);

            if (this.OpTools == OpType.最佳组合)
            {
                tag = "1";
            }
            else if (this.OpTools == OpType.推荐配件)
            {
                tag = "2";
            }
            else if (this.OpTools == OpType.买几送几)
            {
                tag = "3";
            }
            else
            {
                tag = "4";
            }
            string mpath = EbSite.Base.Host.Instance.GetModulePath(new Guid("cfccc599-4585-43ed-ba31-fdb50024714b"));
            output.Write(string.Format("<iframe scrolling='no' src=\"{0}CusttomControls/BatchProductPg.aspx?rn={1}&cid={2}&op={3}\" width=\"1000\" height=\"480\" frameborder=\"0\"  marginwidth=\"0\" marginheight=\"0\"  ></iframe>", mpath, _uIDs.ClientID, CID, tag));

        }

        public enum OpType : int
        {
            最佳组合 = 1,
            推荐配件 = 2,
            买几送几 = 3,
            批发打折 = 4
        }
    }


}
public class InfoProduct
{
    private int _id;
    private string _picurl;
    private string _title;
    private int _typeid;
    /// <summary>
    /// 商品id
    /// </summary>
    public int ID
    {
        get { return _id; }
        set { _id = value; }
    }
    /// <summary>
    /// 小图路径
    /// </summary>
    public string PicUrl
    {
        get { return _picurl; }
        set { _picurl=value; }
    }
    /// <summary>
    /// 标题
    /// </summary>
    public string Title
    {
        get { return _title; }
        set {  _title=value; }
    }
    public int TypeId
    {
        get { return _typeid; }
        set { _typeid = value; }
    }
}