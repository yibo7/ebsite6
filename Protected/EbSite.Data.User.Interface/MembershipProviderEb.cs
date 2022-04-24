using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration.Provider;
using System.Data;
using System.Data.Common;
using System.Text;
using System.Web.Security;
using EbSite.Base.DataProfile;
using EbSite.Base.EntityAPI;

namespace EbSite.Data.User.Interface
{
    abstract public class MembershipProviderEb : MembershipProvider
    {
        //private string connStringName;
        protected string tablePrefix;
        //private string parmPrefix;
        protected string applicationName;
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
                config["tablePrefix"] = Base.Configs.BaseCinfigs.ConfigsControl.Instance.TablePrefixUser;
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

        #region 公共方法

        public virtual Base.EntityAPI.ShortUserInfo GetShortUserInfo(string UserName)
        {
            UserName = UserName.Replace("'", ""); 
            string sCountSql = string.Format("select UserID, UserName,Password,NiName,GroupID  from {0}Users where UserName='{1}' ", tablePrefix, UserName);

            Base.EntityAPI.ShortUserInfo model = null;
            using (IDataReader dataReader = DbHelperUser.Instance.ExecuteReader(CommandType.Text, sCountSql))
            {
                if (dataReader.Read())
                {
                    model = new ShortUserInfo();
                    object ojb;
                    ojb = dataReader["UserID"];
                    if (ojb != null && ojb != DBNull.Value)
                    {
                        model.UserID = int.Parse(ojb.ToString());
                    }
                    model.UserName = dataReader["UserName"].ToString();
                    model.Password = dataReader["Password"].ToString();
                    model.UserNiName = dataReader["NiName"].ToString();
                    ojb = dataReader["GroupID"];
                    if (ojb != null && ojb != DBNull.Value)
                    {
                        model.GroupID = int.Parse(ojb.ToString());
                    }

                }
            }
            return model;
        }

        virtual public Base.EntityAPI.ShortUserInfo GetShortUserInfo(int UserID)
        {
            string sCountSql = string.Format("select UserID, UserName,Password,NiName,GroupID  from {0}Users where UserID={1} ", tablePrefix, UserID);

            Base.EntityAPI.ShortUserInfo model = null;
            using (IDataReader dataReader = DbHelperUser.Instance.ExecuteReader(CommandType.Text, sCountSql))
            {
                if (dataReader.Read())
                {
                    model = new ShortUserInfo();
                    object ojb;
                    ojb = dataReader["UserID"];
                    if (ojb != null && ojb != DBNull.Value)
                    {
                        model.UserID = int.Parse(ojb.ToString());
                    }
                    model.UserName = dataReader["UserName"].ToString();
                    model.Password = dataReader["Password"].ToString();
                    model.UserNiName = dataReader["NiName"].ToString();
                    ojb = dataReader["GroupID"];
                    if (ojb != null && ojb != DBNull.Value)
                    {
                        model.GroupID = int.Parse(ojb.ToString());
                    }

                }
            }
            return model;
        }
        /// <summary>
        /// 获取某个条件下的记录条数
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
      virtual  public int User_GetCount(string strWhere)
        {
            string sCountSql = string.Format("select count(*)  from {0}Users  {1} ", tablePrefix, string.IsNullOrEmpty(strWhere) ? "" : string.Concat(" Where ", strWhere));

            object obCount = DbHelperUser.Instance.ExecuteScalar(CommandType.Text, sCountSql);
            int totalRecords = 0;
            if (!Equals(obCount, null))
            {
                totalRecords = int.Parse(obCount.ToString());
            }
            return totalRecords;
        }
//      public string Users_GetPass(string UserName,out bool isHave)
//      {
//          UserName = UserName.Replace("'", ""); 
//          string sCountSql = string.Format("select Password  from {0}Users where UserName='{1}' ", tablePrefix, UserName);
//          object obCount = DbHelperUser.Instance.ExecuteScalar(CommandType.Text, sCountSql);
//          isHave = false;
//          if (!Equals(obCount, null))
//          {
//              isHave = true;
//              return obCount.ToString();
//          } 
//          return "";
//      }
      public string Users_GetEmail(int UserID)
      {
          string sCountSql = string.Format("select emailAddress  from {0}Users where UserID={1} ", tablePrefix, UserID);

          object obCount = DbHelperUser.Instance.ExecuteScalar(CommandType.Text, sCountSql);

          if (!Equals(obCount, null))
          {
              return obCount.ToString();
          }
          return "";
      }
      /// <summary>
      /// 获取某个用户的手机号码
      /// </summary>
      /// <returns></returns>
      public string User_GetMobileNumber(string UserName)
      {
          UserName = UserName.Replace("'", "");
          string sCountSql = string.Format("select MobileNumber  from {0}Users where UserName='{1}' ", tablePrefix, UserName);

          object obCount = DbHelperUser.Instance.ExecuteScalar(CommandType.Text, sCountSql);
          
          if (!Equals(obCount, null))
          {
              return obCount.ToString();
          }
          return "";
      }

