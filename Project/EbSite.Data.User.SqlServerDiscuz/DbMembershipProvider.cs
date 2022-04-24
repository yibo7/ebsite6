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
using EbSite.Configs.SysConfigs;
using EbSite.Core;
using EbSite.Core.Strings;
using EbSite.Data.Profile;
using EbSite.Entity;

namespace EbSite.Data.User.SqlServerDiscuz
{
    /// <summary>
    /// Generic Db Membership Provider
    /// </summary>
    public class DbMembershipProvider : MembershipProvider
    {
        //private string connStringName;
        private string tablePrefix;
        //private string parmPrefix;
        private string applicationName;
        //private MembershipPasswordFormat passwordFormat;

        /// <summary>
        /// Initializes the provider,调用base.Initialze之前删除了参数，因为如果内置提供程序传送了它们不认识的
        /// 属性，它们会抛出异常
        /// </summary>
        /// <param name="name">Configuration name</param>
        /// <param name="config">Configuration settings</param>
        public override void Initialize(string name, NameValueCollection config)
        {
            if (config == null)
            {
                throw new ArgumentNullException("config");
            }

            if (String.IsNullOrEmpty(name))
            {
                name = "DbMembershipProvider";
            }

            if (Type.GetType("Mono.Runtime") != null)
            {
                // Mono dies with a "Unrecognized attribute: description" if a description is part of the config.
                if (!string.IsNullOrEmpty(config["description"]))
                {
                    config.Remove("description");
                }
            }
            else
            {
                if (string.IsNullOrEmpty(config["description"]))
                {
                    config.Remove("description");
                    config.Add("description", "Generic Database Membership Provider");
                }
            }

            base.Initialize(name, config);

            // Connection String
            //if (config["connectionStringName"] == null)
            //{
            //    config["connectionStringName"] = "EbSiteUserDB";
            //}
            //connStringName = config["connectionStringName"];
            //config.Remove("connectionStringName");
            //connStringName = EbSite.Configs.BaseCinfigs.ConfigsControl.Instance.ConnectionStringSysUser;
            // Table Prefix
            if (config["tablePrefix"] == null)
            {
                config["tablePrefix"] = EbSite.Configs.BaseCinfigs.ConfigsControl.Instance.TablePrefixUser;
            }
            tablePrefix = config["tablePrefix"];
            config.Remove("tablePrefix");

            // Parameter character
            //if (config["parmPrefix"] == null)
            //{
            //    config["parmPrefix"] = "@";
            //}
            //parmPrefix = config["parmPrefix"];
            //config.Remove("parmPrefix");

            // Application Name
            if (config["applicationName"] == null)
            {
                config["applicationName"] = "SwordWeb";
            }
            applicationName = config["applicationName"];
            config.Remove("applicationName");

            //Password Format
            //if (config["passwordFormat"] == null)
            //{
            //    config["passwordFormat"] = "Hashed";
            //    passwordFormat = MembershipPasswordFormat.Hashed;
            //}
            //else if (String.Compare(config["passwordFormat"], "clear", true) == 0)
            //{
            //    passwordFormat = MembershipPasswordFormat.Clear;
            //}
            //else
            //{
            //    passwordFormat = MembershipPasswordFormat.Hashed;
            //}
            //config.Remove("passwordFormat");

            // Throw an exception if unrecognized attributes remain
            if (config.Count > 0)
            {
                string attr = config.GetKey(0);
                if (!String.IsNullOrEmpty(attr))
                    throw new ProviderException("Unrecognized attribute: " + attr);
            }
        }

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

            //可能要的配置里设置

            //默认用户组ID
            int DefaultGroupID = 10; //新路上手
            //黑夜模板ID
            int Templateid = 0;
            
