using System;
using System.Web.UI.WebControls;
using EbSite.Base.ControlPage;
using EbSite.Entity;


namespace EbSite.Web.AdminHt.Controls.Admin_Log
{
    public partial class AdminLogInLog : UserControlListBase
    {

        #region 权限

        public override string Permission
        {
            get
            {
                return "163";
            }
        }
        /// <summary>
        /// 删除数据的权限ID
        /// </summary>
        public override string PermissionDelID
        {
            get
            {
                return "163";
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
            return BLL.AdminLoginLog.GetListPages(pcPage.PageIndex, pcPage.PageSize, out iCount);
        }


        override protected object SearchList(out int iCount)
        {
            throw new NotImplementedException();
        }

        override protected void Delete(object iID)
        {
            int id = int.Parse(iID.ToString());
            BLL.AdminLoginLog.DeleteLogs(id);
            
        }

        public string GetIPAndAear(string ip)
        {
            return ip;
           ClientIpInfo md =   HostApi.GetAreaByIP(ip);
            if (!Equals(md, null))
                return string.Concat(ip, "<font color=red>--来自:", md.Country, md.Province, md.City,"</font>");
            else
                return ip;

        }
        #region 工具栏的初始化
        //protected System.Web.UI.WebControls.TextBox txtKeyWord = new System.Web.UI.WebControls.TextBox();
        //protected System.Web.UI.WebControls.DropDownList drpSearchTp = new System.Web.UI.WebControls.DropDownList();
        //protected System.Web.UI.WebControls.DropDownList drpLike = new System.Web.UI.WebControls.DropDownList();
        override protected void BindToolBar()
        {

            base.BindToolBar();

            ucToolBar.AddBnt("清空所有日志", string.Concat(IISPath, "images/Menus/ie.png"), "clearlog", "确认要清空所有管理员登录日志吗？");


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
                    BLL.AdminLoginLog.DeleteAll();
                    gdList_Bind();
                    break;
            }
        }

        #endregion

        //protected void Page_Load(object sender, EventArgs e)
        //{
        //    if(!IsPostBack)
        //    {
        //        BindData();
        //    }
        //}
        //private void BindData()
        //{
        //    gvLogs.DataSource = BLL.AdminLoginLog.FillLogs();
        //    gvLogs.DataBind();
        //}
        //protected void gvLogs_PageIndexChanging(object sender, GridViewPageEventArgs e)
        //{
        //    gvLogs.PageIndex = e.NewPageIndex;
        //    BindData();

        //}
    }
}