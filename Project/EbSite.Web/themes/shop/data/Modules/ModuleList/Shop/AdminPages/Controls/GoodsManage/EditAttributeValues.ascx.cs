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
    public partial class EditAttributeValues : MPUCBaseList
    {

        public override string PageName
        {
            get
            {
                return "编辑扩展属性";
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
                return new Guid("f5bd0aeb-0a53-4121-908c-555d4401181c");
            }
        }
        override protected string AddUrl
        {
            get
            {
                return "t=7&pid=" + AttributeId;
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
                return Core.Utils.StrToInt( Request.QueryString["attributeid"],0);
            }
        }
        override protected object LoadList(out int iCount)
        {
            return ModuleCore.BLL.TypeNameValues.Instance.GetListPages(pcPage.PageIndex, iPageSize, "TypeNameValueID=" + AttributeId,"", out iCount);
        }
        
        override protected object SearchList(out int iCount)
        {
            return ModuleCore.BLL.TypeNameValues.Instance.GetListPages(pcPage.PageIndex, pcPage.PageSize, base.GetWhere(true), "", out iCount);
        }
        override protected void Delete(object iID)
        {
            ModuleCore.BLL.TypeNameValues.Instance.Delete(int.Parse(iID.ToString()));
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
                    ModuleCore.Entity.TypeNameValue md = ModuleCore.BLL.TypeNameValue.Instance.GetEntity(AttributeId);
                
                     string sUrl = "GoodsManage.aspx?muid=e8b2cdd7-4299-497b-9215-a94e8c3a6c88&mid=cfccc599-4585-43ed-ba31-fdb50024714b";
                     Response.Redirect(sUrl+"&t=5&tid="+md.TypeNameID);//t=5
                    break; 
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}