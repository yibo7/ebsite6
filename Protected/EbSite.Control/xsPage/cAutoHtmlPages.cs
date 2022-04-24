using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace EbSite.Control.xsPage
{
    public class cAutoHtmlPages : cAspxPages
    {
        protected override string BuildURL(int PageNumber)
        {
         
                if(PageNumber>1)
                {
                    return string.Format(ReWritePatchUrl, PageNumber);
                }
                else
                {
                    if (!string.IsNullOrEmpty(FirstPageUrl))
                    {
                        return FirstPageUrl;
                    }
                   return ReWritePatchUrl.Replace("{页码}", PageNumber.ToString());
                   // return string.Format(ReWritePatchUrl, PageNumber);//ReWritePatchUrl    13029-{0}-0{分类ID}a{页码}b{排序类别}l.aspx
                }
                
            
            
        }
        //public override string showpages()
        //{
        //    StringBuilder sb = new StringBuilder();
        //    sb.Append(string.Concat("<div class='" , ParentClassName , "'><table class=" , PageClassName , "><tr>"));
        //    if (iCurrentPage > 1)
        //    {
        //        if (iCurrentPage > ShowCodeNum)
        //        {
        //            //sb.AppendFormat("<td><a  href=\"{0}\">首页</a></td>", BuildURL(1));
        //            sb.AppendFormat("<td>{0}</td>", base.GetHref("首页", BuildURL(1)));
        //        }
        //        sb.AppendFormat("<td><a class=\"{0}\" href=\"", UpPageCss);
        //        sb.Append(BuildURL(iCurrentPage - 1));
        //        sb.Append(string.Concat("\">", UpPageHtml, "</a></td>"));
        //    }

        //    foreach (object i in alsCurrentPages)
        //    {
        //        if (((int.Parse(i.ToString()) + 1) == iCurrentPage))
        //        {
                   
        //            sb.AppendFormat("<td class=\"{0}\"><a>{1}</a></td>", CurrentCss, (int.Parse(i.ToString()) + 1));
        //        }
        //        else
        //        {
                    
        //            sb.AppendFormat("<td>{0}</td>", base.GetHref((int.Parse(i.ToString()) + 1).ToString(), BuildURL(int.Parse(i.ToString()) + 1)));
        //        }
        //        //sb.Append(((int.Parse(i.ToString()) + 1) == iCurrentPage) ? string.Concat("<td class=\"" , CurrentCss , "\"><a>" , (int.Parse(i.ToString()) + 1) , "</a></td>") : string.Concat("<td><a href=\"" , BuildURL(int.Parse(i.ToString()) + 1) , "\">" , (int.Parse(i.ToString()) + 1) , "</a></td>"));
        //    }

        //    if (iCurrentPage < iPageNum)
        //    {
        //        //sb.AppendFormat("<td><a class=\"{0}\" href=\"", NextPageCss);
        //        //sb.Append(BuildURL(iCurrentPage + 1));
        //        //sb.Append(string.Concat("\">", NextPageHtml, "</a></td>"));
        //        //if (iCurrentPage < (iPageNum - ShowCodeNum - 1))
        //        //{
        //        //    sb.AppendFormat("<td ><a  href=\"{0}\">尾页</a></td>", BuildURL(iPageNum));
        //        //}

                 
        //        sb.Append("<td>");
        //        sb.Append(base.GetHref(NextPageHtml, BuildURL(iCurrentPage + 1), NextPageCss)); 
        //        sb.Append("</td>"); 

        //        if (iCurrentPage < (iPageNum - ShowCodeNum - 1))
        //        {
        //            sb.AppendFormat("<td >{0}</td>", base.GetHref("尾页", BuildURL(iPageNum))); 
        //        }

        //    }
        //    sb.Append("</tr></table></div>");
        //    return sb.ToString();
        //}
    }
}
