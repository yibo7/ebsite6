using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EbSite.Base.PageLink;

namespace EbSite.Base.EntityAPI
{
    [Serializable]
    public class UserGroupProfileShort
    {
        public string GroupName { get; set; }
        public string ManageIndex { get; set; }
        //private string _ManageIndex;
        //public string ManageIndex
        //{
        //    get
        //    {
        //        if (string.IsNullOrEmpty(_ManageIndex))
        //        {
        //            return GetBaseLinks.Get(Base.Host.Instance.GetSiteID).UccIndexRw;
        //        }
        //        return _ManageIndex;
        //    }
        //    set { _ManageIndex = value; }
        //}
        public string ManageIndexMaster { get; set; }
        public string WebSiteIndex { get; set; }
        /// <summary>
        /// guid类型，为了减少转换，这直接保存为字符串
        /// </summary>
        public string UserModelID { get; set; }
    }
}
