using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbSite.Core.SplitPage
{
    public class MvcPager : XsPages
    {
        protected override string BuildURL(long PageNumber)
        {
            string url = string.Empty;
            if (PageNumber > 1)
            {
                url = string.Format(ReWritePatchUrl, PageNumber);
            }
            else
            {
                if (!string.IsNullOrEmpty(FirstPageUrl))
                {
                    url = FirstPageUrl;
                }
                url = string.Format(ReWritePatchUrl, PageNumber);
            }
            if (!Equals(htPrams, null))
            {
                System.Collections.IDictionaryEnumerator enumerator = htPrams.GetEnumerator();
                StringBuilder sb = new StringBuilder("&");
                while (enumerator.MoveNext())
                {
                    sb.Append(enumerator.Key);
                    sb.Append("=");
                    sb.Append(enumerator.Value);
                }
                url = string.Concat(url, sb);
            }


            return url;
        }
        public override string showpages()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<div class='" + PageClassName + "'><ul>");
            if (iCurrentPage > 1)
            {
                if (iCurrentPage > ShowCodeNum)
                {
                    sb.AppendFormat("<li><a  href=\"{0}\">首页</a></li>", BuildURL(1));
                }

                sb.AppendFormat("<li><a class=\"{0}\" href=\"", UpPageCss);
                sb.Append(BuildURL(iCurrentPage - 1));
                sb.Append(string.Concat("\">", UpPageHtml, "</a></li>"));
            }

            foreach (object i in alsCurrentPages)
            {

                sb.Append(((int.Parse(i.ToString()) + 1) == iCurrentPage) ? "<li class=\"" + CurrentCss + "\"><a href=\"#\">" + (int.Parse(i.ToString()) + 1) + "</a></li>" : "<li><a href=\"" + BuildURL(int.Parse(i.ToString()) + 1) + "\">" + (int.Parse(i.ToString()) + 1) + "</a></li>");
            }

            if (iCurrentPage < iPageNum)
            {
                sb.AppendFormat("<li><a class=\"{0}\" href=\"", NextPageCss);
                sb.Append(BuildURL(iCurrentPage + 1));
                sb.Append(string.Concat("\">", NextPageHtml, "</a></li>"));

                if (iCurrentPage < (iPageNum - ShowCodeNum - 1))
                {
                    sb.AppendFormat("<li ><a  href=\"{0}\">尾页</a></li>", BuildURL(iPageNum));
                }

            }
            sb.Append("</ul></div>");
            return sb.ToString();
        }
    }
}
