using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
    

namespace EbSite.Plugin.Payment
{
    public enum AliPayPayType
    {
        普通支付=0,
        网银支付=1,
        快捷支付信用卡支付=2,
        快捷储蓄卡支付 = 3

    }
    public class AliPay
    {

        #region Core

        /// <summary>
        /// 生成签名结果
        /// </summary>
        /// <param name="sArray">要签名的数组</param>
        /// <param name="key">安全校验码</param>
        /// <param name="sign_type">签名类型</param>
        /// <param name="_input_charset">编码格式</param>
        /// <returns>签名结果字符串</returns>
        public static string BuildMysign(Dictionary<string, string> dicArray, string key, string sign_type, string _input_charset)
        {
            string prestr = CreateLinkString(dicArray);  //把数组所有元素，按照“参数=参数值”的模式用“&”字符拼接成字符串

            prestr = prestr + key;                      //把拼接后的字符串再与安全校验码直接连接起来
            string mysign = Sign(prestr, sign_type, _input_charset);	//把最终的字符串签名，获得签名结果

            return mysign;
        }

        ///// <summary>
        ///// 除去数组中的空值和签名参数并以字母a到z的顺序排序
        ///// </summary>
        ///// <param name="dicArrayPre">过滤前的参数组</param>
        ///// <returns>过滤后的参数组</returns>
        public static Dictionary<string, string> FilterPara(SortedDictionary<string, string> dicArrayPre)
        {
            Dictionary<string, string> dicArray = new Dictionary<string, string>();
            foreach (KeyValuePair<string, string> temp in dicArrayPre)
            {
                if (temp.Key.ToLower() != "sign" && temp.Key.ToLower() != "sign_type" && temp.Value != "" && temp.Value != null)
                {
                    dicArray.Add(temp.Key.ToLower(), temp.Value);
                }
            }

            return dicArray;
        }

        /// <summary>
        /// 把数组所有元素，按照“参数=参数值”的模式用“&”字符拼接成字符串
        /// </summary>
        /// <param name="sArray">需要拼接的数组</param>
        /// <returns>拼接完成以后的字符串</returns>
        public static string CreateLinkString(Dictionary<string, string> dicArray)
        {
            StringBuilder prestr = new StringBuilder();
            foreach (KeyValuePair<string, string> temp in dicArray)
            {
                prestr.Append(temp.Key + "=" + temp.Value + "&");
            }

            //去掉最後一個&字符
            int nLen = prestr.Length;
            prestr.Remove(nLen - 1, 1);

            return prestr.ToString();
        }

        /// <summary>
        /// 把数组所有元素，按照“参数=参数值”的模式用“&”字符拼接成字符串，并对参数值做urlencode
        /// </summary>
        /// <param name="sArray">需要拼接的数组</param>
        /// <param name="code">字符编码</param>
        /// <returns>拼接完成以后的字符串</returns>
        public static string CreateLinkStringUrlencode(Dictionary<string, string> dicArray, Encoding code)
        {
            StringBuilder prestr = new StringBuilder();
            foreach (KeyValuePair<string, string> temp in dicArray)
            {
                prestr.Append(temp.Key + "=" + HttpUtility.UrlEncode(temp.Value, code) + "&");
            }

            //去掉最後一個&字符
            int nLen = prestr.Length;
            prestr.Remove(nLen - 1, 1);

            return prestr.ToString();
        }

        /// <summary>
        /// 签名字符串
        /// </summary>
        /// <param name="prestr">需要签名的字符串</param>
        /// <param name="sign_type">签名类型</param>
        /// <param name="_input_charset">编码格式</param>
        /// <returns>签名结果</returns>
        public static string Sign(string prestr, string sign_type, string _input_charset)
        {
            StringBuilder sb = new StringBuilder(32);
            if (sign_type.ToUpper() == "MD5")
            {
                MD5 md5 = new MD5CryptoServiceProvider();
                byte[] t = md5.ComputeHash(Encoding.GetEncoding(_input_charset).GetBytes(prestr));
                for (int i = 0; i < t.Length; i++)
                {
                    sb.Append(t[i].ToString("x").PadLeft(2, '0'));
                }
            }
            return sb.ToString();
        }

