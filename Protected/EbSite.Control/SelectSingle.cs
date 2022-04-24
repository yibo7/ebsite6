using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ComponentModel;
namespace EbSite.Control
{
	/// <summary>
    /// 下拉列表控件。如果正常使用，可以像安装操作一个DropDownList一样，如果要在前端的js初始选项，要将IsForJsBind=true,并且调用，并且调用值时要用 CtrValue与 SelText
	/// </summary>
	[DefaultProperty("Text"), ToolboxData("<{0}:SelectSingle runat=server></{0}:SelectSingle>")]
    public class SelectSingle : System.Web.UI.WebControls.DropDownList, IUserContrlBase, INamingContainer, IPostBackDataHandler
	{
		/// <summary>
		/// 构造函数
		/// </summary>
        public SelectSingle()
            : base()
		{
            hfValue.ID = "selv";
            hfTxt.ID = "seltxt";
    	}
        
        public string SelText
        {
            get
            {
                if (!IsForJsBind)
                    return this.SelectedItem.Text;
                else
                {
                    return this.hfTxt.Value;
                }

            }
            set
            {
                this.hfTxt.Value = value;
                this.SelectedItem.Text = value;
            }
        }


	    public string CtrValue
	    {
            get
            {
                if (!IsForJsBind)
                    return this.SelectedValue;
                else
                {
                    return this.hfValue.Value;
                }

            }
            set
            {
                this.hfValue.Value = value;
                this.SelectedValue = value;
            }
	    }
        
	    public bool IsMouseoverDrp
	    {
            get
            {
                object objA = this.ViewState["IsMouseoverDrp"];
                return (!object.Equals(objA, null) && bool.Parse(objA.ToString()));
            }
            set
            {
                this.ViewState["IsMouseoverDrp"] = value;
            }
	    }

        public bool IsForJsBind
        {
            get
            {
                object objA = this.ViewState["IsForJsBind"];
                return (!object.Equals(objA, null) && bool.Parse(objA.ToString()));
            }
            set
            {
                this.ViewState["IsForJsBind"] = value;
            }
        }
       new  public bool LoadPostData(string postDataKey, System.Collections.Specialized.NameValueCollection postCollection)
        {
           //主控件的值
            string v = postCollection[postDataKey];

            string presentValue = this.hfValue.Value;
            string postedValue = postCollection[this.hfValue.ClientID];

            //string presentTxt = this.hfTxt.Value;
            string postedTxt = postCollection[this.hfTxt.ClientID];

            if (!presentValue.Equals(postedValue))//如果回发数据不等于原有数据
            {
                this.hfValue.Value = postedValue;
                this.hfTxt.Value = postedTxt;
                this.SelectedValue = v;

                return true;
            }
           
            return false;

        }
        protected override void OnPreRender(EventArgs e)
        {

            if (!Page.ClientScript.IsClientScriptBlockRegistered("SelectSingle"))
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "SelectSingle", string.Concat("<link type=\"text/css\" href=\"", EbSite.Base.Host.Instance.IISPath, "js/plugin/SelectSingle/css.css\" rel=\"stylesheet\" /><SCRIPT language='javascript' src='", EbSite.Base.Host.Instance.IISPath, "js/plugin/SelectSingle/select.js'></SCRIPT>"));
            }
            base.OnPreRender(e);
        }

        /// <summary>
        /// 当在前端js里初始化下拉选项时，在C#里到不到仠，所以要用一个HiddenField保存
        /// </summary>
        public HiddenField hfValue = new HiddenField();
        public HiddenField hfTxt = new HiddenField();
        //protected override void CreateChildControls()
        //{
        //    Controls.Clear();
        //    if (IsForJsBind)
        //    {
        //        hfValue.ID = "v" + this.ID;
        //        Controls.Add(hfValue);
        //        hfTxt.ID = "txt" + this.ID;
        //        Controls.Add(hfTxt);
        //    }
           
        //}


        /// <summary> 
        /// 输出html,在浏览器中显示控件
        /// </summary>
        /// <param name="output"> 要写出到的 HTML 编写器 </param>
        protected override void Render(HtmlTextWriter output)
        {
            if (IsMouseoverDrp)
            {
                this.Attributes.Add("drp", "1");
            }
            if (IsForJsBind)
            {
               
                hfValue.RenderControl(output);
                hfTxt.RenderControl(output);
            }

            base.Render(output);
            output.Write("<script>");
            output.Write(string.Concat("$(\"#" + this.ClientID + "\").sSelect('", hfValue.ClientID, "','", hfTxt.ClientID, "');"));
            output.Write("</script>");
            //if (this.HintInfo != "")
            //{
            //    output.WriteEndTag("span");
            //}
        }
	
	}

}
