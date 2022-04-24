
using System;
using System.Data;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text;
using EbSite.BLL.User;


namespace EbSite.Data.Interface
{
    public partial interface IDataProviderCms
    {
        BLL.User.UserProfile UserProfile_SelectUserProfile(int UserId);

        /// <summary>
        /// 没有当前用户的资料，反回null
        /// </summary>
        /// <param name="UserName"></param>
        /// <param name="UserModelID"></param>
        /// <returns></returns>
        BLL.User.UserProfile UserProfile_SelectUserProfile(string UserName, Guid UserModelID);

        void UserProfile_InsertUserProfile(BLL.User.UserProfile model);
        void UserProfile_UpdateUserProfile(BLL.User.UserProfile model);
        //static public void UpdateUserToAdmin(string sUserName)
        //{
        //    StringBuilder strSql = new StringBuilder();
        //    strSql.Append("update " + EbSite.Configs.BaseCinfigs.ConfigsControl.Instance.TablePrefix + "UserProfile set ");
        //    strSql.Append("IsManager=@IsManager");
        //    strSql.Append(" where UserName=@UserName");
        //    SqlParameter[] parameters = {
        //            new SqlParameter("@UserName", SqlDbType.NVarChar,50),
        //            new SqlParameter("@IsManager", SqlDbType.Bit,1)};

        //    parameters[0].Value = sUserName;
        //    parameters[1].Value = 1;

        //    DbHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        //}
        void UserProfile_DeleteUserProfile(BLL.User.UserProfile Model);
    }
}