        #endregion



        //private static string[] BubbleSort(string[] r)
        //{
        //    for (int i = 0; i < r.Length; i++)
        //    {
        //        bool flag = false;
        //        for (int j = r.Length - 2; j >= i; j--)
        //        {
        //            if (string.CompareOrdinal(r[j + 1], r[j]) < 0)
        //            {
        //                string str = r[j + 1];
        //                r[j + 1] = r[j];
        //                r[j] = str;
        //                flag = true;
        //            }
        //        }
        //        if (!flag)
        //        {
        //            return r;
        //        }
        //    }
        //    return r;
        //}
        /// <summary>
        /// 支付宝 传递参数
        /// </summary>
        /// <param name="gateway">支付接口 地址</param>
        /// <param name="service">服务名称。这个是用来标明当前接口是什么接口。因为每种接口都有属于自己的服务名称，支付宝为了辨识每种接口，就在这些接口上加了名称以示区别。因此这个参数的值不需要改动。按照不同的接口技术文档中的参数列表，对其赋于固定的值。即时到帐接口服务名称的值是：create_direct_pay_by_user</param>
        /// <param name="partner">合作者身份</param>
        /// <param name="sign_type"> 加密方式 MD5</param>
        /// <param name="out_trade_no">年月日 单号 流水单号</param>
        /// <param name="subject">客户的真实订单ID</param>
        /// <param name="body">商品描述。说的更为形象一些，它是该笔订单的备注、明细、描述等。ID</param>
        /// <param name="payment_type">1 默认是1</param>
        /// <param name="total_fee">总金额</param>
        /// <param name="show_url">展示地址，即在支付宝页面时商品名称旁边的“详情”的链接地址 </param>
        /// <param name="seller_email">Email地址 支付宝认证Email,必须通过支付宝认证才可以</param>
        /// <param name="key">交易安全校验码</param>
        /// <param name="return_url">PayCallBack/Alipay.aspx</param>
        /// <param name="_input_charset">utf-8</param>
        /// <param name="notify_url">PayCallBack/Alipay.aspx</param>
        /// <param name="logistics_type">"EXPRESS";//物流类型，三个值可选：EXPRESS（快递）、POST（平邮）、EMS（EMS）</param>
        /// <param name="logistics_fee">物流配送费用</param> 
        /// <param name="logistics_payment">物流配送费用付款方式：SELLER_PAY(卖家支付)、BUYER_PAY(买家支 付)</param>
        /// <param name="logistics_type_1">第二组物流类型</param>
        /// <param name="logistics_fee_1">第二组物流配送费用</param>
        /// <param name="logistics_payment_1">第二组物流配送方式</param>
        /// <param name="quantity">购买数量,price、quantity能代替total_fee。即存在total_fee，就不能存在price和quantity；存在price、quantity，就不能存在total_fee。 </param>
        /// <param name="agent">如果一些交易网站的交易，有一定的“代理”所属关系，代理商可以在交易中传递该参数，来表明代理的身份。这里传送的值，请使用代理商所属支付宝账户的PartnerID。</param>
        /// <returns></returns>
        public string CreatUrl(string gateway, string service, string partner, string sign_type, string out_trade_no, string subject, string body, string payment_type, string total_fee, string show_url, string seller_email, string key, string return_url, string _input_charset, string notify_url, string logistics_type, string logistics_fee, string logistics_payment, string logistics_type_1, string logistics_fee_1, string logistics_payment_1, string quantity, string agent, string defaultbank, AliPayPayType aliPayPayType)
        {
            
            SortedDictionary<string, string> sParaTemp = new SortedDictionary<string, string>();
            sParaTemp.Add("service", service);
            sParaTemp.Add("partner", partner);
            sParaTemp.Add("subject", subject);
            sParaTemp.Add("body", body);
            sParaTemp.Add("out_trade_no", out_trade_no);
            sParaTemp.Add("seller_email", seller_email);
            sParaTemp.Add("_input_charset", _input_charset);
            sParaTemp.Add("notify_url", notify_url);
            sParaTemp.Add("return_url", return_url);
            
            if (!string.IsNullOrEmpty(show_url))
                sParaTemp.Add("show_url", show_url);
            if (aliPayPayType==AliPayPayType.普通支付)
            {
                sParaTemp.Add("payment_type", payment_type);
                sParaTemp.Add("price", total_fee);
                sParaTemp.Add("quantity", quantity);
                sParaTemp.Add("logistics_type", logistics_type);
                sParaTemp.Add("logistics_fee", logistics_fee);
                sParaTemp.Add("logistics_payment", logistics_payment);
                sParaTemp.Add("logistics_type_1", logistics_type_1);
                sParaTemp.Add("logistics_fee_1", logistics_fee_1);
                sParaTemp.Add("agent", agent);
                sParaTemp.Add("logistics_payment_1", logistics_payment_1);
            }
            else if (aliPayPayType == AliPayPayType.网银支付)
            {
                sParaTemp.Add("payment_type", "1");
                sParaTemp.Add("total_fee", total_fee);
                sParaTemp.Add("paymethod", "bankPay");
                sParaTemp.Add("defaultbank", defaultbank);
            }
            

            //待请求参数数组
            Dictionary<string, string> dicPara = new Dictionary<string, string>();
            dicPara = BuildRequestPara(sParaTemp, key, "MD5", _input_charset);

            StringBuilder sbPram = new StringBuilder(gateway);
            //输出url连接
            foreach (KeyValuePair<string, string> temp in dicPara)
            {
                sbPram.Append(temp.Key);
                sbPram.Append("=");
                sbPram.Append(HttpUtility.UrlEncode(temp.Value));
                sbPram.Append("&");
            }
            sbPram.Remove(sbPram.Length-1,1);
            //输出表单暂时没用到
            //sbPram.Append("<form id='alipaysubmit' name='alipaysubmit' action='" + gateway + "_input_charset=" + _input_charset + "' method='get'>");
            //foreach (KeyValuePair<string, string> temp in dicPara)
            //{
            //    sbPram.Append("<input type='hidden' name='" + temp.Key + "' value='" + temp.Value + "'/>");
            //}
            //sbPram.Append("<input type='submit' value='提交支付' style='display:none;'></form>");
            //sbPram.Append("<script>document.forms['alipaysubmit'].submit();</script>");)



            return sbPram.ToString();
        }

