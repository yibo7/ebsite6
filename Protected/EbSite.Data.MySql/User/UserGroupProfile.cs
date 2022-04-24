//======================================================
//==     (c)2008 SwordWeb inc by SwordWeb v1.0              ==
//==          Forum:bbs.SwordWeb.cn                   ==
//==         Website:www.ebsite.net                  ==
//======================================================
using System;
using System.Data;
using System.Collections.Generic;
using System.Data.Common;
using EbSite.Base.EntityAPI;
using MySql.Data.MySqlClient;
using System.Text;
using EbSite.Base.DataProfile;

namespace EbSite.Data.MySql
{
    public partial class DataProviderCms : Interface.IDataProviderCms
    {
        public BLL.User.UserGroupProfile UserGroupProfile_SelectUserGroupProfile(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select   GroupID,GroupName,CreditShigher,CreditSlower,ManageIndexMaster,IsSys,UserModelID,AllowAddClass,AllowAddContentNum,IsAuditingMember,IsAllowDelete,IsAllowModify,isauditingcontent,ManageIndex,WebSiteIndex from {0}usergroupprofile ", sPre);
            strSql.Append(" where GroupID=?GroupID limit 1 ");
            MySqlParameter[] parameters = {
                    new MySqlParameter("?GroupID",  MySqlDbType.Int32,4)};
            parameters[0].Value = id;
            BLL.User.UserGroupProfile model = new BLL.User.UserGroupProfile();
            using (DbDataReader rdr = DbHelperCms.Instance.ExecuteReader(CommandType.Text, strSql.ToString(), parameters))
            {

                if (rdr.Read())
                {
                    model = UserGroupProfile_ReaderBind(rdr);
                    model.MarkOld();
                }

            }
            return model;
        }
        /// <summary>
        /// 验证用户组 名称 是否存在
        /// </summary>
        /// <param name="GroupName"></param>
        /// <returns></returns>
        public bool UserGroupProfile_IsExist(string GroupName)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select count(1) from  {0}UserGroupProfile ", sPre);
            strSql.Append(" where GroupName=?GroupName ");
            MySqlParameter[] parameters = {
					  new MySqlParameter("?GroupName", MySqlDbType.VarChar,50)};
            parameters[0].Value = GroupName;

