//======================================================
//==     (c)2008 SwordWeb inc by SwordWeb v1.0              ==
//==          Forum:bbs.SwordWeb.cn                   ==
//==         Website:www.ebsite.net                  ==
//======================================================
using System;
using System.Data;
using System.Collections.Generic;
using System.Data.Common;
using MySql.Data.MySqlClient;
using System.Text;
using EbSite.BLL;
using EbSite.Base.DataProfile;

namespace EbSite.Data.User.MySql
{
    public partial class DataProviderUser : Interface.IDataProviderUser
    {
        #region 读

        public BLL.Msg Msg_SelectMsg(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select ID,Sender,Recipient,FolderType,IsNew,Title,SendDate,MsgContent,SenderNiName,SenderUserID,RecipientUserID from  {0}msg ", sPre);
            strSql.Append(" where ID=?ID limit 1");
            MySqlParameter[] parameters = {
					new MySqlParameter("?ID",  MySqlDbType.Int32,4)};
            parameters[0].Value = id;

            BLL.Msg model = new BLL.Msg();
            using (DbDataReader rdr = DbHelperUser.Instance.ExecuteReader(CommandType.Text, strSql.ToString(), parameters))
            {
                if (rdr.Read())
                {
                    model = Msg_ReaderBind(rdr);
                }
            }
            return model;
        }

        /// <summary>
        /// 获取某个用户的短信
        /// </summary>
        /// <param name="UserName"></param>
        /// <param name="IsNews"></param>
        /// <returns></returns>
        public int Msg_Count(int UserID, bool IsNews)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select count(1) from  {0}msg ", sPre);
            strSql.Append(" where  RecipientUserID=?RecipientUserID");

            if (IsNews)
            {
                strSql.Append(" and  IsNew=1");
            }

            MySqlParameter[] parameters = {
					new MySqlParameter("?RecipientUserID", MySqlDbType.Int32,4)};

            parameters[0].Value = UserID;

            object ob = DbHelperUser.Instance.ExecuteScalar(CommandType.Text, strSql.ToString(), parameters);

            if (!Equals(ob, null))
            {
                return int.Parse(ob.ToString());
            }
            else
            {
                return 0;
            }
        }

