using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using EbSite.Base.DataProfile;

namespace EbSite.Data.User.SqlServer
{
    /// <summary>
    /// 数据访问类Favorite。
    /// </summary>
    public partial class DataProviderUser : Interface.IDataProviderUser
    {

        #region  成员方法
        /// <summary>
        /// 获取统计
        /// </summary>
        public int FavoriteClass_GetCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select count(*)  from {0}FavoriteClass ", sPre);
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
        /// 增加一条数据
        /// </summary>
        public int FavoriteClass_Add(EbSite.Entity.FavoriteClass model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("insert into {0}FavoriteClass(", sPre);

            strSql.Append("ClassName,UserName,UserID,UserNiName,Adddatetime,Orderid,Parentid,Annex1,Annex2,Annex3,Annex4,Annex5)");
            strSql.Append(" values (");
            strSql.Append("@ClassName,@UserName,@UserID,@UserNiName,@Adddatetime,@Orderid,@Parentid,@Annex1,@Annex2,@Annex3,@Annex4,@Annex5)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					
					new SqlParameter("@ClassName", SqlDbType.NVarChar,50),
                    new SqlParameter("@UserName", SqlDbType.NVarChar,50),
					new SqlParameter("@UserID", SqlDbType.Int,4),
					new SqlParameter("@UserNiName", SqlDbType.NVarChar,50),
                    new SqlParameter("@Adddatetime",SqlDbType.DateTime),
                    new SqlParameter("@Orderid",SqlDbType.Int,4),
                    new SqlParameter("@Parentid",SqlDbType.Int,4),

                    
                    new SqlParameter("@Annex1",SqlDbType.NVarChar,1000),
                    new SqlParameter("@Annex2",SqlDbType.NVarChar,1000),
                    new SqlParameter("@Annex3",SqlDbType.NVarChar,1000),
                    new SqlParameter("@Annex4", SqlDbType.Int,4),
					new SqlParameter("@Annex5", SqlDbType.Int,4)
                   };
            parameters[0].Value = model.ClassName;
            parameters[1].Value = model.UserName;
            parameters[2].Value = model.UserID;
            parameters[3].Value = model.UserNiName;

            parameters[4].Value = model.Adddatetime;
            parameters[5].Value = model.Orderid;
            parameters[6].Value = model.Parentid;

            parameters[7].Value = model.Annex1;
            parameters[8].Value = model.Annex2;
            parameters[9].Value = model.Annex3;
            parameters[10].Value = model.Annex4;
            parameters[11].Value = model.Annex5;



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
        public void FavoriteClass_Update(Entity.FavoriteClass model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("update {0}FavoriteClass set ", sPre);
            strSql.Append("ClassName=@ClassName,");
            strSql.Append("UserName=@UserName,");
            strSql.Append("UserID=@UserID,");
            strSql.Append("UserNiName=@UserNiName,");

            strSql.Append("Adddatetime=@Adddatetime,");
            strSql.Append("Orderid=@Orderid,");
            strSql.Append("Parentid=@Parentid,");

            strSql.Append("Annex1=@Annex1,");
            strSql.Append("Annex2=@Annex2,");
            strSql.Append("Annex3=@Annex3,");
            strSql.Append("Annex4=@Annex4,");
            strSql.Append("Annex5=@Annex5");

            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@ClassName", SqlDbType.NVarChar,50),
					new SqlParameter("@UserName", SqlDbType.NVarChar,50),
					new SqlParameter("@UserID", SqlDbType.Int,4),
					new SqlParameter("@UserNiName", SqlDbType.NVarChar,50),


                    new SqlParameter("@Adddatetime",SqlDbType.DateTime),
                    new SqlParameter("@Orderid",SqlDbType.Int,4),
                    new SqlParameter("@Parentid",SqlDbType.Int,4),

                    new SqlParameter("@Annex1",SqlDbType.NVarChar,1000),
                    new SqlParameter("@Annex2",SqlDbType.NVarChar,1000),
                    new SqlParameter("@Annex3",SqlDbType.NVarChar,1000),
                    new SqlParameter("@Annex4", SqlDbType.Int,4),
					new SqlParameter("@Annex5", SqlDbType.Int,4)
					};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.ClassName;
            parameters[2].Value = model.UserName;
            parameters[3].Value = model.UserID;
            parameters[4].Value = model.UserNiName;

            parameters[5].Value = model.Adddatetime;
            parameters[6].Value = model.Orderid;
            parameters[7].Value = model.Parentid;

            parameters[8].Value = model.Annex1;
            parameters[9].Value = model.Annex2;
            parameters[10].Value = model.Annex3;
            parameters[11].Value = model.Annex4;
            parameters[12].Value = model.Annex5;

            DbHelperUser.Instance.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }
        /// <summary>
        /// 删除一条数据-内容
        /// </summary>
        public void FavoriteClass_DeleteOFClass(int ID, string UserName)
        {
            //ID,ClassName,UserName,UserID,UserNiName
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("delete from {0}FavoriteClass ", sPre);
            strSql.Append(" where id=@ID AND UserName=@UserName  ");
            SqlParameter[] parameters = {
                    new SqlParameter("@ID", SqlDbType.Int,4),
                    new SqlParameter("@UserName", SqlDbType.NVarChar,100)};
            parameters[0].Value = ID;
            parameters[1].Value = UserName;

            DbHelperUser.Instance.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public List<EbSite.Entity.FavoriteClass> FavoriteClass_GetListArr(int Top, string strWhere, string filedOrder)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" ID,ClassName,UserName,UserID,UserNiName,Adddatetime,Orderid,Parentid,Annex1,Annex2,Annex3,Annex4,Annex5 ");
            strSql.AppendFormat(" FROM  {0}FavoriteClass ", sPre);
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            List<EbSite.Entity.FavoriteClass> list = new List<EbSite.Entity.FavoriteClass>();

