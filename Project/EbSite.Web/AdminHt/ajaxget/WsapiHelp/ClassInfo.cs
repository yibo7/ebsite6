using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EbSite.Web.AdminHt.ajaxget.WsapiHelp
{
    public struct ClassInfo
    {
        public int id{ get; set;}
        public string ClassName { get; set; }
        public string Url { get; set; }
        public int CtCount { get; set; }
        public int ChildCount { get; set; }
        public string CtUrl { get; set; }
        public string UrlCode { get; set; }
        public string UrlEdit { get; set; }
    }
}