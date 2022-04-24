using System;
using System.Data;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using EbSite.Base;
using EbSite.Base.Static;
using EbSite.Data.Interface;

namespace EbSite.BLL
{
	/// <summary>
	/// ҵ���߼���spiderlog ��ժҪ˵����
	/// </summary>
	public class spiderlog 
	{
		public static readonly spiderlog Instance = new spiderlog();
        private const double cachetime = 60.0;

        private const string Cachespiderlog = "spiderlog";
        private  spiderlog()
		{
		}
		#region  ��Ա����
		/// <summary>
		/// �Ƿ���ڸü�¼
		/// </summary>
		public bool Exists(long Id)
		{
			return DbProviderCms.GetInstance().spiderlog_Exists(Id);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		 public int Add(Entity.spiderlog model)
		{
			 
			return DbProviderCms.GetInstance().spiderlog_Add(model);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		 public void Update(Entity.spiderlog model)
		{
			
			DbProviderCms.GetInstance().spiderlog_Update(model);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		 public void Delete(long Id)
		{
			
			DbProviderCms.GetInstance().spiderlog_Delete(Id);
		}

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		 public Entity.spiderlog GetEntity(long Id)
		{

            string rawKey = string.Concat("GetEntity-", Id);
            Entity.spiderlog etEntity = Host.CacheApp.GetCacheItem<Entity.spiderlog>(rawKey, Cachespiderlog);
            if (Equals(etEntity, null))
            {
                etEntity = DbProviderCms.GetInstance().spiderlog_GetEntity(Id);
                if (!Equals(etEntity, null))
                    Host.CacheApp.AddCacheItem(rawKey, etEntity, cachetime, ETimeSpanModel.M, Cachespiderlog);
            }
            return etEntity;
        }

		/// <summary>
		/// ��������б�
		/// </summary>
		public int GetCount(string strWhere)
		{
			return DbProviderCms.GetInstance().spiderlog_GetCount(strWhere);
		}
		/// <summary>
		/// ��������б�
		/// </summary>
		public int GetCountCache(string strWhere)
		{
			string rawKey = string.Concat("GetCount-", strWhere);
			 string sCount = Host.CacheApp.GetCacheItem<string>(rawKey, Cachespiderlog);
            if (string.IsNullOrEmpty(sCount))
			{
				sCount = GetCount(strWhere).ToString();
				if (!string.IsNullOrEmpty(sCount)) 
                    Host.CacheApp.AddCacheItem(rawKey, sCount, cachetime, ETimeSpanModel.M, Cachespiderlog);
            }
			if (!string.IsNullOrEmpty(sCount))
			{
				return int.Parse(sCount);
			}
			return 0;
		}
		/// <summary>
		/// ��������б�
		/// </summary>
		public int GetCount()
		{
			return GetCountCache("");
		} 
		/// <summary>
		/// ��������б�
		/// </summary>
		public List<Entity.spiderlog> GetListArray(int Top, string strWhere, string filedOrder)
		{
			return DbProviderCms.GetInstance().spiderlog_GetListArray( Top,  strWhere,  filedOrder);
		}
		/// <summary>
		/// ��������б�
		/// </summary>
		public List<Entity.spiderlog> GetListArrayCache(int Top, string strWhere, string filedOrder)
		{
			string rawKey = string.Concat("GetListArray-", strWhere,Top,filedOrder);
			 List<Entity.spiderlog> lstData = Host.CacheApp.GetCacheItem<List<Entity.spiderlog>>(rawKey, Cachespiderlog);
            if (Equals(lstData,null))
			{
				//�ӻ�����ã������¼�
				lstData = GetListArray( Top,  strWhere,  filedOrder);
				if (!Equals(lstData,null))
                    Host.CacheApp.AddCacheItem(rawKey, lstData, cachetime, ETimeSpanModel.M, Cachespiderlog);
            }
			return lstData;
		}
		/// <summary>
		/// ��������б�
		/// </summary>
		public List<Entity.spiderlog> GetListArray(int Top,  string filedOrder)
		{
			return GetListArrayCache( Top,  "",  filedOrder);
		}
		/// <summary>
		/// ��������б�
		/// </summary>
		public List<Entity.spiderlog> GetListArray(string strWhere)
		{
			return GetListArrayCache( 0,  strWhere,  "");
		}
		/// <summary>
		/// ��������б�
		/// </summary>
		public List<Entity.spiderlog> GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds,string oderby, out int RecordCount)
		{
			return DbProviderCms.GetInstance().spiderlog_GetListPages( PageIndex,  PageSize,  strWhere,  Fileds, oderby, out  RecordCount);
		}
		/// <summary>
		/// ��������б�
		/// </summary>
		public List<Entity.spiderlog> GetListPagesCache(int PageIndex, int PageSize, string strWhere, string Fileds,string oderby, out int RecordCount)
		{
			string rawKey = string.Concat("GlPages-", PageIndex,PageSize,strWhere,Fileds,oderby);
			string rawKeyCount = string.Concat("C-", rawKey);
			 List<Entity.spiderlog> lstData = Host.CacheApp.GetCacheItem<List<Entity.spiderlog>>(rawKey, Cachespiderlog);
            int iRecordCount = -1;
			if (Equals(lstData,null))
			{
				//�ӻ�����ã������¼�
				lstData = GetListPages(  PageIndex,  PageSize,  strWhere,  Fileds, oderby, out  RecordCount);
				if (!Equals(lstData,null))
				{
                    Host.CacheApp.AddCacheItem(rawKey, lstData, cachetime, ETimeSpanModel.M, Cachespiderlog);
                    Host.CacheApp.AddCacheItem(rawKeyCount, RecordCount, cachetime, ETimeSpanModel.M, Cachespiderlog); 
				}
			}
			if(iRecordCount==-1)
			{
				string sCount = Host.CacheApp.GetCacheItem<string>(rawKeyCount, Cachespiderlog); 
				if (!string.IsNullOrEmpty(sCount))
				{
					RecordCount = int.Parse(sCount);
				}
				else
				{
					RecordCount = GetCountCache(strWhere);
				}
			}
			else
			{
				RecordCount = iRecordCount;
			}
			return lstData;
		}
		/// <summary>
		/// ��������б�-��ҳ
		/// </summary>
		public List<Entity.spiderlog> GetListPages(int PageIndex, int PageSize, out int RecordCount)
		{
			return GetListPagesCache( PageIndex,  PageSize,  "",  "", "", out  RecordCount);
		}
		/// <summary>
		/// ��������б�-��ҳ
		/// </summary>
		public List<Entity.spiderlog> GetListPages(int PageIndex, int PageSize, string strWhere, string oderby, out int RecordCount)
		{
			return GetListPagesCache( PageIndex,  PageSize,  strWhere,  "", oderby, out  RecordCount);
		}
		/// <summary>
		/// ��������б�-��ҳ
		/// </summary>
		public List<Entity.spiderlog> GetListPages(int PageIndex, int PageSize, string strWhere, string oderby)
		{
			int iCount = 0;
			return GetListPagesCache(PageIndex, PageSize, strWhere, "", oderby, out iCount);
		}
		/// <summary>
		/// ����-��ҳ
		/// </summary>
		public List<Entity.spiderlog> SearchLike(int PageIndex, int PageSize, string oderby, out int RecordCount, string sKeyWord, string ColumnName)
		{
			string strWhere = "";
			if (!string.IsNullOrEmpty(sKeyWord)) strWhere = string.Format("{0} like '%{1}%'", ColumnName, sKeyWord);
			if (string.IsNullOrEmpty(strWhere))
			{
			RecordCount = 0;
			return null;
			}
			return GetListPagesCache(PageIndex, PageSize, strWhere, "", oderby, out  RecordCount);
		}


        #endregion  ��Ա����

        #region  �Զ��巽��
        /// <summary>
        /// ͳ����������
        /// </summary>
        /// <param name="spiderid">The spiderid.</param>
        /// <param name="itype">����,1.�������ã�2�������ã�3ǰ7�����ã�4ǰ30������</param>
        /// <returns>System.Int32.</returns>
        public int GetLogCount(int spiderid, int itype)
	    {
	       return DbProviderCms.GetInstance().GetLogCount(spiderid, itype);

	    }

	    public List<Entity.ListItemModel> GetVisitSum(string strWhere,int iTop)
	    {
            return DbProviderCms.GetInstance().GetVisitSum(strWhere, iTop);
        }

	    public List<Entity.ListItemModel> GetVisitTime(int itype)
	    {
            return DbProviderCms.GetInstance().GetVisitTime(itype);
        }

	    #endregion  �Զ��巽��
        }
}

