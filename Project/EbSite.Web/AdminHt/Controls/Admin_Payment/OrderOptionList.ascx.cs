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
    public partial class OrderOptionList : UserControlListBase
    {
        public override string PageName
        {
            get
            {
                return "订单可选项";
            }
        }
        #region 权限

        public override string Permission
        {
            get
            {
                return "160";
            }
        }
        public override string PermissionAddID
        {
            get
            {
                return "159";
            }
        }
        /// <summary>
        /// 修改数据的权限ID
        /// </summary>
        public override string PermissionModifyID
        {
            get
            {
                return "230";
            }
        }
        /// <summary>
        /// 删除数据的权限ID
        /// </summary>
        public override string PermissionDelID
        {
            get
            {
                return "229";
            }
        }

        #endregion

        public override int OrderID
        {
            get
            {
                return 4;
            }
        }
       
        override protected string AddUrl
        {
            get
            {
                return "t=54";
            }
        }
        override protected string ShowUrl
        {
            get
            {
                return "t=1";
            }
        }
        override protected object LoadList(out int iCount)
        {
            return EbSite.BLL.OrderOptions.Instance.GetListPages(pcPage.PageIndex, iPageSize, out iCount);
        }
      
        override protected object SearchList(out int iCount)
        {
            iCount = 0;
            return null;
           // return ModuleCore.BLL.OrderOptions.Instance.GetListPages(pcPage.PageIndex, pcPage.PageSize, base.GetWhere(true), "", out iCount);
        }
        override protected void Delete(object iID)
        {
           BLL.OrderOptions.Instance.Delete(int.Parse(iID.ToString()));

            List<Entity.OrderOptionItems> ls = EbSite.BLL.OrderOptionItems.Instance.GetListArray(0,
                                                                                                 "OrderOptionID=" + iID,
                                                                                                 "");
            foreach (var orderOptionItemse in ls)
            {
                EbSite.BLL.OrderOptionItems.Instance.Delete(orderOptionItemse.id);
            }

        }
        #region  工具栏的初始化
      
        override protected void BindToolBar()
        {
            base.BindToolBar(false,true,false,false,false);
           
          
        }
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}