            using (IDataReader dataReader = DbHelperUser.Instance.ExecuteReader(CommandType.Text, strSql.ToString()))
            {
                while (dataReader.Read())
                {
                    list.Add(FavoriteClass_ReaderBind(dataReader));
                }
            }
            return list;
        }
        /// <summary>
        /// 对象实体绑定数据
        /// </summary>
        public EbSite.Entity.FavoriteClass FavoriteClass_ReaderBind(IDataReader dataReader)
        {
            Entity.FavoriteClass model = new Entity.FavoriteClass();

            if (dataReader["ID"].ToString() != "")
            {
                model.ID = int.Parse(dataReader["ID"].ToString());
            }

            model.ClassName = dataReader["ClassName"].ToString();
            model.UserName = dataReader["UserName"].ToString();

            if (dataReader["UserID"].ToString() != "")
            {
                model.UserID = int.Parse(dataReader["UserID"].ToString());
            }

            model.UserNiName = dataReader["UserNiName"].ToString();

            if (dataReader["Adddatetime"].ToString() != "")
            {
                model.Adddatetime = DateTime.Parse(dataReader["Adddatetime"].ToString());
            }
            if (dataReader["Orderid"].ToString() != "")
            {
                model.Orderid = int.Parse(dataReader["Orderid"].ToString());
            }
            if (dataReader["Parentid"].ToString() != "")
            {
                model.Parentid = int.Parse(dataReader["Parentid"].ToString());
            }

            model.Annex1 = dataReader["Annex1"].ToString();
            model.Annex2 = dataReader["Annex2"].ToString();
            model.Annex3 = dataReader["Annex3"].ToString();
            if (dataReader["Annex4"].ToString() != "")
            {
                model.Annex4 = Core.Utils.StrToInt(dataReader["Annex4"].ToString(), 0);
            }
            if (dataReader["Annex5"].ToString() != "")
            {
                model.Annex5 = Core.Utils.StrToInt(dataReader["Annex5"].ToString(), 0);
            }

            return model;
        }
        /// <summary>
        /// 获得分页数据
        /// </summary>
        public List<Entity.FavoriteClass> FavoriteClass_GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby, out int RecordCount)
        {
            List<Entity.FavoriteClass> list = new List<Entity.FavoriteClass>();
            using (IDataReader dataReader = SplitPages.GetListPages_SP("FavoriteClass", PageSize, PageIndex, Fileds, "id", oderby, strWhere, out RecordCount, sPre))
            {
                while (dataReader.Read())
                {
                    list.Add(FavoriteClass_ReaderBind(dataReader));
                }
            }
            return list;
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public EbSite.Entity.FavoriteClass FavoriteClass_GetModel(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select  top 1 ID,ClassName,UserName,UserID,UserNiName,AddDateTime,OrderID,ParentID,Annex1,Annex2,Annex3,Annex4,Annex5 from  {0}FavoriteClass ", sPre);
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = ID;

            Entity.FavoriteClass model = new Entity.FavoriteClass();
            using (IDataReader dataReader = DbHelperUser.Instance.ExecuteReader(CommandType.Text, strSql.ToString(), parameters))
            {
                if (dataReader.Read())
                {
                    model = FavoriteClass_ReaderBind(dataReader);

                }
            }
            return model;
        }


        #endregion  成员方法
    }
}

