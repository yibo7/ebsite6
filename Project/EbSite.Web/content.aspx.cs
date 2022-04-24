using System;
using System.Text;
using EbSite.Base.Configs.SysConfigs;
using EbSite.Base.Page;
using EbSite.BLL;
using EbSite.BLL.GetLink;
using EbSite.Pages;

namespace EbSite.Web
{
    public partial class content : EbSite.Base.Page.TemPage
    {
        protected override EMakeType MakeType
        {
            get
            {
                return EMakeType.NRY;
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
        }  
        protected override string GetCacheUrl
        {
            get
            {
                //string HtmlUrl = string.Empty;
                //HtmlUrl = LinkContent.Instance.GetHtmlInstance(base.GetSiteID).GetContentLink(GetContentID);
                //return HtmlUrl;
                StringBuilder sb = new StringBuilder("content/");
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
                Entity.NewsContent mdContent = NewsContentInst.GetModel(DataID, GetSiteID);//BLL.NewsContent.GetModel(DataID);
                Entity.Templates tm = null;
                if (!Equals(mdContent, null))
                {
                    //查询当前内容所在的分类-获取分类的模板
                     

                    Guid _ContentTemID = BLL.ClassConfigs.Instance.GetContentTemID(mdContent.ClassID);

                    if (!Equals(_ContentTemID, Guid.Empty))
                    {
                        tm = TempFactory.Instance.GetModelByCache(_ContentTemID,GetSiteID);
                    }
                    else
                    {
                        Base.AppStartInit.TipsPageRender("找不到相应的模板!!", string.Concat("内容ID为:", mdContent.ID, "的模板为空，其对应的分类ID:", mdContent.ClassID, "的模板也为空，所以无法创建此页面！"), "");
                    }


                    if (!Equals(tm, null))
                    {
                        TemPath = tm.TemPath;
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
