using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EbSite.Base.Entity;
using EbSite.Core.FSO;

namespace EbSite.Widgets.RecommendUsers
{
    public class RecommendUsers: XmlEntityBase<int>
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
        public string UserName
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
    public class RecommendUsersControl : EbSite.Base.Datastore.XMLProviderBaseInt<RecommendUsers>
    {
        public static readonly RecommendUsersControl Instance = new RecommendUsersControl();
        /// <summary>
        /// 重写数据的保存路径-绝对
        /// </summary>
        public override string SavePath
        {
            get
            {
                return HttpContext.Current.Server.MapPath(string.Concat(IISPath, "datastore/RecommendUser/"));               
            }
        }
        private RecommendUsersControl()
        {
            if (!FObject.IsExist(SavePath, FsoMethod.Folder))
            {
                FObject.Create(SavePath, FsoMethod.Folder);
            }
        }
    }
        
}