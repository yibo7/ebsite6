using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using EbSite.Core.FSO;

namespace EbSite.BLL
{
    public class PsDelivery : EbSite.Base.Datastore.XMLProviderBaseInt<Entity.PsDelivery>
    {
        public static readonly PsDelivery Instance = new PsDelivery();
        /// <summary>
        /// 重写菜单的保存路径-绝对
        /// </summary>
        public override string SavePath
        {
            get
            {
                return HttpContext.Current.Server.MapPath(string.Concat(IISPath, "datastore/peisong/delivery/"));
            }
        }

        private PsDelivery()
        {

            if (!FObject.IsExist(SavePath, FsoMethod.Folder))
            {
                FObject.Create(SavePath, FsoMethod.Folder);
            }
        }
        /// <summary>
        /// 计算运费
        /// </summary>
        /// <param name="deliveryid">配送方式ID</param>
        /// <param name="TotalWeight">商品总重量</param>
        /// <param name="Areaid">配送区域ID</param>
        /// <param name="TotalMemberPrice">会员价格合计</param>
        /// <param name="CODTotalFree">获取货到付款费用</param>
        /// <returns></returns>
        public decimal GetFreeByWeight(int deliveryid, decimal TotalWeight, int Areaid, decimal TotalMemberPrice, out decimal CODTotalFree)
        {
            CODTotalFree = 0;
            EbSite.Entity.PsDelivery md = EbSite.BLL.PsDelivery.Instance.GetEntity(deliveryid);
            if (!Equals(md, null))
            {
                int iShippingTemplatesId = md.ShippingTemplatesId;//运费模板ID
                decimal dRree = 0;
                //decimal dCODTotal = 0;
                //获取当前运费模板-默认设置
                EbSite.Entity.PsFreight pfModel = EbSite.BLL.PsFreight.Instance.GetEntity(iShippingTemplatesId);
                //获取某个运费模板下的区域配置ID
                List<EbSite.Entity.PsAreaPrice> lst = EbSite.BLL.PsAreaPrice.Instance.GetListByTempID(iShippingTemplatesId);
                bool isExit = true;
                if (lst.Count > 0) //有子区域计算
                {
                    EbSite.Entity.Address model = EbSite.BLL.Address.Instance.GetEntity(Areaid);
                    string addressA = model.CountryName + "," + model.AreaID;

                    foreach (EbSite.Entity.PsAreaPrice li in lst)
                    {
                        if (IsExit(addressA, li.RegionIDS))
                        {
                            isExit = false;
                            //计算公式
                            if (TotalMemberPrice >= li.FullMoney && li.FullMoney > 0)
                            {
                                dRree = 0;//免运费
                            }
                            else
                            {
                                decimal OverstepWeight = TotalWeight - pfModel.StartWeight;
                                dRree = li.RegionPrice;
                                if (OverstepWeight > 0) //计算超出重量运费
                                {
                                    dRree = dRree + ((OverstepWeight / pfModel.AddWeight) * li.AddRegionPrice);
                                }
                            }
                            break;
                        }

                    }
                }
                else
                {
                    isExit = false;
                    decimal OverstepWeight = TotalWeight - pfModel.StartWeight;
                    dRree = pfModel.StartPrice;
                    if (OverstepWeight > 0) //计算超出重量运费
                    {
                        dRree = dRree + ((OverstepWeight / pfModel.AddWeight) * pfModel.AddPrice);
                    }
                }

                if (isExit)
                {
                    decimal OverstepWeight = TotalWeight - pfModel.StartWeight;
                    dRree = pfModel.StartPrice;
                    if (OverstepWeight > 0) //计算超出重量运费
                    {
                        dRree = dRree + ((OverstepWeight / pfModel.AddWeight) * pfModel.AddPrice);
                    }
                }

                //计算货到付款费用
                if (md.IsCod)
                {
                    if (md.IsPercent)
                    {
                        CODTotalFree = (dRree * (md.UseMoney / 100));
                        //dRree += (dRree * (md.UseMoney / 100));
                    }
                    else
                    {
                        CODTotalFree = md.UseMoney;
                        //  dRree += md.UseMoney;
                    }
                }

                return dRree;
            }
            else
            {
                return 0;
            }
        }
        /// <summary>
        /// 验证是否 存在 地区id
        /// </summary>
        /// <param name="adderssIDs">源</param>
        /// <param name="fixIDs">固定</param>
        /// <returns></returns>
        private bool IsExit(string adderssIDs, string fixIDs)
        {
            string[] arry = adderssIDs.Split(',');
            string[] arry2 = fixIDs.Split(',');
            bool key = false;
            for (int i = 0; i < arry.Length; i++)
            {
                string t = arry[i];
                int icount = (from k in arry2 where k == t select k).Count();
                if (icount > 0)
                {
                    key = true;
                    break;
                }
            }
            return key;
        }
    }
}
