using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using EbSite.Base.DataProfile;
using EbSite.Modules.Shop.ModuleCore.Entity;
using MySql.Data.MySqlClient;
namespace EbSite.Modules.Shop.ModuleCore.DAL.MySql
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
			strSql.Append(" where id=?id ");
			MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32,4)};
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
			strSql.Append("?TitleName,?PromoteType,?Description)");
			strSql.Append(";select @@IDENTITY");
			MySqlParameter[] parameters = {
					new MySqlParameter("?TitleName", MySqlDbType.VarChar,100),
					new MySqlParameter("?PromoteType", MySqlDbType.Int32,4),
					new MySqlParameter("?Description", MySqlDbType.VarChar,500)};
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
			strSql.Append("TitleName=?TitleName,");
			strSql.Append("PromoteType=?PromoteType,");
			strSql.Append("Description=?Description");
			strSql.Append(" where id=?id ");
			MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32,4),
					new MySqlParameter("?TitleName", MySqlDbType.VarChar,100),
					new MySqlParameter("?PromoteType", MySqlDbType.Int32,4),
					new MySqlParameter("?Description", MySqlDbType.VarChar,500)};
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
			strSql.Append(" where id=?id ");
			MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32,4)};
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
			strSql.Append(" where id=?id ");
			MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32,4)};
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
            if(Top>0)
			{
				strSql.Append(" limit "+Top.ToString());
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
            if(Top>0)
			{
				strSql.Append(" limit "+Top.ToString());
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
            StringBuilder sbSql = new StringBuilder();
            //if (!string.IsNullOrEmpty(strWhere.Trim()))
            //{
            //    sbSql.Append(" where ");
                sbSql.AppendFormat(strWhere);
            //}
            RecordCount = Promotions_GetCount(sbSql.ToString());
            List<Entity.Promotions> list = new List<Entity.Promotions>();
            string strSql = SplitPages.GetSplitPagesMySql(DB, "Promotions", PageSize, PageIndex, Fileds, "id", oderby, sbSql.ToString(), sPre);
            using (IDataReader dataReader = DB.ExecuteReader(CommandType.Text, strSql))
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

        #region 自定义方法

        /// <summary>
        /// 删除相关联的数据
        /// </summary>
        public void Promotions_DeleteByType(int id, ModuleCore.BLL.EPromotionsType pType)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("delete from {0}Promotions ", sPre);
            strSql.Append(" where id=?id; ");
            string tbName="";
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
                strSql.AppendFormat("delete from {0}{1} where promotionsid=?id;", sPre, tbName);
            }
            strSql.AppendFormat("delete from {0}promotionsrole where promotionsid=?id;", sPre);
            MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32,4)};
            parameters[0].Value = id;

            DB.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }

        public void GetActivityInfo(int RoleID, int Quantity,long ProductId, out Entity.PromotionFullNumGiveWithName pfgwn, out Entity.PromotionWholesaleWithName pwwn)
        {
            pfgwn = new PromotionFullNumGiveWithName();
            pwwn = new PromotionWholesaleWithName();
            MySqlParameter[] parameters = new MySqlParameter[] { new MySqlParameter("?p_Quantity", MySqlDbType.Int32, 4), new MySqlParameter("?p_ProductId", MySqlDbType.Int32), new MySqlParameter("?p_GradeId", MySqlDbType.Int32) };
            parameters[0].Value = Quantity;
            parameters[1].Value = ProductId;
            parameters[2].Value = RoleID;
            using (DataSet set = DB.ExecuteDataset(CommandType.StoredProcedure, string.Format("{0}GetPromotionsInfo", sPre), parameters))
            {
                if (set.Tables.Count > 0)
                {
                    DataTable dtpfpwn = set.Tables[0];
                    if (dtpfpwn.Rows.Count>0)
                    {
                        pfgwn.PromotionsId = (int)dtpfpwn.Rows[0]["id"];
                        pfgwn.PromotionsName = dtpfpwn.Rows[0]["TitleName"].ToString();
                        pfgwn.BuyQuantity = (int)dtpfpwn.Rows[0]["BuyQuantity"];
                        pfgwn.GiveQuantity = (int)dtpfpwn.Rows[0]["GiveQuantity"];
                    }
                   
                    
                    if (set.Tables.Count == 2)
                    {
                        
                        DataTable dtpppwn = set.Tables[1];
                        if (dtpppwn.Rows.Count>0)
                        {
                            pwwn.PromotionsId = (int)dtpppwn.Rows[0]["id"];
                            pwwn.PromotionsName = dtpppwn.Rows[0]["TitleName"].ToString();
                            pwwn.DiscountValue = (int)dtpppwn.Rows[0]["DiscountValue"];
                        }
                       
                    }
                }
            }

        }

	    public void GetActivityInfo(int RoleID,decimal Price,out Entity.PromotionFullPriceCutWithName pfpwn,out Entity.PromotionPriceFreeWithName ppwn )
        {
            pfpwn = new PromotionFullPriceCutWithName();
            ppwn = new PromotionPriceFreeWithName();
            MySqlParameter[] parameters = new MySqlParameter[] { new MySqlParameter("?p_RoleID", MySqlDbType.Int32, 4), new MySqlParameter("?p_Amount", MySqlDbType.Decimal) };
            parameters[0].Value = RoleID;
            parameters[1].Value = Price;
            using (DataSet set = DB.ExecuteDataset(CommandType.StoredProcedure, string.Format("{0}GetFullActivityInfo", sPre), parameters))
            {
               if(set.Tables.Count>0)
               {
                   DataTable dtpfpwn = set.Tables[0];
                   if (dtpfpwn.Rows.Count>0)
                   {
                       pfpwn.PromotionsId = (int)dtpfpwn.Rows[0]["id"];
                       pfpwn.PromotionsName = dtpfpwn.Rows[0]["TitleName"].ToString();
                       pfpwn.ValueType = (int)dtpfpwn.Rows[0]["ValueType"];
                       pfpwn.Amount = (decimal)dtpfpwn.Rows[0]["Amount"];
                       pfpwn.DiscountValue = (int)dtpfpwn.Rows[0]["DiscountValue"];
                   }
                   
                   if(set.Tables.Count==2)
                   {
                       DataTable dtpppwn = set.Tables[1];
                       if (dtpppwn.Rows.Count>0)
                       {
                           ppwn.PromotionsId = (int)dtpppwn.Rows[0]["id"];
                           ppwn.PromotionsName = dtpppwn.Rows[0]["TitleName"].ToString();
                           ppwn.PayFee = dtpppwn.Rows[0]["PayFee"].ToString() == "0" ? false : true;
                           ppwn.ServiceFree = dtpppwn.Rows[0]["ServiceFree"].ToString() == "0" ? false : true;
                           ppwn.FreightFree = dtpppwn.Rows[0]["FreightFree"].ToString() == "0" ? false : true;
                           ppwn.Amount = (decimal)dtpppwn.Rows[0]["Amount"];
                       }
                       

                   }
               }
            }
        }
        public List<Entity.Activities> GetShowList(int PageIndex, int PageSize,int AcivitieID,  string oderby, out int RecordCount)
        {
            StringBuilder sbSql = new StringBuilder();

            if (PageIndex > 0)
            {
                PageIndex--;
            }
            if (string.IsNullOrEmpty(oderby))
            {
                oderby = "-c.id";   
            }
            string sWhere = string.Empty;
            if(AcivitieID>0)
            {
                sWhere = string.Concat(" and c.id=", AcivitieID);
            }
            int numStart = PageIndex * PageSize;
            RecordCount = Promotions_GetCount(sbSql.ToString());
            List<Entity.Activities> list = new List<Entity.Activities>();
            string strSql = string.Format("SELECT a.id, a.NewsTitle,a.classid,a.SmallPic,a.Annex2,a.Annex16,c.TitleName,c.id as ActID FROM {0}newscontent as a,{1}promotionproduct as b,{1}Promotions as c WHERE a.ID = b.ProductID and b.PromotionsID = c.id {5} ORDER BY {2} LIMIT {3},{4}",
                EbSite.Base.Host.Instance.GetSysTablePrefix,
                sPre,
               oderby,
                numStart,
                PageSize,
                sWhere
                );
            using (IDataReader dataReader = DB.ExecuteReader(CommandType.Text, strSql))
            {
                while (dataReader.Read())
                {
                    Entity.Activities model = new Entity.Activities();
                    object ojb;
                    ojb = dataReader["id"];
                    if (ojb != null && ojb != DBNull.Value)
                    {
                        model.ID = (int)ojb;
                    }
                    ojb = dataReader["ClassID"];
                    if (ojb != null && ojb != DBNull.Value)
                    {
                        model.ClassID = (int)ojb;
                    }
                    model.NewsTitle = dataReader["NewsTitle"].ToString();
                    model.SmallPic = dataReader["SmallPic"].ToString();
                    model.ActName = dataReader["TitleName"].ToString();
                    ojb = dataReader["Annex2"];
                    if (ojb != null && ojb != DBNull.Value)
                    {
                        model.MarketPrice = decimal.Parse(ojb.ToString());
                    }
                    ojb = dataReader["Annex16"];
                    if (ojb != null && ojb != DBNull.Value)
                    {
                        model.Price = decimal.Parse(ojb.ToString());
                    }
                    ojb = dataReader["ActID"];
                    if (ojb != null && ojb != DBNull.Value)
                    {
                        model.ActID = (int)ojb;
                    }
                    list.Add(model);
                }
            }
            return list;
        }
        #endregion 自定义方法
	}
}

