
//using System;
//using System.Data;
//using System.Collections.Generic;
//using System.Data.Common;
//using System.Data.SqlClient;
//using System.Text;
//using EbSite.BLL.User;


//namespace EbSite.Data.User.Interface
//{
//    public partial interface IDataProviderUser
//    {
        
//        BLL.User.UserCustomField UserCustomField_SelectUserCustomField(string UserName);
//        int UserCustomField_InsertUserCustomField(BLL.User.UserCustomField model);
//        void UserCustomField_UpdateUserCustomField(BLL.User.UserCustomField model);
//        void UserCustomField_DeleteUserCustomField(BLL.User.UserCustomField Model);
//        BLL.User.UserCustomField UserCustomField_ReaderBind(IDataReader dataReader);
//        bool UserCustomField_ExistsUser(string UserName);
//        List<BLL.User.UserCustomField> UserCustomField_GetList(int Top, string strWhere, string filedOrder);
//        BLL.User.UserCustomField UserCustomField_SelectUserCustomField(int uid);
//        int UserCustomField_GetCount(string strWhere);


//        List<EbSite.BLL.User.UserCustomField> UserCustomField_GetListPages(int PageIndex, int PageSize, string strWhere,
//                                                                           string oderby, bool IsAuditing, out int totalRecords);

//        List<EbSite.BLL.User.UserCustomField> UserCustomField_GetListPages(int PageIndex, int PageSize, string strWhere,
//                                                                          string oderby, out int totalRecords);

//        List<EbSite.BLL.User.UserCustomField> UserCustomField_GetListPages(int PageIndex, int PageSize, string strWhere, string oderby, bool IsAuditing, out int totalRecords, int RoleID);
//        /// <summary>
//        /// 搜索用户
//        /// </summary>
//        /// <param name="PageIndex"></param>
//        /// <param name="PageSize"></param>
//        /// <param name="Key"></param>
//        /// <returns></returns>
//        List<UserCustomField> UserCustomField_SearhUserByName(int PageIndex, int PageSize, string Key, out int totalRecords);
//        /// <summary>
//        /// 统计搜索用户个数
//        /// </summary>
//        /// <param name="Key"></param>
//        /// <returns></returns>
//        int UserCustomField_CountUserByName(string Key);
//        /// <summary>
//        /// 获取最新用户
//        /// </summary>
//        /// <param name="top"></param>
//        /// <returns></returns>
//        List<UserCustomField> UserCustomField_GetListOfNews(int top);
//        void UserCustomField_UpdateNiName(BLL.User.UserCustomField model);
//        void UserCustomField_UpdateSign(BLL.User.UserCustomField model);
//        void UserCustomField_UpdateCredits(BLL.User.UserCustomField model);
//        /// <summary>
//        /// 获取用户头像
//        /// </summary>
//        /// <param name="UserID"></param>
//        /// <param name="iSize">1大,2中，3小</param>
//        /// <returns></returns>
//        string UserCustomField_GetAvatarFileName(int UserID, int iSize);

//        int UserCustomField_GetUserIDByName(string UserName);

//    }
//}
