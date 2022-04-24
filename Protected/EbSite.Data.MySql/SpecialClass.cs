using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using EbSite.Base.DataProfile;//请先添加引用
namespace EbSite.Data.MySql
{
    /// <summary>
    /// 数据访问类SpecialClass。
    /// </summary>
    public partial class DataProviderCms : Interface.IDataProviderCms
    {
        #region 读
        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int SpecialClass_GetMaxId()
        {
            return DbHelperCms.Instance.GetMaxID("id", "specialclass");
        }
        /// <summary>
        /// 获取总记录条数
        /// </summary>
        /// <returns></returns>
        public int SpecialClass_GetCount(string strWhere, int SiteID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(*) ");
            strSql.AppendFormat(" from  {0}specialclass where SiteID={1}", sPre, SiteID);

            if (strWhere.Trim() != "")
            {

                strSql.Append(" and " + strWhere);
            }
            int iCount = -1;
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
        /// 是否存在该记录
        /// </summary>
        public bool SpecialClass_Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select count(1) from  {0}specialclass", sPre);
            strSql.Append(" where id=?id ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?id",  MySqlDbType.Int32,4)};
            parameters[0].Value = id;

            return DbHelperCms.Instance.Exists(strSql.ToString(), parameters);
        }





        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public EbSite.Entity.SpecialClass SpecialClass_GetModel(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select   id,SpecialName,Orderid,Titletype,Outlink,HtmlName,ClassHtmlNameRule,SpecialTemID,SeoTitle,SeoKeyWord,SeoDescription,ParentID,RelateClassIDs,SiteID,SpecialTemIDMobile,SubClassNum,Info,IsCusttomRw from  {0}specialclass ", sPre);
            strSql.Append(" where id=?id limit 1 ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?id",  MySqlDbType.Int32,4)};
            parameters[0].Value = id;

            Entity.SpecialClass model = new Entity.SpecialClass();

