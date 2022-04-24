using System;
using System.Data;
using System.Data.Common;
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
        private string sFieldCouponItems = "id,CouponId,LotNumber,ClaimCode,UserId,EmailAddress,AddDateTime,'status'";

        #region 读

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int CouponItems_GetMaxId()
        {
            return DbHelperUser.Instance.GetMaxID("id", string.Format("{0}couponitems", sPre));
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool CouponItems_Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select count(1) from {0}couponitems", sPre);
            strSql.Append(" where id=?id ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32,4)};
            parameters[0].Value = id;

            return DbHelperUser.Instance.Exists(strSql.ToString(), parameters);
        }



        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Entity.CouponItems CouponItems_GetEntity(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select " + sFieldCouponItems + "  from {0}couponitems ", sPre);
            strSql.Append(" where id=?id ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32,4)};
            parameters[0].Value = id;
            Entity.CouponItems model = null;
            using (IDataReader dataReader = DbHelperUser.Instance.ExecuteReader(CommandType.Text, strSql.ToString(), parameters))
            {
                if (dataReader.Read())
                {
                    model = CouponItems_ReaderBind(dataReader);
                }
            }
            return model;
        }
        /// <summary>
        /// 获取统计
        /// </summary>
        public int CouponItems_GetCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select count(*)  from {0}couponitems ", sPre);
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
        public DataSet CouponItems_GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");

            strSql.Append(sFieldCouponItems);
            strSql.AppendFormat(" FROM {0}couponitems ", sPre);
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
        public List<Entity.CouponItems> CouponItems_GetListArray(string strWhere)
        {
            return CouponItems_GetListArray(0, strWhere, "");
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public List<Entity.CouponItems> CouponItems_GetListArray(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");

            strSql.Append(sFieldCouponItems);
            strSql.AppendFormat(" FROM {0}couponitems ", sPre);
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
            List<Entity.CouponItems> list = new List<Entity.CouponItems>();
            using (IDataReader dataReader = DbHelperUser.Instance.ExecuteReader(CommandType.Text, strSql.ToString()))
            {
                while (dataReader.Read())
                {
                    list.Add(CouponItems_ReaderBind(dataReader));
                }
            }
            return list;
        }


        /// <summary>
        /// 获得分页数据
        /// </summary>
        public List<Entity.CouponItems> CouponItems_GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby, out int RecordCount)
        {
            StringBuilder sbSql = new StringBuilder();
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                //  sbSql.Append(" where ");
                sbSql.AppendFormat(strWhere);
            }
            RecordCount = CouponItems_GetCount(sbSql.ToString());
            List<Entity.CouponItems> list = new List<Entity.CouponItems>();
            string strSql = SplitPages.GetSplitPagesMySql(DbHelperUser.Instance, "CouponItems", PageSize, PageIndex, Fileds, "id", oderby, sbSql.ToString(), sPre);
            using (IDataReader dataReader = DbHelperUser.Instance.ExecuteReader(CommandType.Text, strSql))
            {
                while (dataReader.Read())
                {
                    list.Add(CouponItems_ReaderBind(dataReader));
                }
            }
            return list;




        }


        /// <summary>
        /// 对象实体绑定数据
        /// </summary>
        public Entity.CouponItems CouponItems_ReaderBind(IDataReader dataReader)
        {
            Entity.CouponItems model = new Entity.CouponItems();
            object ojb;
            ojb = dataReader["id"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.id = (int)ojb;
            }
            ojb = dataReader["CouponId"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.CouponId = (int)ojb;
            }
            model.LotNumber = dataReader["LotNumber"].ToString();
            model.ClaimCode = dataReader["ClaimCode"].ToString();
            ojb = dataReader["UserId"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.UserId = (int)ojb;
            }
            model.EmailAddress = dataReader["EmailAddress"].ToString();
            ojb = dataReader["AddDateTime"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.AddDateTime = (DateTime)ojb;
            }
            ojb = dataReader["Status"];

            if (ojb != null && ojb != DBNull.Value)
            {

                if ((dataReader["Status"].ToString() == "1") || (dataReader["Status"].ToString().ToLower() == "true"))
                {
                    model.Status = true;
                }
                else
                {
                    model.Status = false;
                }
            }

            return model;
        }

        public Entity.CouponItems CouponItems_GetEntity(string CouponCode, out string CouponName, out decimal Amount, out decimal CouponValue)
        {
            CouponName = string.Empty;
            Amount = 0;
            CouponValue = 0;
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select CI.id,CI.CouponId,CI.LotNumber,CI.ClaimCode,CI.UserId,CI.EmailAddress,CI.AddDateTime,C.CouponName,C.Amount,C.DiscountPrice,CI.Status  from {0}couponitems as CI,{0}coupons as C", sPre);
            strSql.Append(" where ClaimCode=?ClaimCode and CI.CouponId=C.id and Status=0");
            MySqlParameter[] parameters = {
					new MySqlParameter("?ClaimCode", MySqlDbType.VarChar,4)};
            parameters[0].Value = CouponCode;
            Entity.CouponItems model = null;
            using (IDataReader dataReader = DbHelperUser.Instance.ExecuteReader(CommandType.Text, strSql.ToString(), parameters))
            {
                if (dataReader.Read())
                {
                    model = CouponItems_ReaderBind(dataReader);
                    CouponName = dataReader["CouponName"].ToString();
                    object ojb;
                    ojb = dataReader["Amount"];
                    if (ojb != null && ojb != DBNull.Value)
                    {
                        Amount = (decimal)ojb;
                    }
                    ojb = dataReader["DiscountPrice"];
                    if (ojb != null && ojb != DBNull.Value)
                    {
                        CouponValue = (decimal)ojb;
                    }
                }
            }
            return model;
        }

        #region 联合查询

        /// <summary>
        /// 联合查询获得前几行数据
        /// </summary>
        public List<Entity.CouponItems> CouponItemsUnion_GetListArray(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("SELECT b.couponname,a.lotnumber ,a.claimcode  ,b.Amount,b.DiscountPrice,b.EndDateTime from {0}couponitems a left OUTER join {0}coupons b on a.CouponId=b.id  ", sPre);


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
            List<Entity.CouponItems> list = new List<Entity.CouponItems>();
            using (IDataReader dataReader = DbHelperUser.Instance.ExecuteReader(CommandType.Text, strSql.ToString()))
            {
                while (dataReader.Read())
                {
                    list.Add(CouponItems_ReaderBind2(dataReader));
                }
            }
            return list;
        }



        /// <summary>
        /// 对象实体绑定数据
        /// </summary>
        public Entity.CouponItems CouponItems_ReaderBind2(IDataReader dataReader)
        {
            Entity.CouponItems model = new Entity.CouponItems();
            object ojb;


            model.LotNumber = dataReader["LotNumber"].ToString();
            model.ClaimCode = dataReader["ClaimCode"].ToString();



            /////附加
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

            return model;
        }
        #endregion
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Entity.CouponItems CouponItems_GetEntity(string ClaimCode)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select " + sFieldCouponItems + "  from {0}couponitems ", sPre);
            strSql.Append(" where ClaimCode=?ClaimCode ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?ClaimCode", MySqlDbType.VarChar,32)};
            parameters[0].Value = ClaimCode;
            Entity.CouponItems model = null;
            using (IDataReader dataReader = DbHelperUser.Instance.ExecuteReader(CommandType.Text, strSql.ToString(), parameters))
            {
                if (dataReader.Read())
                {
                    model = CouponItems_ReaderBind(dataReader);
                }
            }
            return model;
        }

        #endregion 读

        #region 写

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int CouponItems_Add(Entity.CouponItems model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("insert into {0}couponitems(", sPre);
            strSql.Append("CouponId,LotNumber,ClaimCode,UserId,EmailAddress,AddDateTime,Status)");
            strSql.Append(" values (");
            strSql.Append("?CouponId,?LotNumber,?ClaimCode,?UserId,?EmailAddress,?AddDateTime,?Status)");
            strSql.Append(";select @@IDENTITY");
            MySqlParameter[] parameters = {
					
					new MySqlParameter("?CouponId", MySqlDbType.Int32,4),
					new MySqlParameter("?LotNumber", MySqlDbType.VarChar,100),
					new MySqlParameter("?ClaimCode", MySqlDbType.VarChar,32),
					new MySqlParameter("?UserId", MySqlDbType.Int32,4),
					new MySqlParameter("?EmailAddress", MySqlDbType.VarChar,150),
					new MySqlParameter("?AddDateTime", MySqlDbType.Datetime),
                    new MySqlParameter("?Status",MySqlDbType.Int16,2)};

            parameters[0].Value = model.CouponId;
            parameters[1].Value = model.LotNumber;
            parameters[2].Value = model.ClaimCode;
            parameters[3].Value = model.UserId;
            parameters[4].Value = model.EmailAddress;
            parameters[5].Value = model.AddDateTime;
            parameters[6].Value = model.Status;

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
        public void CouponItems_Update(Entity.CouponItems model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("update {0}couponitems set ", sPre);
            strSql.Append("CouponId=?CouponId,");
            strSql.Append("LotNumber=?LotNumber,");
            strSql.Append("ClaimCode=?ClaimCode,");
            strSql.Append("UserId=?UserId,");
            strSql.Append("EmailAddress=?EmailAddress,");
            strSql.Append("AddDateTime=?AddDateTime,");
            strSql.Append("Status=?Status");
            strSql.Append(" where id=?id ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32,4),
					new MySqlParameter("?CouponId", MySqlDbType.Int32,4),
					new MySqlParameter("?LotNumber", MySqlDbType.VarChar,100),
					new MySqlParameter("?ClaimCode", MySqlDbType.VarChar,32),
					new MySqlParameter("?UserId", MySqlDbType.Int32,4),
					new MySqlParameter("?EmailAddress", MySqlDbType.VarChar,150),
					new MySqlParameter("?AddDateTime", MySqlDbType.Datetime),
                    new MySqlParameter("?Status",MySqlDbType.Int16,2) };
            parameters[0].Value = model.id;
            parameters[1].Value = model.CouponId;
            parameters[2].Value = model.LotNumber;
            parameters[3].Value = model.ClaimCode;
            parameters[4].Value = model.UserId;
            parameters[5].Value = model.EmailAddress;
            parameters[6].Value = model.AddDateTime;
            parameters[7].Value = model.Status;

            DbHelperUserWrite.Instance.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void CouponItems_Delete(int id)
        {
            CouponItems_Delete(id, null);

        }
        /// <summary>
        /// 0.未使用 1.使用
        /// </summary>
        /// <param name="id"></param>
        /// <param name="Trans"></param>
        public void CouponItems_Delete(int id, DbTransaction Trans)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("update {0}couponitems set `Status`=1 ", sPre);
            strSql.Append(" where id=?id ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32,4)};
            parameters[0].Value = id;
            if (Trans == null)
            {
                DbHelperUserWrite.Instance.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
            }
            else
            {
                DbHelperUserWrite.Instance.ExecuteNonQuery(Trans, CommandType.Text, strSql.ToString(), parameters);
            }
        }

        #endregion 写

    }
}

