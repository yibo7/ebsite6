using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using EbSite.Modules.Shop.ModuleCore.Cart;
using EbSite.Modules.Shop.ModuleCore.Entity;

namespace EbSite.Modules.Shop.ModuleCore.Pages
{
    public class MshoppingcarBase : BasePageM
    {
        #region 控件定义
        /// <summary>
        /// repShoppingCart control.
        /// </summary>
        /// <remarks>
        /// Auto-generated field.
        /// To modify move field declaration from designer file to code-behind file.
        /// </remarks>
        protected global::System.Web.UI.WebControls.Repeater repShoppingCart;
        /// <summary>
        /// repCreditCart control.
        /// </summary>
        protected global::System.Web.UI.WebControls.Repeater repCreditCart;

        /// <summary>
        /// ltlCount control.
        /// </summary>
        /// <remarks>
        /// Auto-generated field.
        /// To modify move field declaration from designer file to code-behind file.
        /// </remarks>
        protected global::System.Web.UI.WebControls.Literal ltlCount;

        /// <summary>
        /// ltlTotal control.
        /// </summary>
        /// <remarks>
        /// Auto-generated field.
        /// To modify move field declaration from designer file to code-behind file.
        /// </remarks>
        protected global::System.Web.UI.WebControls.Literal ltlTotal;
        protected global::System.Web.UI.WebControls.Literal ltlTotalProduct;




        protected global::System.Web.UI.WebControls.Literal ltlPoints;
        protected global::System.Web.UI.WebControls.Literal ltlNoGift;
        protected global::System.Web.UI.WebControls.Literal ltlSumPoints;
        protected global::System.Web.UI.WebControls.Literal DiscountInfo;
        protected global::System.Web.UI.HtmlControls.HtmlInputHidden HiScore;



        protected global::System.Web.UI.HtmlControls.HtmlInputHidden txtgroup;//团购id

        protected global::System.Web.UI.HtmlControls.HtmlInputHidden txtrush;//抢购id
        #endregion
        /// <summary>
        /// 是否设置 余额密码
        /// </summary>
        protected bool IsOpenBlance = false;
        /// <summary>
        /// 余额款
        /// </summary>
        protected decimal Balance = 0;
        /// <summary>
        /// 当前购物车商品的重量
        /// </summary>
        protected decimal TotalWeight = 0;
        /// <summary>
        /// 当前购物车商品的钱数
        /// </summary>
        protected decimal TotalMoney = 0;
        /// <summary>
        /// 当前商品数量
        /// 
        /// </summary>
        protected int TotalCount = 0;
        /// <summary>
        /// /是否免运费
        /// </summary>
        protected bool IsFreeEight = false;
        /// <summary>
        /// 是否免支付手续费
        /// </summary>
        protected bool IsFreePay = false;
        /// <summary>
        /// 是否免订单选项费
        /// </summary>
        protected bool IsFreeOrderOption = false;

