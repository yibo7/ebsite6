
using EbSite.Core;

namespace EbSite.Control
{

    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Threading;
    using System.Web;
    using System.Web.UI;
    public class ToolBarItemSimple
    {
        internal string Attributes;
        public string EventTag;
        public string Img;
        internal bool IsLine = false;
        public bool IsPostBack = true;
        public string OnClientClick;
        public string Text;
    }

    [DefaultEvent("Click"), ToolboxData("<{0}:ToolBarMobile runat=server></{0}:ToolBarMobile>"), DefaultProperty("Text")]
    public class ToolBarMobile : Control, IPostBackEventHandler
    {
        public List<ToolBarItemSimple> Items = new List<ToolBarItemSimple>();
        public List<ToolBarItem> MoreItems = new List<ToolBarItem>();
        public void AddBnt(string Title, string ImgIco, string EvTagMak)
        {
            AddBnt(Title, ImgIco, EvTagMak,true, "","");
        }
        public void AddSubMenu(string Title,  string EvTagMak, bool IsPostBack, string ClientJs, string Attr)
        {
            ToolBarItem item = new ToolBarItem();
            item = new ToolBarItem();
            item.Text = Title;
            //if (!string.IsNullOrEmpty(ImgIco))
            //{
            //    item.Img = ImgIco;
            //}
            item.EventTag = EvTagMak;
            item.IsPostBack = IsPostBack;
            item.OnClientClick = ClientJs;
            item.Attributes = Attr;
            //item.IsRight = isRight;
            //item.Tips = Tips;
            this.MoreItems.Add(item);
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
        public void AddBnt(string Title, string ImgIco, string EvTagMak, bool IsPostBack, string ClientJs, string Attr)
        {
            ToolBarItemSimple item = new ToolBarItemSimple();
            item = new ToolBarItemSimple();
            item.Text = Title;
            if (!string.IsNullOrEmpty(ImgIco))
            {
                item.Img = ImgIco;
            }
            item.EventTag = EvTagMak;
            item.IsPostBack = IsPostBack;
            item.OnClientClick = ClientJs;
            item.Attributes = Attr;
            //item.IsRight = isRight;
            //item.Tips = Tips;
            this.Items.Add(item);
        }

        public void AddLine()
        {
            ToolBarItemSimple item = new ToolBarItemSimple();
            item.IsLine = true;
            item.Text = "|";
            this.Items.Add(item);
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

        public event EventToolBarItemClick ItemClick;
        protected virtual void OnItemClick(ItemClickArgs e)
        {
            if (this.ItemClick != null)
            {
                this.ItemClick(this, e);
            }
        }

        private void InitData()
        {
            foreach (ToolBarItem item in this.MoreItems)
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
        protected override void OnPreRender(EventArgs e)
        {
            //if (!this.Page.ClientScript.IsClientScriptBlockRegistered("ToolBar"))
            //{
            //    this.Page.ClientScript.RegisterClientScriptBlock(base.GetType(), "ToolBar", string.Format("<link href=\"{0}js/plugin/toolbar/index.css\" media=\"all\" rel=\"stylesheet\" type=\"text/css\" />", Base.AppStartInit.IISPath));
                
            //}
            //string iISPath = Base.AppStartInit.IISPath;
            //if (!this.Page.ClientScript.IsClientScriptIncludeRegistered("EasyuiDialog"))
            //{
            //    this.Page.ClientScript.RegisterClientScriptInclude("EasyuiDialog", string.Format("{0}js/plugin/EasyuiDialog/js.js", iISPath));
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
            output.Write(" <div class=\"w-navigator\">");
            foreach (ToolBarItemSimple item in this.Items)
            {
                if (!item.IsLine)
                {
                    string strOnClick = "";
                    if (!string.IsNullOrEmpty(item.OnClientClick))
                    {
                        strOnClick = string.Format("onclick=\"{0}\"", item.OnClientClick);
                    }
                    string strHref = "#";
                    if (item.IsPostBack)
                    {
                        strHref =string.Concat("javascript: " , this.Page.ClientScript.GetPostBackEventReference(this, item.EventTag));
                    }
                    output.Write(string.Format("<a {2} {0} href=\"{1}\"  >", new object[] { strOnClick, strHref, item.Attributes }));
                    output.Write(string.Format("<img   src=\"{0}\"  />", item.Img));
                    output.Write("</a>");
                }
                else
                {
                    output.Write("<b>|</b>");
                }
            }

            if (MoreItems.Count > 0)
            {
                output.Write("<span onclick=\"onmdsubmenusClick()\" >更多&#9660</span>");
            }
            

            output.Write(" </div>");

           output.Write("<div  class=\"w-home-search\" style=\"margin:5px;display: none;\" >");
           output.Write("<input onclick=\"javascript:{0}\" type=\"button\" value=\" 搜 索 \" alog-alias=\"search\">", this.Page.ClientScript.GetPostBackEventReference(this,"search"));
           output.Write(" <div class=\"input\">");
           output.Write("     <div class=\"ui-input-mask\" style=\"height: 45px;\">");
           output.Write("         <input id=\"mkey\" name=\"mkey\" type=\"text\" autocomplete=\"off\" autocorrect=\"off\" maxlength=\"100\" placeholder=\"请输入关键词…\" style=\"position: absolute; top: 0px; left: 0px; width: auto; right: 40px;\">");
           output.Write("         <div class=\"ui-quickdelete-button\" style=\"height: 20px; width: 20px; top: 13px; right: 10px;\">");
           output.Write("         </div>");
           output.Write("     </div>");
           output.Write(" </div>");
           output.Write(" </div>");


           #region 更多工具条菜单

           if (MoreItems.Count > 0)
           {
               output.Write(" <div style=\"height: 100px;\" id=\"ebSubMenus\">");

               foreach (ToolBarItem item in this.MoreItems)
               {
                   string strOnClick = "";
                   if (!string.IsNullOrEmpty(item.OnClientClick))
                   {
                       strOnClick = string.Format("onclick=\"{0}\"", item.OnClientClick);
                   }
                   string strHref = "#";
                   if (item.IsPostBack)
                   {
                       strHref = string.Concat("javascript: ", this.Page.ClientScript.GetPostBackEventReference(this, item.EventTag));
                   }
                   output.Write("<div><a {2} {0} href=\"{1}\"  >", new object[] { strOnClick, strHref, item.Attributes });
                   output.Write(item.Text);
                   output.Write("</a></div>");
               }
               output.Write("</div>");

               output.Write("<script>m_dialog('ebSubMenus', '300', '200');</script>");
           }

           #endregion
           

        }

        protected override object SaveViewState()
        {
            return "";
        }

        public void SetItemVal(Control uc)
        {
            if (!object.Equals(uc, null))
            {
                string sv = HttpContext.Current.Request[uc.ID];
                this.SetItemVal(uc, sv);
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
