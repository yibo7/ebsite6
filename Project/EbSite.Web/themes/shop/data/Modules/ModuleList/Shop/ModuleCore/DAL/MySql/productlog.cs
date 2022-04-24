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
		private string sFieldproductlog = "id,ProductId,PNumber,UserID,UserName,AddDate,Content,Number";

		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int productlog_GetMaxId()
		{
			return DB.GetMaxID("id", string.Format("{0}productlog",sPre)); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool productlog_Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("select count(1) from {0}productlog",sPre);
			strSql.Append(" where id=?id ");
			MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32)};
			parameters[0].Value = id;

			return DB.Exists(strSql.ToString(),parameters);
		}

        public int productlog_Add(Entity.productlog model, MySqlTransaction Trans)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("insert into {0}productlog(", sPre);
            strSql.Append("ProductId,PNumber,UserID,UserName,AddDate,Content,Number)");
            strSql.Append(" values (");
            strSql.Append("?ProductId,?PNumber,?UserID,?UserName,?AddDate,?Content,?Number)");
            strSql.Append(";SELECT @@session.identity");
            MySqlParameter[] parameters = {
					new MySqlParameter("?ProductId", MySqlDbType.Int32,11),
					new MySqlParameter("?PNumber", MySqlDbType.VarChar,200),
					new MySqlParameter("?UserID", MySqlDbType.Int32,11),
					new MySqlParameter("?UserName", MySqlDbType.VarChar,200),
					new MySqlParameter("?AddDate", MySqlDbType.DateTime),
					new MySqlParameter("?Content", MySqlDbType.VarChar,2000),
					new MySqlParameter("?Number", MySqlDbType.Int32,11)};
            parameters[0].Value = model.ProductId;
            parameters[1].Value = model.PNumber;
            parameters[2].Value = model.UserID;
            parameters[3].Value = model.UserName;
            parameters[4].Value = model.AddDate;
            parameters[5].Value = model.Content;
            parameters[6].Value = model.Number;

            object obj=null;

            if (Trans == null)
            {
                obj = DB.ExecuteScalar(CommandType.Text, strSql.ToString(), parameters);
            }
            else
            {
                obj = DB.ExecuteScalar(Trans, CommandType.Text, strSql.ToString(), parameters);

            }
            if (obj == null)
            {
                return productlog_GetMaxId();
            }
            return 0;
         
           
        }
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int productlog_Add(Entity.productlog model)
		{
		  return  productlog_Add(model, null);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void productlog_Update(Entity.productlog model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("update {0}productlog set ",sPre);
			strSql.Append("ProductId=?ProductId,");
			strSql.Append("PNumber=?PNumber,");
			strSql.Append("UserID=?UserID,");
			strSql.Append("UserName=?UserName,");
			strSql.Append("AddDate=?AddDate,");
			strSql.Append("Content=?Content,");
			strSql.Append("Number=?Number");
			strSql.Append(" where id=?id ");
			MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32,11),
					new MySqlParameter("?ProductId", MySqlDbType.Int32,11),
					new MySqlParameter("?PNumber", MySqlDbType.VarChar,200),
					new MySqlParameter("?UserID", MySqlDbType.Int32,11),
					new MySqlParameter("?UserName", MySqlDbType.VarChar,200),
					new MySqlParameter("?AddDate", MySqlDbType.DateTime),
					new MySqlParameter("?Content", MySqlDbType.VarChar,2000),
					new MySqlParameter("?Number", MySqlDbType.Int32,11)};
			parameters[0].Value = model.id;
			parameters[1].Value = model.ProductId;
			parameters[2].Value = model.PNumber;
			parameters[3].Value = model.UserID;
			parameters[4].Value = model.UserName;
			parameters[5].Value = model.AddDate;
			parameters[6].Value = model.Content;
			parameters[7].Value = model.Number;

			DB.ExecuteNonQuery(CommandType.Text,strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void productlog_Delete(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("delete from {0}productlog ",sPre);
			strSql.Append(" where id=?id ");
			MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32)};
			parameters[0].Value = id;

			DB.ExecuteNonQuery(CommandType.Text,strSql.ToString(),parameters);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Entity.productlog productlog_GetEntity(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("select "+ sFieldproductlog +"  from {0}productlog ",sPre);
			strSql.Append(" where id=?id ");
			MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32)};
			parameters[0].Value = id;
			Entity.productlog model=null;
			using (IDataReader dataReader = DB.ExecuteReader(CommandType.Text, strSql.ToString(),parameters))
			{
				if(dataReader.Read())
				{
					model= productlog_ReaderBind(dataReader);
				}
			}
			return model;
		}
		/// <summary>
		/// 获取统计
		/// </summary>
		public int productlog_GetCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("select count(*)  from {0}productlog ",sPre);
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
		public DataSet productlog_GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			strSql.Append(sFieldproductlog );
			strSql.AppendFormat(" FROM {0}productlog ",sPre);
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
		public List<Entity.productlog> productlog_GetListArray(string strWhere)
		{
			return productlog_GetListArray(0,strWhere,""); 
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public List<Entity.productlog> productlog_GetListArray(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			strSql.Append(sFieldproductlog );
			strSql.AppendFormat(" FROM {0}productlog ",sPre);
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
			List<Entity.productlog> list = new List<Entity.productlog>();
			using (IDataReader dataReader = DB.ExecuteReader(CommandType.Text, strSql.ToString()))
			{
				while (dataReader.Read())
				{
					list.Add(productlog_ReaderBind(dataReader));
				}
			}
			return list;
		}


		/// <summary>
		/// 获得分页数据
		/// </summary>
		public List<Entity.productlog> productlog_GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby,out int RecordCount)
		{
			List<Entity.productlog> list = new List<Entity.productlog>();
			RecordCount = productlog_GetCount(strWhere);
			string strSql = SplitPages.GetSplitPagesMySql(DbHelperCms.Instance, "productlog", PageSize, PageIndex, Fileds, "id",  oderby, strWhere, sPre);
			using (IDataReader dataReader = DbHelperCms.Instance.ExecuteReader(CommandType.Text, strSql))
			{
				while (dataReader.Read())
				{
					list.Add(productlog_ReaderBind(dataReader));
				}
			}
			return list;
		}


		/// <summary>
		/// 对象实体绑定数据
		/// </summary>
		public Entity.productlog productlog_ReaderBind(IDataReader dataReader)
		{
			Entity.productlog model=new Entity.productlog();
			object ojb; 
			ojb = dataReader["id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.id=(int)ojb;
			}
			ojb = dataReader["ProductId"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.ProductId=(int)ojb;
			}
			model.PNumber=dataReader["PNumber"].ToString();
			ojb = dataReader["UserID"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.UserID=(int)ojb;
			}
			model.UserName=dataReader["UserName"].ToString();
			ojb = dataReader["AddDate"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.AddDate=(DateTime)ojb;
			}
			model.Content=dataReader["Content"].ToString();
			ojb = dataReader["Number"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Number=(int)ojb;
			}
			return model;
		}

		#endregion  成员方法
	}
}

