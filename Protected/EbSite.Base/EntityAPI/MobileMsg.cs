using System;
using System.Collections.Generic;
using System.Text;

namespace EbSite.Base.EntityAPI
{
    [Serializable]
    public class MobileMsg
    {
        private string _UserName;
        private string _MobileNumber;
        private string _Msg;
        private DateTime _SendDate;
        private long _Id;

        public long Id
        {
            get
            {
                return _Id;
            }
            set
            {
                _Id = value;
            }
        }
        public string UserName
        {
            get
            {
                return _UserName;
            }
            set
            {
                _UserName = value;
            }
        }
        public string MobileNumber
        {
            get
            {
                return _MobileNumber;
            }
            set
            {
                _MobileNumber = value;
            }
        }
        public string Msg
        {
            get
            {
                return _Msg;
            }
            set
            {
                _Msg = value;
            }
        }
        public DateTime SendDate
        {
            get
            {
                return _SendDate;
            }
            set
            {
                _SendDate = value;
            }
        }

    }
}
