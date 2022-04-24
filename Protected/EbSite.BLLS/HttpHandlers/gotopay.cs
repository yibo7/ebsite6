using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using EbSite.Base.EBSiteEventArgs;

namespace EbSite.BLL.HttpHandlers
{
    /// <summary>
    /// Summary description for gotopay
    /// </summary>
    public class gotopay : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string sOrderNamber = context.Request["OrderNamber"];
            string sMoney = context.Request["PayMoney"];
            string sDemo = context.Request["PayInfo"];
            string sPaymentID = context.Request["paymentapi"];
            string sPayKey = context.Request["PayKey"];
            if (!string.IsNullOrEmpty(sOrderNamber) && !string.IsNullOrEmpty(sMoney) && !string.IsNullOrEmpty(sPaymentID) && !string.IsNullOrEmpty(sPayKey))
            {

                //string CurrentPayKey = EbSite.Base.Host.Instance.EncodeByKey(string.Format("{0}-{1}", sOrderNamber, sMoney));
                //if(CurrentPayKey==sPayKey) //使用支付价格与订单号验证数据安全
                //{
                //    int iPaymentID = int.Parse(sPaymentID);
                //    decimal dPayMoney = decimal.Parse(sMoney);
                //    Entity.Payment pInfo = EbSite.BLL.Payment.Instance.GetEntity(iPaymentID);
                //    context.Response.Redirect(pInfo.GetPayLink(dPayMoney, sOrderNamber, sDemo));
                //}
                //else
                //{
                //    context.Response.Redirect(EbSite.Base.Host.Instance.GetErrPageRw("7"));
                //}

                int iPaymentID = int.Parse(sPaymentID);
                decimal dPayMoney = decimal.Parse(sMoney);
                Entity.Payment pInfo = EbSite.BLL.Payment.Instance.GetEntity(iPaymentID);

                GotoPayEventArgs mea = new GotoPayEventArgs(long.Parse(sOrderNamber), dPayMoney, sDemo, pInfo, sPayKey, context);
                EbSite.Base.EBSiteEvents.OnGotoPay(null, mea);
                if (!mea.IsStop)
                {
                    string sUrlPay = pInfo.GetPayLink(dPayMoney, sOrderNamber, sDemo);
                    if (!string.IsNullOrEmpty(sUrlPay))
                        context.Response.Redirect(sUrlPay);
                    else
                    {
                        context.Response.Redirect(EbSite.Base.Host.Instance.GetTips("定向到支付平台时发生错误,获取不到支付平台地址，确定是否已经安装此支付插件！"));
                    }
                }



            }
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
