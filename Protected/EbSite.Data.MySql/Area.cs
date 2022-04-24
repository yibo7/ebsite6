using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;
using EbSite.Entity;
using MySql.Data.MySqlClient;
using EbSite.Base.DataProfile;//请先添加引用

namespace EbSite.Data.MySql
{
    /// <summary>
    /// 数据访问类area。
    /// </summary>
    public partial class DataProviderCms : Interface.IDataProviderCms
    {
        private string sFieldAreaInfo = "id,Name,OrderID,HeadID,Level";
        #region  成员方法

       
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Entity.AreaInfo AreaInfo_GetEntity(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select " + sFieldAreaInfo + "  from {0}areainfo ", sPre);
            strSql.Append(" where ID=?ID");
            MySqlParameter[] parameters = {
                                            	new MySqlParameter("@id", MySqlDbType.Int32,4)
                                        };
            parameters[0].Value = id;
            Entity.AreaInfo model = new AreaInfo();
            using (IDataReader dataReader = DbHelperCms.Instance.ExecuteReader(CommandType.Text, strSql.ToString(), parameters))
            {
                if (dataReader.Read())
                {
                    model = AreaInfo_ReaderBind(dataReader);
                }
            }
            return model;
        }
        /// <summary>
        /// 获取统计
        /// </summary>
        public int AreaInfo_GetCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select count(*)  from {0}areainfo ", sPre);
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            int iCount = 0;
            using (IDataReader dataReader = DbHelperCms.Instance.ExecuteReader(CommandType.Text, strSql.ToString()))
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
        public DataSet AreaInfo_GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
           
