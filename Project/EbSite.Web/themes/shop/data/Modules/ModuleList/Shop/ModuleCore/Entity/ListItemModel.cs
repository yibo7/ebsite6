using System;
using System.Collections.Generic;
using System.Text;

namespace EbSite.Modules.Shop.ModuleCore.Entity
{
    public class ListItemModel
    {
        public ListItemModel()
        {
        }

        public ListItemModel(string sText, string sValue)
        {
          
            this._Text = sText;
            this._Value = sValue;
        }

        public ListItemModel(string sID,string sText,string sValue)
        {
            this._ID = sID;
            this._Text = sText;
            this._Value = sValue;
        }
        private string _ID;
        public string ID
        {
            get
            {
                return _ID;
            }
            set
            {
                _ID = value;
            }
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
