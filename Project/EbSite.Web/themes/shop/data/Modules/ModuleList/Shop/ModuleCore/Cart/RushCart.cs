using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EbSite.Modules.Shop.ModuleCore.Cart
{
    public class RushCart
    {
        static  public CartManger GetRushCart(int ProductID, int Quantity, string normid,int qid)
        {
            CartManger cm = new CartManger();
            cm.Add(ProductID, Quantity, normid,0,qid);

            cm.UpdateGroupActivityInfo();

            return cm;

        }
    }
}