            strSql.Append(sFieldAreaInfo);
            strSql.AppendFormat(" FROM {0}areainfo ", sPre);
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
                strSql.Append(" limit ");
                strSql.Append(Top);
            }
            return DbHelperCms.Instance.ExecuteDataset(CommandType.Text, strSql.ToString());
        }

        /// <summary>
        /// 获得数据列表（比DataSet效率高，推荐使用）
        /// </summary>
        public List<Entity.AreaInfo> AreaInfo_GetListArray(string strWhere)
        {
            return AreaInfo_GetListArray(0, strWhere, "");
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public List<Entity.AreaInfo> AreaInfo_GetListArray(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
           
            strSql.Append(sFieldAreaInfo);
            strSql.AppendFormat(" FROM {0}areainfo ", sPre);
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
                strSql.Append(" limit ");
                strSql.Append(Top);
            }
            List<Entity.AreaInfo> list = new List<Entity.AreaInfo>();
            using (IDataReader dataReader = DbHelperCms.Instance.ExecuteReader(CommandType.Text, strSql.ToString()))
            {
                while (dataReader.Read())
                {
                    list.Add(AreaInfo_ReaderBind(dataReader));
                }
            }
            return list;
        }


        /// <summary>
        /// 获得分页数据
        /// </summary>
        public List<Entity.AreaInfo> AreaInfo_GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby, out int RecordCount)
        {
          
            List<Entity.AreaInfo> list = new List<Entity.AreaInfo>();
            string strSql = SplitPages.GetSplitPagesMySql(DbHelperCms.Instance, "areainfo", PageSize, PageIndex, "", "id", oderby, strWhere, sPre);
            RecordCount = AreaInfo_GetCount(strWhere);
            using (IDataReader dataReader = DbHelperCms.Instance.ExecuteReader(CommandType.Text, strSql))
            {
                while (dataReader.Read())
                {
                    list.Add(AreaInfo_ReaderBind(dataReader));
                }
            }
            return list;         
        }


        /// <summary>
        /// 对象实体绑定数据
        /// </summary>
        public Entity.AreaInfo AreaInfo_ReaderBind(IDataReader dataReader)
        {
            Entity.AreaInfo model = new Entity.AreaInfo();
            object ojb;
            ojb = dataReader["id"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.id = (int)ojb;
            }
            model.Name = dataReader["Name"].ToString();
            ojb = dataReader["OrderID"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.OrderID = (int)ojb;
            }
            ojb = dataReader["HeadID"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.HeadID = (int)ojb;
            }
            ojb = dataReader["Level"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.Level = (int)ojb;
            }
            return model;
        }

        #endregion  成员方法


        #region 导数据

        public bool AreaDataAllAdd(string url)
        {

            bool key = false;
            //初始化核心系统数据
            string dbscriptpath = "";
          
            string tableprefix = "";
            StringBuilder sb = new StringBuilder();
            sb.Remove(0, sb.Length);
            dbscriptpath = string.Concat(url,"InitData_Cms2.sql");
            tableprefix = EbSite.Base.Configs.BaseCinfigs.ConfigsControl.Instance.TablePrefix;

            using (StreamReader objReader = new StreamReader(dbscriptpath, Encoding.UTF8))
            {
                sb.Append(objReader.ReadToEnd());
                objReader.Close();
            }
          

            if (tableprefix.ToLower() == "eb_")
            {
                DbHelperCms.Instance.ExecuteCommandWithSplitter(sb.ToString());
            }
            else
            {
                DbHelperCms.Instance.ExecuteCommandWithSplitter(sb.ToString().Replace("eb_", tableprefix).Replace("EB_", tableprefix));
            }
            //初始化核心系统数据

            sb.Remove(0, sb.Length);
            dbscriptpath = string.Concat(url, "InitData_Cms3.sql");
            tableprefix = EbSite.Base.Configs.BaseCinfigs.ConfigsControl.Instance.TablePrefix;

            using (StreamReader objReader = new StreamReader(dbscriptpath, Encoding.UTF8))
            {
                sb.Append(objReader.ReadToEnd());
                objReader.Close();
            }
           
            if (tableprefix.ToLower() == "eb_")
            {
                DbHelperCms.Instance.ExecuteCommandWithSplitter(sb.ToString());
            }
            else
            {
                DbHelperCms.Instance.ExecuteCommandWithSplitter(sb.ToString().Replace("eb_", tableprefix).Replace("EB_", tableprefix));
            }
            //初始化核心系统数据

            sb.Remove(0, sb.Length);
            dbscriptpath = string.Concat(url, "InitData_Cms4.sql");
            tableprefix = EbSite.Base.Configs.BaseCinfigs.ConfigsControl.Instance.TablePrefix;

            using (StreamReader objReader = new StreamReader(dbscriptpath, Encoding.UTF8))
            {
                sb.Append(objReader.ReadToEnd());
                objReader.Close();
            }
           
            if (tableprefix.ToLower() == "eb_")
            {
                DbHelperCms.Instance.ExecuteCommandWithSplitter(sb.ToString());
            }
            else
            {
                DbHelperCms.Instance.ExecuteCommandWithSplitter(sb.ToString().Replace("eb_", tableprefix).Replace("EB_", tableprefix));
            }
            //初始化核心系统数据

            sb.Remove(0, sb.Length);
            dbscriptpath = string.Concat(url, "InitData_Cms5.sql");
            tableprefix = EbSite.Base.Configs.BaseCinfigs.ConfigsControl.Instance.TablePrefix;

            using (StreamReader objReader = new StreamReader(dbscriptpath, Encoding.UTF8))
            {
                sb.Append(objReader.ReadToEnd());
                objReader.Close();
            }
            
            if (tableprefix.ToLower() == "eb_")
            {
                DbHelperCms.Instance.ExecuteCommandWithSplitter(sb.ToString());
            }
            else
            {
                DbHelperCms.Instance.ExecuteCommandWithSplitter(sb.ToString().Replace("eb_", tableprefix).Replace("EB_", tableprefix));
            }
            //初始化核心系统数据

            sb.Remove(0, sb.Length);
            dbscriptpath = string.Concat(url, "InitData_Cms6.sql");
            tableprefix = EbSite.Base.Configs.BaseCinfigs.ConfigsControl.Instance.TablePrefix;

            using (StreamReader objReader = new StreamReader(dbscriptpath, Encoding.UTF8))
            {
                sb.Append(objReader.ReadToEnd());
                objReader.Close();
            }
           
            if (tableprefix.ToLower() == "eb_")
            {
                DbHelperCms.Instance.ExecuteCommandWithSplitter(sb.ToString());
            }
            else
            {
                DbHelperCms.Instance.ExecuteCommandWithSplitter(sb.ToString().Replace("eb_", tableprefix).Replace("EB_", tableprefix));
            }
            key = true;

            return key;
        }
        #endregion


        #region 写
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int AreaInfo_Add(Entity.AreaInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("insert into {0}areainfo(", sPre);
            strSql.Append("Name,OrderID,HeadID,Level)");
            strSql.Append(" values (");
            strSql.Append("@Name,@OrderID,@HeadID,@Level)");
            MySqlParameter[] parameters = {                
		                                    new MySqlParameter("@Name", MySqlDbType.VarChar, 50),
		                                    new MySqlParameter("@OrderID", MySqlDbType.Int32, 4),
		                                    new MySqlParameter("@HeadID", MySqlDbType.Int32, 4),
		                                    new MySqlParameter("@Level", MySqlDbType.Int32, 4)
		                                };

            parameters[0].Value = model.Name;
            parameters[1].Value = model.OrderID;
            parameters[2].Value = model.HeadID;
            parameters[3].Value = model.Level;

            object obj = DbHelperCmsWrite.Instance.ExecuteScalar(CommandType.Text, strSql.ToString(), parameters);
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
        public void AreaInfo_Update(Entity.AreaInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("update {0}areainfo set ", sPre);
            strSql.Append("Name=@Name,");
            strSql.Append("OrderID=@OrderID,");
            strSql.Append("HeadID=@HeadID,");
            strSql.Append("Level=@Level");
            strSql.Append(" where ID=@id ");
            MySqlParameter[] parameters = {
					new MySqlParameter("@id", MySqlDbType.Int32,4),
					new MySqlParameter("@Name", MySqlDbType.VarChar,50),
					new MySqlParameter("@OrderID", MySqlDbType.Int32,4),
					new MySqlParameter("@HeadID", MySqlDbType.Int32,4),
					new MySqlParameter("@Level", MySqlDbType.Int32,4)};
            parameters[0].Value = model.id;
            parameters[1].Value = model.Name;
            parameters[2].Value = model.OrderID;
            parameters[3].Value = model.HeadID;
            parameters[4].Value = model.Level;

            DbHelperCmsWrite.Instance.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void AreaInfo_Delete(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("delete from {0}areainfo ", sPre);
            strSql.Append(" where id=@id");
            MySqlParameter[] parameters = {
                                            	new MySqlParameter("@id", MySqlDbType.Int32,4)
                                        };
            parameters[0].Value = id;

            DbHelperCmsWrite.Instance.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }

        #endregion
    }
}

