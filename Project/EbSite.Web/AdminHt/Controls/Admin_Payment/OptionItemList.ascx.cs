using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.ControlPage;
using EbSite.Base.Modules;

namespace EbSite.Web.AdminHt.Controls.Admin_Payment
{
    public partial class OptionItemList : UserControlListBase
    {
        public override string PageName
        {
            get
            {
                return "选项内容列表";
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
                return "58";
            }
        }
        /// <summary>
        /// 添加
        /// </summary>
        public override string PermissionAddID
        {
            get
            {
                return "57";
            }
        }
        
        /// <summary>
        /// 删除
        /// </summary>
        public override string PermissionDelID
        {
            get
            {
                return "60";
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
                return new Guid("73e4494a-7e2f-40ed-919a-1ef4f5a0a0f6");
            }
        }
        override protected string AddUrl
        {
            get
            {
                return "t=57";
            }
        }
        override protected string ShowUrl
        {
            get
            {
                return "t=1";
            }
        }
        public string OpenUrl
        {
            get
            {
                int pid = 0;
                if (Request.Params["id"] != null)
                {
                    pid = Core.Utils.StrToInt(Request.Params["id"].ToString());
                }
                return string.Format("Admin_Payment.aspx?t=57&id=" + pid);
            }
        }
        override protected object LoadList(out int iCount)
        {
            iCount = 0;
            return null;
        }
        /// <summary>
        /// 重写简单查询条件
        /// </summary>
        override protected SearchParameter[] GetSearchParameters
        {
            get
            {
                List<SearchParameter> lstSp = new List<SearchParameter>();
                SearchParameter spModel = new SearchParameter();

                return lstSp.ToArray();
            }
        }
        override protected object SearchList(out int iCount)
        {
            return EbSite.BLL.OrderOptionItems.Instance.GetListPages(pcPage.PageIndex, pcPage.PageSize, base.GetWhere(true), "", out iCount);
        }
        override protected void Delete(object iID)
        {
            EbSite.BLL.OrderOptionItems.Instance.Delete(int.Parse(iID.ToString()));
        }

        #region  工具栏的初始化

        override protected void BindToolBar()
        {
            base.BindToolBar(true, true, true, true, true);
        }

        #endregion 工具栏的初始化

        protected void Page_Load(object sender, EventArgs e)
        {
            int pid = 0;
            if (Request.Params["id"] != null)
            {
                pid = Core.Utils.StrToInt(Request.Params["id"].ToString());
            }
            List<EbSite.Entity.OrderOptionItems> ls = EbSite.BLL.OrderOptionItems.Instance.GetListArray("OrderOptionID=" + pid);
            if (ls != null&&ls.Count>0)
            {
                this.gdList.DataSource = ls;
                this.gdList.DataBind();
            }
        }
    }
}