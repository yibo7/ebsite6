using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Web;
using EbSite.Base.Datastore;
using EbSite.Core;
using EbSite.Core.FSO;
using EbSite.Entity;

namespace EbSite.BLL
{
    /// <summary>
    /// 将上传的文件记录下来
    /// </summary>
    [Serializable]
    public class UploadFileInfoBLL : EbSite.Base.BLL.BllBase<UploadFileInfo, int> 
    {
        public static readonly UploadFileInfoBLL Instance = new UploadFileInfoBLL();
        private UploadFileInfoBLL()
		{
		}
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			return dal.uploadfiles_GetMaxId();
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			return dal.uploadfiles_Exists(id);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		override public int Add(Entity.UploadFileInfo model)
		{
			base.InvalidateCache();
			return dal.uploadfiles_Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
        override public void Update(Entity.UploadFileInfo model)
		{
			base.InvalidateCache();
			dal.uploadfiles_Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		override public void Delete(int id)
		{
			base.InvalidateCache();
			
			dal.uploadfiles_Delete(id);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
        override public Entity.UploadFileInfo GetEntity(int id)
		{
			
			string rawKey = string.Concat("GetEntity-", id);
            Entity.UploadFileInfo etEntity = base.GetCacheItem<Entity.UploadFileInfo>(rawKey) ;
			if (Equals(etEntity,null))
			{
				etEntity = dal.uploadfiles_GetEntity(id);
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
			return dal.uploadfiles_GetCount(strWhere);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public int GetCountCache(string strWhere)
		{
			string rawKey = string.Concat("GetCount-", strWhere);
			 string sCount = base.GetCacheItem<string>(rawKey) ;
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
			return dal.uploadfiles_GetList( Top,  strWhere,  filedOrder);
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
        override public List<Entity.UploadFileInfo> GetListArray(int Top, string strWhere, string filedOrder)
		{
			return dal.uploadfiles_GetListArray( Top,  strWhere,  filedOrder);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
        public List<Entity.UploadFileInfo> GetListArrayCache(int Top, string strWhere, string filedOrder)
		{
			string rawKey = string.Concat("GetListArray-", strWhere,Top,filedOrder);
            List<Entity.UploadFileInfo> lstData = base.GetCacheItem< List<Entity.UploadFileInfo>>(rawKey) ;
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
        public List<Entity.UploadFileInfo> GetListArray(int Top, string filedOrder)
		{
			return GetListArrayCache( Top,  "",  filedOrder);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
        public List<Entity.UploadFileInfo> GetListArray(string strWhere)
		{
			return GetListArrayCache( 0,  strWhere,  "");
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
        override public List<Entity.UploadFileInfo> GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby, out int RecordCount)
		{
			return dal.uploadfiles_GetListPages( PageIndex,  PageSize,  strWhere,  Fileds, oderby, out  RecordCount);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
        public List<Entity.UploadFileInfo> GetListPagesCache(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby, out int RecordCount)
		{
			string rawKey = string.Concat("GlPages-", PageIndex,PageSize,strWhere,Fileds,oderby);
			string rawKeyCount = string.Concat("C-", rawKey);
            List<Entity.UploadFileInfo> lstData = base.GetCacheItem<List<Entity.UploadFileInfo>>(rawKey)  ;
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
				string sCount = base.GetCacheItem<string>(rawKeyCount) ;
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
        public List<Entity.UploadFileInfo> GetListPages(int PageIndex, int PageSize, out int RecordCount)
		{
			return GetListPagesCache( PageIndex,  PageSize,  "",  "", "", out  RecordCount);
		}
		/// <summary>
		/// 获得数据列表-分页
		/// </summary>
        public List<Entity.UploadFileInfo> GetListPages(int PageIndex, int PageSize, string strWhere, string oderby, out int RecordCount)
		{
			return GetListPagesCache( PageIndex,  PageSize,  strWhere,  "", oderby, out  RecordCount);
		}
		/// <summary>
		/// 获得数据列表-分页
		/// </summary>
        public List<Entity.UploadFileInfo> GetListPages(int PageIndex, int PageSize, string strWhere, string oderby)
		{
			int iCount = 0;
			return GetListPagesCache(PageIndex, PageSize, strWhere, "", oderby, out iCount);
		}
		/// <summary>
		/// 搜索-分页
		/// </summary>
        public List<Entity.UploadFileInfo> SearchLike(int PageIndex, int PageSize, string oderby, out int RecordCount, string sKeyWord, string ColumnName)
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
		
		

		#endregion  成员方法
		
	

#region
        public void UpdataToSave(int sGid)
        {
            UploadFileInfo entity = GetEntity(sGid);
            if (!Equals(entity, null))
            {
                entity.IsSave = true;
                Update(entity);
            }
                
        }
        public void DeleteDataAndFile(int sGid)
        {
            UploadFileInfo entity = GetEntity(sGid);
            string SaveUrl = HttpContext.Current.Server.MapPath(entity.FileNewName);

            if(Core.FSO.FObject.IsExist(SaveUrl,FsoMethod.File))
            {
                Core.FSO.FObject.Delete(SaveUrl, FsoMethod.File);
            }
            Delete(sGid);
        }
      
        public List<UploadFileInfo> GetListPages(int PageIndex, int PageSize, out int RecordCount,bool IsUsed)
        {

            return this.GetListPages(PageIndex, PageSize, string.Concat(" issave=",IsUsed), "id desc", out RecordCount);
            //List<UploadFileInfo> lst = new List<UploadFileInfo>();

            //foreach (UploadFileInfo fileInfo in this.lstDataList)
            //{
            //    if (IsUsed)
            //    {
            //        if (fileInfo.IsSave)
            //        {
            //            lst.Add(fileInfo);
            //        }
            //    }
            //    else
            //    {
            //        if (!fileInfo.IsSave)
            //        {
            //            lst.Add(fileInfo);
            //        }
            //    }

            //}
            //RecordCount = lst.Count;
            //return PagedListExpansion.ToPagedList(lst, PageIndex, PageSize);
        }
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="PageIndex"></param>
        /// <param name="PageSize"></param>
        /// <param name="RecordCount"></param>
        /// <param name="itype">时间类别,0为所有，1为今天，2为本周，3为本月</param>
        /// <param name="sName">文件名称，为空时表示所有</param>
        /// <returns></returns>
        public List<UploadFileInfo> GetListPages(int PageIndex, int PageSize, out int RecordCount, int itype,string sName,bool IsUsed)
        {
            List<UploadFileInfo> lstSoure = GetListPages(PageIndex, PageSize, out RecordCount, IsUsed);
            
            List<UploadFileInfo> lst = new List<UploadFileInfo>();
            if (itype > 0)
            {
                foreach (UploadFileInfo fileInfo in lstSoure)
                {

                    DateTime dtEnd = DateTime.Now;
                    DateTime dtStart = fileInfo.AddDate;
                    long sp = Core.Strings.cConvert.DateDiff("d", dtStart, dtEnd);
                   
                    if (itype == 1)
                    {
                        if (sp < 1)  //今天)
                            lst.Add(fileInfo);
                    }
                    else if (itype == 2) //本周
                    {
                        if (sp < 7)
                            lst.Add(fileInfo);
                    }
                    else if (itype == 3)
                    {
                        if (sp < 30)
                            lst.Add(fileInfo);
                    }

                }
            }
            else
            {
                lst = lstSoure;
            }

            List<UploadFileInfo> lstRz = new List<UploadFileInfo>();

            if (!string.IsNullOrEmpty(sName))
            {
                foreach (UploadFileInfo fileInfo in lst)
                {
                    if (fileInfo.FileOldName.IndexOf(sName) > -1)
                    {
                        lstRz.Add(fileInfo);
                    }
                }
                
            }
            else
            {
                lstRz = lst;
            }

            RecordCount = lstRz.Count;
            return lstRz;
        }

       
#endregion
    }
}
