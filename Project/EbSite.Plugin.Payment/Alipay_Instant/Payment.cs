using System.Text.RegularExpressions;
using System.Web;
using EbSite.Base;
using EbSite.Base.Extension;
using EbSite.Base.Extension.Manager;
using EbSite.Base.Plugin;
using EbSite.Base.Plugin.Base;

namespace EbSite.Plugin.Payment.Alipay_Instant
{
    [Extension("支付宝即时到帐接口", "1.0", "<a href=\"http://www.ebsite.net\">小菜菜</a>")]
    public class Payment : AlipayPaymentBase
    {
       override public string aDescription
        {
            get
            {
                return "支付宝即时到帐接口，是支付宝公司针对网上收款、付费、虚拟物品交易而建立的一个安全即时到帐交易平台、无需繁杂的过程即可轻松实现在线交易。";
            }
        }
        /// <summary>
        /// HTML文本显示为插件的帮助配置信息
        /// </summary>
       override public string aConfigHelpHtml
        {
            get
            {
                return @"支付宝即时到帐接口，是支付宝公司针对网上收款、付费、虚拟物品交易而建立的一个安全即时到帐交易平台、无需繁杂的过程即可轻松实现在线交易。按年收取服务费：600元/年包48000元交易量、18000元/年包180000元交易量。<a href=""https://www.alipay.com/himalayas/practicality_customer.htm?customer_external_id=C4335329993464066118&market_type=from_agent_contract&pro_codes=6AECD60F4D75A7FB"" target=""_blank""><font color=""#ff0000""><strong>立即申请</strong></font></a>";
            }
        }
       override public string aAlipayTypeName
       {
           get
           {
               return "create_direct_pay_by_user";
           }
       }
    }
}