            DbParameter[] parms = {
									   DbHelperUser.Instance.MakeInParam("@username",(DbType)SqlDbType.Char,20,username),
									   DbHelperUser.Instance.MakeInParam("@nickname",(DbType)SqlDbType.Char,20,username),
									   DbHelperUser.Instance.MakeInParam("@password",(DbType)SqlDbType.Char,32,Core.Utils.MD5(password)),
									   DbHelperUser.Instance.MakeInParam("@secques",(DbType)SqlDbType.Char,8,string.IsNullOrEmpty(passwordQuestion)?"":passwordQuestion),
									   DbHelperUser.Instance.MakeInParam("@gender",(DbType)SqlDbType.Int,4,1),
									   DbHelperUser.Instance.MakeInParam("@adminid",(DbType)SqlDbType.Int,4,0),
									   DbHelperUser.Instance.MakeInParam("@groupid",(DbType)SqlDbType.SmallInt,2,DefaultGroupID),
									   DbHelperUser.Instance.MakeInParam("@groupexpiry",(DbType)SqlDbType.Int,4,0),
									   DbHelperUser.Instance.MakeInParam("@extgroupids",(DbType)SqlDbType.Char,60,""),
									   DbHelperUser.Instance.MakeInParam("@regip",(DbType)SqlDbType.VarChar,0,Core.Utils.GetIP()),
									   DbHelperUser.Instance.MakeInParam("@joindate",(DbType)SqlDbType.VarChar,0,DateTime.Now.ToString()),
									   DbHelperUser.Instance.MakeInParam("@lastip",(DbType)SqlDbType.Char,15,Utils.GetIP()),
									   DbHelperUser.Instance.MakeInParam("@lastvisit",(DbType)SqlDbType.VarChar,0,DateTime.Now.ToString()),
									   DbHelperUser.Instance.MakeInParam("@lastactivity",(DbType)SqlDbType.VarChar,0,DateTime.Now.ToString()),
									   DbHelperUser.Instance.MakeInParam("@lastpost",(DbType)SqlDbType.VarChar,0,DateTime.Now.ToString()),
									   DbHelperUser.Instance.MakeInParam("@lastpostid",(DbType)SqlDbType.Int,4,0),
									   DbHelperUser.Instance.MakeInParam("@lastposttitle",(DbType)SqlDbType.VarChar,0,""),
									   DbHelperUser.Instance.MakeInParam("@posts",(DbType)SqlDbType.Int,4,0),
									   DbHelperUser.Instance.MakeInParam("@digestposts",(DbType)SqlDbType.SmallInt,2,0),
									   DbHelperUser.Instance.MakeInParam("@oltime",(DbType)SqlDbType.Int,2,1),
									   DbHelperUser.Instance.MakeInParam("@pageviews",(DbType)SqlDbType.Int,4,0),
									   DbHelperUser.Instance.MakeInParam("@credits",(DbType)SqlDbType.Int,4,EbSite.Configs.UserSetConfigs.ConfigsControl.Instance.DefaultCredits),
									   DbHelperUser.Instance.MakeInParam("@extcredits1",(DbType)SqlDbType.Float,8,0.00),
									   DbHelperUser.Instance.MakeInParam("@extcredits2",(DbType)SqlDbType.Float,8,0.00),
									   DbHelperUser.Instance.MakeInParam("@extcredits3",(DbType)SqlDbType.Float,8,0.00),
									   DbHelperUser.Instance.MakeInParam("@extcredits4",(DbType)SqlDbType.Float,8,0.00),
									   DbHelperUser.Instance.MakeInParam("@extcredits5",(DbType)SqlDbType.Float,8,0.00),
									   DbHelperUser.Instance.MakeInParam("@extcredits6",(DbType)SqlDbType.Float,8,0.00),
									   DbHelperUser.Instance.MakeInParam("@extcredits7",(DbType)SqlDbType.Float,8,0.00),
									   DbHelperUser.Instance.MakeInParam("@extcredits8",(DbType)SqlDbType.Float,8,0.00),
									   DbHelperUser.Instance.MakeInParam("@avatarshowid",(DbType)SqlDbType.Int,4,0),
									   DbHelperUser.Instance.MakeInParam("@email",(DbType)SqlDbType.Char,50,email),
									   DbHelperUser.Instance.MakeInParam("@bday",(DbType)SqlDbType.VarChar,0,""),
									   DbHelperUser.Instance.MakeInParam("@sigstatus",(DbType)SqlDbType.Int,4,1),
									   DbHelperUser.Instance.MakeInParam("@tpp",(DbType)SqlDbType.Int,4,0),
									   DbHelperUser.Instance.MakeInParam("@ppp",(DbType)SqlDbType.Int,4,0),
									   DbHelperUser.Instance.MakeInParam("@templateid",(DbType)SqlDbType.SmallInt,2,Templateid),
									   DbHelperUser.Instance.MakeInParam("@pmsound",(DbType)SqlDbType.Int,4,0),
									   DbHelperUser.Instance.MakeInParam("@showemail",(DbType)SqlDbType.Int,4,0),
									   DbHelperUser.Instance.MakeInParam("@newsletter",(DbType)SqlDbType.Int,4,7),
									   DbHelperUser.Instance.MakeInParam("@invisible",(DbType)SqlDbType.Int,4,0),
									   DbHelperUser.Instance.MakeInParam("@newpm",(DbType)SqlDbType.Int,4,0),
									   DbHelperUser.Instance.MakeInParam("@accessmasks",(DbType)SqlDbType.Int,4,0),
                                       DbHelperUser.Instance.MakeInParam("@salt",(DbType)SqlDbType.NChar,6,""),
									   //
									   DbHelperUser.Instance.MakeInParam("@website",(DbType)SqlDbType.VarChar,80,""),
									   DbHelperUser.Instance.MakeInParam("@icq",(DbType)SqlDbType.VarChar,12,""),
									   DbHelperUser.Instance.MakeInParam("@qq",(DbType)SqlDbType.VarChar,12,""),
									   DbHelperUser.Instance.MakeInParam("@yahoo",(DbType)SqlDbType.VarChar,40,""),
									   DbHelperUser.Instance.MakeInParam("@msn",(DbType)SqlDbType.VarChar,40,""),
									   DbHelperUser.Instance.MakeInParam("@skype",(DbType)SqlDbType.VarChar,40,""),
									   DbHelperUser.Instance.MakeInParam("@location",(DbType)SqlDbType.VarChar,30,""),
									   DbHelperUser.Instance.MakeInParam("@customstatus",(DbType)SqlDbType.VarChar,30,""),
									   DbHelperUser.Instance.MakeInParam("@avatar",(DbType)SqlDbType.VarChar,255,""),
									   DbHelperUser.Instance.MakeInParam("@avatarwidth",(DbType)SqlDbType.Int,4,0),
									   DbHelperUser.Instance.MakeInParam("@avatarheight",(DbType)SqlDbType.Int,4,0),
									   DbHelperUser.Instance.MakeInParam("@medals",(DbType)SqlDbType.VarChar,40, ""),
									   DbHelperUser.Instance.MakeInParam("@bio",(DbType)SqlDbType.NVarChar,500,""),
									   DbHelperUser.Instance.MakeInParam("@signature",(DbType)SqlDbType.NVarChar,500,""),
									   DbHelperUser.Instance.MakeInParam("@sightml",(DbType)SqlDbType.NVarChar,1000,""),
									   DbHelperUser.Instance.MakeInParam("@authstr",(DbType)SqlDbType.VarChar,20,""),
                                       DbHelperUser.Instance.MakeInParam("@realname",(DbType)SqlDbType.NVarChar,10,""),
                                       DbHelperUser.Instance.MakeInParam("@idcard",(DbType)SqlDbType.VarChar,20,""),
                                       DbHelperUser.Instance.MakeInParam("@mobile",(DbType)SqlDbType.VarChar,20,""),
                                       DbHelperUser.Instance.MakeInParam("@phone",(DbType)SqlDbType.VarChar,20,"")
								   };
            DbHelperUser.Instance.ExecuteScalar(CommandType.StoredProcedure, string.Format("{0}createuser", tablePrefix), parms);



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
            throw new NotImplementedException();
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
            oldPasswordCorrect = ValidateUser(username, Core.Utils.MD5(oldPassword));

