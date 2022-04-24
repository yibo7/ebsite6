using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using EbSite.Base.DataProfile;

namespace EbSite.Data.MySql
{
    /// <summary>
    /// 数据访问类RemarkSublistSublist。
    /// </summary>
    public partial class DataProviderCms : Interface.IDataProviderCms
    {
        #region 读

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int RemarkSublist_GetMaxId()
        {
            return DbHelperCms.Instance.GetMaxID("ID", "remarksublist");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool RemarkSublist_Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select count(1) from  {0}remarksublist ", sPre);
            strSql.Append(" where ID=?ID ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?ID",  MySqlDbType.Int32,4)};
            parameters[0].Value = ID;

            return DbHelperCms.Instance.Exists(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 获取总记录条数
        /// </summary>
        /// <returns></returns>
        public int RemarkSublist_GetCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(*) ");
            strSql.AppendFormat(" from  {0}remarksublist ", sPre);

            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            int iCount = -1;
            using (IDataReader dataReader = DbHelperCms.Instance.ExecuteReader(CommandType.Text, strSql.ToString()))
            {
                while (dataReader.Read())
                {
                    iCount = int.Parse(dataReader[0].ToString());
                }
            }
            return iCount;
        }
        public int RemarkSublist_GetCount(string Mark, bool IsAuditing)
        {
            StringBuilder sbWhere = new StringBuilder();
            sbWhere.AppendFormat("IsAuditing={0}", (IsAuditing ? "1" : "0"));
            if (!string.IsNullOrEmpty(Mark))
            {
                sbWhere.AppendFormat("  and Mark='{0}'", Mark.Replace("'", "''"));
            }
            return RemarkSublist_GetCount(sbWhere.ToString());
        }

        public int RemarkSublist_GetCountByClassID(bool IsAuditing)
        {
            string sWhere = " IsAuditing=" + (IsAuditing ? "1" : "0");

            return RemarkSublist_GetCount(sWhere);
        }




        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public EbSite.Entity.RemarkSublist RemarkSublist_GetModel(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select  ID,Body,Ip,Quote,Support,Discourage,Information,DateAndTime,IsNiName,IsAuditing,Mark,UserID,UserName,UserNiName,ParentID from  {0}remarksublist   ", sPre);
            strSql.Append(" where ID=?ID limit 1 ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?ID",  MySqlDbType.Int32,4)};
            parameters[0].Value = ID;

            EbSite.Entity.RemarkSublist model = new Entity.RemarkSublist();

            using (IDataReader dataReader = DbHelperCms.Instance.ExecuteReader(CommandType.Text, strSql.ToString(), parameters))
            {
                if (dataReader.Read())
                {
                    model = RemarkSublist_ReaderBind(dataReader);
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet RemarkSublist_GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,Body,Ip,Quote,Support,Discourage,Information,DateAndTime,IsNiName,IsAuditing,Mark,UserID,UserName,UserNiName,ParentID ");
            strSql.AppendFormat(" from  {0}remarksublist  ", sPre);
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperCms.Instance.ExecuteDataset(CommandType.Text, strSql.ToString());
        }
        public List<EbSite.Entity.RemarkSublist> RemarkSublist_GetListPages(int PageIndex, int PageSize, string strWhere, string oderby, int IsAuditing)
        {

            string sIsAuditing = string.Empty;

            if (IsAuditing == 1)
            {
                sIsAuditing = "IsAuditing=1";
            }
            else if (IsAuditing == 0)
            {
                sIsAuditing = "IsAuditing=0";
            }

            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                if (!string.IsNullOrEmpty(sIsAuditing))
                    strWhere = string.Concat(strWhere, " and ", sIsAuditing);

            }
            else
            {
                strWhere = sIsAuditing;
            }

            //int RecordCount = 0;

            List<EbSite.Entity.RemarkSublist> list = new List<EbSite.Entity.RemarkSublist>();

            //RecordCount = RemarkSublist_GetCount(strWhere);
            string strSql = SplitPages.GetSplitPagesMySql(DbHelperCms.Instance, "RemarkSublist", PageSize, PageIndex, "", "id", oderby, strWhere, sPre);

            using (IDataReader dataReader = DbHelperCms.Instance.ExecuteReader(CommandType.Text, strSql))
            {
                while (dataReader.Read())
                {
                    list.Add(RemarkSublist_ReaderBind(dataReader));
                }
            }
            return list;


            //string sFields = "ID,Body,Ip,Quote,Support,Discourage,Information,DateAndTime,IsNiName,RemarkSublistClassID,IsAuditing,Mark,UserID,UserName,UserNiName";
            //string strSql = SplitPages.GetSplitPagesSql("RemarkSublist", PageSize, PageIndex, sFields, "id", oderby, strWhere);


            //List<EbSite.Entity.RemarkSublist> list = new List<EbSite.Entity.RemarkSublist>();

            //using (IDataReader dataReader = DbHelperCms.Instance.ExecuteReader(CommandType.Text,strSql.ToString()))
            //{
            //    while (dataReader.Read())
            //    {
            //        list.Add(RemarkSublist_ReaderBind(dataReader));
            //    }
            //}
            //return list;

        }

