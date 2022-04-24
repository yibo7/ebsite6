using System;
using System.Data;
using System.Collections.Generic;
using System.Web.UI.WebControls;
namespace EbSite.Modules.Shop.ModuleCore.BLL
{
    /// <summary>
    /// 业务逻辑类GroupBuy 的摘要说明。
    /// </summary>
    public class GroupBuy : Base.BLLBase<Entity.GroupBuy, int>
    {
        public static readonly GroupBuy Instance = new GroupBuy();
        private GroupBuy()
        {
        }
        #region  成员方法

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return dalHelper.GroupBuy_GetMaxId();
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            return dalHelper.GroupBuy_Exists(id);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        override public int Add(Entity.GroupBuy model)
        {
            base.InvalidateCache();
            return dalHelper.GroupBuy_Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        override public void Update(Entity.GroupBuy model)
        {
            base.InvalidateCache();
            dalHelper.GroupBuy_Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        override public void Delete(int id)
        {
            base.InvalidateCache();

            dalHelper.GroupBuy_Delete(id);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        override public Entity.GroupBuy GetEntity(int id)
        {
            return dalHelper.GroupBuy_GetEntity(id);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public int GetCount(string strWhere)
        {
            return dalHelper.GroupBuy_GetCount(strWhere);
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
            return dalHelper.GroupBuy_GetList(Top, strWhere, filedOrder);
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
                lstData = EbSite.Core.DataSetHelper.RetrieveDataSet(ibyte);
            }
            return lstData;
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        override public List<Entity.GroupBuy> GetListArray(int Top, string strWhere, string filedOrder)
        {
            return dalHelper.GroupBuy_GetListArray(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Entity.GroupBuy> GetListArrayCache(int Top, string strWhere, string filedOrder)
        {
            string rawKey = string.Concat("GetListArray-", strWhere, Top, filedOrder);
            List<Entity.GroupBuy> lstData = base.GetCacheItem<List<Entity.GroupBuy>>(rawKey);
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
        public List<Entity.GroupBuy> GetListArray(int Top, string filedOrder)
        {
            return GetListArrayCache(Top, "", filedOrder);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Entity.GroupBuy> GetListArray(string strWhere)
        {
            return GetListArrayCache(0, strWhere, "");
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        override public List<Entity.GroupBuy> GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby, out int RecordCount)
        {
            return dalHelper.GroupBuy_GetListPages(PageIndex, PageSize, strWhere, Fileds, oderby, out  RecordCount);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Entity.GroupBuy> GetListPagesCache(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby, out int RecordCount)
        {
            string rawKey = string.Concat("GlPages-", PageIndex, PageSize, strWhere, Fileds, oderby);
            string rawKeyCount = string.Concat("C-", rawKey);
            List<Entity.GroupBuy> lstData = base.GetCacheItem<List<Entity.GroupBuy>>(rawKey);
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
        public List<Entity.GroupBuy> GetListPages(int PageIndex, int PageSize, out int RecordCount)
        {
            return GetListPagesCache(PageIndex, PageSize, "", "", "", out  RecordCount);
        }
        /// <summary>
        /// 获得数据列表-分页
        /// </summary>
        public List<Entity.GroupBuy> GetListPages(int PageIndex, int PageSize, string strWhere, string oderby, out int RecordCount)
        {
            return GetListPagesCache(PageIndex, PageSize, strWhere, "", oderby, out  RecordCount);
        }
        /// <summary>
        /// 获得数据列表-分页
        /// </summary>
        public List<Entity.GroupBuy> GetListPages(int PageIndex, int PageSize, string strWhere, string oderby)
        {
            int iCount = 0;
            return GetListPagesCache(PageIndex, PageSize, strWhere, "", oderby, out iCount);
        }
        /// <summary>
        /// 搜索-分页
        /// </summary>
        public List<Entity.GroupBuy> SearchLike(int PageIndex, int PageSize, string oderby, out int RecordCount, string sKeyWord, string ColumnName)
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
                Entity.GroupBuy mdEt = GetEntity(ThisId);
                foreach (System.Web.UI.Control uc in ph.Controls)
                {
                    if (Equals(uc.ID, null)) continue;
                    string sValue = "";
                    if (Equals(uc.ID.ToLower(), "id".ToLower()))
                    {
                        sValue = mdEt.id.ToString();
                    }
                    else if (Equals(uc.ID.ToLower(), "ProductID".ToLower()))
                    {
                        sValue = mdEt.ProductID.ToString();
                    }
                    else if (Equals(uc.ID.ToLower(), "NeedPrice".ToLower()))
                    {
                        sValue = mdEt.NeedPrice.ToString();
                    }
                    else if (Equals(uc.ID.ToLower(), "StartDate".ToLower()))
                    {
                        sValue = mdEt.StartDate.ToString();
                    }
                    else if (Equals(uc.ID.ToLower(), "EndDate".ToLower()))
                    {
                        sValue = mdEt.EndDate.ToString();
                    }
                    else if (Equals(uc.ID.ToLower(), "MaxCount".ToLower()))
                    {
                        sValue = mdEt.MaxCount.ToString();
                    }
                    else if (Equals(uc.ID.ToLower(), "Content".ToLower()))
                    {
                        sValue = mdEt.Content.ToString();
                    }
                    else if (Equals(uc.ID.ToLower(), "Status".ToLower()))
                    {
                        sValue = mdEt.Status.ToString();
                    }
                    else if (Equals(uc.ID.ToLower(), "OrderID".ToLower()))
                    {
                        sValue = mdEt.OrderID.ToString();
                    }
                    else if (Equals(uc.ID.ToLower(), "Price".ToLower()))
                    {
                        sValue = mdEt.Price.ToString();
                    }
                    else if (Equals(uc.ID.ToLower(), "Title".ToLower()))
                    {
                        sValue = mdEt.Title.ToString();
                    }
                    else if (Equals(uc.ID.ToLower(), "SmallImg".ToLower()))
                    {
                        sValue = mdEt.SmallImg.ToString();
                    }
                    else if (Equals(uc.ID.ToLower(), "BuyCount".ToLower()))
                    {
                        sValue = mdEt.BuyCount.ToString();
                    }
                    else if (Equals(uc.ID.ToLower(), "SDateLine".ToLower()))
                    {
                        sValue = mdEt.SDateLine.ToString();
                    }
                    else if (Equals(uc.ID.ToLower(), "EDateLine".ToLower()))
                    {
                        sValue = mdEt.EDateLine.ToString();
                    }
                    else if (Equals(uc.ID.ToLower(), "BuyPrice".ToLower()))
                    {
                        sValue = mdEt.BuyPrice.ToString();
                    }
                     else if (Equals(uc.ID.ToLower(), "Buyed".ToLower()))
                    {
                        sValue = mdEt.Buyed.ToString();
                    }
                     else if (Equals(uc.ID.ToLower(), "BuySumOrder".ToLower()))
                    {
                        sValue = mdEt.BuySumOrder.ToString();
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
        public int SaveEntityFromCtr(PlaceHolder ph, List<EbSite.Base.BLL.OtherColumn> lstOtherColumn)
        {
            int groupid = 0;
            Entity.GroupBuy mdEntity = GetEntityFromCtr(ph);
            if (!Equals(lstOtherColumn, null) && lstOtherColumn.Count > 0)
            {
                foreach (EbSite.Base.BLL.OtherColumn column in lstOtherColumn)
                {
                    if (Equals(column.ColumnName.ToLower(), "id".ToLower()))
                    {
                        mdEntity.id = int.Parse(column.ColumnValue);
                    }
                    else if (Equals(column.ColumnName.ToLower(), "ProductID".ToLower()))
                    {
                        mdEntity.ProductID = int.Parse(column.ColumnValue);
                    }
                    else if (Equals(column.ColumnName.ToLower(), "NeedPrice".ToLower()))
                    {
                        mdEntity.NeedPrice = decimal.Parse(column.ColumnValue);
                    }
                    else if (Equals(column.ColumnName.ToLower(), "StartDate".ToLower()))
                    {
                        mdEntity.StartDate = DateTime.Parse(column.ColumnValue);
                    }
                    else if (Equals(column.ColumnName.ToLower(), "EndDate".ToLower()))
                    {
                        mdEntity.EndDate = DateTime.Parse(column.ColumnValue);
                    }
                    else if (Equals(column.ColumnName.ToLower(), "MaxCount".ToLower()))
                    {
                        mdEntity.MaxCount = int.Parse(column.ColumnValue);
                    }
                    else if (Equals(column.ColumnName.ToLower(), "Content".ToLower()))
                    {
                        mdEntity.Content = column.ColumnValue;
                    }
                    else if (Equals(column.ColumnName.ToLower(), "Status".ToLower()))
                    {
                        mdEntity.Status = int.Parse(column.ColumnValue);
                    }
                    else if (Equals(column.ColumnName.ToLower(), "OrderID".ToLower()))
                    {
                        mdEntity.OrderID = int.Parse(column.ColumnValue);
                    }
                    else if (Equals(column.ColumnName.ToLower(), "Price".ToLower()))
                    {
                        mdEntity.Price = decimal.Parse(column.ColumnValue);
                    }
                    else if (Equals(column.ColumnName.ToLower(), "Title".ToLower()))
                    {
                        mdEntity.Title = column.ColumnValue.ToString();
                    }
                    else if (Equals(column.ColumnName.ToLower(), "SmallImg".ToLower()))
                    {
                        mdEntity.SmallImg = column.ColumnValue.ToString();
                    }
                    else if (Equals(column.ColumnName.ToLower(), "BuyCount".ToLower()))
                    {
                        mdEntity.BuyCount =int.Parse(column.ColumnValue.ToString());
                    }
                    else if (Equals(column.ColumnName.ToLower(), "SDateLine".ToLower()))
                    {
                        mdEntity.SDateLine = int.Parse(column.ColumnValue.ToString());
                    }
                    else if (Equals(column.ColumnName.ToLower(), "EDateLine".ToLower()))
                    {
                        mdEntity.EDateLine = int.Parse(column.ColumnValue.ToString());
                    }
                    else if (Equals(column.ColumnName.ToLower(), "BuyPrice".ToLower()))
                    {
                        mdEntity.BuyPrice =decimal.Parse(column.ColumnValue.ToString());
                    }
                      else if (Equals(column.ColumnName.ToLower(), "Buyed".ToLower()))
                    {
                        mdEntity.Buyed = int.Parse(column.ColumnValue.ToString());
                    }
                      else if (Equals(column.ColumnName.ToLower(), "BuySumOrder".ToLower()))
                    {
                        mdEntity.BuySumOrder = int.Parse(column.ColumnValue.ToString());
                    }

                       
                }
            }
            if (mdEntity.id > 0)
            {
                Update(mdEntity);
            }
            else
            {
                groupid = Add(mdEntity);
            }
            return groupid;
        }
        /// <summary>
        /// 从PlaceHolder中获取一个实例
        /// </summary>
        public Entity.GroupBuy GetEntityFromCtr(PlaceHolder ph)
        {
            Entity.GroupBuy mdEt = new Entity.GroupBuy();
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
                else if (Equals(uc.ID.ToLower(), "ProductID".ToLower()))
                {
                    mdEt.ProductID = int.Parse(sValue);
                }
                else if (Equals(uc.ID.ToLower(), "NeedPrice".ToLower()))
                {
                    mdEt.NeedPrice = decimal.Parse(sValue);
                }
                else if (Equals(uc.ID.ToLower(), "StartDate".ToLower()))
                {
                    mdEt.StartDate = DateTime.Parse(sValue);
                }
                else if (Equals(uc.ID.ToLower(), "EndDate".ToLower()))
                {
                    mdEt.EndDate = DateTime.Parse(sValue);
                }
                else if (Equals(uc.ID.ToLower(), "MaxCount".ToLower()))
                {
                    mdEt.MaxCount = int.Parse(sValue);
                }
                else if (Equals(uc.ID.ToLower(), "Content".ToLower()))
                {
                    mdEt.Content = sValue;
                }
                else if (Equals(uc.ID.ToLower(), "Status".ToLower()))
                {
                    mdEt.Status = int.Parse(sValue);
                }
                else if (Equals(uc.ID.ToLower(), "OrderID".ToLower()))
                {
                    mdEt.OrderID = int.Parse(sValue);
                }
                else if (Equals(uc.ID.ToLower(), "Price".ToLower()))
                {
                    mdEt.Price = decimal.Parse(sValue);
                }
                else if (Equals(uc.ID.ToLower(), "Title".ToLower()))
                {
                    mdEt.Title = sValue.ToString();
                }
                else if (Equals(uc.ID.ToLower(), "SmallImg".ToLower()))
                {
                    mdEt.SmallImg = sValue.ToString();
                }
                else if (Equals(uc.ID.ToLower(), "BuyCount".ToLower()))
                {
                    mdEt.BuyCount =int.Parse(sValue.ToString());
                }
                else if (Equals(uc.ID.ToLower(), "SDateLine".ToLower()))
                {
                    mdEt.SDateLine = int.Parse(sValue.ToString());
                }
                else if (Equals(uc.ID.ToLower(), "EDateLine".ToLower()))
                {
                    mdEt.EDateLine = int.Parse(sValue.ToString());
                }
                else if (Equals(uc.ID.ToLower(), "BuyPrice".ToLower()))
                {
                    mdEt.BuyPrice =decimal.Parse(sValue.ToString());
                }
                else if (Equals(uc.ID.ToLower(), "Buyed".ToLower()))
                {
                    mdEt.Buyed =int.Parse(sValue.ToString());
                }
                else if (Equals(uc.ID.ToLower(), "BuySumOrder".ToLower()))
                {
                    mdEt.BuySumOrder =int.Parse(sValue.ToString());
                }

                
            }
            return mdEt;
        }

        #endregion  成员方法

        #region  自定义方法

        /// <summary>
        /// 获取团购数量
        /// </summary>
        /// <param name="groupID">团购ID</param>
        /// <returns></returns>
        public int GetOrderCount(int groupID)
        {
            return dalHelper.GroupBuy_GetOrderCount(groupID);
        }
        /// <summary>
        /// 团购状态转换
        /// </summary>
        /// <param name="orderState"></param>
        /// <returns></returns>
        public string ParseGroupState(string iState)
        {
            string resultState = "未知";
            switch (iState)
            {   
                case "0":
                    resultState = "<font style='color:#F14383;font-weight:bold;'>正在进行中 </font>";
                    break;
                case "1":
                    resultState = "<font style='font-weight:bold;color:#0E529E;'>成功结束</font>";
                    break;
                case "2":
                    resultState = "失败结束";
                    break;
                case "3":
                    resultState = "还未开始";
                    break;
                case "4":
                    resultState = "<font style='color:red;'>结束未处理</font>";
                    break;
               
            }
            return resultState;
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="Status">团购状态</param>
        /// <param name="id">团购ID</param>
        public void Update(int Status, int id)
        {
            dalHelper.GroupBuy_Update(Status, id);
        }

        #endregion  自定义方法

        //public List<Entity.GroupBuy> UnionGroupBuy_GetList(int Top, string strWhere, string filedOrder)
        //{
        //    return dalHelper.UnionGroupBuy_GetList(Top, strWhere, filedOrder);
        //}

        /// <summary>
        /// 自动 检测 团购状态 到期 改为进行中
        /// </summary>
        public void AutoSetGroupStaus()
        {
            //status=3 未开始
            List<Entity.GroupBuy> ls = GroupBuy.Instance.GetListArray(0, "Status=3 and StartDate <NOW()", "");
            foreach (var groupBuy in ls)
            {
                groupBuy.Status = Convert.ToInt32( SystemEnum.GroupBuyState.正在进行中);
                groupBuy.Update();
            }

            //status=0 正在进行中 
            List<Entity.GroupBuy> lsing = GroupBuy.Instance.GetListArray(0, "Status=0 and EndDate <NOW()", "");
            foreach (var groupBuy in lsing)
            {
                groupBuy.Status = Convert.ToInt32(SystemEnum.GroupBuyState.结束未处理);
                groupBuy.Update();
            }
        }
        /// <summary>
        /// 定时更新团购状态
        /// </summary>
        /// <returns></returns>
        public bool UpdateStatus()
        {
            return dalHelper.GroupBuy_UpdateStatus();
        }
    }
}

