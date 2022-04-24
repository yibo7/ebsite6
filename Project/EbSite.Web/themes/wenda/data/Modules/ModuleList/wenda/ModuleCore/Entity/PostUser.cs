using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EbSite.Base.Entity;

namespace EbSite.Modules.Wenda.ModuleCore.Entity
{
    /// <summary>
    /// 随机发帖子 用户信息
    /// </summary>
     [Serializable]
    public class PostUser : XmlEntityBase<int>
    {
        private int _userid;
        /// <summary>
        /// 用户id
        /// </summary>
        public int UserID
        {
            get { return _userid; }
            set { _userid = value; }
        }
        private string _username;
        /// <summary>
        /// 用户名称
        /// </summary>
        public string  UserName
        {
            get { return _username; }
            set { _username = value; }
        }
        private string _userniname;
        /// <summary>
        /// 用户昵称
        /// </summary>
        public string UserNiName
        {
            get { return _userniname; }
            set { _userniname = value; }
        }
       
       

    }
}