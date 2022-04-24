using System;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using EbSite.Base.DataProfile;
namespace EbSite.Modules.Shop.ModuleCore.DAL.MySql
{
	/// <summary>
	/// 数据访问类Shop。
	/// </summary>
	public partial class Shop
	{
        private string sFieldcartproductoptionvalue = "id,CartItemID,ProductID,ProductOptionId,ProductOptionItemId,OptionName,ItemName,IsGive,AppendMoney,CalculateMode,BuyUserID,Quantity,ProductPrice";
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int cartproductoptionvalue_GetMaxId()
		{
			return DB.GetMaxID("id", string.Format("{0}cartproductoptionvalue",sPre)); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool cartproductoptionvalue_Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("select count(1) from {0}cartproductoptionvalue",sPre);
			strSql.Append(" where id=?id ");
			MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32)};
			parameters[0].Value = id;

			return DB.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int cartproductoptionvalue_Add(Entity.cartproductoptionvalue model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("insert into {0}cartproductoptionvalue(",sPre);
            strSql.Append("CartItemID,ProductID,ProductOptionId,ProductOptionItemId,OptionName,ItemName,IsGive,AppendMoney,CalculateMode,BuyUserID,Quantity,ProductPrice)");
			strSql.Append(" values (");
            strSql.Append("?CartItemID,?ProductID,?ProductOptionId,?ProductOptionItemId,?OptionName,?ItemName,?IsGive,?AppendMoney,?CalculateMode,?BuyUserID,?Quantity,?ProductPrice)");
			 strSql.Append(";SELECT @@session.identity");
			MySqlParameter[] parameters = {
					new MySqlParameter("?CartItemID", MySqlDbType.Int64,12),
					new MySqlParameter("?ProductID", MySqlDbType.Int32,11),
					new MySqlParameter("?ProductOptionId", MySqlDbType.Int32,11),
					new MySqlParameter("?ProductOptionItemId", MySqlDbType.Int32,11),
					new MySqlParameter("?OptionName", MySqlDbType.VarChar,50),
					new MySqlParameter("?ItemName", MySqlDbType.VarChar,50),
					new MySqlParameter("?IsGive", MySqlDbType.Int16,2),
					new MySqlParameter("?AppendMoney", MySqlDbType.Decimal,11),
					new MySqlParameter("?CalculateMode", MySqlDbType.Int32,11),
                    new MySqlParameter("?BuyUserID", MySqlDbType.Int32,11),
                     new MySqlParameter("?Quantity", MySqlDbType.Int32,11),
                     new MySqlParameter("?ProductPrice", MySqlDbType.Decimal,11)                     
                                          };
			parameters[0].Value = model.CartItemID;
			parameters[1].Value = model.ProductID;
			parameters[2].Value = model.ProductOptionId;
			parameters[3].Value = model.ProductOptionItemId;
			parameters[4].Value = model.OptionName;
			parameters[5].Value = model.ItemName;
			parameters[6].Value = model.IsGive;
			parameters[7].Value = model.AppendMoney;
			parameters[8].Value = model.CalculateMode;
            parameters[9].Value = model.BuyUserID;
            parameters[10].Value = model.Quantity;
            parameters[11].Value = model.ProductPrice;

			object obj = DB.ExecuteScalar(CommandType.Text,strSql.ToString(),parameters);
			if (obj == null)
			{
				return cartproductoptionvalue_GetMaxId();
			}
			return 0;
		}

