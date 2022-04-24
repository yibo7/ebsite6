using System;
using System.Collections;
using System.Collections.Specialized;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.ComponentModel;
using EbSite.Control;


namespace EbSite.ControlData
{


    [DefaultProperty("Text"), ToolboxData("<{0}:SelectUser runat=server></{0}:SelectUser>"), Designer("System.Web.UI.Design.WebControls.PreviewControlDesigner, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
    public class SelectUser : EbSite.Control.WebControl, INamingContainer, IPostBackDataHandler
    {
        #region 实现IPostBackDataHandler
        public void RaisePostDataChangedEvent()
        {
        }
        public bool LoadPostData(string postDataKey, NameValueCollection postCollection)
        {
            string str = this.hfUserID.Value;
            string str2 = postCollection[postDataKey];
            if (!str.Equals(str2))
            {
                this.hfUserID.Value = str2;
                return true;
            }
            return false;
        }
        #endregion
        //public SelectUser()
        //{
        //    base.ReadOnly = true;
        //}
        public string UserNiName
        {
            get
            {
                return hfUserNiName.Text;
            }
            set
            {
                hfUserNiName.Text = value;
            }
        }

        public string UserName
        {
            get
            {
                return hfUserName.Value;
            }
            set
            {
                hfUserName.Value = value;
            }
        }

        public string UserID
        {
            get
            {
                return hfUserID.Value;
            }
            set
            {
                hfUserID.Value = value;
            }
        }

        public int UserGroupID
        {
            get
            {
                object objA = this.ViewState["UserGroupID"];
                if (objA != null)
                {
                    return int.Parse(objA.ToString());
                }
                return 0;
            }
            set
            {
                this.ViewState["UserGroupID"] = value;
            }
        }
        protected override void OnPreRender(EventArgs e)
        {

            if (!Page.ClientScript.IsClientScriptBlockRegistered("SelectUser"))
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "SelectUser", string.Concat("<SCRIPT language='javascript' src='", EbSite.Base.Host.Instance.IISPath, "js/plugin/SelectUser/js.js'></SCRIPT>"));
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "SelectUserStyle", string.Concat(" <link rel=\"stylesheet\" href=\"", EbSite.Base.Host.Instance.IISPath, "js/plugin/poshytip/tip-yellow/tip-yellow.css\" type=\"text/css\" />"));
            }
            base.OnPreRender(e);
        }
        public System.Web.UI.WebControls.HiddenField hfUserName = new System.Web.UI.WebControls.HiddenField();
        public System.Web.UI.WebControls.HiddenField hfUserID = new System.Web.UI.WebControls.HiddenField();

        public EbSite.Control.TextBox hfUserNiName = new EbSite.Control.TextBox();
        protected override void CreateChildControls()
        {
            Controls.Clear();


            hfUserName.ID = "hfUserName";
            hfUserID.ID = "hfUserID";
            hfUserNiName.ID = "hfUserNiName";
            if (SelectType == UserSelType.多选)
                hfUserNiName.TextMode = TextBoxMode.MultiLine;
            Controls.Add(hfUserName);
            Controls.Add(hfUserID);
            Controls.Add(hfUserNiName);

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

            hfUserNiName.ReadOnly = true;
            hfUserNiName.Width = this.Width;
            hfUserNiName.Height = this.Height;

            hfUserName.RenderControl(output);
            hfUserID.RenderControl(output);
            hfUserNiName.RenderControl(output);

            //base.Render(output);

            output.Write("<script>");
            output.Write("var us" + hfUserNiName.ClientID + " = new SelectUser();");
            output.Write("us" + hfUserNiName.ClientID + ".Init(\"" + hfUserName.ClientID + "\", \"" + hfUserNiName.ClientID + "\", \"" + hfUserID.ClientID + "\"," + UserGroupID + "," + sSelType + ");");
            output.Write("</script>");


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
                    return UserSelType.单选;
                }
            }
            set
            {
                ViewState["SelectType"] = value;
            }
        }
    }

    public enum UserSelType
    {
        多选 = 0,
        单选 = 1

    }

}
