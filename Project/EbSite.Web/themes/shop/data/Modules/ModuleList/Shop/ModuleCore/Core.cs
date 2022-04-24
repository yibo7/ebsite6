using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EbSite.Modules.Shop.ModuleCore
{
    public class Core
    {
        public static string GetRandomCode(int CodeCount)
        {
            string allChar = "0,1,2,3,4,5,6,7,8,9,A,B,C,D,E,F,G,H,i,J,K,M,N,P,Q,R,S,T,U,W,X,Y,Z";
            string[] allCharArray = allChar.Split(',');
            string RandomCode = "";
            int temp = -1;

            Random rand = new Random();
            for (int i = 0; i < CodeCount; i++)
            {
                if (temp != -1)
                {
                    rand = new Random(temp * i * ((int)DateTime.Now.Ticks));
                }

                int t = rand.Next(33);

                while (temp == t)
                {
                    t = rand.Next(33);
                }

                temp = t;
                RandomCode += allCharArray[t];
            }

            return RandomCode;
        }
        /// <summary>
        /// 计算 折扣
        /// </summary>
        /// <param name="oldPrice"></param>
        /// <param name="nowPrice"></param>
        /// <returns></returns>
        public static string GetDiscountRate(object oldPrice, object nowPrice)
        {
            string result = "";
            if (oldPrice != null && nowPrice != null)
            {
                decimal l = (decimal)oldPrice;
                decimal n = (decimal)nowPrice;
                if (l > n)
                {
                    result = (Math.Round(n*100 / l, 0)).ToString();
                }
            }
            return result;
        }
        /// <summary>
        /// 商品出库
        /// </summary>
        /// <param name="Sku">商品编码 如：JY20740-1</param>
        /// <param name="ProductId">产品ID</param>
        /// <param name="Count">出库的数量</param>
        public static void OutStore(string Sku, int ProductId, int Count,int SiteID)
        {
            EbSite.Entity.NewsContent Model = Base.AppStartInit.NewsContentInstDefault.GetModel(ProductId,SiteID);
            if (!Equals(Model, null))
            {
                Model.Annex21 += Count;//总销量  //可能有bug 2013-08-30
                if (Model.Annex1 == Sku)//说明此商品 是价格最低的那一款。
                {
                    Model.Annex12 -= Count;//库量
                }
                Base.AppStartInit.NewsContentInstDefault.Update(Model);

                List<ModuleCore.Entity.NormRelationProduct> ls =
                    ModuleCore.BLL.NormRelationProduct.Instance.GetListArray(1, string.Concat("pnumber='",Sku ,"' and productid=",ProductId), "");

                if (ls.Count > 0)
                {
                    ModuleCore.Entity.NormRelationProduct md = ls[0];
                    md.Stocks -= Count;

                    md.Update();
                }
            }
        }
        /// <summary>
        /// 检测 库存时是否充足
        /// </summary>
        /// <param name="OrderId"></param>
        /// <returns></returns>
        public string CheckStore(int OrderId)
        {
            string sInfo = "";




            return sInfo;
        }

        /// <summary>
        /// 退货
        /// </summary>
        /// <param name="Sku">商品编码</param>
        /// <param name="ProductId">产品ID</param>
        /// <param name="Count">出库数量</param>
        public static void ReturnGoods(string Sku, int ProductId, int Count,int SiteID)
        {
            EbSite.Entity.NewsContent Model = Base.AppStartInit.NewsContentInstDefault.GetModel(ProductId,SiteID);
            if (!Equals(Model, null))
            {
                Model.Annex21 -= Count;//总销量  //可能有bug 2013-08-30
                if (Model.Annex1 == Sku)//说明此商品 是价格最低的那一款。
                {
                    Model.Annex12 += Count;//库量
                }
                Base.AppStartInit.NewsContentInstDefault.Update(Model);

                List<ModuleCore.Entity.NormRelationProduct> ls =
                    ModuleCore.BLL.NormRelationProduct.Instance.GetListArray(1, string.Concat("pnumber='", Sku, "' and productid=", ProductId), "");

                if (ls.Count > 0)
                {
                    ModuleCore.Entity.NormRelationProduct md = ls[0];
                    md.Stocks += Count;

                    md.Update();
                }
            }
        }
    }
}