            if(oldPasswordCorrect)
            {
                StringBuilder strSql = new StringBuilder();
                strSql.AppendFormat("update {0}Users set ", tablePrefix);
                strSql.Append("password=@password");
                strSql.Append(" where UserName=@UserName ");
                SqlParameter[] parameters = {
					new SqlParameter("@Password", SqlDbType.NVarChar,255),
					new SqlParameter("@UserName", SqlDbType.NVarChar,100)};
                //整合只用md5
                parameters[0].Value = Core.Utils.MD5(newPassword);
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
            strSql.Append("email=@email,joindate=@joindate");
            
            strSql.Append(" where UserName=@UserName ");
            SqlParameter[] parameters = {
					new SqlParameter("@UserName", SqlDbType.NVarChar,100),
					new SqlParameter("@email", SqlDbType.NVarChar,100),
					new SqlParameter("@joindate", SqlDbType.DateTime)};
            parameters[0].Value = user.UserName;
            parameters[1].Value = user.Email;
            parameters[2].Value = DateTime.Now;

            DbHelperUser.Instance.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);

        }

        /// <summary>
        /// Check username and password
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public override bool ValidateUser(string username, string password)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select count(1) from {0}Users", tablePrefix);
            strSql.Append(" where username=@username and password=@password");
            SqlParameter[] parameters = {
					new SqlParameter("@username", SqlDbType.NVarChar,50),
                    new SqlParameter("@password", SqlDbType.NVarChar,255)
                                        };
            parameters[0].Value = username;

