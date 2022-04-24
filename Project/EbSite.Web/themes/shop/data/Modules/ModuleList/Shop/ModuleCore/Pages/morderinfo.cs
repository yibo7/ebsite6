using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.MobileControls;
using System.Web.UI.WebControls;
using EbSite.Base.Configs.SysConfigs;
using EbSite.Base.EntityAPI;
using EbSite.Base.Json;
using EbSite.Base.Page;
using EbSite.Entity;

using System.Text;
using EbSite.Modules.Shop.ModuleCore.BLL;

namespace EbSite.Modules.Shop.ModuleCore.Pages
{
    public class morderinfo : orderinfo
    {


        protected override void AddHeaderPram()
        {
            base.MobileAddHeaderPram();

        }

        protected override void InitStyle()
        {
            base.MobileInitStyle();
        }

        protected string MTitle
        {
            get
            {
                return SiteName;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //验证用户是否登录
                if (EbSite.Base.Host.Instance.UserID < 0)
                {
                    base.MCheckCurrentUserIsLogin();
                }
            }
            base.Page_Load(sender, e);
        }
    }
}