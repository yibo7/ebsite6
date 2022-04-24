using System;
using System.Data;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using EbSite.Core;
using EbSite.Data.Interface;

namespace EbSite.BLL
{
    /// <summary>
    /// 业务逻辑类Invite 的摘要说明。
    /// </summary>
    public class Invite
    {
        const double cachetime = 10.0;

        private const string CacheInvite = "invite"; //private static readonly string[] MasterCacheKeyArray = { "Invite" };
       // private static CacheManager bllCache;
        //static Invite()
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
            
            return DbProviderCms.GetInstance().Invite_GetMaxId();
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        static public bool Exists(int id)
        {
            return DbProviderCms.GetInstance().Invite_Exists(id);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        static public int Add(EbSite.Entity.Invite model)
        {

            return DbProviderCms.GetInstance().Invite_Add(model);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        static public void Update(EbSite.Entity.Invite model)
        {
            DbProviderCms.GetInstance().Invite_Update(model);
        }


        /// <summary>
        /// 删除一条数据
        /// </summary>
        static public void Delete(int id)
        {
            DbProviderCms.GetInstance().Invite_Delete(id);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        static public Entity.Invite GetModel(int id)
        {
            return DbProviderCms.GetInstance().Invite_GetEntity(id);
        }



        /// <summary>
        /// 获得数据列表
        /// </summary>
        static public int GetCount(string strWhere)
        {
            return DbProviderCms.GetInstance().Invite_GetCount(strWhere);
        }

        #endregion  成员方法

        #region  自定义方法

        #endregion  自定义方法
    }
}

