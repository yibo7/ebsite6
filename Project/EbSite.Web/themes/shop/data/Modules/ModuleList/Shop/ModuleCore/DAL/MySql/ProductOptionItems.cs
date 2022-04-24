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
        private string sFieldProductOptionItems = "id,ProductOptionID,ItemName,IsGive,AppendMoney,CalculateMode,Remark";
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int ProductOptionItems_GetMaxId()
		{
			return DB.GetMaxID("id", string.Format("{0}ProductOptionItems",sPre)); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool ProductOptionItems_Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("select count(1) from {0}ProductOptionItems",sPre);
			strSql.Append(" where id=?id ");
			MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32,4)};
			parameters[0].Value = id;

			return DB.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int ProductOptionItems_Add(Entity.ProductOptionItems model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("insert into {0}ProductOptionItems(",sPre);
            strSql.Append("ProductOptionID,ItemName,IsGive,AppendMoney,CalculateMode,Remark)");
			strSql.Append(" values (");
            strSql.Append("?ProductOptionID,?ItemName,?IsGive,?AppendMoney,?CalculateMode,?Remark)");
			strSql.Append(";select @@IDENTITY");
			MySqlParameter[] parameters = {
					new MySqlParameter("?ProductOptionID", MySqlDbType.Int32,4),
					new MySqlParameter("?ItemName", MySqlDbType.VarChar,100),
					new MySqlParameter("?IsGive", MySqlDbType.Bit,1),
					new MySqlParameter("?AppendMoney", MySqlDbType.Decimal,9),
					new MySqlParameter("?CalculateMode", MySqlDbType.Int32,4),
					new MySqlParameter("?Remark", MySqlDbType.VarChar,300)};
			parameters[0].Value = model.ProductOptionID;
			parameters[1].Value = model.ItemName;
            parameters[2].Value = model.IsGive;
			parameters[3].Value = model.AppendMoney;
			parameters[4].Value = model.CalculateMode;
			parameters[5].Value = model.Remark;

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
        public int ProductOptionItems_Add(Entity.ProductOptionItems model, MySqlTransaction Trans)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("insert into {0}ProductOptionItems(", sPre);
            strSql.Append("ProductOptionID,ItemName,IsGive,AppendMoney,CalculateMode,Remark)");
            strSql.Append(" values (");
            strSql.Append("?ProductOptionID,?ItemName,?IsGive,?AppendMoney,?CalculateMode,?Remark)");
            strSql.Append(";select @@IDENTITY");
            MySqlParameter[] parameters = {
					new MySqlParameter("?ProductOptionID", MySqlDbType.Int32,4),
					new MySqlParameter("?ItemName", MySqlDbType.VarChar,100),
					new MySqlParameter("?IsGive", MySqlDbType.Bit,1),
					new MySqlParameter("?AppendMoney", MySqlDbType.Decimal,9),
					new MySqlParameter("?CalculateMode", MySqlDbType.Int32,4),
					new MySqlParameter("?Remark", MySqlDbType.VarChar,300)};
            parameters[0].Value = model.ProductOptionID;
            parameters[1].Value = model.ItemName;
            parameters[2].Value = model.IsGive;
            parameters[3].Value = model.AppendMoney;
            parameters[4].Value = model.CalculateMode;
            parameters[5].Value = model.Remark;

            object obj = DB.ExecuteScalar(Trans,CommandType.Text, strSql.ToString(), parameters);
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
		public void ProductOptionItems_Update(Entity.ProductOptionItems model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("update {0}ProductOptionItems set ",sPre);
			strSql.Append("ProductOptionID=?ProductOptionID,");
			strSql.Append("ItemName=?ItemName,");
            strSql.Append("IsGive=?IsGive,");
			
			strSql.Append("AppendMoney=?AppendMoney,");
			strSql.Append("CalculateMode=?CalculateMode,");
			strSql.Append("Remark=?Remark");
			strSql.Append(" where id=?id ");
			MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32,4),
					new MySqlParameter("?ProductOptionID", MySqlDbType.Int32,4),
					new MySqlParameter("?ItemName", MySqlDbType.VarChar,100),
					new MySqlParameter("?IsGive", MySqlDbType.Bit,1),
					new MySqlParameter("?AppendMoney", MySqlDbType.Decimal,9),
					new MySqlParameter("?CalculateMode", MySqlDbType.Int32,4),
					new MySqlParameter("?Remark", MySqlDbType.VarChar,300)};
			parameters[0].Value = model.id;
			parameters[1].Value = model.ProductOptionID;
			parameters[2].Value = model.ItemName;
            parameters[3].Value = model.IsGive;
			parameters[4].Value = model.AppendMoney;
			parameters[5].Value = model.CalculateMode;
			parameters[6].Value = model.Remark;

			DB.ExecuteNonQuery(CommandType.Text,strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void ProductOptionItems_Delete(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("delete from {0}ProductOptionItems ",sPre);
			strSql.Append(" where id=?id ");
			MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32,4)};
			parameters[0].Value = id;

			DB.ExecuteNonQuery(CommandType.Text,strSql.ToString(),parameters);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Entity.ProductOptionItems ProductOptionItems_GetEntity(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("select "+ sFieldProductOptionItems +"  from {0}ProductOptionItems ",sPre);
			strSql.Append(" where id=?id ");
			MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32,4)};
			parameters[0].Value = id;
			Entity.ProductOptionItems model=null;
			using (IDataReader dataReader = DB.ExecuteReader(CommandType.Text, strSql.ToString(),parameters))
			{
				if(dataReader.Read())
				{
					model= ProductOptionItems_ReaderBind(dataReader);
				}
			}
			return model;
		}
		/// <summary>
		/// 获取统计
		/// </summary>
		public int ProductOptionItems_GetCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("select count(*)  from {0}ProductOptionItems ",sPre);
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
		public DataSet ProductOptionItems_GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			
			strSql.Append(sFieldProductOptionItems );
			strSql.AppendFormat(" FROM {0}ProductOptionItems ",sPre);
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
		public List<Entity.ProductOptionItems> ProductOptionItems_GetListArray(string strWhere)
		{
			return ProductOptionItems_GetListArray(0,strWhere,""); 
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public List<Entity.ProductOptionItems> ProductOptionItems_GetListArray(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			
			strSql.Append(sFieldProductOptionItems );
			strSql.AppendFormat(" FROM {0}ProductOptionItems ",sPre);
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
				strSql.Append(" limts "+Top.ToString());
			}
			List<Entity.ProductOptionItems> list = new List<Entity.ProductOptionItems>();
			using (IDataReader dataReader = DB.ExecuteReader(CommandType.Text, strSql.ToString()))
			{
				while (dataReader.Read())
				{
					list.Add(ProductOptionItems_ReaderBind(dataReader));
				}
			}
			return list;
		}


		/// <summary>
		/// 获得分页数据
		/// </summary>
		public List<Entity.ProductOptionItems> ProductOptionItems_GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby,out int RecordCount)
		{
            StringBuilder sbSql = new StringBuilder();
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                sbSql.Append(" where ");
                sbSql.AppendFormat(strWhere);
            }
            RecordCount = ProductOptionItems_GetCount(sbSql.ToString());
            List<Entity.ProductOptionItems> list = new List<Entity.ProductOptionItems>();
            string strSql = SplitPages.GetSplitPagesMySql(DB, "ProductOptionItems", PageSize, PageIndex, Fileds, "id", oderby, sbSql.ToString(), sPre);
            using (IDataReader dataReader = DB.ExecuteReader(CommandType.Text, strSql))
            {
                while (dataReader.Read())
                {
                    list.Add(ProductOptionItems_ReaderBind(dataReader));
                }
            }
            return list;
		}


		/// <summary>
		/// 对象实体绑定数据
		/// </summary>
		public Entity.ProductOptionItems ProductOptionItems_ReaderBind(IDataReader dataReader)
		{
			Entity.ProductOptionItems model=new Entity.ProductOptionItems();
			object ojb; 
			ojb = dataReader["id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.id=(int)ojb;
			}
			ojb = dataReader["ProductOptionID"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.ProductOptionID=(int)ojb;
			}
			model.ItemName=dataReader["ItemName"].ToString();
            ojb = dataReader["IsGive"];
			if(ojb != null && ojb != DBNull.Value)
			{
                if (ojb.ToString().Equals("1") || ojb.ToString().Equals("true"))
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
            ojb = dataReader["Remark"];
		    if (ojb != null && ojb != DBNull.Value)
		    {
                model.Remark = dataReader["Remark"].ToString();
		    }
			return model;
		}
        public Entity.ProductOptionItems ProductOptionItems_ReaderBind2(IDataReader dataReader)
        {
            Entity.ProductOptionItems model = new Entity.ProductOptionItems();
            object ojb;
            ojb = dataReader["id"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.id = (int)ojb;
            }
            ojb = dataReader["ProductOptionID"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.ProductOptionID = (int)ojb;
            }
            model.ItemName = dataReader["ItemName"].ToString();
            ojb = dataReader["IsGive"];
            if (ojb != null && ojb != DBNull.Value)
            {
                if (ojb.ToString().Equals("1") || ojb.ToString().Equals("true"))
                {
                    model.IsGive = true;
                }
                else
                {
                    model.IsGive = false;
                }
            }

            ojb = dataReader["AppendMoney"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.AppendMoney = (decimal)ojb;
            }
            ojb = dataReader["CalculateMode"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.CalculateMode = (int)ojb;
            }
            //ojb = dataReader["Remark"];
            //if (ojb != null && ojb != DBNull.Value)
            //{
            //    model.Remark = dataReader["Remark"].ToString();
            //}
            ojb = dataReader["OptionName"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.OptionName = dataReader["OptionName"].ToString();
            }
            return model;
        }
		#endregion  成员方法


       public List<Entity.ProductOptionItems> ProductOptionItems_GetListArrayInIDs(string IDs)
       {
           StringBuilder strSql = new StringBuilder();
           strSql.Append("SELECT a.id, a.ItemName,a.AppendMoney,a.CalculateMode,a.ProductOptionID,a.IsGive,b.OptionName  ");
           strSql.AppendFormat("FROM {0}productoptionitems a,ebshop_productoptions b ", sPre);
           strSql.AppendFormat(" WHERE a.ProductOptionID = b.id and a.id in({0}) ", IDs);
          
           List<Entity.ProductOptionItems> list = new List<Entity.ProductOptionItems>();
           using (IDataReader dataReader = DB.ExecuteReader(CommandType.Text, strSql.ToString()))
           {
               while (dataReader.Read())
               {
                   list.Add(ProductOptionItems_ReaderBind2(dataReader));
               }
           }
           return list;
       }

       public List<Entity.ProductOptionItems> ProductOptionItems_GetListArrayByProductID(int ProductID)
       {
           StringBuilder strSql = new StringBuilder();
           strSql.Append("SELECT a.id,a.AppendMoney,a.CalculateMode,a.IsGive,a.ItemName,a.ProductOptionID,a.Remark,b.OptionName   ");
           strSql.AppendFormat("FROM {0}productoptionitems a, {0}productoptions b  ", sPre);
           strSql.AppendFormat(" where a.ProductOptionID=b.id and b.ProductID={0} ", ProductID);

           List<Entity.ProductOptionItems> list = new List<Entity.ProductOptionItems>();
           using (IDataReader dataReader = DB.ExecuteReader(CommandType.Text, strSql.ToString()))
           {
               while (dataReader.Read())
               {
                   list.Add(ProductOptionItems_ReaderBind2(dataReader));
               }
           }
           return list;
       }



	}
}

