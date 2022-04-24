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
		private string sFieldNormsValue = "ID,NormsValueName,NormsIco,OrderID,NormID";
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int NormsValue_GetMaxId()
		{
			return DB.GetMaxID("ID", string.Format("{0}NormsValue",sPre)); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool NormsValue_Exists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("select count(1) from {0}NormsValue",sPre);
			strSql.Append(" where ID=?ID ");
			MySqlParameter[] parameters = {
					new MySqlParameter("?ID", MySqlDbType.Int32,4)};
			parameters[0].Value = ID;

			return DB.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int NormsValue_Add(Entity.NormsValue model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("insert into {0}NormsValue(",sPre);
			strSql.Append("NormsValueName,NormsIco,OrderID,NormID)");
			strSql.Append(" values (");
			strSql.Append("?NormsValueName,?NormsIco,?OrderID,?NormID)");
			strSql.Append(";select @@IDENTITY");
			MySqlParameter[] parameters = {
					
					new MySqlParameter("?NormsValueName", MySqlDbType.VarChar,50),
					new MySqlParameter("?NormsIco", MySqlDbType.VarChar,250),
					new MySqlParameter("?OrderID", MySqlDbType.Int32,4),
					new MySqlParameter("?NormID", MySqlDbType.Int32,4)};
		
			parameters[0].Value = model.NormsValueName;
			parameters[1].Value = model.NormsIco;
			parameters[2].Value = model.OrderID;
			parameters[3].Value = model.NormID;

			object obj = DB.ExecuteScalar(CommandType.Text,strSql.ToString(),parameters);
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
		public void NormsValue_Update(Entity.NormsValue model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("update {0}NormsValue set ",sPre);
			strSql.Append("NormsValueName=?NormsValueName,");
			strSql.Append("NormsIco=?NormsIco,");
			strSql.Append("OrderID=?OrderID,");
			strSql.Append("NormID=?NormID");
			strSql.Append(" where ID=?ID ");
			MySqlParameter[] parameters = {
					new MySqlParameter("?ID", MySqlDbType.Int32,4),
					new MySqlParameter("?NormsValueName", MySqlDbType.VarChar,50),
					new MySqlParameter("?NormsIco", MySqlDbType.VarChar,250),
					new MySqlParameter("?OrderID", MySqlDbType.Int32,4),
					new MySqlParameter("?NormID", MySqlDbType.Int32,4)};
			parameters[0].Value = model.id;
			parameters[1].Value = model.NormsValueName;
			parameters[2].Value = model.NormsIco;
			parameters[3].Value = model.OrderID;
			parameters[4].Value = model.NormID;

			DB.ExecuteNonQuery(CommandType.Text,strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void NormsValue_Delete(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("delete from {0}NormsValue ",sPre);
			strSql.Append(" where ID=?ID ");
			MySqlParameter[] parameters = {
					new MySqlParameter("?ID", MySqlDbType.Int32,4)};
			parameters[0].Value = ID;

			DB.ExecuteNonQuery(CommandType.Text,strSql.ToString(),parameters);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Entity.NormsValue NormsValue_GetEntity(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("select "+ sFieldNormsValue +"  from {0}NormsValue ",sPre);
			strSql.Append(" where ID=?ID ");
			MySqlParameter[] parameters = {
					new MySqlParameter("?ID", MySqlDbType.Int32,4)};
			parameters[0].Value = ID;
			Entity.NormsValue model=null;
			using (IDataReader dataReader = DB.ExecuteReader(CommandType.Text, strSql.ToString(),parameters))
			{
				if(dataReader.Read())
				{
					model= NormsValue_ReaderBind(dataReader);
				}
			}
			return model;
		}
		/// <summary>
		/// 获取统计
		/// </summary>
		public int NormsValue_GetCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("select count(*)  from {0}NormsValue ",sPre);
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
		public DataSet NormsValue_GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			
			strSql.Append(sFieldNormsValue );
			strSql.AppendFormat(" FROM {0}NormsValue ",sPre);
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
		public List<Entity.NormsValue> NormsValue_GetListArray(string strWhere)
		{
			return NormsValue_GetListArray(0,strWhere,""); 
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public List<Entity.NormsValue> NormsValue_GetListArray(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			
			strSql.Append(sFieldNormsValue );
			strSql.AppendFormat(" FROM {0}NormsValue ",sPre);
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
			List<Entity.NormsValue> list = new List<Entity.NormsValue>();
			using (IDataReader dataReader = DB.ExecuteReader(CommandType.Text, strSql.ToString()))
			{
				while (dataReader.Read())
				{
					list.Add(NormsValue_ReaderBind(dataReader));
				}
			}
			return list;
		}


		/// <summary>
		/// 获得分页数据
		/// </summary>
		public List<Entity.NormsValue> NormsValue_GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby,out int RecordCount)
		{

            StringBuilder sbSql = new StringBuilder();
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
               // sbSql.Append(" where ");
                sbSql.AppendFormat(strWhere);
            }
            RecordCount = NormsValue_GetCount(sbSql.ToString());
            List<Entity.NormsValue> list = new List<Entity.NormsValue>();
            string strSql = SplitPages.GetSplitPagesMySql(DB, "NormsValue", PageSize, PageIndex, Fileds, "id", oderby, sbSql.ToString(), sPre);
            using (IDataReader dataReader = DB.ExecuteReader(CommandType.Text, strSql))
            {
                while (dataReader.Read())
                {
                    list.Add(NormsValue_ReaderBind(dataReader));
                }
            }
            return list;
            
		
		}


		/// <summary>
		/// 对象实体绑定数据
		/// </summary>
		public Entity.NormsValue NormsValue_ReaderBind(IDataReader dataReader)
		{
			Entity.NormsValue model=new Entity.NormsValue();
			object ojb; 
			ojb = dataReader["ID"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.id=(int)ojb;
			}
			model.NormsValueName=dataReader["NormsValueName"].ToString();
			model.NormsIco=dataReader["NormsIco"].ToString();
			ojb = dataReader["OrderID"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.OrderID=(int)ojb;
			}
			ojb = dataReader["NormID"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.NormID=(int)ojb;
			}
			return model;
		}

		#endregion  成员方法
	}
}

