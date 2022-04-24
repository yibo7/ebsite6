using System;
using System.Data;
using System.Collections.Generic;
using EbSite.Base;
using EbSite.Data.Interface;

namespace EbSite.BLL
{
	/// <summary>
	/// 业务逻辑类EB_FriendList 的摘要说明。
	/// </summary>
    public class FriendList : BusinessBase<FriendList, int>
	{
        #region Model
        private string _username;
        private string _friendname;
        private bool _isallow;
        private DateTime _adddate;
        private int _userid;
        private string _userniname;
        private int _friendid;
        private string _friendniname;
        /// <summary>
        /// 
        /// </summary>
        public int UserID
        {
            set
            {
                if (this._userid != value)
                {
                    this.MarkChanged("userid");
                }
                _userid = value;
            }
            get { return _userid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string UserNiName
        {
            set
            {
                if (this._userniname != value)
                {
                    this.MarkChanged("userniname");
                }
                _userniname = value;
            }
            get { return _userniname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int FriendID
        {
            set
            {
                if (this._friendid != value)
                {
                    this.MarkChanged("friendid");
                }
                _friendid = value;
            }
            get { return _friendid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string FriendNiName
        {
            set
            {
                if (this._friendniname != value)
                {
                    this.MarkChanged("friendniname");
                }
                _friendniname = value;
            }
            get { return _friendniname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string UserName
        {
            set
            {
                if (this._username != value)
                {
                    this.MarkChanged("username");
                } 
                _username = value;
            }
            get { return _username; }
        }
        
        /// <summary>
        /// 
        /// </summary>
        public string FriendName
        {
            set
            {
                if (this._friendname != value)
                {
                    this.MarkChanged("friendname");
                }
                _friendname = value;
            }
            get { return _friendname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool IsAllow
        {
            set
            {
                if (this._isallow != value)
                {
                    this.MarkChanged("isallow");
                }
                _isallow = value;
            }
            get { return _isallow; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime AddDate
        {
            set
            {
                if (this._adddate != value)
                {
                    this.MarkChanged("adddate");
                }
                _adddate = value;
            }
            get { return _adddate; }
        }
        #endregion Model
		
		public  FriendList() 
		{}
        /// <summary>
        /// 增加一条数据
        /// </summary>
        protected override void DataInsert()
        {
            if (IsNew)
             DbProviderCms.GetInstance().FriendList_Add(this);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        protected override void DataUpdate()
        {
            if (this.IsChanged)
            {
                
                DbProviderCms.GetInstance().FriendList_Update(this);

            }
           
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        protected override void DataDelete()
        {
            if (IsDeleted)
                DbProviderCms.GetInstance().FriendList_Delete(this.Id);
            Dispose();

           
        }

	   static public  void DataDelete(int id)
        {
            DbProviderCms.GetInstance().FriendList_Delete(id);
	    }

	    protected override FriendList DataSelect(int id)
        {
            return null;
        }
        /// <summary>
        /// 验证规则
        /// </summary>
        protected override void ValidationRules()
        {
            this.AddRule("UserID", "必须设置用户ID", this.UserID<1);
        }

		#region  成员方法
        /// <summary>
        /// 好友的昵称
        /// </summary>
        //public string FriendNiName
        //{
            
        //    get {
        //        return BLL.User.UserCustomField.GetUserCustomField(this.FriendName).NiName;
        //    }
        //}
		/// <summary>
		/// 得到最大ID
		/// </summary>
	   static  public int GetMaxId()
		{
            return DbProviderCms.GetInstance().FriendList_GetMaxId();
		}

       /// <summary>
       /// 判断是否已经存在好友关系
       /// </summary>
       /// <param name="UserID">当前用户ID</param>
       /// <param name="FriendID">好友ID</param>
       /// <returns>0为不存在好友关系，1两人已经是好友,2对方已经邀请你,3邀请你已经邀请过对方</returns>
       static public int Exists(int UserID, int FriendID)
		{
            return DbProviderCms.GetInstance().FriendList_Exists(UserID, FriendID);
		}

		

		

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
        static public FriendList GetModel(int id)
		{
            return DbProviderCms.GetInstance().FriendList_GetModel(id);
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		static public List<FriendList> GetList(string strWhere)
		{
		   return DbProviderCms.GetInstance().FriendList_GetList(0, strWhere, "");
		}
        /// <summary>
        /// 获得我的好友，注意，我加的朋友与朋友加我这种都是好友,所以要做一下处理
        /// </summary>
        static public List<FriendList> GetList_All(int  UserID)
        {

            return GetList_All(UserID, 0); 
        }

        ///// <summary>
        ///// 获得我的好友，注意，我加的朋友与朋友加我这种都是好友,所以要做一下处理
        ///// </summary>
        //static public List<FriendList> GetList_All(string UserName,int top)
        //{

        //    List<FriendList> lst = DbProviderCms.GetInstance().FriendList_GetList(top, string.Concat(" (UserName ='", UserName, "' or FriendName='", UserName, "')   "), "",1);
           
        //    foreach (FriendList md in lst)
        //    {
        //        if (Equals(md.FriendName, UserName))
        //        {
                    
        //            md.FriendName = md.UserName;
        //            md.UserName = UserName;

        //        }
               
        //    }

        //    return lst;

        //}


        static public List<FriendList> GetList_All(int UserID, int top)
        {

            //List<FriendList> lst = DbProviderCms.GetInstance().FriendList_GetList(top, string.Concat(" UserID =", UserID, " or (FriendID=", UserID, " and IsAllow=1)  "), "");
            List<FriendList> lst = DbProviderCms.GetInstance().FriendList_GetList(top, string.Concat(" UserID =", UserID), "", 1);
            foreach (FriendList md in lst)
            {
                if (Equals(md.FriendID, UserID))
                {

                    md.FriendName = md.UserName;
                    md.UserName = md.UserName;

                }

            }

            return lst;

        }
        /// <summary>
        /// 通过朋友邀请
        /// </summary>
        /// <returns></returns>
       public bool Allow()
       {
           return DbProviderCms.GetInstance().FriendList_Allow(this);
       }

        /// <summary>
        /// 等待我确认的好友   + "' or FriendName='",UserName
        /// </summary>
        /// <param name="UserName"></param>
        /// <returns></returns>
        static public List<FriendList> GetList_ByMyAllow(int UserID)
        {
            return DbProviderCms.GetInstance().FriendList_GetList(0, string.Concat("UserID =" , UserID ),"",0);
        }
        ///// <summary>
        /////  等待确认我的好友
        ///// </summary>
        ///// <param name="UserName"></param>
        ///// <returns></returns>
        //static public List<FriendList> GetList_ByFriendAllow(string UserName)
        //{
        //    return DbProviderCms.GetInstance().FriendList_GetList(0, string.Concat("FriendName ='" + UserName + "' and IsAllow=0"), "");
        //}
        /// <summary>
        /// 用户头像-小
        /// </summary>
        public string AvatarSmall
        {
            get
            {
                return BLL.User.MembershipUserEb.Instance.GetAvatarFileName(this.FriendID, 3);
            }

        }
        /// <summary>
        /// 用户头像-小
        /// </summary>
        public string AvatarMid
        {
            get
            {
                return BLL.User.MembershipUserEb.Instance.GetAvatarFileName(this.FriendID, 2);
            }

        }
        /// <summary>
        /// 用户头像-大
        /// </summary>
        public string AvatarBig
        {
            get
            {
                return BLL.User.MembershipUserEb.Instance.GetAvatarFileName(this.FriendID, 1);
            }

        }
        /// <summary>
        /// 是否在线
        /// </summary>
        public bool IsOnline
        {
            get { return EbSite.Base.Host.Instance.IsOnline(this.FriendID); }

        }
		
		#endregion  成员方法
	}
}

