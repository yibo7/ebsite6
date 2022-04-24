using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Profile;

namespace EbSite.Modules.Shop.Core.Cart
{
    public class ProfileCommon : System.Web.Profile.ProfileBase
    {
        //此名称如果与ShoppingCart同名，将会出错:此配置已经定义
        public virtual CartManger ShopCart
        {
            get
            {
                return ((CartManger)(this.GetPropertyValue("eBSiteShopingCart")));
            }
            set
            {
                this.SetPropertyValue("eBSiteShopingCart", value);
            }
        }

       

        //public  int DeleteProfiles(ProfileInfoCollection profiles)
        //{

        //    int deleteCount = 0;
            
        //    foreach (ProfileInfo p in profiles)
        //        if (CartProfileProvider.DeleteProfile(p.UserName))
        //            deleteCount++;

        //    return deleteCount;
        //}

    }
}