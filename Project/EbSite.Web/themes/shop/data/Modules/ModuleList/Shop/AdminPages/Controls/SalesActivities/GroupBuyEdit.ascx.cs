using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.BLL;
using EbSite.Base.Modules;
using EbSite.Modules.Shop.ModuleCore.Entity;

namespace EbSite.Modules.Shop.AdminPages.Controls.SalesActivities
{
    public partial class GroupBuyEdit : MPUCBaseSave
    {
        public override string PageName
        {
            get
            {
                return "团购活动添加";
            }
        }
        public override string Permission
        {
            get
            {
                return "18";
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
            ModuleCore.BLL.GroupBuy.Instance.InitModifyCtr(SID, phCtrList);

            ModuleCore.Entity.GroupBuy md = ModuleCore.BLL.GroupBuy.Instance.GetEntity(int.Parse(SID));
            this.editorContent.Text = md.Content;
            ProductIDX.ProductId = md.ProductID.ToString();
            ProductIDX.ProductName = Base.AppStartInit.NewsContentInstDefault.GetModel(int.Parse(md.ProductID.ToString()),GetSiteID).NewsTitle;

            if (md.Status.ToString().Equals("0"))
            {
                this.btnGroupOver.Visible = true;
            }
            else if (md.Status.ToString().Equals("4"))
            {
                this.btnGroupSuccess.Visible = true;
                this.btnGroupFail.Visible = true;
            }
            this.BuyCount.Text = md.BuyCount.ToString();
            this.BuyPrice.Text = md.BuyPrice.ToString();
           
        }
        override protected void SaveModel()
        {
            if (Core.Utils.StrToFloat(this.BuyPrice.Text)>=Core.Utils.StrToFloat(this.Price.Text))
            {
                base.RunJs("alert('团购价不能大于或者等于商品原价')");
                return;
            }
            if (Core.Utils.StrToFloat(this.MaxCount.Text)< Core.Utils.StrToFloat(this.BuyCount.Text))
            {
                base.RunJs("alert('团购满足数量必须小于等于限购总数量!')");
                return;
            }
            Base.BLL.OtherColumn cRealname = new OtherColumn("ProductID", ProductIDX.ProductId);
            lstOtherColumn.Add(cRealname);
            cRealname = new OtherColumn("Content", this.editorContent.CtrValue);
            lstOtherColumn.Add(cRealname);
            int initStatus =(int)ModuleCore.SystemEnum.GroupBuyState.还未开始;
            DateTime dtStart =DateTime.Parse(this.StartDate.Value);
            DateTime dtEnd = DateTime.Parse(this.EndDate.Value);
            cRealname = new OtherColumn("sdateline",EbSite.Core.SqlDateTimeInt.GetSecond(dtStart).ToString());
            lstOtherColumn.Add(cRealname);

            cRealname = new OtherColumn("edateline", EbSite.Core.SqlDateTimeInt.GetSecond(dtEnd).ToString());
            lstOtherColumn.Add(cRealname);

            if (dtStart <= DateTime.Now)
            {
                initStatus = (int)ModuleCore.SystemEnum.GroupBuyState.正在进行中;
            }
            cRealname = new OtherColumn("status", initStatus.ToString());
            lstOtherColumn.Add(cRealname);



           
            ModuleCore.BLL.GroupBuy.Instance.SaveEntityFromCtr(phCtrList, lstOtherColumn);
           
            if (string.IsNullOrEmpty(SID))
            {
                base.RunJs("alert('添加成功!')");
            }
            else
            {
                base.RunJs("alert('修改成功!')");
            }
           
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                    
            }
        }

        protected void btnGroupOver_Click(object sender, EventArgs e)
        {
            ModuleCore.BLL.GroupBuy.Instance.Update(4,int.Parse(SID));
            base.RunJs("ClosePage(1)");
        }

        protected void btnGroupSuccess_Click(object sender, EventArgs e)
        {
            ModuleCore.BLL.GroupBuy.Instance.Update(1, int.Parse(SID));
            base.RunJs("ClosePage(1)");
        }

        protected void btnGroupFail_Click(object sender, EventArgs e)
        {
            ModuleCore.BLL.GroupBuy.Instance.Update(2, int.Parse(SID));
            base.RunJs("ClosePage(1)");
        }
    }
}