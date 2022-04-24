using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Configuration.Provider;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text;
using System.Web.Security;
using EbSite.BLL.User;
using EbSite.Core.Strings;
using EbSite.Base.DataProfile;
using EbSite.Data.User.Interface;
using EbSite.Entity;

namespace EbSite.Data.User.SqlServer
{
    /// <summary>
    /// Generic Db Membership Provider
    /// </summary>
    public class DbMembershipProvider : MembershipProviderEb
    {

        /// <summary>
        /// Add new user to database
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="email"></param>
        /// <param name="passwordQuestion"></param>
        /// <param name="passwordAnswer"></param>
        /// <param name="isApproved"></param>
        /// <param name="providerUserKey"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public override MembershipUser CreateUser(string username, string password, string email,
                                                  string passwordQuestion, string passwordAnswer, bool isApproved,
                                                  object providerUserKey, out MembershipCreateStatus status)
        {


            MembershipUser user;

            MembershipUser mu = GetUser(username, false);

            if (!Equals(mu, null))
            {
                status = MembershipCreateStatus.InvalidUserName;
                return null;
            }

            string HavedUserName = GetUserNameByEmail(email);
            if (!string.IsNullOrEmpty(HavedUserName))
            {
                status = MembershipCreateStatus.InvalidEmail;
                return null;
            }

            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("insert into {0}Users(", tablePrefix);
            strSql.Append("UserName,Password,emailAddress,IsApproved,IsLockedOut,CreateDate,LastLoginDate,LastPasswordChangedDate,LastLockoutDate,FailedPasswordAttemptCount,LastActivityDate)");
            strSql.Append(" values (");
            strSql.Append("@UserName,@Password,@emailAddress,@IsApproved,@IsLockedOut,@CreateDate,@LastLoginDate,@LastPasswordChangedDate,@LastLockoutDate,@FailedPasswordAttemptCount,@LastActivityDate)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@UserName", SqlDbType.NVarChar,100),
					new SqlParameter("@Password", SqlDbType.NVarChar,255),
					new SqlParameter("@emailAddress", SqlDbType.NVarChar,100),
					new SqlParameter("@IsApproved", SqlDbType.Bit,1),
					new SqlParameter("@IsLockedOut", SqlDbType.Bit,1),
					new SqlParameter("@CreateDate", SqlDbType.DateTime),
					new SqlParameter("@LastLoginDate", SqlDbType.DateTime),
					new SqlParameter("@LastPasswordChangedDate", SqlDbType.DateTime),
					new SqlParameter("@LastLockoutDate", SqlDbType.DateTime),
					new SqlParameter("@FailedPasswordAttemptCount", SqlDbType.Int,4),
					new SqlParameter("@LastActivityDate", SqlDbType.DateTime)};
            parameters[0].Value = username;
            parameters[1].Value = UserIdentity.PassWordEncode(password);
            

            parameters[2].Value = email;
            parameters[3].Value = isApproved;
            parameters[4].Value = false;//model.IsLockedOut;
            parameters[5].Value = DateTime.Now;//model.CreateDate;
            parameters[6].Value = DateTime.Now;// model.LastLoginDate;
            parameters[7].Value = DateTime.Now;// model.LastPasswordChangedDate;
            parameters[8].Value = DateTime.Now;// model.LastLockoutDate;
            parameters[9].Value =0;//model.FailedPasswordAttemptCount;
            parameters[10].Value = DateTime.Now;//model.LastActivityDate;

            int UserID = 0;
            object obj = DbHelperUser.Instance.ExecuteScalar(CommandType.Text,strSql.ToString(), parameters);
            if (!Equals(obj, null))
            {
                UserID = Convert.ToInt32(obj);
            }
            user = GetMembershipUser(username, email, DateTime.Now, isApproved, false, DateTime.Now, DateTime.Now, DateTime.Now, DateTime.Now);
            status = MembershipCreateStatus.Success;



