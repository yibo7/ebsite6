using System;
using System.Collections.Generic;
using EbSite.Base.EntityAPI;
using EbSite.Base.Plugin.Base;

namespace EbSite.Base.Plugin
{
    public interface IPayment : IProvider
    {

        ///// <summary>
        ///// 显示在后台的说明  在帮助里写就行
        ///// </summary>
        //string DefaultDescription { get; }
        /// <summary>
        /// 显示在前台的说明
        /// </summary>
        string Description { get; }
      /// <summary>
        /// 生成一个连接，连接到支付平台
      /// </summary>
      /// <param name="OrderName">订单名称</param>
      /// <param name="TotalPrice">要支付的金额</param>
      /// <param name="OrderNumber">订单号</param>
      /// <returns></returns>
        string GetPayStr(string OrderName, string TotalPrice, string OrderNumber);
        

       
    }
}

