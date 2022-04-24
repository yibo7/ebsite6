using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Web.UI;
using EbSite.Control;
using EbSite.Core.DataStore;

namespace EbSite.BLL.Space
{
    public class WidgetMoveForHome : WidgetMove
    {

        public override ExtensionType ExtensionTp
        {
            get
            {
                return ExtensionType.HomeWidget;
            }
        }
        protected override void Render(HtmlTextWriter output)
        {
            //class=\"widget-header\"
            string sManager = "";
            if (IsManager)
                sManager = "movable removable editable closeconfirm collapsable";
            output.Write(string.Concat("<div id=\"", WidgetID, "\"  t=\"", WidgetType, "\" twid=\"", CtrID, "\" class=\"widget   ", sManager, "\">"));
            if (IsManager)
             output.Write("<div class='widget-header'>&nbsp;</div>");
            //获取外框
            Entity.WidgetBoxStyle mdBoxStyle = WidgetBoxStyle.Instance.GetStyleByID(BoxStyleID, ThemeID);
            if (mdBoxStyle!=null)
            {
                if (!string.IsNullOrEmpty(TitleLink))
                    Title = string.Format("<a href=\"{0}\">{1}</a>", TitleLink, Title);
                StringWriter sw = new StringWriter();
                HtmlTextWriter op = new HtmlTextWriter(sw);
                base.Render(op);
                string strHtml = sw.GetStringBuilder().ToString();
                //替换外框模板代码
                if(!string.IsNullOrEmpty(mdBoxStyle.StyleTemp))
                {
                    string OutHtml = mdBoxStyle.StyleTemp.Replace("{Title}", Title).Replace("{Content}", strHtml);
                    if (!string.IsNullOrEmpty(CustomDropDownListPram))
                    {
                        if (!string.IsNullOrEmpty(mdBoxStyle.CustomDropDownListPram))
                        {
                            string[] DrpCtrs = mdBoxStyle.CustomDropDownListPram.Split('|');
                            for (int i = 0; i < DrpCtrs.Length; i++)
                            {
                                string[] OneItem = DrpCtrs[i].Split('=');
                                if (OneItem.Length == 2)
                                    OutHtml = OutHtml.Replace(string.Concat("{", OneItem[0], "}"), mdBoxStyle.GetOneCustomDrpValue(i, base.CustomDropDownListPram));
                            }
                        }

                    }


                    if (!string.IsNullOrEmpty(base.CustomColors))
                    {
                        if (!string.IsNullOrEmpty(mdBoxStyle.StyleColorPram))
                        {
                            string[] sList = mdBoxStyle.StyleColorPram.Split('|');
                            for (int i = 0; i < sList.Length; i++)
                            {
                                OutHtml = OutHtml.Replace(string.Concat("{", sList[i], "}"), mdBoxStyle.GetOneCustomColorValue(i, base.CustomColors));
                            }
                        }

                    }

                    if (!string.IsNullOrEmpty(base.GetTextBoxValue))
                    {
                        if (!string.IsNullOrEmpty(mdBoxStyle.CustomTextBoxPram))
                        {
                            string[] sList = mdBoxStyle.CustomTextBoxPram.Split('|');
                            for (int i = 0; i < sList.Length; i++)
                            {
                                string[] OneItem = sList[i].Split('=');
                                if (OneItem.Length == 2)
                                {
                                    OutHtml = OutHtml.Replace(string.Concat("{", OneItem[0], "}"), mdBoxStyle.GetOneCustomTextBoxValue(i, base.GetTextBoxValue));
                                }

                            }
                        }

                    }

                    output.Write(OutHtml);
                }
                else
                {
                    base.Render(output);
                }
            }
            else
            {
                base.Render(output);
            }
            

            output.Write("</div>");
        }

        //protected override void Render(HtmlTextWriter output)
        //{


        //    StringBuilder sb = new StringBuilder();
        //    string sManager = "";
        //    if (IsManager)
        //        sManager = "movable removable editable closeconfirm collapsable";
        //    sb.AppendFormat("<div id=\"{0}\"  t=\"{1}\" twid=\"{2}\" class=\"widget   {3}\">", WidgetID, WidgetType, CtrID, sManager);
        //    if (!string.IsNullOrEmpty(TitleLink))
        //        Title = string.Format("<a href=\"{0}\">{1}</a>", TitleLink, Title);
        //    sb.AppendFormat("<div class=\"widget-header\"><span class='widgettitle_text'>{0}<span></div>", Title);
        //    sb.Append("<div class=\"widget-content\">");
        //    output.Write(sb.ToString());
        //    base.Render(output);
        //    output.Write("</div>");
        //    output.Write("</div>");
        //}
    }
}
