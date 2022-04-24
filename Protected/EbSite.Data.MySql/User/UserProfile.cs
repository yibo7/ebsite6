
using System;
using System.Data;
using System.Collections.Generic;
using System.Data.Common;
using MySql.Data.MySqlClient;
using System.Text;
using EbSite.BLL.User;
using EbSite.Base.DataProfile;

namespace EbSite.Data.MySql
{
    public partial class DataProviderCms : Interface.IDataProviderCms
    {
        public BLL.User.UserProfile UserProfile_SelectUserProfile(int UserId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select   UserID,UserName,QQ,MSN,ICO,Sex,BirthDay,Photo,Bloodtype,Country,Province,City,Phone,Postcode,Address,Job,Edu,School,Introduction,UserModelID,Annex1,Annex2,Annex3,Annex4,Annex5 from {0}userprofile ", sPre);
            strSql.Append(" where UserID=?UserID limit 1");
            MySqlParameter[] parameters = {
                    new MySqlParameter("?UserID",  MySqlDbType.Int32,4)
                    };
            parameters[0].Value = UserId;

            EbSite.BLL.User.UserProfile model = null;

            using (IDataReader dataReader = DbHelperCms.Instance.ExecuteReader(CommandType.Text, strSql.ToString(), parameters))
            {
                if (dataReader.Read())
                {
                    model = UserProfile_ReaderBind(dataReader);
                }
            }
            return model;

        }
        /// <summary>
        /// 没有当前用户的资料，反回null
        /// </summary>
        /// <param name="UserName"></param>
        /// <param name="UserModelID"></param>
        /// <returns></returns>
        public BLL.User.UserProfile UserProfile_SelectUserProfile(string UserName, Guid UserModelID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select   UserID,UserName,QQ,MSN,ICO,Sex,BirthDay,Photo,Bloodtype,Country,Province,City,Phone,Postcode,Address,Job,Edu,School,Introduction,UserModelID,Annex1,Annex2,Annex3,Annex4,Annex5 from {0}userprofile ", sPre);
            strSql.Append(" where UserName=?UserName and UserModelID=?UserModelID limit 1");
            MySqlParameter[] parameters = {
                    new MySqlParameter("?UserName", MySqlDbType.VarChar,50),
                    new MySqlParameter("?UserModelID",MySqlDbType.VarChar,50)
                    };
            parameters[0].Value = UserName;
            parameters[1].Value = UserModelID;
            EbSite.BLL.User.UserProfile model = null;

            using (IDataReader dataReader = DbHelperCms.Instance.ExecuteReader(CommandType.Text, strSql.ToString(), parameters))
            {
                if (dataReader.Read())
                {
                    model = UserProfile_ReaderBind(dataReader);
                }
            }
            return model;
        }
        public void UserProfile_InsertUserProfile(BLL.User.UserProfile model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("insert into {0}userprofile(", sPre);
            strSql.Append("UserName,QQ,MSN,ICO,Sex,BirthDay,Photo,Bloodtype,Country,Province,City,Phone,Postcode,Address,Job,Edu,School,Introduction,UserModelID,Annex1,Annex2,Annex3,Annex4,Annex5)");
            strSql.Append(" values (");
            strSql.Append("?UserName,?QQ,?MSN,?ICO,?Sex,?BirthDay,?Photo,?Bloodtype,?Country,?Province,?City,?Phone,?Postcode,?Address,?Job,?Edu,?School,?Introduction,?UserModelID,?Annex1,?Annex2,?Annex3,?Annex4,?Annex5)");
             strSql.Append(";SELECT @@session.identity");
            MySqlParameter[] parameters = {
					new MySqlParameter("?UserName", MySqlDbType.VarChar,50),
					new MySqlParameter("?QQ", MySqlDbType.VarChar,20),
					new MySqlParameter("?MSN", MySqlDbType.VarChar,50),
					new MySqlParameter("?ICO", MySqlDbType.VarChar,20),
					new MySqlParameter("?Sex",MySqlDbType.VarChar,10),
					new MySqlParameter("?BirthDay", MySqlDbType.Datetime),
					new MySqlParameter("?Photo", MySqlDbType.VarChar,225),
					new MySqlParameter("?Bloodtype", MySqlDbType.VarChar,5),
					new MySqlParameter("?Country", MySqlDbType.VarChar,50),
					new MySqlParameter("?Province", MySqlDbType.VarChar,50),
					new MySqlParameter("?City", MySqlDbType.VarChar,50),
					new MySqlParameter("?Phone", MySqlDbType.VarChar,50),
					new MySqlParameter("?Postcode", MySqlDbType.VarChar,10),
					new MySqlParameter("?Address", MySqlDbType.VarChar,500),
					new MySqlParameter("?Job", MySqlDbType.VarChar,50),
					new MySqlParameter("?Edu", MySqlDbType.VarChar,10),
					new MySqlParameter("?School", MySqlDbType.VarChar,50),
					new MySqlParameter("?Introduction", MySqlDbType.VarChar,1000),
					new MySqlParameter("?UserModelID", MySqlDbType.VarChar,36),
					new MySqlParameter("?Annex1", MySqlDbType.VarChar,100),
					new MySqlParameter("?Annex2", MySqlDbType.VarChar,200),
					new MySqlParameter("?Annex3", MySqlDbType.VarChar,300),
					new MySqlParameter("?Annex4", MySqlDbType.VarChar,400),
					new MySqlParameter("?Annex5", MySqlDbType.VarChar,500)};
            parameters[0].Value = model.UserName;
            parameters[1].Value = model.QQ;
            parameters[2].Value = model.MSN;
            parameters[3].Value = model.ICO;
            parameters[4].Value = model.Sex;
            parameters[5].Value = model.BirthDay;
            parameters[6].Value = model.Photo;
            parameters[7].Value = model.Bloodtype;
            parameters[8].Value = model.Country;
            parameters[9].Value = model.Province;
            parameters[10].Value = model.City;
            parameters[11].Value = model.Phone;
            parameters[12].Value = model.Postcode;
            parameters[13].Value = model.Address;
            parameters[14].Value = model.Job;
            parameters[15].Value = model.Edu;
            parameters[16].Value = model.School;
            parameters[17].Value = model.Introduction;
            parameters[18].Value = model.UserModelID;
            parameters[19].Value = model.Annex1;
            parameters[20].Value = model.Annex2;
            parameters[21].Value = model.Annex3;
            parameters[22].Value = model.Annex4;
            parameters[23].Value = model.Annex5;
            DbHelperCms.Instance.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }
        public void UserProfile_UpdateUserProfile(BLL.User.UserProfile model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("update {0}userprofile set ", sPre);
            strSql.Append("QQ=?QQ,");
            strSql.Append("MSN=?MSN,");
            strSql.Append("ICO=?ICO,");
            strSql.Append("Sex=?Sex,");
            strSql.Append("BirthDay=?BirthDay,");
            strSql.Append("Photo=?Photo,");
            strSql.Append("Bloodtype=?Bloodtype,");
            strSql.Append("Country=?Country,");
            strSql.Append("Province=?Province,");
            strSql.Append("City=?City,");
            strSql.Append("Phone=?Phone,");
            strSql.Append("Postcode=?Postcode,");
            strSql.Append("Address=?Address,");
            strSql.Append("Job=?Job,");
            strSql.Append("Edu=?Edu,");
            strSql.Append("School=?School,");
            strSql.Append("Introduction=?Introduction,");
            strSql.Append("UserModelID=?UserModelID,");
            strSql.Append("Annex1=?Annex1,");
            strSql.Append("Annex2=?Annex2,");
            strSql.Append("Annex3=?Annex3,");
            strSql.Append("Annex4=?Annex4,");
            strSql.Append("Annex5=?Annex5");
            strSql.Append(" where UserName=?UserName and UserID=?UserID ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?UserID",  MySqlDbType.Int32,4),
					new MySqlParameter("?UserName", MySqlDbType.VarChar,50),
					new MySqlParameter("?QQ", MySqlDbType.VarChar,20),
					new MySqlParameter("?MSN", MySqlDbType.VarChar,50),
					new MySqlParameter("?ICO", MySqlDbType.VarChar,20),
					new MySqlParameter("?Sex",MySqlDbType.VarChar,10),
					new MySqlParameter("?BirthDay", MySqlDbType.Datetime),
					new MySqlParameter("?Photo", MySqlDbType.VarChar,225),
					new MySqlParameter("?Bloodtype", MySqlDbType.VarChar,5),
					new MySqlParameter("?Country", MySqlDbType.VarChar,50),
					new MySqlParameter("?Province", MySqlDbType.VarChar,50),
					new MySqlParameter("?City", MySqlDbType.VarChar,50),
					new MySqlParameter("?Phone", MySqlDbType.VarChar,50),
					new MySqlParameter("?Postcode", MySqlDbType.VarChar,10),
					new MySqlParameter("?Address", MySqlDbType.VarChar,500),
					new MySqlParameter("?Job", MySqlDbType.VarChar,50),
					new MySqlParameter("?Edu", MySqlDbType.VarChar,10),
					new MySqlParameter("?School", MySqlDbType.VarChar,50),
					new MySqlParameter("?Introduction", MySqlDbType.VarChar,1000),
					new MySqlParameter("?UserModelID", MySqlDbType.VarChar,36),
					new MySqlParameter("?Annex1", MySqlDbType.VarChar,100),
					new MySqlParameter("?Annex2", MySqlDbType.VarChar,200),
					new MySqlParameter("?Annex3", MySqlDbType.VarChar,300),
					new MySqlParameter("?Annex4", MySqlDbType.VarChar,400),
					new MySqlParameter("?Annex5", MySqlDbType.VarChar,500)};
            parameters[0].Value = model.UserID;
            parameters[1].Value = model.UserName;
            parameters[2].Value = model.QQ;
            parameters[3].Value = model.MSN;
            parameters[4].Value = model.ICO;
            parameters[5].Value = model.Sex;
            parameters[6].Value = model.BirthDay;
            parameters[7].Value = model.Photo;
            parameters[8].Value = model.Bloodtype;
            parameters[9].Value = model.Country;
            parameters[10].Value = model.Province;
            parameters[11].Value = model.City;
            parameters[12].Value = model.Phone;
            parameters[13].Value = model.Postcode;
            parameters[14].Value = model.Address;
            parameters[15].Value = model.Job;
            parameters[16].Value = model.Edu;
            parameters[17].Value = model.School;
            parameters[18].Value = model.Introduction;
            parameters[19].Value = model.UserModelID;
            parameters[20].Value = model.Annex1;
            parameters[21].Value = model.Annex2;
            parameters[22].Value = model.Annex3;
            parameters[23].Value = model.Annex4;
            parameters[24].Value = model.Annex5;
            DbHelperCms.Instance.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }
        
