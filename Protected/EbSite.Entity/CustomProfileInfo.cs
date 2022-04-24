using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace EbSite.Entity
{
    /// <summary>
    /// Business entity used to model a profile
    /// </summary>
    [Serializable]
    //[DataContract]
    //[KnownType(typeof(CustomProfileInfo))]
    public class CustomProfileInfo
    {

        // Internal member variables
        private string userName;
        private DateTime lastActivityDate;
        private DateTime lastUpdatedDate;
        private bool isAnonymous;

        /// <summary>
        /// Default constructor
        /// </summary>
        public CustomProfileInfo()
        {
        }

        /// <summary>
        /// Constructor with specified initial values
        /// </summary>
        /// <param name="userName">User Name</param>
        /// <param name="lastActivityDate">Last activity date</param>
        /// <param name="lastUpdatedDate">Last update date</param>
        /// <param name="isAnonymous">True if user is authenticated</param>
        public CustomProfileInfo(string userName, DateTime lastActivityDate, DateTime lastUpdatedDate, bool isAnonymous)
        {
            this.userName = userName;
            this.lastActivityDate = lastActivityDate;
            this.lastUpdatedDate = lastUpdatedDate;
            this.isAnonymous = isAnonymous;
        }

        // Properties
        //[DataMember]
        public string UserName
        {
            get
            {
                return userName;
            }
        }
        //[DataMember]
        public DateTime LastActivityDate
        {
            get
            {
                return lastActivityDate;
            }
        }
        //[DataMember]
        public DateTime LastUpdatedDate
        {
            get
            {
                return lastUpdatedDate;
            }
        }
        //[DataMember]
        public bool IsAnonymous
        {
            get
            {
                return isAnonymous;
            }
        }
    }
}
