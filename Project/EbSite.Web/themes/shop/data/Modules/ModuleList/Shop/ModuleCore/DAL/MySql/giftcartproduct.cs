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
        private string sFieldgiftcartproduct = "id,CartItemID,BuyProductId,GiftProductId,Quantity,BuyCount,ProductName,SmallImg,BuyUserID";
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int giftcartproduct_GetMaxId()
		{
			return DB.GetMaxID("id", string.Format("{0}giftcartproduct",sPre)); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool giftcartproduct_Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("select count(1) from {0}giftcartproduct",sPre);
			strSql.Append(" where id=?id ");
			MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32)};
			parameters[0].Value = id;

			return DB.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int giftcartproduct_Add(Entity.giftcartproduct model)
		{

		    return giftcartproduct_Add(model, null);

		    //StringBuilder strSql=new StringBuilder();
		    //strSql.AppendFormat("insert into {0}giftcartproduct(",sPre);
		    //strSql.Append("CartItemID,BuyProductId,GiftProductId,Quantity,BuyCount,ProductName,SmallImg)");
		    //strSql.Append(" values (");
		    //strSql.Append("?CartItemID,?BuyProductId,?GiftProductId,?Quantity,?BuyCount,?ProductName,?SmallImg)");
		    // strSql.Append(";SELECT @@session.identity");
		    //MySqlParameter[] parameters = {
		    //        new MySqlParameter("?CartItemID", MySqlDbType.Int64,12),
		    //        new MySqlParameter("?BuyProductId", MySqlDbType.Int32,11),
		    //        new MySqlParameter("?GiftProductId", MySqlDbType.Int32,11),
		    //        new MySqlParameter("?Quantity", MySqlDbType.Int32,11),
		    //        new MySqlParameter("?BuyCount", MySqlDbType.Int32,11),
		    //        new MySqlParameter("?ProductName", MySqlDbType.VarChar,100),
		    //        new MySqlParameter("?SmallImg", MySqlDbType.VarChar,300)

		    //                              };
		    //parameters[0].Value = model.CartItemID;
		    //parameters[1].Value = model.BuyProductId;
		    //parameters[2].Value = model.GiftProductId;
		    //parameters[3].Value = model.Quantity;
		    //parameters[4].Value = model.BuyCount;
		    //parameters[5].Value = model.ProductName;
		    //parameters[6].Value = model.SmallImg;

		    //object obj = DB.ExecuteScalar(CommandType.Text,strSql.ToString(),parameters);
		    //if (obj == null)
		    //{
		    //    return giftcartproduct_GetMaxId();
		    //}
		    //return 0;
		}

        public int giftcartproduct_Add(Entity.giftcartproduct model, MySqlTransaction Trans)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("insert into {0}giftcartproduct(", sPre);
            strSql.Append("CartItemID,BuyProductId,GiftProductId,Quantity,BuyCount,ProductName,SmallImg,BuyUserID)");
            strSql.Append(" values (");
            strSql.Append("?CartItemID,?BuyProductId,?GiftProductId,?Quantity,?BuyCount,?ProductName,?SmallImg,?BuyUserID)");
            strSql.Append(";SELECT @@session.identity");
            MySqlParameter[] parameters = {
					new MySqlParameter("?CartItemID", MySqlDbType.Int64,12),
					new MySqlParameter("?BuyProductId", MySqlDbType.Int32,11),
					new MySqlParameter("?GiftProductId", MySqlDbType.Int32,11),
					new MySqlParameter("?Quantity", MySqlDbType.Int32,11),
					new MySqlParameter("?BuyCount", MySqlDbType.Int32,11),
                    new MySqlParameter("?ProductName", MySqlDbType.VarChar,100),
                    new MySqlParameter("?SmallImg", MySqlDbType.VarChar,300),
                    new MySqlParameter("?BuyUserID", MySqlDbType.Int32,11)
                                          
                                          };
            parameters[0].Value = model.CartItemID;
            parameters[1].Value = model.BuyProductId;
            parameters[2].Value = model.GiftProductId;
            parameters[3].Value = model.Quantity;
            parameters[4].Value = model.BuyCount;
            parameters[5].Value = model.ProductName;
            parameters[6].Value = model.SmallImg;
            parameters[7].Value = model.BuyUserID;

            if (!Equals(Trans, null))
            {
                object obj = DB.ExecuteScalar(Trans, CommandType.Text, strSql.ToString(), parameters);
                if (obj == null)
                {
                    return giftcartproduct_GetMaxId();
                }
                return 0;
            }
            else
            {
                object obj = DB.ExecuteScalar(CommandType.Text, strSql.ToString(), parameters);
                if (obj == null)
                {
                    return giftcartproduct_GetMaxId();
                }
                return 0;
            }
            
        }

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void giftcartproduct_Update(Entity.giftcartproduct model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("update {0}giftcartproduct set ",sPre);
			strSql.Append("CartItemID=?CartItemID,");
			strSql.Append("BuyProductId=?BuyProductId,");
			strSql.Append("GiftProductId=?GiftProductId,");
			strSql.Append("Quantity=?Quantity,");
			strSql.Append("BuyCount=?BuyCount,");
            strSql.Append("ProductName=?ProductName,");
            strSql.Append("SmallImg=?SmallImg,");
            strSql.Append("BuyUserID=?BuyUserID");
            
			strSql.Append(" where id=?id ");
			MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32,11),
					new MySqlParameter("?CartItemID", MySqlDbType.Int64,12),
					new MySqlParameter("?BuyProductId", MySqlDbType.Int32,11),
					new MySqlParameter("?GiftProductId", MySqlDbType.Int32,11),
					new MySqlParameter("?Quantity", MySqlDbType.Int32,11),
					new MySqlParameter("?BuyCount", MySqlDbType.Int32,11),
                     new MySqlParameter("?ProductName", MySqlDbType.VarChar,100),
                    new MySqlParameter("?SmallImg", MySqlDbType.VarChar,300),
                    new MySqlParameter("?BuyUserID", MySqlDbType.Int32,11)
                                          };
			parameters[0].Value = model.id;
			parameters[1].Value = model.CartItemID;
			parameters[2].Value = model.BuyProductId;
			parameters[3].Value = model.GiftProductId;
			parameters[4].Value = model.Quantity;
			parameters[5].Value = model.BuyCount;
            parameters[6].Value = model.ProductName;
            parameters[7].Value = model.SmallImg;
            parameters[8].Value = model.BuyUserID;
           
			DB.ExecuteNonQuery(CommandType.Text,strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void giftcartproduct_Delete(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("delete from {0}giftcartproduct ",sPre);
			strSql.Append(" where id=?id ");
			MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32)};
			parameters[0].Value = id;

			DB.ExecuteNonQuery(CommandType.Text,strSql.ToString(),parameters);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Entity.giftcartproduct giftcartproduct_GetEntity(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("select "+ sFieldgiftcartproduct +"  from {0}giftcartproduct ",sPre);
			strSql.Append(" where id=?id ");
			MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32)};
			parameters[0].Value = id;
			Entity.giftcartproduct model=null;
			using (IDataReader dataReader = DB.ExecuteReader(CommandType.Text, strSql.ToString(),parameters))
			{
				if(dataReader.Read())
				{
					model= giftcartproduct_ReaderBind(dataReader);
				}
			}
			return model;
		}
		/// <summary>
		/// 获取统计
		/// </summary>
		public int giftcartproduct_GetCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("select count(*)  from {0}giftcartproduct ",sPre);
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
		public DataSet giftcartproduct_GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			strSql.Append(sFieldgiftcartproduct );
			strSql.AppendFormat(" FROM {0}giftcartproduct ",sPre);
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
		public List<Entity.giftcartproduct> giftcartproduct_GetListArray(string strWhere)
		{
			return giftcartproduct_GetListArray(0,strWhere,""); 
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public List<Entity.giftcartproduct> giftcartproduct_GetListArray(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
		
			strSql.Append(sFieldgiftcartproduct );
			strSql.AppendFormat(" FROM {0}giftcartproduct ",sPre);
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
			List<Entity.giftcartproduct> list = new List<Entity.giftcartproduct>();
			using (IDataReader dataReader = DB.ExecuteReader(CommandType.Text, strSql.ToString()))
			{
				while (dataReader.Read())
				{
					list.Add(giftcartproduct_ReaderBind(dataReader));
				}
			}
			return list;
		}


		/// <summary>
		/// 获得分页数据
		/// </summary>
		public List<Entity.giftcartproduct> giftcartproduct_GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby,out int RecordCount)
		{
			List<Entity.giftcartproduct> list = new List<Entity.giftcartproduct>();
			RecordCount = giftcartproduct_GetCount(strWhere);
			string strSql = SplitPages.GetSplitPagesMySql(DbHelperCms.Instance, "giftcartproduct", PageSize, PageIndex, Fileds, "id",  oderby, strWhere, sPre);
			using (IDataReader dataReader = DbHelperCms.Instance.ExecuteReader(CommandType.Text, strSql))
			{
				while (dataReader.Read())
				{
					list.Add(giftcartproduct_ReaderBind(dataReader));
				}
			}
			return list;
		}


		/// <summary>
		/// 对象实体绑定数据
		/// </summary>
		public Entity.giftcartproduct giftcartproduct_ReaderBind(IDataReader dataReader)
		{
			Entity.giftcartproduct model=new Entity.giftcartproduct();
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
			ojb = dataReader["BuyProductId"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.BuyProductId=(int)ojb;
			}
			ojb = dataReader["GiftProductId"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.GiftProductId=(int)ojb;
			}
			ojb = dataReader["Quantity"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Quantity=(int)ojb;
			}
			ojb = dataReader["BuyCount"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.BuyCount=(int)ojb;
			}

            model.ProductName = dataReader["ProductName"].ToString();
            model.SmallImg = dataReader["SmallImg"].ToString();

            ojb = dataReader["BuyUserID"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.BuyUserID = (int)ojb;
            }
			return model;
		}

		#endregion  成员方法
	}
}

