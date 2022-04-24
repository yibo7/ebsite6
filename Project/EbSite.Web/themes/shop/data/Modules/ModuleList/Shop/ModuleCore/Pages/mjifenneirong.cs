using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using EbSite.Base.Page;
using EbSite.Modules.Shop.ModuleCore.Cart;
using EbSite.Modules.Shop.ModuleCore.Entity;

namespace EbSite.Modules.Shop.ModuleCore.Pages
{
    public class mjifenneirong : jifenneirong
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