        public void UserProfile_DeleteUserProfile(BLL.User.UserProfile Model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("delete from {0}userprofile ", sPre);
            strSql.Append(" where UserName=?UserName and UserID=?UserID ");
            MySqlParameter[] parameters = {
                    new MySqlParameter("?UserName", MySqlDbType.VarChar,50)
                    };
            parameters[0].Value = Model.UserName;
            DbHelperCms.Instance.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }
        /// <summary>
        /// 对象实体绑定数据
        /// </summary>
        public BLL.User.UserProfile UserProfile_ReaderBind(IDataReader dataReader)
        {
            EbSite.BLL.User.UserProfile model = new BLL.User.UserProfile();

            if (dataReader["UserID"].ToString() != "")
            {
                model.UserID = int.Parse(dataReader["UserID"].ToString());
            }
            model.UserName = dataReader["UserName"].ToString();
            model.QQ = dataReader["QQ"].ToString();
            model.MSN = dataReader["MSN"].ToString();
            model.ICO = dataReader["ICO"].ToString();
            model.Sex = dataReader["Sex"].ToString();
            if (dataReader["BirthDay"].ToString() != "")
            {
                model.BirthDay = DateTime.Parse(dataReader["BirthDay"].ToString());
            }
            model.Photo = dataReader["Photo"].ToString();
            model.Bloodtype = dataReader["Bloodtype"].ToString();
            model.Country = dataReader["Country"].ToString();
            model.Province = dataReader["Province"].ToString();
            model.City = dataReader["City"].ToString();
            model.Phone = dataReader["Phone"].ToString();
            model.Postcode = dataReader["Postcode"].ToString();
            model.Address = dataReader["Address"].ToString();
            model.Job = dataReader["Job"].ToString();
            model.Edu = dataReader["Edu"].ToString();
            model.School = dataReader["School"].ToString();
            model.Introduction = dataReader["Introduction"].ToString();
            if (dataReader["UserModelID"].ToString() != "")
            {
                model.UserModelID = new Guid(dataReader["UserModelID"].ToString());
            }
            model.Annex1 = dataReader["Annex1"].ToString();
            model.Annex2 = dataReader["Annex2"].ToString();
            model.Annex3 = dataReader["Annex3"].ToString();
            model.Annex4 = dataReader["Annex4"].ToString();
            model.Annex5 = dataReader["Annex5"].ToString();
            model.MarkOld();
            return model;
        }

    }
}
