using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Profile;
using System.Web.Security;
using EbSite.Base;
using EbSite.Base.EBSiteEventArgs;
using EbSite.Base.Modules;
using EbSite.Entity;

namespace EbSite.Modules.UserBaseInfo
{
    public class AppStart : ModuleStartInit
    {
        private static string StartupOK = null;
        private static object _SyncRoot = new object();
        private static bool _startWasCalled;

        public void Start()
        {
            if (_startWasCalled) return;
            _startWasCalled = true;

            EBSiteEvents.ApplicationBeginRequest += new EventHandler<EventArgs>(Application_BeginRequest);
        }

         public void Application_BeginRequest(object sender, EventArgs e)
        {
            if (StartupOK == null)
            {
                lock (_SyncRoot)
                {
                    if (StartupOK == null)
                    {
                        EbSite.Base.EBSiteEvents.Payed += new EventHandler<PayedEventArgs>(OnPayed);
                       // EbSite.Base.EBSiteEvents.HttpModuleRuning += new EventHandler<HttpModuleRuningEventArgs>(On_HttpModuleRuning);
                        StartupOK = "OK";
                    }
                }
            }

        }
        /// <summary>
        /// 对预付款的操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnPayed(object sender, PayedEventArgs e)
        {
            string trade_status = e.TradeStatus;

            if (e.OrderNo.IndexOf("yfko_") == 0)  //带有yfko_标记表示为预付款
            {
                //Guid gid = new Guid(e.OrderNo.Replace("yfko_", ""));
                long lid = 0;
                long.TryParse(e.OrderNo.Replace("yfko_", ""), out lid);

                Entity.PayLog pl = EbSite.BLL.PayLog.Instance.GetEntity(lid);
                if(pl!=null)
                {
                    if (trade_status == "TRADE_FINISHED" || trade_status == "TRADE_SUCCESS")
                        {
                            // TRADE_FINISHED(表示交易已经成功结束，通用即时到帐反馈的交易状态成功标志);
                            //TRADE_SUCCESS(表示交易已经成功结束，高级即时到帐反馈的交易状态成功标志);
                            
                            //判断该笔订单是否在商户网站中已经做过处理（可参考“集成教程”中“3.4返回数据处理”）
                            //如果没有做过处理，根据订单号（out_trade_no）在商户网站的订单系统中查到该笔订单的详细，并执行商户的业务程序
                            //如果有做过处理，不执行商户的业务程序

                            EbSite.Entity.PayPass pp = EbSite.BLL.PayPass.Instance.GetEntityByUserID(pl.UserID);

                            //EbSite.Entity.AccountMoneyLog am = new AccountMoneyLog();
                            //am.Income = pl.Income;
                            //am.Balance = pp.Balance;
                            
                            //am.UserName = pl.UserName;
                            //am.TradeDate = DateTime.Now;
                            //am.TradeType = 1; //自助充值
                            //am.Remark = string.Format("{0}用户后台自助充值{1}元,其中可用余额{2}元,支付手续费{3}元", DateTime.Now, pl.Income, (pl.Income - pl.Free), pl.Free);


                            EbSite.Entity.AccountMoneyLog dd = new Entity.AccountMoneyLog();
                            dd.UserId = pl.UserID;
                            dd.Income = pl.Income;
                            dd.Balance = pp.Balance + pl.Income;
                            dd.UserName = pl.UserName;
                            dd.TradeDate = DateTime.Now;
                            dd.TradeType = Convert.ToInt32(BLL.EAccountMoneyType.ZDCZ); //自助充值
                            dd.Remark = string.Format("{0}用户后台自助充值{1}元,其中可用余额{2}元,支付手续费{3}元", DateTime.Now, pl.Income, (pl.Income - pl.Free), pl.Free);
                            dd.Add();

                            //更新 总资产
                            List<Entity.PayPass> ls = EbSite.BLL.PayPass.Instance.GetListArray(1, "UserId=" + pl.UserID, "");
                            if (ls.Count == 0)
                            {
                                Entity.PayPass model = new Entity.PayPass();
                                model.Balance = dd.Balance;
                                model.UserID = pl.UserID;
                                model.Add();
                            }
                            else
                            {
                                Entity.PayPass model = ls[0];
                                model.Balance = dd.Balance;
                                model.Update();
                            }

                            //该判断表示买家已经确认收货，这笔交易完成
                            EbSite.Base.Host.Instance.InsertLog("用户后台自助充值", dd.Remark);

                        }
                }
                
            }
            else
            {
                EbSite.Base.Host.Instance.InsertLog("交易成功，获取订单编号失败", "取不到当前订单数据,返回状态为:" + trade_status);
            }

        }

        
    }
}