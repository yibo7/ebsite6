using System;
using System.Collections;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using EbSite.Base.Static;
using EbSite.Data.Interface;

namespace EbSite.BLL
{
    /// <summary>
    /// 业务逻辑类EB_Area 的摘要说明。
    /// </summary>
    public class AreaInfo : Base.BLL.BllBase<Entity.AreaInfo, int>
    {
        public static readonly AreaInfo Instance = new AreaInfo();
        private AreaInfo()
        {
        }
        #region  成员方法

        /// <summary>
        /// 增加一条数据
        /// </summary>
        override public int Add(Entity.AreaInfo model)
        {
            base.InvalidateCache();
            return DbProviderCms.GetInstance().AreaInfo_Add(model);

        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        override public void Update(Entity.AreaInfo model)
        {
            base.InvalidateCache();
            DbProviderCms.GetInstance().AreaInfo_Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        override public void Delete(int id)
        {
            base.InvalidateCache();
            DbProviderCms.GetInstance().AreaInfo_Delete(id);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        override public Entity.AreaInfo GetEntity(int id)
        {
            string rawKey = string.Concat("GetEntity-", id);
            Entity.AreaInfo etEntity = base.GetCacheItem<Entity.AreaInfo>(rawKey);
            if (Equals(etEntity, null))
            {
                etEntity = DbProviderCms.GetInstance().AreaInfo_GetEntity(id);
                if (!Equals(etEntity, null))
                    base.AddCacheItem(rawKey, etEntity);
            }
            return etEntity;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public int GetCount(string strWhere)
        {
            return DbProviderCms.GetInstance().AreaInfo_GetCount(strWhere);
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
            return GetListCache(0, strWhere, "");
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
            return DbProviderCms.GetInstance().AreaInfo_GetList(Top, strWhere, filedOrder);
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
        override public List<Entity.AreaInfo> GetListArray(int Top, string strWhere, string filedOrder)
        {
            return DbProviderCms.GetInstance().AreaInfo_GetListArray(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Entity.AreaInfo> GetListArrayCache(int Top, string strWhere, string filedOrder)
        {
            string rawKey = string.Concat("GetListArray-", strWhere, Top, filedOrder);
            List<Entity.AreaInfo> lstData = base.GetCacheItem<List<Entity.AreaInfo>>(rawKey);
            if (Equals(lstData, null))
            {
                //从基类调用，激活事件
                lstData = base.GetListArrayEv(Top, strWhere, filedOrder);
                if (!Equals(lstData, null))
                    base.AddCacheItem(rawKey, lstData);
            }
            return lstData;
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Entity.AreaInfo> GetListArray(int Top, string filedOrder)
        {
            return GetListArrayCache(Top, "", filedOrder);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Entity.AreaInfo> GetListArray(string strWhere)
        {
            return GetListArrayCache(0, strWhere, "");
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        override public List<Entity.AreaInfo> GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby, out int RecordCount)
        {
            return DbProviderCms.GetInstance().AreaInfo_GetListPages(PageIndex, PageSize, strWhere, Fileds, oderby, out  RecordCount);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Entity.AreaInfo> GetListPagesCache(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby, out int RecordCount)
        {
            string rawKey = string.Concat("GlPages-", PageIndex, PageSize, strWhere, Fileds, oderby);
            string rawKeyCount = string.Concat("C-", rawKey);
            List<Entity.AreaInfo> lstData = base.GetCacheItem<List<Entity.AreaInfo>>(rawKey);
            int iRecordCount = -1;
            if (Equals(lstData, null))
            {
                //从基类调用，激活事件
                lstData = base.GetListPagesEv(PageIndex, PageSize, strWhere, Fileds, oderby, out  RecordCount);
                if (!Equals(lstData, null))
                {
                    base.AddCacheItem(rawKey, lstData);
                    base.AddCacheItem(rawKeyCount, RecordCount.ToString());
                }
            }
            if (iRecordCount == -1)
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
        public List<Entity.AreaInfo> GetListPages(int PageIndex, int PageSize, out int RecordCount)
        {
            return GetListPagesCache(PageIndex, PageSize, "", "", "", out  RecordCount);
        }
        /// <summary>
        /// 获得数据列表-分页
        /// </summary>
        public List<Entity.AreaInfo> GetListPages(int PageIndex, int PageSize, string strWhere, string oderby, out int RecordCount)
        {
            return GetListPagesCache(PageIndex, PageSize, strWhere, "", oderby, out  RecordCount);
        }
        /// <summary>
        /// 获得数据列表-分页
        /// </summary>
        public List<Entity.AreaInfo> GetListPages(int PageIndex, int PageSize, string strWhere, string oderby)
        {
            int iCount = 0;
            return GetListPagesCache(PageIndex, PageSize, strWhere, "", oderby, out iCount);
        }
        /// <summary>
        /// 搜索-分页
        /// </summary>
        public List<Entity.AreaInfo> SearchLike(int PageIndex, int PageSize, string oderby, out int RecordCount, string sKeyWord, string ColumnName)
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
                Entity.AreaInfo mdEt = GetEntity(ThisId);
                foreach (System.Web.UI.Control uc in ph.Controls)
                {
                    if (Equals(uc.ID, null)) continue;
                    string sValue = "";
                    if (Equals(uc.ID.ToLower(), "id".ToLower()))
                    {
                        sValue = mdEt.id.ToString();
                    }
                    else if (Equals(uc.ID.ToLower(), "Name".ToLower()))
                    {
                        sValue = mdEt.Name.ToString();
                    }
                    else if (Equals(uc.ID.ToLower(), "OrderID".ToLower()))
                    {
                        sValue = mdEt.OrderID.ToString();
                    }
                    else if (Equals(uc.ID.ToLower(), "HeadID".ToLower()))
                    {
                        sValue = mdEt.HeadID.ToString();
                    }
                    else if (Equals(uc.ID.ToLower(), "Level".ToLower()))
                    {
                        sValue = mdEt.Level.ToString();
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
            SaveEntityFromCtr(ph, null);
        }
        /// <summary>
        /// 获取控件里的数据映射到一个实体，接着保存这个实例到数据
        /// </summary>
        public void SaveEntityFromCtr(PlaceHolder ph, List<EbSite.Base.BLL.OtherColumn> lstOtherColumn)
        {
            Entity.AreaInfo mdEntity = GetEntityFromCtr(ph);
            if (!Equals(lstOtherColumn, null) && lstOtherColumn.Count > 0)
            {
                foreach (EbSite.Base.BLL.OtherColumn column in lstOtherColumn)
                {
                    if (Equals(column.ColumnName.ToLower(), "id".ToLower()))
                    {
                        mdEntity.id = int.Parse(column.ColumnValue);
                    }
                    else if (Equals(column.ColumnName.ToLower(), "Name".ToLower()))
                    {
                        mdEntity.Name = column.ColumnValue;
                    }
                    else if (Equals(column.ColumnName.ToLower(), "OrderID".ToLower()))
                    {
                        mdEntity.OrderID = int.Parse(column.ColumnValue);
                    }
                    else if (Equals(column.ColumnName.ToLower(), "HeadID".ToLower()))
                    {
                        mdEntity.HeadID = int.Parse(column.ColumnValue);
                    }
                    else if (Equals(column.ColumnName.ToLower(), "Level".ToLower()))
                    {
                        mdEntity.Level = int.Parse(column.ColumnValue);
                    }
                }
            }
            if (mdEntity.id > 0)
            {
                Update(mdEntity);
            }
            else
            {
                Add(mdEntity);
            }
        }
        /// <summary>
        /// 从PlaceHolder中获取一个实例
        /// </summary>
        public Entity.AreaInfo GetEntityFromCtr(PlaceHolder ph)
        {
            Entity.AreaInfo mdEt = new Entity.AreaInfo();
            string sKeyID;
            if (GetIDFromCtr(ph, out sKeyID))
            {
                mdEt = GetEntity(int.Parse(sKeyID));
            }
            foreach (System.Web.UI.Control uc in ph.Controls)
            {
                if (Equals(uc.ID, null)) continue;
                string sValue = GetValueFromControl(uc);
                if (Equals(uc.ID.ToLower(), "id".ToLower()))
                {
                    mdEt.id = int.Parse(sValue);
                }
                else if (Equals(uc.ID.ToLower(), "Name".ToLower()))
                {
                    mdEt.Name = sValue;
                }
                else if (Equals(uc.ID.ToLower(), "OrderID".ToLower()))
                {
                    mdEt.OrderID = int.Parse(sValue);
                }
                else if (Equals(uc.ID.ToLower(), "HeadID".ToLower()))
                {
                    mdEt.HeadID = int.Parse(sValue);
                }
                else if (Equals(uc.ID.ToLower(), "Level".ToLower()))
                {
                    mdEt.Level = int.Parse(sValue);
                }
            }
            return mdEt;
        }

        #endregion  成员方法


         public bool AreaDataAllAdd(string url)
         {
             return DbProviderCms.GetInstance().AreaDataAllAdd(url);
         }
        #region  原来XML 中方法
        public List<Entity.AreaInfo> GetListByParentID(int iParentID)
        {
            #region 旧版
            //IEnumerable<Entity.AreaInfo> lst = base.FillList().Where(p => p.HeadID == iParentID);
            //return lst.ToList();
            #endregion

            List<Entity.AreaInfo> lst = GetListArray(0, "HeadID="+iParentID, "");
            return lst;
        }
        /// <summary>
        /// 得到各个深度的数据源
        /// </summary>
        /// <returns></returns>
        public List<Entity.AreaInfo> GetListDataing(int levelID)
        {
            #region 旧
            //List<Entity.AreaInfo> NewList = (from li in base.FillList()
            //                                 where (li.Level == levelID)
            //                                 select li
            //                          ).ToList();

            //return NewList;
            #endregion

            List<Entity.AreaInfo> NewList = GetListArray(0, "Level="+levelID, "");
            return NewList;
        }
        /// <summary>
        /// 联动的查询
        /// </summary>
        /// <param name="HeadID"></param>
        /// <returns></returns>
        public List<Entity.AreaInfo> GetListTree(int HeadID)
        {
            #region 旧
            //List<Entity.AreaInfo> NewList = (from li in base.FillList()
            //                                 where (li.HeadID == HeadID)
            //                                 select li
            //                          ).ToList();

            //return NewList;
            #endregion
            List<Entity.AreaInfo> lst = GetListArray(0, "HeadID=" + HeadID, "");
            return lst;

        }
        /// <summary>
        /// 得到某一个深度的最大ID
        /// </summary>
        /// <returns></returns>
        public int GetAreaOrderNums(int levelID)
        {
            #region 旧
            //int nums = 1;
            //List<Entity.AreaInfo> NewList = (from li in base.FillList()
            //                                 where (li.Level == levelID)
            //                                 orderby li.OrderID descending
            //                                 select li
            //                                ).Take(1).ToList();
            //if (NewList != null)
            //{
            //    if (NewList.Count > 0)
            //    {
            //        nums = NewList[0].OrderID + 1;
            //    }
            //}
            //return nums;
            #endregion
            int nums = 1;

            List<Entity.AreaInfo> NewList = GetListArray(1, "Level=" + levelID, "OrderID desc"); 
            if (NewList != null)
            {
                if (NewList.Count > 0)
                {
                    nums = NewList[0].OrderID + 1;
                }
            }
            return nums;
        }
        /// <summary>
        /// 倒序 的呈现  朝阳区 北京市 北京 中国 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string GetAddressByID(int id)
        {
            Entity.AreaInfo md = GetEntity(id);
            int pid = md.HeadID;
            List<string> sList = new List<string>();
            sList.Add(md.Name);
            GetAddressByPID(pid, ref sList);

            return string.Join(" ", sList.ToArray());
        }
       
        private void GetAddressByPID(int pid, ref List<string> lst)
        {

            if (pid > 0)
            {
                Entity.AreaInfo md = GetEntity(pid);
                lst.Add(md.Name);
                GetAddressByPID(md.HeadID, ref lst);
            }
        }

        /// <summary>
        /// 正序 的呈现  中国   北京  北京市 朝阳区
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string GetAddressByIdAsc(int id)
        {
            Entity.AreaInfo md = GetEntity(id);
            int pid = md.HeadID;

            List<Entity.AreaInfo> sl = new List<Entity.AreaInfo>();
            Entity.AreaInfo mdN = new Entity.AreaInfo();
            mdN.Level = md.Level;
            mdN.Name = md.Name;
            sl.Add(mdN);
            GetAddressByPIDAsc(pid, ref sl);

            string str = "";
            List<Entity.AreaInfo> SDList = (from i in sl orderby i.Level select i).ToList();
            foreach (var areaInfo in SDList)
            {
                str += areaInfo.Name + " ";
            }
            return str;
        }
        private void GetAddressByPIDAsc(int pid, ref List<Entity.AreaInfo> lst)
        {

            if (pid > 0)
            {
                Entity.AreaInfo md = GetEntity(pid);
                Entity.AreaInfo mdN = new Entity.AreaInfo();
                mdN.Level = md.Level;
                mdN.Name = md.Name;
                lst.Add(mdN);
                GetAddressByPIDAsc(md.HeadID, ref lst);
            }
        }
        #region 获取某个分类父ID集合,逗号分开

        public string GetListParentIDs(int id, out int cityid,out string cityname, out int  provinceid,out string provincename)
        {
            Entity.AreaInfo md = GetEntity(id);
            int pid = md.HeadID;
            List<Entity.AreaInfo> sList = new List<Entity.AreaInfo>();
            //sList.Add(md.Name);
            List<string> sListID = new List<string>();
            int icityid = 0;
            int iprovinceid = 0;
            string icityname="", iprovincename="";
            GetParentID(pid, ref sList);
            for (int i = 0; i < sList.Count; i++)
            {
                sListID.Add(sList[i].id.ToString());
                if (i == 0)
                {
                    icityid = sList[i].id;
                    icityname = sList[i].Name;
                }
                if (i == 1)
                {
                    iprovinceid = sList[i].id;
                    iprovincename = sList[i].Name;
                }
            }
            cityid = icityid;
            cityname = icityname;
            provinceid = iprovinceid;
            provincename = iprovincename;
            return string.Join(",", sListID.ToArray());
        }
        private void GetParentID(int pid, ref List<Entity.AreaInfo> lst)
        {

            if (pid > 0)
            {
                Entity.AreaInfo md = GetEntity(pid);
                lst.Add(md);
                GetParentID(md.HeadID, ref lst);
            }
        }

        
        #endregion

        #region 根据ID获省市县ID、name

        //flz(2012-8-28)
        public Hashtable GetAddressListByID(int id)
        {
            Hashtable ht = Hashtable.Synchronized(new Hashtable());
            Dictionary<int, string> dic = new Dictionary<int, string>();
            Entity.AreaInfo md = GetEntity(id);
            int pid = md.HeadID;
            dic.Add(md.id, md.Name);
            ht.Add(md.Level, dic);
            GetAddressListByPID(md.HeadID, ref ht);
            return ht;
        }
        //flz(2012-8-28)
        private void GetAddressListByPID(int pid, ref Hashtable ht)
        {
            Dictionary<int, string> dic = new Dictionary<int, string>();
            if (pid > 0)
            {
                Entity.AreaInfo md = GetEntity(pid);
                dic.Add(md.id, md.Name);
                ht.Add(md.Level, dic);
                GetAddressListByPID(md.HeadID, ref ht);
            }
        }

        #endregion 根据ID获省市县ID、name

        #endregion  自定义方法
    }
}

