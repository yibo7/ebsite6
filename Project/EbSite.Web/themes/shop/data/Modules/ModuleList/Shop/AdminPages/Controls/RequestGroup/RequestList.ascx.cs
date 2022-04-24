using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.Modules;

namespace EbSite.Modules.Shop.AdminPages.Controls.RequestGroup
{
    public partial class RequestList : MPUCBaseList
    {
        public override string PageName
        {
            get
            {
                return "求团购";
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
                return "99";
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
                return new Guid("cb8aab9e-3934-45ac-a278-16ee6a6d3d9a");
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
            return ModuleCore.BLL.requestgroup.Instance.GetListPages(pcPage.PageIndex, iPageSize,"isnotice=0 group by productid","", out iCount);
        }
        override protected object SearchList(out int iCount)
        {
            string key = ucToolBar.GetItemVal(ProductName);
            if (!string.IsNullOrEmpty(key))
            {
                return ModuleCore.BLL.requestgroup.Instance.GetListPages(pcPage.PageIndex, iPageSize," b.NewsTitle like '%" +key + "%' ", "", out iCount);
            }
            else
            {
                iCount = 0;
                return null;
            }
        }
        override protected void Delete(object iID)
        {
            
        }

        #region  工具栏的初始化
        protected System.Web.UI.WebControls.Label LbName = new Label();
        protected System.Web.UI.WebControls.TextBox ProductName = new TextBox();
        override protected void BindToolBar()
        {
            base.BindToolBar(true,true,false,false,false);
            //ucToolBar.AddLine();
            //LbName.ID = "LbName";
            //LbName.Text = "商品名称";
            //ucToolBar.AddCtr(LbName);
            //ProductName.ID = "ProductName";
            //ProductName.Attributes.Add("style", "width:90px");
            //ucToolBar.AddCtr(ProductName);
            //base.ShowCustomSearch("查询");
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected string GetProductName(string id)
        {
            EbSite.Entity.NewsContent md = Base.AppStartInit.NewsContentInstDefault.GetModel(int.Parse(id),GetSiteID);
            if (md != null)
            {
                return md.NewsTitle;
            }
            else
            {
                return "";
            }
        }
    }
}