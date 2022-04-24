using System;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using EbSite.Base.DataProfile;
namespace EbSite.Data.MySql
{
	/// <summary>
	/// 数据访问类a。
	/// </summary>
    public partial class DataProviderCms : Interface.IDataProviderCms
	{
        private string sFieldvote = "id,VoteName,AllowMaxSel,IsMoreSel,MarkInt,MarkStr,VoteCount,StartDate,EndDate,IsItemColorRan,VoteInfo,ClassID";

        #region 读

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int vote_GetMaxId()
        {
            return DbHelperCms.Instance.GetMaxID("id", string.Format("{0}vote", sPre));
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool vote_Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select count(1) from {0}vote", sPre);
            strSql.Append(" where id=?id ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32)};
            parameters[0].Value = id;

            return DbHelperCms.Instance.Exists(strSql.ToString(), parameters);
        }




        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Entity.vote vote_GetEntity(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select " + sFieldvote + "  from {0}vote ", sPre);
            strSql.Append(" where id=?id ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32)};
            parameters[0].Value = id;
            Entity.vote model = null;
            using (IDataReader dataReader = DbHelperCms.Instance.ExecuteReader(CommandType.Text, strSql.ToString(), parameters))
            {
                if (dataReader.Read())
                {
                    model = vote_ReaderBind(dataReader);
                }
            }
            return model;
        }
        /// <summary>
        /// 获取统计
        /// </summary>
        public int vote_GetCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select count(*)  from {0}vote ", sPre);
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            int iCount = 0;
            using (IDataReader dataReader = DbHelperCms.Instance.ExecuteReader(CommandType.Text, strSql.ToString()))
            {
                while (dataReader.Read())
                {
                    iCount = int.Parse(dataReader[0].ToString());
                }
            }
            return iCount;
        }


        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet vote_GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");

            strSql.Append(sFieldvote);
            strSql.AppendFormat(" FROM {0}vote ", sPre);
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            if (filedOrder.Trim() != "")
            {
                strSql.Append(" order by  " + filedOrder);
            }

            if (Top > 0)
            {
                strSql.Append(" limit " + Top.ToString());
            }
            return DbHelperCms.Instance.ExecuteDataset(CommandType.Text, strSql.ToString());
        }

        /// <summary>
        /// 获得数据列表（比DataSet效率高，推荐使用）
        /// </summary>
        public List<Entity.vote> vote_GetListArray(string strWhere)
        {
            return vote_GetListArray(0, strWhere, "");
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public List<Entity.vote> vote_GetListArray(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");

            strSql.Append(sFieldvote);
            strSql.AppendFormat(" FROM {0}vote ", sPre);
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            if (filedOrder.Trim() != "")
            {
                strSql.Append(" order by  " + filedOrder);
            }

            if (Top > 0)
            {
                strSql.Append(" limit " + Top.ToString());
            }
            List<Entity.vote> list = new List<Entity.vote>();
            using (IDataReader dataReader = DbHelperCms.Instance.ExecuteReader(CommandType.Text, strSql.ToString()))
            {
                while (dataReader.Read())
                {
                    list.Add(vote_ReaderBind(dataReader));
                }
            }
            return list;
        }


        /// <summary>
        /// 获得分页数据
        /// </summary>
        public List<Entity.vote> vote_GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby, out int RecordCount)
        {
            List<Entity.vote> list = new List<Entity.vote>();
            RecordCount = vote_GetCount(strWhere);
            string strSql = SplitPages.GetSplitPagesMySql(DbHelperCms.Instance, "vote", PageSize, PageIndex, Fileds, "id", oderby, strWhere, sPre);
            using (IDataReader dataReader = DbHelperCms.Instance.ExecuteReader(CommandType.Text, strSql))
            {
                while (dataReader.Read())
                {
                    list.Add(vote_ReaderBind(dataReader));
                }
            }
            return list;
        }


        /// <summary>
        /// 对象实体绑定数据
        /// </summary>
        public Entity.vote vote_ReaderBind(IDataReader dataReader)
        {
            Entity.vote model = new Entity.vote();
            object ojb;
            ojb = dataReader["id"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.id = (int)ojb;
            }
            model.VoteName = dataReader["VoteName"].ToString();
            ojb = dataReader["AllowMaxSel"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.AllowMaxSel = (int)ojb;
            }
            ojb = dataReader["IsMoreSel"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.IsMoreSel = bool.Parse(ojb.ToString());
            }
            ojb = dataReader["MarkInt"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.MarkInt = (int)ojb;
            }
            model.MarkStr = dataReader["MarkStr"].ToString();
            ojb = dataReader["VoteCount"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.VoteCount = (int)ojb;
            }
            ojb = dataReader["StartDate"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.StartDate = (int)ojb;
            }
            ojb = dataReader["EndDate"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.EndDate = (int)ojb;
            }
            ojb = dataReader["IsItemColorRan"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.IsItemColorRan = (bool)ojb;
            }
            model.VoteInfo = dataReader["VoteInfo"].ToString();


            ojb = dataReader["ClassID"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.ClassID = (int)ojb;
            }
            return model;
        }

        #endregion 读

