using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EbSite.Modules.Shop.ModuleCore
{
    public class SystemEnum
    {
        /// <summary>
        /// 订单状态类型 订单状态  0.提交订单 (1.审核订单-货到付款 2.等待付款-在线支付)  3.已发货 4.确认收货 5.交易完成 6.回收站  
        /// </summary>
        public enum OrderStatus
        {

            /// <summary>
            /// 提交订单
            /// </summary>
            提交订单 = 0,
            /// <summary>
            /// 审核订单
            /// </summary>
            审核订单 = 1,
            /// <summary>
            /// 等待付款
            /// </summary>
            等待付款 = 2,
            /// <summary>
            /// 已支付
            /// </summary>
            已支付 = 21,//等待付款,
            /// <summary>
            /// 已发货
            /// </summary>
            已发货 = 3,
            /// <summary>
            /// 确认收货
            /// </summary>
            确认收货 = 4,
            /// <summary>
            /// 交易完成
            /// </summary>
            交易完成 = 5,
            /// <summary>
            /// 回收站
            /// </summary>
            回收站 = 6

        }
        /// <summary>
        ///  订单子表状态
        /// </summary>
        public enum OrderItemStatus
        {
            正常 = 0,
            审核中 = 1,
            审核通过 = 2,
            审核失败 = 3,
            已完成 = 4
        }
        /// <summary>
        /// 退换货服务类型
        /// </summary>
        public enum ServiceType
        {
            换货 = 0,
            退货 = 1,
            维修 = 2
        }
        /// <summary>
        /// 退换货凭据类型
        /// </summary>
        public enum ProofType
        {
            有发票有检测报告 = 0,
            有发票无检测报告 = 1,
            有检测报告无发票 = 2
        }
        /// <summary>
        /// 积分来源 类型 
        /// </summary>
        public enum MyPointType : int
        {
            兑换礼品 = 1,
            购物奖励 = 2,
            退款扣积分 = 3,
            关闭订单返还积分 = 4,
            关闭订单扣除奖励积分 = 5,
            兑换优惠券 = 6
        }
        /// <summary>
        /// 团购状态
        /// </summary>
        public enum GroupBuyState
        {
            /// <summary>
            /// 正在进行中
            /// </summary>
            正在进行中 = 0,
            /// <summary>
            /// 成功结束
            /// </summary>
            成功结束 = 1,
            /// <summary>
            ///失败结束 
            /// </summary>
            失败结束 = 2,
            /// <summary>
            /// 还未开始
            /// </summary>
            还未开始 = 3,
            /// <summary>
            /// 结束未处理
            /// </summary>
            结束未处理 = 4
        }
        /// <summary>
        /// 抢购状态
        /// </summary>
        public enum PanicBuyingState
        {
            /// <summary>
            /// 正在进行中
            /// </summary>
            正在进行中 = 0,
            /// <summary>
            /// 成功结束
            /// </summary>
            已结束 = 1,

            /// <summary>
            /// 还未开始
            /// </summary>
            还未开始 = 2

        }
        public enum OrderLogType
        {
            前台显示 = 0,
            全部显示 = 1
        }
        /// <summary>
        /// 付款方式
        /// </summary>
        public enum PayType
        {
            货到付款 = -1,
            在线支付 = 0
        }
        /// <summary>
        /// 预付款收支流水 类型
        /// </summary>
        public enum AccountMoneyLogTradeType : int
        {
            //交易类型 1.自助充值 2.后台加款 3.消费 4.提现 5.订单退款 6.推荐人提成7.提现完成
            /// <summary>
            /// 自助充值
            /// </summary>
            自助充值 = 1,
            后台加款 = 2,
            消费 = 3,
            提现 = 4,
            订单退款 = 5,
            推荐人提成 = 6,
            提现完成 = 7

        }
        /// <summary>
        /// 打印类型
        /// </summary>
        public enum PrintType
        {
            快递单 = 1,
            购货单 = 2,
            配送单 = 3
        }
        /// <summary>
        /// 下单来源
        /// </summary>
        public enum ComeType : int
        {
            /// <summary>
            /// 电脑下单
            /// </summary>
            pc = 0,
            /// <summary>
            /// 手机下单
            /// </summary>
            手机 = 1
        }
    }
}