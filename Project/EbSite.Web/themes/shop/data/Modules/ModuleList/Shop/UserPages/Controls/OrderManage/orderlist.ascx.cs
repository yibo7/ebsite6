using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base;
using EbSite.Base.Modules;
using EbSite.Control;
using DropDownList = System.Web.UI.WebControls.DropDownList;

namespace EbSite.Modules.Shop.UserPages.Controls.OrderManage
{
    public partial class orderlist : MPUCBaseListForUserRp
    {
        public override Guid ModuleMenuID
        {
            get
            {
                return new Guid("ac85e68f-7723-4c21-bcb8-90279f386c9b");
            }
        }
        
        public override string PageName
        {
            get
            {
                
                return "订单管理";
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
        /// 此权限ID不为空，将要求用户登录后才能访问此页面
        /// </summary>
        public override string Permission
        {
            get
            {
                return "1";
            }
        }

        override protected string AddUrlType
        {
            get
            {
                return "0";
            }

        }
         /// <summary>
         /// 弹出框修改
         /// </summary>
         /// <param name="id"></param>
         /// <returns></returns>
         protected string ModifyBoxUrl(string id)
         {

             return string.Concat(AddUrlBox, "&id=", id);

         }
        /// <summary>
        /// 关闭
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        protected string CloseBoxUrl(string id)
        {
            return string.Concat("?box=1&t=1&id=", id); 
        }
         protected override string GetUrl
         {
             get
             {
              
                 return string.Format("{0}?mpid={1}&msid={2}", this.GetPageName,  "34394338-7ff6-480e-a478-e6809d8d7546","acd22185-6164-40ba-9a11-3c039d76c396");
             }
         }
        override protected object LoadList(out int iCount)
        {
            return ModuleCore.BLL.Buy_Orders.Instance.GetListPages(this.pcPage.PageIndex, this.pcPage.PageSize, "UserId="+base.UserID, "",
                                                                   out iCount);
        }

        override protected object SearchList(out int iCount)
        {

            string typeid = ucToolBar.GetItemVal(DrpList);
            string orderid = ucToolBar.GetItemVal(tbOrderID);
            string dtb = ucToolBar.GetItemVal(DatePickerB);
            string dte = ucToolBar.GetItemVal(DatePickerE);

            SqlWhere = ModuleCore.BLL.Buy_Orders.Instance.GetSqlWhere(orderid, typeid, dtb, dte);
            return ModuleCore.BLL.Buy_Orders.Instance.GetListPages(this.pcPage.PageIndex, this.pcPage.PageSize, base.GetWhere(true), "", out iCount);
        }

        public string SqlWhere = "";
        protected override string BulderSearchWhere(bool IsValueEmpytNoSearch)
        {
            return SqlWhere;
        }
        override protected void Delete(object iID)
        {
           
            
        }

        #region
        protected void gdList_ItemCommand(object sender, RepeaterCommandEventArgs e)
        {
            if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
            {
                
                //if (e.CommandName == "ExClose")
                //{
                //    string id = e.CommandArgument.ToString();

                //    ModuleCore.Entity.Buy_Orders md =
                //        ModuleCore.BLL.Buy_Orders.Instance.GetEntity(EbSite.Core.Utils.StrToInt(id, 0));
                //    if (!Equals(md, null))
                //    {
                       
                //        md.OrderStatus =Convert.ToInt32( ModuleCore.SystemEnum.OrderStatus.回收站);
                //        md.DelOrderDate = DateTime.Now;
                //        md.CloseReason = "用户关闭";
                //        ModuleCore.BLL.Buy_Orders.Instance.Update(md);
                //    }
                //    gdList_Bind();
                //}
                if (e.CommandName == "ExConfirm") //确认订单
                {
                    string id = e.CommandArgument.ToString();
                    //flz(2013-12-13)
                    ModuleCore.Entity.Buy_Orders md =ModuleCore.BLL.Buy_Orders.Instance.GetEntity(EbSite.Core.Utils.StrToInt(id, 0));
                    if (!Equals(md, null))
                    {
                        if (md.PaymentTypeId < 0)
                        {
                            md.OrderStatus = Convert.ToInt32(ModuleCore.SystemEnum.OrderStatus.确认收货);
                            md.SureReceiptDate = DateTime.Now;//确定收货时间
                        }
                        else
                        {
                            md.OrderStatus = Convert.ToInt32(ModuleCore.SystemEnum.OrderStatus.交易完成);
                            md.FinishDate = DateTime.Now;//订单完成时间
                        }
                        
                        //记录操作日志
                        ModuleCore.BLL.buy_orderlog.Instance.Add(md.id, "您进行了确认收货操作", ModuleCore.SystemEnum.OrderLogType.前台显示);
                        ModuleCore.BLL.buy_orderlog.Instance.Add(md.id, "客户进行了确认收货操作", ModuleCore.SystemEnum.OrderLogType.全部显示);

                        ModuleCore.BLL.Buy_Orders.Instance.Update(md);
                    }
                    gdList_Bind();
                }
              
               
            }
        }
        protected void gdList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
            {
                System.Web.UI.WebControls.Panel lbClose = (Panel)e.Item.FindControl("PanColse");
               // EbSite.Control.EasyuiDialog lbClose = (EbSite.Control.EasyuiDialog)e.Item.FindControl("lbClose");//关闭订单
                System.Web.UI.WebControls.HyperLink lbPay = (System.Web.UI.WebControls.HyperLink)e.Item.FindControl("HlinkPay");//付款
                EbSite.Control.LinkButton lbConfirm = (EbSite.Control.LinkButton)e.Item.FindControl("lbConfirm");//确认收货
               // EbSite.Control.EasyuiDialog  = (EbSite.Control.EasyuiDialog)e.Item.FindControl("lbComment");//评价
                System.Web.UI.WebControls.HyperLink lbComment = (System.Web.UI.WebControls.HyperLink)e.Item.FindControl("lbComment");//付款
                
                if (!Equals(lbClose, null))
                {
                    ModuleCore.Entity.Buy_Orders orMd =( e.Item.DataItem) as ModuleCore.Entity.Buy_Orders;
                    if (orMd.OrderStatus == Convert.ToInt32(ModuleCore.SystemEnum.OrderStatus.提交订单))
                    {
                        lbClose.Visible = true;
                        if (orMd.PaymentTypeId !=Convert.ToInt32( ModuleCore.SystemEnum.PayType.货到付款))
                        {
                            lbPay.Visible = true;
                        }
                        else
                        {
                            lbPay.Visible = false;
                        }
                        lbConfirm.Visible = false;
                        lbComment.Visible = false;

                        lbPay.NavigateUrl = ModuleCore.GetLinks.Instance.GoToPayUrl(SettingInfo.Instance.GetSiteID, orMd.OrderId);// string.Format("/gotopay-{0}.ashx?orderid={1}", SettingInfo.Instance.GetSiteID, orMd.OrderId);
                        lbPay.Target = "_blank";
                    }
                    else if (orMd.OrderStatus == Convert.ToInt32(ModuleCore.SystemEnum.OrderStatus.等待付款))
                    {
                        lbClose.Visible = true;
                        lbPay.Visible = true;
                        lbConfirm.Visible = false;
                        lbComment.Visible = false;

                        lbPay.NavigateUrl = ModuleCore.GetLinks.Instance.GoToPayUrl(SettingInfo.Instance.GetSiteID, orMd.OrderId);// string.Format("/gotopay-{0}.ashx?orderid={1}", SettingInfo.Instance.GetSiteID, orMd.OrderId);
                        lbPay.Target = "_blank";
                    }
                    else  if (orMd.OrderStatus == Convert.ToInt32(ModuleCore.SystemEnum.OrderStatus.已发货))
                    {
                        lbClose.Visible = false;
                        lbPay.Visible = false;

                        lbConfirm.Visible = true;
                        lbComment.Visible = false;
                    }
                    else if (orMd.OrderStatus == Convert.ToInt32(ModuleCore.SystemEnum.OrderStatus.等待付款))
                    {
                        lbClose.Visible = false;
                        lbPay.Visible = false;

                        lbConfirm.Visible = false;
                        lbComment.Visible = false;
                    }
                    else if (orMd.OrderStatus == Convert.ToInt32(ModuleCore.SystemEnum.OrderStatus.已支付))
                    {
                        lbClose.Visible = false;
                        lbPay.Visible = false;

                        lbConfirm.Visible = false;
                        lbComment.Visible = false;
                    }
                    else if (orMd.OrderStatus == Convert.ToInt32(ModuleCore.SystemEnum.OrderStatus.交易完成))
                    {
                        lbClose.Visible = false;
                        lbPay.Visible = false;

                        lbConfirm.Visible = false;
                        lbComment.Visible = true;

                        lbComment.NavigateUrl = ModuleCore.GetLinks.Instance.GetViewTradeCommentUrl(SettingInfo.Instance.GetSiteID, orMd.OrderId.ToString());
                        lbComment.Target = "_blank";
                    }
                    else //订单完成
                    {
                        lbClose.Visible = false;
                        lbPay.Visible = false;

                        lbConfirm.Visible = false;
                        lbComment.Visible = false;
                    }
                }
                
            }
        }
        #endregion
        #region 工具栏的初始化

       
       

        private void BindDrop()
        {
            
            //  0.提交订单 (1.审核订单-货到付款 2.等待付款-在线支付)  3.已发货 4.确认收货 5.交易完成 6.回收站  
            DrpList.Items.Add(new ListItem("所有订单", ""));
            DrpList.Items.Add(new ListItem("提交订单", "0"));
            DrpList.Items.Add(new ListItem("审核订单", "1"));
            DrpList.Items.Add(new ListItem("等待付款", "2"));
            DrpList.Items.Add(new ListItem("已支付", "21"));

            DrpList.Items.Add(new ListItem("已发货", "3"));

            DrpList.Items.Add(new ListItem("确认收货", "4"));
            DrpList.Items.Add(new ListItem("交易完成", "5"));
            DrpList.Items.Add(new ListItem("回收站", "6"));
            DrpList.SelectedIndex = 0;
            

        }

        protected Label Lb = new Label();
        protected Label LbOrderID = new Label();
        protected System.Web.UI.WebControls.TextBox tbOrderID = new System.Web.UI.WebControls.TextBox();
        protected DropDownList DrpList = new DropDownList();
        protected Label LbDateB = new Label();
        protected Label LbDateE = new Label();

        protected EbSite.Control.DatePicker DatePickerB = new DatePicker();
        protected EbSite.Control.DatePicker DatePickerE = new DatePicker();
        override protected void BindToolBar()
        {

            base.BindToolBar(true, true);
            //ucToolBar.AddLine();
            LbOrderID.ID = "LbOrderID";
            LbOrderID.Text = "订单号";
            ucToolBar.AddCtr(LbOrderID);
            tbOrderID.ID = "tbOrderID";
            tbOrderID.Width = 100;
            
            ucToolBar.AddCtr(tbOrderID);
            Lb.ID = "Lb";
            Lb.Text = "订单状态";
            ucToolBar.AddCtr(Lb);

            DrpList.ID = "DrpList";
            BindDrop();
            ucToolBar.AddCtr(DrpList);

            LbDateB.ID = "LbDateB";
            LbDateB.Text = "下单日期从";
            ucToolBar.AddCtr(LbDateB);

            DatePickerB.ID = "DatePickerB";
            DatePickerB.Width =85;
            ucToolBar.AddCtr(DatePickerB);

            LbDateE.ID = "LbDateE";
            LbDateE.Text = "至";
            ucToolBar.AddCtr(LbDateE);
            DatePickerE.ID = "DatePickerE";
            DatePickerE.Width = 85;
            ucToolBar.AddCtr(DatePickerE);


            ucToolBar.AddBnt("查询", IISPath + "images/menus/Search.gif", "search");
        }
        #endregion

        #region 工具栏事件扩展

        //protected override void ucToolBar_ItemClick(object source, Control.ItemClickArgs e)
        //{
        //    base.ucToolBar_ItemClick(source, e);
        //    switch (e.ItemTag)
        //    {
        //        case "good":
        //            break;
        //    }
        //}

        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            
           // aspnetForm.Target = "_blank";
        }
    }
}