using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using EbSite.Base.DataProfile;
using MySql.Data.MySqlClient;

namespace EbSite.Modules.BBS.ModuleCore.DAL.MySql
{
	/// <summary>
	/// 数据访问类BBS。
	/// </summary>
	public partial class BBS
	{
		private string sFieldTopicReplies = "id,TopicID,UserID,UserName,IsGoodCount,IsBadCount,DeleteFlag,AuditFlag,ReplyContent,ReferenceFlag,ReferenceContent,CreatedTime,CreatedIP,UpdatedTime";

	    private string GetPostTableName(int classid)
	    {
            return Comm.GetPostTableNamePre(classid);
	    }

	    public int TopicReplies_Copy(string tablename)
	    {

            //先检查是否存在此表
            StringBuilder strSql2 = new StringBuilder();
            strSql2.AppendFormat(" SHOW TABLES LIKE '{0}';", tablename);
            List<string> list = new List<string>();
            using (IDataReader dataReader = DbHelperCms.Instance.ExecuteReader(CommandType.Text, strSql2.ToString()))
            {
                while (dataReader.Read())
                {
                    list.Add(dataReader[0].ToString());
                }
            }
            if (list.Count > 0)
            {
                //存在
                return 0;
            }
            else
            {
                StringBuilder strSql = new StringBuilder();
                strSql.AppendFormat(" CREATE TABLE {0}  LIKE {1} ;", tablename, string.Concat(sPre, "topicreplies")); //bbs_topicreplies
                DbHelperCms.Instance.ExecuteNonQuery(CommandType.Text, strSql.ToString());
            }

	        return 1;
	    }
        #region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public long TopicReplies_GetMaxId(int classid)
		{
            return DB.GetMaxID("id", string.Format("{0}", GetPostTableName(classid))); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
        public bool TopicReplies_Exists(long id, int classid)
		{
            //StringBuilder strSql=new StringBuilder();
            //strSql.AppendFormat("select count(1) from {0}TopicReplies",sPre);
            //strSql.Append(" where id=?id ");
            //MySqlParameter[] parameters = {
            //        new MySqlParameter("?id", MySqlDbType.Int32,4)};
            //parameters[0].Value = id;

            //return DB.Exists(strSql.ToString(),parameters);

            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select count(1) from {0}", GetPostTableName(classid));
            strSql.Append(" where id=?id ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32,4)};
            parameters[0].Value = id;

            return DB.Exists(strSql.ToString(), parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
        public long TopicReplies_Add(Entity.TopicReplies model, int classid)
		{
			StringBuilder strSql=new StringBuilder();
            strSql.AppendFormat("insert into {0}(", GetPostTableName(classid));
			strSql.Append("TopicID,UserID,UserName,IsGoodCount,IsBadCount,DeleteFlag,AuditFlag,ReplyContent,ReferenceFlag,ReferenceContent,CreatedTime,CreatedIP,UpdatedTime)");
			strSql.Append(" values (");
			strSql.Append("?TopicID,?UserID,?UserName,?IsGoodCount,?IsBadCount,?DeleteFlag,?AuditFlag,?ReplyContent,?ReferenceFlag,?ReferenceContent,?CreatedTime,?CreatedIP,?UpdatedTime)");
            strSql.Append(";select @@IDENTITY");
			MySqlParameter[] parameters = {
					
					new MySqlParameter("?TopicID", MySqlDbType.Int32,4),
					new MySqlParameter("?UserID", MySqlDbType.Int32,4),
					new MySqlParameter("?UserName", MySqlDbType.VarChar,50),
					new MySqlParameter("?IsGoodCount", MySqlDbType.Int32,4),
					new MySqlParameter("?IsBadCount", MySqlDbType.Int32,4),
					new MySqlParameter("?DeleteFlag", MySqlDbType.Int32,4),
					new MySqlParameter("?AuditFlag", MySqlDbType.Int32,4),
					new MySqlParameter("?ReplyContent", MySqlDbType.Text),
					new MySqlParameter("?ReferenceFlag", MySqlDbType.Int32,4),
					new MySqlParameter("?ReferenceContent", MySqlDbType.Text),
					new MySqlParameter("?CreatedTime", MySqlDbType.DateTime),
					new MySqlParameter("?CreatedIP", MySqlDbType.VarChar,20),
					new MySqlParameter("?UpdatedTime", MySqlDbType.DateTime)};
			
			parameters[0].Value = model.TopicID;
			parameters[1].Value = model.UserID;
			parameters[2].Value = model.UserName;
			parameters[3].Value = model.IsGoodCount;
			parameters[4].Value = model.IsBadCount;
			parameters[5].Value = model.DeleteFlag;
			parameters[6].Value = model.AuditFlag;
			parameters[7].Value = model.ReplyContent;
			parameters[8].Value = model.ReferenceFlag;
			parameters[9].Value = model.ReferenceContent;
			parameters[10].Value = model.CreatedTime;
			parameters[11].Value = model.CreatedIP;
			parameters[12].Value = model.UpdatedTime;
             
			object obj = DB.ExecuteScalar(CommandType.Text,strSql.ToString(),parameters);
			if (obj == null)
			{
				return 1;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
			
        }
        public void EditeReply(long id, string ContentHtml, int classid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("update {0} set ", GetPostTableName(classid));
            strSql.Append("ReplyContent=?ReplyContent,");
            strSql.Append("UpdatedTime=?UpdatedTime");
            strSql.Append(" where id=?id ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32,4),
					new MySqlParameter("?ReplyContent", MySqlDbType.Text),
					new MySqlParameter("?UpdatedTime", MySqlDbType.DateTime)};
            parameters[0].Value = id;
            parameters[1].Value = ContentHtml;
            parameters[2].Value = DateTime.Now;
            DB.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }
		/// <summary>
		/// 更新一条数据
		/// </summary>
        public void TopicReplies_Update(Entity.TopicReplies model, int classid)
		{
			StringBuilder strSql=new StringBuilder();
            strSql.AppendFormat("update {0} set ", GetPostTableName(classid));
			strSql.Append("TopicID=?TopicID,");
			strSql.Append("UserID=?UserID,");
			strSql.Append("UserName=?UserName,");
			strSql.Append("IsGoodCount=?IsGoodCount,");
			strSql.Append("IsBadCount=?IsBadCount,");
			strSql.Append("DeleteFlag=?DeleteFlag,");
			strSql.Append("AuditFlag=?AuditFlag,");
			strSql.Append("ReplyContent=?ReplyContent,");
			strSql.Append("ReferenceFlag=?ReferenceFlag,");
			strSql.Append("ReferenceContent=?ReferenceContent,");
			strSql.Append("CreatedTime=?CreatedTime,");
			strSql.Append("CreatedIP=?CreatedIP,");
			strSql.Append("UpdatedTime=?UpdatedTime");
			strSql.Append(" where id=?id ");
			MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32,4),
					new MySqlParameter("?TopicID", MySqlDbType.Int32,4),
					new MySqlParameter("?UserID", MySqlDbType.Int32,4),
					new MySqlParameter("?UserName", MySqlDbType.VarChar,50),
					new MySqlParameter("?IsGoodCount", MySqlDbType.Int32,4),
					new MySqlParameter("?IsBadCount", MySqlDbType.Int32,4),
					new MySqlParameter("?DeleteFlag", MySqlDbType.Int32,4),
					new MySqlParameter("?AuditFlag", MySqlDbType.Int32,4),
					new MySqlParameter("?ReplyContent", MySqlDbType.Text),
					new MySqlParameter("?ReferenceFlag", MySqlDbType.Int32,4),
					new MySqlParameter("?ReferenceContent", MySqlDbType.Text),
					new MySqlParameter("?CreatedTime", MySqlDbType.DateTime),
					new MySqlParameter("?CreatedIP", MySqlDbType.VarChar,20),
					new MySqlParameter("?UpdatedTime", MySqlDbType.DateTime)};
			parameters[0].Value = model.id;
			parameters[1].Value = model.TopicID;
			parameters[2].Value = model.UserID;
			parameters[3].Value = model.UserName;
			parameters[4].Value = model.IsGoodCount;
			parameters[5].Value = model.IsBadCount;
			parameters[6].Value = model.DeleteFlag;
			parameters[7].Value = model.AuditFlag;
			parameters[8].Value = model.ReplyContent;
			parameters[9].Value = model.ReferenceFlag;
			parameters[10].Value = model.ReferenceContent;
			parameters[11].Value = model.CreatedTime;
			parameters[12].Value = model.CreatedIP;
			parameters[13].Value = model.UpdatedTime;
            //parameters[14].Value = model.CompanyID;

			DB.ExecuteNonQuery(CommandType.Text,strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
        public void TopicReplies_Delete(long id, int classid)
		{
			
			StringBuilder strSql=new StringBuilder();
            strSql.AppendFormat("delete from {0} ", GetPostTableName(classid));
			strSql.Append(" where id=?id ");
			MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32,4)};
			parameters[0].Value = id;

			DB.ExecuteNonQuery(CommandType.Text,strSql.ToString(),parameters);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
        public Entity.TopicReplies TopicReplies_GetEntity(long id, int classid)
		{
			
			StringBuilder strSql=new StringBuilder();
            strSql.AppendFormat("select {1}  from {0} ", GetPostTableName(classid), sFieldTopicReplies);
			strSql.Append(" where id=?id ");
			MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32,4)};
			parameters[0].Value = id;
			Entity.TopicReplies model=null;
            
			using (IDataReader dataReader = DB.ExecuteReader(CommandType.Text, strSql.ToString(),parameters))
			{
				if(dataReader.Read())
				{
					model= TopicReplies_ReaderBind(dataReader);
				}
			}
			return model;
		}
		/// <summary>
		/// 获取统计
		/// </summary>
        public int TopicReplies_GetCount(string strWhere, int classid)
		{
			StringBuilder strSql=new StringBuilder();
            strSql.AppendFormat("select count(*)  from {0} ", GetPostTableName(classid));
			if (strWhere.Trim() != "")
			{
				strSql.Append(" where " + strWhere);
			}
			int iCount = 0;
			using (IDataReader dataReader = DB.ExecuteReader(CommandType.Text,strSql.ToString()))
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
        public DataSet TopicReplies_GetList(int Top, string strWhere, string filedOrder, int classid)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			
			strSql.Append(sFieldTopicReplies );
            strSql.AppendFormat(" FROM {0} ", GetPostTableName(classid));
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			if(filedOrder.Trim()!="")
			{
				strSql.Append(" order by  "+filedOrder);
			}
            if (Top > 0)
            {
                strSql.Append(" limit " + Top.ToString());
            }
			return DB.ExecuteDataset(CommandType.Text, strSql.ToString());
		}

		/// <summary>
		/// 获得数据列表（比DataSet效率高，推荐使用）
		/// </summary>
        public List<Entity.TopicReplies> TopicReplies_GetListArray(string strWhere, int classid)
		{
			return TopicReplies_GetListArray(0,strWhere,"",classid); 
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
        public List<Entity.TopicReplies> TopicReplies_GetListArray(int Top, string strWhere, string filedOrder, int classid)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
            //if(Top>0)
            //{
            //    strSql.Append(" top "+Top.ToString());
            //}
			strSql.Append(sFieldTopicReplies );
            strSql.AppendFormat(" FROM {0} ", GetPostTableName(classid));
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			if(filedOrder.Trim()!="")
			{
				strSql.Append(" order by  "+filedOrder);
			}

            if (Top > 0)
            {
                strSql.Append(" limit " + Top.ToString());
            }

			List<Entity.TopicReplies> list = new List<Entity.TopicReplies>();
			using (IDataReader dataReader = DB.ExecuteReader(CommandType.Text, strSql.ToString()))
			{
				while (dataReader.Read())
				{
					list.Add(TopicReplies_ReaderBind(dataReader));
				}
			}
			return list;
		}


		/// <summary>
		/// 获得分页数据
		/// </summary>
        public List<Entity.TopicReplies> TopicReplies_GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby, out int RecordCount, int classid)
		{
          

            StringBuilder sbSql = new StringBuilder();
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                //sbSql.Append(" where ");
                sbSql.AppendFormat(strWhere);
            }
            RecordCount = TopicReplies_GetCount(sbSql.ToString(),classid);
            List<Entity.TopicReplies> list = new List<Entity.TopicReplies>();
            string strSql = SplitPages.GetSplitPagesMySql(DB,Comm.GetPostTableNameNoPre(classid), PageSize, PageIndex, Fileds, "id", oderby, sbSql.ToString(), sPre);
            using (IDataReader dataReader = DB.ExecuteReader(CommandType.Text, strSql))
            {
                while (dataReader.Read())
                {
                    list.Add(TopicReplies_ReaderBind(dataReader));
                }
            }
            return list;
		}


