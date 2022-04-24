
using System;
using System.Data;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text;
using EbSite.BLL.User;
using EbSite.Data.Profile;

namespace EbSite.Data.User.SqlServerDiscuz
{
    public partial class DataProviderUser : Interface.IDataProviderUser
    {
        public BLL.User.UserCustomField UserCustomField_SelectUserCustomField(string UserName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select  top 1 uid,UserName,Credits,joindate,nickname,sigstatus,lastactivity from {0}users ", sPre);
            strSql.Append(" where UserName=@UserName ");
            SqlParameter[] parameters = {
					new SqlParameter("@UserName", SqlDbType.NVarChar,50)};
            parameters[0].Value = UserName;

            EbSite.BLL.User.UserCustomField model = new BLL.User.UserCustomField();
            using (IDataReader dataReader = DbHelperUser.Instance.ExecuteReader(CommandType.Text,strSql.ToString(), parameters))
            {
                if (dataReader.Read())
                {
                    model = UserCustomField_ReaderBind(dataReader);
                }
            }
            return model;
        }
        public BLL.User.UserCustomField UserCustomField_SelectUserCustomField(int uid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select  top 1 uid,UserName,Credits,joindate,nickname,sigstatus,lastactivity from {0}users ", sPre);
            strSql.Append(" where uid=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = uid;

            EbSite.BLL.User.UserCustomField model = new BLL.User.UserCustomField();
            using (IDataReader dataReader = DbHelperUser.Instance.ExecuteReader(CommandType.Text, strSql.ToString(), parameters))
            {
                if (dataReader.Read())
                {
                    model = UserCustomField_ReaderBind(dataReader);
                }
            }
            return model;
        }
        /// <summary>
        /// 由于 dnt论坛只用一个用户表，只要获取当前用户ID，返回就行
        /// </summary>
        /// <param name="model"></param>
        public int UserCustomField_InsertUserCustomField(BLL.User.UserCustomField model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select  top 1 uid from {0}users ", sPre);
            strSql.Append(" where UserName=@UserName ");
            SqlParameter[] parameters = {
					new SqlParameter("@UserName", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.UserName;

            object obj = DbHelperUser.Instance.ExecuteScalar(CommandType.Text, strSql.ToString(), parameters);

            if (!Equals(obj, null))
            {
                return Convert.ToInt32(obj);
            }
            else
            {
                return -1;
            }

            //UserCustomField_UpdateUserCustomField(model);

            //StringBuilder strSql = new StringBuilder();
            //strSql.AppendFormat("insert into {0}users(", sPre);
            //strSql.Append("UserName,Credits,joindate,nickname,sigstatus,lastactivity)");
            //strSql.Append(" values (");
            //strSql.Append("@UserName,@Credits,@joindate,@nickname,@sigstatus,@lastactivity)");
            //strSql.Append(";select @@IDENTITY");
            //SqlParameter[] parameters = {
            //        new SqlParameter("@UserName", SqlDbType.NVarChar,100),
            //        new SqlParameter("@Credits", SqlDbType.Int,4),
            //        new SqlParameter("@joindate", SqlDbType.DateTime),
            //        new SqlParameter("@nickname", SqlDbType.NChar,20),
            //        new SqlParameter("@sigstatus", SqlDbType.NVarChar,100),
            //        new SqlParameter("@lastactivity", SqlDbType.DateTime)};
            //parameters[0].Value = model.UserName;
            //parameters[1].Value = model.Credits;
            //parameters[2].Value = model.AddDateTime;
            //parameters[3].Value = model.NiName;
            //parameters[4].Value = model.Sign;
            //parameters[5].Value = model.LastActivityDate;
            
            //DbHelperUser.Instance.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }
        /// <summary>
        /// 更新一个用户的最后活动时间
        /// </summary>
        /// <param name="UserName"></param>
        public void UserCustomField_UpdateLastActivityDate(string UserName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("update {0}users set ", sPre);
            strSql.Append("lastactivity=@lastactivity");
            strSql.Append(" where UserName=@UserName");
            SqlParameter[] parameters = {
					new SqlParameter("@UserName", SqlDbType.NVarChar,50),
                    new SqlParameter("@lastactivity", SqlDbType.DateTime) 
                                        };
            parameters[0].Value = UserName;
            parameters[1].Value = DateTime.Now;
           
            DbHelperUser.Instance.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }
        public void UserCustomField_UpdateUserCustomField(BLL.User.UserCustomField model)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("update {0}users set ",sPre);
            strSql.Append("Credits=@Credits,");
            strSql.Append("nickname=@nickname,");
            strSql.Append("joindate=@joindate,");
            strSql.Append("sigstatus=@sigstatus,");
            strSql.Append("lastactivity=@lastactivity");
            strSql.Append(" where UserName=@UserName and uid=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
                    new SqlParameter("@UserName", SqlDbType.NVarChar,50),
					new SqlParameter("@Credits", SqlDbType.Int,4),
					new SqlParameter("@nickname", SqlDbType.NVarChar,20),
					new SqlParameter("@joindate", SqlDbType.DateTime),
					new SqlParameter("@sigstatus", SqlDbType.NVarChar,100),
					new SqlParameter("@lastactivity", SqlDbType.DateTime)};
            parameters[0].Value = model.Id;
            parameters[1].Value = model.UserName;
            parameters[2].Value = model.Credits;
            parameters[3].Value = model.NiName;
            parameters[4].Value = model.AddDateTime;
            parameters[5].Value = model.Sign;
            parameters[6].Value = model.LastActivityDate;

            DbHelperUser.Instance.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }
        /// <summary>
        /// 更新昵称
        /// </summary>
        /// <param name="UserName"></param>
        /// <param name="NiName"></param>
        public void UserCustomField_UpdateNiName(BLL.User.UserCustomField model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("update {0}users set ", sPre);
            strSql.Append("nickname=@nickname");
            strSql.Append(" where UserName=@UserName ");
            SqlParameter[] parameters = {
					new SqlParameter("@UserName", SqlDbType.NVarChar,100),
					new SqlParameter("@nickname", SqlDbType.NVarChar,20)};
            parameters[0].Value = model.UserName;
            parameters[1].Value = model.NiName;

            DbHelperUser.Instance.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }
        /// <summary>
        /// 更新签名
        /// </summary>
        /// <param name="UserName"></param>
        /// <param name="Sign"></param>
        public void UserCustomField_UpdateSign(BLL.User.UserCustomField model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("update {0}userfields set ", sPre);
            strSql.Append("signature=@signature");
            strSql.Append(" where uid=@uid ");
            SqlParameter[] parameters = {
					new SqlParameter("@uid", SqlDbType.Int,4),
					new SqlParameter("@signature", SqlDbType.NVarChar,20)};
            parameters[0].Value = model.Id;
            parameters[1].Value = model.Sign;

            DbHelperUser.Instance.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }
        /// <summary>
        /// 更新积分
        /// </summary>
        /// <param name="UserName"></param>
        /// <param name="Credits"></param>
        public void UserCustomField_UpdateCredits(BLL.User.UserCustomField model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("update {0}users set ", sPre);
            strSql.Append("Credits=@Credits");
            strSql.Append(" where UserName=@UserName ");
            SqlParameter[] parameters = {
					new SqlParameter("@UserName", SqlDbType.NVarChar,100),
					new SqlParameter("@Credits", SqlDbType.Int,4)};
            parameters[0].Value = model.UserName;
            parameters[1].Value = model.Credits;
        }

        public bool UserCustomField_ExistsUser(string UserName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select count(1) from  {0}users ", sPre);
            strSql.Append(" where  UserName=@UserName");

            SqlParameter[] parameters = {
					new SqlParameter("@UserName", SqlDbType.NVarChar,50)};

            parameters[0].Value = UserName;

            return DbHelperUser.Instance.Exists(strSql.ToString(), parameters);
        }

   
        public void UserCustomField_DeleteUserCustomField(BLL.User.UserCustomField Model)
        {
            
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("delete {0}users ", sPre);
            strSql.Append(" where UserName=@UserName ");
            SqlParameter[] parameters = {
                    new SqlParameter("@UserName", SqlDbType.NVarChar,50)
                    };
            parameters[0].Value = Model.UserName;
            DbHelperUser.Instance.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }
        /// <summary>
        /// 获取总记录条数
        /// </summary>
        /// <returns></returns>
        public int UserCustomField_GetCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(*) ");
            strSql.AppendFormat(" from  {0}users  ", sPre);

            if (strWhere.Trim() != "")
            {

                strSql.AppendFormat(" where {0}" , strWhere);
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
        /// 分页获取数据列表 -不在接口实现里
        /// </summary>
        private List<EbSite.BLL.User.UserCustomField> GetListPages(int PageIndex, int PageSize, string strWhere, string oderby, int IsAuditing)
        {
            //int RecordCount = 0;
            //string sFields = "uid, UserName,Credits,joindate,nickname,sigstatus,lastactivity";
            //List<EbSite.BLL.User.UserCustomField> list = new List<EbSite.BLL.User.UserCustomField>();
            //using (IDataReader dataReader = SplitPages.GetListPages_SP("users", PageSize, PageIndex, sFields, "id", oderby, strWhere, out RecordCount, sPre))
            //{
            //    while (dataReader.Read())
            //    {
            //        list.Add(UserCustomField_ReaderBind(dataReader));
            //    }
            //}
            //return list;



            string sIsAuditing = string.Empty;

            if (IsAuditing > -1)
            {
                sIsAuditing = string.Format(" IsAuditing={0} ", IsAuditing);
            }



            if (string.IsNullOrEmpty(strWhere))
            {
                strWhere = sIsAuditing;
            }
            else
            {
                strWhere = string.Concat(sIsAuditing, " and ", strWhere);
            }

            string sFields = "uid, UserName,Credits,joindate,nickname,sigstatus,lastactivity";
            string strSql = SplitPages.GetSplitPagesSql("users", PageSize, PageIndex, sFields, "uid", oderby, strWhere, sPre);


            List<EbSite.BLL.User.UserCustomField> list = new List<EbSite.BLL.User.UserCustomField>();

            using (IDataReader dataReader = DbHelperUser.Instance.ExecuteReader(CommandType.Text, strSql))
            {
                while (dataReader.Read())
                {
                    list.Add(UserCustomField_ReaderBind(dataReader));
                }
            }
            return list;

        }
      
        /// <summary>
        /// 分页获取数据列表 只适用 sql 2005
        /// </summary>
        public List<EbSite.BLL.User.UserCustomField> UserCustomField_GetListPages(int PageIndex, int PageSize, string strWhere, string oderby, bool IsAuditing)
        {
            if (IsAuditing)
            {
                return GetListPages(PageIndex, PageSize, strWhere, oderby, 1);
            }
            else
            {
                return GetListPages(PageIndex, PageSize, strWhere, oderby, 0);
            }
            

        }
        /// <summary>
        /// 分页获取数据列表 只适用 sql 2005
        /// </summary>
        public List<EbSite.BLL.User.UserCustomField> UserCustomField_GetListPages(int PageIndex, int PageSize, string strWhere, string oderby)
        {

            return GetListPages(PageIndex, PageSize, strWhere, oderby, -1);
        }


        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public List<BLL.User.UserCustomField> UserCustomField_GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" * ");
            strSql.AppendFormat(" FROM {0}users ", sPre);
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            if (!string.IsNullOrEmpty(filedOrder))
                strSql.Append(" order by " + filedOrder);

            List<BLL.User.UserCustomField> list = new List<BLL.User.UserCustomField>();

            using (IDataReader dataReader = DbHelperUser.Instance.ExecuteReader(CommandType.Text, strSql.ToString()))
            {
                while (dataReader.Read())
                {
                    list.Add(UserCustomField_ReaderBind(dataReader));
                }
            }
            return list;
        }
        /// <summary>
        /// 搜索用户
        /// </summary>
        /// <param name="PageIndex"></param>
        /// <param name="PageSize"></param>
        /// <param name="Key"></param>
        /// <returns></returns>
        public List<UserCustomField> UserCustomField_SearhUserByName(int PageIndex, int PageSize, string Key)
        {
            return UserCustomField_GetListPages(PageIndex, PageSize, string.Format("UserName like '%{0}%' ", Key), " uid desc ");
        }
        /// <summary>
        /// 统计搜索用户个数
        /// </summary>
        /// <param name="Key"></param>
        /// <returns></returns>
        public int UserCustomField_CountUserByName(string Key)
        {
            return UserCustomField_GetCount(string.Format("UserName like '%{0}%'", Key));
        }
        /// <summary>
        /// 获取最新用户
        /// </summary>
        /// <param name="top"></param>
        /// <returns></returns>
        public List<UserCustomField> UserCustomField_GetListOfNews(int top)
        {
            return UserCustomField_GetList(top, "", " uid desc ");
        }
        /// <summary>
        /// 获取用户头像
        /// </summary>
        /// <param name="UserID"></param>
        /// <param name="iSize">1大,2中，3小</param>
        /// <returns></returns>
        public  string UserCustomField_GetAvatarFileName(int UserID, int iSize)
        {
            string size = "";
            if (iSize == 1)
            {
                size = "large";
            }
            else if (iSize == 2)
            {
                size = "medium";
            }
            else
            {
                size = "small";
            }
            return string.Format("{0}/tools/avatar.aspx?uid={1}&size={2}", Configs.ConformConfig.ConfigsControl.Instance.WebUrl, UserID, size);
        }
         /// <summary>
        /// 对象实体绑定数据
        /// </summary>
        public BLL.User.UserCustomField UserCustomField_ReaderBind(IDataReader dataReader)
         {
             EbSite.BLL.User.UserCustomField model = new BLL.User.UserCustomField();
             model.UserName = dataReader["UserName"].ToString();
            
             if (dataReader["Credits"].ToString() != "")
             {
                 model.Credits = int.Parse(dataReader["Credits"].ToString());
             }
             
             if (dataReader["uid"].ToString() != "")
             {
                 model.Id = int.Parse(dataReader["uid"].ToString());
             }
             model.NiName = dataReader["nickname"].ToString();
             if (dataReader["joindate"].ToString() != "")
             {
                 model.AddDateTime = DateTime.Parse(dataReader["joindate"].ToString());
             }
             if (dataReader["lastactivity"].ToString() != "")
             {
                 model.LastActivityDate = DateTime.Parse(dataReader["lastactivity"].ToString());
             }
             
            //dnt的签名放在别一个表，所以要另外获取
            //model.Sign = dataReader["sigstatus"].ToString();

             model.Sign = GetSign(model.Id);
            
            model.MarkOld();
             return model;
         }
        private string GetSign(int uid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select  top 1 signature from {0}userfields ", sPre);
            strSql.Append(" where uid=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = uid;

            object ob = DbHelperUser.Instance.ExecuteScalar(CommandType.Text, strSql.ToString(), parameters);

            if(!Equals(ob,null))
            {
                return ob.ToString();
            }
            else
            {
                return string.Empty;
            }
            
        }
        public int UserCustomField_GetUserIDByName(string UserName)
       {
           string sql = string.Format("SELECT uid FROM {0}Users WHERE UserName = @user", sPre);
           SqlParameter[] parameters = {
                new SqlParameter("@user", SqlDbType.NVarChar,100)};
           parameters[0].Value = UserName;
           object ouid = DbHelperUser.Instance.ExecuteScalar(CommandType.Text, sql, parameters);

            if(!Equals(ouid,null))
            {
                return (int) ouid;
            }
            return -1;
       }

    }
}
