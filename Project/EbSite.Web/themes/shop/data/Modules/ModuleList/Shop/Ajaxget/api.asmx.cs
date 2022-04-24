using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using EbSite.BLL.User;
using EbSite.Base;
using EbSite.Base.EntityAPI;
using EbSite.Base.EntityCustom;
using EbSite.Base.Json;
using EbSite.Entity;
using EbSite.Modules.Shop.Ajaxget.AjaxHelp;
using EbSite.Modules.Shop.ModuleCore;
using EbSite.Modules.Shop.ModuleCore.Cart;
using EbSite.Modules.Shop.ModuleCore.Entity;
using System.Text;

namespace EbSite.Modules.Shop.Ajaxget
{
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ScriptService]
    public class api : WebServiceBase
    {
        #region System
        [WebMethod]
        public string HelloString(string username)
        {
            return "调用了HelloString这是传来参数值" + username;
        }

        [WebMethod]
        public NormPriceInfo GetPriceByNormID(string id)
        {
            if (IsAllow(false))
            {
                NormPriceInfo md = new NormPriceInfo();

                NormRelationProduct mdNormRelationProduct = ModuleCore.BLL.NormRelationProduct.Instance.GetEntityByNormID(id);
                if (!Equals(mdNormRelationProduct, null))
                {
                    md.CostPrice = mdNormRelationProduct.CostPrice;
                    md.MarketPrice = mdNormRelationProduct.MarketPrice;
                    md.PNumber = mdNormRelationProduct.PNumber;
                    md.SalePrice = mdNormRelationProduct.SalePrice;
                    md.Stocks = mdNormRelationProduct.Stocks;
                    md.Weight = mdNormRelationProduct.Weight;

                }

                return md;
            }
            else
            {
                return null;
            }

        }

        [WebMethod]
        public List<TreeItem> GetSubBrand(int pid, int sid)
        {
            if (IsAllow(false))
            {
                List<TreeItem> lstOK = new List<TreeItem>();
                int ParentID = pid;
                if (ParentID == 0)
                {
                    List<EbSite.Entity.SpecialClass> lstP = BLL.SpecialClass.GetListArr("SpecialName='eBSite商城品牌勿删'", sid);
                    if (lstP.Count > 0)
                    {
                        ParentID = lstP[0].id;
                    }
                }
                List<EbSite.Entity.SpecialClass> lst = EbSite.BLL.SpecialClass.GetSub(ParentID, sid);
                foreach (SpecialClass newClass in lst)
                {
                    lstOK.Add(new TreeItem(newClass.id, newClass.SpecialName, 0));
                    //if (newClass.IsCanAddContent)
                    //{
                    //    lstOK.Add(new TreeItem(newClass.ID, newClass.ClassName, 0, newClass.IsCanAddContent ? "1" : "0"));
                    //}
                    //else
                    //{
                    //    List<EbSite.Entity.NewsClass> lstSub = EbSite.BLL.NewsClass.GetSubClass(newClass.ID, 0, sid);
                    //    if(lstSub.Count>0)
                    //    {
                    //        lstOK.Add(new TreeItem(newClass.ID, newClass.ClassName, 0, newClass.IsCanAddContent?"1":"0"));
                    //    }
                    //}

                }
                return lstOK;
            }
            else
            {
                return null;
            }

        }
        [WebMethod]
        public JsonResponse HelloJson(string username)
        {
            return new JsonResponse() { Success = true, Message = "调用了HelloJson这是传来参数值" + username };
        }
        #endregion System

        #region 购物车操作
        [WebMethod]
        public JsonResponse ClearCart()
        {
            if (IsAllow(false))
            {
                ProfileCommon profile = (ProfileCommon)HttpContext.Current.Profile;
                profile.ShopCart.Clear();
                profile.Save();

                return new JsonResponse() { Success = true, Message = "操作成功" };
            }
            else
            {
                return new JsonResponse() { Success = false, Message = base.NoAllowTips };
            }

        }
        [WebMethod]
        public JsonResponse AddCar(int pid, int num, string normid, string opt)
        {
            if (IsAllow(false))
            {
                ProfileCommon profile = (ProfileCommon)HttpContext.Current.Profile;
                profile.ShopCart.Add(pid, num, normid, opt);
                profile.Save();

                return new JsonResponse() { Success = true, Message = "添加成功" };
            }
            else
            {
                return new JsonResponse() { Success = false, Message = base.NoAllowTips };
            }

        }
        [WebMethod]
        public JsonResponse DelCar(string sku)
        {
            if (IsAllow(false))
            {
                ProfileCommon profile = (ProfileCommon)HttpContext.Current.Profile;
                profile.ShopCart.Remove(sku);
                profile.Save();
                return new JsonResponse() { Success = true, Message = "删除成功" };
            }
            else
            {
                return new JsonResponse() { Success = false, Message = base.NoAllowTips };
            }

        }
        [WebMethod]
        public JsonResponse SetQuantity(string sku, int qty)
        {
            if (IsAllow(false))
            {
                ProfileCommon profile = (ProfileCommon)HttpContext.Current.Profile;
                if (qty > 0)
                    profile.ShopCart.SetQuantity(sku, qty);
                else if (qty == 0)
                    profile.ShopCart.Remove(sku);

                profile.Save();
                return new JsonResponse() { Success = true, Message = "更新成功" };
            }
            else
            {
                return new JsonResponse() { Success = false, Message = base.NoAllowTips };
            }

        }

        [WebMethod]
        public JsonResponse SetCreaditQuantity(int id, int qty)
        {
            if (IsAllow(false))
            {
                ProfileCommon profile = (ProfileCommon)HttpContext.Current.Profile;
                if (qty > 0)
                    profile.ShopCart.SetCreditQuantity(id, qty);
                else if (qty == 0)
                    profile.ShopCart.RemoveCredit(id);

                profile.Save();
                return new JsonResponse() { Success = true, Message = "更新成功" };
            }
            else
            {
                return new JsonResponse() { Success = false, Message = base.NoAllowTips };
            }

        }
        [WebMethod]
        public EbSite.Base.EntityAPI.ListItemSimple GetCartCount(int siteid)
        {
            ListItemSimple rz = new ListItemSimple();
            ProfileCommon profile = (ProfileCommon)HttpContext.Current.Profile;
            rz.Value = profile.ShopCart.CountTotal.ToString();
            rz.Text = ModuleCore.GetLinks.Instance.ShoppingCarUrl(siteid);
            return rz;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sku"></param>
        /// <param name="optids">多个ID用_号分开,如18_21_26</param>
        /// <returns></returns>
        [WebMethod]
        public JsonResponse ModifyProductOptions(string sku, string optids)
        {
            if (IsAllow(false))
            {
                ProfileCommon profile = (ProfileCommon)HttpContext.Current.Profile;
                profile.ShopCart.ModifyProductOptions(sku, optids);

                profile.Save();
                return new JsonResponse() { Success = true, Message = "更新成功" };
            }
            else
            {
                return new JsonResponse() { Success = false, Message = base.NoAllowTips };
            }

        }

        #endregion

        #region yhl

        #region  商品类型 主表添加
        /// <summary>
        ///  商品类型 主表添加
        /// </summary>
        /// <param name="name"></param>
        /// <param name="BrandIDs"></param>
        /// <returns></returns>
        [WebMethod(EnableSession = true)]
        public int AddTypeNames(string name, string BrandIDs, int OrderID)
        {
            if (IsAllow(true, true))
            {
                int k = 0;
                ModuleCore.Entity.TypeNames md = new TypeNames();
                md.TypeName = name;
                md.BrandIDs = BrandIDs;
                md.OrderID = OrderID;
                k = ModuleCore.BLL.TypeNames.Instance.Add(md);
                return k;
            }
            else
            {
                return 0;
            }

        }
        #endregion

        #region  商品类型 主表添加
        /// <summary>
        ///  商品扩展属性 添加
        /// </summary>
        /// <param name="name"></param>
        /// <param name="BrandIDs"></param>
        /// <returns></returns>
        [WebMethod(EnableSession = true)]
        public int AddTypeNameValue(int TypeNameID, string ValueName, int OrderID, int IsMoreSel, int IsSele, string DefaultValues)
        {
            if (IsAllow(true, true))
            {
                int k = 0;
                ModuleCore.Entity.TypeNameValue md = new TypeNameValue();
                md.TypeNameID = TypeNameID;
                md.ValueName = ValueName;
                md.OrderID = OrderID;
                md.IsMoreSel = IsMoreSel;
                md.IsSele = IsSele;
                md.DefaultValues = DefaultValues;
                k = ModuleCore.BLL.TypeNameValue.Instance.Add(md);
                return k;
            }
            else
            {
                return 0;
            }

        }
        #endregion

        #region 修改属性名称
        [WebMethod(EnableSession = true)]
        public bool EditTypeNameValue(int id, string name)
        {
            if (IsAllow(true, true))
            {
                ModuleCore.Entity.TypeNameValue md = ModuleCore.BLL.TypeNameValue.Instance.GetEntity(id);
                md.ValueName = name;
                ModuleCore.BLL.TypeNameValue.Instance.Update(md);
                return true;
            }
            else
            {
                return false;
            }

        }

        #endregion

        #region 修改规格名称
        [WebMethod(EnableSession = true)]
        public bool EditSkuValue(int id, string name)
        {
            if (IsAllow(true, true))
            {
                ModuleCore.Entity.Norms md = ModuleCore.BLL.Norms.Instance.GetEntity(id);
                md.NormsName = name;
                ModuleCore.BLL.Norms.Instance.Update(md);
                return true;
            }
            else
            {
                return false;
            }

        }

        #endregion

        #region 修改是否多选
        [WebMethod(EnableSession = true)]
        public void EditMoreSelValue(int id)
        {
            if (IsAllow(true, true))
            {
                ModuleCore.Entity.TypeNameValue md = ModuleCore.BLL.TypeNameValue.Instance.GetEntity(id);
                if (md.IsMoreSel == 0)
                {
                     
                    md.IsMoreSel = 1;
                }
                else
                {
                    md.IsMoreSel = 0;
                }
                ModuleCore.BLL.TypeNameValue.Instance.Update(md);
            }


        }

        #endregion

        #region 修改是否 支持检索
        [WebMethod(EnableSession = true)]
        public void EditSeleValue(int id)
        {
            if (IsAllow(true, true))
            {
                ModuleCore.Entity.TypeNameValue md = ModuleCore.BLL.TypeNameValue.Instance.GetEntity(id);
                if (md.IsSele == 0)
                {
                    md.IsSele = 1;
                }
                else
                {
                    md.IsSele = 0;
                }
                ModuleCore.BLL.TypeNameValue.Instance.Update(md);
            }


        }

        #endregion

        #region 删除属性值
        [WebMethod(EnableSession = true)]
        public bool DelProValue(int id)
        {
            if (IsAllow(true, true))
            {
                ModuleCore.BLL.TypeNameValues.Instance.Delete(id);
                return true;
            }
            else
            {
                return false;
            }

        }
        #endregion

        #region 删除属性
        [WebMethod(EnableSession = true)]
        public void DelTypeNameValue(int id)
        {
            if (IsAllow(true, true))
            {
                ModuleCore.BLL.TypeNameValue.Instance.Delete(id);

                List<ModuleCore.Entity.TypeRelationProduct> ls = ModuleCore.BLL.TypeRelationProduct.Instance.GetListArray(
                    0, "TypeNameValueID=" + id, "");
                if (ls.Count > 0)
                {
                    foreach (var i in ls)
                    {
                        ModuleCore.BLL.TypeRelationProduct.Instance.Delete(i.id);
                    }
                }
            }

        }
        #endregion

        #region 删除规格
        [WebMethod]
        public void DelNorms(int id)
        {
            if (IsAllow(true, true))
            {
                ModuleCore.BLL.Norms.Instance.Delete(id);
            }

        }
        [WebMethod]
        public void DelNormsValue(int id)
        {
            if (IsAllow(true, true))
            {
                ModuleCore.BLL.NormsValue.Instance.Delete(id);
            }

        }
        #endregion

        [WebMethod(EnableSession = true)]
        public void EditNorms(int id, string name)
        {
            if (IsAllow(true, true))
            {
                ModuleCore.Entity.Norms md = ModuleCore.BLL.Norms.Instance.GetEntity(id);
                md.NormsName = name;
                ModuleCore.BLL.Norms.Instance.Update(md);
            }


        }

        #endregion

        #region 主站 后台添加 2012-12-3
        [WebMethod]
        public ResultData AddProduct(string id)
        {
            if (IsAllow(true))
            {
                ResultData Model = new ResultData();
                int dc = 0;
                if (int.TryParse(id, out dc))
                {
                    //属性
                    List<GoodsAttribute> nlis = new List<GoodsAttribute>();
                    List<ModuleCore.Entity.TypeNameValue> ls = ModuleCore.BLL.TypeNameValue.Instance.GetListArray(0,
                                                                                                                  "TypeNameID=" +
                                                                                                                  id, "");
                    foreach (ModuleCore.Entity.TypeNameValue typeNameValue in ls)
                    {
                        GoodsAttribute md = new GoodsAttribute();
                        md.AttributeId = typeNameValue.id;
                        md.Name = typeNameValue.ValueName;
                        md.UsageMode = Core.Utils.StrToInt(typeNameValue.IsMoreSel.ToString(), 0);

                        List<ModuleCore.Entity.TypeNameValues> lsrel =
                            ModuleCore.BLL.TypeNameValues.Instance.GetListArray(0, "TypeNameValueID=" + typeNameValue.id, "");
                        List<GoodsAttributeChild> newlsrel = new List<GoodsAttributeChild>();
                        foreach (ModuleCore.Entity.TypeNameValues typeRelationProduct in lsrel)
                        {
                            GoodsAttributeChild mdrel = new GoodsAttributeChild();
                            mdrel.ValueId = typeRelationProduct.id;
                            mdrel.ValueStr = typeRelationProduct.TValues;
                            newlsrel.Add(mdrel);
                        }
                        md.AttributeValues = newlsrel;
                        nlis.Add(md);
                    }

                    //规格

                    List<GoodsAttribute> sklis = new List<GoodsAttribute>();
                    List<ModuleCore.Entity.Norms> skls = ModuleCore.BLL.Norms.Instance.GetListArray(0, "TypeNameID=" + id, "");
                    foreach (ModuleCore.Entity.Norms typeNameValue in skls)
                    {
                        GoodsAttribute md = new GoodsAttribute();
                        md.AttributeId = typeNameValue.id;
                        md.Name = typeNameValue.NormsName;


                        List<ModuleCore.Entity.NormsValue> lsrel =
                            ModuleCore.BLL.NormsValue.Instance.GetListArray(0, "NormID=" + typeNameValue.id, "");
                        List<GoodsAttributeChild> newlsrel = new List<GoodsAttributeChild>();
                        foreach (ModuleCore.Entity.NormsValue typeRelationProduct in lsrel)
                        {
                            GoodsAttributeChild mdrel = new GoodsAttributeChild();
                            mdrel.ValueId = typeRelationProduct.id;
                            mdrel.ValueStr = typeRelationProduct.NormsValueName;
                            newlsrel.Add(mdrel);
                        }
                        md.AttributeValues = newlsrel;
                        sklis.Add(md);
                    }

                    Model.goodsAttribute = nlis;
                    Model.goodsNorms = sklis;
                    return Model;
                }
                return null;
            }
            else
            {
                return null;
            }


        }
        /// <summary>
        /// 添加属性的value值 
        /// </summary>
        /// <param name="attributeId"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        [WebMethod]
        public int TypeRelationProduct(int TypeNameValueID, string value)
        {
            if (IsAllow(true, true))
            {
                ModuleCore.Entity.TypeNameValues md = new TypeNameValues();
                md.TypeNameValueID = TypeNameValueID;
                md.TValues = value;
                int k = ModuleCore.BLL.TypeNameValues.Instance.Add(md);
                return k;
            }
            else
            {
                return 0;
            }

        }


        #endregion

        #region 促销活动商品操作(flz)

        [WebMethod(Description = "添加促销商品 最佳组合 = 1,推荐配件 = 2 ,买几送几=3,批发打折=4")]
        public int AddPromotionGoods(int promoID, int goodID, int typeID)
        {
            if (IsAllow(true))
            {
                if (promoID > 0)
                {
                    if (typeID == 3 || typeID == 4)
                    {
                        ModuleCore.Entity.PromotionProduct model = new PromotionProduct();
                        model.PromotionsID = promoID;
                        model.ProductID = goodID;
                        return ModuleCore.BLL.PromotionProduct.Instance.Add(model);
                    }
                    if (typeID == 1 || typeID == 2)
                    {
                        ModuleCore.Entity.P_BestGroup md = new ModuleCore.Entity.P_BestGroup();
                        if (goodID > 0)
                        {
                            EbSite.Entity.NewsContent ctent = EbSite.Base.AppStartInit.NewsContentInstDefault.GetModelByFiledOfDefault("SmallPic,NewsTitle", "id=" + goodID);
                            md.ProductID = promoID;
                            md.GoodsID = goodID;
                            md.GoodsAvatarSmall = ctent.SmallPic;
                            md.GoodsName = ctent.NewsTitle;
                            md.OrderiD = 1;
                            md.TypeID = typeID;
                            return md.Add();
                        }
                    }
                }
                return 0;
            }
            return 0;

        }

        [WebMethod(Description = "删除促销商品")]
        public int DeletePromotionGoods(int promoID, int goodID, int typeID)
        {
            if (IsAllow(true, true))
            {
                if (typeID == 3 || typeID == 4)
                {
                    return ModuleCore.BLL.PromotionProduct.Instance.Delete(promoID, goodID) ? 1 : 0;
                }
                if (typeID == 1 || typeID == 2)
                {
                    List<ModuleCore.Entity.P_BestGroup> ls = ModuleCore.BLL.P_BestGroup.Instance.GetListArray(0, string.Format("TypeID={1} and  ProductID={0} and GoodsID={2} ", promoID, typeID, goodID), "");
                    foreach (var productsImg in ls)
                    {
                        ModuleCore.BLL.P_BestGroup.Instance.Delete(productsImg.id);
                        return 1;
                    }
                }
            }
            return 0;

        }
        [WebMethod(Description = "清空促销商品")]
        public int ClearPromotionGoods(int promoID, int typeID)
        {
            if (IsAllow(true, true))
            {
                if (typeID == 3 || typeID == 4)
                {
                    return ModuleCore.BLL.PromotionProduct.Instance.Delete(promoID, 0) ? 1 : 0;
                }
                if (typeID == 1 || typeID == 2)
                {
                    List<ModuleCore.Entity.P_BestGroup> ls = ModuleCore.BLL.P_BestGroup.Instance.GetListArray(0, string.Format("TypeID={1} and  ProductID={0}  ", promoID, typeID), "");
                    foreach (var productsImg in ls)
                    {
                        ModuleCore.BLL.P_BestGroup.Instance.Delete(productsImg.id);
                    }
                }
            }
            return 0;

        }

        #endregion 促销活动商品操作(flz)

        #region 使用指南说明(flz)

        [WebMethod(Description = "删除指定的使用指南")]
        public int DeleteUserBook(int id)
        {
            if (IsAllow(true, true))
            {
                if (id > 0)
                {
                    ModuleCore.BLL.P_UserBook.Instance.Delete(id);
                    return 1;
                }
                return 0;
            }
            return 0;

        }

        #endregion 使用指南说明(flz)

        //#region 最佳组合、推荐配件(flz)

        //[WebMethod(Description = "最佳组合")]
        //public int DeleteBestGroup(int id)
        //{
        //    if (IsAllow(true, true))
        //    {
        //        if (id > 0)
        //        {
        //            ModuleCore.BLL.P_BestGroup.Instance.Delete(id);
        //            return 1;
        //        }
        //        return 0;
        //    }
        //    return 0;

        //}

        //[WebMethod(Description = "推荐配件")]
        //public int DeleteRecommendPart(int id)
        //{
        //    if (IsAllow(true, true))
        //    {
        //        if (id > 0)
        //        {
        //            ModuleCore.BLL.P_BestGroup.Instance.Delete(id);
        //            return 1;
        //        }
        //        return 0;
        //    }
        //    return 0;
        //}

        //#endregion 最佳组合、推荐配件(flz)

        #region 订单相关操作(flz)

        [WebMethod(Description = "删除订单(修改订单状态为删除状态)")]
        public int AsynDelOrder(string rIDs)
        {
            if (IsAllow(true, true))
            {
                if (!string.IsNullOrEmpty(rIDs))
                {
                    Dictionary<string, object> dicArray = new Dictionary<string, object>();
                    dicArray.Add("OrderStatus", ModuleCore.BLL.Buy_Orders.Instance.GetStatusTips(ModuleCore.SystemEnum.OrderStatus.回收站));
                    dicArray.Add("FinishDate", string.Concat("'", DateTime.Now.ToString(), "'"));
                    //记录操作日志
                    if (ModuleCore.BLL.Buy_Orders.Instance.UpdateByDic(dicArray, rIDs.TrimEnd(',')))
                    {
                        rIDs = rIDs.TrimEnd(',');
                        if (rIDs.Contains(','))
                        {
                            string[] arrIDs = rIDs.Split(',');
                            foreach (string str in arrIDs)
                            {
                                ModuleCore.BLL.buy_orderlog.Instance.Add(int.Parse(str), "删除了此订单", ModuleCore.SystemEnum.OrderLogType.全部显示);
                            }
                        }
                        else
                        {
                            ModuleCore.BLL.buy_orderlog.Instance.Add(int.Parse(rIDs), "删除了此订单", ModuleCore.SystemEnum.OrderLogType.全部显示);
                        }

                        return 1;
                    }
                    return 1;
                }
            }
            return 0;

        }

        [WebMethod(Description = "把订单修改为关闭状态")]
        public int AsynCloseOrder(int rid, string strRea)
        {
            if (IsAllow(true, true))
            {
                Dictionary<string, object> dicArray = new Dictionary<string, object>();
                dicArray.Add("OrderStatus", ModuleCore.BLL.Buy_Orders.Instance.GetStatusTips(ModuleCore.SystemEnum.OrderStatus.回收站));
                dicArray.Add("CloseReason", string.Concat("'", strRea, "'"));
                dicArray.Add("FinishDate", string.Concat("'", DateTime.Now.ToString(), "'"));
                dicArray.Add("DelOrderDate", "'" + DateTime.Now + "'");
                if (ModuleCore.BLL.Buy_Orders.Instance.UpdateByDic(dicArray, rid))
                {
                    //EbSite.Base.Host.Instance.InsertLog("关闭订单", "把订单状态修改为了关闭状态,原因：" + strRea);
                    ModuleCore.BLL.buy_orderlog.Instance.Add(rid, string.Concat("把订单状态修改为了关闭状态,原因:", strRea), ModuleCore.SystemEnum.OrderLogType.全部显示);
                    return 1;
                }
                return 0;
            }
            return 0;

        }

        [WebMethod(Description = "通过审核")]
        public int ApprovedOrder(int rid)
        {
            if (IsAllow(true, true))
            {
                if (rid > 0)
                {
                    Dictionary<string, object> dicArray = new Dictionary<string, object>();
                    dicArray.Add("OrderStatus", ModuleCore.BLL.Buy_Orders.Instance.GetStatusTips(ModuleCore.SystemEnum.OrderStatus.审核订单));
                    dicArray.Add("ReviewedOrderDate", "'" + DateTime.Now + "'");
                    if (ModuleCore.BLL.Buy_Orders.Instance.UpdateByDic(dicArray, rid))
                    {
                        ModuleCore.BLL.buy_orderlog.Instance.Add(rid, string.Concat("您的订单已通过审核，正准备出库"), ModuleCore.SystemEnum.OrderLogType.前台显示);
                        return 1;
                    }
                }
            }
            return 0;
        }
        [WebMethod(Description = "完成交易")]
        public int FinishOrder(int rid)
        {
            if (IsAllow(true, true))
            {
                if (rid > 0)
                {
                    Dictionary<string, object> dicArray = new Dictionary<string, object>();
                    dicArray.Add("OrderStatus", ModuleCore.BLL.Buy_Orders.Instance.GetStatusTips(ModuleCore.SystemEnum.OrderStatus.交易完成));
                    dicArray.Add("finishdate", "'" + DateTime.Now + "'");
                    if (ModuleCore.BLL.Buy_Orders.Instance.UpdateByDic(dicArray, rid))
                    {
                        ModuleCore.BLL.buy_orderlog.Instance.Add(rid, string.Concat("商品完成交易"), ModuleCore.SystemEnum.OrderLogType.全部显示);
                        return 1;
                    }
                }
            }
            return 0;
        }

        [WebMethod(Description = "已线下支付")]
        public int AsynOffLinePayed(int rid)
        {
            if (IsAllow(true, true))
            {
                Dictionary<string, object> dicArray = new Dictionary<string, object>();
                dicArray.Add("OrderStatus", ModuleCore.BLL.Buy_Orders.Instance.GetStatusTips(ModuleCore.SystemEnum.OrderStatus.已支付));
                dicArray.Add("PayDate", string.Concat("'", DateTime.Now.ToString(), "'"));
                if (ModuleCore.BLL.Buy_Orders.Instance.UpdateByDic(dicArray, rid))
                {
                    //EbSite.Base.Host.Instance.InsertLog("订单已线下支付", "此订单已在线下支付");
                    ModuleCore.BLL.buy_orderlog.Instance.Add(rid, "此订单已在线下支付", ModuleCore.SystemEnum.OrderLogType.全部显示);
                    #region YHL 同时把积分写进用户

                    ModuleCore.Entity.Buy_Orders buymd = ModuleCore.BLL.Buy_Orders.Instance.GetEntity(rid);
                    if (!Equals(buymd, null))
                    {
                        int iScore = EbSite.Base.Host.Instance.GetUserCreditsByID(buymd.UserId);

                        ModuleCore.Entity.pointdetails md = new pointdetails();
                        md.UserId = buymd.UserId;
                        md.OrderId = buymd.OrderId;
                        md.TradeDate = DateTime.Now;
                        md.TradeType = Convert.ToInt32(ModuleCore.SystemEnum.MyPointType.购物奖励);
                        md.Increased = buymd.OrderPoint;
                        md.Reduced = 0;
                        md.Points = iScore + buymd.OrderPoint;
                        md.Remark = "";
                        md.Add();

                        //同时 更新 总积分
                        EbSite.Base.Host.Instance.AddUserCreditsByID(buymd.UserId, buymd.OrderPoint);
                    }

                    #endregion

                    return 1;
                }
                return 0;
            }
            return 0;

        }
        [WebMethod(Description = "修改订单价格")]
        public int UpdateOrderPrice(int id, int gc, string tp, int rid)
        {
            if (IsAllow(true, true))
            {
                ModuleCore.Entity.Buy_OrderItem itemModel = ModuleCore.BLL.Buy_OrderItem.Instance.GetEntity(id);
                if (itemModel != null)
                {
                    decimal tmpPrice = (gc - itemModel.Quantity) * decimal.Parse(tp);
                    if (tmpPrice > 0 || tmpPrice < 0)
                    {
                        Dictionary<string, object> dicArray = new Dictionary<string, object>();
                        dicArray.Add("Quantity", gc);
                        //dicArray.Add("MemberPrice", decimal.Parse(tp) * gc);
                        Dictionary<string, object> dicArray_Order = new Dictionary<string, object>();
                        dicArray_Order.Add("Amount", string.Concat("Amount", tmpPrice > 0 ? "+" + tmpPrice.ToString() : tmpPrice.ToString()));
                        dicArray_Order.Add("OrderTotal", string.Concat("OrderTotal", tmpPrice > 0 ? "+" + tmpPrice.ToString() : tmpPrice.ToString()));

                        if (ModuleCore.BLL.Buy_OrderItem.Instance.UpdateByDic(dicArray, dicArray_Order, id, rid))
                        {
                            //EbSite.Base.Host.Instance.InsertLog("修改购买数量和订单价格", "修改了订单购买数量,修改了订单价格");
                            ModuleCore.BLL.buy_orderlog.Instance.Add(rid, "修改了订单购买数量", ModuleCore.SystemEnum.OrderLogType.全部显示);
                            return 1;
                        }
                    }
                }
                return 0;
            }
            else
            {
                return 0;
            }

        }

        [WebMethod(Description = "用户前台取消订单")]
        public int PageCloseOrder(int id, string strRea)
        {
            ModuleCore.Entity.Buy_Orders md = ModuleCore.BLL.Buy_Orders.Instance.GetEntity(id);
            if (!Equals(md, null) && md.OrderStatus == ModuleCore.BLL.Buy_Orders.Instance.GetStatusTips(ModuleCore.SystemEnum.OrderStatus.提交订单))
            {
                ModuleCore.BLL.Buy_Orders.Instance.CloseOrder(id, string.Concat("用户关闭", strRea));
                ModuleCore.BLL.buy_orderlog.Instance.Add(id, string.Concat("客户关闭了此订单,原因:", strRea), ModuleCore.SystemEnum.OrderLogType.全部显示);
                return 1;
            }
            else
            {
                return 0;
            }
        }

        #endregion 订单相关操作(flz)

        #region 订单日志操作(flz)

        [WebMethod(Description = "添加订单操作日志")]
        public int AddOrderLog(string orderID, string logMsg, ModuleCore.SystemEnum.OrderLogType showTpe)
        {
            return ModuleCore.BLL.buy_orderlog.Instance.Add(orderID, logMsg, showTpe);
        }

        #endregion 订单日志操作(flz)

        #region 地区相关操作(flz)

        [WebMethod(Description = "获取子级数据")]
        public string GetAreaOption(int level, int pid)
        {
            if (IsAllow(true, true))
            {
                List<EbSite.Entity.AreaInfo> ls = EbSite.BLL.AreaInfo.Instance.GetListArray("level=" + level + " and headid=" + pid);
                if (ls != null && ls.Count > 0)
                {
                    StringBuilder optionItem = new StringBuilder();
                    optionItem.Append("<option value=\"-1\">-请选择-</option>");
                    foreach (EbSite.Entity.AreaInfo m in ls)
                    {
                        optionItem.AppendFormat("<option value=\"{0}\">{1}</option>", m.id, m.Name);
                    }
                    return optionItem.ToString();
                }
                return "<option value=\"-1\">-请选择-</option>";
            }
            else
            {
                return base.NoAllowTips;
            }

        }

        #endregion 地区相关操作(flz)

        #region 后台商品费用
        #region 列表商品费用
        [WebMethod(Description = "")]
        public List<ProductOp> GetProductOptionList(int id)
        {
            if (IsAllow(true, true))
            {
                List<ProductOp> ls = new List<ProductOp>();
                List<ModuleCore.Entity.ProductOptions> lsOption = ModuleCore.BLL.ProductOptions.Instance.GetListArray("ProductID=" + id);
                foreach (var productOptionse in lsOption)
                {
                    ProductOp md = new ProductOp();
                    md.id = productOptionse.id;
                    md.title = productOptionse.OptionName;
                    md.Description = productOptionse.Description;
                    ls.Add(md);

                }
                return ls;
            }
            else
            {
                return null;
            }


        }
        #endregion

        #region 添加商品费用选项
        /// <summary>
        /// 商品费用选项
        /// </summary>
        /// <param name="title">标题</param>
        /// <param name="ProductID">产品ID</param>
        /// <param name="Description">描述</param>
        /// <param name="opid">opid=0 添加 |opid>0 修改</param>
        /// <returns></returns>
        [WebMethod(Description = "商品费用选项 ")]
        public ProdeuctOpAdd OpProductOptions(string title, int ProductID, string Description, int opid)
        {
            if (IsAllow(true, true))
            {
                ProdeuctOpAdd model = new ProdeuctOpAdd();
                if (opid == 0)
                {
                    ModuleCore.Entity.ProductOptions md = new ProductOptions();
                    md.Description = Description;
                    md.ProductID = ProductID;
                    md.OptionName = title;

                    int id = ModuleCore.BLL.ProductOptions.Instance.Add(md);
                    model.id = id;
                }
                else
                {
                    ModuleCore.Entity.ProductOptions md = ModuleCore.BLL.ProductOptions.Instance.GetEntity(opid);
                    md.Description = Description;
                    md.OptionName = title;
                    ModuleCore.BLL.ProductOptions.Instance.Update(md);
                    model.id = opid;
                }
                int icount = ModuleCore.BLL.ProductOptions.Instance.GetCount("ProductID=" + ProductID);

                model.icount = icount;
                return model;
            }
            return null;
        }
        #endregion


        #region 查询大类一条 商品费用选项

        [WebMethod(Description = "查询一条 商品费用选项 ")]
        public ProductOp GetProductOptions(int opid)
        {
            if (IsAllow(true, true))
            {
                ProductOp model = new ProductOp();
                if (opid > 0)
                {
                    ModuleCore.Entity.ProductOptions md = ModuleCore.BLL.ProductOptions.Instance.GetEntity(opid);
                    model.Description = md.Description;
                    model.title = md.OptionName;
                    model.id = opid;
                }
                return model;
            }
            return null;
        }

        #endregion


        #region 添加从表
        /// <summary>
        /// 添加 子项
        /// </summary>
        /// <param name="pid">ProductOptionID</param>
        /// <param name="ititle">标题</param>
        /// <param name="IsGive">是否赠送</param>
        /// <param name="AppendMoney"></param>
        /// <param name="CalculateMode"></param>
        /// <param name="Remark"></param>
        /// <returns></returns>
        [WebMethod(Description = "ProductOptionItems")]
        public ProdeuctOpAdd OpProductOptionItems(int pid, string ititle, bool IsGive, decimal AppendMoney, int CalculateMode, string Remark, int opid)
        {
            if (IsAllow(true, true))
            {
                ProdeuctOpAdd model = new ProdeuctOpAdd();
                if (opid == 0)
                {
                    ModuleCore.Entity.ProductOptionItems md = new ProductOptionItems();
                    md.ProductOptionID = pid;
                    md.ItemName = ititle;
                    md.IsGive = IsGive;
                    md.AppendMoney = AppendMoney;
                    md.CalculateMode = CalculateMode;
                    md.Remark = Remark;
                    int id = ModuleCore.BLL.ProductOptionItems.Instance.Add(md);
                    model.id = id;
                }
                else
                {
                    ModuleCore.Entity.ProductOptionItems md = ModuleCore.BLL.ProductOptionItems.Instance.GetEntity(opid);
                    md.ProductOptionID = pid;
                    md.ItemName = ititle;
                    md.IsGive = IsGive;
                    md.AppendMoney = AppendMoney;
                    md.CalculateMode = CalculateMode;
                    md.Remark = Remark;
                    ModuleCore.BLL.ProductOptionItems.Instance.Update(md);
                    model.id = opid;
                }
                int icount = ModuleCore.BLL.ProductOptionItems.Instance.GetCount("ProductOptionID=" + pid);
                model.icount = icount;
                return model;
            }
            return null;

        }

        #endregion

        #region 取子项的列表
        [WebMethod(Description = "取子项的列表")]
        public List<ProductItem> GetProductItem(int id)
        {
            if (IsAllow(true, true))
            {
                List<ProductItem> ls = new List<ProductItem>();
                List<ModuleCore.Entity.ProductOptionItems> list = ModuleCore.BLL.ProductOptionItems.Instance.GetListArray("ProductOptionID=" + id);
                foreach (var productOptionItemse in list)
                {
                    ProductItem md = new ProductItem();
                    md.AppendMoney = productOptionItemse.AppendMoney;
                    //费用计算模式 0.固定金额 1.购物车金额百分比 
                    md.CalculateMode = Equals(productOptionItemse.CalculateMode, 0) ? "固定金额" : "购物车金额百分比";
                    md.ItemName = productOptionItemse.ItemName;
                    md.IsGive = Equals(productOptionItemse.IsGive, true) ? "是" : "否";
                    md.id = productOptionItemse.id;
                    md.Remark = productOptionItemse.Remark;
                    ls.Add(md);
                }
                return ls;
            }
            return null;

        }
        #endregion


        #region 取子项列表 检测是否有赠送的选项
        [WebMethod(Description = "取子项列表 检测是否有赠送的选项")]
        public bool CheckGiveGetProductItem(int id)
        {
            bool key = false;
            if (IsAllow(true, true))
            {
                List<ProductItem> ls = new List<ProductItem>();
                List<ModuleCore.Entity.ProductOptionItems> list = ModuleCore.BLL.ProductOptionItems.Instance.GetListArray(" isgive=1 and ProductOptionID=" + id);
                if (list.Count > 0)
                    key = true;
                return key;
            }
            return key;

        }
        #endregion

        #region 取子项的实体
        [WebMethod(Description = "取子项的实体")]
        public ProductItem GetEntityProductItem(int id)
        {
            if (IsAllow(true, true))
            {
                ProductItem md = new ProductItem();
                ModuleCore.Entity.ProductOptionItems productOptionItemse = ModuleCore.BLL.ProductOptionItems.Instance.GetEntity(id);

                md.AppendMoney = productOptionItemse.AppendMoney;
                //费用计算模式 0.固定金额 1.购物车金额百分比 
                md.CalculateMode = productOptionItemse.CalculateMode.ToString();
                md.ItemName = productOptionItemse.ItemName;
                md.IsGive = productOptionItemse.IsGive.ToString();
                md.id = productOptionItemse.id;
                md.Remark = productOptionItemse.Remark;


                return md;
            }
            return null;

        }
        #endregion
        #region 删除子项
        [WebMethod(Description = "删除")]
        public void DelProductItem(int id)
        {
            if (IsAllow(true, true))
            {
                ModuleCore.BLL.ProductOptionItems.Instance.Delete(id);
            }

        }
        #endregion

        #region 删除大项 同时删除子表项
        [WebMethod(Description = "")]
        public void DelOption(int id)
        {
            if (IsAllow(true, true))
            {
                ModuleCore.BLL.ProductOptions.Instance.Delete(id);
                List<ModuleCore.Entity.ProductOptionItems> ls = ModuleCore.BLL.ProductOptionItems.Instance.GetListArray("ProductOptionID=" + id);
                foreach (var i in ls)
                {
                    ModuleCore.BLL.ProductOptionItems.Instance.Delete(i.id);
                }
            }

        }
        #endregion
        #endregion

        #region 浮动菜单
        [WebMethod]
        public string MouseOverMenus()
        {
            string menus = "";

            return menus;
        }
        #endregion


        [WebMethod]
        public List<ProductOption> GetProductOptionItems(int pid)
        {
            return ModuleCore.BLL.ProductOptionItems.Instance.GetListArrayByPID(pid);

            //List<ProductOptionItems> lst = ModuleCore.BLL.ProductOptionItems.Instance.GetListArrayByPID(pid);
            //List<ProductOption> rz = new List<ProductOption>();

            ////foreach (ProductOptionItems itemse in lst)
            ////{
            ////    ProductItem li = new ProductItem();
            ////    li.AppendMoney = itemse.AppendMoney;
            ////    li.CalculateMode = itemse.CalculateMode.ToString();
            ////    li.IsGive = itemse.IsGive.ToString();
            ////    li.ItemName = itemse.ItemName;
            ////    li.id = itemse.id;
            ////    li.OptionName = itemse.OptionName;
            ////    rz.Add(li);
            ////}

            //return rz;

        }

        #region yhl 得到用户总积分
        [WebMethod]
        public int GetUserScore(int userId)
        {
            int iScore = 0;
            if (IsAllow(true, true))
            {
                if (userId > 0)
                {
                    iScore = EbSite.Base.Host.Instance.GetUserCreditsByID(userId);
                }
            }
            return iScore;
        }
        #endregion

        #region 检测用户的支付密码 YHL 2013-11-05
        [WebMethod]
        public int CheckUserPayPass(string pass)
        {
            int key = 0;
            if (IsAllow(true, true))
            {
                EbSite.Entity.PayPass payModel = EbSite.BLL.PayPass.Instance.GetEntityByUserID(EbSite.Base.Host.Instance.UserID);
                if (!Equals(payModel, null))
                {
                    if (!string.IsNullOrEmpty(payModel.Pass))
                    {
                        string sPass = UserIdentity.PassWordEncode(pass);
                        if (sPass == payModel.Pass)
                        {
                            key = 1;
                        }
                    }
                }
            }
            return key;
        }
        #endregion


        #region 2013-12-16 得到商品的实际数量
        /// <summary>
        /// 得到商品的实际数量
        /// </summary>
        /// <param name="productId">产品id</param>
        /// <param name="pNumber">规格编码 商品编号 唯一的</param>
        /// <returns></returns>
        [WebMethod]
        public int GetProductCount(int productId, string pNumber)
        {
            //一种 没有开启规格时 Annex12商品数量
            //开始了规格 正好是默认的那个商品
            EbSite.Entity.NewsContent md = EbSite.Base.AppStartInit.NewsContentInstDefault.GetModelByFiledOfDefault("Annex12", string.Concat("id=", productId, " and annex1='", pNumber, "'"));
            if (!Equals(md, null))
            {
                return md.Annex12;
            }
            else
            {
                //第二种情况 开启了 规格 不是默认的那个
                List<ModuleCore.Entity.NormRelationProduct> ls =
                    ModuleCore.BLL.NormRelationProduct.Instance.GetListArray(1,
                                                                             string.Concat("productid=", productId,
                                                                                           " and pnumber='", pNumber,
                                                                                           "'"));
                if (ls.Count > 0)
                {
                    return ls[0].Stocks;
                }
                return 0;
            }
        }
        #endregion
        /// <summary>
        /// 用户后台 关闭订单
        /// </summary>
        /// <param name="id"></param>
        /// <param name="orderID"></param>
        /// <param name="strReason"></param>
        /// <returns></returns>
        [WebMethod(Description = "关闭订单")]
        public int ClosePcOrder(int id, string orderID, string strReason)
        {
            int uid = base.UserID();
            if (uid > 0)
            {
                Dictionary<string, object> arrList = new Dictionary<string, object>();
                arrList.Add("orderstatus", (int)ModuleCore.SystemEnum.OrderStatus.回收站);
                arrList.Add("closereason", string.Format("'{0}'", strReason));
                arrList.Add("finishdate", string.Format("'{0}'", DateTime.Now));
                ModuleCore.BLL.Buy_Orders.Instance.UpdateByDic(arrList, id);
                ModuleCore.BLL.buy_orderlog.Instance.Add(orderID, "订单关闭，原因：" + strReason, ModuleCore.SystemEnum.OrderLogType.全部显示);
                return 1;
            }
            return 0;
        }
        #region 2014-1-10 手机版 关闭订单
        /// <summary>
        /// 手机版 关闭订单
        /// </summary>
        /// <param name="orderid">订单 自增长id</param>
        /// <param name="ctent">关闭 原因</param>
        /// <returns></returns>
        [WebMethod]
        public bool CloseOrder(int orderid, string ctent)
        {
            bool ikey = false;
            if (IsAllow(true, true))
            {
                if (orderid > 0)
                {
                    if (!string.IsNullOrEmpty(ctent))
                    {
                        ModuleCore.Entity.Buy_Orders md =
                            ModuleCore.BLL.Buy_Orders.Instance.GetEntity(orderid);
                        if (!Equals(md, null))
                        {
                            bool key = ModuleCore.BLL.Buy_Orders.Instance.CloseOrder(orderid, "用户关闭" + ctent);
                            if (key)
                            {
                                //添加日志
                                ModuleCore.BLL.buy_orderlog.Instance.Add(md.OrderId.ToString(), "您关闭了订单。", SystemEnum.OrderLogType.前台显示);
                                ikey = true;
                            }
                        }

                    }
                }

            }
            return ikey;
        }

        #endregion

    }
    public class ResultData
    {
        /// <summary>
        /// 属性
        /// </summary>
        public List<GoodsAttribute> goodsAttribute { get; set; }
        /// <summary>
        /// 规格
        /// </summary>
        public List<GoodsAttribute> goodsNorms { get; set; }

    }
    public class GoodsAttribute
    {
        /// <summary>
        /// id
        /// </summary>
        public int AttributeId { get; set; }
        /// <summary>
        /// 支持多选
        /// </summary>
        public int UsageMode { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        public List<GoodsAttributeChild> AttributeValues { get; set; }

    }
    public class GoodsAttributeChild
    {
        /// <summary>
        /// 子类id
        /// </summary>
        public int ValueId { get; set; }
        /// <summary>
        /// 内容
        /// </summary>
        public string ValueStr { get; set; }

    }


    /// <summary>
    /// 商品费用选项表
    /// </summary>
    public class ProductOp
    {
        public string title { get; set; }
        public string Description { get; set; }
        public int id { get; set; }

    }
    public class ProdeuctOpAdd
    {
        public int id { get; set; }
        public int icount { get; set; }
    }



}
