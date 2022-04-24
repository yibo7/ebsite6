using System;
using System.Collections.Generic;
using System.Text;

namespace EbSite.Base.ExtWidgets
{
    public class WidGetEntity
    {
        private string _TypeName;
        private string _ReadMe;

        public string TypeName
        {
            get
            {
                return _TypeName;
            }
            set
            {
                _TypeName = value;
            }
        }
        public string ReadMe
        {
            get
            {
                return _ReadMe;
            }
            set
            {
                _ReadMe = value;
            }
        }
    }
}
