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
		private string sFieldOrderOptions = "id,OptionName,SelectMode,Description";
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int OrderOptions_GetMaxId()
		{
			return DB.GetMaxID("id", string.Format("{0}OrderOptions",sPre)); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool OrderOptions_Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("select count(1) from {0}OrderOptions",sPre);
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id",SqlDbType.Int,4)};
			parameters[0].Value = id;

			return DB.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int OrderOptions_Add(Entity.OrderOptions model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("insert into {0}OrderOptions(",sPre);
			strSql.Append("OptionName,SelectMode,Description)");
			strSql.Append(" values (");
			strSql.Append("@OptionName,@SelectMode,@Description)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					
					new SqlParameter("@OptionName", SqlDbType.VarChar,100),
					new SqlParameter("@SelectMode",SqlDbType.Int,4),
					new SqlParameter("@Description", SqlDbType.VarChar,500)};
		
			parameters[0].Value = model.OptionName;
			parameters[1].Value = model.SelectMode;
			parameters[2].Value = model.Description;

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
		public void OrderOptions_Update(Entity.OrderOptions model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("update {0}OrderOptions set ",sPre);
			strSql.Append("OptionName=@OptionName,");
			strSql.Append("SelectMode=@SelectMode,");
			strSql.Append("Description=@Description");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id",SqlDbType.Int,4),
					new SqlParameter("@OptionName", SqlDbType.VarChar,100),
					new SqlParameter("@SelectMode",SqlDbType.Int,4),
					new SqlParameter("@Description", SqlDbType.VarChar,500)};
			parameters[0].Value = model.id;
			parameters[1].Value = model.OptionName;
			parameters[2].Value = model.SelectMode;
			parameters[3].Value = model.Description;

			DB.ExecuteNonQuery(CommandType.Text,strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void OrderOptions_Delete(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("delete from {0}OrderOptions ",sPre);
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id",SqlDbType.Int,4)};
			parameters[0].Value = id;

			DB.ExecuteNonQuery(CommandType.Text,strSql.ToString(),parameters);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Entity.OrderOptions OrderOptions_GetEntity(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("select "+ sFieldOrderOptions +"  from {0}OrderOptions ",sPre);
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id",SqlDbType.Int,4)};
			parameters[0].Value = id;
			Entity.OrderOptions model=null;
			using (IDataReader dataReader = DB.ExecuteReader(CommandType.Text, strSql.ToString(),parameters))
			{
				if(dataReader.Read())
				{
					model= OrderOptions_ReaderBind(dataReader);
				}
			}
			return model;
		}
		/// <summary>
		/// 获取统计
		/// </summary>
		public int OrderOptions_GetCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("select count(*)  from {0}OrderOptions ",sPre);
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
		public DataSet OrderOptions_GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(sFieldOrderOptions );
			strSql.AppendFormat(" FROM {0}OrderOptions ",sPre);
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
		public List<Entity.OrderOptions> OrderOptions_GetListArray(string strWhere)
		{
			return OrderOptions_GetListArray(0,strWhere,""); 
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public List<Entity.OrderOptions> OrderOptions_GetListArray(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(sFieldOrderOptions );
			strSql.AppendFormat(" FROM {0}OrderOptions ",sPre);
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			if(filedOrder.Trim()!="")
			{
				strSql.Append(" order by  "+filedOrder);
			}
			List<Entity.OrderOptions> list = new List<Entity.OrderOptions>();
			using (IDataReader dataReader = DB.ExecuteReader(CommandType.Text, strSql.ToString()))
			{
				while (dataReader.Read())
				{
					list.Add(OrderOptions_ReaderBind(dataReader));
				}
			}
			return list;
		}


		/// <summary>
		/// 获得分页数据
		/// </summary>
		public List<Entity.OrderOptions> OrderOptions_GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby,out int RecordCount)
		{
			List<Entity.OrderOptions> list = new List<Entity.OrderOptions>();
			using (IDataReader dataReader = SplitPages.GetListPages_SP(DB,"OrderOptions", PageSize, PageIndex, Fileds, "id", oderby, strWhere, out RecordCount,sPre))
			{
				while (dataReader.Read())
				{
					list.Add(OrderOptions_ReaderBind(dataReader));
				}
			}
			return list;
		}


		/// <summary>
		/// 对象实体绑定数据
		/// </summary>
		public Entity.OrderOptions OrderOptions_ReaderBind(IDataReader dataReader)
		{
			Entity.OrderOptions model=new Entity.OrderOptions();
			object ojb; 
			ojb = dataReader["id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.id=(int)ojb;
			}
			model.OptionName=dataReader["OptionName"].ToString();
			ojb = dataReader["SelectMode"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.SelectMode=(int)ojb;
			}
			model.Description=dataReader["Description"].ToString();
			return model;
		}

		#endregion  成员方法
	}
}

