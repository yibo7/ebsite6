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
        private string sFieldTypeNames = "ID,TypeName,OrderID,BrandIDs,IsSpecial";
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int TypeNames_GetMaxId()
		{
			return DB.GetMaxID("ID", string.Format("{0}TypeNames",sPre)); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool TypeNames_Exists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("select count(1) from {0}TypeNames",sPre);
			strSql.Append(" where ID=?ID ");
			MySqlParameter[] parameters = {
					new MySqlParameter("?ID", MySqlDbType.Int32,4)};
			parameters[0].Value = ID;

			return DB.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int TypeNames_Add(Entity.TypeNames model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("insert into {0}TypeNames(",sPre);
            strSql.Append("TypeName,OrderID,BrandIDs,IsSpecial)");
			strSql.Append(" values (");
            strSql.Append("?TypeName,?OrderID,?BrandIDs,?IsSpecial)");
			strSql.Append(";select @@IDENTITY");
			MySqlParameter[] parameters = {
					new MySqlParameter("?TypeName", MySqlDbType.VarChar,50),
					new MySqlParameter("?OrderID", MySqlDbType.Int32,4),
					new MySqlParameter("?BrandIDs", MySqlDbType.VarChar,200),
                    new MySqlParameter("?IsSpecial",MySqlDbType.Int16,1) };
			parameters[0].Value = model.TypeName;
			parameters[1].Value = model.OrderID;
			parameters[2].Value = model.BrandIDs;
		    parameters[3].Value = model.IsSpecial;

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
		public void TypeNames_Update(Entity.TypeNames model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("update {0}TypeNames set ",sPre);
			strSql.Append("TypeName=?TypeName,");
			strSql.Append("OrderID=?OrderID,");
			strSql.Append("BrandIDs=?BrandIDs,");
		    strSql.Append("IsSpecial=?IsSpecial");
			strSql.Append(" where ID=?ID ");
			MySqlParameter[] parameters = {
					new MySqlParameter("?ID", MySqlDbType.Int32,4),
					new MySqlParameter("?TypeName", MySqlDbType.VarChar,50),
					new MySqlParameter("?OrderID", MySqlDbType.Int32,4),
					new MySqlParameter("?BrandIDs", MySqlDbType.VarChar,200),
                    new MySqlParameter("?IsSpecial",MySqlDbType.Int16,1) };
			parameters[0].Value = model.id;
			parameters[1].Value = model.TypeName;
			parameters[2].Value = model.OrderID;
			parameters[3].Value = model.BrandIDs;
		    parameters[4].Value = model.IsSpecial;

			DB.ExecuteNonQuery(CommandType.Text,strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void TypeNames_Delete(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("delete from {0}TypeNames ",sPre);
			strSql.Append(" where ID=?ID ");
			MySqlParameter[] parameters = {
					new MySqlParameter("?ID", MySqlDbType.Int32,4)};
			parameters[0].Value = ID;

			DB.ExecuteNonQuery(CommandType.Text,strSql.ToString(),parameters);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Entity.TypeNames TypeNames_GetEntity(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("select "+ sFieldTypeNames +"  from {0}TypeNames ",sPre);
			strSql.Append(" where ID=?ID ");
			MySqlParameter[] parameters = {
					new MySqlParameter("?ID", MySqlDbType.Int32,4)};
			parameters[0].Value = ID;
			Entity.TypeNames model=null;
			using (IDataReader dataReader = DB.ExecuteReader(CommandType.Text, strSql.ToString(),parameters))
			{
				if(dataReader.Read())
				{
					model= TypeNames_ReaderBind(dataReader);
				}
			}
			return model;
		}
		/// <summary>
		/// 获取统计
		/// </summary>
		public int TypeNames_GetCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("select count(*)  from {0}TypeNames ",sPre);
            //if (strWhere.Trim() != "")
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
		public DataSet TypeNames_GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			
			strSql.Append(sFieldTypeNames );
			strSql.AppendFormat(" FROM {0}TypeNames ",sPre);
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
		public List<Entity.TypeNames> TypeNames_GetListArray(string strWhere)
		{
			return TypeNames_GetListArray(0,strWhere,""); 
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public List<Entity.TypeNames> TypeNames_GetListArray(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			
			strSql.Append(sFieldTypeNames );
			strSql.AppendFormat(" FROM {0}TypeNames ",sPre);
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
			List<Entity.TypeNames> list = new List<Entity.TypeNames>();
			using (IDataReader dataReader = DB.ExecuteReader(CommandType.Text, strSql.ToString()))
			{
				while (dataReader.Read())
				{
					list.Add(TypeNames_ReaderBind(dataReader));
				}
			}
			return list;
		}


		/// <summary>
		/// 获得分页数据
		/// </summary>
		public List<Entity.TypeNames> TypeNames_GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby,out int RecordCount)
		{
            StringBuilder sbSql = new StringBuilder();
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                //sbSql.Append(" where ");
                sbSql.AppendFormat(strWhere);
            }
            RecordCount = TypeNames_GetCount(sbSql.ToString());
            List<Entity.TypeNames> list = new List<Entity.TypeNames>();
            string strSql = SplitPages.GetSplitPagesMySql(DB, "TypeNames", PageSize, PageIndex, Fileds, "id", oderby, sbSql.ToString(), sPre);
            using (IDataReader dataReader = DB.ExecuteReader(CommandType.Text, strSql))
            {
                while (dataReader.Read())
                {
                    list.Add(TypeNames_ReaderBind(dataReader));
                }
            }
            return list;
		}


		/// <summary>
		/// 对象实体绑定数据
		/// </summary>
		public Entity.TypeNames TypeNames_ReaderBind(IDataReader dataReader)
		{
			Entity.TypeNames model=new Entity.TypeNames();
			object ojb; 
			ojb = dataReader["ID"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.id=(int)ojb;
			}
			model.TypeName=dataReader["TypeName"].ToString();
			ojb = dataReader["OrderID"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.OrderID=(int)ojb;
			}
			model.BrandIDs=dataReader["BrandIDs"].ToString();

            if ( dataReader["IsSpecial"].ToString() != "")
            {
                if ((dataReader["IsSpecial"].ToString() == "1") || (dataReader["IsSpecial"].ToString().ToLower() == "true"))
                {
                    model.IsSpecial = true;
                }
                else
                {
                    model.IsSpecial = false;
                }
            }
			return model;
		}

		#endregion  成员方法
	}
}

