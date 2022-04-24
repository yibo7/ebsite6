using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.ControlPage;
using EbSite.Base.Modules;

namespace EbSite.Modules.Shop.AdminPages.Controls.GoodsManage
{
    public partial class GoodsType : MPUCBaseList
    {
        public override string PageName
        {
            get
            {
                return "商品类型";
            }
        }
        protected override Guid MenuAddID
        {
            get
            {
                return new Guid("e8b2cdd7-4299-497b-9215-a94e8c3a6c88");
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
                return "1";
            }
        }
        /// <summary>
        /// 添加
        /// </summary>
        public override string PermissionAddID
        {
            get
            {
                return "2";
            }
        }
        /// <summary>
        /// 修改
        /// </summary>
        public override string PermissionModifyID
        {
            get
            {
                return "3";
            }
        }
        /// <summary>
        /// 删除
        /// </summary>
        public override string PermissionDelID
        {
            get
            {
                return "4";
            }
        }

        public override int OrderID
        {
            get
            {
                return 1;
            }
        }
        /// <summary>
        /// 菜单ID
        /// </summary>
        public override Guid ModuleMenuID
        {
            get
            {
                return new Guid("ddc7379d-89b7-4f48-b553-f34887a85524");
            }
        }
        override protected string AddUrl
        {
            get
            {
                return "t=4";
            }
        }
        override protected string ShowUrl
        {
            get
            {
                return "t=1";
            }
        }
        override protected object LoadList(out int iCount)
        {
            return ModuleCore.BLL.TypeNames.Instance.GetListPages(pcPage.PageIndex, iPageSize, out iCount);

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


                spModel.ColumnName = "TypeName";
                spModel.ColumnValue = ucToolBar.GetItemVal(ProductName);
                spModel.IsString = true;
                spModel.SearchWhere = EmSearchWhere.模糊匹配;
                lstSp.Add(spModel);


                return lstSp.ToArray();
            }
        }
        override protected object SearchList(out int iCount)
        {
            return ModuleCore.BLL.TypeNames.Instance.GetListPages(pcPage.PageIndex, pcPage.PageSize, base.GetWhere(true), "", out iCount);
        }
        override protected void Delete(object iID)
        {
            ModuleCore.BLL.TypeNames.Instance.Delete(int.Parse(iID.ToString()));
            //删除 属性
            string attributeids = "";
            List<ModuleCore.Entity.TypeNameValue> ls_1 = ModuleCore.BLL.TypeNameValue.Instance.GetListArray(0, "TypeNameId=" + iID, "");
            foreach (var typeNameValue in ls_1)
            {
                attributeids += typeNameValue.id + ",";
                ModuleCore.BLL.TypeNameValue.Instance.Delete(typeNameValue.id);
            }
            if (attributeids.Length > 0)
            {
                attributeids = attributeids.Remove(attributeids.Length - 1, 1);
            }
            if (attributeids.Length > 0)
            {
                List<ModuleCore.Entity.TypeNameValues> ls_11 = ModuleCore.BLL.TypeNameValues.Instance.GetListArray(0,"TypeNameValueID in(" +attributeids +")","");
                foreach (var typeNameValuese in ls_11)
                {
                    ModuleCore.BLL.TypeNameValues.Instance.Delete(typeNameValuese.id);
                }

            }
            //删除 规格
            string skus = "";
            List<ModuleCore.Entity.Norms> ls_2 = ModuleCore.BLL.Norms.Instance.GetListArray(0, "TypeNameId=" + iID, "");
            foreach (var typeNameValue in ls_2)
            {
                skus += typeNameValue.id + ",";
                ModuleCore.BLL.Norms.Instance.Delete(typeNameValue.id);
            }
            if (skus.Length > 0)
            {
                skus = skus.Remove(skus.Length - 1, 1);
            }
            if (skus.Length > 0)
            {
                List<ModuleCore.Entity.NormsValue> ls_22 = ModuleCore.BLL.NormsValue.Instance.GetListArray(0,"normid in(" +skus + ")","");
                foreach (var typeNameValuese in ls_22)
                {
                    ModuleCore.BLL.NormsValue.Instance.Delete(typeNameValuese.id);
                }
            }
        }
        #region  工具栏的初始化
        protected System.Web.UI.WebControls.Label LbName = new Label();
        protected System.Web.UI.WebControls.TextBox ProductName = new TextBox();
        override protected void BindToolBar()
        {
            base.BindToolBar();
            ucToolBar.AddLine();
            LbName.ID = "LbName";
            LbName.Text = "类型名称";
            ucToolBar.AddCtr(LbName);
            ProductName.ID = "TypeName";
            ProductName.Attributes.Add("style", "width:90px");
            ucToolBar.AddCtr(ProductName);
            base.ShowCustomSearch("查询");
        }
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}