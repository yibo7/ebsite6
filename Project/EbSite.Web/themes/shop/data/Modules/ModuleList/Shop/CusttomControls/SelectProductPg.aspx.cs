using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.Configs.SysConfigs;
using EbSite.Base.Modules;
using EbSite.Base.Page;

namespace EbSite.Modules.Shop.CusttomControls
{
    public partial class SelectProductPg : BasePage
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //查询出商品列表
                BindData();


                //绑定商品分类
                //List<EbSite.Entity.NewsClass> classList = EbSite.BLL.NewsClass.GetContentClassesTree(SettingInfo.Instance.GetSiteID);
               // List<EbSite.Entity.NewsClass> classList = EbSite.BLL.NewsClass.GetModelIdParentClass(0, "", "", SettingInfo.Instance.GetSiteID, new Guid( "cfd5666c-0bd5-4beb-884b-75d23e7ca158"));
                List<EbSite.Entity.NewsClass> classList = EbSite.BLL.NewsClass.GetTreeModelID(0, SettingInfo.Instance.GetSiteID,
                                                                                                 new Guid(
                                                                                                     "cfd5666c-0bd5-4beb-884b-75d23e7ca158"));//EbSite.BLL.NewsClass.GetContentClassesTree(SettingInfo.Instance.GetSiteID);
            
                if (classList != null && classList.Count > 0)
                {
                    //cfd5666c-0bd5-4beb-884b-75d23e7ca158 是 模型管理-分类模型 商品分类 guid
                    //List<EbSite.Entity.NewsClass> nlist =
                    //   (from i in classList where i.Annex9 == "1" select i).ToList();
                    this.ddl_goodtype.DataSource = classList;
                    
                    this.ddl_goodtype.DataTextField = "ClassName";
                    this.ddl_goodtype.DataValueField = "ID";
                    this.ddl_goodtype.DataBind();
                    this.ddl_goodtype.Items.Insert(0, new ListItem("--请选择分类--", "0"));
                }
            }
        }
        protected void btnSearch_OnClick(object sender, EventArgs e)
        {
          //  Session["selectproductpgswhere"] = "";
            pcPage.PageIndex = 1;
            BindData();
        }


        //是否调不含有商品规格的商品 1:
        public bool IsNorms
        {
            get
            {
                if (Request.Params["isnor"] != null)
                {
                    return bool.Parse(Request.Params["isnor"].ToString());
                }
                return false; //全部
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
                return Core.Utils.GetQueryInt("id", 0);
            }
        }
        private void BindData()
        {
            string strWhere = " annex25=1";

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
            if (IsNorms)
            {
                strWhere += " and annex22=0 ";
            }
            //if (!Equals(Session["selectproductpgswhere"], null))
            //{
            //    if (string.IsNullOrEmpty(Session["selectproductpgswhere"].ToString()))
            //    {


            //        int classID = Core.Utils.StrToInt(this.ddl_goodtype.SelectedValue, 0);
            //        string strKey = this.txtKeyWord.Text;

            //        if (classID > 0)
            //        {
            //            strWhere += " and ClassID=" + classID;
            //        }
            //        if (!string.IsNullOrEmpty(strKey.Trim()))
            //        {
            //            strWhere += " and NewsTitle like '%" + strKey.Trim() + "%'";
            //        }
            //        if (IsNorms)
            //        {
            //            strWhere += " and annex22=0 ";
            //        }
            //        if (!string.IsNullOrEmpty(strWhere))
            //        {
            //            Session["selectproductpgswhere"] = strWhere;
            //        }
            //    }
            //    else
            //    {
            //        string str = Session["selectproductpgswhere"] as string;
            //        if (!string.IsNullOrEmpty(str.Trim()))
            //        {
            //            strWhere = Session["selectproductpgswhere"].ToString();
            //        }

            //    }
            //}
            //else
            //{
            //    int classID = Core.Utils.StrToInt(this.ddl_goodtype.SelectedValue, 0);
            //    string strKey = this.txtKeyWord.Text;

            //    if (classID > 0)
            //    {
            //        strWhere += " and ClassID=" + classID;
            //    }
            //    if (!string.IsNullOrEmpty(strKey.Trim()))
            //    {
            //        strWhere += " and NewsTitle like '%" + strKey.Trim() + "%'";
            //    }
            //    if (IsNorms)
            //    {
            //        strWhere += " and annex22=0 ";
            //    }
            //    if (!string.IsNullOrEmpty(strWhere))
            //    {
            //        Session["selectproductpgswhere"] = strWhere;
            //    }
            //}
            int iCount = 0;
            pcPage.PageSize = 5;

            List<EbSite.Entity.NewsContent> goodList = Base.AppStartInit.NewsContentInstDefault.GetListPages(pcPage.PageIndex, pcPage.PageSize, strWhere, out iCount, SettingInfo.Instance.GetSiteID);
            this.repData.DataSource = goodList;
            this.repData.DataBind();
            pcPage.Linktype = LinkType.Aspx;
            pcPage.AllCount = iCount;
            //pcPage.OtherPram = string.Format("muid,{0}|mid,{1}|t,34|tp,{2}|id,{3}", "e3d7ac92-bd84-4e54-8bbd-797d327cc74f", "cfccc599-4585-43ed-ba31-fdb50024714b", IdType, PromoID);

            pcPage.OtherPram = string.Format("muid,{0}|mid,{1}|t,34|tp,{2}|id,{3}|rn,{4}|ids,{5}|isnor,{6}", "e3d7ac92-bd84-4e54-8bbd-797d327cc74f", "cfccc599-4585-43ed-ba31-fdb50024714b", IdType, PromoID, Request.QueryString["rn"], Request.QueryString["ids"], IsNorms);

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