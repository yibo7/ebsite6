using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.HtmlControls;
using EbSite.Base;

namespace EbSite.Web.AdminHt
{
    public class BaseMaster : System.Web.UI.MasterPage
    {/// <summary>
     /// 网站安装目录
     /// </summary>
        protected  string IISPath
        {
            get
            {
                return EbSite.Base.AppStartInit.IISPath;
            }
        }
        /// <summary>
        /// 网站后台安装目录
        /// </summary>
        /// <value>The admin path.</value>
        protected string AdminPath
        {
            get { return AppStartInit.AdminPath; }
        }
       
        //protected override void OnLoad(EventArgs e)
        //{
        //    base.OnLoad(e);
        //    //InitJavaScript();
        //    //InitStyle();


        //}
        
        //protected virtual void InitStyle()
        //{
        //    AddStylesheetInclude(string.Concat(AdminPath, "themes/Ubold/css.css"));

        //}
        //public virtual void AddJavaScriptInclude(string url, string ID)
        //{

        //    HtmlGenericControl script = new HtmlGenericControl("script");
        //    script.Attributes["type"] = "text/javascript";
        //    script.Attributes["src"] = url;
        //    if (!string.IsNullOrEmpty(ID))
        //        script.Attributes["id"] = ID;

        //    Page.Header.Controls.Add(script);



        //}
        //public virtual void AddJavaScriptInclude(string url)
        //{

        //    AddJavaScriptInclude(url, "");

        //}
        //public virtual void AddStylesheetInclude(string url)
        //{
        //    HtmlLink link = new HtmlLink();
        //    link.Attributes["type"] = "text/css";
        //    link.Attributes["href"] = url;
        //    link.Attributes["rel"] = "stylesheet";
        //    Page.Header.Controls.Add(link);
        //}
    }
}