using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace EbSite.Control.xsPage
{
    public class HtmlPages : cAspxPages
    {
        private string PageSplit
        {
            get
            {
                return Base.Configs.HtmlConfigs.ConfigsControl.Instance.PageSplit;
            }
        }
        protected override string BuildURL(int PageNumber)
        {
            if(PageNumber<2&&!string.IsNullOrEmpty(FirstPageUrl))
            {
                return FirstPageUrl;
            }
            else
            {
                StringBuilder sb = new StringBuilder();

                if (iCurrentPage > 1)
                {
                    sb.Append("../");
                }
                if (PageNumber > 1)
                {
                    //foreach (DictionaryEntry entry in htPrams)
                    //{
                    //    sb.Append(entry.Value);
                    //}
                    sb.Append(PageSplit);
                    sb.Append(PageNumber);
                    sb.Append("/");
                }
                return sb.ToString();
            }


            
        }

        //public override string showpages()
        //{
        //    StringBuilder sb = new StringBuilder();
        //    sb.Append(string.Concat("<div class='" + ParentClassName + "'><table class=" + PageClassName + "><tr>"));
        //    if (iCurrentPage > 1)
        //    {
        //        if (iCurrentPage > ShowCodeNum)
        //        {
        //            sb.AppendFormat("<td><a  href=\"{0}\">首页</a></td>", BuildURL(1));
        //        }

        //        sb.AppendFormat("<td><a class=\"{0}\" href=\"", UpPageCss);
        //        sb.Append(BuildURL(iCurrentPage - 1));
        //        sb.Append(string.Concat("\">", UpPageHtml, "</a></td>"));
        //    }
        //    //sb.Append("<ul>");
        //    foreach (object i in alsCurrentPages)
        //    {

        //        sb.Append(((int.Parse(i.ToString()) + 1) == iCurrentPage) ? "<td class=\"" + CurrentCss + "\">" + (int.Parse(i.ToString()) + 1) + "</td>" : "<td><a href=\"" + BuildURL(int.Parse(i.ToString()) + 1)  + "\">" + (int.Parse(i.ToString()) + 1) + "</a></td>");
        //    }
        //    //sb.Append("</ul>");
        //    if (iCurrentPage < iPageNum)
        //    {
        //        sb.AppendFormat("<td><a class=\"{0}\" href=\"", NextPageCss);
        //        sb.Append(BuildURL(iCurrentPage + 1));
        //        sb.Append(string.Concat("\">", NextPageHtml, "</a></td>"));

        //        if (iCurrentPage < (iPageNum - ShowCodeNum - 1))
        //        {
        //            sb.AppendFormat("<td ><a  href=\"{0}\">尾页</a></td>", BuildURL(iPageNum));
        //        }

        //    }
        //    sb.Append("</table></div>");
        //    return sb.ToString();
        //}
    }
}
