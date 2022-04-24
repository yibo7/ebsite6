using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EbSite.Base.Static;
using EbSite.Modules.Shop.ModuleCore.Cart;
using System.Text;
using System.Web.UI.WebControls;
using NormRelationProduct = EbSite.Modules.Shop.ModuleCore.Entity.NormRelationProduct;
using EbSite.Modules.Shop.ModuleCore.BLL;

namespace EbSite.Modules.Shop.ModuleCore.Pages
{
    public class mcontent_product : EbSite.Base.Page.BasePage
    {

        protected global::System.Web.UI.WebControls.Repeater rpPicList;
        protected global::System.Web.UI.WebControls.Repeater rpCuXiaoList;
        protected global::System.Web.UI.WebControls.Repeater rpZengPinList;
        protected global::System.Web.UI.WebControls.Repeater rpGGList;
        protected global::System.Web.UI.WebControls.Repeater rpListFeeOption;
        




        protected global::EbSite.Control.PagesContrl pgCtr;
        protected EbSite.Entity.NewsContent Model = new EbSite.Entity.NewsContent();
        protected int iSearchCount = 0;
        private int iPageSize
        {
            get
            {
                if (!Equals(pgCtr, null) && pgCtr.PageSize > 0)
                {
                    return pgCtr.PageSize;
                }
                else
                {
                    return 10;
                }

            }

        }

        public int PageIndex
        {
            get
            {
                if (!string.IsNullOrEmpty(Request.QueryString["p"]))
                    return Convert.ToInt32(Request.QueryString["p"]);
                else
                    return 1;
            }
        }
        protected string GetNav(string Nav)
        {
            return EbSite.BLL.NewsClass.GetNav(Nav, Model.ClassID, true, GetSiteID,0);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = "产品详细页";
            Model = Base.AppStartInit.NewsContentInstDefault.GetModel(iRequestID,GetSiteID);
            if (!IsPostBack)
            {
                inithead();
                binglistPic();
                CuXiaoInfo();
                BindZengPin();
                GGInfo();
                FeeOption();
            }
        }
        protected int iRequestID
        {
            get
            {
                if (!string.IsNullOrEmpty(Request["id"]))
                {
                    return int.Parse(Request["id"]);
                }
                else
                {

                    return -1;
                }
            }
        }
        #region  产品图片
        protected ModuleCore.Entity.ProductsImg FirstModel;
        /// <summary>
        /// 产品图片
        /// </summary>
        private void binglistPic()
        {


            if (iRequestID > 0)
            {


                List<ModuleCore.Entity.ProductsImg> lst = ModuleCore.BLL.ProductsImg.Instance.GetListByProductID(iRequestID);
                if (lst.Count > 0)
                {
                    rpPicList.DataSource = lst;
                    rpPicList.DataBind();

                    FirstModel = lst[0];
                }
                else
                {
                    FirstModel = new ModuleCore.Entity.ProductsImg();
                }

            }


        }
        #endregion

        #region 促销
        private void CuXiaoInfo()
        {
            List<CxInfo> cList = new List<CxInfo>();
            List<ModuleCore.Entity.PromotionProduct> ls = ModuleCore.BLL.PromotionProduct.Instance.GetListArray("productid=" + iRequestID);
            if (ls.Count > 0)
            {
                foreach (var promotionProduct in ls)
                {
                    CxInfo md = new CxInfo();
                    md.Url = "ctent.aspx" + promotionProduct.PromotionsID.ToString();
                    md.Title = GetTitle(promotionProduct.PromotionsID.ToString());
                    md.SuitUser = GetRoles(promotionProduct.PromotionsID.ToString());
                    cList.Add(md);
                }


            }
            List<ModuleCore.Entity.Promotions> ls2 = ModuleCore.BLL.Promotions.Instance.GetListArray("PromoteType in(1,3)");
            if (ls2.Count > 0)
            {
                foreach (var promotionse in ls2)
                {
                    CxInfo md = new CxInfo();
                    md.Url = "ctent.aspx" + promotionse.id;
                    md.Title = promotionse.TitleName;
                    md.SuitUser = GetRoles(promotionse.id.ToString());
                    cList.Add(md);
                }
            }
            if (cList.Count > 0)
            {
                rpCuXiaoList.DataSource = cList;
                rpCuXiaoList.DataBind();
            }
        }
        private string GetTitle(string id)
        {
            ModuleCore.Entity.Promotions model =
                       ModuleCore.BLL.Promotions.Instance.GetEntity(Convert.ToInt32(id));
            if (!Equals(model, null))
            {
                return model.TitleName;
            }
            return "";
        }
        private string GetRoles(string id)
        {
            string strRoles = "";
            List<ModuleCore.Entity.PromotionsRole> ls = ModuleCore.BLL.PromotionsRole.Instance.GetListArray("PromotionsID=" + id);
            foreach (var promotionsRole in ls)
            {
                EbSite.Modules.Shop.ModuleCore.Entity.ListItemModel lm = EbSite.Modules.Shop.ModuleCore.BLL.PromotionUserLevelType.GetPromotionUserLevelType(promotionsRole.UserRoleID.ToString());
                strRoles += lm.Text + ",";
            }
            if (strRoles.Length > 0)
                strRoles = strRoles.Remove(strRoles.Length - 1, 1);
            return strRoles;
        }
        #endregion