      public string User_GetMobileNumber(int UserID)
      {
          string sCountSql = string.Format("select MobileNumber  from {0}Users where UserID={1} ", tablePrefix, UserID);

          object obCount = DbHelperUser.Instance.ExecuteScalar(CommandType.Text, sCountSql);

          if (!Equals(obCount, null))
          {
              return obCount.ToString();
          }
          return "";
      }


      /// <summary>
      /// 是否存在手机号码
      /// </summary>
      public bool ExistMobile(string sMobileNumber)
      {
          sMobileNumber = sMobileNumber.Replace("'", "");
          StringBuilder strSql = new StringBuilder();
          strSql.AppendFormat("select count(1) from {0}Users", tablePrefix);
          strSql.AppendFormat(" where MobileNumber='{0}' ", sMobileNumber);
          return DbHelperUser.Instance.Exists(strSql.ToString());
      }/// <summary>
      /// 是否存在email
      /// </summary>
      public bool ExistEmail(string sEmail)
      {
          sEmail = sEmail.Replace("'", "");
          StringBuilder strSql = new StringBuilder();
          strSql.AppendFormat("select count(1) from {0}Users", tablePrefix);
          strSql.AppendFormat(" where emailAddress='{0}' ", sEmail);
          return DbHelperUser.Instance.Exists(strSql.ToString());
      }


      
     
        /// <summary>
        /// 获取头像的路径包括文件名
        /// </summary>
        /// <param name="UserName"></param>
        /// <param name="iSize"></param>
        /// <returns></returns>
        public string GetAvatarFileName(int UserID, int iSize)
        {
            string sPath = string.Empty;
            string size = "";
            if (iSize == 1)
            {
                size = "large";
            }
            else if (iSize == 2)
            {
                size = "mid";
            }
            else
            {
                size = "small";
            }
            sPath = EbSite.Base.Host.Instance.GetAvatarPath(UserID);
            sPath = string.Concat(sPath, "at-", size, ".jpg");
            //判断是否存在文件
            return string.Concat(sPath, "at-", size, ".jpg");
        }


        
       
