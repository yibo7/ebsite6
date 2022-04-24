using System;
using System.Data;
using System.Collections.Generic;
using System.Web.UI.WebControls;
namespace EbSite.Modules.BBS.ModuleCore.BLL
{
	/// <summary>
	/// ҵ���߼���Voters ��ժҪ˵����
	/// </summary>
	public class Voters: Base.BLLBase<Entity.Voters, int> 
	{
		public static readonly Voters Instance = new Voters();
		private  Voters()
		{
		}
		#region  ��Ա����

		/// <summary>
		/// �õ����ID
		/// </summary>
		public int GetMaxId()
		{
			return dalHelper.Voters_GetMaxId();
		}

		/// <summary>
		/// �Ƿ���ڸü�¼
		/// </summary>
		public bool Exists(int id)
		{
			return dalHelper.Voters_Exists(id);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		override public int Add(Entity.Voters model)
		{
			base.InvalidateCache();
			return dalHelper.Voters_Add(model);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		override public void Update(Entity.Voters model)
		{
			base.InvalidateCache();
			dalHelper.Voters_Update(model);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		override public void Delete(int id)
		{
			base.InvalidateCache();
			
			dalHelper.Voters_Delete(id);
		}

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		override public Entity.Voters GetEntity(int id)
		{
			
			string rawKey = string.Concat("GetEntity-", id);
			Entity.Voters etEntity = base.GetCacheItem(rawKey) as Entity.Voters;
			if (Equals(etEntity,null))
			{
				etEntity = dalHelper.Voters_GetEntity(id);
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
			return dalHelper.Voters_GetCount(strWhere);
		}
		/// <summary>
		/// ��������б�
		/// </summary>
		public int GetCountCache(string strWhere)
		{
			string rawKey = string.Concat("GetCount-", strWhere);
			 string sCount = base.GetCacheItem(rawKey) as string;
			if (string.IsNullOrEmpty(sCount))
			{
				sCount = GetCountCache(strWhere).ToString();
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
			return dalHelper.Voters_GetList( Top,  strWhere,  filedOrder);
		}
		/// <summary>
		/// ��������б�
		/// </summary>
		public DataSet GetListCache(int Top, string strWhere, string filedOrder)
		{
			string rawKey = string.Concat("GetList-", strWhere,Top,filedOrder);
			 DataSet lstData = base.GetCacheItem(rawKey) as DataSet;
			if (Equals(lstData,null))
			{
				lstData = GetList( Top,  strWhere,  filedOrder);
				if (!Equals(lstData,null))
					base.AddCacheItem(rawKey, lstData);
			}
			return lstData;
		}
		/// <summary>
		/// ��������б�
		/// </summary>
		override public List<Entity.Voters> GetListArray(int Top, string strWhere, string filedOrder)
		{
			return dalHelper.Voters_GetListArray( Top,  strWhere,  filedOrder);
		}
		/// <summary>
		/// ��������б�
		/// </summary>
		public List<Entity.Voters> GetListArrayCache(int Top, string strWhere, string filedOrder)
		{
			string rawKey = string.Concat("GetListArray-", strWhere,Top,filedOrder);
			 List<Entity.Voters> lstData = base.GetCacheItem(rawKey) as List<Entity.Voters>;
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
		public List<Entity.Voters> GetListArray(int Top,  string filedOrder)
		{
			return GetListArrayCache( Top,  "",  filedOrder);
		}
		/// <summary>
		/// ��������б�
		/// </summary>
		public List<Entity.Voters> GetListArray(string strWhere)
		{
			return GetListArrayCache( 0,  strWhere,  "");
		}
		/// <summary>
		/// ��������б�
		/// </summary>
		override public List<Entity.Voters> GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds,string oderby, out int RecordCount)
		{
			return dalHelper.Voters_GetListPages( PageIndex,  PageSize,  strWhere,  Fileds, oderby, out  RecordCount);
		}
		/// <summary>
		/// ��������б�
		/// </summary>
		public List<Entity.Voters> GetListPagesCache(int PageIndex, int PageSize, string strWhere, string Fileds,string oderby, out int RecordCount)
		{
			string rawKey = string.Concat("GlPages-", PageIndex,PageSize,strWhere,Fileds,oderby);
			string rawKeyCount = string.Concat("C-", rawKey);
			 List<Entity.Voters> lstData = base.GetCacheItem(rawKey) as List<Entity.Voters>;
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
				string sCount = base.GetCacheItem(rawKeyCount) as string;
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
		public List<Entity.Voters> GetListPages(int PageIndex, int PageSize, out int RecordCount)
		{
			return GetListPagesCache( PageIndex,  PageSize,  "",  "", "", out  RecordCount);
		}
		/// <summary>
		/// ��������б�-��ҳ
		/// </summary>
		public List<Entity.Voters> GetListPages(int PageIndex, int PageSize, string strWhere, string oderby, out int RecordCount)
		{
			return GetListPagesCache( PageIndex,  PageSize,  strWhere,  "", oderby, out  RecordCount);
		}
		/// <summary>
		/// ��������б�-��ҳ
		/// </summary>
		public List<Entity.Voters> GetListPages(int PageIndex, int PageSize, string strWhere, string oderby)
		{
			int iCount = 0;
			return GetListPagesCache(PageIndex, PageSize, strWhere, "", oderby, out iCount);
		}
		/// <summary>
		/// ����-��ҳ
		/// </summary>
		public List<Entity.Voters> SearchLike(int PageIndex, int PageSize, string oderby, out int RecordCount, string sKeyWord, string ColumnName)
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
				Entity.Voters mdEt = GetEntity(ThisId);
				foreach (System.Web.UI.Control uc in ph.Controls)
				{
					if (Equals(uc.ID, null)) continue;
					string sValue = "";
					if (Equals(uc.ID.ToLower(), "id".ToLower()))
					{
						sValue = mdEt.id.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "VoteID".ToLower()))
					{
						sValue = mdEt.VoteID.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "VoteContent".ToLower()))
					{
						sValue = mdEt.VoteContent.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "UserID".ToLower()))
					{
						sValue = mdEt.UserID.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "UserName".ToLower()))
					{
						sValue = mdEt.UserName.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "UserHeadImageUrl".ToLower()))
					{
						sValue = mdEt.UserHeadImageUrl.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "CreatedTime".ToLower()))
					{
						sValue = mdEt.CreatedTime.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "CreatedIP".ToLower()))
					{
						sValue = mdEt.CreatedIP.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "CompanyID".ToLower()))
					{
						sValue = mdEt.CompanyID.ToString();
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
			Entity.Voters mdEntity = GetEntityFromCtr(ph);
			if(!Equals(lstOtherColumn,null) && lstOtherColumn.Count>0)
			{
				foreach (EbSite.Base.BLL.OtherColumn column in lstOtherColumn)
				{
					if(Equals(column.ColumnName.ToLower(), "id".ToLower()))
					{
						mdEntity.id = int.Parse(column.ColumnValue);
					}
					else if(Equals(column.ColumnName.ToLower(), "VoteID".ToLower()))
					{
						mdEntity.VoteID = int.Parse(column.ColumnValue);
					}
					else if(Equals(column.ColumnName.ToLower(), "VoteContent".ToLower()))
					{
						mdEntity.VoteContent = column.ColumnValue;
					}
					else if(Equals(column.ColumnName.ToLower(), "UserID".ToLower()))
					{
						mdEntity.UserID = int.Parse(column.ColumnValue);
					}
					else if(Equals(column.ColumnName.ToLower(), "UserName".ToLower()))
					{
						mdEntity.UserName = column.ColumnValue;
					}
					else if(Equals(column.ColumnName.ToLower(), "UserHeadImageUrl".ToLower()))
					{
						mdEntity.UserHeadImageUrl = column.ColumnValue;
					}
					else if(Equals(column.ColumnName.ToLower(), "CreatedTime".ToLower()))
					{
						mdEntity.CreatedTime = DateTime.Parse(column.ColumnValue);
					}
					else if(Equals(column.ColumnName.ToLower(), "CreatedIP".ToLower()))
					{
						mdEntity.CreatedIP = column.ColumnValue;
					}
					else if(Equals(column.ColumnName.ToLower(), "CompanyID".ToLower()))
					{
						mdEntity.CompanyID = int.Parse(column.ColumnValue);
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
		public Entity.Voters GetEntityFromCtr(PlaceHolder ph)
		{
			Entity.Voters mdEt = new Entity.Voters();
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
					else if(Equals(uc.ID.ToLower(),"VoteID".ToLower()))
					{
						mdEt.VoteID = int.Parse(sValue);
					}
					else if(Equals(uc.ID.ToLower(),"VoteContent".ToLower()))
					{
						mdEt.VoteContent = sValue;
					}
					else if(Equals(uc.ID.ToLower(),"UserID".ToLower()))
					{
						mdEt.UserID = int.Parse(sValue);
					}
					else if(Equals(uc.ID.ToLower(),"UserName".ToLower()))
					{
						mdEt.UserName = sValue;
					}
					else if(Equals(uc.ID.ToLower(),"UserHeadImageUrl".ToLower()))
					{
						mdEt.UserHeadImageUrl = sValue;
					}
					else if(Equals(uc.ID.ToLower(),"CreatedTime".ToLower()))
					{
						mdEt.CreatedTime = DateTime.Parse(sValue);
					}
					else if(Equals(uc.ID.ToLower(),"CreatedIP".ToLower()))
					{
						mdEt.CreatedIP = sValue;
					}
					else if(Equals(uc.ID.ToLower(),"CompanyID".ToLower()))
					{
						mdEt.CompanyID = int.Parse(sValue);
					}
			}
		return mdEt;
		}

		#endregion  ��Ա����
		
		#region  �Զ��巽��
        public List<Entity.Voters> GetListArrayVoteID(string voteId)
        {
            string sWhere = string.Format("VoteID='{0}'", voteId);
            return GetListArray(sWhere);
        }
		#endregion  �Զ��巽��
	}
}