        #region 写

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int vote_Add(Entity.vote model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("insert into {0}vote(", sPre);
            strSql.Append("VoteName,AllowMaxSel,IsMoreSel,MarkInt,MarkStr,VoteCount,StartDate,EndDate,IsItemColorRan,VoteInfo,ClassID)");
            strSql.Append(" values (");
            strSql.Append("?VoteName,?AllowMaxSel,?IsMoreSel,?MarkInt,?MarkStr,?VoteCount,?StartDate,?EndDate,?IsItemColorRan,?VoteInfo,?ClassID)");
            strSql.Append(";SELECT @@session.identity");
            MySqlParameter[] parameters = {
					new MySqlParameter("?VoteName", MySqlDbType.VarChar,50),
					new MySqlParameter("?AllowMaxSel", MySqlDbType.Int32,4),
					new MySqlParameter("?IsMoreSel", MySqlDbType.Int16,1),
					new MySqlParameter("?MarkInt", MySqlDbType.Int32,11),
					new MySqlParameter("?MarkStr", MySqlDbType.VarChar,20),
					new MySqlParameter("?VoteCount", MySqlDbType.Int32,11),
					new MySqlParameter("?StartDate", MySqlDbType.Int32,10),
					new MySqlParameter("?EndDate", MySqlDbType.Int32,10),
					new MySqlParameter("?IsItemColorRan", MySqlDbType.Int16,1),
					new MySqlParameter("?VoteInfo", MySqlDbType.VarChar,500),
                    new MySqlParameter("?ClassID",MySqlDbType.Int32,11) };
            parameters[0].Value = model.VoteName;
            parameters[1].Value = model.AllowMaxSel;
            parameters[2].Value = model.IsMoreSel;
            parameters[3].Value = model.MarkInt;
            parameters[4].Value = model.MarkStr;
            parameters[5].Value = model.VoteCount;
            parameters[6].Value = model.StartDate;
            parameters[7].Value = model.EndDate;
            parameters[8].Value = model.IsItemColorRan;
            parameters[9].Value = model.VoteInfo;
            parameters[10].Value = model.ClassID;

            object obj = DbHelperCmsWrite.Instance.ExecuteScalar(CommandType.Text, strSql.ToString(), parameters);
            if (obj == null)
            {
                return vote_GetMaxId();
            }
            return 0;
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void vote_Update(Entity.vote model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("update {0}vote set ", sPre);
            strSql.Append("VoteName=?VoteName,");
            strSql.Append("AllowMaxSel=?AllowMaxSel,");
            strSql.Append("IsMoreSel=?IsMoreSel,");
            strSql.Append("MarkInt=?MarkInt,");
            strSql.Append("MarkStr=?MarkStr,");
            strSql.Append("VoteCount=?VoteCount,");
            strSql.Append("StartDate=?StartDate,");
            strSql.Append("EndDate=?EndDate,");
            strSql.Append("IsItemColorRan=?IsItemColorRan,");
            strSql.Append("VoteInfo=?VoteInfo,");
            strSql.Append("ClassID=?ClassID");
            strSql.Append(" where id=?id ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32,11),
					new MySqlParameter("?VoteName", MySqlDbType.VarChar,50),
					new MySqlParameter("?AllowMaxSel", MySqlDbType.Int32,4),
					new MySqlParameter("?IsMoreSel", MySqlDbType.Int32,1),
					new MySqlParameter("?MarkInt", MySqlDbType.Int32,11),
					new MySqlParameter("?MarkStr", MySqlDbType.VarChar,20),
					new MySqlParameter("?VoteCount", MySqlDbType.Int32,11),
					new MySqlParameter("?StartDate", MySqlDbType.Int32,10),
					new MySqlParameter("?EndDate", MySqlDbType.Int32,10),
					new MySqlParameter("?IsItemColorRan", MySqlDbType.Int16,1),
					new MySqlParameter("?VoteInfo", MySqlDbType.VarChar,500),
                    new MySqlParameter("?ClassID",MySqlDbType.Int32,11) 
                                          };
            parameters[0].Value = model.id;
            parameters[1].Value = model.VoteName;
            parameters[2].Value = model.AllowMaxSel;
            parameters[3].Value = model.IsMoreSel;
            parameters[4].Value = model.MarkInt;
            parameters[5].Value = model.MarkStr;
            parameters[6].Value = model.VoteCount;
            parameters[7].Value = model.StartDate;
            parameters[8].Value = model.EndDate;
            parameters[9].Value = model.IsItemColorRan;
            parameters[10].Value = model.VoteInfo;
            parameters[11].Value = model.ClassID;

            DbHelperCmsWrite.Instance.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void vote_Delete(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("delete from {0}vote ", sPre);
            strSql.Append(" where id=?id ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32)};
            parameters[0].Value = id;

            DbHelperCmsWrite.Instance.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }

        public void PostVoteSingle(int vid, int itemid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("update {0}vote set ", sPre);
            strSql.AppendFormat("VoteCount=VoteCount+1 where id={0};", vid);
            strSql.AppendFormat("update {0}voteitem set ", sPre);
            strSql.AppendFormat("PostCount=PostCount+1 where id={0};", itemid);
            DbHelperCmsWrite.Instance.ExecuteNonQuery(CommandType.Text, strSql.ToString());
        }
        public void PostVoteMore(int vid, string itemids)
        {
            string[] aItems = itemids.Split(',');
            if (aItems.Length > 0)
            {
                StringBuilder strSql = new StringBuilder();
                strSql.AppendFormat("update {0}vote set ", sPre);
                strSql.AppendFormat("VoteCount=VoteCount+{0} where id={1};", aItems.Length, vid);
                strSql.AppendFormat("update {0}voteitem set ", sPre);
                strSql.AppendFormat("PostCount=PostCount+1 where id in({0});", itemids);
                DbHelperCmsWrite.Instance.ExecuteNonQuery(CommandType.Text, strSql.ToString());
            }

        }

        #endregion 写

    }
}

