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
        public int Favorite_GetCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select count(*)  from {0}Favorite ", sPre);
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
        public int Favorite_Add(EbSite.Entity.Favorite model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("insert into {0}Favorite(", sPre);

            strSql.Append("ContentID,ClassID,FavType,AddDateTime,UserName,UserID,UserNiName,Title,Description,Tagids,Annex1,Annex2,Annex3,Annex4,Annex5,LinkUrl)");
            strSql.Append(" values (");
            strSql.Append("@ContentID,@ClassID,@FavType,@AddDateTime,@UserName,@UserID,@UserNiName,@Title,@Description,@Tagids,@Annex1,@Annex2,@Annex3,@Annex4,@Annex5,@LinkUrl)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                    new SqlParameter("@ContentID", SqlDbType.Int,4),
                    new SqlParameter("@ClassID", SqlDbType.Int,4),
                    new SqlParameter("@FavType", SqlDbType.Int,4),
                    new SqlParameter("@AddDateTime", SqlDbType.DateTime),
                    new SqlParameter("@UserName", SqlDbType.NVarChar,50),
                    new SqlParameter("@UserID", SqlDbType.Int,4),
                    new SqlParameter("@UserNiName", SqlDbType.NVarChar,50),
                    new SqlParameter("@Title",SqlDbType.NVarChar,200),
                    new SqlParameter("@Description", SqlDbType.NVarChar,1000),
                    new SqlParameter("@Tagids",SqlDbType.NVarChar,200),

                    new SqlParameter("@Annex1",SqlDbType.NVarChar,1000),
                    new SqlParameter("@Annex2",SqlDbType.NVarChar,1000),
                    new SqlParameter("@Annex3",SqlDbType.NVarChar,1000),
                    new SqlParameter("@Annex4", SqlDbType.Int,4),
                    new SqlParameter("@Annex5", SqlDbType.Int,4),
                    new SqlParameter("@LinkUrl",SqlDbType.NVarChar,200)
                   
                                        };
            parameters[0].Value = model.ContentID;
            parameters[1].Value = model.ClassID;
            parameters[2].Value = model.FavType;
            parameters[3].Value = model.AddDateTime;
            parameters[4].Value = model.UserName;
            parameters[5].Value = model.UserID;
            parameters[6].Value = model.UserNiName;
            parameters[7].Value = model.Title;
            parameters[8].Value = model.Description;
            parameters[9].Value = model.Tagids;

            parameters[10].Value = model.Annex1;
            parameters[11].Value = model.Annex2;
            parameters[12].Value = model.Annex3;
            parameters[13].Value = model.Annex4;
            parameters[14].Value = model.Annex5;

            parameters[15].Value = model.LinkUrl;



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
        public void Favorite_Update(Entity.Favorite model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("update {0}Favorite set ", sPre);
            strSql.Append("ContentID=@ContentID,");
            strSql.Append("ClassID=@ClassID,");
            strSql.Append("FavType=@FavType,");
            strSql.Append("AddDateTime=@AddDateTime,");
            strSql.Append("UserName=@UserName,");
            strSql.Append("UserID=@UserID,");
            strSql.Append("UserNiName=@UserNiName,");
            strSql.Append("Title=@Title,");
            strSql.Append("Description=@Description,");
            strSql.Append("Tagids=@Tagids,");

            strSql.Append("Annex1=@Annex1,");
            strSql.Append("Annex2=@Annex2,");
            strSql.Append("Annex3=@Annex3,");
            strSql.Append("Annex4=@Annex4,");
            strSql.Append("Annex5=@Annex5,");

            strSql.Append("LinkUrl=@LinkUrl");
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
                    new SqlParameter("@id", SqlDbType.Int,4),
                    new SqlParameter("@ContentID", SqlDbType.Int,4),
                    new SqlParameter("@ClassID", SqlDbType.Int,4),
                    new SqlParameter("@FavType", SqlDbType.Int,4),
                    new SqlParameter("@AddDateTime", SqlDbType.DateTime),
                    new SqlParameter("@UserName", SqlDbType.NVarChar,50),
                    new SqlParameter("@UserID", SqlDbType.Int,4),
                    new SqlParameter("@UserNiName", SqlDbType.NVarChar,50),
                    new SqlParameter("@Title", SqlDbType.NVarChar,250),
                    new SqlParameter("@Description", SqlDbType.NVarChar,1000),
                    new SqlParameter("@Tagids",SqlDbType.NVarChar,200),

                    new SqlParameter("@Annex1",SqlDbType.NVarChar,1000),
                    new SqlParameter("@Annex2",SqlDbType.NVarChar,1000),
                    new SqlParameter("@Annex3",SqlDbType.NVarChar,1000),
                    new SqlParameter("@Annex4", SqlDbType.Int,4),
                    new SqlParameter("@Annex5", SqlDbType.Int,4),
                    new SqlParameter("@LinkUrl",SqlDbType.NVarChar,200)
                   
                    

                    };
            parameters[0].Value = model.ID;
            parameters[1].Value = model.ContentID;
            parameters[2].Value = model.ClassID;
            parameters[3].Value = model.FavType;
            parameters[4].Value = model.AddDateTime;
            parameters[5].Value = model.UserName;
            parameters[6].Value = model.UserID;
            parameters[7].Value = model.UserNiName;
            parameters[8].Value = model.Title;
            parameters[9].Value = model.Description;
            parameters[10].Value = model.Tagids;

            parameters[11].Value = model.Annex1;
            parameters[12].Value = model.Annex2;
            parameters[13].Value = model.Annex3;
            parameters[14].Value = model.Annex4;
            parameters[15].Value = model.Annex5;

            parameters[16].Value = model.LinkUrl;

            DbHelperUser.Instance.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }
        /// <summary>
        /// 删除一条数据-内容
        /// </summary>
        public void Favorite_DeleteOFContent(int ContentID, string UserName)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("delete from {0}Favorite ", sPre);
            strSql.Append(" where ID=@ID AND UserName=@UserName and FavType=0 ");
            SqlParameter[] parameters = {
                    new SqlParameter("@ID", SqlDbType.Int,4),
                    new SqlParameter("@UserName", SqlDbType.NVarChar,100)};
            parameters[0].Value = ContentID;
            parameters[1].Value = UserName;

            DbHelperUser.Instance.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }
        /// <summary>
        /// 删除一条数据-分类
        /// </summary>
        public void Favorite_DeleteOFClass(int ContentID, string UserName)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("delete from {0}Favorite ", sPre);
            strSql.Append(" where ID=@ID AND UserName=@UserName and FavType=1 ");
            SqlParameter[] parameters = {
                    new SqlParameter("@ID", SqlDbType.Int,4),
                    new SqlParameter("@UserName", SqlDbType.NVarChar,100)};
            parameters[0].Value = ContentID;
            parameters[1].Value = UserName;

            DbHelperUser.Instance.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public List<EbSite.Entity.Favorite> Favorite_GetListArr(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" ID,ContentID,ClassID,FavType,AddDateTime,UserName,UserID,UserNiName,Title,Description,Tagids,Annex1,Annex2,Annex3,Annex4,Annex5,LinkUrl ");
            strSql.AppendFormat(" FROM  {0}Favorite ", sPre);
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            List<EbSite.Entity.Favorite> list = new List<EbSite.Entity.Favorite>();

            using (IDataReader dataReader = DbHelperUser.Instance.ExecuteReader(CommandType.Text, strSql.ToString()))
            {
                while (dataReader.Read())
                {
                    list.Add(Favorite_ReaderBind(dataReader));
                }
            }
            return list;
        }
        /// <summary>
        /// 对象实体绑定数据
        /// </summary>
        public EbSite.Entity.Favorite Favorite_ReaderBind(IDataReader dataReader)
        {
            Entity.Favorite model = new Entity.Favorite();

            if (dataReader["ID"].ToString() != "")
            {
                model.ID = int.Parse(dataReader["ID"].ToString());
            }
            if (dataReader["ContentID"].ToString() != "")
            {
                model.ContentID = int.Parse(dataReader["ContentID"].ToString());
            }
            if (dataReader["ClassID"].ToString() != "")
            {
                model.ClassID = int.Parse(dataReader["ClassID"].ToString());
            }
            if (dataReader["FavType"].ToString() != "")
            {
                model.FavType = int.Parse(dataReader["FavType"].ToString());
            }
            if (dataReader["AddDateTime"].ToString() != "")
            {
                model.AddDateTime = DateTime.Parse(dataReader["AddDateTime"].ToString());
            }
            model.UserName = dataReader["UserName"].ToString();
            if (dataReader["UserID"].ToString() != "")
            {
                model.UserID = int.Parse(dataReader["UserID"].ToString());
            }
            model.UserNiName = dataReader["UserNiName"].ToString();
            model.Title = dataReader["Title"].ToString();
            model.Description = dataReader["Description"].ToString();

            model.Tagids = dataReader["Tagids"].ToString();


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

            model.LinkUrl = dataReader["LinkUrl"].ToString();

            return model;
        }
        /// <summary>
        /// 获得分页数据
        /// </summary>
        public List<Entity.Favorite> Favorite_GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby, out int RecordCount)
        {
            List<Entity.Favorite> list = new List<Entity.Favorite>();
            using (IDataReader dataReader = SplitPages.GetListPages_SP("Favorite", PageSize, PageIndex, Fileds, "id", oderby, strWhere, out RecordCount, sPre))
            {
                while (dataReader.Read())
                {
                    list.Add(Favorite_ReaderBind(dataReader));
                }
            }
            return list;
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public EbSite.Entity.Favorite Favorite_GetModel(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select  top 1 ID,ContentID,ClassID,FavType,AddDateTime,UserName,UserID,UserNiName,Title,Description,Tagids,Annex1,Annex2,Annex3,Annex4,Annex5,LinkUrl  from  {0}Favorite ", sPre);
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
                    new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = ID;

            Entity.Favorite model = new Entity.Favorite();
            using (IDataReader dataReader = DbHelperUser.Instance.ExecuteReader(CommandType.Text, strSql.ToString(), parameters))
            {
                if (dataReader.Read())
                {
                    model = Favorite_ReaderBind(dataReader);

                }
            }
            return model;
        }
        #endregion  成员方法
        public void Favorite_DeleteInIDs(string IDs)
        {
            if (!string.IsNullOrEmpty(IDs))
            {
                StringBuilder strSql = new StringBuilder();
                strSql.AppendFormat("delete from {0}Favorite ", sPre);
                strSql.AppendFormat(" where ID in({0}) ", IDs);
                DbHelperUser.Instance.ExecuteNonQuery(CommandType.Text, strSql.ToString(), null);
            }

        }

    }
}

