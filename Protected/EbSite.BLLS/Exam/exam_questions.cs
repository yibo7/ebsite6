using System;
using System.Data;
using System.Collections.Generic;
using System.Web.UI.WebControls;
namespace EbSite.BLL
{
	/// <summary>
	/// 业务逻辑类exam_questions 的摘要说明。
	/// </summary>
	public class exam_questions: Base.BLL.BllBase<Entity.exam_questions, int> 
	{
		public static readonly exam_questions Instance = new exam_questions();
		private  exam_questions()
		{
		}
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			return dal.exam_questions_GetMaxId();
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			return dal.exam_questions_Exists(id);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		override public int Add(Entity.exam_questions model)
		{
			base.InvalidateCache();
			return dal.exam_questions_Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		override public void Update(Entity.exam_questions model)
		{
			base.InvalidateCache();
			dal.exam_questions_Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		override public void Delete(int id)
		{
			base.InvalidateCache();
			
			dal.exam_questions_Delete(id);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		override public Entity.exam_questions GetEntity(int id)
		{
			
			string rawKey = string.Concat("GetEntity-", id);
            Entity.exam_questions etEntity = base.GetCacheItem<Entity.exam_questions>(rawKey);
			if (Equals(etEntity,null))
			{
				etEntity = dal.exam_questions_GetEntity(id);
				if (!Equals(etEntity,null))
					base.AddCacheItem(rawKey, etEntity);
			}
			return etEntity;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public int GetCount(string strWhere)
		{
			return dal.exam_questions_GetCount(strWhere);
		}
		/// <summary>
		/// 获得数据列表
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
		/// 获得数据列表
		/// </summary>
		public int GetCount()
		{
			return GetCountCache("");
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return GetListCache(0,strWhere,"");
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList()
		{
			return GetList("");
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(int Top, string strWhere, string filedOrder)
		{
			return dal.exam_questions_GetList( Top,  strWhere,  filedOrder);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
        //public DataSet GetListCache(int Top, string strWhere, string filedOrder)
        //{
        //    string rawKey = string.Concat("GetList-", strWhere,Top,filedOrder);
        //    DataSet lstData = base.GetCacheItem<DataSet>(rawKey);
        //    if (Equals(lstData,null))
        //    {
        //        lstData = GetList( Top,  strWhere,  filedOrder);
        //        if (!Equals(lstData,null))
        //            base.AddCacheItem(rawKey, lstData);
        //    }
        //    return lstData;
        //}
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
		/// 获得数据列表
		/// </summary>
		override public List<Entity.exam_questions> GetListArray(int Top, string strWhere, string filedOrder)
		{
			return dal.exam_questions_GetListArray( Top,  strWhere,  filedOrder);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Entity.exam_questions> GetListArrayCache(int Top, string strWhere, string filedOrder)
		{
			string rawKey = string.Concat("GetListArray-", strWhere,Top,filedOrder);
            List<Entity.exam_questions> lstData = base.GetCacheItem<List<Entity.exam_questions>>(rawKey);
			if (Equals(lstData,null))
			{
				//从基类调用，激活事件
				lstData = base.GetListArrayEv( Top,  strWhere,  filedOrder);
				if (!Equals(lstData,null))
					base.AddCacheItem(rawKey, lstData);
			}
			return lstData;
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Entity.exam_questions> GetListArray(int Top,  string filedOrder)
		{
			return GetListArrayCache( Top,  "",  filedOrder);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Entity.exam_questions> GetListArray(string strWhere)
		{
			return GetListArrayCache( 0,  strWhere,  "");
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		override public List<Entity.exam_questions> GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds,string oderby, out int RecordCount)
		{
			return dal.exam_questions_GetListPages( PageIndex,  PageSize,  strWhere,  Fileds, oderby, out  RecordCount);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Entity.exam_questions> GetListPagesCache(int PageIndex, int PageSize, string strWhere, string Fileds,string oderby, out int RecordCount)
		{
			string rawKey = string.Concat("GlPages-", PageIndex,PageSize,strWhere,Fileds,oderby);
			string rawKeyCount = string.Concat("C-", rawKey);
            List<Entity.exam_questions> lstData = base.GetCacheItem<List<Entity.exam_questions>>(rawKey);
			int iRecordCount = -1;
			if (Equals(lstData,null))
			{
				//从基类调用，激活事件
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
		/// 获得数据列表-分页
		/// </summary>
		public List<Entity.exam_questions> GetListPages(int PageIndex, int PageSize, out int RecordCount)
		{
			return GetListPagesCache( PageIndex,  PageSize,  "",  "", "", out  RecordCount);
		}
		/// <summary>
		/// 获得数据列表-分页
		/// </summary>
		public List<Entity.exam_questions> GetListPages(int PageIndex, int PageSize, string strWhere, string oderby, out int RecordCount)
		{
			return GetListPagesCache( PageIndex,  PageSize,  strWhere,  "", oderby, out  RecordCount);
		}
		/// <summary>
		/// 获得数据列表-分页
		/// </summary>
		public List<Entity.exam_questions> GetListPages(int PageIndex, int PageSize, string strWhere, string oderby)
		{
			int iCount = 0;
			return GetListPagesCache(PageIndex, PageSize, strWhere, "", oderby, out iCount);
		}
		/// <summary>
		/// 搜索-分页
		/// </summary>
		public List<Entity.exam_questions> SearchLike(int PageIndex, int PageSize, string oderby, out int RecordCount, string sKeyWord, string ColumnName)
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
		/// 修改时获取当前实例，并载入控件到PlaceHolder
		/// </summary>
		public void InitModifyCtr(string id, PlaceHolder ph)
		{
			if (!string.IsNullOrEmpty(id))
			{
				int ThisId = int.Parse(id);
				Entity.exam_questions mdEt = GetEntity(ThisId);
				foreach (System.Web.UI.Control uc in ph.Controls)
				{
					if (Equals(uc.ID, null)) continue;
					string sValue = "";
					if (Equals(uc.ID.ToLower(), "id".ToLower()))
					{
						sValue = mdEt.id.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "ExamID".ToLower()))
					{
						sValue = mdEt.ExamID.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "ClassID".ToLower()))
					{
						sValue = mdEt.ClassID.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "QuestionsType".ToLower()))
					{
						sValue = mdEt.QuestionsType.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "Questions".ToLower()))
					{
						sValue = mdEt.Questions.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "AnswerInput".ToLower()))
					{
						sValue = mdEt.AnswerInput.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "AnswerJudge".ToLower()))
					{
						sValue = mdEt.AnswerJudge.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "AnswerA".ToLower()))
					{
						sValue = mdEt.AnswerA.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "AnswerB".ToLower()))
					{
						sValue = mdEt.AnswerB.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "AnswerC".ToLower()))
					{
						sValue = mdEt.AnswerC.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "AnswerD".ToLower()))
					{
						sValue = mdEt.AnswerD.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "AnswerE".ToLower()))
					{
						sValue = mdEt.AnswerE.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "AnswerF".ToLower()))
					{
						sValue = mdEt.AnswerF.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "AnswerG".ToLower()))
					{
						sValue = mdEt.AnswerG.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "RightABC".ToLower()))
					{
						sValue = mdEt.RightABC.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "Analysis".ToLower()))
					{
						sValue = mdEt.Analysis.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "AddDateTimeInt".ToLower()))
					{
						sValue = mdEt.AddDateTimeInt.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "AddUserID".ToLower()))
					{
						sValue = mdEt.AddUserID.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "AddUserNiName".ToLower()))
					{
						sValue = mdEt.AddUserNiName.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "RightUserCount".ToLower()))
					{
						sValue = mdEt.RightUserCount.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "ErrorUserCount".ToLower()))
					{
						sValue = mdEt.ErrorUserCount.ToString();
					}
					else if (Equals(uc.ID.ToLower(), "OrderID".ToLower()))
					{
						sValue = mdEt.OrderID.ToString();
					}
                    else if (Equals(uc.ID.ToLower(), "Score".ToLower()))
                    {
                        sValue = mdEt.Score.ToString();
                    }
				    SetValueFromControl(uc, sValue);
				}
			}
		}
		/// <summary>
		/// 获取控件里的数据映射到一个实体，接着保存这个实例到数据
		/// </summary>
		public void SaveEntityFromCtr(PlaceHolder ph)
		{
				SaveEntityFromCtr(ph,null);
		}
		/// <summary>
		/// 获取控件里的数据映射到一个实体，接着保存这个实例到数据
		/// </summary>
		public void SaveEntityFromCtr(PlaceHolder ph, List<EbSite.Base.BLL.OtherColumn> lstOtherColumn)
		{
			Entity.exam_questions mdEntity = GetEntityFromCtr(ph);
			if(!Equals(lstOtherColumn,null) && lstOtherColumn.Count>0)
			{
				foreach (EbSite.Base.BLL.OtherColumn column in lstOtherColumn)
				{
					if(Equals(column.ColumnName.ToLower(), "id".ToLower()))
					{
						mdEntity.id = int.Parse(column.ColumnValue);
					}
					else if(Equals(column.ColumnName.ToLower(), "ExamID".ToLower()))
					{
						mdEntity.ExamID = int.Parse(column.ColumnValue);
					}
					else if(Equals(column.ColumnName.ToLower(), "ClassID".ToLower()))
					{
						mdEntity.ClassID = int.Parse(column.ColumnValue);
					}
					else if(Equals(column.ColumnName.ToLower(), "QuestionsType".ToLower()))
					{
						mdEntity.QuestionsType = int.Parse(column.ColumnValue);
					}
					else if(Equals(column.ColumnName.ToLower(), "Questions".ToLower()))
					{
						mdEntity.Questions = column.ColumnValue;
					}
					else if(Equals(column.ColumnName.ToLower(), "AnswerInput".ToLower()))
					{
						mdEntity.AnswerInput = column.ColumnValue;
					}
					else if(Equals(column.ColumnName.ToLower(), "AnswerJudge".ToLower()))
					{
						mdEntity.AnswerJudge = bool.Parse(column.ColumnValue);
					}
					else if(Equals(column.ColumnName.ToLower(), "AnswerA".ToLower()))
					{
						mdEntity.AnswerA = column.ColumnValue;
					}
					else if(Equals(column.ColumnName.ToLower(), "AnswerB".ToLower()))
					{
						mdEntity.AnswerB = column.ColumnValue;
					}
					else if(Equals(column.ColumnName.ToLower(), "AnswerC".ToLower()))
					{
						mdEntity.AnswerC = column.ColumnValue;
					}
					else if(Equals(column.ColumnName.ToLower(), "AnswerD".ToLower()))
					{
						mdEntity.AnswerD = column.ColumnValue;
					}
					else if(Equals(column.ColumnName.ToLower(), "AnswerE".ToLower()))
					{
						mdEntity.AnswerE = column.ColumnValue;
					}
					else if(Equals(column.ColumnName.ToLower(), "AnswerF".ToLower()))
					{
						mdEntity.AnswerF = column.ColumnValue;
					}
					else if(Equals(column.ColumnName.ToLower(), "AnswerG".ToLower()))
					{
						mdEntity.AnswerG = column.ColumnValue;
					}
					else if(Equals(column.ColumnName.ToLower(), "RightABC".ToLower()))
					{
						mdEntity.RightABC = column.ColumnValue;
					}
					else if(Equals(column.ColumnName.ToLower(), "Analysis".ToLower()))
					{
						mdEntity.Analysis = column.ColumnValue;
					}
					else if(Equals(column.ColumnName.ToLower(), "AddDateTimeInt".ToLower()))
					{
						mdEntity.AddDateTimeInt = int.Parse(column.ColumnValue);
					}
					else if(Equals(column.ColumnName.ToLower(), "AddUserID".ToLower()))
					{
						mdEntity.AddUserID = int.Parse(column.ColumnValue);
					}
					else if(Equals(column.ColumnName.ToLower(), "AddUserNiName".ToLower()))
					{
						mdEntity.AddUserNiName = column.ColumnValue;
					}
					else if(Equals(column.ColumnName.ToLower(), "RightUserCount".ToLower()))
					{
						mdEntity.RightUserCount = int.Parse(column.ColumnValue);
					}
					else if(Equals(column.ColumnName.ToLower(), "ErrorUserCount".ToLower()))
					{
						mdEntity.ErrorUserCount = int.Parse(column.ColumnValue);
					}
					else if(Equals(column.ColumnName.ToLower(), "OrderID".ToLower()))
					{
						mdEntity.OrderID = int.Parse(column.ColumnValue);
					}
                    else if (Equals(column.ColumnName.ToLower(), "Score".ToLower()))
					{
                        mdEntity.Score = decimal.Parse(column.ColumnValue);
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
		/// 从PlaceHolder中获取一个实例
		/// </summary>
		public Entity.exam_questions GetEntityFromCtr(PlaceHolder ph)
		{
			Entity.exam_questions mdEt = new Entity.exam_questions();
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
					else if(Equals(uc.ID.ToLower(),"ExamID".ToLower()))
					{
						mdEt.ExamID = int.Parse(sValue);
					}
					else if(Equals(uc.ID.ToLower(),"ClassID".ToLower()))
					{
						mdEt.ClassID = int.Parse(sValue);
					}
					else if(Equals(uc.ID.ToLower(),"QuestionsType".ToLower()))
					{
						mdEt.QuestionsType = int.Parse(sValue);
					}
					else if(Equals(uc.ID.ToLower(),"Questions".ToLower()))
					{
						mdEt.Questions = sValue;
					}
					else if(Equals(uc.ID.ToLower(),"AnswerInput".ToLower()))
					{
						mdEt.AnswerInput = sValue;
					}
					else if(Equals(uc.ID.ToLower(),"AnswerJudge".ToLower()))
					{
						mdEt.AnswerJudge = bool.Parse(sValue);
					}
					else if(Equals(uc.ID.ToLower(),"AnswerA".ToLower()))
					{
						mdEt.AnswerA = sValue;
					}
					else if(Equals(uc.ID.ToLower(),"AnswerB".ToLower()))
					{
						mdEt.AnswerB = sValue;
					}
					else if(Equals(uc.ID.ToLower(),"AnswerC".ToLower()))
					{
						mdEt.AnswerC = sValue;
					}
					else if(Equals(uc.ID.ToLower(),"AnswerD".ToLower()))
					{
						mdEt.AnswerD = sValue;
					}
					else if(Equals(uc.ID.ToLower(),"AnswerE".ToLower()))
					{
						mdEt.AnswerE = sValue;
					}
					else if(Equals(uc.ID.ToLower(),"AnswerF".ToLower()))
					{
						mdEt.AnswerF = sValue;
					}
					else if(Equals(uc.ID.ToLower(),"AnswerG".ToLower()))
					{
						mdEt.AnswerG = sValue;
					}
					else if(Equals(uc.ID.ToLower(),"RightABC".ToLower()))
					{
						mdEt.RightABC = sValue;
					}
					else if(Equals(uc.ID.ToLower(),"Analysis".ToLower()))
					{
						mdEt.Analysis = sValue;
					}
					else if(Equals(uc.ID.ToLower(),"AddDateTimeInt".ToLower()))
					{
						mdEt.AddDateTimeInt = int.Parse(sValue);
					}
					else if(Equals(uc.ID.ToLower(),"AddUserID".ToLower()))
					{
						mdEt.AddUserID = int.Parse(sValue);
					}
					else if(Equals(uc.ID.ToLower(),"AddUserNiName".ToLower()))
					{
						mdEt.AddUserNiName = sValue;
					}
					else if(Equals(uc.ID.ToLower(),"RightUserCount".ToLower()))
					{
						mdEt.RightUserCount = int.Parse(sValue);
					}
					else if(Equals(uc.ID.ToLower(),"ErrorUserCount".ToLower()))
					{
						mdEt.ErrorUserCount = int.Parse(sValue);
					}
					else if(Equals(uc.ID.ToLower(),"OrderID".ToLower()))
					{
						mdEt.OrderID = int.Parse(sValue);
					}
                    else if (Equals(uc.ID.ToLower(), "Score".ToLower()))
					{
                        mdEt.Score = decimal.Parse(sValue);
					}
                
			}
		return mdEt;
		}

		#endregion  成员方法
		
		#region  自定义方法
		
		#endregion  自定义方法
	}
}

