using System;
using System.Collections.Generic;
using System.Text;

namespace EbSite.Entity
{
    [Serializable]
    public class ListItemModel : EbSite.Base.EntityAPI.ListItemModel
    {
        public ListItemModel()
        {
        }

        public ListItemModel(string sText, string sValue)
            : base(sText, sValue)
        {

         
        }

        public ListItemModel(string sID, string sText, string sValue)
            : base(sID, sText, sValue)
        {
           
        }
        //private string _ID;
        //public string ID
        //{
        //    get
        //    {
        //        return _ID;
        //    }
        //    set
        //    {
        //        _ID = value;
        //    }
        //}

        //private string _Text;
        //private string _Value;
        //public string Text
        //{
        //    get
        //    {
        //        return _Text;
        //    }
        //    set
        //    {
        //        _Text = value;
        //    }
        //}

        //public string Value
        //{
        //    get
        //    {
        //        return _Value;
        //    }
        //    set
        //    {
        //        _Value = value;
        //    }
        //}
       
    }
}
