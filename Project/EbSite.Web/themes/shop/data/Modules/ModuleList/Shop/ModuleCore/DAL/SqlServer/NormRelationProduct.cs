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
		private string sFieldNormRelationProduct = "ID,PNumber,Stocks,SalePrice,CostPrice,MarketPrice,Weight,ProductID,NormsValues";
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int NormRelationProduct_GetMaxId()
		{
			return DB.GetMaxID("ID", string.Format("{0}NormRelationProduct",sPre)); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool NormRelationProduct_Exists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("select count(1) from {0}NormRelationProduct",sPre);
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = ID;

			return DB.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int NormRelationProduct_Add(Entity.NormRelationProduct model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("insert into {0}NormRelationProduct(",sPre);
			strSql.Append("PNumber,Stocks,SalePrice,CostPrice,MarketPrice,Weight,ProductID,NormsValues)");
			strSql.Append(" values (");
			strSql.Append("@PNumber,@Stocks,@SalePrice,@CostPrice,@MarketPrice,@Weight,@ProductID,@NormsValues)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					
					new SqlParameter("@PNumber", SqlDbType.VarChar,30),
					new SqlParameter("@Stocks", SqlDbType.Int,4),
					new SqlParameter("@SalePrice", SqlDbType.Decimal,9),
					new SqlParameter("@CostPrice", SqlDbType.Decimal,9),
					new SqlParameter("@MarketPrice", SqlDbType.Decimal,9),
					new SqlParameter("@Weight", SqlDbType.Decimal,9),
					new SqlParameter("@ProductID", SqlDbType.Int,4),
					new SqlParameter("@NormsValues", SqlDbType.VarChar,300)};
		
			parameters[0].Value = model.PNumber;
			parameters[1].Value = model.Stocks;
			parameters[2].Value = model.SalePrice;
			parameters[3].Value = model.CostPrice;
			parameters[4].Value = model.MarketPrice;
			parameters[5].Value = model.Weight;
			parameters[6].Value = model.ProductID;
			parameters[7].Value = model.NormsValues;

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
		public void NormRelationProduct_Update(Entity.NormRelationProduct model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("update {0}NormRelationProduct set ",sPre);
			strSql.Append("PNumber=@PNumber,");
			strSql.Append("Stocks=@Stocks,");
			strSql.Append("SalePrice=@SalePrice,");
			strSql.Append("CostPrice=@CostPrice,");
			strSql.Append("MarketPrice=@MarketPrice,");
			strSql.Append("Weight=@Weight,");
			strSql.Append("ProductID=@ProductID,");
			strSql.Append("NormsValues=@NormsValues");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@PNumber", SqlDbType.VarChar,30),
					new SqlParameter("@Stocks", SqlDbType.Int,4),
					new SqlParameter("@SalePrice", SqlDbType.Decimal,9),
					new SqlParameter("@CostPrice", SqlDbType.Decimal,9),
					new SqlParameter("@MarketPrice", SqlDbType.Decimal,9),
					new SqlParameter("@Weight", SqlDbType.Decimal,9),
					new SqlParameter("@ProductID", SqlDbType.Int,4),
					new SqlParameter("@NormsValues", SqlDbType.VarChar,300)};
			parameters[0].Value = model.id;
			parameters[1].Value = model.PNumber;
			parameters[2].Value = model.Stocks;
			parameters[3].Value = model.SalePrice;
			parameters[4].Value = model.CostPrice;
			parameters[5].Value = model.MarketPrice;
			parameters[6].Value = model.Weight;
			parameters[7].Value = model.ProductID;
			parameters[8].Value = model.NormsValues;

			DB.ExecuteNonQuery(CommandType.Text,strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void NormRelationProduct_Delete(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("delete from {0}NormRelationProduct ",sPre);
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = ID;

			DB.ExecuteNonQuery(CommandType.Text,strSql.ToString(),parameters);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Entity.NormRelationProduct NormRelationProduct_GetEntity(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("select "+ sFieldNormRelationProduct +"  from {0}NormRelationProduct ",sPre);
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = ID;
			Entity.NormRelationProduct model=null;
			using (IDataReader dataReader = DB.ExecuteReader(CommandType.Text, strSql.ToString(),parameters))
			{
				if(dataReader.Read())
				{
					model= NormRelationProduct_ReaderBind(dataReader);
				}
			}
			return model;
		}
		/// <summary>
		/// 获取统计
		/// </summary>
		public int NormRelationProduct_GetCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("select count(*)  from {0}NormRelationProduct ",sPre);
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
		public DataSet NormRelationProduct_GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(sFieldNormRelationProduct );
			strSql.AppendFormat(" FROM {0}NormRelationProduct ",sPre);
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
		public List<Entity.NormRelationProduct> NormRelationProduct_GetListArray(string strWhere)
		{
			return NormRelationProduct_GetListArray(0,strWhere,""); 
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public List<Entity.NormRelationProduct> NormRelationProduct_GetListArray(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(sFieldNormRelationProduct );
			strSql.AppendFormat(" FROM {0}NormRelationProduct ",sPre);
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			if(filedOrder.Trim()!="")
			{
				strSql.Append(" order by  "+filedOrder);
			}
			List<Entity.NormRelationProduct> list = new List<Entity.NormRelationProduct>();
			using (IDataReader dataReader = DB.ExecuteReader(CommandType.Text, strSql.ToString()))
			{
				while (dataReader.Read())
				{
					list.Add(NormRelationProduct_ReaderBind(dataReader));
				}
			}
			return list;
		}


		/// <summary>
		/// 获得分页数据
		/// </summary>
		public List<Entity.NormRelationProduct> NormRelationProduct_GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby,out int RecordCount)
		{
			List<Entity.NormRelationProduct> list = new List<Entity.NormRelationProduct>();
			using (IDataReader dataReader = SplitPages.GetListPages_SP(DB,"NormRelationProduct", PageSize, PageIndex, Fileds, "ID", oderby, strWhere, out RecordCount,sPre))
			{
				while (dataReader.Read())
				{
					list.Add(NormRelationProduct_ReaderBind(dataReader));
				}
			}
			return list;
		}


		/// <summary>
		/// 对象实体绑定数据
		/// </summary>
		public Entity.NormRelationProduct NormRelationProduct_ReaderBind(IDataReader dataReader)
		{
			Entity.NormRelationProduct model=new Entity.NormRelationProduct();
			object ojb; 
			ojb = dataReader["ID"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.id=(int)ojb;
			}
			model.PNumber=dataReader["PNumber"].ToString();
			ojb = dataReader["Stocks"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Stocks=(int)ojb;
			}
			ojb = dataReader["SalePrice"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.SalePrice=(decimal)ojb;
			}
			ojb = dataReader["CostPrice"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.CostPrice=(decimal)ojb;
			}
			ojb = dataReader["MarketPrice"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.MarketPrice=(decimal)ojb;
			}
			ojb = dataReader["Weight"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Weight=(decimal)ojb;
			}
			ojb = dataReader["ProductID"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.ProductID=(int)ojb;
			}
			model.NormsValues=dataReader["NormsValues"].ToString();
			return model;
		}

		#endregion  成员方法
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Entity.NormRelationProduct NormRelationProduct_GetEntityByNormID(string ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select " + sFieldNormRelationProduct + "  from {0}NormRelationProduct ", sPre);
            strSql.Append(" where NormsValues=@NormsValues ");
            SqlParameter[] parameters = {
					new SqlParameter("@NormsValues", SqlDbType.NVarChar,250)};
            parameters[0].Value = ID;
            Entity.NormRelationProduct model = null;
            using (IDataReader dataReader = DB.ExecuteReader(CommandType.Text, strSql.ToString(), parameters))
            {
                if (dataReader.Read())
                {
                    model = NormRelationProduct_ReaderBind(dataReader);
                }
            }
            return model;
        }
	}
}

