using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using EbSite.Base.EntityAPI;
using EbSite.Core;

namespace EbSite.Control
{
    [DefaultEvent("Click"), DefaultProperty("Text"), ToolboxData("<{0}:AreaSelector runat=server></{0}:AreaSelector>")]
    public class AreaSelector : System.Web.UI.WebControls.TextBox, IUserContrlBase, INamingContainer, IPostBackDataHandler
    {
        public HiddenField _IDS = new HiddenField();
        //public TextBox txtBox = new TextBox();
        /// <summary>
        /// ID，用逗号分开
        /// </summary>
        public string CtrValue
        {
            get
            {
                return _IDS.Value;
            }
            set
            {
                _IDS.Value = value;
            }
        }
        new public bool LoadPostData(string postDataKey, System.Collections.Specialized.NameValueCollection postCollection)
        {
            //主控件的值
            string v = postCollection[postDataKey];

            string presentValue = this._IDS.Value;
            string postedValue = postCollection[this._IDS.ClientID];

            //string postedTxt = postCollection[this.ClientID];
            if (!presentValue.Equals(postedValue))//如果回发数据不等于原有数据
            {
                this._IDS.Value = postedValue;
                //重新设置 TextBox的值
                this.Text = v;
                return true;
            }

            return false;

        }
        //public string Text
        //{
        //    get
        //    {
        //        return txtBox.Text;
        //    }
        //    set
        //    {
        //        txtBox.Text = value;
        //    }
        //}
       
        ///// <summary>
        ///// 一个数据模型列表
        ///// </summary>
        //public List<EbSite.Base.EntityAPI.ListItemModel> ModelList
        //{
        //    get
        //    {
        //        if(!string.IsNullOrEmpty(JsonValue))
        //        {
        //            JsonHelper.DataContractJsonDeserialize<List<EbSite.Base.EntityAPI.ListItemModel>>(JsonValue);
        //        }
        //        return new List<ListItemModel>();
        //    }
        //}

        protected override void CreateChildControls()
        {
            //this.Controls.Clear();
            //this.txtBox.ID = "fl" + this.ClientID;
            //this.txtBox.HintInfo = base.HintInfo;
            //this.txtBox.ReadOnly = true;
            
            //this.Controls.Add(this.txtBox);
            

            this._IDS.ID = "IDS" + this.ClientID;
            this.Controls.Add(this._IDS);
            this.Attributes.Add("onclick", "onclick_seladreess('" + this.ClientID + "','" + _IDS.ClientID + "')");
        }

        

        //public bool LoadPostData(string postDataKey, NameValueCollection postCollection)
        //{
        //    string str = this._IDS.Value;
        //    string str2 = postCollection[postDataKey];
        //    if (!str.Equals(str2))
        //    {
        //        this._IDS.Value = str2;
        //        return true;
        //    }
        //    return false;
        //}

        protected override void OnPreRender(EventArgs e)
        {
            if (!this.Page.ClientScript.IsClientScriptBlockRegistered("AreaSelector"))
            {
                this.Page.ClientScript.RegisterClientScriptBlock(base.GetType(), "AreaSelector", string.Concat("<script type=\"text/javascript\">function onclick_seladreess(id,vid) {In.ready('dialog', function () {OpenDialog_Iframe(\"", EbSite.Base.Host.Instance.IISPath, "dialog/areasel.html?objid=\"+id+\"&vid=\"+vid , \"选择城市\", 500, 390, true);});}</script>"));
            }

            base.OnPreRender(e);
        }

        //public void RaisePostDataChangedEvent()
        //{
        //}

        protected override void Render(HtmlTextWriter output)
        {
            base.Render(output);
            //txtBox.Width = base.Width;
            //txtBox.Height = base.Height;
            //this.Attributes.Add("onclick", "onclick_seladreess('" + this.ClientID + "','"+ _IDS.ClientID+ "')");
            //this.txtBox.RenderControl(output);
            _IDS.RenderControl(output);
        }

    }
}
