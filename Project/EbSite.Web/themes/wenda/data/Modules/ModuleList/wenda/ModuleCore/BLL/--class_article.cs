//using System;
//using System.Data;
//using System.Collections.Generic;
//using System.Web.UI.WebControls;
//namespace EbSite.Modules.Wenda.ModuleCore.BLL
//{
//    /// <summary>
//    /// 业务逻辑类expandanswers 的摘要说明。
//    /// </summary>
//    public class class_article: Base.BLLBase<Entity.class_article, long> 
//    {
//        public static readonly class_article Instance = new class_article();
//        private class_article()
//        {
//        }
//        #region  成员方法
	

//        /// <summary>
//        /// 增加一条数据
//        /// </summary>
//        override public long Add(Entity.class_article model)
//        {
//            base.InvalidateCache();
//            return dalHelper.class_article_Add(model);
//        }

//        /// <summary>
//        /// 更新一条数据
//        /// </summary>
//        override public void Update(Entity.class_article model)
//        {
//            base.InvalidateCache();
//            dalHelper.class_article_Update(model);
//        }

//        /// <summary>
//        /// 删除一条数据
//        /// </summary>
//        override public void Delete(long id)
//        {
			
//        }

//        /// <summary>
//        /// 得到一个对象实体
//        /// </summary>
//        override public Entity.class_article GetEntity(long id)
//        {

//            return null;
//        }

//        /// <summary>
//        /// 获得数据列表
//        /// </summary>
//        public int GetCount(string strWhere)
//        {
//            return dalHelper.expandanswers_GetCount(strWhere);
//        }
		
//        /// <summary>
//        /// 获得数据列表
//        /// </summary>
//        override public List<Entity.class_article> GetListArray(int Top, string strWhere, string filedOrder)
//        {
//            return dalHelper.GetListArray(Top, strWhere, filedOrder);
//        }
//        /// <summary>
//        /// 获得数据列表
//        /// </summary>
//        public List<Entity.class_article> GetListArrayCache(int Top, string strWhere, string filedOrder)
//        {
//            string rawKey = string.Concat("GetListArray-", strWhere,Top,filedOrder);
//             List<Entity.class_article> lstData = base.GetCacheItem(rawKey) as List<Entity.class_article>;
//            if (Equals(lstData,null))
//            {
//                //从基类调用，激活事件
//                lstData = base.GetListArrayEv( Top,  strWhere,  filedOrder);
//                if (!Equals(lstData,null))
//                    base.AddCacheItem(rawKey, lstData);
//            }
//            return lstData;
//        }
		
	
//        /// <summary>
//        /// 获得数据列表
//        /// </summary>
//        override public List<Entity.class_article> GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby, out int RecordCount)
//        {
//            return dalHelper.class_article_GetListPages( PageIndex,  PageSize,  strWhere,  Fileds, oderby, out  RecordCount);
//        }
//        /// <summary>
//        /// 获得数据列表
//        /// </summary>
//        public List<Entity.class_article> GetListPagesCache(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby, out int RecordCount)
//        {
//            string rawKey = string.Concat("GlPages-", PageIndex,PageSize,strWhere,Fileds,oderby);
//            string rawKeyCount = string.Concat("C-", rawKey);
//            List<Entity.class_article> lstData = base.GetCacheItem(rawKey) as List<Entity.class_article>;
//            int iRecordCount = -1;
//            if (Equals(lstData,null))
//            {
//                //从基类调用，激活事件
//                lstData = base.GetListPagesEv(  PageIndex,  PageSize,  strWhere,  Fileds, oderby, out  RecordCount);
//                if (!Equals(lstData,null))
//                {
//                    base.AddCacheItem(rawKey, lstData);
//                    base.AddCacheItem(rawKeyCount, RecordCount.ToString());
//                }
//            }
//            if(iRecordCount==-1)
//            {
//                string sCount = base.GetCacheItem(rawKeyCount) as string;
//                if (!string.IsNullOrEmpty(sCount))
//                {
//                    RecordCount = int.Parse(sCount);
//                }
//                else
//                {
//                    RecordCount = GetCountCache(strWhere);
//                }
//            }
//            else
//            {
//                RecordCount = iRecordCount;
//            }
//            return lstData;
//        }
//        /// <summary>
//        /// 获得数据列表
//        /// </summary>
//        public int GetCountCache(string strWhere)
//        {
//            string rawKey = string.Concat("GetCount-", strWhere);
//            string sCount = base.GetCacheItem(rawKey) as string;
//            if (string.IsNullOrEmpty(sCount))
//            {
//                sCount = GetCountCache(strWhere).ToString();
//                if (!string.IsNullOrEmpty(sCount))
//                    base.AddCacheItem(rawKey, sCount);
//            }
//            if (!string.IsNullOrEmpty(sCount))
//            {
//                return int.Parse(sCount);
//            }
//            return 0;
//        }
//        /// <summary>
//        /// 获得数据列表-分页
//        /// </summary>
//        public List<Entity.class_article> GetListPages(int PageIndex, int PageSize, out int RecordCount)
//        {
//            return GetListPagesCache( PageIndex,  PageSize,  "",  "", "", out  RecordCount);
//        }
//        /// <summary>
//        /// 获得数据列表-分页
//        /// </summary>
//        public List<Entity.class_article> GetListPages(int PageIndex, int PageSize, string strWhere, string oderby, out int RecordCount)
//        {
//            return GetListPagesCache( PageIndex,  PageSize,  strWhere,  "", oderby, out  RecordCount);
//        }
//        /// <summary>
//        /// 获得数据列表-分页
//        /// </summary>
//        public List<Entity.class_article> GetListPages(int PageIndex, int PageSize, string strWhere, string oderby)
//        {
//            int iCount = 0;
//            return GetListPagesCache(PageIndex, PageSize, strWhere, "", oderby, out iCount);
//        }
//        /// <summary>
//        /// 搜索-分页
//        /// </summary>
//        public List<Entity.class_article> SearchLike(int PageIndex, int PageSize, string oderby, out int RecordCount, string sKeyWord, string ColumnName)
//        {
//            string strWhere = "";
//            if (!string.IsNullOrEmpty(sKeyWord)) strWhere = string.Format("{0} like '%{1}%'", ColumnName, sKeyWord);
//            if (string.IsNullOrEmpty(strWhere))
//            {
//            RecordCount = 0;
//            return null;
//            }
//            return GetListPagesCache(PageIndex, PageSize, strWhere, "", oderby, out  RecordCount);
//        }


//        public DataSet GetClassArticleRandomContentIDS(int Top, string swhere, string ids)
//        {
//            return dalHelper.GetClassArticleRandomContentIDS(Top, swhere, ids);
//        }

//        public DataSet GetNewsClassArticleContent(int PageIndex, int PageSize)
//        {
//            return dalHelper.GetNewsClassArticleContent(PageIndex, PageSize);
//        }
//        #endregion  成员方法
	
//    }
//}

