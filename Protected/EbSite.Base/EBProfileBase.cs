using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Web.Profile;
using EbSite.Base.EBSiteEventArgs;
using EbSite.Entity;

namespace EbSite.Base
{
    public class EBProfileBase: ProfileProvider
    {
        private static EbSite.Base.Host dal
        {
            get
            {
                return Base.Host.Instance;
            }
        } 


        //#region 事件扩展

       

        //static public event EventHandler<DeleteProfilesArgs> EDeleteProfilesArgs;
        //static private void OnDeleteProfilesArgs(object sender, DeleteProfilesArgs arg)
        //{
        //    if (!Equals(EDeleteProfilesArgs, null))
        //    {
        //        EDeleteProfilesArgs(sender, arg);
        //    }
        //}
        //#endregion

        // Private members
        protected const string ERR_INVALID_PARAMETER = "不正确的 Profile 参数:";
        //private const string PROFILE_SHOPPINGCART = "ShoppingCart";
        //private const string PROFILE_WISHLIST = "WishList";
        //private const string PROFILE_ACCOUNT = "AccountInfo";
        protected static string applicationName = "EbSite 2.0";

        /// <summary>
        /// The name of the application using the custom profile provider.
        /// </summary>
        public override string ApplicationName
        {
            get
            {
                return applicationName;
            }
            set
            {
                applicationName = value;
            }
        }

        /// <summary>
        /// Initializes the provider.
        /// </summary>
        /// <param name="name">The friendly name of the provider.</param>
        /// <param name="config">A collection of the name/value pairs representing the provider-specific attributes specified in the configuration for this provider.</param>
        public override void Initialize(string name, NameValueCollection config)
        {

            if (config == null)
                throw new ArgumentNullException("config");

            if (string.IsNullOrEmpty(config["description"]))
            {
                config.Remove("description");
                config.Add("description", "EbSite Custom Profile Provider");
            }

            if (string.IsNullOrEmpty(name))
                name = "EBProfileProvider";

            if (config["applicationName"] != null && !string.IsNullOrEmpty(config["applicationName"].Trim()))
                applicationName = config["applicationName"];

            base.Initialize(name, config);

        }

        /// <summary>
        /// Returns the collection of settings property values for the specified application instance and settings property group.
        /// </summary>
        /// <param name="context">A System.Configuration.SettingsContext describing the current application use.</param>
        /// <param name="collection">A System.Configuration.SettingsPropertyCollection containing the settings property group whose values are to be retrieved.</param>
        /// <returns>A System.Configuration.SettingsPropertyValueCollection containing the values for the specified settings property group.</returns>
        public override SettingsPropertyValueCollection GetPropertyValues(SettingsContext context, SettingsPropertyCollection collection)
        {
            
            SettingsPropertyValueCollection svc = new SettingsPropertyValueCollection();
            
            return svc;
        }

        /// <summary>
        /// Sets the values of the specified group of property settings.
        /// </summary>
        /// <param name="context">A System.Configuration.SettingsContext describing the current application usage.</param>
        /// <param name="collection">A System.Configuration.SettingsPropertyValueCollection representing the group of property settings to set.</param>
        public override void SetPropertyValues(SettingsContext context, SettingsPropertyValueCollection collection)
        {
           
        }
        public override int DeleteProfiles(ProfileInfoCollection profiles)
        {

            int deleteCount = 0;

            foreach (ProfileInfo p in profiles)
                if (DeleteProfile(p.UserName))
                    deleteCount++;

            return deleteCount;
        }
        public override int DeleteProfiles(string[] usernames)
        {

            int deleteCount = 0;

            foreach (string user in usernames)
                if (DeleteProfile(user))
                    deleteCount++;

            return deleteCount;
        }
        public static bool DeleteProfile(string username)
        {
            CheckUserName(username);
            int uniqueID = dal.GetProfileUniqueID(username, false, true, applicationName);
            EBSiteEvents.OnDeleteProfilesArgs(null, new DeleteProfilesArgs(username));
            return dal.DeleteProfile(uniqueID);
        }
        protected static void CheckUserName(string userName)
        {
            if (string.IsNullOrEmpty(userName) || userName.Length > 256 || userName.IndexOf(",") > 0)
                throw new ApplicationException(ERR_INVALID_PARAMETER + " user name.");
        }

