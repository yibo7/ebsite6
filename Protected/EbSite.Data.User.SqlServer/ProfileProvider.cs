using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using EbSite.Base.DataProfile;
using EbSite.Entity;

namespace EbSite.Data.User.SqlServer
{
    public partial class DataProviderUser : Interface.IDataProviderUser
    {
        // Contst matching System.Web.Profile.ProfileAuthenticationOption.Anonymous
        private const int AUTH_ANONYMOUS = 0;

        // Contst matching System.Web.Profile.ProfileAuthenticationOption.Authenticated
        private const int AUTH_AUTHENTICATED = 1;

        // Contst matching System.Web.Profile.ProfileAuthenticationOption.All
        private const int AUTH_ALL = 2;
        /// <summary>
        /// Update activity dates for current user and application
        /// </summary>
        /// <param name="userName">USer name</param>
        /// <param name="activityOnly">Activity only flag</param>
        /// <param name="appName">Application Name</param>
        public void UpdateActivityDates(string userName, bool activityOnly, string appName)
        {
            DateTime activityDate = DateTime.Now;

            string sqlUpdate;
            SqlParameter[] parms;

            if (activityOnly)
            {
                sqlUpdate = string.Concat("UPDATE ", sPre, "Profiles Set LastActivityDate = @LastActivityDate WHERE Username = @Username AND ApplicationName = @ApplicationName;");
                parms = new SqlParameter[]{						   
					new SqlParameter("@LastActivityDate", SqlDbType.DateTime),
					new SqlParameter("@Username", SqlDbType.VarChar, 256),
					new SqlParameter("@ApplicationName", SqlDbType.VarChar, 256)};

                parms[0].Value = activityDate;
                parms[1].Value = userName;
                parms[2].Value = appName;

            }
            else
            {
                sqlUpdate =string.Concat("UPDATE ",sPre,"Profiles Set LastActivityDate = @LastActivityDate, LastUpdatedDate = @LastUpdatedDate WHERE Username = @Username AND ApplicationName = @ApplicationName;");
                parms = new SqlParameter[]{
					new SqlParameter("@LastActivityDate", SqlDbType.DateTime),
					new SqlParameter("@LastUpdatedDate", SqlDbType.DateTime),
					new SqlParameter("@Username", SqlDbType.VarChar, 256),
					new SqlParameter("@ApplicationName", SqlDbType.VarChar, 256)};

                parms[0].Value = activityDate;
                parms[1].Value = activityDate;
                parms[2].Value = userName;
                parms[3].Value = appName;
            }

            DbHelperUser.Instance.ExecuteNonQuery(CommandType.Text, sqlUpdate, parms);

        }

        /// <summary>
        /// Retrive unique id for current user
        /// </summary>
        /// <param name="userName">User name</param>
        /// <param name="isAuthenticated">Authentication flag</param>
        /// <param name="ignoreAuthenticationType">Ignore authentication flag</param>
        /// <param name="appName">Application Name</param>
        /// <returns>Unique id for current user</returns>
        public int GetUniqueID(string userName, bool isAuthenticated, bool ignoreAuthenticationType, string appName)
        {
            string sqlSelect = string.Concat("SELECT UniqueID FROM ",sPre,"Profiles WHERE Username = @Username AND ApplicationName = @ApplicationName");

            SqlParameter[] parms = {
				new SqlParameter("@Username", SqlDbType.VarChar, 256),
				new SqlParameter("@ApplicationName", SqlDbType.VarChar, 256)};
            parms[0].Value = userName;
            parms[1].Value = appName;

            if (!ignoreAuthenticationType)
            {
                sqlSelect += " AND IsAnonymous = @IsAnonymous";
                Array.Resize<SqlParameter>(ref parms, parms.Length + 1);
                parms[2] = new SqlParameter("@IsAnonymous", SqlDbType.Bit);
                parms[2].Value = !isAuthenticated;
            }

            int uniqueID = 0;

            object retVal = null;
            retVal = DbHelperUser.Instance.ExecuteScalar(CommandType.Text, sqlSelect, parms);

            if (retVal == null)
                uniqueID = CreateProfileForUser(userName, isAuthenticated, appName);
            else
                uniqueID = Convert.ToInt32(retVal);
            return uniqueID;
        }

