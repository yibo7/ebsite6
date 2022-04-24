
using System;
using System.Collections.Generic;
using System.Text;
using System.Web.Security;
using EbSite.BLL.User;
using EbSite.Core;
using MembershipUserEb = EbSite.Base.EntityAPI.MembershipUserEb;
using NewsClass = EbSite.Entity.NewsClass;

namespace EbSite.Base.Page
{
    public class UserPage : BasePage
    {
        /// <summary>
        /// 当前登录的用户名,不登录为空
        /// </summary>
        //protected string CurentUserName = string.Empty;

        //protected string CurentUserNiName = "游客";
        /// <summary>
        /// 是否当前用户访问自己的管理页面
        /// </summary>
        //protected bool IsCurrentUser = false;
        /// <summary>
        /// 用户积分
        /// </summary>
        protected int Credits = 0;

        /// <summary>
        /// <summary>
        /// 是否管理人员
        /// </summary>
        protected bool IsAdmin = false;

        protected Base.EntityAPI.MembershipUserEb UCF = null;

        /////////////////////////////////////////////////////////////////////
        const double CacheDuration = 60.0;//
        private const string CacheUserPage = "userpage";// private static readonly string[] MasterCacheKeyArray = { "UserPage" };
       // private static CacheManager bllCache;
        ///// <summary>
        ///// 获取某个用户可以添加内容的分类
        ///// </summary>
        //protected List<EbSite.Entity.NewsClass> CanAddClass(string UserName)
        //{


        //    string CacheKey = string.Concat("CanAddClass-", UserName);
        //    List<EbSite.Entity.NewsClass> lst = bllCache.GetCacheItem(CacheKey) as List<NewsClass>;
        //    if (Equals(lst,null))
        //    {
        //        lst = new List<NewsClass>();

        //        List<UserGroupProfile> lstRoleProfiles = UserGroupProfile.GetRoleProfilesByUserName(CurentUserName);

        //        if(lstRoleProfiles.Count>0)
        //        {
        //            //多用户组机制
        //            foreach (UserGroupProfile mdRoleProfile in lstRoleProfiles)
        //            {
        //                string sClassIDs = mdRoleProfile.AllowAddClass;

        //                if (sClassIDs.Length > 0)
        //                {
        //                    string[] aClassids = sClassIDs.Split(',');

        //                    foreach (string classid in aClassids)
        //                    {

        //                       EbSite.Entity.NewsClass mdClass = EbSite.BLL.NewsClass.GetModelByCache(int.Parse(classid));

        //                        if (!Equals(mdClass, null))
        //                        {
        //                            mdClass.UserCanAddNum = mdRoleProfile.AllowAddContentNum;
        //                            mdClass.IsAllowDelete = mdRoleProfile.IsAllowDelete;
        //                            mdClass.IsAllowModify = mdRoleProfile.IsAllowModify;
        //                            mdClass.isauditingcontent = mdRoleProfile.IsAuditingContent;
        //                            lst.Add(mdClass);
        //                        }

        //                    }
        //                }
        //            }
        //        }

        //        if (!Equals(lst, null)) bllCache.AddCacheItem(CacheKey, lst);
        //    }
           
        //   return lst;
           
        //}
        ///// <summary>
        ///// 要访问用户的名称,如果无法获取，表示为当前用户，如果获取得到此值，表示为要访问的用户页面
        ///// </summary>
        //protected string VisitorUserName
        //{
        //    get
        //    {
        //        return Request["uid"];
        //    }
        //}
        ///// <summary>
        ///// 由于系统可以设置成多用户组机制，每个用户组又可以属于不同的模型
        ///// </summary>
        //protected List<Guid> GetCurrentUserModelID
        //{
        //    get
        //    {
        //        string CacheKey = string.Concat("CurrentUMID-", CurentUserName);
        //        List<Guid> lst = bllCache.GetCacheItem(CacheKey) as List<Guid>;
        //        if (Equals(lst, null))
        //        {
        //            lst = new List<Guid>();
        //            string[] CurrentRosles = Roles.GetRolesForUser(CurentUserName);
        //            foreach (string currentRosle in CurrentRosles)
        //            {
        //                EbSite.BLL.User.UserGroupProfile ugp = UserGroupProfile.GetUserGroupProfile(currentRosle);

        //                lst.Add(ugp.UserModelID);

        //            }

        //            bllCache.AddCacheItem(CacheKey, lst);
        //        }
        //        return lst;

        //    }
        //}
        ///// <summary>
        ///// 获取当前用户所在的用户组，用逗号分开
        ///// </summary>
        //protected string UserGroupNames
        //{
        //    get
        //    {

