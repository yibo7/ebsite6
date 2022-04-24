using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using EbSite.Base.DataProfile;
using MySql.Data.MySqlClient;
namespace EbSite.Data.User.MySql
{
	/// <summary>
	/// 数据访问类Shop。
	/// </summary>
    public partial class DataProviderUser : Interface.IDataProviderUser
	{
		private string sFieldCoupons = "id,CouponName,EndDateTime,Amount,DiscountPrice,Description,SentCount,UsedCount,NeedPoint";

        #region 读

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int Coupons_GetMaxId()
        {
            return DbHelperUser.Instance.GetMaxID("id", string.Format("{0}coupons", sPre));
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Coupons_Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select count(1) from {0}coupons", sPre);
            strSql.Append(" where id=?id ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32,4)};
            parameters[0].Value = id;

            return DbHelperUser.Instance.Exists(strSql.ToString(), parameters);
        }



        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Entity.Coupons Coupons_GetEntity(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select " + sFieldCoupons + "  from {0}coupons ", sPre);
            strSql.Append(" where id=?id ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32,4)};
            parameters[0].Value = id;
            Entity.Coupons model = null;
            using (IDataReader dataReader = DbHelperUser.Instance.ExecuteReader(CommandType.Text, strSql.ToString(), parameters))
            {
                if (dataReader.Read())
                {
                    model = Coupons_ReaderBind(dataReader);
                }
            }
            return model;
        }
        /// <summary>
        /// 获取统计
        /// </summary>
        public int Coupons_GetCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select count(*)  from {0}coupons ", sPre);
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            int iCount = 0;
            using (IDataReader dataReader = DbHelperUser.Instance.ExecuteReader(CommandType.Text, strSql.ToString()))
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
        public DataSet Coupons_GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");

            strSql.Append(sFieldCoupons);
            strSql.AppendFormat(" FROM {0}coupons ", sPre);
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
            return DbHelperUser.Instance.ExecuteDataset(CommandType.Text, strSql.ToString());
        }

        /// <summary>
        /// 获得数据列表（比DataSet效率高，推荐使用）
        /// </summary>
        public List<Entity.Coupons> Coupons_GetListArray(string strWhere)
        {
            return Coupons_GetListArray(0, strWhere, "");
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public List<Entity.Coupons> Coupons_GetListArray(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");

            strSql.Append(sFieldCoupons);
            strSql.AppendFormat(" FROM {0}coupons ", sPre);
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
            List<Entity.Coupons> list = new List<Entity.Coupons>();
            using (IDataReader dataReader = DbHelperUser.Instance.ExecuteReader(CommandType.Text, strSql.ToString()))
            {
                while (dataReader.Read())
                {
                    list.Add(Coupons_ReaderBind(dataReader));
                }
            }
            return list;
        }


        /// <summary>
        /// 获得分页数据
        /// </summary>
        public List<Entity.Coupons> Coupons_GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby, out int RecordCount)
        {
            StringBuilder sbSql = new StringBuilder();
            if (strWhere == "1")
            {
                strWhere = "SentCount>0 and EndDateTime>now()";
            }
            if (strWhere == "2")
            {
                strWhere = "EndDateTime<now()";
            }
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                sbSql.AppendFormat(strWhere);
            }
            RecordCount = Coupons_GetCount(strWhere.ToString());
            List<Entity.Coupons> list = new List<Entity.Coupons>();
            string strSql = SplitPages.GetSplitPagesMySql(DbHelperUser.Instance, "Coupons", PageSize, PageIndex, Fileds, "id", oderby, sbSql.ToString(), sPre);
            using (IDataReader dataReader = DbHelperUser.Instance.ExecuteReader(CommandType.Text, strSql))
            {
                while (dataReader.Read())
                {
                    list.Add(Coupons_ReaderBind(dataReader));
                }
            }
            return list;



        }


