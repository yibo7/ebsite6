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
        private string sFieldNormRelationProduct = "ID,PNumber,Stocks,SalePrice,CostPrice,MarketPrice,Weight,ProductID,NormsValues";
        #region  成员方法

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int NormRelationProduct_GetMaxId()
        {
            return DB.GetMaxID("ID", string.Format("{0}NormRelationProduct", sPre));
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool NormRelationProduct_Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select count(1) from {0}NormRelationProduct", sPre);
            strSql.Append(" where ID=?ID ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?ID", MySqlDbType.Int32,4)};
            parameters[0].Value = ID;

            return DB.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int NormRelationProduct_Add(Entity.NormRelationProduct model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("insert into {0}NormRelationProduct(", sPre);
            strSql.Append("PNumber,Stocks,SalePrice,CostPrice,MarketPrice,Weight,ProductID,NormsValues)");
            strSql.Append(" values (");
            strSql.Append("?PNumber,?Stocks,?SalePrice,?CostPrice,?MarketPrice,?Weight,?ProductID,?NormsValues)");
            strSql.Append(";select @@IDENTITY");
            MySqlParameter[] parameters = {
					
					new MySqlParameter("?PNumber", MySqlDbType.VarChar,30),
					new MySqlParameter("?Stocks", MySqlDbType.Int32,4),
					new MySqlParameter("?SalePrice", MySqlDbType.Decimal,9),
					new MySqlParameter("?CostPrice", MySqlDbType.Decimal,9),
					new MySqlParameter("?MarketPrice", MySqlDbType.Decimal,9),
					new MySqlParameter("?Weight", MySqlDbType.Decimal,9),
					new MySqlParameter("?ProductID", MySqlDbType.Int32,4),
					new MySqlParameter("?NormsValues", MySqlDbType.VarChar,300)};

            parameters[0].Value = model.PNumber;
            parameters[1].Value = model.Stocks;
            parameters[2].Value = model.SalePrice;
            parameters[3].Value = model.CostPrice;
            parameters[4].Value = model.MarketPrice;
            parameters[5].Value = model.Weight;
            parameters[6].Value = model.ProductID;
            parameters[7].Value = model.NormsValues;

            object obj = DB.ExecuteScalar(CommandType.Text, strSql.ToString(), parameters);
            if (obj == null)
            {
                return 1;
            }
            else
            {
                #region 添加入库日志 yhl 2013-09-09

                ModuleCore.Entity.productlog mProductlog = new productlog();
                mProductlog.ProductId = model.ProductID;
                mProductlog.PNumber = model.PNumber;
                mProductlog.UserID = EbSite.Base.Host.Instance.UserID;
                mProductlog.UserName = EbSite.Base.Host.Instance.UserName;
                mProductlog.AddDate = DateTime.Now;
                mProductlog.Content = string.Concat("于",DateTime.Now,EbSite.Base.Host.Instance.UserName,"【修改入库】",model.Stocks);
                mProductlog.Number = model.Stocks;
                productlog_Add(mProductlog);

                #endregion


                return Convert.ToInt32(obj);
            }
            return 0;
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void NormRelationProduct_Update(Entity.NormRelationProduct model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("update {0}NormRelationProduct set ", sPre);
            strSql.Append("PNumber=?PNumber,");
            strSql.Append("Stocks=?Stocks,");
            strSql.Append("SalePrice=?SalePrice,");
            strSql.Append("CostPrice=?CostPrice,");
            strSql.Append("MarketPrice=?MarketPrice,");
            strSql.Append("Weight=?Weight,");
            strSql.Append("ProductID=?ProductID,");
            strSql.Append("NormsValues=?NormsValues");
            strSql.Append(" where ID=?ID ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?ID", MySqlDbType.Int32,4),
					new MySqlParameter("?PNumber", MySqlDbType.VarChar,30),
					new MySqlParameter("?Stocks", MySqlDbType.Int32,4),
					new MySqlParameter("?SalePrice", MySqlDbType.Decimal,9),
					new MySqlParameter("?CostPrice", MySqlDbType.Decimal,9),
					new MySqlParameter("?MarketPrice", MySqlDbType.Decimal,9),
					new MySqlParameter("?Weight", MySqlDbType.Decimal,9),
					new MySqlParameter("?ProductID", MySqlDbType.Int32,4),
					new MySqlParameter("?NormsValues", MySqlDbType.VarChar,300)};
            parameters[0].Value = model.id;
            parameters[1].Value = model.PNumber;
            parameters[2].Value = model.Stocks;
            parameters[3].Value = model.SalePrice;
            parameters[4].Value = model.CostPrice;
            parameters[5].Value = model.MarketPrice;
            parameters[6].Value = model.Weight;
            parameters[7].Value = model.ProductID;
            parameters[8].Value = model.NormsValues;

            DB.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void NormRelationProduct_Delete(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("delete from {0}NormRelationProduct ", sPre);
            strSql.Append(" where ID=?ID ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?ID", MySqlDbType.Int32,4)};
            parameters[0].Value = ID;

            DB.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Entity.NormRelationProduct NormRelationProduct_GetEntity(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select " + sFieldNormRelationProduct + "  from {0}NormRelationProduct ", sPre);
            strSql.Append(" where ID=?ID ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?ID", MySqlDbType.Int32,4)};
            parameters[0].Value = ID;
            Entity.NormRelationProduct model = null;
            using (IDataReader dataReader = DB.ExecuteReader(CommandType.Text, strSql.ToString(), parameters))
            {
                if (dataReader.Read())
                {
                    model = NormRelationProduct_ReaderBind(dataReader);
                }
            }
            return model;
        }
        /// <summary>
        /// 获取统计
        /// </summary>
        public int NormRelationProduct_GetCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select count(*)  from {0}NormRelationProduct ", sPre);
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            int iCount = 0;
            using (IDataReader dataReader = DB.ExecuteReader(CommandType.Text, strSql.ToString()))
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
        public DataSet NormRelationProduct_GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");

            strSql.Append(sFieldNormRelationProduct);
            strSql.AppendFormat(" FROM {0}NormRelationProduct ", sPre);
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            if (filedOrder.Trim() != "")
            {
                strSql.Append(" order by  " + filedOrder);
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
        public List<Entity.NormRelationProduct> NormRelationProduct_GetListArray(string strWhere)
        {
            return NormRelationProduct_GetListArray(0, strWhere, "");
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public List<Entity.NormRelationProduct> NormRelationProduct_GetListArray(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");

            strSql.Append(sFieldNormRelationProduct);
            strSql.AppendFormat(" FROM {0}NormRelationProduct ", sPre);
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            if (filedOrder.Trim() != "")
            {
                strSql.Append(" order by  " + filedOrder);
            }
            if (Top > 0)
            {
                strSql.Append(" limit " + Top.ToString());
            }
            List<Entity.NormRelationProduct> list = new List<Entity.NormRelationProduct>();
            using (IDataReader dataReader = DB.ExecuteReader(CommandType.Text, strSql.ToString()))
            {
                while (dataReader.Read())
                {
                    list.Add(NormRelationProduct_ReaderBind(dataReader));
                }
            }
            return list;
        }


        /// <summary>
        /// 报警产品 获得分页数据
        /// </summary>
        public List<Entity.NormRelationProduct> NormRelationProduct_UnionGetListPages(int PageIndex, int PageSize, out int RecordCount, string strWhere)
        {
            StringBuilder strSqlCount = new StringBuilder();

            if (!string.IsNullOrEmpty(strWhere))
            {
                strWhere = string.Concat(" and ", strWhere);
            }
            strSqlCount.AppendFormat("SELECT count(*) from {0}normrelationproduct  a LEFT OUTER JOIN {1}newscontent b on a.ProductID=b.ID where a.Stocks<=b.Annex13 {2}; ", sPre, EbSite.Base.Host.Instance.GetSysTablePrefix,strWhere);

            int iCount = 0;
            using (IDataReader dataReader = DB.ExecuteReader(CommandType.Text, strSqlCount.ToString()))
            {
                while (dataReader.Read())
                {
                    iCount = int.Parse(dataReader[0].ToString());
                }
            }
            RecordCount = iCount;

            List<Entity.NormRelationProduct> list = new List<Entity.NormRelationProduct>();


            if (PageIndex > 0)
            {
                PageIndex--;
            }


            int numStart = PageIndex * PageSize;

            StringBuilder strSql = new StringBuilder();
            // string strSql = string.Concat("select ", KeyField, " from ", sTableName, " ", strWhere, sOrderBy, " limit ", numStart, ",", PageSize, ";");
            strSql.AppendFormat("SELECT a.*,b.Annex13,b.NewsTitle,b.ClassName from {0}normrelationproduct  a LEFT OUTER JOIN {1}newscontent b on a.ProductID=b.ID {4} where b.Annex13>0 and a.Stocks<=b.Annex13  limit {2},{3}", sPre, EbSite.Base.Host.Instance.GetSysTablePrefix, numStart, PageSize,strWhere);
            using (IDataReader dataReader = DB.ExecuteReader(CommandType.Text, strSql.ToString()))
            {
                while (dataReader.Read())
                {
                    list.Add(NormRelationProduct_ReaderBind2(dataReader));
                }
            }
            return list;
        }

        /// <summary>
        ///  获得分页数据
        /// </summary>
        public List<Entity.NormRelationProduct> NormRelationProduct_GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby, out int RecordCount)
        {
            StringBuilder sbSql = new StringBuilder();
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                sbSql.Append(" where ");
                sbSql.AppendFormat(strWhere);
            }
            RecordCount = NormRelationProduct_GetCount(sbSql.ToString());
            List<Entity.NormRelationProduct> list = new List<Entity.NormRelationProduct>();
            string strSql = SplitPages.GetSplitPagesMySql(DB, "NormRelationProduct", PageSize, PageIndex, Fileds, "id", oderby, sbSql.ToString(), sPre);
            using (IDataReader dataReader = DB.ExecuteReader(CommandType.Text, strSql))
            {
                while (dataReader.Read())
                {
                    list.Add(NormRelationProduct_ReaderBind(dataReader));
                }
            }
            return list;
        }


        /// <summary>
        /// 对象实体绑定数据
        /// </summary>
        public Entity.NormRelationProduct NormRelationProduct_ReaderBind(IDataReader dataReader)
        {
            Entity.NormRelationProduct model = new Entity.NormRelationProduct();
            object ojb;
            ojb = dataReader["ID"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.id = (int)ojb;
            }
            model.PNumber = dataReader["PNumber"].ToString();
            ojb = dataReader["Stocks"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.Stocks = (int)ojb;
            }
            ojb = dataReader["SalePrice"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.SalePrice = (decimal)ojb;
            }
            ojb = dataReader["CostPrice"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.CostPrice = (decimal)ojb;
            }
            ojb = dataReader["MarketPrice"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.MarketPrice = (decimal)ojb;
            }
            ojb = dataReader["Weight"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.Weight = (decimal)ojb;
            }
            ojb = dataReader["ProductID"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.ProductID = (int)ojb;
            }
            model.NormsValues = dataReader["NormsValues"].ToString();
            return model;
        }
        /// <summary>
        /// 对象实体绑定数据
        /// </summary>
        public Entity.NormRelationProduct NormRelationProduct_ReaderBind2(IDataReader dataReader)
        {
            Entity.NormRelationProduct model = new Entity.NormRelationProduct();
            object ojb;
            ojb = dataReader["ID"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.id = (int)ojb;
            }
            model.PNumber = dataReader["PNumber"].ToString();
            ojb = dataReader["Stocks"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.Stocks = (int)ojb;
            }
            ojb = dataReader["SalePrice"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.SalePrice = (decimal)ojb;
            }
            ojb = dataReader["CostPrice"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.CostPrice = (decimal)ojb;
            }
            ojb = dataReader["MarketPrice"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.MarketPrice = (decimal)ojb;
            }
            ojb = dataReader["Weight"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.Weight = (decimal)ojb;
            }
            ojb = dataReader["ProductID"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.ProductID = (int)ojb;
            }
            model.NormsValues = dataReader["NormsValues"].ToString();


            model.Annex13 = dataReader["Annex13"].ToString();
            model.NewsTitle = dataReader["NewsTitle"].ToString();
            model.ClassName = dataReader["ClassName"].ToString();

            return model;
        }
        #endregion  成员方法

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Entity.NormRelationProduct NormRelationProduct_GetEntityByNormID(string ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select " + sFieldNormRelationProduct + "  from {0}NormRelationProduct ", sPre);
            strSql.Append(" where NormsValues=?NormsValues ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?NormsValues", MySqlDbType.VarChar,250)};
            parameters[0].Value = ID;
            Entity.NormRelationProduct model = null;
            using (IDataReader dataReader = DB.ExecuteReader(CommandType.Text, strSql.ToString(), parameters))
            {
                if (dataReader.Read())
                {
                    model = NormRelationProduct_ReaderBind(dataReader);
                }
            }
            return model;
        }

        /// <summary>
        /// 下单时 事务更新库存量
        /// </summary>
        /// <param name="pnumber">商品货号</param>
        /// <param name="ProductId">产品id</param>
        /// <param name="icount">出库数量</param>
        /// <param name="Trans"></param>
        public void NormRelationProduct_Update(string pnumber, long ProductId, int icount, MySqlTransaction Trans)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select " + sFieldNormRelationProduct + "  from {0}NormRelationProduct ", sPre);
            strSql.Append(" where pnumber=?pnumber and productid=?productid ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?pnumber", MySqlDbType.VarChar,250),
                    new MySqlParameter("?productid",MySqlDbType.Int32,11) 
                                         };
            parameters[0].Value = pnumber;
            parameters[1].Value = ProductId;
            Entity.NormRelationProduct model = null;
            using (IDataReader dataReader = DB.ExecuteReader(CommandType.Text, strSql.ToString(), parameters))
            {
                if (dataReader.Read())
                {
                    model = NormRelationProduct_ReaderBind(dataReader);
                }
            }
            if (!Equals(model, null))
            {
                if (Trans != null)
                {
                    StringBuilder strSql2 = new StringBuilder();
                    strSql2.AppendFormat("update {0}NormRelationProduct set ", sPre);
                    strSql2.Append("Stocks=?Stocks");
                    strSql2.Append(" where ID=?ID ");
                    MySqlParameter[] parameters2 =
                       {
                           new MySqlParameter("?ID", MySqlDbType.Int32, 4), 
                           new MySqlParameter("?Stocks", MySqlDbType.Int32, 4)                  
                       };
                    parameters2[0].Value = model.id;
                    parameters2[1].Value = model.Stocks - icount;
                    DB.ExecuteNonQuery(Trans, CommandType.Text, strSql2.ToString(), parameters2);
                }
            }
        }

        public bool NormRelationProduct_UpdateStocks(int id, int stocks,ModuleCore.Entity.productlog md)
        {
            string strSql =string.Format("update {0}NormRelationProduct set stocks={1}+stocks where id={2};", sPre,stocks,id);
            ModuleCore.Entity.NormRelationProduct normMD = ModuleCore.BLL.NormRelationProduct.Instance.GetEntity(id);
            if (normMD != null)
            {
                long productID = normMD.ProductID;
                md.ProductId = productID;
                md.PNumber = normMD.PNumber;
                EbSite.Entity.NewsContent productMD = EbSite.Base.AppStartInit.NewsContentInstDefault.GetModelDefaultFiled(productID);
                if (productMD != null)
                {
                    if (normMD.PNumber.ToLower().Equals(productMD.Annex1.ToLower()))
                    {
                        strSql += string.Format("update eb_newscontent set annex12={0}+annex12 where id={1};", stocks, productID);
                    }
                }
            }
            if (DB.ExecuteNonQuery(CommandType.Text, strSql)>0)
            {
                ModuleCore.BLL.productlog.Instance.Add(md);
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool NormRelationProduct_UpdateStocksNoNorms(int productID, int stocks,ModuleCore.Entity.productlog md)
        {

            EbSite.Entity.NewsContent productMD = EbSite.Base.AppStartInit.NewsContentInstDefault.GetModelDefaultFiled(productID);
            md.ProductId = productID;
            md.PNumber = productMD.Annex1;
            string strSql = string.Format("update eb_newscontent set annex12={0}+annex12 where id={1};", stocks, productID);
            if (DB.ExecuteNonQuery(CommandType.Text, strSql) > 0)
            {
                ModuleCore.BLL.productlog.Instance.Add(md);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

