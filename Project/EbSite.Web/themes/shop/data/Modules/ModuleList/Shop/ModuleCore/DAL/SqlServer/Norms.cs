using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using EbSite.Base.DataProfile;
namespace EbSite.Modules.Shop.ModuleCore.DAL.SqlServer
{
	/// <summary>
	/// 数据访问类Shop。
	/// </summary>
	public partial class Shop
	{
		private string sFieldNorms = "ID,NormsName,Demo,OrderID,TypeNameID,IsImg";
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int Norms_GetMaxId()
		{
			return DB.GetMaxID("ID", string.Format("{0}Norms",sPre)); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Norms_Exists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("select count(1) from {0}Norms",sPre);
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = ID;

			return DB.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Norms_Add(Entity.Norms model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("insert into {0}Norms(",sPre);
			strSql.Append("NormsName,Demo,OrderID,TypeNameID,IsImg)");
			strSql.Append(" values (");
			strSql.Append("@NormsName,@Demo,@OrderID,@TypeNameID,@IsImg)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
			
					new SqlParameter("@NormsName", SqlDbType.VarChar,50),
					new SqlParameter("@Demo", SqlDbType.VarChar,300),
					new SqlParameter("@OrderID", SqlDbType.Int,4),
					new SqlParameter("@TypeNameID", SqlDbType.Int,4),
					new SqlParameter("@IsImg", SqlDbType.Int,4)};
	
			parameters[0].Value = model.NormsName;
			parameters[1].Value = model.Demo;
			parameters[2].Value = model.OrderID;
			parameters[3].Value = model.TypeNameID;
			parameters[4].Value = model.IsImg;

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
		public void Norms_Update(Entity.Norms model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("update {0}Norms set ",sPre);
			strSql.Append("NormsName=@NormsName,");
			strSql.Append("Demo=@Demo,");
			strSql.Append("OrderID=@OrderID,");
			strSql.Append("TypeNameID=@TypeNameID,");
			strSql.Append("IsImg=@IsImg");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@NormsName", SqlDbType.VarChar,50),
					new SqlParameter("@Demo", SqlDbType.VarChar,300),
					new SqlParameter("@OrderID", SqlDbType.Int,4),
					new SqlParameter("@TypeNameID", SqlDbType.Int,4),
					new SqlParameter("@IsImg", SqlDbType.Int,4)};
			parameters[0].Value = model.id;
			parameters[1].Value = model.NormsName;
			parameters[2].Value = model.Demo;
			parameters[3].Value = model.OrderID;
			parameters[4].Value = model.TypeNameID;
			parameters[5].Value = model.IsImg;

			DB.ExecuteNonQuery(CommandType.Text,strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Norms_Delete(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("delete from {0}Norms ",sPre);
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = ID;

			DB.ExecuteNonQuery(CommandType.Text,strSql.ToString(),parameters);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Entity.Norms Norms_GetEntity(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("select "+ sFieldNorms +"  from {0}Norms ",sPre);
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = ID;
			Entity.Norms model=null;
			using (IDataReader dataReader = DB.ExecuteReader(CommandType.Text, strSql.ToString(),parameters))
			{
				if(dataReader.Read())
				{
					model= Norms_ReaderBind(dataReader);
				}
			}
			return model;
		}
		/// <summary>
		/// 获取统计
		/// </summary>
		public int Norms_GetCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("select count(*)  from {0}Norms ",sPre);
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
		public DataSet Norms_GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(sFieldNorms );
			strSql.AppendFormat(" FROM {0}Norms ",sPre);
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			if(filedOrder.Trim()!="")
			{
				strSql.Append(" order by  "+filedOrder);
			}
			return DB.ExecuteDataset(CommandType.Text, strSql.ToString());
		}

		/// <summary>
		/// 获得数据列表（比DataSet效率高，推荐使用）
		/// </summary>
		public List<Entity.Norms> Norms_GetListArray(string strWhere)
		{
			return Norms_GetListArray(0,strWhere,""); 
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public List<Entity.Norms> Norms_GetListArray(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(sFieldNorms );
			strSql.AppendFormat(" FROM {0}Norms ",sPre);
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			if(filedOrder.Trim()!="")
			{
				strSql.Append(" order by  "+filedOrder);
			}
			List<Entity.Norms> list = new List<Entity.Norms>();
			using (IDataReader dataReader = DB.ExecuteReader(CommandType.Text, strSql.ToString()))
			{
				while (dataReader.Read())
				{
					list.Add(Norms_ReaderBind(dataReader));
				}
			}
			return list;
		}


		/// <summary>
		/// 获得分页数据
		/// </summary>
		public List<Entity.Norms> Norms_GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby,out int RecordCount)
		{
			List<Entity.Norms> list = new List<Entity.Norms>();
			using (IDataReader dataReader = SplitPages.GetListPages_SP(DB,"Norms", PageSize, PageIndex, Fileds, "ID", oderby, strWhere, out RecordCount,sPre))
			{
				while (dataReader.Read())
				{
					list.Add(Norms_ReaderBind(dataReader));
				}
			}
			return list;
		}


		/// <summary>
		/// 对象实体绑定数据
		/// </summary>
		public Entity.Norms Norms_ReaderBind(IDataReader dataReader)
		{
			Entity.Norms model=new Entity.Norms();
			object ojb; 
			ojb = dataReader["ID"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.id=(int)ojb;
			}
			model.NormsName=dataReader["NormsName"].ToString();
			model.Demo=dataReader["Demo"].ToString();
			ojb = dataReader["OrderID"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.OrderID=(int)ojb;
			}
			ojb = dataReader["TypeNameID"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.TypeNameID=(int)ojb;
			}
			ojb = dataReader["IsImg"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.IsImg=(int)ojb;
			}
			return model;
		}

		#endregion  成员方法
	}
}

