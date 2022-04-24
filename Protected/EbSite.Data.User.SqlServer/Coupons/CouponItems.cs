using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using EbSite.Base.DataProfile;

namespace EbSite.Data.User.SqlServer
{
	/// <summary>
	/// 数据访问类Shop。
	/// </summary>
    public partial class DataProviderUser : Interface.IDataProviderUser
	{
		private string sFieldCouponItems = "id,CouponId,LotNumber,ClaimCode,UserId,EmailAddress,AddDateTime";
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int CouponItems_GetMaxId()
		{
			return DbHelperUser.Instance.GetMaxID("id", string.Format("{0}CouponItems",sPre)); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool CouponItems_Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("select count(1) from {0}CouponItems",sPre);
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;

			return DbHelperUser.Instance.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int CouponItems_Add(Entity.CouponItems model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("insert into {0}CouponItems(",sPre);
			strSql.Append("CouponId,LotNumber,ClaimCode,UserId,EmailAddress,AddDateTime)");
			strSql.Append(" values (");
			strSql.Append("@CouponId,@LotNumber,@ClaimCode,@UserId,@EmailAddress,@AddDateTime)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					
					new SqlParameter("@CouponId", SqlDbType.Int,4),
					new SqlParameter("@LotNumber", SqlDbType.VarChar,100),
					new SqlParameter("@ClaimCode", SqlDbType.VarChar,32),
					new SqlParameter("@UserId", SqlDbType.Int,4),
					new SqlParameter("@EmailAddress", SqlDbType.VarChar,150),
					new SqlParameter("@AddDateTime", SqlDbType.DateTime)};
		
			parameters[0].Value = model.CouponId;
			parameters[1].Value = model.LotNumber;
			parameters[2].Value = model.ClaimCode;
			parameters[3].Value = model.UserId;
			parameters[4].Value = model.EmailAddress;
			parameters[5].Value = model.AddDateTime;

			object obj = DbHelperUser.Instance.ExecuteScalar(CommandType.Text,strSql.ToString(),parameters);
			if (obj == null)
			{
				return 1;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
			return 0;		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void CouponItems_Update(Entity.CouponItems model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("update {0}CouponItems set ",sPre);
			strSql.Append("CouponId=@CouponId,");
			strSql.Append("LotNumber=@LotNumber,");
			strSql.Append("ClaimCode=@ClaimCode,");
			strSql.Append("UserId=@UserId,");
			strSql.Append("EmailAddress=@EmailAddress,");
			strSql.Append("AddDateTime=@AddDateTime");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@CouponId", SqlDbType.Int,4),
					new SqlParameter("@LotNumber", SqlDbType.VarChar,100),
					new SqlParameter("@ClaimCode", SqlDbType.VarChar,32),
					new SqlParameter("@UserId", SqlDbType.Int,4),
					new SqlParameter("@EmailAddress", SqlDbType.VarChar,150),
					new SqlParameter("@AddDateTime", SqlDbType.DateTime)};
			parameters[0].Value = model.id;
			parameters[1].Value = model.CouponId;
			parameters[2].Value = model.LotNumber;
			parameters[3].Value = model.ClaimCode;
			parameters[4].Value = model.UserId;
			parameters[5].Value = model.EmailAddress;
			parameters[6].Value = model.AddDateTime;

			DbHelperUser.Instance.ExecuteNonQuery(CommandType.Text,strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void CouponItems_Delete(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("delete from {0}CouponItems ",sPre);
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;

			DbHelperUser.Instance.ExecuteNonQuery(CommandType.Text,strSql.ToString(),parameters);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Entity.CouponItems CouponItems_GetEntity(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("select "+ sFieldCouponItems +"  from {0}CouponItems ",sPre);
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;
			Entity.CouponItems model=null;
			using (IDataReader dataReader = DbHelperUser.Instance.ExecuteReader(CommandType.Text, strSql.ToString(),parameters))
			{
				if(dataReader.Read())
				{
					model= CouponItems_ReaderBind(dataReader);
				}
			}
			return model;
		}
		/// <summary>
		/// 获取统计
		/// </summary>
		public int CouponItems_GetCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("select count(*)  from {0}CouponItems ",sPre);
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
		public DataSet CouponItems_GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
			strSql.Append(sFieldCouponItems );
			strSql.AppendFormat(" FROM {0}CouponItems ",sPre);
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
		public List<Entity.CouponItems> CouponItems_GetListArray(string strWhere)
		{
			return CouponItems_GetListArray(0,strWhere,""); 
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public List<Entity.CouponItems> CouponItems_GetListArray(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
			strSql.Append(sFieldCouponItems );
			strSql.AppendFormat(" FROM {0}CouponItems ",sPre);
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			if(filedOrder.Trim()!="")
			{
				strSql.Append(" order by  "+filedOrder);
			}
           
			List<Entity.CouponItems> list = new List<Entity.CouponItems>();
			using (IDataReader dataReader = DbHelperUser.Instance.ExecuteReader(CommandType.Text, strSql.ToString()))
			{
				while (dataReader.Read())
				{
					list.Add(CouponItems_ReaderBind(dataReader));
				}
			}
			return list;
		}


		/// <summary>
		/// 获得分页数据
		/// </summary>
		public List<Entity.CouponItems> CouponItems_GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby,out int RecordCount)
		{
            List<Entity.CouponItems> list = new List<Entity.CouponItems>();
            using (IDataReader dataReader = SplitPages.GetListPages_SP(DbHelperUser.Instance, "CouponItems", PageSize, PageIndex, Fileds, "id", oderby, strWhere, out RecordCount, sPre))
            {
                while (dataReader.Read())
                {
                    list.Add(CouponItems_ReaderBind(dataReader));
                }
            }
            return list;		
		}


		/// <summary>
		/// 对象实体绑定数据
		/// </summary>
		public Entity.CouponItems CouponItems_ReaderBind(IDataReader dataReader)
		{
			Entity.CouponItems model=new Entity.CouponItems();
			object ojb; 
			ojb = dataReader["id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.id=(int)ojb;
			}
			ojb = dataReader["CouponId"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.CouponId=(int)ojb;
			}
			model.LotNumber=dataReader["LotNumber"].ToString();
			model.ClaimCode=dataReader["ClaimCode"].ToString();
			ojb = dataReader["UserId"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.UserId=(int)ojb;
			}
			model.EmailAddress=dataReader["EmailAddress"].ToString();
			ojb = dataReader["AddDateTime"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.AddDateTime=(DateTime)ojb;
			}
			return model;
		}

		#endregion  成员方法
        public Entity.CouponItems CouponItems_GetEntity(string CouponCode, out string CouponName, out decimal Amount, out decimal CouponValue)
        {
            CouponName = string.Empty;
            Amount = 0;
            CouponValue = 0;
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select CI.id,CI.CouponId,CI.LotNumber,CI.ClaimCode,CI.UserId,CI.EmailAddress,CI.AddDateTime,C.CouponName  from {0}CouponItems as CI,coupons as C", sPre);
            strSql.Append(" where ClaimCode=@ClaimCode and CI.CouponId=C.CouponId");
            SqlParameter[] parameters = {
					new SqlParameter("@CouponId", SqlDbType.VarChar,4)};
            parameters[0].Value = CouponCode;
            Entity.CouponItems model = null;
            using (IDataReader dataReader = DbHelperUser.Instance.ExecuteReader(CommandType.Text, strSql.ToString(), parameters))
            {
                if (dataReader.Read())
                {
                    model = CouponItems_ReaderBind(dataReader);
                    CouponName = dataReader["CouponName"].ToString();
                    object ojb;
                    ojb = dataReader["Amount"];
                    if (ojb != null && ojb != DBNull.Value)
                    {
                        Amount = (decimal)ojb;
                    }
                    ojb = dataReader["DiscountPrice"];
                    if (ojb != null && ojb != DBNull.Value)
                    {
                        CouponValue = (decimal)ojb;
                    }
                }
            }
            return model;
        }
	}
}

