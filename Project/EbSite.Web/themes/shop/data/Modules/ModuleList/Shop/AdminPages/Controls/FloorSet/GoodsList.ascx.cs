using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.Modules;

namespace EbSite.Modules.Shop.AdminPages.Controls.FloorSet
{
    public partial class GoodsList : MPUCBaseList
    {
        public override string PageName
        {
            get
            {
                return "楼层商品列表";
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
                return "95";
            }
        }
        /// <summary>
        /// 添加
        /// </summary>
        public override string PermissionAddID
        {
            get
            {
                return "96";
            }
        }
        /// <summary>
        /// 修改
        /// </summary>
        public override string PermissionModifyID
        {
            get
            {
                return "97";
            }
        }
        /// <summary>
        /// 删除
        /// </summary>
        public override string PermissionDelID
        {
            get
            {
                return "98";
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
                return new Guid("bc16a27f-00f0-4416-a639-6daae444ea10");
            }
        }
        override protected string AddUrl
        {
            get
            {
                return "t=12&fid="+Request.Params["fid"];
            }
        }
        override protected string ShowUrl
        {
            get
            {
                return "t=1";
            }
        }
        protected int fid
        {
            get
            {
                return Core.Utils.StrToInt(Request.Params["fid"], 0);
            }
        }
        override protected object LoadList(out int iCount)
        {
            iCount = 0;
            List<ModuleCore.Entity.FloorProducts> ls = ModuleCore.BLL.FloorProductsInfo.Instance.FillList();
            List<ModuleCore.Entity.FloorProducts> nls = (from i in ls where i.FloorSetId == fid select i).ToList();

            if (nls != null && nls.Count>0)
            {
                ModuleCore.Entity.FloorProducts md = nls[0];
                List<EbSite.Entity.NewsContent> mdList = Base.AppStartInit.NewsContentInstDefault.GetListArray(string.Format("id in({0})", md.ProductIds), 0, "id", "", ModuleSiteID);
                if (mdList != null && mdList.Count > 0)
                {
                    iCount = mdList.Count;
                    return mdList;
                }
            }

            return null;
        }
       
        override protected object SearchList(out int iCount)
        {
            iCount = 0;
            return null;
        }
        override protected void Delete(object iID)
        {
            ModuleCore.BLL.FloorProductsInfo.Instance.Delete(int.Parse(iID.ToString()));
        }
        #region  工具栏的初始化
      
        override protected void BindToolBar()
        {
            base.BindToolBar(false,true,true,true,true);
           
        }
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {

        }
       
    }
}