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
		private string sFieldgiftorderproduct = "id,OrderID,OrderNumber,OrderItemID,BuyProductId,GiftProductId,Quantity,BuyCount";
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int giftorderproduct_GetMaxId()
		{
			return DB.GetMaxID("id", string.Format("{0}giftorderproduct",sPre)); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool giftorderproduct_Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("select count(1) from {0}giftorderproduct",sPre);
			strSql.Append(" where id=?id ");
			MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32)};
			parameters[0].Value = id;

			return DB.Exists(strSql.ToString(),parameters);
		}

	    public int giftorderproduct_Add(Entity.giftorderproduct model)
	    {
	        return giftorderproduct_Add(model,null);
	    }

	    /// <summary>
		/// 增加一条数据
		/// </summary>
        public int giftorderproduct_Add(Entity.giftorderproduct model, MySqlTransaction Trans)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("insert into {0}giftorderproduct(",sPre);
			strSql.Append("OrderID,OrderNumber,OrderItemID,BuyProductId,GiftProductId,Quantity,BuyCount)");
			strSql.Append(" values (");
			strSql.Append("?OrderID,?OrderNumber,?OrderItemID,?BuyProductId,?GiftProductId,?Quantity,?BuyCount)");
			 strSql.Append(";SELECT @@session.identity");
			MySqlParameter[] parameters = {
					new MySqlParameter("?OrderID", MySqlDbType.Int32,11),
					new MySqlParameter("?OrderNumber", MySqlDbType.Int64,12),
					new MySqlParameter("?OrderItemID", MySqlDbType.Int64,12),
					new MySqlParameter("?BuyProductId", MySqlDbType.Int32,11),
					new MySqlParameter("?GiftProductId", MySqlDbType.Int32,11),
					new MySqlParameter("?Quantity", MySqlDbType.Int32,11),
					new MySqlParameter("?BuyCount", MySqlDbType.Int32,11)};
			parameters[0].Value = model.OrderID;
			parameters[1].Value = model.OrderNumber;
			parameters[2].Value = model.OrderItemID;
			parameters[3].Value = model.BuyProductId;
			parameters[4].Value = model.GiftProductId;
			parameters[5].Value = model.Quantity;
			parameters[6].Value = model.BuyCount;


             object obj = null;

	        if (Trans == null)
	        {
	             obj = DB.ExecuteScalar(CommandType.Text, strSql.ToString(), parameters);
	        }
	        else
	        {
                obj = DB.ExecuteScalar(Trans,CommandType.Text, strSql.ToString(), parameters);
	        }
	        if (obj == null)
			{
				return giftorderproduct_GetMaxId();
			}
			return 0;
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void giftorderproduct_Update(Entity.giftorderproduct model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("update {0}giftorderproduct set ",sPre);
			strSql.Append("OrderID=?OrderID,");
			strSql.Append("OrderNumber=?OrderNumber,");
			strSql.Append("OrderItemID=?OrderItemID,");
			strSql.Append("BuyProductId=?BuyProductId,");
			strSql.Append("GiftProductId=?GiftProductId,");
			strSql.Append("Quantity=?Quantity,");
			strSql.Append("BuyCount=?BuyCount");
			strSql.Append(" where id=?id ");
			MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32,11),
					new MySqlParameter("?OrderID", MySqlDbType.Int32,11),
					new MySqlParameter("?OrderNumber", MySqlDbType.Int64,12),
					new MySqlParameter("?OrderItemID", MySqlDbType.Int64,12),
					new MySqlParameter("?BuyProductId", MySqlDbType.Int32,11),
					new MySqlParameter("?GiftProductId", MySqlDbType.Int32,11),
					new MySqlParameter("?Quantity", MySqlDbType.Int32,11),
					new MySqlParameter("?BuyCount", MySqlDbType.Int32,11)};
			parameters[0].Value = model.id;
			parameters[1].Value = model.OrderID;
			parameters[2].Value = model.OrderNumber;
			parameters[3].Value = model.OrderItemID;
			parameters[4].Value = model.BuyProductId;
			parameters[5].Value = model.GiftProductId;
			parameters[6].Value = model.Quantity;
			parameters[7].Value = model.BuyCount;

			DB.ExecuteNonQuery(CommandType.Text,strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void giftorderproduct_Delete(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("delete from {0}giftorderproduct ",sPre);
			strSql.Append(" where id=?id ");
			MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32)};
			parameters[0].Value = id;

			DB.ExecuteNonQuery(CommandType.Text,strSql.ToString(),parameters);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Entity.giftorderproduct giftorderproduct_GetEntity(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("select "+ sFieldgiftorderproduct +"  from {0}giftorderproduct ",sPre);
			strSql.Append(" where id=?id ");
			MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32)};
			parameters[0].Value = id;
			Entity.giftorderproduct model=null;
			using (IDataReader dataReader = DB.ExecuteReader(CommandType.Text, strSql.ToString(),parameters))
			{
				if(dataReader.Read())
				{
					model= giftorderproduct_ReaderBind(dataReader);
				}
			}
			return model;
		}
		/// <summary>
		/// 获取统计
		/// </summary>
		public int giftorderproduct_GetCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("select count(*)  from {0}giftorderproduct ",sPre);
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
		public DataSet giftorderproduct_GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			strSql.Append(sFieldgiftorderproduct );
			strSql.AppendFormat(" FROM {0}giftorderproduct ",sPre);
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
		public List<Entity.giftorderproduct> giftorderproduct_GetListArray(string strWhere)
		{
			return giftorderproduct_GetListArray(0,strWhere,""); 
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public List<Entity.giftorderproduct> giftorderproduct_GetListArray(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			
            strSql.AppendFormat("SELECT a.*,b.NewsTitle,b.SmallPic,b.Annex16 from {0}giftorderproduct a  LEFT OUTER JOIN {1}newscontent b on a.GiftProductId=b.ID  ", sPre,EbSite.Base.Host.Instance.GetSysTablePrefix);
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
			List<Entity.giftorderproduct> list = new List<Entity.giftorderproduct>();
			using (IDataReader dataReader = DB.ExecuteReader(CommandType.Text, strSql.ToString()))
			{
				while (dataReader.Read())
				{
					list.Add(giftorderproduct_ReaderBind2(dataReader));
				}
			}
			return list;
		}


		/// <summary>
		/// 获得分页数据
		/// </summary>
		public List<Entity.giftorderproduct> giftorderproduct_GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby,out int RecordCount)
		{
			List<Entity.giftorderproduct> list = new List<Entity.giftorderproduct>();
			RecordCount = giftorderproduct_GetCount(strWhere);
			string strSql = SplitPages.GetSplitPagesMySql(DbHelperCms.Instance, "giftorderproduct", PageSize, PageIndex, Fileds, "id",  oderby, strWhere, sPre);
			using (IDataReader dataReader = DbHelperCms.Instance.ExecuteReader(CommandType.Text, strSql))
			{
				while (dataReader.Read())
				{
					list.Add(giftorderproduct_ReaderBind(dataReader));
				}
			}
			return list;
		}


		/// <summary>
		/// 对象实体绑定数据
		/// </summary>
		public Entity.giftorderproduct giftorderproduct_ReaderBind(IDataReader dataReader)
		{
			Entity.giftorderproduct model=new Entity.giftorderproduct();
			object ojb; 
			ojb = dataReader["id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.id=(int)ojb;
			}
			ojb = dataReader["OrderID"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.OrderID=(int)ojb;
			}

            ojb = dataReader["OrderNumber"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.OrderNumber = (long)ojb;
            }

			
			ojb = dataReader["OrderItemID"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.OrderItemID=(long)ojb;
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
			return model;
		}


        public Entity.giftorderproduct giftorderproduct_ReaderBind2(IDataReader dataReader)
        {
            Entity.giftorderproduct model = new Entity.giftorderproduct();
            object ojb;
            ojb = dataReader["id"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.id = (int)ojb;
            }
            ojb = dataReader["OrderID"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.OrderID = (int)ojb;
            }

            ojb = dataReader["OrderNumber"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.OrderNumber = (long)ojb;
            }


            ojb = dataReader["OrderItemID"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.OrderItemID = (long)ojb;
            }
            ojb = dataReader["BuyProductId"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.BuyProductId = (int)ojb;
            }
            ojb = dataReader["GiftProductId"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.GiftProductId = (int)ojb;
            }
            ojb = dataReader["Quantity"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.Quantity = (int)ojb;
            }
            ojb = dataReader["BuyCount"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.BuyCount = (int)ojb;
            }


            model.NewsTitle = dataReader["NewsTitle"].ToString();
            model.SmallPic = dataReader["SmallPic"].ToString();
            model.Annex16 = dataReader["Annex16"].ToString();
            return model;
        }
      
		#endregion  成员方法
	}
}

