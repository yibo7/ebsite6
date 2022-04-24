using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.Modules;
using EbSite.Base.Configs.SysConfigs;
using System.Data;

namespace EbSite.Modules.Shop.AdminPages.Controls.Promotions
{
    public partial class PromoAddProduct : MPUCBaseSave
    {
        public override string PageName
        {
            get
            {
                return "选择促销商品";
            }
        }
        public override string Permission
        {
            get
            {
                return "34";
            }
        }
        override protected string KeyColumnName
        {
            get
            {
                return "ID";
            }
        }
        //促销ID类型
        public string IdType
        {
            get
            {
                if (Request.Params["tp"] != null)
                {
                    return Request.Params["tp"].ToString();
                }
                return "";
            }
        }
        public int PromoID
        {
            get
            {
                return Core.Utils.StrToInt(Request.Params["id"], 0);
            }
        }
        //促销标题
        public string NewTitle
        {
            get
            {
                return "添加 <span>" + ModuleCore.BLL.PromotionsType.GetPromotionsTypeName(IdType) + "</span> 促销活动的商品";
            }
        }
        override protected void InitModifyCtr()
        {
           // ModuleCore.BLL.Supplier.Instance.InitModifyCtr(SID, phCtrList);
        }
        override protected void SaveModel()
        {
            base.ShowTipsPop("添加成功");
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {  
                //查询出商品列表
               // BindData();

               ////绑定已添加商品列表
               // if (PromoID > 0)
               // {
               //     DataSet productList = ModuleCore.BLL.PromotionProduct.Instance.GetList("PromotionsID=" + PromoID);
               //     if (productList != null && productList.Tables.Count > 0&&productList.Tables[0].Rows.Count>0)
               //     {
               //         string strIDs = "";
               //         foreach (DataRow dr in productList.Tables[0].Rows)
               //         {
               //             strIDs += dr["ProductID"].ToString() + ",";
               //         }
               //         if (!string.IsNullOrEmpty(strIDs))
               //         {
               //             strIDs = Core.Utils.ClearLastChar(strIDs);
               //             List<EbSite.Entity.NewsContent> goodListEx = EbSite.BLL.NewsContent.GetListArray("id in("+strIDs+")",0,"","",SettingInfo.Instance.GetSiteID);//(pcPageEx.PageIndex, pcPageEx.PageSize,"", out iCountEx, 3);
               //             this.repDataEx.DataSource = goodListEx;
               //             this.repDataEx.DataBind();
               //         }
               //     }
               // }
               // //绑定商品分类
               // List<EbSite.Entity.NewsClass> classList = EbSite.BLL.NewsClass.GetContentClassesTree(SettingInfo.Instance.GetSiteID);
               // if (classList != null && classList.Count > 0)
               // {
               //     List<EbSite.Entity.NewsClass> nlist = (from i in classList where i.Annex9 == 1 select i).ToList();
               //     this.ddl_goodtype.DataSource = nlist;
               //     this.ddl_goodtype.DataTextField = "ClassName";
               //     this.ddl_goodtype.DataValueField = "ID";
               //     this.ddl_goodtype.DataBind();
               //     this.ddl_goodtype.Items.Insert(0, new ListItem("--请选择分类--", "0"));
               // }
            }
        }

        protected void repData_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            Image img = (Image)e.Item.FindControl("imgGoodPic");
            List<ModuleCore.Entity.ProductsImg> imgList = ModuleCore.BLL.ProductsImg.Instance.GetListArray("productID=" + img.ToolTip);
            if (imgList != null && imgList.Count > 0)
            {
                img.ImageUrl = imgList[0].BigImg;
            }
            else
            {
                
                img.ImageUrl = "/themes/shop/data/Upload/other/nopic.gif";
            }
        }
        protected void repDataEx_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            Image img = (Image)e.Item.FindControl("imgGoodPicEx");
            List<ModuleCore.Entity.ProductsImg> imgList = ModuleCore.BLL.ProductsImg.Instance.GetListArray("productID=" + img.ToolTip);
            if (imgList != null && imgList.Count > 0)
            {
                img.ImageUrl = imgList[0].BigImg;
            }
            else
            {
                img.ImageUrl = "/themes/shop/data/Upload/other/nopic.gif";
            }
        }

        //protected void btnSearch_OnClick(object sender, EventArgs e)
        //{
            
        //    BindData();
        //}

        //private void BindData()
        //{
        //    int classID =Core.Utils.StrToInt(this.ddl_goodtype.SelectedValue,0);
        //    string strKey = this.txtKeyWord.Text;
        //    string strWhere = " annex25=1";
        //    if (classID > 0)
        //    {
        //        strWhere += " and ClassID="+classID;
        //    }
        //    if (!string.IsNullOrEmpty(strKey.Trim()))
        //    {
        //        strWhere += " and NewsTitle like '%"+strKey.Trim()+"%'";
        //    }

        //    int iCount = 0;
        //    pcPage.PageSize = 10;
        //    List<EbSite.Entity.NewsContent> goodList = EbSite.BLL.NewsContent.GetListPages(pcPage.PageIndex, pcPage.PageSize, strWhere, out iCount, SettingInfo.Instance.GetSiteID);
        //    this.repData.DataSource = goodList;
        //    this.repData.DataBind();
        //    pcPage.Linktype = LinkType.Aspx;
        //    pcPage.AllCount = iCount;
        //    pcPage.OtherPram = string.Format("muid,{0}|mid,{1}|t,34|tp,{2}|id,{3}", "e3d7ac92-bd84-4e54-8bbd-797d327cc74f", base.ModuleID, IdType, PromoID);
        //}
    }
}