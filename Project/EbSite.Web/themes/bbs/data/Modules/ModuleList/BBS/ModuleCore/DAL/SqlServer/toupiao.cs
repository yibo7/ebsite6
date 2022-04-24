using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using EbSite.Base.DataProfile;
using System.Collections.Generic;
namespace EbSite.Modules.BBS.ModuleCore.DAL.SqlServer
{
	/// <summary>
	/// 数据访问类toupiao。
	/// </summary>
    public partial class BBS 
	{
		private string sFieldtoupiao = "id,title,color,piaoshu,bigId,bigtitle,shuoming,TpUsername,TpRealname,username,realname,CompanyID";
		#region  成员方法

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool toupiao_Exists(long id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("select count(1) from {0}toupiao",sPre);
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.BigInt)};
			parameters[0].Value = id;

			return DB.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int toupiao_Add(Entity.toupiao model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("insert into {0}toupiao(",sPre);
			strSql.Append("title,color,piaoshu,bigId,bigtitle,shuoming,TpUsername,TpRealname,username,realname,CompanyID)");
			strSql.Append(" values (");
			strSql.Append("@title,@color,@piaoshu,@bigId,@bigtitle,@shuoming,@TpUsername,@TpRealname,@username,@realname,@CompanyID)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@title", SqlDbType.NVarChar,500),
					new SqlParameter("@color", SqlDbType.NVarChar,50),
					new SqlParameter("@piaoshu", SqlDbType.BigInt,8),
					new SqlParameter("@bigId", SqlDbType.NVarChar,50),
					new SqlParameter("@bigtitle", SqlDbType.NVarChar,50),
					new SqlParameter("@shuoming", SqlDbType.NText),
					new SqlParameter("@TpUsername", SqlDbType.VarChar,8000),
					new SqlParameter("@TpRealname", SqlDbType.VarChar,8000),
					new SqlParameter("@username", SqlDbType.NVarChar,50),
					new SqlParameter("@realname", SqlDbType.NVarChar,50),
					new SqlParameter("@CompanyID", SqlDbType.Int,4)};
			parameters[0].Value = model.title;
			parameters[1].Value = model.color;
			parameters[2].Value = model.piaoshu;
			parameters[3].Value = model.bigId;
			parameters[4].Value = model.bigtitle;
			parameters[5].Value = model.shuoming;
			parameters[6].Value = model.TpUsername;
			parameters[7].Value = model.TpRealname;
			parameters[8].Value = model.username;
			parameters[9].Value = model.realname;
			parameters[10].Value = model.CompanyID;

