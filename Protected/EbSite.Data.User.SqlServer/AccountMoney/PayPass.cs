using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using EbSite.Base.DataProfile;
namespace EbSite.Data.User.SqlServer
{
	/// <summary>
	/// 数据访问类ddddd。
	/// </summary>
    public partial class DataProviderUser : Interface.IDataProviderUser
	{
        private string sFieldPayPass = "id,UserID,Pass,EndType,Balance,RequestBalance";
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int PayPass_GetMaxId()
		{
            return DbHelperUser.Instance.GetMaxID("id", string.Format("{0}PayPass", sPre)); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool PayPass_Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("select count(1) from {0}PayPass",sPre);
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;

			return DbHelperUser.Instance.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int PayPass_Add(Entity.PayPass model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("insert into {0}PayPass(",sPre);
            strSql.Append("UserID,Pass,EndType,Balance,RequestBalance)");
			strSql.Append(" values (");
            strSql.Append("@UserID,@Pass,@EndType,@Balance,@RequestBalance)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.Int,4),
					new SqlParameter("@Pass", SqlDbType.VarChar,100),
					new SqlParameter("@EndType", SqlDbType.Int,4),
                                new SqlParameter("?Balance", SqlDbType.Decimal),
                        new SqlParameter("?RequestBalance", SqlDbType.Decimal)         
                                        };
            parameters[0].Value = model.UserID;
            parameters[1].Value = model.Pass;
            parameters[2].Value = model.EndType;
            parameters[3].Value = model.Balance;
            parameters[4].Value = model.RequestBalance;

			object obj = DbHelperUser.Instance.ExecuteScalar(CommandType.Text,strSql.ToString(),parameters);
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
		public void PayPass_Update(Entity.PayPass model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("update {0}PayPass set ",sPre);
			strSql.Append("UserID=@UserID,");
			strSql.Append("Pass=@Pass,");
			strSql.Append("EndType=@EndType,");
            strSql.Append("Balance=@Balance,");
            strSql.Append("RequestBalance=@RequestBalance");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@UserID", SqlDbType.Int,4),
					new SqlParameter("@Pass", SqlDbType.VarChar,100),
					new SqlParameter("@EndType", SqlDbType.Int,4),
                                   new SqlParameter("@Balance", SqlDbType.Decimal),
                        new SqlParameter("@RequestBalance", SqlDbType.Decimal)          
                                        };
			parameters[0].Value = model.id;
			parameters[1].Value = model.UserID;
			parameters[2].Value = model.Pass;
			parameters[3].Value = model.EndType;
                        parameters[4].Value = model.Balance;
            parameters[5].Value = model.RequestBalance;
			DbHelperUser.Instance.ExecuteNonQuery(CommandType.Text,strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void PayPass_Delete(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("delete from {0}PayPass ",sPre);
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;

			DbHelperUser.Instance.ExecuteNonQuery(CommandType.Text,strSql.ToString(),parameters);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Entity.PayPass PayPass_GetEntity(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("select "+ sFieldPayPass +"  from {0}PayPass ",sPre);
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;
			Entity.PayPass model=null;
			using (IDataReader dataReader = DbHelperUser.Instance.ExecuteReader(CommandType.Text, strSql.ToString(),parameters))
			{
				if(dataReader.Read())
				{
					model= PayPass_ReaderBind(dataReader);
				}
			}
			return model;
		}
		/// <summary>
		/// 获取统计
		/// </summary>
		public int PayPass_GetCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("select count(*)  from {0}PayPass ",sPre);
			if (strWhere.Trim() != "")
			{
				strSql.Append(" where " + strWhere);
			}
			int iCount = 0;
			using (IDataReader dataReader = DbHelperUser.Instance.ExecuteReader(CommandType.Text,strSql.ToString()))
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
		public DataSet PayPass_GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(sFieldPayPass );
			strSql.AppendFormat(" FROM {0}PayPass ",sPre);
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			if(filedOrder.Trim()!="")
			{
				strSql.Append(" order by  "+filedOrder);
			}
			return DbHelperUser.Instance.ExecuteDataset(CommandType.Text, strSql.ToString());
		}

		/// <summary>
		/// 获得数据列表（比DataSet效率高，推荐使用）
		/// </summary>
		public List<Entity.PayPass> PayPass_GetListArray(string strWhere)
		{
			return PayPass_GetListArray(0,strWhere,""); 
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public List<Entity.PayPass> PayPass_GetListArray(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(sFieldPayPass );
			strSql.AppendFormat(" FROM {0}PayPass ",sPre);
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			if(filedOrder.Trim()!="")
			{
				strSql.Append(" order by  "+filedOrder);
			}
			List<Entity.PayPass> list = new List<Entity.PayPass>();
			using (IDataReader dataReader = DbHelperUser.Instance.ExecuteReader(CommandType.Text, strSql.ToString()))
			{
				while (dataReader.Read())
				{
					list.Add(PayPass_ReaderBind(dataReader));
				}
			}
			return list;
		}


		/// <summary>
		/// 获得分页数据
		/// </summary>
		public List<Entity.PayPass> PayPass_GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby,out int RecordCount)
		{
			List<Entity.PayPass> list = new List<Entity.PayPass>();
			using (IDataReader dataReader = SplitPages.GetListPages_SP(DbHelperUser.Instance,"PayPass", PageSize, PageIndex, Fileds, "id", oderby, strWhere, out RecordCount,sPre))
			{
				while (dataReader.Read())
				{
					list.Add(PayPass_ReaderBind(dataReader));
				}
			}
			return list;
		}


		/// <summary>
		/// 对象实体绑定数据
		/// </summary>
		public Entity.PayPass PayPass_ReaderBind(IDataReader dataReader)
		{
			Entity.PayPass model=new Entity.PayPass();
			object ojb; 
			ojb = dataReader["id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.id=(int)ojb;
			}
			ojb = dataReader["UserID"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.UserID=(int)ojb;
			}
			model.Pass=dataReader["Pass"].ToString();
			ojb = dataReader["EndType"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.EndType=(int)ojb;
			}
            ojb = dataReader["Balance"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.Balance = (decimal)ojb;
            }
            ojb = dataReader["RequestBalance"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.RequestBalance = (decimal)ojb;
            }
			return model;
		}

		#endregion  成员方法

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool PayPass_ExistsByUserID(int UserId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select count(1) from {0}PayPass", sPre);
            strSql.Append(" where UserID=@UserID ");
            SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.Int,4)};
            parameters[0].Value = UserId;

            return DbHelperUser.Instance.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Entity.PayPass PayPass_GetEntityByUserID(int UserId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select " + sFieldPayPass + "  from {0}PayPass ", sPre);
            strSql.Append(" where UserID=@UserID ");
            SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.Int,4)};
            parameters[0].Value = UserId;
            Entity.PayPass model = null;
            using (IDataReader dataReader = DbHelperUser.Instance.ExecuteReader(CommandType.Text, strSql.ToString(), parameters))
            {
                if (dataReader.Read())
                {
                    model = PayPass_ReaderBind(dataReader);
                }
            }
            return model;
        }
	}
}

