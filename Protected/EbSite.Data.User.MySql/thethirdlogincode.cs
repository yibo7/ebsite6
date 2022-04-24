using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using EbSite.Base.DataProfile;
using MySql.Data.MySqlClient;

namespace EbSite.Data.User.MySql
{
	/// <summary>
	/// 数据访问类qwef。
	/// </summary>
    public partial class DataProviderUser : Interface.IDataProviderUser
	{
		private string sFieldthethirdlogincode = "ID,userid,username,tokencode,appname,isbind,otherinfo,adddate";

        #region 读

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int thethirdlogincode_GetMaxId()
        {
            return DbHelperUser.Instance.GetMaxID("ID", string.Format("{0}thethirdlogincode", sPre));
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool thethirdlogincode_Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select count(1) from {0}thethirdlogincode", sPre);
            strSql.Append(" where ID=?ID ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?ID", MySqlDbType.Int32,4)};
            parameters[0].Value = ID;

            return DbHelperUser.Instance.Exists(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool thethirdlogincode_Exists(string strToken)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select count(1) from {0}thethirdlogincode", sPre);
            strSql.Append(" where tokencode=?tokencode ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?tokencode", MySqlDbType.VarChar,50)};
            parameters[0].Value = strToken;
            string result = DbHelperUser.Instance.ExecuteScalarToStr(CommandType.Text, strSql.ToString(), parameters);
            return string.IsNullOrEmpty(result) || result.Equals("0") ? false : true;
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Entity.TheThirdLoginCode thethirdlogincode_GetEntity(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select " + sFieldthethirdlogincode + "  from {0}thethirdlogincode ", sPre);
            strSql.Append(" where ID=?ID ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?ID", MySqlDbType.Int32,4)};
            parameters[0].Value = ID;
            Entity.TheThirdLoginCode model = null;
            using (IDataReader dataReader = DbHelperUser.Instance.ExecuteReader(CommandType.Text, strSql.ToString(), parameters))
            {
                if (dataReader.Read())
                {
                    model = thethirdlogincode_ReaderBind(dataReader);
                }
            }
            return model;
        }
        /// <summary>
        /// 获取统计
        /// </summary>
        public int thethirdlogincode_GetCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select count(*)  from {0}thethirdlogincode ", sPre);
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
        public DataSet thethirdlogincode_GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");

            strSql.Append(sFieldthethirdlogincode);
            strSql.AppendFormat(" FROM {0}thethirdlogincode ", sPre);
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
        public List<Entity.TheThirdLoginCode> thethirdlogincode_GetListArray(string strWhere)
        {
            return thethirdlogincode_GetListArray(0, strWhere, "");
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public List<Entity.TheThirdLoginCode> thethirdlogincode_GetListArray(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");

            strSql.Append(sFieldthethirdlogincode);
            strSql.AppendFormat(" FROM {0}thethirdlogincode ", sPre);
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
            List<Entity.TheThirdLoginCode> list = new List<Entity.TheThirdLoginCode>();
            using (IDataReader dataReader = DbHelperUser.Instance.ExecuteReader(CommandType.Text, strSql.ToString()))
            {
                while (dataReader.Read())
                {
                    list.Add(thethirdlogincode_ReaderBind(dataReader));
                }
            }
            return list;
        }


        /// <summary>
        /// 获得分页数据
        /// </summary>
        public List<Entity.TheThirdLoginCode> thethirdlogincode_GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby, out int RecordCount)
        {
            List<Entity.TheThirdLoginCode> list = new List<Entity.TheThirdLoginCode>();
            using (IDataReader dataReader = SplitPages.GetListPages_SP(DbHelperUser.Instance, "TheThirdLoginCode", PageSize, PageIndex, Fileds, "ID", oderby, strWhere, out RecordCount, sPre))
            {
                while (dataReader.Read())
                {
                    list.Add(thethirdlogincode_ReaderBind(dataReader));
                }
            }
            return list;
        }


        /// <summary>
        /// 对象实体绑定数据
        /// </summary>
        public Entity.TheThirdLoginCode thethirdlogincode_ReaderBind(IDataReader dataReader)
        {
            Entity.TheThirdLoginCode model = new Entity.TheThirdLoginCode();
            object ojb;
            ojb = dataReader["ID"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.id = (int)ojb;
            }
            ojb = dataReader["userid"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.userid = (int)ojb;
            }
            ojb = dataReader["isbind"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.IsBind = (int)ojb;
            }
            model.username = dataReader["username"].ToString();
            model.tokencode = dataReader["tokencode"].ToString();
            model.appname = dataReader["appname"].ToString();
            model.otherinfo = dataReader["otherinfo"].ToString();
            ojb = dataReader["adddate"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.adddate = (DateTime)ojb;
            }
            return model;
        }

        #region 自定义方法