        /// <summary>
        /// 对象实体绑定数据
        /// </summary>
        public Entity.Coupons Coupons_ReaderBind(IDataReader dataReader)
        {
            Entity.Coupons model = new Entity.Coupons();
            object ojb;
            ojb = dataReader["id"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.id = (int)ojb;
            }
            model.CouponName = dataReader["CouponName"].ToString();
            ojb = dataReader["EndDateTime"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.EndDateTime = (DateTime)ojb;
            }
            ojb = dataReader["Amount"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.Amount = (decimal)ojb;
            }
            ojb = dataReader["DiscountPrice"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.DiscountPrice = (decimal)ojb;
            }
            model.Description = dataReader["Description"].ToString();
            ojb = dataReader["SentCount"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.SentCount = (int)ojb;
            }
            ojb = dataReader["UsedCount"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.UsedCount = (int)ojb;
            }
            ojb = dataReader["NeedPoint"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.NeedPoint = (int)ojb;
            }
            return model;
        }
        /// <summary>
        /// 获取我的优惠券
        /// </summary>
        /// <param name="uid">用户ID</param>
        /// <param name="endDate">当前日期</param>
        /// <returns></returns>
        public List<Entity.Coupons> Coupons_GetListArray(int uid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select {0} from eb_coupons where id in(SELECT couponid from eb_couponitems where UserId={1} GROUP BY CouponId) and enddatetime>current_date()", sFieldCoupons, uid);
            List<Entity.Coupons> list = new List<Entity.Coupons>();
            using (IDataReader dataReader = DbHelperUser.Instance.ExecuteReader(CommandType.Text, strSql.ToString()))
            {
                while (dataReader.Read())
                {
                    list.Add(Coupons_ReaderBind(dataReader));
                }
            }
            return list;
        }

        #endregion 读

        #region 写

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Coupons_Add(Entity.Coupons model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("insert into {0}coupons(", sPre);
            strSql.Append("CouponName,EndDateTime,Amount,DiscountPrice,Description,SentCount,UsedCount,NeedPoint)");
            strSql.Append(" values (");
            strSql.Append("?CouponName,?EndDateTime,?Amount,?DiscountPrice,?Description,?SentCount,?UsedCount,?NeedPoint)");
            strSql.Append(";select @@IDENTITY");
            MySqlParameter[] parameters = {
					
					new MySqlParameter("?CouponName", MySqlDbType.VarChar,50),
					new MySqlParameter("?EndDateTime", MySqlDbType.Datetime),
					new MySqlParameter("?Amount", MySqlDbType.Decimal,9),
					new MySqlParameter("?DiscountPrice", MySqlDbType.Decimal,9),
					new MySqlParameter("?Description", MySqlDbType.VarChar,500),
					new MySqlParameter("?SentCount", MySqlDbType.Int32,4),
					new MySqlParameter("?UsedCount", MySqlDbType.Int32,4),
					new MySqlParameter("?NeedPoint", MySqlDbType.Int32,4)};
            parameters[0].Value = model.CouponName;
            parameters[1].Value = model.EndDateTime;
            parameters[2].Value = model.Amount;
            parameters[3].Value = model.DiscountPrice;
            parameters[4].Value = model.Description;
            parameters[5].Value = model.SentCount;
            parameters[6].Value = model.UsedCount;
            parameters[7].Value = model.NeedPoint;


            object obj = DbHelperUserWrite.Instance.ExecuteScalar(CommandType.Text, strSql.ToString(), parameters);
            if (obj == null)
            {
                return 1;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
            return 0;
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Coupons_Update(Entity.Coupons model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("update {0}coupons set ", sPre);
            strSql.Append("CouponName=?CouponName,");
            strSql.Append("EndDateTime=?EndDateTime,");
            strSql.Append("Amount=?Amount,");
            strSql.Append("DiscountPrice=?DiscountPrice,");
            strSql.Append("Description=?Description,");
            strSql.Append("SentCount=?SentCount,");
            strSql.Append("UsedCount=?UsedCount,");
            strSql.Append("NeedPoint=?NeedPoint");
            strSql.Append(" where id=?id ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32,4),
					new MySqlParameter("?CouponName", MySqlDbType.VarChar,50),
					new MySqlParameter("?EndDateTime", MySqlDbType.Datetime),
					new MySqlParameter("?Amount", MySqlDbType.Decimal,9),
					new MySqlParameter("?DiscountPrice", MySqlDbType.Decimal,9),
					new MySqlParameter("?Description", MySqlDbType.VarChar,500),
					new MySqlParameter("?SentCount", MySqlDbType.Int32,4),
					new MySqlParameter("?UsedCount", MySqlDbType.Int32,4),
					new MySqlParameter("?NeedPoint", MySqlDbType.Int32,4)};
            parameters[0].Value = model.id;
            parameters[1].Value = model.CouponName;
            parameters[2].Value = model.EndDateTime;
            parameters[3].Value = model.Amount;
            parameters[4].Value = model.DiscountPrice;
            parameters[5].Value = model.Description;
            parameters[6].Value = model.SentCount;
            parameters[7].Value = model.UsedCount;
            parameters[8].Value = model.NeedPoint;

            DbHelperUserWrite.Instance.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Coupons_Delete(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("delete from {0}coupons ", sPre);
            strSql.Append(" where id=?id ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32,4)};
            parameters[0].Value = id;

            DbHelperUserWrite.Instance.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }


        #endregion 写

    }
}

