using System;
using System.Text;
using System.Web;
using System.Web.UI;
using EbSite.Base.Configs.SysConfigs;
using EbSite.Base.Page;
using EbSite.BLL;
using EbSite.Core.FSO;

namespace EbSite.Web
{
    public partial class indexmobile : TemPage
    {
        protected override EMakeType MakeType
        {
            get
            {
                return EMakeType.YDSY;
            }
        }
        protected override int DataID
        {
            get
            {
                return 0;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string sQuery = Request.Url.Query;
                if (!string.IsNullOrEmpty(sQuery))
                {
                    if (sQuery.LastIndexOf("$html$") > -1 || sQuery.LastIndexOf("$timermake$") > -1)
                    {
                        GoToTem();
                    }
                    else
                    {
                        PageLoadBll();
                    }

                }
                else
                {
                    PageLoadBll();

                }
                
            }
            
        }

        protected override  string GetCacheUrl
        {
            get
            {
               
                StringBuilder sb = new StringBuilder("indexm/");
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
        private void GoToTem()
        {
            string sT = GetTemUrl;
            if (!string.IsNullOrEmpty(sT))
            {
                Server.Transfer(sT);
            }
            else
            {
                Response.Write("找不到模板!");
            }
           
        }
        override protected bool IsNoAAutoHtml()
        {
            return false;
        }  
        protected override  string GetTemUrl
        {
            get
            {
                string sp = EbSite.Base.Host.Instance.CurrentSite.MGetCurrentPageUrl("index.aspx");
                if (!string.IsNullOrEmpty(sp))
                {
                    return sp;
                }
                return string.Empty;
            }
        }
       
    }
}
