
using EbSite.Core;

namespace EbSite.Control
{

    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Threading;
    using System.Web;
    using System.Web.UI;

    public delegate void EventToolBarItemClick(object source, ItemClickArgs e);
    public class ItemClickArgs : EventArgs
    {

        private string mItemTag;
        public string ItemTag
        {
            get
            {
                return mItemTag;
            }
            set
            {
                mItemTag = value;
            }
        }

    }
    public class ToolBarItem
    {
        internal string Attributes;
        public string EventTag;
        public string Img;
        internal bool IsLine = false;
        public bool IsPostBack = true;
        public bool IsRight;
        public string OnClientClick;
        public string Text;
        public string Tips;
        internal Control Uc;
    }

    [DefaultEvent("Click"), ToolboxData("<{0}:ToolBar runat=server></{0}:ToolBar>"), DefaultProperty("Text")]
    public class ToolBar : Control, IPostBackEventHandler
    {
        public List<ToolBarItem> Items = new List<ToolBarItem>();
        public void AddBnt(string Title, string ImgIco, string EvTagMak)
        {
            AddBnt(Title, ImgIco, EvTagMak, "");
        }

        public void AddBnt(string Title, string ImgIco, string EvTagMak, string Tips)
        {
            this.AddBnt(Title, ImgIco, EvTagMak, true, "", "", Tips);
        }

        public void AddBnt(string Title, string ImgIco, string EvTagMak, bool IsPostBack, string ClientJs, string Tips)
        {
            this.AddBnt(Title, ImgIco, EvTagMak, IsPostBack, ClientJs, "", Tips);
        }

        public void AddBnt(string Title, string ImgIco, string EvTagMak, bool IsPostBack, string ClientJs, string Attr, string Tips)
        {
            this.AddBnt(Title, ImgIco, EvTagMak, IsPostBack, ClientJs, Attr, false, Tips);
        }
        /// <summary>
        /// 向工具条添加一个按钮
        /// </summary>
        /// <param name="Title">按钮文本</param>
        /// <param name="ImgIco">按钮图标</param>
        /// <param name="EvTagMak">按钮的事件标志</param>
        /// <param name="IsPostBack">是否可以回发</param>
        /// <param name="ClientJs">要执行的客户端脚本</param>
        /// <param name="Attr">其他属性</param>
        /// <param name="isRight">是不添加到工作条的右边，否则左边</param>
        /// <param name="Tips">提示文本</param>
        public void AddBnt(string Title, string ImgIco, string EvTagMak, bool IsPostBack, string ClientJs, string Attr, bool isRight, string Tips)
        {
            ToolBarItem item = new ToolBarItem();
            item = new ToolBarItem();
            item.Text = Title;
            if (!string.IsNullOrEmpty(ImgIco))
            {
                item.Img = ImgIco;
            }
            item.EventTag = EvTagMak;
            item.IsPostBack = IsPostBack;
            item.OnClientClick = ClientJs;
            item.Attributes = Attr;
            item.IsRight = isRight;
            item.Tips = Tips;
            this.Items.Add(item);
        }
        /// <summary>
        /// 添加一个对话框，这个窗口由当前页面元素组成
        /// </summary>
        /// <param name="divID"></param>
        /// <param name="Title"></param>
        /// <param name="EvTagMak"></param>
        /// <param name="ImgIco"></param>
        public void AddBox(string divID, string Title, string EvTagMak, string ImgIco)
        {
            this.AddBnt(Title, ImgIco, "", false, "OpenDialog_SavePost('" + divID + @"',function(){setTimeout('__doPostBack(\'" + this.UniqueID + @"\',\'" + EvTagMak + @"\')',0)},true)", "");
        }
        public void AddCtr(EbSite.Control.DatePicker uc)
        {

            if (!this.Page.ClientScript.IsClientScriptIncludeRegistered("DatePickerSet"))
            {
                string url = string.Format("{0}js/plugin/ui/datepicker/js.js", Base.AppStartInit.IISPath);
                this.Page.ClientScript.RegisterClientScriptInclude("DatePickerSet", url);
            }
            ToolBarItem item = new ToolBarItem();
            item.Uc = uc;
            this.Items.Add(item);
        }

