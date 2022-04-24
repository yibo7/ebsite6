using System;
using System.Data;
using System.Collections.Generic;
using System.Web;
using Amib.Threading;
using EbSite.Base;
using EbSite.Base.EntityAPI;
using EbSite.Data.Interface;

namespace EbSite.BLL
{
	/// <summary>
	/// 业务逻辑类EB_RecentVisitors 的摘要说明。
	/// </summary>
	static public class RecentVisitors
	{
		static  RecentVisitors()
		{}
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		static public int GetMaxId()
		{
            return DbProviderCms.GetInstance().RecentVisitors_GetMaxId();
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		static public bool Exists(int ID)
		{
            return DbProviderCms.GetInstance().RecentVisitors_Exists(ID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		static public int  Add(Entity.RecentVisitors model)
		{
            return DbProviderCms.GetInstance().RecentVisitors_Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		static public void Update(Entity.RecentVisitors model)
		{
            DbProviderCms.GetInstance().RecentVisitors_Update(model);
		}
        /// <summary>
        /// 来访登记
        /// </summary>
        /// <param name="VisitorUserName"></param>
        static public void UpdateVisitors(int VisitorUserID)
        {
            if (AppStartInit.UserID > 0 && VisitorUserID != AppStartInit.UserID)
            {
                ShortUserInfo su = new ShortUserInfo(AppStartInit.UserID, AppStartInit.UserName, AppStartInit.UserNiName, VisitorUserID, AppStartInit.UserPass);
                IWorkItemResult wir = ThreadPoolManager.Instance.QueueWorkItem(new WorkItemCallback(UpdateVisitor), su);
            }
           
            

        }

	    private static object UpdateVisitor(object obsu)
	    {
	        ShortUserInfo mdSu = obsu as ShortUserInfo;
            int VisitorUserID = mdSu.GroupID;//将GroupID当成来访ID使用

            if (BLL.User.MembershipUserEb.Instance.ExistsUserID(VisitorUserID))
            {

                //只有当当前访问者已经登录，才能更新当前用户为访问对像的来访者,应该另开线程,这样不占用当前线程

                Entity.RecentVisitors md = new Entity.RecentVisitors();
                md.UserID = VisitorUserID;
                //md.UserName = VisitorUserName;
                md.VisitorName = mdSu.UserName;
                md.VisitorID = mdSu.UserID;
                md.VisitorNiName = mdSu.UserNiName;
                md.AddDateTime = DateTime.Now;
                md.LastDateTimeInt = Core.SqlDateTimeInt.GetSecond();
                UpdateVisitors(md);
                return true;

            }

            return false;
	    }

	    static public void UpdateVisitors(Entity.RecentVisitors model)
        {
            if (RecentVisitors_Exists(model)) //如果已经存在，只要更新最后访问日期就可以了
            {
                DbProviderCms.GetInstance().RecentVisitors_Update(model);
            }
            else //不存在的话新加入一条记录
            {
                Add(model);
            }
            
        }
        static public bool RecentVisitors_Exists(Entity.RecentVisitors model)
        {
            return DbProviderCms.GetInstance().RecentVisitors_Exists(model);
        }

	    /// <summary>
		/// 删除一条数据
		/// </summary>
		static public void Delete(int ID)
		{

            DbProviderCms.GetInstance().RecentVisitors_Delete(ID);
		}

        ///// <summary>
        ///// 获取某个用户下的最新来访者
        ///// </summary>
        ///// <param name="Top"></param>
        ///// <param name="UserName"></param>
        ///// <returns></returns>
        //static public List<Entity.RecentVisitors> GetListOfNews(int Top,string UserName)
        //{
        //    return DbProviderCms.GetInstance().RecentVisitors_GetList(Top, string.Format(" UserName='{0}'", UserName), " id desc");
        //}
        static public List<Entity.RecentVisitors> GetListOfNews(int Top, int UserID)
        {
            return DbProviderCms.GetInstance().RecentVisitors_GetList(Top, string.Format(" UserID={0}", UserID), " LastDateTimeInt desc");
        }
		#endregion  成员方法
	}
}

