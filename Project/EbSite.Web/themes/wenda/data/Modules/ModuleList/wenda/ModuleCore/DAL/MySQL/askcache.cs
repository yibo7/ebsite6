using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using EbSite.Base.DataProfile;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;
namespace EbSite.Modules.Wenda.ModuleCore.DAL.MySQL
{
	/// <summary>
	/// ����ҳ �Ҳ�� �������Դ�����೤ʱ�� �仯��
	/// </summary>
    public partial class Ask
	{
		private string sFieldAskCache = "id,keyid,keytype,randomids,dateline,addtime";
		#region  ��Ա����

		/// <summary>
		/// �õ����ID
		/// </summary>
		public int AskCache_GetMaxId()
		{
			return DB.GetMaxID("id", string.Format("{0}AskCache",sPre)); 
		}
        
		/// <summary>
		/// �Ƿ���ڸü�¼
		/// </summary>
		public bool AskCache_Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("select count(1) from {0}AskCache",sPre);
			strSql.Append(" where id=?id ");
			MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32)};
			parameters[0].Value = id;

			return DB.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// ����һ������
		/// </summary>
		public int AskCache_Add(Entity.AskCache model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("insert into {0}AskCache(",sPre);
			strSql.Append("keyid,keytype,randomids,dateline,addtime)");
			strSql.Append(" values (");
			strSql.Append("?keyid,?keytype,?randomids,?dateline,?addtime)");
			 strSql.Append(";SELECT @@session.identity");
			MySqlParameter[] parameters = {
					new MySqlParameter("?keyid", MySqlDbType.Int32,11),
					new MySqlParameter("?keytype", MySqlDbType.Int32,11),
					new MySqlParameter("?randomids", MySqlDbType.VarChar,255),
					new MySqlParameter("?dateline", MySqlDbType.Int32,11),
					new MySqlParameter("?addtime", MySqlDbType.DateTime)};
			parameters[0].Value = model.keyid;
			parameters[1].Value = model.keytype;
			parameters[2].Value = model.randomids;
			parameters[3].Value = model.dateline;
			parameters[4].Value = model.addtime;

			object obj = DB.ExecuteScalar(CommandType.Text,strSql.ToString(),parameters);
			if (obj == null)
			{
				return AskCache_GetMaxId();
			}
			return 0;		}
		/// <summary>
		/// ����һ������
		/// </summary>
		public void AskCache_Update(Entity.AskCache model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("update {0}AskCache set ",sPre);
			strSql.Append("keyid=?keyid,");
			strSql.Append("keytype=?keytype,");
			strSql.Append("randomids=?randomids,");
			strSql.Append("dateline=?dateline,");
			strSql.Append("addtime=?addtime");
			strSql.Append(" where id=?id ");
			MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32,11),
					new MySqlParameter("?keyid", MySqlDbType.Int32,11),
					new MySqlParameter("?keytype", MySqlDbType.Int32,11),
					new MySqlParameter("?randomids", MySqlDbType.VarChar,255),
					new MySqlParameter("?dateline", MySqlDbType.Int32,11),
					new MySqlParameter("?addtime", MySqlDbType.DateTime)};
			parameters[0].Value = model.id;
			parameters[1].Value = model.keyid;
			parameters[2].Value = model.keytype;
			parameters[3].Value = model.randomids;
			parameters[4].Value = model.dateline;
			parameters[5].Value = model.addtime;

			DB.ExecuteNonQuery(CommandType.Text,strSql.ToString(),parameters);
		}
        /// <summary>
        /// ����һ������
        /// </summary>
        public void AskCache_UpdateEx(Entity.AskCache model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("update {0}AskCache set ", sPre);
            strSql.Append("randomids=?randomids,");
            strSql.Append("dateline=?dateline,");
            strSql.Append("addtime=?addtime");
            strSql.Append(" where keyid=?keyid and keytype=?keytype");
            MySqlParameter[] parameters = {
					new MySqlParameter("?randomids", MySqlDbType.VarChar,255),
					new MySqlParameter("?dateline", MySqlDbType.Int32,11),
					new MySqlParameter("?addtime", MySqlDbType.DateTime),
                    new MySqlParameter("?keyid", MySqlDbType.Int32,11),
					new MySqlParameter("?keytype", MySqlDbType.Int32,11)};
            parameters[0].Value = model.randomids;
            parameters[1].Value = model.dateline;
            parameters[2].Value = model.addtime;
            parameters[3].Value = model.keyid;
            parameters[4].Value = model.keytype;
            DB.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public void AskCache_Delete(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("delete from {0}AskCache ",sPre);
			strSql.Append(" where id=?id ");
			MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32)};
			parameters[0].Value = id;

			DB.ExecuteNonQuery(CommandType.Text,strSql.ToString(),parameters);
		}

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public Entity.AskCache AskCache_GetEntity(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("select "+ sFieldAskCache +"  from {0}AskCache ",sPre);
			strSql.Append(" where id=?id ");
			MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32)};
			parameters[0].Value = id;
			Entity.AskCache model=null;
			using (IDataReader dataReader = DB.ExecuteReader(CommandType.Text, strSql.ToString(),parameters))
			{
				if(dataReader.Read())
				{
					model= AskCache_ReaderBind(dataReader);
				}
			}
			return model;
		}
        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        public Entity.AskCache AskCache_GetEntity(int keyid, int keytype)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select " + sFieldAskCache + "  from {0}AskCache ", sPre);
            strSql.Append(" where keyid=?keyid and keytype=?keytype ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?keyid", MySqlDbType.Int32),
                    new MySqlParameter("?keytype", MySqlDbType.Int32)};
            parameters[0].Value = keyid;
            parameters[1].Value = keytype;
            Entity.AskCache model = null;
            using (IDataReader dataReader = DB.ExecuteReader(CommandType.Text, strSql.ToString(), parameters))
            {
                if (dataReader.Read())
                {
                    model = AskCache_ReaderBind(dataReader);
                }
            }
            return model;
        }
		/// <summary>
		/// ��ȡͳ��
		/// </summary>
		public int AskCache_GetCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("select count(*)  from {0}AskCache ",sPre);
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
		public DataSet AskCache_GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			
			strSql.Append(sFieldAskCache );
			strSql.AppendFormat(" FROM {0}AskCache ",sPre);
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			if(filedOrder.Trim()!="")
			{
				strSql.Append(" order by  "+filedOrder);
			}

            if (Top > 0)
            {
                strSql.Append(" limits " + Top.ToString());
            }
			return DB.ExecuteDataset(CommandType.Text, strSql.ToString());
		}

		/// <summary>
		/// ��������б���DataSetЧ�ʸߣ��Ƽ�ʹ�ã�
		/// </summary>
		public List<Entity.AskCache> AskCache_GetListArray(string strWhere)
		{
			return AskCache_GetListArray(0,strWhere,""); 
		}

		/// <summary>
		/// ���ǰ��������
		/// </summary>
		public List<Entity.AskCache> AskCache_GetListArray(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			
			strSql.Append(sFieldAskCache );
			strSql.AppendFormat(" FROM {0}AskCache ",sPre);
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			if(filedOrder.Trim()!="")
			{
				strSql.Append(" order by  "+filedOrder);
			}
            if (Top > 0)
            {
                strSql.Append(" limits " + Top.ToString());
            }
			List<Entity.AskCache> list = new List<Entity.AskCache>();
			using (IDataReader dataReader = DB.ExecuteReader(CommandType.Text, strSql.ToString()))
			{
				while (dataReader.Read())
				{
					list.Add(AskCache_ReaderBind(dataReader));
				}
			}
			return list;
		}


		/// <summary>
		/// ��÷�ҳ����
		/// </summary>
		public List<Entity.AskCache> AskCache_GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby,out int RecordCount)
		{
			List<Entity.AskCache> list = new List<Entity.AskCache>();
			RecordCount = AskCache_GetCount(strWhere);
			string strSql = SplitPages.GetSplitPagesMySql(DbHelperCms.Instance, "AskCache", PageSize, PageIndex, Fileds, "id",  oderby, strWhere, sPre);
			using (IDataReader dataReader = DbHelperCms.Instance.ExecuteReader(CommandType.Text, strSql))
			{
				while (dataReader.Read())
				{
					list.Add(AskCache_ReaderBind(dataReader));
				}
			}
			return list;
		}


		/// <summary>
		/// ����ʵ�������
		/// </summary>
		public Entity.AskCache AskCache_ReaderBind(IDataReader dataReader)
		{
			Entity.AskCache model=new Entity.AskCache();
			object ojb; 
			ojb = dataReader["id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.id=(int)ojb;
			}
			ojb = dataReader["keyid"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.keyid=(int)ojb;
			}
			ojb = dataReader["keytype"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.keytype=(int)ojb;
			}
			model.randomids=dataReader["randomids"].ToString();
			ojb = dataReader["dateline"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.dateline=(int)ojb;
			}
			ojb = dataReader["addtime"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.addtime=(DateTime)ojb;
			}
			return model;
		}

		#endregion  ��Ա����

        #region �Զ��巽��

        /// <summary>
        /// �ж��Ƿ����
        /// </summary>
        /// <param name="keyid">����ID</param>
        /// <param name="keytype">��������</param>
        /// <returns></returns>
        public bool AskCache_IsTimeOut(int keyid, int keytype)
        {
            int timesTamp = EbSite.Core.SqlDateTimeInt.GetSecond(DateTime.Now);
            string strSql = string.Format("select dateline from {2}askcache where keyid={0} and keytype={1} limit 1", keyid, keytype, sPre);
            object obj = DB.ExecuteScalar(CommandType.Text, strSql);
            if (obj != null)
            {
                if (timesTamp>=Core.Utils.ObjectToInt(obj, 0))
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// �Ƿ���ڸü�¼
        /// </summary>
        /// <param name="keyid">����ID</param>
        /// <param name="keytype">��������</param>
        public bool AskCache_Exists(int keyid, int keytype)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select count(1) from {0}AskCache", sPre);
            strSql.Append(" where keyid=?keyid and keytype=?keytype ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?keyid", MySqlDbType.Int32),
                    new MySqlParameter("?keytype", MySqlDbType.Int32)};
            parameters[0].Value = keyid;
            parameters[1].Value = keytype;

            return DB.Exists(strSql.ToString(), parameters);
        }

        #endregion �Զ��巽��
	}
}

