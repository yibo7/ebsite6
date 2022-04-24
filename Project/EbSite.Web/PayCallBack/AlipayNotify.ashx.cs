using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using EbSite.Base.EBSiteEventArgs;
using EbSite.Web.PayCallBack.AlipayBLL;

namespace EbSite.Web.PayCallBack
{
    /// <summary>
    /// Summary description for AlipayNotify
    /// </summary>
    public class AlipayNotify : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            SortedDictionary<string, string> sPara = GetRequestPost(context);
            EbSite.Base.Host.Instance.InsertLog("有返回", "有返回");
            if (sPara.Count > 0)//判断是否有带返回参数
            {
                string PaymentName = context.Request.Form["body"];
                if(!string.IsNullOrEmpty(PaymentName))
                {
                    Notify aliNotify = new Notify(PaymentName);

                    bool verifyResult = aliNotify.Verify(sPara, context.Request.Form["notify_id"], context.Request.Form["sign"]);

                    if (verifyResult)//验证成功
                    {
                        //获取支付宝的通知返回参数，可参考技术文档中服务器异步通知参数列表
                        string trade_no = context.Request.Form["trade_no"];         //支付宝交易号
                        string order_no = context.Request.Form["out_trade_no"];     //获取订单号
                        string total_fee = context.Request.Form["total_fee"];       //获取总金额
                        string subject = context.Request.Form["subject"];           //商品名称、订单名称
                        //string body = context.Request.Form["body"];                 //商品描述、订单备注、描述
                        string buyer_email = context.Request.Form["buyer_email"];   //买家支付宝账号
                        string trade_status = context.Request.Form["trade_status"]; //交易状态

                        EbSite.Base.Host.Instance.InsertLog("支付宝回馈,验证成功", "支付宝回馈,验证成功,订单号:" + order_no);
                        PayedEventArgs mea = new PayedEventArgs(trade_no, order_no, total_fee, subject, buyer_email, trade_status, PaymentName);
                        EbSite.Base.EBSiteEvents.OnPayed(null, mea);
                        context.Response.Write("success");  
                    }
                    else//验证失败
                    {
                        EbSite.Base.Host.Instance.InsertLog("支付宝回馈,验证失败", "支付宝回馈,验证失败:");
                        context.Response.Write("fail");
                    } 
                }
                else
                {
                    context.Response.Write("找不到支付接口");
                    EbSite.Base.Host.Instance.InsertLog("支付宝回馈,找不到支付接口", "找不到支付接口");
                }
                
                
            }
            else
            {
                context.Response.Write("无通知参数");
                EbSite.Base.Host.Instance.InsertLog("支付宝回馈,无通知参数", "无通知参数");
            }
            
        }

        /// <summary>
        /// 获取支付宝POST过来通知消息，并以“参数名=参数值”的形式组成数组
        /// </summary>
        /// <returns>request回来的信息组成的数组</returns>
        public SortedDictionary<string, string> GetRequestPost(HttpContext context)
        {
            int i = 0;
            SortedDictionary<string, string> sPara = new SortedDictionary<string, string>();
            NameValueCollection coll;
            //Load Form variables into NameValueCollection variable.
            coll = context.Request.Form;

            // Get names of all forms into a string array.
            String[] requestItem = coll.AllKeys;

            for (i = 0; i < requestItem.Length; i++)
            {
                sPara.Add(requestItem[i], context.Request.Form[requestItem[i]]);
            }

            return sPara;
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}