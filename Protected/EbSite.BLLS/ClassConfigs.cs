using System;
using System.Collections;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using EbSite.Base;
using EbSite.Base.Static;
using EbSite.Data.Interface;

namespace EbSite.BLL
{
	/// <summary>
	/// 业务逻辑类ClassConfigs 的摘要说明。
	/// </summary>
    public class ClassConfigs : Base.BLL.BllBase<Entity.ClassConfigs, int>
	{
        private static readonly string CacheName = "ClassConfigs";
		public static readonly ClassConfigs Instance = new ClassConfigs();
        private ClassConfigs()
		{

		}
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			return DbProviderCms.GetInstance().ClassConfigs_GetMaxId();
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			return DbProviderCms.GetInstance().ClassConfigs_Exists(id);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		override public int Add(Entity.ClassConfigs model)
		{
			
			int id = DbProviderCms.GetInstance().ClassConfigs_Add(model);
            base.InvalidateCache();
		    return id;
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		override public void Update(Entity.ClassConfigs model)
		{
			
			DbProviderCms.GetInstance().ClassConfigs_Update(model);
            base.InvalidateCache();
        }

		/// <summary>
		/// 删除一条数据
		/// </summary>
		override public void Delete(int id)
		{
			base.InvalidateCache();
			
			DbProviderCms.GetInstance().ClassConfigs_Delete(id);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		override public Entity.ClassConfigs GetEntity(int id)
		{
			
			string rawKey = string.Concat("GetEntity-", id);
            Entity.ClassConfigs etEntity = base.GetCacheItem<Entity.ClassConfigs>(rawKey);
			if (Equals(etEntity,null))
			{
				etEntity = DbProviderCms.GetInstance().ClassConfigs_GetEntity(id);
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
			return DbProviderCms.GetInstance().ClassConfigs_GetCount(strWhere);
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
			return DbProviderCms.GetInstance().ClassConfigs_GetList( Top,  strWhere,  filedOrder);
		}
		/// <summary>
		/// 获得数据列表
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
		/// 获得数据列表
		/// </summary>
		override public List<Entity.ClassConfigs> GetListArray(int Top, string strWhere, string filedOrder)
		{
			return DbProviderCms.GetInstance().ClassConfigs_GetListArray( Top,  strWhere,  filedOrder);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Entity.ClassConfigs> GetListArrayCache(int Top, string strWhere, string filedOrder)
		{
			string rawKey = string.Concat("GetListArray-", strWhere,Top,filedOrder);
            List<Entity.ClassConfigs> lstData = base.GetCacheItem<List<Entity.ClassConfigs>>(rawKey);
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
		public List<Entity.ClassConfigs> GetListArray(int Top,  string filedOrder)
		{
			return GetListArrayCache( Top,  "",  filedOrder);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Entity.ClassConfigs> GetListArray(string strWhere)
		{
			return GetListArrayCache( 0,  strWhere,  "");
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		override public List<Entity.ClassConfigs> GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds,string oderby, out int RecordCount)
		{
			return DbProviderCms.GetInstance().ClassConfigs_GetListPages( PageIndex,  PageSize,  strWhere,  Fileds, oderby, out  RecordCount);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Entity.ClassConfigs> GetListPagesCache(int PageIndex, int PageSize, string strWhere, string Fileds,string oderby, out int RecordCount)
		{
			string rawKey = string.Concat("GlPages-", PageIndex,PageSize,strWhere,Fileds,oderby);
			string rawKeyCount = string.Concat("C-", rawKey);
            List<Entity.ClassConfigs> lstData = base.GetCacheItem<List<Entity.ClassConfigs>>(rawKey);
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
		public List<Entity.ClassConfigs> GetListPages(int PageIndex, int PageSize, out int RecordCount)
		{
			return GetListPagesCache( PageIndex,  PageSize,  "",  "", "", out  RecordCount);
		}
		/// <summary>
		/// 获得数据列表-分页
		/// </summary>
		public List<Entity.ClassConfigs> GetListPages(int PageIndex, int PageSize, string strWhere, string oderby, out int RecordCount)
		{
			return GetListPagesCache( PageIndex,  PageSize,  strWhere,  "", oderby, out  RecordCount);
		}
		/// <summary>
		/// 获得数据列表-分页
		/// </summary>
		public List<Entity.ClassConfigs> GetListPages(int PageIndex, int PageSize, string strWhere, string oderby)
		{
			int iCount = 0;
			return GetListPagesCache(PageIndex, PageSize, strWhere, "", oderby, out iCount);
		}
		/// <summary>
		/// 搜索-分页
		/// </summary>
		public List<Entity.ClassConfigs> SearchLike(int PageIndex, int PageSize, string oderby, out int RecordCount, string sKeyWord, string ColumnName)
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
		//public void InitModifyCtr(string id, PlaceHolder ph)
		//{
		//	if (!string.IsNullOrEmpty(id))
		//	{
		//		int ThisId = int.Parse(id);
		//		Entity.ClassConfigs mdEt = GetEntity(ThisId);
		//		foreach (System.Web.UI.Control uc in ph.Controls)
		//		{
		//			if (Equals(uc.ID, null)) continue;
		//			string sValue = "";
		//			if (Equals(uc.ID.ToLower(), "id".ToLower()))
		//			{
		//				sValue = mdEt.id.ToString();
		//			}
		//			else if (Equals(uc.ID.ToLower(), "ContentHtmlName".ToLower()))
		//			{
		//				sValue = mdEt.ContentHtmlName.ToString();
		//			}
		//			else if (Equals(uc.ID.ToLower(), "ClassHtmlNameRule".ToLower()))
		//			{
		//				sValue = mdEt.ClassHtmlNameRule.ToString();
		//			}
		//			else if (Equals(uc.ID.ToLower(), "IsCanAddContent".ToLower()))
		//			{
		//				sValue = mdEt.IsCanAddContent.ToString();
		//			}
		//			else if (Equals(uc.ID.ToLower(), "ContentModelID".ToLower()))
		//			{
		//				sValue = mdEt.ContentModelID.ToString();
		//			}
		//			else if (Equals(uc.ID.ToLower(), "ContentTemID".ToLower()))
		//			{
		//				sValue = mdEt.ContentTemID.ToString();
		//			}
		//			else if (Equals(uc.ID.ToLower(), "ClassTemID".ToLower()))
		//			{
		//				sValue = mdEt.ClassTemID.ToString();
		//			}
		//			else if (Equals(uc.ID.ToLower(), "ClassModelID".ToLower()))
		//			{
		//				sValue = mdEt.ClassModelID.ToString();
		//			}
		//			else if (Equals(uc.ID.ToLower(), "SubClassAddName".ToLower()))
		//			{
		//				sValue = mdEt.SubClassAddName.ToString();
		//			}
		//			else if (Equals(uc.ID.ToLower(), "SubClassTemID".ToLower()))
		//			{
		//				sValue = mdEt.SubClassTemID.ToString();
		//			}
		//			else if (Equals(uc.ID.ToLower(), "SubClassModelID".ToLower()))
		//			{
		//				sValue = mdEt.SubClassModelID.ToString();
		//			}
		//			else if (Equals(uc.ID.ToLower(), "SubDefaultContentModelID".ToLower()))
		//			{
		//				sValue = mdEt.SubDefaultContentModelID.ToString();
		//			}
		//			else if (Equals(uc.ID.ToLower(), "SubDefaultContentTemID".ToLower()))
		//			{
		//				sValue = mdEt.SubDefaultContentTemID.ToString();
		//			}
		//			else if (Equals(uc.ID.ToLower(), "SubIsCanAddSub".ToLower()))
		//			{
		//				sValue = mdEt.SubIsCanAddSub.ToString();
		//			}
		//			else if (Equals(uc.ID.ToLower(), "SubIsCanAddContent".ToLower()))
		//			{
		//				sValue = mdEt.SubIsCanAddContent.ToString();
		//			}
		//			else if (Equals(uc.ID.ToLower(), "IsCanAddSub".ToLower()))
		//			{
		//				sValue = mdEt.IsCanAddSub.ToString();
		//			}
		//			else if (Equals(uc.ID.ToLower(), "ListTemID".ToLower()))
		//			{
		//				sValue = mdEt.ListTemID.ToString();
		//			}
		//			else if (Equals(uc.ID.ToLower(), "PageSize".ToLower()))
		//			{
		//				sValue = mdEt.PageSize.ToString();
		//			}
		//			else if (Equals(uc.ID.ToLower(), "ModuleID".ToLower()))
		//			{
		//				sValue = mdEt.ModuleID.ToString();
		//			}
		//			else if (Equals(uc.ID.ToLower(), "ClassID".ToLower()))
		//			{
		//				sValue = mdEt.ClassID.ToString();
		//			}
		//			else if (Equals(uc.ID.ToLower(), "AddTime".ToLower()))
		//			{
		//				sValue = mdEt.AddTime.ToString();
		//			}
		//			else if (Equals(uc.ID.ToLower(), "ClassTemIdMobile".ToLower()))
		//			{
		//				sValue = mdEt.ClassTemIdMobile.ToString();
		//			}
		//			else if (Equals(uc.ID.ToLower(), "ContentTemIdMobile".ToLower()))
		//			{
		//				sValue = mdEt.ContentTemIdMobile.ToString();
		//			}
  //                  else if (Equals(uc.ID.ToLower(), "SiteID".ToLower()))
  //                  {
  //                      sValue = mdEt.SiteID.ToString();
  //                  }
  //                  else if (Equals(uc.ID.ToLower(), "IsDefault".ToLower()))
  //                  {
  //                      sValue = mdEt.IsDefault.ToString();
  //                  }
		//		SetValueFromControl(uc, sValue);
		//		}
		//	}
		//}
		/// <summary>
		/// 获取控件里的数据映射到一个实体，接着保存这个实例到数据
		/// </summary>
		//public void SaveEntityFromCtr(PlaceHolder ph)
		//{
		//		SaveEntityFromCtr(ph,null);
		//}
		/// <summary>
		/// 获取控件里的数据映射到一个实体，接着保存这个实例到数据
		/// </summary>
		//public void SaveEntityFromCtr(PlaceHolder ph, List<EbSite.Base.BLL.OtherColumn> lstOtherColumn)
		//{
		//	Entity.ClassConfigs mdEntity = GetEntityFromCtr(ph);
		//	if(!Equals(lstOtherColumn,null) && lstOtherColumn.Count>0)
		//	{
		//		foreach (EbSite.Base.BLL.OtherColumn column in lstOtherColumn)
		//		{
		//			if(Equals(column.ColumnName.ToLower(), "id".ToLower()))
		//			{
		//				mdEntity.id = int.Parse(column.ColumnValue);
		//			}
		//			else if(Equals(column.ColumnName.ToLower(), "ContentHtmlName".ToLower()))
		//			{
		//				mdEntity.ContentHtmlName = column.ColumnValue;
		//			}
		//			else if(Equals(column.ColumnName.ToLower(), "ClassHtmlNameRule".ToLower()))
		//			{
		//				mdEntity.ClassHtmlNameRule = column.ColumnValue;
		//			}
		//			else if(Equals(column.ColumnName.ToLower(), "IsCanAddContent".ToLower()))
		//			{
		//				mdEntity.IsCanAddContent = bool.Parse(column.ColumnValue);
		//			}
		//			else if(Equals(column.ColumnName.ToLower(), "ContentModelID".ToLower()))
		//			{
		//				mdEntity.ContentModelID = new Guid(column.ColumnValue);
		//			}
		//			else if(Equals(column.ColumnName.ToLower(), "ContentTemID".ToLower()))
		//			{
		//				mdEntity.ContentTemID = new Guid(column.ColumnValue);
		//			}
		//			else if(Equals(column.ColumnName.ToLower(), "ClassTemID".ToLower()))
		//			{
		//				mdEntity.ClassTemID = new Guid(column.ColumnValue);
		//			}
		//			else if(Equals(column.ColumnName.ToLower(), "ClassModelID".ToLower()))
		//			{
		//				mdEntity.ClassModelID = new Guid(column.ColumnValue);
		//			}
		//			else if(Equals(column.ColumnName.ToLower(), "SubClassAddName".ToLower()))
		//			{
		//				mdEntity.SubClassAddName = column.ColumnValue;
		//			}
		//			else if(Equals(column.ColumnName.ToLower(), "SubClassTemID".ToLower()))
		//			{
		//				mdEntity.SubClassTemID = new Guid(column.ColumnValue);
		//			}
		//			else if(Equals(column.ColumnName.ToLower(), "SubClassModelID".ToLower()))
		//			{
		//				mdEntity.SubClassModelID = new Guid(column.ColumnValue);
		//			}
		//			else if(Equals(column.ColumnName.ToLower(), "SubDefaultContentModelID".ToLower()))
		//			{
		//				mdEntity.SubDefaultContentModelID = new Guid(column.ColumnValue);
		//			}
		//			else if(Equals(column.ColumnName.ToLower(), "SubDefaultContentTemID".ToLower()))
		//			{
		//				mdEntity.SubDefaultContentTemID = new Guid(column.ColumnValue);
		//			}
		//			else if(Equals(column.ColumnName.ToLower(), "SubIsCanAddSub".ToLower()))
		//			{
		//				mdEntity.SubIsCanAddSub = bool.Parse(column.ColumnValue);
		//			}
		//			else if(Equals(column.ColumnName.ToLower(), "SubIsCanAddContent".ToLower()))
		//			{
		//				mdEntity.SubIsCanAddContent = bool.Parse(column.ColumnValue);
		//			}
		//			else if(Equals(column.ColumnName.ToLower(), "IsCanAddSub".ToLower()))
		//			{
		//				mdEntity.IsCanAddSub = bool.Parse(column.ColumnValue);
		//			}
		//			else if(Equals(column.ColumnName.ToLower(), "ListTemID".ToLower()))
		//			{
		//				mdEntity.ListTemID = new Guid(column.ColumnValue);
		//			}
		//			else if(Equals(column.ColumnName.ToLower(), "PageSize".ToLower()))
		//			{
		//				mdEntity.PageSize = int.Parse(column.ColumnValue);
		//			}
		//			else if(Equals(column.ColumnName.ToLower(), "ModuleID".ToLower()))
		//			{
		//				mdEntity.ModuleID = new Guid(column.ColumnValue);
		//			}
		//			else if(Equals(column.ColumnName.ToLower(), "ClassID".ToLower()))
		//			{
		//				mdEntity.ClassID = int.Parse(column.ColumnValue);
		//			}
		//			else if(Equals(column.ColumnName.ToLower(), "AddTime".ToLower()))
		//			{
		//				mdEntity.AddTime = DateTime.Parse(column.ColumnValue);
		//			}
		//			else if(Equals(column.ColumnName.ToLower(), "ClassTemIdMobile".ToLower()))
		//			{
		//				mdEntity.ClassTemIdMobile = new Guid(column.ColumnValue);
		//			}
		//			else if(Equals(column.ColumnName.ToLower(), "ContentTemIdMobile".ToLower()))
		//			{
  //                      mdEntity.ContentTemIdMobile = new Guid(column.ColumnValue);
		//			}
  //                  else if (Equals(column.ColumnName.ToLower(), "SiteID".ToLower()))
  //                  {
  //                      mdEntity.SiteID = int.Parse(column.ColumnValue);
  //                  }
  //                  else if (Equals(column.ColumnName.ToLower(), "IsDefault".ToLower()))
  //                  {
  //                      mdEntity.IsDefault = bool.Parse(column.ColumnValue);
  //                  }
		//		}
		//	}
		//	if (mdEntity.id>0)
		//	{
		//		Update(mdEntity);
		//	}else{
		//		 Add(mdEntity);
		//	}
		//}
		/// <summary>
		/// 从PlaceHolder中获取一个实例
		/// </summary>
		//public Entity.ClassConfigs GetEntityFromCtr(PlaceHolder ph)
		//{
		//	Entity.ClassConfigs mdEt = new Entity.ClassConfigs();
		//	string sKeyID;
		//	if (GetIDFromCtr(ph, out sKeyID))
		//	{
		//		mdEt = GetEntity(int.Parse(sKeyID));
		//	}
		//	foreach (System.Web.UI.Control uc in ph.Controls)
		//	{
		//		if (Equals(uc.ID, null)) continue;
		//		string sValue = GetValueFromControl(uc);
		//			if(Equals(uc.ID.ToLower(),"id".ToLower()))
		//			{
		//				mdEt.id = int.Parse(sValue);
		//			}
		//			else if(Equals(uc.ID.ToLower(),"ContentHtmlName".ToLower()))
		//			{
		//				mdEt.ContentHtmlName = sValue;
		//			}
		//			else if(Equals(uc.ID.ToLower(),"ClassHtmlNameRule".ToLower()))
		//			{
		//				mdEt.ClassHtmlNameRule = sValue;
		//			}
		//			else if(Equals(uc.ID.ToLower(),"IsCanAddContent".ToLower()))
		//			{
		//				mdEt.IsCanAddContent = bool.Parse(sValue);
		//			}
		//			else if(Equals(uc.ID.ToLower(),"ContentModelID".ToLower()))
		//			{
		//				mdEt.ContentModelID =new Guid(sValue);
		//			}
		//			else if(Equals(uc.ID.ToLower(),"ContentTemID".ToLower()))
		//			{
		//				mdEt.ContentTemID = new Guid(sValue);
		//			}
		//			else if(Equals(uc.ID.ToLower(),"ClassTemID".ToLower()))
		//			{
		//				mdEt.ClassTemID = new Guid(sValue);
		//			}
		//			else if(Equals(uc.ID.ToLower(),"ClassModelID".ToLower()))
		//			{
		//				mdEt.ClassModelID = new Guid(sValue);
		//			}
		//			else if(Equals(uc.ID.ToLower(),"SubClassAddName".ToLower()))
		//			{
		//				mdEt.SubClassAddName = sValue;
		//			}
		//			else if(Equals(uc.ID.ToLower(),"SubClassTemID".ToLower()))
		//			{
		//				mdEt.SubClassTemID = new Guid(sValue);
		//			}
		//			else if(Equals(uc.ID.ToLower(),"SubClassModelID".ToLower()))
		//			{
		//				mdEt.SubClassModelID = new Guid(sValue);
		//			}
		//			else if(Equals(uc.ID.ToLower(),"SubDefaultContentModelID".ToLower()))
		//			{
		//				mdEt.SubDefaultContentModelID = new Guid(sValue);
		//			}
		//			else if(Equals(uc.ID.ToLower(),"SubDefaultContentTemID".ToLower()))
		//			{
		//				mdEt.SubDefaultContentTemID = new Guid(sValue);
		//			}
		//			else if(Equals(uc.ID.ToLower(),"SubIsCanAddSub".ToLower()))
		//			{
		//				mdEt.SubIsCanAddSub = bool.Parse(sValue);
		//			}
		//			else if(Equals(uc.ID.ToLower(),"SubIsCanAddContent".ToLower()))
		//			{
		//				mdEt.SubIsCanAddContent = bool.Parse(sValue);
		//			}
		//			else if(Equals(uc.ID.ToLower(),"IsCanAddSub".ToLower()))
		//			{
		//				mdEt.IsCanAddSub = bool.Parse(sValue);
		//			}
		//			else if(Equals(uc.ID.ToLower(),"ListTemID".ToLower()))
		//			{
		//				mdEt.ListTemID = new Guid(sValue);
		//			}
		//			else if(Equals(uc.ID.ToLower(),"PageSize".ToLower()))
		//			{
		//				mdEt.PageSize = int.Parse(sValue);
		//			}
		//			else if(Equals(uc.ID.ToLower(),"ModuleID".ToLower()))
		//			{
		//				mdEt.ModuleID = new Guid(sValue);
		//			}
		//			else if(Equals(uc.ID.ToLower(),"ClassID".ToLower()))
		//			{
		//				mdEt.ClassID = int.Parse(sValue);
		//			}
		//			else if(Equals(uc.ID.ToLower(),"AddTime".ToLower()))
		//			{
		//				mdEt.AddTime = DateTime.Parse(sValue);
		//			}
		//			else if(Equals(uc.ID.ToLower(),"ClassTemIdMobile".ToLower()))
		//			{
		//				mdEt.ClassTemIdMobile = new Guid(sValue);
		//			}
		//			else if(Equals(uc.ID.ToLower(),"ContentTemIdMobile".ToLower()))
		//			{
  //                      mdEt.ContentTemIdMobile = new Guid(sValue);
		//			}
  //                  else if (Equals(uc.ID.ToLower(), "SiteID".ToLower()))
  //                  {
  //                      mdEt.SiteID = int.Parse(sValue);
  //                  }
  //                  else if (Equals(uc.ID.ToLower(), "IsDefault".ToLower()))
  //                  {
  //                      mdEt.IsDefault = bool.Parse(sValue);
  //                  }
		//	}
		//return mdEt;
		//}

		#endregion  成员方法
		
		#region  自定义方法

        public Entity.ClassConfigs GetClassConfigs(int SiteID)
        {
            string CacheKey = string.Concat("GetClassConfigs_", SiteID);
            Entity.ClassConfigs md = Host.CacheApp.GetCacheItem<Entity.ClassConfigs>(CacheKey, CacheName); 
            if (Equals(md,null))
            {
               md =  DbProviderCms.GetInstance().GeClassConfigs(SiteID);
               if (!Equals(md, null))
                   Host.CacheApp.AddCacheItem(CacheKey, md, 1, ETimeSpanModel.T, CacheName);
            }
            return md;
        }

        public bool IsHaveClassConfigs(int SiteID)
	    {
            return DbProviderCms.GetInstance().IsHaveClassConfigs(SiteID);
	    }

     //   public bool IsHaveClassConfigsByClassID(int ClassID)
	    //{
     //       Entity.ClassConfigs Model   DbProviderCms.GetInstance().GeClassConfigsByClassID(ClassID);

     //       //return DbProviderCms.GetInstance().IsHaveClassConfigsByClassID(ClassID);
     //   }

	    //public void UpdateDefaultClassConfigs(Entity.ClassConfigs Model)
     //   {
     //       if (IsHaveClassConfigs(Model.SiteID))
     //       {
     //           DbProviderCms.GetInstance().UpdateDefaultClassConfigs(Model);
     //       }
     //       else
     //       {
     //           Add(Model);
     //       }
     //   }

	    

        private static Dictionary<int, Guid> ClassTems = new Dictionary<int, Guid>();
        private static Dictionary<int, Guid> ContentTems = new Dictionary<int, Guid>();

        private static Dictionary<int, Guid> MClassTems = new Dictionary<int, Guid>();
        private static Dictionary<int, Guid> MContentTems = new Dictionary<int, Guid>();

        private static Dictionary<int, string> NewContentNames = new Dictionary<int, string>();

        protected object lockHelper = new object();
	    public Guid GetClassTemID(int ClassID)
	    {
            if (ClassTems.ContainsKey(ClassID))
            {
                return ClassTems[ClassID];  
            }
            else
            {
                    lock (lockHelper)
                    {
                        if (!ClassTems.ContainsKey(ClassID))
                        {
                            Entity.ClassConfigs md = GetClassConfigsByClassID(ClassID);

                            ClassTems.Add(ClassID, md.ClassTemID);

                            
                        }
                    }
                   return  ClassTems[ClassID];
            }
	    }

        public string GetNewContentTableName(int ClassID)
	    {

            if (NewContentNames.ContainsKey(ClassID))
            {
                return NewContentNames[ClassID];
            }
            else
            {

                lock (lockHelper)
                {
                    if (!NewContentNames.ContainsKey(ClassID))
                    {
                        Entity.ClassConfigs md = GetClassConfigsByClassID(ClassID);
                        Guid moduleid = md.ContentModelID;
                        string tbName = EbSite.BLL.WebModel.Instance.GetTableName(moduleid);
                        NewContentNames.Add(ClassID, tbName);
                    }
                }
                return NewContentNames[ClassID];
            }
	    }
        public Guid GetContentTemID(int ClassID)
        {

            if (ContentTems.ContainsKey(ClassID))
            {
                return ContentTems[ClassID];
            }
            else
            {

                lock (lockHelper)
                {
                    if (!ContentTems.ContainsKey(ClassID))
                    {
                        Entity.ClassConfigs md = GetClassConfigsByClassID(ClassID);

                        ContentTems.Add(ClassID, md.ContentTemID);
                    }
                }
                return ContentTems[ClassID];
            }

        }

	    
	    public Guid GetClassTemIDMobile(int ClassID)
        {
            if (MClassTems.ContainsKey(ClassID))
            {
                return MClassTems[ClassID];
            }
            else
            {

                lock (lockHelper)
                {
                    if (!MClassTems.ContainsKey(ClassID))
                    {
                        Entity.ClassConfigs md = GetClassConfigsByClassID(ClassID);

                        MClassTems.Add(ClassID, md.ClassTemIdMobile);
                    }
                }
                return MClassTems[ClassID];
            }
        }
        public Guid GetContentTemIDMobile(int ClassID)
        {

            if (MContentTems.ContainsKey(ClassID))
            {
                return MContentTems[ClassID];
            }
            else
            {
                lock (lockHelper)
                {
                    if (!MContentTems.ContainsKey(ClassID))
                    {
                        Entity.ClassConfigs md = GetClassConfigsByClassID(ClassID);

                        MContentTems.Add(ClassID, md.ContentTemIdMobile);
                    }
                }
                return MContentTems[ClassID];
            }
        }

	    public Guid GetClassModelID(int ClassID)
	    {
            Entity.ClassConfigs md = GetClassConfigsByClassID(ClassID);

	        return md.ClassModelID;
	    }
        public Guid GetContentModelID(int ClassID)
        {
            Entity.ClassConfigs md = GetClassConfigsByClassID(ClassID);

            return md.ContentModelID;
        }
        public string GetClassHtmlNameRule(int ClassID)
        {
            Entity.ClassConfigs md = GetClassConfigsByClassID(ClassID);

            return md.ClassHtmlNameRule;
        }
        public string GetContentHtmlName(int ClassID)
        {
            Entity.ClassConfigs md = GetClassConfigsByClassID(ClassID);

            return md.ContentHtmlName;
        }
        public bool GetIsCanAddContent(int ClassID)
        {
            Entity.ClassConfigs md = GetClassConfigsByClassID(ClassID);

            return md.IsCanAddContent;
        }
        public Guid GetModuleID(int ClassID)
        {
            Entity.ClassConfigs md = GetClassConfigsByClassID(ClassID);

            return md.ModuleID;
        }


        public Guid GetListTemID(int ClassID)
        {
            Entity.ClassConfigs md = GetClassConfigsByClassID(ClassID);

            return md.ListTemID;
        }
        public bool GetIsCanAddSub(int ClassID)
        {
            Entity.ClassConfigs md = GetClassConfigsByClassID(ClassID);

            return md.IsCanAddSub;
        }
        public Guid GetSubClassModelID(int ClassID)
        {
            Entity.ClassConfigs md = GetClassConfigsByClassID(ClassID);

            return md.SubClassModelID;
        }

	    

	    public void DeleteByClassIDBySite(int SiteID)
	    {
	         List<EbSite.Entity.NewsClass> lst =  BLL.NewsClass.GetListArr("", SiteID);

	        foreach (var newsClass in lst)
	        {
                DeleteByClassID(newsClass.ID);
	        }
	    }

	    public void DeleteByClassID(int ClassID)
	    {
            base.InvalidateCache();
             DbProviderCms.GetInstance().DeleteByClassID(ClassID);
	    }

	    public void UpdateClassConfigs(Entity.ClassConfigs Model,int iClassId,int iSiteId,bool isChangeRule,bool isAddNew,bool isUpdateToSub,bool isDefault,bool IsSetTo)
        {
	        if (isDefault)//站点的默认分类设置，所以要设置站点ID
	        {
	            Model.SiteID = iSiteId;
	        }

	        if (isAddNew)
	        {
                Model.SiteID = 0;
                int cfid =  Add(Model);
                EbSite.Entity.ClassSetConfig newConfig = new Entity.ClassSetConfig();
	            newConfig.ClassId = iClassId;
	            newConfig.ConfigId = cfid;
                if (!IsSetTo)
	            {
	                BLL.ClassSetConfig.Instance.Add(newConfig);
	            }
	            else
	            {
                    BLL.ClassSetConfig.Instance.UpdateConfigId(newConfig);//更新条件是 ClassId,ConfigId
                }
	        }
	        else
	        {
                Update(Model);
            }
            

            //Entity.ClassConfigs mdOld = BLL.ClassConfigs.Instance.GetClassConfigsByClassID(iClassId);
	        //bool isChangeRule = !Equals(Model.ClassHtmlNameRule, mdOld.ClassHtmlNameRule);
            if (isChangeRule)
	        {
                //同时更新分类记录的
               // List<Entity.NewsClass> mds = NewsClass.GetClassInIDs(Model.ClassID, Model.SiteID);
                List<EbSite.Entity.NewsClass> mds = DbProviderCms.GetInstance().NewsClass_GetListArrayFormConfigId(Model.id);
                foreach (var model in mds)
                {
                    model.HtmlName = HtmlReNameRule.GetName(Model.ClassHtmlNameRule, model.ClassName);//从当前规则转换文件名
                    NewsClass.Update(model);
                }

            }


            base.InvalidateCache();
            
        }


        private Entity.ClassConfigs GetClassConfigsFromClassID(int ClassId)
        {
            //public List<Entity.ClassConfigs> GeClassConfigsByModuleId(int mid)

            string CacheKey = string.Concat("GeClassConfigsByClassID_", ClassId);
            Entity.ClassConfigs md = Host.CacheApp.GetCacheItem<Entity.ClassConfigs>(CacheKey, CacheName);
            if (Equals(md, null))
            {
                md = DbProviderCms.GetInstance().GeClassConfigsByClassID(ClassId);
                if (!Equals(md, null))
                    Host.CacheApp.AddCacheItem(CacheKey, md, 15, ETimeSpanModel.FZ, CacheName);
            }
            return md;
        }

	    public Entity.ClassConfigs GetClassConfigsByClassID(int ClassID)
	    {
          
            Entity.ClassConfigs mConfigs = GetClassConfigsFromClassID(ClassID); 
            if (Equals(mConfigs, null))
            {

                mConfigs = GetClassConfigs(EbSite.Base.Host.Instance.GetSiteID); 
                if (Equals(mConfigs, null))
                {
                    throw new Exception(string.Format("当前站找不到默认分类设置数据，你登录后台切换到当前站点，执行以下操作即可正常访问:网站管理>分类管理>数据调整>更改分类默认设置>保存分类设置"));
                }
            } 

            return mConfigs;
        }

	    public Entity.ClassConfigs GetClassConfigsByClassID(int ClassID,out bool IsDefault,out int UsedClassCount,out bool IsSetTo)
	    {
	        IsSetTo = false;
            IsDefault = false;
            UsedClassCount = 0;
            Entity.ClassConfigs mConfigs = GetClassConfigsFromClassID(ClassID);
            Entity.ClassConfigs mDefaultConfigs = GetClassConfigs(EbSite.Base.Host.Instance.GetSiteID);
            if (Equals(mConfigs, null))
            {

                mConfigs = mDefaultConfigs;
                IsDefault = true;
               
                if (Equals(mConfigs, null))
                {
                    throw new Exception(string.Format("当前站找不到默认分类设置数据，你登录后台切换到当前站点，执行以下操作即可正常访问:网站管理>分类管理>数据调整>更改分类默认设置>保存分类设置"));
                }
            }
            else
            {
                IsSetTo = true;
                if (mConfigs.id == mDefaultConfigs.id)
                {
                    IsDefault = true;
                }
                UsedClassCount = BLL.ClassSetConfig.Instance.GetCountByConfigId(mConfigs.id);
                
            }

            return mConfigs;

            //if (IsHaveClassConfigsByClassID(ClassID))
            //{
            //    mConfigs = GeClassConfigsByClassID(ClassID);//DbProviderCms.GetInstance().GeClassConfigsByClassID(ClassID);
            //}
            //else
            //{
            //    mConfigs = GetClassConfigs(EbSite.Base.Host.Instance.GetSiteID);

            //    if (Equals(mConfigs, null))
            //    {
            //        throw new Exception(string.Format("当前站找不到默认分类设置数据，你登录后台切换到当前站点，执行以下操作即可正常访问:网站管理>分类管理>数据调整>更改分类默认设置>保存分类设置"));
            //    }
            //}
            //return mConfigs;

        }

        /// <summary>
        /// 获取分类模型一样的分类配置
        /// </summary>
        /// <param name="mid">分类模型Id</param>
        /// <returns></returns>
        public List<Entity.ClassConfigs> GeClassConfigsByModuleId(Guid mid)
        {
             return DbProviderCms.GetInstance().GeClassConfigsByModuleId(mid);
        }


        /// <summary>
        /// 添加一级分类时，为分类分配分类配置
        /// </summary>
        /// <param name="ClassId">分类Id</param>
        /// <param name="ModuleId">分类模型ID</param>
        /// <returns>0，分配到默认分类配置，1分配到一个已有的相关分类模型的配置,2.添加一个新分类配置，这个时候往往需要去设置一下</returns>
        public int AddClassToDefault(int ClassId, Guid ModuleId)
        {
            Entity.ClassConfigs mConfigs = GetClassConfigs(EbSite.Base.Host.Instance.GetSiteID);

            if (mConfigs.ClassModelID != ModuleId) //如果默认的分类配置里设置的不是当前模型，那么就要新建
            {
                List<Entity.ClassConfigs> lsM = GeClassConfigsByModuleId(ModuleId);
                if (lsM.Count > 0)
                {
                    Entity.ClassConfigs Model = lsM[0]; //默认取第一个
                    //Model.ClassID = string.Concat(Model.ClassID, ",", ClassId);//追加一个分类ID
                    //Update(Model);

                    Entity.ClassSetConfig mset = new Entity.ClassSetConfig();
                    mset.ClassId = ClassId;
                    mset.ConfigId = Model.id;
                    BLL.ClassSetConfig.Instance.Add(mset);
                    return 1;

                }
                else //如果也不能使用默认配置，也没有存在相同分类模型的分配配置，那么复制一份默认的，修改分类ID，分类模型Id,添加，这种情况往往用户还需要配置一下其他设置
                {

                    mConfigs.ClassModelID = ModuleId;
                    int id = Add(mConfigs);

                    Entity.ClassSetConfig mset = new Entity.ClassSetConfig();
                    mset.ClassId = ClassId;
                    mset.ConfigId = id;
                    BLL.ClassSetConfig.Instance.Add(mset);

                    return 2;
                }
            }
            else  //2016-02-26  之前默认配置是没有添加分类与配置关系的，这样查不好查
            {
                Entity.ClassSetConfig mset = new Entity.ClassSetConfig();
                mset.ClassId = ClassId;
                mset.ConfigId = mConfigs.id;
                BLL.ClassSetConfig.Instance.Add(mset);
            }

            return 0;
        }

	    public void AddSubClassToParentConfig(int PClassId,int subClassId)
	    {
	        Entity.ClassConfigs Model = GetClassConfigsByClassID(PClassId);

            Entity.ClassSetConfig mset = new Entity.ClassSetConfig();
            mset.ClassId = subClassId;
            mset.ConfigId = Model.id;
            BLL.ClassSetConfig.Instance.Add(mset);

            //   if (!string.IsNullOrEmpty(Model.ClassID))//默认配置不用添加Id
            //{
            //       Model.ClassID = string.Concat(Model.ClassID, ",", subClassId);//追加一个分类ID
            //       Update(Model);
            //   }

        }


        //public int AddClassListToDefault(string ClassIds, Guid ModuleId)
        //{
        //    Entity.ClassConfigs mConfigs = GetClassConfigs(EbSite.Base.Host.Instance.GetSiteID);

        //    if (mConfigs.ClassModelID != ModuleId) //如果默认的分类配置里设置的不是当前模型，那么就要新建
        //    {
        //        List<Entity.ClassConfigs> lsM = GeClassConfigsByModuleId(ModuleId);
        //        if (lsM.Count > 0)
        //        {
        //            Entity.ClassConfigs Model = lsM[0];//默认取第一个
        //            Model.ClassID = string.Concat(Model.ClassID, ",", ClassIds);//追加一个分类ID
        //            Update(Model);
        //            return 1;

        //        }
        //        else //如果也不能使用默认配置，也没有存在相同分类模型的分配配置，那么复制一份默认的，修改分类ID，分类模型Id,添加，这种情况往往用户还需要配置一下其他设置
        //        {
        //            mConfigs.ClassID = ClassIds;
        //            mConfigs.ClassModelID = ModuleId;
        //            Add(mConfigs);

        //            return 2;

        //        }
        //    }

        //    return 0;
        //}

        //public void AddSubClassListToParentConfig(int PClassId, string ClassIds)
        //{
        //    Entity.ClassConfigs Model = GetClassConfigsByClassID(PClassId);
        //    if (!string.IsNullOrEmpty(Model.ClassID))//为空时，表示是默认配置，默认配置不用添加Id
        //    {
        //        Model.ClassID = string.Concat(Model.ClassID, ",", ClassIds);//追加一个分类ID
        //        Update(Model);
        //    }
        //}

        #endregion  自定义方法
    }
}