        public MshoppingcarBase()
        {

            base.Load += new EventHandler(this.MshoppingcarBase_Load);
        }
        private void MshoppingcarBase_Load(object sender, EventArgs e)
        {
            Response.Buffer = true;
            //Response.ExpiresAbsolute = DateTime.Now();
            Response.Expires = 0;
            Response.CacheControl = "no-cache";


            if (!string.IsNullOrEmpty(Request["gid"])) //团购
            {
                ProfileCommon profile = (ProfileCommon)HttpContext.Current.Profile;
                if (!string.IsNullOrEmpty(Request.QueryString["pid"]))
                {
                    int itemId = int.Parse(Request.QueryString["pid"]); //商品ID
                    if (itemId > 0)
                    {
                        int Quantity = EbSite.Core.Utils.StrToInt(Request["num"], 1); //购买数量
                        profile.ShopCart = GroupCart.GetGroupCart(itemId, Quantity, Request["normid"],
                                                                  EbSite.Core.Utils.StrToInt(Request["gid"], 0));
                        profile.Save();
                        BindCart(profile.ShopCart);

                        this.txtgroup.Value = Request["gid"].ToString();
                    }
                }
            }
            else if (!string.IsNullOrEmpty(Request["qid"])) //抢购
            {
                ProfileCommon profile = (ProfileCommon)HttpContext.Current.Profile;
                if (!string.IsNullOrEmpty(Request.QueryString["pid"]))
                {
                    int itemId = int.Parse(Request.QueryString["pid"]); //商品ID
                    if (itemId > 0)
                    {
                        int Quantity = EbSite.Core.Utils.StrToInt(Request["num"], 1); //购买数量
                        profile.ShopCart = RushCart.GetRushCart(itemId, Quantity, Request["normid"],
                                                                  EbSite.Core.Utils.StrToInt(Request["qid"], 0));
                        profile.Save();
                        BindCart(profile.ShopCart);

                        this.txtrush.Value = Request["qid"];
                    }
                }

            }
            else if (!string.IsNullOrEmpty(Request.QueryString["jifen"]))//积分礼品
            {
                int itemId = int.Parse(Request.QueryString["jifen"]);//商品ID
                if (itemId > 0)
                {
                    ProfileCommon profile = (ProfileCommon)HttpContext.Current.Profile;
                    //int Quantity = EbSite.Core.Utils.StrToInt(Request["num"], 1); //购买数量
                    profile.ShopCart.AddCredit(itemId); //规格值
                    profile.Save();
                    BindCart(profile.ShopCart);
                    //去除问号的参数，防止刷新
                    string surl = EbSite.Core.Strings.GetString.RegexReplace(Request.RawUrl, "\\?.*", "");
                    Response.Redirect("~" + surl, true);
                    return;
                }
            }
            else if (!string.IsNullOrEmpty(Request.QueryString["pid"]))
            {
                ProfileCommon profile = (ProfileCommon)HttpContext.Current.Profile;

                int itemId = int.Parse(Request.QueryString["pid"]);//商品ID
                if (itemId > 0)
                {

                    int Quantity = EbSite.Core.Utils.StrToInt(Request["num"], 1); //购买数量
                    profile.ShopCart.Add(itemId, Quantity, Request["normid"], Request["otp"]); //规格值
                    profile.Save();


                    if (!string.IsNullOrEmpty(Request.QueryString["pids"]))
                    {
                        string[] apids = Request.QueryString["pids"].Split('_');
                        foreach (string apid in apids)
                        {
                            if (!string.IsNullOrEmpty(apid))
                            {
                                profile.ShopCart.Add(int.Parse(apid), 1, "", ""); //规格值
                                profile.Save();
                                BindCart(profile.ShopCart);
                            }
                        }
                    }

                    //去除问号的参数，防止刷新
                    string surl = EbSite.Core.Strings.GetString.RegexReplace(Request.RawUrl, "\\?.*", "");
                    Response.Redirect("~" + surl, true);
                    return;
                }

                //if (!string.IsNullOrEmpty(Request.QueryString["pid"]))
                //{
                //    int itemId = int.Parse(Request.QueryString["pid"]);//商品ID
                //    if (itemId > 0)
                //    {

                //        int Quantity = EbSite.Core.Utils.StrToInt(Request["num"], 1); //购买数量
                //        profile.ShopCart.Add(itemId, Quantity, Request["normid"], Request["otp"]); //规格值
                //        profile.Save();
                //        //去除问号的参数，防止刷新
                //        string surl = EbSite.Core.Strings.GetString.RegexReplace(Request.RawUrl, "\\?.*", "");
                //        Response.Redirect("~" + surl, true);
                //        return; 
                //    }

                //}    
            }
            else
            {
                ProfileCommon profile = (ProfileCommon)HttpContext.Current.Profile;
                BindCart(profile.ShopCart);
            }




        }
        private void UpdateCartInfo(CartManger ShopCart)
        {
            if (ShopCart.CartItems.Count > 0)
            {
                TotalWeight = ShopCart.TotalWeight;

                TotalCount = ShopCart.Count + ShopCart.CreditCount;


                ltlTotalProduct.Text = ShopCart.TotalRealSellPrice.ToString("f2");

                if (ShopCart.TotalGiveQuantity > 0)
                {
                    ltlCount.Text = string.Format("{2}件 <font color='#005EA7' title='购买{0}件+赠送{1}件={2}件'>(有赠送)</font>",
                                                  ShopCart.Count, ShopCart.TotalGiveQuantity, ShopCart.CountTotal);
                }
                else
                {
                    ltlCount.Text = (ShopCart.CreditCount + ShopCart.Count).ToString();
                }

                if (ShopCart.DiscountAmount > 0)
                {

                    //TotalMoney = profile.ShopCart.OrderTotal;
                    ltlTotal.Text =
                        string.Format(
                            "{0}元 <span style='font-size:9px; color:red; text-decoration:overline;'>原价:{1}</span>",
                            ShopCart.OrderTotal, ShopCart.TotalMember);

                }
                else
                {
                    //TotalMoney = profile.ShopCart.TotalMember;
                    ltlTotal.Text = string.Concat(ShopCart.TotalMember, "元");
                }

                TotalMoney = ShopCart.OrderTotal;

            }


            ltlPoints.Text = ShopCart.TotalPoints.ToString();
            StringBuilder sb = new StringBuilder();
            if (ShopCart.DiscountId > 0)
            {
                //yhl 2013-08-27  profile.ShopCart.TotalMember - profile.ShopCart.DiscountAmount
                sb.AppendFormat("<a href='#' style='color:#ff0000;text-decoration:underline' title='{1}'>-{0}</a>&nbsp;",
                    ShopCart.DiscountAmount
                    , ShopCart.DiscountName
                    );

            }
            if (ShopCart.ActivityId > 0)
            {
                sb.AppendFormat("<a href='#' title='{0}' >已免费用</a>(", ShopCart.ActivityName);
                if (ShopCart.EightFree)
                {
                    IsFreeEight = true;
                    sb.Append("<span>免运费 </span>");
                }
                if (ShopCart.PayFreeFree)
                {
                    IsFreePay = true;
                    sb.Append("<span>支付手续 </span>");
                }
                if (ShopCart.OrderOptionFree)
                {
                    IsFreeOrderOption = true;
                    sb.Append("<span>订单选项费 </span>");
                }
                sb.Append(")");
            }
            if (sb.Length == 0)
            {
                sb.Append("无");
            }
            DiscountInfo.Text = sb.ToString();
           

        }
        /// <summary>
        /// Bind repeater to Cart object in Profile
        /// </summary>
        protected void BindCart(CartManger ShopCart)
        {

            repShoppingCart.ItemDataBound += repShoppingCart_ItemDataBound;
            if (string.IsNullOrEmpty(Request["gid"]) && string.IsNullOrEmpty(Request["qid"])) //团购 抢购 都没有 赠品
            {
                //更新活动信息
                ShopCart.UpdateActivityInfo();
            }
            ICollection<ModuleCore.Entity.Buy_CartItem> cart = ShopCart.CartItems;

            if (cart.Count > 0)
            {
                repShoppingCart.DataSource = cart;
                repShoppingCart.DataBind();

                UpdateCartInfo(ShopCart);
            }
            else
            {
                ltlTotalProduct.Text = "0";
                ltlPoints.Text = "0";
                DiscountInfo.Text = "无";
                ltlTotal.Text = "0";
                ltlCount.Text = ShopCart.CreditCount.ToString();
                TotalCount = ShopCart.Count + ShopCart.CreditCount;
                
            }
            //积分兑换商品 所需积分
            HtmlInputHidden hiddenScore = this.Page.FindControl("HiScore") as HtmlInputHidden;
            if (!Equals(hiddenScore, null))
                hiddenScore.Value = ShopCart.CreditSocre.ToString();
            //else
            //{
            //    repShoppingCart.Visible = false;

            //}
            if (ShopCart.CreditCartItems.Count > 0 && ShopCart.CreditCartItems != null)
            {
                repCreditCart.DataSource = ShopCart.CreditCartItems;
                repCreditCart.DataBind();
            }
            else
            {
                repCreditCart.DataSource = null;
                repCreditCart.DataBind();
            }


        }

        /// <summary>
        /// 商品选项费用 总计 yhl 2013-08-28
        /// </summary>
        //public decimal TotalProductOptionFee;

        protected void repShoppingCart_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
            {
                Repeater rpProductOptons = (Repeater)e.Item.FindControl("rpProductOptons");
                Buy_CartItem mdItem = e.Item.DataItem as Buy_CartItem;
                if (!Equals(mdItem, null))
                {
                    if (!Equals(rpProductOptons, null))
                    {
                        //List<cartproductoptionvalue> ls = mdItem.SelOptionItems;
                        //foreach (var cartproductoptionvalue in ls)
                        //{
                        //    TotalProductOptionFee += cartproductoptionvalue.TotalPrice;
                        //}
                        rpProductOptons.DataSource = mdItem.SelOptionItems;
                        rpProductOptons.DataBind();

                    }

                    Repeater rpGiveProducts = (Repeater)e.Item.FindControl("rpGiveProducts");
                    if (!Equals(rpGiveProducts, null))
                    {
                        rpGiveProducts.DataSource = mdItem.Gives;
                        rpGiveProducts.DataBind();
                    }
                }

            }
        }

    }
}