using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using EbSite.Base.DataProfile;
using System.Collections.Generic;
namespace EbSite.Modules.BBS.ModuleCore.DAL.SqlServer
{
	/// <summary>
	/// 数据访问类toupiaobt。
	/// </summary>
    public partial class BBS
	{
		private string sFieldtoupiaobt = "id,title,xuanze,username,realname,Gkusername,Gkrealname,type,ifopen,CompanyID";
		#region  成员方法

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool toupiaobt_Exists(long id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("select count(1) from {0}toupiaobt",sPre);
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.BigInt)};
			parameters[0].Value = id;

			return DB.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int toupiaobt_Add(Entity.toupiaobt model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("insert into {0}toupiaobt(",sPre);
			strSql.Append("title,xuanze,username,realname,Gkusername,Gkrealname,type,ifopen,CompanyID)");
			strSql.Append(" values (");
			strSql.Append("@title,@xuanze,@username,@realname,@Gkusername,@Gkrealname,@type,@ifopen,@CompanyID)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@title", SqlDbType.NVarChar,500),
					new SqlParameter("@xuanze", SqlDbType.NVarChar,50),
					new SqlParameter("@username", SqlDbType.NVarChar,50),
					new SqlParameter("@realname", SqlDbType.NVarChar,50),
					new SqlParameter("@Gkusername", SqlDbType.VarChar,8000),
					new SqlParameter("@Gkrealname", SqlDbType.VarChar,8000),
					new SqlParameter("@type", SqlDbType.NVarChar,50),
					new SqlParameter("@ifopen", SqlDbType.NVarChar,50),
					new SqlParameter("@CompanyID", SqlDbType.Int,4)};
			parameters[0].Value = model.title;
			parameters[1].Value = model.xuanze;
			parameters[2].Value = model.username;
			parameters[3].Value = model.realname;
			parameters[4].Value = model.Gkusername;
			parameters[5].Value = model.Gkrealname;
			parameters[6].Value = model.type;
			parameters[7].Value = model.ifopen;
			parameters[8].Value = model.CompanyID;

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
		public void toupiaobt_Update(Entity.toupiaobt model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("update {0}toupiaobt set ",sPre);
			strSql.Append("title=@title,");
			strSql.Append("xuanze=@xuanze,");
			strSql.Append("username=@username,");
			strSql.Append("realname=@realname,");
			strSql.Append("Gkusername=@Gkusername,");
			strSql.Append("Gkrealname=@Gkrealname,");
			strSql.Append("type=@type,");
			strSql.Append("ifopen=@ifopen,");
			strSql.Append("CompanyID=@CompanyID");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.BigInt,8),
					new SqlParameter("@title", SqlDbType.NVarChar,500),
					new SqlParameter("@xuanze", SqlDbType.NVarChar,50),
					new SqlParameter("@username", SqlDbType.NVarChar,50),
					new SqlParameter("@realname", SqlDbType.NVarChar,50),
					new SqlParameter("@Gkusername", SqlDbType.VarChar,8000),
					new SqlParameter("@Gkrealname", SqlDbType.VarChar,8000),
					new SqlParameter("@type", SqlDbType.NVarChar,50),
					new SqlParameter("@ifopen", SqlDbType.NVarChar,50),
					new SqlParameter("@CompanyID", SqlDbType.Int,4)};
			parameters[0].Value = model.id;
			parameters[1].Value = model.title;
			parameters[2].Value = model.xuanze;
			parameters[3].Value = model.username;
			parameters[4].Value = model.realname;
			parameters[5].Value = model.Gkusername;
			parameters[6].Value = model.Gkrealname;
			parameters[7].Value = model.type;
			parameters[8].Value = model.ifopen;
			parameters[9].Value = model.CompanyID;

			DB.ExecuteNonQuery(CommandType.Text,strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void toupiaobt_Delete(long id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("delete from {0}toupiaobt ",sPre);
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.BigInt)};
			parameters[0].Value = id;

			DB.ExecuteNonQuery(CommandType.Text,strSql.ToString(),parameters);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Entity.toupiaobt toupiaobt_GetEntity(long id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("select "+ sFieldtoupiaobt +"  from {0}toupiaobt ",sPre);
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.BigInt)};
			parameters[0].Value = id;
			Entity.toupiaobt model=null;
			using (IDataReader dataReader = DB.ExecuteReader(CommandType.Text, strSql.ToString(),parameters))
			{
				if(dataReader.Read())
				{
					model= toupiaobt_ReaderBind(dataReader);
				}
			}
			return model;
		}
		/// <summary>
		/// 获取统计
		/// </summary>
		public int toupiaobt_GetCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("select count(*)  from {0}toupiaobt ",sPre);
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
		public DataSet toupiaobt_GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(sFieldtoupiaobt );
            strSql.AppendFormat(" FROM {0}toupiaobt ", sPre);
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
		public List<Entity.toupiaobt> toupiaobt_GetListArray(string strWhere)
		{
			return toupiaobt_GetListArray(0,strWhere,""); 
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public List<Entity.toupiaobt> toupiaobt_GetListArray(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(sFieldtoupiaobt );
			strSql.AppendFormat(" FROM {0}toupiaobt ",sPre);
			if(strWhere.Trim()!="")
			{
                strSql.Append(" where " + strWhere);
			}
			if(filedOrder.Trim()!="")
			{
				strSql.Append(" order by  "+filedOrder);
			}
			List<Entity.toupiaobt> list = new List<Entity.toupiaobt>();
			using (IDataReader dataReader = DB.ExecuteReader(CommandType.Text, strSql.ToString()))
			{
				while (dataReader.Read())
				{
					list.Add(toupiaobt_ReaderBind(dataReader));
				}
			}
			return list;
		}


		/// <summary>
		/// 获得分页数据
		/// </summary>
		public List<Entity.toupiaobt> toupiaobt_GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby,out int RecordCount)
		{
			List<Entity.toupiaobt> list = new List<Entity.toupiaobt>();
            using (IDataReader dataReader = SplitPages.GetListPages_SP(DB,"toupiaobt", PageSize, PageIndex, Fileds, "id", oderby, strWhere, out RecordCount,sPre))
			{
				while (dataReader.Read())
				{
					list.Add(toupiaobt_ReaderBind(dataReader));
				}
			}
			return list;
		}


		/// <summary>
		/// 对象实体绑定数据
		/// </summary>
		public Entity.toupiaobt toupiaobt_ReaderBind(IDataReader dataReader)
		{
			Entity.toupiaobt model=new Entity.toupiaobt();
			object ojb; 
			ojb = dataReader["id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.id=(long)ojb;
			}
			model.title=dataReader["title"].ToString();
			model.xuanze=dataReader["xuanze"].ToString();
			model.username=dataReader["username"].ToString();
			model.realname=dataReader["realname"].ToString();
			model.Gkusername=dataReader["Gkusername"].ToString();
			model.Gkrealname=dataReader["Gkrealname"].ToString();
			model.type=dataReader["type"].ToString();
			model.ifopen=dataReader["ifopen"].ToString();
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

