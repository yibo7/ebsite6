using System;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using EbSite.Base.DataProfile;
using EbSite.Entity;

namespace EbSite.Data.MySql
{
    
    public partial class DataProviderCms : Interface.IDataProviderCms
    {
		private string sFieldspiderlog = "Id,SpiderName,SpiderId,Url,AddDateTime,AddDateTimeInt,UserAgent,HttpState,UrlPath,Domain";
		#region  成员方法

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool spiderlog_Exists(long Id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("select count(1) from {0}spiderlog",sPre);
			strSql.Append(" where Id=?Id ");
			MySqlParameter[] parameters = {
					new MySqlParameter("?Id", MySqlDbType.Int64)};
			parameters[0].Value = Id;

			return DbHelperCms.Instance.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int spiderlog_Add(Entity.spiderlog model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("insert into {0}spiderlog(",sPre);
			strSql.Append("SpiderName,SpiderId,Url,AddDateTime,AddDateTimeInt,UserAgent,HttpState,UrlPath,Domain)");
			strSql.Append(" values (");
			strSql.Append("?SpiderName,?SpiderId,?Url,?AddDateTime,?AddDateTimeInt,?UserAgent,?HttpState,?UrlPath,?Domain)");
			 strSql.Append(";SELECT @@session.identity");
			MySqlParameter[] parameters = {
					new MySqlParameter("?SpiderName", MySqlDbType.VarChar,50),
					new MySqlParameter("?SpiderId", MySqlDbType.Int32,11),
					new MySqlParameter("?Url", MySqlDbType.VarChar,300),
					new MySqlParameter("?AddDateTime", MySqlDbType.DateTime),
					new MySqlParameter("?AddDateTimeInt", MySqlDbType.Int64,20),
					new MySqlParameter("?UserAgent", MySqlDbType.VarChar,500),
					new MySqlParameter("?HttpState", MySqlDbType.Int32,10),
					new MySqlParameter("?UrlPath", MySqlDbType.VarChar,255),
					new MySqlParameter("?Domain", MySqlDbType.VarChar,255)};
			parameters[0].Value = model.SpiderName;
			parameters[1].Value = model.SpiderId;
			parameters[2].Value = model.Url;
			parameters[3].Value = model.AddDateTime;
			parameters[4].Value = model.AddDateTimeInt;
			parameters[5].Value = model.UserAgent;
			parameters[6].Value = model.HttpState;
			parameters[7].Value = model.UrlPath;
			parameters[8].Value = model.Domain;

			object obj = DbHelperCms.Instance.ExecuteScalar(CommandType.Text,strSql.ToString(),parameters);
			if (obj != null)
			{
				return int.Parse(obj.ToString());
			}
			return 0;
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void spiderlog_Update(Entity.spiderlog model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("update {0}spiderlog set ",sPre);
			strSql.Append("SpiderName=?SpiderName,");
			strSql.Append("SpiderId=?SpiderId,");
			strSql.Append("Url=?Url,");
			strSql.Append("AddDateTime=?AddDateTime,");
			strSql.Append("AddDateTimeInt=?AddDateTimeInt,");
			strSql.Append("UserAgent=?UserAgent,");
			strSql.Append("HttpState=?HttpState,");
			strSql.Append("UrlPath=?UrlPath,");
			strSql.Append("Domain=?Domain");
			strSql.Append(" where Id=?Id ");
			MySqlParameter[] parameters = {
					new MySqlParameter("?Id", MySqlDbType.Int64,20),
					new MySqlParameter("?SpiderName", MySqlDbType.VarChar,50),
					new MySqlParameter("?SpiderId", MySqlDbType.Int32,11),
					new MySqlParameter("?Url", MySqlDbType.VarChar,300),
					new MySqlParameter("?AddDateTime", MySqlDbType.DateTime),
					new MySqlParameter("?AddDateTimeInt", MySqlDbType.Int64,20),
					new MySqlParameter("?UserAgent", MySqlDbType.VarChar,500),
					new MySqlParameter("?HttpState", MySqlDbType.Int32,10),
					new MySqlParameter("?UrlPath", MySqlDbType.VarChar,255),
					new MySqlParameter("?Domain", MySqlDbType.VarChar,255)};
			parameters[0].Value = model.Id;
			parameters[1].Value = model.SpiderName;
			parameters[2].Value = model.SpiderId;
			parameters[3].Value = model.Url;
			parameters[4].Value = model.AddDateTime;
			parameters[5].Value = model.AddDateTimeInt;
			parameters[6].Value = model.UserAgent;
			parameters[7].Value = model.HttpState;
			parameters[8].Value = model.UrlPath;
			parameters[9].Value = model.Domain;

			DbHelperCms.Instance.ExecuteNonQuery(CommandType.Text,strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void spiderlog_Delete(long Id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("delete from {0}spiderlog ",sPre);
			strSql.Append(" where Id=?Id ");
			MySqlParameter[] parameters = {
					new MySqlParameter("?Id", MySqlDbType.Int64)};
			parameters[0].Value = Id;

			DbHelperCms.Instance.ExecuteNonQuery(CommandType.Text,strSql.ToString(),parameters);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Entity.spiderlog spiderlog_GetEntity(long Id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("select "+ sFieldspiderlog +"  from {0}spiderlog ",sPre);
			strSql.Append(" where Id=?Id ");
			MySqlParameter[] parameters = {
					new MySqlParameter("?Id", MySqlDbType.Int64)};
			parameters[0].Value = Id;
			Entity.spiderlog model=null;
			using (IDataReader dataReader = DbHelperCms.Instance.ExecuteReader(CommandType.Text, strSql.ToString(),parameters))
			{
				if(dataReader.Read())
				{
					model= spiderlog_ReaderBind(dataReader);
				}
			}
			return model;
		}
		/// <summary>
		/// 获取统计
		/// </summary>
		public int spiderlog_GetCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("select count(*)  from {0}spiderlog ",sPre);
			if (strWhere.Trim() != "")
			{
				strSql.Append(" where " + strWhere);
			}
			int iCount = 0;
			using (IDataReader dataReader = DbHelperCms.Instance.ExecuteReader(CommandType.Text,strSql.ToString()))
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
		public DataSet spiderlog_GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			strSql.Append(sFieldspiderlog );
			strSql.AppendFormat(" FROM {0}spiderlog ",sPre);
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			if(filedOrder.Trim()!="")
			{
				strSql.Append(" order by  "+filedOrder);
			}
			if(Top>0)
			{
				strSql.Append(" limit "+Top.ToString());
			}
			return DbHelperCms.Instance.ExecuteDataset(CommandType.Text, strSql.ToString());
		}

		/// <summary>
		/// 获得数据列表（比DataSet效率高，推荐使用）
		/// </summary>
		public List<Entity.spiderlog> spiderlog_GetListArray(string strWhere)
		{
			return spiderlog_GetListArray(0,strWhere,""); 
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public List<Entity.spiderlog> spiderlog_GetListArray(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			strSql.Append(sFieldspiderlog );
			strSql.AppendFormat(" FROM {0}spiderlog ",sPre);
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			if(filedOrder.Trim()!="")
			{
				strSql.Append(" order by  "+filedOrder);
			}
			if(Top>0)
			{
				strSql.Append(" limit "+Top.ToString());
			}
			List<Entity.spiderlog> list = new List<Entity.spiderlog>();
			using (IDataReader dataReader = DbHelperCms.Instance.ExecuteReader(CommandType.Text, strSql.ToString()))
			{
				while (dataReader.Read())
				{
					list.Add(spiderlog_ReaderBind(dataReader));
				}
			}
			return list;
		}


		/// <summary>
		/// 获得分页数据
		/// </summary>
		public List<Entity.spiderlog> spiderlog_GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby,out int RecordCount)
		{
			List<Entity.spiderlog> list = new List<Entity.spiderlog>();
			StringBuilder sbSql = new StringBuilder();
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				sbSql.AppendFormat(strWhere);
			}
			RecordCount = spiderlog_GetCount(sbSql.ToString());
			string strSql = SplitPages.GetSplitPagesMySql(DbHelperCms.Instance, "spiderlog", PageSize, PageIndex, Fileds, "Id", oderby, sbSql.ToString(), sPre);
			using (IDataReader dataReader = DbHelperCms.Instance.ExecuteReader(CommandType.Text, strSql))
			{
				 while (dataReader.Read())
				{
					 list.Add(spiderlog_ReaderBind(dataReader));
				}
			}
			return list;
		}


		/// <summary>
		/// 对象实体绑定数据
		/// </summary>
		public Entity.spiderlog spiderlog_ReaderBind(IDataReader dataReader)
		{
			Entity.spiderlog model=new Entity.spiderlog();
			object ojb; 
			model.Id= int.Parse(dataReader["Id"].ToString());

			model.SpiderName=dataReader["SpiderName"].ToString();

			ojb = dataReader["SpiderId"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.SpiderId=(int)ojb;
			}
			model.Url=dataReader["Url"].ToString();
            if(!Equals(dataReader["AddDateTime"],null))
			    model.AddDateTime=DateTime.Parse(dataReader["AddDateTime"].ToString());
            if(!Equals(dataReader["AddDateTimeInt"],null))
			    model.AddDateTimeInt= long.Parse(dataReader["AddDateTimeInt"].ToString());

			model.UserAgent=dataReader["UserAgent"].ToString();

			ojb = dataReader["HttpState"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.HttpState=(int)ojb;
			}
			model.UrlPath=dataReader["UrlPath"].ToString();

			model.Domain=dataReader["Domain"].ToString();

			return model;
		}

        #endregion  成员方法

        /// <summary>
        /// 统计来访数据
        /// </summary>
        /// <param name="spiderid">The spiderid.</param>
        /// <param name="itype">类型,1.今日来访，2昨日来访，3前7天来访，4前30天来访</param>
        /// <returns>System.Int32.</returns>
        public int GetLogCount(int spiderid, int itype)
        {
            int iCount = 0;
            string sql = "";
            switch (itype)
            {
                case 1:
                    sql = string.Format("SELECT COUNT(*) FROM eb_spiderlog WHERE AddDateTime  BETWEEN DATE_FORMAT(DATE_ADD(now(),INTERVAL 0 DAY),'%Y-%m-%d') and DATE_FORMAT(DATE_ADD(now(),INTERVAL +1 DAY),'%Y-%m-%d') AND SpiderId={0}", spiderid);
                    break;
                case 2:
                    sql = string.Format("SELECT COUNT(*) FROM eb_spiderlog WHERE AddDateTime  BETWEEN DATE_FORMAT(DATE_ADD(now(),INTERVAL -1 DAY),'%Y-%m-%d') and DATE_FORMAT(DATE_ADD(now(),INTERVAL 0 DAY),'%Y-%m-%d')  AND SpiderId={0}", spiderid);
                    break;
                case 3:
                    sql = string.Format("SELECT COUNT(*) FROM eb_spiderlog WHERE AddDateTime  BETWEEN DATE_FORMAT(DATE_ADD(now(),INTERVAL -7 DAY),'%Y-%m-%d') and DATE_FORMAT(DATE_ADD(now(),INTERVAL -6 DAY),'%Y-%m-%d')  AND SpiderId={0}", spiderid);
                    break;
                case 4:
                    sql = string.Format("SELECT COUNT(*) FROM eb_spiderlog WHERE AddDateTime  BETWEEN DATE_FORMAT(DATE_ADD(now(),INTERVAL -30 DAY),'%Y-%m-%d') and DATE_FORMAT(DATE_ADD(now(),INTERVAL -29 DAY),'%Y-%m-%d')  AND SpiderId={0}", spiderid);
                    break;

            }

            if (!string.IsNullOrEmpty(sql))
            {
                object obj = DbHelperCms.Instance.ExecuteScalar(CommandType.Text, sql);
                if (obj != null)
                {
                    iCount =  int.Parse(obj.ToString());
                }
            } 

            return iCount;
        }

        public List<Entity.ListItemModel> GetVisitSum(string strWhere,int iTop)
        {
            List<Entity.ListItemModel> list = new List<Entity.ListItemModel>();
            if (!string.IsNullOrEmpty(strWhere))
            {
                strWhere = string.Concat("WHERE ", strWhere);
            }
             
            string strSql = string.Format("SELECT Url,count(0) as vnum FROM {0}spiderlog {1} GROUP BY Url ORDER BY vnum DESC LIMIT {2}", sPre, strWhere, iTop);
            using (IDataReader dataReader = DbHelperCms.Instance.ExecuteReader(CommandType.Text, strSql))
            {
                while (dataReader.Read())
                {
                    list.Add(new ListItemModel(dataReader["Url"].ToString(), dataReader["vnum"].ToString()));
                }
            }
            return list;
        }
        /// <summary>
        /// 最近时段分析
        /// </summary>
        /// <param name="itype">请求类型，1为今天，2为昨天，3为最近7天，4为最近30天.</param>
        /// <returns>List&lt;Entity.ListItemModel&gt;.</returns>
        public List<Entity.ListItemModel> GetVisitTime(int itype)
        {
            List<Entity.ListItemModel> list = new List<Entity.ListItemModel>();
            string strWhere = string.Empty;

            switch (itype)
            {
                case 1:
                    strWhere = "AddDateTime  BETWEEN DATE_FORMAT(DATE_ADD(now(),INTERVAL 0 DAY),'%Y-%m-%d') and DATE_FORMAT(DATE_ADD(now(),INTERVAL +1 DAY),'%Y-%m-%d')";
                    break;
                case 2:
                    strWhere = "AddDateTime  BETWEEN DATE_FORMAT(DATE_ADD(now(),INTERVAL -1 DAY),'%Y-%m-%d') and DATE_FORMAT(DATE_ADD(now(),INTERVAL 0 DAY),'%Y-%m-%d')";
                    break;
                case 3:
                    strWhere = "AddDateTime  BETWEEN DATE_FORMAT(DATE_ADD(now(),INTERVAL -7 DAY),'%Y-%m-%d') and DATE_FORMAT(DATE_ADD(now(),INTERVAL 0 DAY),'%Y-%m-%d')";
                    break;
                case 4:
                    strWhere = "AddDateTime  BETWEEN DATE_FORMAT(DATE_ADD(now(),INTERVAL -30 DAY),'%Y-%m-%d') and DATE_FORMAT(DATE_ADD(now(),INTERVAL 0 DAY),'%Y-%m-%d')";
                    break;
            }

            string strSql = string.Format("select SpiderId,SpiderName, hour(AddDateTime) as hours,count(*) as counts from {0}spiderlog  WHERE {1}  group by hours,SpiderName ORDER BY SpiderId,hours ; ", sPre, strWhere);
            using (IDataReader dataReader = DbHelperCms.Instance.ExecuteReader(CommandType.Text, strSql))
            {
                while (dataReader.Read())
                {
                    list.Add(new ListItemModel(dataReader["SpiderName"].ToString(), dataReader["hours"].ToString(), dataReader["counts"].ToString()));
                }
            }
            return list;
        }
    }
}

