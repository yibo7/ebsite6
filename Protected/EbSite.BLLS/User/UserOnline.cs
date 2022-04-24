using System.Collections;
using System.Reflection;
using System.Web;
using System.Web.Security;
using EbSite.Base;
using EbSite.BLL;
using EbSite.Base.Static;
using EbSite.Core;
using EbSite.Data.Interface;
using EbSite.Data.User.Interface;

namespace EbSite.BLL.User
{
    using System;
    using System.Collections.Generic;
    /// <summary>
    /// 实现了IComparable 才能在 List里使用Sort
    /// </summary>
    [Serializable]
    public class UserOnline : BusinessBase<UserOnline, int>, IComparable<UserOnline>
    {
        //private static readonly EbSite.DbProviderCms.GetInstance().UserProfile_User.UserProfile dal = new DbProviderCms.GetInstance().UserProfile_User.UserProfile();
        #region 与实体相关的属性
        //private static object _SyncRoot = new object();
        private static List<UserOnline> _UserOnlines;

        #region Model
        private string _username;
        private string _userniname;
        private string _usergroupname;
        private int _adminid;
        private bool _invisible;
        private string _actioninfo;
        private DateTime _lastsearchtime;
        private DateTime _lastupdatetime;
        private string _weburl;
        private string _verifycode;
        private string _ip;
        private int _userid;
        /// <summary>
        /// 用户ID
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
        /// 用户名称
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
        /// 用户昵称
        /// </summary>
        public string UserNiname
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
        /// 用户组名称，多个用户组用号分开
        /// </summary>
        public string UserGroupName
        {
            set
            {
                if (this._usergroupname != value)
                {
                    this.MarkChanged("usergroupname");
                }
                _usergroupname = value;
            }
            get { return _usergroupname; }
        }
        /// <summary>
        /// 管理员ID
        /// </summary>
        public int AdminID
        {
            set
            {
                if (this._adminid != value)
                {
                    this.MarkChanged("adminid");
                }
                _adminid = value;
            }
            get { return _adminid; }
        }
        /// <summary>
        /// 是否隐身
        /// </summary>
        public bool Invisible
        {
            set
            {
                if (this._invisible != value)
                {
                    this.MarkChanged("invisible");
                }
                _invisible = value;
            }
            get { return _invisible; }
        }
        /// <summary>
        /// 用户当前的活动信息
        /// </summary>
        public string ActionInfo
        {
            set
            {
                if (this._actioninfo != value)
                {
                    this.MarkChanged("actioninfo");
                }
                _actioninfo = value;
            }
            get { return _actioninfo; }
        }
        /// <summary>
        /// 最后搜索内容的时间 
        /// </summary>
        public DateTime LastSearchTime
        {
            set
            {
                if (this._lastsearchtime != value)
                {
                    this.MarkChanged("lastsearchtime");
                }
                _lastsearchtime = value;
            }
            get { return _lastsearchtime; }
        }
        /// <summary>
        /// 最后活动更新的时间,用来判断用户是否已经离线
        /// </summary>
        public DateTime LastUpdateTime
        {
            set
            {
                if (this._lastupdatetime != value)
                {
                    this.MarkChanged("lastupdatetime");
                }
                _lastupdatetime = value;
            }
            get { return _lastupdatetime; }
        }
        /// <summary>
        /// 当前访问的页面地址
        /// </summary>
        public string WebUrl
        {
            set
            {
                if (this._weburl != value)
                {
                    this.MarkChanged("weburl");
                }
                _weburl = value;
            }
            get { return _weburl; }
        }
        /// <summary>
        /// 验证码，目前还不用，discuz有，所以先保留
        /// </summary>
        public string Verifycode
        {
            set
            {
                if (this._verifycode != value)
                {
                    this.MarkChanged("verifycode");
                }
                _verifycode = value;
            }
            get { return _verifycode; }
        }
        /// <summary>
        /// 当前用户的ip
        /// </summary>
        public string Ip
        {
            set
            {
                if (this._ip != value)
                {
                    this.MarkChanged("ip");
                }
                _ip = value;
            }
            get { return _ip; }
        }
        #endregion Model
        #endregion

        #region 构造方法
        public UserOnline()
        {
            //base.Id = Guid.NewGuid();
        }


