using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EbSite.Modules.Shop.ModuleCore.BLL.GRShow
{
    public class Rush : IBase
    {
        public override void AutoSetGroupStaus()
        {
            ModuleCore.BLL.CountDownBuy.Instance.AutoSetGroupStaus();
        }
        public override GRShowModel GetEntity(int iGroupID)
        {
            ModuleCore.Entity.CountDownBuy ModelG = ModuleCore.BLL.CountDownBuy.Instance.GetEntity(iGroupID);

            GRShowModel m = new GRShowModel();
            m.id = ModelG.id;
            m.EndDate = ModelG.EndDate;
            m.Title = ModelG.Title;
            m.ProductID = ModelG.ProductId;
            m.Price = ModelG.Price;
            m.BuyPrice = ModelG.CountDownPrice;
            m.Status = ModelG.Status;
            //m.BuyCount = 0;
            m.Buyed = ModelG.Buyed;
            m.Content = ModelG.Content;
            return m;

        }
    }
}