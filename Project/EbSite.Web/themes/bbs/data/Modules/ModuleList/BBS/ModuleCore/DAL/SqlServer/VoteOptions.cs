using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using EbSite.Base.DataProfile;
namespace EbSite.Modules.BBS.ModuleCore.DAL.SqlServer
{
	/// <summary>
	/// ���ݷ�����BBS��
	/// </summary>
	public partial class BBS
	{
		private string sFieldVoteOptions = "id,VoteID,OptionName,VoteCount,VotePercent,CreatedTime,CompanyID";
		#region  ��Ա����

		/// <summary>
		/// �õ����ID
		/// </summary>
		public int VoteOptions_GetMaxId()
		{
			return DB.GetMaxID("id", string.Format("{0}VoteOptions",sPre)); 
		}

		/// <summary>
		/// �Ƿ���ڸü�¼
		/// </summary>
		public bool VoteOptions_Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("select count(1) from {0}VoteOptions",sPre);
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;

			return DB.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// ����һ������
		/// </summary>
		public int VoteOptions_Add(Entity.VoteOptions model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("insert into {0}VoteOptions(",sPre);
			strSql.Append("id,VoteID,OptionName,VoteCount,VotePercent,CreatedTime,CompanyID)");
			strSql.Append(" values (");
			strSql.Append("@id,@VoteID,@OptionName,@VoteCount,@VotePercent,@CreatedTime,@CompanyID)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@VoteID", SqlDbType.Int,4),
					new SqlParameter("@OptionName", SqlDbType.VarChar,500),
					new SqlParameter("@VoteCount", SqlDbType.Int,4),
					new SqlParameter("@VotePercent", SqlDbType.Decimal,9),
					new SqlParameter("@CreatedTime", SqlDbType.DateTime),
					new SqlParameter("@CompanyID", SqlDbType.Int,4)};
			parameters[0].Value = model.id;
			parameters[1].Value = model.VoteID;
			parameters[2].Value = model.OptionName;
			parameters[3].Value = model.VoteCount;
			parameters[4].Value = model.VotePercent;
			parameters[5].Value = model.CreatedTime;
			parameters[6].Value = model.CompanyID;

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
		public void VoteOptions_Update(Entity.VoteOptions model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("update {0}VoteOptions set ",sPre);
			strSql.Append("VoteID=@VoteID,");
			strSql.Append("OptionName=@OptionName,");
			strSql.Append("VoteCount=@VoteCount,");
			strSql.Append("VotePercent=@VotePercent,");
			strSql.Append("CreatedTime=@CreatedTime,");
			strSql.Append("CompanyID=@CompanyID");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@VoteID", SqlDbType.Int,4),
					new SqlParameter("@OptionName", SqlDbType.VarChar,500),
					new SqlParameter("@VoteCount", SqlDbType.Int,4),
					new SqlParameter("@VotePercent", SqlDbType.Decimal,9),
					new SqlParameter("@CreatedTime", SqlDbType.DateTime),
					new SqlParameter("@CompanyID", SqlDbType.Int,4)};
			parameters[0].Value = model.id;
			parameters[1].Value = model.VoteID;
			parameters[2].Value = model.OptionName;
			parameters[3].Value = model.VoteCount;
			parameters[4].Value = model.VotePercent;
			parameters[5].Value = model.CreatedTime;
			parameters[6].Value = model.CompanyID;

			DB.ExecuteNonQuery(CommandType.Text,strSql.ToString(),parameters);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public void VoteOptions_Delete(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("delete from {0}VoteOptions ",sPre);
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;

			DB.ExecuteNonQuery(CommandType.Text,strSql.ToString(),parameters);
		}

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public Entity.VoteOptions VoteOptions_GetEntity(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("select "+ sFieldVoteOptions +"  from {0}VoteOptions ",sPre);
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;
			Entity.VoteOptions model=null;
			using (IDataReader dataReader = DB.ExecuteReader(CommandType.Text, strSql.ToString(),parameters))
			{
				if(dataReader.Read())
				{
					model= VoteOptions_ReaderBind(dataReader);
				}
			}
			return model;
		}
		/// <summary>
		/// ��ȡͳ��
		/// </summary>
		public int VoteOptions_GetCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("select count(*)  from {0}VoteOptions ",sPre);
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
		public DataSet VoteOptions_GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(sFieldVoteOptions );
			strSql.AppendFormat(" FROM {0}VoteOptions ",sPre);
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
		public List<Entity.VoteOptions> VoteOptions_GetListArray(string strWhere)
		{
			return VoteOptions_GetListArray(0,strWhere,""); 
		}

		/// <summary>
		/// ���ǰ��������
		/// </summary>
		public List<Entity.VoteOptions> VoteOptions_GetListArray(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(sFieldVoteOptions );
			strSql.AppendFormat(" FROM {0}VoteOptions ",sPre);
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			if(filedOrder.Trim()!="")
			{
				strSql.Append(" order by  "+filedOrder);
			}
			List<Entity.VoteOptions> list = new List<Entity.VoteOptions>();
			using (IDataReader dataReader = DB.ExecuteReader(CommandType.Text, strSql.ToString()))
			{
				while (dataReader.Read())
				{
					list.Add(VoteOptions_ReaderBind(dataReader));
				}
			}
			return list;
		}


		/// <summary>
		/// ��÷�ҳ����
		/// </summary>
		public List<Entity.VoteOptions> VoteOptions_GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby,out int RecordCount)
		{
			List<Entity.VoteOptions> list = new List<Entity.VoteOptions>();
			using (IDataReader dataReader = SplitPages.GetListPages_SP(DB,"VoteOptions", PageSize, PageIndex, Fileds, "id", oderby, strWhere, out RecordCount,sPre))
			{
				while (dataReader.Read())
				{
					list.Add(VoteOptions_ReaderBind(dataReader));
				}
			}
			return list;
		}


		/// <summary>
		/// ����ʵ�������
		/// </summary>
		public Entity.VoteOptions VoteOptions_ReaderBind(IDataReader dataReader)
		{
			Entity.VoteOptions model=new Entity.VoteOptions();
			object ojb; 
			ojb = dataReader["id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.id=(int)ojb;
			}
			ojb = dataReader["VoteID"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.VoteID=(int)ojb;
			}
			model.OptionName=dataReader["OptionName"].ToString();
			ojb = dataReader["VoteCount"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.VoteCount=(int)ojb;
			}
			ojb = dataReader["VotePercent"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.VotePercent=(decimal)ojb;
			}
			ojb = dataReader["CreatedTime"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.CreatedTime=(DateTime)ojb;
			}
			ojb = dataReader["CompanyID"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.CompanyID=(int)ojb;
			}
			return model;
		}

		#endregion  ��Ա����
	}
}

