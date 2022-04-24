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
    public partial class index : TemPage
    {
        protected override EMakeType MakeType
        {
            get
            {
                return EMakeType.DCSY;
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
                if (Base.Configs.SchedulTask.ConfigsControl.Instance.IsOpenIndexCache)
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
                else
                {
                    GoToTem();
                }

                
                
            }
            
        }

        protected override  string GetCacheUrl
        {
            get
            {
               if (Request.QueryString.Count == 1 && !string.IsNullOrEmpty(Request.QueryString["site"])) //缓存站点首页目录，正好更新静态首页
               {
                   int iSiteID = int.Parse(Request.QueryString["site"]);

                   return string.Concat(Base.AppStartInit.IISPath,EbSite.Base.AppStartInit.Sites[iSiteID].SiteFolder,"/index.htm");
               }
               else
               {
                   StringBuilder sb = new StringBuilder("index/");
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
                Guid IndexTemID = EbSite.Base.Host.Instance.CurrentSite.IndexTemID;
                Entity.Templates obTem = TempFactory.Instance.GetModelByCache(IndexTemID, GetSiteID);
                if (!Equals(obTem, null))
                {
                    return obTem.TemPath;
                }
                return string.Empty;
            }
        }
       
    }
}
