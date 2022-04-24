using System;
using System.ComponentModel;
using System.Text;
using System.Web.UI;

namespace EbSite.Control
{
    /*
     实例:
      一次浏览多图片(设置ImgList,用|号分开)
      <XS:WinBox  ImgList="/themes/adminlogo.gif|/themes/admin/MenuImg/Comments-add.gif|/themes/admin/MenuImg/foldergreen_16.gif" Text="fsdfs" Href="#" IsImg=true Title="真的爱你1" ID="WinBoxList1" runat="server" />
     
     
     浏览组名为test的图片或页面(设置GroupName)
     图片:
     <XS:WinBox GroupName="test" Text="f4234" Href="/themes/admin/MenuImg/Comments-add.gif" IsImg=true Title="真的爱你2" ID="WinBoxList2" runat="server" />
     <XS:WinBox GroupName="test" Text="f4234" Href="/themes/admin/MenuImg/foldergreen_16.gif" IsImg=true Title="真的爱你3" ID="WinBoxList3" runat="server" />
     页面(不要IsImg=true):
     <XS:WinBox GroupName="test" Text="f4234" Href="/test1.html"  Title="真的爱你2" ID="WinBoxList2" runat="server" />
     <XS:WinBox GroupName="test" Text="f4234" Href="/test2.html"  Title="真的爱你3" ID="WinBoxList3" runat="server" />
     
     打开单个页面或图片
       图片:
          <XS:WinBox IsImg=true ID="WinBoxOne1" IsButton=true  Href="/themes/adminlogo.gif"   Title="查询结果" Text="测试SQL语句" runat="server" />
       页面(不要IsImg=true):
          <XS:WinBox  ID="WinBoxOne1" IsButton=true  Href="/index.aspx"   Title="查询结果" Text="测试SQL语句" runat="server" />
     */

    public enum WinBoxLinkModel
    {
        文本连接 = 0,
        图片连接 = 1,
        按钮 = 2,
        连接按钮 = 3
    }
    /// <summary>
    /// 控钮控件。
    /// </summary>
    [DefaultProperty("Text"), ToolboxData("<{0}:WinBox runat=server></{0}:WinBox>")]
    public class WinBox : WebControl
    {


        private WinBoxLinkModel _Linkmodel = WinBoxLinkModel.文本连接;
        /// <summary>
        /// 是否以按钮的样式显示
        /// </summary>
        [Bindable(true), Category("Appearance")]
        public WinBoxLinkModel LinkModel
        {
            get
            {
                return _Linkmodel;
            }
            set
            {
                _Linkmodel = value;
            }
        }

        private bool _IsFull = false;
        /// <summary>
        /// 是否全屏
        /// </summary>
        [Bindable(true), Category("Appearance"), DefaultValue("false")]
        public bool IsFull
        {
            get
            {
                return _IsFull;
            }
            set
            {
                _IsFull = value;
            }
        }

        private bool _IsImg = false;
        /// <summary>
        /// 是否图片
        /// </summary>
        [Bindable(true), Category("Appearance"), DefaultValue("false")]
        public bool IsImg
        {
            get
            {
                return _IsImg;
            }
            set
            {
                _IsImg = value;
            }
        }

        private bool _IsColseReLoadPage = false;
        /// <summary>
        /// 是否关闭时重载当前页面,只支持全屏模式 
        /// </summary>
        [Bindable(true), Category("Appearance"), DefaultValue("false")]
        public bool IsColseReLoadPage
        {
            get
            {
                return _IsColseReLoadPage;
            }
            set
            {
                _IsColseReLoadPage = value;
            }
        }


        private string _Text = "";
        /// <summary>
        /// 显示的文本，支持html
        /// </summary>
        [Bindable(true), Category("Appearance"), DefaultValue("")]
        public string Text
        {
            get
            {
                if (LinkModel == WinBoxLinkModel.按钮)
                {
                    return "<input type=\"submit\"  value=\"" + _Text + "\" class=\"AdminButton\" />";
                }
                if (LinkModel == WinBoxLinkModel.图片连接)
                {
                    string txt = string.Format("<img  style=\"border:solid 0px #ccc\" src=\"{0}\" />", HrefImg);

                    return txt;
                }
                if (LinkModel == WinBoxLinkModel.连接按钮)
                {
                    string txt = string.Format("<span class='AdminButton'>{0}</span>", _Text);

                    return txt;
                }
                return _Text;
            }
            set
            {
                _Text = value;
            }
        }
        private string _Href = "";
        /// <summary>
        /// 显示的文本，支持html
        /// </summary>
        [Bindable(true), Category("Appearance"), DefaultValue("")]
        public string Href
        {
            get
            {

                return _Href;
            }
            set
            {
                _Href = value;
            }
        }

