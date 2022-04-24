
using System.Collections.Generic;
using System.Text;
using EbSite.Base;
using EbSite.BLL.Count;
using EbSite.Data.Interface;
using EbSite.Data.User.Interface;

namespace EbSite.BLL
{
    /// <summary>
    /// 业务逻辑类Favorite 的摘要说明。
    /// </summary>
    public class Favorite
    {
        //static private readonly DbProviderUser.GetInstance().Favorite_Favorite dal = new DbProviderUser.GetInstance().Favorite_Favorite();
        public Favorite()
        { }
        #region  成员方法


        static public int GetCount(string strsql)
        {
            return DbProviderUser.GetInstance().Favorite_GetCount(strsql);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        static public int Add(EbSite.Entity.Favorite model)
        {

            model.UserName = Base.AppStartInit.UserName;
            model.UserNiName = AppStartInit.UserNiName;
            model.UserID = Base.AppStartInit.UserID;

            int id =  DbProviderUser.GetInstance().Favorite_Add(model);


            //向内容表或分类列表递增收藏的统计数据-采用缓存
            if (model.FavType == 0) //内容  
            {
                ContentBase cfn = BLL.Count.ContentFavorableNum.Instance(model.ClassID);
                cfn.iID = model.ContentID;
                cfn.AddNum();
            }
            else if (model.FavType == 1) //分类
            {
                BLL.Count.ClassFavorableNum.Instance.iID = model.ContentID;
                BLL.Count.ClassFavorableNum.Instance.AddNum();
            }

            return id;
        }
        static public void Update(EbSite.Entity.Favorite model)
        {
            DbProviderUser.GetInstance().Favorite_Update(model);
        }

        /// <summary>
        /// 删除一条数据-内容
        /// </summary>
        static public void DeleteOfContent(int ContentID, string UserName)
        {
            //该表无主键信息，请自定义主键/条件字段
            DbProviderUser.GetInstance().Favorite_DeleteOFContent(ContentID, UserName);
        }
        /// <summary>
        /// 删除一条数据-分类
        /// </summary>
        static public void DeleteOfClass(int ClassID, string UserName)
        {
            //该表无主键信息，请自定义主键/条件字段
            DbProviderUser.GetInstance().Favorite_DeleteOFClass(ClassID, UserName);
        }
        static public List<EbSite.Entity.Favorite> GetListArr(int Top, string strWhere, string filedOrder)
        {
            return DbProviderUser.GetInstance().Favorite_GetListArr(Top, strWhere, filedOrder);
        }
        static public List<EbSite.Entity.Favorite> GetListArr(string strWhere)
        {
            return DbProviderUser.GetInstance().Favorite_GetListArr(0, strWhere, " id desc");
        }
        /// <summary>
        /// 获取某个专辑内容列表
        /// </summary>
        /// <param name="UserID"></param>
        /// <returns></returns>
        static public List<EbSite.Entity.Favorite> GetContentListAlbumID(int AlbumID)
        {
            return GetListArr(string.Format("ClassID={0}", AlbumID));

        }
        /// <summary>
        /// 获取某个用户收藏的内容ID列表 如果是分类应将FavType=1
        /// </summary>
        /// <param name="strUserName">当前用户名称</param>
        /// <returns></returns>
        static public string GetContentIDsByUserName(string strUserName)
        {
            List<EbSite.Entity.Favorite> lst = GetListArr(string.Format("UserName='{0}' and FavType=0", strUserName));
            StringBuilder sb = new StringBuilder();
            foreach (EbSite.Entity.Favorite md in lst)
            {
                sb.Append(md.ContentID);
                sb.Append(",");
            }
            if (sb.Length > 0) sb.Remove(sb.Length - 1, 1);
            return sb.ToString();
        }
      
        /// <summary>
        /// 获取某个用户收藏的分类ID列表
        /// </summary>
        /// <param name="strUserName">当前用户名称</param>
        /// <returns></returns>
        static public string GetClassIDsByUserName(string strUserName)
        {
            List<EbSite.Entity.Favorite> lst = GetListArr(string.Format("UserName='{0}' and FavType=1", strUserName));
            StringBuilder sb = new StringBuilder();
            foreach (EbSite.Entity.Favorite md in lst)
            {
                sb.Append(md.ContentID);
                sb.Append(",");
            }
            if (sb.Length > 0) sb.Remove(sb.Length - 1, 1);
            return sb.ToString();
        }
        /// <summary>
        /// 分页列表
        /// </summary>
        /// <param name="PageIndex"></param>
        /// <param name="PageSize"></param>
        /// <param name="strWhere"></param>
        /// <param name="Fileds"></param>
        /// <param name="oderby"></param>
        /// <param name="RecordCount"></param>
        /// <returns></returns>
        static public List<Entity.Favorite> GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby, out int RecordCount)
        {
            return DbProviderUser.GetInstance().Favorite_GetListPages(PageIndex, PageSize, strWhere, Fileds, oderby,
                                                                     out RecordCount);
        }
        static public List<Entity.Favorite> GetListPages(int PageIndex, int PageSize, string oderby, out int RecordCount,int iAlbumID)
        {
            return GetListPages(PageIndex, PageSize, oderby, out RecordCount, iAlbumID, 0);
        }

        public static List<Entity.Favorite> GetListPages(int PageIndex, int PageSize, string oderby, out int RecordCount,int iAlbumID,int UserID)
        {
            if (iAlbumID > 0)
            {
                return GetListPages(PageIndex, PageSize, string.Format("ClassID={0}", iAlbumID), "", oderby,
                                                                     out RecordCount);
            }
            else
            {
                return GetListPages(PageIndex, PageSize, string.Format("UserID={0}", UserID), "", oderby,out RecordCount);
            }
        }

        static public EbSite.Entity.Favorite GetModel(int ID)
        {
            return DbProviderUser.GetInstance().Favorite_GetModel(ID);
        }
        /// <summary>
        /// 批量删除,IDs用逗号分开ID
        /// </summary>
        /// <param name="IDs"></param>
        static public void DeleteInIDs(string IDs)
        {
            if (!string.IsNullOrEmpty(IDs))
             DbProviderUser.GetInstance().Favorite_DeleteInIDs(IDs);
        }
        

        #endregion  成员方法
    }
}

