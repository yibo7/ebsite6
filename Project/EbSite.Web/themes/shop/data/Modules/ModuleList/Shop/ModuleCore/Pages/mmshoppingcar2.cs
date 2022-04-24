using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.MobileControls;
using System.Web.UI.WebControls;
using EbSite.Base.Json;
using EbSite.Base.Page;
using EbSite.Entity;
using EbSite.Modules.Shop.ModuleCore.Cart;
using EbSite.Modules.Shop.ModuleCore.Ctrls;

namespace EbSite.Modules.Shop.ModuleCore.Pages
{
    public class mmshoppingcar2 : mshoppingcar2
    {
        protected override void AddHeaderPram()
        {
            base.MobileAddHeaderPram();

        }
        protected string MTitle
        {
            get
            {
                return SiteName;
            }
        }
        protected override void InitStyle()
        {
            base.MobileInitStyle();
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
            base.Page_Load(sender,e );
        }
    }
}