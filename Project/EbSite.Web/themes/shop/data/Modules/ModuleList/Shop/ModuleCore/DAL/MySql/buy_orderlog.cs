using System;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using EbSite.Base.DataProfile;
namespace EbSite.Modules.Shop.ModuleCore.DAL.MySql
{
	/// <summary>
	/// 数据访问类Shop。
	/// </summary>
	public partial class Shop
	{
		private string sFieldbuy_orderlog = "id,OrderID,OpDate,OpUserId,OpUserName,OpType,OpCtent";
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int buy_orderlog_GetMaxId()
		{
			return DB.GetMaxID("id", string.Format("{0}buy_orderlog",sPre)); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool buy_orderlog_Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("select count(1) from {0}buy_orderlog",sPre);
			strSql.Append(" where id=?id ");
			MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32)};
			parameters[0].Value = id;

			return DB.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int buy_orderlog_Add(Entity.buy_orderlog model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("insert into {0}buy_orderlog(",sPre);
			strSql.Append("OrderID,OpDate,OpUserId,OpUserName,OpType,OpCtent)");
			strSql.Append(" values (");
			strSql.Append("?OrderID,?OpDate,?OpUserId,?OpUserName,?OpType,?OpCtent)");
			 strSql.Append(";SELECT @@session.identity");
			MySqlParameter[] parameters = {
					new MySqlParameter("?OrderID", MySqlDbType.Int64,12),
					new MySqlParameter("?OpDate", MySqlDbType.DateTime),
					new MySqlParameter("?OpUserId", MySqlDbType.Int32,11),
					new MySqlParameter("?OpUserName", MySqlDbType.VarChar,50),
					new MySqlParameter("?OpType", MySqlDbType.Int32,11),
					new MySqlParameter("?OpCtent", MySqlDbType.VarChar,500)};
			parameters[0].Value = model.OrderID;
			parameters[1].Value = model.OpDate;
			parameters[2].Value = model.OpUserId;
			parameters[3].Value = model.OpUserName;
			parameters[4].Value = model.OpType;
			parameters[5].Value = model.OpCtent;

			object obj = DB.ExecuteScalar(CommandType.Text,strSql.ToString(),parameters);
			if (obj == null)
			{
				return buy_orderlog_GetMaxId();
			}
			return 0;		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void buy_orderlog_Update(Entity.buy_orderlog model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("update {0}buy_orderlog set ",sPre);
			strSql.Append("OrderID=?OrderID,");
			strSql.Append("OpDate=?OpDate,");
			strSql.Append("OpUserId=?OpUserId,");
			strSql.Append("OpUserName=?OpUserName,");
			strSql.Append("OpType=?OpType,");
			strSql.Append("OpCtent=?OpCtent");
			strSql.Append(" where id=?id ");
			MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32,12),
					new MySqlParameter("?OrderID", MySqlDbType.Int64,12),
					new MySqlParameter("?OpDate", MySqlDbType.DateTime),
					new MySqlParameter("?OpUserId", MySqlDbType.Int32,11),
					new MySqlParameter("?OpUserName", MySqlDbType.VarChar,50),
					new MySqlParameter("?OpType", MySqlDbType.Int32,11),
					new MySqlParameter("?OpCtent", MySqlDbType.VarChar,500)};
			parameters[0].Value = model.id;
			parameters[1].Value = model.OrderID;
			parameters[2].Value = model.OpDate;
			parameters[3].Value = model.OpUserId;
			parameters[4].Value = model.OpUserName;
			parameters[5].Value = model.OpType;
			parameters[6].Value = model.OpCtent;

			DB.ExecuteNonQuery(CommandType.Text,strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void buy_orderlog_Delete(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("delete from {0}buy_orderlog ",sPre);
			strSql.Append(" where id=?id ");
			MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32)};
			parameters[0].Value = id;

