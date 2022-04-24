using System;

namespace EbSite.BLL
{
    public class KeyValueModel
    {
        private string _Key;
        private string _Name;


        public string Name
        {
            get
            {
                return _Name;
            }
            set
            {
                _Name = value;
            }
        }
        public string Key
        {
            get
            {
                return _Key;
            }
            set
            {
                _Key = value;
            }
        }
    }
}
