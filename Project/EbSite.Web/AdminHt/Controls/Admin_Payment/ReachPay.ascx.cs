using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.Configs.ReachPayConfigs;
using EbSite.Base.ControlPage;

namespace EbSite.Web.AdminHt.Controls.Admin_Payment
{
    public partial class ReachPay : UserControlBaseSave
    {
       

        #region 权限

        public override string Permission
        {
            get
            {
                return "160";
            }
        }
        #endregion

        protected override string KeyColumnName
        {
            get { return "ID"; }
        }
        protected override void InitModifyCtr()
        {
            throw new NotImplementedException();
        }
        protected override void SaveModel()
        {
            ConfigsControl.Instance.IsCod = Convert.ToBoolean(this.IsCod.CtrValue);
            ConfigsControl.Instance.IsPercent = Convert.ToBoolean(this.IsPercent.CtrValue);
            if (!string.IsNullOrEmpty(this.UseMoney.Text.Trim()))
                ConfigsControl.Instance.UseMoney = Convert.ToDecimal(this.UseMoney.Text.Trim());

            ConfigsControl.SaveConfig();
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.IsCod.Checked = ConfigsControl.Instance.IsCod;
                this.IsPercent.Checked = ConfigsControl.Instance.IsPercent;
                this.UseMoney.Text = ConfigsControl.Instance.UseMoney.ToString();
                
            }
        }
        protected void IsCod_CheckedChanged(object sender, EventArgs e)
        {
            ISCodBind();
        }
        private void ISCodBind()
        {
            if (IsCod.Checked)
            {
                this.IsPercent.Enabled = true;
                this.UseMoney.Enabled = true;
            }
            else
            {
                this.IsPercent.Enabled = false;
                this.UseMoney.Enabled = false;
                this.IsPercent.Checked = false;
                this.UseMoney.Text = "0";
            }
        }
    }
}