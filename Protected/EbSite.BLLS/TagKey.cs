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
    /// 业务逻辑类TagKey 的摘要说明。
    /// </summary>
    public class TagKey
    {
        //private static readonly EbSite.DbProviderCms.GetInstance().TagKey_TagKey dal = new EbSite.DbProviderCms.GetInstance().TagKey_TagKey();
        const double cachetime = 60.0;
        private const string CacheTagKey = "tagkey";// private static readonly string[] MasterCacheKeyArray = { "SpecialNews" };
       // private static CacheManager bllCache;
        //static TagKey()
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
            return DbProviderCms.GetInstance().TagKey_GetMaxId();
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        static public bool Exists(int id)
        {
            return DbProviderCms.GetInstance().TagKey_Exists(id);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        static public int Add(EbSite.Entity.TagKey model)
        {
            return DbProviderCms.GetInstance().TagKey_Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        static public void Update(EbSite.Entity.TagKey model)
        {
            DbProviderCms.GetInstance().TagKey_Update(model);
        }
        /// <summary>
        /// 更新标签
        /// </summary>
        /// <param name="tags">标签名称，用逗号分开</param>
        /// <param name="ContentID">内容ID</param>
        /// <returns></returns>
        static public void UpdateTag(string tags, long ContentID, int iClassID, int SiteID)
        {
             
            UpdateTag( tags,  ContentID,  iClassID,  SiteID, EbSite.Base.AppStartInit.UserID);

        }

        static public void UpdateTag(string tags, long ContentID, int iClassID, int SiteID,int UserId)
        {
            //先添加标签,用户可能更新时加入了新的标签
            AddTags(tags.Split(','), ContentID, iClassID, SiteID, UserId);

            //获取当前内容对应的标签ID列表
            string NewTagIDs = GetTagsIDByName(tags, SiteID);

            //删除后的标签与内容关联的记录
            TagRelateNews.DeleteByRemove(NewTagIDs, ContentID);
            TagRelateUser.DeleteByRemove(NewTagIDs, UserId);
            EbSite.BLL.TagRelateClass.DeleteByRemove(NewTagIDs, iClassID);

        }

        //public static void AddTags(string[] tags, long ContentID, int iClassID, int SiteID)
        //{
        //    AddTags(tags, ContentID, iClassID, SiteID, AppStartInit.UserID);
        //}

        /// <summary>
            /// 添加多个标签
            /// </summary>
            /// <param name="tags"></param>
            /// <param name="ContentID"></param>
            static public void AddTags(string[] tags, long ContentID, int iClassID, int SiteID,int UserId)
        {
            if (tags.Length < 1) return;
            foreach (string tag in tags)
            {
                if(string.IsNullOrEmpty(tag)|| tag.Length<2)
                    continue;

                int tgID = AddOneTag(tag, ContentID, SiteID);


                if (tgID > 0)
                {
                    //添加标签与内容关联的记录
                    Entity.TagRelateNews md = new Entity.TagRelateNews();
                    md.NewsID = ContentID;
                    md.TagID = tgID;
                    md.ClassID = iClassID;
                    EbSite.BLL.TagRelateNews.Add(md);

                    if (UserId > 0) //配合在外面程序生成标签用 2015-09-19
                    {
                        //添加标签与用户关联的记录
                        Entity.TagRelateUser mdu = new Entity.TagRelateUser();
                        mdu.UserID = UserId;// AppStartInit.UserID;
                        mdu.UserName = AppStartInit.UserName;
                        mdu.UserNiName = AppStartInit.UserNiName;
                        mdu.TagID = tgID;
                        EbSite.BLL.TagRelateUser.Add(mdu);
                    }
                   

                    //添加标签与分类关联的记录
                    Entity.TagRelateClass mdc = new Entity.TagRelateClass();
                    mdc.TagID = tgID;
                    mdc.TagName = tag;
                    mdc.ClassID = iClassID;
                    EbSite.BLL.TagRelateClass.Add(mdc);
                }



            }
        }
        static public int UpdateByDelete(int tagID)
        {
            return DbProviderCms.GetInstance().TagKey_UpdateByDelete(tagID);
        }
        //添加一个标签，如果已经有相同名称的标签将不做添加操作，中在num上加一
        static public int AddOneTag(string tag, int SiteID)
        {
            return DbProviderCms.GetInstance().TagKey_UpdateByAdd(tag, SiteID);
        }
        static public int AddOneTag(string tag, long ContentID, int SiteID)
        {
            return DbProviderCms.GetInstance().TagKey_UpdateByAdd(tag, ContentID, SiteID);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        static public void Delete(int id)
        {
            DbProviderCms.GetInstance().TagKey_Delete(id);
            EbSite.BLL.TagRelateNews.DeleteByTagDelete(id);
        }
        /// <summary>
        /// 获取所有id列表，主要用来批量生成静态面页
        /// </summary>
        /// <returns></returns>
        static public List<int> GetIDList(int SiteID)
        {
            return DbProviderCms.GetInstance().TagKey_GetIDList("", SiteID);
        }
        /// <summary>
        /// 批量获取标签ID列表 ，如 a,b,c 三个标签，返回ID格式为 1,2,3 
        /// </summary>
        /// <param name="TagNames">标签名称列表，用逗号分开</param>
        /// <returns></returns>
        static public string GetTagsIDByName(string TagNames, int SiteID)
        {
            StringBuilder sb = new StringBuilder();
            if (!string.IsNullOrEmpty(TagNames))
            {
                string[] aNames = TagNames.Split(',');

                string sWhere = string.Join(" or TagName='", aNames);
                sWhere = string.Concat("TagName='", sWhere);

                sWhere = sWhere.Replace(" or", "' or");

                sWhere = string.Concat(sWhere, "' ");

                List<int> lstID = DbProviderCms.GetInstance().TagKey_GetIDList(sWhere, SiteID);

                foreach (int i in lstID)
                {
                    sb.Append(i);
                    sb.Append(",");
                }
                if (sb.Length > 0) sb.Remove(sb.Length - 1, 1);

            }

            return sb.ToString();
        }
        static public List<EbSite.Entity.TagKey> GetTagsIDByContentID(int ContentID, int ClassId, int OrderBy, int Top, int SiteID,int Num)
        {
            return DbProviderCms.GetInstance().TagKey_GetTagByContentID(ContentID, ClassId, OrderBy==1?"id":"num", Top, SiteID, Num);
        }

        ///// <summary>
        ///// 批量获取标签ID 超链接
        ///// </summary>
        ///// <param name="ContentID"></param>
        ///// <param name="SiteID"></param>
        ///// <returns></returns>
        //static public string GetTagsLink(int ContentID,int ClassID, int SiteID)
        //{
        //    string str = "";
        //    List<EbSite.Entity.TagKey> ls = DbProviderCms.GetInstance().TagKey_GetTagByContentID(ContentID, ClassID, SiteID);
        //    foreach (EbSite.Entity.TagKey tagKey in ls)
        //    {
        //        str += "<a href='" +EbSite.Base.Host.Instance.TagsSearchList(tagKey.id ,1,SiteID) + "'>" + tagKey.TagName + "</a>  ";
        //    }
        //    return str;
        //}

        /// <summary>
        /// 获取热门标签
        /// </summary>
        /// <param name="top"></param>
        /// <returns></returns>
        public static List<EbSite.Entity.TagKey> GetTagKeys_Hot(int top, int classid, int SiteID,int Num)
        {
            return GetTagKeysByClassID(top, classid, " num desc ", SiteID, Num);// DbProviderCms.GetInstance().TagKey_GetListArr("", top, " num desc ");
        }
        /// <summary>
        /// 获取某个分类的tag,采用联合查询，比较慢，以后分表
        /// </summary>
        /// <param name="top"></param>
        /// <param name="ClassID">大于0获取对应分类Tag,小于等于0,获取全部tag</param>
        /// <returns></returns>
        public static List<EbSite.Entity.TagKey> GetTagKeysByClassID(int top, int ClassID, string OrderBy, int SiteID,int Num)
        {
            string CacheKey = string.Concat("TagKey-", top, ClassID, OrderBy, "-", SiteID);
            List<EbSite.Entity.TagKey> lst = Host.CacheApp.GetCacheItem<List<EbSite.Entity.TagKey>>(CacheKey, CacheTagKey); //bllCache.GetCacheItem(CacheKey) as List<EbSite.Entity.TagKey>;
            if (Equals(lst, null))
            {
                if (ClassID > 0)
                {
                    lst = DbProviderCms.GetInstance().TagKey_GetTagKeysByClassID(top, ClassID, OrderBy, SiteID, Num);
                }
                else
                {
                    lst = DbProviderCms.GetInstance().TagKey_GetListArr("", top, OrderBy, SiteID, Num);
                }
                if (!Equals(lst, null))
                    Host.CacheApp.AddCacheItem(CacheKey, lst, cachetime, ETimeSpanModel.M, CacheTagKey);//bllCache.AddCacheItem(CacheKey, lst);
            }

            return lst;




        }

        /// <summary>
        /// 获取最新标签
        /// </summary>
        /// <param name="top"></param>
        /// <returns></returns>
        public static List<EbSite.Entity.TagKey> GetTagKeys_New(int top, int classid, int SiteID,int Num)
        {
            return GetTagKeysByClassID(top, classid, " id desc ", SiteID, Num); //DbProviderCms.GetInstance().TagKey_GetListArr("", top, " id desc ");
        }
        /// <summary>
        /// 获得数据列表-分页
        /// </summary>
        /// <param name="PageIndex"></param>
        /// <param name="PageSize"></param>
        /// <param name="iTop">1 为最新标签，2热门标签</param>
        /// <returns></returns>
        static public List<EbSite.Entity.TagKey> GetListPages(int PageIndex, int PageSize, int iTop, out int Count, int SiteID)
        {

            string sTop = " num "; //热门

            if (iTop == 2)
            {
                sTop = " id ";
            }
            return DbProviderCms.GetInstance().TagKey_GetListPages(PageIndex, PageSize, "", string.Format(" {0}  desc ", sTop), out Count, SiteID);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        static public EbSite.Entity.TagKey GetModel(int id)
        {
            return DbProviderCms.GetInstance().TagKey_GetModel(id);
        }
        static public string GetEname(int id)
        {
            EbSite.Entity.TagKey md = GetModel(id);
            if (md != null)
            {
                return EbSite.Core.Strings.cConvert.GetQuanPing(md.TagName);
            }
            return EbSite.Core.Strings.GetString.RandomNUMSTR(6);
        }
        static public string GetHtmlName(int id)
        {
            EbSite.Entity.TagKey md = GetModelByCache(id);
            if (md != null)
            {
                if (!string.IsNullOrEmpty(md.HtmlName))
                    return md.HtmlName;
            }
            return EbSite.Core.Strings.GetString.RandomNUMSTR(6);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中。
        /// </summary>
        static public EbSite.Entity.TagKey GetModelByCache(int ID)
        {
            string CacheKey = "TagKey-" + ID;
            Entity.TagKey model = Host.CacheApp.GetCacheItem<Entity.TagKey>(CacheKey, CacheTagKey);// bllCache.GetCacheItem(CacheKey) as Entity.TagKey;
            if (model == null)
            {
                model = DbProviderCms.GetInstance().TagKey_GetModel(ID); ; ;
                Host.CacheApp.AddCacheItem(CacheKey, model, cachetime, ETimeSpanModel.M, CacheTagKey);//bllCache.AddCacheItem(CacheKey, model);
            }

            return model;
        }
        /// <summary>
        /// 获得记录总数
        /// </summary>
        static public int GetCount(int SiteID)
        {
            return DbProviderCms.GetInstance().TagKey_GetCount("", SiteID);


        }

        static public void UpdateHtmlName(string Name, int KeyID)
        {
            DbProviderCms.GetInstance().TagKey_UpdateHtmlName(Name, KeyID);
        }
        static public void UpdateAllHtmlRule(string Rule)
        {
            DbProviderCms.GetInstance().TagKey_UpdateAllHtmlRule(Rule);
        }
        static public void MakeHtmlName(int SiteID)
        {
            List<EbSite.Entity.TagKey> lst = DbProviderCms.GetInstance().TagKey_GetListArr("", 0, "", SiteID,0);
            foreach (EbSite.Entity.TagKey md in lst)
            {
                string sHtmlName = HtmlReNameRule.GetName(md.HtmlNameRule, md.TagName, ""); ;
                UpdateHtmlName(sHtmlName, md.id);
            }
        }
        /// <summary>
        /// 合并标签
        /// </summary>
        /// <param name="iID">源标签ID</param>
        /// <param name="TargetID">目标标签ID</param>
        static public void MergeLable(int iID, int TargetID)
        {
            DbProviderCms.GetInstance().TagKey_MergeLable(iID, TargetID);
        }
        #endregion  成员方法
    }
}

