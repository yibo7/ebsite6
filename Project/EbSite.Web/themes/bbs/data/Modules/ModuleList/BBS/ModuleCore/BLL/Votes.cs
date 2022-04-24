using System;
using System.Data;
using System.Collections.Generic;
using System.Web.UI.WebControls;
namespace EbSite.Modules.BBS.ModuleCore.BLL
{
	/// <summary>
	/// ҵ���߼���Votes ��ժҪ˵����
	/// </summary>
	public class Votes: Base.BLLBase<Entity.Votes, int> 
	{
		public static readonly Votes Instance = new Votes();
		private  Votes()
		{
		}
		#region  ��Ա����

		/// <summary>
		/// �õ����ID
		/// </summary>
		public int GetMaxId()
		{
			return dalHelper.Votes_GetMaxId();
		}

		/// <summary>
		/// �Ƿ���ڸü�¼
		/// </summary>
		public bool Exists(int id)
		{
			return dalHelper.Votes_Exists(id);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		override public int Add(Entity.Votes model)
		{
			base.InvalidateCache();
			return dalHelper.Votes_Add(model);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		override public void Update(Entity.Votes model)
		{
			base.InvalidateCache();
			dalHelper.Votes_Update(model);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		override public void Delete(int id)
		{
			base.InvalidateCache();
			
			dalHelper.Votes_Delete(id);
		}

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		override public Entity.Votes GetEntity(int id)
		{
			
			string rawKey = string.Concat("GetEntity-", id);
			Entity.Votes etEntity = base.GetCacheItem(rawKey) as Entity.Votes;
			if (Equals(etEntity,null))
			{
				etEntity = dalHelper.Votes_GetEntity(id);
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
			return dalHelper.Votes_GetCount(strWhere);
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
			return dalHelper.Votes_GetList( Top,  strWhere,  filedOrder);
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
		override public List<Entity.Votes> GetListArray(int Top, string strWhere, string filedOrder)
		{
			return dalHelper.Votes_GetListArray( Top,  strWhere,  filedOrder);
		}
		/// <summary>
		/// ��������б�
		/// </summary>
		public List<Entity.Votes> GetListArrayCache(int Top, string strWhere, string filedOrder)
		{
			string rawKey = string.Concat("GetListArray-", strWhere,Top,filedOrder);
			 List<Entity.Votes> lstData = base.GetCacheItem(rawKey) as List<Entity.Votes>;
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
		public List<Entity.Votes> GetListArray(int Top,  string filedOrder)
		{
			return GetListArrayCache( Top,  "",  filedOrder);
		}
		/// <summary>
		/// ��������б�
		/// </summary>
		public List<Entity.Votes> GetListArray(string strWhere)
		{
			return GetListArrayCache( 0,  strWhere,  "");
		}
		/// <summary>
		/// ��������б�
		/// </summary>
		override public List<Entity.Votes> GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds,string oderby, out int RecordCount)
		{
			return dalHelper.Votes_GetListPages( PageIndex,  PageSize,  strWhere,  Fileds, oderby, out  RecordCount);
		}
		/// <summary>
		/// ��������б�
		/// </summary>
		public List<Entity.Votes> GetListPagesCache(int PageIndex, int PageSize, string strWhere, string Fileds,string oderby, out int RecordCount)
		{
			string rawKey = string.Concat("GlPages-", PageIndex,PageSize,strWhere,Fileds,oderby);
			string rawKeyCount = string.Concat("C-", rawKey);
			 List<Entity.Votes> lstData = base.GetCacheItem(rawKey) as List<Entity.Votes>;
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
		public List<Entity.Votes> GetListPages(int PageIndex, int PageSize, out int RecordCount)
		{
			return GetListPagesCache( PageIndex,  PageSize,  "",  "", "", out  RecordCount);
		}
		/// <summary>
		/// ��������б�-��ҳ
		/// </summary>
		public List<Entity.Votes> GetListPages(int PageIndex, int PageSize, string strWhere, string oderby, out int RecordCount)
		{
			return GetListPagesCache( PageIndex,  PageSize,  strWhere,  "", oderby, out  RecordCount);
		}
		/// <summary>
		/// ��������б�-��ҳ
		/// </summary>
		public List<Entity.Votes> GetListPages(int PageIndex, int PageSize, string strWhere, string oderby)
		{
			int iCount = 0;
			return GetListPagesCache(PageIndex, PageSize, strWhere, "", oderby, out iCount);
		}
		/// <summary>
		/// ����-��ҳ
		/// </summary>
		public List<Entity.Votes> SearchLike(int PageIndex, int PageSize, string oderby, out int RecordCount, string sKeyWord, string ColumnName)
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
				Entity.Votes mdEt = GetEntity(ThisId);
				foreach (System.Web.UI.Control uc in ph.Controls)
				{
					if (Equals(uc.ID, null)) continue;
					string sValue = "";
					if (Equals(uc.ID.ToLower(), "id".ToLower()))
					{
						sValue = mdEt.id.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "VoteName".ToLower()))
					{
						sValue = mdEt.VoteName.ToString();
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
					else if (Equals(uc.ID.ToLower(), "VoteDescription".ToLower()))
					{
						sValue = mdEt.VoteDescription.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "VoteConclusion".ToLower()))
					{
						sValue = mdEt.VoteConclusion.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "OptionCount".ToLower()))
					{
						sValue = mdEt.OptionCount.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "OptionFlag".ToLower()))
					{
						sValue = mdEt.OptionFlag.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "VoteCount".ToLower()))
					{
						sValue = mdEt.VoteCount.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "CreatedTime".ToLower()))
					{
						sValue = mdEt.CreatedTime.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "CreatedIP".ToLower()))
					{
						sValue = mdEt.CreatedIP.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "UpdatedTime".ToLower()))
					{
						sValue = mdEt.UpdatedTime.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "ExpiredTime".ToLower()))
					{
						sValue = mdEt.ExpiredTime.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "LockFlag".ToLower()))
					{
						sValue = mdEt.LockFlag.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "BBSTopicID".ToLower()))
					{
						sValue = mdEt.BBSTopicID.ToString();
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
			Entity.Votes mdEntity = GetEntityFromCtr(ph);
			if(!Equals(lstOtherColumn,null) && lstOtherColumn.Count>0)
			{
				foreach (EbSite.Base.BLL.OtherColumn column in lstOtherColumn)
				{
					if(Equals(column.ColumnName.ToLower(), "id".ToLower()))
					{
						mdEntity.id = int.Parse(column.ColumnValue);
					}
					else if(Equals(column.ColumnName.ToLower(), "VoteName".ToLower()))
					{
						mdEntity.VoteName = column.ColumnValue;
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
					else if(Equals(column.ColumnName.ToLower(), "VoteDescription".ToLower()))
					{
						mdEntity.VoteDescription = column.ColumnValue;
					}
					else if(Equals(column.ColumnName.ToLower(), "VoteConclusion".ToLower()))
					{
						mdEntity.VoteConclusion = column.ColumnValue;
					}
					else if(Equals(column.ColumnName.ToLower(), "OptionCount".ToLower()))
					{
						mdEntity.OptionCount = int.Parse(column.ColumnValue);
					}
					else if(Equals(column.ColumnName.ToLower(), "OptionFlag".ToLower()))
					{
						mdEntity.OptionFlag = int.Parse(column.ColumnValue);
					}
					else if(Equals(column.ColumnName.ToLower(), "VoteCount".ToLower()))
					{
						mdEntity.VoteCount = int.Parse(column.ColumnValue);
					}
					else if(Equals(column.ColumnName.ToLower(), "CreatedTime".ToLower()))
					{
						mdEntity.CreatedTime = DateTime.Parse(column.ColumnValue);
					}
					else if(Equals(column.ColumnName.ToLower(), "CreatedIP".ToLower()))
					{
						mdEntity.CreatedIP = column.ColumnValue;
					}
					else if(Equals(column.ColumnName.ToLower(), "UpdatedTime".ToLower()))
					{
						mdEntity.UpdatedTime = DateTime.Parse(column.ColumnValue);
					}
					else if(Equals(column.ColumnName.ToLower(), "ExpiredTime".ToLower()))
					{
						mdEntity.ExpiredTime = DateTime.Parse(column.ColumnValue);
					}
					else if(Equals(column.ColumnName.ToLower(), "LockFlag".ToLower()))
					{
						mdEntity.LockFlag = int.Parse(column.ColumnValue);
					}
					else if(Equals(column.ColumnName.ToLower(), "BBSTopicID".ToLower()))
					{
						mdEntity.BBSTopicID = long.Parse(column.ColumnValue);
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
		public Entity.Votes GetEntityFromCtr(PlaceHolder ph)
		{
			Entity.Votes mdEt = new Entity.Votes();
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
					else if(Equals(uc.ID.ToLower(),"VoteName".ToLower()))
					{
						mdEt.VoteName = sValue;
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
					else if(Equals(uc.ID.ToLower(),"VoteDescription".ToLower()))
					{
						mdEt.VoteDescription = sValue;
					}
					else if(Equals(uc.ID.ToLower(),"VoteConclusion".ToLower()))
					{
						mdEt.VoteConclusion = sValue;
					}
					else if(Equals(uc.ID.ToLower(),"OptionCount".ToLower()))
					{
						mdEt.OptionCount = int.Parse(sValue);
					}
					else if(Equals(uc.ID.ToLower(),"OptionFlag".ToLower()))
					{
						mdEt.OptionFlag = int.Parse(sValue);
					}
					else if(Equals(uc.ID.ToLower(),"VoteCount".ToLower()))
					{
						mdEt.VoteCount = int.Parse(sValue);
					}
					else if(Equals(uc.ID.ToLower(),"CreatedTime".ToLower()))
					{
						mdEt.CreatedTime = DateTime.Parse(sValue);
					}
					else if(Equals(uc.ID.ToLower(),"CreatedIP".ToLower()))
					{
						mdEt.CreatedIP = sValue;
					}
					else if(Equals(uc.ID.ToLower(),"UpdatedTime".ToLower()))
					{
						mdEt.UpdatedTime = DateTime.Parse(sValue);
					}
					else if(Equals(uc.ID.ToLower(),"ExpiredTime".ToLower()))
					{
						mdEt.ExpiredTime = DateTime.Parse(sValue);
					}
					else if(Equals(uc.ID.ToLower(),"LockFlag".ToLower()))
					{
						mdEt.LockFlag = int.Parse(sValue);
					}
					else if(Equals(uc.ID.ToLower(),"BBSTopicID".ToLower()))
					{
						mdEt.BBSTopicID = long.Parse(sValue);
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
       
        public List<Entity.Votes> GetListArrayByTopicId(string tId)
        {
            string sWhere = string.Format("BBSTopicID='{0}'", tId);
            return GetListArray(sWhere);
        }
        #endregion  �Զ��巽��
	}
}

