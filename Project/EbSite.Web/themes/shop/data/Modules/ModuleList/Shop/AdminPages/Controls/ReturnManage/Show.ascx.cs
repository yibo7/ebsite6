using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.Modules;

namespace EbSite.Modules.Shop.AdminPages.Controls.ReturnManage
{
    public partial class Show : MPUCBaseSave
    {
        public override string PageName
        {
            get
            {
                return "处理退换货";
            }
        }
        public override string Permission
        {
            get
            {
                return "94";
            }
        }
        override protected string KeyColumnName
        {
            get
            {
                return "ID";
            }
        }
        override protected void InitModifyCtr()
        {
            //ModuleCore.BLL.Supplier.Instance.InitModifyCtr(SID, phCtrList);
        }
        override protected void SaveModel()
        {
            if (!string.IsNullOrEmpty(SID))
            {
                Dictionary<string, object> dicArr = new Dictionary<string, object>();
                dicArr.Add("itemstatus", (int)ModuleCore.SystemEnum.OrderItemStatus.审核通过);
                dicArr.Add("returndate", "'" + DateTime.Now.ToString() + "'");
                dicArr.Add("Reason", "'" + txtReason.Text.Trim() + "'");
                ModuleCore.BLL.Buy_OrderItem.Instance.UpdateOrderItemByDic(dicArr, int.Parse(SID));
                base.RunJs("alert('保存成功');ClosePage()");
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(SID))
                {
                    ModuleCore.Entity.Buy_OrderItem orderItem = ModuleCore.BLL.Buy_OrderItem.Instance.GetEntity(int.Parse(SID));
                    if (orderItem != null)
                    {
                        this.litOrderNum.Text =orderItem.OrderId.ToString();
                        this.litProductNum.Text = orderItem.SKU;
                        this.litServiceType.Text =((ModuleCore.SystemEnum.ServiceType)orderItem.ServiceType).ToString();
                        this.litSubmitCount.Text = orderItem.SubmitQuantity.ToString();
                        this.litApliyProof.Text =((ModuleCore.SystemEnum.ProofType)orderItem.ApplyProof).ToString();
                        this.litQuestionDesc.Text = orderItem.QuestionDesc;
                        this.litSubmitDate.Text = orderItem.ReturnDate.ToString();
                        this.txtReason.Text= orderItem.Reason;
                        //图片处理
                        List<ModuleCore.Entity.buy_orderitem_img> ls = ModuleCore.BLL.buy_orderitem_img.Instance.GetListArray("orderitemid="+SID);
                        if (ls != null && ls.Count > 0)
                        {
                            this.rptImgList.DataSource = ls;
                            this.rptImgList.DataBind();
                        }
                        if (orderItem.ItemStatus.Equals(1))
                        {
                            this.bntSave.Enabled = true;
                            this.btnNoPass.Enabled = true;
                        }
                    }
                }
            }
        }

        protected void btnNoPass_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(SID))
            {
                if (!string.IsNullOrEmpty(txtReason.Text.Trim()))
                {
                    Dictionary<string, object> dicArr = new Dictionary<string, object>();
                    dicArr.Add("itemstatus", (int) ModuleCore.SystemEnum.OrderItemStatus.审核失败);
                    dicArr.Add("returndate", "'" + DateTime.Now.ToString() + "'");
                    dicArr.Add("Reason", "'" + txtReason.Text.Trim() + "'");
                    ModuleCore.BLL.Buy_OrderItem.Instance.UpdateOrderItemByDic(dicArr, int.Parse(SID));
                    base.RunJs("alert('操作成功');ClosePage()");
                }
                else
                {
                    base.TipsAlert("请添写拒绝处理的原因");
                }
            }
        }
    }
}