        public int cartproductoptionvalue_Add(Entity.cartproductoptionvalue model, MySqlTransaction Trans)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("insert into {0}cartproductoptionvalue(", sPre);
            strSql.Append("CartItemID,ProductID,ProductOptionId,ProductOptionItemId,OptionName,ItemName,IsGive,AppendMoney,CalculateMode,BuyUserID,Quantity,ProductPrice)");
            strSql.Append(" values (");
            strSql.Append("?CartItemID,?ProductID,?ProductOptionId,?ProductOptionItemId,?OptionName,?ItemName,?IsGive,?AppendMoney,?CalculateMode,?BuyUserID,?Quantity,?ProductPrice)");
            strSql.Append(";SELECT @@session.identity");
            MySqlParameter[] parameters = {
					new MySqlParameter("?CartItemID", MySqlDbType.Int64,12),
					new MySqlParameter("?ProductID", MySqlDbType.Int32,11),
					new MySqlParameter("?ProductOptionId", MySqlDbType.Int32,11),
					new MySqlParameter("?ProductOptionItemId", MySqlDbType.Int32,11),
					new MySqlParameter("?OptionName", MySqlDbType.VarChar,50),
					new MySqlParameter("?ItemName", MySqlDbType.VarChar,50),
					new MySqlParameter("?IsGive", MySqlDbType.Int16,2),
					new MySqlParameter("?AppendMoney", MySqlDbType.Decimal,11),
					new MySqlParameter("?CalculateMode", MySqlDbType.Int32,11),
                    new MySqlParameter("?BuyUserID", MySqlDbType.Int32,11),
                    new MySqlParameter("?Quantity", MySqlDbType.Int32,11),
                    new MySqlParameter("?ProductPrice", MySqlDbType.Decimal,11) 
                                          };
            parameters[0].Value = model.CartItemID;
            parameters[1].Value = model.ProductID;
            parameters[2].Value = model.ProductOptionId;
            parameters[3].Value = model.ProductOptionItemId;
            parameters[4].Value = model.OptionName;
            parameters[5].Value = model.ItemName;
            parameters[6].Value = model.IsGive;
            parameters[7].Value = model.AppendMoney;
            parameters[8].Value = model.CalculateMode;
            parameters[9].Value = model.BuyUserID;
            parameters[10].Value = model.Quantity;
            parameters[11].Value = model.ProductPrice;

            object obj = DB.ExecuteScalar(Trans,CommandType.Text, strSql.ToString(), parameters);

