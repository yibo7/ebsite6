using System;
using System.Data;
using System.Text;
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
		private string sFieldGift = "id,BuyProductId,GiftProductId,Quantity,EndDateTime";
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int Gift_GetMaxId()
		{
			return DB.GetMaxID("id", string.Format("{0}Gift",sPre)); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Gift_Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("select count(1) from {0}Gift",sPre);
			strSql.Append(" where id=?id ");
			MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32,4)};
			parameters[0].Value = id;

			return DB.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Gift_Add(Entity.Gift model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("insert into {0}Gift(",sPre);
			strSql.Append("BuyProductId,GiftProductId,Quantity,EndDateTime)");
			strSql.Append(" values (");
			strSql.Append("?BuyProductId,?GiftProductId,?Quantity,?EndDateTime)");
			strSql.Append(";select @@IDENTITY");
			MySqlParameter[] parameters = {
					
					new MySqlParameter("?BuyProductId", MySqlDbType.Int32,4),
					new MySqlParameter("?GiftProductId", MySqlDbType.Int32,4),
					new MySqlParameter("?Quantity", MySqlDbType.Int32,4),
					new MySqlParameter("?EndDateTime", MySqlDbType.Datetime)};
			
			parameters[0].Value = model.BuyProductId;
			parameters[1].Value = model.GiftProductId;
			parameters[2].Value = model.Quantity;
			parameters[3].Value = model.EndDateTime;

			object obj = DB.ExecuteScalar(CommandType.Text,strSql.ToString(),parameters);
			if (obj == null)
			{
				return 1;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
			return 0;		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Gift_Update(Entity.Gift model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("update {0}Gift set ",sPre);
			strSql.Append("BuyProductId=?BuyProductId,");
			strSql.Append("GiftProductId=?GiftProductId,");
			strSql.Append("Quantity=?Quantity,");
			strSql.Append("EndDateTime=?EndDateTime");
			strSql.Append(" where id=?id ");
			MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32,4),
					new MySqlParameter("?BuyProductId", MySqlDbType.Int32,4),
					new MySqlParameter("?GiftProductId", MySqlDbType.Int32,4),
					new MySqlParameter("?Quantity", MySqlDbType.Int32,4),
					new MySqlParameter("?EndDateTime", MySqlDbType.Datetime)};
			parameters[0].Value = model.id;
			parameters[1].Value = model.BuyProductId;
			parameters[2].Value = model.GiftProductId;
			parameters[3].Value = model.Quantity;
			parameters[4].Value = model.EndDateTime;

			DB.ExecuteNonQuery(CommandType.Text,strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Gift_Delete(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("delete from {0}Gift ",sPre);
			strSql.Append(" where id=?id ");
			MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32,4)};
			parameters[0].Value = id;

			DB.ExecuteNonQuery(CommandType.Text,strSql.ToString(),parameters);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Entity.Gift Gift_GetEntity(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("select "+ sFieldGift +"  from {0}Gift ",sPre);
			strSql.Append(" where id=?id ");
			MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32,4)};
			parameters[0].Value = id;
			Entity.Gift model=null;
			using (IDataReader dataReader = DB.ExecuteReader(CommandType.Text, strSql.ToString(),parameters))
			{
				if(dataReader.Read())
				{
					model= Gift_ReaderBind(dataReader);
				}
			}
			return model;
		}
		/// <summary>
		/// 获取统计
		/// </summary>
		public int Gift_GetCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("select count(*)  from {0}Gift ",sPre);
            //if (strWhere.Trim() != "")
            //{
            //    strSql.Append(" where " + strWhere);
            //}
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
		public DataSet Gift_GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			
			strSql.Append(sFieldGift );
			strSql.AppendFormat(" FROM {0}Gift ",sPre);
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
		public List<Entity.Gift> Gift_GetListArray(string strWhere)
		{
			return Gift_GetListArray(0,strWhere,""); 
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public List<Entity.Gift> Gift_GetListArray(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			
			strSql.Append(sFieldGift );
			strSql.AppendFormat(" FROM {0}Gift ",sPre);
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
			List<Entity.Gift> list = new List<Entity.Gift>();
			using (IDataReader dataReader = DB.ExecuteReader(CommandType.Text, strSql.ToString()))
			{
				while (dataReader.Read())
				{
					list.Add(Gift_ReaderBind(dataReader));
				}
			}
			return list;
		}


		/// <summary>
		/// 获得分页数据
		/// </summary>
		public List<Entity.Gift> Gift_GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby,out int RecordCount)
		{
            StringBuilder sbSql = new StringBuilder();
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                //sbSql.Append(" where ");
                sbSql.AppendFormat(strWhere);
            }
            RecordCount = Gift_GetCount(sbSql.ToString());
            List<Entity.Gift> list = new List<Entity.Gift>();
            string strSql = SplitPages.GetSplitPagesMySql(DB, "Gift", PageSize, PageIndex, Fileds, "id", oderby, sbSql.ToString(), sPre);
            using (IDataReader dataReader = DB.ExecuteReader(CommandType.Text, strSql))
            {
                while (dataReader.Read())
                {
                    list.Add(Gift_ReaderBind(dataReader));
                }
            }
            return list;

           

			
		}


		/// <summary>
		/// 对象实体绑定数据
		/// </summary>
		public Entity.Gift Gift_ReaderBind(IDataReader dataReader)
		{
			Entity.Gift model=new Entity.Gift();
			object ojb; 
			ojb = dataReader["id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.id=(int)ojb;
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
			ojb = dataReader["EndDateTime"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.EndDateTime=(DateTime)ojb;
			}
			return model;
		}

		#endregion  成员方法


        public List<Entity.Gift> Gift_ListByProductID(long ProductID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select a.id,a.BuyProductId,a.GiftProductId,a.Quantity,a.EndDateTime,b.SmallPic,b.NewsTitle ");
            strSql.AppendFormat(" FROM {0}gift a,{1}newscontent b ", sPre, EbSite.Base.Host.Instance.GetSysTablePrefix);
            strSql.AppendFormat(" where  a.EndDateTime >NOW() and   a.GiftProductId = b.ID and a.BuyProductId ={0} ", ProductID);
            List<Entity.Gift> list = new List<Entity.Gift>();
            using (IDataReader dataReader = DB.ExecuteReader(CommandType.Text, strSql.ToString()))
            {
                while (dataReader.Read())
                {
                    list.Add(Gift_ReaderBind2(dataReader));
                }
            }
            return list;
        }
        /// <summary>
        /// 对象实体绑定数据
        /// </summary>
        public Entity.Gift Gift_ReaderBind2(IDataReader dataReader)
        {
            Entity.Gift model = new Entity.Gift();
            object ojb;
            ojb = dataReader["id"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.id = (int)ojb;
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
            ojb = dataReader["EndDateTime"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.EndDateTime = (DateTime)ojb;
            }
            model.SmallImg = dataReader["SmallPic"].ToString();
            model.ProductName = dataReader["NewsTitle"].ToString();

            return model;
        }
	}
}

