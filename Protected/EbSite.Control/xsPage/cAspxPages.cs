using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace EbSite.Control.xsPage
{
    public class cAspxPages : XsPages
    {
        protected override string BuildURL(int PageNumber)
        {
            if (PageNumber < 2 && !string.IsNullOrEmpty(FirstPageUrl))
            {
                return FirstPageUrl;
            }
            else
            {
                StringBuilder sb = new StringBuilder("?");
                if (!object.Equals(htPrams, null))
                {
                    foreach (DictionaryEntry entry in htPrams)
                    {
                        sb.Append(string.Concat(entry.Key, "=", entry.Value, "&"));
                    }

                }

                sb.Append("p=");
                sb.Append(PageNumber);
                return sb.ToString();
            }
            
        }
        public override string showpages()
        {
            StringBuilder sb = new StringBuilder();
            if (iTotalCount > 0)
            {
                sb.AppendFormat("<div class='ebtext-right'><ul class='pagination'>", PageClassName);
                if (iCurrentPage > 1)
                {
                    if (iCurrentPage > ShowCodeNum)
                    { 
                        sb.AppendFormat("<li>{0}</li>", base.GetHref("首页", BuildURL(1)));
                    }
                    sb.AppendFormat("<li><a class=\"{0}\" href=\"", UpPageCss);
                    sb.Append(BuildURL(iCurrentPage - 1));
                    sb.Append(string.Concat("\">", UpPageHtml, "</a></li>"));


                }

                foreach (object i in alsCurrentPages)
                {
                    if (((int.Parse(i.ToString()) + 1) == iCurrentPage))
                    { 
                        sb.AppendFormat("<li class=\"{0}\" ><a >{1}</a></li>", CurrentCss, (int.Parse(i.ToString()) + 1));
                    }
                    else
                    { 
                        sb.AppendFormat("<li class=\"pgcode\">{0}</li>", base.GetHref((int.Parse(i.ToString()) + 1).ToString(), BuildURL(int.Parse(i.ToString()) + 1)));
                    } 
                }

                if (iCurrentPage < iPageNum)
                { 
                    sb.Append("<li>");
                    sb.Append(base.GetHref(NextPageHtml, BuildURL(iCurrentPage + 1), NextPageCss)); 
                    sb.Append("</li>"); 

                    if (iCurrentPage < (iPageNum - ShowCodeNum - 1))
                    {
                        sb.AppendFormat("<li >{0}</li>", base.GetHref("尾页", BuildURL(iPageNum))); 
                    }

                }

                sb.AppendFormat("<li ><a>共<font color=red>{0}</font>条记录</a></li>", iTotalCount);

                sb.Append("</ul></div>");
            }
            
            return sb.ToString();
        }
    }
}
