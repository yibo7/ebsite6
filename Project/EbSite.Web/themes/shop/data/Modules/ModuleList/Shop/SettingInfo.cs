using System;
using System.Collections.Generic;
using System.Web;
using EbSite.Base.Modules;

namespace EbSite.Modules.Shop
{
    /// <summary>
    /// 类SettingInfo:系统配置实体，在这里可以添加相关配置属性，调用方法(可参考Setting.ascx):SettingInfo.Instance.CF
    /// 属性ModuleAttribute:是模块的重要信息，请认真填写
    /// </summary>
    [ModuleAttribute("高级商城模块", Version = "1.0.0", Author = "小菜", AuthorUrl = "")]
    public class SettingInfo : EbSite.Base.Modules.Configs.Configs 
    {
        override public Guid CurrentModelID
        {
            get
            {

                return new Guid("cfccc599-4585-43ed-ba31-fdb50024714b");
            }
        }
        public static readonly SettingInfo Instance = new SettingInfo();
        public SettingInfo()
        {
           
        }

		//#region 扩展属性

  //      #region 购物设置
  //      /// <summary>
		///// 是否保存购物车
		///// </summary>
  //      public bool IsSaveShopCar { get; set; }
  //      #endregion

  //      #region 发票设置
  //      /// <summary>
  //      /// 能否开发票
  //      /// </summary>
  //      public bool IsOpenInvoice { get; set; }
  //      /// <summary>
  //      /// 订单税点
  //      /// </summary>
  //      public int OrderTaxPoint { get; set; }
  //      /// <summary>
  //      /// 积分支付比例
  //      /// </summary>
  //      public int ScorePayPoint { get; set; }
  //      #endregion

  //      #region 缺货设置
  //      /// <summary>
  //      /// 是否启用缺货处理
  //      /// </summary>
  //      public bool IsNoGood { get; set; }
  //      /// <summary>
  //      /// 添加缺货登记的对象  0：所有用户 1.注册用户
  //      /// </summary>
  //      public int UserGroup { get; set; } 
  //      #endregion

  //      #region 邮件短信设置
  //      /// <summary>
  //      /// 用户下单完成时是否发邮件
  //      /// </summary>
  //      public bool IsOkEmail { get; set; }
  //      /// <summary>
  //      /// 发货时 是否发邮件
  //      /// </summary>
  //      public bool IsSendEmail { get; set; }
  //      /// <summary>
  //      /// 取消订单时 是否发邮件
  //      /// </summary>
  //      public bool IsCancelEmail { get; set; }
  //      /// <summary>
  //      /// 最小购物金额
  //      /// </summary>
  //      public decimal LessMoney { get; set; }

  //      #endregion

  //      #region 订单设置
  //      /// <summary>
  //      /// 过期几天自动关闭订单
  //      /// </summary>
  //      public int AutoCloseOrderDays { get; set; }
  //      /// <summary>
  //      /// 发货几天自动完成订单
  //      /// </summary>
  //      public int AutoFinishOrderDays { get; set; }
  //      #endregion

  //      #region 打印设置
  //      /// <summary>
  //      /// 是否打印赠品
  //      /// </summary>
  //      public bool IsPrintGift { get; set; }
  //      #endregion

  //      #region 短信、邮件模板

  //      /// <summary>
  //      /// 降价通知短信模板
  //      /// </summary>
  //      public string DownPriceMsgTemplate
  //      { get; set; }
  //      /// <summary>
  //      /// 降价通知邮件模板
  //      /// </summary>
  //      public string DownPriceEmailTemplate
  //      { get; set; }
  //      /// <summary>
  //      /// 求团购短信模板
  //      /// </summary>
  //      public string RequestGroupMsgTemplate
  //      { get; set; }
  //      /// <summary>
  //      /// 求团购邮件模板
  //      /// </summary>
  //      public string RequestGroupEmailTemplate
  //      { get; set; }

  //      #endregion 短信、邮件模板

  //      #endregion

    }
}