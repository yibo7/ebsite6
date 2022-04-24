using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.ControlPage;
using EbSite.Base.Modules;

namespace EbSite.Modules.Shop.AdminPages.Controls.StockAlarm
{
    public partial class ProductLog : MPUCBaseList
    {
        public override string PageName
        {
            get
            {
                return "商品进出库查询";
            }
        }
        /// <summary>
        /// 是否添加到管理页面菜单之中
        /// </summary>
        public override bool IsAddToAdminMenus
        {
            get
            {
                return true;
            }
        }
        /// <summary>
        /// 权限全部
        /// </summary>
        public override string Permission
        {
            get
            {
                return "93";
            }
        }
      
      

        public override int OrderID
        {
            get
            {
                return 3;
            }
        }
        /// <summary>
        /// 菜单ID
        /// </summary>
        public override Guid ModuleMenuID
        {
            get
            {
                return new Guid("9de5a73a-2f0a-408c-bff8-0aff8a7b3b30");
            }
        }
        override protected string AddUrl
        {
            get
            {
                return "t=0";
            }
        }
        override protected string ShowUrl
        {
            get
            {
                return "t=0";
            }
        }
        override protected object LoadList(out int iCount)
        {
            if (Request.Params["pnum"] != null)
            {
                PNumber.Text = Request.Params["pnum"];
                return ModuleCore.BLL.productlog.Instance.GetListPages(pcPage.PageIndex, pcPage.PageSize, string.Format("PNumber='{0}'", Request.Params["pnum"]), "", out iCount);
            }
            else
            {
                iCount = 0;
                return null;
            }
        }
        /// <summary>
        /// 重写简单查询条件
        /// </summary>
        override protected SearchParameter[] GetSearchParameters
        {
            get
            {
                List<SearchParameter> lstSp = new List<SearchParameter>();
                SearchParameter spModel = new SearchParameter();


                spModel.ColumnName = "商品名称";
                spModel.ColumnValue = ucToolBar.GetItemVal(PNumber);
                spModel.IsString = true;
                spModel.SearchWhere = EmSearchWhere.相等匹配;
                lstSp.Add(spModel);


                return lstSp.ToArray();
            }
        }

        protected string StrWhere = "";

        protected override object SearchList(out int iCount)
        {
            if (!string.IsNullOrEmpty(ucToolBar.GetItemVal(PNumber)))
            {
                StrWhere = string.Concat("PNumber=", "'", ucToolBar.GetItemVal(PNumber).Trim(), "'");
                return ModuleCore.BLL.productlog.Instance.GetListPages(pcPage.PageIndex, pcPage.PageSize,
                                                                       base.GetWhere(true), "", out iCount);
            }
            else
            {
                iCount = 0;
                return null;
            }
        }

        protected override string BulderSearchWhere(bool IsValueEmpytNoSearch)
        {
            return StrWhere;
        }
        override protected void Delete(object iID)
        {
          
        }
        #region  工具栏的初始化
        protected System.Web.UI.WebControls.Label LbName = new Label();
        protected System.Web.UI.WebControls.TextBox PNumber = new TextBox();
        override protected void BindToolBar()
        {
            base.BindToolBar(true,true,true,true,true);
          
            LbName.ID = "LbName";
            LbName.Text = "商品货号";
            ucToolBar.AddCtr(LbName);
            PNumber.ID = "PNumber";
            PNumber.Attributes.Add("style", "width:190px");
            ucToolBar.AddCtr(PNumber);
            base.ShowCustomSearch("查询");
        }
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected string GetProductName(object productID)
        {
            int pid = Core.Utils.ObjectToInt(productID, 0);
            if (pid > 0)
            {
                EbSite.Entity.NewsContent md = Base.AppStartInit.NewsContentInstDefault.GetModel(pid,GetSiteID);
                if (md != null)
                {
                    return md.NewsTitle;
                }
            }
            return productID.ToString();
        }
    }
}