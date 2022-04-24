using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web.UI.WebControls;
using EbSite.Base;
using EbSite.Base.ExtWidgets.WidgetsManage;
using EbSite.Base.Static;
using EbSite.Core;
using EbSite.Modules.Shop.ModuleCore.Entity;
using ListItemModel = EbSite.Base.EntityAPI.ListItemModel;

namespace EbSite.Modules.Shop.Widgets.GetProduct
{
    public partial class widget : WidgetBase
    {
        const double CacheDuration = 60.0;
        private string CacheGetProduct;// private static readonly string[] MasterCacheKeyArray = { "ebshop-GetContent", "-", Host.Instance.GetSiteID.ToString() };
       // private static CacheManager bllCache;

     
        /// <summary>
        /// 自动适应分类ID
        /// </summary>
        private int GetClassID
        {
            get
            {
                if (!string.IsNullOrEmpty(Request["cid"]))
                {
                    return int.Parse(Request["cid"]);
                }
                else
                {
                    return 0;
                }
            }
        }


        public override void LoadData()
        {
            if (!base.IsPostBack)
            {
               // bllCache = new CacheManager(CacheDuration, MasterCacheKeyArray);
                CacheGetProduct = string.Concat("ebshopcontent", "-", Host.Instance.GetSiteID.ToString());
                int iTop = 0;
                string sType = "";
                bool IsGetSub = false;
                StringDictionary settings = GetSettings();

                if (settings.ContainsKey("drpType")) //类别 热卖 爆款 惊爆价 特价 直降
                {
                    sType = settings["drpType"];
                }
                if (settings.ContainsKey("CountTitle")) //Top 条数
                {
                    iTop = int.Parse(settings["CountTitle"]);
                }


                if (settings.ContainsKey("IsGetSub")) //是否 查子类
                {
                    string sIsGetSub = settings["IsGetSub"];
                    if (!string.IsNullOrEmpty(sIsGetSub))
                        IsGetSub = bool.Parse(sIsGetSub);

                }
                if (settings.ContainsKey("TemTitle") && !string.IsNullOrEmpty(settings["TemTitle"])) //模板
                {
                    string CacheKey = string.Concat("GetClassData-", sType, "-", iTop, "-", GetClassID, "-", SettingInfo.Instance.GetSiteID);
                    List<Entity.NewsContent> lst =
                        EbSite.Base.Host.CacheApp.GetCacheItem<List<Entity.NewsContent>>(CacheKey, CacheGetProduct);// bllCache.GetCacheItem(CacheKey) as List<Entity.NewsContent>;

                    if (lst == null)
                    {
                        if (sType == "1") //热卖 hot.热卖          
                        {
                            lst = GetListProduct("annex9='hot' ", iTop, GetClassID, "id desc", IsGetSub, "id,NewsTitle,SmallPic,annex16,classid",
                                                                      SettingInfo.Instance.GetSiteID);
                        }
                        else if (sType == "2")//bk.爆款
                        {
                            lst = GetListProduct("annex9='bk'", iTop, GetClassID, "id desc", IsGetSub, "id,NewsTitle,smallpic,annex16,classid",
                                                                     SettingInfo.Instance.GetSiteID);
                        }
                        else if (sType == "3") // jbj.惊爆价
                        {
                            lst = GetListProduct("annex9='jbj'", iTop, GetClassID, "id desc", IsGetSub, "id,NewsTitle,smallpic,annex16,classid",
                                                                     SettingInfo.Instance.GetSiteID);
                        }
                        else if (sType == "4") //tj.特价
                        {
                            lst = GetListProduct("annex9='tj'", iTop, GetClassID, "id desc", IsGetSub, "id,NewsTitle,smallpic,annex16,classid",
                                                                     SettingInfo.Instance.GetSiteID);
                        }
                        else if (sType == "5") //zj.直降
                        {
                            lst = GetListProduct("annex9='zj'", iTop, GetClassID, "id desc", IsGetSub, "id,NewsTitle,smallpic,annex16,classid",
                                                                     SettingInfo.Instance.GetSiteID);
                        }
                        if (!Equals(lst, null)) EbSite.Base.Host.CacheApp.AddCacheItem(CacheKey,lst,CacheDuration,ETimeSpanModel.FZ, CacheGetProduct); // bllCache.AddCacheItem(CacheKey, lst);
                    }

                    rpList.DataSource = lst;
                    string sTem = settings["TemTitle"];
                    sTem = base.TemBll.GetTemPath(sTem);
                    if (!string.IsNullOrEmpty(sTem))
                        rpList.ItemTemplate = LoadTemplate(sTem);
                    rpList.DataBind();
                }
            }



        }
        private List<EbSite.Entity.NewsContent> GetListProduct(string strWhere, int iTop, int iClassID, string OrderBy, bool IsGetSub, string Fields, int SiteID)
        {
            string sWhere = "";
            if (iClassID > 0)
            {
                if (!IsGetSub)
                {
                    sWhere = string.Concat("  ClassID =", iClassID);
                }
                else
                {
                    //很占用内存，有等优化
                    string SubIds = EbSite.BLL.NewsClass.GetSubIDs(iClassID, SiteID);
                    if (!string.IsNullOrEmpty(SubIds)) SubIds = string.Concat(",", SubIds);
                    sWhere = string.Concat("  ClassID in(", iClassID, SubIds, ")");
                }
                if (!string.IsNullOrEmpty(strWhere)) sWhere = string.Concat(sWhere, " and  ", strWhere);
            }
            return Base.AppStartInit.NewsContentInstDefault.GetListArray(sWhere, iTop, OrderBy, Fields, SiteID);
        }
        public override string Name
        {
            get { return "GetProduct"; }
        }

        public override bool IsEditable
        {
            get { return true; }
        }
    }
}