		/// <summary>
		/// 对象实体绑定数据
		/// </summary>
		public Entity.TopicReplies TopicReplies_ReaderBind(IDataReader dataReader)
		{
			Entity.TopicReplies model=new Entity.TopicReplies();
			object ojb; 
			ojb = dataReader["id"];
			if(ojb != null && ojb != DBNull.Value)
			{
                model.id = (int)ojb;
			}
			ojb = dataReader["TopicID"];
			if(ojb != null && ojb != DBNull.Value)
			{
                model.TopicID = (int)ojb;
			}
			ojb = dataReader["UserID"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.UserID=(int)ojb;
			}
			model.UserName=dataReader["UserName"].ToString();
			ojb = dataReader["IsGoodCount"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.IsGoodCount=(int)ojb;
			}
			ojb = dataReader["IsBadCount"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.IsBadCount=(int)ojb;
			}
			ojb = dataReader["DeleteFlag"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.DeleteFlag=(int)ojb;
			}
			ojb = dataReader["AuditFlag"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.AuditFlag=(int)ojb;
			}
			model.ReplyContent=dataReader["ReplyContent"].ToString();
			ojb = dataReader["ReferenceFlag"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.ReferenceFlag=(int)ojb;
			}
			model.ReferenceContent=dataReader["ReferenceContent"].ToString();
			ojb = dataReader["CreatedTime"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.CreatedTime=(DateTime)ojb;
			}
			model.CreatedIP=dataReader["CreatedIP"].ToString();
			ojb = dataReader["UpdatedTime"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.UpdatedTime=(DateTime)ojb;
			}
            //ojb = dataReader["CompanyID"];
            //if(ojb != null && ojb != DBNull.Value)
            //{
            //    model.CompanyID=(int)ojb;
            //}
			return model;
		}

		#endregion  成员方法

        public void TopicReplies_Update(int id, string Col, string sValue, int classid)
       {
           StringBuilder strSql = new StringBuilder();
           strSql.AppendFormat("update {3} set {0}={1} where id={2}", Col, sValue, id, GetPostTableName(classid));
           DbHelperCms.Instance.ExecuteNonQuery(CommandType.Text, strSql.ToString());
       }
	}
}

