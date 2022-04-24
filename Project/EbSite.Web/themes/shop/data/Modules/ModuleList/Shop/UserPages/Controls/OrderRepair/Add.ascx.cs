using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.Modules;
using EbSite.Entity; 

namespace EbSite.Modules.Shop.UserPages.Controls.OrderRepair
{
    public partial class Add : MPUCBaseSaveForUser
    {

        public override Guid ModuleMenuID
        {
            get
            {
                return new Guid("999ebbca-0202-4a18-9141-3fd7a8808957");
            }
        }
        public override string PageName
        {
            get
            {
                return "申请售后服务";
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
        public override int OrderID
        {
            get
            {
                return 2;
            }
        }

        public int OrderItemID
        {
            get {
                return Core.Utils.StrToInt(Request.Params["id"], 0);
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (UserID < 1)
            {
                Tips("请先登录", "本页面需要登录内能访问!");
            }
       
            if (!IsPostBack)
            {
                if (OrderItemID>0)
                {
                    ModuleCore.Entity.Buy_OrderItem itemMD = ModuleCore.BLL.Buy_OrderItem.Instance.GetEntity(OrderItemID);
                    if (itemMD != null)
                    {
                        this.imgbtngoods.ImageUrl = itemMD.ThumbnailsUrl;
                        string purl=EbSite.Base.Host.Instance.GetContentLink(itemMD.ProductId,3);;
                        this.imgbtngoods.ToolTip = itemMD.ProductName;
                        this.labLnkGoods.Text =string.Format("<a href=\"{0}\" target=\"_blank\">{1}</a>",purl,itemMD.ProductName);
                        this.labprice.Text = "&yen;" + itemMD.MemberPrice.ToString();
                        this.labyh.Text = "-";
                        this.labqd.Text = "-";
                        this.labcount.Text = itemMD.Quantity.ToString();
                    }
                }
            }
        }
    
        override protected string KeyColumnName
        {
            get
            {
                return "id";
            }
        }
        override protected void InitModifyCtr()
        {
          
        }

        override protected void SaveModel()
        {
            if (OrderItemID > 0)
            {
                int subCount = Core.Utils.StrToInt(this.labcount.Text,0);
                if (Core.Utils.StrToInt(this.txtCount.Text) > subCount)
                {
                    base.RunJs("alert('提交数量不能大于已购买数量')");
                    return;
                }

                Dictionary<string, object> dicArr = new Dictionary<string, object>();
                dicArr.Add("ServiceType", this.rdoServerType.SelectedValue);
                dicArr.Add("SubmitQuantity", this.txtCount.Text);
                int proofType = -1;
                if (this.chkYFP.Checked)
                {
                    proofType = 1;
                }
                if (this.chkYJCBG.Checked)
                {
                    proofType = 2;
                }
                if (this.chkYFP.Checked && this.chkYJCBG.Checked)
                {
                    proofType = 0;
                }

                dicArr.Add("ApplyProof", proofType);
                dicArr.Add("QuestionDesc", "'" + this.txtDesc.Text + "'");
                dicArr.Add("ReturnDate", "'" + DateTime.Now.ToString() + "'");
                dicArr.Add("ItemStatus", (int)ModuleCore.SystemEnum.OrderItemStatus.审核中);

                if (ModuleCore.BLL.Buy_OrderItem.Instance.UpdateOrderItemByDic(dicArr, OrderItemID))
                {
                    //保存图片
                    List<UploadFileInfo> itemList = this.MoreUploadImg.ValueItems;
                    if (itemList != null && itemList.Count > 0)
                    {
                        ModuleCore.Entity.buy_orderitem_img imgMD;
                        foreach (UploadFileInfo f in itemList)
                        {
                            imgMD = new ModuleCore.Entity.buy_orderitem_img();
                            imgMD.orderitemid = OrderItemID;
                            string imgEx = System.IO.Path.GetExtension(f.FileNewName);
                            imgMD.smallimg = f.FileNewName.Replace(imgEx, string.Concat("-small", imgEx));
                            imgMD.bigimg = f.FileNewName;
                            imgMD.typeid = 0;
                            ModuleCore.BLL.buy_orderitem_img.Instance.Add(imgMD);
                        }
                    }
                    base.RunJs("alert(\"提交成功!\");BackPage();");
                }
            }
            else
            {
                base.RunJs("alert(\"操作失败，参数不完整\");");
            }
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            ModuleCore.Entity.Buy_OrderItem itemMD = ModuleCore.BLL.Buy_OrderItem.Instance.GetEntity(OrderItemID);
            if (itemMD != null)
            {
                if (itemMD.ItemStatus > 0)
                {
                    base.RunJs("alert(\"此商品已经提交申请,不能重复提交\");BackPage();");
                    return;
                }
            }
            SaveModel();
        }
    }
}