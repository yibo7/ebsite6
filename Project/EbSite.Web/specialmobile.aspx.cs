using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.BLL;
using EbSite.Base.Configs.SysConfigs;
using EbSite.Base.Page;

namespace EbSite.Web
{
    public partial class specialmobile : EbSite.Base.Page.TemPage
    {
        protected override EMakeType MakeType
        {
            get
            {
                return EMakeType.YDZTY;
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
                PageLoadBll();

            }
        }
        override protected bool IsNoAAutoHtml()
        {
            return (EbSite.BLL.Sites.Instance.GetLinkTypeSpecial(GetSiteID) != LinkType.AutoHtml || Request.Url.Query.LastIndexOf("$html$") > -1);
            //return (EbSite.BLL.Sites.Instance.GetLinkTypeSpecial(GetSiteID) != LinkType.AutoHtml || Request.Url.Query.LastIndexOf("$html$") > -1);
        }
        protected override string GetCacheUrl
        {
            get
            {
                StringBuilder sb = new StringBuilder("specialm/");
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
                if (DataID > 0)
                {
                    Entity.SpecialClass md = BLL.SpecialClass.GetModelByCache(DataID);
                    //Entity.Templates obTem = null;
                    if (!Equals(md, null))
                    {
                        TemPath = TempFactory.InstanceMobile.GetTemPathByCache(md.SpecialTemIDMobile);
                        //TemPath = obTem.TemPath;
                    }
                }
                else
                {
                    TemPath = string.Concat(EbSite.Base.Host.Instance.IISPath, "themesm/", EbSite.Base.Host.Instance.CurrentSite.MobileTheme, "/pages/special.aspx");
                }
                
                return TemPath;
            }

        }
    }
}