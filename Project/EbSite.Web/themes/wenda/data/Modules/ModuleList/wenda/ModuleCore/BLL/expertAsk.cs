using System;
using System.Data;
using System.Collections.Generic;
using System.Web.UI.WebControls;
namespace EbSite.Modules.Wenda.ModuleCore.BLL
{
	/// <summary>
	/// ҵ���߼���expertAsk ��ժҪ˵����
	/// </summary>
	public class expertAsk: Base.BLLBase<Entity.expertAsk, int> 
	{
		public static readonly expertAsk Instance = new expertAsk();
		private  expertAsk()
		{
		}
		#region  ��Ա����

		/// <summary>
		/// �õ����ID
		/// </summary>
		public int GetMaxId()
		{
			return dalHelper.expertAsk_GetMaxId();
		}

		/// <summary>
		/// �Ƿ���ڸü�¼
		/// </summary>
		public bool Exists(int id)
		{
			return dalHelper.expertAsk_Exists(id);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		override public int Add(Entity.expertAsk model)
		{
			base.InvalidateCache();
			return dalHelper.expertAsk_Add(model);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		override public void Update(Entity.expertAsk model)
		{
			base.InvalidateCache();
			dalHelper.expertAsk_Update(model);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		override public void Delete(int id)
		{
			base.InvalidateCache();
			
			dalHelper.expertAsk_Delete(id);
		}

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		override public Entity.expertAsk GetEntity(int id)
		{
			
			string rawKey = string.Concat("GetEntity-", id);
            Entity.expertAsk etEntity = base.GetCacheItem<Entity.expertAsk>(rawKey);
			if (Equals(etEntity,null))
			{
				etEntity = dalHelper.expertAsk_GetEntity(id);
				if (!Equals(etEntity,null))
					base.AddCacheItem(rawKey, etEntity);
			}
			return etEntity;
		}

		/// <summary>
		/// ��������б�
		/// </summary>
		public int GetCount(string strWhere)
		{
			return dalHelper.expertAsk_GetCount(strWhere);
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
			return dalHelper.expertAsk_GetList( Top,  strWhere,  filedOrder);
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
		override public List<Entity.expertAsk> GetListArray(int Top, string strWhere, string filedOrder)
		{
			return dalHelper.expertAsk_GetListArray( Top,  strWhere,  filedOrder);
		}
		/// <summary>
		/// ��������б�
		/// </summary>
		public List<Entity.expertAsk> GetListArrayCache(int Top, string strWhere, string filedOrder)
		{
			string rawKey = string.Concat("GetListArray-", strWhere,Top,filedOrder);
            List<Entity.expertAsk> lstData = base.GetCacheItem<List<Entity.expertAsk>>(rawKey);
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
		public List<Entity.expertAsk> GetListArray(int Top,  string filedOrder)
		{
			return GetListArrayCache( Top,  "",  filedOrder);
		}
		/// <summary>
		/// ��������б�
		/// </summary>
		public List<Entity.expertAsk> GetListArray(string strWhere)
		{
			return GetListArrayCache( 0,  strWhere,  "");
		}
		/// <summary>
		/// ��������б�
		/// </summary>
		override public List<Entity.expertAsk> GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds,string oderby, out int RecordCount)
		{
			return dalHelper.expertAsk_GetListPages( PageIndex,  PageSize,  strWhere,  Fileds, oderby, out  RecordCount);
		}
		/// <summary>
		/// ��������б�
		/// </summary>
		public List<Entity.expertAsk> GetListPagesCache(int PageIndex, int PageSize, string strWhere, string Fileds,string oderby, out int RecordCount)
		{
			string rawKey = string.Concat("GlPages-", PageIndex,PageSize,strWhere,Fileds,oderby);
			string rawKeyCount = string.Concat("C-", rawKey);
            List<Entity.expertAsk> lstData = base.GetCacheItem<List<Entity.expertAsk>>(rawKey);
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
		public List<Entity.expertAsk> GetListPages(int PageIndex, int PageSize, out int RecordCount)
		{
			return GetListPagesCache( PageIndex,  PageSize,  "",  "", "", out  RecordCount);
		}
		/// <summary>
		/// ��������б�-��ҳ
		/// </summary>
		public List<Entity.expertAsk> GetListPages(int PageIndex, int PageSize, string strWhere, string oderby, out int RecordCount)
		{
			return GetListPagesCache( PageIndex,  PageSize,  strWhere,  "", oderby, out  RecordCount);
		}
		/// <summary>
		/// ��������б�-��ҳ
		/// </summary>
		public List<Entity.expertAsk> GetListPages(int PageIndex, int PageSize, string strWhere, string oderby)
		{
			int iCount = 0;
			return GetListPagesCache(PageIndex, PageSize, strWhere, "", oderby, out iCount);
		}
		/// <summary>
		/// ����-��ҳ
		/// </summary>
		public List<Entity.expertAsk> SearchLike(int PageIndex, int PageSize, string oderby, out int RecordCount, string sKeyWord, string ColumnName)
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
				Entity.expertAsk mdEt = GetEntity(ThisId);
				foreach (System.Web.UI.Control uc in ph.Controls)
				{
					if (Equals(uc.ID, null)) continue;
					string sValue = "";
					if (Equals(uc.ID.ToLower(), "id".ToLower()))
					{
						sValue = mdEt.id.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "Qid".ToLower()))
					{
						sValue = mdEt.Qid.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "UserID".ToLower()))
					{
						sValue = mdEt.UserID.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "State".ToLower()))
					{
						sValue = mdEt.State.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "OpTime".ToLower()))
					{
						sValue = mdEt.OpTime.ToString();
					}
                    else if (Equals(uc.ID.ToLower(), "Title".ToLower()))
                    {
                        sValue = mdEt.Title.ToString();
                    }
                    else if (Equals(uc.ID.ToLower(), "AskDate".ToLower()))
                    {
                        sValue = mdEt.AskDate.ToString();
                    }
                    else if (Equals(uc.ID.ToLower(), "ClassId".ToLower()))
                    {
                        sValue = mdEt.ClassID.ToString();
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
			Entity.expertAsk mdEntity = GetEntityFromCtr(ph);
			if(!Equals(lstOtherColumn,null) && lstOtherColumn.Count>0)
			{
				foreach (EbSite.Base.BLL.OtherColumn column in lstOtherColumn)
				{
					if(Equals(column.ColumnName.ToLower(), "id".ToLower()))
					{
						mdEntity.id = int.Parse(column.ColumnValue);
					}
					else if(Equals(column.ColumnName.ToLower(), "Qid".ToLower()))
					{
						mdEntity.Qid = int.Parse(column.ColumnValue);
					}
					else if(Equals(column.ColumnName.ToLower(), "UserID".ToLower()))
					{
						mdEntity.UserID = int.Parse(column.ColumnValue);
					}
					else if(Equals(column.ColumnName.ToLower(), "State".ToLower()))
					{
						mdEntity.State = int.Parse(column.ColumnValue);
					}
					else if(Equals(column.ColumnName.ToLower(), "OpTime".ToLower()))
					{
						mdEntity.OpTime = DateTime.Parse(column.ColumnValue);
					}
                    else if (Equals(column.ColumnName.ToLower(), "Title".ToLower()))
                    {
                        mdEntity.Title = column.ColumnValue;
                    }
                    else if (Equals(column.ColumnName.ToLower(), "AskDate".ToLower()))
                    {
                        mdEntity.AskDate = DateTime.Parse(column.ColumnValue);
                    }
                    else if (Equals(column.ColumnName.ToLower(), "ClassId".ToLower()))
                    {
                        mdEntity.ClassID = int.Parse(column.ColumnValue);
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
		public Entity.expertAsk GetEntityFromCtr(PlaceHolder ph)
		{
			Entity.expertAsk mdEt = new Entity.expertAsk();
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
					else if(Equals(uc.ID.ToLower(),"Qid".ToLower()))
					{
						mdEt.Qid = int.Parse(sValue);
					}
					else if(Equals(uc.ID.ToLower(),"UserID".ToLower()))
					{
						mdEt.UserID = int.Parse(sValue);
					}
					else if(Equals(uc.ID.ToLower(),"State".ToLower()))
					{
						mdEt.State = int.Parse(sValue);
					}
					else if(Equals(uc.ID.ToLower(),"OpTime".ToLower()))
					{
						mdEt.OpTime = DateTime.Parse(sValue);
					}
                    else if (Equals(uc.ID.ToLower(), "Title".ToLower()))
                    {
                        mdEt.Title = sValue;
                    }
                    else if (Equals(uc.ID.ToLower(), "AskDate".ToLower()))
                    {
                        mdEt.AskDate = DateTime.Parse(sValue);
                    }
                    else if (Equals(uc.ID.ToLower(), "ClassId".ToLower()))
                    {
                        mdEt.ClassID = int.Parse(sValue);
                    }
                
			}
		return mdEt;
		}

		#endregion  ��Ա����
		
		#region  �Զ��巽��
		
		#endregion  �Զ��巽��
	}
}

