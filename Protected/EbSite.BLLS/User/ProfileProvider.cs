using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EbSite.Data.User.Interface;
using EbSite.Entity;

namespace EbSite.BLL.User
{
    public class ProfileProvider
    {
        
        static public void UpdateActivityDates(string userName, bool activityOnly, string appName)
        {
            DbProviderUser.GetInstance().UpdateActivityDates(userName, activityOnly, appName);
        }
       
        static public int GetUniqueID(string userName, bool isAuthenticated, bool ignoreAuthenticationType, string appName)
        {
           return DbProviderUser.GetInstance().GetUniqueID(userName, isAuthenticated, ignoreAuthenticationType, appName);
        }

        static public int CreateProfileForUser(string userName, bool isAuthenticated, string appName)
        {
            return DbProviderUser.GetInstance().CreateProfileForUser(userName, isAuthenticated, appName);
        }

      
        static public IList<string> GetInactiveProfiles(int authenticationOption, DateTime userInactiveSinceDate, string appName)
        {
            return DbProviderUser.GetInstance().GetInactiveProfiles(authenticationOption, userInactiveSinceDate, appName);
        }

      
       static  public bool DeleteProfile(string userName, string appName)
       {
           return DbProviderUser.GetInstance().DeleteProfile(userName, appName);
       }

       static public bool DeleteProfile(int iUid)
       {
           return DbProviderUser.GetInstance().DeleteProfile(iUid);
       }
       static public  IList<CustomProfileInfo> GetProfileInfo(int authenticationOption, string usernameToMatch, DateTime userInactiveSinceDate, string appName, out int totalRecords)
       {
           return DbProviderUser.GetInstance().GetProfileInfo(authenticationOption, usernameToMatch, userInactiveSinceDate, appName, out  totalRecords);
       }
    }
}