			DB.ExecuteNonQuery(CommandType.Text,strSql.ToString(),parameters);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Entity.buy_orderlog buy_orderlog_GetEntity(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("select "+ sFieldbuy_orderlog +"  from {0}buy_orderlog ",sPre);
			strSql.Append(" where id=?id ");
			MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32)};
			parameters[0].Value = id;
			Entity.buy_orderlog model=null;
			using (IDataReader dataReader = DB.ExecuteReader(CommandType.Text, strSql.ToString(),parameters))
			{
				if(dataReader.Read())
				{
					model= buy_orderlog_ReaderBind(dataReader);
				}
			}
			return model;
		}
		/// <summary>
		/// 获取统计
		/// </summary>
		public int buy_orderlog_GetCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("select count(*)  from {0}buy_orderlog ",sPre);
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
		public DataSet buy_orderlog_GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			
			strSql.Append(sFieldbuy_orderlog );
			strSql.AppendFormat(" FROM {0}buy_orderlog ",sPre);
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
			return DB.ExecuteDataset(CommandType.Text, strSql.ToString());
		}

		/// <summary>
		/// 获得数据列表（比DataSet效率高，推荐使用）
		/// </summary>
		public List<Entity.buy_orderlog> buy_orderlog_GetListArray(string strWhere)
		{
			return buy_orderlog_GetListArray(0,strWhere,""); 
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public List<Entity.buy_orderlog> buy_orderlog_GetListArray(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			
			strSql.Append(sFieldbuy_orderlog );
			strSql.AppendFormat(" FROM {0}buy_orderlog ",sPre);
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
			List<Entity.buy_orderlog> list = new List<Entity.buy_orderlog>();
			using (IDataReader dataReader = DB.ExecuteReader(CommandType.Text, strSql.ToString()))
			{
				while (dataReader.Read())
				{
					list.Add(buy_orderlog_ReaderBind(dataReader));
				}
			}
			return list;
		}


		/// <summary>
		/// 获得分页数据
		/// </summary>
		public List<Entity.buy_orderlog> buy_orderlog_GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby,out int RecordCount)
		{
			List<Entity.buy_orderlog> list = new List<Entity.buy_orderlog>();
			RecordCount = buy_orderlog_GetCount(strWhere);
			string strSql = SplitPages.GetSplitPagesMySql(DbHelperCms.Instance, "buy_orderlog", PageSize, PageIndex, Fileds, "id",  oderby, strWhere, sPre);
			using (IDataReader dataReader = DbHelperCms.Instance.ExecuteReader(CommandType.Text, strSql))
			{
				while (dataReader.Read())
				{
					list.Add(buy_orderlog_ReaderBind(dataReader));
				}
			}
			return list;
		}


		/// <summary>
		/// 对象实体绑定数据
		/// </summary>
		public Entity.buy_orderlog buy_orderlog_ReaderBind(IDataReader dataReader)
		{
			Entity.buy_orderlog model=new Entity.buy_orderlog();
			object ojb; 
			ojb = dataReader["id"];
			if(ojb != null && ojb != DBNull.Value)
			{
                model.id = Convert.ToInt32(ojb);
			}
			ojb = dataReader["OrderID"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.OrderID=(long)ojb;
			}
			ojb = dataReader["OpDate"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.OpDate=(DateTime)ojb;
			}
			ojb = dataReader["OpUserId"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.OpUserId=Convert.ToInt32(ojb);
			}
			model.OpUserName=dataReader["OpUserName"].ToString();
			ojb = dataReader["OpType"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.OpType=Convert.ToInt32(ojb);
			}
			model.OpCtent=dataReader["OpCtent"].ToString();
			return model;
		}

		#endregion  成员方法

        #region 自定义方法

        /// <summary>
        /// 增加一条数据
        /// </summary>
        /// <param name="orderID">订单号</param>
        /// <param name="logMsg">日志内容</param>
        /// <param name="uid">用户ID</param>
        /// <param name="uname">用户姓名</param>
        /// <param name="orderShowType">日志类型</param>
        /// <returns></returns>
        public int buy_orderlog_Add(string orderID, string logMsg, int uid, string uname, SystemEnum.OrderLogType orderShowType)
        {
            ModuleCore.Entity.buy_orderlog m = new Entity.buy_orderlog();
            m.OrderID = Int64.Parse(orderID);
            m.OpDate = DateTime.Now;
            m.OpUserId = uid;
            m.OpUserName = uname;
            m.OpType = (int)orderShowType;
            m.OpCtent = logMsg;
            return buy_orderlog_Add(m);
        }

        #endregion 自定义方法
	}
}

