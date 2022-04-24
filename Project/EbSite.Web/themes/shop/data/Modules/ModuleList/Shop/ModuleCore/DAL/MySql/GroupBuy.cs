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
        private string sFieldGroupBuy = "id,ProductID,NeedPrice,StartDate,EndDate,MaxCount,Content,Status,OrderID,Price,Title,SmallImg,BuyCount,BuyPrice,sdateline,edateline,Buyed,BuySumOrder";
        #region  成员方法

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GroupBuy_GetMaxId()
        {
            return DB.GetMaxID("id", string.Format("{0}GroupBuy", sPre));
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool GroupBuy_Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select count(1) from {0}GroupBuy", sPre);
            strSql.Append(" where id=?id ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32,4)};
            parameters[0].Value = id;

            return DB.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int GroupBuy_Add(Entity.GroupBuy model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("insert into {0}GroupBuy(", sPre);
            strSql.Append("ProductID,NeedPrice,StartDate,EndDate,MaxCount,Content,Status,OrderID,Price,Title,SmallImg,BuyCount,BuyPrice,sdateline,edateline,Buyed,BuySumOrder)");
            strSql.Append(" values (");
            strSql.Append("?ProductID,?NeedPrice,?StartDate,?EndDate,?MaxCount,?Content,?Status,?OrderID,?Price,?Title,?SmallImg,?BuyCount,?BuyPrice,?sdateline,?edateline,?Buyed,?BuySumOrder)");
            strSql.Append(";select @@IDENTITY");
            MySqlParameter[] parameters = {
					new MySqlParameter("?ProductID", MySqlDbType.Int32,4),
					new MySqlParameter("?NeedPrice", MySqlDbType.Decimal,9),
					new MySqlParameter("?StartDate", MySqlDbType.DateTime),
					new MySqlParameter("?EndDate", MySqlDbType.DateTime),
					new MySqlParameter("?MaxCount", MySqlDbType.Int32,4),
					new MySqlParameter("?Content", MySqlDbType.VarChar),
					new MySqlParameter("?Status", MySqlDbType.Int32,4),
					new MySqlParameter("?OrderID", MySqlDbType.Int32,4),
                    new MySqlParameter("?Price", MySqlDbType.Decimal,18),
                    new MySqlParameter("?Title", MySqlDbType.VarChar,255),
                    new MySqlParameter("?SmallImg", MySqlDbType.VarChar,255),
                    new MySqlParameter("?BuyCount", MySqlDbType.Int32,4),
                    new MySqlParameter("?BuyPrice", MySqlDbType.Decimal,18),
                    new MySqlParameter("?sdateline", MySqlDbType.Int32,4),
                    new MySqlParameter("?edateline", MySqlDbType.Int32,4),
                    new MySqlParameter("?Buyed",MySqlDbType.Int32,4),
                    new MySqlParameter( "?BuySumOrder",MySqlDbType.Int32,4)};
            parameters[0].Value = model.ProductID;
            parameters[1].Value = model.NeedPrice;
            parameters[2].Value = model.StartDate;
            parameters[3].Value = model.EndDate;
            parameters[4].Value = model.MaxCount;
            parameters[5].Value = model.Content;
            parameters[6].Value = model.Status;
            parameters[7].Value = model.OrderID;
            parameters[8].Value = model.Price;
            parameters[9].Value = model.Title;
            parameters[10].Value = model.SmallImg;
            parameters[11].Value = model.BuyCount;
            parameters[12].Value = model.BuyPrice;
            parameters[13].Value = model.SDateLine;
            parameters[14].Value = model.EDateLine;
            parameters[15].Value = model.Buyed;
            parameters[16].Value = model.BuySumOrder;

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
        public void GroupBuy_Update(Entity.GroupBuy model)
        {
            GroupBuy_Update(model,null);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void GroupBuy_Update(Entity.GroupBuy model,MySqlTransaction trans)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("update {0}GroupBuy set ", sPre);
            strSql.Append("ProductID=?ProductID,");
            strSql.Append("NeedPrice=?NeedPrice,");
            strSql.Append("StartDate=?StartDate,");
            strSql.Append("EndDate=?EndDate,");
            strSql.Append("MaxCount=?MaxCount,");
            strSql.Append("Content=?Content,");
            strSql.Append("Status=?Status,");
            strSql.Append("OrderID=?OrderID,");
            strSql.Append("Price=?Price,");
            strSql.Append("Title=?Title,");
            strSql.Append("SmallImg=?SmallImg,");
            strSql.Append("BuyCount=?BuyCount,");
            strSql.Append("BuyPrice=?BuyPrice,");
            strSql.Append("SDateLine=?SDateLine,");
            strSql.Append("EDateLine=?EDateLine,");
            strSql.Append("Buyed=?Buyed,");
            strSql.Append("BuySumOrder=?BuySumOrder");

            strSql.Append(" where id=?id ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32,4),
					new MySqlParameter("?ProductID", MySqlDbType.Int32,4),
					new MySqlParameter("?NeedPrice", MySqlDbType.Decimal,9),
					new MySqlParameter("?StartDate", MySqlDbType.DateTime),
					new MySqlParameter("?EndDate", MySqlDbType.DateTime),
					new MySqlParameter("?MaxCount", MySqlDbType.Int32,4),
					new MySqlParameter("?Content", MySqlDbType.VarChar),
					new MySqlParameter("?Status", MySqlDbType.Int32,4),
					new MySqlParameter("?OrderID", MySqlDbType.Int32,4),
                    new MySqlParameter("?Price", MySqlDbType.Decimal,18),
                    new MySqlParameter("?Title", MySqlDbType.VarChar,255),
                    new MySqlParameter("?SmallImg", MySqlDbType.VarChar,255),
                    new MySqlParameter("?BuyCount", MySqlDbType.Int32,4),
                    new MySqlParameter("?BuyPrice", MySqlDbType.Decimal,18),
                    new MySqlParameter("?SDateLine", MySqlDbType.Int32,4),
                    new MySqlParameter("?EDateLine", MySqlDbType.Int32,4),
                                         
                    new MySqlParameter("?Buyed",MySqlDbType.Int32,4),
                    new MySqlParameter( "?BuySumOrder",MySqlDbType.Int32,4)};
            parameters[0].Value = model.id;
            parameters[1].Value = model.ProductID;
            parameters[2].Value = model.NeedPrice;
            parameters[3].Value = model.StartDate;
            parameters[4].Value = model.EndDate;
            parameters[5].Value = model.MaxCount;
            parameters[6].Value = model.Content;
            parameters[7].Value = model.Status;
            parameters[8].Value = model.OrderID;
            parameters[9].Value = model.Price;
            parameters[10].Value = model.Title;
            parameters[11].Value = model.SmallImg;
            parameters[12].Value = model.BuyCount;
            parameters[13].Value = model.BuyPrice;
            parameters[14].Value = model.SDateLine;
            parameters[15].Value = model.EDateLine;

            parameters[16].Value = model.Buyed;
            parameters[17].Value = model.BuySumOrder;

            if (trans == null)
            {
                DB.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
            }
            else
            {
                DB.ExecuteNonQuery(trans,CommandType.Text, strSql.ToString(), parameters);
            }
            
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="Status">团购状态</param>
        /// <param name="id">团购ID</param>
        public void GroupBuy_Update(int Status, int id)
        {
            string strSql = string.Format("update {0}GroupBuy set status={1} where id={2};update {0}Buy_Orders set groupbuystatus={1} where groupid={2};", sPre, Status, id);
            DB.ExecuteNonQuery(CommandType.Text, strSql);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void GroupBuy_Delete(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("delete from {0}GroupBuy ", sPre);
            strSql.Append(" where id=?id ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32,4)};
            parameters[0].Value = id;

            DB.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Entity.GroupBuy GroupBuy_GetEntity(int id)
        {
           
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select {1} from {0}GroupBuy", sPre, sFieldGroupBuy);
            strSql.AppendFormat(" where id=?id ");
            MySqlParameter[] parameters = {
                    new MySqlParameter("?id", MySqlDbType.Int32,4)};
            parameters[0].Value = id;
            Entity.GroupBuy model = null;
            using (IDataReader dataReader = DB.ExecuteReader(CommandType.Text, strSql.ToString(), parameters))
            {
                if (dataReader.Read())
                {
                    model = GroupBuy_ReaderBind(dataReader);
                }
            }
            return model;
        }
        /// <summary>
        /// 获取统计
        /// </summary>
        public int GroupBuy_GetCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select count(*)  from {0}GroupBuy ", sPre);
            if (strWhere.Trim() != "")
            {
                strSql.Append("where " + strWhere);
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
        public DataSet GroupBuy_GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");

            strSql.Append(sFieldGroupBuy);
            strSql.AppendFormat(" FROM {0}GroupBuy ", sPre);
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
        public List<Entity.GroupBuy> GroupBuy_GetListArray(string strWhere)
        {
            return GroupBuy_GetListArray(0, strWhere, "");
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public List<Entity.GroupBuy> GroupBuy_GetListArray(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");

            strSql.Append(sFieldGroupBuy);
            strSql.AppendFormat(" FROM {0}GroupBuy ", sPre);
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
            List<Entity.GroupBuy> list = new List<Entity.GroupBuy>();
            using (IDataReader dataReader = DB.ExecuteReader(CommandType.Text, strSql.ToString()))
            {
                while (dataReader.Read())
                {
                    list.Add(GroupBuy_ReaderBind(dataReader));
                }
            }
            return list;
        }


        /// <summary>
        /// 获得分页数据
        /// </summary>
        public List<Entity.GroupBuy> GroupBuy_GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby, out int RecordCount)
        {

            StringBuilder sbSql = new StringBuilder();
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                //sbSql.Append(" where ");
                sbSql.AppendFormat(strWhere);
            }
            RecordCount = GroupBuy_GetCount(sbSql.ToString());
            List<Entity.GroupBuy> list = new List<Entity.GroupBuy>();
            string strSql = SplitPages.GetSplitPagesMySql(DB, "GroupBuy", PageSize, PageIndex, sFieldGroupBuy, "id", oderby, sbSql.ToString(), sPre);
            using (IDataReader dataReader = DB.ExecuteReader(CommandType.Text, strSql))
            {
                while (dataReader.Read())
                {
                    list.Add(GroupBuy_ReaderBind(dataReader));
                }
            }
            return list;




        }


        /// <summary>
        /// 对象实体绑定数据
        /// </summary>
        public Entity.GroupBuy GroupBuy_ReaderBind(IDataReader dataReader)
        {
            Entity.GroupBuy model = new Entity.GroupBuy();
            object ojb;
            ojb = dataReader["id"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.id = (int)ojb;
            }
            ojb = dataReader["ProductID"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.ProductID = (int)ojb;
            }
            ojb = dataReader["NeedPrice"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.NeedPrice = (decimal)ojb;
            }
            ojb = dataReader["StartDate"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.StartDate = (DateTime)ojb;
            }
            ojb = dataReader["EndDate"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.EndDate = (DateTime)ojb;
            }
            ojb = dataReader["MaxCount"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.MaxCount = (int)ojb;
            }
            model.Content = dataReader["Content"].ToString();
            ojb = dataReader["Status"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.Status = (int)ojb;
            }
            ojb = dataReader["OrderID"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.OrderID = (int)ojb;
            }
            ojb = dataReader["Price"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.Price = (decimal)ojb;
            }

            model.Title = dataReader["Title"].ToString();
            model.SmallImg = dataReader["SmallImg"].ToString();

         
            ojb = dataReader["BuyCount"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.BuyCount = (int)ojb;
            }
            ojb = dataReader["BuyPrice"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.BuyPrice = (decimal)ojb;
            }

            ojb = dataReader["SDateLine"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.SDateLine = (int)ojb;
            }
            ojb = dataReader["EDateLine"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.EDateLine = (int)ojb;
            }

             ojb = dataReader["Buyed"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.Buyed = (int)ojb;
            }
             ojb = dataReader["BuySumOrder"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.BuySumOrder = (int)ojb;
            }
             
            return model;
        }

        /// <summary>
        /// 获取团购数量
        /// </summary>
        /// <param name="groupID">团购ID</param>
        /// <returns></returns>
        public int GroupBuy_GetOrderCount(int groupID)
        {
            string strSql = string.Format("select count(id) from {0}buy_orders where groupid={1}", sPre, groupID);
            object rows = DB.ExecuteScalar(CommandType.Text, strSql);
            if (rows != null)
            {
                return EbSite.Core.Utils.ObjectToInt(rows, 0);
            }
            else
            {
                return 0;
            }
        }

        #endregion  成员方法

        /// <summary>
        /// 定时更新团购状态
        /// </summary>
        /// <returns></returns>
        public bool GroupBuy_UpdateStatus()
        {
            string tableName = string.Format("{0}groupbuy", sPre);
            string strSql = string.Format("update {0} set status=3 where DATEDIFF(NOW(),StartDate)<0;",tableName);
            strSql += string.Format("update {0} set status=0 where DATEDIFF(NOW(),StartDate)>=0 and DATEDIFF(NOW(),EndDate)<=0;", tableName);
            strSql += string.Format("update {0} set status=4 where (status=0 or status=3) and DATEDIFF(NOW(),EndDate)>0;", tableName);

            return DB.ExecuteNonQuery(CommandType.Text,strSql)>0?true:false;
        }

        //#region 联合查询

        ///// <summary>
        ///// 获得分页数据
        ///// </summary>
        //public List<Entity.GroupBuy> UnionGroupBuy_GetList(int Top, string strWhere, string filedOrder)
        //{
        //    StringBuilder strSql = new StringBuilder();

        //    strSql.AppendFormat(" SELECT a.*,(select count(*) from {0}buy_orders where GroupId=a.id)as ordernum, (SELECT sum(Quantity) from {0}buy_orderitem where OrderID in(select OrderID from {0}buy_orders where GroupId=a.id) ) as sumorder from {0}groupbuy a  ", sPre);
        //    if (strWhere.Trim() != "")
        //    {
        //        strSql.Append(" where " + strWhere);
        //    }
        //    if (filedOrder.Trim() != "")
        //    {
        //        strSql.Append(" order by  " + filedOrder);
        //    }
        //    if (Top > 0)
        //    {
        //        strSql.Append(" limit " + Top.ToString());
        //    }
        //    List<Entity.GroupBuy> list = new List<Entity.GroupBuy>();
        //    using (IDataReader dataReader = DB.ExecuteReader(CommandType.Text, strSql.ToString()))
        //    {
        //        while (dataReader.Read())
        //        {
        //            list.Add(GroupBuy_ReaderBind2(dataReader));
        //        }
        //    }
        //    return list;
        //}


       
        //#endregion

    }
}

