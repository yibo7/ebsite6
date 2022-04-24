using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using EbSite.Base.DataProfile;
namespace EbSite.Modules.Shop.ModuleCore.DAL.SqlServer
{
	/// <summary>
	/// 数据访问类369369。
	/// </summary>
    public partial class Shop
	{
        private string sFieldP_BestGroup = "id,ProductID,GoodsID,OrderiD,GoodsName,GoodsAvatarSmall,TypeID";
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int P_BestGroup_GetMaxId()
		{
			return DB.GetMaxID("id", string.Format("{0}P_BestGroup",sPre)); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool P_BestGroup_Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("select count(1) from {0}P_BestGroup",sPre);
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;

			return DB.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int P_BestGroup_Add(Entity.P_BestGroup model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("insert into {0}P_BestGroup(",sPre);
            strSql.Append("ProductID,GoodsID,OrderiD,GoodsName,GoodsAvatarSmall,TypeID)");
			strSql.Append(" values (");
            strSql.Append("@ProductID,@GoodsID,@OrderiD,@GoodsName,@GoodsAvatarSmall,@TypeID)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@ProductID", SqlDbType.Int,4),
					new SqlParameter("@GoodsID", SqlDbType.Int,4),
					new SqlParameter("@OrderiD", SqlDbType.Int,4),
					new SqlParameter("@GoodsName", SqlDbType.NVarChar,200),
					new SqlParameter("@GoodsAvatarSmall", SqlDbType.NVarChar,200),
                    new SqlParameter("@TypeID", SqlDbType.Int,4)};
			parameters[0].Value = model.ProductID;
			parameters[1].Value = model.GoodsID;
			parameters[2].Value = model.OrderiD;
			parameters[3].Value = model.GoodsName;
			parameters[4].Value = model.GoodsAvatarSmall;
            parameters[5].Value = model.TypeID;

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
		public void P_BestGroup_Update(Entity.P_BestGroup model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("update {0}P_BestGroup set ",sPre);
			strSql.Append("ProductID=@ProductID,");
			strSql.Append("GoodsID=@GoodsID,");
			strSql.Append("OrderiD=@OrderiD,");
			strSql.Append("GoodsName=@GoodsName,");
			strSql.Append("GoodsAvatarSmall=@GoodsAvatarSmall,");
            strSql.Append("TypeID=@TypeID");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@ProductID", SqlDbType.Int,4),
					new SqlParameter("@GoodsID", SqlDbType.Int,4),
					new SqlParameter("@OrderiD", SqlDbType.Int,4),
					new SqlParameter("@GoodsName", SqlDbType.NVarChar,200),
					new SqlParameter("@GoodsAvatarSmall", SqlDbType.NVarChar,200),
                    new SqlParameter("@TypeID", SqlDbType.Int,4)};
			parameters[0].Value = model.id;
			parameters[1].Value = model.ProductID;
			parameters[2].Value = model.GoodsID;
			parameters[3].Value = model.OrderiD;
			parameters[4].Value = model.GoodsName;
			parameters[5].Value = model.GoodsAvatarSmall;
            parameters[6].Value = model.TypeID;

			DB.ExecuteNonQuery(CommandType.Text,strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void P_BestGroup_Delete(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("delete from {0}P_BestGroup ",sPre);
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;

			DB.ExecuteNonQuery(CommandType.Text,strSql.ToString(),parameters);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Entity.P_BestGroup P_BestGroup_GetEntity(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("select "+ sFieldP_BestGroup +"  from {0}P_BestGroup ",sPre);
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;
			Entity.P_BestGroup model=null;
			using (IDataReader dataReader = DB.ExecuteReader(CommandType.Text, strSql.ToString(),parameters))
			{
				if(dataReader.Read())
				{
					model= P_BestGroup_ReaderBind(dataReader);
				}
			}
			return model;
		}
		/// <summary>
		/// 获取统计
		/// </summary>
		public int P_BestGroup_GetCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("select count(*)  from {0}P_BestGroup ",sPre);
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
		public DataSet P_BestGroup_GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(sFieldP_BestGroup );
			strSql.AppendFormat(" FROM {0}P_BestGroup ",sPre);
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
		public List<Entity.P_BestGroup> P_BestGroup_GetListArray(string strWhere)
		{
			return P_BestGroup_GetListArray(0,strWhere,""); 
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public List<Entity.P_BestGroup> P_BestGroup_GetListArray(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(sFieldP_BestGroup );
			strSql.AppendFormat(" FROM {0}P_BestGroup ",sPre);
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			if(filedOrder.Trim()!="")
			{
				strSql.Append(" order by  "+filedOrder);
			}
			List<Entity.P_BestGroup> list = new List<Entity.P_BestGroup>();
			using (IDataReader dataReader = DB.ExecuteReader(CommandType.Text, strSql.ToString()))
			{
				while (dataReader.Read())
				{
					list.Add(P_BestGroup_ReaderBind(dataReader));
				}
			}
			return list;
		}


		/// <summary>
		/// 获得分页数据
		/// </summary>
		public List<Entity.P_BestGroup> P_BestGroup_GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby,out int RecordCount)
		{
			List<Entity.P_BestGroup> list = new List<Entity.P_BestGroup>();
			using (IDataReader dataReader = SplitPages.GetListPages_SP(DB,"P_BestGroup", PageSize, PageIndex, Fileds, "id", oderby, strWhere, out RecordCount,sPre))
			{
				while (dataReader.Read())
				{
					list.Add(P_BestGroup_ReaderBind(dataReader));
				}
			}
			return list;
		}


		/// <summary>
		/// 对象实体绑定数据
		/// </summary>
		public Entity.P_BestGroup P_BestGroup_ReaderBind(IDataReader dataReader)
		{
			Entity.P_BestGroup model=new Entity.P_BestGroup();
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
			ojb = dataReader["GoodsID"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.GoodsID=(int)ojb;
			}
			ojb = dataReader["OrderiD"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.OrderiD=(int)ojb;
			}
			model.GoodsName=dataReader["GoodsName"].ToString();
			model.GoodsAvatarSmall=dataReader["GoodsAvatarSmall"].ToString();
            ojb = dataReader["TypeID"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.TypeID = (int)ojb;
            }
			return model;
		}

		#endregion  成员方法
	}
}