        #endregion

        #region 对数据的-增-删-查-改

        /// <summary>
        /// 删除某条数据及此数据的子记录
        /// </summary>
        protected override void DataDelete()
        {

            if (IsDeleted)
                DbProviderUser.GetInstance().UserOnline_Delete(this);
            Dispose();
        }

       
        /// <summary>
        /// 插入一条数据
        /// </summary>
        protected override void DataInsert()
        {
            if (IsNew)
            {
                this.Id = DbProviderUser.GetInstance().UserOnline_Insert(this);

              //将当前用户的在线ID写入到客户端cookie
               // EbSite.BLL.User.UserIdentity.WriteUserOnlineID(this.Id.ToString());

              //// 如果id值太大则重建在线表
              //if (this.Id > 2147483000)
              //{
              //    //在线表复位
              //    CreateOnlineTable();
                 
              //}

            }
                
        }
        /// <summary>
        /// 与GetMenu一样，从某个ID获取某个对象,只不过这个从数据库获取GetMenu 在内存里获取
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        protected override UserOnline DataSelect(int id)
        {
            return DbProviderUser.GetInstance().UserOnline_Select(id);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        protected override void DataUpdate()
        {
            if (IsChanged)
                DbProviderUser.GetInstance().UserOnline_Update(this);
        }
        
        #endregion
       
        public static UserOnline GetUser(int id)
        {
            string CacheKey = string.Concat("UserOnlineGetUser-", id);
            UserOnline mdUserOnline = Host.CacheRawApp.GetCacheItem<UserOnline>(CacheKey, "GetUser");// as UserOnline;
            if (Equals(mdUserOnline,null))
            {
                mdUserOnline = DbProviderUser.GetInstance().UserOnline_Select(id);
                if (!Equals(mdUserOnline, null))
                    Host.CacheRawApp.AddCacheItem(CacheKey, mdUserOnline, 10, ETimeSpanModel.FZ, "GetUser");
            }
            return mdUserOnline;
             
        }

        static public int GetCountRegUser()
        {
            return DbProviderUser.GetInstance().UserOnline_GetCountRegUser();
        }
        static public int GetCountGuestUser()
        {
            return DbProviderUser.GetInstance().UserOnline_GetCountGuestUser();
        }
        static public int GetCountAllUser()
        {
            return DbProviderUser.GetInstance().UserOnline_GetCount("");
        }
        static public bool ExistsUser(int olineid)
        {
            return DbProviderUser.GetInstance().UserOnline_ExistsUser(olineid);
        }
        //static public int ExistsUser(string UserName)
        //{
        //    return DbProviderUser.GetInstance().UserOnline_ExistsUser(UserName);
        //}

        /// <summary>
        /// 获取所有在线的注册用户
        /// </summary>
        /// <param name="PageIndex"></param>
        /// <param name="PageSize"></param>
        /// <param name="oderby"></param>
        /// <returns></returns>
       static public List<EbSite.BLL.User.UserOnline> GetRegUser(int PageIndex, int PageSize, string oderby)
       {
           return DbProviderUser.GetInstance().UserOnline_GetRegUser(PageIndex, PageSize, oderby);
       }
        /// <summary>
        /// 获取所有在线的游客
        /// </summary>
        /// <param name="PageIndex"></param>
        /// <param name="PageSize"></param>
        /// <param name="oderby"></param>
        /// <returns></returns>
       static public List<EbSite.BLL.User.UserOnline> GetGuestUser(int PageIndex, int PageSize, string oderby)
        {
            return DbProviderUser.GetInstance().UserOnline_GetGuestUser(PageIndex, PageSize, oderby);
        }
        /// <summary>
       /// 获取所有的线用户
        /// </summary>
        /// <param name="PageIndex"></param>
        /// <param name="PageSize"></param>
        /// <param name="oderby"></param>
        /// <returns></returns>
       static public List<EbSite.BLL.User.UserOnline> GetAllUser(int PageIndex, int PageSize, string oderby)
        {
            return DbProviderUser.GetInstance().UserOnline_GetAllUser(PageIndex, PageSize, oderby);
        }
        //static public TimeSpan GetOnlineTimeSpan
        //{
        //    get
        //    {
        //        TimeSpan ts;
        //        //过期方式,0.天，1小时,2分钟
        //        int OnlineTimeSpanModel = Base.Configs.UserSetConfigs.ConfigsControl.Instance.OnlineTimeSpanModel;
        //        int OnlineTimeSpan = Base.Configs.UserSetConfigs.ConfigsControl.Instance.OnlineTimeSpan; 
        //        if (OnlineTimeSpanModel == 0)
        //        {
        //            ts = new TimeSpan(OnlineTimeSpan, 0, 0);
        //        }
        //        else if (OnlineTimeSpanModel == 1)
        //        {
        //            ts = new TimeSpan(0, OnlineTimeSpan, 0);
        //        }
        //        else if (OnlineTimeSpanModel == 2)
        //        {
        //            ts = new TimeSpan(0, 0, OnlineTimeSpan);
        //        }
        //        else
        //        {
        //            ts = new TimeSpan(0, Membership.UserIsOnlineTimeWindow, 0);
        //        }
        //        return ts;
        //    }
        //}
       // /// <summary>
       ///// 执行一次过期用户清理工作
       // /// </summary>
       //static public void DeleteExpiredOnlineUsers()
       //{
       //    DbProviderUser.GetInstance().DeleteExpiredOnlineUsers();
       //}
        /// <summary>
       /// 复位在线表，主要考虑到在线ID的不断增加，过多时需要复位一下 自动动ID大于2147483000
        /// </summary>
        /// <returns></returns>
       //static public int CreateOnlineTable()
       //{
       //    return DbProviderUser.GetInstance().CreateOnlineTable();
       //}
        
       // /// <summary>
       // /// 添加一个游客到在线用户表
       // /// </summary>
       //static public int CreateGuestUser()
       // {
       //     UserOnline mdGuest = new UserOnline();

       //     mdGuest.UserName = "游客";
       //     mdGuest.UserNiname = "游客";
       //     mdGuest.ActionInfo = "";
       //     mdGuest.AdminID = 0;
       //     mdGuest.Invisible = false;
       //     mdGuest.Ip = Core.Utils.GetClientIP();
       //     mdGuest.LastSearchTime = new DateTime(1900,1,1);
       //     mdGuest.LastUpdateTime = DateTime.Now;
       //     mdGuest.UserGroupName = "";
       //     mdGuest.Verifycode = Utils.CreateAuthStr(5, false);
       //     if (HttpContext.Current!=null)
       //     {
       //         if (HttpContext.Current.Request.UrlReferrer!=null)
       //         {
       //             mdGuest.WebUrl = HttpContext.Current.Request.UrlReferrer.AbsoluteUri;
       //         }
       //         else
       //         {
       //             mdGuest.WebUrl = HttpContext.Current.Request.RawUrl;
       //         }
                
       //     }
            

       //     mdGuest.Save();

       //     return mdGuest.Id;
            
       // }
       // /// <summary>
       // /// 添加一个已经登录的用户到的线表
       // /// </summary>
       //static public int CreateRegUser()
       // {
       //     //UserCustomField UCF = UserCustomField.GetUserCustomField(EbSite.Base.AppStartInit.UserName);

       //     UserOnline mdReg = new UserOnline();

       //     mdReg.UserID = AppStartInit.UserID;// UCF.Id;
       //     mdReg.UserName = AppStartInit.UserName;//UCF.UserName;
       //     mdReg.UserNiname = AppStartInit.UserNiName;//UCF.NiName;
       //     mdReg.ActionInfo = "";
       //     mdReg.AdminID = 0;
       //     mdReg.Invisible = false;
       //     mdReg.Ip = Core.Utils.GetClientIP();
       //     mdReg.LastSearchTime = new DateTime(1900, 1, 1);
       //     mdReg.LastUpdateTime = DateTime.Now;
       //     mdReg.UserGroupName = "";
       //     mdReg.Verifycode = Utils.CreateAuthStr(5, false);
       //     if (!Equals(HttpContext.Current, null))
       //     {
       //         mdReg.WebUrl = HttpContext.Current.Request.RawUrl;
       //         //mdReg.WebUrl = HttpContext.Current.Request.UrlReferrer.AbsoluteUri;
       //     }
            

       //     mdReg.Save();

       //     return mdReg.Id;
       // }

       ///// <summary>
       ///// 更新一个当前在线用户的信息
       ///// </summary>
       //static public int UpdateCurrentOnlineUser()
       //{
       //    //最好还要写个最后更新cookie,在指定时间内才更新一次，减少系统负载（以后完成）

       //    int iOnlineID = EbSite.Base.Host.Instance.OnlineID;
       //    UserOnline mdGuest = GetUser(iOnlineID);

       //    if (!Equals(mdGuest, null))
       //    {
       //        mdGuest.UserID = AppStartInit.UserID;
       //        mdGuest.UserName = string.IsNullOrEmpty(AppStartInit.UserName) ? "游客" : AppStartInit.UserName;
       //        mdGuest.UserNiname = string.IsNullOrEmpty(AppStartInit.UserNiName) ? "游客" : AppStartInit.UserNiName;
       //        mdGuest.ActionInfo = "";
       //        mdGuest.AdminID = 0;
       //        mdGuest.Invisible = false;
       //        mdGuest.Ip = Core.Utils.GetClientIP();
       //        mdGuest.LastSearchTime = new DateTime(1900, 1, 1);
       //        mdGuest.LastUpdateTime = DateTime.Now;
       //        mdGuest.UserGroupName = "";
       //        mdGuest.Verifycode = Utils.CreateAuthStr(5, false);
       //        if (!Equals(HttpContext.Current, null))
       //        {
       //            if (!Equals(HttpContext.Current.Request.UrlReferrer, null))
       //            {
       //                mdGuest.WebUrl = HttpContext.Current.Request.UrlReferrer.AbsoluteUri;
       //            }
                       
       //            else
       //            {
       //                mdGuest.WebUrl = HttpContext.Current.Request.RawUrl;
       //            }
       //        }

       //        mdGuest.Save();

       //        return mdGuest.Id;
       //    }

       //    return 0;
       //}

        //public static bool IsTimeOut 
        //{ 
        //    get
        //    {
        //        string key = "uoltime";
        //        bool isout = true;
               

        //        string uoltime = Core.Utils.GetCookie(key);

        //        if (!string.IsNullOrEmpty(uoltime))
        //        {
        //            isout = false;
                    
        //        }
        //        else
        //        {
        //            //过期方式,0.天，1小时,2分钟
        //            int OnlineTimeSpanModel = Base.Configs.UserSetConfigs.ConfigsControl.Instance.OnlineTimeSpanModel;
        //            int OnlineTimeSpan = Base.Configs.UserSetConfigs.ConfigsControl.Instance.OnlineTimeSpan;
        //            if (OnlineTimeSpan > 1)
        //            {
        //                OnlineTimeSpan = OnlineTimeSpan - 1;//将他早点过期
        //            }
        //            if (OnlineTimeSpanModel == 0)
        //            {
        //                Core.Utils.WriteCookie(key, "1", OnlineTimeSpan, ETimeSpanModel.T);
        //            }
        //            else if (OnlineTimeSpanModel == 1)
        //            {
        //                Core.Utils.WriteCookie(key, "1", OnlineTimeSpan, ETimeSpanModel.XS);
        //            }
        //            else if (OnlineTimeSpanModel == 2)
        //            {
        //                Core.Utils.WriteCookie(key, "1", OnlineTimeSpan, ETimeSpanModel.FZ);
        //            }
                    
        //        }

        //        return isout;
        //    }
        //}

         
       // /// <summary>
       // /// 最后的删除过期用户时间
       // /// </summary>
       // private static int _lastRemoveTimeout;
       // /// <summary>
       // /// 删除过期用户频率(单位:分钟)
       // /// </summary>
       // private static int deletingFrequency = 5;
       // /// <summary>
       ///// 检测当前用户是否的线，并更新在线信息
       ///// </summary>
       //static public void SetUserOnline()
       //{
       //     lock (_SyncRoot)
       //     {
       //         if (Base.Configs.UserSetConfigs.ConfigsControl.Instance.OnlineTimeSpan > 0)//是否开户在线用户统计
       //         {
       //             if (IsTimeOut)//只有当前用户活动时间甚至再更新一次，没必要每次请求都更新
       //             {

       //                 #region 执行一次更新操作
       //                 int iUserID = EbSite.Base.AppStartInit.UserID;
       //                 if (iUserID > 0) //当前用户已经登录
       //                 {

       //                     if (EbSite.Base.Host.Instance.OnlineID > 0)  //说明当前游客已经添加到用户在线表里,这个时候只要更新当前用户的一些活信息就行
       //                     {
       //                         if (ExistsUser(EbSite.Base.Host.Instance.OnlineID))
       //                         {
       //                             UpdateCurrentOnlineUser();
       //                         }
       //                         else
       //                         {
       //                             int uolid = ExistsUserID(iUserID);
       //                             if (uolid > 0)
       //                             {
       //                                 //将当前用户的在线ID写入到客户端cookie
       //                                 UserIdentity.WriteUserOnlineID(uolid.ToString());
       //                                 UpdateCurrentOnlineUser();
       //                             }
       //                             else
       //                             {
       //                                 CreateRegUser();
       //                             }

       //                         }

       //                     }
       //                     else  //完全添加一个新的在线用户
       //                     {
       //                         CreateRegUser();
       //                     }


       //                     //检测的线用户表里是否已经存在当前用户
       //                 }
       //                 else //当前用户是游客
       //                 {
       //                     if (EbSite.Base.Host.Instance.OnlineID > 0)  //说明当前游客已经添加到用户在线表里,这个时候只要更新当前用户的一些活信息就行
       //                     {
       //                         if (ExistsUser(EbSite.Base.Host.Instance.OnlineID))
       //                         {
       //                             UpdateCurrentOnlineUser();
       //                         }
       //                         else
       //                         {
       //                             CreateGuestUser();
       //                         }

       //                     }
       //                     else  //完全添加一个新的在线用户
       //                     {

       //                         CreateGuestUser();

       //                     }
       //                 }

       //                 #endregion

       //                 #region

       //                 //按照系统设置频率(默认5分钟)清除过期用户
       //                 if (_lastRemoveTimeout == 0 || (System.Environment.TickCount - _lastRemoveTimeout) > 60000 * deletingFrequency)
       //                 {
       //                     DeleteExpiredOnlineUsers();
       //                     _lastRemoveTimeout = System.Environment.TickCount;
       //                 }
       //                 #endregion

       //             }

       //         }
       //     }
            
       //}
       /// <summary>
       /// 用户头像-小
       /// </summary>
       public string AvatarSmall
       {
           get
           {

               return Base.Host.Instance.EBMembershipInstance.GetAvatarFileName(this.UserID, 3);
           }

       }
       /// <summary>
       /// 用户头像-小
       /// </summary>
       public string AvatarMid
       {
           get
           {
               return Base.Host.Instance.EBMembershipInstance.GetAvatarFileName(this.UserID, 2);
           }

       }
       /// <summary>
       /// 用户头像-大
       /// </summary>
       public string AvatarBig
       {
           get
           {
               return Base.Host.Instance.EBMembershipInstance.GetAvatarFileName(this.UserID, 1);
           }

       }
        /// <summary>
        /// 验证规则
        /// </summary>
        protected override void ValidationRules()
        {
            this.AddRule("UserName", "必须设置用户名称", string.IsNullOrEmpty(this.UserName));
        }

        /// <summary>
        /// 重写ToString()
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.UserName;
        }
        /// <summary>
        /// 是否在线
        /// </summary>
        /// <param name="UserID"></param>
        /// <returns></returns>
      static  public bool  IsOnline(int UserID)
      {
          return ExistsUserID(UserID)>0;
      }
        /// <summary>
        /// 获取一个用户的在线ID
        /// </summary>
        /// <param name="UserID"></param>
        /// <returns></returns>
      static public int ExistsUserID(int UserID)
      {
          return DbProviderUser.GetInstance().UserOnline_ExistsUserID(UserID);
      }

        #region 实现IComparable接口,以便在List里可以使用Sort对orderid 进行排序
        /// <summary>
        /// 按orderid的降序来排序,实现这个方法，可以让List.Sort(),按这个比较大小来排序
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public int CompareTo(UserOnline other)
        {

            return this.Id.CompareTo(other.Id);
        }

        #endregion



    }



}

