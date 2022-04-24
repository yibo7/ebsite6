using System;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using EbSite.Base.DataProfile;
namespace EbSite.Data.MySql
{
    /// <summary>
    /// 数据访问类EbSite。
    /// </summary>
    public partial class DataProviderCms : Interface.IDataProviderCms
    {
        private string sFieldclasssetconfig = "Id,ClassId,ConfigId";
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int ClassSetConfig_GetMaxId()
		{
			return DbHelperCms.Instance.GetMaxID("Id", string.Format("{0}classsetconfig",sPre)); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool ClassSetConfig_Exists(int Id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("select count(1) from {0}classsetconfig",sPre);
			strSql.Append(" where Id=?Id ");
			MySqlParameter[] parameters = {
					new MySqlParameter("?Id", MySqlDbType.Int32)};
			parameters[0].Value = Id;

			return DbHelperCms.Instance.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int ClassSetConfig_Add(Entity.ClassSetConfig model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("insert into {0}classsetconfig(",sPre);
			strSql.Append("ClassId,ConfigId)");
			strSql.Append(" values (");
			strSql.Append("?ClassId,?ConfigId)");
			 strSql.Append(";SELECT @@session.identity");
			MySqlParameter[] parameters = {
					new MySqlParameter("?ClassId", MySqlDbType.Int32,11),
					new MySqlParameter("?ConfigId", MySqlDbType.Int32,11)};
			parameters[0].Value = model.ClassId;
			parameters[1].Value = model.ConfigId;

			object obj = DbHelperCms.Instance.ExecuteScalar(CommandType.Text,strSql.ToString(),parameters);
			if (obj == null)
			{
				return ClassSetConfig_GetMaxId();
			}
			return 0;
		}

        public void ClassSetConfig_UpdateConfigId(Entity.ClassSetConfig md)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("update {0}classsetconfig set ", sPre); 
            strSql.Append("ConfigId=?ConfigId");
            strSql.Append(" where ClassId=?ClassId ");
            MySqlParameter[] parameters = { 
                    new MySqlParameter("?ConfigId", MySqlDbType.Int32,11),
                    new MySqlParameter("?ClassId", MySqlDbType.Int32,11)}; 
            parameters[0].Value = md.ConfigId;
            parameters[1].Value = md.ClassId;

            DbHelperCms.Instance.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void ClassSetConfig_Update(Entity.ClassSetConfig model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("update {0}classsetconfig set ",sPre);
			strSql.Append("ClassId=?ClassId,");
			strSql.Append("ConfigId=?ConfigId");
			strSql.Append(" where Id=?Id ");
			MySqlParameter[] parameters = {
					new MySqlParameter("?Id", MySqlDbType.Int32,11),
					new MySqlParameter("?ClassId", MySqlDbType.Int32,11),
					new MySqlParameter("?ConfigId", MySqlDbType.Int32,11)};
			parameters[0].Value = model.id;
			parameters[1].Value = model.ClassId;
			parameters[2].Value = model.ConfigId;

			DbHelperCms.Instance.ExecuteNonQuery(CommandType.Text,strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void ClassSetConfig_Delete(int Id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("delete from {0}classsetconfig ",sPre);
			strSql.Append(" where Id=?Id ");
			MySqlParameter[] parameters = {
					new MySqlParameter("?Id", MySqlDbType.Int32)};
			parameters[0].Value = Id;

			DbHelperCms.Instance.ExecuteNonQuery(CommandType.Text,strSql.ToString(),parameters);
		}

        public void ClassSetConfig_DeleteByClassIds(string ClassIds)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("delete from {0}classsetconfig ", sPre);
            strSql.AppendFormat(" where ClassId in({0}) ", ClassIds);

            DbHelperCms.Instance.ExecuteNonQuery(CommandType.Text, strSql.ToString());
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Entity.ClassSetConfig ClassSetConfig_GetEntity(int Id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("select "+ sFieldclasssetconfig +"  from {0}classsetconfig ",sPre);
			strSql.Append(" where Id=?Id ");
			MySqlParameter[] parameters = {
					new MySqlParameter("?Id", MySqlDbType.Int32)};
			parameters[0].Value = Id;
			Entity.ClassSetConfig model=null;
			using (IDataReader dataReader = DbHelperCms.Instance.ExecuteReader(CommandType.Text, strSql.ToString(),parameters))
			{
				if(dataReader.Read())
				{
					model= ClassSetConfig_ReaderBind(dataReader);
				}
			}
			return model;
		}
		/// <summary>
		/// 获取统计
		/// </summary>
		public int ClassSetConfig_GetCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("select count(*)  from {0}classsetconfig ",sPre);
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
		public DataSet ClassSetConfig_GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			strSql.Append(sFieldclasssetconfig );
			strSql.AppendFormat(" FROM {0}classsetconfig ",sPre);
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
		public List<Entity.ClassSetConfig> ClassSetConfig_GetListArray(string strWhere)
		{
			return ClassSetConfig_GetListArray(0,strWhere,""); 
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public List<Entity.ClassSetConfig> ClassSetConfig_GetListArray(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			strSql.Append(sFieldclasssetconfig );
			strSql.AppendFormat(" FROM {0}classsetconfig ",sPre);
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
			List<Entity.ClassSetConfig> list = new List<Entity.ClassSetConfig>();
			using (IDataReader dataReader = DbHelperCms.Instance.ExecuteReader(CommandType.Text, strSql.ToString()))
			{
				while (dataReader.Read())
				{
					list.Add(ClassSetConfig_ReaderBind(dataReader));
				}
			}
			return list;
		}


		/// <summary>
		/// 获得分页数据
		/// </summary>
		public List<Entity.ClassSetConfig> ClassSetConfig_GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby,out int RecordCount)
		{
			List<Entity.ClassSetConfig> list = new List<Entity.ClassSetConfig>();
			StringBuilder sbSql = new StringBuilder();
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				sbSql.AppendFormat(strWhere);
			}
			RecordCount = ClassSetConfig_GetCount(sbSql.ToString());
			string strSql = SplitPages.GetSplitPagesMySql(DbHelperCms.Instance, "classsetconfig", PageSize, PageIndex, Fileds, "Id", oderby, sbSql.ToString(), sPre);
			using (IDataReader dataReader = DbHelperCms.Instance.ExecuteReader(CommandType.Text, strSql))
			{
				 while (dataReader.Read())
				{
					 list.Add(ClassSetConfig_ReaderBind(dataReader));
				}
			}
			return list;
		}


		/// <summary>
		/// 对象实体绑定数据
		/// </summary>
		public Entity.ClassSetConfig ClassSetConfig_ReaderBind(IDataReader dataReader)
		{
			Entity.ClassSetConfig model=new Entity.ClassSetConfig();
			object ojb; 
			ojb = dataReader["Id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.id=(int)ojb;
			}
			ojb = dataReader["ClassId"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.ClassId=(int)ojb;
			}
			ojb = dataReader["ConfigId"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.ConfigId=(int)ojb;
			}
			return model;
		}

        #endregion  成员方法

        //public void ClassSetConfig_DeleteByClassId(string IDs)
        //{
        //    StringBuilder strSql = new StringBuilder();
        //    strSql.AppendFormat("delete from {0}classsetconfig ", sPre);
        //    strSql.Append(" where ID in(" + IDs + ")");
        //    DbHelperCmsWrite.Instance.ExecuteNonQuery(CommandType.Text, strSql.ToString());
        //}
    }
}

