
using System;
using System.Data;
using System.Collections.Generic;
using System.Data.Common;
using MySql.Data.MySqlClient;
using System.Text;
using System.Web.Security;
using EbSite.BLL.User;
using EbSite.Base.DataProfile;

namespace EbSite.Data.User.MySql
{
    public partial class DataProviderUser : Interface.IDataProviderUser
    {

        #region 读

        public BLL.User.UserOnline UserOnline_Select(int OnlineID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select ID,UserName,UserNiname,UserGroupName,AdminID,Invisible,ActionInfo,LastSearchTime,lastUpdateTime,WebUrl,Verifycode,Ip,UserID from {0}useronline ", sPre);
            strSql.Append(" where ID=?ID limit 1");
            MySqlParameter[] parameters = {
					new MySqlParameter("?ID", MySqlDbType.Int32,4)};
            parameters[0].Value = OnlineID;

            EbSite.BLL.User.UserOnline model = new BLL.User.UserOnline();
            using (IDataReader dataReader = DbHelperUser.Instance.ExecuteReader(CommandType.Text, strSql.ToString(), parameters))
            {
                if (dataReader.Read())
                {
                    model = UserOnline_ReaderBind(dataReader);
                }
            }
            return model;
        }
        /// <summary>
        /// 没有当前用户的资料，反回null
        /// </summary>
        /// <param name="UserName"></param>
        /// <param name="UserModelID"></param>
        /// <returns></returns>
        public BLL.User.UserOnline UserOnline_Select(string UserName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select ID,UserName,UserNiname,UserGroupName,AdminID,Invisible,ActionInfo,LastSearchTime,lastUpdateTime,WebUrl,Verifycode,Ip,UserID from {0}useronline ", sPre);
            strSql.Append(" where UserName=?UserName limit 1");
            MySqlParameter[] parameters = {
					new MySqlParameter("?UserName", MySqlDbType.VarChar,30)};
            parameters[0].Value = UserName;

            EbSite.BLL.User.UserOnline model = new BLL.User.UserOnline();
            using (IDataReader dataReader = DbHelperUser.Instance.ExecuteReader(CommandType.Text, strSql.ToString(), parameters))
            {
                if (dataReader.Read())
                {
                    model = UserOnline_ReaderBind(dataReader);
                }
            }
            return model;
        }

        /// <summary>
        /// 分页获取数据列表 -不在接口实现里
        /// </summary>
        private List<EbSite.BLL.User.UserOnline> UserOnline_GetListPages(int PageIndex, int PageSize, string strWhere, string oderby)
        {


            string sFields = "ID,UserName,UserNiname,UserGroupName,AdminID,Invisible,ActionInfo,LastSearchTime,lastUpdateTime,WebUrl,Verifycode,Ip,UserID";
            string strSql = SplitPages.GetSplitPagesMySql(DbHelperUser.Instance, "UserOnline", PageSize, PageIndex, sFields, "id", oderby, strWhere, sPre);



            List<EbSite.BLL.User.UserOnline> list = new List<EbSite.BLL.User.UserOnline>();

            using (IDataReader dataReader = DbHelperUser.Instance.ExecuteReader(CommandType.Text, strSql))
            {
                while (dataReader.Read())
                {
                    list.Add(UserOnline_ReaderBind(dataReader));
                }
            }
            return list;



        }
        /// <summary>
        /// 获取所有的线用户
        /// </summary>
        /// <param name="PageIndex"></param>
        /// <param name="PageSize"></param>
        /// <param name="oderby"></param>
        /// <returns></returns>
        public List<EbSite.BLL.User.UserOnline> UserOnline_GetAllUser(int PageIndex, int PageSize, string oderby)
        {

            return UserOnline_GetListPages(PageIndex, PageSize, "", " LastUpdateTime desc ");

        }
        public int UserOnline_GetCountRegUser()
        {
            string sWhere = string.Format(" UserName <> '游客'");
            return UserOnline_GetCount(sWhere);
        }
        public int UserOnline_GetCountGuestUser()
        {
            string sWhere = string.Format(" UserName = '游客'");
            return UserOnline_GetCount(sWhere);
        }
        public bool UserOnline_ExistsUser(int olineid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select count(1) from  {0}useronline ", sPre);
            strSql.Append(" where  id=?id");

            MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32,4)};

