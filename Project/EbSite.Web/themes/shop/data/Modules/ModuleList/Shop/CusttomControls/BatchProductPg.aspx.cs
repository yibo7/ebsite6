using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.Configs.SysConfigs;
using EbSite.Base.Page;

namespace EbSite.Modules.Shop.CusttomControls
{
    public partial class BatchProductPg : BasePage
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                //查询出商品列表
                BindData();


                //绑定商品分类  //cfd5666c-0bd5-4beb-884b-75d23e7ca158 是 模型管理-分类模型 商品分类 guid
                List<EbSite.Entity.NewsClass> classList = EbSite.BLL.NewsClass.GetTreeModelID(0, SettingInfo.Instance.GetSiteID,
                                                                                                  new Guid(
                                                                                                      "cfd5666c-0bd5-4beb-884b-75d23e7ca158"));//EbSite.BLL.NewsClass.GetContentClassesTree(SettingInfo.Instance.GetSiteID);
                if (classList != null && classList.Count > 0)
                {



                    this.ddl_goodtype.DataSource = classList;
                    this.ddl_goodtype.DataTextField = "ClassName";
                    this.ddl_goodtype.DataValueField = "ID";
                    this.ddl_goodtype.DataBind();
                    this.ddl_goodtype.Items.Insert(0, new ListItem("--请选择分类--", "0"));
                }

