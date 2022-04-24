namespace EbSite.Base.Modules
{
    using System;

    public class ListItemModel
    {
        private string _ID;
        private string _Text;
        private string _Value;
        public ListItemModel()
        {
        }

        public ListItemModel(string sText, string sValue)
        {

            this._Text = sText;
            this._Value = sValue;
        }

        public ListItemModel(string sID, string sText, string sValue)
        {
            this._ID = sID;
            this._Text = sText;
            this._Value = sValue;
        }
        public string ID
        {
            get
            {
                return this._ID;
            }
            set
            {
                this._ID = value;
            }
        }

        public string Text
        {
            get
            {
                return this._Text;
            }
            set
            {
                this._Text = value;
            }
        }

        public string Value
        {
            get
            {
                return this._Value;
            }
            set
            {
                this._Value = value;
            }
        }
    }
}