        /// <summary>
        /// Create profile record for current user
        /// </summary>
        /// <param name="userName">User name</param>
        /// <param name="isAuthenticated">Authentication flag</param>
        /// <param name="appName">Application Name</param>
        /// <returns>Number of records created</returns>
        public int CreateProfileForUser(string userName, bool isAuthenticated, string appName)
        {

            string sqlInsert = string.Concat("INSERT INTO ",sPre,"Profiles (Username, ApplicationName, LastActivityDate, LastUpdatedDate, IsAnonymous) Values(@Username, @ApplicationName, @LastActivityDate, @LastUpdatedDate, @IsAnonymous); SELECT @@IDENTITY;");

            SqlParameter[] parms = {
				new SqlParameter("@Username", SqlDbType.VarChar, 256),
				new SqlParameter("@ApplicationName", SqlDbType.VarChar, 256),
				new SqlParameter("@LastActivityDate", SqlDbType.DateTime),
				new SqlParameter("@LastUpdatedDate", SqlDbType.DateTime),
				new SqlParameter("@IsAnonymous", SqlDbType.Bit)};

            parms[0].Value = userName;
            parms[1].Value = appName;
            parms[2].Value = DateTime.Now;
            parms[3].Value = DateTime.Now;
            parms[4].Value = !isAuthenticated;

            int uniqueID = 0;
            int.TryParse(DbHelperUser.Instance.ExecuteScalar(CommandType.Text, sqlInsert, parms).ToString(), out uniqueID);

            return uniqueID;
        }

        /// <summary>
        /// Retrieve colection of inactive user id's
        /// </summary>
        /// <param name="authenticationOption">Authentication option</param>
        /// <param name="userInactiveSinceDate">Date to start search from</param>
        /// <param name="appName">Application Name</param>
        /// <returns>Collection of inactive profile id's</returns>
        public IList<string> GetInactiveProfiles(int authenticationOption, DateTime userInactiveSinceDate, string appName)
        {

            StringBuilder sqlSelect = new StringBuilder(string.Concat("SELECT Username FROM ",sPre,"Profiles WHERE ApplicationName = @ApplicationName AND LastActivityDate <= @LastActivityDate"));

            SqlParameter[] parms = {
				new SqlParameter("@ApplicationName", SqlDbType.VarChar, 256),
				new SqlParameter("@LastActivityDate", SqlDbType.DateTime)};
            parms[0].Value = appName;
            parms[1].Value = userInactiveSinceDate;

            switch (authenticationOption)
            {
                case AUTH_ANONYMOUS:
                    sqlSelect.Append(" AND IsAnonymous = @IsAnonymous");
                    Array.Resize<SqlParameter>(ref parms, parms.Length + 1);
                    parms[2] = new SqlParameter("@IsAnonymous", SqlDbType.Bit);
                    parms[2].Value = true;
                    break;
                case AUTH_AUTHENTICATED:
                    sqlSelect.Append(" AND IsAnonymous = @IsAnonymous");
                    Array.Resize<SqlParameter>(ref parms, parms.Length + 1);
                    parms[2] = new SqlParameter("@IsAnonymous", SqlDbType.Bit);
                    parms[2].Value = false;
                    break;
                default:
                    break;
            }

            IList<string> usernames = new List<string>();

            DbDataReader dr = DbHelperUser.Instance.ExecuteReader(CommandType.Text, sqlSelect.ToString(), parms);
            while (dr.Read())
            {
                usernames.Add(dr.GetString(0));
            }

            dr.Close();
            return usernames;
        }
        public bool DeleteProfile(int uid)
        {
            string sqlDelete = string.Concat("DELETE FROM ", sPre, "Profiles WHERE UniqueID = @UniqueID;");
            SqlParameter param = new SqlParameter("@UniqueId", SqlDbType.Int, 4);
            param.Value = uid;

            int numDeleted = DbHelperUser.Instance.ExecuteNonQuery(CommandType.Text, sqlDelete, param);

            if (numDeleted <= 0)
                return false;
            else
                return true;
        }
        /// <summary>
        /// Delete user's profile
        /// </summary>
        /// <param name="userName">User name</param>
        /// <param name="appName">Application Name</param>
        /// <returns>True, if profile successfully deleted</returns>
        public bool DeleteProfile(string userName, string appName)
        {

            int uniqueID = GetUniqueID(userName, false, true, appName);
            return DeleteProfile(uniqueID);
            //string sqlDelete = string.Concat("DELETE FROM ",sPre,"Profiles WHERE UniqueID = @UniqueID;");
            //SqlParameter param = new SqlParameter("@UniqueId", SqlDbType.Int, 4);
            //param.Value = uniqueID;

            //int numDeleted = DbHelperUser.Instance.ExecuteNonQuery(CommandType.Text, sqlDelete, param);

            //if (numDeleted <= 0)
            //    return false;
            //else
            //    return true;
        }