        public List<BLL.Msg> Msg_FillMsg()
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,Sender,Recipient,FolderType,IsNew,Title,SendDate,MsgContent,SenderNiName,SenderUserID,RecipientUserID ");
            strSql.AppendFormat(" FROM  {0}msg ", sPre);
            List<BLL.Msg> Msges = new List<BLL.Msg>();
            using (DbDataReader rdr = DbHelperUser.Instance.ExecuteReader(CommandType.Text, strSql.ToString()))
            {
                while (rdr.Read())
                {
                    BLL.Msg model = Msg_ReaderBind(rdr);
                    model.MarkOld();
                    Msges.Add(model);
                }
            }
            return Msges;

        }

        /// <summary>
        /// 获得分页数据
        /// </summary>
        public List<BLL.Msg> Msg_GetListPages(int PageIndex, int PageSize, int UserId, bool IsNews, string oderby, out int RecordCount)
        {
            string Fileds = "ID,Sender,Recipient,FolderType,IsNew,Title,SendDate,MsgContent,SenderNiName,SenderUserID,RecipientUserID";
            List<BLL.Msg> list = new List<BLL.Msg>();
            RecordCount = Msg_Count(UserId, IsNews);
            string strWhere = string.Concat(" RecipientUserID=", UserId);//"(" where  Recipient=?UserName");

            if (IsNews)
            {
                strWhere = string.Concat(strWhere, " and  IsNew=1");
            }
            else
            {
                strWhere = string.Concat(strWhere, " and  IsNew=0");
            }

            string strSql = SplitPages.GetSplitPagesMySql(DbHelperUser.Instance, "Msg", PageSize, PageIndex, Fileds, "id", oderby, strWhere, sPre);

            using (IDataReader dataReader = DbHelperUser.Instance.ExecuteReader(CommandType.Text, strSql))
            {
                while (dataReader.Read())
                {
                    list.Add(Msg_ReaderBind(dataReader));
                }
            }
            return list;


        }
        public List<BLL.Msg> Msg_New(int top, int UserId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,Sender,Recipient,FolderType,IsNew,Title,SendDate,MsgContent,SenderNiName,SenderUserID,RecipientUserID ");
            strSql.AppendFormat(" FROM  {0}msg WHERE  RecipientUserID={1}  and  IsNew=1 order by id desc", sPre, UserId);

            List<BLL.Msg> list = new List<BLL.Msg>();
            using (IDataReader dataReader = DbHelperUser.Instance.ExecuteReader(CommandType.Text, strSql.ToString()))
            {
                while (dataReader.Read())
                {
                    list.Add(Msg_ReaderBind(dataReader));
                }
            }
            return list;


        }
        public BLL.Msg Msg_ReaderBind(IDataReader rdr)
        {
            BLL.Msg model = new BLL.Msg();

            if (rdr["ID"].ToString() != "")
            {
                model.Id = int.Parse(rdr["ID"].ToString());
            }
            model.Sender = rdr["Sender"].ToString();
            model.Recipient = rdr["Recipient"].ToString();
            if (rdr["FolderType"].ToString() != "")
            {
                model.FolderType = int.Parse(rdr["FolderType"].ToString());
            }
            if (rdr["IsNew"].ToString() != "")
            {
                if ((rdr["IsNew"].ToString() == "1") || (rdr["IsNew"].ToString().ToLower() == "true"))
                {
                    model.IsNewMsg = true;
                }
                else
                {
                    model.IsNewMsg = false;
                }
            }
            model.Title = rdr["Title"].ToString();
            if (rdr["SendDate"].ToString() != "")
            {
                model.SendDate = DateTime.Parse(rdr["SendDate"].ToString());
            }
            model.MsgContent = rdr["MsgContent"].ToString();
            model.SenderNiName = rdr["SenderNiName"].ToString();
            if (rdr["SenderUserID"].ToString() != "")
            {
                model.SenderUserID = int.Parse(rdr["SenderUserID"].ToString());
            }
            if (rdr["RecipientUserID"].ToString() != "")
            {
                model.RecipientUserID = int.Parse(rdr["RecipientUserID"].ToString());
            }

            return model;

        }

        #endregion 读

        #region 写

        public void Msg_InsertMsg(BLL.Msg model)
       {
           StringBuilder strSql = new StringBuilder();
           strSql.AppendFormat("insert into  {0}msg(", sPre);
           strSql.Append("Sender,Recipient,FolderType,IsNew,Title,SendDate,MsgContent,SenderNiName,SenderUserID,RecipientUserID)");
           strSql.Append(" values (");
           strSql.Append("?Sender,?Recipient,?FolderType,?IsNew,?Title,?SendDate,?MsgContent,?SenderNiName,?SenderUserID,?RecipientUserID)");
            strSql.Append(";SELECT @@session.identity");
           MySqlParameter[] parameters = {
					new MySqlParameter("?Sender", MySqlDbType.VarChar,50),
					new MySqlParameter("?Recipient", MySqlDbType.VarChar,50),
					new MySqlParameter("?FolderType", MySqlDbType.Int16,2),
					new MySqlParameter("?IsNew", MySqlDbType.Int16,1),
					new MySqlParameter("?Title", MySqlDbType.VarChar,60),
					new MySqlParameter("?SendDate", MySqlDbType.Datetime),
					new MySqlParameter("?MsgContent", MySqlDbType.Text),
					new MySqlParameter("?SenderNiName", MySqlDbType.VarChar,50),
					new MySqlParameter("?SenderUserID",  MySqlDbType.Int32,4),
					new MySqlParameter("?RecipientUserID",  MySqlDbType.Int32,4)};
           parameters[0].Value = model.Sender;
           parameters[1].Value = model.Recipient;
           parameters[2].Value = model.FolderType;
           parameters[3].Value = model.IsNew;
           parameters[4].Value = model.Title;
           parameters[5].Value = model.SendDate;
           parameters[6].Value = model.MsgContent;
           parameters[7].Value = model.SenderNiName;
           parameters[8].Value = model.SenderUserID;
           parameters[9].Value = model.RecipientUserID;
           DbHelperUserWrite.Instance.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
       }
        public void Msg_UpdateMsg(BLL.Msg model)
       {
           StringBuilder strSql = new StringBuilder();
           strSql.AppendFormat("update  {0}msg set ", sPre);
           strSql.Append("Sender=?Sender,");
           strSql.Append("Recipient=?Recipient,");
           strSql.Append("FolderType=?FolderType,");
           strSql.Append("IsNew=?IsNew,");
           strSql.Append("Title=?Title,");
           strSql.Append("SendDate=?SendDate,");
           strSql.Append("MsgContent=?MsgContent,");
           strSql.Append("SenderNiName=?SenderNiName,");
           strSql.Append("SenderUserID=?SenderUserID,");
           strSql.Append("RecipientUserID=?RecipientUserID");
           strSql.Append(" where ID=?ID ");
           MySqlParameter[] parameters = {
					new MySqlParameter("?ID",  MySqlDbType.Int32,4),
					new MySqlParameter("?Sender", MySqlDbType.VarChar,50),
					new MySqlParameter("?Recipient", MySqlDbType.VarChar,50),
					new MySqlParameter("?FolderType", MySqlDbType.Int16,2),
					new MySqlParameter("?IsNew", MySqlDbType.Int16,1),
					new MySqlParameter("?Title", MySqlDbType.VarChar,60),
					new MySqlParameter("?SendDate", MySqlDbType.Datetime),
					new MySqlParameter("?MsgContent", MySqlDbType.Text),
					new MySqlParameter("?SenderNiName", MySqlDbType.VarChar,50),
					new MySqlParameter("?SenderUserID",  MySqlDbType.Int32,4),
					new MySqlParameter("?RecipientUserID",  MySqlDbType.Int32,4)};
           parameters[0].Value = model.Id;
           parameters[1].Value = model.Sender;
           parameters[2].Value = model.Recipient;
           parameters[3].Value = model.FolderType;
           parameters[4].Value = model.IsNew;
           parameters[5].Value = model.Title;
           parameters[6].Value = model.SendDate;
           parameters[7].Value = model.MsgContent;
           parameters[8].Value = model.SenderNiName;
           parameters[9].Value = model.SenderUserID;
           parameters[10].Value = model.RecipientUserID;
           DbHelperUserWrite.Instance.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
       }
       public void Msg_DeleteMsg(BLL.Msg model)
       {

           StringBuilder strSql = new StringBuilder();
           strSql.AppendFormat("delete from  {0}msg ", sPre);
           strSql.Append(" where ID=?ID ");
           MySqlParameter[] parameters = {
					new MySqlParameter("?ID",  MySqlDbType.Int32,4)};
           parameters[0].Value = model.Id;
           DbHelperUserWrite.Instance.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
       }
       public void Msg_DeleteMsg(int ID, int RecipientID)
       {

           StringBuilder strSql = new StringBuilder();
           strSql.AppendFormat("delete from  {0}msg ", sPre);
           strSql.Append(" where ID=?ID and RecipientUserID=?RecipientUserID");
           MySqlParameter[] parameters = {
					new MySqlParameter("?ID",  MySqlDbType.Int32,4),
                                       new MySqlParameter("?RecipientUserID", MySqlDbType.VarChar,50)
                                       };
           parameters[0].Value = ID;
           parameters[1].Value = RecipientID;
           DbHelperUserWrite.Instance.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
       }
        /// <summary>
        /// 将某个用户的新短信设为已经读
        /// </summary>
        public void Msg_SetToRead(int MsgID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("update  {0}msg set ", sPre);
            strSql.Append("IsNew=0");
            strSql.Append(" where id=?id  ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32,4)
                                        };
            parameters[0].Value = MsgID;
            DbHelperUserWrite.Instance.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }
        public void Msg_DeleteInIDs(string IDs)
        {
            if (!string.IsNullOrEmpty(IDs))
            {
                StringBuilder strSql = new StringBuilder();
                strSql.AppendFormat("delete from {0}msg ", sPre);
                strSql.AppendFormat(" where ID in({0}) ", IDs);
                DbHelperUserWrite.Instance.ExecuteNonQuery(CommandType.Text, strSql.ToString(), null);
            }

        }

        #endregion 写

    }
}