       /// <summary>
        /// 生成要请求给支付宝的参数数组
       /// </summary>
       /// <param name="sParaTemp"></param>
       /// <param name="_key">安全效验码</param>
        /// <param name="_sign_type">签名方式</param>
        /// <param name="_input_charset">编码格式</param>
       /// <returns></returns>
        private static Dictionary<string, string> BuildRequestPara(SortedDictionary<string, string> sParaTemp, string _key, string _sign_type, string _input_charset)
        {
            //待签名请求参数数组
            Dictionary<string, string> sPara = new Dictionary<string, string>();
            //签名结果
            string mysign = "";

            //过滤签名参数数组
            sPara = FilterPara(sParaTemp);

            //获得签名结果
            mysign = BuildMysign(sPara, _key, _sign_type, _input_charset);

            //签名结果与签名方式加入请求提交参数组中
            sPara.Add("sign", mysign);
            sPara.Add("sign_type", _sign_type);

            return sPara;
        }

        private string GetNowUrl()
        {
            string input = string.Empty;
            string pattern = @"http://(?<domain>[^\/]*)";
            input = HttpContext.Current.Request.Url.ToString();
            Regex regex = new Regex(pattern, RegexOptions.IgnoreCase);
            return regex.Match(input).Groups["domain"].Value;
        }
        public string GetPayStr(string agent, string paymentAccount, string safetyCode, string cooperationId, string service, string OrderName, string TotalPrice, string path, string PaymentName, string OrderNumber)
        {
           return GetPayStr(agent, paymentAccount, safetyCode, cooperationId, service, OrderName, TotalPrice, path,
                      PaymentName, OrderNumber,"", AliPayPayType.普通支付);
        }

