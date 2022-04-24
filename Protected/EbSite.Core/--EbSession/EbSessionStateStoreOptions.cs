//using System;
//using System.Collections.Generic;
//using System.Diagnostics;
//using System.Linq;
//using System.Text;

//namespace EbSite.Core.EbSession
//{
//    public delegate void DistributedLockNotAcquiredHandler(string sessionId);

//    public class EbSessionStateStoreOptions
//    {
//        private static readonly string defaultKeySeparator = "/";
//        private static readonly int defaultDistributedLockAcquisitionTimeoutSeconds = 1;
//        private static readonly int defaultDistributedLockTimeoutSeconds = 1;
//        private static readonly DistributedLockNotAcquiredHandler defaultOnDistributedLockNotAcquired = sessionId =>
//        {
//            Debug.WriteLine("Session \"{0}\" could not establish distributed lock. " +
//                            "This most likely means you have to increase the " +
//                            "DistributedLockAcquireSeconds/DistributedLockTimeoutSeconds.", sessionId);
//        };

//        public string KeySeparator { get; set; }
//        public int? DistributedLockAcquisitionTimeoutSeconds { get; set; }
//        public int? DistributedLockTimeoutSeconds { get; set; }
//        public DistributedLockNotAcquiredHandler OnDistributedLockNotAcquired { get; set; }

//        public EbSessionStateStoreOptions()
//        {

//        }

//        internal EbSessionStateStoreOptions(EbSessionStateStoreOptions other)
//        {
//            KeySeparator = other.KeySeparator ?? defaultKeySeparator;
//            DistributedLockAcquisitionTimeoutSeconds = other.DistributedLockAcquisitionTimeoutSeconds ?? defaultDistributedLockAcquisitionTimeoutSeconds;
//            DistributedLockTimeoutSeconds = other.DistributedLockTimeoutSeconds ?? defaultDistributedLockTimeoutSeconds;
//            OnDistributedLockNotAcquired = other.OnDistributedLockNotAcquired ?? defaultOnDistributedLockNotAcquired;
//        }
//    }
//}