        protected int GetProfileUniqueID(string userName, bool isAuthenticated, bool ignoreAuthenticationType, string appName)
        {
            return dal.GetProfileUniqueID(userName, isAuthenticated, ignoreAuthenticationType, appName);
        }

        protected int CreateProfileForUser(string userName, bool isAuthenticated, string appName)
        {
            return dal.CreateProfileForUser(userName, isAuthenticated, appName);
        }

        protected static void UpdateActivityDates(string username, bool activityOnly)
        {
            dal.UpdateActivityDates(username, activityOnly, applicationName);
        }
        public override int DeleteInactiveProfiles(ProfileAuthenticationOption authenticationOption, DateTime userInactiveSinceDate)
        {

            string[] userArray = new string[0];
            dal.GetInactiveProfiles((int)authenticationOption, userInactiveSinceDate, ApplicationName).CopyTo(userArray, 0);

            return DeleteProfiles(userArray);
        }
        public override ProfileInfoCollection FindProfilesByUserName(ProfileAuthenticationOption authenticationOption, string usernameToMatch, int pageIndex, int pageSize, out int totalRecords)
        {

            CheckParameters(pageIndex, pageSize);

            return GetProfileInfo(authenticationOption, usernameToMatch, null, pageIndex, pageSize, out totalRecords);
        }
        public override ProfileInfoCollection FindInactiveProfilesByUserName(ProfileAuthenticationOption authenticationOption, string usernameToMatch, DateTime userInactiveSinceDate, int pageIndex, int pageSize, out int totalRecords)
        {

            CheckParameters(pageIndex, pageSize);

            return GetProfileInfo(authenticationOption, usernameToMatch, userInactiveSinceDate, pageIndex, pageSize, out totalRecords);
        }
        public override ProfileInfoCollection GetAllProfiles(ProfileAuthenticationOption authenticationOption, int pageIndex, int pageSize, out int totalRecords)
        {
            CheckParameters(pageIndex, pageSize);

            return GetProfileInfo(authenticationOption, null, null, pageIndex, pageSize, out totalRecords);
        }
        public override ProfileInfoCollection GetAllInactiveProfiles(ProfileAuthenticationOption authenticationOption, DateTime userInactiveSinceDate, int pageIndex, int pageSize, out int totalRecords)
        {
            CheckParameters(pageIndex, pageSize);

            return GetProfileInfo(authenticationOption, null, userInactiveSinceDate, pageIndex, pageSize, out totalRecords);
        }
        public override int GetNumberOfInactiveProfiles(ProfileAuthenticationOption authenticationOption, DateTime userInactiveSinceDate)
        {

            int inactiveProfiles = 0;

            ProfileInfoCollection profiles = GetProfileInfo(authenticationOption, null, userInactiveSinceDate, 0, 0, out inactiveProfiles);

            return inactiveProfiles;
        }
        private static void CheckParameters(int pageIndex, int pageSize)
        {
            if (pageIndex < 1 || pageSize < 1)
                throw new ApplicationException(ERR_INVALID_PARAMETER + " page index.");
        }
        private static ProfileInfoCollection GetProfileInfo(ProfileAuthenticationOption authenticationOption, string usernameToMatch, object userInactiveSinceDate, int pageIndex, int pageSize, out int totalRecords)
        {

            ProfileInfoCollection profiles = new ProfileInfoCollection();

            totalRecords = 0;

            // Count profiles only.
            if (pageSize == 0)
                return profiles;

            int counter = 0;
            int startIndex = pageSize * (pageIndex - 1);
            int endIndex = startIndex + pageSize - 1;

            DateTime dt = new DateTime(1900, 1, 1);
            if (userInactiveSinceDate != null)
                dt = (DateTime)userInactiveSinceDate;

            foreach (CustomProfileInfo profile in dal.GetProfileInfo((int)authenticationOption, usernameToMatch, dt, applicationName, out totalRecords))
            {
                if (counter >= startIndex)
                {
                    ProfileInfo p = new ProfileInfo(profile.UserName, profile.IsAnonymous, profile.LastActivityDate, profile.LastUpdatedDate, 0);
                    profiles.Add(p);
                }

                if (counter >= endIndex)
                {
                    break;
                }

                counter++;
            }

            return profiles;
        }



    }
}
