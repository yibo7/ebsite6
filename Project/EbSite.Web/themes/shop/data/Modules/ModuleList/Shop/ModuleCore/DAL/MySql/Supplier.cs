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
		private string sFieldSupplier = "ID,SupplierName,ContactUser,Phone,Tel,Adres";
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int Supplier_GetMaxId()
		{
			return DB.GetMaxID("ID", string.Format("{0}Supplier",sPre)); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Supplier_Exists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("select count(1) from {0}Supplier",sPre);
			strSql.Append(" where ID=?ID ");
			MySqlParameter[] parameters = {
					new MySqlParameter("?ID", MySqlDbType.Int32,4)};
			parameters[0].Value = ID;

			return DB.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Supplier_Add(Entity.Supplier model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("insert into {0}Supplier(",sPre);
			strSql.Append("SupplierName,ContactUser,Phone,Tel,Adres)");
			strSql.Append(" values (");
			strSql.Append("?SupplierName,?ContactUser,?Phone,?Tel,?Adres)");
			strSql.Append(";select @@IDENTITY");
			MySqlParameter[] parameters = {
					new MySqlParameter("?SupplierName", MySqlDbType.VarChar,50),
					new MySqlParameter("?ContactUser", MySqlDbType.VarChar,20),
					new MySqlParameter("?Phone", MySqlDbType.VarChar,20),
					new MySqlParameter("?Tel", MySqlDbType.VarChar,10),
					new MySqlParameter("?Adres", MySqlDbType.VarChar,200)};
			parameters[0].Value = model.SupplierName;
			parameters[1].Value = model.ContactUser;
			parameters[2].Value = model.Phone;
			parameters[3].Value = model.Tel;
			parameters[4].Value = model.Adres;

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
		public void Supplier_Update(Entity.Supplier model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("update {0}Supplier set ",sPre);
			strSql.Append("SupplierName=?SupplierName,");
			strSql.Append("ContactUser=?ContactUser,");
			strSql.Append("Phone=?Phone,");
			strSql.Append("Tel=?Tel,");
			strSql.Append("Adres=?Adres");
			strSql.Append(" where ID=?ID ");
			MySqlParameter[] parameters = {
					new MySqlParameter("?ID", MySqlDbType.Int32,4),
					new MySqlParameter("?SupplierName", MySqlDbType.VarChar,50),
					new MySqlParameter("?ContactUser", MySqlDbType.VarChar,20),
					new MySqlParameter("?Phone", MySqlDbType.VarChar,20),
					new MySqlParameter("?Tel", MySqlDbType.VarChar,10),
					new MySqlParameter("?Adres", MySqlDbType.VarChar,200)};
			parameters[0].Value = model.id;
			parameters[1].Value = model.SupplierName;
			parameters[2].Value = model.ContactUser;
			parameters[3].Value = model.Phone;
			parameters[4].Value = model.Tel;
			parameters[5].Value = model.Adres;

			DB.ExecuteNonQuery(CommandType.Text,strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Supplier_Delete(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("delete from {0}Supplier ",sPre);
			strSql.Append(" where ID=?ID ");
			MySqlParameter[] parameters = {
					new MySqlParameter("?ID", MySqlDbType.Int32,4)};
			parameters[0].Value = ID;

			DB.ExecuteNonQuery(CommandType.Text,strSql.ToString(),parameters);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Entity.Supplier Supplier_GetEntity(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("select "+ sFieldSupplier +"  from {0}Supplier ",sPre);
			strSql.Append(" where ID=?ID ");
			MySqlParameter[] parameters = {
					new MySqlParameter("?ID", MySqlDbType.Int32,4)};
			parameters[0].Value = ID;
			Entity.Supplier model=null;
			using (IDataReader dataReader = DB.ExecuteReader(CommandType.Text, strSql.ToString(),parameters))
			{
				if(dataReader.Read())
				{
					model= Supplier_ReaderBind(dataReader);
				}
			}
			return model;
		}
		/// <summary>
		/// 获取统计
		/// </summary>
		public int Supplier_GetCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("select count(*)  from {0}Supplier ",sPre);
            //if (strWhere.ToLower().IndexOf("where")<0)
            //{
            //    strSql.Append(" where " + strWhere);
            //}
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
		public DataSet Supplier_GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			
			strSql.Append(sFieldSupplier );
			strSql.AppendFormat(" FROM {0}Supplier ",sPre);
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
		public List<Entity.Supplier> Supplier_GetListArray(string strWhere)
		{
			return Supplier_GetListArray(0,strWhere,""); 
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public List<Entity.Supplier> Supplier_GetListArray(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			
			strSql.Append(sFieldSupplier );
			strSql.AppendFormat(" FROM {0}Supplier ",sPre);
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
			List<Entity.Supplier> list = new List<Entity.Supplier>();
			using (IDataReader dataReader = DB.ExecuteReader(CommandType.Text, strSql.ToString()))
			{
				while (dataReader.Read())
				{
					list.Add(Supplier_ReaderBind(dataReader));
				}
			}
			return list;
		}


		/// <summary>
		/// 获得分页数据
		/// </summary>
		public List<Entity.Supplier> Supplier_GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby,out int RecordCount)
		{
            StringBuilder sbSql = new StringBuilder();
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                //sbSql.Append(" where ");
                sbSql.AppendFormat(strWhere);
            }
            RecordCount = Supplier_GetCount(sbSql.ToString());
            List<Entity.Supplier> list = new List<Entity.Supplier>();
            string strSql = SplitPages.GetSplitPagesMySql(DB, "Supplier", PageSize, PageIndex, Fileds, "id", oderby, sbSql.ToString(), sPre);
            using (IDataReader dataReader = DB.ExecuteReader(CommandType.Text, strSql))
            {
                while (dataReader.Read())
                {
                    list.Add(Supplier_ReaderBind(dataReader));
                }
            }
            return list;
		}


		/// <summary>
		/// 对象实体绑定数据
		/// </summary>
		public Entity.Supplier Supplier_ReaderBind(IDataReader dataReader)
		{
			Entity.Supplier model=new Entity.Supplier();
			object ojb; 
			ojb = dataReader["ID"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.id=(int)ojb;
			}
			model.SupplierName=dataReader["SupplierName"].ToString();
			model.ContactUser=dataReader["ContactUser"].ToString();
			model.Phone=dataReader["Phone"].ToString();
			model.Tel=dataReader["Tel"].ToString();
			model.Adres=dataReader["Adres"].ToString();
			return model;
		}

		#endregion  成员方法
	}
}

