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
        private string sFieldProductOptionItems = "id,ProductOptionID,ItemName,IsGive,AppendMoney,CalculateMode,Remark";
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int ProductOptionItems_GetMaxId()
		{
			return DB.GetMaxID("id", string.Format("{0}ProductOptionItems",sPre)); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool ProductOptionItems_Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("select count(1) from {0}ProductOptionItems",sPre);
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;

			return DB.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int ProductOptionItems_Add(Entity.ProductOptionItems model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("insert into {0}ProductOptionItems(",sPre);
            strSql.Append("ProductOptionID,ItemName,IsGive,AppendMoney,CalculateMode,Remark)");
			strSql.Append(" values (");
            strSql.Append("@ProductOptionID,@ItemName,@IsGive,@AppendMoney,@CalculateMode,@Remark)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@ProductOptionID", SqlDbType.Int,4),
					new SqlParameter("@ItemName", SqlDbType.VarChar,100),
					new SqlParameter("@IsGive", SqlDbType.Bit,1),
					
					new SqlParameter("@AppendMoney", SqlDbType.Decimal,9),
					new SqlParameter("@CalculateMode", SqlDbType.Int,4),
					new SqlParameter("@Remark", SqlDbType.VarChar,300)};
			parameters[0].Value = model.ProductOptionID;
			parameters[1].Value = model.ItemName;
            parameters[2].Value = model.IsGive;
			
			parameters[3].Value = model.AppendMoney;
			parameters[4].Value = model.CalculateMode;
			parameters[5].Value = model.Remark;

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
		public void ProductOptionItems_Update(Entity.ProductOptionItems model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("update {0}ProductOptionItems set ",sPre);
			strSql.Append("ProductOptionID=@ProductOptionID,");
			strSql.Append("ItemName=@ItemName,");
            strSql.Append("IsGive=@IsGive,");
			
			strSql.Append("AppendMoney=@AppendMoney,");
			strSql.Append("CalculateMode=@CalculateMode,");
			strSql.Append("Remark=@Remark");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@ProductOptionID", SqlDbType.Int,4),
					new SqlParameter("@ItemName", SqlDbType.VarChar,100),
					new SqlParameter("@IsGive", SqlDbType.Bit,1),
					
					new SqlParameter("@AppendMoney", SqlDbType.Decimal,9),
					new SqlParameter("@CalculateMode", SqlDbType.Int,4),
					new SqlParameter("@Remark", SqlDbType.VarChar,300)};
			parameters[0].Value = model.id;
			parameters[1].Value = model.ProductOptionID;
			parameters[2].Value = model.ItemName;
            parameters[3].Value = model.IsGive;
			
			parameters[4].Value = model.AppendMoney;
			parameters[5].Value = model.CalculateMode;
			parameters[6].Value = model.Remark;

			DB.ExecuteNonQuery(CommandType.Text,strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void ProductOptionItems_Delete(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("delete from {0}ProductOptionItems ",sPre);
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;

			DB.ExecuteNonQuery(CommandType.Text,strSql.ToString(),parameters);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Entity.ProductOptionItems ProductOptionItems_GetEntity(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("select "+ sFieldProductOptionItems +"  from {0}ProductOptionItems ",sPre);
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;
			Entity.ProductOptionItems model=null;
			using (IDataReader dataReader = DB.ExecuteReader(CommandType.Text, strSql.ToString(),parameters))
			{
				if(dataReader.Read())
				{
					model= ProductOptionItems_ReaderBind(dataReader);
				}
			}
			return model;
		}
		/// <summary>
		/// 获取统计
		/// </summary>
		public int ProductOptionItems_GetCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("select count(*)  from {0}ProductOptionItems ",sPre);
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
		public DataSet ProductOptionItems_GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(sFieldProductOptionItems );
			strSql.AppendFormat(" FROM {0}ProductOptionItems ",sPre);
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
		public List<Entity.ProductOptionItems> ProductOptionItems_GetListArray(string strWhere)
		{
			return ProductOptionItems_GetListArray(0,strWhere,""); 
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public List<Entity.ProductOptionItems> ProductOptionItems_GetListArray(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(sFieldProductOptionItems );
			strSql.AppendFormat(" FROM {0}ProductOptionItems ",sPre);
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			if(filedOrder.Trim()!="")
			{
				strSql.Append(" order by  "+filedOrder);
			}
			List<Entity.ProductOptionItems> list = new List<Entity.ProductOptionItems>();
			using (IDataReader dataReader = DB.ExecuteReader(CommandType.Text, strSql.ToString()))
			{
				while (dataReader.Read())
				{
					list.Add(ProductOptionItems_ReaderBind(dataReader));
				}
			}
			return list;
		}


		/// <summary>
		/// 获得分页数据
		/// </summary>
		public List<Entity.ProductOptionItems> ProductOptionItems_GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby,out int RecordCount)
		{
			List<Entity.ProductOptionItems> list = new List<Entity.ProductOptionItems>();
			using (IDataReader dataReader = SplitPages.GetListPages_SP(DB,"ProductOptionItems", PageSize, PageIndex, Fileds, "id", oderby, strWhere, out RecordCount,sPre))
			{
				while (dataReader.Read())
				{
					list.Add(ProductOptionItems_ReaderBind(dataReader));
				}
			}
			return list;
		}


		/// <summary>
		/// 对象实体绑定数据
		/// </summary>
		public Entity.ProductOptionItems ProductOptionItems_ReaderBind(IDataReader dataReader)
		{
			Entity.ProductOptionItems model=new Entity.ProductOptionItems();
			object ojb; 
			ojb = dataReader["id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.id=(int)ojb;
			}
			ojb = dataReader["ProductOptionID"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.ProductOptionID=(int)ojb;
			}
			model.ItemName=dataReader["ItemName"].ToString();
            ojb = dataReader["IsGive"];
			if(ojb != null && ojb != DBNull.Value)
			{
                model.IsGive = (bool)ojb;
			}
			
			ojb = dataReader["AppendMoney"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.AppendMoney=(decimal)ojb;
			}
			ojb = dataReader["CalculateMode"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.CalculateMode=(int)ojb;
			}
			model.Remark=dataReader["Remark"].ToString();
			return model;
		}

		#endregion  成员方法
	}
}

