using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using EbSite.Base;
using EbSite.Base.EntityCustom;
using EbSite.BLL;

namespace EbSite.Mvc.Models
{
     public class ModelBae
    {
        public int SiteID;
        public string TemPath;
        public Entity.Templates Tem;
        private System.Web.HttpContext _HttpContext;
         public EbSite.Entity.Sites CurrentSite;
         public string SeoTitle;
         public string SeoKeyWord;
         public string SeoDes;
         public string SiteName;
       
         public EbSite.Base.EntityCustom.SeoSite SeoConfigs;
        public ModelBae()
        {
            _HttpContext = System.Web.HttpContext.Current;

            SiteID = Core.Utils.StrToInt(_HttpContext.Request["site"],1); 
            CurrentSite =  EbSite.BLL.Sites.Instance.GetEntity(SiteID);
            if (!Equals(TemID, Guid.Empty))
            {
                Tem = TempFactory.Instance.GetModelByCache(TemID, SiteID);
                TemPath = Tem.TemPath;
            }
            SiteName = CurrentSite.SiteName;

            #region SeoConfigs

            List<EbSite.Base.EntityCustom.SeoSite> ls = EbSite.BLL.SeoSites.Instance.FillList();
            int siteid = SiteID;
            List<EbSite.Base.EntityCustom.SeoSite> md = (from i in ls where i.SiteID == siteid select i).ToList();
            if (md.Count > 0)
            {
                SeoConfigs = md[0];

            }
            else
            {
                EbSite.Base.EntityCustom.SeoSite mdDefault = new SeoSite();

                mdDefault.SeoSiteIndexTitle = "{站点名称}_网站建设系统";
                mdDefault.SeoTagIndexKeyWord = "{站点名称}，网站建设";
                mdDefault.SeoSiteIndexDes = "{站点名称}是一个功能强大的网站建设系统";

                mdDefault.SeoClassTitle = "{分类名称}_{站点名称}";
                mdDefault.SeoSpecialTitle = "{专题名称}_{站点名称}";
                mdDefault.SeoContentTitle = "{内容标题}_{站点名称}";
                mdDefault.SeoTagIndexTitle = "标签大全_{站点名称}";
                mdDefault.SeoTagListTitle = "{标签名称}_{站点名称}";

                SeoConfigs = mdDefault;
            }

            #endregion
            
        }

         virtual protected string _MobileUrl
         {
             get { return string.Empty; }    
         }
         public string MobileUrl
         {
             get { return _MobileUrl; }
         }
         virtual public string GetNav(string Nav, bool IsAddCurrent, int FilterClassID)
         {
             return string.Empty;
         }
        public string PartialPathCshtml(string PartialName)
        {
            return string.Concat("~",CurrentSite.GetCurrentPageUrl(PartialName),".cshtml");
        }
        public string PartialPathAscx(string PartialName)
        {
            return string.Concat("~", CurrentSite.GetCurrentPageUrl(PartialName), ".ascx");
        }
        public string PartialPath(string PartialName)
        {
            return string.Concat("~", CurrentSite.GetCurrentPageUrl(PartialName));
        }
         protected virtual Guid TemID
         {
             get { return Guid.Empty; }
         }
         protected string GetSeoWord(string Rule, string sTitle)
         {
             string sSeo = Rule.Replace("{专题名称}", sTitle).Replace("{站点名称}", SiteName).Replace("{标签名称}", sTitle).Replace("{标签名称}", sTitle);
             return sSeo;
         }
         //分类
         protected void GetSeoWord(ref string RuleTitle, ref string RuleKeyWord, ref string RuleDes, string ClassName, int ClassID)
         {

             RuleTitle = RuleTitle.Replace("{分类名称}", ClassName).Replace("{站点名称}", SiteName);
             RuleKeyWord = RuleKeyWord.Replace("{分类名称}", ClassName).Replace("{站点名称}", SiteName);
             RuleDes = RuleDes.Replace("{分类名称}", ClassName).Replace("{站点名称}", SiteName);

             List<EbSite.Entity.NewsClass> lst = EbSite.BLL.NewsClass.GetParents(ClassID);
             int iCount = lst.Count;
             for (int i = 0; i < iCount; i++)
             {
                 string RulString = string.Concat("{父分类", i, "}");
                 string sClassName = lst[i].ClassName;
                 RuleTitle = RuleTitle.Replace(RulString, sClassName);
                 RuleKeyWord = RuleKeyWord.Replace(RulString, sClassName);
                 RuleDes = RuleDes.Replace(RulString, sClassName);
             }
             int iEndCount = iCount + 5;//去除多余的标记,一般来说在已经有层次基础上追加5个深度就足够
             for (int i = iCount; i < iEndCount; i++)
             {
                 string RulString2 = string.Concat("{父分类", i, "}");
                 RuleTitle = RuleTitle.Replace(RulString2, "");
                 RuleKeyWord = RuleKeyWord.Replace(RulString2, "");
                 RuleDes = RuleDes.Replace(RulString2, "");
             }
         }
         //内容
         protected void GetSeoWord(ref string RuleTitle, ref string RuleKeyWord, ref string RuleDes, string Title, string ClassName, int ClassID)
         {

             RuleTitle = RuleTitle.Replace("{内容标题}", Title).Replace("{站点名称}", SiteName).Replace("{分类名称}", ClassName);
             RuleKeyWord = RuleKeyWord.Replace("{内容标题}", Title).Replace("{站点名称}", SiteName).Replace("{分类名称}", ClassName);
             RuleDes = RuleDes.Replace("{内容标题}", Title).Replace("{站点名称}", SiteName).Replace("{分类名称}", ClassName);

             List<EbSite.Entity.NewsClass> lst = EbSite.BLL.NewsClass.GetParents(ClassID);
             int iCount = lst.Count;
             for (int i = 0; i < iCount; i++)
             {
                 string RulString = string.Concat("{父分类", i, "}");
                 string sClassName = lst[i].ClassName;
                 RuleTitle = RuleTitle.Replace(RulString, sClassName);
                 RuleKeyWord = RuleKeyWord.Replace(RulString, sClassName);
                 RuleDes = RuleDes.Replace(RulString, sClassName);
             }
             int iEndCount = iCount + 5;//去除多余的标记,一般来说在已经有层次基础上追加5个深度就足够
             for (int i = iCount; i < iEndCount; i++)
             {
                 string RulString2 = string.Concat("{父分类", i, "}");
                 RuleTitle = RuleTitle.Replace(RulString2, "");
                 RuleKeyWord = RuleKeyWord.Replace(RulString2, "");
                 RuleDes = RuleDes.Replace(RulString2, "");
             }
         }

