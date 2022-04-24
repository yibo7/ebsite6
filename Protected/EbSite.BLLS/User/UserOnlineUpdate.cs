using System.Collections;
using System.Reflection;
using System.Web;
using System.Web.Security;
using EbSite.Base;
using EbSite.BLL;
using EbSite.Base.Static;
using EbSite.BLL.HttpHandlers;
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
     
    public class UserOnlineUpdate
    {
        private int OnlineID = 0;
        private int UserId = 0;
        private HttpContext httpContext;
        private string UserName = string.Empty;
        private string UserNiName = string.Empty;
        private string UserGroupName = string.Empty;
        private int  AdminId = 0;
        private string Ip = string.Empty;
        public UserOnlineUpdate(HttpContext _httpContext, int _OnlineID,int _UserId,string _UserName,string _UserNiName,string _UserGroupName,int _AdminId, string _Ip)
        {
            httpContext = _httpContext;
            OnlineID = _OnlineID;
            UserId = _UserId;
            UserName = _UserName;
            UserNiName = _UserNiName;
            UserGroupName = _UserGroupName;
            AdminId = _AdminId;
            Ip = _Ip;
        }

        private TimeSpan GetOnlineTimeSpan
        {
            get
            {
                TimeSpan ts;
                //过期方式,0.天，1小时,2分钟
                int OnlineTimeSpanModel = Base.Configs.UserSetConfigs.ConfigsControl.Instance.OnlineTimeSpanModel;
                int OnlineTimeSpan = Base.Configs.UserSetConfigs.ConfigsControl.Instance.OnlineTimeSpan; 
                if (OnlineTimeSpanModel == 0)
                {
                    ts = new TimeSpan(OnlineTimeSpan, 0, 0);
                }
                else if (OnlineTimeSpanModel == 1)
                {
                    ts = new TimeSpan(0, OnlineTimeSpan, 0);
                }
                else if (OnlineTimeSpanModel == 2)
                {
                    ts = new TimeSpan(0, 0, OnlineTimeSpan);
                }
                else
                {
                    ts = new TimeSpan(0, Membership.UserIsOnlineTimeWindow, 0);
                }
                return ts;
            }
        }
        /// <summary>
       /// 执行一次过期用户清理工作
        /// </summary>
        private void DeleteExpiredOnlineUsers()
       {
             
           DbProviderUser.GetInstance().DeleteExpiredOnlineUsers(GetOnlineTimeSpan);
       }
        
        
        ///// <summary>
        ///// 添加一个游客到在线用户表
        ///// </summary>
        //public int CreateGuestUser()
        //{
        //    UserOnline mdGuest = new UserOnline();

        //    mdGuest.UserName = "游客";
        //    mdGuest.UserNiname = "游客";
        //    mdGuest.ActionInfo = "";
        //    mdGuest.AdminID = AdminId;
        //    mdGuest.Invisible = false;
        //    mdGuest.Ip = Core.Utils.GetClientIP(httpContext);
        //    mdGuest.LastSearchTime = new DateTime(1900,1,1);
        //    mdGuest.LastUpdateTime = DateTime.Now;
        //    mdGuest.UserGroupName = UserGroupName;
        //    mdGuest.Verifycode = Utils.CreateAuthStr(5, false);

        //    if (httpContext.Request.UrlReferrer != null)
        //    {
        //        mdGuest.WebUrl = httpContext.Request.UrlReferrer.AbsoluteUri;
        //    }
        //    else
        //    {
        //        mdGuest.WebUrl = httpContext.Request.RawUrl;
        //    }

        //    mdGuest.Save();

        //    return mdGuest.Id;
            
        //}
        /// <summary>
        /// 添加一个已经登录的用户到的线表
        /// </summary>
        private int CreateRegUser()
        {
            
            UserOnline mdReg = new UserOnline();

            mdReg.UserID = UserId; 
            mdReg.UserName = UserId>0?UserName: "游客"; 
            mdReg.UserNiname = UserId > 0 ? UserName : "游客";
            mdReg.ActionInfo = "";
            mdReg.AdminID = AdminId;
            mdReg.Invisible = false;
            mdReg.Ip = Ip;// Core.Utils.GetClientIP(httpContext);
            mdReg.LastSearchTime = new DateTime(1900, 1, 1);
            mdReg.LastUpdateTime = DateTime.Now;
            mdReg.UserGroupName = UserGroupName;
            mdReg.Verifycode = Utils.CreateAuthStr(5, false);
            //mdReg.WebUrl = httpContext.Request.RawUrl;

            if (httpContext.Request.UrlReferrer != null)
            {
                mdReg.WebUrl = httpContext.Request.UrlReferrer.AbsoluteUri;
            }
            else
            {
                mdReg.WebUrl = httpContext.Request.RawUrl;
            }

            mdReg.Save();

            // 如果id值太大则重建在线表
            if (mdReg.Id > 2147483000)
            {
                //在线表复位
                CreateOnlineTable();

            }
            //将当前用户的在线ID写入到客户端cookie
            UserIdentity.WriteUserOnlineID(mdReg.Id.ToString(), httpContext);
            return mdReg.Id;
        }

        /// <summary>
        /// 获取一个在线用户
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>UserOnline.</returns>
        private UserOnline GetUser(int id)
        {
            UserOnline mdUserOnline = DbProviderUser.GetInstance().UserOnline_Select(id);
            return mdUserOnline;

        }
        /// <summary>
        /// 复位在线表，主要考虑到在线ID的不断增加，过多时需要复位一下 自动动ID大于2147483000
        /// </summary>
        /// <returns></returns>
        private int CreateOnlineTable()
        {
            return DbProviderUser.GetInstance().CreateOnlineTable();
        }
        /// <summary>
        /// 更新一个当前在线用户的信息
        /// </summary>
        private int UpdateCurrentOnlineUser(int CurrentOnlineID)
       {
           //最好还要写个最后更新cookie,在指定时间内才更新一次，减少系统负载（以后完成）

          
           UserOnline mdGuest = GetUser(CurrentOnlineID);

           if (!Equals(mdGuest, null))
           {
               mdGuest.UserID = UserId;
               mdGuest.UserName = UserId > 0 ? UserName : "游客"; //string.IsNullOrEmpty(AppStartInit.UserName) ? "游客" : AppStartInit.UserName;
               mdGuest.UserNiname = UserId > 0 ? UserName : "游客"; //string.IsNullOrEmpty(AppStartInit.UserNiName) ? "游客" : AppStartInit.UserNiName;
               mdGuest.ActionInfo = "";
               mdGuest.AdminID = AdminId;
               mdGuest.Invisible = false;
               mdGuest.Ip = Ip;// Core.Utils.GetClientIP(httpContext);
               mdGuest.LastSearchTime = new DateTime(1900, 1, 1);
               mdGuest.LastUpdateTime = DateTime.Now;
               mdGuest.UserGroupName = "";
               mdGuest.Verifycode = Utils.CreateAuthStr(5, false);

                if (!Equals(httpContext.Request.UrlReferrer, null))
                {
                    mdGuest.WebUrl = httpContext.Request.UrlReferrer.AbsoluteUri;
                }
                else
                {
                    mdGuest.WebUrl = httpContext.Request.RawUrl;
                }

                mdGuest.Save();
                //将当前用户的在线ID写入到客户端cookie
                UserIdentity.WriteUserOnlineID(mdGuest.Id.ToString(), httpContext);
                return mdGuest.Id;
           }

           return 0;
       }

        private bool IsTimeOut 
        { 
            get
            {
                string key = "uoltime";
                bool isout = true;
               

                string uoltime = Core.Utils.GetCookie(key, httpContext);

                if (!string.IsNullOrEmpty(uoltime))
                {
                    isout = false;
                    
                }
                else
                {
                    //过期方式,0.天，1小时,2分钟
                    int OnlineTimeSpanModel = Base.Configs.UserSetConfigs.ConfigsControl.Instance.OnlineTimeSpanModel;
                    int OnlineTimeSpan = Base.Configs.UserSetConfigs.ConfigsControl.Instance.OnlineTimeSpan;
                    if (OnlineTimeSpan > 1)
                    {
                        OnlineTimeSpan = OnlineTimeSpan - 1;//将他早点过期
                    }
                    if (OnlineTimeSpanModel == 0)
                    {
                        Core.Utils.WriteCookie(key, "1", OnlineTimeSpan, ETimeSpanModel.T, httpContext);
                    }
                    else if (OnlineTimeSpanModel == 1)
                    {
                        Core.Utils.WriteCookie(key, "1", OnlineTimeSpan, ETimeSpanModel.XS, httpContext);
                    }
                    else if (OnlineTimeSpanModel == 2)
                    {
                        Core.Utils.WriteCookie(key, "1", OnlineTimeSpan, ETimeSpanModel.FZ,httpContext);
                    }
                    
                }

                return isout;
            }
        }
        private bool ExistsOnlineId(int olineid)
        {
            return DbProviderUser.GetInstance().UserOnline_ExistsUser(olineid);
        }
        private static object _SyncRoot = new object();
        /// <summary>
        /// 最后的删除过期用户时间
        /// </summary>
        static private  int _lastRemoveTimeout;
        /// <summary>
        /// 检查删除过期用户频率(单位:分钟)
        /// </summary>
        static readonly private  int deletingFrequency = 1; 
        /// <summary>
       /// 检测当前用户是否的线，并更新在线信息
       /// </summary>
       public object SetUserOnline(object obj)
       {
            try
            {
                if (Base.Configs.UserSetConfigs.ConfigsControl.Instance.OnlineTimeSpan > 0)//是否开户在线用户统计
                {
                    if (IsTimeOut)//只有当前用户活动时间甚至再更新一次，没必要每次请求都更新
                    {

                        #region 执行一次更新操作
                        int iUserID = UserId;
                        if (iUserID > 0) //当前用户已经登录
                        {

                            if (OnlineID > 0)  //说明当前游客已经添加到用户在线表里,这个时候只要更新当前用户的一些活信息就行
                            {
                                if (ExistsOnlineId(OnlineID))
                                {
                                    UpdateCurrentOnlineUser(OnlineID);
                                }
                                else
                                {
                                    int uolid = ExistsUserID(iUserID);
                                    if (uolid > 0)
                                    {
                                        //将当前用户的在线ID写入到客户端cookie
                                        //UserIdentity.WriteUserOnlineID(uolid.ToString(), httpContext);
                                        UpdateCurrentOnlineUser(uolid);
                                    }
                                    else
                                    {
                                        CreateRegUser();
                                    }

                                }

                            }
                            else  //完全添加一个新的在线用户
                            {
                                CreateRegUser();
                            }


                            //检测的线用户表里是否已经存在当前用户
                        }
                        else //当前用户是游客
                        {
                            if (OnlineID > 0)  //说明当前游客已经添加到用户在线表里,这个时候只要更新当前用户的一些活信息就行
                            {
                                if (ExistsOnlineId(OnlineID))
                                {
                                    UpdateCurrentOnlineUser(OnlineID);
                                }
                                else
                                {
                                    CreateRegUser();// CreateGuestUser();
                                }

                            }
                            else  //完全添加一个新的在线用户
                            {

                                CreateRegUser();// CreateGuestUser();

                            }
                        }

                        #endregion

                        #region

                        //按照系统设置频率(默认5分钟)清除过期用户
                        if (_lastRemoveTimeout == 0 || (System.Environment.TickCount - _lastRemoveTimeout) > 60000 * deletingFrequency)
                        {
                            DeleteExpiredOnlineUsers();
                            lock (_SyncRoot)
                            {
                                _lastRemoveTimeout = System.Environment.TickCount;
                            }

                        }
                        #endregion

                    }

                }
            }
            catch (Exception e)
            {
                Log.Factory.GetInstance().ErrorLog(string.Format("更新在线用户数据,SetUserOnline发生错误:{0}", e.Message));
                
            }
            

            return 1;

       }
         
        /// <summary>
        /// 获取一个用户的在线ID
        /// </summary>
        /// <param name="UserID"></param>
        /// <returns></returns>
        public int ExistsUserID(int UserID)
      {
          return DbProviderUser.GetInstance().UserOnline_ExistsUserID(UserID);
      }

        

    }



}

