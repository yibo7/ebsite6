using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EbSite.Base.EntityAPI
{
    [Serializable]
    public class ListItemSimple 
    {
        public ListItemSimple()
        {
        }

        public ListItemSimple(string sText, string sValue)
        {

            this._Text = sText;
            this._Value = sValue;
        }


        private string _Text;
        private string _Value;
        public string Text
        {
            get
            {
                return _Text;
            }
            set
            {
                _Text = value;
            }
        }

        public string Value
        {
            get
            {
                return _Value;
            }
            set
            {
                _Value = value;
            }
        }
       
    }
}
