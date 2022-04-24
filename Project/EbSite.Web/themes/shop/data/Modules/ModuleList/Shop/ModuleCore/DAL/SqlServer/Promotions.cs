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
		private string sFieldPromotions = "id,TitleName,PromoteType,Description";
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int Promotions_GetMaxId()
		{
			return DB.GetMaxID("id", string.Format("{0}Promotions",sPre)); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Promotions_Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("select count(1) from {0}Promotions",sPre);
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id",SqlDbType.Int,4)};
			parameters[0].Value = id;

			return DB.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Promotions_Add(Entity.Promotions model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("insert into {0}Promotions(",sPre);
			strSql.Append("TitleName,PromoteType,Description)");
			strSql.Append(" values (");
			strSql.Append("@TitleName,@PromoteType,@Description)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@TitleName", SqlDbType.VarChar,100),
					new SqlParameter("@PromoteType",SqlDbType.Int,4),
					new SqlParameter("@Description", SqlDbType.VarChar,500)};
			parameters[0].Value = model.TitleName;
			parameters[1].Value = model.PromoteType;
			parameters[2].Value = model.Description;

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
		public void Promotions_Update(Entity.Promotions model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("update {0}Promotions set ",sPre);
			strSql.Append("TitleName=@TitleName,");
			strSql.Append("PromoteType=@PromoteType,");
			strSql.Append("Description=@Description");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id",SqlDbType.Int,4),
					new SqlParameter("@TitleName", SqlDbType.VarChar,100),
					new SqlParameter("@PromoteType",SqlDbType.Int,4),
					new SqlParameter("@Description", SqlDbType.VarChar,500)};
			parameters[0].Value = model.id;
			parameters[1].Value = model.TitleName;
			parameters[2].Value = model.PromoteType;
			parameters[3].Value = model.Description;

			DB.ExecuteNonQuery(CommandType.Text,strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Promotions_Delete(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("delete from {0}Promotions ",sPre);
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id",SqlDbType.Int,4)};
			parameters[0].Value = id;

			DB.ExecuteNonQuery(CommandType.Text,strSql.ToString(),parameters);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Entity.Promotions Promotions_GetEntity(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("select "+ sFieldPromotions +"  from {0}Promotions ",sPre);
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id",SqlDbType.Int,4)};
			parameters[0].Value = id;
			Entity.Promotions model=null;
			using (IDataReader dataReader = DB.ExecuteReader(CommandType.Text, strSql.ToString(),parameters))
			{
				if(dataReader.Read())
				{
					model= Promotions_ReaderBind(dataReader);
				}
			}
			return model;
		}
		/// <summary>
		/// 获取统计
		/// </summary>
		public int Promotions_GetCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("select count(*)  from {0}Promotions ",sPre);
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
		public DataSet Promotions_GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(sFieldPromotions );
			strSql.AppendFormat(" FROM {0}Promotions ",sPre);
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
		public List<Entity.Promotions> Promotions_GetListArray(string strWhere)
		{
			return Promotions_GetListArray(0,strWhere,""); 
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public List<Entity.Promotions> Promotions_GetListArray(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(sFieldPromotions );
			strSql.AppendFormat(" FROM {0}Promotions ",sPre);
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			if(filedOrder.Trim()!="")
			{
				strSql.Append(" order by  "+filedOrder);
			}
			List<Entity.Promotions> list = new List<Entity.Promotions>();
			using (IDataReader dataReader = DB.ExecuteReader(CommandType.Text, strSql.ToString()))
			{
				while (dataReader.Read())
				{
					list.Add(Promotions_ReaderBind(dataReader));
				}
			}
			return list;
		}


		/// <summary>
		/// 获得分页数据
		/// </summary>
		public List<Entity.Promotions> Promotions_GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby,out int RecordCount)
		{
			List<Entity.Promotions> list = new List<Entity.Promotions>();
			using (IDataReader dataReader = SplitPages.GetListPages_SP(DB,"Promotions", PageSize, PageIndex, Fileds, "id", oderby, strWhere, out RecordCount,sPre))
			{
				while (dataReader.Read())
				{
					list.Add(Promotions_ReaderBind(dataReader));
				}
			}
			return list;
		}

		/// <summary>
		/// 对象实体绑定数据
		/// </summary>
		public Entity.Promotions Promotions_ReaderBind(IDataReader dataReader)
		{
			Entity.Promotions model=new Entity.Promotions();
			object ojb; 
			ojb = dataReader["id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.id=(int)ojb;
			}
			model.TitleName=dataReader["TitleName"].ToString();
			ojb = dataReader["PromoteType"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.PromoteType=(int)ojb;
			}
			model.Description=dataReader["Description"].ToString();
			return model;
		}

		#endregion  成员方法

        /// <summary>
        /// 删除相关联的数据
        /// </summary>
        public void Promotions_DeleteByType(int id, ModuleCore.BLL.EPromotionsType pType)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("delete from {0}Promotions ", sPre);
            strSql.Append(" where id=@id; ");
            string tbName = "";
            switch (pType)
            {
                case BLL.EPromotionsType.满额打折:
                    tbName = "promotionfullpricecut";
                    break;
                case BLL.EPromotionsType.买几送几:
                    tbName = "promotionfullnumgive";
                    break;
                case BLL.EPromotionsType.满额免费用:
                    tbName = "promotionpricefree";
                    break;
                case BLL.EPromotionsType.批发打折:
                    tbName = "promotionwholesale";
                    break;
            }

            if (!string.IsNullOrEmpty(tbName))
            {
                strSql.AppendFormat("delete from {0}{1} where promotionsid=@id;", sPre, tbName);
            }
            strSql.AppendFormat("delete from {0}promotionsrole where promotionsid=@id;", sPre);
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;

            DB.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }

        public void GetActivityInfo(int RoleID, int Quantity,int ProductId, out Entity.PromotionFullNumGiveWithName pfgwn, out Entity.PromotionWholesaleWithName pwwn)
        {
            pfgwn = new Entity.PromotionFullNumGiveWithName();
            pwwn = new Entity.PromotionWholesaleWithName();
    

        }

        public void GetActivityInfo(int RoleID, decimal Price, out Entity.PromotionFullPriceCutWithName pfpwn, out Entity.PromotionPriceFreeWithName ppwn)
        {
            pfpwn = new Entity.PromotionFullPriceCutWithName();
            ppwn = new Entity.PromotionPriceFreeWithName();
        }
	}
}

