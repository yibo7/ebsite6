using System;
using System.Text;
using EbSite.Base.Configs.SysConfigs;
using EbSite.BLL;
using EbSite.Base.Page;

namespace EbSite.Web
{
    public partial class listmobile : EbSite.Base.Page.TemPage
    {
      
        protected override EMakeType MakeType
        {
            get
            {
                return EMakeType.YDFLY;
            }
        }
        protected override int DataID
        {
            get
            {
                if (!string.IsNullOrEmpty(Request.QueryString["cid"]))
                {
                    return int.Parse(Request.QueryString["cid"]);
                }
                return -1;
            }
        }
        override protected bool IsNoAAutoHtml()
        {
            return (EbSite.BLL.Sites.Instance.GetLinkTypeClass(GetSiteID) != LinkType.AutoHtml || Request.Url.Query.LastIndexOf("$html$") > -1);
            //return false; //手机版默认自动静态
        }    
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                PageLoadBll();

            }

        }
        
        protected override string GetCacheUrl
        {
            get
            {
                
                StringBuilder sb = new StringBuilder("classm/");
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
                    Guid temId = BLL.ClassConfigs.Instance.GetClassTemIDMobile(DataID);
                    if (temId != Guid.Empty)
                    {
                        TemPath = TempFactory.InstanceMobile.GetTemPathByCache(temId);
                    }
                }
                else
                {
                    TemPath = string.Concat(EbSite.Base.Host.Instance.IISPath, "themesm/", EbSite.Base.Host.Instance.CurrentSite.MobileTheme, "/pages/listall.aspx");
                }

                return TemPath;

            }
        }
        
        
    }
}
