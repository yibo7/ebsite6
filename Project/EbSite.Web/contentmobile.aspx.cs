using System;
using System.Text;
using EbSite.Base.Configs.SysConfigs;
using EbSite.Base.Page;
using EbSite.BLL;
using EbSite.BLL.GetLink;
using EbSite.Pages;

namespace EbSite.Web
{
    public partial class contentmobile : EbSite.Base.Page.TemPage
    {
        protected override EMakeType MakeType
        {
            get
            {
                return EMakeType.YDNRY;
            }
        }
        protected override int DataID
        {
            get
            {
                if (!string.IsNullOrEmpty(Request.QueryString["id"]))
                {
                    return int.Parse(Request.QueryString["id"]);
                }
                return -1;
            }
        }
        //private int GetContentID
        //{
        //    get
        //    {
        //        if (!string.IsNullOrEmpty(Request.QueryString["id"]))
        //        {
        //            return int.Parse(Request.QueryString["id"]);
        //        }
        //        return -1;
        //    }
        //}
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
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
            return (EbSite.BLL.Sites.Instance.GetLinkTypeContent(GetSiteID) != LinkType.AutoHtml || Request.Url.Query.LastIndexOf("&$html$") > -1);
            //return false; //手机版默认自动静态
        }  
        protected override string GetCacheUrl
        {
            get
            {
                StringBuilder sb = new StringBuilder("contentm/");
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
                Entity.NewsContent mdContent = NewsContentInst.GetModel(DataID, GetSiteID);
                Entity.Templates tm = null;
                if (!Equals(mdContent, null))
                {
                    Guid temId = BLL.ClassConfigs.Instance.GetContentTemIDMobile(mdContent.ClassID);
                    if (temId != Guid.Empty)
                    {
                        TemPath = TempFactory.InstanceMobile.GetTemPathByCache(temId);
                    }
                }
                return TemPath;
            }
            
        }

        #region yhl 2014-2-10
        private NewsContentSplitTable NewsContentInst
        {
            get
            {
                if (ClassID > 0)
                {
                    return EbSite.Base.AppStartInit.GetNewsContentInst(ClassID);
                }
                else
                {
                    return EbSite.Base.AppStartInit.GetNewsContentInst(ModelID, GetSiteID);
                }

            }
        }
        protected int ClassID
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

        public Guid ModelID
        {
            get
            {
                if (!string.IsNullOrEmpty(Request.QueryString["modelid"]))
                    return new Guid(Request.QueryString["modelid"]);
                else
                    return Guid.Empty;

            }
        }


        #endregion
    }
}
