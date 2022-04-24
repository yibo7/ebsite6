using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ComponentModel;
using System.Drawing;

namespace EbSite.Control
{
    /// <summary>
    /// ColorPicker 颜色拾取器控件。
    /// </summary>
    [DefaultProperty("ScriptPath"), ToolboxData("<{0}:CustomTagsBox runat=server></{0}:CustomTagsBox>")]
    public class CustomTagsBox : EbSite.Control.WebControl
    {

     
        /// <summary>
        /// 构造函数
        /// </summary>
        public CustomTagsBox()
            : base()
        {
        }

        /// <summary>
        /// 创建子控件
        /// </summary>
        protected override void CreateChildControls()
        {

          
            base.CreateChildControls();
        }


       
      
		#region protected override void OnPreRender(EventArgs e)
		/// <summary>
		/// 重写<see cref="System.Web.UI.Control.OnPreRender"/>方法。
		/// </summary>
		/// <param name="e">包含事件数据的 <see cref="EventArgs"/> 对象。</param>
		protected override void OnPreRender(EventArgs e)
		{
           StringBuilder sb = new StringBuilder();

            sb.AppendLine("<style>");
            sb.AppendLine(".CTDTTabs{ border-left:solid 1px #919191; text-align:center; height:18px; line-height:20px;border-top:solid 1px #919191; cursor:pointer; background-color:#EBEBEB; border-right:solid 1px #919191; margin-left:5px; padding:5px;  float:left }");
            sb.AppendLine(".CTDTTabs_On{ border-left:solid 1px #919191; text-align:center; height:18px; line-height:20px;border-top:solid 1px #919191; background-color:#fff; font-weight:bold;border-right:solid 1px #919191; margin-left:5px; padding:5px; float:left;}");
            sb.AppendLine("</style>");

            if (!Page.ClientScript.IsClientScriptBlockRegistered("CustomTagsBoxCss"))
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "CustomTagsBoxCss", sb.ToString());
            }
			base.OnPreRender(e);
		}



        #endregion
        #region Property 

        private Literal _EndLiteral;
        /// <summary>
        /// 当前选择的颜色值
        /// </summary>
        [Description("结束控件"), DefaultValue("")]
        public Literal EndLiteral
        {

            set
            {
                _EndLiteral = value;
            }
        }

        private bool IsMorePage = false;
        public string Items
        {
            get
            {
                object o = ViewState[this.ClientID + "Items"];
               if(!Equals(o,null))
               {
                   StringBuilder Taglist = new StringBuilder();
                   string sItems = o.ToString();
                   if (!string.IsNullOrEmpty(sItems))
                   {
                       string[] aItem = sItems.Split('|');
                       foreach (string s in aItem)
                       {
                           string[] aTtemSub = s.Split('#');
                          
                           if (aTtemSub.Length == 3)
                           {
                               IsMorePage = true;
                               Taglist.AppendFormat("<div  name=\"{0}\" u=\"{1}\" >", aTtemSub[1], aTtemSub[2]);
                               Taglist.Append(aTtemSub[0]);
                               Taglist.Append("</div>");
                           }
                           else
                           {
                               Taglist.AppendFormat("<div  name=\"{0}\" >", aTtemSub[1]);
                               Taglist.Append(aTtemSub[0]);
                               Taglist.Append("</div>");
                           }


                       }

                   }
                   return Taglist.ToString();
               }
               else
               {
                   return "";
               }

                
            }
            set
            {
                ViewState[this.ClientID + "Items"] = value;
            }
        }
        #endregion


        /// <summary> 
        /// 输出html,在浏览器中显示控件
        /// </summary>
        /// <param name="output"> 要写出到的 HTML 编写器 </param>
        protected override void Render(HtmlTextWriter output)
        {
         
            output.Write("<table id=\"CustomTagName\" width=\"98%\" border=\"0\"  cellpadding=0 cellspacing=0 ><tr><td id=\"CustomDataTableTags\"  style=\" height:30px; vertical-align:bottom\">");

            output.Write(Items);

            output.Write(string.Format("</td></tr><tr id=\"BoxContent\"><td  style=\" border:solid 1px #919191; padding:10px; vertical-align:top; height:{0}px; width:{1}px;\">", base.Height, base.Width));

            StringBuilder sbJs = new StringBuilder();
            sbJs.AppendLine("<script>");
            sbJs.AppendLine(" In.ready('customtags', function() {");
            sbJs.AppendLine("var Tags_CustomDataTable = new CustomTags();");
            sbJs.AppendLine("function InitCustomDataTableTags() {");
            sbJs.AppendLine("Tags_CustomDataTable.ParentObjName = \"CustomDataTableTags\";");
            sbJs.AppendLine("Tags_CustomDataTable.SubObj = \"div\";");
            sbJs.AppendLine("Tags_CustomDataTable.CurrentClassName = \"CTDTTabs_On\";");
            sbJs.AppendLine("Tags_CustomDataTable.ClassName = \"CTDTTabs\";");
            //sbJs.AppendLine("Tags_CustomDataTable.fun = function () { OnTags_Tags_CustomDataTable(this) };");
            sbJs.AppendLine("Tags_CustomDataTable.InitOnclickInTags();");
            if (IsMorePage)
            {
                string sTagname = HttpContext.Current.Request["tagname"];
                sbJs.AppendFormat("Tags_CustomDataTable.InitCurrent('{0}');", sTagname);
            }
            else
            {
                sbJs.AppendLine("Tags_CustomDataTable.InitOnclick(0);");
            }
            sbJs.AppendLine("}");

            //sbJs.AppendLine("function OnTags_Tags_CustomDataTable(obj) {");
            //sbJs.AppendLine("Tags_CustomDataTable.OnclickTags(obj);");
            //sbJs.AppendLine("}");
           
            sbJs.AppendLine("InitCustomDataTableTags();");
            sbJs.AppendLine("});");
            sbJs.AppendLine("</script>");
      

            if (!Equals(_EndLiteral,null))
            {
                _EndLiteral.Text = string.Concat("</td></tr></table>", sbJs.ToString());
                //_EndLiteral.RenderControl(output);
            }
            else
            {
                throw new Exception("没有设置结束输出控件(Literal),请完成此设置");
            }

            

        }
    }

}