        /// <summary>
        /// 是否已经绑定过
        /// </summary>
        /// <param name="strToken">授权码</param>
        /// <returns></returns>
        public bool thethirdlogincode_IsBind(string strToken)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select isbind from {0}thethirdlogincode", sPre);
            strSql.Append(" where tokencode=?tokencode ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?tokencode", MySqlDbType.VarChar,50)};
            parameters[0].Value = strToken;

            return DbHelperUser.Instance.ExecuteScalarToStr(CommandType.Text, strSql.ToString(), parameters).Equals("1") ? true : false;
        }
        /// <summary>
        /// 根据授权码获取用户ID
        /// </summary>
        /// <param name="strToken"></param>
        /// <returns></returns>
        public int thethirdlogincode_GetUserIDByToken(string strToken)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select userid from {0}thethirdlogincode", sPre);
            strSql.Append(" where tokencode=?tokencode ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?tokencode", MySqlDbType.VarChar,50)};
            parameters[0].Value = strToken;
            object o = DbHelperUser.Instance.ExecuteScalar(CommandType.Text, strSql.ToString(), parameters);
            return Equals(o, null) ? 0 : (int)o;
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Entity.TheThirdLoginCode thethirdlogincode_GetEntity(string Uid, string appName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select " + sFieldthethirdlogincode + "  from {0}thethirdlogincode where UserID={1} and appname=\"{2}\"", sPre, Uid, appName);
            Entity.TheThirdLoginCode model = null;
            using (IDataReader dataReader = DbHelperUser.Instance.ExecuteReader(CommandType.Text, strSql.ToString()))
            {
                if (dataReader.Read())
                {
                    model = thethirdlogincode_ReaderBind(dataReader);
                }
            }
            return model;
        }

        #endregion 自定义方法

        #endregion 读

        #region 写

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int thethirdlogincode_Add(Entity.TheThirdLoginCode model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("insert into {0}thethirdlogincode(", sPre);
            strSql.Append("ID,userid,username,tokencode,appname,isbind,otherinfo,adddate)");
            strSql.Append(" values (");
            strSql.Append("?ID,?userid,?username,?tokencode,?appname,?isbind,?otherinfo,?adddate)");
            strSql.Append(";SELECT @@session.identity;");
            MySqlParameter[] parameters = {
					new MySqlParameter("?ID", MySqlDbType.Int32,4),
					new MySqlParameter("?userid", MySqlDbType.Int32,4),
					new MySqlParameter("?username", MySqlDbType.VarChar,50),
					new MySqlParameter("?tokencode", MySqlDbType.VarChar,512),
					new MySqlParameter("?appname", MySqlDbType.VarChar,50),
					new MySqlParameter("?otherinfo", MySqlDbType.VarChar,2000),
					new MySqlParameter("?adddate", MySqlDbType.Datetime),
                    new MySqlParameter("?isbind", MySqlDbType.Int32,4)
            };
            parameters[0].Value = model.ID;
            parameters[1].Value = model.userid;
            parameters[2].Value = model.username;
            parameters[3].Value = model.tokencode;
            parameters[4].Value = model.appname;
            parameters[5].Value = model.otherinfo;
            parameters[6].Value = model.adddate;
            parameters[7].Value = model.IsBind;

            object obj = DbHelperUserWrite.Instance.ExecuteScalar(CommandType.Text, strSql.ToString(), parameters);
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
        public void thethirdlogincode_Update(Entity.TheThirdLoginCode model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update eb_thethirdlogincode set ");
            if (model.userid != null)
            {
                strSql.Append("userid=" + model.userid + ",");
            }

            if (model.username != null)
            {
                strSql.Append("username='" + model.username + "',");
            }

            if (model.tokencode != null)
            {
                strSql.Append("tokencode='" + model.tokencode + "',");
            }

            if (model.appname != null)
            {
                strSql.Append("appname='" + model.appname + "',");
            }

            if (model.IsBind != null)
            {
                strSql.Append("isbind=" + model.IsBind + ",");
            }

            if (model.otherinfo != null)
            {
                strSql.Append("otherinfo='" + model.otherinfo + "',");
            }

            if (model.adddate != null)
            {
                strSql.Append("adddate='" + model.adddate + "',");
            }

            int n = strSql.ToString().LastIndexOf(",");
            strSql.Remove(n, 1);
            strSql.Append(" where ID=" + model.ID + "");
            int rowsAffected = DbHelperUserWrite.Instance.ExecuteNonQuery(strSql.ToString());
        }
        /// <summary>
        /// 根据授权码更新
        /// </summary>
        /// <param name="model">对象</param>
        /// <returns></returns>
        public bool thethirdlogincode_UpdateByToken(Entity.TheThirdLoginCode model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update eb_thethirdlogincode set ");
            if (model.username != null)
            {
                strSql.Append("username='" + model.username + "',");
            }

            if (model.IsBind != null)
            {
                strSql.Append("isbind=" + model.IsBind + ",");
            }

            if (model.otherinfo != null)
            {
                strSql.Append("otherinfo='" + model.otherinfo + "',");
            }

            int n = strSql.ToString().LastIndexOf(",");
            strSql.Remove(n, 1);
            strSql.Append(" where tokencode='" + model.tokencode + "'");
            int rowsAffected = DbHelperUserWrite.Instance.ExecuteNonQuery(strSql.ToString());
            if (rowsAffected > 0)
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void thethirdlogincode_Delete(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("delete from {0}thethirdlogincode ", sPre);
            strSql.Append(" where ID=?ID ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?ID", MySqlDbType.Int32,4)};
            parameters[0].Value = ID;

            DbHelperUserWrite.Instance.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }


        #endregion 写

    }
}

