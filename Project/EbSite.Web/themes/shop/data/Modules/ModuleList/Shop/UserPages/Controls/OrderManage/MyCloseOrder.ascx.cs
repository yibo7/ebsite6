using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.Modules;
using EbSite.Modules.Shop.ModuleCore;
using EbSite.Modules.Shop.ModuleCore.Entity;

namespace EbSite.Modules.Shop.UserPages.Controls.OrderManage
{
    public partial class MyCloseOrder : MPUCBaseShow<ModuleCore.Entity.Buy_Orders>
    {
        public override Guid ModuleMenuID
        {
            get
            {
                return new Guid("52c7482e-4d2d-4aa0-97f3-6cf05a59c2b2");
            }
        }

        public override string PageName
        {
            get
            {

                return "关闭订单";
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
        /// 此权限ID不为空，将要求用户登录后才能访问此页面
        /// </summary>
        public override string Permission
        {
            get
            {
                return "7";
            }
        }

        protected override ModuleCore.Entity.Buy_Orders LoadModel()
        {
            if (!string.IsNullOrEmpty(GetKeyID))
            {
                return ModuleCore.BLL.Buy_Orders.Instance.GetEntity(int.Parse(GetKeyID));
            }
            else
            {
                Tips("出错了", "找不到要查看的记录!");
                return null;
            }
        }




        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
                ModuleCore.Entity.Buy_Orders md =ModuleCore.BLL.Buy_Orders.Instance.GetEntity(OID);
                if (!Equals(md, null))
                {
                    if (md.GroupId > 0)
                    {
                        ModuleCore.Entity.GroupBuy gMd = ModuleCore.BLL.GroupBuy.Instance.GetEntity(Core.Utils.StrToInt(md.GroupId.ToString(), 0));

                        List<ModuleCore.Entity.Buy_OrderItem> OItem =
                            ModuleCore.BLL.Buy_OrderItem.Instance.GetListArray(1, "OrderId=" + md.OrderId, "");

                        if (OItem.Count > 0)
                        {
                            litGroupInfo.Text = string.Concat("团购订单将扣违约金 ", gMd.NeedPrice, "(每个)*", OItem[0].Quantity, "(数量)", "=", gMd.NeedPrice * OItem[0].Quantity, "元");
                        }

                    }
                }

            }
        }
        /// <summary>
        /// Order表 id
        /// </summary>
        private int OID
        {
            get
            {
                string id = Request.QueryString["id"];
                if (!string.IsNullOrEmpty(id))
                {
                    return EbSite.Core.Utils.StrToInt(id, 0);
                }
                return 0;
            }
        }


        protected void bntSave_Click(object sender, EventArgs e)
        {
            string id = Request.QueryString["id"];
            if (!string.IsNullOrEmpty(id))
            {
                if (!string.IsNullOrEmpty(txtRegion.Text.Trim()))
                {
                    ModuleCore.Entity.Buy_Orders md =
                        ModuleCore.BLL.Buy_Orders.Instance.GetEntity(OID);
                    if (!Equals(md, null))
                    {
                        bool key = ModuleCore.BLL.Buy_Orders.Instance.CloseOrder(OID, "用户关闭" + this.txtRegion.Text);
                        if (key)
                        {
                            //添加日志
                            ModuleCore.BLL.buy_orderlog.Instance.Add(md.OrderId.ToString(), "您关闭了订单。", SystemEnum.OrderLogType.前台显示);
                            base.TipsAlert("操作成功。");
                        }
                    }
                    else
                    {
                        base.TipsAlert("订单号不对，请核实。");
                    }
                }
                else
                {
                    base.TipsAlert("请添写理由！");

                }
            }
        }


    }
}