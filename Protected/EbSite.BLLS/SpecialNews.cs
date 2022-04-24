using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using EbSite.Base;
using EbSite.Base.Static;
using EbSite.Core;
using EbSite.Data.Interface;
using EbSite.Entity;
namespace EbSite.BLL
{
    /// <summary>
    /// 业务逻辑类ListClassNews 的摘要说明。
    /// </summary>
    public class SpecialNews
    {
        //private static readonly EbSite.DbProviderCms.GetInstance().SpecialNews_SpecialNews dal = new EbSite.DbProviderCms.GetInstance().SpecialNews_SpecialNews();
        const double cachetime = 10.0;
        private const string CacheSpecialNews = "specialnews";// private static readonly string[] MasterCacheKeyArray = { "SpecialNews" };
       // private static CacheManager bllCache;
        //static SpecialNews()
        //{
        //    if (Equals(bllCache, null))
        //    {
        //        bllCache = new CacheManager(CacheDuration, MasterCacheKeyArray);
        //    }
        //}
        #region  成员方法

        /// <summary>
        /// 得到最大ID
        /// </summary>
        static public int GetMaxId()
        {
            return DbProviderCms.GetInstance().SpecialNews_GetMaxId();
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        static public bool Exists(int id)
        {
            return DbProviderCms.GetInstance().SpecialNews_Exists(id);
        }
        /// <summary>
        /// 获取记录总数-指定家族ID
        /// </summary>
        static public int GetCount(int jzid)
        {
            return DbProviderCms.GetInstance().SpecialNews_GetCount("SpecialClassID=" + jzid);
        }
        /// <summary>
        /// 从内容表的某个字段检测，并添加内容到专题
        /// </summary>
        /// <param name="sColumnName">字段名称</param>
        /// <param name="iType">类型，0,包含，1,等于</param>
        static public void AddFormContentColumn(string sColumnName, int iType, int SiteID)
        {
            if (string.IsNullOrEmpty(sColumnName)) return;

            string sWhere = "";
            List<EbSite.Entity.SpecialClass> lstSpecialClass = BLL.SpecialClass.GetListArr(SiteID);

            foreach (Entity.SpecialClass mdSpecialClass in lstSpecialClass)
            {
                string sSpecialClass = mdSpecialClass.SpecialName;

                if (iType == 0) //包含
                {
                    sWhere = string.Format("  {0} like '%{1}%'", sColumnName, sSpecialClass);
                }
                else  //相等
                {
                    sWhere = string.Format("  {0} = '{1}'", sColumnName, sSpecialClass);
                }

                //YHL 2014-2-11 遍历在 内容管理=》数据调整=》所选择的 专题的表 做为 批量添加专题的数据源
                string sv  = EbSite.BLL.DataSettings.Content.Instance.GetConfigCurrent.ContentTables;
                if (!string.IsNullOrEmpty(sv))
                {
                    string[] arryTb = sv.Split(',');
                    foreach (var li in arryTb)
                    {
                        EbSite.BLL.NewsContentSplitTable NewsContentBll = AppStartInit.GetNewsContentInst(li);
                        List<EbSite.Entity.NewsContent> lstContent = NewsContentBll.GetListArray(sWhere, 0, "", "", SiteID);
                        foreach (EbSite.Entity.NewsContent mdContent in lstContent)
                        {
                            Entity.SpecialNews mdSpecialNews = new Entity.SpecialNews();

                            mdSpecialNews.NewsID = mdContent.ID;

                            mdSpecialNews.SpecialClassID = mdSpecialClass.id;

                            mdSpecialNews.ClassID = mdContent.ClassID;

                            if (!ExistsContent(mdSpecialNews))
                                Add(mdSpecialNews);
                        }
                    }
                }



            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sColumnName">字段名称</param>
        /// <param name="iType">类型，0,包含，1,等于</param>
        /// <param name="key">关健词</param>
        /// <param name="specialId">专题ID</param>
        /// <param name="SiteID"></param>
        static public void AddFormContentToSpecial(string sColumnName, int iType, string key, int specialId, int SiteID)
        {
            if (string.IsNullOrEmpty(sColumnName)) return;
            string sWhere = "";
            if (iType == 0) //包含
            {
                sWhere = string.Format("  {0} like '%{1}%'", sColumnName, key);
            }
            else  //相等
            {
                sWhere = string.Format("  {0} = '{1}'", sColumnName, key);
            }
            //YHL 2014-2-11 遍历在 内容管理=》数据调整=》所选择的 专题的表 做为 批量添加专题的数据源
            string sv = string.Empty;
            sv = EbSite.BLL.DataSettings.Content.Instance.GetConfigCurrent.ContentTables;
            if (!string.IsNullOrEmpty(sv))
            {
                string[] arryTb = sv.Split(',');
                foreach (var li in arryTb)
                {
                    EbSite.BLL.NewsContentSplitTable NewsContentBll = AppStartInit.GetNewsContentInst(li);
                    List<EbSite.Entity.NewsContent> lstContent = NewsContentBll.GetListArray(sWhere, 0, "", "", SiteID);
                    foreach (EbSite.Entity.NewsContent mdContent in lstContent)
                    {
                        Entity.SpecialNews mdSpecialNews = new Entity.SpecialNews();

                        mdSpecialNews.NewsID = mdContent.ID;

                        mdSpecialNews.SpecialClassID = specialId;
                        mdSpecialNews.ClassID = mdContent.ClassID;

                        if (!ExistsContent(mdSpecialNews))
                            Add(mdSpecialNews);
                    }
                }

            }


        }

        /// <summary>
        /// 在某个分类里是否已经存在指定歌曲ID的记录
        /// </summary>
        static public bool ExistsContent(EbSite.Entity.SpecialNews model)
        {
            return DbProviderCms.GetInstance().SpecialNews_Exists("NewsID=" + model.NewsID + " and SpecialClassID=" + model.SpecialClassID);
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        static public int Add(EbSite.Entity.SpecialNews model)
        {

            return DbProviderCms.GetInstance().SpecialNews_Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        static public void Update(EbSite.Entity.SpecialNews model)
        {
            DbProviderCms.GetInstance().SpecialNews_Update(model);
        }


        /// <summary>
        /// 删除一条数据
        /// </summary>
        static public void Delete(int id)
        {
            DbProviderCms.GetInstance().SpecialNews_Delete(id);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        static public void Delete(EbSite.Entity.SpecialNews mb)
        {
            DbProviderCms.GetInstance().SpecialNews_Delete(mb.NewsID, mb.SpecialClassID);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        static public Entity.SpecialNews GetModel(int id)
        {
            return DbProviderCms.GetInstance().SpecialNews_GetModel(id);
        }

        /// <summary>
        /// 获取某个专题下的内容ID,用逗号分开
        /// </summary>
        static public string GetNewsIDBySid(int sid)
        {
            List<EbSite.Entity.SpecialNews> lst = DbProviderCms.GetInstance().SpecialNews_GetListArray(string.Concat("specialclassid=" + sid), 0, "");
            StringBuilder sb = new StringBuilder();
            foreach (EbSite.Entity.SpecialNews specialNews in lst)
            {
                sb.Append(specialNews.NewsID);
                sb.Append(",");
            }
            if (sb.Length > 1)
                sb.Remove(sb.Length - 1, 1);

            return sb.ToString();
        }

        /// <summary>
        /// 获取某个专题下的内容ID,用逗号分开
        /// </summary>
        static public List<EbSite.Entity.SpecialNews> GetArrBySid(int sid)
        {
            return DbProviderCms.GetInstance().SpecialNews_GetListArray(string.Concat("specialclassid=" + sid), 0, "");

        }


        /// <summary>
        /// 得到一个对象实体，从缓存中。
        /// </summary>
        static public Entity.SpecialNews GetModelByCache(int ID)
        {
            string CacheKey = "SpecialClass-" + ID;
            Entity.SpecialNews model = Host.CacheApp.GetCacheItem<Entity.SpecialNews>(CacheKey, CacheSpecialNews);// bllCache.GetCacheItem(CacheKey) as Entity.SpecialNews;
            if (model == null)
            {
                model = DbProviderCms.GetInstance().SpecialNews_GetModel(ID); ; ;
                Host.CacheApp.AddCacheItem(CacheKey, model, cachetime, ETimeSpanModel.FZ, CacheSpecialNews);// bllCache.AddCacheItem(CacheKey, model);
            }

            return model;
        }

        /// <summary>
        /// 获取某个专题下的内容ID,用逗号分开
        /// </summary>
        static public List<EbSite.Entity.SpecialNews> GetListArry(string strWhere)
        {
            return DbProviderCms.GetInstance().SpecialNews_GetListArray(strWhere, 0, "");

        }


        #endregion  成员方法
    }
}

