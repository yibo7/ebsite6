using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using EbSite.Base.DataProfile;
namespace EbSite.Modules.Shop.ModuleCore.DAL.SqlServer
{
	/// <summary>
	/// 数据访问类Shop。
	/// </summary>
	public partial class Shop
	{
        private string sFieldProductsImg = "ID,ProductName,ProductID,BigImg,SmallImg,Title";
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int ProductsImg_GetMaxId()
		{
			return DB.GetMaxID("ID", string.Format("{0}ProductsImg",sPre)); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool ProductsImg_Exists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("select count(1) from {0}ProductsImg",sPre);
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = ID;

			return DB.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int ProductsImg_Add(Entity.ProductsImg model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("insert into {0}ProductsImg(",sPre);
            strSql.Append("ProductName,ProductID,BigImg,SmallImg,Title)");
			strSql.Append(" values (");
            strSql.Append("@ProductName,@ProductID,@BigImg,@SmallImg,@Title)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					
					new SqlParameter("@ProductName", SqlDbType.VarChar,100),
					new SqlParameter("@ProductID", SqlDbType.Int,4),
					new SqlParameter("@BigImg", SqlDbType.VarChar,250),
					new SqlParameter("@SmallImg", SqlDbType.VarChar,250),
                    new SqlParameter("@Title", SqlDbType.VarChar,250)             };
			
			parameters[0].Value = model.ProductName;
			parameters[1].Value = model.ProductID;
			parameters[2].Value = model.BigImg;
			parameters[3].Value = model.SmallImg;
		    parameters[4].Value = model.Title;

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
		public void ProductsImg_Update(Entity.ProductsImg model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("update {0}ProductsImg set ",sPre);
			strSql.Append("ProductName=@ProductName,");
			strSql.Append("ProductID=@ProductID,");
			strSql.Append("BigImg=@BigImg,");
			strSql.Append("SmallImg=@SmallImg,");
            strSql.Append("Title=@Title");
            
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@ProductName", SqlDbType.VarChar,100),
					new SqlParameter("@ProductID", SqlDbType.Int,4),
					new SqlParameter("@BigImg", SqlDbType.VarChar,250),
					new SqlParameter("@SmallImg", SqlDbType.VarChar,250),
                    new SqlParameter("@Title", SqlDbType.VarChar,250)
                                        };
			parameters[0].Value = model.id;
			parameters[1].Value = model.ProductName;
			parameters[2].Value = model.ProductID;
			parameters[3].Value = model.BigImg;
			parameters[4].Value = model.SmallImg;
		    parameters[5].Value = model.Title;

			DB.ExecuteNonQuery(CommandType.Text,strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void ProductsImg_Delete(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("delete from {0}ProductsImg ",sPre);
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = ID;

			DB.ExecuteNonQuery(CommandType.Text,strSql.ToString(),parameters);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Entity.ProductsImg ProductsImg_GetEntity(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("select "+ sFieldProductsImg +"  from {0}ProductsImg ",sPre);
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = ID;
			Entity.ProductsImg model=null;
			using (IDataReader dataReader = DB.ExecuteReader(CommandType.Text, strSql.ToString(),parameters))
			{
				if(dataReader.Read())
				{
					model= ProductsImg_ReaderBind(dataReader);
				}
			}
			return model;
		}
		/// <summary>
		/// 获取统计
		/// </summary>
		public int ProductsImg_GetCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("select count(*)  from {0}ProductsImg ",sPre);
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
		public DataSet ProductsImg_GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(sFieldProductsImg );
			strSql.AppendFormat(" FROM {0}ProductsImg ",sPre);
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			if(filedOrder.Trim()!="")
			{
				strSql.Append(" order by  "+filedOrder);
			}
			return DB.ExecuteDataset(CommandType.Text, strSql.ToString());
		}

		/// <summary>
		/// 获得数据列表（比DataSet效率高，推荐使用）
		/// </summary>
		public List<Entity.ProductsImg> ProductsImg_GetListArray(string strWhere)
		{
			return ProductsImg_GetListArray(0,strWhere,""); 
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public List<Entity.ProductsImg> ProductsImg_GetListArray(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(sFieldProductsImg );
			strSql.AppendFormat(" FROM {0}ProductsImg ",sPre);
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			if(filedOrder.Trim()!="")
			{
				strSql.Append(" order by  "+filedOrder);
			}
			List<Entity.ProductsImg> list = new List<Entity.ProductsImg>();
			using (IDataReader dataReader = DB.ExecuteReader(CommandType.Text, strSql.ToString()))
			{
				while (dataReader.Read())
				{
					list.Add(ProductsImg_ReaderBind(dataReader));
				}
			}
			return list;
		}


		/// <summary>
		/// 获得分页数据
		/// </summary>
		public List<Entity.ProductsImg> ProductsImg_GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby,out int RecordCount)
		{
			List<Entity.ProductsImg> list = new List<Entity.ProductsImg>();
			using (IDataReader dataReader = SplitPages.GetListPages_SP(DB,"ProductsImg", PageSize, PageIndex, Fileds, "ID", oderby, strWhere, out RecordCount,sPre))
			{
				while (dataReader.Read())
				{
					list.Add(ProductsImg_ReaderBind(dataReader));
				}
			}
			return list;
		}


		/// <summary>
		/// 对象实体绑定数据
		/// </summary>
		public Entity.ProductsImg ProductsImg_ReaderBind(IDataReader dataReader)
		{
			Entity.ProductsImg model=new Entity.ProductsImg();
			object ojb; 
			ojb = dataReader["ID"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.id=(int)ojb;
			}
			model.ProductName=dataReader["ProductName"].ToString();
			ojb = dataReader["ProductID"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.ProductID=(int)ojb;
			}
			model.BigImg=dataReader["BigImg"].ToString();
			model.SmallImg=dataReader["SmallImg"].ToString();
            model.Title = dataReader["Title"].ToString();
            
			return model;
		}

		#endregion  成员方法
	}
}

