using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;
using MySql.Data.MySqlClient;
using EbSite.BLL;
using EbSite.Base.DataProfile;
using EbSite.Entity;

namespace EbSite.Data.MySql
{
    public partial class DataProviderCms : Interface.IDataProviderCms
	{		
        #region 读

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int FriendList_GetMaxId()
        {
            return DbHelperCms.Instance.GetMaxID("ID", string.Format("{0}friendlist", sPre));
        }

        /// <summary>
        /// 判断是否已经存在好友关系
        /// </summary>
        /// <param name="UserID">当前用户ID</param>
        /// <param name="FriendID">好友ID</param>
        /// <returns>0为不存在好友关系，1两人已经是好友,2对方已经邀请你,3邀请你已经邀请过对方</returns>
        public int FriendList_Exists(int UserID, int FriendID)
        {

            ////两人已经是好友
            //string sql1 = string.Format("select count(1) from {0}FriendList where UserID=?UserID and FriendID=?FriendID and IsAllow=1", sPre);
            ////对方已经邀请你
            //string sql2 = string.Format("select count(1) from {0}FriendList where UserID=?UserID and FriendID=?FriendID ", sPre);
            ////邀请你已经邀请过对方
            //string sql3 = string.Format("select count(1) from {0}FriendList where UserID=?FriendID and FriendID=?UserID ", sPre);

            //MySqlParameter[] parameters = {
            //        new MySqlParameter("?UserID", MySqlDbType.Int32,4),
            //        new MySqlParameter("?FriendID", MySqlDbType.Int32,4)
            //                            };
            //parameters[0].Value = UserID;
            //parameters[1].Value = FriendID;

            //bool ishave = DbHelperCms.Instance.Exists(sql1, parameters);
            //// DbHelperCms.Instance.ExecuteReader(CommandType.StoredProcedure, string.Format("{0}ProcSpecialClassFoo", sPre), parameters)
            //if (ishave)
            //{
            //    return 1;//两人已经是好友
            //}

            //ishave = DbHelperCms.Instance.Exists(sql2, parameters);

            //if (ishave)
            //{
            //    return 2;//对方已经邀请你
            //}
            //ishave = DbHelperCms.Instance.Exists(sql3, parameters);

            //if (ishave)
            //{
            //    return 3;//邀请你已经邀请过对方
            //}
            //return 0;

            MySqlParameter[] parameters = {
                    new MySqlParameter("?p_UserID", MySqlDbType.Int32,4),
                    new MySqlParameter("?p_FriendID", MySqlDbType.Int32,4)
                                        };
            parameters[0].Value = UserID;
            parameters[1].Value = FriendID;
            string ob = DbHelperCms.Instance.ExecuteScalarToStr(CommandType.StoredProcedure, string.Format("{0}IsFriend", sPre), parameters);

            return int.Parse(ob);

        }




        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public BLL.FriendList FriendList_GetModel(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select ID,FriendName,IsAllow,AddDate,UserID,UserName,UserNiName,FriendID,FriendNiName from {0}friendlist ", sPre);
            strSql.Append(" where ID=?ID limit 1");
            MySqlParameter[] parameters = {
					new MySqlParameter("?ID", MySqlDbType.Int32,4)
                                        
                                        };
            parameters[0].Value = id;
            //parameters[1].Value = FriendName;
            BLL.FriendList model = new BLL.FriendList();
            using (IDataReader dataReader = DbHelperCms.Instance.ExecuteReader(CommandType.Text, strSql.ToString(), parameters))
            {
                if (dataReader.Read())
                {
                    model = FriendList_ReaderBind(dataReader);

                }
            }
            return model;
        }