        protected MembershipUser GetMembershipUser(string userName, string email, DateTime lastLogin,
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
        protected MembershipUser ReaderBind(IDataReader dataReader)
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



            //if (dataReader["UserID"].ToString() != "")
            //{
            //    model.UserID = int.Parse(dataReader["UserID"].ToString());
            //}
            userName = dataReader["UserName"].ToString();

            email = dataReader["emailAddress"].ToString();
            if (dataReader["IsApproved"].ToString() != "")
            {
                if ((dataReader["IsApproved"].ToString() == "1") || (dataReader["IsApproved"].ToString().ToLower() == "true"))
                {
                    IsApproved = true;
                }
                else
                {
                    IsApproved = false;
                }
            }
            if (dataReader["IsLockedOut"].ToString() != "")
            {
                if ((dataReader["IsLockedOut"].ToString() == "1") || (dataReader["IsLockedOut"].ToString().ToLower() == "true"))
                {
                    IsLockedOut = true;
                }
                else
                {
                    IsLockedOut = false;
                }
            }
            if (dataReader["CreateDate"].ToString() != "")
            {
                CreateDate = DateTime.Parse(dataReader["CreateDate"].ToString());
            }
            if (dataReader["LastLoginDate"].ToString() != "")
            {
                lastLogin = DateTime.Parse(dataReader["LastLoginDate"].ToString());
            }
            if (dataReader["LastPasswordChangedDate"].ToString() != "")
            {
                LastPasswordChangedDate = DateTime.Parse(dataReader["LastPasswordChangedDate"].ToString());
            }
            if (dataReader["LastLockoutDate"].ToString() != "")
            {
                LastLockoutDate = DateTime.Parse(dataReader["LastLockoutDate"].ToString());
            }
            //if (dataReader["FailedPasswordAttemptCount"].ToString() != "")
            //{
            //    FailedPasswordAttemptCount = int.Parse(dataReader["FailedPasswordAttemptCount"].ToString());
            //}
            if (dataReader["LastActivityDate"].ToString() != "")
            {
                LastActivityDate = DateTime.Parse(dataReader["LastActivityDate"].ToString());
            }
            MembershipUser model = GetMembershipUser(userName, email, lastLogin, IsApproved, IsLockedOut, CreateDate, LastPasswordChangedDate, LastLockoutDate, LastActivityDate);
            return model;
        }

        /// <summary>
        /// 对象实体绑定数据
        /// </summary>
        protected Base.EntityAPI.MembershipUserEb Users_ReaderBind(IDataReader dataReader)
        {
            Base.EntityAPI.MembershipUserEb model = new Base.EntityAPI.MembershipUserEb();
            object ojb;
            ojb = dataReader["UserID"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.id = int.Parse(ojb.ToString());
            }
            model.UserName = dataReader["UserName"].ToString();
            model.Password = dataReader["Password"].ToString();
            model.emailAddress = dataReader["emailAddress"].ToString();
            ojb = dataReader["IsApproved"];
            if( dataReader["IsApproved"].ToString()=="1")
            {
                ojb = true;
            }
            if (dataReader["IsApproved"].ToString() == "0")
            {
                ojb = false;
            }
            if (ojb != null && ojb != DBNull.Value)
            {
                model.IsApproved = bool.Parse(ojb.ToString());
            }
            ojb = dataReader["IsLockedOut"];
            if (dataReader["IsLockedOut"].ToString() == "1")
            {
                ojb = true;
            }
            if (dataReader["IsLockedOut"].ToString() == "0")
            {
                ojb = false;
            }
            if (ojb != null && ojb != DBNull.Value)
            {
                model.IsLockedOut =bool.Parse(ojb.ToString());
            }
            ojb = dataReader["CreateDate"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.CreateDate = (DateTime)ojb;
            }
            ojb = dataReader["LastLoginDate"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.LastLoginDate = (DateTime)ojb;
            }
            ojb = dataReader["LastPasswordChangedDate"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.LastPasswordChangedDate = (DateTime)ojb;
            }
            ojb = dataReader["LastLockoutDate"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.LastLockoutDate = (DateTime)ojb;
            }
            ojb = dataReader["FailedPasswordAttemptCount"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.FailedPasswordAttemptCount = int.Parse(ojb.ToString());
            }
            ojb = dataReader["LastActivityDate"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.LastActivityDate = (DateTime)ojb;
            }
            ojb = dataReader["Credits"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.Credits = int.Parse(ojb.ToString());
            }
            ojb = dataReader["UserLevel"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.UserLevel = int.Parse(ojb.ToString());
            }

            
            model.NiName = dataReader["NiName"].ToString();
            model.Sign = dataReader["Sign"].ToString();
            model.MobileNumber = dataReader["MobileNumber"].ToString();

            model.IP = dataReader["IP"].ToString();
            model.RegRemark = dataReader["RegRemark"].ToString();

            ojb = dataReader["GroupID"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.GroupID = int.Parse(ojb.ToString());
            }

            ojb = dataReader["LoginCount"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.GroupID = int.Parse(ojb.ToString());
            }

            return model;
        }

