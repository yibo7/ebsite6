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
		private string sFieldPromotionPriceFree = "id,PromotionsID,Amount,FreightFree,ServiceFree,PayFee";
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int PromotionPriceFree_GetMaxId()
		{
			return DB.GetMaxID("id", string.Format("{0}PromotionPriceFree",sPre)); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool PromotionPriceFree_Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("select count(1) from {0}PromotionPriceFree",sPre);
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id",SqlDbType.Int,4)};
			parameters[0].Value = id;

			return DB.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int PromotionPriceFree_Add(Entity.PromotionPriceFree model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("insert into {0}PromotionPriceFree(",sPre);
			strSql.Append("PromotionsID,Amount,FreightFree,ServiceFree,PayFee)");
			strSql.Append(" values (");
			strSql.Append("@PromotionsID,@Amount,@FreightFree,@ServiceFree,@PayFee)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@PromotionsID",SqlDbType.Int,4),
					new SqlParameter("@Amount", SqlDbType.Decimal,9),
					new SqlParameter("@FreightFree", SqlDbType.Bit,1),
					new SqlParameter("@ServiceFree", SqlDbType.Bit,1),
					new SqlParameter("@PayFee", SqlDbType.Bit,1)};
			parameters[0].Value = model.PromotionsID;
			parameters[1].Value = model.Amount;
			parameters[2].Value = model.FreightFree;
			parameters[3].Value = model.ServiceFree;
			parameters[4].Value = model.PayFee;

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
		public void PromotionPriceFree_Update(Entity.PromotionPriceFree model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("update {0}PromotionPriceFree set ",sPre);
			strSql.Append("PromotionsID=@PromotionsID,");
			strSql.Append("Amount=@Amount,");
			strSql.Append("FreightFree=@FreightFree,");
			strSql.Append("ServiceFree=@ServiceFree,");
			strSql.Append("PayFee=@PayFee");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@PromotionsID",SqlDbType.Int,4),
					new SqlParameter("@Amount", SqlDbType.Decimal,9),
					new SqlParameter("@FreightFree", SqlDbType.Bit,1),
					new SqlParameter("@ServiceFree", SqlDbType.Bit,1),
					new SqlParameter("@PayFee", SqlDbType.Bit,1)};
			parameters[0].Value = model.id;
			parameters[1].Value = model.PromotionsID;
			parameters[2].Value = model.Amount;
			parameters[3].Value = model.FreightFree;
			parameters[4].Value = model.ServiceFree;
			parameters[5].Value = model.PayFee;

			DB.ExecuteNonQuery(CommandType.Text,strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void PromotionPriceFree_Delete(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("delete from {0}PromotionPriceFree ",sPre);
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id",SqlDbType.Int,4)};
			parameters[0].Value = id;

			DB.ExecuteNonQuery(CommandType.Text,strSql.ToString(),parameters);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Entity.PromotionPriceFree PromotionPriceFree_GetEntity(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("select "+ sFieldPromotionPriceFree +"  from {0}PromotionPriceFree ",sPre);
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id",SqlDbType.Int,4)};
			parameters[0].Value = id;
			Entity.PromotionPriceFree model=null;
			using (IDataReader dataReader = DB.ExecuteReader(CommandType.Text, strSql.ToString(),parameters))
			{
				if(dataReader.Read())
				{
					model= PromotionPriceFree_ReaderBind(dataReader);
				}
			}
			return model;
		}
		/// <summary>
		/// 获取统计
		/// </summary>
		public int PromotionPriceFree_GetCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("select count(*)  from {0}PromotionPriceFree ",sPre);
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
		public DataSet PromotionPriceFree_GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(sFieldPromotionPriceFree );
			strSql.AppendFormat(" FROM {0}PromotionPriceFree ",sPre);
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
		public List<Entity.PromotionPriceFree> PromotionPriceFree_GetListArray(string strWhere)
		{
			return PromotionPriceFree_GetListArray(0,strWhere,""); 
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public List<Entity.PromotionPriceFree> PromotionPriceFree_GetListArray(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(sFieldPromotionPriceFree );
			strSql.AppendFormat(" FROM {0}PromotionPriceFree ",sPre);
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			if(filedOrder.Trim()!="")
			{
				strSql.Append(" order by  "+filedOrder);
			}
			List<Entity.PromotionPriceFree> list = new List<Entity.PromotionPriceFree>();
			using (IDataReader dataReader = DB.ExecuteReader(CommandType.Text, strSql.ToString()))
			{
				while (dataReader.Read())
				{
					list.Add(PromotionPriceFree_ReaderBind(dataReader));
				}
			}
			return list;
		}


		/// <summary>
		/// 获得分页数据
		/// </summary>
		public List<Entity.PromotionPriceFree> PromotionPriceFree_GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby,out int RecordCount)
		{
			List<Entity.PromotionPriceFree> list = new List<Entity.PromotionPriceFree>();
			using (IDataReader dataReader = SplitPages.GetListPages_SP(DB,"PromotionPriceFree", PageSize, PageIndex, Fileds, "id", oderby, strWhere, out RecordCount,sPre))
			{
				while (dataReader.Read())
				{
					list.Add(PromotionPriceFree_ReaderBind(dataReader));
				}
			}
			return list;
		}


		/// <summary>
		/// 对象实体绑定数据
		/// </summary>
		public Entity.PromotionPriceFree PromotionPriceFree_ReaderBind(IDataReader dataReader)
		{
			Entity.PromotionPriceFree model=new Entity.PromotionPriceFree();
			object ojb; 
			ojb = dataReader["id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.id=(int)ojb;
			}
			ojb = dataReader["PromotionsID"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.PromotionsID=(int)ojb;
			}
			ojb = dataReader["Amount"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Amount=(decimal)ojb;
			}
			ojb = dataReader["FreightFree"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.FreightFree=(bool)ojb;
			}
			ojb = dataReader["ServiceFree"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.ServiceFree=(bool)ojb;
			}
			ojb = dataReader["PayFee"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.PayFee=(bool)ojb;
			}
			return model;
		}

		#endregion  成员方法


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Entity.PromotionPriceFree PromotionPriceFree_GetEntity(string strWhere)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select " + sFieldPromotionPriceFree + "  from {0}PromotionPriceFree ", sPre);
            strSql.Append(" where " + strWhere);
            Entity.PromotionPriceFree model = null;
            using (IDataReader dataReader = DB.ExecuteReader(CommandType.Text, strSql.ToString()))
            {
                if (dataReader.Read())
                {
                    model = PromotionPriceFree_ReaderBind(dataReader);
                }
            }
            return model;
        }
	}
}

