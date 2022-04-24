using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Web;
using System.Web.Profile;
using EbSite.Base;
using EbSite.Base.EBSiteEventArgs;
using EbSite.Entity;
using EbSite.Modules.Shop.ModuleCore.BLL;

namespace EbSite.Modules.Shop.Core.Cart
{
    public class CartProfileProvider : EbSite.Base.EBProfileBase
    {
        private const string PROFILE_SHOPPINGCART = "eBSiteShopingCart";
        public override void Initialize(string name, NameValueCollection config)
        {
            base.Initialize(name, config);
           EbSite.Base.EBSiteEvents.EDeleteProfilesArgs += new EventHandler<DeleteProfilesArgs>(DeleteProfile);

        }
        private  void DeleteProfile(object sender, DeleteProfilesArgs arg)
        {
            CheckUserName(arg.UserName);
            int uniqueID = GetProfileUniqueID(arg.UserName, false, true, applicationName);
            BLL.Buy_CartItem.Instance.DeleteByUniqueID(uniqueID);

        }

        public override SettingsPropertyValueCollection GetPropertyValues(SettingsContext context, SettingsPropertyCollection collection)
        {
            string username = (string)context["UserName"];
            bool isAuthenticated = (bool)context["IsAuthenticated"];

            SettingsPropertyValueCollection svc = new SettingsPropertyValueCollection();
            int uniqueID = GetProfileUniqueID(username, isAuthenticated, false, ApplicationName);
            if (uniqueID == 0)
                return svc;
            foreach (SettingsProperty prop in collection)
            {
                SettingsPropertyValue pv = new SettingsPropertyValue(prop);

                switch (pv.Property.Name)
                {
                    case PROFILE_SHOPPINGCART:
                        pv.PropertyValue = GetCartItems(uniqueID);
                        break;
                }

                svc.Add(pv);
            }
            return svc;
        }

        public override void SetPropertyValues(SettingsContext context, SettingsPropertyValueCollection collection)
        {

            string username = (string)context["UserName"];
            CheckUserName(username);
            bool isAuthenticated = (bool)context["IsAuthenticated"];
            int uniqueID = GetProfileUniqueID(username, isAuthenticated, false, ApplicationName);
            if (uniqueID == 0)
                uniqueID = CreateProfileForUser(username, isAuthenticated, ApplicationName);

            foreach (SettingsPropertyValue pv in collection)
            {

                if (pv.PropertyValue != null)
                {
                    switch (pv.Property.Name)
                    {
                        case PROFILE_SHOPPINGCART:
                            SetCartItems(uniqueID, (CartManger)pv.PropertyValue);
                            break;
                     
                    }
                }
            }

            UpdateActivityDates(username, false);
        }

        private static CartManger GetCartItems(int uniqueID)
        {

            return Buy_CartItem.Instance.GetCartManger(uniqueID, applicationName);

            //CartManger cart = new CartManger();
            //List<ModuleCore.Entity.Buy_CartItem> lst = ModuleCore.BLL.Buy_CartItem.Instance.GetCartItems(uniqueID,
            //                                                                                               applicationName);
            //foreach (ModuleCore.Entity.Buy_CartItem cartItem in lst)
            //{
            //    //需要优化查询
            //   cartItem.SelOptionItems =  ModuleCore.BLL.cartproductoptionvalue.Instance.GetListArrayByCarItemID(cartItem.CartNumber);
            //   cartItem.Gives = ModuleCore.BLL.giftcartproduct.Instance.GetListArrayByCarItemID(cartItem.CartNumber);

            //   cart.Add(cartItem);
            //}
            //return cart;
        }

        private static void SetCartItems(int uniqueID, CartManger cart)
        {
            Buy_CartItem.Instance.SetCartItems(uniqueID, cart);
            //Buy_CartItem.Instance.SetCartItems(uniqueID, cart.CartItems);
        }

    }
}