using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.Modules;
using EbSite.Entity;
using System.Collections; 

namespace EbSite.Modules.Shop.UserPages.Controls.OrderRepair
{
    public partial class Show : MPUCBaseSaveForUser
    {

        public override Guid ModuleMenuID
        {
            get
            {
                return new Guid("10a70edf-e9cc-4616-a97f-d96cdd980e81");
            }
        }
        public override string PageName
        {
            get
            {
                return "退换货信息";
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
                return 5;
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
                        this.litProductNum.Text = itemMD.SKU;
                        this.litProductName.Text = itemMD.ProductName;
                        this.litCount.Text = itemMD.SubmitQuantity.ToString();
                        this.litSericeType.Text = ((ModuleCore.SystemEnum.ServiceType)itemMD.ServiceType).ToString();
                        string strProof = "无发票  无检测报告";
                        if (itemMD.ApplyProof == 0)
                        {
                            strProof = "有发票  有检测报告";
                        }
                        else if (itemMD.ApplyProof == 1)
                        {
                            strProof = "有发票  无检测报告";
                        }
                        else if (itemMD.ApplyProof ==2)
                        {
                            strProof = "无发票  有检测报告";
                        }
                        this.litProof.Text = strProof;
                        this.litQuestionDesc.Text = itemMD.QuestionDesc;

                        this.litReason.Text = itemMD.Reason;


                        //绑定图片
                        List<ModuleCore.Entity.buy_orderitem_img> imgls = ModuleCore.BLL.buy_orderitem_img.Instance.GetListArray("orderitemid="+OrderItemID);
                        if (imgls != null && imgls.Count > 0)
                        {
                            this.rptDataImgList.DataSource = imgls;
                            this.rptDataImgList.DataBind();
                        }
                        this.litOrderNum.Text = itemMD.OrderId.ToString();
                        this.litAppDate.Text = itemMD.ReturnDate.ToString();
                        this.labState.Text = ((ModuleCore.SystemEnum.OrderItemStatus)itemMD.ItemStatus).ToString();
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
           
        }
    }
}