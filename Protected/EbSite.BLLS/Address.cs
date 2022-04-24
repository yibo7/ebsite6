using System;
using System.Data;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using EbSite.Base.Static;
using EbSite.Data.User.Interface;

namespace EbSite.BLL
{
	/// <summary>
	/// 业务逻辑类Address 的摘要说明。
	/// </summary>
    public class Address : Base.BLL.BllBase<Entity.Address, int> 
	{
		public static readonly Address Instance = new Address();
		private  Address()
		{
		}
        #region  成员方法

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbProviderUser.GetInstance().Address_GetMaxId();
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            return DbProviderUser.GetInstance().Address_Exists(id);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        override public int Add(Entity.Address model)
        {
            base.InvalidateCache();
            return DbProviderUser.GetInstance().Address_Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        override public void Update(Entity.Address model)
        {
            base.InvalidateCache();
            DbProviderUser.GetInstance().Address_Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        override public void Delete(int id)
        {
            base.InvalidateCache();

            DbProviderUser.GetInstance().Address_Delete(id);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        override public Entity.Address GetEntity(int id)
        {

            string rawKey = string.Concat("GetEntity-", id);
            Entity.Address etEntity = base.GetCacheItem<Entity.Address>(rawKey);
            if (Equals(etEntity, null))
            {
                etEntity = DbProviderUser.GetInstance().Address_GetEntity(id);
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
            return DbProviderUser.GetInstance().Address_GetCount(strWhere);
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
            return DbProviderUser.GetInstance().Address_GetList(Top, strWhere, filedOrder);
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
        override public List<Entity.Address> GetListArray(int Top, string strWhere, string filedOrder)
        {
            return DbProviderUser.GetInstance().Address_GetListArray(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Entity.Address> GetListArrayCache(int Top, string strWhere, string filedOrder)
        {
            string rawKey = string.Concat("GetListArray-", strWhere, Top, filedOrder);
            List<Entity.Address> lstData = base.GetCacheItem<List<Entity.Address>>(rawKey);
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
        public List<Entity.Address> GetListArray(int Top, string filedOrder)
        {
            return GetListArrayCache(Top, "", filedOrder);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Entity.Address> GetListArray(string strWhere)
        {
            return GetListArrayCache(0, strWhere, "");
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        override public List<Entity.Address> GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby, out int RecordCount)
        {
            return DbProviderUser.GetInstance().Address_GetListPages(PageIndex, PageSize, strWhere, Fileds, oderby, out  RecordCount);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Entity.Address> GetListPagesCache(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby, out int RecordCount)
        {
            string rawKey = string.Concat("GlPages-", PageIndex, PageSize, strWhere, Fileds, oderby);
            string rawKeyCount = string.Concat("C-", rawKey);
            List<Entity.Address> lstData = base.GetCacheItem<List<Entity.Address>>(rawKey);
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
        public List<Entity.Address> GetListPages(int PageIndex, int PageSize, out int RecordCount)
        {
            return GetListPagesCache(PageIndex, PageSize, "", "", "", out  RecordCount);
        }
        /// <summary>
        /// 获得数据列表-分页
        /// </summary>
        public List<Entity.Address> GetListPages(int PageIndex, int PageSize, string strWhere, string oderby, out int RecordCount)
        {
            return GetListPagesCache(PageIndex, PageSize, strWhere, "", oderby, out  RecordCount);
        }
        /// <summary>
        /// 获得数据列表-分页
        /// </summary>
        public List<Entity.Address> GetListPages(int PageIndex, int PageSize, string strWhere, string oderby)
        {
            int iCount = 0;
            return GetListPagesCache(PageIndex, PageSize, strWhere, "", oderby, out iCount);
        }
        /// <summary>
        /// 搜索-分页
        /// </summary>
        public List<Entity.Address> SearchLike(int PageIndex, int PageSize, string oderby, out int RecordCount, string sKeyWord, string ColumnName)
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
                Entity.Address mdEt = GetEntity(ThisId);
                foreach (System.Web.UI.Control uc in ph.Controls)
                {
                    if (Equals(uc.ID, null)) continue;
                    string sValue = "";
                    if (Equals(uc.ID.ToLower(), "id".ToLower()))
                    {
                        sValue = mdEt.id.ToString();
                    }
                    else if (Equals(uc.ID.ToLower(), "UserID".ToLower()))
                    {
                        sValue = mdEt.UserID.ToString();
                    }
                    else if (Equals(uc.ID.ToLower(), "UserRealName".ToLower()))
                    {
                        sValue = mdEt.UserRealName.ToString();
                    }
                    else if (Equals(uc.ID.ToLower(), "Phone".ToLower()))
                    {
                        sValue = mdEt.Phone.ToString();
                    }
                    else if (Equals(uc.ID.ToLower(), "Email".ToLower()))
                    {
                        sValue = mdEt.Email.ToString();
                    }
                    else if (Equals(uc.ID.ToLower(), "Mobile".ToLower()))
                    {
                        sValue = mdEt.Mobile.ToString();
                    }
                    else if (Equals(uc.ID.ToLower(), "PostCode".ToLower()))
                    {
                        sValue = mdEt.PostCode.ToString();
                    }
                    else if (Equals(uc.ID.ToLower(), "AreaID".ToLower()))
                    {
                        sValue = mdEt.AreaID.ToString();
                    }
                    else if (Equals(uc.ID.ToLower(), "AreaName".ToLower()))
                    {
                        sValue = mdEt.AreaName.ToString();
                    }
                    else if (Equals(uc.ID.ToLower(), "CountryID".ToLower()))
                    {
                        sValue = mdEt.CountryID.ToString();
                    }
                    else if (Equals(uc.ID.ToLower(), "CountryName".ToLower()))
                    {
                        sValue = mdEt.CountryName.ToString();
                    }
                    else if (Equals(uc.ID.ToLower(), "ProvinceID".ToLower()))
                    {
                        sValue = mdEt.ProvinceID.ToString();
                    }
                    else if (Equals(uc.ID.ToLower(), "ProvinceName".ToLower()))
                    {
                        sValue = mdEt.ProvinceName.ToString();
                    }
                    else if (Equals(uc.ID.ToLower(), "CityID".ToLower()))
                    {
                        sValue = mdEt.CityID.ToString();
                    }
                    else if (Equals(uc.ID.ToLower(), "CityName".ToLower()))
                    {
                        sValue = mdEt.CityName.ToString();
                    }
                    else if (Equals(uc.ID.ToLower(), "AddressInfo".ToLower()))
                    {
                        sValue = mdEt.AddressInfo.ToString();
                    }
                    else if (Equals(uc.ID.ToLower(), "IsTemAdress".ToLower()))
                    {
                        sValue = mdEt.IsTemAdress.ToString();
                    }
                    else if (Equals(uc.ID.ToLower(), "AddDateime".ToLower()))
                    {
                        sValue = mdEt.AddDateime.ToString();
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
            Entity.Address mdEntity = GetEntityFromCtr(ph);
            if (!Equals(lstOtherColumn, null) && lstOtherColumn.Count > 0)
            {
                foreach (EbSite.Base.BLL.OtherColumn column in lstOtherColumn)
                {
                    if (Equals(column.ColumnName.ToLower(), "id".ToLower()))
                    {
                        mdEntity.id = int.Parse(column.ColumnValue);
                    }
                    else if (Equals(column.ColumnName.ToLower(), "UserID".ToLower()))
                    {
                        mdEntity.UserID = int.Parse(column.ColumnValue);
                    }
                    else if (Equals(column.ColumnName.ToLower(), "UserRealName".ToLower()))
                    {
                        mdEntity.UserRealName = column.ColumnValue;
                    }
                    else if (Equals(column.ColumnName.ToLower(), "Phone".ToLower()))
                    {
                        mdEntity.Phone = column.ColumnValue;
                    }
                    else if (Equals(column.ColumnName.ToLower(), "Email".ToLower()))
                    {
                        mdEntity.Email = column.ColumnValue;
                    }
                    else if (Equals(column.ColumnName.ToLower(), "Mobile".ToLower()))
                    {
                        mdEntity.Mobile = column.ColumnValue;
                    }
                    else if (Equals(column.ColumnName.ToLower(), "PostCode".ToLower()))
                    {
                        mdEntity.PostCode = column.ColumnValue;
                    }
                    else if (Equals(column.ColumnName.ToLower(), "AreaID".ToLower()))
                    {
                        mdEntity.AreaID = int.Parse(column.ColumnValue);
                    }
                    else if (Equals(column.ColumnName.ToLower(), "AreaName".ToLower()))
                    {
                        mdEntity.AreaName = column.ColumnValue;
                    }
                    else if (Equals(column.ColumnName.ToLower(), "CountryID".ToLower()))
                    {
                        mdEntity.CountryID = int.Parse(column.ColumnValue);
                    }
                    else if (Equals(column.ColumnName.ToLower(), "CountryName".ToLower()))
                    {
                        mdEntity.CountryName = column.ColumnValue;
                    }
                    else if (Equals(column.ColumnName.ToLower(), "ProvinceID".ToLower()))
                    {
                        mdEntity.ProvinceID = int.Parse(column.ColumnValue);
                    }
                    else if (Equals(column.ColumnName.ToLower(), "ProvinceName".ToLower()))
                    {
                        mdEntity.ProvinceName = column.ColumnValue;
                    }
                    else if (Equals(column.ColumnName.ToLower(), "CityID".ToLower()))
                    {
                        mdEntity.CityID = int.Parse(column.ColumnValue);
                    }
                    else if (Equals(column.ColumnName.ToLower(), "CityName".ToLower()))
                    {
                        mdEntity.CityName = column.ColumnValue;
                    }
                    else if (Equals(column.ColumnName.ToLower(), "AddressInfo".ToLower()))
                    {
                        mdEntity.AddressInfo = column.ColumnValue;
                    }
                    else if (Equals(column.ColumnName.ToLower(), "IsTemAdress".ToLower()))
                    {
                        mdEntity.IsTemAdress = int.Parse(column.ColumnValue);
                    }
                    else if (Equals(column.ColumnName.ToLower(), "AddDateime".ToLower()))
                    {
                        mdEntity.AddDateime = DateTime.Parse(column.ColumnValue);
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
        public Entity.Address GetEntityFromCtr(PlaceHolder ph)
        {
            Entity.Address mdEt = new Entity.Address();
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
                else if (Equals(uc.ID.ToLower(), "UserID".ToLower()))
                {
                    mdEt.UserID = int.Parse(sValue);
                }
                else if (Equals(uc.ID.ToLower(), "UserRealName".ToLower()))
                {
                    mdEt.UserRealName = sValue;
                }
                else if (Equals(uc.ID.ToLower(), "Phone".ToLower()))
                {
                    mdEt.Phone = sValue;
                }
                else if (Equals(uc.ID.ToLower(), "Mobile".ToLower()))
                {
                    mdEt.Mobile = sValue;
                }
                else if (Equals(uc.ID.ToLower(), "Email".ToLower()))
                {
                    mdEt.Email = sValue;
                }
                else if (Equals(uc.ID.ToLower(), "PostCode".ToLower()))
                {
                    mdEt.PostCode = sValue;
                }
                else if (Equals(uc.ID.ToLower(), "AreaID".ToLower()))
                {
                    mdEt.AreaID = int.Parse(sValue);
                }
                else if (Equals(uc.ID.ToLower(), "AreaName".ToLower()))
                {
                    mdEt.AreaName = sValue;
                }
                else if (Equals(uc.ID.ToLower(), "CountryID".ToLower()))
                {
                    mdEt.CountryID = int.Parse(sValue);
                }
                else if (Equals(uc.ID.ToLower(), "CountryName".ToLower()))
                {
                    mdEt.CountryName = sValue;
                }
                else if (Equals(uc.ID.ToLower(), "ProvinceID".ToLower()))
                {
                    mdEt.ProvinceID = int.Parse(sValue);
                }
                else if (Equals(uc.ID.ToLower(), "ProvinceName".ToLower()))
                {
                    mdEt.ProvinceName = sValue;
                }
                else if (Equals(uc.ID.ToLower(), "CityID".ToLower()))
                {
                    mdEt.CityID = int.Parse(sValue);
                }
                else if (Equals(uc.ID.ToLower(), "CityName".ToLower()))
                {
                    mdEt.CityName = sValue;
                }
                else if (Equals(uc.ID.ToLower(), "AddressInfo".ToLower()))
                {
                    mdEt.AddressInfo = sValue;
                }
                else if (Equals(uc.ID.ToLower(), "IsTemAdress".ToLower()))
                {
                    mdEt.IsTemAdress = int.Parse(sValue);
                }
                else if (Equals(uc.ID.ToLower(), "AddDateime".ToLower()))
                {
                    mdEt.AddDateime = DateTime.Parse(sValue);
                }
            }
            return mdEt;
        }

        #endregion  成员方法

        #region  自定义方法
        public List<Entity.Address> GetListByUserID(int UID)
        {
            if (UID>0)
            {
                return DbProviderUser.GetInstance().Address_GetListArray(0, string.Concat("userid=", UID), "");
            }
            else
            {
                return DbProviderUser.GetInstance().Address_GetListArray(0, string.Concat("IsTemAdress=", EbSite.Base.Host.Instance.OnlineID), "");
            }
            
        }

       /// <summary>
       /// 获取运费
       /// </summary>
        /// <param name="ShippingTemplatesId">运费模板ID</param>
       /// <param name="TotalWeight">重量(克)</param>
       /// <param name="AreaID">地区ID，可以是任何一个级别</param>
        /// <param name="AreaParentIDs">相对于 AreaID对应的父级ID,多个用逗号分开</param>
       /// <returns></returns>
        protected decimal GetFreeByWeight(int ShippingTemplatesId, int TotalWeight, int AreaID, string AreaParentIDs)
        {
            //int iShippingTemplatesId = int.Parse(ShippingTemplatesId.ToString());
            decimal dRree = 0;
            //获取当前运费模板-默认设置
            EbSite.Entity.PsFreight pfModel = EbSite.BLL.PsFreight.Instance.GetEntity(ShippingTemplatesId);
            //获取某个运费模板下的区域配置ID
            List<EbSite.Entity.PsAreaPrice> lst = EbSite.BLL.PsAreaPrice.Instance.GetListByTempID(ShippingTemplatesId);
            if (lst.Count > 0) //有子区域计算
            {

            }
            else  
            {
                decimal OverstepWeight = TotalWeight - pfModel.StartWeight;
                dRree = pfModel.StartPrice;
                if (OverstepWeight > 0) //计算超出重量运费
                {
                    dRree = dRree + ((OverstepWeight / pfModel.AddWeight) * pfModel.AddPrice);
                }
            }
            //TotalWeight)
            return dRree;
        }
        public int Add(string UserRealName, string Phone, string Mobile, string PostCode, int AreaID, string AreaName, string AddressInfo, string Email,int modyfiyid)
        {
            EbSite.Entity.Address md = new Entity.Address();
            md.UserRealName = UserRealName;
            md.Phone = Phone;
            md.Mobile = Mobile;
            md.PostCode = PostCode;
            md.AreaID = AreaID;
            md.AreaName = AreaName;
            md.AddressInfo = AddressInfo;
            md.AddDateime = DateTime.Now;
            md.Email = Email;
            int cityid=0; 
            string cityname=""; 
            int  provinceid=0;
            string provincename = "";
            md.CountryName = EbSite.BLL.AreaInfo.Instance.GetListParentIDs(AreaID,out  cityid, out cityname, out   provinceid,out  provincename);
            md.CityID = cityid;
            md.CityName = cityname;
            md.ProvinceID = provinceid;
            md.ProvinceName = provincename;
            int dataid;
            if(EbSite.Base.Host.Instance.UserID>0)
            {
                md.UserID = EbSite.Base.Host.Instance.UserID;
            }
            else
            {
                md.IsTemAdress = EbSite.Base.Host.Instance.OnlineID;
            }
            if (modyfiyid==0)
            {
                dataid = Add(md);
            }
            else
            {
                md.id = modyfiyid;
                 Update(md);
                 dataid = modyfiyid;
            }

            return dataid;
           
        }
        #endregion  自定义方法
	}
}

