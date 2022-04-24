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
		private string sFieldProductOptions = "id,ProductID,OptionName,SelectMode,Description";

		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int ProductOptions_GetMaxId()
		{
			return DB.GetMaxID("id", string.Format("{0}ProductOptions",sPre)); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool ProductOptions_Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("select count(1) from {0}ProductOptions",sPre);
			strSql.Append(" where id=?id ");
			MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32,4)};
			parameters[0].Value = id;

			return DB.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int ProductOptions_Add(Entity.ProductOptions model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("insert into {0}ProductOptions(",sPre);
			strSql.Append("ProductID,OptionName,SelectMode,Description)");
			strSql.Append(" values (");
			strSql.Append("?ProductID,?OptionName,?SelectMode,?Description)");
			strSql.Append(";select @@IDENTITY");
			MySqlParameter[] parameters = {
					new MySqlParameter("?ProductID", MySqlDbType.Int32,4),
					new MySqlParameter("?OptionName", MySqlDbType.VarChar,100),
					new MySqlParameter("?SelectMode", MySqlDbType.Int32,4),
					new MySqlParameter("?Description", MySqlDbType.VarChar,500)};
			parameters[0].Value = model.ProductID;
			parameters[1].Value = model.OptionName;
			parameters[2].Value = model.SelectMode;
			parameters[3].Value = model.Description;

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
		public void ProductOptions_Update(Entity.ProductOptions model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("update {0}ProductOptions set ",sPre);
			strSql.Append("ProductID=?ProductID,");
			strSql.Append("OptionName=?OptionName,");
			strSql.Append("SelectMode=?SelectMode,");
			strSql.Append("Description=?Description");
			strSql.Append(" where id=?id ");
			MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32,4),
					new MySqlParameter("?ProductID", MySqlDbType.Int32,4),
					new MySqlParameter("?OptionName", MySqlDbType.VarChar,100),
					new MySqlParameter("?SelectMode", MySqlDbType.Int32,4),
					new MySqlParameter("?Description", MySqlDbType.VarChar,500)};
			parameters[0].Value = model.id;
			parameters[1].Value = model.ProductID;
			parameters[2].Value = model.OptionName;
			parameters[3].Value = model.SelectMode;
			parameters[4].Value = model.Description;

			DB.ExecuteNonQuery(CommandType.Text,strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void ProductOptions_Delete(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("delete from {0}ProductOptions ",sPre);
			strSql.Append(" where id=?id ");
			MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32,4)};
			parameters[0].Value = id;

			DB.ExecuteNonQuery(CommandType.Text,strSql.ToString(),parameters);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Entity.ProductOptions ProductOptions_GetEntity(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("select "+ sFieldProductOptions +"  from {0}ProductOptions ",sPre);
			strSql.Append(" where id=?id ");
			MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32,4)};
			parameters[0].Value = id;
			Entity.ProductOptions model=null;
			using (IDataReader dataReader = DB.ExecuteReader(CommandType.Text, strSql.ToString(),parameters))
			{
				if(dataReader.Read())
				{
					model= ProductOptions_ReaderBind(dataReader);
				}
			}
			return model;
		}
		/// <summary>
		/// 获取统计
		/// </summary>
		public int ProductOptions_GetCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("select count(*)  from {0}ProductOptions ",sPre);
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
		public DataSet ProductOptions_GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			
			strSql.Append(sFieldProductOptions );
			strSql.AppendFormat(" FROM {0}ProductOptions ",sPre);
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
				strSql.Append(" top "+Top.ToString());
			}
			return DB.ExecuteDataset(CommandType.Text, strSql.ToString());
		}

		/// <summary>
		/// 获得数据列表（比DataSet效率高，推荐使用）
		/// </summary>
		public List<Entity.ProductOptions> ProductOptions_GetListArray(string strWhere)
		{
			return ProductOptions_GetListArray(0,strWhere,""); 
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public List<Entity.ProductOptions> ProductOptions_GetListArray(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			
			strSql.Append(sFieldProductOptions );
			strSql.AppendFormat(" FROM {0}ProductOptions ",sPre);
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
				strSql.Append(" top "+Top.ToString());
			}
			List<Entity.ProductOptions> list = new List<Entity.ProductOptions>();
			using (IDataReader dataReader = DB.ExecuteReader(CommandType.Text, strSql.ToString()))
			{
				while (dataReader.Read())
				{
					list.Add(ProductOptions_ReaderBind(dataReader));
				}
			}
			return list;
		}


		/// <summary>
		/// 获得分页数据
		/// </summary>
		public List<Entity.ProductOptions> ProductOptions_GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby,out int RecordCount)
		{
            StringBuilder sbSql = new StringBuilder();
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                sbSql.Append(" where ");
                sbSql.AppendFormat(strWhere);
            }
            RecordCount = ProductOptions_GetCount(sbSql.ToString());
            List<Entity.ProductOptions> list = new List<Entity.ProductOptions>();
            string strSql = SplitPages.GetSplitPagesMySql(DB, "ProductOptions", PageSize, PageIndex, Fileds, "id", oderby, sbSql.ToString(), sPre);
            using (IDataReader dataReader = DB.ExecuteReader(CommandType.Text, strSql))
            {
                while (dataReader.Read())
                {
                    list.Add(ProductOptions_ReaderBind(dataReader));
                }
            }
            return list;
		}


		/// <summary>
		/// 对象实体绑定数据
		/// </summary>
		public Entity.ProductOptions ProductOptions_ReaderBind(IDataReader dataReader)
		{
			Entity.ProductOptions model=new Entity.ProductOptions();
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

        #region 自定义方法

        /// <summary>
        /// 删除产品关联项
        /// </summary>
        /// <param name="productID">产品ID</param>
        /// <returns></returns>
        public bool ProductOptions_DeleteProductOption(long productID)
        {
            string strSql =string.Format("delete from {0}normrelationproduct where ProductID={1};",sPre,productID);
            strSql += string.Format("delete from {0}typerelationproduct where ProductID={1};", sPre, productID);
            strSql += string.Format("delete from {0}productoptions where ProductID={1};", sPre, productID);
            strSql += string.Format("delete from {0}productoptionitems where Productoptionid in(select id from {0}productoptions where ProductID={1});", sPre, productID);
            strSql += string.Format("delete from {0}p_bestgroup where ProductID={1};", sPre, productID);
            strSql += string.Format("delete from {0}p_userbook where ProductID={1};", sPre, productID);

            return DB.ExecuteNonQuery(CommandType.Text, strSql) > 0 ? true : false;
        }

        #endregion 自定义方法
	}
}

