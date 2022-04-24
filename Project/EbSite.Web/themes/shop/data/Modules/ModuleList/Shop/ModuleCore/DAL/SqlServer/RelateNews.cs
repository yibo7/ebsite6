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
		private string sFieldRelateNews = "ID,ProductID,NewsTitle,NewsID";
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int RelateNews_GetMaxId()
		{
			return DB.GetMaxID("ID", string.Format("{0}RelateNews",sPre)); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool RelateNews_Exists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("select count(1) from {0}RelateNews",sPre);
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = ID;

			return DB.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int RelateNews_Add(Entity.RelateNews model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("insert into {0}RelateNews(",sPre);
			strSql.Append("ProductID,NewsTitle,NewsID)");
			strSql.Append(" values (");
			strSql.Append("@ProductID,@NewsTitle,@NewsID)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@ProductID", SqlDbType.Int,4),
					new SqlParameter("@NewsTitle", SqlDbType.NVarChar,250),
					new SqlParameter("@NewsID", SqlDbType.Int,4)};
			parameters[0].Value = model.ProductID;
			parameters[1].Value = model.NewsTitle;
			parameters[2].Value = model.NewsID;

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
		public void RelateNews_Update(Entity.RelateNews model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("update {0}RelateNews set ",sPre);
			strSql.Append("ProductID=@ProductID,");
			strSql.Append("NewsTitle=@NewsTitle,");
			strSql.Append("NewsID=@NewsID");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@ProductID", SqlDbType.Int,4),
					new SqlParameter("@NewsTitle", SqlDbType.NVarChar,250),
					new SqlParameter("@NewsID", SqlDbType.Int,4)};
			parameters[0].Value = model.id;
			parameters[1].Value = model.ProductID;
			parameters[2].Value = model.NewsTitle;
			parameters[3].Value = model.NewsID;

			DB.ExecuteNonQuery(CommandType.Text,strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void RelateNews_Delete(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("delete from {0}RelateNews ",sPre);
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = ID;

			DB.ExecuteNonQuery(CommandType.Text,strSql.ToString(),parameters);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Entity.RelateNews RelateNews_GetEntity(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("select "+ sFieldRelateNews +"  from {0}RelateNews ",sPre);
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = ID;
			Entity.RelateNews model=null;
			using (IDataReader dataReader = DB.ExecuteReader(CommandType.Text, strSql.ToString(),parameters))
			{
				if(dataReader.Read())
				{
					model= RelateNews_ReaderBind(dataReader);
				}
			}
			return model;
		}
		/// <summary>
		/// 获取统计
		/// </summary>
		public int RelateNews_GetCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("select count(*)  from {0}RelateNews ",sPre);
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
		public DataSet RelateNews_GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(sFieldRelateNews );
			strSql.AppendFormat(" FROM {0}RelateNews ",sPre);
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
		public List<Entity.RelateNews> RelateNews_GetListArray(string strWhere)
		{
			return RelateNews_GetListArray(0,strWhere,""); 
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public List<Entity.RelateNews> RelateNews_GetListArray(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(sFieldRelateNews );
			strSql.AppendFormat(" FROM {0}RelateNews ",sPre);
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			if(filedOrder.Trim()!="")
			{
				strSql.Append(" order by  "+filedOrder);
			}
			List<Entity.RelateNews> list = new List<Entity.RelateNews>();
			using (IDataReader dataReader = DB.ExecuteReader(CommandType.Text, strSql.ToString()))
			{
				while (dataReader.Read())
				{
					list.Add(RelateNews_ReaderBind(dataReader));
				}
			}
			return list;
		}


		/// <summary>
		/// 获得分页数据
		/// </summary>
		public List<Entity.RelateNews> RelateNews_GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby,out int RecordCount)
		{
			List<Entity.RelateNews> list = new List<Entity.RelateNews>();
			using (IDataReader dataReader = SplitPages.GetListPages_SP(DB,"RelateNews", PageSize, PageIndex, Fileds, "ID", oderby, strWhere, out RecordCount,sPre))
			{
				while (dataReader.Read())
				{
					list.Add(RelateNews_ReaderBind(dataReader));
				}
			}
			return list;
		}


		/// <summary>
		/// 对象实体绑定数据
		/// </summary>
		public Entity.RelateNews RelateNews_ReaderBind(IDataReader dataReader)
		{
			Entity.RelateNews model=new Entity.RelateNews();
			object ojb; 
			ojb = dataReader["ID"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.id=(int)ojb;
			}
			ojb = dataReader["ProductID"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.ProductID=(int)ojb;
			}
			model.NewsTitle=dataReader["NewsTitle"].ToString();
			ojb = dataReader["NewsID"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.NewsID=(int)ojb;
			}
			return model;
		}

		#endregion  成员方法
	}
}

