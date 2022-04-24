using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EbSite.Base;
using EbSite.Base.Configs.UserSetConfigs;
using EbSite.Base.EBSiteEventArgs;
using EbSite.BLL.Count;
using EbSite.Core;
using EbSite.Data.Interface;

namespace EbSite.BLL
{
    /// <summary>
    /// 业务逻辑类Remark 的摘要说明。
    /// </summary>
    public class Remark
    {
        //private static readonly DbProviderCms.GetInstance().Remark_Remark dal = new DbProviderCms.GetInstance().Remark_Remark();
       const double cachetime = 60.0;

       private  const string CacheRemark = "remark";// private static readonly string[] MasterCacheKeyArray = { "Remark" };
       // private static CacheManager bllCache;
        //static Remark()
        //{
        //    bllCache = new CacheManager(MasterCacheKeyArray);
        //}
        #region  成员方法

        /// <summary>
        /// 得到最大ID
        /// </summary>
        static public int GetMaxId()
        {
            return DbProviderCms.GetInstance().Remark_GetMaxId();
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        static public bool Exists(int ID)
        {
            return DbProviderCms.GetInstance().Remark_Exists(ID);
        }

        static public int GetCountByClassID(int ClassID, bool IsAuditing)
        {
            return DbProviderCms.GetInstance().Remark_GetCountByClassID(ClassID, IsAuditing);
        }
        /// <summary>
        /// 审核通过一个帖子
        /// </summary>
        /// <param name="ID"></param>
        static public void AllowOnePost(int ID)
        {
            Entity.Remark model = GetModel(ID);

            model.IsAuditing = true;

            Update(model);
            Host.CacheApp.InvalidateCache(CacheRemark);//bllCache.InvalidateCache();
        }
        static public int GetCount(int cid, int classid,int contentid, bool IsAuditing, string sqlwhere)
        {
            StringBuilder sbWhere = new StringBuilder();
            //触发的事件
            RemarkEventArgs Argsed = new RemarkEventArgs("");
            Base.EBSiteEvents.OnRemarkLoading(null, Argsed);
            if (string.IsNullOrEmpty(Argsed.Where))
            {
                if (cid >0 )
                {
                    sbWhere.AppendFormat(sqlwhere + " and  RemarkClassID={0} and classid={1} and contentid={2} and IsAuditing={3}", cid, classid, contentid,IsAuditing);
                }
                
            }
            else
            {
                sbWhere.AppendFormat(sqlwhere + " and  RemarkClassID='{0}' and {1}", cid, Argsed.Where);
            }
            return GetCount(sbWhere.ToString());//DbProviderCms.GetInstance().Remark_GetCount( cid,  classid, contentid,  IsAuditing);//
        }

        static public int GetCount(int cid, bool IsAuditing, out int CountScore, int classid, int contentid, string strSql)
        {


            string sWhere = string.Format("   RemarkClassID={0} and Classid={1} and ContentID={2} and IsAuditing={3}", cid, classid, contentid,IsAuditing);
            if (!string.IsNullOrEmpty(strSql))
                sWhere = sWhere + " and " + strSql;
            CountScore = DbProviderCms.GetInstance().Remark_CountScore(sWhere);
            return GetCount(sWhere);
        }
        
        static public int GetCount(string sbWhere)
        {

            return DbProviderCms.GetInstance().Remark_GetCount(sbWhere);
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <param name="isCredit">是否增加积分</param>
        /// <param name="iPage">0：一问一答 （不用管）。1：代表分类 2 :代表内容</param>
        static public void Add(EbSite.Entity.Remark model, bool isCredit)
        {
            //Host.CacheApp.InvalidateCache(CacheRemark);
            model.IsAuditing = !Base.Configs.SysConfigs.ConfigsControl.Instance.AuditingComment;
            //2013-12-18 YHL 原因：一问一答 不能增加积分。
            /*2014-3-5 YHL
            * 原来 Remark 表中 启用 Mark标实 时 ，在分类和内容 统计 评价 总数时 不能区分 后加 页面分类 用Ipage来 承载
            * 现在 扩展字段了 加了 classid contentid ，这样 就可以方便的 知道 是分类 还是内容了。如 contentid =0时 ，必定为分类
            */
            if (isCredit)
            {
                //更新内容（或分类或其他）中的评论条数
                if(model.ContentID>0)//if (iPage == 2) //内容评论
                {
                    //int iID = int.Parse(model.Mark);
                    //ContentCommentNum.Instance.iID = iID;
                    //ContentCommentNum.Instance.AddNum();

                    ContentBase cfn = BLL.Count.ContentCommentNum.Instance(model.ClassID);
                    cfn.iID = model.ContentID;
                    cfn.AddNum();
                }
                if(model.ContentID==0&&model.ClassID>0)//if (iPage == 1)  //分类评论
                {
                    //int iID = int.Parse(model.Mark);
                    ClassCommentNum.Instance.iID = model.ClassID;
                    ClassCommentNum.Instance.AddNum();
                }
            }
            model.Body = model.Body;// Core.Utils.CleanInput(model.Body);
            model.Quote = model.Quote;
            DbProviderCms.GetInstance().Remark_Add(model);
            if (isCredit)
            {
                #region 添加内容时 要获得积分

                //发表评论时 要获得积分 2011-12-31 杨欢乐添加
                EbSite.Base.EntityAPI.MembershipUserEb umd =
                    EbSite.BLL.User.MembershipUserEb.Instance.GetEntity(EbSite.Base.AppStartInit.UserID);
                if (!Equals(umd, null))
                {
                    int score = int.Parse(ConfigsControl.Instance.ToCommentInCredit.ToString());
                    umd.Credits += score;
                    EbSite.BLL.User.MembershipUserEb.Instance.Update(umd);
                }

                #endregion
            }
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        static public void Update(EbSite.Entity.Remark model)
        {
            Host.CacheApp.InvalidateCache(CacheRemark);// bllCache.InvalidateCache();
            DbProviderCms.GetInstance().Remark_Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        static public void Delete(int ID)
        {
            Host.CacheApp.InvalidateCache(CacheRemark);// bllCache.InvalidateCache();
            DbProviderCms.GetInstance().Remark_Delete(ID);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        static public Entity.Remark GetModel(int ID)
        {

            return DbProviderCms.GetInstance().Remark_GetModel(ID);
        }
        /// <summary>
        /// 帖子操作
        /// </summary>
        /// <param name="postid"></param>
        /// <param name="flag"></param>
        static public void ExecutePost(int postid, int flag)
        {
            Host.CacheApp.InvalidateCache(CacheRemark);//  bllCache.InvalidateCache();
            DbProviderCms.GetInstance().Remark_ExecutePost(postid, flag);

        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        //static private List<EbSite.Entity.Remark> GetModelList(int PageIndex, int PageSize,string strWhere)
        //{

        //    string rawKey = string.Concat(strWhere, PageIndex);
        //    List<EbSite.Entity.Remark> dsAllPost = bllCache.GetCacheItem(rawKey) as List<EbSite.Entity.Remark>;
        //    if (dsAllPost == null)
        //    {
        //        dsAllPost = DbProviderCms.GetInstance().Remark_GetListPages(PageIndex, PageSize, strWhere, " ID desc",);

        //        bllCache.AddCacheItem(rawKey, dsAllPost);
        //    }
        //    return dsAllPost;
        //}

        static public List<EbSite.Entity.Remark> GetListArray(string strWhere, int iTop, string OrderBy)
        {
            return DbProviderCms.GetInstance().Remark_GetListArray(strWhere, iTop, OrderBy);

        }

        //static public List<EbSite.Entity.Remark> GetModelList(int PageIndex, int PageSize, int cid, bool IsAuditing)
        //{
        //    string sWhere = "";
        //    if (cid >0)
        //    {
        //        sWhere = "  RemarkClassID=" + cid ;
        //    }
        //    return DbProviderCms.GetInstance().Remark_GetListPages(PageIndex, PageSize, sWhere, " ID desc", (IsAuditing ? 1 : 0));
        //}


        //static public List<EbSite.Entity.Remark> GetModelList(int cid, string Mark, bool IsAuditing, int PageIndex, int PageSize, string strSql)
        //{
        //    StringBuilder sbWhere = new StringBuilder();
        //    //sbWhere.AppendFormat("IsAuditing={0}", (IsAuditing ? "1" : "0"));

        //    //添加后触发的事件
        //    RemarkEventArgs Argsed = new RemarkEventArgs(Mark);
        //    Base.EBSiteEvents.OnRemarkLoading(null, Argsed);
        //    if (string.IsNullOrEmpty(Argsed.Where))
        //    {
        //        if (cid >0 && !string.IsNullOrEmpty(Mark))
        //        {
        //            sbWhere.AppendFormat(strSql + " and RemarkClassID={0} and Mark='{1}'", cid, Mark.Replace("'", "''"));
        //        }
        //        else if (cid >0)
        //        {
        //            sbWhere.AppendFormat(strSql + " and RemarkClassID={0} ", cid);
        //        }
        //    }
        //    else
        //    {
        //        sbWhere.AppendFormat(strSql + " and RemarkClassID={0} and {1}", cid, Argsed.Where);
        //    }

        //    return DbProviderCms.GetInstance().Remark_GetListPages(PageIndex, PageSize, sbWhere.ToString(), " ID desc", (IsAuditing ? 1 : 0));
        //}

        public static List<EbSite.Entity.Remark> GetModelList(int cid,bool IsAuditing, int PageIndex,int PageSize, int ClassID,int ContentID,out int Count,string strSql)
        {
           
            string sWhere = string.Format(" RemarkClassID={0} and ClassID={1} and ContentID={2}", cid, ClassID, ContentID);
            if (!string.IsNullOrEmpty(strSql))
                sWhere = sWhere +" and " +strSql;
            Count = GetCount(sWhere);
            return DbProviderCms.GetInstance().Remark_GetListPages(PageIndex, PageSize, sWhere, " ID desc", (IsAuditing ? 1 : 0));
        }
        public static List<EbSite.Entity.Remark> GetModelList(int cid, bool IsAuditing, int PageIndex, int PageSize, int ClassID, int ContentID)
        {

            string sWhere = string.Format(" RemarkClassID={0} and ClassID={1} and ContentID={2}", cid, ClassID, ContentID);
            
            return DbProviderCms.GetInstance().Remark_GetListPages(PageIndex, PageSize, sWhere, " ID desc", (IsAuditing ? 1 : 0));
        }

        static public List<EbSite.Entity.Remark> GetModelList(string sbWhere, bool IsAuditing, int PageIndex, int PageSize)
        {
            return DbProviderCms.GetInstance().Remark_GetListPages(PageIndex, PageSize, sbWhere.ToString(), " ID desc", (IsAuditing ? 1 : 0));
        }

        /// <summary>
        /// Gets the model list.
        /// </summary>
        /// <param name="sbWhere">The sb where.</param>
        /// <param name="IsAuditing">为1时已审核，为0未审核，为2所有.</param>
        /// <param name="PageIndex">Index of the page.</param>
        /// <param name="PageSize">Size of the page.</param>
        /// <returns>List&lt;EbSite.Entity.Remark&gt;.</returns>
        static public List<EbSite.Entity.Remark> GetModelList(string sbWhere, int IsAuditing, int PageIndex, int PageSize)
        {
            return DbProviderCms.GetInstance().Remark_GetListPages(PageIndex, PageSize, sbWhere.ToString(), " ID desc", IsAuditing);
        }

        #endregion  成员方法
        /// <summary>
        /// 得到评价的辅助信息
        /// </summary>
        /// <param name="gid">分类 GUID</param>
        /// <param name="mark"></param>
        /// <returns></returns>
        public static RemarkInfo GetRemarkInfo(int cid,int classid,int contentid)
        {
            RemarkInfo md = new RemarkInfo();
            List<EbSite.Entity.Remark> ls = EbSite.BLL.Remark.GetListArray( string.Format(" RemarkClassID={0} and ClassID={1} and ContentID={2}", cid, classid, contentid), 0, "");
            md.PlCount = ls.Count;


            int csum = (from s in ls select Convert.ToInt32(s.EvaluationScore)).Sum();
            if (ls.Count > 0)
            { md.StartCount = (csum / ls.Count).ToString(); }
            else
            {
                md.StartCount = "0";
            }
            return md;
        }


        /// <summary>
        ///跳转 前台 页面
        /// </summary>
        /// <param name="classid"></param>
        /// <param name="contentid"></param>
        /// <returns></returns>
        public static string PageUrl(int classid, int contentid)
        {
            string url = "";
            if (contentid > 0)
            {
                url = EbSite.Base.Host.Instance.GetContentLink(contentid, classid);
            }
            else
            {
                url = EbSite.Base.Host.Instance.GetClassHref(classid, 1);
            }
            return url;
        }
    }
    public class RemarkInfo
    {
        public RemarkInfo()
        {

        }
        public RemarkInfo(int _plcount)
        {
            this.PlCount = _plcount;

        }
        /// <summary>
        /// 评价总数
        /// </summary>
        public int PlCount { get; set; }
        /// <summary>
        /// 星星 (平均)
        /// </summary>
        public string StartCount { get; set; }
    }
}

