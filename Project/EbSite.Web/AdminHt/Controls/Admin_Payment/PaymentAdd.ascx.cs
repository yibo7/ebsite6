using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.BLL;
using EbSite.Base.ControlPage;
using EbSite.Base.Plugin;

namespace EbSite.Web.AdminHt.Controls.Admin_Payment
{
    public partial class PaymentAdd : UserControlBaseSave
    {
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
                return "id";
            }
        }


        override protected void InitModifyCtr()
        {
            BLL.Payment.Instance.InitModifyCtr(SID, phCtrList);
            Entity.Payment md = BLL.Payment.Instance.GetEntity(int.Parse(SID));
            BindSiteDrpList();
            ClassID.SelectedValue = md.ClassID.ToString();
        }
        override protected void SaveModel()
        {
            Base.BLL.OtherColumn cRealname = new OtherColumn("OrderNumber", "0");
            lstOtherColumn.Add(cRealname);
            BLL.Payment.Instance.SaveEntityFromCtr(phCtrList, lstOtherColumn);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            PaymentApi.DataTextField = "Description";
            PaymentApi.DataValueField = "name";
            PaymentApi.DataSource = PluginManager.Instance.GetPluginInfoByType("IPayment", 1);
            PaymentApi.DataBind();
            if (string.IsNullOrEmpty(SID))
                BindSiteDrpList();
        }

        private void BindSiteDrpList()
        {
            List<Entity.PayTypeInfo> s = BLL.PayTypeInfo.Instance.GetSalesTeamTree(0);
            ClassID.DataSource = s;
            ClassID.DataTextField = "Name";
            ClassID.DataValueField = "id";
            ClassID.DataBind();


        }
    }
}