            //dnt论坛有个兼容动网的设置，以后更新
            parameters[1].Value = password;

            return DbHelperUser.Instance.Exists(strSql.ToString(), parameters);

        }

        /// <summary>
        /// Not implemented
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public override bool UnlockUser(string userName)
        {

            //dnt好像没有锁定用户的功能
            return false;

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
            strSql.AppendFormat("select  top 1 uid,UserName,Password,email from {0}Users ", tablePrefix);
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
            strSql.Append(" where email=@email ");
			SqlParameter[] parameters = {
					new SqlParameter("@email", SqlDbType.NVarChar,100)};
            parameters[0].Value = email;

            object ob =  DbHelperUser.Instance.ExecuteScalar(CommandType.Text, strSql.ToString(), parameters);

            if(!Equals(ob,null))
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

        /// <summary>
        /// Can password be retrieved via email?
        /// </summary>
        public override bool EnablePasswordRetrieval
        {
            get { return false; }
        }

        /// <summary>
        /// Hardcoded to false
        /// </summary>
        public override bool EnablePasswordReset
        {
            get { return false; }
        }

        /// <summary>
        /// Hardcoded to false
        /// </summary>
        public override bool RequiresQuestionAndAnswer
        {
            get { return false; }
        }

        /// <summary>
        /// Returns the application name as set in the web.config
        /// otherwise returns BlogEngine.  Set will throw an error.
        /// </summary>
        public override string ApplicationName
        {
            get { return applicationName; }
            set { throw new NotImplementedException(); }
        }

        /// <summary>
        /// Hardcoded to 5
        /// </summary>
        public override int MaxInvalidPasswordAttempts
        {
            get { return 5; }
        }

        /// <summary>
        /// Not implemented
        /// </summary>
        public override int PasswordAttemptWindow
        {
            get { throw new NotImplementedException(); }
        }

        /// <summary>
        /// Hardcoded to false
        /// </summary>
        public override bool RequiresUniqueEmail
        {
            get { return false; }
        }

        /// <summary>
        /// Password format (Clear or Hashed)
        /// </summary>
        public override MembershipPasswordFormat PasswordFormat
        {
            get { throw new NotImplementedException(); }
        }

        /// <summary>
        /// Hardcoded to 4
        /// </summary>
        public override int MinRequiredPasswordLength
        {
            get { return 4; }
        }

        /// <summary>
        /// Hardcoded to 0
        /// </summary>
        public override int MinRequiredNonAlphanumericCharacters
        {
            get { return 0; }
        }

        /// <summary>
        /// Not Implemented
        /// </summary>
        public override string PasswordStrengthRegularExpression
        {
            get { throw new NotImplementedException(); }
        }

        private MembershipUser GetMembershipUser(string userName, string email, DateTime lastLogin,
                                                    bool IsApproved, bool IsLockedOut, DateTime CreateDate,
                                                    DateTime LastPasswordChangedDate,
                                                    DateTime LastLockoutDate, DateTime LastActivityDate)
        {
            MembershipUser user = new MembershipUser(
                                    Name,                       // Provider name
                                    userName,                  // Username
                                    userName,                  // providerUserKey
                                    email,                      // Email
                                    String.Empty,               // passwordQuestion
                                    String.Empty,               // Comment
                                    IsApproved,                       // isApproved
                                    IsLockedOut,                      // isLockedOut
                                    CreateDate,               // creationDate
                                    lastLogin,                  // lastLoginDate
                                    LastActivityDate,               // lastActivityDate
                                    LastPasswordChangedDate,               // lastPasswordChangedDate
                                    LastLockoutDate    // lastLockoutDate


                                );
            return user;
        }

        /// <summary>
        /// 对象实体绑定数据
        /// </summary>
        public MembershipUser ReaderBind(IDataReader dataReader)
        {

            string userName;
            string email;
            DateTime lastLogin = DateTime.Now;
            bool IsApproved = false;
            bool IsLockedOut = false;
            DateTime CreateDate = DateTime.Now;
            DateTime LastPasswordChangedDate = DateTime.Now;
            DateTime LastLockoutDate = DateTime.Now;
            DateTime LastActivityDate = DateTime.Now;

            userName = dataReader["UserName"].ToString();
            
            email = dataReader["email"].ToString();
            
            MembershipUser model = GetMembershipUser(userName, email, lastLogin, IsApproved, IsLockedOut, CreateDate, LastPasswordChangedDate, LastLockoutDate, LastActivityDate);
            return model;
        }


    }
}
