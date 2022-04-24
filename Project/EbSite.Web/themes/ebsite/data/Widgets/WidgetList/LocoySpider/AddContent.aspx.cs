using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using EbSite.BLL;
using EbSite.Base;
using EbSite.BLL.ModelBll;
using EbSite.Base.Static;
using EbSite.Core;
using NewsContent = EbSite.Entity.NewsContent;

namespace EbSite.Widgets.LocoySpider
{
    public partial class AddContent : System.Web.UI.Page
    {
        private string GetID
        {
            get
            {
                if (!string.IsNullOrEmpty(Request.Form["id"]))
                {
                    return Request.Form["id"];
                }
                return "";
            }
        }
        private List<string> GetColumn
        {
            get
            {
                string CacheKey = string.Concat("md", GetID);
                List<string> lst = EbSite.Base.Host.CacheApp.GetCacheItem<List<string>>(CacheKey, CacheLocoySpider); //bllCache.GetCacheItem(CacheKey) as List<string>;
                if (lst == null)
                {
                    edit md = new edit();
                    md.DataID = new Guid(GetID);
                    StringDictionary settings = md.GetSettings();

                    string sColumn = settings["Columns"];
                    if (!string.IsNullOrEmpty(sColumn))
                    {
                        string[] aColumn = sColumn.Split(',');
                        lst = new List<string>();
                        foreach (string column in aColumn)
                        {
                            string[] ac = column.Split('|');

                            lst.Add(ac[0]);
                        }

                        if (lst.Count > 0) EbSite.Base.Host.CacheApp.AddCacheItem(CacheKey, lst, CacheDuration, ETimeSpanModel.FZ, CacheLocoySpider); //bllCache.AddCacheItem(CacheKey, lst);
                    }

                }
                return lst;
            }
        }
        private NewsContent NewsModel
        {
            get
            {
                string CacheKey = string.Concat("md", GetID);
                NewsContent md = EbSite.Base.Host.CacheApp.GetCacheItem<NewsContent>(CacheKey, CacheLocoySpider); //bllCache.GetCacheItem(CacheKey) as NewsContent;
                if (Equals(md, null))
                {
                    Serializable.ConfigsControl mdSerializable = new Serializable.ConfigsControl(GetID);
                    md = mdSerializable.Instance;

                    if (!Equals(md, null))  EbSite.Base.Host.CacheApp.AddCacheItem(CacheKey,md,CacheDuration,ETimeSpanModel.FZ, CacheLocoySpider); //bllCache.AddCacheItem(CacheKey, md);
                }
                return md;
            }
        }
        const double CacheDuration = 5.0;//
        private const string CacheLocoySpider = "lspider";// private static readonly string[] MasterCacheKeyArray = { "LocoySpider" };
        //private static CacheManager bllCache;
        protected void Page_Load(object sender, EventArgs e)
        {
           // bllCache = new CacheManager(CacheDuration, MasterCacheKeyArray);
            if(!IsPostBack)
            {
                AddBll();
            }
        }
        /// <summary>
        /// 获取当前站点ID，要求当前页面的url有参数site,没有参数site将获取后台默认站点
        /// </summary>
        protected int GetSiteID
        {
            get
            {
                return Host.Instance.GetSiteID;
            }
        }
        private void AddBll()
        {
            if(!string.IsNullOrEmpty(GetID))
            {
                NewsContent nc = NewsModel;
                foreach (string c in GetColumn)
                {
                    if(!string.IsNullOrEmpty(c))
                    {
                        string cv = Request.Form[c];
                        InitModel(c, cv, ref nc);
                    }
                    
                }
                nc.SmallPic = "";
                Entity.NewsClass cModel = BLL.NewsClass.GetModelByCache(nc.ClassID);
                NewsContentSplitTable NewsContentInst = EbSite.Base.AppStartInit.GetNewsContentInst(nc.ClassID);//YHL 2014-2-11
                long ContentID = NewsContentInst.AddBLL(nc, -1, false, GetSiteID, cModel.ContentModelID); //暂时不下载图片

                if(ContentID>0)
                {
                    Response.Write("发表成功");
                }
                else
                {
                    Response.Write("发表失败");
                }

            }
            else
            {
                Response.Write("发表失败");
            }
        }
        private void InitModel(string ColumnName, string sValue, ref NewsContent ModifyModel)
        {
            if (ColumnName == "NewsTitle")
            {
                ModifyModel.NewsTitle = sValue;
            }
            else if (ColumnName == "SmallPic")
            {
                ModifyModel.SmallPic = sValue;
            }
            else if (ColumnName == "TitleStyle")
            {
                ModifyModel.TitleStyle = sValue;
            }
            else if (ColumnName == "hits")
            {
                if (!string.IsNullOrEmpty(sValue))
                    ModifyModel.hits = int.Parse(sValue);
            }
            else if (ColumnName == "ContentInfo")
            {
                ModifyModel.ContentInfo = sValue;
            }
            else if (ColumnName == "dayHits")
            {
                if (!string.IsNullOrEmpty(sValue))
                    ModifyModel.dayHits = int.Parse(sValue);
            }
            else if (ColumnName == "weekHits")
            {
                if (!string.IsNullOrEmpty(sValue))
                    ModifyModel.weekHits = int.Parse(sValue);
            }
            else if (ColumnName == "monthhits")
            {
                if (!string.IsNullOrEmpty(sValue))
                    ModifyModel.monthhits = int.Parse(sValue);
            }
            ///////////////////////
            else if (ColumnName == "TagIDs")
            {
                ModifyModel.TagIDs = sValue;
            }
            else if (ColumnName == "IsGood")
            {
                if (!string.IsNullOrEmpty(sValue))
                    ModifyModel.IsGood = bool.Parse(sValue);
            }
            else if (ColumnName == "IsComment")
            {
                if (!string.IsNullOrEmpty(sValue))
                    ModifyModel.IsComment = bool.Parse(sValue);
            }
            //else if (ColumnName == "ContentTemID")
            //{
            //    if (!string.IsNullOrEmpty(sValue))
            //        ModifyModel.ContentTemID = new Guid(sValue);
            //}
            else if (ColumnName == "Advs")
            {
                if (!string.IsNullOrEmpty(sValue))
                    ModifyModel.Advs = int.Parse(sValue);
            }
            /// //////////////////////////

            else if (ColumnName == "OrderID")
            {
                if (!string.IsNullOrEmpty(sValue))
                    ModifyModel.OrderID = int.Parse(sValue);
            }
            else if (ColumnName == "Annex1")
            {
                ModifyModel.Annex1 = sValue;
            }
            else if (ColumnName == "Annex2")
            {
                ModifyModel.Annex2 = sValue;
            }
            else if (ColumnName == "Annex3")
            {
                ModifyModel.Annex3 = sValue;
            }
            else if (ColumnName == "Annex4")
            {
                ModifyModel.Annex4 = sValue;
            }
            else if (ColumnName == "Annex5")
            {
                ModifyModel.Annex5 = sValue;
            }
            else if (ColumnName == "Annex6")
            {
                ModifyModel.Annex6 = sValue;
            }
            else if (ColumnName == "Annex7")
            {
                ModifyModel.Annex7 = sValue;
            }
            else if (ColumnName == "Annex8")
            {
                ModifyModel.Annex8 = sValue;
            }
            else if (ColumnName == "Annex9")
            {
                ModifyModel.Annex9 = sValue;
            }
            else if (ColumnName == "Annex10")
            {
                ModifyModel.Annex10 = sValue;
            }

        }


    }
}
