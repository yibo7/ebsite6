using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.Configs.SysConfigs;
using EbSite.Base.ControlPage;

namespace EbSite.Web.AdminHt.Controls.Admin_SEO
{
    public partial class SearchKey : UserControlListBase
    {
        #region 权限

        public override string Permission
        {
            get
            {
                return "273";
            }
        }
        /// <summary>
        /// 删除数据的权限ID
        /// </summary>
        public override string PermissionDelID
        {
            get
            {
                return "273";
            }
        }
        /// <summary>
        /// 添加数据的权限ID
        /// </summary>
        public override string PermissionAddID
        {
            get
            {
                return "273";
            }
        }
        /// <summary>
        /// 修改数据权限ID
        /// </summary>
        public override string PermissionModifyID
        {
            get
            {
                return "273";
            }
        }
        #endregion

        override protected string AddUrl
        {
            get
            {
                return "t=2";
            }
        }
        override protected object LoadList(out int iCount)
        {

            return BLL.searchword.Instance.GetListPages(pcPage.PageIndex, pcPage.PageSize, out iCount);
        }
        override protected object SearchList(out int iCount)
        {
            throw new NotImplementedException();
        }
        override protected void Delete(object iID)
        {
            BLL.searchword.Instance.Delete(new Guid(iID.ToString()));

        }



        #region 工具栏的初始化
        override protected void BindToolBar()
        {

            base.BindToolBar(true, false, false, false, false);
            ucToolBar.AddLine();
            if (ConfigsControl.Instance.IsAddSearchKeyword)
            {
                ucToolBar.AddBnt("关闭关键词跟踪功能", string.Concat(IISPath, "images/Menus/Overlay-del.gif"), "stop", true, "", "关闭后将不在跟踪用户搜索的关键词");
            }
            else
            {
                ucToolBar.AddBnt("开启关键词跟踪功能", string.Concat(IISPath, "images/Menus/Overlay-add.gif"), "open", true, "", "打开后将跟踪用户搜索的关键词，此功能会占用数据库资源");
            }

            ucToolBar.AddBnt("清空所有关键词", string.Concat(IISPath, "images/Menus/Delete.gif"), "delete", true, "", "清空所有关键词");


        }
        #endregion

        #region 工具栏事件扩展

        protected override void ucToolBar_ItemClick(object source, Control.ItemClickArgs e)
        {
            base.ucToolBar_ItemClick(source, e);
            switch (e.ItemTag)
            {
                case "stop":
                    ConfigsControl.Instance.IsAddSearchKeyword = false;
                    ConfigsControl.SaveConfig();
                    break;
                case "open":
                    ConfigsControl.Instance.IsAddSearchKeyword = true;
                    ConfigsControl.SaveConfig();
                    break;
                case "delete":
                    BLL.searchword.Instance.DeleteALL();
                    break;
            }

            Response.Redirect(Request.RawUrl);
        }

        #endregion

    }
}