        /// <summary>
        /// 调支付接口
        /// </summary>
        /// <param name="agent">商家的身份ID</param>
        /// <param name="paymentAccount">支付宝帐号 email</param>
        /// <param name="safetyCode">交易安全校验码</param>
        /// <param name="cooperationId">合作者身份</param>
        /// <param name="service">排序方式</param>
        /// <param name="OrderName">订单的ID,流水号，也可以是商品的名称</param>
        /// <param name="TotalPrice">订单交易的总金额</param>
        /// <param name="path">虚拟目录</param>
        /// <returns></returns>
        public string GetPayStr(string agent, string paymentAccount, string safetyCode, string cooperationId, string service, string OrderName, string TotalPrice, string path, string PaymentName, string OrderNumber, string defaultbank, AliPayPayType aliPayPayType)
        {


            string agentNamber = agent;

            DateTime time = new DateTime();
            //string str = DateTime.Now.ToString("g").Replace("-", "").Replace(":", "").Replace(" ", "");
            string out_trade_no = OrderNumber;
            string gateway = "https://www.alipay.com/cooperate/gateway.do?";
            if (aliPayPayType==AliPayPayType.网银支付)
            {
                gateway = "https://mapi.alipay.com/gateway.do?";
            }
            string partner = cooperationId;//strArray[2];
            string sign_type = "MD5";
            string subject = OrderName; //商品名称
            string body = PaymentName;  //用body来传递插件名称    
            string payment_type = "1";       // 支付类型。默认为1，代表商品购买的意思。目前所有的支付接口，这里都设置为1。4为捐赠
            string total_fee = TotalPrice;
            string quantity = "1";
            string show_url = "";// "http://" + this.GetNowUrl() + path + "orderdetail.aspx?id=" + OrderName; ;//商品展示网址。它是商户的订单详细的一个快速入口链接。以方便买家可以在商家网站中查找自己的下单信息。
            string seller_email = paymentAccount;//签约支付宝账号。它俗称收款支付宝账号，因为买家支付的时候看到的收款账号就是它。通常情况下，需要填写签约时候的支付宝账号，而不能是其他支付宝账号。如果签约支付宝账号类型是公司类型，那么在收银台里显示的时候会显示公司名称，如果支付宝账号的类型是个人性质，那么在收银台里显示的时候会显示支付宝账号，即邮箱或手机号。该显示方式无法更改。
            string key = safetyCode;//strArray[1];
            //建议：return_url和notify_url 可以都设置，前者做数据显示，后者做更新数据库
            string return_url = "http://" + this.GetNowUrl() + path + "PayCallBack/Alipay.aspx";//服务器通知返回接口
            string notify_url = "http://" + this.GetNowUrl() + path + "PayCallBack/AlipayNotify.ashx";//服务器通知返回接口
            string _input_charset = "utf-8";
            string logistics_type = "EXPRESS";//物流类型，三个值可选：EXPRESS（快递）、POST（平邮）、EMS（EMS）
            string logistics_fee = "0";//物流费用
            string logistics_payment = "BUYER_PAY";//物流配送费用付款方式：SELLER_PAY(卖家支付)、BUYER_PAY(买家支 付)
            string logistics_type_1 = "POST";
            string logistics_fee_1 = "0";
            string logistics_payment_1 = "BUYER_PAY";  

            return this.CreatUrl(gateway, service, partner, sign_type,
                out_trade_no, subject, body, payment_type, total_fee, show_url,
                seller_email, key, return_url,
                _input_charset, notify_url, logistics_type, logistics_fee, logistics_payment, logistics_type_1, logistics_fee_1, logistics_payment_1, quantity, agentNamber,defaultbank, aliPayPayType);
        }

       
    }
}

