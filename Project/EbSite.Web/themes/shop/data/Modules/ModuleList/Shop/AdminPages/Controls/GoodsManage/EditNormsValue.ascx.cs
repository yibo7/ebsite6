using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.Modules;

namespace EbSite.Modules.Shop.AdminPages.Controls.GoodsManage
{
    public partial class EditNormsValue : MPUCBaseList
    {
        public override string PageName
        {
            get
            {
                return "编辑规格值";
            }
        }
        /// <summary>
        /// 是否添加到管理页面菜单之中
        /// </summary>
        public override bool IsAddToAdminMenus
        {
            get
            {
                return false;
            }
        }
        /// <summary>
        /// 权限全部
        /// </summary>
        public override string Permission
        {
            get
            {
                return "34";
            }
        }
        /// <summary>
        /// 添加
        /// </summary>
        public override string PermissionAddID
        {
            get
            {
                return "35";
            }
        }
        /// <summary>
        /// 修改
        /// </summary>
        public override string PermissionModifyID
        {
            get
            {
                return "35";
            }
        }
        /// <summary>
        /// 删除
        /// </summary>
        public override string PermissionDelID
        {
            get
            {
                return "36";
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
                return new Guid("a720984c-6b25-418f-8df4-f2315c4e543f");
            }
        }
        override protected string AddUrl
        {
            get
            {
                if (IsImg == 0)
                {
                    return "t=11&pid=" + AttributeId;
                }
                else
                {
                    return "t=10&pid=" + AttributeId;
                }
            }
        }
        override protected string ShowUrl
        {
            get
            {
                return "t=1";
            }
        }
        private int AttributeId
        {
            get
            {
                return Core.Utils.StrToInt(Request.QueryString["attributeid"], 0);
            }
        }
        protected  int IsImg
        {
            get
            {
                return Core.Utils.StrToInt(Request.QueryString["isimg"], 0); 
            }
        }
        override protected object LoadList(out int iCount)
        {
            return ModuleCore.BLL.NormsValue.Instance.GetListPages(pcPage.PageIndex, iPageSize, "NormID=" + AttributeId, "", out iCount);
        }

        override protected object SearchList(out int iCount)
        {
            return ModuleCore.BLL.NormsValue.Instance.GetListPages(pcPage.PageIndex, pcPage.PageSize, base.GetWhere(true), "", out iCount);
        }
        override protected void Delete(object iID)
        {
            ModuleCore.BLL.NormsValue.Instance.Delete(int.Parse(iID.ToString()));
        }
        #region  工具栏的初始化

        override protected void BindToolBar()
        {
            base.BindToolBar();

            ucToolBar.AddBnt("返回", IISPath + "images/menus/Previous.gif", "putout");
        }
        #endregion


        protected override void ucToolBar_ItemClick(object source, Control.ItemClickArgs e)
        {
            base.ucToolBar_ItemClick(source, e);
            switch (e.ItemTag)
            {
                case "putout":
                   // ModuleCore.Entity.NormsValue md = ModuleCore.BLL.NormsValue.Instance.GetEntity(AttributeId);
                    ModuleCore.Entity.Norms mda = ModuleCore.BLL.Norms.Instance.GetEntity(AttributeId);
                    string sUrl = "GoodsManage.aspx?muid=e8b2cdd7-4299-497b-9215-a94e8c3a6c88&mid=cfccc599-4585-43ed-ba31-fdb50024714b";
                    Response.Redirect(sUrl + "&t=8&tid=" + mda.TypeNameID);
                    break;
            }
        }
        public string GetTitle(string NormsIco, string NormsValueName)
        {
            if(string.IsNullOrEmpty(NormsIco))
            {
                return NormsValueName;
            }
            else
            {
                return "<img src=" + NormsIco + " width=23 height=20/>";
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}