        //        string CacheKey = string.Concat("CurrentUMID-", CurentUserName);
        //        string UGroupNames = bllCache.GetCacheItem(CacheKey) as string;
        //        if (string.IsNullOrEmpty(UGroupNames))
        //        {
        //            StringBuilder sb = new StringBuilder();
        //            string[] sGs = Roles.GetRolesForUser(CurentUserName);
                    
        //            foreach (string sG in sGs)
        //            {
        //                sb.Append(sG);
        //                sb.Append(",");
        //            }
        //            if (sb.Length > 0) sb.Remove(sb.Length - 1, 1);
        //            if (sb.Length > 0)
        //            {
        //                UGroupNames =  sb.ToString();
        //            }
        //            else
        //            {
        //                UGroupNames =  "未分配";
        //            }

        //            if (!string.IsNullOrEmpty(UGroupNames)) bllCache.AddCacheItem(CacheKey, UGroupNames);
        //        }


        //        return UGroupNames;
        //    }
        //}
        /// <summary>
        /// LOAD事件处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UserPage_Load(object sender, EventArgs e)
        {
           // bllCache = new CacheManager(CacheDuration, MasterCacheKeyArray);

            if (UserID > 0)
            {
                CheckCurrentUserIsLogin();
                UCF = EbSite.BLL.User.MembershipUserEb.Instance.GetEntity(UserID);
                Credits = UCF.Credits;
                IsAdmin = UCF.ManagerID > 0;
                //CurentUserNiName = UCF.NiName;
            }

            //if(!string.IsNullOrEmpty(VisitorUserName)) //访问的是指定用户
            //{
            //    //检测是否正在当前访问某个对像（非当前登录用户）
                
            //    if(EbSite.BLL.User.MembershipUserEb.Instance.ExistsUserName(VisitorUserName)) 
            //    {
                  
            //       EbSite.BLL.RecentVisitors.UpdateVisitors(VisitorUserName);
                    
            //    }
            //    else
            //    {
            //        Tips("出错了","不存在当前用户！");
            //    }
            //    CurentUserName = VisitorUserName;
            //}
            //else  //访问者是当前登录的用户
            //{
            //    if (!string.IsNullOrEmpty(AppStartInit.UserName))  
            //    {
            //        //验证当前用户是否已经登录(帐号+密码),如果还未登录，跳转到登录页面
            //        CheckCurrentUserIsLogin();

            //        CurentUserName = AppStartInit.UserName;
            //        IsCurrentUser = true;//确认是当前用户访问自己的内容
            //    }
            //    else if (!IsAllowGuest()) ////如果用户还没有登录(游客)，定向到登录页面
            //    {
            //        EbSite.Base.AppStartInit.UserLoginReurl();
            //    }
            //    else
            //    {
            //        CurentUserName = "游客";


            //    }

            //}

            //if (!string.IsNullOrEmpty(AppStartInit.UserName))
            //{
            //    //验证当前用户是否已经登录(帐号+密码),如果还未登录，跳转到登录页面
            //    CheckCurrentUserIsLogin();

            //    CurentUserName = AppStartInit.UserName;
            //    IsCurrentUser = true;//确认是当前用户访问自己的内容
            //}
            //else if (!IsAllowGuest()) ////如果用户还没有登录(游客)，定向到登录页面
            //{
            //    EbSite.Base.AppStartInit.UserLoginReurl();
            //}
            //else
            //{
            //    CurentUserName = "游客";

            //}

            //if (!Equals(CurentUserName ,"游客"))
            //{
            //    UCF = EbSite.BLL.User.MembershipUserEb.Instance.GetEntity(CurentUserName);
            //    Credits = UCF.Credits;
            //    IsAdmin = UCF.ManagerID > 0;
            //    CurentUserNiName = UCF.NiName;
            //}
            //else
            //{
            //    UCF = new MembershipUserEb();
            //    UCF.UserName = EbSite.Base.Host.Instance.GetGuestName(EbSite.Base.Host.Instance.OnlineID);
            //    UCF.NiName = string.Concat("游客", EbSite.Base.Host.Instance.OnlineID);


            //    Credits = UCF.Credits;
            //    IsAdmin = UCF.ManagerID > 0;
            //    CurentUserNiName = UCF.NiName;
            //}

            
            
        }
        
        
        //protected virtual bool IsAllowGuest()
        //{
        //    return false;
        //}
        

        /// <summary>
        /// LOAD事件处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UserPage_LoadComplete(object sender, EventArgs e)
        {
            
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        public UserPage()
        {
            this.Load += new EventHandler(UserPage_Load);
            this.LoadComplete += new EventHandler(UserPage_LoadComplete);
        }


    }
        
}
