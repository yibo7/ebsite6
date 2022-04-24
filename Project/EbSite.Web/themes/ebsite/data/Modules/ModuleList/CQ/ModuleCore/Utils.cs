using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EbSite.Base.EntityCustom;

namespace EbSite.Modules.CQ.ModuleCore
{

    public class OrderBoxGetEbClassListEventArgs : EventArgs
    {
        public bool IsStop { get; set; }
        public int StepType { get; set; }
        public string ParentID { get; set; }
        public int StepID { get; set; }
        public List<TreeItem> CustomList = null;
        public OrderBoxGetEbClassListEventArgs(string _ParentID, int _StepType, int _StepID)
        {
            StepType = _StepType;
            ParentID = _ParentID;
            StepID = _StepID;

        }
    }



    public class Utils
    {
        #region 订单宝流程载入时触发
        public static event EventHandler<OrderBoxGetEbClassListEventArgs> OrderBoxGetEbClassListing;
        public static void OnOrderBoxGetEbClassList(object sender, OrderBoxGetEbClassListEventArgs arg)
        {
            if (OrderBoxGetEbClassListing != null)
            {
                OrderBoxGetEbClassListing(sender, arg);
            }
        }
        #endregion
    }
}