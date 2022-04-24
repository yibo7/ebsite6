using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EbSite.Modules.Shop.ModuleCore.BLL.GRShow
{
    public class Group : IBase
    {
        public override void AutoSetGroupStaus()
        {
            ModuleCore.BLL.GroupBuy.Instance.AutoSetGroupStaus();
        }
        public override GRShowModel GetEntity(int iGroupID)
        {
            ModuleCore.Entity.GroupBuy ModelG = ModuleCore.BLL.GroupBuy.Instance.GetEntity(iGroupID);

            GRShowModel m = new GRShowModel();
            m.EndDate = ModelG.EndDate;
            m.Title = ModelG.Title;
            m.ProductID = ModelG.ProductID;
            m.Price = ModelG.Price;
            m.BuyPrice = ModelG.BuyPrice;
            m.Status = ModelG.Status;
            m.BuyCount = ModelG.BuyCount;
            m.Buyed = EbSite.Core.Utils.StrToInt(ModelG.Buyed.ToString(),0);
            m.Content = ModelG.Content;
            m.id = ModelG.id;
            return m;

        }
    }
}