        public EbSite.Entity.RemarkSublist RemarkSublist_ReaderBind(IDataReader dataReader)
        {
            Entity.RemarkSublist model = new Entity.RemarkSublist();
            if (dataReader["ID"].ToString() != "")
            {
                model.ID = int.Parse(dataReader["ID"].ToString());
            }

            model.UserName = dataReader["Username"].ToString();
            model.Body = dataReader["Body"].ToString();
            model.Ip = dataReader["Ip"].ToString();
            model.Quote = dataReader["Quote"].ToString();
            model.Mark = dataReader["Mark"].ToString();
            if (dataReader["Support"].ToString() != "")
            {
                model.Support = int.Parse(dataReader["Support"].ToString());
            }
            if (dataReader["Discourage"].ToString() != "")
            {
                model.Discourage = int.Parse(dataReader["Discourage"].ToString());
            }
            if (dataReader["Information"].ToString() != "")
            {
                model.Information = int.Parse(dataReader["Information"].ToString());
            }
            if (dataReader["DateAndTime"].ToString() != "")
            {
                model.DateAndTime = DateTime.Parse(dataReader["DateAndTime"].ToString());
            }

            if (dataReader["IsNiName"].ToString() != "")
            {
                if ((dataReader["IsNiName"].ToString() == "1") || (dataReader["IsNiName"].ToString().ToLower() == "true"))
                {
                    model.IsNiName = true;
                }
                else
                {
                    model.IsNiName = false;
                }
            }
            if (dataReader["IsAuditing"].ToString() != "")
            {
                if ((dataReader["IsAuditing"].ToString() == "1") || (dataReader["IsAuditing"].ToString().ToLower() == "true"))
                {
                    model.IsAuditing = true;
                }
                else
                {
                    model.IsAuditing = false;
                }
            }



            if (dataReader["UserID"].ToString() != "")
            {
                model.UserID = int.Parse(dataReader["UserID"].ToString());
            }
            model.UserNiName = dataReader["UserNiName"].ToString();

            if (dataReader["ParentID"].ToString() != "")
            {
                model.ParentID = int.Parse(dataReader["ParentID"].ToString());
            }
            return model;
        }

        #endregion 读

