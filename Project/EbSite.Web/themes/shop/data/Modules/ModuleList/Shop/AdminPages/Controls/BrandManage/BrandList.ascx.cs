using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.ControlPage;
using EbSite.Base.Modules;

namespace EbSite.Modules.Shop.AdminPages.Controls.BrandManage
{
    public partial class BrandList : MPUCBaseList
    {
        public override string PageName
        {
            get
            {
                return "品牌管理";
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
                return "37";
            }
        }
        /// <summary>
        /// 添加
        /// </summary>
        public override string PermissionAddID
        {
            get
            {
                return "38";
            }
        }
        /// <summary>
        /// 修改
        /// </summary>
        public override string PermissionModifyID
        {
            get
            {
                return "39";
            }
        }
        /// <summary>
        /// 删除
        /// </summary>
        public override string PermissionDelID
        {
            get
            {
                return "40";
            }
        }

        public override int OrderID
        {
            get
            {
                return 2;
            }
        }
        /// <summary>
        /// 菜单ID
        /// </summary>
        public override Guid ModuleMenuID
        {
            get
            {
                return new Guid("9f7358b1-d95d-495d-aee7-1d6ab33c34dc");
            }
        }
        override protected string AddUrl
        {
            get
            {
                return "t=0";
            }
        }

        override protected object LoadList(out int iCount)
        {
            iCount = 0;
            return ModuleCore.BLL.GoodsBrand.Instance.GetListPages(pcPage.PageIndex, pcPage.PageSize, out iCount);
        }

        override protected object SearchList(out int iCount)
        {
            iCount = 0;
            return null;
        }
        override protected void Delete(object iID)
        {
            //检查 有没有 占用
            bool key = true;
            List<ModuleCore.Entity.TypeNames> ls = ModuleCore.BLL.TypeNames.Instance.GetListArray("");
            foreach (var typeNamese in ls)
            {
                string[] a = typeNamese.BrandIDs.Split(',');
                foreach (var s in a)
                {
                    if (iID.ToString() == s)
                    {
                        key = false;
                        break;
                    }
                }
                break;
            }
            if (key)
            {
                ModuleCore.BLL.GoodsBrand.Instance.Delete(int.Parse(iID.ToString()));
            }
            else
            {
                base.TipsAlert("占用，不能删除！");
            }


        }
        #region  工具栏的初始化

        override protected void BindToolBar()
        {
            base.BindToolBar(false, false, true, true, true);

            //base.ShowCustomSearch("查询");
        }
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}