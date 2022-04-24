using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.ControlPage;


namespace EbSite.Web.AdminHt.Controls.Admin_Payment
{
    public partial class OrderOptionAdd : UserControlBaseSave
    {
        public override string PageName
        {
            get
            {
                return "订单可选项添加";
            }
        }
        public override string Permission
        {
            get
            {
                return "159";
            }
        }
        override protected string KeyColumnName
        {
            get
            {
                return "ID";
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(SID))
            {
                this.btnNextStep.Text = " 保存 ";
            }
        }

        override protected void InitModifyCtr()
        {
            //ModuleCore.BLL.Coupons.Instance.InitModifyCtr(SID, phCtrList);
            if (!string.IsNullOrEmpty(SID))
            {
                //ModuleCore.Entity.OrderOptions md = ModuleCore.BLL.OrderOptions.Instance.GetEntity(int.Parse(SID));
                EbSite.Entity.OrderOptions md = EbSite.BLL.OrderOptions.Instance.GetEntity(int.Parse(SID));
                if (md != null)
                {
                    this.txtItemName.Text = md.OptionName;
                    this.Description.Text = md.Description;
                    this.ddl_ShowType.SelectedIndex =int.Parse(md.SelectMode.ToString());
                }
            }
        }
        override protected void SaveModel()
        {
           
        }

        protected void btnNextStep_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(SID))
            {
                EbSite.Entity.OrderOptions md = new EbSite.Entity.OrderOptions();
                md.OptionName = this.txtItemName.Text;
                md.SelectMode = Core.Utils.StrToInt(this.ddl_ShowType.SelectedValue);
                md.Description = this.Description.Text;
                int resultID = EbSite.BLL.OrderOptions.Instance.Add(md);
                if (resultID > 0)
                {
                    Response.Redirect(string.Format("Admin_Payment.aspx?t=58&id={0}&mid=cfccc599-4585-43ed-ba31-fdb50024714b&muid=20f990d2-f638-4352-bb93-705cbe9cf0b3", resultID));
                }
            }
            else
            {
                EbSite.Entity.OrderOptions md = new EbSite.Entity.OrderOptions();
                md.id = int.Parse(SID);
                md.OptionName = this.txtItemName.Text;
                md.SelectMode = Core.Utils.StrToInt(this.ddl_ShowType.SelectedValue);
                md.Description = this.Description.Text;
                EbSite.BLL.OrderOptions.Instance.Update(md);
                base.RunJs("$(window.parent.document.body).find(\"div[class='panel-tool-close']\").click();");
            }
        }
    }
}