        #region 写

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void RemarkSublist_Add(EbSite.Entity.RemarkSublist model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("insert into {0}remarksublist(", sPre);
            strSql.Append("Body,Ip,Quote,Support,Discourage,Information,DateAndTime,IsNiName,IsAuditing,Mark,UserID,UserName,UserNiName,ParentID)");
            strSql.Append(" values (");
            strSql.Append("?Body,?Ip,?Quote,?Support,?Discourage,?Information,?DateAndTime,?IsNiName,?IsAuditing,?Mark,?UserID,?UserName,?UserNiName,?ParentID)");
            //strSql.Append(";select ??IDENTITY");
            MySqlParameter[] parameters = {
					new MySqlParameter("?Body", MySqlDbType.Text),
					new MySqlParameter("?Ip", MySqlDbType.VarChar,20),
					new MySqlParameter("?Quote", MySqlDbType.Text),
					new MySqlParameter("?Support",  MySqlDbType.Int32,4),
					new MySqlParameter("?Discourage",  MySqlDbType.Int32,4),
					new MySqlParameter("?Information",  MySqlDbType.Int32,4),
					new MySqlParameter("?DateAndTime", MySqlDbType.Datetime),
					new MySqlParameter("?IsNiName", MySqlDbType.Int16,1),	
					new MySqlParameter("?IsAuditing", MySqlDbType.Int16,1),
					new MySqlParameter("?Mark", MySqlDbType.VarChar,50),
					new MySqlParameter("?UserID",  MySqlDbType.Int32,4),
					new MySqlParameter("?UserName", MySqlDbType.VarChar,50),
					new MySqlParameter("?UserNiName", MySqlDbType.VarChar,50),
                    new MySqlParameter("?ParentID",MySqlDbType.Int32,4) };
            parameters[0].Value = model.Body;
            parameters[1].Value = model.Ip;
            parameters[2].Value = model.Quote;
            parameters[3].Value = model.Support;
            parameters[4].Value = model.Discourage;
            parameters[5].Value = model.Information;
            parameters[6].Value = model.DateAndTime;
            parameters[7].Value = model.IsNiName;

            parameters[8].Value = model.IsAuditing;
            parameters[9].Value = model.Mark;
            parameters[10].Value = model.UserID;
            parameters[11].Value = model.UserName;
            parameters[12].Value = model.UserNiName;
            parameters[13].Value = model.ParentID;
            DbHelperCmsWrite.Instance.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
            //object obj = DbHelperCmsWrite.Instance.ExecuteScalar(CommandType.Text,strSql.ToString(), parameters);
            //if (obj == null)
            //{
            //    return 1;
            //}
            //else
            //{
            //    return Convert.ToInt32(obj);
            //}
        }
        /// <summary>
        /// 帖子操作
        /// </summary>
        /// <param name="postid"></param>
        /// <param name="flag"></param>
        public void RemarkSublist_ExecutePost(int postid, int flag)
        {

            string sWhere = "Support=Support+1";


            switch (flag)
            {
                //case 0:   //支持
                //    sWhere = "Support=Support+1";
                //    break;
                case 1:  //反对
                    sWhere = "Discourage=Discourage+1";
                    break;
                case 2: //举报
                    sWhere = "Information=Information+1";
                    break;
            }

            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("update {0}remarksublist set ", sPre);
            strSql.Append(sWhere);
            strSql.Append(" where ID=" + postid);

            DbHelperCmsWrite.Instance.ExecuteNonQuery(CommandType.Text, strSql.ToString());

            //object obj = DbHelperCmsWrite.Instance.ExecuteScalar(CommandType.Text,strSql.ToString());
            //if (obj == null)
            //{
            //    return 0;
            //}
            //else
            //{
            //    return Convert.ToInt32(obj);
            //}

        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void RemarkSublist_Update(EbSite.Entity.RemarkSublist model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("update {0}remarksublist set ", sPre);
            strSql.Append("Body=?Body,");
            strSql.Append("Ip=?Ip,");
            strSql.Append("Quote=?Quote,");
            strSql.Append("Support=?Support,");
            strSql.Append("Discourage=?Discourage,");
            strSql.Append("Information=?Information,");
            strSql.Append("DateAndTime=?DateAndTime,");
            strSql.Append("IsNiName=?IsNiName,");
            strSql.Append("IsAuditing=?IsAuditing,");
            strSql.Append("Mark=?Mark,");
            strSql.Append("UserID=?UserID,");
            strSql.Append("UserName=?UserName,");
            strSql.Append("UserNiName=?UserNiName,");
            strSql.Append("ParentID=?ParentID");
            strSql.Append(" where ID=?ID ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?ID",  MySqlDbType.Int32,4),
					new MySqlParameter("?Body", MySqlDbType.Text),
					new MySqlParameter("?Ip", MySqlDbType.VarChar,20),
					new MySqlParameter("?Quote", MySqlDbType.Text),
					new MySqlParameter("?Support",  MySqlDbType.Int32,4),
					new MySqlParameter("?Discourage",  MySqlDbType.Int32,4),
					new MySqlParameter("?Information",  MySqlDbType.Int32,4),
					new MySqlParameter("?DateAndTime", MySqlDbType.Datetime),
					new MySqlParameter("?IsNiName", MySqlDbType.Int16,1),
					new MySqlParameter("?IsAuditing", MySqlDbType.Int16,1),
					new MySqlParameter("?Mark", MySqlDbType.VarChar,50),
					new MySqlParameter("?UserID",  MySqlDbType.Int32,4),
					new MySqlParameter("?UserName", MySqlDbType.VarChar,50),
					new MySqlParameter("?UserNiName", MySqlDbType.VarChar,50),
                    new MySqlParameter("?ParentID",MySqlDbType.Int32,4)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.Body;
            parameters[2].Value = model.Ip;
            parameters[3].Value = model.Quote;
            parameters[4].Value = model.Support;
            parameters[5].Value = model.Discourage;
            parameters[6].Value = model.Information;
            parameters[7].Value = model.DateAndTime;
            parameters[8].Value = model.IsNiName;

            parameters[9].Value = model.IsAuditing;
            parameters[10].Value = model.Mark;
            parameters[11].Value = model.UserID;
            parameters[12].Value = model.UserName;
            parameters[13].Value = model.UserNiName;
            parameters[14].Value = model.ParentID;
            DbHelperCmsWrite.Instance.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void RemarkSublist_Delete(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("delete  from {0}remarksublist ", sPre);
            strSql.Append(" where ID=?ID ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?ID",  MySqlDbType.Int32,4)};
            parameters[0].Value = ID;

            DbHelperCmsWrite.Instance.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }

        #endregion 写

    }
}