        /// <summary>
        /// Retrieve profile information
        /// </summary>
        /// <param name="authenticationOption">Authentication option</param>
        /// <param name="usernameToMatch">User name</param>
        /// <param name="userInactiveSinceDate">Date to start search from</param>
        /// <param name="appName">Application Name</param>
        /// <param name="totalRecords">Number of records to return</param>
        /// <returns>Collection of profiles</returns>
        public IList<CustomProfileInfo> GetProfileInfo(int authenticationOption, string usernameToMatch, DateTime userInactiveSinceDate, string appName, out int totalRecords)
        {

            // Retrieve the total count.
            StringBuilder sqlSelect1 = new StringBuilder(string.Concat("SELECT COUNT(*) FROM ",sPre,"Profiles WHERE ApplicationName = @ApplicationName"));
            SqlParameter[] parms1 = {
				new SqlParameter("@ApplicationName", SqlDbType.VarChar, 256)};
            parms1[0].Value = appName;

            // Retrieve the profile data.
            StringBuilder sqlSelect2 = new StringBuilder(string.Concat("SELECT Username, LastActivityDate, LastUpdatedDate, IsAnonymous FROM ",sPre,"Profiles WHERE ApplicationName = @ApplicationName"));
            SqlParameter[] parms2 = { new SqlParameter("@ApplicationName", SqlDbType.VarChar, 256) };
            parms2[0].Value = appName;

            int arraySize;

            // If searching for a user name to match, add the command text and parameters.
            if (usernameToMatch != null)
            {
                arraySize = parms1.Length;

                sqlSelect1.Append(" AND Username LIKE @Username ");
                Array.Resize<SqlParameter>(ref parms1, arraySize + 1);
                parms1[arraySize] = new SqlParameter("@Username", SqlDbType.VarChar, 256);
                parms1[arraySize].Value = usernameToMatch;

                sqlSelect2.Append(" AND Username LIKE @Username ");
                Array.Resize<SqlParameter>(ref parms2, arraySize + 1);
                parms2[arraySize] = new SqlParameter("@Username", SqlDbType.VarChar, 256);
                parms2[arraySize].Value = usernameToMatch;
            }


            // If searching for inactive profiles, 
            // add the command text and parameters.
            if (userInactiveSinceDate != null)
            {
                arraySize = parms1.Length;

                sqlSelect1.Append(" AND LastActivityDate >= @LastActivityDate ");
                Array.Resize<SqlParameter>(ref parms1, arraySize + 1);
                parms1[arraySize] = new SqlParameter("@LastActivityDate", SqlDbType.DateTime);
                parms1[arraySize].Value = (DateTime)userInactiveSinceDate;

                sqlSelect2.Append(" AND LastActivityDate >= @LastActivityDate ");
                Array.Resize<SqlParameter>(ref parms2, arraySize + 1);
                parms2[arraySize] = new SqlParameter("@LastActivityDate", SqlDbType.DateTime);
                parms2[arraySize].Value = (DateTime)userInactiveSinceDate;
            }


            // If searching for a anonymous or authenticated profiles,    
            // add the command text and parameters.	
            if (authenticationOption != AUTH_ALL)
            {
                arraySize = parms1.Length;

                Array.Resize<SqlParameter>(ref parms1, arraySize + 1);
                sqlSelect1.Append(" AND IsAnonymous = @IsAnonymous");
                parms1[arraySize] = new SqlParameter("@IsAnonymous", SqlDbType.Bit);

                Array.Resize<SqlParameter>(ref parms2, arraySize + 1);
                sqlSelect2.Append(" AND IsAnonymous = @IsAnonymous");
                parms2[arraySize] = new SqlParameter("@IsAnonymous", SqlDbType.Bit);

                switch (authenticationOption)
                {
                    case AUTH_ANONYMOUS:
                        parms1[arraySize].Value = true;
                        parms2[arraySize].Value = true;
                        break;
                    case AUTH_AUTHENTICATED:
                        parms1[arraySize].Value = false;
                        parms2[arraySize].Value = false;
                        break;
                    default:
                        break;
                }
            }

            IList<CustomProfileInfo> profiles = new List<CustomProfileInfo>();

            // Get the profile count.
            totalRecords = (int)DbHelperUser.Instance.ExecuteScalar(CommandType.Text, sqlSelect1.ToString(), parms1);

            // No profiles found.
            if (totalRecords <= 0)
                return profiles;

            DbDataReader dr;
            dr = DbHelperUser.Instance.ExecuteReader(CommandType.Text, sqlSelect2.ToString(), parms2);
            while (dr.Read())
            {
                CustomProfileInfo profile = new CustomProfileInfo(dr.GetString(0), dr.GetDateTime(1), dr.GetDateTime(2), dr.GetBoolean(3));
                profiles.Add(profile);
            }
            dr.Close();

            return profiles;
        }
    }
}
