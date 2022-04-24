using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EbSite.Modules.Shop.Core.Cart
{
    public class GroupCart
    {
        static  public CartManger GetGroupCart(int ProductID, int Quantity, string normid,int gid)
        {
            CartManger cm = new CartManger();
            cm.Add(ProductID, Quantity, normid,gid,0);

            cm.UpdateGroupActivityInfo();

            return cm;

        }
    }
}