using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.Modules;

namespace EbSite.Modules.BBS.AdminPages.Controls.ImitatePost
{
    public partial class ImitatePostUser : MPUCBaseList
    {
        public override string PageName
        {
            get
            {
                return "模块发帖用户";
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
                return "2";
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
                return "2";
            }
        }
        /// <summary>
        /// 删除
        /// </summary>
        public override string PermissionDelID
        {
            get
            {
                return "2";
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

                return new Guid("8401883f-b7d3-4602-af3f-70960b4cbe84");
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
            return ModuleCore.BLL.imitateuser.Instance.GetListPages(pcPage.PageIndex, iPageSize, "", "", out iCount);
        }
        override protected object SearchList(out int iCount)
        {
            return ModuleCore.BLL.imitateuser.Instance.GetListPages(pcPage.PageIndex, pcPage.PageSize, base.GetWhere(true), "", out iCount);
        }
        override protected void Delete(object iID)
        {
            ModuleCore.BLL.imitateuser.Instance.Delete(int.Parse(iID.ToString()));
        }

        protected string CutStr(object str)
        {
            return EbSite.Core.Strings.GetString.CutLen(str.ToString(), 200);
        }

        #region  工具栏的初始化
        //override protected void BindToolBar()
        //{
        //    base.BindToolBar(true, false, true, true, true);
        //    ucToolBar.AddLine();
        //    LbName.ID = "LbName";
        //    LbName.Text = "回帖内容:";
        //    ucToolBar.AddCtr(LbName);
        //    txtkeyword.ID = "keyword";
        //    txtkeyword.Attributes.Add("style", "width:200px");
        //    ucToolBar.AddCtr(txtkeyword);
        //    base.ShowCustomSearch("查询");
        //}
        #endregion
    }
}