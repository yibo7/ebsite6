using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.HtmlControls;
using EbSite.Base;
using EbSite.Base.Configs.SysConfigs;
using EbSite.BLL.GetLink;
using EbSite.Entity;
using EbSite.Pages;

namespace EbSite.Web.Pages
{
    public partial class tagv : EbSite.Base.Page.SearchBase
    {
        Entity.TagKey ThisModel = new TagKey();
        protected string ThisKeyName = "";

       virtual protected void MobileGo()
        {
           if (Core.Utils.IsMobileDevice(this.Context))
           {
               Response.Redirect(HostApi.MGetTagvHref(TagID, 1));
               Response.End();
           }
                
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                MobileGo();

                if (TagID > 0)
                {
                    ThisModel = BLL.TagKey.GetModel(TagID);
                    if (Equals(ThisModel, null))
                    {
                        EbSite.Log.Factory.GetInstance().ErrorLog(string.Format("标签已经不存在,发生在:{0}", Request.RawUrl));
                        Response.Status = "404 Not Found";
                        Response.End();
                    }
                    ThisKeyName = ThisModel.TagName;

                }
                //Response.Write(TagID);
                bindinfo();
                inithead();

                MobileMeta();

            }
        }
        /// <summary>
        /// 手机版不需要输出适配
        /// </summary>
       virtual protected   void MobileMeta()
        {
            #region 添加手机版定向

            HtmlMeta meta = new HtmlMeta();
            meta.HttpEquiv = "mobile-agent";
            meta.Content = string.Concat("format=xhtml; url=" , EbSite.Base.Host.Instance.MGetTagvHref(TagID, this.pgCtr.PageIndex));
            this.Header.Controls.Add(meta);
            HtmlMeta meta2 = new HtmlMeta();
            meta2.HttpEquiv = "mobile-agent";
            meta2.Content = string.Concat("format=html5; url=" , EbSite.Base.Host.Instance.MGetTagvHref(TagID, this.pgCtr.PageIndex));
            this.Header.Controls.Add(meta2);
            HtmlMeta meta3 = new HtmlMeta();
            meta3.HttpEquiv = "mobile-agent";
            meta3.Content = string.Concat("format=wml; url=" , EbSite.Base.Host.Instance.MGetTagvHref(TagID, this.pgCtr.PageIndex));
            this.Header.Controls.Add(meta3);

            #endregion 添加手机版定向
        }
        protected int TagID
        {
            get
            {
                if (!string.IsNullOrEmpty(Request.QueryString["tid"]))
                    return Convert.ToInt32(Request.QueryString["tid"]);
                else
                    return -1;
            }
        }
        protected string TagName
        {
            get
            {
                return Request.QueryString["tg"];
            }
        }

        protected int iPageSize
        {
            get
            {
                if (!Equals(pgCtr, null) && pgCtr.PageSize > 0)
                {
                    return pgCtr.PageSize;
                }
                else
                {
                    return Base.Configs.ContentSet.ConfigsControl.Instance.PageSizeTagValue;
                }

            }

        }
        private void bindinfo()
        {
            int Count = new int();

            List<Entity.NewsContent> lst; 
            if (TagID > 0)
            {
                lst = EbSite.Base.AppStartInit.NewsContentInstDefault.GetListPagesFromTagID(PageIndex, iPageSize, TagID, out Count, base.GetSiteID);
            }
            else if (!string.IsNullOrEmpty(TagName))
            {
                ThisKeyName = TagName;
                lst = EbSite.Base.AppStartInit.NewsContentInstDefault.GetListPagesFromTagName(PageIndex, iPageSize, TagName, out Count, base.GetSiteID);
            }
            else
            {
                return;
            }

            rpGetList.DataSource = lst;
            rpGetList.DataBind();
            //iSearchCount = Count;

            base.iSearchCount = Count;

            base.KeyWord = ThisKeyName;

            intpages();

        }
       virtual protected void intpages()
        {
            string rp = string.Empty;
            string sOtherPram;
            if (TagID > 0)
            {
                //rp = HrefFactory.GetInstance(base.GetSiteID).TagsSearchList(TagID, pgCtr.PageIndex);//string.Concat(TagID,"-{0}tagv.aspx");
                rp =string.Concat(IISPath,TagID, "-{0}", HostApi.TagSearchLinkRw(GetSiteID)); //{0} 页码//HostApi.TagsSearchList(TagID, pgCtr.PageIndex,GetSiteID);
                sOtherPram = string.Format("tid,{0}", TagID);
                pgCtr.FirstPageUrl = HostApi.TagsSearchList(TagID, 1);
            }
            else
            {
                //rp = "tagv.aspx?p={0}&";
                pgCtr.Linktype = LinkType.Aspx;
                sOtherPram = string.Format("tg,{0}|site,{1}", TagName, GetSiteID);
            }

            if (string.IsNullOrEmpty(pgCtr.ReWritePatchUrl)) //外面可以自定义
                pgCtr.ReWritePatchUrl = rp;

            
            pgCtr.AllCount = iSearchCount;
            pgCtr.PageSize = iPageSize;
            pgCtr.OtherPram = sOtherPram;
            pgCtr.CurrentClass = "CurrentPageCoder";
            pgCtr.ParentClass = "PagesClass";
        }
        private void inithead()
        {

            //base.SeoTitle = GetSeoWord(Base.Configs.ContentSet.ConfigsControl.Instance.SeoTagListTitle, ThisKeyName);
            //base.SeoKeyWord = GetSeoWord(Base.Configs.ContentSet.ConfigsControl.Instance.SeoTagListKeyWord, ThisKeyName);
            //base.SeoDes = GetSeoWord(Base.Configs.ContentSet.ConfigsControl.Instance.SeoTagListDes, ThisKeyName);
            base.SeoTitle = GetSeoWord(SeoSite.SeoTagListTitle, ThisKeyName);
            base.SeoKeyWord = GetSeoWord(SeoSite.SeoTagListKeyWord, ThisKeyName);
            base.SeoDes = GetSeoWord(SeoSite.SeoTagListDes, ThisKeyName);
        }
    }
}
