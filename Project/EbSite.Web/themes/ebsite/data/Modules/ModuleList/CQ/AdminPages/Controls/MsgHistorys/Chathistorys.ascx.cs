using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.Modules;

namespace EbSite.Modules.CQ.AdminPages.Controls.MsgHistorys
{
    public partial class Chathistorys : MPUCBaseList
    {
        public override Guid ModuleMenuID
        {
            get
            {
                return new Guid("9191e187-c334-48e3-b444-6ecc1ee99c78");
            }
        }
        public override string PageName
        {
            get
            {
                return "聊天记录";
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
        public override int OrderID
        {
            get
            {
                return 13;
            }
        }
        public override string Permission
        {
            get
            {
                return "21";
            }
        }
        public override string PermissionAddID
        {
            get
            {
                return "21";
            }
        }

        /// <summary>
        /// 修改数据的权限ID
        /// </summary>
        public override string PermissionModifyID
        {
            get
            {
                return "21";
            }
        }
        /// <summary>
        /// 删除数据的权限ID
        /// </summary>
        public override string PermissionDelID
        {
            get
            {
                return "21";
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
            string strWhere = "";
            if (Request.Params["u"] != null)
            {
                strWhere =string.Format("SalerUserID={0}",Request.Params["u"]);
            }
            return EbSite.BLL.Tool_ChatList.Instance.GetListPages(pcPage.PageIndex, pcPage.PageSize, strWhere, "id", out iCount);
        }

        override protected object SearchList(out int iCount)
        {
            string strWhere = "";
            if (Request.Params["u"] != null)
            {
                strWhere = string.Format("SalerUserID={0}", Request.Params["u"]);
            }
            string strSta = ucToolBar.GetItemVal(staDate);
            string strEnd = ucToolBar.GetItemVal(endDate);
            if (!string.IsNullOrEmpty(strSta))
            {
                if (string.IsNullOrEmpty(strEnd))
                {
                    strEnd = DateTime.Now.ToString();
                }
                //组合字符串
                if (string.IsNullOrEmpty(strWhere))
                {
                    strWhere = string.Format("DateTime between '{0}' and '{1}'", strSta, strEnd);
                }
                else
                {
                    strWhere += string.Format(" and DateTime between '{0}' and '{1}'", strSta, strEnd);
                }
            }
            return EbSite.BLL.Tool_ChatList.Instance.GetListPages(pcPage.PageIndex, pcPage.PageSize, strWhere, "id", out iCount);
        }
        override protected void Delete(object iID)
        {
            EbSite.BLL.Tool_ChatList.Instance.Delete(int.Parse(iID.ToString()));
        }
        
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected System.Web.UI.WebControls.Label startLab = new Label();
        protected System.Web.UI.WebControls.Label endLab = new Label();
        protected EbSite.Control.DatePicker staDate = new EbSite.Control.DatePicker();
        protected EbSite.Control.DatePicker endDate = new EbSite.Control.DatePicker();
        override protected void BindToolBar()
        {
            ucToolBar.AddBnt("全选", string.Concat(IISPath, "images/Menus/Search-Add.gif"), "", false, "checkall()", "全选");
            base.BindToolBar(true, false, false, false,false);

            startLab.ID = "startLab";
            startLab.Text = "开始日期";
            endLab.ID = "endLab";
            endLab.Text = "结束日期";

            staDate.ID = "startDate";
            staDate.Width = 100;
            endDate.ID = "endDate";
            endDate.Width = 100;
            //if (!base.IsPostBack)
            //{
            //    staDate.Text = DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd");
            //    endDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
            //}
            ucToolBar.AddCtr(startLab);
            ucToolBar.AddCtr(staDate);
            ucToolBar.AddCtr(endLab);
            ucToolBar.AddCtr(endDate);

            ucToolBar.AddBnt("查询", string.Concat(IISPath, "images/Menus/Search.gif"), "search");
        }
    }
}