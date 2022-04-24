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
using EbSite.Core.SplitPage;

namespace EbSite.Mvc.Models
{
    public class List : ModelBae
    {
        public Entity.NewsClass CEntity = new Entity.NewsClass();
        public Entity.NewsClass PEntity;
        public int ClassId = 0;
        
        public int Count = 0;
        public int PageIndex = 0;
        public int PageSize = 0;
        public int OrderBy = 0;
        public EbSite.BLL.NewsContentSplitTable NewsContentBll;
        public List(int classId, int pageIndex,  int orderBy)
        {
            ClassId = classId;
            PageIndex = pageIndex; 
            OrderBy = orderBy;

            

            base.SeoTitle = GetSeoWord(SeoConfigs.SeoSiteIndexTitle, "");
            base.SeoKeyWord = GetSeoWord(SeoConfigs.SeoSiteIndexKeyWord, "");
            base.SeoDes = GetSeoWord(SeoConfigs.SeoSiteIndexDes, "");

            if (ClassId > 0)
            {
                NewsContentBll = AppStartInit.GetNewsContentInst(classId);
                CEntity = BLL.NewsClass.GetModelByCache(ClassId);
            }
            else
            {
                CEntity.ClassName = "所有分类";

            }

            if (CEntity.ParentID > 0)
                PEntity = BLL.NewsClass.GetModelByCache(CEntity.ParentID);
            else
                PEntity = CEntity;

            inithead();

          

            //Base.EBSiteEventArgs.ClassPageLoadEventArgs Args = new Base.EBSiteEventArgs.ClassPageLoadEventArgs(CEntity, HttpContext.Current, this.Page, GetSiteID, GetClassID);
            //Base.EBSiteEvents.OnClassPageLoadEvent(null, Args);
           
        }

        public List<EbSite.Entity.NewsContent> LoadContentListPages(int iPageSize = 15)
        {
            PageSize = iPageSize;
            if (!Equals(NewsContentBll,null))
              return NewsContentBll.GetListForListPage(PageIndex, PageSize, ClassId, OrderBy, out Count, SiteID, HttpContext.Current);
            return new List<Entity.NewsContent>();
        }

        public List<EbSite.Entity.NewsClass> LoadSubListPages(int iPageSize = 15)
        {
            PageSize = iPageSize;
           return BLL.NewsClass.GetOrderListPages_SubClass(PageIndex, PageSize, ClassId, out Count, SiteID);
        }
        public List<EbSite.Entity.NewsClass> LoadSubList()
        {
            SubClassBindingEventArgs Args = new SubClassBindingEventArgs(ClassId, "", HttpContext.Current, SiteID, "");
            Base.EBSiteEvents.OnSubClassBinding(null, Args);

            if (!Args.IsStopBind)
            {

                return BLL.NewsClass.GetSubClass(ClassId, 0, Args.Where, Args.OrderBy, SiteID);

            }
            return null;
        }




        public IHtmlString GetPageHtml(int showCodeNum=10)
        {
            XsPages pgJzList = new MvcPager();
            pgJzList.iCurrentPage = PageIndex;               //设置当前页码
            pgJzList.iTotalCount = Count;             //记录总数
            pgJzList.iPageSize = PageSize;                 //一首显示多少条
            pgJzList.ReWritePatchUrl = string.Concat(ClassId, "-{0}-", OrderBy, Base.Configs.ContentSet.ConfigsControl.Instance.ListPathRw);
            pgJzList.htPrams = null;
            pgJzList.ShowCodeNum = showCodeNum;
            return MvcHtmlString.Create(pgJzList.showpages());
        }

        private void inithead()
        {
            ClassMetaEventArgs Args = new ClassMetaEventArgs(base.SeoTitle, base.SeoKeyWord, base.SeoDes, CEntity.ID, PEntity.SiteID, HttpContext.Current);
            Base.EBSiteEvents.OnClassMeta(null, Args);
            if (!Args.StopSytemMeta)
            {
               
                string seoClassTitle = SeoSite.SeoClassTitle;
                string seoKeyWord = SeoSite.SeoClassKeyWord;
                string seoDes = SeoSite.SeoClassDes;
                GetSeoWord(ref seoClassTitle, ref seoKeyWord, ref seoDes, CEntity.ClassName, CEntity.ID);
                if (!Equals(CEntity.ClassName, "所有分类"))
                    base.SeoTitle = seoClassTitle;
                else
                {
                    base.SeoTitle = GetSeoWord(SeoSite.SeoSiteIndexTitle, "");
                }
                base.SeoKeyWord = seoKeyWord;
                base.SeoDes = seoDes;
            }
            else
            {
                base.SeoTitle = Args.SeoTitle;
                base.SeoKeyWord = Args.SeoKeyWord;
                base.SeoDes = Args.SeoDes;
            }
        }

        override protected string _MobileUrl
        {
            get
            {
                return EbSite.Base.Host.Instance.MGetClassHref(ClassId, 1);
            }
        }

        public string GetNav()
        {
            return GetNav(">>", true, 0);
        }
        public string GetNav(string Nav)
        {
            return GetNav(Nav, true, 0);
        }
        public string GetNav(string Nav, int FilterClassID)
        {
            return GetNav(Nav, true, FilterClassID);
        }
        public string GetNav(string Nav, bool IsAddCurrent)
        {
            return GetNav(Nav, IsAddCurrent, 0);
        }
       override public string GetNav(string Nav, bool IsAddCurrent, int FilterClassID)
        {
            return BLL.NewsClass.GetNav(Nav, ClassId, IsAddCurrent, SiteID, FilterClassID);
        }

       override protected  Guid TemID
        {
            get
            {
                return BLL.ClassConfigs.Instance.GetClassTemID(ClassId);
            }
        }
    }
}
