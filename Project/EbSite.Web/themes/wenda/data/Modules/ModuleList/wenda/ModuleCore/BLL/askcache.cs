using System;
using System.Data;
using System.Collections.Generic;
using System.Web.UI.WebControls;
namespace EbSite.Modules.Wenda.ModuleCore.BLL
{
	/// <summary>
	/// ҵ���߼���AskCache ��ժҪ˵����
	/// </summary>
	public class AskCache: Base.BLLBase<Entity.AskCache, int> 
	{
		public static readonly AskCache Instance = new AskCache();
		private  AskCache()
		{
		}
		#region  ��Ա����

		/// <summary>
		/// �õ����ID
		/// </summary>
		public int GetMaxId()
		{
			return dalHelper.AskCache_GetMaxId();
		}

		/// <summary>
		/// �Ƿ���ڸü�¼
		/// </summary>
		public bool Exists(int id)
		{
			return dalHelper.AskCache_Exists(id);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		override public int Add(Entity.AskCache model)
		{
			base.InvalidateCache();
			return dalHelper.AskCache_Add(model);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		override public void Update(Entity.AskCache model)
		{
			base.InvalidateCache();
			dalHelper.AskCache_Update(model);
		}
        /// <summary>
        /// ����һ������
        /// </summary>
        public void UpdateEx(Entity.AskCache model)
        {
            base.InvalidateCache();
            dalHelper.AskCache_UpdateEx(model);
        }

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		override public void Delete(int id)
		{
			base.InvalidateCache();
			
			dalHelper.AskCache_Delete(id);
		}

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		override public Entity.AskCache GetEntity(int id)
		{
			
			string rawKey = string.Concat("GetEntity-", id);
            Entity.AskCache etEntity = base.GetCacheItem<Entity.AskCache>(rawKey);
			if (Equals(etEntity,null))
			{
				etEntity = dalHelper.AskCache_GetEntity(id);
				if (!Equals(etEntity,null))
					base.AddCacheItem(rawKey, etEntity);
			}
			return etEntity;
		}

        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        public Entity.AskCache GetEntity(int keyid, int keytype)
        {
            return dalHelper.AskCache_GetEntity(keyid,keytype); ;
        }

		/// <summary>
		/// ��������б�
		/// </summary>
		public int GetCount(string strWhere)
		{
			return dalHelper.AskCache_GetCount(strWhere);
		}
		/// <summary>
		/// ��������б�
		/// </summary>
		public int GetCountCache(string strWhere)
		{
			string rawKey = string.Concat("GetCount-", strWhere);
            string sCount = base.GetCacheItem<string>(rawKey);
			if (string.IsNullOrEmpty(sCount))
			{
				sCount = GetCount(strWhere).ToString();
				if (!string.IsNullOrEmpty(sCount))
					base.AddCacheItem(rawKey, sCount);
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
		public DataSet GetList(string strWhere)
		{
			return GetListCache(0,strWhere,"");
		}
		/// <summary>
		/// ��������б�
		/// </summary>
		public DataSet GetList()
		{
			return GetList("");
		}
		/// <summary>
		/// ��������б�
		/// </summary>
		public DataSet GetList(int Top, string strWhere, string filedOrder)
		{
			return dalHelper.AskCache_GetList( Top,  strWhere,  filedOrder);
		}
		/// <summary>
		/// ��������б�
		/// </summary>
		
        public DataSet GetListCache(int Top, string strWhere, string filedOrder)
        {
            string rawKey = string.Concat("GetList-", strWhere, Top, filedOrder);
            byte[] ibyte = base.GetCacheItem<byte[]>(rawKey);
            DataSet lstData = null;
            if (Equals(ibyte, null))
            {
                lstData = GetList(Top, strWhere, filedOrder);
                ibyte = EbSite.Core.DataSetHelper.GetBinaryFormatDataSet(lstData);
                if (!Equals(ibyte, null))
                    base.AddCacheItem(rawKey, ibyte);
            }
            else
            {
                lstData = Core.DataSetHelper.RetrieveDataSet(ibyte);
            }
            return lstData;
        }
		/// <summary>
		/// ��������б�
		/// </summary>
		override public List<Entity.AskCache> GetListArray(int Top, string strWhere, string filedOrder)
		{
			return dalHelper.AskCache_GetListArray( Top,  strWhere,  filedOrder);
		}
		/// <summary>
		/// ��������б�
		/// </summary>
		public List<Entity.AskCache> GetListArrayCache(int Top, string strWhere, string filedOrder)
		{
			string rawKey = string.Concat("GetListArray-", strWhere,Top,filedOrder);
            List<Entity.AskCache> lstData = base.GetCacheItem<List<Entity.AskCache>>(rawKey);
			if (Equals(lstData,null))
			{
				//�ӻ�����ã������¼�
				lstData = base.GetListArrayEv( Top,  strWhere,  filedOrder);
				if (!Equals(lstData,null))
					base.AddCacheItem(rawKey, lstData);
			}
			return lstData;
		}
		/// <summary>
		/// ��������б�
		/// </summary>
		public List<Entity.AskCache> GetListArray(int Top,  string filedOrder)
		{
			return GetListArrayCache( Top,  "",  filedOrder);
		}
		/// <summary>
		/// ��������б�
		/// </summary>
		public List<Entity.AskCache> GetListArray(string strWhere)
		{
			return GetListArrayCache( 0,  strWhere,  "");
		}
		/// <summary>
		/// ��������б�
		/// </summary>
		override public List<Entity.AskCache> GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds,string oderby, out int RecordCount)
		{
			return dalHelper.AskCache_GetListPages( PageIndex,  PageSize,  strWhere,  Fileds, oderby, out  RecordCount);
		}
		/// <summary>
		/// ��������б�
		/// </summary>
		public List<Entity.AskCache> GetListPagesCache(int PageIndex, int PageSize, string strWhere, string Fileds,string oderby, out int RecordCount)
		{
			string rawKey = string.Concat("GlPages-", PageIndex,PageSize,strWhere,Fileds,oderby);
			string rawKeyCount = string.Concat("C-", rawKey);
            List<Entity.AskCache> lstData = base.GetCacheItem<List<Entity.AskCache>>(rawKey);
			int iRecordCount = -1;
			if (Equals(lstData,null))
			{
				//�ӻ�����ã������¼�
				lstData = base.GetListPagesEv(  PageIndex,  PageSize,  strWhere,  Fileds, oderby, out  RecordCount);
				if (!Equals(lstData,null))
				{
					base.AddCacheItem(rawKey, lstData);
					base.AddCacheItem(rawKeyCount, RecordCount.ToString());
				}
			}
			if(iRecordCount==-1)
			{
                string sCount = base.GetCacheItem<string>(rawKeyCount);
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
		public List<Entity.AskCache> GetListPages(int PageIndex, int PageSize, out int RecordCount)
		{
			return GetListPagesCache( PageIndex,  PageSize,  "",  "", "", out  RecordCount);
		}
		/// <summary>
		/// ��������б�-��ҳ
		/// </summary>
		public List<Entity.AskCache> GetListPages(int PageIndex, int PageSize, string strWhere, string oderby, out int RecordCount)
		{
			return GetListPagesCache( PageIndex,  PageSize,  strWhere,  "", oderby, out  RecordCount);
		}
		/// <summary>
		/// ��������б�-��ҳ
		/// </summary>
		public List<Entity.AskCache> GetListPages(int PageIndex, int PageSize, string strWhere, string oderby)
		{
			int iCount = 0;
			return GetListPagesCache(PageIndex, PageSize, strWhere, "", oderby, out iCount);
		}
		/// <summary>
		/// ����-��ҳ
		/// </summary>
		public List<Entity.AskCache> SearchLike(int PageIndex, int PageSize, string oderby, out int RecordCount, string sKeyWord, string ColumnName)
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
		/// <summary>
		/// �޸�ʱ��ȡ��ǰʵ����������ؼ���PlaceHolder
		/// </summary>
		public void InitModifyCtr(string id, PlaceHolder ph)
		{
			if (!string.IsNullOrEmpty(id))
			{
				int ThisId = int.Parse(id);
				Entity.AskCache mdEt = GetEntity(ThisId);
				foreach (System.Web.UI.Control uc in ph.Controls)
				{
					if (Equals(uc.ID, null)) continue;
					string sValue = "";
					if (Equals(uc.ID.ToLower(), "id".ToLower()))
					{
						sValue = mdEt.id.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "keyid".ToLower()))
					{
						sValue = mdEt.keyid.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "keytype".ToLower()))
					{
						sValue = mdEt.keytype.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "randomids".ToLower()))
					{
						sValue = mdEt.randomids.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "dateline".ToLower()))
					{
						sValue = mdEt.dateline.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "addtime".ToLower()))
					{
						sValue = mdEt.addtime.ToString();
					}
				SetValueFromControl(uc, sValue);
				}
			}
		}
		/// <summary>
		/// ��ȡ�ؼ��������ӳ�䵽һ��ʵ�壬���ű������ʵ��������
		/// </summary>
		public void SaveEntityFromCtr(PlaceHolder ph)
		{
				SaveEntityFromCtr(ph,null);
		}
		/// <summary>
		/// ��ȡ�ؼ��������ӳ�䵽һ��ʵ�壬���ű������ʵ��������
		/// </summary>
		public void SaveEntityFromCtr(PlaceHolder ph, List<EbSite.Base.BLL.OtherColumn> lstOtherColumn)
		{
			Entity.AskCache mdEntity = GetEntityFromCtr(ph);
			if(!Equals(lstOtherColumn,null) && lstOtherColumn.Count>0)
			{
				foreach (EbSite.Base.BLL.OtherColumn column in lstOtherColumn)
				{
					if(Equals(column.ColumnName.ToLower(), "id".ToLower()))
					{
						mdEntity.id = int.Parse(column.ColumnValue);
					}
					else if(Equals(column.ColumnName.ToLower(), "keyid".ToLower()))
					{
						mdEntity.keyid = int.Parse(column.ColumnValue);
					}
					else if(Equals(column.ColumnName.ToLower(), "keytype".ToLower()))
					{
						mdEntity.keytype = int.Parse(column.ColumnValue);
					}
					else if(Equals(column.ColumnName.ToLower(), "randomids".ToLower()))
					{
						mdEntity.randomids = column.ColumnValue;
					}
					else if(Equals(column.ColumnName.ToLower(), "dateline".ToLower()))
					{
						mdEntity.dateline = int.Parse(column.ColumnValue);
					}
					else if(Equals(column.ColumnName.ToLower(), "addtime".ToLower()))
					{
						mdEntity.addtime = DateTime.Parse(column.ColumnValue);
					}
				}
			}
			if (mdEntity.id>0)
			{
				Update(mdEntity);
			}else{
				 Add(mdEntity);
			}
		}
		/// <summary>
		/// ��PlaceHolder�л�ȡһ��ʵ��
		/// </summary>
		public Entity.AskCache GetEntityFromCtr(PlaceHolder ph)
		{
			Entity.AskCache mdEt = new Entity.AskCache();
			string sKeyID;
			if (GetIDFromCtr(ph, out sKeyID))
			{
				mdEt = GetEntity(int.Parse(sKeyID));
			}
			foreach (System.Web.UI.Control uc in ph.Controls)
			{
				if (Equals(uc.ID, null)) continue;
				string sValue = GetValueFromControl(uc);
					if(Equals(uc.ID.ToLower(),"id".ToLower()))
					{
						mdEt.id = int.Parse(sValue);
					}
					else if(Equals(uc.ID.ToLower(),"keyid".ToLower()))
					{
						mdEt.keyid = int.Parse(sValue);
					}
					else if(Equals(uc.ID.ToLower(),"keytype".ToLower()))
					{
						mdEt.keytype = int.Parse(sValue);
					}
					else if(Equals(uc.ID.ToLower(),"randomids".ToLower()))
					{
						mdEt.randomids = sValue;
					}
					else if(Equals(uc.ID.ToLower(),"dateline".ToLower()))
					{
						mdEt.dateline = int.Parse(sValue);
					}
					else if(Equals(uc.ID.ToLower(),"addtime".ToLower()))
					{
						mdEt.addtime = DateTime.Parse(sValue);
					}
			}
		return mdEt;
		}

		#endregion  ��Ա����
		
		#region  �Զ��巽��

        /// <summary>
        /// �ж��Ƿ����
        /// </summary>
        /// <param name="keyid">����ID</param>
        /// <param name="keytype">��������</param>
        /// <returns></returns>
        public bool IsTimeOut(int keyid, int keytype)
        {
            return dalHelper.AskCache_IsTimeOut(keyid, keytype);
        }
        /// <summary>
        /// �Ƿ���ڸü�¼
        /// </summary>
        /// <param name="keyid">����ID</param>
        /// <param name="keytype">��������</param>
        public bool Exists(int keyid, int keytype)
        {
            return dalHelper.AskCache_Exists(keyid, keytype);
        }

		#endregion  �Զ��巽��
	}
}

