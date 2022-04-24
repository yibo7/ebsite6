using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using EbSite.Base.DataProfile;
using MySql.Data.MySqlClient;
namespace EbSite.Modules.Shop.ModuleCore.DAL.MySql
{
    /// <summary>
    /// 数据访问类Shop。
    /// </summary>
    public partial class Shop
    {
        private string sFieldTypeRelationProduct = "ID,AttributeId,UsageMode,ProductID,Item";
        #region  成员方法

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int TypeRelationProduct_GetMaxId()
        {
            return DB.GetMaxID("ID", string.Format("{0}TypeRelationProduct", sPre));
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool TypeRelationProduct_Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select count(1) from {0}TypeRelationProduct", sPre);
            strSql.Append(" where ID=?ID ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?ID", MySqlDbType.Int32,4)};
            parameters[0].Value = ID;

            return DB.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int TypeRelationProduct_Add(Entity.TypeRelationProduct model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("insert into {0}TypeRelationProduct(", sPre);
            strSql.Append("AttributeId,UsageMode,ProductID,Item)");
            strSql.Append(" values (");
            strSql.Append("?AttributeId,?UsageMode,?ProductID,?Item)");
            strSql.Append(";select @@IDENTITY");
            MySqlParameter[] parameters = {
					
					new MySqlParameter("?AttributeId", MySqlDbType.VarChar,30),
					new MySqlParameter("?UsageMode", MySqlDbType.Int32,4),
					
					new MySqlParameter("?ProductID", MySqlDbType.Int32,4),
					new MySqlParameter("?Item", MySqlDbType.Int32,4)};
            parameters[0].Value = model.AttributeId;
            parameters[1].Value = model.UsageMode;
            parameters[2].Value = model.ProductID;
            parameters[3].Value = model.Item;

            object obj = DB.ExecuteScalar(CommandType.Text, strSql.ToString(), parameters);
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
        public void TypeRelationProduct_Update(Entity.TypeRelationProduct model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("update {0}TypeRelationProduct set ", sPre);
            strSql.Append("AttributeId=?AttributeId,");
            strSql.Append("UsageMode=?UsageMode,");
            strSql.Append("ProductID=?ProductID,");
            strSql.Append("Item=?Item");


            strSql.Append(" where ID=?ID ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?ID", MySqlDbType.Int32,4),
					new MySqlParameter("?AttributeId", MySqlDbType.VarChar,30),
				
					new MySqlParameter("?ProductID", MySqlDbType.Int32,4),
					new MySqlParameter("?Item", MySqlDbType.Int32,4)};
            parameters[0].Value = model.id;
            parameters[1].Value = model.AttributeId;
            parameters[2].Value = model.UsageMode;
            parameters[3].Value = model.ProductID;
            parameters[4].Value = model.Item;


            DB.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void TypeRelationProduct_Delete(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("delete from {0}TypeRelationProduct ", sPre);
            strSql.Append(" where ID=?ID ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?ID", MySqlDbType.Int32,4)};
            parameters[0].Value = ID;

            DB.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Entity.TypeRelationProduct TypeRelationProduct_GetEntity(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select " + sFieldTypeRelationProduct + "  from {0}TypeRelationProduct ", sPre);
            strSql.Append(" where ID=?ID ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?ID", MySqlDbType.Int32,4)};
            parameters[0].Value = ID;
            Entity.TypeRelationProduct model = null;
            using (IDataReader dataReader = DB.ExecuteReader(CommandType.Text, strSql.ToString(), parameters))
            {
                if (dataReader.Read())
                {
                    model = TypeRelationProduct_ReaderBind(dataReader);
                }
            }
            return model;
        }
        /// <summary>
        /// 获取统计
        /// </summary>
        public int TypeRelationProduct_GetCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select count(*)  from {0}TypeRelationProduct ", sPre);
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
        public DataSet TypeRelationProduct_GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");

            strSql.Append(sFieldTypeRelationProduct);
            strSql.AppendFormat(" FROM {0}TypeRelationProduct ", sPre);
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
        public List<Entity.TypeRelationProduct> TypeRelationProduct_GetListArray(string strWhere)
        {
            return TypeRelationProduct_GetListArray(0, strWhere, "");
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public List<Entity.TypeRelationProduct> TypeRelationProduct_GetListArray(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");

            strSql.Append(sFieldTypeRelationProduct);
            strSql.AppendFormat(" FROM {0}TypeRelationProduct ", sPre);
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
            List<Entity.TypeRelationProduct> list = new List<Entity.TypeRelationProduct>();
            using (IDataReader dataReader = DB.ExecuteReader(CommandType.Text, strSql.ToString()))
            {
                while (dataReader.Read())
                {
                    list.Add(TypeRelationProduct_ReaderBind(dataReader));
                }
            }
            return list;
        }


        /// <summary>
        /// 获得分页数据
        /// </summary>
        public List<Entity.TypeRelationProduct> TypeRelationProduct_GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby, out int RecordCount)
        {
            StringBuilder sbSql = new StringBuilder();
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                sbSql.Append(" where ");
                sbSql.AppendFormat(strWhere);
            }
            RecordCount = TypeRelationProduct_GetCount(sbSql.ToString());
            List<Entity.TypeRelationProduct> list = new List<Entity.TypeRelationProduct>();
            string strSql = SplitPages.GetSplitPagesMySql(DB, "TypeRelationProduct", PageSize, PageIndex, Fileds, "id", oderby, sbSql.ToString(), sPre);
            using (IDataReader dataReader = DB.ExecuteReader(CommandType.Text, strSql))
            {
                while (dataReader.Read())
                {
                    list.Add(TypeRelationProduct_ReaderBind(dataReader));
                }
            }
            return list;
        }


        /// <summary>
        /// 对象实体绑定数据
        /// </summary>
        public Entity.TypeRelationProduct TypeRelationProduct_ReaderBind(IDataReader dataReader)
        {
            Entity.TypeRelationProduct model = new Entity.TypeRelationProduct();
            object ojb;
            ojb = dataReader["ID"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.id = (int)ojb;
            }
            model.AttributeId = dataReader["AttributeId"].ToString();
            ojb = dataReader["UsageMode"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.UsageMode = (int)ojb;
            }
            ojb = dataReader["ProductID"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.ProductID = (int)ojb;
            }

            ojb = dataReader["Item"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.Item = (int)ojb;
            }
          
            return model;
        }

        #endregion  成员方法
    }
}

