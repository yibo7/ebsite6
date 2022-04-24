using System;
using System.Collections;
using System.Configuration;
using System.Data;

using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using EbSite.Base.ControlPage;


namespace EbSite.Web.AdminHt.Controls.Admin_Log
{
    public partial class AppErrLog : UserControlListBase
    {

        #region 权限

        public override string Permission
        {
            get
            {
                return "164";
            }
        }
        /// <summary>
        /// 删除数据的权限ID
        /// </summary>
        public override string PermissionDelID
        {
            get
            {
                return "232";
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
            return BLL.AppErrLog.GetListPages(pcPage.PageIndex, pcPage.PageSize, out iCount);
        }


        override protected object SearchList(out int iCount)
        {
            throw new NotImplementedException();
        }
        override protected void Delete(object iID)
        {
            int id = int.Parse(iID.ToString());
            BLL.AppErrLog.DeleteLogs(id);

        }

        #region 工具栏的初始化
        //protected System.Web.UI.WebControls.TextBox txtKeyWord = new System.Web.UI.WebControls.TextBox();
        //protected System.Web.UI.WebControls.DropDownList drpSearchTp = new System.Web.UI.WebControls.DropDownList();
        //protected System.Web.UI.WebControls.DropDownList drpLike = new System.Web.UI.WebControls.DropDownList();
        override protected void BindToolBar()
        {

            base.BindToolBar();

            ucToolBar.AddBnt("清空所有日志", string.Concat(IISPath, "images/Menus/ie.png"), "clearlog", "确认要清空所有所有系统异常日志吗？");


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
                    BLL.AppErrLog.DeleteAll();
                    gdList_Bind();
                    break;
            }
        }

        #endregion

        //protected void Page_Load(object sender, EventArgs e)
        //{
        //    if (!IsPostBack)
        //    {
        //        BindData();
        //    }
        //}
        //private void BindData()
        //{
        //    gvLogs.DataSource = BLL.AppErrLog.FillLogs();
        //    gvLogs.DataBind();
        //}
        //protected void gvLogs_PageIndexChanging(object sender, GridViewPageEventArgs e)
        //{
        //    gvLogs.PageIndex = e.NewPageIndex;
        //    BindData();

        //}
        //protected void gvLogs_RowCommand(object sender, GridViewCommandEventArgs e)
        //{
        //    if (Equals(e.CommandName, "showinfo"))
        //    {
        //        string id = e.CommandArgument.ToString();
        //        Response.Redirect("Admin_Log.aspx?mat=3&id=" + id);

        //    }
        //}
    }
}