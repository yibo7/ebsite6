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
		private string sFieldCutPriceTips = "id,ProductID,Email,Mobile,UserID,AddDateTime";
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int CutPriceTips_GetMaxId()
		{
			return DB.GetMaxID("id", string.Format("{0}CutPriceTips",sPre)); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool CutPriceTips_Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("select count(1) from {0}CutPriceTips",sPre);
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id",SqlDbType.Int,4)};
			parameters[0].Value = id;

			return DB.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int CutPriceTips_Add(Entity.CutPriceTips model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("insert into {0}CutPriceTips(",sPre);
			strSql.Append("ProductID,Email,Mobile,UserID,AddDateTime)");
			strSql.Append(" values (");
			strSql.Append("@ProductID,@Email,@Mobile,@UserID,@AddDateTime)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					
					new SqlParameter("@ProductID",SqlDbType.Int,4),
					new SqlParameter("@Email", SqlDbType.VarChar,30),
					new SqlParameter("@Mobile", SqlDbType.VarChar,15),
					new SqlParameter("@UserID",SqlDbType.Int,4),
					new SqlParameter("@AddDateTime", SqlDbType.DateTime)};
			
			parameters[0].Value = model.ProductID;
			parameters[1].Value = model.Email;
			parameters[2].Value = model.Mobile;
			parameters[3].Value = model.UserID;
			parameters[4].Value = model.AddDateTime;

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
		public void CutPriceTips_Update(Entity.CutPriceTips model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("update {0}CutPriceTips set ",sPre);
			strSql.Append("ProductID=@ProductID,");
			strSql.Append("Email=@Email,");
			strSql.Append("Mobile=@Mobile,");
			strSql.Append("UserID=@UserID,");
			strSql.Append("AddDateTime=@AddDateTime");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id",SqlDbType.Int,4),
					new SqlParameter("@ProductID",SqlDbType.Int,4),
					new SqlParameter("@Email", SqlDbType.VarChar,30),
					new SqlParameter("@Mobile", SqlDbType.VarChar,15),
					new SqlParameter("@UserID",SqlDbType.Int,4),
					new SqlParameter("@AddDateTime", SqlDbType.DateTime)};
			parameters[0].Value = model.id;
			parameters[1].Value = model.ProductID;
			parameters[2].Value = model.Email;
			parameters[3].Value = model.Mobile;
			parameters[4].Value = model.UserID;
			parameters[5].Value = model.AddDateTime;

			DB.ExecuteNonQuery(CommandType.Text,strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void CutPriceTips_Delete(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("delete from {0}CutPriceTips ",sPre);
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id",SqlDbType.Int,4)};
			parameters[0].Value = id;

			DB.ExecuteNonQuery(CommandType.Text,strSql.ToString(),parameters);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Entity.CutPriceTips CutPriceTips_GetEntity(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("select "+ sFieldCutPriceTips +"  from {0}CutPriceTips ",sPre);
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id",SqlDbType.Int,4)};
			parameters[0].Value = id;
			Entity.CutPriceTips model=null;
			using (IDataReader dataReader = DB.ExecuteReader(CommandType.Text, strSql.ToString(),parameters))
			{
				if(dataReader.Read())
				{
					model= CutPriceTips_ReaderBind(dataReader);
				}
			}
			return model;
		}
		/// <summary>
		/// 获取统计
		/// </summary>
		public int CutPriceTips_GetCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("select count(*)  from {0}CutPriceTips ",sPre);
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
		public DataSet CutPriceTips_GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(sFieldCutPriceTips );
			strSql.AppendFormat(" FROM {0}CutPriceTips ",sPre);
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
		public List<Entity.CutPriceTips> CutPriceTips_GetListArray(string strWhere)
		{
			return CutPriceTips_GetListArray(0,strWhere,""); 
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public List<Entity.CutPriceTips> CutPriceTips_GetListArray(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(sFieldCutPriceTips );
			strSql.AppendFormat(" FROM {0}CutPriceTips ",sPre);
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			if(filedOrder.Trim()!="")
			{
				strSql.Append(" order by  "+filedOrder);
			}
			List<Entity.CutPriceTips> list = new List<Entity.CutPriceTips>();
			using (IDataReader dataReader = DB.ExecuteReader(CommandType.Text, strSql.ToString()))
			{
				while (dataReader.Read())
				{
					list.Add(CutPriceTips_ReaderBind(dataReader));
				}
			}
			return list;
		}


		/// <summary>
		/// 获得分页数据
		/// </summary>
		public List<Entity.CutPriceTips> CutPriceTips_GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby,out int RecordCount)
		{
			List<Entity.CutPriceTips> list = new List<Entity.CutPriceTips>();
			using (IDataReader dataReader = SplitPages.GetListPages_SP(DB,"CutPriceTips", PageSize, PageIndex, Fileds, "id", oderby, strWhere, out RecordCount,sPre))
			{
				while (dataReader.Read())
				{
					list.Add(CutPriceTips_ReaderBind(dataReader));
				}
			}
			return list;
		}


		/// <summary>
		/// 对象实体绑定数据
		/// </summary>
		public Entity.CutPriceTips CutPriceTips_ReaderBind(IDataReader dataReader)
		{
			Entity.CutPriceTips model=new Entity.CutPriceTips();
			object ojb; 
			ojb = dataReader["id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.id=(int)ojb;
			}
			ojb = dataReader["ProductID"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.ProductID=(int)ojb;
			}
			model.Email=dataReader["Email"].ToString();
			model.Mobile=dataReader["Mobile"].ToString();
			ojb = dataReader["UserID"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.UserID=(int)ojb;
			}
			ojb = dataReader["AddDateTime"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.AddDateTime=(DateTime)ojb;
			}
			return model;
		}

		#endregion  成员方法
	}
}

