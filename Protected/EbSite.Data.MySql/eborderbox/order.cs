using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using EbSite.Base.DataProfile;

namespace EbSite.Data.MySql
{
	/// <summary>
	/// 数据访问类aa。
	/// </summary>
    public partial class DataProviderCms : Interface.IDataProviderCms
	{
	    private string sPreS = "eborderbox_";
		private string sFieldorder = "id,OrderNumber,DataInfo,AddUserID,AddUserIP,AddUserName,UserID,AddTime";
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int order_GetMaxId()
		{
			return DbHelperCms.Instance.GetMaxID("id", string.Format("{0}order",sPreS)); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool order_Exists(long id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("select count(1) from {0}order",sPreS);
			strSql.Append(" where id=?id ");
			MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int64)};
			parameters[0].Value = id;

			return DbHelperCms.Instance.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int order_Add(Entity.order model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("insert into {0}order(",sPreS);
			strSql.Append("OrderNumber,DataInfo,AddUserID,AddUserIP,AddUserName,UserID,AddTime)");
			strSql.Append(" values (");
			strSql.Append("?OrderNumber,?DataInfo,?AddUserID,?AddUserIP,?AddUserName,?UserID,?AddTime)");
            strSql.Append(";SELECT @@session.identity");
			MySqlParameter[] parameters = {
					
					new MySqlParameter("?OrderNumber", MySqlDbType.VarChar,36),
					new MySqlParameter("?DataInfo", MySqlDbType.Text),
					new MySqlParameter("?AddUserID", MySqlDbType.Int32,4),
					new MySqlParameter("?AddUserIP", MySqlDbType.VarChar,20),
					new MySqlParameter("?AddUserName", MySqlDbType.VarChar,20),
					new MySqlParameter("?UserID", MySqlDbType.Int32,4),
					new MySqlParameter("?AddTime", MySqlDbType.DateTime)};
			
			parameters[0].Value = model.OrderNumber;
			parameters[1].Value = model.DataInfo;
			parameters[2].Value = model.AddUserID;
			parameters[3].Value = model.AddUserIP;
			parameters[4].Value = model.AddUserName;
			parameters[5].Value = model.UserID;
			parameters[6].Value = model.AddTime;

			object obj = DbHelperCms.Instance.ExecuteScalar(CommandType.Text,strSql.ToString(),parameters);
			if (obj == null)
			{
				return 1;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
			return 0;		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void order_Update(Entity.order model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("update {0}order set ",sPreS);
			strSql.Append("OrderNumber=?OrderNumber,");
			strSql.Append("DataInfo=?DataInfo,");
			strSql.Append("AddUserID=?AddUserID,");
			strSql.Append("AddUserIP=?AddUserIP,");
			strSql.Append("AddUserName=?AddUserName,");
			strSql.Append("UserID=?UserID,");
			strSql.Append("AddTime=?AddTime");
			strSql.Append(" where id=?id ");
			MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int64,8),
					new MySqlParameter("?OrderNumber", MySqlDbType.VarChar,36),
					new MySqlParameter("?DataInfo", MySqlDbType.Text),
					new MySqlParameter("?AddUserID", MySqlDbType.Int32,4),
					new MySqlParameter("?AddUserIP", MySqlDbType.VarChar,20),
					new MySqlParameter("?AddUserName", MySqlDbType.VarChar,20),
					new MySqlParameter("?UserID", MySqlDbType.Int32,4),
					new MySqlParameter("?AddTime", MySqlDbType.DateTime)};
			parameters[0].Value = model.id;
			parameters[1].Value = model.OrderNumber;
			parameters[2].Value = model.DataInfo;
			parameters[3].Value = model.AddUserID;
			parameters[4].Value = model.AddUserIP;
			parameters[5].Value = model.AddUserName;
			parameters[6].Value = model.UserID;
			parameters[7].Value = model.AddTime;

			DbHelperCms.Instance.ExecuteNonQuery(CommandType.Text,strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void order_Delete(long id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("delete from {0}order ",sPreS);
			strSql.Append(" where id=?id ");
			MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int64)};
			parameters[0].Value = id;

			DbHelperCms.Instance.ExecuteNonQuery(CommandType.Text,strSql.ToString(),parameters);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Entity.order order_GetEntity(long id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("select "+ sFieldorder +"  from {0}order ",sPreS);
			strSql.Append(" where id=?id ");
			MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int64)};
			parameters[0].Value = id;
			Entity.order model=null;
			using (IDataReader dataReader = DbHelperCms.Instance.ExecuteReader(CommandType.Text, strSql.ToString(),parameters))
			{
				if(dataReader.Read())
				{
					model= order_ReaderBind(dataReader);
				}
			}
			return model;
		}
		/// <summary>
		/// 获取统计
		/// </summary>
		public int order_GetCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("select count(*)  from {0}order ",sPreS);
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
		public DataSet order_GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			
			strSql.Append(sFieldorder );
			strSql.AppendFormat(" FROM {0}order ",sPreS);
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
			return DbHelperCms.Instance.ExecuteDataset(CommandType.Text, strSql.ToString());
		}

		/// <summary>
		/// 获得数据列表（比DataSet效率高，推荐使用）
		/// </summary>
		public List<Entity.order> order_GetListArray(string strWhere)
		{
			return order_GetListArray(0,strWhere,""); 
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public List<Entity.order> order_GetListArray(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			
			strSql.Append(sFieldorder );
			strSql.AppendFormat(" FROM {0}order ",sPreS);
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
			List<Entity.order> list = new List<Entity.order>();
			using (IDataReader dataReader = DbHelperCms.Instance.ExecuteReader(CommandType.Text, strSql.ToString()))
			{
				while (dataReader.Read())
				{
					list.Add(order_ReaderBind(dataReader));
				}
			}
			return list;
		}


		/// <summary>
		/// 获得分页数据
		/// </summary>
		public List<Entity.order> order_GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby,out int RecordCount)
		{
			List<Entity.order> list = new List<Entity.order>();

            RecordCount = order_GetCount(strWhere);
            string strSql = SplitPages.GetSplitPagesMySql(DbHelperCms.Instance, "order", PageSize, PageIndex, "", "id", oderby, strWhere, sPreS);

            using (IDataReader dataReader = DbHelperCms.Instance.ExecuteReader(CommandType.Text, strSql))
            {
                while (dataReader.Read())
                {
                    list.Add(order_ReaderBind(dataReader));
                }
            }
            return list;
            
            
           
		}


		/// <summary>
		/// 对象实体绑定数据
		/// </summary>
		public Entity.order order_ReaderBind(IDataReader dataReader)
		{
			Entity.order model=new Entity.order();
			object ojb; 
			ojb = dataReader["id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.id=(long)ojb;
			}
			model.OrderNumber=dataReader["OrderNumber"].ToString();
			model.DataInfo=dataReader["DataInfo"].ToString();
			ojb = dataReader["AddUserID"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.AddUserID=(int)ojb;
			}
			model.AddUserIP=dataReader["AddUserIP"].ToString();
			model.AddUserName=dataReader["AddUserName"].ToString();
			ojb = dataReader["UserID"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.UserID=(int)ojb;
			}
			ojb = dataReader["AddTime"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.AddTime=(DateTime)ojb;
			}
			return model;
		}

		#endregion  成员方法
	}
}

