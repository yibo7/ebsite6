using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using EbSite.Base.DataProfile;
using MySql.Data.MySqlClient;
namespace EbSite.Modules.Shop.ModuleCore.DAL.MySql
{
	/// <summary>
	/// 数据访问类Shop。
	/// </summary>
	public partial class Shop
	{
		private string sFieldTypeNameValue = "ID,ValueName,OrderID,IsMoreSel,IsSele,DefaultValues,TypeNameID";
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int TypeNameValue_GetMaxId()
		{
			return DB.GetMaxID("ID", string.Format("{0}TypeNameValue",sPre)); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool TypeNameValue_Exists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("select count(1) from {0}TypeNameValue",sPre);
			strSql.Append(" where ID=?ID ");
			MySqlParameter[] parameters = {
					new MySqlParameter("?ID", MySqlDbType.Int32,4)};
			parameters[0].Value = ID;

			return DB.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int TypeNameValue_Add(Entity.TypeNameValue model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("insert into {0}TypeNameValue(",sPre);
			strSql.Append("ValueName,OrderID,IsMoreSel,IsSele,DefaultValues,TypeNameID)");
			strSql.Append(" values (");
			strSql.Append("?ValueName,?OrderID,?IsMoreSel,?IsSele,?DefaultValues,?TypeNameID)");
			strSql.Append(";select @@IDENTITY");
			MySqlParameter[] parameters = {
					new MySqlParameter("?ValueName", MySqlDbType.VarChar,50),
					new MySqlParameter("?OrderID", MySqlDbType.Int32,4),
					new MySqlParameter("?IsMoreSel", MySqlDbType.Int32,4),
					new MySqlParameter("?IsSele", MySqlDbType.Int32,4),
					new MySqlParameter("?DefaultValues", MySqlDbType.VarChar,300),
					new MySqlParameter("?TypeNameID", MySqlDbType.Int32,4)};
			parameters[0].Value = model.ValueName;
			parameters[1].Value = model.OrderID;
			parameters[2].Value = model.IsMoreSel;
			parameters[3].Value = model.IsSele;
			parameters[4].Value = model.DefaultValues;
			parameters[5].Value = model.TypeNameID;

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
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void TypeNameValue_Update(Entity.TypeNameValue model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("update {0}TypeNameValue set ",sPre);
			strSql.Append("ValueName=?ValueName,");
			strSql.Append("OrderID=?OrderID,");
			strSql.Append("IsMoreSel=?IsMoreSel,");
			strSql.Append("IsSele=?IsSele,");
			strSql.Append("DefaultValues=?DefaultValues,");
			strSql.Append("TypeNameID=?TypeNameID");
			strSql.Append(" where ID=?ID ");
			MySqlParameter[] parameters = {
					new MySqlParameter("?ID", MySqlDbType.Int32,4),
					new MySqlParameter("?ValueName", MySqlDbType.VarChar,50),
					new MySqlParameter("?OrderID", MySqlDbType.Int32,4),
					new MySqlParameter("?IsMoreSel", MySqlDbType.Int32,4),
					new MySqlParameter("?IsSele", MySqlDbType.Int32,4),
					new MySqlParameter("?DefaultValues", MySqlDbType.VarChar,300),
					new MySqlParameter("?TypeNameID", MySqlDbType.Int32,4)};
			parameters[0].Value = model.id;
			parameters[1].Value = model.ValueName;
			parameters[2].Value = model.OrderID;
			parameters[3].Value = model.IsMoreSel;
			parameters[4].Value = model.IsSele;
			parameters[5].Value = model.DefaultValues;
			parameters[6].Value = model.TypeNameID;

			DB.ExecuteNonQuery(CommandType.Text,strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void TypeNameValue_Delete(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("delete from {0}TypeNameValue ",sPre);
			strSql.Append(" where ID=?ID ");
			MySqlParameter[] parameters = {
					new MySqlParameter("?ID", MySqlDbType.Int32,4)};
			parameters[0].Value = ID;

			DB.ExecuteNonQuery(CommandType.Text,strSql.ToString(),parameters);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Entity.TypeNameValue TypeNameValue_GetEntity(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("select "+ sFieldTypeNameValue +"  from {0}TypeNameValue ",sPre);
			strSql.Append(" where ID=?ID ");
			MySqlParameter[] parameters = {
					new MySqlParameter("?ID", MySqlDbType.Int32,4)};
			parameters[0].Value = ID;
			Entity.TypeNameValue model=null;
			using (IDataReader dataReader = DB.ExecuteReader(CommandType.Text, strSql.ToString(),parameters))
			{
				if(dataReader.Read())
				{
					model= TypeNameValue_ReaderBind(dataReader);
				}
			}
			return model;
		}
		/// <summary>
		/// 获取统计
		/// </summary>
		public int TypeNameValue_GetCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("select count(*)  from {0}TypeNameValue ",sPre);
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
		public DataSet TypeNameValue_GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			
			strSql.Append(sFieldTypeNameValue );
			strSql.AppendFormat(" FROM {0}TypeNameValue ",sPre);
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
		public List<Entity.TypeNameValue> TypeNameValue_GetListArray(string strWhere)
		{
			return TypeNameValue_GetListArray(0,strWhere,""); 
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public List<Entity.TypeNameValue> TypeNameValue_GetListArray(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			
			strSql.Append(sFieldTypeNameValue );
			strSql.AppendFormat(" FROM {0}TypeNameValue ",sPre);
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
			List<Entity.TypeNameValue> list = new List<Entity.TypeNameValue>();
			using (IDataReader dataReader = DB.ExecuteReader(CommandType.Text, strSql.ToString()))
			{
				while (dataReader.Read())
				{
					list.Add(TypeNameValue_ReaderBind(dataReader));
				}
			}
			return list;
		}


		/// <summary>
		/// 获得分页数据
		/// </summary>
		public List<Entity.TypeNameValue> TypeNameValue_GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby,out int RecordCount)
		{
            StringBuilder sbSql = new StringBuilder();
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                sbSql.Append(" where ");
                sbSql.AppendFormat(strWhere);
            }
            RecordCount = TypeNameValue_GetCount(sbSql.ToString());
            List<Entity.TypeNameValue> list = new List<Entity.TypeNameValue>();
            string strSql = SplitPages.GetSplitPagesMySql(DB, "TypeNameValue", PageSize, PageIndex, Fileds, "id", oderby, sbSql.ToString(), sPre);
            using (IDataReader dataReader = DB.ExecuteReader(CommandType.Text, strSql))
            {
                while (dataReader.Read())
                {
                    list.Add(TypeNameValue_ReaderBind(dataReader));
                }
            }
            return list;
		}


		/// <summary>
		/// 对象实体绑定数据
		/// </summary>
		public Entity.TypeNameValue TypeNameValue_ReaderBind(IDataReader dataReader)
		{
			Entity.TypeNameValue model=new Entity.TypeNameValue();
			object ojb; 
			ojb = dataReader["ID"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.id=(int)ojb;
			}
			model.ValueName=dataReader["ValueName"].ToString();
			ojb = dataReader["OrderID"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.OrderID=(int)ojb;
			}
			ojb = dataReader["IsMoreSel"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.IsMoreSel=(int)ojb;
			}
			ojb = dataReader["IsSele"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.IsSele=(int)ojb;
			}
			model.DefaultValues=dataReader["DefaultValues"].ToString();
			ojb = dataReader["TypeNameID"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.TypeNameID=(int)ojb;
			}
			return model;
		}

		#endregion  成员方法
	}
}