            if (obj == null)
            {
                return cartproductoptionvalue_GetMaxId();
            }
            return 0;
        }

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void cartproductoptionvalue_Update(Entity.cartproductoptionvalue model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("update {0}cartproductoptionvalue set ",sPre);
			strSql.Append("CartItemID=?CartItemID,");
			strSql.Append("ProductID=?ProductID,");
			strSql.Append("ProductOptionId=?ProductOptionId,");
			strSql.Append("ProductOptionItemId=?ProductOptionItemId,");
			strSql.Append("OptionName=?OptionName,");
			strSql.Append("ItemName=?ItemName,");
			strSql.Append("IsGive=?IsGive,");
			strSql.Append("AppendMoney=?AppendMoney,");
			strSql.Append("CalculateMode=?CalculateMode,");
            strSql.Append("BuyUserID=?BuyUserID,");
            strSql.Append("Quantity=?Quantity,");
            strSql.Append("ProductPrice=?ProductPrice");
			strSql.Append(" where id=?id ");
			MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32,11),
					new MySqlParameter("?CartItemID", MySqlDbType.Int64,12),
					new MySqlParameter("?ProductID", MySqlDbType.Int32,11),
					new MySqlParameter("?ProductOptionId", MySqlDbType.Int32,11),
					new MySqlParameter("?ProductOptionItemId", MySqlDbType.Int32,11),
					new MySqlParameter("?OptionName", MySqlDbType.VarChar,50),
					new MySqlParameter("?ItemName", MySqlDbType.VarChar,50),
					new MySqlParameter("?IsGive", MySqlDbType.Int16,2),
					new MySqlParameter("?AppendMoney", MySqlDbType.Decimal,11),
					new MySqlParameter("?CalculateMode", MySqlDbType.Int32,11),
                    new MySqlParameter("?BuyUserID", MySqlDbType.Int32,11),
                    new MySqlParameter("?Quantity", MySqlDbType.Int32,11),
                    new MySqlParameter("?ProductPrice", MySqlDbType.Decimal,11)   
                                          };
			parameters[0].Value = model.id;
			parameters[1].Value = model.CartItemID;
			parameters[2].Value = model.ProductID;
			parameters[3].Value = model.ProductOptionId;
			parameters[4].Value = model.ProductOptionItemId;
			parameters[5].Value = model.OptionName;
			parameters[6].Value = model.ItemName;
			parameters[7].Value = model.IsGive;
			parameters[8].Value = model.AppendMoney;
			parameters[9].Value = model.CalculateMode;
            parameters[10].Value = model.BuyUserID;
            parameters[11].Value = model.Quantity;
            parameters[12].Value = model.ProductPrice;

			DB.ExecuteNonQuery(CommandType.Text,strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void cartproductoptionvalue_Delete(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("delete from {0}cartproductoptionvalue ",sPre);
			strSql.Append(" where id=?id ");
			MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32)};
			parameters[0].Value = id;

			DB.ExecuteNonQuery(CommandType.Text,strSql.ToString(),parameters);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Entity.cartproductoptionvalue cartproductoptionvalue_GetEntity(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("select "+ sFieldcartproductoptionvalue +"  from {0}cartproductoptionvalue ",sPre);
			strSql.Append(" where id=?id ");
			MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32)};
			parameters[0].Value = id;
			Entity.cartproductoptionvalue model=null;
			using (IDataReader dataReader = DB.ExecuteReader(CommandType.Text, strSql.ToString(),parameters))
			{
				if(dataReader.Read())
				{
					model= cartproductoptionvalue_ReaderBind(dataReader);
				}
			}
			return model;
		}
		/// <summary>
		/// 获取统计
		/// </summary>
		public int cartproductoptionvalue_GetCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("select count(*)  from {0}cartproductoptionvalue ",sPre);
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
		public DataSet cartproductoptionvalue_GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			strSql.Append(sFieldcartproductoptionvalue );
			strSql.AppendFormat(" FROM {0}cartproductoptionvalue ",sPre);
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
		public List<Entity.cartproductoptionvalue> cartproductoptionvalue_GetListArray(string strWhere)
		{
			return cartproductoptionvalue_GetListArray(0,strWhere,""); 
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public List<Entity.cartproductoptionvalue> cartproductoptionvalue_GetListArray(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			
			strSql.Append(sFieldcartproductoptionvalue );
			strSql.AppendFormat(" FROM {0}cartproductoptionvalue ",sPre);
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			if(filedOrder.Trim()!="")
			{
				strSql.Append(" order by  "+filedOrder);
			}
            if (Top > 0)
            {
                strSql.Append(" limit " + Top.ToString());
            }
			List<Entity.cartproductoptionvalue> list = new List<Entity.cartproductoptionvalue>();
			using (IDataReader dataReader = DB.ExecuteReader(CommandType.Text, strSql.ToString()))
			{
				while (dataReader.Read())
				{
					list.Add(cartproductoptionvalue_ReaderBind(dataReader));
				}
			}
			return list;
		}


		/// <summary>
		/// 获得分页数据
		/// </summary>
		public List<Entity.cartproductoptionvalue> cartproductoptionvalue_GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby,out int RecordCount)
		{
			List<Entity.cartproductoptionvalue> list = new List<Entity.cartproductoptionvalue>();
			RecordCount = cartproductoptionvalue_GetCount(strWhere);
			string strSql = SplitPages.GetSplitPagesMySql(DbHelperCms.Instance, "cartproductoptionvalue", PageSize, PageIndex, Fileds, "id",  oderby, strWhere, sPre);
			using (IDataReader dataReader = DbHelperCms.Instance.ExecuteReader(CommandType.Text, strSql))
			{
				while (dataReader.Read())
				{
					list.Add(cartproductoptionvalue_ReaderBind(dataReader));
				}
			}
			return list;
		}


		/// <summary>
		/// 对象实体绑定数据
		/// </summary>
		public Entity.cartproductoptionvalue cartproductoptionvalue_ReaderBind(IDataReader dataReader)
		{
			Entity.cartproductoptionvalue model=new Entity.cartproductoptionvalue();
			object ojb; 
			ojb = dataReader["id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.id=(int)ojb;
			}
			ojb = dataReader["CartItemID"];
			if(ojb != null && ojb != DBNull.Value)
			{

                model.CartItemID = (long)ojb;
			}
			ojb = dataReader["ProductID"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.ProductID=(int)ojb;
			}
			ojb = dataReader["ProductOptionId"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.ProductOptionId=(int)ojb;
			}
			ojb = dataReader["ProductOptionItemId"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.ProductOptionItemId=(int)ojb;
			}
			model.OptionName=dataReader["OptionName"].ToString();
			model.ItemName=dataReader["ItemName"].ToString();
			ojb = dataReader["IsGive"];
			if(ojb != null && ojb != DBNull.Value)
			{
                if ((dataReader["IsGive"].ToString() == "1") || (dataReader["IsGive"].ToString().ToLower() == "true"))
                {
                    model.IsGive = true;
                }
                else
                {
                    model.IsGive = false;
                }
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
            ojb = dataReader["BuyUserID"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.BuyUserID = (int)ojb;
            }
            ojb = dataReader["Quantity"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.Quantity = (int)ojb;
            }
             ojb = dataReader["ProductPrice"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.ProductPrice = (decimal)ojb;
            }


			return model;
		}

		#endregion  成员方法
	}
}

