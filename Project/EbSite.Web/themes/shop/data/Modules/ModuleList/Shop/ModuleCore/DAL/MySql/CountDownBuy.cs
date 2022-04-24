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
        private string sFieldCountDownBuy = "id,ProductId,StartDate,EndDate,Content,OrderID,CountDownPrice,Price,Title,SmallImg,Status,Buyed";

		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int CountDownBuy_GetMaxId()
		{
			return DB.GetMaxID("id", string.Format("{0}CountDownBuy",sPre)); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool CountDownBuy_Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("select count(1) from {0}CountDownBuy",sPre);
			strSql.Append(" where id=?id ");
			MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32,4)};
			parameters[0].Value = id;

			return DB.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int CountDownBuy_Add(Entity.CountDownBuy model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("insert into {0}CountDownBuy(",sPre);
            strSql.Append("ProductId,StartDate,EndDate,Content,OrderID,CountDownPrice,Price,Title,SmallImg,Status,Buyed)");
			strSql.Append(" values (");
            strSql.Append("?ProductId,?StartDate,?EndDate,?Content,?OrderID,?CountDownPrice,?Price,?Title,?SmallImg,?Status,?Buyed)");
			strSql.Append(";select @@IDENTITY");
			MySqlParameter[] parameters = {
					new MySqlParameter("?ProductId", MySqlDbType.Int32,4),
					new MySqlParameter("?StartDate", MySqlDbType.DateTime),
					new MySqlParameter("?EndDate", MySqlDbType.DateTime),
					new MySqlParameter("?Content", MySqlDbType.VarChar),
					new MySqlParameter("?OrderID", MySqlDbType.Int32,4),
					new MySqlParameter("?CountDownPrice", MySqlDbType.Decimal,9),
                    new MySqlParameter("?Price", MySqlDbType.Decimal,18),
                    new MySqlParameter("?Title", MySqlDbType.VarChar,255),
                    new MySqlParameter("?SmallImg", MySqlDbType.VarChar,255),
                    new MySqlParameter("?Status",MySqlDbType.Int32,4),
                    new MySqlParameter("?Buyed",MySqlDbType.Int32,4)};
			
			parameters[0].Value = model.ProductId;
			parameters[1].Value = model.StartDate;
			parameters[2].Value = model.EndDate;
			parameters[3].Value = model.Content;
			parameters[4].Value = model.OrderID;
			parameters[5].Value = model.CountDownPrice;
            parameters[6].Value = model.Price;
            parameters[7].Value = model.Title;
            parameters[8].Value = model.SmallImg;

		    parameters[9].Value = model.Status;
		    parameters[10].Value = model.Buyed;

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
        public void CountDownBuy_Update(Entity.CountDownBuy model)
        {
            CountDownBuy_Update(model,null);
        }
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void CountDownBuy_Update(Entity.CountDownBuy model,MySqlTransaction trans)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("update {0}CountDownBuy set ",sPre);
			strSql.Append("ProductId=?ProductId,");
			strSql.Append("StartDate=?StartDate,");
			strSql.Append("EndDate=?EndDate,");
			strSql.Append("Content=?Content,");
			strSql.Append("OrderID=?OrderID,");
			strSql.Append("CountDownPrice=?CountDownPrice,");
            strSql.Append("Price=?Price,");
            strSql.Append("Title=?Title,");
            strSql.Append("SmallImg=?SmallImg,");
            strSql.Append("Status=?Status,");
            strSql.Append("Buyed=?Buyed");
			strSql.Append(" where id=?id ");
			MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32,4),
					new MySqlParameter("?ProductId", MySqlDbType.Int32,4),
					new MySqlParameter("?StartDate", MySqlDbType.DateTime),
					new MySqlParameter("?EndDate", MySqlDbType.DateTime),
					new MySqlParameter("?Content", MySqlDbType.VarChar),
					new MySqlParameter("?OrderID", MySqlDbType.Int32,4),
					new MySqlParameter("?CountDownPrice", MySqlDbType.Decimal,9),
                    new MySqlParameter("?Price", MySqlDbType.Decimal,18),
                    new MySqlParameter("?Title", MySqlDbType.VarChar,255),
                    new MySqlParameter("?SmallImg", MySqlDbType.VarChar,255),
                     new MySqlParameter("?Status",MySqlDbType.Int32,4),
                    new MySqlParameter("?Buyed",MySqlDbType.Int32,4)
                                          };
			parameters[0].Value = model.id;
			parameters[1].Value = model.ProductId;
			parameters[2].Value = model.StartDate;
			parameters[3].Value = model.EndDate;
			parameters[4].Value = model.Content;
			parameters[5].Value = model.OrderID;
			parameters[6].Value = model.CountDownPrice;
            parameters[7].Value = model.Price;
            parameters[8].Value = model.Title;
            parameters[9].Value = model.SmallImg;

            parameters[10].Value = model.Status;
            parameters[11].Value = model.Buyed;
            if (trans == null)
            {
                DB.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
            }
            else
            {
                DB.ExecuteNonQuery(trans,CommandType.Text, strSql.ToString(), parameters);
            }
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void CountDownBuy_Delete(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("delete from {0}CountDownBuy ",sPre);
			strSql.Append(" where id=?id ");
			MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32,4)};
			parameters[0].Value = id;

			DB.ExecuteNonQuery(CommandType.Text,strSql.ToString(),parameters);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Entity.CountDownBuy CountDownBuy_GetEntity(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("select "+ sFieldCountDownBuy +"  from {0}CountDownBuy ",sPre);
			strSql.Append(" where id=?id ");
			MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32,4)};
			parameters[0].Value = id;
			Entity.CountDownBuy model=null;
			using (IDataReader dataReader = DB.ExecuteReader(CommandType.Text, strSql.ToString(),parameters))
			{
				if(dataReader.Read())
				{
					model= CountDownBuy_ReaderBind(dataReader);
				}
			}
			return model;
		}
		/// <summary>
		/// 获取统计
		/// </summary>
		public int CountDownBuy_GetCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("select count(*)  from {0}CountDownBuy ",sPre);
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
		public DataSet CountDownBuy_GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			
			strSql.Append(sFieldCountDownBuy );
			strSql.AppendFormat(" FROM {0}CountDownBuy ",sPre);
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
			return DB.ExecuteDataset(CommandType.Text, strSql.ToString());
		}

		/// <summary>
		/// 获得数据列表（比DataSet效率高，推荐使用）
		/// </summary>
		public List<Entity.CountDownBuy> CountDownBuy_GetListArray(string strWhere)
		{
			return CountDownBuy_GetListArray(0,strWhere,""); 
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public List<Entity.CountDownBuy> CountDownBuy_GetListArray(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			
			strSql.Append(sFieldCountDownBuy );
			strSql.AppendFormat(" FROM {0}CountDownBuy ",sPre);
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
			List<Entity.CountDownBuy> list = new List<Entity.CountDownBuy>();
			using (IDataReader dataReader = DB.ExecuteReader(CommandType.Text, strSql.ToString()))
			{
				while (dataReader.Read())
				{
					list.Add(CountDownBuy_ReaderBind(dataReader));
				}
			}
			return list;
		}


		/// <summary>
		/// 获得分页数据
		/// </summary>
		public List<Entity.CountDownBuy> CountDownBuy_GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby,out int RecordCount)
		{


            StringBuilder sbSql = new StringBuilder();
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                //sbSql.Append(" where ");
                sbSql.AppendFormat(strWhere);
            }
            RecordCount = CountDownBuy_GetCount(sbSql.ToString());
            List<Entity.CountDownBuy> list = new List<Entity.CountDownBuy>();
            string strSql = SplitPages.GetSplitPagesMySql(DB, "CountDownBuy", PageSize, PageIndex, Fileds, "id", oderby, sbSql.ToString(), sPre);
            using (IDataReader dataReader = DB.ExecuteReader(CommandType.Text, strSql))
            {
                while (dataReader.Read())
                {
                    list.Add(CountDownBuy_ReaderBind(dataReader));
                }
            }
            return list;



		}


		/// <summary>
		/// 对象实体绑定数据
		/// </summary>
		public Entity.CountDownBuy CountDownBuy_ReaderBind(IDataReader dataReader)
		{
			Entity.CountDownBuy model=new Entity.CountDownBuy();
			object ojb; 
			ojb = dataReader["id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.id=(int)ojb;
			}
			ojb = dataReader["ProductId"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.ProductId=(int)ojb;
			}
			ojb = dataReader["StartDate"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.StartDate=(DateTime)ojb;
			}
			ojb = dataReader["EndDate"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.EndDate=(DateTime)ojb;
			}
			model.Content=dataReader["Content"].ToString();
			ojb = dataReader["OrderID"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.OrderID=(int)ojb;
			}
			ojb = dataReader["CountDownPrice"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.CountDownPrice=(decimal)ojb;
			}
            ojb = dataReader["Price"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.Price = (decimal)ojb;
            }
            model.Title = dataReader["Title"].ToString();
            model.SmallImg = dataReader["SmallImg"].ToString();

            ojb = dataReader["Status"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Status=(int)ojb;
			}
            ojb = dataReader["Buyed"];
			if(ojb != null && ojb != DBNull.Value)
			{
                model.Buyed = (int)ojb;
			}
            

                
			return model;
		}

		#endregion  成员方法

        /// <summary>
        /// 定时更新抢购状态
        /// </summary>
        /// <returns></returns>
        public bool CountDownBuy_UpdateStatus()
        {
            string tableName = string.Format("{0}countdownbuy",sPre);
            string strSql = string.Format("update {0} set status=2 where DATEDIFF(NOW(),StartDate)<0;", tableName);
            strSql += string.Format("update {0} set status=0 where DATEDIFF(NOW(),StartDate)>=0 and DATEDIFF(NOW(),EndDate)<=0;", tableName);
            strSql += string.Format("update {0} set status=1 where DATEDIFF(NOW(),EndDate)>0;", tableName);

            return DB.ExecuteNonQuery(CommandType.Text, strSql) > 0 ? true : false;
        }

	}
}

