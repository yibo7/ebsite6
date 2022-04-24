using System;
using System.Text;
using EbSite.Base.Configs.SysConfigs;
using EbSite.Base.Page;
using EbSite.BLL;

namespace EbSite.Web
{
    public partial class list : EbSite.Base.Page.TemPage
    {
  
        protected override EMakeType MakeType
        {
            get
            {
                return EMakeType.FLY;
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
                
                StringBuilder sb = new StringBuilder("class/");
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

                if(DataID>0)
                {
                    
                    //Guid temId = BLL.NewsClass.GetTemID(DataID);
                    Guid temId = BLL.ClassConfigs.Instance.GetClassTemID(DataID);
                    if (temId != Guid.Empty)
                    {
                        TemPath = TempFactory.Instance.GetTemPathByCache(temId);
                    }
                }
                else
                {
                    TemPath = string.Concat(EbSite.Base.Host.Instance.IISPath, "themes/", EbSite.Base.Host.Instance.CurrentSite.PageTheme, "/pages/listall.aspx"); 
                }
         
                return TemPath;
            }
        }
        
        
    }
}
