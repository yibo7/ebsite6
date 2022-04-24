using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using EbSite.Data.Interface;

namespace EbSite.BLL
{
	/// <summary>
	/// 业务逻辑类EB_UserNews 的摘要说明。
	/// </summary>
	static public class UserNews
	{
		static  UserNews()
		{}
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		static public int GetMaxId()
		{
			return DbProviderCms.GetInstance().UserNews_GetMaxId();
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		static public bool Exists(int ID)
		{
            return DbProviderCms.GetInstance().UserNews_Exists(ID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		static public int  Add(string UserName,string NewsInfo)
		{
            Entity.UserNews model = new Entity.UserNews();

		    model.UserName = UserName;
            model.NewsInfo = NewsInfo;
		    model.AddDateTime = DateTime.Now;
            return DbProviderCms.GetInstance().UserNews_Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		static public void Update(Entity.UserNews model)
		{
            DbProviderCms.GetInstance().UserNews_Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		static public void Delete(int ID)
		{

            DbProviderCms.GetInstance().UserNews_Delete(ID);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		static public Entity.UserNews GetModel(int ID)
		{

            return DbProviderCms.GetInstance().UserNews_GetModel(ID);
		}
        /// <summary>
        /// 获取某个好友的动态
        /// </summary>
        /// <param name="UserName"></param>
        /// <returns></returns>
        static public List<Entity.UserNews> GetList_ByUser(string UserName,int top)
        {
            return DbProviderCms.GetInstance().UserNews_GetList(top, string.Format("UserName='{0}'", UserName), "");
        }

	    /// <summary>
        /// 获得某个用户的好友动态信息
        /// </summary>
        static public List<Entity.UserNews> GetList_FriendNews(int UserID,int top)
        {
            StringBuilder  sbWhere = new StringBuilder();

            List<BLL.FriendList> lst = BLL.FriendList.GetList_All(UserID);

            foreach (BLL.FriendList friendList in lst)
            {
                //if (Equals(friendList.UserName, UserName))
                //{
                //    sbWhere.AppendFormat(" UserName='{0}'", friendList.FriendName);
                //}
                //else
                //{
                //    sbWhere.AppendFormat(" UserName='{0}'", friendList.UserName);
                //}

                sbWhere.AppendFormat(" UserName='{0}'", friendList.FriendName);

                sbWhere.Append(" or ");
            }

            if (sbWhere.Length > 1) sbWhere.Remove(sbWhere.Length - 4, 4);

            return DbProviderCms.GetInstance().UserNews_GetList(top, sbWhere.ToString(), "");
        }
		
		/// <summary>
		/// 获得前几行数据
		/// </summary>
        static public List<Entity.UserNews> GetList(int Top, string strWhere, string filedOrder)
		{
            return DbProviderCms.GetInstance().UserNews_GetList(Top, strWhere, filedOrder);
		}
		
		#endregion  成员方法
	}
}