        #endregion

        #region 自定义扩展接口

        protected string sFieldEB_Users = "UserID,UserName,Password,emailAddress,IsApproved,IsLockedOut,CreateDate,LastLoginDate,LastPasswordChangedDate,LastLockoutDate,FailedPasswordAttemptCount,LastActivityDate,Credits,NiName,Sign,MobileNumber,UserLevel,IP,RegRemark,GroupID,LoginCount";
        /// <summary>
        /// 获取已经锁定的用户
        /// </summary>
        /// <returns></returns>
        public abstract List<EbSite.Base.EntityAPI.MembershipUserEb> GetLockedUsers(int PageIndex, int PageSize, out int totalRecords);

        public abstract List<EbSite.Base.EntityAPI.MembershipUserEb> GetListPages(int PageIndex, int PageSize, string strWhere, string oderby,
                                                          int IsAuditing, out int totalRecords);

        /// <summary>
        /// 获取用户ID-从用户帐号
        /// </summary>
        /// <param name="sUserName"></param>
        /// <returns></returns>
        public abstract int GetUserIDByUserName(string sUserName);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        abstract public Base.EntityAPI.MembershipUserEb Users_GetEntity(string sUserName);

        /// <summary>
        /// 锁定一个用户
        /// </summary>
        /// <param name="userName"></param>
        public abstract void LockUser(string userName);


        /// <summary>
        /// 得到最大ID
        /// </summary>
        abstract public int Users_GetMaxId();
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        abstract public bool Users_Exists(int UserID);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        abstract public int Users_Add(EbSite.Base.EntityAPI.MembershipUserEb model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        abstract public void Users_Update(Base.EntityAPI.MembershipUserEb model);

         abstract  public  void Users_Update(Base.EntityAPI.MembershipUserEb model, DbTransaction tran);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        abstract public void Users_Delete(int UserID);
        abstract public void Users_Delete(string sUserName);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        abstract public Base.EntityAPI.MembershipUserEb Users_GetEntity(int UserID);
        

        /// <summary>
        /// 获得数据列表（比DataSet效率高，推荐使用）
        /// </summary>
        abstract public List<Base.EntityAPI.MembershipUserEb> Users_GetListArray(string strWhere);
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        abstract public List<Base.EntityAPI.MembershipUserEb> Users_GetListArray(int Top, string strWhere, string filedOrder);
        /// <summary>
        /// 获得分页数据
        /// </summary>
        abstract public List<Base.EntityAPI.MembershipUserEb> Users_GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby, out int RecordCount);

        abstract public List<Base.EntityAPI.MembershipUserEb> GetListPages(int PageIndex, int PageSize, string strWhere, string oderby, bool IsAuditing,
                                     out int totalRecords, int RoleID);
        /// <summary>
        /// 是否存在用户
        /// </summary>
        /// <param name="UserName">用户帐号</param>
        /// <param name="UserPass">加密后的密码</param>
        /// <returns></returns>
        abstract public bool IsHaveUser(string UserName, string UserPass);

        public abstract MembershipUserEb GetUserByEmail(string UserName, string Pass);
        public abstract MembershipUserEb GetUserByMobile(string UserName, string Pass);

        /// <summary>
        /// 通过手机得到 用户实体
        /// </summary>
        public abstract Base.EntityAPI.MembershipUserEb GetUserMobile(string sMobileNumber);

        public abstract bool ChangeUserPass(string UserName, string UserPass);


        //后台管理会员-更改用户组
        abstract   public bool UpdateUserGroupId(string userName, int GroupId);
        //后台管理会员-取到 用户组id
        public abstract  int GetUserGroupId(string username);

        #endregion
    }
}
