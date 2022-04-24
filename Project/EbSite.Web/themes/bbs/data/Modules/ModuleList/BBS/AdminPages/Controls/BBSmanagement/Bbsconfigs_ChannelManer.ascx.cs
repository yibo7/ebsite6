using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.ControlPage;
using EbSite.Base.Modules;


namespace EbSite.Modules.BBS.AdminPages.Controls.BBSmanagement
{
    public partial class Bbsconfigs_ChannelManer : MPUCBaseList
    {
        public override int OrderID
        {
            get
            {
                return 2;
            }
        }
        public override string PageName
        {
            get
            {
                return "版主管理";
            }
        }
        public override Guid ModuleMenuID
        {
            get
            {
                return new Guid("ecfc84c1-bbb4-40bd-abe3-cfa1dceb0118");
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
        #region 权限
        public override string Permission
        {
            get
            {
                return "13";
            }
        }
        public override string PermissionAddID
        {
            get
            {
                return "14";
            }
        }
        /// <summary>
        /// 修改数据的权限ID
        /// </summary>
        public override string PermissionModifyID
        {
            get
            {
                return "15";
            }
        }
        /// <summary>
        /// 删除数据的权限ID
        /// </summary>
        public override string PermissionDelID
        {
            get
            {
                return "16";
            }
        }
        #endregion
        override protected string AddUrl
        {
            get
            {
                return "t=9";
            }
        }
        protected Label label = new Label();
        protected TextBox txtOne = new TextBox();
        protected override void BindToolBar()
        {
            base.BindToolBar(false, false, true, true, false);
            label.ID = "lblOne";
            label.Text = " 版主名 ";
            ucToolBar.AddCtr(label); txtOne.ID = "Name";
            ucToolBar.AddCtr(txtOne);
            base.ShowCustomSearch("查询");
        }
        override protected object LoadList(out int iCount)
        {
            return ModuleCore.BLL.ChannelMasters.Instance.GetListPagesCache(pcPage.PageIndex, pcPage.PageSize, "", "", "", out iCount);
        }

        override protected object SearchList(out int iCount)
        {
            return ModuleCore.BLL.ChannelMasters.Instance.GetListPages(pcPage.PageIndex, pcPage.PageSize, base.GetWhere(true).Trim(), "", out iCount);
        }

        override protected SearchParameter[] GetSearchParameters
        {
            get
            {
                List<SearchParameter> lstSp = new List<SearchParameter>();
                SearchParameter spModel = new SearchParameter();
                spModel.ColumnName = "UserName";
                spModel.ColumnValue = ucToolBar.GetItemVal(txtOne);
                spModel.IsString = true;
                spModel.SearchLink = EmSearchLink.不连用于最后一个;
                spModel.SearchWhere = EmSearchWhere.模糊匹配;
                lstSp.Add(spModel);
                return lstSp.ToArray();
            }
        }
        override protected void Delete(object iID)
        {

            ModuleCore.BLL.ChannelMasters.Instance.Delete(int.Parse(iID.ToString()));
        }
       

        //protected string newurl()
        //{
        //    string starturl = HttpContext.Current.Request.Url.AbsolutePath;
        //    string pid = Convert.ToString(base.MenuID);
        //    string sid = Convert.ToString(base.ModuleID);
        //    string path = starturl + "?muid=" + pid + "&mid=" + sid;
        //    return path;
        //}
    }
}