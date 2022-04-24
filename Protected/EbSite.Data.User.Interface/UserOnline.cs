
using System;
using System.Collections.Generic;
namespace EbSite.Data.User.Interface
{
    public partial interface IDataProviderUser
    {
        void UserOnline_Delete(BLL.User.UserOnline Model);
        void UserOnline_Delete(int ID);
        void UserOnline_Update(BLL.User.UserOnline model);
        int UserOnline_Insert(BLL.User.UserOnline model);
        BLL.User.UserOnline UserOnline_Select(string UserName);
        BLL.User.UserOnline UserOnline_Select(int OnlineID);
        List<EbSite.BLL.User.UserOnline> UserOnline_GetRegUser(int PageIndex, int PageSize, string oderby);
        List<EbSite.BLL.User.UserOnline> UserOnline_GetGuestUser(int PageIndex, int PageSize, string oderby);
        List<EbSite.BLL.User.UserOnline> UserOnline_GetAllUser(int PageIndex, int PageSize, string oderby);
       
        void DeleteExpiredOnlineUsers(TimeSpan ts);
        int CreateOnlineTable();
         int UserOnline_GetCountRegUser();
        int UserOnline_GetCountGuestUser();
        
        int UserOnline_GetCount(string strWhere);
        //int UserOnline_ExistsUser(string UserName);
        bool UserOnline_ExistsUser(int olineid);
        int UserOnline_ExistsUserID(int UserID);
    }
}
