using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using EbSite.BLL.User;
using EbSite.Entity;
using EbSite.Modules.Shop.ModuleCore.Cart;
using EbSite.Modules.Shop.ModuleCore.Entity;

namespace EbSite.Modules.Shop.ModuleCore.Pages
{
    public class mmshoppingcar3 : mshoppingcar3
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

        override protected int OrderiCome
        {
            get
            {
                return Convert.ToInt32(SystemEnum.ComeType.手机);
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

        override protected Guid GetMenuGuid
        {
            get
            {
                return new Guid("cef0a633-b792-49af-8a79-93af37651495");
            }
        }
       override protected Guid GetMenuLuYou
        {
            get { return new Guid("fd8177fb-66f3-4c32-936e-ca226a95549c"); }
        }
    }
}