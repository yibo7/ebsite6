using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EbSite.Base.Modules;
using System.Web.UI.WebControls;
using System.Text;

namespace EbSite.Modules.Shop.AdminPages.Controls.Orders
{
    public abstract class BaseOrderList : MPUCBaseList
    {
        protected string NoteInfo
        {
            get
            {
                return "注：订单状态列中有“退”字代表该订单退过款；有“(团)”字的代表团购订单；有“(抢)”字的代表限时抢购订单；";
            }
        }

        public void BindDDLOrderStateList(DropDownList ddlOrderState)
        {
            ddlOrderState.Items.Add(new ListItem("全部", ""));
            ddlOrderState.Items.Add(new ListItem("提交订单", "0"));
            ddlOrderState.Items.Add(new ListItem("审核订单", "1"));
            ddlOrderState.Items.Add(new ListItem("等待支付", "2"));
            ddlOrderState.Items.Add(new ListItem("已发货", "3"));
            ddlOrderState.Items.Add(new ListItem("确认收货", "4"));
            ddlOrderState.Items.Add(new ListItem("完成交易", "5"));
            ddlOrderState.Items.Add(new ListItem("回收站", "6"));
        }

        public void BindDDLPrintTypeList(DropDownList ddl)
        {
            ddl.Items.Add(new ListItem("全部", "-1"));
            ddl.Items.Add(new ListItem("未打印", "0"));
            ddl.Items.Add(new ListItem("已打印", "1"));
        }


        public void BindDDLiComeList(DropDownList ddl)
        {
            ddl.Items.Add(new ListItem("全部", ""));
            ddl.Items.Add(new ListItem("pc", "0"));
            ddl.Items.Add(new ListItem("手机", "1"));
        }
        public void BindDDLSendTypeList(DropDownList ddl)
        {
            List<EbSite.Entity.PsDelivery> ls = EbSite.BLL.PsDelivery.Instance.FillList();
            if (ls != null && ls.Count > 0)
            {
                ddl.DataTextField = "ModeName";
                ddl.DataValueField = "id";
                ddl.DataSource = ls;
                ddl.DataBind();
            }
            ddl.Items.Insert(0, new ListItem("全部", "-1"));
        }

        /// <summary>
        /// 订单状态转换
        /// </summary>
        /// <param name="orderState"></param>
        /// <returns></returns>
        public string ParseOrderState(string orderState)
        {
            return ModuleCore.BLL.Buy_Orders.Instance.ParseOrderState(orderState);
        }
        /// <summary>
        /// 获取标志名称
        /// </summary>
        /// <param name="imgName">图片名称</param>
        /// <returns></returns>
        public string GetImgName(string markID)
        {
            string result = "<img alt=\"\" src=\"/images/menus/{0}\" />";
            switch (markID)
            { 
                case "0":
                    return string.Format(result, "Ok.gif");
                case "1":
                    return string.Format(result, "Overlay-Warning.gif");
                case "2":
                    return string.Format(result, "Flag-Red.gif");
                case "3":
                    return string.Format(result, "Flag-Green.gif");
                case "4":
                    return string.Format(result, "Flag-Yellow.gif");
                case "5":
                    return string.Format(result, "Flag-Cyan.gif");
                default:
                    return "暂无标注";
            }
        }

        public string GetOrderState(ModuleCore.SystemEnum.OrderStatus orderState)
        {
            return ModuleCore.BLL.Buy_Orders.Instance.GetStatusTips(orderState).ToString();
        }
        /// <summary>
        /// 控制按钮发货、退款 显示
        /// </summary>
        /// <returns></returns>
        public string SendGoods(string PaymentType, string OrderStatus, object gid, object gs)
        {
            string str = "<a href='javascript:void(0);' style=' color: #f00;'  onclick='SendOrder(this)'>发货</a>";
            int groupid = Core.Utils.ObjectToInt(gid, 0);
            //如果是新提交、货到付款的订单，则显示 通过审核 按钮
            if (OrderStatus.Equals(ModuleCore.BLL.Buy_Orders.Instance.GetStatusTips(ModuleCore.SystemEnum.OrderStatus.提交订单).ToString()) && PaymentType.Equals("-1"))
            {
                return "<a href='javascript:void(0);' style=' color: #f00;' title='只有通过审核后才能发货哦'  onclick='ApprovedOrder(this)'>通过审核</a>";
            }

            //是否为团购订单
            if (groupid > 0)
            {
                int gStatus = Core.Utils.ObjectToInt(gs, 0);
                if (gStatus == (int)ModuleCore.SystemEnum.GroupBuyState.成功结束)
                {
                    //如果团购已经
                    int tmpOrderStatus = int.Parse(OrderStatus);
                    if (tmpOrderStatus >= ModuleCore.BLL.Buy_Orders.Instance.GetStatusTips(ModuleCore.SystemEnum.OrderStatus.已支付) && tmpOrderStatus <= ModuleCore.BLL.Buy_Orders.Instance.GetStatusTips(ModuleCore.SystemEnum.OrderStatus.交易完成))
                    {
                        str += "&nbsp;&nbsp;&nbsp;<a href='javascript:void(0);' style=' color: #f00;'  onclick='RefundOrderEx(this)'>退款</a>";
                        return str;
                    }
                    else
                    {
                        return "";
                    }
                }
            }
            else
            {
                //如果是货到付款、已审核订单 则显示 发货 按钮
                if (PaymentType.Equals("-1") && OrderStatus.Equals(ModuleCore.BLL.Buy_Orders.Instance.GetStatusTips(ModuleCore.SystemEnum.OrderStatus.审核订单).ToString()))
                {
                    return str;
                }
                else if (OrderStatus == ModuleCore.BLL.Buy_Orders.Instance.GetStatusTips(ModuleCore.SystemEnum.OrderStatus.已支付).ToString())
                {
                    return str;
                }
            }
            return "";
        }
    }
}