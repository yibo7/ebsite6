using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using EbSite.Base;
using EbSite.Base.EBSiteEventArgs;
using EbSite.Base.EntityCustom;
using EbSite.Core;
using EbSite.Core.SplitPage;

namespace EbSite.Mvc.Models
{
    public class Content : ModelBae
    {
        public Entity.NewsContent CEntity = new Entity.NewsContent();
        public Entity.NewsClass PEntity;
        public int ClassId = 0;
        
        public int Count = 0;
        public int PageIndex = 0;
        //public int PageSize = 0;
        public int ContentId = 0;
        public EbSite.BLL.NewsContentSplitTable NewsContentBll;
        public Content(int classId, int contentId, int pageIndex)
        {
            ClassId = classId;
            PageIndex = pageIndex;
            ContentId = contentId;
             

            if (ClassId > 0)
            {
                NewsContentBll = AppStartInit.GetNewsContentInst(classId);
                CEntity = NewsContentBll.GetModel(contentId, SiteID); 
            }
            else
            {
                CEntity.ClassName = "所有分类";

            }

            BindPageInfo();

            inithead();

          

            //Base.EBSiteEventArgs.ClassPageLoadEventArgs Args = new Base.EBSiteEventArgs.ClassPageLoadEventArgs(CEntity, HttpContext.Current, this.Page, GetSiteID, GetClassID);
            //Base.EBSiteEvents.OnClassPageLoadEvent(null, Args);
           
        }
        public Entity.ContentPageInfo CPINext;
        private string PageTitle;
        public string ShowInfo = string.Empty;
        protected virtual EbSite.Base.ThemeType eThemeType
        {
            get { return ThemeType.PC; }
        }
        private void BindPageInfo()
        {
            
            if (!string.IsNullOrEmpty(CEntity.ContentInfo) && (CEntity.ContentInfo.IndexOf(AppStartInit.ContentPageSplit) > -1))
            {
                //bool isHtml = CEntity.ContentInfo.IndexOf("<") > -1;
                List<Entity.ContentPageInfo> lst = NewsContentBll.GetPageInfos(CEntity.ContentInfo, ref ShowInfo, CEntity.ID, CEntity.ClassID, PageIndex, eThemeType);
                if (lst.Count > 1)
                {
                    if (PageIndex > 0)
                        PageTitle = lst[PageIndex].Title;
                    int nextindex = PageIndex + 1;
                    if (nextindex < lst.Count)
                    {
                        CPINext = lst[nextindex];
                    }


                }
            }
            else
            {
                ShowInfo = UBB.UBBToHtml(CEntity.ContentInfo);
            }

            if (eThemeType == ThemeType.MOBILE && !string.IsNullOrEmpty(ShowInfo))
            {
                ShowInfo = HostApi.GetMobileContent(ShowInfo);
            }

        }   

        private void inithead()
        {
            string seoClassTitle = SeoSite.SeoContentTitle;
            string seoKeyWord = SeoSite.SeoContentKeyWord;
            string seoDes = SeoSite.SeoContentDes;

            string newstitle = CEntity.NewsTitle;
            if (!string.IsNullOrEmpty(PageTitle))
                newstitle = string.Concat(newstitle, "_", PageTitle);

            GetSeoWord(ref seoClassTitle, ref seoKeyWord, ref seoDes, newstitle, CEntity.ClassName, CEntity.ClassID);
            base.SeoTitle = seoClassTitle;
            base.SeoKeyWord = seoKeyWord;
            base.SeoDes = seoDes;
        }
        public EbSite.Base.EntityAPI.MembershipUserEb UserInfos
        {
            get
            {
                Base.EntityAPI.MembershipUserEb _UserInfos =EbSite.BLL.User.MembershipUserEb.Instance.GetEntity(CEntity.UserID);
                if (_UserInfos != null)
                    return _UserInfos;
                else
                {
                    return new Base.EntityAPI.MembershipUserEb();
                }
            }
        }
        override protected string _MobileUrl
        {
            get
            {
                return EbSite.Base.Host.Instance.MGetContentLink(CEntity.ID, CEntity.ClassID, 1);
            }
        }

        public string GetNav(string Nav)
        {
            return BLL.NewsClass.GetNav(Nav, CEntity.ClassID, true, SiteID, 0);
        }
        public string GetNav(string Nav, bool IsAddIndex)
        {
            return BLL.NewsClass.GetNav(Nav, CEntity.ClassID, IsAddIndex, SiteID, 0);
        }
        override public string GetNav(string Nav, bool IsAddIndex, int FilterClassID)
        {
            return BLL.NewsClass.GetNav(Nav, CEntity.ClassID, IsAddIndex, SiteID, FilterClassID);
        }

       override protected  Guid TemID
        {
            get
            {
                return BLL.ClassConfigs.Instance.GetContentTemID(ClassId);
            }
        }
    }
}