            return user;

        }

        /// <summary>
        /// Not implemented
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="newPasswordQuestion"></param>
        /// <param name="newPasswordAnswer"></param>
        /// <returns></returns>
        public override bool ChangePasswordQuestionAndAnswer(string username, string password,
                                                             string newPasswordQuestion, string newPasswordAnswer)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Not implemented
        /// </summary>
        /// <param name="username"></param>
        /// <param name="answer"></param>
        /// <returns></returns>
        public override string GetPassword(string username, string answer)
        {
            if (string.IsNullOrEmpty(username))
                throw new ArgumentNullException("username");


            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select Password from {0}Users ", tablePrefix);
            strSql.Append(" where UserName=@UserName ");
            SqlParameter[] parameters = {
					new SqlParameter("@UserName", SqlDbType.NVarChar,100)};
            parameters[0].Value = username;

            object ob = DbHelperUser.Instance.ExecuteScalar(CommandType.Text, strSql.ToString(), parameters);
            if (!Equals(ob, null))
            {
                return ob.ToString();
            }
            else
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// Change the password if the old password matches what is stored
        /// </summary>
        /// <param name="username"></param>
        /// <param name="oldPassword"></param>
        /// <param name="newPassword"></param>
        /// <returns></returns>
        public override bool ChangePassword(string username, string oldPassword, string newPassword)
        {
            bool oldPasswordCorrect = false;
            bool success = false;
            //先验证有无此用户
            oldPasswordCorrect = IsHaveUser(username, oldPassword); //oldPassword 由外面加密好的密码

            if(oldPasswordCorrect)
            {
                StringBuilder strSql = new StringBuilder();
                strSql.AppendFormat("update {0}Users set ", tablePrefix);
                strSql.Append("Password=@Password");
                strSql.Append(" where UserName=@UserName ");
                SqlParameter[] parameters = {
					new SqlParameter("@Password", SqlDbType.NVarChar,255),
					new SqlParameter("@UserName", SqlDbType.NVarChar,100)};

                parameters[0].Value = UserIdentity.PassWordEncode(newPassword);

                parameters[1].Value = username;

                DbHelperUser.Instance.ExecuteNonQuery(CommandType.Text,strSql.ToString(), parameters);

                success = true;
            }
            

            return success;
        }

        /// <summary>
        /// Not implemented
        /// </summary>
        /// <param name="username"></param>
        /// <param name="answer"></param>
        /// <returns></returns>
        public override string ResetPassword(string username, string answer)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Update User Data (not password)
        /// </summary>
        /// <param name="user"></param>
        public override void UpdateUser(MembershipUser user)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("update {0}Users set ", tablePrefix);
            strSql.Append("UserName=@UserName,");
            strSql.Append("emailAddress=@emailAddress,");
            strSql.Append("IsApproved=@IsApproved,");
            strSql.Append("IsLockedOut=@IsLockedOut,");
            strSql.Append("LastLoginDate=@LastLoginDate,");
            strSql.Append("LastPasswordChangedDate=@LastPasswordChangedDate,");
            strSql.Append("LastLockoutDate=@LastLockoutDate,");
            strSql.Append("LastActivityDate=@LastActivityDate");
            strSql.Append(" where UserName=@UserName ");
            SqlParameter[] parameters = {
					new SqlParameter("@UserName", SqlDbType.NVarChar,100),
					new SqlParameter("@emailAddress", SqlDbType.NVarChar,100),
					new SqlParameter("@IsApproved", SqlDbType.Bit,1),
					new SqlParameter("@IsLockedOut", SqlDbType.Bit,1),
					new SqlParameter("@LastLoginDate", SqlDbType.DateTime),
					new SqlParameter("@LastPasswordChangedDate", SqlDbType.DateTime),
					new SqlParameter("@LastLockoutDate", SqlDbType.DateTime),
					new SqlParameter("@LastActivityDate", SqlDbType.DateTime)};
            parameters[0].Value = user.UserName;
            parameters[1].Value = user.Email;
            parameters[2].Value = user.IsApproved;
            parameters[3].Value = user.IsLockedOut;
            parameters[4].Value = user.LastLoginDate;
            parameters[5].Value = user.LastPasswordChangedDate;
            parameters[6].Value = user.LastLockoutDate;
            parameters[7].Value = user.LastActivityDate;
            
            DbHelperUser.Instance.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);

        }

        /// <summary>
        /// Check username and password
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password">注意，这里是密码密文,所以以无须再加密</param>
        /// <returns></returns>
        public override bool ValidateUser(string username, string password)
        {
            string sPass = UserIdentity.PassWordEncode(password);
            bool isok = IsHaveUser(username, sPass);
          
            if (isok)
            {
                BLL.User.UserIdentity.WriteUserIdentity(GetUserIDByUserName(username).ToString(), username, username, sPass, 1);

            }
            
            return isok;
        }
        override public bool IsHaveUser(string UserName, string UserPass)
        {
           
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select count(1) from {0}Users", tablePrefix);
            strSql.Append(" where username=@username and password=@password");
            SqlParameter[] parameters = {
					new SqlParameter("@username", SqlDbType.NVarChar,50),
                    new SqlParameter("@password", SqlDbType.NVarChar,255)
                                        };
            parameters[0].Value = UserName;
            parameters[1].Value = UserPass;
            bool isok = DbHelperUser.Instance.Exists(strSql.ToString(), parameters);
            return isok;
        }
        /// <summary>
        /// 如果用户已经锁定将解锁，反正锁定
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public override bool UnlockUser(string userName)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("update {0}Users set ", tablePrefix);
            strSql.Append("IsLockedOut=@IsLockedOut");
            strSql.Append(" where UserName=@UserName ");
            SqlParameter[] parameters = {
                    new SqlParameter("@UserName", SqlDbType.NVarChar,100),
                    new SqlParameter("@IsLockedOut", SqlDbType.Bit,1)};
            parameters[0].Value = userName;
            parameters[1].Value = false;

            DbHelperUser.Instance.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
           return true;
        }

        /// <summary>
        /// Get User by providerUserKey
        /// </summary>
        /// <param name="providerUserKey"></param>
        /// <param name="userIsOnline"></param>
        /// <returns></returns>
        public override MembershipUser GetUser(object providerUserKey, bool userIsOnline)
        {
            return GetUser(providerUserKey.ToString(), userIsOnline);
        }

        /// <summary>
        /// 摘要:从数据源获取指定成员资格用户的信息。更新用户（如果指定）的最近一次活动的日期/时间戳。

        /// </summary>
        /// <param name="username">要检索的用户名</param>
        /// <param name="userIsOnline">如果为 true，则更新指定用户的最近活动日期/时间戳。</param>
        /// <returns></returns>
        public override MembershipUser GetUser(string username, bool userIsOnline)
        {

            StringBuilder strSql=new StringBuilder();
            strSql.AppendFormat("select  top 1 UserID,UserName,Password,emailAddress,IsApproved,IsLockedOut,CreateDate,LastLoginDate,LastPasswordChangedDate,LastLockoutDate,FailedPasswordAttemptCount,LastActivityDate from {0}Users ", tablePrefix);
            strSql.Append(" where UserName=@UserName ");
			SqlParameter[] parameters = {
					new SqlParameter("@UserName", SqlDbType.NVarChar,50)};
            parameters[0].Value = username;

            MembershipUser model = null;
			
            using (IDataReader dataReader = DbHelperUser.Instance.ExecuteReader(CommandType.Text, strSql.ToString(), parameters))
            {
                if (dataReader.Read())
                {
                    model = ReaderBind(dataReader);
                }
            }
            //已经有专门的用户的线表来处理的线用户，这里不必更新用户当前活动时间
            if (userIsOnline)
            {
                
            }

            return model;

        }

        /// <summary>
        /// Retrieve UserName for given email
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public override string GetUserNameByEmail(string email)
        {
            if (email == null)
                throw new ArgumentNullException("email");


             StringBuilder strSql=new StringBuilder();
            strSql.AppendFormat("select UserName from {0}Users ", tablePrefix);
            strSql.Append(" where emailAddress=@emailAddress ");
			SqlParameter[] parameters = {
					new SqlParameter("@emailAddress", SqlDbType.NVarChar,100)};
            parameters[0].Value = email;

            object ob = DbHelperUser.Instance.ExecuteScalar(CommandType.Text, strSql.ToString(), parameters);
            if (!Equals(ob, null))
            {
                return ob.ToString();
            }
            else
            {
                return string.Empty;
            }


        }

        /// <summary>
        /// Delete user from database
        /// </summary>
        /// <param name="username"></param>
        /// <param name="deleteAllRelatedData"></param>
        /// <returns></returns>
        public override bool DeleteUser(string username, bool deleteAllRelatedData)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("delete from {0}Users ", tablePrefix);
            strSql.Append(" where username=@username ");
            SqlParameter[] parameters = {
					new SqlParameter("@username", SqlDbType.NVarChar,50)};
            parameters[0].Value = username;

             DbHelperUser.Instance.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters).ToString();

            return true;

        }

        /// <summary>
        /// Return all users in MembershipUserCollection
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="totalRecords"></param>
        /// <returns></returns>
        public override MembershipUserCollection GetAllUsers(int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();

        }

        /// <summary>
        /// Not implemented
        /// </summary>
        /// <returns></returns>
        public override int GetNumberOfUsersOnline()
        {
            throw new NotImplementedException();


        }

        /// <summary>
        /// Not implemented
        /// </summary>
        /// <param name="usernameToMatch"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="totalRecords"></param>
        /// <returns></returns>
        public override MembershipUserCollection FindUsersByName(string usernameToMatch, int pageIndex, int pageSize,
                                                                 out int totalRecords)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Not implemented
        /// </summary>
        /// <param name="emailToMatch"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="totalRecords"></param>
        /// <returns></returns>
        public override MembershipUserCollection FindUsersByEmail(string emailToMatch, int pageIndex, int pageSize,
                                                                  out int totalRecords)
        {
            throw new NotImplementedException();
        }

        

        

        #region 实现扩展方法

        override public int User_GetCount(string strWhere)
        {
            if (strWhere.Equals("d"))
            {
                strWhere = "datediff(d,CreateDate,getdate())=0";
            }
            else if (strWhere.Equals("w"))
            {
                strWhere = "datediff(ww,CreateDate,getdate())=0";
            }
            else if (strWhere.Equals("m"))
            {
                strWhere = "datediff(mm,CreateDate,getdate())=0";
            }
            else if (strWhere.Equals("q"))
            {
                strWhere = "datediff(q,CreateDate,getdate())=0";
            }
            else if (strWhere.Equals("y"))
            {
                strWhere = "datediff(yyyy,CreateDate,getdate())=0";
            }

            return base.User_GetCount(strWhere);
        }

        public override int GetUserIDByUserName(string sUserName)
        {
            string sql = string.Format("SELECT UserID FROM {0}Users WHERE UserName = @user", tablePrefix);
            SqlParameter[] parameters = {
                            new SqlParameter("@user", SqlDbType.NVarChar,100)};
            parameters[0].Value = sUserName;
            object ouid = DbHelperUser.Instance.ExecuteScalar(CommandType.Text, sql, parameters);

            if (!Equals(ouid, null))
            {
                return int.Parse(ouid.ToString());
            }
            return -1;
        }

        public override Base.EntityAPI.MembershipUserEb Users_GetEntity(string sUserName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select " + sFieldEB_Users + "  from {0}Users ", tablePrefix);
            strSql.Append(" where UserName=@UserName ");
            SqlParameter[] parameters = {
					new SqlParameter("@UserName", SqlDbType.NVarChar,20)};
            parameters[0].Value = sUserName;
            Base.EntityAPI.MembershipUserEb model = null;
            using (IDataReader dataReader = DbHelperUser.Instance.ExecuteReader(CommandType.Text, strSql.ToString(), parameters))
            {
                if (dataReader.Read())
                {
                    model = Users_ReaderBind(dataReader);
                }
            }
            return model;
        }
        override public List<EbSite.Base.EntityAPI.MembershipUserEb> GetLockedUsers(int PageIndex, int PageSize, out int totalRecords)
        {
            return GetListPages(PageIndex, PageSize, "IsLockedOut=1", "", -1, out totalRecords);
            
        }
        override public List<Base.EntityAPI.MembershipUserEb> GetListPages(int PageIndex, int PageSize, string strWhere, string oderby, int IsAuditing, out int totalRecords)
        {
            string sIsAuditing = string.Empty;

            if (IsAuditing > -1)
            {
                sIsAuditing = string.Format(" IsApproved={0} ", IsAuditing);
            }

            if (string.IsNullOrEmpty(oderby))
                oderby = "UserID";


            if (string.IsNullOrEmpty(strWhere))
            {
                strWhere = sIsAuditing;
            }
            else
            {
                if (!string.IsNullOrEmpty(sIsAuditing))
                    strWhere = string.Concat(sIsAuditing, " and ", strWhere);
            }

            List<Base.EntityAPI.MembershipUserEb> list = new List<Base.EntityAPI.MembershipUserEb>();

            using (IDataReader dataReader = SplitPages.GetListPages_SP("Users", PageSize, PageIndex, "", "UserID", oderby, strWhere, out totalRecords, tablePrefix))
            {
                while (dataReader.Read())
                {
                    list.Add(Users_ReaderBind(dataReader));
                }
            }
            return list;
        }
        public override void LockUser(string userName)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("update {0}Users set ", tablePrefix);
            strSql.Append("IsLockedOut=@IsLockedOut");
            strSql.Append(" where UserName=@UserName ");
            SqlParameter[] parameters = {
                    new SqlParameter("@UserName", SqlDbType.NVarChar,100),
                    new SqlParameter("@IsLockedOut", SqlDbType.Bit,1)};
            parameters[0].Value = userName;
            parameters[1].Value = true;

            DbHelperUser.Instance.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
           
        }


        /// <summary>
        /// 得到最大ID
        /// </summary>
        public override int Users_GetMaxId()
        {
            return DbHelperUser.Instance.GetMaxID("UserID", string.Format("{0}Users", tablePrefix));
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public override bool Users_Exists(int UserID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select count(1) from {0}Users", tablePrefix);
            strSql.Append(" where UserID=@UserID ");
            SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.Int,4)};
            parameters[0].Value = UserID;

            return DbHelperUser.Instance.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public override int Users_Add(Base.EntityAPI.MembershipUserEb model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("insert into {0}Users(", tablePrefix);
            strSql.Append("UserName,Password,emailAddress,IsApproved,IsLockedOut,CreateDate,LastLoginDate,LastPasswordChangedDate,LastLockoutDate,FailedPasswordAttemptCount,LastActivityDate,Credits,NiName,Sign,MobileNumber)");
            strSql.Append(" values (");
            strSql.Append("@UserName,@Password,@emailAddress,@IsApproved,@IsLockedOut,@CreateDate,@LastLoginDate,@LastPasswordChangedDate,@LastLockoutDate,@FailedPasswordAttemptCount,@LastActivityDate,@Credits,@NiName,@Sign,@MobileNumber)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@UserName", SqlDbType.NVarChar,100),
					new SqlParameter("@Password", SqlDbType.NVarChar,255),
					new SqlParameter("@emailAddress", SqlDbType.NVarChar,100),
					new SqlParameter("@IsApproved", SqlDbType.Bit,1),
					new SqlParameter("@IsLockedOut", SqlDbType.Bit,1),
					new SqlParameter("@CreateDate", SqlDbType.DateTime),
					new SqlParameter("@LastLoginDate", SqlDbType.DateTime),
					new SqlParameter("@LastPasswordChangedDate", SqlDbType.DateTime),
					new SqlParameter("@LastLockoutDate", SqlDbType.DateTime),
					new SqlParameter("@FailedPasswordAttemptCount", SqlDbType.Int,4),
					new SqlParameter("@LastActivityDate", SqlDbType.DateTime),
					new SqlParameter("@Credits", SqlDbType.Int,4),
					new SqlParameter("@NiName", SqlDbType.NVarChar,10),
					new SqlParameter("@Sign", SqlDbType.NVarChar,100),
					new SqlParameter("@MobileNumber", SqlDbType.NChar,20)};
            parameters[0].Value = model.UserName;
            parameters[1].Value = model.Password;
            parameters[2].Value = model.emailAddress;
            parameters[3].Value = model.IsApproved;
            parameters[4].Value = model.IsLockedOut;
            parameters[5].Value = model.CreateDate;
            parameters[6].Value = model.LastLoginDate;
            parameters[7].Value = model.LastPasswordChangedDate;
            parameters[8].Value = model.LastLockoutDate;
            parameters[9].Value = model.FailedPasswordAttemptCount;
            parameters[10].Value = model.LastActivityDate;
            parameters[11].Value = model.Credits;
            parameters[12].Value = model.NiName;
            parameters[13].Value = model.Sign;
            parameters[14].Value = model.MobileNumber;

            object obj = DbHelperUser.Instance.ExecuteScalar(CommandType.Text, strSql.ToString(), parameters);
            if (obj == null)
            {
                return 1;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public override void Users_Update(Base.EntityAPI.MembershipUserEb model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("update {0}Users set ", tablePrefix);
            strSql.Append("UserName=@UserName,");
            strSql.Append("Password=@Password,");
            strSql.Append("emailAddress=@emailAddress,");
            strSql.Append("IsApproved=@IsApproved,");
            strSql.Append("IsLockedOut=@IsLockedOut,");
            strSql.Append("CreateDate=@CreateDate,");
            strSql.Append("LastLoginDate=@LastLoginDate,");
            strSql.Append("LastPasswordChangedDate=@LastPasswordChangedDate,");
            strSql.Append("LastLockoutDate=@LastLockoutDate,");
            strSql.Append("FailedPasswordAttemptCount=@FailedPasswordAttemptCount,");
            strSql.Append("LastActivityDate=@LastActivityDate,");
            strSql.Append("Credits=@Credits,");
            strSql.Append("NiName=@NiName,");
            strSql.Append("Sign=@Sign,");
            strSql.Append("MobileNumber=@MobileNumber,");
            strSql.Append("UserLevel=@UserLevel");
            strSql.Append(" where UserID=@UserID ");
            SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.Int,4),
					new SqlParameter("@UserName", SqlDbType.NVarChar,100),
					new SqlParameter("@Password", SqlDbType.NVarChar,255),
					new SqlParameter("@emailAddress", SqlDbType.NVarChar,100),
					new SqlParameter("@IsApproved", SqlDbType.Bit,1),
					new SqlParameter("@IsLockedOut", SqlDbType.Bit,1),
					new SqlParameter("@CreateDate", SqlDbType.DateTime),
					new SqlParameter("@LastLoginDate", SqlDbType.DateTime),
					new SqlParameter("@LastPasswordChangedDate", SqlDbType.DateTime),
					new SqlParameter("@LastLockoutDate", SqlDbType.DateTime),
					new SqlParameter("@FailedPasswordAttemptCount", SqlDbType.Int,4),
					new SqlParameter("@LastActivityDate", SqlDbType.DateTime),
					new SqlParameter("@Credits", SqlDbType.Int,4),
					new SqlParameter("@NiName", SqlDbType.NVarChar,10),
					new SqlParameter("@Sign", SqlDbType.NVarChar,100),
					new SqlParameter("@MobileNumber", SqlDbType.NChar,20),
                                        new SqlParameter("@UserLevel", SqlDbType.Int,4)};
            parameters[0].Value = model.id;
            parameters[1].Value = model.UserName;
            parameters[2].Value = model.Password;
            parameters[3].Value = model.emailAddress;
            parameters[4].Value = model.IsApproved;
            parameters[5].Value = model.IsLockedOut;
            parameters[6].Value = model.CreateDate;
            parameters[7].Value = model.LastLoginDate;
            parameters[8].Value = model.LastPasswordChangedDate;
            parameters[9].Value = model.LastLockoutDate;
            parameters[10].Value = model.FailedPasswordAttemptCount;
            parameters[11].Value = model.LastActivityDate;
            parameters[12].Value = model.Credits;
            parameters[13].Value = model.NiName;
            parameters[14].Value = model.Sign;
            parameters[15].Value = model.MobileNumber;
            parameters[16].Value = model.UserLevel;

            DbHelperUser.Instance.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public override void Users_Delete(int UserID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("delete from {0}Users ", tablePrefix);
            strSql.Append(" where UserID=@UserID ");
            SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.Int,4)};
            parameters[0].Value = UserID;

            DbHelperUser.Instance.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public override void Users_Delete(string sUserName)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("delete from {0}Users ", tablePrefix);
            strSql.Append(" where UserName=@UserName ");
            SqlParameter[] parameters = {
					new SqlParameter("@UserName", SqlDbType.NVarChar,20)};
            parameters[0].Value = sUserName;

            DbHelperUser.Instance.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public override  Base.EntityAPI.MembershipUserEb Users_GetEntity(int UserID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select " + sFieldEB_Users + "  from {0}Users ", tablePrefix);
            strSql.Append(" where UserID=@UserID ");
            SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.Int,4)};
            parameters[0].Value = UserID;
            Base.EntityAPI.MembershipUserEb model = null;
            using (IDataReader dataReader = DbHelperUser.Instance.ExecuteReader(CommandType.Text, strSql.ToString(), parameters))
            {
                if (dataReader.Read())
                {
                    model = Users_ReaderBind(dataReader);
                }
            }
            return model;
        }
       


        /// <summary>
        /// 获得数据列表（比DataSet效率高，推荐使用）
        /// </summary>
        public override List<Base.EntityAPI.MembershipUserEb> Users_GetListArray(string strWhere)
        {
            return Users_GetListArray(0, strWhere, "");
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public override List<Base.EntityAPI.MembershipUserEb> Users_GetListArray(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(sFieldEB_Users);
            strSql.AppendFormat(" FROM {0}Users ", tablePrefix);
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            if (filedOrder.Trim() != "")
            {
                strSql.Append(" order by  " + filedOrder);
            }
            List<Base.EntityAPI.MembershipUserEb> list = new List<Base.EntityAPI.MembershipUserEb>();
            using (IDataReader dataReader = DbHelperUser.Instance.ExecuteReader(CommandType.Text, strSql.ToString()))
            {
                while (dataReader.Read())
                {
                    list.Add(Users_ReaderBind(dataReader));
                }
            }
            return list;
        }


        /// <summary>
        /// 获得分页数据
        /// </summary>
        public override List<Base.EntityAPI.MembershipUserEb> Users_GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby, out int RecordCount)
        {
            List<Base.EntityAPI.MembershipUserEb> list = new List<Base.EntityAPI.MembershipUserEb>();
            using (IDataReader dataReader = SplitPages.GetListPages_SP("Users", PageSize, PageIndex, Fileds, "UserID", oderby, strWhere, out RecordCount,tablePrefix))
            {
                while (dataReader.Read())
                {
                    list.Add(Users_ReaderBind(dataReader));
                }
            }
            return list;
        }


        public override List<Base.EntityAPI.MembershipUserEb> GetListPages(int PageIndex, int PageSize, string strWhere, string oderby, bool IsAuditing,
                                     out int totalRecords, int RoleID)
        {
            if(RoleID>0)
            {
                string sw = string.Format(" {1}UserRoles.UserID={1}Users.UserID and {1}UserRoles.RoleID={0}", RoleID, tablePrefix);

                if (string.IsNullOrEmpty(strWhere))
                {
                    strWhere = sw;
                }
                else
                {
                    strWhere = string.Concat(sw, " and ", strWhere);
                }
                string sTableNames = string.Format("{0}Users , {0}UserRoles ", tablePrefix);
                string strSql = SplitPages.GetSplitPagesSql(sTableNames, PageSize, PageIndex, "", string.Format("{0}Users.UserID", tablePrefix), oderby, strWhere, "");

                //throw new Exception(strSql);

                List<Base.EntityAPI.MembershipUserEb> list = new List<Base.EntityAPI.MembershipUserEb>();

                using (IDataReader dataReader = DbHelperUser.Instance.ExecuteReader(CommandType.Text, strSql.ToString()))
                {
                    while (dataReader.Read())
                    {
                        list.Add(Users_ReaderBind(dataReader));
                    }
                }

                string sCountSql = string.Format("select count(*)  from {0}  where {1} ", sTableNames, strWhere);

                object obCount = DbHelperUser.Instance.ExecuteScalar(CommandType.Text, sCountSql);
                totalRecords = 1;
                if (!Equals(obCount, null))
                {
                    totalRecords = int.Parse(obCount.ToString());
                }

                return list;



            }
            else
            {
                int iType = (IsAuditing)?1:0;

                return GetListPages(PageIndex, PageSize, strWhere, oderby, iType, out totalRecords);
            }
        }

        #endregion




        /// <summary>
        ///获取用户
        /// </summary>
        /// <param name="UserName">要检索的用户名</param>
        /// <param name="Pass">密码加密的</param>
        /// <returns></returns>
        public override Base.EntityAPI.MembershipUserEb GetUserByEmail(string emailAddress, string Pass)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select top 1 {0} from {1}Users ", sFieldEB_Users, tablePrefix);
            strSql.Append(" where emailAddress=@emailAddress and Password=@Password limit 1");
            SqlParameter[] parameters = {
					new SqlParameter("@emailAddress", SqlDbType.VarChar,50),
                    new SqlParameter("@Password", SqlDbType.VarChar,50)                      
                                          };
            parameters[0].Value = emailAddress;
            parameters[1].Value = Pass;
            Base.EntityAPI.MembershipUserEb model = null;

            using (IDataReader dataReader = DbHelperUser.Instance.ExecuteReader(CommandType.Text, strSql.ToString(), parameters))
            {
                if (dataReader.Read())
                {
                    model = Users_ReaderBind(dataReader);
                }
            }
            return model;

        }

        /// <summary>
        ///获取用户
        /// </summary>
        /// <param name="UserName">要检索的用户名</param>
        /// <param name="Pass">密码加密的</param>
        /// <returns></returns>
        public override Base.EntityAPI.MembershipUserEb GetUserByMobile(string Mobile, string Pass)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select top 1 {0} from {1}Users ", sFieldEB_Users, tablePrefix);
            strSql.Append(" where MobileNumber=@MobileNumber and Password=@Password ");
            SqlParameter[] parameters = {
					new SqlParameter("@MobileNumber", SqlDbType.VarChar,50),
                    new SqlParameter("@Password", SqlDbType.VarChar,50)                      
                                          };
            parameters[0].Value = Mobile;
            parameters[1].Value = Pass;
            Base.EntityAPI.MembershipUserEb model = null;

            using (IDataReader dataReader = DbHelperUser.Instance.ExecuteReader(CommandType.Text, strSql.ToString(), parameters))
            {
                if (dataReader.Read())
                {
                    model = Users_ReaderBind(dataReader);
                }
            }
            return model;

        }
        public override Base.EntityAPI.MembershipUserEb GetUserMobile(string sMobileNumber)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select top 1 {0} from {1}Users", sFieldEB_Users, tablePrefix);
            strSql.Append(" where MobileNumber=@MobileNumber ");
            SqlParameter[] parameters = {
					new SqlParameter("@MobileNumber", SqlDbType.VarChar,50)
                               
                                          };
            parameters[0].Value = sMobileNumber;
            Base.EntityAPI.MembershipUserEb model = null;
            using (IDataReader dataReader = DbHelperUser.Instance.ExecuteReader(CommandType.Text, strSql.ToString(), parameters))
            {
                if (dataReader.Read())
                {
                    model = Users_ReaderBind(dataReader);
                }
            }
            return model;
        }
    }
}