            return DbHelperCms.Instance.Exists(strSql.ToString(), parameters);

           
        }
        public BLL.User.UserGroupProfile UserGroupProfile_SelectUserGroupProfile(string GroupName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select GroupID,GroupName,CreditShigher,CreditSlower,ManageIndexMaster,IsSys,UserModelID,AllowAddClass,AllowAddContentNum,IsAuditingMember,IsAllowDelete,IsAllowModify,isauditingcontent,ManageIndex,WebSiteIndex from {0}usergroupprofile ", sPre);
            strSql.Append(" where GroupName=?GroupName limit 1");
            MySqlParameter[] parameters = {
                    new MySqlParameter("?GroupName", MySqlDbType.VarChar,50)};
            parameters[0].Value = GroupName;
            BLL.User.UserGroupProfile model = new BLL.User.UserGroupProfile();
            using (DbDataReader rdr = DbHelperCms.Instance.ExecuteReader(CommandType.Text, strSql.ToString(), parameters))
            {
                if (rdr.Read())
                {
                    model = UserGroupProfile_ReaderBind(rdr);
                    model.MarkOld();
                }

            }
            return model;
        }
        public void UserGroupProfile_InsertUserGroupProfile(BLL.User.UserGroupProfile model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("insert into {0}usergroupprofile(", sPre);

            strSql.Append("GroupName,CreditShigher,CreditSlower,ManageIndexMaster,IsSys,UserModelID,AllowAddClass,AllowAddContentNum,IsAuditingMember,IsAllowDelete,IsAllowModify,IsAuditingContent,ManageIndex,WebSiteIndex)");
            strSql.Append(" values (");
            strSql.Append("?GroupName,?CreditShigher,?CreditSlower,?ManageIndexMaster,?IsSys,?UserModelID,?AllowAddClass,?AllowAddContentNum,?IsAuditingMember,?IsAllowDelete,?IsAllowModify,?IsAuditingContent,?ManageIndex,?WebSiteIndex)");
             strSql.Append(";SELECT @@session.identity");
            MySqlParameter[] parameters = {
                    new MySqlParameter("?GroupName", MySqlDbType.VarChar,50),
                    new MySqlParameter("?CreditShigher",  MySqlDbType.Int32,4),
                    new MySqlParameter("?CreditSlower",  MySqlDbType.Int32,4),
                    new MySqlParameter("?ManageIndexMaster",MySqlDbType.VarChar,200),
                    new MySqlParameter("?IsSys", MySqlDbType.Int16,1),
                    new MySqlParameter("?UserModelID", MySqlDbType.VarChar,36),
                    new MySqlParameter("?AllowAddClass", MySqlDbType.VarChar,50),
                    new MySqlParameter("?AllowAddContentNum",  MySqlDbType.Int32,4),
                    new MySqlParameter("?IsAuditingMember", MySqlDbType.Int16,1),
                    new MySqlParameter("?IsAllowDelete", MySqlDbType.Int16,1),
                    new MySqlParameter("?IsAllowModify", MySqlDbType.Int16,1),
                    new MySqlParameter("?IsAuditingContent", MySqlDbType.Int16,1),
                    new MySqlParameter("?ManageIndex", MySqlDbType.VarChar,100),
                    new MySqlParameter("?WebSiteIndex", MySqlDbType.VarChar,32)
                                        
                                        };
            parameters[0].Value = model.GroupName;
            parameters[1].Value = model.CreditShigher;
            parameters[2].Value = model.CreditSlower;
            parameters[3].Value = model.ManageIndexMaster;
            parameters[4].Value = model.IsSys;
            parameters[5].Value = model.UserModelID;
            parameters[6].Value = model.AllowAddClass;
            parameters[7].Value = model.AllowAddContentNum;
            parameters[8].Value = model.IsAuditingMember;
            parameters[9].Value = model.IsAllowDelete;
            parameters[10].Value = model.IsAllowModify;
            parameters[11].Value = model.IsAuditingContent;
            parameters[12].Value = model.ManageIndex;
            parameters[13].Value = model.WebSiteIndex;

            DbHelperCms.Instance.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }
        public void UserGroupProfile_UpdateUserGroupProfile(BLL.User.UserGroupProfile model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update " + sPre + "usergroupprofile set ");
            strSql.Append("CreditShigher=?CreditShigher,");
            strSql.Append("CreditSlower=?CreditSlower,");
            strSql.Append("ManageIndexMaster=?ManageIndexMaster,");
            strSql.Append("IsSys=?IsSys,");
            strSql.Append("UserModelID=?UserModelID,");
            strSql.Append("AllowAddClass=?AllowAddClass,");
            strSql.Append("AllowAddContentNum=?AllowAddContentNum,");
            strSql.Append("IsAuditingMember=?IsAuditingMember,");
            strSql.Append("IsAllowDelete=?IsAllowDelete,");
            strSql.Append("IsAllowModify=?IsAllowModify,");
            strSql.Append("IsAuditingContent=?IsAuditingContent,");
            strSql.Append("ManageIndex=?ManageIndex,");
            strSql.Append("GroupName=?GroupName,");
            strSql.Append("WebSiteIndex=?WebSiteIndex");
            strSql.Append(" where GroupID=?GroupID ");
            MySqlParameter[] parameters = {
                    new MySqlParameter("?GroupID",  MySqlDbType.Int32,4),
                    new MySqlParameter("?GroupName", MySqlDbType.VarChar,50),
                    new MySqlParameter("?CreditShigher",  MySqlDbType.Int32,4),
                    new MySqlParameter("?CreditSlower",  MySqlDbType.Int32,4),
                    new MySqlParameter("?ManageIndexMaster",MySqlDbType.VarChar,200),
                    new MySqlParameter("?IsSys", MySqlDbType.Int16,1),
                    new MySqlParameter("?UserModelID", MySqlDbType.VarChar,36),
                    new MySqlParameter("?AllowAddClass", MySqlDbType.VarChar,50),
                    new MySqlParameter("?AllowAddContentNum",  MySqlDbType.Int32,4),
                    new MySqlParameter("?IsAuditingMember", MySqlDbType.Int16,1),
                    new MySqlParameter("?IsAllowDelete", MySqlDbType.Int16,1),
                    new MySqlParameter("?IsAllowModify", MySqlDbType.Int16,1),
                    new MySqlParameter("?IsAuditingContent", MySqlDbType.Int16,1),
                    new MySqlParameter("?ManageIndex", MySqlDbType.VarChar,100),
                     new MySqlParameter("?WebSiteIndex", MySqlDbType.VarChar,32)
                                        
                                        };
            parameters[0].Value = model.Id;
            parameters[1].Value = model.GroupName;
            parameters[2].Value = model.CreditShigher;
            parameters[3].Value = model.CreditSlower;
            parameters[4].Value = model.ManageIndexMaster;
            parameters[5].Value = model.IsSys;
            parameters[6].Value = model.UserModelID;
            parameters[7].Value = model.AllowAddClass;
            parameters[8].Value = model.AllowAddContentNum;
            parameters[9].Value = model.IsAuditingMember;
            parameters[10].Value = model.IsAllowDelete;
            parameters[11].Value = model.IsAllowModify;
            parameters[12].Value = model.IsAuditingContent;
            parameters[13].Value = model.ManageIndex;
            parameters[14].Value = model.WebSiteIndex;
            
            DbHelperCms.Instance.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }
        public void UserGroupProfile_DeleteUserGroupProfile(BLL.User.UserGroupProfile model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from " + Base.Configs.BaseCinfigs.ConfigsControl.Instance.TablePrefix + "usergroupprofile ");
            strSql.Append(" where GroupName=?GroupName");
            MySqlParameter[] parameters = {
                    new MySqlParameter("?GroupName", MySqlDbType.VarChar,50)
                    };
            parameters[0].Value = model.GroupName;
            DbHelperCms.Instance.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }
        public List<BLL.User.UserGroupProfile> UserGroupProfile_FillUserGroupProfiles()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select GroupID,GroupName,CreditShigher,CreditSlower,ManageIndexMaster,IsSys,UserModelID,AllowAddClass,AllowAddContentNum,IsAuditingMember,IsAllowDelete,IsAllowModify,isauditingcontent,ManageIndex,WebSiteIndex ");
            strSql.AppendFormat(" FROM {0}UserGroupProfile ", sPre);
            List<BLL.User.UserGroupProfile> list = new List<BLL.User.UserGroupProfile>();
            using (DbDataReader rdr = DbHelperCms.Instance.ExecuteReader(CommandType.Text, strSql.ToString()))
            {
                while (rdr.Read())
                {

                    BLL.User.UserGroupProfile model = UserGroupProfile_ReaderBind(rdr);
                    model.MarkOld();
                    list.Add(model);

                }

            }
            return list;


        }

        public UserGroupProfileShort UserGroupProfile_GroupShortByUserID(object uid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("SELECT a.GroupName,a.ManageIndex,a.WebSiteIndex,a.ManageIndexMaster,a.UserModelID FROM  {0}usergroupprofile as a WHERE  a.GroupID=(SELECT b.groupid FROM  {0}users as b WHERE  b.UserID = {1} LIMIT 1) LIMIT 1; ", sPre, uid);

            UserGroupProfileShort model = new UserGroupProfileShort();
            using (DbDataReader rdr = DbHelperCms.Instance.ExecuteReader(CommandType.Text, strSql.ToString()))
            {
                if (rdr.Read())
                {
                    model.GroupName = rdr["GroupName"].ToString();
                    model.ManageIndex = rdr["ManageIndex"].ToString();
                    model.ManageIndexMaster = rdr["ManageIndexMaster"].ToString();
                    model.UserModelID = rdr["UserModelID"].ToString();
                    model.WebSiteIndex = rdr["WebSiteIndex"].ToString();
                }

            }
            return model;
        }
        public BLL.User.UserGroupProfile UserGroupProfile_ReaderBind(IDataReader rdr)
        {
            BLL.User.UserGroupProfile model = new BLL.User.UserGroupProfile();
            if (rdr["GroupID"].ToString() != "")
            {
                model.Id = int.Parse(rdr["GroupID"].ToString());
            }
            model.GroupName = rdr["GroupName"].ToString();
            if (rdr["CreditShigher"].ToString() != "")
            {
                model.CreditShigher = int.Parse(rdr["CreditShigher"].ToString());
            }
            if (rdr["CreditSlower"].ToString() != "")
            {
                model.CreditSlower = int.Parse(rdr["CreditSlower"].ToString());
            }
            model.ManageIndexMaster = rdr["ManageIndexMaster"].ToString();
            if (rdr["IsSys"].ToString() != "")
            {
                if ((rdr["IsSys"].ToString() == "1") ||
                    (rdr["IsSys"].ToString().ToLower() == "true"))
                {
                    model.IsSys = true;
                }
                else
                {
                    model.IsSys = false;
                }
            }
            if (rdr["UserModelID"].ToString() != "")
            {
                model.UserModelID = new Guid(rdr["UserModelID"].ToString());
            }
            model.AllowAddClass = rdr["AllowAddClass"].ToString();
            if (rdr["AllowAddContentNum"].ToString() != "")
            {
                model.AllowAddContentNum = int.Parse(rdr["AllowAddContentNum"].ToString());
            }
            if (rdr["IsAuditingMember"].ToString() != "")
            {
                if ((rdr["IsAuditingMember"].ToString() == "1") || (rdr["IsAuditingMember"].ToString().ToLower() == "true"))
                {
                    model.IsAuditingMember = true;
                }
                else
                {
                    model.IsAuditingMember = false;
                }
            }

            if (rdr["IsAllowDelete"].ToString() != "")
            {
                if ((rdr["IsAllowDelete"].ToString() == "1") || (rdr["IsAllowDelete"].ToString().ToLower() == "true"))
                {
                    model.IsAllowDelete = true;
                }
                else
                {
                    model.IsAllowDelete = false;
                }
            }
            if (rdr["IsAllowModify"].ToString() != "")
            {
                if ((rdr["IsAllowModify"].ToString() == "1") || (rdr["IsAllowModify"].ToString().ToLower() == "true"))
                {
                    model.IsAllowModify = true;
                }
                else
                {
                    model.IsAllowModify = false;
                }
            }
            if (rdr["isauditingcontent"].ToString() != "")
            {
                if ((rdr["isauditingcontent"].ToString() == "1") || (rdr["isauditingcontent"].ToString().ToLower() == "true"))
                {
                    model.IsAuditingContent = true;
                }
                else
                {
                    model.IsAuditingContent = false;
                }
            }
            model.ManageIndex = rdr["ManageIndex"].ToString();
            model.WebSiteIndex = rdr["WebSiteIndex"].ToString();
            return model;
        }


    }
}