        public void AddCtr(Control uc)
        {
            ToolBarItem item = new ToolBarItem();
            item.Uc = uc;
            this.Items.Add(item);

            
        }

        public void AddDDownListOnchange(System.Web.UI.WebControls.DropDownList uc, string OnchangeEvTagMak)
        {
            uc.Attributes.Add("onchange", @"javascript:setTimeout('__doPostBack(\'" + this.UniqueID + @"\',\'" + OnchangeEvTagMak + @"\')', 0)");
            this.AddCtr(uc);
        }

        public void AddDialog(string sUrl, string Title, string ImgIco)
        {
            this.AddDialog(sUrl, Title, ImgIco, 800, 500, true, false,"保存");
        }
        public void AddDialog(string sUrl, string Title, string ImgIco,string tips,string savetext)
        {
            AddDialog(sUrl, Title, ImgIco, 800, 500, false, false, tips, savetext);
        }

        /// <summary>
        /// 添加一个子窗口
        /// </summary>
        /// <param name="sUrl"></param>
        /// <param name="Title"></param>
        /// <param name="ImgIco"></param>
        /// <param name="IsRight"></param>
        public void AddDialog(string sUrl, string Title, string ImgIco, bool IsRight,string savetext)
        {
            this.AddDialog(sUrl, Title, ImgIco, 800, 500, true, IsRight, savetext);
        }
        /// <summary>
        /// 添加一个子窗口
        /// </summary>
        /// <param name="sUrl">连接地址</param>
        /// <param name="Title">按钮文本</param>
        /// <param name="ImgIco">图片的ICO</param>
        /// <param name="width">窗口的宽</param>
        /// <param name="height">窗口的高</param>
        /// <param name="isColoseRefesh">关闭是否刷新父页</param>
        /// <param name="IsRight">是否向右边添加</param>
        public void AddDialog(string sUrl, string Title, string ImgIco, int width, int height, bool isColoseRefesh, bool IsRight,string tips,string savetext)
        {
            string attr = string.Format("class=\"EasyuiDialog\"   edhref=\"{0}\" edtitle=\"{1}\" edwidth=\"{2}\" edheight=\"{3}\" edrefesh=\"{4}\" savetext=\"{5}\"", new object[] { sUrl, Title, width, height, isColoseRefesh, savetext });
            this.AddBnt(Title, ImgIco, "", false, "", attr, IsRight, tips);
        }
        public void AddDialog(string sUrl, string Title, string ImgIco, int width, int height, bool isColoseRefesh, bool IsRight,string savetext)
        {
            AddDialog(sUrl, Title, ImgIco, width, height, isColoseRefesh, IsRight, "", savetext);
        }

        public void AddLine()
        {
            ToolBarItem item = new ToolBarItem();
            item.IsLine = true;
            item.Text = "<img class=\"bline\" align=\"left\"   />";
            this.Items.Add(item);
        }

        protected override void CreateChildControls()
        {
            if (this.Page.IsPostBack)
            {
                this.InitData();
            }
        }

        public string GetItemVal(Control uc)
        {
            string str = "";
            if (!object.Equals(uc, null))
            {
                str = HttpContext.Current.Request[uc.ID];
            }
            return str;
        }

        private void InitData()
        {
            foreach (ToolBarItem item in this.Items)
            {
                if (!object.Equals(item.Uc, null))
                {
                    this.SetItemVal(item.Uc);
                }
            }
        }

        protected override void LoadViewState(object savedState)
        {
            this.InitData();
        }
        public event EventToolBarItemClick ItemClick;
        protected virtual void OnItemClick(ItemClickArgs e)
        {
            if (this.ItemClick != null)
            {
                this.ItemClick(this, e);
            }
        }

