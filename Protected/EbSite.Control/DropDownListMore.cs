using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.ComponentModel;
using EbSite.Base.EntityCustom;

namespace EbSite.Control
{
    /// <summary>
    /// 编辑器
    /// </summary>
    [DefaultEvent("Click"), DefaultProperty("Text"), ToolboxData("<{0}:DropDownListMore runat=server></{0}:DropDownListMore>")]
    public class DropDownListMore : Label, INamingContainer, IPostBackDataHandler
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
            string presentValue = this.hfValue.Value;
            string postedValue = postCollection[postDataKey];

            if (!presentValue.Equals(postedValue))//如果回发数据不等于原有数据
            {
                this.hfValue.Value = postedValue;
                return true;
            }
            return false;

        }
        #endregion


        #region Property

        /// <summary>
        /// 所选择城市的ID
        /// </summary>

        public string Value
        {
            get
            {

                return hfValue.Value;
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    hfValue.Value = value;
                }


            }

        }
        private string _BackFun = "";
        public string BackFun
        {
            get
            {

                return _BackFun;
            }
            set
            {
                _BackFun = value;
            }

        }
        private string _ModuleID = "";
        public string ModuleID
        {
            get
            {

                return _ModuleID;
            }
            set
            {
                _ModuleID = value;
            }

        }

        private int _Size = 1;
        public int Size
        {
            get
            {

                return _Size;
            }
            set
            {
                _Size = value;
            }

        }

        private int _SiteID = 0;
        public int SiteID
        {
            get
            {
                if (_SiteID==0)
                {
                    return EbSite.Base.Host.Instance.GetSiteID;
                }
                return _SiteID;
            }
            set
            {
                _SiteID = value;
            }

        }

        public ServiceApiName ApiName { get; set; }

        public string ApiFunctionName { get; set; }

        public string ObjName
        {
            get
            {
                return string.Concat("objal_", this.ID);
            }
        }

        #endregion

        /// <summary>
        /// 重写<see cref="System.Web.UI.Control.OnPreRender"/>方法。
        /// </summary>
        /// <param name="e">包含事件数据的 <see cref="EventArgs"/> 对象。</param>

        public HiddenField hfValue = new HiddenField();
        public HiddenField hfValueParentIDs = new HiddenField();
        protected override void CreateChildControls()
        {
            Controls.Clear();


            hfValue.ID = "hfValue";
            hfValueParentIDs.ID = "hfValueP";

            Controls.Add(hfValue);
            Controls.Add(hfValueParentIDs);
        }
        /// <summary>
        /// 如果控件需要修改时重写此方法，修改的时候将会自动初始化
        /// </summary>
        /// <returns></returns>
        public virtual string GetModifyParentIDs()
        {
            return "";
        }
        protected override void OnPreRender(EventArgs e)
        {

            if (!Page.ClientScript.IsClientScriptBlockRegistered("DropDownListMore"))
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "DropDownListMore", string.Concat("<SCRIPT language='javascript' src='", EbSite.Base.Host.Instance.IISPath, "js/drplistbll.js'></SCRIPT>"));
            }
            base.OnPreRender(e);
        }
        /// <summary>
        /// 可以在C#代码指定顶级选项的数据源，比如有些查询条件比较复杂的顶级选项，可以通过这个来初始化,可以参考分类管理
        /// </summary>
        public List<TreeItem> DataSoure { get; set; }
        /// <summary>
        /// 输出html,在浏览器中显示控件
        /// </summary>
        /// <param name="output"></param>
        protected override void Render(HtmlTextWriter output)
        {
            hfValueParentIDs.Value = GetModifyParentIDs();
            base.Render(output);
            //if (Page.IsPostBack)
            //{
            //    output.Write("<input type=\"hidden\" id=\"pst" + this.ClientID + "\" value=\"1\" />");
            //}
            string sFun = "null";
            if(!string.IsNullOrEmpty(this.BackFun))
            {
                sFun = string.Concat("function(obj){ ", this.BackFun, "(obj) }");
            }
            

            output.Write("<script>");
            if (!Equals(DataSoure, null))
            {
                
                output.Write("var ebdrpdatalist = {0};",EbSite.Core.JsonHelperForJs.ObjToJson(DataSoure));
            }
            
            output.Write(string.Concat("var ", ObjName, " = InitAreaList(\"", this.ClientID, "\", 5, \"", hfValue.ClientID, "\", \"", ApiName, "\", \"", ApiFunctionName, "\",\"", ModuleID, "\",", Size, ",", SiteID, ",", sFun, ");"));
            output.Write("</script>");
            

        }


    }

    public enum ServiceApiName
    {
        wcf = 0,
        webservice = 1
    }

}
