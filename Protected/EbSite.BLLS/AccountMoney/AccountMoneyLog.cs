using System;
using System.Data;
using System.Collections.Generic;
using System.Data.Common;
using System.Web.UI.WebControls;
using EbSite.Base.Static;
using EbSite.Data.User.Interface;

namespace EbSite.BLL
{
    /// <summary>
    /// 业务逻辑类AccountMoneyLog 的摘要说明。
    /// </summary>
    public class AccountMoneyLog : Base.BLL.BllBase<Entity.AccountMoneyLog, int>
    {
        public static readonly AccountMoneyLog Instance = new AccountMoneyLog();
        private AccountMoneyLog()
        {
        }
        #region  成员方法

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbProviderUser.GetInstance().AccountMoneyLog_GetMaxId();
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            return DbProviderUser.GetInstance().AccountMoneyLog_Exists(id);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        override public int Add(Entity.AccountMoneyLog model)
        {
            base.InvalidateCache();
            return DbProviderUser.GetInstance().AccountMoneyLog_Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        override public void Update(Entity.AccountMoneyLog model)
        {
            base.InvalidateCache();
            DbProviderUser.GetInstance().AccountMoneyLog_Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        override public void Delete(int id)
        {
            base.InvalidateCache();

            DbProviderUser.GetInstance().AccountMoneyLog_Delete(id);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        override public Entity.AccountMoneyLog GetEntity(int id)
        {

            string rawKey = string.Concat("GetEntity-", id);
            Entity.AccountMoneyLog etEntity = base.GetCacheItem<Entity.AccountMoneyLog>(rawKey);
            if (Equals(etEntity, null))
            {
                etEntity = DbProviderUser.GetInstance().AccountMoneyLog_GetEntity(id);
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
            return DbProviderUser.GetInstance().AccountMoneyLog_GetCount(strWhere);
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
            return DbProviderUser.GetInstance().AccountMoneyLog_GetList(Top, strWhere, filedOrder);
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
        override public List<Entity.AccountMoneyLog> GetListArray(int Top, string strWhere, string filedOrder)
        {
            return DbProviderUser.GetInstance().AccountMoneyLog_GetListArray(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Entity.AccountMoneyLog> GetListArrayCache(int Top, string strWhere, string filedOrder)
        {
            string rawKey = string.Concat("GetListArray-", strWhere, Top, filedOrder);
            List<Entity.AccountMoneyLog> lstData = base.GetCacheItem<List<Entity.AccountMoneyLog>>(rawKey);
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
        public List<Entity.AccountMoneyLog> GetListArray(int Top, string filedOrder)
        {
            return GetListArrayCache(Top, "", filedOrder);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Entity.AccountMoneyLog> GetListArray(string strWhere)
        {
            return GetListArrayCache(0, strWhere, "");
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        override public List<Entity.AccountMoneyLog> GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby, out int RecordCount)
        {
            return DbProviderUser.GetInstance().AccountMoneyLog_GetListPages(PageIndex, PageSize, strWhere, Fileds, oderby, out  RecordCount);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Entity.AccountMoneyLog> GetListPagesCache(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby, out int RecordCount)
        {
            string rawKey = string.Concat("GlPages-", PageIndex, PageSize, strWhere, Fileds, oderby);
            string rawKeyCount = string.Concat("C-", rawKey);
            List<Entity.AccountMoneyLog> lstData = base.GetCacheItem<List<Entity.AccountMoneyLog>>(rawKey);
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
        public List<Entity.AccountMoneyLog> GetListPages(int PageIndex, int PageSize, out int RecordCount)
        {
            return GetListPagesCache(PageIndex, PageSize, "", "", "", out  RecordCount);
        }
        /// <summary>
        /// 获得数据列表-分页
        /// </summary>
        public List<Entity.AccountMoneyLog> GetListPages(int PageIndex, int PageSize, string strWhere, string oderby, out int RecordCount)
        {
            return GetListPagesCache(PageIndex, PageSize, strWhere, "", oderby, out  RecordCount);
        }
        /// <summary>
        /// 获得数据列表-分页
        /// </summary>
        public List<Entity.AccountMoneyLog> GetListPages(int PageIndex, int PageSize, string strWhere, string oderby)
        {
            int iCount = 0;
            return GetListPagesCache(PageIndex, PageSize, strWhere, "", oderby, out iCount);
        }
        /// <summary>
        /// 搜索-分页
        /// </summary>
        public List<Entity.AccountMoneyLog> SearchLike(int PageIndex, int PageSize, string oderby, out int RecordCount, string sKeyWord, string ColumnName)
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
                Entity.AccountMoneyLog mdEt = GetEntity(ThisId);
                foreach (System.Web.UI.Control uc in ph.Controls)
                {
                    if (Equals(uc.ID, null)) continue;
                    string sValue = "";
                    if (Equals(uc.ID.ToLower(), "id".ToLower()))
                    {
                        sValue = mdEt.id.ToString();
                    }
                    else if (Equals(uc.ID.ToLower(), "UserId".ToLower()))
                    {
                        sValue = mdEt.UserId.ToString();
                    }
                    else if (Equals(uc.ID.ToLower(), "UserName".ToLower()))
                    {
                        sValue = mdEt.UserName.ToString();
                    }
                    else if (Equals(uc.ID.ToLower(), "TradeDate".ToLower()))
                    {
                        sValue = mdEt.TradeDate.ToString();
                    }
                    else if (Equals(uc.ID.ToLower(), "TradeType".ToLower()))
                    {
                        sValue = mdEt.TradeType.ToString();
                    }
                    else if (Equals(uc.ID.ToLower(), "Income".ToLower()))
                    {
                        sValue = mdEt.Income.ToString();
                    }
                    else if (Equals(uc.ID.ToLower(), "Expenses".ToLower()))
                    {
                        sValue = mdEt.Expenses.ToString();
                    }
                    else if (Equals(uc.ID.ToLower(), "Balance".ToLower()))
                    {
                        sValue = mdEt.Balance.ToString();
                    }
                    else if (Equals(uc.ID.ToLower(), "Remark".ToLower()))
                    {
                        sValue = mdEt.Remark.ToString();
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
            Entity.AccountMoneyLog mdEntity = GetEntityFromCtr(ph);
            if (!Equals(lstOtherColumn, null) && lstOtherColumn.Count > 0)
            {
                foreach (EbSite.Base.BLL.OtherColumn column in lstOtherColumn)
                {
                    if (Equals(column.ColumnName.ToLower(), "id".ToLower()))
                    {
                        mdEntity.id = int.Parse(column.ColumnValue);
                    }
                    else if (Equals(column.ColumnName.ToLower(), "UserId".ToLower()))
                    {
                        mdEntity.UserId = int.Parse(column.ColumnValue);
                    }
                    else if (Equals(column.ColumnName.ToLower(), "UserName".ToLower()))
                    {
                        mdEntity.UserName = column.ColumnValue;
                    }
                    else if (Equals(column.ColumnName.ToLower(), "TradeDate".ToLower()))
                    {
                        mdEntity.TradeDate = DateTime.Parse(column.ColumnValue);
                    }
                    else if (Equals(column.ColumnName.ToLower(), "TradeType".ToLower()))
                    {
                        mdEntity.TradeType = int.Parse(column.ColumnValue);
                    }
                    else if (Equals(column.ColumnName.ToLower(), "Income".ToLower()))
                    {
                        mdEntity.Income = decimal.Parse(column.ColumnValue);
                    }
                    else if (Equals(column.ColumnName.ToLower(), "Expenses".ToLower()))
                    {
                        mdEntity.Expenses = decimal.Parse(column.ColumnValue);
                    }
                    else if (Equals(column.ColumnName.ToLower(), "Balance".ToLower()))
                    {
                        mdEntity.Balance = decimal.Parse(column.ColumnValue);
                    }
                    else if (Equals(column.ColumnName.ToLower(), "Remark".ToLower()))
                    {
                        mdEntity.Remark = column.ColumnValue;
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
        public Entity.AccountMoneyLog GetEntityFromCtr(PlaceHolder ph)
        {
            Entity.AccountMoneyLog mdEt = new Entity.AccountMoneyLog();
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
                else if (Equals(uc.ID.ToLower(), "UserId".ToLower()))
                {
                    mdEt.UserId = int.Parse(sValue);
                }
                else if (Equals(uc.ID.ToLower(), "UserName".ToLower()))
                {
                    mdEt.UserName = sValue;
                }
                else if (Equals(uc.ID.ToLower(), "TradeDate".ToLower()))
                {
                    mdEt.TradeDate = DateTime.Parse(sValue);
                }
                else if (Equals(uc.ID.ToLower(), "TradeType".ToLower()))
                {
                    mdEt.TradeType = int.Parse(sValue);
                }
                else if (Equals(uc.ID.ToLower(), "Income".ToLower()))
                {
                    mdEt.Income = decimal.Parse(sValue);
                }
                else if (Equals(uc.ID.ToLower(), "Expenses".ToLower()))
                {
                    mdEt.Expenses = decimal.Parse(sValue);
                }
                else if (Equals(uc.ID.ToLower(), "Balance".ToLower()))
                {
                    mdEt.Balance = decimal.Parse(sValue);
                }
                else if (Equals(uc.ID.ToLower(), "Remark".ToLower()))
                {
                    mdEt.Remark = sValue;
                }
            }
            return mdEt;
        }

        #endregion  成员方法

        #region  自定义方法
        public string StrWhere(string dateBegin, string dateEnd, string typeid, int uid)
        {
            string sqlwhere = "";
            if (!string.IsNullOrEmpty(dateBegin) && !string.IsNullOrEmpty(dateEnd))
            {
                sqlwhere += "  TradeDate between '" + dateBegin + " 0:00:00' and '" + dateEnd + " 23:59:59' and";
            }
            if (!string.IsNullOrEmpty(typeid))
            {
                sqlwhere += "  TradeType=" + typeid + " and";
            }
            if (uid > 0)
            {
                sqlwhere += " userid=" + uid + " and";
            }
            if (sqlwhere.Length > 0)
                sqlwhere = sqlwhere.Remove(sqlwhere.Length - 3, 3);
            return sqlwhere;
        }

         public int Add(Entity.AccountMoneyLog model, DbTransaction Trans)
         {
             return DbProviderUser.GetInstance().AccountMoneyLog_Add(model, Trans);
         }

         public bool Add(Entity.AccountMoneyLog accountMoneyMd, Entity.PayPass payModel)
         {
             return DbProviderUser.GetInstance().AccountMoney_Add(accountMoneyMd, payModel);
         }
        #endregion  自定义方法
    }
}