        private string _ThemesPath = string.Empty;
        public string ThemesPath
        {
            get
            {
                return _ThemesPath;
            }
            set
            {
                _ThemesPath = value;
            }
        }
        protected override void OnPreRender(EventArgs e)
        {
            if (!this.Page.ClientScript.IsClientScriptBlockRegistered("ToolBar"))
            {
                if (string.IsNullOrEmpty(ThemesPath))
                {
                    this.Page.ClientScript.RegisterClientScriptBlock(base.GetType(), "ToolBar", string.Format("<link href=\"{0}js/plugin/toolbar/index.css\" media=\"all\" rel=\"stylesheet\" type=\"text/css\" />", Base.AppStartInit.IISPath));
                }
                else
                {
                    this.Page.ClientScript.RegisterClientScriptBlock(base.GetType(), "ToolBar", string.Format("<link href=\"{0}\" media=\"all\" rel=\"stylesheet\" type=\"text/css\" />", ThemesPath));
                }
                
            }
            string iISPath = Base.AppStartInit.IISPath;
            if (!this.Page.ClientScript.IsClientScriptIncludeRegistered("EasyuiDialog"))
            {
                this.Page.ClientScript.RegisterClientScriptInclude("EasyuiDialog", string.Format("{0}js/plugin/EasyuiDialog/js.js", iISPath));
            }
            
            //if (_IsIncDatePickerJs)
            //{
                
            //}
            
            base.OnPreRender(e);
        }

        public void RaisePostBackEvent(string eventArgument)
        {
            ItemClickArgs e = new ItemClickArgs();
            e.ItemTag = eventArgument;
            this.OnItemClick(e);
        }

        protected override void Render(HtmlTextWriter output)
        {
            output.Write(" <div class=\"toolbarbox\"><div id=\"vista_toolbar\" > <ul>");
            foreach (ToolBarItem item in this.Items)
            {
                output.Write("<li>");
                if (!item.IsLine)
                {
                    if (!object.Equals(item.Uc, null)) //如果是控件
                    {
                        output.Write("<a>");
                        item.Uc.RenderControl(output);
                        output.Write("</a>");
                    }
                    else    //这里主要对bnt的设置
                    {
                        string strOnclick = "";
                        if (!string.IsNullOrEmpty(item.OnClientClick))
                        {
                            strOnclick = string.Format("onclick=\"{0}\"", item.OnClientClick);
                        }
                        string strHref = "#";
                        if (item.IsPostBack)
                        {
                            strHref = "javascript: " + this.Page.ClientScript.GetPostBackEventReference(this, item.EventTag);
                        }
                        string sIsRight = "";
                        if (item.IsRight)
                        {
                            sIsRight = "class=\"right\"";
                        }
                        string strTips = "";
                        if (!string.IsNullOrEmpty(item.Tips))
                        {
                            strTips = string.Format("data-toggle=\"tooltip\" title=\"{0}\"", item.Tips);
                            //strTips = string.Format("onmouseover=\"TipsAutoClose(this,'{0}')\"", item.Tips);

                        }
                        output.Write(string.Format("<a {2} {0} href=\"{1}\" {3} {4} ><span>\r\n", new object[] { strOnclick, strHref, sIsRight, item.Attributes, strTips }));
                        output.Write(string.Format("<img align=\"left\" src=\"{0}\" alt=\"{1}\" />{1}", item.Img, item.Text));
                        output.Write("\r\n</span></a>");
                    }
                }
                else
                {
                    output.Write("<a><span><img class=\"bline\" align=\"left\"   /></span></a>");
                }
                output.Write("</li>");
            }
            output.Write(" </ul></div></div>");//<div style=\"clear:both;\"></div>
        }

        protected override object SaveViewState()
        {
            return "";
        }

        public void SetItemVal(Control uc)
        {
            if (!object.Equals(uc, null))
            {
                if (!Equals(HttpContext.Current, null))
                {
                    if (!string.IsNullOrEmpty(uc.ID))
                    {
                        string sv = HttpContext.Current.Request[uc.ID];
                        this.SetItemVal(uc, sv);
                    }
                    else
                    {
                        throw new Exception("工具条控件需要设置一个ID,请确认是否有哪个控件没有设置ID!");
                    }
                    
                }
               
            }
        }

        public void SetItemVal(Control uc, string sv)
        {
            if (!object.Equals(uc, null))
            {
                Utils.SetValueFromControl(uc, sv);
            }
        }
    }

    

}