        private string _HrefImg = "";
        /// <summary>
        /// 超连接图片路径
        /// </summary>
        [Bindable(true), Category("Appearance"), DefaultValue("")]
        public string HrefImg
        {
            get
            {

                return _HrefImg;
            }
            set
            {
                _HrefImg = value;
            }
        }

        private string _Title = "";
        /// <summary>
        /// 显示的文本，支持html
        /// </summary>
        [Bindable(true), Category("Appearance"), DefaultValue("")]
        public string Title
        {
            get
            {

                return _Title;
            }
            set
            {
                _Title = value;
            }
        }
        private string _GroupName = "";
        /// <summary>
        /// 显示的文本，支持html
        /// </summary>
        [Bindable(true), Category("Appearance"), DefaultValue("")]
        public string GroupName
        {
            get
            {

                return _GroupName;
            }
            set
            {
                _GroupName = value;
            }
        }
        private string _ImgList = "";
        /// <summary>
        /// 要显示的图片列表 用|号分开
        /// </summary>
        [Bindable(true), Category("Appearance"), DefaultValue("")]
        public string ImgList
        {
            get
            {

                return _ImgList;
            }
            set
            {
                _ImgList = value;
            }
        }
        private string jsfunction
        {
            get
            {
                if (!string.IsNullOrEmpty(ImgList))
                {
                    return "onclick=\"return GB_showImageSet(image_set, 1)\"";
                }
                //如果是安分组显示
                else if (!string.IsNullOrEmpty(GroupName))
                {
                    if (IsImg)
                        return "rel=\"gb_imageset[" + GroupName + "]\"";

                    return "rel=\"gb_pageset[" + GroupName + "]\"";
                }
                else
                {
                    if (IsImg)
                        return "onclick=\" return GB_showImage('" + Title + "', this.href);\"";
                    if (IsFull)
                    {
                        if (IsColseReLoadPage)
                        {
                            return "rel=\"gb_page_fs[1]\"";
                        }
                        else
                        {
                            return "rel=\"gb_page_fs[0]\"";
                        }
                    }

                    return "rel=\"gb_page_center[" + base.Width + ", " + base.Height + "]\"";
                }



            }
        }

        public WinBox()
        {
            base.Width = 640;
            base.Height = 480;
            Title = "窗口名称";

        }
        #region protected override void OnPreRender(EventArgs e)
        ///// <summary>
        ///// 重写<see cref="System.Web.UI.Control.OnPreRender"/>方法。
        ///// </summary>
        ///// <param name="e">包含事件数据的 <see cref="EventArgs"/> 对象。</param>
        //protected override void OnPreRender(EventArgs e)
        //{
        //    string IISPath = Base.AppStartInit.IISPath;
        //    StringBuilder scriptStr = new StringBuilder();
        //    scriptStr.AppendFormat("<script type=\"text/javascript\">var GB_ROOT_DIR = \"{0}js/openbox/\";</script>", IISPath);
        //    scriptStr.AppendFormat("<script type=\"text/javascript\" src=\"{0}js/openbox/AJS.js\"></script>", IISPath);
        //    scriptStr.AppendFormat("<script type=\"text/javascript\" src=\"{0}js/openbox/AJS_fx.js\"></script>", IISPath);
        //    scriptStr.AppendFormat("<script type=\"text/javascript\" src=\"{0}js/openbox/gb_scripts.js\"></script>", IISPath);
        //    scriptStr.AppendFormat("<link href=\"{0}js/openbox/gb_styles.css\" rel=\"stylesheet\" type=\"text/css\" media=\"all\" />", IISPath);

        //    if (!Page.ClientScript.IsClientScriptBlockRegistered("WinBoxScript"))
        //    {
        //        Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "WinBoxScript", scriptStr.ToString());
        //    }

        //    base.OnPreRender(e);
        //}
        #endregion
        protected override void Render(HtmlTextWriter output)
        {
            if (!string.IsNullOrEmpty(ImgList))
            {
                string[] aImgList = ImgList.Split('|');
                StringBuilder sb = new StringBuilder("<script>var image_set = [");
                foreach (string s in aImgList)
                {
                    sb.Append("{");
                    sb.Append("'caption': '图片浏览',");
                    sb.Append("'url': '" + s + "'");
                    sb.Append("},");
                }
                sb.Remove(sb.Length - 1, 1);
                sb.Append("];</script>");
                output.Write(sb.ToString());
            }
            output.Write("<a title=\"" + Title + "\" href=\"" + Href + "\"  " + jsfunction + " >");
            output.Write(Text);
            output.Write("</a>");
        }



    }
    
}