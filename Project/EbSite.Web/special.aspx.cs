using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using EbSite.Base.Configs.SysConfigs;
using EbSite.Base.Page;
using EbSite.BLL;
using EbSite.BLL.GetLink;
using EbSite.Pages;

namespace EbSite.Web
{
    public partial class special : EbSite.Base.Page.TemPage
    {
        protected override EMakeType MakeType 
        { 
            get
            {
                return EMakeType.ZTY;
            } 
        }
        protected override int DataID 
        { 
            get
            {

                if (!string.IsNullOrEmpty(Request.QueryString["sid"]))
                {
                    return int.Parse(Request.QueryString["sid"]);
                }
                return -1;
            } 
        }

        //private int GetSpecialID
        //{
        //    get
        //    {
        //        if (!string.IsNullOrEmpty(Request.QueryString["sid"]))
        //        {
        //            return int.Parse(Request.QueryString["sid"]);
        //        }
        //        return -1;
        //    }
        //}
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                if (DataID > 0)
                {
                    PageLoadBll();

                }
                else
                {
                    TransferErr();
                }

            }
        }
        override protected bool IsNoAAutoHtml()
        {
            return (EbSite.BLL.Sites.Instance.GetLinkTypeSpecial(GetSiteID) != LinkType.AutoHtml || Request.Url.Query.LastIndexOf("$html$") > -1);
        }   
        protected override string GetCacheUrl
        {
            get
            {
                //string HtmlUrl = string.Empty;
                //int iPageIndex = 0;
                //if (!string.IsNullOrEmpty(Request["p"]))
                //{
                //    iPageIndex = int.Parse(Request["p"]);
                //}
                //HtmlUrl = LinkSpecial.Instance.GetHtmlInstance(base.GetSiteID).GetSpecialHref(GetSpecialID, iPageIndex);
                //return HtmlUrl;

                StringBuilder sb = new StringBuilder("special/");
                for (int i = 0; i < Request.QueryString.Count; i++)
                {
                    string sKey = Request.QueryString.Keys[i];
                    string sValue = Request.QueryString[i];
                    sb.Append(sKey);
                    sb.Append(sValue);
                    sb.Append("-");
                }
                sb.Append("eb.htm");
                return sb.ToString();
            }
            

        }
        protected override string GetTemUrl
        {
            get
            {
                string TemPath = string.Empty;
                Entity.SpecialClass md = BLL.SpecialClass.GetModelByCache(DataID);
                //Entity.Templates obTem = null;
                if (!Equals(md, null))
                {
                    TemPath = TempFactory.Instance.GetTemPathByCache(md.SpecialTemID);
                    //TemPath = obTem.TemPath;
                }
                return TemPath;
            }
          
        }
    }
}