         public IHtmlString HeadHtml(bool IsShowMobileRule = false)
         {
             string html = string.Format("<title>{0}</title><meta http-equiv=\"Content-Type\" content=\"text/html; charset={1}\" /><script type=\"text/javascript\">inisite({2}, '{3}');</script>", SeoTitle, "utf-8", SiteID, Host.Instance.ThemePath);
             if (IsShowMobileRule)
             {
                 html = string.Concat(html,
                     string.Format(
                         "<meta http-equiv=\"mobile-agent\" content=\"format=xhtml; url={0}\" /><meta http-equiv=\"mobile-agent\" content=\"format=html5; url={0}\" /><meta http-equiv=\"mobile-agent\" content=\"format=wml; url={0}\" />  ",
                         MobileUrl));
             }
             html = string.Concat(html, Styles.Render(string.Concat("~/themescss", SiteID)).ToHtmlString(), Scripts.Render("~/bundles/main").ToHtmlString());
             return MvcHtmlString.Create(html);
         }
         protected EbSite.Base.EntityCustom.SeoSite SeoSite
         {
             get
             {
                 List<EbSite.Base.EntityCustom.SeoSite> ls = EbSite.BLL.SeoSites.Instance.FillList();

                 List<EbSite.Base.EntityCustom.SeoSite> md = (from i in ls where i.SiteID == SiteID select i).ToList();
                 if (md.Count > 0)
                 {
                     return md[0];

                 }
                 else
                 {
                     EbSite.Base.EntityCustom.SeoSite mdDefault = new SeoSite();

                     mdDefault.SeoSiteIndexTitle = "{站点名称}_网站建设系统";
                     mdDefault.SeoTagIndexKeyWord = "{站点名称}，网站建设";
                     mdDefault.SeoSiteIndexDes = "{站点名称}是一个功能强大的网站建设系统";

                     mdDefault.SeoClassTitle = "{分类名称}_{站点名称}";
                     mdDefault.SeoSpecialTitle = "{专题名称}_{站点名称}";
                     mdDefault.SeoContentTitle = "{内容标题}_{站点名称}";
                     mdDefault.SeoTagIndexTitle = "标签大全_{站点名称}";
                     mdDefault.SeoTagListTitle = "{标签名称}_{站点名称}";

                     return mdDefault;
                 }



             }
         }
         public Host HostApi
         {
             get
             {
                 return Host.Instance;
             }
         }
    }
}
