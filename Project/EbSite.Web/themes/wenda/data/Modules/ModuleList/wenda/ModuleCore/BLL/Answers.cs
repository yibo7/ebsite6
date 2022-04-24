using System;
using System.Data;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using EbSite.Base.Static;
using EbSite.Modules.Wenda.ModuleCore.DAL.MySQL;

namespace EbSite.Modules.Wenda.ModuleCore.BLL
{
	/// <summary>
	/// ҵ���߼���Answers ��ժҪ˵����
	/// </summary>
	public class Answers: Base.BLLBase<Entity.Answers, int> 
	{
		public static readonly Answers Instance = new Answers();
		private  Answers()
		{
		}
		#region  ��Ա����

		/// <summary>
		/// �õ����ID
		/// </summary>
		public int GetMaxId()
		{
			return dalHelper.Answers_GetMaxId();
		}

		/// <summary>
		/// �Ƿ���ڸü�¼
		/// </summary>
		public bool Exists(int id)
		{
			return dalHelper.Answers_Exists(id);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		override public int Add(Entity.Answers model)
		{
			base.InvalidateCache();
			return dalHelper.Answers_Add(model);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		override public void Update(Entity.Answers model)
		{
			base.InvalidateCache();
			dalHelper.Answers_Update(model);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		override public void Delete(int id)
		{
			base.InvalidateCache();
			
			dalHelper.Answers_Delete(id);
		}

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		override public Entity.Answers GetEntity(int id)
		{
			
			string rawKey = string.Concat("GetEntity-", id);
			Entity.Answers etEntity = base.GetCacheItem<Entity.Answers>(rawKey);
			if (Equals(etEntity,null))
			{
				etEntity = dalHelper.Answers_GetEntity(id);
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
			return dalHelper.Answers_GetCount(strWhere);
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
			return dalHelper.Answers_GetList( Top,  strWhere,  filedOrder);
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
		override public List<Entity.Answers> GetListArray(int Top, string strWhere, string filedOrder)
		{
			return dalHelper.Answers_GetListArray( Top,  strWhere,  filedOrder);
		}
		/// <summary>
		/// ��������б�
		/// </summary>
		public List<Entity.Answers> GetListArrayCache(int Top, string strWhere, string filedOrder)
		{
			string rawKey = string.Concat("GetListArray-", strWhere,Top,filedOrder);
            List<Entity.Answers> lstData = base.GetCacheItem<List<Entity.Answers>>(rawKey);
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
		public List<Entity.Answers> GetListArray(int Top,  string filedOrder)
		{
			return GetListArrayCache( Top,  "",  filedOrder);
		}
		/// <summary>
		/// ��������б�
		/// </summary>
		public List<Entity.Answers> GetListArray(string strWhere)
		{
			return GetListArrayCache( 0,  strWhere,  "");
		}
		/// <summary>
		/// ��������б�
		/// </summary>
		override public List<Entity.Answers> GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds,string oderby, out int RecordCount)
		{
			return dalHelper.Answers_GetListPages( PageIndex,  PageSize,  strWhere,  Fileds, oderby, out  RecordCount);
		}
		/// <summary>
		/// ��������б�
		/// </summary>
		public List<Entity.Answers> GetListPagesCache(int PageIndex, int PageSize, string strWhere, string Fileds,string oderby, out int RecordCount)
		{
			string rawKey = string.Concat("GlPages-", PageIndex,PageSize,strWhere,Fileds,oderby);
			string rawKeyCount = string.Concat("C-", rawKey);
            List<Entity.Answers> lstData = base.GetCacheItem<List<Entity.Answers>>(rawKey);
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
		public List<Entity.Answers> GetListPages(int PageIndex, int PageSize, out int RecordCount)
		{
			return GetListPagesCache( PageIndex,  PageSize,  "",  "", "", out  RecordCount);
		}
		/// <summary>
		/// ��������б�-��ҳ
		/// </summary>
		public List<Entity.Answers> GetListPages(int PageIndex, int PageSize, string strWhere, string oderby, out int RecordCount)
		{
			return GetListPagesCache( PageIndex,  PageSize,  strWhere,  "", oderby, out  RecordCount);
		}
		/// <summary>
		/// ��������б�-��ҳ
		/// </summary>
		public List<Entity.Answers> GetListPages(int PageIndex, int PageSize, string strWhere, string oderby)
		{
			int iCount = 0;
			return GetListPagesCache(PageIndex, PageSize, strWhere, "", oderby, out iCount);
		}
		/// <summary>
		/// ����-��ҳ
		/// </summary>
		public List<Entity.Answers> SearchLike(int PageIndex, int PageSize, string oderby, out int RecordCount, string sKeyWord, string ColumnName)
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
				Entity.Answers mdEt = GetEntity(ThisId);
				foreach (System.Web.UI.Control uc in ph.Controls)
				{
					if (Equals(uc.ID, null)) continue;
					string sValue = "";
					if (Equals(uc.ID.ToLower(), "id".ToLower()))
					{
						sValue = mdEt.id.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "QID".ToLower()))
					{
						sValue = mdEt.QID.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "QUserID".ToLower()))
					{
						sValue = mdEt.QUserID.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "AnswerUserID".ToLower()))
					{
						sValue = mdEt.AnswerUserID.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "AnswerContent".ToLower()))
					{
						sValue = mdEt.AnswerContent.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "IsAdoption".ToLower()))
					{
						sValue = mdEt.IsAdoption.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "AnswerTime".ToLower()))
					{
						sValue = mdEt.AnswerTime.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "IsDel".ToLower()))
					{
						sValue = mdEt.IsDel.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "AnswerIP".ToLower()))
					{
						sValue = mdEt.AnswerIP.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "ReferBook".ToLower()))
					{
						sValue = mdEt.ReferBook.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "IsAnonymity".ToLower()))
					{
						sValue = mdEt.IsAnonymity.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "AnswerUpdateTime".ToLower()))
					{
						sValue = mdEt.AnswerUpdateTime.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "Score".ToLower()))
					{
						sValue = mdEt.Score.ToString();
					}
                    else if (Equals(uc.ID.ToLower(), "GoodAsk".ToLower()))
					{
                        sValue = mdEt.GoodAsk.ToString();
					}
                    else if (Equals(uc.ID.ToLower(), "IsApproved".ToLower()))
					{
                        sValue = mdEt.IsApproved.ToString();
					}
                    else if (Equals(uc.ID.ToLower(), "ThanksInfo".ToLower()))
					{
                        sValue = mdEt.ThanksInfo.ToString();
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
			Entity.Answers mdEntity = GetEntityFromCtr(ph);
			if(!Equals(lstOtherColumn,null) && lstOtherColumn.Count>0)
			{
				foreach (EbSite.Base.BLL.OtherColumn column in lstOtherColumn)
				{
					if(Equals(column.ColumnName.ToLower(), "id".ToLower()))
					{
						mdEntity.id = int.Parse(column.ColumnValue);
					}
					else if(Equals(column.ColumnName.ToLower(), "QID".ToLower()))
					{
						mdEntity.QID = int.Parse(column.ColumnValue);
					}
					else if(Equals(column.ColumnName.ToLower(), "QUserID".ToLower()))
					{
						mdEntity.QUserID = int.Parse(column.ColumnValue);
					}
					else if(Equals(column.ColumnName.ToLower(), "AnswerUserID".ToLower()))
					{
						mdEntity.AnswerUserID = int.Parse(column.ColumnValue);
					}
					else if(Equals(column.ColumnName.ToLower(), "AnswerContent".ToLower()))
					{
						mdEntity.AnswerContent = column.ColumnValue;
					}
					else if(Equals(column.ColumnName.ToLower(), "IsAdoption".ToLower()))
					{
						mdEntity.IsAdoption = bool.Parse(column.ColumnValue);
					}
					else if(Equals(column.ColumnName.ToLower(), "AnswerTime".ToLower()))
					{
						mdEntity.AnswerTime = DateTime.Parse(column.ColumnValue);
					}
					else if(Equals(column.ColumnName.ToLower(), "IsDel".ToLower()))
					{
						mdEntity.IsDel = bool.Parse(column.ColumnValue);
					}
					else if(Equals(column.ColumnName.ToLower(), "AnswerIP".ToLower()))
					{
						mdEntity.AnswerIP = column.ColumnValue;
					}
					else if(Equals(column.ColumnName.ToLower(), "ReferBook".ToLower()))
					{
						mdEntity.ReferBook = column.ColumnValue;
					}
					else if(Equals(column.ColumnName.ToLower(), "IsAnonymity".ToLower()))
					{
						mdEntity.IsAnonymity = bool.Parse(column.ColumnValue);
					}
					else if(Equals(column.ColumnName.ToLower(), "AnswerUpdateTime".ToLower()))
					{
						mdEntity.AnswerUpdateTime = DateTime.Parse(column.ColumnValue);
					}
					else if(Equals(column.ColumnName.ToLower(), "Score".ToLower()))
					{
						mdEntity.Score = int.Parse(column.ColumnValue);
					}
                    else if (Equals(column.ColumnName.ToLower(), "GoodAsk".ToLower()))
					{
                        mdEntity.GoodAsk = int.Parse(column.ColumnValue);
					}
                    else if (Equals(column.ColumnName.ToLower(), "IsApproved".ToLower()))
					{
                        mdEntity.IsApproved = int.Parse(column.ColumnValue);
					}
                    else if (Equals(column.ColumnName.ToLower(), "ThanksInfo".ToLower()))
					{
                        mdEntity.ThanksInfo = column.ColumnValue;
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
		public Entity.Answers GetEntityFromCtr(PlaceHolder ph)
		{
			Entity.Answers mdEt = new Entity.Answers();
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
					else if(Equals(uc.ID.ToLower(),"QID".ToLower()))
					{
						mdEt.QID = int.Parse(sValue);
					}
					else if(Equals(uc.ID.ToLower(),"QUserID".ToLower()))
					{
						mdEt.QUserID = int.Parse(sValue);
					}
					else if(Equals(uc.ID.ToLower(),"AnswerUserID".ToLower()))
					{
						mdEt.AnswerUserID = int.Parse(sValue);
					}
					else if(Equals(uc.ID.ToLower(),"AnswerContent".ToLower()))
					{
						mdEt.AnswerContent = sValue;
					}
					else if(Equals(uc.ID.ToLower(),"IsAdoption".ToLower()))
					{
						mdEt.IsAdoption = bool.Parse(sValue);
					}
					else if(Equals(uc.ID.ToLower(),"AnswerTime".ToLower()))
					{
						mdEt.AnswerTime = DateTime.Parse(sValue);
					}
					else if(Equals(uc.ID.ToLower(),"IsDel".ToLower()))
					{
						mdEt.IsDel = bool.Parse(sValue);
					}
					else if(Equals(uc.ID.ToLower(),"AnswerIP".ToLower()))
					{
						mdEt.AnswerIP = sValue;
					}
					else if(Equals(uc.ID.ToLower(),"ReferBook".ToLower()))
					{
						mdEt.ReferBook = sValue;
					}
					else if(Equals(uc.ID.ToLower(),"IsAnonymity".ToLower()))
					{
						mdEt.IsAnonymity = bool.Parse(sValue);
					}
					else if(Equals(uc.ID.ToLower(),"AnswerUpdateTime".ToLower()))
					{
						mdEt.AnswerUpdateTime = DateTime.Parse(sValue);
					}
					else if(Equals(uc.ID.ToLower(),"Score".ToLower()))
					{
						mdEt.Score = int.Parse(sValue);
					}
                    else if (Equals(uc.ID.ToLower(), "GoodAsk".ToLower()))
					{
                        mdEt.GoodAsk = int.Parse(sValue);
					}
                    else if (Equals(uc.ID.ToLower(), "IsApproved".ToLower()))
					{
                        mdEt.IsApproved = int.Parse(sValue);
					}
                    else if (Equals(uc.ID.ToLower(), "ThanksInfo".ToLower()))
					{
                        mdEt.ThanksInfo = sValue;
					}
                
                
			}
		return mdEt;
		}

		#endregion  ��Ա����
		
		#region  �Զ��巽��
        /// <summary>
        /// ͳ�ư����˵��ܸ���
        /// </summary>
        /// <param name="UserID"></param>
        /// <returns></returns>
        public string HelpUserCount(int UserID)
        {
            string cache = string.Concat("usercount-", UserID);
            string str = EbSite.Base.Host.CacheApp.GetCacheItem<string>(cache, "huc");// as string;
            if(string.IsNullOrEmpty(str))
            {
                str=dalHelper.HelpUserCount(UserID);
                EbSite.Base.Host.CacheApp.AddCacheItem(cache, str, 10, ETimeSpanModel.FZ, "huc");
            }

            return str;
        }
		#endregion  �Զ��巽��

        public List<BNewsClass> BNews_GetListArray(int Top, string strWhere, string filedOrder)
        {
            return dalHelper.DALBNews_GetListArray(Top, strWhere, filedOrder);
        }

         /// <summary>
        /// ��ȡ����ʴ�
        /// </summary>
        /// <param name="bid">Ҫ������Ʒ��ID</param>
        /// <param name="top">ǰ����</param>
        /// <returns></returns>
        public DataSet GetRandAskData(int bid, int top)
        {
            if (top <= 0)
            {
                top = 10;
            }
            return dalHelper.GetRandAskData(bid, top);
        }

        public DataSet GetDataArticle(int id,long key)
        {
            if (key == 1) //δ���
            {
                //string cache = string.Concat("dataarticle-", id);
                //DataSet ds = EbSite.Base.Host.CacheApp.GetCacheItem(cache) as DataSet;
                //if (Equals(ds, null))
                //{
                //    ds = dalHelper.GetDataArticle(id);
                //    EbSite.Base.Host.CacheApp.AddCacheItem(cache, ds);

                //}
                DataSet ds = dalHelper.GetDataArticle(id);
                return ds;
            }
            else
            {
               return dalHelper.GetDataArticle(id);
            }
        }
	}
}

