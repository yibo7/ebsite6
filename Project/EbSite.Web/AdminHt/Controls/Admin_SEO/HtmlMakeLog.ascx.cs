using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.ControlPage;

namespace EbSite.Web.AdminHt.Controls.Admin_SEO
{
    public partial class HtmlMakeLog : UserControlListBase
    {
        #region 权限

        public override string Permission
        {
            get
            {
                return "282";
            }
        }
        /// <summary>
        /// 删除数据的权限ID
        /// </summary>
        public override string PermissionDelID
        {
            get
            {
                return "282";
            }
        }

        #endregion

        override protected string AddUrl
        {
            get
            {
                return "";
            }
        }
        override protected object LoadList(out int iCount)
        {

            return BLL.HTMLLog.GetListPages(pcPage.PageIndex, pcPage.PageSize, out iCount);

        }


        override protected object SearchList(out int iCount)
        {
            throw new NotImplementedException();
        }
        override protected void Delete(object iID)
        {
            int id = int.Parse(iID.ToString());
            BLL.HTMLLog.DeleteLogs(id);

        }

        #region 工具栏的初始化
        //protected System.Web.UI.WebControls.TextBox txtKeyWord = new System.Web.UI.WebControls.TextBox();
        //protected System.Web.UI.WebControls.DropDownList drpSearchTp = new System.Web.UI.WebControls.DropDownList();
        //protected System.Web.UI.WebControls.DropDownList drpLike = new System.Web.UI.WebControls.DropDownList();
        override protected void BindToolBar()
        {

            base.BindToolBar();
            
            ucToolBar.AddBnt("清空所有日志", string.Concat(IISPath, "images/Menus/ie.png"), "clearlog", "确认要清空所有所有生成错误日志吗？");


        }
        #endregion

        #region 工具栏事件扩展

        protected override void ucToolBar_ItemClick(object source, Control.ItemClickArgs e)
        {
            base.ucToolBar_ItemClick(source, e);
            switch (e.ItemTag)
            {
                case "remake": //重新生成

                    break;
                case "clearlog": //清空所有日志
                    BLL.HTMLLog.DeleteAll();
                    gdList_Bind();
                    break;
            }
        }

        #endregion
    }
}