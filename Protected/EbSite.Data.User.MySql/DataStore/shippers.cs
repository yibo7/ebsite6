using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using EbSite.Base.DataProfile;
using MySql.Data.MySqlClient;

namespace EbSite.Data.User.MySql
{
    /// <summary>
    /// 数据访问类。
    /// </summary>
    public partial class DataProviderUser : Interface.IDataProviderUser
	{
        private string sFieldshippers = "id,IsDefault,ShipperTag,ShipperName,RegionId,Address,CellPhone,TelPhone,Zipcode,Remark,ShopName";

        #region 读

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int shippers_GetMaxId()
        {
            return DbHelperUser.Instance.GetMaxID("id", string.Format("{0}shippers", sPre));
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool shippers_Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select count(1) from {0}shippers", sPre);
            strSql.Append(" where id=?id ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32)};
            parameters[0].Value = id;

            return DbHelperUser.Instance.Exists(strSql.ToString(), parameters);
        }




        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Entity.Shippers shippers_GetEntity(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select " + sFieldshippers + "  from {0}shippers ", sPre);
            strSql.Append(" where id=?id ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32)};
            parameters[0].Value = id;
            Entity.Shippers model = null;
            using (IDataReader dataReader = DbHelperUser.Instance.ExecuteReader(CommandType.Text, strSql.ToString(), parameters))
            {
                if (dataReader.Read())
                {
                    model = shippers_ReaderBind(dataReader);
                }
            }
            return model;
        }
        /// <summary>
        /// 获取统计
        /// </summary>
        public int shippers_GetCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select count(*)  from {0}shippers ", sPre);
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
        public DataSet shippers_GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            strSql.Append(sFieldshippers);
            strSql.AppendFormat(" FROM {0}shippers ", sPre);
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
        public List<Entity.Shippers> shippers_GetListArray(string strWhere)
        {
            return shippers_GetListArray(0, strWhere, "");
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public List<Entity.Shippers> shippers_GetListArray(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            strSql.Append(sFieldshippers);
            strSql.AppendFormat(" FROM {0}shippers ", sPre);
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
            List<Entity.Shippers> list = new List<Entity.Shippers>();
            using (IDataReader dataReader = DbHelperUser.Instance.ExecuteReader(CommandType.Text, strSql.ToString()))
            {
                while (dataReader.Read())
                {
                    list.Add(shippers_ReaderBind(dataReader));
                }
            }
            return list;
        }


        /// <summary>
        /// 获得分页数据
        /// </summary>
        public List<Entity.Shippers> shippers_GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby, out int RecordCount)
        {
            List<Entity.Shippers> list = new List<Entity.Shippers>();
            RecordCount = shippers_GetCount(strWhere);
            string strSql = SplitPages.GetSplitPagesMySql(DbHelperCms.Instance, "Shippers", PageSize, PageIndex, Fileds, "id", oderby, strWhere, sPre);
            using (IDataReader dataReader = DbHelperCms.Instance.ExecuteReader(CommandType.Text, strSql))
            {
                while (dataReader.Read())
                {
                    list.Add(shippers_ReaderBind(dataReader));
                }
            }
            return list;
        }


        /// <summary>
        /// 对象实体绑定数据
        /// </summary>
        public Entity.Shippers shippers_ReaderBind(IDataReader dataReader)
        {
            Entity.Shippers model = new Entity.Shippers();
            object ojb;
            ojb = dataReader["id"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.id = (int)ojb;
            }
            ojb = dataReader["IsDefault"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.IsDefault = (bool)ojb;
            }
            model.ShipperTag = dataReader["ShipperTag"].ToString();
            model.ShipperName = dataReader["ShipperName"].ToString();
            ojb = dataReader["RegionId"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.RegionId = (int)ojb;
            }
            model.Address = dataReader["Address"].ToString();
            model.CellPhone = dataReader["CellPhone"].ToString();
            model.TelPhone = dataReader["TelPhone"].ToString();
            model.Zipcode = dataReader["Zipcode"].ToString();
            model.Remark = dataReader["Remark"].ToString();
            model.ShopName = dataReader["ShopName"].ToString();
            return model;
        }

        #endregion 读

        #region 写

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int shippers_Add(Entity.Shippers model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("insert into {0}shippers(", sPre);
            strSql.Append("IsDefault,ShipperTag,ShipperName,RegionId,Address,CellPhone,TelPhone,Zipcode,Remark,ShopName)");
            strSql.Append(" values (");
            strSql.Append("?IsDefault,?ShipperTag,?ShipperName,?RegionId,?Address,?CellPhone,?TelPhone,?Zipcode,?Remark,?ShopName)");
            strSql.Append(";SELECT @@session.identity");
            MySqlParameter[] parameters = {
					new MySqlParameter("?IsDefault", MySqlDbType.Int16,1),
					new MySqlParameter("?ShipperTag", MySqlDbType.VarChar,200),
					new MySqlParameter("?ShipperName", MySqlDbType.VarChar,200),
					new MySqlParameter("?RegionId", MySqlDbType.Int32,11),
					new MySqlParameter("?Address", MySqlDbType.VarChar,200),
					new MySqlParameter("?CellPhone", MySqlDbType.VarChar,50),
					new MySqlParameter("?TelPhone", MySqlDbType.VarChar,50),
					new MySqlParameter("?Zipcode", MySqlDbType.VarChar,50),
					new MySqlParameter("?Remark", MySqlDbType.VarChar,500),
                    new MySqlParameter("?ShopName",MySqlDbType.VarChar,100) };
            parameters[0].Value = model.IsDefault;
            parameters[1].Value = model.ShipperTag;
            parameters[2].Value = model.ShipperName;
            parameters[3].Value = model.RegionId;
            parameters[4].Value = model.Address;
            parameters[5].Value = model.CellPhone;
            parameters[6].Value = model.TelPhone;
            parameters[7].Value = model.Zipcode;
            parameters[8].Value = model.Remark;
            parameters[9].Value = model.ShopName;

            object obj = DbHelperUserWrite.Instance.ExecuteScalar(CommandType.Text, strSql.ToString(), parameters);
            if (obj == null)
            {
                return shippers_GetMaxId();
            }
            return 0;
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void shippers_Update(Entity.Shippers model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("update {0}shippers set ", sPre);
            strSql.Append("IsDefault=?IsDefault,");
            strSql.Append("ShipperTag=?ShipperTag,");
            strSql.Append("ShipperName=?ShipperName,");
            strSql.Append("RegionId=?RegionId,");
            strSql.Append("Address=?Address,");
            strSql.Append("CellPhone=?CellPhone,");
            strSql.Append("TelPhone=?TelPhone,");
            strSql.Append("Zipcode=?Zipcode,");
            strSql.Append("Remark=?Remark,");
            strSql.Append("ShopName=?ShopName");
            strSql.Append(" where id=?id ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32,11),
					new MySqlParameter("?IsDefault", MySqlDbType.Int16,1),
					new MySqlParameter("?ShipperTag", MySqlDbType.VarChar,200),
					new MySqlParameter("?ShipperName", MySqlDbType.VarChar,200),
					new MySqlParameter("?RegionId", MySqlDbType.Int32,11),
					new MySqlParameter("?Address", MySqlDbType.VarChar,200),
					new MySqlParameter("?CellPhone", MySqlDbType.VarChar,50),
					new MySqlParameter("?TelPhone", MySqlDbType.VarChar,50),
					new MySqlParameter("?Zipcode", MySqlDbType.VarChar,50),
					new MySqlParameter("?Remark", MySqlDbType.VarChar,500),
                    new MySqlParameter("?ShopName",MySqlDbType.VarChar,100) };
            parameters[0].Value = model.id;
            parameters[1].Value = model.IsDefault;
            parameters[2].Value = model.ShipperTag;
            parameters[3].Value = model.ShipperName;
            parameters[4].Value = model.RegionId;
            parameters[5].Value = model.Address;
            parameters[6].Value = model.CellPhone;
            parameters[7].Value = model.TelPhone;
            parameters[8].Value = model.Zipcode;
            parameters[9].Value = model.Remark;
            parameters[10].Value = model.ShopName;

            DbHelperUserWrite.Instance.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void shippers_Delete(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("delete from {0}shippers ", sPre);
            strSql.Append(" where id=?id ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32)};
            parameters[0].Value = id;

            DbHelperUserWrite.Instance.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }

        #endregion 写

    }
}

