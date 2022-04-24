using System;
using System.Web.UI.HtmlControls;
using EbSite.Core.HttpModules;


namespace EbSite.Web.Pages
{

    public partial class special : EbSite.Base.Page.ILCSBase
    {
        //private int PageSize
        //{
        //    get
        //    {
        //        return Base.Configs.ContentSet.ConfigsControl.Instance.PageSizeSpecail;
        //    }

        //}
        protected int GetSpecialID
        {
            get
            {
                if (!string.IsNullOrEmpty(Request["sid"]))
                {
                    return int.Parse(Request["sid"]);
                }
                else
                {
                    return 0;
                }
            }
        }

        public int PageIndex
        {
            get
            {
                if (!string.IsNullOrEmpty(Request.QueryString["p"]))
                    return Convert.ToInt32(Request.QueryString["p"]);
                else
                    return 1;
            }
        }

        protected Entity.SpecialClass Model = new Entity.SpecialClass();
        protected string ParentSpecialName = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Model = BLL.SpecialClass.GetModelByCache(GetSpecialID);
                inithead();
                BindPages();

              
                BindData();
               
                ParentSpecialName = BLL.SpecialClass.GetModel(Model.ParentID).SpecialName;
                BindSubSpecial();

               
            }
        }

        protected override void MobileMeta()
        {
            #region 添加手机版定向

            HtmlMeta meta = new HtmlMeta();
            meta.HttpEquiv = "mobile-agent";
            meta.Content = string.Concat("format=xhtml; url=", EbSite.Base.Host.Instance.MGetSpecialHref(Model.id, PageIndex));
            this.Header.Controls.Add(meta);
            HtmlMeta meta2 = new HtmlMeta();
            meta2.HttpEquiv = "mobile-agent";
            meta2.Content = string.Concat("format=html5; url=", EbSite.Base.Host.Instance.MGetSpecialHref(Model.id, PageIndex));
            this.Header.Controls.Add(meta2);
            HtmlMeta meta3 = new HtmlMeta();
            meta3.HttpEquiv = "mobile-agent";
            meta3.Content = string.Concat("format=wml; url=", EbSite.Base.Host.Instance.MGetSpecialHref(Model.id, PageIndex));
            this.Header.Controls.Add(meta3);

            #endregion 添加手机版定向
        }

        protected int iPageSize
        {
            get
            {
                //if (Base.Configs.ContentSet.ConfigsControl.Instance.PageSizeSpecail > 0)
                //{
                //    return Base.Configs.ContentSet.ConfigsControl.Instance.PageSizeSpecail; 
                //}
                //else
                //{
                //    return pgCtr.PageSize;
                //}
                if (!Equals(pgCtr, null) && pgCtr.PageSize > 0)
                {
                    return pgCtr.PageSize;
                }
                else
                {
                    return Base.Configs.ContentSet.ConfigsControl.Instance.PageSizeSpecail;
                }


            }

        }
        virtual protected  void BindPages()
        {
            //318-{0}{专题ID}a{页码}s.html

            if (!Equals(pgCtr, null))
            {

                if (string.IsNullOrEmpty(pgCtr.ReWritePatchUrl)) //外面可以自定义
                {
                    if (UrlRules.SpecialRuleHtmlNames2.ContainsKey(GetSpecialID))
                    {
                        pgCtr.ReWritePatchUrl = string.Concat(UrlRules.SpecialRuleHtmlNames2[GetSpecialID], "{0}/");
                        pgCtr.FirstPageUrl = UrlRules.SpecialRuleHtmlNames2[GetSpecialID];
                    }
                    else
                    {
                        pgCtr.ReWritePatchUrl = HostApi.SpecialLinkRw(GetSiteID).Replace("{专题ID}", GetSpecialID.ToString()).Replace("{页码}", "{0}"); //{0} 页码
                        pgCtr.FirstPageUrl = HostApi.SpecialLinkRw(GetSiteID).Replace("{专题ID}", GetSpecialID.ToString()).Replace("{页码}", "1");
                    }

                  
                }
                    

                pgCtr.AllCount = iSearchCount;
                pgCtr.PageSize = iPageSize;
                pgCtr.OtherPram = string.Format("sid,{0}", GetSpecialID);
                pgCtr.CurrentClass = "CurrentPageCoder";
                pgCtr.ParentClass = "PagesClass";
            }
        }
       


        protected int iSearchCount = 0;
        private void BindData()
        {
            if (!Equals(rpSpecialList, null))
            {
                iSearchCount = 0;
                rpSpecialList.DataSource = EbSite.Base.AppStartInit.NewsContentInstDefault.GetListPagesFromSpecialID(PageIndex, iPageSize, GetSpecialID, out iSearchCount, base.GetSiteID);
                pgCtr.AllCount = iSearchCount;
                rpSpecialList.DataBind();
            }
            if (!Equals(rpSubSpecial, null))
            {
                rpSubSpecial.DataSource = BLL.SpecialClass.GetListArrByParentID(GetSpecialID,GetSiteID);
                rpSubSpecial.DataBind();
            }
        }

       
       virtual protected void inithead()
        {

            SeoTitle = GetSeoWord((string.IsNullOrEmpty(Model.SeoTitle)) ? SeoSite.SeoSpecialTitle : Model.SeoTitle, Model.SpecialName);
            SeoKeyWord = GetSeoWord((string.IsNullOrEmpty(Model.SeoKeyWord)) ? SeoSite.SeoSpecialKeyWord : Model.SeoKeyWord, Model.SpecialName);
            SeoDes = GetSeoWord((string.IsNullOrEmpty(Model.SeoDescription)) ? SeoSite.SeoSpecialDes : Model.SeoDescription, Model.SpecialName);
        
        }
       private void BindSubSpecial()
       {
           if (!Equals(rpGetSubSpecialList, null))
           {
               rpGetSubSpecialList.DataSource = BLL.SpecialClass.GetSub(GetSpecialID, GetSiteID);
               rpGetSubSpecialList.DataBind();
               if (rpGetSubSpecialList.Items.Count == 0)
               {
                   rpGetSubSpecialList.Visible = false;
               }
           }
       }
    }
}
