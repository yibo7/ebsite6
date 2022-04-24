
using System.Collections.Generic;
using System.Text;
using EbSite.Base;
using EbSite.Data.Interface;
using EbSite.Data.User.Interface;

namespace EbSite.BLL
{
	/// <summary>
	/// 业务逻辑类Favorite 的摘要说明。
	/// </summary>
	public class FavoriteClass
	{
        //static private readonly DbProviderUser.GetInstance().Favorite_Favorite dal = new DbProviderUser.GetInstance().Favorite_Favorite();
		public FavoriteClass()
		{}
		#region  成员方法
        /// <summary>
        /// 增加一条数据
        /// </summary>
        static public void AddV(EbSite.Entity.FavoriteClass model)
        {

            DbProviderUser.GetInstance().FavoriteClass_Add(model);
            //向内容表或分类列表递增收藏的统计数据-采用缓存

        }
		/// <summary>
		/// 增加一条数据
		/// </summary>
        static public void Add(EbSite.Entity.FavoriteClass model)
		{

            model.UserName = Base.AppStartInit.UserName;
            model.UserNiName = AppStartInit.UserNiName;
            model.UserID = Base.AppStartInit.UserID;

            DbProviderUser.GetInstance().FavoriteClass_Add(model);


            //向内容表或分类列表递增收藏的统计数据-采用缓存
           
		}
        static public void Update(EbSite.Entity.FavoriteClass model)
        {
             DbProviderUser.GetInstance().FavoriteClass_Update(model);
        }

        static public void Delete(int ID, string UserName)
        {
            DbProviderUser.GetInstance().FavoriteClass_DeleteOFClass(ID, UserName);
        }
        static public List<EbSite.Entity.FavoriteClass> GetListArr(int Top, string strWhere, string filedOrder)
        {
            return DbProviderUser.GetInstance().FavoriteClass_GetListArr(Top, strWhere, filedOrder);
        }
        static public List<EbSite.Entity.FavoriteClass> GetListArr(string strWhere)
        {
            return DbProviderUser.GetInstance().FavoriteClass_GetListArr(0, strWhere, " id desc");
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
        static public List<Entity.FavoriteClass> GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby, out int RecordCount)
        {
            return DbProviderUser.GetInstance().FavoriteClass_GetListPages(PageIndex, PageSize, strWhere, Fileds, oderby,
                                                                     out RecordCount);
        }
        static public EbSite.Entity.FavoriteClass GetModel(int ID)
        {
            return DbProviderUser.GetInstance().FavoriteClass_GetModel(ID);
        }
        public static List<EbSite.Entity.FavoriteClass> GetListByUserID(int UserID)
        {
            return EbSite.BLL.FavoriteClass.GetListArr(0, "UserID=" + UserID + "", "id asc");

        }
	    #endregion  成员方法
	}
}