        public List<BLL.FriendList> FriendList_GetList(int Top, string strWhere, string filedOrder, int IsAllow)
        {


            string sIsAllow = "";

            if (IsAllow > -1)
            {
                sIsAllow = string.Format(" IsAllow={0}", IsAllow);
            }

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");

            strSql.Append(" ID,FriendName,IsAllow,AddDate,UserID,UserName,UserNiName,FriendID,FriendNiName ");
            strSql.AppendFormat(" FROM {0}FriendList ", sPre);
            if (strWhere.Trim() != "")
            {
                if (!string.IsNullOrEmpty(sIsAllow))
                {
                    strSql.AppendFormat(" where {0} and {1}", strWhere, sIsAllow);
                }
                else
                {
                    strSql.AppendFormat(" where {0}", strWhere);
                }

            }
            else
            {
                if (!string.IsNullOrEmpty(sIsAllow))
                {
                    strSql.AppendFormat(" where {0} ", sIsAllow);
                }

            }
            if (filedOrder.Trim() != "")
            {
                strSql.Append(" order by " + filedOrder);
            }
            if (Top > 0)
            {
                strSql.Append(" limit " + Top.ToString());
            }
            List<EbSite.BLL.FriendList> list = new List<EbSite.BLL.FriendList>();

            using (IDataReader dataReader = DbHelperCms.Instance.ExecuteReader(CommandType.Text, strSql.ToString()))
            {
                while (dataReader.Read())
                {
                    list.Add(FriendList_ReaderBind(dataReader));
                }
            }
            return list;
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public List<BLL.FriendList> FriendList_GetList(int Top, string strWhere, string filedOrder)
        {
            return FriendList_GetList(Top, strWhere, filedOrder, -1);
        }
        /// <summary>
        /// 对象实体绑定数据
        /// </summary>
        public BLL.FriendList FriendList_ReaderBind(IDataReader dataReader)
        {
            BLL.FriendList model = new FriendList();

            if (dataReader["ID"].ToString() != "")
            {
                model.Id = int.Parse(dataReader["ID"].ToString());
            }
            model.FriendName = dataReader["FriendName"].ToString();
            if (dataReader["IsAllow"].ToString() != "")
            {
                if ((dataReader["IsAllow"].ToString() == "1") || (dataReader["IsAllow"].ToString().ToLower() == "true"))
                {
                    model.IsAllow = true;
                }
                else
                {
                    model.IsAllow = false;
                }
            }
            if (dataReader["AddDate"].ToString() != "")
            {
                model.AddDate = DateTime.Parse(dataReader["AddDate"].ToString());
            }
            if (dataReader["UserID"].ToString() != "")
            {
                model.UserID = int.Parse(dataReader["UserID"].ToString());
            }
            model.UserName = dataReader["UserName"].ToString();
            model.UserNiName = dataReader["UserNiName"].ToString();
            if (dataReader["FriendID"].ToString() != "")
            {
                model.FriendID = int.Parse(dataReader["FriendID"].ToString());
            }
            model.FriendNiName = dataReader["FriendNiName"].ToString();
            model.MarkOld();
            return model;
        }


        #endregion 读

        #region 写

        public int FriendList_Add(BLL.FriendList model)
        {
            return FriendList_Add(model, null);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int FriendList_Add(BLL.FriendList model, DbTransaction Trans)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("insert into {0}friendlist(", sPre);
            strSql.Append("FriendName,IsAllow,AddDate,UserID,UserName,UserNiName,FriendID,FriendNiName)");
            strSql.Append(" values (");
            strSql.Append("?FriendName,?IsAllow,?AddDate,?UserID,?UserName,?UserNiName,?FriendID,?FriendNiName)");
            strSql.Append(";SELECT @@session.identity");
            MySqlParameter[] parameters = {
					new MySqlParameter("?FriendName", MySqlDbType.VarChar,50),
					new MySqlParameter("?IsAllow", MySqlDbType.Int16,1),
					new MySqlParameter("?AddDate", MySqlDbType.Datetime),
					new MySqlParameter("?UserID",  MySqlDbType.Int32,4),
					new MySqlParameter("?UserName", MySqlDbType.VarChar,50),
					new MySqlParameter("?UserNiName", MySqlDbType.VarChar,50),
					new MySqlParameter("?FriendID",  MySqlDbType.Int32,4),
					new MySqlParameter("?FriendNiName", MySqlDbType.VarChar,50)};
            parameters[0].Value = model.FriendName;
            parameters[1].Value = model.IsAllow;
            parameters[2].Value = model.AddDate;
            parameters[3].Value = model.UserID;
            parameters[4].Value = model.UserName;
            parameters[5].Value = model.UserNiName;
            parameters[6].Value = model.FriendID;
            parameters[7].Value = model.FriendNiName;

            //object obj = DbHelperCmsWrite.Instance.ExecuteScalar(CommandType.Text, strSql.ToString(), parameters);
            //if (obj == null)
            //{
            //    return 1;
            //}
            //else
            //{
            //    return Convert.ToInt32(obj);
            //}
            object obj = null;
            if (Equals(Trans, null))
            {
                obj = DbHelperCmsWrite.Instance.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
            }
            else
            {
                obj = DbHelperCmsWrite.Instance.ExecuteNonQuery(Trans, CommandType.Text, strSql.ToString(), parameters);
            }

            if (Equals(obj, null))
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
        public void FriendList_Update(BLL.FriendList model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("update {0}friendlist set ", sPre);
            strSql.Append("FriendName=?FriendName,");
            strSql.Append("IsAllow=?IsAllow,");
            strSql.Append("AddDate=?AddDate,");
            strSql.Append("UserID=?UserID,");
            strSql.Append("UserName=?UserName,");
            strSql.Append("UserNiName=?UserNiName,");
            strSql.Append("FriendID=?FriendID,");
            strSql.Append("FriendNiName=?FriendNiName");
            strSql.Append(" where ID=?ID ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?ID",  MySqlDbType.Int32,4),
					new MySqlParameter("?FriendName", MySqlDbType.VarChar,50),
					new MySqlParameter("?IsAllow", MySqlDbType.Int16,1),
					new MySqlParameter("?AddDate", MySqlDbType.Datetime),
					new MySqlParameter("?UserID",  MySqlDbType.Int32,4),
					new MySqlParameter("?UserName", MySqlDbType.VarChar,50),
					new MySqlParameter("?UserNiName", MySqlDbType.VarChar,50),
					new MySqlParameter("?FriendID",  MySqlDbType.Int32,4),
					new MySqlParameter("?FriendNiName", MySqlDbType.VarChar,50)};
            parameters[0].Value = model.Id;
            parameters[1].Value = model.FriendName;
            parameters[2].Value = model.IsAllow;
            parameters[3].Value = model.AddDate;
            parameters[4].Value = model.UserID;
            parameters[5].Value = model.UserName;
            parameters[6].Value = model.UserNiName;
            parameters[7].Value = model.FriendID;
            parameters[8].Value = model.FriendNiName;

            DbHelperCmsWrite.Instance.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void FriendList_Delete(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("delete from {0}friendlist ", sPre);
            //strSql.Append(" where (UserName=?UserName and FriendName=?FriendName) or (UserName=?FriendName and FriendName=?UserName)  ");
            strSql.Append(" where ID=?ID  ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?ID", MySqlDbType.Int32,4)
                                        };
            parameters[0].Value = ID;

            DbHelperCmsWrite.Instance.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }
        public bool FriendList_Allow(BLL.FriendList model)
        {
            MySqlConnection cn = new MySqlConnection(DbHelperCmsWrite.Instance.ConnectionString());
            cn.Open();
            MySqlTransaction tran = cn.BeginTransaction();  //创建事务
            bool isok = false;
            try
            {

                StringBuilder strSql1 = new StringBuilder();
                strSql1.AppendFormat("update {0}friendlist set ", sPre);
                strSql1.Append("IsAllow=1");
                strSql1.AppendFormat(" where ID={0} ", model.Id);
                DbHelperCmsWrite.Instance.ExecuteScalar(tran, CommandType.Text, strSql1.ToString());

                BLL.FriendList model2 = new FriendList();
                model2.AddDate = DateTime.Now;
                model2.FriendID = model.UserID;
                model2.FriendName = model.UserName;
                model2.FriendNiName = model.UserNiName;
                model2.IsAllow = true;
                model2.UserID = model.FriendID;
                model2.UserName = model.FriendName;
                model2.UserNiName = model.FriendNiName;

                FriendList_Add(model2, tran);
                //提交事务
                tran.Commit();
                isok = true;
            }
            catch
            {
                //出错回滚
                tran.Rollback();
                isok = false;
            }
            finally  //关闭联接
            {
                if (cn != null && cn.State == ConnectionState.Open)
                    cn.Close();
            }

            return isok;
        }

        #endregion 写

    }
}

