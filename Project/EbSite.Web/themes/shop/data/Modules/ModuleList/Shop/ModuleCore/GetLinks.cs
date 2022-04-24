using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EbSite.Modules.Shop.ModuleCore
{
    public class GetLinks
    {

        public static readonly GetLinks Instance = new GetLinks();

        #region 查看定单详情
        private static string ViewOrderUrlRule = "{0}vieworder-{1}-{2}.ashx";
        public  string RegexViewOrderUrlRule()
        {
            return string.Format(ViewOrderUrlRule, "", "([0-9]+)", "([0-9]+)");
        }

        /// <summary>
        /// 获取查看定单详情页面url
        /// </summary>
        /// <param name="siteid">站点ID</param>
        /// <param name="orderid">定单ID</param>
        /// <returns></returns>
        public  string GetViewOrderUrl(int siteid, string orderid)
        {
            return string.Format(ViewOrderUrlRule, EbSite.Base.Host.Instance.IISPath, siteid, orderid);
        }

        #endregion
        
        #region 求团购
        private static string GetGroupUrlRule = "{0}requestgroup-{1}-{2}.ashx";
        public  string RegexGetGroupUrlRule()
        {
            return string.Format(GetGroupUrlRule, "", "([0-9]+)", "([0-9]+)");
        }
        /// <summary>
        /// 获取求团购的连接
        /// </summary>
        /// <param name="siteid">站点ID</param>
        /// <param name="contentid">内容ID</param>
        /// <returns></returns>
        public  string GetGroupUrl(int siteid, int contentid)
        {
            return string.Format("{0}requestgroup-{1}-{2}.ashx", EbSite.Base.Host.Instance.IISPath, siteid, contentid);
        }

        #endregion

        #region 降价通知
        private static string ReducePriceUrlRule = "{0}reduceprice-{1}-{2}.ashx";
        public  string RegexReducePriceUrl()
        {
            return string.Format(ReducePriceUrlRule, "", "([0-9]+)", "([0-9]+)");
        }
        /// <summary>
        /// 获取降价通知的连接
        /// </summary>
        /// <param name="siteid">站点ID</param>
        /// <param name="contentid">内容ID</param>
        /// <returns></returns>
        public  string ReducePriceUrl(int siteid, int contentid)
        {
            return string.Format(ReducePriceUrlRule, EbSite.Base.Host.Instance.IISPath, siteid, contentid);
        }

        #endregion

        #region 商品相册
        private static string PhotoBoxUrlRule = "{0}photobox-{1}-{2}.ashx";
        public  string RegexPhotoBoxUrlRule()
        {
            return string.Format(PhotoBoxUrlRule, "", "([0-9]+)", "([0-9]+)");
        }

        /// <summary>
        /// 获取商品相册连接
        /// </summary>
        /// <param name="siteid">站点ID</param>
        /// <param name="contentid">内容ID</param>
        /// <returns></returns>
        public  string PhotoBoxUrl(int siteid, int contentid)
        {
            return string.Format(PhotoBoxUrlRule, EbSite.Base.Host.Instance.IISPath, siteid, contentid);
        }
        #endregion

        #region 购物车
        private static  string ShoppingCarUrlRule = "{0}shoppingcar-{1}.ashx";
        public  string RegexShoppingCarUrlRule()
        {
            return string.Format(ShoppingCarUrlRule, "", "([0-9]+)");
        }

        private static  string PostCarUrlRule = "{0}postcar-{1}.ashx";
        public  string RegexPostCarUrlRule()
        {
            return string.Format(PostCarUrlRule, "", "([0-9]+)");
        }

        private static  string GoToPayUrlRule = "{0}gotopay-{1}.ashx";
        public  string RegexGoToPayUrlRule()
        {
            return string.Format(GoToPayUrlRule, "", "([0-9]+)");
        }
        /// <summary>
        /// 1.加入到购物车的连接
        /// </summary>
        /// <param name="siteid">站点ID</param>
        /// <param name="contentid">内容ID</param>
        /// <returns></returns>
        public  string ShoppingCarUrl(int siteid, int contentid)
        {
            return string.Format(string.Concat(ShoppingCarUrlRule,"?pid={2}"), EbSite.Base.Host.Instance.IISPath, siteid, contentid);
        }
        public  string ShoppingCarUrlJiFen(int siteid, int contentid)
        {
            return string.Format(string.Concat(ShoppingCarUrlRule,"?jifen={2}"), EbSite.Base.Host.Instance.IISPath, siteid, contentid);
        }
        /// <summary>
        /// 获取购物车地址
        /// </summary>
        /// <param name="siteid">站点ID</param>
        /// <returns></returns>
        public  string ShoppingCarUrl(int siteid)
        {
            return string.Format(ShoppingCarUrlRule, EbSite.Base.Host.Instance.IISPath, siteid);
        }

        public  string ShoppingGroupCarUrl(int siteid, int contentid, int GroupID)
        {
            return string.Format(string.Concat(PostCarUrl(siteid), "?pid={0}&gid={1}"), contentid, GroupID);
        }
        public  string ShoppingPanicBuyUrl(int siteid, int contentid, int GroupID)
        {
            return string.Format(string.Concat(PostCarUrl(siteid), "?pid={0}&qid={1}"), contentid, GroupID);
        }

        /// <summary>
        /// 2.从购物车到核算页面的连接
        /// </summary>
        /// <param name="siteid">站点ID</param>
        /// <returns></returns>
        public  string PostCarUrl(int siteid)
        {
            return string.Format(PostCarUrlRule, EbSite.Base.Host.Instance.IISPath, siteid);
        }
        /// <summary>
        /// 3.从核算页面到支付页面的连接
        /// </summary>
        /// <param name="siteid">站点</param>
        /// <returns></returns>
        public  string GoToPayUrl(int siteid)
        {
            return string.Format(GoToPayUrlRule, EbSite.Base.Host.Instance.IISPath, siteid);
        }

        public  string GoToPayUrl(int siteid, long orderid)
        {
            return string.Format(string.Concat(GoToPayUrlRule, "?orderid={2}"), EbSite.Base.Host.Instance.IISPath, siteid, orderid);
        }

        public  string GoToPayUrlHelp(int siteid, long orderid)
        {
            return string.Format(string.Concat(GoToPayUrlRule,"?orderid={2}&hp=1"), EbSite.Base.Host.Instance.Domain, EbSite.Base.Host.Instance.IISPath, siteid, orderid);
        }

        //public static string GoToPayUrlHelp(int siteid, long orderid)
        //{
        //    return string.Format("{0}{1}gotopay-{2}.ashx?orderid={3}&hp=1", EbSite.Base.Host.Instance.Domain, EbSite.Base.Host.Instance.IISPath, siteid, orderid);
        //}

        #endregion

        #region 团购

        private static  string GroupListRule = "{0}grouplist-{1}-{2}-{3}.ashx";
        public static  string GroupShowRule = "{0}groupshow-{1}-{2}-{3}.ashx";


        public  string RegexGroupListRule()
        {
            return string.Format(GroupListRule, "", "([0-9]+)", "([0-9]+)", "([0-9]+)");
        }
        public  string RegexGroupShowRule()
        {
            return string.Format(GroupShowRule, "", "([0-9]+)", "([0-9]+)", "([0-9]+)");
        }

        /// <summary>
        /// 团购列表页面
        /// </summary>
        /// <param name="siteid">站点ID</param>
        /// <returns></returns>
        public  string GroupList(int siteid,object classid,int pageindex)
        {
            return string.Format(GroupListRule, EbSite.Base.Host.Instance.IISPath, siteid, classid, pageindex);
        }

        public  string GroupList(int siteid)
        {
            return GroupList(siteid, 0, 1);
        }
        public  string GroupListSplitPage(int siteid, object classid)
        {
            return string.Format(GroupListRule, EbSite.Base.Host.Instance.IISPath, siteid, classid, "{0}");
        }
        /// <summary>
        /// 团购内容页面
       /// </summary>
        /// <param name="siteid">站点ID</param>
       /// <param name="gid">团购ID</param>
       /// <param name="id">商品ID</param>
       /// <returns></returns>
        public  string GroupShow(int siteid, object gid, object id)
        {
            return string.Format(GroupShowRule, EbSite.Base.Host.Instance.IISPath, siteid, gid, id);
        }

        #endregion

        #region 抢购

        private static  string RushListRule = "{0}rushlist-{1}-{2}-{3}.ashx";
        private static string RushShowRule = "{0}rushshow-{1}-{2}-{3}.ashx";

        
        public  string RegexRushListRule()
        {
            return string.Format(RushListRule, "", "([0-9]+)", "([0-9]+)", "([0-9]+)");
        }
        public  string RegexRushShowRule()
        {
            return string.Format(RushShowRule, "", "([0-9]+)", "([0-9]+)", "([0-9]+)");
        }
        /// <summary>
        /// 抢购列表页面
        /// </summary>
        /// <param name="siteid">站点ID</param>
        /// <returns></returns>
        public  string RushList(int siteid,object classid,int pageindex)
        {
            return string.Format(RushListRule, EbSite.Base.Host.Instance.IISPath, siteid, classid, pageindex);
        }

        public  string RushListSplitPage(int siteid, object classid)
        {
            return string.Format(RushListRule, EbSite.Base.Host.Instance.IISPath, siteid, classid, "{0}");
        }

        public  string RushList(int siteid)
        {
            return RushList(siteid, 0, 1);
        }

        /// <summary>
        /// 抢购内容页面
       /// </summary>
        /// <param name="siteid">站点ID</param>
        /// <param name="gid">抢购ID</param>
       /// <param name="id">商品ID</param>
       /// <returns></returns>
        public  string RushShow(int siteid, object gid, object id)
        {
            return string.Format(RushShowRule, EbSite.Base.Host.Instance.IISPath, siteid, gid, id);
        }

        #endregion

        #region 优惠活动
        private static  string ActFullMRule = "{0}actfullm-{1}-{2}-{3}.ashx";
        public  string RegexActFullMRule()
        {
            return string.Format(ActFullMRule, "", "([0-9]+)", "([0-9]+)", "([0-9]+)");
        }
        private static  string ActFullQRule = "{0}actfullq-{1}-{2}-{3}.ashx";
        public  string RegexActFullQRule()
        {
            return string.Format(ActFullQRule, "", "([0-9]+)", "([0-9]+)", "([0-9]+)");
        }
        /// <summary>
        /// 满量优惠活动
        /// </summary>
        /// <param name="siteid">站点ID</param>
        /// <param name="activitieid">活动ID</param>
        /// <returns></returns>
        public  string ActFullQuantity(int siteid, object activitieid, int pageindex)
        {
            return string.Format(ActFullQRule, EbSite.Base.Host.Instance.IISPath, siteid, activitieid, pageindex);
        }

        public  string ActFullQuantity(int siteid, object activitieid)
        {
            return ActFullQuantity(siteid, activitieid, 1);
        }

        public string ActFullQuantitySplitPage(int siteid, object activitieid)
        {
            return string.Format(ActFullQRule, EbSite.Base.Host.Instance.IISPath, siteid, activitieid, "{0}");
        }

        /// <summary>
        /// 满额优惠活动
        /// </summary>
        /// <param name="siteid">站点ID</param>
        /// <param name="activitieid">活动ID,为0将调用满额下所有商品,所以在制作导航时设置为0</param>
        /// <returns></returns>
        public  string ActFullMoney(int siteid, object activitieid, int pageindex)
        {
            return string.Format(ActFullMRule, EbSite.Base.Host.Instance.IISPath, siteid, activitieid, pageindex);
        }

        public  string ActFullMoney(int siteid, object activitieid)
        {
            return ActFullMoney(siteid, activitieid, 1);
        }
        #endregion

        #region 积分商城
        private static string JiFenRule = "{0}jifen-{1}-{2}-{3}.ashx";
        public  string RegexJiFenRule()
        {
            return string.Format(JiFenRule, "", "([0-9]+)", "([0-9]+)", "([0-9]+)");
        }

        private static string JiFenShowRule = "{0}jifenshow-{1}-{2}.ashx";
        public  string RegexJiFenShowRule()
        {
            return string.Format(JiFenShowRule, "", "([0-9]+)", "([0-9]+)");
        }
        /// <summary>
        /// 积分商城
        /// </summary>
        /// <param name="siteid"></param>
        /// <returns></returns>
        public  string JiFen(int siteid, object classid,int pageindex)
        {
            return string.Format(JiFenRule, EbSite.Base.Host.Instance.IISPath, siteid, classid, pageindex);
        }

        public string JiFen(int siteid, object classid)
        {
            return JiFen(siteid, classid, 1);
        }

        public  string JiFen(int siteid)
        {
            return JiFen(siteid, 0,1);
        }

        public  string JiFenShow(int siteid, object id)
        {
            return string.Format(JiFenShowRule, EbSite.Base.Host.Instance.IISPath, siteid, id);
        }

        #endregion

        #region 对比页面
        private static string CompareRule = "{0}compare-{1}.ashx";
        public  string RegexCompareRule()
        {
            return string.Format(CompareRule, "", "([0-9]+)");
        }
        /// <summary>
        /// 对比页面
        /// </summary>
        /// <returns></returns>
        public  string Compare(int siteid)
        {
            return string.Format(CompareRule, EbSite.Base.Host.Instance.IISPath, siteid);
        }

        #endregion

        #region 打印订单
        private static string PrintOrderRule = "{0}printorder-{1}-{2}.ashx";
        public  string RegexPrintOrderRule()
        {
            return string.Format(PrintOrderRule, "", "([0-9]+)", "([0-9]+)");
        }
        /// <summary>
        /// 打印订单
        /// </summary>
        /// <returns></returns>
        public  string PrintOrder(int siteid,object orderid)
        {
            return string.Format(PrintOrderRule, EbSite.Base.Host.Instance.IISPath, siteid, orderid);
        }

        #endregion

        #region 订单完成后 评论商品
        private static string TradeCommentRule = "{0}tradecomment-{1}-{2}.ashx";
        public string RegexTradeCommentRule()
        {
            return string.Format(TradeCommentRule, "", "([0-9]+)", "([0-9]+)");
        }

        /// <summary>
        /// 获取查看定单详情页面url
        /// </summary>
        /// <param name="siteid">站点ID</param>
        /// <param name="orderid">定单ID</param>
        /// <returns></returns>
        public string GetViewTradeCommentUrl(int siteid, string orderid)
        {
            return string.Format(TradeCommentRule, EbSite.Base.Host.Instance.IISPath, siteid, orderid);
        }

        #endregion

        #region 以后要去掉了 ，用系统的
        ///// <summary>
        ///// 产品页面
        ///// </summary>
        ///// <param name="siteid"></param>
        ///// <param name="id"></param>
        ///// <returns></returns>
        //public static string Product(int siteid, object id)
        //{
        //    return string.Format("{0}product-{1}-{2}.ashx", EbSite.Base.Host.Instance.IISPath, siteid, id);
        //}

        ///// <summary>
        ///// 产品分类
        ///// </summary>
        ///// <param name="siteid"></param>
        ///// <param name="id"></param>
        ///// <returns></returns>
        //public static string ProductClass(int siteid, object id)
        //{
        //    return string.Format("{0}type-{1}-{2}.ashx", EbSite.Base.Host.Instance.IISPath, siteid, id);
        //}
        #endregion

        #region 手机版 购物车


        private static string MShoppingCarUrlRule = "{0}shoppingcarm-{1}.ashx";
        public string MRegexShoppingCarUrlRule()
        {
            return string.Format(MShoppingCarUrlRule, "", "([0-9]+)");
        }

        private static string MPostCarUrlRule = "{0}postcarm-{1}.ashx";
        public string MRegexPostCarUrlRule()
        {
            return string.Format(MPostCarUrlRule, "", "([0-9]+)");
        }

        private static string MGoToPayUrlRule = "{0}gotopaym-{1}.ashx";
        public string MRegexGoToPayUrlRule()
        {
            return string.Format(MGoToPayUrlRule, "", "([0-9]+)");
        }

       

        /// <summary>
        /// 1.加入到购物车的连接
        /// </summary>
        /// <param name="siteid">站点ID</param>
        /// <param name="contentid">内容ID</param>
        /// <returns></returns>
        public string MShoppingCarUrl(int siteid, int contentid)
        {
            if (contentid > 0)
            {
                return string.Format(string.Concat(MShoppingCarUrlRule, "?pid={2}"), EbSite.Base.Host.Instance.IISPath,
                                     siteid, contentid);
            }
            else
            {
                return string.Format(MShoppingCarUrlRule, EbSite.Base.Host.Instance.IISPath, siteid );
            }
        }
        public string MShoppingCarUrlJiFen(int siteid, int contentid)
        {
            return string.Format(string.Concat(MShoppingCarUrlRule, "?jifen={2}"), EbSite.Base.Host.Instance.IISPath, siteid, contentid);
        }
        /// <summary>
        /// 获取购物车地址
        /// </summary>
        /// <param name="siteid">站点ID</param>
        /// <returns></returns>
        public string MShoppingCarUrl(int siteid)
        {
            return string.Format(MShoppingCarUrlRule, EbSite.Base.Host.Instance.IISPath, siteid);
        }

        public string MShoppingGroupCarUrl(int siteid, int contentid, int GroupID)
        {
            return string.Format(string.Concat(MPostCarUrl(siteid), "?pid={0}&gid={1}"), contentid, GroupID);
        }
        public string MShoppingPanicBuyUrl(int siteid, int contentid, int GroupID)
        {
            return string.Format(string.Concat(MPostCarUrl(siteid), "?pid={0}&qid={1}"), contentid, GroupID);
        }

        /// <summary>
        /// 2.从购物车到核算页面的连接
        /// </summary>
        /// <param name="siteid">站点ID</param>
        /// <returns></returns>
        public string MPostCarUrl(int siteid)
        {
            return string.Format(MPostCarUrlRule, EbSite.Base.Host.Instance.IISPath, siteid);
        }
        /// <summary>
        /// 3.从核算页面到支付页面的连接
        /// </summary>
        /// <param name="siteid">站点</param>
        /// <returns></returns>
        public string MGoToPayUrl(int siteid)
        {
            return string.Format(MGoToPayUrlRule, EbSite.Base.Host.Instance.IISPath, siteid);
        }

        public string MGoToPayUrl(int siteid, long orderid)
        {
            return string.Format(string.Concat(MGoToPayUrlRule, "?orderid={2}"), EbSite.Base.Host.Instance.IISPath, siteid, orderid);
        }

        public string MGoToPayUrlHelp(int siteid, long orderid)
        {
            return string.Format(string.Concat(MGoToPayUrlRule, "?orderid={2}&hp=1"), EbSite.Base.Host.Instance.Domain, EbSite.Base.Host.Instance.IISPath, siteid, orderid);
        }

     

        #endregion

        #region  手机版 查看定单详情
        private static string ViewOrderMUrlRule = "{0}vieworderm-{1}-{2}.ashx";
        public string RegexViewOrderMUrlRule()
        {
            return string.Format(ViewOrderMUrlRule, "", "([0-9]+)", "([0-9]+)");
        }

        /// <summary>
        /// 获取查看定单详情页面url
        /// </summary>
        /// <param name="siteid">站点ID</param>
        /// <param name="orderid">定单ID</param>
        /// <returns></returns>
        public string GetViewOrderMUrl(int siteid, string orderid)
        {
            return string.Format(ViewOrderMUrlRule, EbSite.Base.Host.Instance.IISPath, siteid, orderid);
        }

        #endregion

        #region 手机版 积分商城
        private static string MJiFenRule = "{0}mjifenm-{1}-{2}-{3}.ashx";
        public string RegexMJiFenRule()
        {
            return string.Format(MJiFenRule, "", "([0-9]+)", "([0-9]+)", "([0-9]+)");
        }

        private static string MJiFenShowRule = "{0}mjifenshowm-{1}-{2}.ashx";
        public string RegexMJiFenShowRule()
        {
            return string.Format(MJiFenShowRule, "", "([0-9]+)", "([0-9]+)");
        }
        /// <summary>
        /// 积分商城
        /// </summary>
        /// <param name="siteid"></param>
        /// <returns></returns>
        public string MJiFen(int siteid, object classid, int pageindex)
        {
            return string.Format(MJiFenRule, EbSite.Base.Host.Instance.IISPath, siteid, classid, pageindex);
        }

        public string MJiFen(int siteid, object classid)
        {
            return MJiFen(siteid, classid, 1);
        }

        public string MJiFen(int siteid)
        {
            return MJiFen(siteid, 0, 1);
        }

        public string MJiFenShow(int siteid, object id)
        {
            return string.Format(MJiFenShowRule, EbSite.Base.Host.Instance.IISPath, siteid, id);
        }

        #endregion

        #region 手机版 抢购

        private static string MRushListRule = "{0}rushlistm-{1}-{2}-{3}.ashx";
        private static string MRushShowRule = "{0}rushshowm-{1}-{2}-{3}.ashx";


        public string RegexMRushListRule()
        {
            return string.Format(MRushListRule, "", "([0-9]+)", "([0-9]+)", "([0-9]+)");
        }
        public string RegexMRushShowRule()
        {
            return string.Format(MRushShowRule, "", "([0-9]+)", "([0-9]+)", "([0-9]+)");
        }
        /// <summary>
        /// 抢购列表页面
        /// </summary>
        /// <param name="siteid">站点ID</param>
        /// <returns></returns>
        public string MRushList(int siteid, object classid, int pageindex)
        {
            return string.Format(MRushListRule, EbSite.Base.Host.Instance.IISPath, siteid, classid, pageindex);
        }

        public string MRushListSplitPage(int siteid, object classid)
        {
            return string.Format(MRushListRule, EbSite.Base.Host.Instance.IISPath, siteid, classid, "{0}");
        }

        public string MRushList(int siteid)
        {
            return MRushList(siteid, 0, 1);
        }

        /// <summary>
        /// 抢购内容页面
        /// </summary>
        /// <param name="siteid">站点ID</param>
        /// <param name="gid">抢购ID</param>
        /// <param name="id">商品ID</param>
        /// <returns></returns>
        public string MRushShow(int siteid, object gid, object id)
        {
            return string.Format(MRushShowRule, EbSite.Base.Host.Instance.IISPath, siteid, gid, id);
        }

        #endregion

        #region 手机版 团购

        private static string MGroupListRule = "{0}grouplistm-{1}-{2}-{3}.ashx";
        public static string MGroupShowRule = "{0}groupshowm-{1}-{2}-{3}.ashx";


        public string RegexMGroupListRule()
        {
            return string.Format(MGroupListRule, "", "([0-9]+)", "([0-9]+)", "([0-9]+)");
        }
        public string RegexMGroupShowRule()
        {
            return string.Format(MGroupShowRule, "", "([0-9]+)", "([0-9]+)", "([0-9]+)");
        }

        /// <summary>
        /// 团购列表页面
        /// </summary>
        /// <param name="siteid">站点ID</param>
        /// <returns></returns>
        public string MGroupList(int siteid, object classid, int pageindex)
        {
            return string.Format(MGroupListRule, EbSite.Base.Host.Instance.IISPath, siteid, classid, pageindex);
        }

        public string MGroupList(int siteid)
        {
            return MGroupList(siteid, 0, 1);
        }
        public string MGroupListSplitPage(int siteid, object classid)
        {
            return string.Format(MGroupListRule, EbSite.Base.Host.Instance.IISPath, siteid, classid, "{0}");
        }
        /// <summary>
        /// 团购内容页面
        /// </summary>
        /// <param name="siteid">站点ID</param>
        /// <param name="gid">团购ID</param>
        /// <param name="id">商品ID</param>
        /// <returns></returns>
        public string MGroupShow(int siteid, object gid, object id)
        {
            return string.Format(MGroupShowRule, EbSite.Base.Host.Instance.IISPath, siteid, gid, id);
        }

        #endregion

        #region 手机版 优惠活动
       
        private static string MActFullQRule = "{0}actfullqm-{1}-{2}-{3}.ashx";
        public string RegexMActFullQRule()
        {
            return string.Format(MActFullQRule, "", "([0-9]+)", "([0-9]+)", "([0-9]+)");
        }
        /// <summary>
        /// 满量优惠活动
        /// </summary>
        /// <param name="siteid">站点ID</param>
        /// <param name="activitieid">活动ID</param>
        /// <returns></returns>
        public string MActFullQuantity(int siteid, object activitieid, int pageindex)
        {
            return string.Format(MActFullQRule, EbSite.Base.Host.Instance.IISPath, siteid, activitieid, pageindex);
        }

        public string MActFullQuantity(int siteid, object activitieid)
        {
            return MActFullQuantity(siteid, activitieid, 1);
        }

        public string MActFullQuantitySplitPage(int siteid, object activitieid)
        {
            return string.Format(MActFullQRule, EbSite.Base.Host.Instance.IISPath, siteid, activitieid, "{0}");
        }
        
        #endregion

    }
}