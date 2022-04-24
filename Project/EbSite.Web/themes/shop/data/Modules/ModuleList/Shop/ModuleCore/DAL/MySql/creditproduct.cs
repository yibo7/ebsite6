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
        private string sFieldcreditproduct = "id,ProductName,SmallImg,BigImg,Unit,CostPrice,MarketPrice,Credit,Outline,SeoDes,SeoKeyWord,SeoTitle,Info,AddTime,AddUserID,IsSaling,Stock,ClassID,ExchangeNum";
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int creditproduct_GetMaxId()
		{
			return DB.GetMaxID("id", string.Format("{0}creditproduct",sPre)); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool creditproduct_Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("select count(1) from {0}creditproduct",sPre);
			strSql.Append(" where id=?id ");
			MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32)};
			parameters[0].Value = id;

			return DB.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int creditproduct_Add(Entity.creditproduct model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("insert into {0}creditproduct(",sPre);
            strSql.Append("ProductName,SmallImg,BigImg,Unit,CostPrice,MarketPrice,Credit,Outline,SeoDes,SeoKeyWord,SeoTitle,Info,AddTime,AddUserID,IsSaling,Stock,ClassID,ExchangeNum)");
			strSql.Append(" values (");
            strSql.Append("?ProductName,?SmallImg,?BigImg,?Unit,?CostPrice,?MarketPrice,?Credit,?Outline,?SeoDes,?SeoKeyWord,?SeoTitle,?Info,?AddTime,?AddUserID,?IsSaling,?Stock,?ClassID,?ExchangeNum)");
			 strSql.Append(";SELECT @@session.identity");
			MySqlParameter[] parameters = {
					new MySqlParameter("?ProductName", MySqlDbType.VarChar,200),
					new MySqlParameter("?SmallImg", MySqlDbType.VarChar,225),
					new MySqlParameter("?BigImg", MySqlDbType.VarChar,225),
					new MySqlParameter("?Unit", MySqlDbType.VarChar,5),
					new MySqlParameter("?CostPrice", MySqlDbType.Decimal,10),
					new MySqlParameter("?MarketPrice", MySqlDbType.Decimal,10),
					new MySqlParameter("?Credit", MySqlDbType.Int32,11),
					new MySqlParameter("?Outline", MySqlDbType.Text),
					new MySqlParameter("?SeoDes", MySqlDbType.VarChar,500),
					new MySqlParameter("?SeoKeyWord", MySqlDbType.VarChar,500),
					new MySqlParameter("?SeoTitle", MySqlDbType.VarChar,100),
					new MySqlParameter("?Info", MySqlDbType.Text),
					new MySqlParameter("?AddTime", MySqlDbType.Int32,10),
					new MySqlParameter("?AddUserID", MySqlDbType.Int32,11),
					new MySqlParameter("?IsSaling", MySqlDbType.Int32,4),
					new MySqlParameter("?Stock", MySqlDbType.Int32,11),
					new MySqlParameter("?ClassID", MySqlDbType.Int32,11),
                    new MySqlParameter("?ExchangeNum",MySqlDbType.Int32,11)};
			parameters[0].Value = model.ProductName;
			parameters[1].Value = model.SmallImg;
			parameters[2].Value = model.BigImg;
			parameters[3].Value = model.Unit;
			parameters[4].Value = model.CostPrice;
			parameters[5].Value = model.MarketPrice;
			parameters[6].Value = model.Credit;
			parameters[7].Value = model.Outline;
			parameters[8].Value = model.SeoDes;
			parameters[9].Value = model.SeoKeyWord;
			parameters[10].Value = model.SeoTitle;
			parameters[11].Value = model.Info;
			parameters[12].Value = model.AddTime;
			parameters[13].Value = model.AddUserID;
			parameters[14].Value = model.IsSaling;
			parameters[15].Value = model.Stock;
			parameters[16].Value = model.ClassID;
            parameters[17].Value = model.ExchangeNum;

			object obj = DB.ExecuteScalar(CommandType.Text,strSql.ToString(),parameters);
			if (obj == null)
			{
				return creditproduct_GetMaxId();
			}
			return 0;
		}
        public void creditproduct_Update(Entity.creditproduct model)
        {
            creditproduct_Update(model,null);
        }


		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void creditproduct_Update(Entity.creditproduct model,MySqlTransaction Trans)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("update {0}creditproduct set ",sPre);
			strSql.Append("ProductName=?ProductName,");
			strSql.Append("SmallImg=?SmallImg,");
			strSql.Append("BigImg=?BigImg,");
			strSql.Append("Unit=?Unit,");
			strSql.Append("CostPrice=?CostPrice,");
			strSql.Append("MarketPrice=?MarketPrice,");
			strSql.Append("Credit=?Credit,");
			strSql.Append("Outline=?Outline,");
			strSql.Append("SeoDes=?SeoDes,");
			strSql.Append("SeoKeyWord=?SeoKeyWord,");
			strSql.Append("SeoTitle=?SeoTitle,");
			strSql.Append("Info=?Info,");
			strSql.Append("AddTime=?AddTime,");
			strSql.Append("AddUserID=?AddUserID,");
			strSql.Append("IsSaling=?IsSaling,");
			strSql.Append("Stock=?Stock,");
			strSql.Append("ClassID=?ClassID,");
            strSql.Append("ExchangeNum=?ExchangeNum");
			strSql.Append(" where id=?id ");
			MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32,11),
					new MySqlParameter("?ProductName", MySqlDbType.VarChar,200),
					new MySqlParameter("?SmallImg", MySqlDbType.VarChar,225),
					new MySqlParameter("?BigImg", MySqlDbType.VarChar,225),
					new MySqlParameter("?Unit", MySqlDbType.VarChar,5),
					new MySqlParameter("?CostPrice", MySqlDbType.Decimal,10),
					new MySqlParameter("?MarketPrice", MySqlDbType.Decimal,10),
					new MySqlParameter("?Credit", MySqlDbType.Int32,11),
					new MySqlParameter("?Outline", MySqlDbType.Text),
					new MySqlParameter("?SeoDes", MySqlDbType.VarChar,500),
					new MySqlParameter("?SeoKeyWord", MySqlDbType.VarChar,500),
					new MySqlParameter("?SeoTitle", MySqlDbType.VarChar,100),
					new MySqlParameter("?Info", MySqlDbType.Text),
					new MySqlParameter("?AddTime", MySqlDbType.Int32,10),
					new MySqlParameter("?AddUserID", MySqlDbType.Int32,11),
					new MySqlParameter("?IsSaling", MySqlDbType.Int32,4),
					new MySqlParameter("?Stock", MySqlDbType.Int32,11),
					new MySqlParameter("?ClassID", MySqlDbType.Int32,11),
                    new MySqlParameter("?ExchangeNum",MySqlDbType.Int32,11)};
			parameters[0].Value = model.id;
			parameters[1].Value = model.ProductName;
			parameters[2].Value = model.SmallImg;
			parameters[3].Value = model.BigImg;
			parameters[4].Value = model.Unit;
			parameters[5].Value = model.CostPrice;
			parameters[6].Value = model.MarketPrice;
			parameters[7].Value = model.Credit;
			parameters[8].Value = model.Outline;
			parameters[9].Value = model.SeoDes;
			parameters[10].Value = model.SeoKeyWord;
			parameters[11].Value = model.SeoTitle;
			parameters[12].Value = model.Info;
			parameters[13].Value = model.AddTime;
			parameters[14].Value = model.AddUserID;
			parameters[15].Value = model.IsSaling;
			parameters[16].Value = model.Stock;
			parameters[17].Value = model.ClassID;
            parameters[18].Value = model.ExchangeNum;
            if (Trans != null)
            {
                DB.ExecuteNonQuery(Trans,CommandType.Text, strSql.ToString(), parameters);
            }
            else
            {
                DB.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
            }
			
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void creditproduct_Delete(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("delete from {0}creditproduct ",sPre);
			strSql.Append(" where id=?id ");
			MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32)};
			parameters[0].Value = id;

			DB.ExecuteNonQuery(CommandType.Text,strSql.ToString(),parameters);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Entity.creditproduct creditproduct_GetEntity(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("select "+ sFieldcreditproduct +"  from {0}creditproduct ",sPre);
			strSql.Append(" where id=?id ");
			MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32)};
			parameters[0].Value = id;
			Entity.creditproduct model=null;
			using (IDataReader dataReader = DB.ExecuteReader(CommandType.Text, strSql.ToString(),parameters))
			{
				if(dataReader.Read())
				{
					model= creditproduct_ReaderBind(dataReader);
				}
			}
			return model;
		}
		/// <summary>
		/// 获取统计
		/// </summary>
		public int creditproduct_GetCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("select count(*)  from {0}creditproduct ",sPre);
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
		public DataSet creditproduct_GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			strSql.Append(sFieldcreditproduct );
			strSql.AppendFormat(" FROM {0}creditproduct ",sPre);
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
		public List<Entity.creditproduct> creditproduct_GetListArray(string strWhere)
		{
			return creditproduct_GetListArray(0,strWhere,""); 
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public List<Entity.creditproduct> creditproduct_GetListArray(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			
			strSql.Append(sFieldcreditproduct );
			strSql.AppendFormat(" FROM {0}creditproduct ",sPre);
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
			List<Entity.creditproduct> list = new List<Entity.creditproduct>();
			using (IDataReader dataReader = DB.ExecuteReader(CommandType.Text, strSql.ToString()))
			{
				while (dataReader.Read())
				{
					list.Add(creditproduct_ReaderBind(dataReader));
				}
			}
			return list;
		}


		/// <summary>
		/// 获得分页数据
		/// </summary>
		public List<Entity.creditproduct> creditproduct_GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby,out int RecordCount)
		{
			List<Entity.creditproduct> list = new List<Entity.creditproduct>();
			RecordCount = creditproduct_GetCount(strWhere);
			string strSql = SplitPages.GetSplitPagesMySql(DbHelperCms.Instance, "creditproduct", PageSize, PageIndex, Fileds, "id",  oderby, strWhere, sPre);
			using (IDataReader dataReader = DbHelperCms.Instance.ExecuteReader(CommandType.Text, strSql))
			{
				while (dataReader.Read())
				{
					list.Add(creditproduct_ReaderBind(dataReader));
				}
			}
			return list;
		}


		/// <summary>
		/// 对象实体绑定数据
		/// </summary>
		public Entity.creditproduct creditproduct_ReaderBind(IDataReader dataReader)
		{
			Entity.creditproduct model=new Entity.creditproduct();
			object ojb; 
			ojb = dataReader["id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.id=(int)ojb;
			}
			model.ProductName=dataReader["ProductName"].ToString();
			model.SmallImg=dataReader["SmallImg"].ToString();
			model.BigImg=dataReader["BigImg"].ToString();
			model.Unit=dataReader["Unit"].ToString();
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
			ojb = dataReader["Credit"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Credit=(int)ojb;
			}
			model.Outline=dataReader["Outline"].ToString();
			model.SeoDes=dataReader["SeoDes"].ToString();
			model.SeoKeyWord=dataReader["SeoKeyWord"].ToString();
			model.SeoTitle=dataReader["SeoTitle"].ToString();
			model.Info=dataReader["Info"].ToString();
			ojb = dataReader["AddTime"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.AddTime=(int)ojb;
			}
			ojb = dataReader["AddUserID"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.AddUserID=(int)ojb;
			}
			ojb = dataReader["IsSaling"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.IsSaling=(int)ojb;
			}
			ojb = dataReader["Stock"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Stock=(int)ojb;
			}
			ojb = dataReader["ClassID"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.ClassID=(int)ojb;
			}
            ojb = dataReader["ExchangeNum"];
			if(ojb != null && ojb != DBNull.Value)
			{
                model.ExchangeNum = (int)ojb;
			}
            
			return model;
		}

		#endregion  成员方法
	}
}

