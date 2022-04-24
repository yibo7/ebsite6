using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Web.UI;

namespace EbSite.Control
{
    /*
     
     前台代码实例:
     * 
     *  <a href="imgProd/triumph_big1.jpg" class="jqzoom" rel='gal1'  title="triumph" >
            <img src="imgProd/triumph_small1.jpg"  title="triumph"  style="border: 4px solid #666;">
        </a>
     * gal1 是一个图片组,如
     * <ul id="thumblist" class="clearfix" >
		<li><a class="zoomThumbActive" href='javascript:void(0);' rel="{gallery: 'gal1', smallimage: './imgProd/triumph_small1.jpg',largeimage: './imgProd/triumph_big1.jpg'}"><img src='imgProd/thumbs/triumph_thumb1.jpg'></a></li>
		<li><a href='javascript:void(0);' rel="{gallery: 'gal1', smallimage: './imgProd/triumph_small2.jpg',largeimage: './imgProd/triumph_big2.jpg'}"><img src='imgProd/thumbs/triumph_thumb2.jpg'></a></li>
		<li><a  href='javascript:void(0);' rel="{gallery: 'gal1', smallimage: './imgProd/triumph_small3.jpg',largeimage: './imgProd/triumph_big3.jpg'}"><img src='imgProd/thumbs/triumph_thumb3.jpg'></a></li>
	</ul>
     
     */

    [DefaultEvent("Click"), DefaultProperty("Text"), ToolboxData("<{0}:Jqzoom runat=server></{0}:Jqzoom>")]
    public class Jqzoom  : System.Web.UI.WebControls.WebControl
    {
         protected override void OnPreRender(EventArgs e)
         {
              
             if (!Page.ClientScript.IsClientScriptBlockRegistered("Jqzoom"))
             {
                 Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "Jqzoom", string.Concat("<SCRIPT language='javascript' src='", EbSite.Base.Host.Instance.IISPath, "js/plugin/jqzoom/jquery.jqzoom-core-pack.js'></SCRIPT>"));
             }
             base.OnPreRender(e);
         }
        #region Property

         /// <summary>
         /// 是否预加载图片
         /// </summary>
        [Bindable(true), Category("Appearance"), DefaultValue("")]
         public bool preloadImages
        {
            get
            {
                if (base.ViewState["preloadImages"] != null)
                {
                    return (bool)base.ViewState["preloadImages"];
                }
                else
                {
                    return false;
                }
            }
            set
            {
                base.ViewState["preloadImages"] = value;
            }
        }
        /// <summary>
        /// 是否总是开户图片展览区
        /// </summary>
        [Bindable(true), Category("Appearance"), DefaultValue("")]
        public bool AlwaysOn
        {
            get
            {
                if (base.ViewState["AlwaysOn"] != null)
                {
                    return (bool)base.ViewState["AlwaysOn"];
                }
                else
                {
                    return false;
                }
            }
            set
            {
                base.ViewState["AlwaysOn"] = value;
            }
        }
        /// <summary>
        /// 是否显示鼠标区域
        /// </summary>
        [Bindable(true), Category("Appearance"), DefaultValue("")]
        public bool Lens
        {
            get
            {
                if (base.ViewState["Lens"] != null)
                {
                    return (bool)base.ViewState["Lens"];
                }
                else
                {
                    return false;
                }
            }
            set
            {
                base.ViewState["Lens"] = value;
            }
        }

        /// <summary>
        /// 图片展览区的位置
        /// </summary>
        [Bindable(true), Category("Appearance"), DefaultValue("")]
        public Eposition Position
        {
            get
            {
                if (base.ViewState["Eposition"] != null)
                {
                    return (Eposition)base.ViewState["Eposition"];
                }
                else
                {
                    return Eposition.右边;
                }
            }
            set
            {
                base.ViewState["Eposition"] = value;
            }
        }
        /// <summary>
        /// 图片展览区的位置偏移-X轴
        /// </summary>
        [Bindable(true), Category("Appearance"), DefaultValue("")]
        public int XOffset
        {
            get
            {
                if (base.ViewState["xOffset"] != null)
                {
                    return (int)base.ViewState["xOffset"];
                }
                else
                {
                    return 0;
                }
            }
            set
            {
                base.ViewState["xOffset"] = value;
            }
        }
        /// <summary>
        /// 图片展览区的位置偏移-Y轴
        /// </summary>
        [Bindable(true), Category("Appearance"), DefaultValue("")]
        public int YOffset
        {
            get
            {
                if (base.ViewState["YOffset"] != null)
                {
                    return (int)base.ViewState["YOffset"];
                }
                else
                {
                    return 0;
                }
            }
            set
            {
                base.ViewState["YOffset"] = value;
            }
        }
        /// <summary>
        /// 图片展览方式
        /// </summary>
        [Bindable(true), Category("Appearance"), DefaultValue("")]
        public ZoomType Zoomtype
        {
            get
            {
                if (base.ViewState["ZoomType"] != null)
                {
                    return (ZoomType)base.ViewState["ZoomType"];
                }
                else
                {
                    return ZoomType.标准;
                }
            }
            set
            {
                base.ViewState["ZoomType"] = value;
            }
        }
        #endregion

        /// <summary>
        /// 输出html,在浏览器中显示控件
        /// </summary>
        /// <param name="output"></param>
        protected override void Render(HtmlTextWriter output)
        {
            if (this.Visible)
            {
                StringBuilder sb = new StringBuilder("<script>$(document).ready(function() {$('.jqzoom').jqzoom({");

                if (Zoomtype==ZoomType.标准)
                {
                    sb.Append("zoomType: 'standard',");
                }
                else if (Zoomtype==ZoomType.拖放)
                {
                    sb.Append("zoomType: 'drag',");
                }
                else if (Zoomtype == ZoomType.反向)
                {
                    sb.Append("zoomType: 'reverse',");
                }
                else if (Zoomtype == ZoomType.内部缩放)
                {
                    sb.Append("zoomType: 'innerzoom',");
                }
                
                if(Lens)
                {
                    sb.Append("lens:true,");
                }
                if (preloadImages)
                {
                    sb.Append("preloadImages: true,");
                }
                else
                {
                    sb.Append("preloadImages: false,");
                }
                if (AlwaysOn)
                {
                    sb.Append("alwaysOn:true,");
                }
                if (Position==Eposition.左边)
                {
                    sb.Append("position:'left',");
                }

                if (XOffset>0)
                {
                    sb.AppendFormat("xOffset:{0},", XOffset);
                }

                if (YOffset > 0)
                {
                    sb.AppendFormat("yOffset:{0},", YOffset);
                }

                if (base.Width.Value>0)
                {
                    sb.AppendFormat("zoomWidth:{0},", Width.Value);
                }
                if (base.Height.Value > 0)
                {
                    sb.AppendFormat("zoomHeight:{0},", Height.Value);
                }

                sb.Remove(sb.Length - 1, 1);

                sb.Append("});});</script>");

                output.Write(sb.ToString());
            }

        }
    }

    public enum Eposition
    {
        左边,
        右边
    }

    public enum ZoomType
    {
        标准,
        拖放,
        反向,
        内部缩放
    }
}
