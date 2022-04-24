using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.Configs.SysConfigs;
using EbSite.Base.ControlPage;

namespace EbSite.Web.AdminHt.Controls.Admin_Frdlink
{
    public partial class Configs : UserControlBaseSave
    {
        public override string Permission
        {
            get
            {
                return "309";
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
            throw new NotImplementedException();
        }
        override protected void SaveModel()
        {
            ConfigsControl.Instance.IsAllowApplyFrdLink = cbIsAllowApplyFrdLink.Checked;
            ConfigsControl.Instance.FrdLinkDemo = txtFrdLinkDemo.Text;

            ConfigsControl.SaveConfig();
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!base.IsPostBack)
            {
                cbIsAllowApplyFrdLink.Checked = ConfigsControl.Instance.IsAllowApplyFrdLink;
                txtFrdLinkDemo.Text = ConfigsControl.Instance.FrdLinkDemo;
            }
        }
    }
}