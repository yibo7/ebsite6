using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.Modules;
using EbSite.Modules.Wenda.ModuleCore.BLL;
using EbSite.Modules.Wenda.ModuleCore.Entity;


namespace EbSite.Modules.Wenda.AdminPages.Controls.ImitatePost
{
    public partial class IpRandom : MPUCBaseSave
    {
        public override Guid ModuleMenuID
        {
            get
            {
                return new Guid("af082886-9804-4fbd-a7fe-5410b791d07e");
            }
        }
        public override string PageName
        {
            get
            {
                return "模拟发帖随机IP范围";
            }
        }
        /// <summary>
        /// 是否添加到管理页面菜单之中
        /// </summary>
        public override bool IsAddToAdminMenus
        {
            get
            {
                return true;
            }
        }
        public override string Permission
        {
            get
            {
                return "30";
            }
        }
        override protected string KeyColumnName
        {
            get
            {
                return "id";
            }
        }
        public override int OrderID
        {
            get
            {
                return 3;
            }
        }

       
        override protected void InitModifyCtr()
        {
            throw new NotImplementedException();
        }


        override protected void SaveModel()
        {

            ModuleCore.BLL.IpControl.Instance.Ips = this.txtIP.Text;
            IpControl.SaveConfig();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!base.IsPostBack)
            {
                this.initConfig();

            }
        }
        protected void initConfig()
        {
         
            this.txtIP.Text = IpControl.Instance.Ips.ToString();


        }

    
    }
}