            using (IDataReader dataReader = DbHelperCms.Instance.ExecuteReader(CommandType.Text, strSql.ToString(), parameters))
            {
                if (dataReader.Read())
                {
                    model = SpecialClass_ReaderBind(dataReader);
                }
            }
            return model;
        }
        public List<EbSite.Entity.SpecialClass> SpecialClass_GetListPages(int PageIndex, int PageSize, string sWhere, string oderby, int SiteID)
        {
            StringBuilder sbSql = new StringBuilder();
            sbSql.AppendFormat(" SiteID={0}", SiteID);

            if (!string.IsNullOrEmpty(sWhere.Trim()))
            {
                sbSql.Append(" and ");
                sbSql.AppendFormat(sWhere);
            }

            int RecordCount = 0;

            List<EbSite.Entity.SpecialClass> list = new List<EbSite.Entity.SpecialClass>();
            RecordCount = SpecialClass_GetCount(sbSql.ToString(), SiteID);
            string strSql = SplitPages.GetSplitPagesMySql(DbHelperCms.Instance, "SpecialClass", PageSize, PageIndex, "", "id", oderby, sbSql.ToString(), sPre);

            using (IDataReader dataReader = DbHelperCms.Instance.ExecuteReader(CommandType.Text, strSql))
            {

                while (dataReader.Read())
                {
                    list.Add(SpecialClass_ReaderBind(dataReader));
                }
            }
            return list;


        }


        /// <summary>
        /// 获得数据列表（比DataSet效率高，推荐使用）
        /// </summary>
        public List<EbSite.Entity.SpecialClass> SpecialClass_GetListArray(string strWhere, int SiteID)
        {
            return SpecialClass_GetListArray(strWhere, 0, "", SiteID);
        }
        /// <summary>
        /// 获得数据列表（比DataSet效率高，推荐使用）
        /// </summary>
        public List<EbSite.Entity.SpecialClass> SpecialClass_GetListArray(string strWhere, int iTop, string sOderby, int SiteID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            //if (iTop > 0) strSql.Append(string.Concat(" top ", iTop));
            strSql.Append(" id,SpecialName,Orderid,Titletype,Outlink,HtmlName,ClassHtmlNameRule,SpecialTemID,SeoTitle,SeoKeyWord,SeoDescription,ParentID,RelateClassIDs,SpecialTemIDMobile,SiteID ,SubClassNum,Info,IsCusttomRw");
            strSql.AppendFormat(" from  {0}specialclass where SiteID={1}", sPre, SiteID);
            if (strWhere.Trim() != "")
            {
                strSql.Append(" and " + strWhere);
            }

            // if (!string.IsNullOrEmpty(sOderby)) strSql.Append(" order by  " + sOderby + " desc");
            if (!string.IsNullOrEmpty(sOderby)) strSql.Append(" order by  " + sOderby);
            if (iTop > 0)
            {
                strSql.Append(" limit " + iTop.ToString());
            }
            List<EbSite.Entity.SpecialClass> list = new List<EbSite.Entity.SpecialClass>();
            using (IDataReader dataReader = DbHelperCms.Instance.ExecuteReader(CommandType.Text, strSql.ToString()))
            {
                while (dataReader.Read())
                {
                    list.Add(SpecialClass_ReaderBind(dataReader));
                }
            }
            return list;
        }

        public List<EbSite.Entity.SpecialClass> SpecialClass_GetListArray(string strWhere, int iTop, string sOderby)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            //if (iTop > 0) strSql.Append(string.Concat(" top ", iTop));
            strSql.Append(" id,SpecialName,Orderid,Titletype,Outlink,HtmlName,ClassHtmlNameRule,SpecialTemID,SeoTitle,SeoKeyWord,SeoDescription,ParentID,RelateClassIDs,SpecialTemIDMobile,SiteID ,SubClassNum,Info,IsCusttomRw");
            strSql.AppendFormat(" from  {0}specialclass  ", sPre);
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }

            // if (!string.IsNullOrEmpty(sOderby)) strSql.Append(" order by  " + sOderby + " desc");
            if (!string.IsNullOrEmpty(sOderby)) strSql.Append(" order by  " + sOderby);
            if (iTop > 0)
            {
                strSql.Append(" limit " + iTop.ToString());
            }
            List<EbSite.Entity.SpecialClass> list = new List<EbSite.Entity.SpecialClass>();
            using (IDataReader dataReader = DbHelperCms.Instance.ExecuteReader(CommandType.Text, strSql.ToString()))
            {
                while (dataReader.Read())
                {
                    list.Add(SpecialClass_ReaderBind(dataReader));
                }
            }
            return list;
        }

        /// <summary>
        /// 获取最大排序ID,主要用于添加分类是让排序编号递增
        /// </summary>
        /// <returns></returns>
        public int SpecialClass_GetMaxOrderID(int iParentClassID, int SiteID)
        {
            string sSql = string.Concat("select Max(OrderID)  from  ", sPre, "SpecialClass where SiteID=", SiteID, " and Parentid=", iParentClassID);
            object MaxID = DbHelperCms.Instance.ExecuteScalar(CommandType.Text, sSql);
            if (MaxID != null && !string.IsNullOrEmpty(MaxID.ToString()))
            {
                return int.Parse(MaxID.ToString());
            }
            else
            {
                return 0;
            }


        }



        /// <summary>
        /// 对象实体绑定数据
        /// </summary>
        public EbSite.Entity.SpecialClass SpecialClass_ReaderBind(IDataReader dataReader)
        {
            EbSite.Entity.SpecialClass model = new EbSite.Entity.SpecialClass();
            model = new Entity.SpecialClass();
            if (dataReader["id"].ToString() != "")
            {
                model.id = int.Parse(dataReader["id"].ToString());
            }


            model.SpecialName = dataReader["SpecialName"].ToString();
            if (dataReader["Orderid"].ToString() != "")
            {
                model.Orderid = int.Parse(dataReader["Orderid"].ToString());
            }
            model.Titletype = dataReader["Titletype"].ToString();
            model.Outlink = dataReader["Outlink"].ToString();
            model.HtmlName = dataReader["HtmlName"].ToString();
            model.ClassHtmlNameRule = dataReader["ClassHtmlNameRule"].ToString();
            if (dataReader["SpecialTemID"].ToString() != "")
            {
                model.SpecialTemID = new Guid(dataReader["SpecialTemID"].ToString());
            }
            model.SeoTitle = dataReader["SeoTitle"].ToString();
            model.SeoKeyWord = dataReader["SeoKeyWord"].ToString();
            model.SeoDescription = dataReader["SeoDescription"].ToString();

            if (dataReader["ParentID"].ToString() != "")
            {
                model.ParentID = int.Parse(dataReader["ParentID"].ToString());
            }

            model.RelateClassIDs = dataReader["RelateClassIDs"].ToString();
            if (dataReader["SiteID"].ToString() != "")
            {
                model.SiteID = int.Parse(dataReader["SiteID"].ToString());
            }
            if (dataReader["SpecialTemIDMobile"].ToString() != "")
            {
                model.SpecialTemIDMobile = new Guid(dataReader["SpecialTemIDMobile"].ToString());
            }
            if (dataReader["SubClassNum"].ToString() != "")
            {
                model.SubClassNum = int.Parse(dataReader["SubClassNum"].ToString());
            }
            if (dataReader["Info"].ToString() != "")
            {
                model.Info = dataReader["Info"].ToString();
            }

            if (dataReader["IsCusttomRw"].ToString() != "")
            {
                if ((dataReader["IsCusttomRw"].ToString() == "1") || (dataReader["IsCusttomRw"].ToString().ToLower() == "true"))
                {
                    model.IsCusttomRw = true;
                }
                else
                {
                    model.IsCusttomRw = false;
                }
                
            }
            

            return model;
        }

        public List<int> SpecialClass_GetSubID(int iParentID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID ");
            strSql.AppendFormat(" from  {0}specialclass Where ParentID={1}", sPre, iParentID);
            List<int> iList = new List<int>();
            using (IDataReader dataReader = DbHelperCms.Instance.ExecuteReader(CommandType.Text, strSql.ToString()))
            {
                while (dataReader.Read())
                {
                    int iID = int.Parse(dataReader[0].ToString());

                    iList.Add(iID);

                }
            }
            return iList;
        }
        public List<EbSite.Entity.SpecialClass> SpecialClass_GetParents(int cid, string OrderBy)
        {
            if (string.IsNullOrEmpty(OrderBy))
                OrderBy = "id desc";
            MySqlParameter[] parameters = new MySqlParameter[] { new MySqlParameter("?p_ID", MySqlDbType.Int32, 4), new MySqlParameter("?p_Orderby", MySqlDbType.VarChar, 50) };
            parameters[0].Value = cid;
            parameters[1].Value = OrderBy;
            List<EbSite.Entity.SpecialClass> list = new List<Entity.SpecialClass>();


            using (IDataReader dataReader = DbHelperCms.Instance.ExecuteReader(CommandType.StoredProcedure, string.Format("{0}ProcSpecialClassFoo", sPre), parameters))
            {
                while (dataReader.Read())
                {
                    EbSite.Entity.SpecialClass md = new Entity.SpecialClass();
                    md.id = dataReader.GetInt32(0);
                    md.SpecialName = dataReader.GetString(1);
                    md.ParentID = dataReader.GetInt32(2);
                    list.Add(md);

                }
            }
            return list;
        }


        public List<EbSite.Entity.SpecialClass> SpecialClass_GetListByContentId(long ContentId, int ClassId, int Top)
        {
            string strSql =
                string.Format(
                    "SELECT * FROM  {0}specialclass WHERE id in(SELECT SpecialClassID FROM {0}specialnews WHERE NewsId={1} AND classid={2}) ORDER BY id DESC LIMIT {3} ",
                    sPre, ContentId, ClassId, Top);
            
            List<EbSite.Entity.SpecialClass> list = new List<EbSite.Entity.SpecialClass>();
            using (IDataReader dataReader = DbHelperCms.Instance.ExecuteReader(CommandType.Text, strSql))
            {
                while (dataReader.Read())
                {
                    list.Add(SpecialClass_ReaderBind(dataReader));
                }
            }
            return list;
        }

        public List<EbSite.Entity.SpecialClass> SpecialClass_GetListHtmlNameReWrite()
        {


            StringBuilder strSql = new StringBuilder();

            strSql.AppendFormat("select *  from  {0}specialclass where IsCusttomRw=1  ", sPre);

            List<EbSite.Entity.SpecialClass> list = new List<EbSite.Entity.SpecialClass>();
            using (IDataReader dataReader = DbHelperCms.Instance.ExecuteReader(CommandType.Text, strSql.ToString()))
            {
                while (dataReader.Read())
                {
                    list.Add(SpecialClass_ReaderBind(dataReader));
                }
            }
            return list;
        }

        #endregion 读

        #region 写

        /// <summary>
        /// 删除分类时要更新比当前分类排序ID大的orderid - 1
        /// </summary>
        /// <param name="OrderID"></param>
        /// <returns></returns>
        public void SpecialClass_DeleteClassUpdateOrderID(int OrderID, int ParentID, int SiteID)
        {
            string sSql = string.Format("UPDATE {0}specialclass SET OrderID = OrderID-1 Where SiteID={3}  and OrderID>{1} and ParentID={2} ", sPre, OrderID, ParentID, SiteID);
            DbHelperCmsWrite.Instance.ExecuteNonQuery(CommandType.Text, sSql);


        }
        /// <summary>
        /// 移动分类
        /// </summary>
        /// <param name="SoureClassID"></param>
        /// <param name="TargetClassID"></param>
        /// <param name="IsAsChildnode"></param>
        public void SpecialClass_Move(int SoureClassID, int TargetClassID, bool IsAsChildnode, int SiteID)
        {

            string sqlStr;

            //将与源分类同级的分类，并且orderid大于源分类orderid的分类，-1补位

            //  sqlStr = string.Format("UPDATE [{0}specialclass] SET [orderid]=[orderid]-1 WHERE SiteID={2} and [ParentID]=(select [parentid] from  {0}specialclass where id={1}) and [orderid]>(select orderid from  {0}specialclass where id={1})", sPre, SoureClassID,SiteID);

            sqlStr = string.Format(" create table tmp1 as select parentid  as col1 from {0}specialclass where id={1};", sPre, SoureClassID);
            sqlStr += string.Format(" create table tmp2 as select orderid as col1 from  {0}specialclass where id={1};", sPre, SoureClassID);
            sqlStr += string.Format(" UPDATE {0}specialclass SET orderid=orderid-1 WHERE SiteID={1} and ParentID=(select col1 from tmp1) and orderid>(select col1 from tmp2);", sPre, SiteID);
            sqlStr += string.Format("drop table tmp1;  drop table tmp2;");

            DbHelperCmsWrite.Instance.ExecuteNonQuery(CommandType.Text, sqlStr);

            if (IsAsChildnode) //作为目标分类的子分类
            {

                //让目标分类下子分类的ID都加1，让位
                sqlStr = string.Format("UPDATE {0}specialclass SET orderid=orderid+1 WHERE SiteID={2} and ParentID={1}", sPre, TargetClassID, SiteID);
                DbHelperCmsWrite.Instance.ExecuteNonQuery(CommandType.Text, sqlStr);


                //先移到目标分类下并将orderid置为1
                sqlStr = string.Format("UPDATE {0}specialclass SET parentid={1} ,orderid=1 WHERE SiteID={3} and id={2}", sPre, TargetClassID, SoureClassID, SiteID);
                DbHelperCmsWrite.Instance.ExecuteNonQuery(CommandType.Text, sqlStr);



            }
            else  //调整到某个分类前面
            {


                //首先将与目标分类同级，并且orderid大于目标分类orderid 增加1,给源分类让位

                // sqlStr = string.Format("UPDATE [{0}specialclass] SET [orderid]=[orderid]+1  WHERE SiteID={2} and [parentid]=(select [Parentid] from  {0}specialclass where id={1}) and [orderid]>=(select orderid from  {0}specialclass where id={1}) ", sPre, TargetClassID,SiteID);
                sqlStr = string.Format(" create table tmp1 as select parentid  as col1 from {0}specialclass where id={1};", sPre, TargetClassID);
                sqlStr += string.Format(" create table tmp2 as select orderid as col1 from  {0}specialclass where id={1};", sPre, TargetClassID);
                sqlStr += string.Format(" UPDATE {0}specialclass SET orderid=orderid+1 WHERE SiteID={1} and ParentID=(select col1 from tmp1) and orderid>=(select col1 from tmp2);", sPre, SiteID);
                sqlStr += string.Format("drop table tmp1;  drop table tmp2;");

                DbHelperCmsWrite.Instance.ExecuteNonQuery(CommandType.Text, sqlStr);




                //将源分类更新到与目标分类同一父级下的分类,并将其orderid置为当前目标分类的orderid ，由于上面已经将目标分类加1，所以这里要减去1

                // sqlStr = string.Format("UPDATE [{0}specialclass] SET [parentid]=(select [Parentid] from  {0}specialclass where id={1}),[orderid]=(select orderid from  {0}specialclass where id={1})-1  WHERE SiteID={3} and [id]={2}", sPre, TargetClassID, SoureClassID,SiteID);
                sqlStr = string.Format(" create table tmp1 as select parentid  as col1 from {0}specialclass where id={1};", sPre, TargetClassID);
                sqlStr += string.Format(" create table tmp2 as select orderid as col1 from  {0}specialclass where id={1};", sPre, TargetClassID);
                sqlStr += string.Format(" UPDATE {0}specialclass SET  parentid=(select col1 from tmp1 ) ,orderid=(select col1 from tmp2)-1 WHERE SiteID={2} and id={1};", sPre, SoureClassID, SiteID);
                sqlStr += string.Format("drop table tmp1;  drop table tmp2;");

                DbHelperCmsWrite.Instance.ExecuteNonQuery(CommandType.Text, sqlStr);


            }
        }
        public void SpecialClass_UpdateOrderID(int iClassID, int iValue, int SiteID)
        {
            string strSql = string.Format("update {0}specialclass set OrderID={1} Where SiteID={3} and ID={2}", sPre, iValue, iClassID, SiteID);

            DbHelperCmsWrite.Instance.ExecuteNonQuery(CommandType.Text, strSql);
        }
        public void SpecialClass_Update(string Where, string Col, string sValue)
        {
            if (!string.IsNullOrEmpty(Where))
            {
                StringBuilder strSql = new StringBuilder();
                strSql.AppendFormat("update {0}specialclass set {1}={2} where {3}", sPre, Col, sValue, Where);
                DbHelperCmsWrite.Instance.ExecuteNonQuery(CommandType.Text, strSql.ToString());
            }

        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int SpecialClass_Add(EbSite.Entity.SpecialClass model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("insert into  {0}specialclass(", sPre);
            strSql.Append("SpecialName,Orderid,Titletype,Outlink,HtmlName,ClassHtmlNameRule,SpecialTemID,SeoTitle,SeoKeyWord,SeoDescription,ParentID,RelateClassIDs,SiteID,SpecialTemIDMobile,SubClassNum,Info,IsCusttomRw)");
            strSql.Append(" values (");
            strSql.Append("?SpecialName,?Orderid,?Titletype,?Outlink,?HtmlName,?ClassHtmlNameRule,?SpecialTemID,?SeoTitle,?SeoKeyWord,?SeoDescription,?ParentID,?RelateClassIDs,?SiteID,?SpecialTemIDMobile,?SubClassNum,?Info,?IsCusttomRw)");
            strSql.Append(";SELECT @@session.identity");
            MySqlParameter[] parameters = {
					new MySqlParameter("?SpecialName", MySqlDbType.VarChar,50),
					new MySqlParameter("?Orderid",  MySqlDbType.Int32,4),
					new MySqlParameter("?Titletype", MySqlDbType.VarChar,50),
					new MySqlParameter("?Outlink", MySqlDbType.VarChar,100),
					new MySqlParameter("?HtmlName", MySqlDbType.VarChar,300),
					new MySqlParameter("?ClassHtmlNameRule", MySqlDbType.VarChar,300),
					new MySqlParameter("?SpecialTemID", MySqlDbType.VarChar,36),
					new MySqlParameter("?SeoTitle", MySqlDbType.VarChar,200),
					new MySqlParameter("?SeoKeyWord", MySqlDbType.VarChar,300),
					new MySqlParameter("?SeoDescription", MySqlDbType.VarChar,300),
                    new MySqlParameter("?ParentID",  MySqlDbType.Int32,4),
                    new MySqlParameter("?RelateClassIDs", MySqlDbType.VarChar,200),
                    new MySqlParameter("?SiteID", MySqlDbType.Int32,4),
                    new MySqlParameter("?SpecialTemIDMobile", MySqlDbType.VarChar,36),
                    new MySqlParameter("?SubClassNum",  MySqlDbType.Int32,4),
                     new MySqlParameter("?Info",  MySqlDbType.Text,0),
                      new MySqlParameter("?IsCusttomRw",  MySqlDbType.Int16,1)
                                        };
            parameters[0].Value = model.SpecialName;
            parameters[1].Value = model.Orderid;
            parameters[2].Value = model.Titletype;
            parameters[3].Value = model.Outlink;
            parameters[4].Value = model.HtmlName;
            parameters[5].Value = model.ClassHtmlNameRule;
            parameters[6].Value = model.SpecialTemID;
            parameters[7].Value = model.SeoTitle;
            parameters[8].Value = model.SeoKeyWord;
            parameters[9].Value = model.SeoDescription;
            parameters[10].Value = model.ParentID;
            parameters[11].Value = model.RelateClassIDs;
            parameters[12].Value = model.SiteID;
            parameters[13].Value = model.SpecialTemIDMobile;
            parameters[14].Value = model.SubClassNum;
            parameters[15].Value = model.Info;
            parameters[16].Value = model.IsCusttomRw;
            

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
        public void SpecialClass_Update(EbSite.Entity.SpecialClass model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("update  {0}specialclass set ", sPre);
            strSql.Append("SpecialName=?SpecialName,");
            strSql.Append("Orderid=?Orderid,");
            strSql.Append("Titletype=?Titletype,");
            strSql.Append("Outlink=?Outlink,");
            strSql.Append("HtmlName=?HtmlName,");
            strSql.Append("ClassHtmlNameRule=?ClassHtmlNameRule,");
            strSql.Append("SpecialTemID=?SpecialTemID,");
            strSql.Append("SeoTitle=?SeoTitle,");
            strSql.Append("SeoKeyWord=?SeoKeyWord,");
            strSql.Append("SeoDescription=?SeoDescription,");
            strSql.Append("ParentID=?ParentID,");
            strSql.Append("RelateClassIDs=?RelateClassIDs,");
            strSql.Append("SiteID=?SiteID,");
            strSql.Append("SpecialTemIDMobile=?SpecialTemIDMobile,");
            strSql.Append("SubClassNum=?SubClassNum,");
            strSql.Append("Info=?Info,"); 
            strSql.Append("IsCusttomRw=?IsCusttomRw"); 

            strSql.Append(" where id=?id ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?id",  MySqlDbType.Int32,4),
					new MySqlParameter("?SpecialName", MySqlDbType.VarChar,50),
					new MySqlParameter("?Orderid",  MySqlDbType.Int32,4),
					new MySqlParameter("?Titletype", MySqlDbType.VarChar,50),
					new MySqlParameter("?Outlink", MySqlDbType.VarChar,100),
					new MySqlParameter("?HtmlName", MySqlDbType.VarChar,300),
					new MySqlParameter("?ClassHtmlNameRule", MySqlDbType.VarChar,300),
					new MySqlParameter("?SpecialTemID", MySqlDbType.VarChar,36),
					new MySqlParameter("?SeoTitle", MySqlDbType.VarChar,200),
					new MySqlParameter("?SeoKeyWord", MySqlDbType.VarChar,300),
					new MySqlParameter("?SeoDescription", MySqlDbType.VarChar,300),
                    new MySqlParameter("?ParentID",  MySqlDbType.Int32,4),
                    new MySqlParameter("?RelateClassIDs", MySqlDbType.VarChar,200),
                    new MySqlParameter("?SiteID", MySqlDbType.Int16,2),
					new MySqlParameter("?SpecialTemIDMobile", MySqlDbType.VarChar,36),
                    new MySqlParameter("?SubClassNum", MySqlDbType.Int32,4),
                      new MySqlParameter("?Info",  MySqlDbType.Text,0),
                      new MySqlParameter("?IsCusttomRw",  MySqlDbType.Int16,1)
                      
                                        };
            parameters[0].Value = model.id;
            parameters[1].Value = model.SpecialName;
            parameters[2].Value = model.Orderid;
            parameters[3].Value = model.Titletype;
            parameters[4].Value = model.Outlink;
            parameters[5].Value = model.HtmlName;
            parameters[6].Value = model.ClassHtmlNameRule;
            parameters[7].Value = model.SpecialTemID;
            parameters[8].Value = model.SeoTitle;
            parameters[9].Value = model.SeoKeyWord;
            parameters[10].Value = model.SeoDescription;
            parameters[11].Value = model.ParentID;
            parameters[12].Value = model.RelateClassIDs;
            parameters[13].Value = model.SiteID;
            parameters[14].Value = model.SpecialTemIDMobile;
            parameters[15].Value = model.SubClassNum;
            parameters[16].Value = model.Info;
            parameters[17].Value = model.IsCusttomRw;
            
            DbHelperCmsWrite.Instance.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }

       

        /// <summary>
        /// 批量删除，用逗号分开ID
        /// </summary>
        public void SpecialClass_Delete(string IDs)
        {
            //StringBuilder strSql=new StringBuilder();
            //strSql.AppendFormat("delete  {0}specialclass ", sPre);
            //strSql.Append(" where id=?id ");
            //MySqlParameter[] parameters = {
            //        new MySqlParameter("?id",  MySqlDbType.Int32,4)};
            //parameters[0].Value = id;
            //DbHelperCmsWrite.Instance.ExecuteNonQuery(CommandType.Text,strSql.ToString(),parameters);

            ////删除与专题相关的内容
            // strSql = new StringBuilder();
            // strSql.AppendFormat("delete  {0}SpecialNews ", sPre);
            // strSql.Append(" where SpecialClassID=?SpecialClassID ");
            //MySqlParameter[] parameters2 = {
            //        new MySqlParameter("?SpecialClassID",  MySqlDbType.Int32,4)};
            //parameters2[0].Value = id;
            //DbHelperCmsWrite.Instance.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);

            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("delete from {0}specialclass ", sPre);
            strSql.Append(" where ID in(" + IDs + ")");
            DbHelperCmsWrite.Instance.ExecuteNonQuery(CommandType.Text, strSql.ToString());

            //同时删除与此分类相关的内容

            strSql = new StringBuilder();
            strSql.AppendFormat("delete from {0}SpecialNews ", sPre);
            strSql.Append(" where SpecialClassID in(" + IDs + ")");
            DbHelperCmsWrite.Instance.ExecuteNonQuery(CommandType.Text, strSql.ToString());
        }

        #endregion 写
    }
}

