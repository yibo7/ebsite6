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

namespace EbSite.Data.User.Interface
{
    public partial interface IDataProviderUser
    {
       BLL.Msg Msg_SelectMsg(int id);
       void Msg_InsertMsg(BLL.Msg model);
       void Msg_UpdateMsg(BLL.Msg model);
       void Msg_DeleteMsg(BLL.Msg model);
       List<BLL.Msg> Msg_FillMsg();
       BLL.Msg Msg_ReaderBind(IDataReader rdr);
       void Msg_SetToRead(int MsgID);
        int Msg_Count(int UserId, bool IsNews);
        void Msg_DeleteMsg(int ID, int UserID);
        void Msg_DeleteInIDs(string IDs);
        List<BLL.Msg> Msg_New(int top, int UserId);
        List<BLL.Msg> Msg_GetListPages(int PageIndex, int PageSize, int UserId, bool IsNews, string oderby,
                                       out int RecordCount);
    }
}
