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
		private string sFieldcreditproductorder = "id,OrderID,CreditProductID,UserID,Quantity,AddTime,Credit";
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int creditproductorder_GetMaxId()
		{
			return DB.GetMaxID("id", string.Format("{0}creditproductorder",sPre)); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool creditproductorder_Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("select count(1) from {0}creditproductorder",sPre);
			strSql.Append(" where id=?id ");
			MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32)};
			parameters[0].Value = id;

			return DB.Exists(strSql.ToString(),parameters);
		}
        public int creditproductorder_Add(Entity.creditproductorder model)
        {
            return creditproductorder_Add(model, null);
        }

		/// <summary>
		/// 增加一条数据
		/// </summary>
        public int creditproductorder_Add(Entity.creditproductorder model, MySqlTransaction Trans)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("insert into {0}creditproductorder(",sPre);
			strSql.Append("OrderID,CreditProductID,UserID,Quantity,AddTime,Credit)");
			strSql.Append(" values (");
			strSql.Append("?OrderID,?CreditProductID,?UserID,?Quantity,?AddTime,?Credit)");
		    strSql.Append(";SELECT @@session.identity");
			MySqlParameter[] parameters = {
					new MySqlParameter("?OrderID", MySqlDbType.Int64,15),
					new MySqlParameter("?CreditProductID", MySqlDbType.Int32,11),
					new MySqlParameter("?UserID", MySqlDbType.Int32,11),
					new MySqlParameter("?Quantity", MySqlDbType.Int32,11),
					new MySqlParameter("?AddTime", MySqlDbType.DateTime),
					new MySqlParameter("?Credit", MySqlDbType.Int32,11)};
			parameters[0].Value = model.OrderID;
			parameters[1].Value = model.CreditProductID;
			parameters[2].Value = model.UserID;
			parameters[3].Value = model.Quantity;
			parameters[4].Value = model.AddTime;
			parameters[5].Value = model.Credit;
		    object obj = null;
            if (Trans != null)
            {
                obj = DB.ExecuteScalar(Trans,CommandType.Text, strSql.ToString(), parameters);
            }
            else
            {
                obj = DB.ExecuteScalar( CommandType.Text, strSql.ToString(), parameters);
            }
			
			if (obj == null)
			{
				return creditproductorder_GetMaxId();
			}
			return 0;
		}
        /// <summary>
        /// 更新一条数据
        /// </summary>
	    public void creditproductorder_Update(Entity.creditproductorder model)
	    {
	        creditproductorder_Update(model, null);
	    }

	    /// <summary>
		/// 更新一条数据
		/// </summary>
		public void creditproductorder_Update(Entity.creditproductorder model,MySqlTransaction tran)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("update {0}creditproductorder set ",sPre);
			strSql.Append("OrderID=?OrderID,");
			strSql.Append("CreditProductID=?CreditProductID,");
			strSql.Append("UserID=?UserID,");
			strSql.Append("Quantity=?Quantity,");
			strSql.Append("AddTime=?AddTime,");
			strSql.Append("Credit=?Credit");
			strSql.Append(" where id=?id ");
			MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int64,15),
					new MySqlParameter("?OrderID", MySqlDbType.Int32,12),
					new MySqlParameter("?CreditProductID", MySqlDbType.Int32,11),
					new MySqlParameter("?UserID", MySqlDbType.Int32,11),
					new MySqlParameter("?Quantity", MySqlDbType.Int32,11),
					new MySqlParameter("?AddTime", MySqlDbType.DateTime),
					new MySqlParameter("?Credit", MySqlDbType.Int32,11)};
			parameters[0].Value = model.id;
			parameters[1].Value = model.OrderID;
			parameters[2].Value = model.CreditProductID;
			parameters[3].Value = model.UserID;
			parameters[4].Value = model.Quantity;
			parameters[5].Value = model.AddTime;
			parameters[6].Value = model.Credit;

            if (tran != null)
            {
                DB.ExecuteNonQuery(tran,CommandType.Text, strSql.ToString(), parameters);
            }
            else
            {
                DB.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
            }
			
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void creditproductorder_Delete(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("delete from {0}creditproductorder ",sPre);
			strSql.Append(" where id=?id ");
			MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32)};
			parameters[0].Value = id;

			DB.ExecuteNonQuery(CommandType.Text,strSql.ToString(),parameters);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Entity.creditproductorder creditproductorder_GetEntity(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("select "+ sFieldcreditproductorder +"  from {0}creditproductorder ",sPre);
			strSql.Append(" where id=?id ");
			MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32)};
			parameters[0].Value = id;
			Entity.creditproductorder model=null;
			using (IDataReader dataReader = DB.ExecuteReader(CommandType.Text, strSql.ToString(),parameters))
			{
				if(dataReader.Read())
				{
					model= creditproductorder_ReaderBind(dataReader);
				}
			}
			return model;
		}
		/// <summary>
		/// 获取统计
		/// </summary>
		public int creditproductorder_GetCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("select count(*)  from {0}creditproductorder ",sPre);
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
		public DataSet creditproductorder_GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			strSql.Append(sFieldcreditproductorder );
			strSql.AppendFormat(" FROM {0}creditproductorder ",sPre);
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
		public List<Entity.creditproductorder> creditproductorder_GetListArray(string strWhere)
		{
			return creditproductorder_GetListArray(0,strWhere,""); 
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public List<Entity.creditproductorder> creditproductorder_GetListArray(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			
            strSql.AppendFormat(" SELECT a.*,b.ProductName,b.SmallImg from {0}creditproductorder a LEFT OUTER JOIN {0}creditproduct b on a.CreditProductID=b.id ", sPre);
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
			List<Entity.creditproductorder> list = new List<Entity.creditproductorder>();
			using (IDataReader dataReader = DB.ExecuteReader(CommandType.Text, strSql.ToString()))
			{
				while (dataReader.Read())
				{
					list.Add(creditproductorder_ReaderBind2(dataReader));
				}
			}
			return list;
		}


		/// <summary>
		/// 获得分页数据
		/// </summary>
		public List<Entity.creditproductorder> creditproductorder_GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby,out int RecordCount)
		{
			List<Entity.creditproductorder> list = new List<Entity.creditproductorder>();
			RecordCount = creditproductorder_GetCount(strWhere);
			string strSql = SplitPages.GetSplitPagesMySql(DbHelperCms.Instance, "creditproductorder", PageSize, PageIndex, Fileds, "id",  oderby, strWhere, sPre);
			using (IDataReader dataReader = DbHelperCms.Instance.ExecuteReader(CommandType.Text, strSql))
			{
				while (dataReader.Read())
				{
					list.Add(creditproductorder_ReaderBind(dataReader));
				}
			}
			return list;
		}


		/// <summary>
		/// 对象实体绑定数据
		/// </summary>
		public Entity.creditproductorder creditproductorder_ReaderBind(IDataReader dataReader)
		{
			Entity.creditproductorder model=new Entity.creditproductorder();
			object ojb; 
			ojb = dataReader["id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.id=(int)ojb;
			}
			ojb = dataReader["OrderID"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.OrderID=(int)ojb;
			}
			ojb = dataReader["CreditProductID"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.CreditProductID=(int)ojb;
			}
			ojb = dataReader["UserID"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.UserID=(int)ojb;
			}
			ojb = dataReader["Quantity"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Quantity=(int)ojb;
			}
			ojb = dataReader["AddTime"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.AddTime=(DateTime)ojb;
			}
			ojb = dataReader["Credit"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Credit=(int)ojb;
			}
			return model;
		}

		#endregion  成员方法

        /// <summary>
        /// 对象实体绑定数据
        /// </summary>
        public Entity.creditproductorder creditproductorder_ReaderBind2(IDataReader dataReader)
        {
            Entity.creditproductorder model = new Entity.creditproductorder();
            object ojb;
            ojb = dataReader["id"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.id = (int)ojb;
            }
            ojb = dataReader["OrderID"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.OrderID = (long)ojb;
            }
            ojb = dataReader["CreditProductID"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.CreditProductID = (int)ojb;
            }
            ojb = dataReader["UserID"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.UserID = (int)ojb;
            }
            ojb = dataReader["Quantity"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.Quantity = (int)ojb;
            }
            ojb = dataReader["AddTime"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.AddTime = (DateTime)ojb;
            }
            ojb = dataReader["Credit"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.Credit = (int)ojb;
            }

            model.ProductName = dataReader["ProductName"].ToString();
            model.SmallImg = dataReader["SmallImg"].ToString();
            return model;
        }

	}
}

