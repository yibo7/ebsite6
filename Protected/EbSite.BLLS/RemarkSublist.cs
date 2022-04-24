using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using EbSite.Base;
using EbSite.Base.Configs.UserSetConfigs;
using EbSite.BLL.Count;
using EbSite.Core;
using EbSite.Data.Interface;

namespace EbSite.BLL
{
    /// <summary>
    /// 业务逻辑类RemarkSublist 的摘要说明。
    /// </summary>
    public class RemarkSublist
    {
        //private static readonly DbProviderCms.GetInstance().RemarkSublist_RemarkSublist dal = new DbProviderCms.GetInstance().RemarkSublist_RemarkSublist();
        //private static readonly string[] MasterCacheKeyArray = { "RemarkSublist" };
        const double cachetime = 60.0;

        private const string CacheRemarkSublist = "rsublist";
        //  private static CacheManager bllCache;
        //static RemarkSublist()
        //{
        //    bllCache = new CacheManager(MasterCacheKeyArray);
        //}
        #region  成员方法

        /// <summary>
        /// 得到最大ID
        /// </summary>
        static public int GetMaxId()
        {
            return DbProviderCms.GetInstance().RemarkSublist_GetMaxId();
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        static public bool Exists(int ID)
        {
            return DbProviderCms.GetInstance().RemarkSublist_Exists(ID);
        }

        static public int GetCountByClassID(bool IsAuditing)
        {
            return DbProviderCms.GetInstance().RemarkSublist_GetCountByClassID(IsAuditing);
        }
        /// <summary>
        /// 审核通过一个帖子
        /// </summary>
        /// <param name="ID"></param>
        static public void AllowOnePost(int ID)
        {
            Entity.RemarkSublist model = GetModel(ID);

            model.IsAuditing = true;

            Update(model);
            Host.CacheApp.InvalidateCache(CacheRemarkSublist);// bllCache.InvalidateCache();
        }
        static public int GetCount(string strsql)
        {
            return DbProviderCms.GetInstance().RemarkSublist_GetCount(strsql);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        static public void Add(EbSite.Entity.RemarkSublist model)
        {
            Host.CacheApp.InvalidateCache(CacheRemarkSublist);// bllCache.InvalidateCache();
            model.IsAuditing = !Base.Configs.SysConfigs.ConfigsControl.Instance.AuditingComment;
            //更新内容（或分类或其他）中的评论条数


            DbProviderCms.GetInstance().RemarkSublist_Add(model);

            #region 添加内容时 要获得积分
            //发表评论时 要获得积分 2011-12-31 杨欢乐添加
            EbSite.Base.EntityAPI.MembershipUserEb umd = EbSite.BLL.User.MembershipUserEb.Instance.GetEntity(EbSite.Base.AppStartInit.UserID);
            if (!Equals(umd, null))
            {
                int score = int.Parse(ConfigsControl.Instance.ToCommentInCredit.ToString());
                umd.Credits += score;
                EbSite.BLL.User.MembershipUserEb.Instance.Update(umd);
            }


            #endregion
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        static public void Update(EbSite.Entity.RemarkSublist model)
        {
            Host.CacheApp.InvalidateCache(CacheRemarkSublist);// bllCache.InvalidateCache();
            DbProviderCms.GetInstance().RemarkSublist_Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        static public void Delete(int ID)
        {
            Host.CacheApp.InvalidateCache(CacheRemarkSublist);// bllCache.InvalidateCache();
            DbProviderCms.GetInstance().RemarkSublist_Delete(ID);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        static public Entity.RemarkSublist GetModel(int ID)
        {

            return DbProviderCms.GetInstance().RemarkSublist_GetModel(ID);
        }
        /// <summary>
        /// 帖子操作
        /// </summary>
        /// <param name="postid"></param>
        /// <param name="flag"></param>
        static public void ExecutePost(int postid, int flag)
        {
            Host.CacheApp.InvalidateCache(CacheRemarkSublist);// bllCache.InvalidateCache();
            DbProviderCms.GetInstance().RemarkSublist_ExecutePost(postid, flag);

        }

        static public List<EbSite.Entity.RemarkSublist> GetModelList(int PageIndex, int PageSize, bool IsAuditing)
        {
            string sWhere = "";

            return DbProviderCms.GetInstance().RemarkSublist_GetListPages(PageIndex, PageSize, sWhere, " ID desc", (IsAuditing ? 1 : 0));
        }
        static public List<EbSite.Entity.RemarkSublist> GetModelList(string sbWhere, bool IsAuditing, int PageIndex, int PageSize)
        {
            return DbProviderCms.GetInstance().RemarkSublist_GetListPages(PageIndex, PageSize, sbWhere.ToString(), " ID desc", (IsAuditing ? 1 : 0));
        }
        static public List<EbSite.Entity.RemarkSublist> GetModelList(string sbWhere, int IsAuditing, int PageIndex, int PageSize)
        {
            return DbProviderCms.GetInstance().RemarkSublist_GetListPages(PageIndex, PageSize, sbWhere.ToString(), " ID desc", IsAuditing);
        }

        #endregion  成员方法

        static public List<EbSite.Entity.RemarkSublist> GetModelList(int ParentID)
        {
            string sWhere = string.Format("ParentID={0}", ParentID);

            return DbProviderCms.GetInstance().RemarkSublist_GetListPages(1, 100, sWhere, "", 1);
        }
    }
}

