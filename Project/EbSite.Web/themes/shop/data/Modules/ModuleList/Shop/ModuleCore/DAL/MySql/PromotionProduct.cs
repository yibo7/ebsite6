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
		private string sFieldPromotionProduct = "id,PromotionsID,ProductID";

		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int PromotionProduct_GetMaxId()
		{
			return DB.GetMaxID("id", string.Format("{0}PromotionProduct",sPre)); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool PromotionProduct_Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("select count(1) from {0}PromotionProduct",sPre);
			strSql.Append(" where id=?id ");
			MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32,4)};
			parameters[0].Value = id;

			return DB.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int PromotionProduct_Add(Entity.PromotionProduct model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("insert into {0}PromotionProduct(",sPre);
			strSql.Append("PromotionsID,ProductID)");
			strSql.Append(" values (");
			strSql.Append("?PromotionsID,?ProductID)");
			strSql.Append(";select @@IDENTITY");
			MySqlParameter[] parameters = {
					new MySqlParameter("?PromotionsID", MySqlDbType.Int32,4),
					new MySqlParameter("?ProductID", MySqlDbType.Int32,4)};
			parameters[0].Value = model.PromotionsID;
			parameters[1].Value = model.ProductID;

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
		public void PromotionProduct_Update(Entity.PromotionProduct model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("update {0}PromotionProduct set ",sPre);
			strSql.Append("PromotionsID=?PromotionsID,");
			strSql.Append("ProductID=?ProductID");
			strSql.Append(" where id=?id ");
			MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32,4),
					new MySqlParameter("?PromotionsID", MySqlDbType.Int32,4),
					new MySqlParameter("?ProductID", MySqlDbType.Int32,4)};
			parameters[0].Value = model.id;
			parameters[1].Value = model.PromotionsID;
			parameters[2].Value = model.ProductID;

			DB.ExecuteNonQuery(CommandType.Text,strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void PromotionProduct_Delete(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("delete from {0}PromotionProduct ",sPre);
			strSql.Append(" where id=?id ");
			MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32,4)};
			parameters[0].Value = id;

			DB.ExecuteNonQuery(CommandType.Text,strSql.ToString(),parameters);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Entity.PromotionProduct PromotionProduct_GetEntity(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("select "+ sFieldPromotionProduct +"  from {0}PromotionProduct ",sPre);
			strSql.Append(" where id=?id ");
			MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32,4)};
			parameters[0].Value = id;
			Entity.PromotionProduct model=null;
			using (IDataReader dataReader = DB.ExecuteReader(CommandType.Text, strSql.ToString(),parameters))
			{
				if(dataReader.Read())
				{
					model= PromotionProduct_ReaderBind(dataReader);
				}
			}
			return model;
		}
		/// <summary>
		/// 获取统计
		/// </summary>
		public int PromotionProduct_GetCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("select count(*)  from {0}PromotionProduct ",sPre);
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
		public DataSet PromotionProduct_GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			
			strSql.Append(sFieldPromotionProduct );
			strSql.AppendFormat(" FROM {0}PromotionProduct ",sPre);
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
		public List<Entity.PromotionProduct> PromotionProduct_GetListArray(string strWhere)
		{
			return PromotionProduct_GetListArray(0,strWhere,""); 
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public List<Entity.PromotionProduct> PromotionProduct_GetListArray(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			
			strSql.Append(sFieldPromotionProduct );
			strSql.AppendFormat(" FROM {0}PromotionProduct ",sPre);
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
			List<Entity.PromotionProduct> list = new List<Entity.PromotionProduct>();
			using (IDataReader dataReader = DB.ExecuteReader(CommandType.Text, strSql.ToString()))
			{
				while (dataReader.Read())
				{
					list.Add(PromotionProduct_ReaderBind(dataReader));
				}
			}
			return list;
		}


		/// <summary>
		/// 获得分页数据
		/// </summary>
		public List<Entity.PromotionProduct> PromotionProduct_GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby,out int RecordCount)
		{
            StringBuilder sbSql = new StringBuilder();
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                sbSql.Append(" where ");
                sbSql.AppendFormat(strWhere);
            }
            RecordCount = PromotionProduct_GetCount(sbSql.ToString());
            List<Entity.PromotionProduct> list = new List<Entity.PromotionProduct>();
            string strSql = SplitPages.GetSplitPagesMySql(DB, "PromotionProduct", PageSize, PageIndex, Fileds, "id", oderby, sbSql.ToString(), sPre);
            using (IDataReader dataReader = DB.ExecuteReader(CommandType.Text, strSql))
            {
                while (dataReader.Read())
                {
                    list.Add(PromotionProduct_ReaderBind(dataReader));
                }
            }
            return list;
		}


		/// <summary>
		/// 对象实体绑定数据
		/// </summary>
		public Entity.PromotionProduct PromotionProduct_ReaderBind(IDataReader dataReader)
		{
			Entity.PromotionProduct model=new Entity.PromotionProduct();
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
			ojb = dataReader["ProductID"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.ProductID=(int)ojb;
			}
			return model;
		}

		#endregion  成员方法

        #region 自定义方法

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool PromotionProduct_Delete(int promotionID, int productID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("delete from {0}PromotionProduct ", sPre);
            strSql.Append(" where PromotionsID=" + promotionID);
            if (productID > 0)
            {
                strSql.Append(" and ProductID=" + productID);
            }

            if (DB.ExecuteNonQuery(CommandType.Text, strSql.ToString()) > 0)
            {
                return true;
            }
            return false;
        }
        public bool PromotionProduct_ExistsProductID(int ProductID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select count(1) from {0}PromotionProduct", sPre);
            strSql.Append(" where ProductID=?ProductID ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?ProductID", MySqlDbType.Int32,4)};
            parameters[0].Value = ProductID;

            return DB.Exists(strSql.ToString(), parameters);
        }
        public bool PromotionProduct_ExistsProductAndPromotionsID(int ProductID, int PromotionsID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select count(1) from {0}PromotionProduct", sPre);
            strSql.Append(" where ProductID=?ProductID and  PromotionsID=?PromotionsID");
            MySqlParameter[] parameters = {
					new MySqlParameter("?ProductID", MySqlDbType.Int32,4),
                    new MySqlParameter("?PromotionsID", MySqlDbType.Int32,4)                      
                                          };
            parameters[0].Value = ProductID;
            parameters[1].Value = PromotionsID;

            return DB.Exists(strSql.ToString(), parameters);
        }
        #endregion 自定义方法
	}
}

