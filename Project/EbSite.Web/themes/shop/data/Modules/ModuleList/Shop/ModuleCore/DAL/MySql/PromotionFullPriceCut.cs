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
		private string sFieldPromotionFullPriceCut = "id,PromotionsID,Amount,DiscountValue,ValueType";
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int PromotionFullPriceCut_GetMaxId()
		{
			return DB.GetMaxID("id", string.Format("{0}PromotionFullPriceCut",sPre)); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool PromotionFullPriceCut_Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("select count(1) from {0}PromotionFullPriceCut",sPre);
			strSql.Append(" where id=?id ");
			MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32,4)};
			parameters[0].Value = id;

			return DB.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int PromotionFullPriceCut_Add(Entity.PromotionFullPriceCut model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("insert into {0}PromotionFullPriceCut(",sPre);
			strSql.Append("PromotionsID,Amount,DiscountValue,ValueType)");
			strSql.Append(" values (");
			strSql.Append("?PromotionsID,?Amount,?DiscountValue,?ValueType)");
			strSql.Append(";select @@IDENTITY");
			MySqlParameter[] parameters = {
					new MySqlParameter("?PromotionsID", MySqlDbType.Int32,4),
					new MySqlParameter("?Amount", MySqlDbType.Decimal,9),
					new MySqlParameter("?DiscountValue", MySqlDbType.Int32,4),
					new MySqlParameter("?ValueType", MySqlDbType.Int32,4)};
			parameters[0].Value = model.PromotionsID;
			parameters[1].Value = model.Amount;
			parameters[2].Value = model.DiscountValue;
			parameters[3].Value = model.ValueType;

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
		public void PromotionFullPriceCut_Update(Entity.PromotionFullPriceCut model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("update {0}PromotionFullPriceCut set ",sPre);
			strSql.Append("PromotionsID=?PromotionsID,");
			strSql.Append("Amount=?Amount,");
			strSql.Append("DiscountValue=?DiscountValue,");
			strSql.Append("ValueType=?ValueType");
			strSql.Append(" where id=?id ");
			MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32,4),
					new MySqlParameter("?PromotionsID", MySqlDbType.Int32,4),
					new MySqlParameter("?Amount", MySqlDbType.Decimal,9),
					new MySqlParameter("?DiscountValue", MySqlDbType.Int32,4),
					new MySqlParameter("?ValueType", MySqlDbType.Int32,4)};
			parameters[0].Value = model.id;
			parameters[1].Value = model.PromotionsID;
			parameters[2].Value = model.Amount;
			parameters[3].Value = model.DiscountValue;
			parameters[4].Value = model.ValueType;

			DB.ExecuteNonQuery(CommandType.Text,strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void PromotionFullPriceCut_Delete(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("delete from {0}PromotionFullPriceCut ",sPre);
			strSql.Append(" where id=?id ");
			MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32,4)};
			parameters[0].Value = id;

			DB.ExecuteNonQuery(CommandType.Text,strSql.ToString(),parameters);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Entity.PromotionFullPriceCut PromotionFullPriceCut_GetEntity(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("select "+ sFieldPromotionFullPriceCut +"  from {0}PromotionFullPriceCut ",sPre);
			strSql.Append(" where id=?id ");
			MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32,4)};
			parameters[0].Value = id;
			Entity.PromotionFullPriceCut model=null;
			using (IDataReader dataReader = DB.ExecuteReader(CommandType.Text, strSql.ToString(),parameters))
			{
				if(dataReader.Read())
				{
					model= PromotionFullPriceCut_ReaderBind(dataReader);
				}
			}
			return model;
		}
		/// <summary>
		/// 获取统计
		/// </summary>
		public int PromotionFullPriceCut_GetCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("select count(*)  from {0}PromotionFullPriceCut ",sPre);
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
		public DataSet PromotionFullPriceCut_GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			
			strSql.Append(sFieldPromotionFullPriceCut );
			strSql.AppendFormat(" FROM {0}PromotionFullPriceCut ",sPre);
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
		public List<Entity.PromotionFullPriceCut> PromotionFullPriceCut_GetListArray(string strWhere)
		{
			return PromotionFullPriceCut_GetListArray(0,strWhere,""); 
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public List<Entity.PromotionFullPriceCut> PromotionFullPriceCut_GetListArray(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			
			strSql.Append(sFieldPromotionFullPriceCut );
			strSql.AppendFormat(" FROM {0}PromotionFullPriceCut ",sPre);
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
			List<Entity.PromotionFullPriceCut> list = new List<Entity.PromotionFullPriceCut>();
			using (IDataReader dataReader = DB.ExecuteReader(CommandType.Text, strSql.ToString()))
			{
				while (dataReader.Read())
				{
					list.Add(PromotionFullPriceCut_ReaderBind(dataReader));
				}
			}
			return list;
		}


		/// <summary>
		/// 获得分页数据
		/// </summary>
		public List<Entity.PromotionFullPriceCut> PromotionFullPriceCut_GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby,out int RecordCount)
		{
            StringBuilder sbSql = new StringBuilder();
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                sbSql.Append(" where ");
                sbSql.AppendFormat(strWhere);
            }
            RecordCount = PromotionFullPriceCut_GetCount(sbSql.ToString());
            List<Entity.PromotionFullPriceCut> list = new List<Entity.PromotionFullPriceCut>();
            string strSql = SplitPages.GetSplitPagesMySql(DB, "PromotionFullPriceCut", PageSize, PageIndex, Fileds, "id", oderby, sbSql.ToString(), sPre);
            using (IDataReader dataReader = DB.ExecuteReader(CommandType.Text, strSql))
            {
                while (dataReader.Read())
                {
                    list.Add(PromotionFullPriceCut_ReaderBind(dataReader));
                }
            }
            return list;
		}


		/// <summary>
		/// 对象实体绑定数据
		/// </summary>
		public Entity.PromotionFullPriceCut PromotionFullPriceCut_ReaderBind(IDataReader dataReader)
		{
			Entity.PromotionFullPriceCut model=new Entity.PromotionFullPriceCut();
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
			ojb = dataReader["DiscountValue"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.DiscountValue=(int)ojb;
			}
			ojb = dataReader["ValueType"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.ValueType=(int)ojb;
			}
			return model;
		}

		#endregion  成员方法

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Entity.PromotionFullPriceCut PromotionFullPriceCut_GetEntity(string strWhere)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select " + sFieldPromotionFullPriceCut + "  from {0}PromotionFullPriceCut ", sPre);
            strSql.Append(" where " + strWhere);
            Entity.PromotionFullPriceCut model = null;
            using (IDataReader dataReader = DB.ExecuteReader(CommandType.Text, strSql.ToString()))
            {
                if (dataReader.Read())
                {
                    model = PromotionFullPriceCut_ReaderBind(dataReader);
                }
            }
            return model;
        }
	}
}

