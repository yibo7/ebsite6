using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.Configs.SysConfigs;
using EbSite.Base.ControlPage;

namespace EbSite.Web.AdminHt.Controls.Admin_PickproofLink
{
    public partial class PicLink : UserControlBaseSave
    {

        public override string Permission
        {
            get
            {
                return "148";
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
            this.SaveConfig();
        }




        protected void Page_Load(object sender, EventArgs e)
        {
            if (!base.IsPostBack)
            {
                cbIsOpenPickproofLink.Checked = ConfigsControl.Instance.IsOpenPickproofLinkOfPic;
                txtPickproofLinkPre.Text = ConfigsControl.Instance.PickproofLinkPreOfPic;

            }
        }

        protected void SaveConfig()
        {

            ConfigsControl.Instance.IsOpenPickproofLinkOfPic = cbIsOpenPickproofLink.Checked;
            ConfigsControl.Instance.PickproofLinkPreOfPic = txtPickproofLinkPre.Text.ToLower().Trim();
            ConfigsControl.SaveConfig();
        }
    }
}