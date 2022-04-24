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
		private string sFieldPromotionFullNumGive = "id,PromotionsID,BuyQuantity,GiveQuantity";
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int PromotionFullNumGive_GetMaxId()
		{
			return DB.GetMaxID("id", string.Format("{0}PromotionFullNumGive",sPre)); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool PromotionFullNumGive_Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("select count(1) from {0}PromotionFullNumGive",sPre);
			strSql.Append(" where id=?id ");
			MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32,4)};
			parameters[0].Value = id;

			return DB.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int PromotionFullNumGive_Add(Entity.PromotionFullNumGive model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("insert into {0}PromotionFullNumGive(",sPre);
			strSql.Append("PromotionsID,BuyQuantity,GiveQuantity)");
			strSql.Append(" values (");
			strSql.Append("?PromotionsID,?BuyQuantity,?GiveQuantity)");
			strSql.Append(";select @@IDENTITY");
			MySqlParameter[] parameters = {
					new MySqlParameter("?PromotionsID", MySqlDbType.Int32,4),
					new MySqlParameter("?BuyQuantity", MySqlDbType.Int32,4),
					new MySqlParameter("?GiveQuantity", MySqlDbType.Int32,4)};
			parameters[0].Value = model.PromotionsID;
			parameters[1].Value = model.BuyQuantity;
			parameters[2].Value = model.GiveQuantity;

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
		public void PromotionFullNumGive_Update(Entity.PromotionFullNumGive model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("update {0}PromotionFullNumGive set ",sPre);
			strSql.Append("PromotionsID=?PromotionsID,");
			strSql.Append("BuyQuantity=?BuyQuantity,");
			strSql.Append("GiveQuantity=?GiveQuantity");
			strSql.Append(" where id=?id ");
			MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32,4),
					new MySqlParameter("?PromotionsID", MySqlDbType.Int32,4),
					new MySqlParameter("?BuyQuantity", MySqlDbType.Int32,4),
					new MySqlParameter("?GiveQuantity", MySqlDbType.Int32,4)};
			parameters[0].Value = model.id;
			parameters[1].Value = model.PromotionsID;
			parameters[2].Value = model.BuyQuantity;
			parameters[3].Value = model.GiveQuantity;

			DB.ExecuteNonQuery(CommandType.Text,strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void PromotionFullNumGive_Delete(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("delete from {0}PromotionFullNumGive ",sPre);
			strSql.Append(" where id=?id ");
			MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32,4)};
			parameters[0].Value = id;

			DB.ExecuteNonQuery(CommandType.Text,strSql.ToString(),parameters);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Entity.PromotionFullNumGive PromotionFullNumGive_GetEntity(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("select "+ sFieldPromotionFullNumGive +"  from {0}PromotionFullNumGive ",sPre);
			strSql.Append(" where id=?id ");
			MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32,4)};
			parameters[0].Value = id;
			Entity.PromotionFullNumGive model=null;
			using (IDataReader dataReader = DB.ExecuteReader(CommandType.Text, strSql.ToString(),parameters))
			{
				if(dataReader.Read())
				{
					model= PromotionFullNumGive_ReaderBind(dataReader);
				}
			}
			return model;
		}
		/// <summary>
		/// 获取统计
		/// </summary>
		public int PromotionFullNumGive_GetCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("select count(*)  from {0}PromotionFullNumGive ",sPre);
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
		public DataSet PromotionFullNumGive_GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			
			strSql.Append(sFieldPromotionFullNumGive );
			strSql.AppendFormat(" FROM {0}PromotionFullNumGive ",sPre);
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
		public List<Entity.PromotionFullNumGive> PromotionFullNumGive_GetListArray(string strWhere)
		{
			return PromotionFullNumGive_GetListArray(0,strWhere,""); 
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public List<Entity.PromotionFullNumGive> PromotionFullNumGive_GetListArray(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			
			strSql.Append(sFieldPromotionFullNumGive );
			strSql.AppendFormat(" FROM {0}PromotionFullNumGive ",sPre);
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
			List<Entity.PromotionFullNumGive> list = new List<Entity.PromotionFullNumGive>();
			using (IDataReader dataReader = DB.ExecuteReader(CommandType.Text, strSql.ToString()))
			{
				while (dataReader.Read())
				{
					list.Add(PromotionFullNumGive_ReaderBind(dataReader));
				}
			}
			return list;
		}


		/// <summary>
		/// 获得分页数据
		/// </summary>
		public List<Entity.PromotionFullNumGive> PromotionFullNumGive_GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby,out int RecordCount)
		{
            StringBuilder sbSql = new StringBuilder();
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                sbSql.Append(" where ");
                sbSql.AppendFormat(strWhere);
            }
            RecordCount = PromotionFullNumGive_GetCount(sbSql.ToString());
            List<Entity.PromotionFullNumGive> list = new List<Entity.PromotionFullNumGive>();
            string strSql = SplitPages.GetSplitPagesMySql(DB, "PromotionFullNumGive", PageSize, PageIndex, Fileds, "id", oderby, sbSql.ToString(), sPre);
            using (IDataReader dataReader = DB.ExecuteReader(CommandType.Text, strSql))
            {
                while (dataReader.Read())
                {
                    list.Add(PromotionFullNumGive_ReaderBind(dataReader));
                }
            }
            return list;
		}


		/// <summary>
		/// 对象实体绑定数据
		/// </summary>
		public Entity.PromotionFullNumGive PromotionFullNumGive_ReaderBind(IDataReader dataReader)
		{
			Entity.PromotionFullNumGive model=new Entity.PromotionFullNumGive();
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
			ojb = dataReader["BuyQuantity"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.BuyQuantity=(int)ojb;
			}
			ojb = dataReader["GiveQuantity"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.GiveQuantity=(int)ojb;
			}
			return model;
		}

		#endregion  成员方法


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Entity.PromotionFullNumGive PromotionFullNumGive_GetEntity(string strWhere)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select " + sFieldPromotionFullNumGive + "  from {0}PromotionFullNumGive ", sPre);
            strSql.Append(" where " + strWhere);

            Entity.PromotionFullNumGive model = null;
            using (IDataReader dataReader = DB.ExecuteReader(CommandType.Text, strSql.ToString()))
            {
                if (dataReader.Read())
                {
                    model = PromotionFullNumGive_ReaderBind(dataReader);
                }
            }
            return model;
        }
	}
}

