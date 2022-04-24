using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using EbSite.Base.Extension.Manager;
using EbSite.Base.Modules;
using EbSite.Base.Plugin;

namespace EbSite.Modules.Shop.AdminPages.Controls.ExportData
{
    public abstract class ExportBase : MPUCBaseList
    {
        override protected string AddUrl
        {
            get
            {
                return "";
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
                return "63";
            }
        }
        override protected object LoadList(out int iCount)
        {
            List<ModuleCore.Entity.Buy_Orders> ls = ModuleCore.BLL.Buy_Orders.Instance.GetListPages(pcPage.PageIndex, pcPage.PageSize, "", "", out iCount);
            return ls;
        }

        override protected object SearchList(out int iCount)
        {
            List<ModuleCore.Entity.Buy_Orders> ls = ModuleCore.BLL.Buy_Orders.Instance.GetListPages(pcPage.PageIndex, pcPage.PageSize, "", "", out iCount);
            return ls;
        }
        override protected void Delete(object iID)
        {

        }
        private void BindDr()
        {
            List<ManagedExtension> lstRz1 = PluginManager.Instance.GetPluginInfoByType("IDataExport", -1);

            drType.DataSource = lstRz1;
            drType.RepeatDirection = RepeatDirection.Horizontal;
            drType.DataTextField = "Description";
            drType.DataValueField = "Name";
            drType.DataBind();
        }
        protected System.Web.UI.WebControls.Label LbName = new Label();
        protected System.Web.UI.WebControls.RadioButtonList drType = new RadioButtonList();
        override protected void BindToolBar()
        {
            base.BindToolBar(true, true, false, false, false);
            ucToolBar.AddLine();
            LbName.ID = "LbName";
            LbName.Text = "导出版本";
            ucToolBar.AddCtr(LbName);
            drType.ID = "drType";
            BindDr();
            drType.Attributes.Add("style", "margin-top:-5px;");
            ucToolBar.AddCtr(drType);
            ucToolBar.AddBnt("导出数据", string.Concat(IISPath, "images/menus/basket_put.png"), "Export", "是否要导出");
        }

        protected override void ucToolBar_ItemClick(object source, Control.ItemClickArgs e)
        {
            base.ucToolBar_ItemClick(source, e);
            switch (e.ItemTag)
            {
                case "Export":
                    string k = ucToolBar.GetItemVal(drType);
                    if (string.IsNullOrEmpty(k))
                    {
                        base.TipsAlert("请选择导出版本");
                    }
                    else
                    {
                        //IDataExport api = EbSite.Base.Plugin.Factory.GetExportApi(k);
                        List<ModuleCore.Entity.Buy_Orders> ls = ModuleCore.BLL.Buy_Orders.Instance.GetListArray(0,"","");
                        object ob = ls;
                        //string url = api.Export(ob);

                    }
                    break;

            }
        }
    }
}