			object obj = DB.ExecuteScalar(CommandType.Text,strSql.ToString(),parameters);
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
		public void toupiao_Update(Entity.toupiao model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("update {0}toupiao set ",sPre);
			strSql.Append("title=@title,");
			strSql.Append("color=@color,");
			strSql.Append("piaoshu=@piaoshu,");
			strSql.Append("bigId=@bigId,");
			strSql.Append("bigtitle=@bigtitle,");
			strSql.Append("shuoming=@shuoming,");
			strSql.Append("TpUsername=@TpUsername,");
			strSql.Append("TpRealname=@TpRealname,");
			strSql.Append("username=@username,");
			strSql.Append("realname=@realname,");
			strSql.Append("CompanyID=@CompanyID");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.BigInt,8),
					new SqlParameter("@title", SqlDbType.NVarChar,500),
					new SqlParameter("@color", SqlDbType.NVarChar,50),
					new SqlParameter("@piaoshu", SqlDbType.BigInt,8),
					new SqlParameter("@bigId", SqlDbType.NVarChar,50),
					new SqlParameter("@bigtitle", SqlDbType.NVarChar,50),
					new SqlParameter("@shuoming", SqlDbType.NText),
					new SqlParameter("@TpUsername", SqlDbType.VarChar,8000),
					new SqlParameter("@TpRealname", SqlDbType.VarChar,8000),
					new SqlParameter("@username", SqlDbType.NVarChar,50),
					new SqlParameter("@realname", SqlDbType.NVarChar,50),
					new SqlParameter("@CompanyID", SqlDbType.Int,4)};
			parameters[0].Value = model.id;
			parameters[1].Value = model.title;
			parameters[2].Value = model.color;
			parameters[3].Value = model.piaoshu;
			parameters[4].Value = model.bigId;
			parameters[5].Value = model.bigtitle;
			parameters[6].Value = model.shuoming;
			parameters[7].Value = model.TpUsername;
			parameters[8].Value = model.TpRealname;
			parameters[9].Value = model.username;
			parameters[10].Value = model.realname;
			parameters[11].Value = model.CompanyID;

			DB.ExecuteNonQuery(CommandType.Text,strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void toupiao_Delete(long id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("delete from {0}toupiao ",sPre);
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.BigInt)};
			parameters[0].Value = id;

			DB.ExecuteNonQuery(CommandType.Text,strSql.ToString(),parameters);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Entity.toupiao toupiao_GetEntity(long id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("select "+ sFieldtoupiao +"  from {0}toupiao ",sPre);
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.BigInt)};
			parameters[0].Value = id;
			Entity.toupiao model=null;
			using (IDataReader dataReader = DB.ExecuteReader(CommandType.Text, strSql.ToString(),parameters))
			{
				if(dataReader.Read())
				{
					model= toupiao_ReaderBind(dataReader);
				}
			}
			return model;
		}
		/// <summary>
		/// 获取统计
		/// </summary>
		public int toupiao_GetCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("select count(*)  from {0}toupiao ",sPre);
			if (strWhere.Trim() != "")
			{
				strSql.Append(" where " + strWhere);
			}
			int iCount = 0;
			using (IDataReader dataReader = DB.ExecuteReader(CommandType.Text,strSql.ToString()))
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
		public DataSet toupiao_GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(sFieldtoupiao );
            strSql.AppendFormat(" FROM {0}toupiao ", sPre);
			if(strWhere.Trim()!="")
			{
                strSql.Append(" where " + strWhere);
			}
			if(filedOrder.Trim()!="")
			{
				strSql.Append(" order by  "+filedOrder);
			}
			return DB.ExecuteDataset(CommandType.Text, strSql.ToString());
		}

		/// <summary>
		/// 获得数据列表（比DataSet效率高，推荐使用）
		/// </summary>
		public List<Entity.toupiao> toupiao_GetListArray(string strWhere)
		{
			return toupiao_GetListArray(0,strWhere,""); 
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public List<Entity.toupiao> toupiao_GetListArray(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(sFieldtoupiao );
			strSql.AppendFormat(" FROM {0}toupiao  ",sPre);
			if(strWhere.Trim()!="")
			{
                strSql.Append(" where " + strWhere);
			}
			if(filedOrder.Trim()!="")
			{
				strSql.Append(" order by  "+filedOrder);
			}
			List<Entity.toupiao> list = new List<Entity.toupiao>();
			using (IDataReader dataReader = DB.ExecuteReader(CommandType.Text, strSql.ToString()))
			{
				while (dataReader.Read())
				{
					list.Add(toupiao_ReaderBind(dataReader));
				}
			}
			return list;
		}


		/// <summary>
		/// 获得分页数据
		/// </summary>
		public List<Entity.toupiao> toupiao_GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby,out int RecordCount)
		{
			List<Entity.toupiao> list = new List<Entity.toupiao>();
            using (IDataReader dataReader = SplitPages.GetListPages_SP(DB,"toupiao", PageSize, PageIndex, Fileds, "id", oderby, strWhere, out RecordCount,sPre))
			{
				while (dataReader.Read())
				{
					list.Add(toupiao_ReaderBind(dataReader));
				}
			}
			return list;
		}


		/// <summary>
		/// 对象实体绑定数据
		/// </summary>
		public Entity.toupiao toupiao_ReaderBind(IDataReader dataReader)
		{
			Entity.toupiao model=new Entity.toupiao();
			object ojb; 
			ojb = dataReader["id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.id=(long)ojb;
			}
			model.title=dataReader["title"].ToString();
			model.color=dataReader["color"].ToString();
			ojb = dataReader["piaoshu"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.piaoshu=(long)ojb;
			}
			model.bigId=dataReader["bigId"].ToString();
			model.bigtitle=dataReader["bigtitle"].ToString();
			model.shuoming=dataReader["shuoming"].ToString();
			model.TpUsername=dataReader["TpUsername"].ToString();
			model.TpRealname=dataReader["TpRealname"].ToString();
			model.username=dataReader["username"].ToString();
			model.realname=dataReader["realname"].ToString();
			ojb = dataReader["CompanyID"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.CompanyID=(int)ojb;
			}
			return model;
		}

		#endregion  成员方法
	}
}

