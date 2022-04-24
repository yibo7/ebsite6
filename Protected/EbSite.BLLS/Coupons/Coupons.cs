using System;
using System.Data;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using EbSite.Base.EntityAPI;
using EbSite.Data.User.Interface;


namespace EbSite.BLL
{
    /// <summary>
    /// 业务逻辑类Coupons 的摘要说明。
    /// </summary>
    public class Coupons : Base.BLL.BllBase<Entity.Coupons, int>
    {
        public static readonly Coupons Instance = new Coupons();
        private Coupons()
        {
        }


        #region  成员方法

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbProviderUser.GetInstance().Coupons_GetMaxId();
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            return DbProviderUser.GetInstance().Coupons_Exists(id);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        override public int Add(Entity.Coupons model)
        {
            base.InvalidateCache();
            return DbProviderUser.GetInstance().Coupons_Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        override public void Update(Entity.Coupons model)
        {
            base.InvalidateCache();
            DbProviderUser.GetInstance().Coupons_Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        override public void Delete(int id)
        {
            base.InvalidateCache();

            DbProviderUser.GetInstance().Coupons_Delete(id);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        override public Entity.Coupons GetEntity(int id)
        {

            string rawKey = string.Concat("GetEntity-", id);
            Entity.Coupons etEntity = base.GetCacheItem<Entity.Coupons>(rawKey);
            if (Equals(etEntity, null))
            {
                etEntity = DbProviderUser.GetInstance().Coupons_GetEntity(id);
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
            return DbProviderUser.GetInstance().Coupons_GetCount(strWhere);
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
            return DbProviderUser.GetInstance().Coupons_GetList(Top, strWhere, filedOrder);
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
        override public List<Entity.Coupons> GetListArray(int Top, string strWhere, string filedOrder)
        {
            return DbProviderUser.GetInstance().Coupons_GetListArray(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Entity.Coupons> GetListArrayCache(int Top, string strWhere, string filedOrder)
        {
            string rawKey = string.Concat("GetListArray-", strWhere, Top, filedOrder);
            List<Entity.Coupons> lstData = base.GetCacheItem<List<Entity.Coupons>>(rawKey);
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
        public List<Entity.Coupons> GetListArray(int Top, string filedOrder)
        {
            return GetListArrayCache(Top, "", filedOrder);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Entity.Coupons> GetListArray(string strWhere)
        {
            return GetListArrayCache(0, strWhere, "");
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        override public List<Entity.Coupons> GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby, out int RecordCount)
        {
            return DbProviderUser.GetInstance().Coupons_GetListPages(PageIndex, PageSize, strWhere, Fileds, oderby, out  RecordCount);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Entity.Coupons> GetListPagesCache(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby, out int RecordCount)
        {
            string rawKey = string.Concat("GlPages-", PageIndex, PageSize, strWhere, Fileds, oderby);
            string rawKeyCount = string.Concat("C-", rawKey);
            List<Entity.Coupons> lstData = base.GetCacheItem<List<Entity.Coupons>>(rawKey);
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
        public List<Entity.Coupons> GetListPages(int PageIndex, int PageSize, out int RecordCount)
        {
            return GetListPagesCache(PageIndex, PageSize, "", "", "", out  RecordCount);
        }
        /// <summary>
        /// 获得数据列表-分页
        /// </summary>
        public List<Entity.Coupons> GetListPages(int PageIndex, int PageSize, string strWhere, string oderby, out int RecordCount)
        {
            return GetListPagesCache(PageIndex, PageSize, strWhere, "", oderby, out  RecordCount);
        }
        /// <summary>
        /// 获得数据列表-分页
        /// </summary>
        public List<Entity.Coupons> GetListPages(int PageIndex, int PageSize, string strWhere, string oderby)
        {
            int iCount = 0;
            return GetListPagesCache(PageIndex, PageSize, strWhere, "", oderby, out iCount);
        }
        /// <summary>
        /// 搜索-分页
        /// </summary>
        public List<Entity.Coupons> SearchLike(int PageIndex, int PageSize, string oderby, out int RecordCount, string sKeyWord, string ColumnName)
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
                Entity.Coupons mdEt = GetEntity(ThisId);
                foreach (System.Web.UI.Control uc in ph.Controls)
                {
                    if (Equals(uc.ID, null)) continue;
                    string sValue = "";
                    if (Equals(uc.ID.ToLower(), "id".ToLower()))
                    {
                        sValue = mdEt.id.ToString();
                    }
                    else if (Equals(uc.ID.ToLower(), "CouponName".ToLower()))
                    {
                        sValue = mdEt.CouponName.ToString();
                    }
                    else if (Equals(uc.ID.ToLower(), "EndDateTime".ToLower()))
                    {
                        sValue = mdEt.EndDateTime.ToString();
                    }
                    else if (Equals(uc.ID.ToLower(), "Amount".ToLower()))
                    {
                        sValue = mdEt.Amount.ToString();
                    }
                    else if (Equals(uc.ID.ToLower(), "DiscountPrice".ToLower()))
                    {
                        sValue = mdEt.DiscountPrice.ToString();
                    }
                    else if (Equals(uc.ID.ToLower(), "Description".ToLower()))
                    {
                        sValue = mdEt.Description.ToString();
                    }
                    else if (Equals(uc.ID.ToLower(), "SentCount".ToLower()))
                    {
                        sValue = mdEt.SentCount.ToString();
                    }
                    else if (Equals(uc.ID.ToLower(), "UsedCount".ToLower()))
                    {
                        sValue = mdEt.UsedCount.ToString();
                    }
                    else if (Equals(uc.ID.ToLower(), "NeedPoint".ToLower()))
                    {
                        sValue = mdEt.NeedPoint.ToString();
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
            Entity.Coupons mdEntity = GetEntityFromCtr(ph);
            if (!Equals(lstOtherColumn, null) && lstOtherColumn.Count > 0)
            {
                foreach (EbSite.Base.BLL.OtherColumn column in lstOtherColumn)
                {
                    if (Equals(column.ColumnName.ToLower(), "id".ToLower()))
                    {
                        mdEntity.id = int.Parse(column.ColumnValue);
                    }
                    else if (Equals(column.ColumnName.ToLower(), "CouponName".ToLower()))
                    {
                        mdEntity.CouponName = column.ColumnValue;
                    }
                    else if (Equals(column.ColumnName.ToLower(), "EndDateTime".ToLower()))
                    {
                        mdEntity.EndDateTime = DateTime.Parse(column.ColumnValue);
                    }
                    else if (Equals(column.ColumnName.ToLower(), "Amount".ToLower()))
                    {
                        mdEntity.Amount = decimal.Parse(column.ColumnValue);
                    }
                    else if (Equals(column.ColumnName.ToLower(), "DiscountPrice".ToLower()))
                    {
                        mdEntity.DiscountPrice = decimal.Parse(column.ColumnValue);
                    }
                    else if (Equals(column.ColumnName.ToLower(), "Description".ToLower()))
                    {
                        mdEntity.Description = column.ColumnValue;
                    }
                    else if (Equals(column.ColumnName.ToLower(), "SentCount".ToLower()))
                    {
                        mdEntity.SentCount = int.Parse(column.ColumnValue);
                    }
                    else if (Equals(column.ColumnName.ToLower(), "UsedCount".ToLower()))
                    {
                        mdEntity.UsedCount = int.Parse(column.ColumnValue);
                    }
                    else if (Equals(column.ColumnName.ToLower(), "NeedPoint".ToLower()))
                    {
                        mdEntity.NeedPoint = int.Parse(column.ColumnValue);
                    }
                }
            }
            if (mdEntity.id > 0)
            {
                Update(mdEntity);
            }
            else
            {
              int id=  Add(mdEntity);

                if(mdEntity.SentCount>0)
                {
                    Guid gid = Guid.NewGuid();
                    for (int i = 0; i < mdEntity.SentCount; i++)
                    {
                      
                       Entity.CouponItems md = new Entity.CouponItems();
                        md.CouponId = id;
                        md.LotNumber = gid.ToString();
                        md.ClaimCode = Core.Strings.GetString.RandomNUMSTR(15);
                        md.AddDateTime = mdEntity.EndDateTime;
                        BLL.CouponItems.Instance.Add(md);

                    }
                }

                //   优惠券批次号	优惠券号码	优惠券金额	过期时间
                //A58EA08F-9A16-4173-BC8E-3274B344E36E	2E26A26B77A54E4	22	2012-12-31 0:00


                // [CouponId](int)  Coupons对应的ID
                //[LotNumber] (guid) 优惠券批次号
                //[ClaimCode](string 32) 优惠券号码
                //[UserId]  (int)  可以使用的用户ID
                //[EmailAddress](string 150) 可以使用的用户Email
                //[AddDateTime] (datetime) 生成时间


            }
        }
        /// <summary>
        /// 从PlaceHolder中获取一个实例
        /// </summary>
        public Entity.Coupons GetEntityFromCtr(PlaceHolder ph)
        {
            Entity.Coupons mdEt = new Entity.Coupons();
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
                else if (Equals(uc.ID.ToLower(), "CouponName".ToLower()))
                {
                    mdEt.CouponName = sValue;
                }
                else if (Equals(uc.ID.ToLower(), "EndDateTime".ToLower()))
                {
                    mdEt.EndDateTime = DateTime.Parse(sValue);
                }
                else if (Equals(uc.ID.ToLower(), "Amount".ToLower()))
                {
                    mdEt.Amount = decimal.Parse(sValue);
                }
                else if (Equals(uc.ID.ToLower(), "DiscountPrice".ToLower()))
                {
                    mdEt.DiscountPrice = decimal.Parse(sValue);
                }
                else if (Equals(uc.ID.ToLower(), "Description".ToLower()))
                {
                    mdEt.Description = sValue;
                }
                else if (Equals(uc.ID.ToLower(), "SentCount".ToLower()))
                {
                    mdEt.SentCount = int.Parse(sValue);
                }
                else if (Equals(uc.ID.ToLower(), "UsedCount".ToLower()))
                {
                    mdEt.UsedCount = int.Parse(sValue);
                }
                else if (Equals(uc.ID.ToLower(), "NeedPoint".ToLower()))
                {
                    mdEt.NeedPoint = int.Parse(sValue);
                }
            }
            return mdEt;
        }

        #endregion  成员方法

        #region  自定义方法

        /// <summary>
        /// 获取我的优惠券
        /// </summary>
        /// <param name="uid">用户ID</param>
        /// <param name="endDate">当前日期</param>
        /// <returns></returns>
        public List<Entity.Coupons> GetListArray(int uid)
        {
            return DbProviderUser.GetInstance().Coupons_GetListArray(uid);
        }

        #endregion  自定义方法

        static public List<ListItemModel> GetCouponsTypes()
        {
            List<ListItemModel> lst = new List<ListItemModel>();
            ListItemModel md = new ListItemModel("1", "新创建的优惠券", "1");
            lst.Add(md);
            md = new ListItemModel("2", "使用中的优惠券", "2");
            lst.Add(md);
            md = new ListItemModel("3", "过期的优惠券", "3");
            lst.Add(md);
          
            return lst;
        }
    }
}

