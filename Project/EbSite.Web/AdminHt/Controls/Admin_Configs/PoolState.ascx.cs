using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Web.UI.WebControls;
using EbSite.Base;
using EbSite.Base.Configs.SysConfigs;
using EbSite.Base.ControlPage;
using EbSite.BLL;
using EbSite.BLL.GetLink;

//using EbSite.BLL.GetLink;

namespace EbSite.Web.AdminHt.Controls.Admin_Configs
{
    public partial class PoolState : UserControlBaseSave
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
            int MaxTread = 0;
            int.TryParse(txtMaxThread.Text, out MaxTread);
            if (MaxTread > 0)
            {
                ThreadPoolManager.Init(MaxTread);
                Base.Configs.SysConfigs.ConfigsControl.Instance.MaxThreadForPool = MaxTread;
                Base.Configs.SysConfigs.ConfigsControl.SaveConfig();
            }
        }

       

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!base.IsPostBack)
            {
                txtMaxThread.Text = ConfigsControl.Instance.MaxThreadForPool.ToString();
            }
        }

        protected void bntStopAllThread_Click(object sender, EventArgs e)
        {
            ThreadPoolManager.Instance.Cancel();
        }

       

       
    }
}