            parameters[0].Value = olineid;

            return DbHelperUser.Instance.Exists(strSql.ToString(), parameters);
        }
        public int UserOnline_ExistsUserID(int UserID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select id from  {0}useronline ", sPre);
            strSql.Append(" where  UserID=?UserID");

            MySqlParameter[] parameters = {
					new MySqlParameter("?UserID", MySqlDbType.Int32,4)};

            parameters[0].Value = UserID;

            object obj = DbHelperUser.Instance.ExecuteScalar(CommandType.Text, strSql.ToString(), parameters);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }

        //public int UserOnline_ExistsUser(string UserName)
        //{
        //    StringBuilder strSql = new StringBuilder();
        //    strSql.AppendFormat("select id from  {0}useronline ", sPre);
        //    strSql.Append(" where  UserName=?UserName limit 1");

        //    MySqlParameter[] parameters = {
        //            new MySqlParameter("?UserName", MySqlDbType.VarChar,50)};

        //    parameters[0].Value = UserName;

        //    object obj = DbHelperUser.Instance.ExecuteScalar(CommandType.Text, strSql.ToString(), parameters);
        //    if (obj == null)
        //    {
        //        return 0;
        //    }
        //    else
        //    {
        //        return Convert.ToInt32(obj);
        //    }
        //}
        /// <summary>
        /// 获取总记录条数
        /// </summary>
        /// <returns></returns>
        public int UserOnline_GetCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(*) ");
            strSql.AppendFormat(" from  {0}useronline  ", sPre);

            if (strWhere.Trim() != "")
            {

                strSql.AppendFormat(" where {0}", strWhere);
            }

            int iCount = -1;
            using (IDataReader dataReader = DbHelperUser.Instance.ExecuteReader(CommandType.Text, strSql.ToString()))
            {
                while (dataReader.Read())
                {
                    iCount = int.Parse(dataReader[0].ToString());
                }
            }
            return iCount;
        }

        /// <summary>
        /// 获取所有在线的注册用户
        /// </summary>
        /// <param name="PageIndex"></param>
        /// <param name="PageSize"></param>
        /// <param name="oderby"></param>
        /// <returns></returns>
        public List<EbSite.BLL.User.UserOnline> UserOnline_GetRegUser(int PageIndex, int PageSize, string oderby)
        {
            //TimeSpan ts = new TimeSpan(0, Membership.UserIsOnlineTimeWindow, 0);
            //DateTime dt = DateTime.Now.Subtract(ts);

            string sWhere = string.Format(" UserName <> '游客'");

            return UserOnline_GetListPages(PageIndex, PageSize, sWhere, " LastUpdateTime desc ");
        }
        /// <summary>
        /// 获取所有的线游客
        /// </summary>
        /// <param name="PageIndex"></param>
        /// <param name="PageSize"></param>
        /// <param name="oderby"></param>
        /// <returns></returns>
        public List<EbSite.BLL.User.UserOnline> UserOnline_GetGuestUser(int PageIndex, int PageSize, string oderby)
        {
            //TimeSpan ts = new TimeSpan(0, Membership.UserIsOnlineTimeWindow, 0);
            //DateTime dt = DateTime.Now.Subtract(ts);

            //string sWhere = string.Format("LastUpdateTime>'{0}' and UserName = '游客'", dt);

            string sWhere = string.Format(" UserName = '游客'");

            return UserOnline_GetListPages(PageIndex, PageSize, sWhere, " LastUpdateTime desc ");
        }

        /// <summary>
        /// 对象实体绑定数据
        /// </summary>
        private BLL.User.UserOnline UserOnline_ReaderBind(IDataReader dataReader)
        {
            BLL.User.UserOnline model = new UserOnline();

            if (dataReader["ID"].ToString() != "")
            {
                model.Id = int.Parse(dataReader["ID"].ToString());
            }
            model.UserName = dataReader["UserName"].ToString();
            model.UserNiname = dataReader["UserNiname"].ToString();
            model.UserGroupName = dataReader["UserGroupName"].ToString();
            if (dataReader["AdminID"].ToString() != "")
            {
                model.AdminID = int.Parse(dataReader["AdminID"].ToString());
            }
            if (dataReader["Invisible"].ToString() != "")
            {
                if ((dataReader["Invisible"].ToString() == "1") || (dataReader["Invisible"].ToString().ToLower() == "true"))
                {
                    model.Invisible = true;
                }
                else
                {
                    model.Invisible = false;
                }
            }
            model.ActionInfo = dataReader["ActionInfo"].ToString();
            if (dataReader["LastSearchTime"].ToString() != "")
            {
                model.LastSearchTime = DateTime.Parse(dataReader["LastSearchTime"].ToString());
            }
            if (dataReader["lastUpdateTime"].ToString() != "")
            {
                model.LastUpdateTime = DateTime.Parse(dataReader["lastUpdateTime"].ToString());
            }
            model.WebUrl = dataReader["WebUrl"].ToString();
            model.Verifycode = dataReader["Verifycode"].ToString();
            model.Ip = dataReader["Ip"].ToString();
            if (dataReader["UserID"].ToString() != "")
            {
                model.UserID = int.Parse(dataReader["UserID"].ToString());
            }
            model.MarkOld();

            return model;
        }

        #endregion 读

        #region 写

        public int UserOnline_Insert(BLL.User.UserOnline model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("insert into {0}useronline(", sPre);
            strSql.Append("UserName,UserNiname,UserGroupName,AdminID,Invisible,ActionInfo,LastSearchTime,LastUpdateTime,WebUrl,Verifycode,Ip,UserID)");
            strSql.Append(" values (");
            strSql.Append("?UserName,?UserNiname,?UserGroupName,?AdminID,?Invisible,?ActionInfo,?LastSearchTime,?LastUpdateTime,?WebUrl,?Verifycode,?Ip,?UserID)");
            strSql.Append(";SELECT @@session.identity");
            MySqlParameter[] parameters = {
					new MySqlParameter("?UserName", MySqlDbType.VarChar,30),
					new MySqlParameter("?UserNiname", MySqlDbType.VarChar,30),
					new MySqlParameter("?UserGroupName", MySqlDbType.VarChar,50),
					new MySqlParameter("?AdminID", MySqlDbType.Int32,4),
					new MySqlParameter("?Invisible", MySqlDbType.Bit,1),
					new MySqlParameter("?ActionInfo", MySqlDbType.VarChar,80),
					new MySqlParameter("?LastSearchTime", MySqlDbType.Datetime),
					new MySqlParameter("?LastUpdateTime", MySqlDbType.Datetime),
					new MySqlParameter("?WebUrl", MySqlDbType.VarChar,50),
					new MySqlParameter("?Verifycode", MySqlDbType.VarChar,10),
					new MySqlParameter("?Ip", MySqlDbType.VarChar,15),
					new MySqlParameter("?UserID", MySqlDbType.Int32,4)};
            parameters[0].Value = model.UserName;
            parameters[1].Value = model.UserNiname;
            parameters[2].Value = model.UserGroupName;
            parameters[3].Value = model.AdminID;
            parameters[4].Value = model.Invisible;
            parameters[5].Value = model.ActionInfo;
            parameters[6].Value = model.LastSearchTime;
            parameters[7].Value = model.LastUpdateTime;
            parameters[8].Value = model.WebUrl;
            parameters[9].Value = model.Verifycode;
            parameters[10].Value = model.Ip;
            parameters[11].Value = model.UserID;
            object obj = DbHelperUserWrite.Instance.ExecuteScalar(CommandType.Text, strSql.ToString(), parameters);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }

        }
        public void UserOnline_Update(BLL.User.UserOnline model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("update {0}useronline set ", sPre);
            strSql.Append("UserName=?UserName,");
            strSql.Append("UserNiname=?UserNiname,");
            strSql.Append("UserGroupName=?UserGroupName,");
            strSql.Append("AdminID=?AdminID,");
            strSql.Append("Invisible=?Invisible,");
            strSql.Append("ActionInfo=?ActionInfo,");
            strSql.Append("LastSearchTime=?LastSearchTime,");
            strSql.Append("LastUpdateTime=?LastUpdateTime,");
            strSql.Append("WebUrl=?WebUrl,");
            strSql.Append("Verifycode=?Verifycode,");
            strSql.Append("Ip=?Ip,");
            strSql.Append("UserID=?UserID");
            strSql.Append(" where ID=?ID ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?ID", MySqlDbType.Int32,4),
					new MySqlParameter("?UserName", MySqlDbType.VarChar,30),
					new MySqlParameter("?UserNiname", MySqlDbType.VarChar,30),
					new MySqlParameter("?UserGroupName", MySqlDbType.VarChar,50),
					new MySqlParameter("?AdminID", MySqlDbType.Int32,4),
					new MySqlParameter("?Invisible", MySqlDbType.Bit,1),
					new MySqlParameter("?ActionInfo", MySqlDbType.VarChar,80),
					new MySqlParameter("?LastSearchTime", MySqlDbType.Datetime),
					new MySqlParameter("?LastUpdateTime", MySqlDbType.Datetime),
					new MySqlParameter("?WebUrl", MySqlDbType.VarChar,50),
					new MySqlParameter("?Verifycode", MySqlDbType.VarChar,10),
					new MySqlParameter("?Ip", MySqlDbType.VarChar,15),
					new MySqlParameter("?UserID", MySqlDbType.Int32,4)};
            parameters[0].Value = model.Id;
            parameters[1].Value = model.UserName;
            parameters[2].Value = model.UserNiname;
            parameters[3].Value = model.UserGroupName;
            parameters[4].Value = model.AdminID;
            parameters[5].Value = model.Invisible;
            parameters[6].Value = model.ActionInfo;
            parameters[7].Value = model.LastSearchTime;
            parameters[8].Value = model.LastUpdateTime;
            parameters[9].Value = model.WebUrl;
            parameters[10].Value = model.Verifycode;
            parameters[11].Value = model.Ip;
            parameters[12].Value = model.UserID;

            DbHelperUserWrite.Instance.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }

        public void UserOnline_Delete(BLL.User.UserOnline Model)
        {
            UserOnline_Delete(Model.Id);
        }

        public void UserOnline_Delete(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("delete from {0}useronline ", sPre);
            strSql.Append(" where ID=?ID ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?ID", MySqlDbType.Int32,4)};
            parameters[0].Value = id;

            DbHelperUserWrite.Instance.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }
        /// <summary>
        /// 执行一次过期用户清理工作
        /// </summary>
        public void DeleteExpiredOnlineUsers(TimeSpan ts)
        {
            //TimeSpan ts = new TimeSpan(0, Membership.UserIsOnlineTimeWindow, 0);
            //TimeSpan ts = BLL.User.UserOnline.GetOnlineTimeSpan;
            DateTime dt = DateTime.Now.Subtract(ts);
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("delete from {0}useronline ", sPre);
            strSql.Append(" where LastUpdateTime<?LastUpdateTime ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?LastUpdateTime", MySqlDbType.DateTime)};
            parameters[0].Value = dt;

            DbHelperUserWrite.Instance.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }
        /// <summary>
        /// 复位在线表，主要考虑到在线ID的不断增加，过多时需要复位一下 自动动ID大于2147483000
        /// </summary>
        /// <returns></returns>
        public int CreateOnlineTable()
        {
            try
            {
                return DbHelperUserWrite.Instance.ExecuteNonQuery(CommandType.Text, string.Format("TRUNCATE TABLE [{0}useronline]", sPre));
            }
            catch
            {
                return -1;
            }
        }

        #endregion 写

    }
}
