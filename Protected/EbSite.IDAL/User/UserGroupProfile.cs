//======================================================
//==     (c)2008 SwordWeb inc by SwordWeb v1.0              ==
//==          Forum:bbs.SwordWeb.cn                   ==
//==         Website:www.ebsite.net                  ==
//======================================================
using System;
using System.Data;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text;
using EbSite.Base.EntityAPI;


namespace EbSite.Data.Interface
{
    public partial interface IDataProviderCms
    {
        BLL.User.UserGroupProfile UserGroupProfile_SelectUserGroupProfile(int id);
        BLL.User.UserGroupProfile UserGroupProfile_SelectUserGroupProfile(string GroupName);
        void UserGroupProfile_InsertUserGroupProfile(BLL.User.UserGroupProfile model);
        void UserGroupProfile_UpdateUserGroupProfile(BLL.User.UserGroupProfile model);
        void UserGroupProfile_DeleteUserGroupProfile(BLL.User.UserGroupProfile model);
        List<BLL.User.UserGroupProfile> UserGroupProfile_FillUserGroupProfiles();
        BLL.User.UserGroupProfile UserGroupProfile_ReaderBind(IDataReader rdr);

        UserGroupProfileShort UserGroupProfile_GroupShortByUserID(object uid);

        bool UserGroupProfile_IsExist(string GroupName);
    }
}
