using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using EbSite.Base.DataProfile;
namespace EbSite.Modules.Ask.ModuleCore.DAL.SqlServer
{
	/// <summary>
	/// ���ݷ�����Ask��
	/// </summary>
	public partial class Ask
	{
		private string sFieldConfig = "id,Configs,UpdateTime,UserID";
		#region  ��Ա����

		/// <summary>
		/// �õ����ID
		/// </summary>
		public int Config_GetMaxId()
		{
			return DB.GetMaxID("id", string.Format("{0}Config",sPre)); 
		}

		/// <summary>
		/// �Ƿ���ڸü�¼
		/// </summary>
		public bool Config_Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("select count(1) from {0}Config",sPre);
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;

			return DB.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// ����һ������
		/// </summary>
		public int Config_Add(Entity.Config model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("insert into {0}Config(",sPre);
			strSql.Append("Configs,UpdateTime,UserID)");
			strSql.Append(" values (");
			strSql.Append("@Configs,@UpdateTime,@UserID)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					//new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@Configs", SqlDbType.Image),
					new SqlParameter("@UpdateTime", SqlDbType.DateTime),
					new SqlParameter("@UserID", SqlDbType.Int,4)};
			//parameters[0].Value = model.id;
			parameters[0].Value = model.Configs;
			parameters[1].Value = model.UpdateTime;
			parameters[2].Value = model.UserID;

			object obj = DB.ExecuteScalar(CommandType.Text,strSql.ToString(),parameters);
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
		/// ����һ������
		/// </summary>
		public void Config_Update(Entity.Config model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("update {0}Config set ",sPre);
			strSql.Append("Configs=@Configs,");
			strSql.Append("UpdateTime=@UpdateTime,");
			strSql.Append("UserID=@UserID");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@Configs", SqlDbType.Image),
					new SqlParameter("@UpdateTime", SqlDbType.DateTime),
					new SqlParameter("@UserID", SqlDbType.Int,4)};
			parameters[0].Value = model.id;
			parameters[1].Value = model.Configs;
			parameters[2].Value = model.UpdateTime;
			parameters[3].Value = model.UserID;

			DB.ExecuteNonQuery(CommandType.Text,strSql.ToString(),parameters);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public void Config_Delete(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("delete from {0}Config ",sPre);
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;

			DB.ExecuteNonQuery(CommandType.Text,strSql.ToString(),parameters);
		}

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public Entity.Config Config_GetEntity(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("select "+ sFieldConfig +"  from {0}Config ",sPre);
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;
			Entity.Config model=null;
			using (IDataReader dataReader = DB.ExecuteReader(CommandType.Text, strSql.ToString(),parameters))
			{
				if(dataReader.Read())
				{
					model= Config_ReaderBind(dataReader);
				}
			}
			return model;
		}
		/// <summary>
		/// ��ȡͳ��
		/// </summary>
		public int Config_GetCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("select count(*)  from {0}Config ",sPre);
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
		/// ���ǰ��������
		/// </summary>
		public DataSet Config_GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(sFieldConfig );
			strSql.AppendFormat(" FROM {0}Config ",sPre);
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			if(filedOrder.Trim()!="")
			{
				strSql.Append(" order by  "+filedOrder);
			}
			return DB.ExecuteDataset(CommandType.Text, strSql.ToString());
		}

		/// <summary>
		/// ��������б���DataSetЧ�ʸߣ��Ƽ�ʹ�ã�
		/// </summary>
		public List<Entity.Config> Config_GetListArray(string strWhere)
		{
			return Config_GetListArray(0,strWhere,""); 
		}

		/// <summary>
		/// ���ǰ��������
		/// </summary>
		public List<Entity.Config> Config_GetListArray(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(sFieldConfig );
			strSql.AppendFormat(" FROM {0}Config ",sPre);
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			if(filedOrder.Trim()!="")
			{
				strSql.Append(" order by  "+filedOrder);
			}
			List<Entity.Config> list = new List<Entity.Config>();
			using (IDataReader dataReader = DB.ExecuteReader(CommandType.Text, strSql.ToString()))
			{
				while (dataReader.Read())
				{
					list.Add(Config_ReaderBind(dataReader));
				}
			}
			return list;
		}


		/// <summary>
		/// ��÷�ҳ����
		/// </summary>
		public List<Entity.Config> Config_GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby,out int RecordCount)
		{
			List<Entity.Config> list = new List<Entity.Config>();
			using (IDataReader dataReader = SplitPages.GetListPages_SP(DB,"Config", PageSize, PageIndex, Fileds, "id", oderby, strWhere, out RecordCount,sPre))
			{
				while (dataReader.Read())
				{
					list.Add(Config_ReaderBind(dataReader));
				}
			}
			return list;
		}


		/// <summary>
		/// ����ʵ�������
		/// </summary>
		public Entity.Config Config_ReaderBind(IDataReader dataReader)
		{
			Entity.Config model=new Entity.Config();
			object ojb; 
			ojb = dataReader["id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.id=(int)ojb;
			}
			ojb = dataReader["Configs"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Configs=(byte[])ojb;
			}
			ojb = dataReader["UpdateTime"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.UpdateTime=(DateTime)ojb;
			}
			ojb = dataReader["UserID"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.UserID=(int)ojb;
			}
			return model;
		}

		#endregion  ��Ա����
	}
}