                //绑定已添加商品列表
                if (PromoID > 0)
                {
                    if (OpTypeID == 1 || OpTypeID == 2)
                    {

                        DataSet productList =
                            ModuleCore.BLL.P_BestGroup.Instance.GetList("productid=" + PromoID + " and TypeID=" +
                                                                        OpTypeID);
                        if (productList != null && productList.Tables.Count > 0 && productList.Tables[0].Rows.Count > 0)
                        {
                            string strIDs = "";
                            foreach (DataRow dr in productList.Tables[0].Rows)
                            {
                                strIDs += dr["goodsid"].ToString() + ",";
                            }
                            if (!string.IsNullOrEmpty(strIDs))
                            {
                                strIDs = Core.Utils.ClearLastChar(strIDs);
                                List<EbSite.Entity.NewsContent> goodListEx =
                                    Base.AppStartInit.NewsContentInstDefault.GetListArray("id in(" + strIDs + ")", 0, "", "", SettingInfo.Instance.GetSiteID);
                                    //(pcPageEx.PageIndex, pcPageEx.PageSize,"", out iCountEx, 3);
                                this.repDataEx.DataSource = goodListEx;
                                this.repDataEx.DataBind();
                            }
                        }
                    }
                     if (OpTypeID == 3 || OpTypeID == 4)
                     {
                         DataSet productList = ModuleCore.BLL.PromotionProduct.Instance.GetList("PromotionsID=" + PromoID);
                         if (productList != null && productList.Tables.Count > 0 && productList.Tables[0].Rows.Count > 0)
                         {
                             string strIDs = "";
                             foreach (DataRow dr in productList.Tables[0].Rows)
                             {
                                 strIDs += dr["ProductID"].ToString() + ",";
                             }
                             if (!string.IsNullOrEmpty(strIDs))
                             {
                                 strIDs = Core.Utils.ClearLastChar(strIDs);
                                 List<EbSite.Entity.NewsContent> goodListEx = Base.AppStartInit.NewsContentInstDefault.GetListArray("id in(" + strIDs + ")", 0, "", "", SettingInfo.Instance.GetSiteID);//(pcPageEx.PageIndex, pcPageEx.PageSize,"", out iCountEx, 3);
                                 this.repDataEx.DataSource = goodListEx;
                                 this.repDataEx.DataBind();
                             }
                         }
                     }
                }
            }
        }
        //protected void repDataEx_ItemDataBound(object sender, RepeaterItemEventArgs e)
        //{
        //    Image img = (Image)e.Item.FindControl("imgGoodPicEx");
        //    List<ModuleCore.Entity.ProductsImg> imgList = ModuleCore.BLL.ProductsImg.Instance.GetListArray("productID=" + img.ToolTip);
        //    if (imgList != null && imgList.Count > 0)
        //    {
        //        img.ImageUrl = imgList[0].BigImg;
        //    }
        //    else
        //    {
        //        img.ImageUrl = "/themes/shop/data/Upload/other/nopic.gif";
        //    }
        //}

        protected void btnSearch_OnClick(object sender, EventArgs e)
        {
            Session["BatchProductPgswhere"] = "";
            pcPage.PageIndex = 1;
            BindData();
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

        /// <summary>
        ///   最佳组合 = 1,推荐配件 = 2 ,买几送几=3,批发打折=4
        /// </summary>
        public int OpTypeID
        {
            get
            {
                return Core.Utils.GetQueryInt("op", 1);
            }
        }
        public int PromoID
        {
            get
            {
                return Core.Utils.GetQueryInt("iid", 0);
            }
        }
        private void BindData()
        {

            string strWhere = " annex25=1";
            if (!Equals(Session["BatchProductPgswhere"],null))
            {
                if (string.IsNullOrEmpty(Session["BatchProductPgswhere"].ToString()))
                {

                    int classID = Core.Utils.StrToInt(this.ddl_goodtype.SelectedValue, 0);
                    string strKey = this.txtKeyWord.Text;

                    if (classID > 0)
                    {
                        strWhere += " and ClassID=" + classID;
                    }
                    if (!string.IsNullOrEmpty(strKey.Trim()))
                    {
                        strWhere += " and NewsTitle like '%" + strKey.Trim() + "%'";
                    }

                    if (!string.IsNullOrEmpty(strWhere))
                    {
                        Session["BatchProductPgswhere"] = strWhere;
                    }
                }
                else
                {
                    string str = Session["BatchProductPgswhere"] as string;
                    if (!string.IsNullOrEmpty(str.Trim()))
                    {
                        strWhere = Session["BatchProductPgswhere"].ToString();
                    }

                }
            }
            else
            {
                int classID = Core.Utils.StrToInt(this.ddl_goodtype.SelectedValue, 0);
                string strKey = this.txtKeyWord.Text;

                if (classID > 0)
                {
                    strWhere += " and ClassID=" + classID;
                }
                if (!string.IsNullOrEmpty(strKey.Trim()))
                {
                    strWhere += " and NewsTitle like '%" + strKey.Trim() + "%'";
                }

                if (!string.IsNullOrEmpty(strWhere))
                {
                    Session["BatchProductPgswhere"] = strWhere;
                }
            }

          

            int iCount = 0;
            pcPage.PageSize = 10;
            List<EbSite.Entity.NewsContent> goodList = Base.AppStartInit.NewsContentInstDefault.GetListPages(pcPage.PageIndex, pcPage.PageSize, strWhere, out iCount, 3);
            this.repData.DataSource = goodList;
            this.repData.DataBind();
            pcPage.Linktype = LinkType.Aspx;
            pcPage.AllCount = iCount;
            pcPage.OtherPram = string.Format("muid,{0}|mid,{1}|t,34|tp,{2}|cid,{3}|rn,{4}|op,{5}", "e3d7ac92-bd84-4e54-8bbd-797d327cc74f", "cfccc599-4585-43ed-ba31-fdb50024714b", IdType, PromoID, "", OpTypeID);

            //pcPage.OtherPram = string.Format("muid,{0}|mid,{1}|t,34|tp,{2}|id,{3}", "e3d7ac92-bd84-4e54-8bbd-797d327cc74f", "cfccc599-4585-43ed-ba31-fdb50024714b", IdType, PromoID);
        }
        //protected void repData_ItemDataBound(object sender, RepeaterItemEventArgs e)
        //{
        //    Image img = (Image)e.Item.FindControl("imgGoodPic");
        //    List<ModuleCore.Entity.ProductsImg> imgList = ModuleCore.BLL.ProductsImg.Instance.GetListArray("productID=" + img.ToolTip);
        //    if (imgList != null && imgList.Count > 0)
        //    {
        //        img.ImageUrl = imgList[0].BigImg;
        //    }
        //    else
        //    {
        //        img.ImageUrl = "/themes/shop/data/Upload/other/nopic.gif";
        //    }
        //}
    }
}