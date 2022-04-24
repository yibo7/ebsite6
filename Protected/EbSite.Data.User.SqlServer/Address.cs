using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using EbSite.Base.DataProfile;
namespace EbSite.Data.User.SqlServer
{
	/// <summary>
	/// 数据访问类qq。
	/// </summary>
    public partial class DataProviderUser : Interface.IDataProviderUser
	{
        private string sFieldAddress = "id,UserID,UserRealName,Phone,Mobile,Email,PostCode,AreaID,AreaName,CountryID,CountryName,ProvinceID,ProvinceName,CityID,CityName,AddressInfo,IsTemAdress,AddDateime";
        #region  成员方法

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int Address_GetMaxId()
        {
            return DbHelperUser.Instance.GetMaxID("id", string.Format("{0}Address", sPre));
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Address_Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select count(1) from {0}Address", sPre);
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;

            return DbHelperUser.Instance.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Address_Add(Entity.Address model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("insert into {0}Address(", sPre);
            strSql.Append("UserID,UserRealName,Phone,Mobile,PostCode,AreaID,AreaName,CountryID,CountryName,ProvinceID,ProvinceName,CityID,CityName,AddressInfo,IsTemAdress,AddDateime,Email)");
            strSql.Append(" values (");
            strSql.Append("@UserID,@UserRealName,@Phone,@Mobile,@PostCode,@AreaID,@AreaName,@CountryID,@CountryName,@ProvinceID,@ProvinceName,@CityID,@CityName,@AddressInfo,@IsTemAdress,@AddDateime,@Email)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.Int,4),
					new SqlParameter("@UserRealName", SqlDbType.NVarChar,100),
					new SqlParameter("@Phone", SqlDbType.NVarChar,15),
					new SqlParameter("@Mobile", SqlDbType.NVarChar,15),
					new SqlParameter("@PostCode", SqlDbType.NVarChar,10),
					new SqlParameter("@AreaID", SqlDbType.Int,4),
					new SqlParameter("@AreaName", SqlDbType.VarChar,50),
					new SqlParameter("@CountryID", SqlDbType.Int,4),
					new SqlParameter("@CountryName", SqlDbType.VarChar,50),
					new SqlParameter("@ProvinceID", SqlDbType.Int,4),
					new SqlParameter("@ProvinceName", SqlDbType.VarChar,50),
					new SqlParameter("@CityID", SqlDbType.Int,4),
					new SqlParameter("@CityName", SqlDbType.VarChar,50),
					new SqlParameter("@AddressInfo", SqlDbType.Text),
					new SqlParameter("@IsTemAdress", SqlDbType.Int,4),
					new SqlParameter("@AddDateime", SqlDbType.DateTime),
                    new SqlParameter("@Email", SqlDbType.VarChar,50)};
            parameters[0].Value = model.UserID;
            parameters[1].Value = model.UserRealName;
            parameters[2].Value = model.Phone;
            parameters[3].Value = model.Mobile;
            parameters[4].Value = model.PostCode;
            parameters[5].Value = model.AreaID;
            parameters[6].Value = model.AreaName;
            parameters[7].Value = model.CountryID;
            parameters[8].Value = model.CountryName;
            parameters[9].Value = model.ProvinceID;
            parameters[10].Value = model.ProvinceName;
            parameters[11].Value = model.CityID;
            parameters[12].Value = model.CityName;
            parameters[13].Value = model.AddressInfo;
            parameters[14].Value = model.IsTemAdress;
            parameters[15].Value = model.AddDateime;
            parameters[16].Value = model.Email;

            object obj = DbHelperUser.Instance.ExecuteScalar(CommandType.Text, strSql.ToString(), parameters);
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
        public void Address_Update(Entity.Address model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("update {0}Address set ", sPre);
            strSql.Append("UserID=@UserID,");
            strSql.Append("UserRealName=@UserRealName,");
            strSql.Append("Phone=@Phone,");
            strSql.Append("Mobile=@Mobile,");
            strSql.Append("Email=@Email,");
            strSql.Append("PostCode=@PostCode,");
            strSql.Append("AreaID=@AreaID,");
            strSql.Append("AreaName=@AreaName,");
            strSql.Append("CountryID=@CountryID,");
            strSql.Append("CountryName=@CountryName,");
            strSql.Append("ProvinceID=@ProvinceID,");
            strSql.Append("ProvinceName=@ProvinceName,");
            strSql.Append("CityID=@CityID,");
            strSql.Append("CityName=@CityName,");
            strSql.Append("AddressInfo=@AddressInfo,");
            strSql.Append("IsTemAdress=@IsTemAdress,");
            strSql.Append("AddDateime=@AddDateime");
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@UserID", SqlDbType.Int,4),
					new SqlParameter("@UserRealName", SqlDbType.NVarChar,100),
					new SqlParameter("@Phone", SqlDbType.NVarChar,15),
					new SqlParameter("@Mobile", SqlDbType.NVarChar,15),
					new SqlParameter("@PostCode", SqlDbType.NVarChar,10),
					new SqlParameter("@AreaID", SqlDbType.Int,4),
					new SqlParameter("@AreaName", SqlDbType.VarChar,50),
					new SqlParameter("@CountryID", SqlDbType.Int,4),
					new SqlParameter("@CountryName", SqlDbType.VarChar,50),
					new SqlParameter("@ProvinceID", SqlDbType.Int,4),
					new SqlParameter("@ProvinceName", SqlDbType.VarChar,50),
					new SqlParameter("@CityID", SqlDbType.Int,4),
					new SqlParameter("@CityName", SqlDbType.VarChar,50),
					new SqlParameter("@AddressInfo", SqlDbType.Text),
					new SqlParameter("@IsTemAdress", SqlDbType.Int,4),
					new SqlParameter("@AddDateime", SqlDbType.DateTime),
                    new SqlParameter("@Email", SqlDbType.VarChar,50)};
            parameters[0].Value = model.id;
            parameters[1].Value = model.UserID;
            parameters[2].Value = model.UserRealName;
            parameters[3].Value = model.Phone;
            parameters[4].Value = model.Mobile;
            parameters[5].Value = model.PostCode;
            parameters[6].Value = model.AreaID;
            parameters[7].Value = model.AreaName;
            parameters[8].Value = model.CountryID;
            parameters[9].Value = model.CountryName;
            parameters[10].Value = model.ProvinceID;
            parameters[11].Value = model.ProvinceName;
            parameters[12].Value = model.CityID;
            parameters[13].Value = model.CityName;
            parameters[14].Value = model.AddressInfo;
            parameters[15].Value = model.IsTemAdress;
            parameters[16].Value = model.AddDateime;
            parameters[17].Value = model.Email;

            DbHelperUser.Instance.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Address_Delete(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("delete from {0}Address ", sPre);
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;

            DbHelperUser.Instance.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Entity.Address Address_GetEntity(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select " + sFieldAddress + "  from {0}Address ", sPre);
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;
            Entity.Address model = null;
            using (IDataReader dataReader = DbHelperUser.Instance.ExecuteReader(CommandType.Text, strSql.ToString(), parameters))
            {
                if (dataReader.Read())
                {
                    model = Address_ReaderBind(dataReader);
                }
            }
            return model;
        }
        /// <summary>
        /// 获取统计
        /// </summary>
        public int Address_GetCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select count(*)  from {0}Address ", sPre);
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
        public DataSet Address_GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(sFieldAddress);
            strSql.AppendFormat(" FROM {0}Address ", sPre);
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            if (filedOrder.Trim() != "")
            {
                strSql.Append(" order by  " + filedOrder);
            }
            return DbHelperUser.Instance.ExecuteDataset(CommandType.Text, strSql.ToString());
        }

        /// <summary>
        /// 获得数据列表（比DataSet效率高，推荐使用）
        /// </summary>
        public List<Entity.Address> Address_GetListArray(string strWhere)
        {
            return Address_GetListArray(0, strWhere, "");
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public List<Entity.Address> Address_GetListArray(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(sFieldAddress);
            strSql.AppendFormat(" FROM {0}Address ", sPre);
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            if (filedOrder.Trim() != "")
            {
                strSql.Append(" order by  " + filedOrder);
            }
            List<Entity.Address> list = new List<Entity.Address>();
            using (IDataReader dataReader = DbHelperUser.Instance.ExecuteReader(CommandType.Text, strSql.ToString()))
            {
                while (dataReader.Read())
                {
                    list.Add(Address_ReaderBind(dataReader));
                }
            }
            return list;
        }


        /// <summary>
        /// 获得分页数据
        /// </summary>
        public List<Entity.Address> Address_GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby, out int RecordCount)
        {
            List<Entity.Address> list = new List<Entity.Address>();
            using (IDataReader dataReader = SplitPages.GetListPages_SP(DbHelperUser.Instance, "Address", PageSize, PageIndex, Fileds, "id", oderby, strWhere, out RecordCount, sPre))
            {
                while (dataReader.Read())
                {
                    list.Add(Address_ReaderBind(dataReader));
                }
            }
            return list;
        }


        /// <summary>
        /// 对象实体绑定数据
        /// </summary>
        public Entity.Address Address_ReaderBind(IDataReader dataReader)
        {
            Entity.Address model = new Entity.Address();
            object ojb;
            ojb = dataReader["id"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.id = (int)ojb;
            }
            ojb = dataReader["UserID"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.UserID = (int)ojb;
            }
            model.UserRealName = dataReader["UserRealName"].ToString();
            model.Phone = dataReader["Phone"].ToString();
            model.Mobile = dataReader["Mobile"].ToString();
            model.Email = dataReader["Email"].ToString();
            model.PostCode = dataReader["PostCode"].ToString();
            ojb = dataReader["AreaID"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.AreaID = (int)ojb;
            }
            model.AreaName = dataReader["AreaName"].ToString();
            ojb = dataReader["CountryID"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.CountryID = (int)ojb;
            }
            model.CountryName = dataReader["CountryName"].ToString();
            ojb = dataReader["ProvinceID"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.ProvinceID = (int)ojb;
            }
            model.ProvinceName = dataReader["ProvinceName"].ToString();
            ojb = dataReader["CityID"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.CityID = (int)ojb;
            }
            model.CityName = dataReader["CityName"].ToString();
            model.AddressInfo = dataReader["AddressInfo"].ToString();
            ojb = dataReader["IsTemAdress"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.IsTemAdress = (int)ojb;
            }
            ojb = dataReader["AddDateime"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.AddDateime = (DateTime)ojb;
            }
            return model;
        }

        #endregion  成员方法
	}
}