        #region 赠品
        private void BindZengPin()
        {
            List<ModuleCore.Entity.Gift> ls = ModuleCore.BLL.Gift.Instance.GetListArray("BuyProductId=" + iRequestID);
            if (ls.Count > 0)
            {
                this.rpZengPinList.DataSource = ls;
                this.rpZengPinList.DataBind();
            }
        }
        public string SmallPic(string id)
        {
            EbSite.Entity.NewsContent model = Base.AppStartInit.NewsContentInstDefault.GetModel(Convert.ToInt32(id),GetSiteID);
            if (!Equals(model, null))
                return model.SmallPic;
            return "";

        }
        public string GetName(string id)
        {
            EbSite.Entity.NewsContent model = Base.AppStartInit.NewsContentInstDefault.GetModel(Convert.ToInt32(id),GetSiteID);
            if (!Equals(model, null))
                return model.NewsTitle;
            return "";

        }

        #endregion

        #region 规格
        private List<ChildTemp> StrData = new List<ChildTemp>();
        protected string sAllNormkey;
        private void GGInfo()
        {
            if (iRequestID > 0)
            {

                List<ModuleCore.Entity.NormRelationProduct> lst = ModuleCore.BLL.NormRelationProduct.Instance.GetListByProductID(iRequestID);
                if (lst.Count > 0)
                {

                    StringBuilder sb = new StringBuilder();
                    foreach (NormRelationProduct nrp in lst)
                    {

                        sb.Append(nrp.NormsValues);
                        sb.Append("#");
                    }
                    sAllNormkey = sb.ToString();
                    StrData =EbSite.Modules.Shop.ModuleCore.BLL.NormRelationProduct.Instance.GetDataListByList(lst);
                    rpGGList.DataSource = EbSite.Modules.Shop.ModuleCore.BLL.NormRelationProduct.Instance.GetHeaderTextByList(lst);
                    rpGGList.DataBind();

                }
            }
        }
        public void rpList_ItemDataBound(object sender, System.Web.UI.WebControls.RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                EbSite.Base.EntityAPI.ListItemModel drData = (Base.EntityAPI.ListItemModel)e.Item.DataItem;
                //提取分类ID 
                string strClassID = drData.ID;
                if (!string.IsNullOrEmpty(strClassID))
                {
                    Repeater llClassList = (Repeater)e.Item.Controls[0].FindControl("rpSubList");

                    llClassList.DataSource = GetSkuBind(int.Parse(strClassID));
                    llClassList.DataBind();
                }

            }
        }
        public List<Base.EntityAPI.ListItemModel> GetSkuBind(int id)
        {
            List<Base.EntityAPI.ListItemModel> nls = new List<Base.EntityAPI.ListItemModel>();
            var xls = (from i in StrData where i.pid == id select i.id).Distinct().ToList();

            foreach (var childTemp in xls)
            {
                EbSite.Base.EntityAPI.ListItemModel md = new Base.EntityAPI.ListItemModel();
                md.ID = childTemp.ToString();
                md.Value = id.ToString();//这是父ID
                md.Text = ModuleCore.BLL.NormsValue.Instance.GetEntity(childTemp).NormsValueName;
                nls.Add(md);
            }
            return nls;
        }

        #endregion

        #region 商品费用选项
        private void FeeOption()
        {
            List<ModuleCore.Entity.ProductOptions> ls = ModuleCore.BLL.ProductOptions.Instance.GetListArray("ProductID=" + iRequestID);
            if (ls.Count > 0)
            {
                rpListFeeOption.DataSource = ls;
                rpListFeeOption.DataBind();
            }       
        }

        public void rpListFeeOption_ItemDataBound(object sender, System.Web.UI.WebControls.RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                ModuleCore.Entity.ProductOptions drData = (ModuleCore.Entity.ProductOptions)e.Item.DataItem;
                //提取分类ID 
                string strClassID = Convert.ToString(drData.id);
                if (!string.IsNullOrEmpty(strClassID))
                {
                    Repeater llClassList = (Repeater)e.Item.Controls[0].FindControl("rpSubList");
                    llClassList.DataSource = GetDataSub(strClassID);
                    llClassList.DataBind();
                }

            }
        }

        private List<ModuleCore.Entity.ProductOptionItems> GetDataSub(string strClassID)
        {
            string CacheKey = string.Concat("BeiMaiBandGetDataSub", strClassID);
            List<ModuleCore.Entity.ProductOptionItems> dl = EbSite.Base.Host.CacheRawApp.GetCacheItem<List<ModuleCore.Entity.ProductOptionItems>>(CacheKey,"shop");// as List<ModuleCore.Entity.ProductOptionItems>;
            if (dl == null)
            {
                dl = ModuleCore.BLL.ProductOptionItems.Instance.GetListArray("ProductOptionID=" + strClassID);
                Base.Host.CacheRawApp.AddCacheItem(CacheKey, dl, 10, ETimeSpanModel.FZ, "shop");
            }
            return dl;
        }
        #endregion
        private void inithead()
        {
            //base.SeoTitle = Args.SeoTitle;
            //base.SeoKeyWord = Args.SeoKeyWord;
            //base.SeoDes = Args.SeoDes;
        }

    }
}

