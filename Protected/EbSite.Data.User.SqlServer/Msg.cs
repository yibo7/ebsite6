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
using EbSite.BLL;
using EbSite.Base.DataProfile;

namespace EbSite.Data.User.SqlServer
{
    public partial class DataProviderUser : Interface.IDataProviderUser
    {
        public BLL.Msg Msg_SelectMsg(int id)
       {
           StringBuilder strSql = new StringBuilder();
           strSql.AppendFormat("select  top 1 ID,Sender,Recipient,FolderType,IsNew,Title,SendDate,MsgContent,SenderNiName,SenderUserID,RecipientUserID from  {0}Msg ", sPre);
           strSql.Append(" where ID=@ID ");
           SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
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
        /// 将某个用户的新短信设为已经读
        /// </summary>
        /// <param name="UserName"></param>
        public void Msg_SetToRead(string UserName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("update  {0}Msg set ", sPre);
            strSql.Append("IsNew=0");
            strSql.Append(" where Recipient=@UserName and IsNew=1 ");
            SqlParameter[] parameters = {
					new SqlParameter("@UserName", SqlDbType.NVarChar,50)
                                        };
            parameters[0].Value = UserName;
            DbHelperUser.Instance.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }
        /// <summary>
        /// 获取某个用户的短信
        /// </summary>
        /// <param name="UserName"></param>
        /// <param name="IsNews"></param>
        /// <returns></returns>
        public int Msg_Count(string UserName,bool IsNews)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select count(1) from  {0}Msg ", sPre);
            strSql.Append(" where  Recipient=@UserName");

            if(IsNews)
            {
                strSql.Append(" and  IsNew=1");
            }

            SqlParameter[] parameters = {
					new SqlParameter("@UserName", SqlDbType.NVarChar,50)};

            parameters[0].Value = UserName;

            object ob = DbHelperUser.Instance.ExecuteScalar(CommandType.Text, strSql.ToString(), parameters);

            if(!Equals(ob,null))
            {
                return (int) ob;
            }
            else
            {
                return 0;
            }
        }
        public void Msg_InsertMsg(BLL.Msg model)
       {
           StringBuilder strSql = new StringBuilder();
           strSql.AppendFormat("insert into  {0}Msg(", sPre);
           strSql.Append("Sender,Recipient,FolderType,IsNew,Title,SendDate,MsgContent,SenderNiName,SenderUserID,RecipientUserID)");
           strSql.Append(" values (");
           strSql.Append("@Sender,@Recipient,@FolderType,@IsNew,@Title,@SendDate,@MsgContent,@SenderNiName,@SenderUserID,@RecipientUserID)");
           strSql.Append(";select @@IDENTITY");
           SqlParameter[] parameters = {
					new SqlParameter("@Sender", SqlDbType.NVarChar,50),
					new SqlParameter("@Recipient", SqlDbType.NVarChar,50),
					new SqlParameter("@FolderType", SqlDbType.SmallInt,2),
					new SqlParameter("@IsNew", SqlDbType.Bit,1),
					new SqlParameter("@Title", SqlDbType.NVarChar,60),
					new SqlParameter("@SendDate", SqlDbType.DateTime),
					new SqlParameter("@MsgContent", SqlDbType.NText),
					new SqlParameter("@SenderNiName", SqlDbType.NVarChar,50),
					new SqlParameter("@SenderUserID", SqlDbType.Int,4),
					new SqlParameter("@RecipientUserID", SqlDbType.Int,4)};
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
           DbHelperUser.Instance.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
       }
        public void Msg_UpdateMsg(BLL.Msg model)
       {
           StringBuilder strSql = new StringBuilder();
           strSql.AppendFormat("update  {0}Msg set ", sPre);
           strSql.Append("Sender=@Sender,");
           strSql.Append("Recipient=@Recipient,");
           strSql.Append("FolderType=@FolderType,");
           strSql.Append("IsNew=@IsNew,");
           strSql.Append("Title=@Title,");
           strSql.Append("SendDate=@SendDate,");
           strSql.Append("MsgContent=@MsgContent,");
           strSql.Append("SenderNiName=@SenderNiName,");
           strSql.Append("SenderUserID=@SenderUserID,");
           strSql.Append("RecipientUserID=@RecipientUserID");
           strSql.Append(" where ID=@ID ");
           SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@Sender", SqlDbType.NVarChar,50),
					new SqlParameter("@Recipient", SqlDbType.NVarChar,50),
					new SqlParameter("@FolderType", SqlDbType.SmallInt,2),
					new SqlParameter("@IsNew", SqlDbType.Bit,1),
					new SqlParameter("@Title", SqlDbType.NVarChar,60),
					new SqlParameter("@SendDate", SqlDbType.DateTime),
					new SqlParameter("@MsgContent", SqlDbType.NText),
					new SqlParameter("@SenderNiName", SqlDbType.NVarChar,50),
					new SqlParameter("@SenderUserID", SqlDbType.Int,4),
					new SqlParameter("@RecipientUserID", SqlDbType.Int,4)};
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
           DbHelperUser.Instance.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
       }
       public void Msg_DeleteMsg(BLL.Msg model)
       {

           StringBuilder strSql = new StringBuilder();
           strSql.AppendFormat("delete  {0}Msg ", sPre);
           strSql.Append(" where ID=@ID ");
           SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
           parameters[0].Value = model.Id;
           DbHelperUser.Instance.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
       }
       public void Msg_DeleteMsg(int ID, string Recipient)
       {

           StringBuilder strSql = new StringBuilder();
           strSql.AppendFormat("delete  {0}Msg ", sPre);
           strSql.Append(" where ID=@ID and Recipient=@Recipient");
           SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
                                       new SqlParameter("@Recipient", SqlDbType.NVarChar,50)
                                       };
           parameters[0].Value = ID;
           parameters[1].Value = Recipient;
           DbHelperUser.Instance.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
       }
        public List<BLL.Msg> Msg_FillMsg()
       {

           StringBuilder strSql = new StringBuilder();
           strSql.Append("select ID,Sender,Recipient,FolderType,IsNew,Title,SendDate,MsgContent,SenderNiName,SenderUserID,RecipientUserID ");
           strSql.AppendFormat(" FROM  {0}Msg ", sPre);
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
        public void Msg_DeleteInIDs(string IDs)
        {
            if (!string.IsNullOrEmpty(IDs))
            {
                StringBuilder strSql = new StringBuilder();
                strSql.AppendFormat("delete from {0}Msg ", sPre);
                strSql.AppendFormat(" where ID in({0}) ", IDs);
                DbHelperUser.Instance.ExecuteNonQuery(CommandType.Text, strSql.ToString(), null);
            }

        }
    }
}
