using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.Modules;
using EbSite.Base.ControlPage;

namespace EbSite.Web.AdminHt.Controls.Admin_Payment
{
    public partial class Add_Sec : UserControlBaseSave
    {
        public override string PageName
        {
            get
            {
                return "添加可选内容";
            }
        }
        public override string Permission
        {
            get
            {
                return "57";
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
           
        }

        override protected void InitModifyCtr()
        {
            
        }
        override protected void SaveModel()
        {
            int pid = 0;
            if (Request.Params["id"] != null)
            {
                pid = Core.Utils.StrToInt(Request.Params["id"].ToString());
            }
            EbSite.Entity.OrderOptionItems md = new EbSite.Entity.OrderOptionItems();
            md.OrderOptionID = pid;
            md.ItemName = TitleName.Text;
            bool isUserInput=false;
            if(this.rdoUserTypeList.Items[0].Selected)
            {
                isUserInput=true;
                md.UserInputTitle = this.txtUserTitle.Text;
            }
            md.IsUserInputRequired = isUserInput;
            md.AppendMoney =decimal.Parse(this.txtMoney.Text);
            md.CalculateMode = this.rdoMonType.Items[0].Selected?0:1;
            md.Remark = this.txtRemark.Text;
            EbSite.BLL.OrderOptionItems.Instance.Add(md);
            base.RunJs("CloseReshPage()");
        }
    }
}