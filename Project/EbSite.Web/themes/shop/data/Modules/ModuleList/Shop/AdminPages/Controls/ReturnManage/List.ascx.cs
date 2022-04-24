using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.ControlPage;
using EbSite.Base.Modules;
using System.Data;

namespace EbSite.Modules.Shop.AdminPages.Controls.StockAlarm
{
    public partial class List : MPUCBaseList
    {
        public override string PageName
        {
            get
            {
                return "退换货列表";
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
                return "94";
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
                return new Guid("36802297-bbc5-4174-9a6a-d5370879e17d");
            }
        }
        override protected string AddUrl
        {
            get
            {
                return "t=0";
            }
        }
        override protected string ShowUrl
        {
            get
            {
                return "t=0";
            }
        }
        override protected object LoadList(out int iCount)
        {
            return ModuleCore.BLL.Buy_OrderItem.Instance.GetTHOrderItem_GetListPages(pcPage.PageIndex, pcPage.PageSize,
                                                                                     out iCount,"");
        }

        override protected object SearchList(out int iCount)
        {
            return ModuleCore.BLL.Buy_OrderItem.Instance.GetTHOrderItem_GetListPages(pcPage.PageIndex, pcPage.PageSize,
                                                                                      out iCount, ucToolBar.GetItemVal(OrderNum));
        }
        override protected void Delete(object iID)
        {
            //ModuleCore.BLL.CountDownBuy.Instance.Delete(int.Parse(iID.ToString()));
        }

        #region  工具栏的初始化

        protected System.Web.UI.WebControls.Label LbName = new Label();
        protected System.Web.UI.WebControls.TextBox OrderNum = new TextBox();
        override protected void BindToolBar()
        {
            base.BindToolBar(true,true,true,true,true);
          
            LbName.ID = "LbName";
            LbName.Text = "订单编号";
            ucToolBar.AddCtr(LbName);
            OrderNum.ID = "OrderNum";
            OrderNum.Attributes.Add("style", "width:150px");
            ucToolBar.AddCtr(OrderNum);
            base.ShowCustomSearch("查询");
        }

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //DataTable dt = ModuleCore.BLL.Buy_OrderItem.Instance.GetTHOrderItemList();
                //if (dt != null && dt.Rows.Count > 0)
                //{
                //    this.gdList.DataSource = dt;
                //    this.gdList.DataBind();
                //}
            }
        }
        /// <summary>
        /// 退换货的服务类型
        /// </summary>
        /// <param name="sid"></param>
        /// <returns></returns>
        protected string GetServiceState(object sid)
        {
            int tmpSID = Core.Utils.ObjectToInt(sid, 0);
            string strResult = "<span style=\"color:#{0};font-weight:bold;\">" + (EbSite.Modules.Shop.ModuleCore.SystemEnum.ServiceType)tmpSID + "</span>";
            switch (tmpSID)
            {
                case 0:
                    strResult = string.Format(strResult, "113a45");
                    break;
                case 1:
                    strResult = string.Format(strResult, "a7a83a");
                    break;
                case 2:
                    strResult = string.Format(strResult, "44892c");
                    break;
                default:
                    strResult = "未知";
                    break;
            }
            return strResult;  
        }
        /// <summary>
        /// 获取退换货的状态
        /// </summary>
        /// <param name="sid"></param>
        /// <returns></returns>
        protected string GetRetrunState(object sid)
        {
            int tmpSID = Core.Utils.ObjectToInt(sid,0);
            string strResult = "<span style=\"color:#{0};font-weight:bold;\">" + (EbSite.Modules.Shop.ModuleCore.SystemEnum.OrderItemStatus)tmpSID + "</span>";
            switch (tmpSID)
            {
                case 0:
                    strResult = string.Format(strResult, "113a45");
                    break;
                case 1:
                    strResult = string.Format(strResult, "a7a83a");
                    break;
                case 2:
                    strResult = string.Format(strResult, "44892c");
                    break;
                case 3:
                    strResult = string.Format(strResult, "f00");
                    break;
                case 4:
                    strResult = string.Format(strResult, "4450b1");
                    break;
                default:
                    strResult = "未知";
                    break;
            }
            return strResult;    
        }

    }
}