using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EbSite.Modules.CQ.ModuleCore.BLL
{
    public class Customer : IComparable<Customer>
    {
        /// <summary>
        /// 客户对应的客服ID
        /// </summary>
        public int ServiceID { get; set; }
        /// <summary>
        /// 客户的用户ID ，如果已经登录为对应的ebsite userid,如果没有登录，为游客,ID统一是0,所以id为有重复的情况，平时以CustomerUserName为主键
        /// </summary>
        public int CustomerUserID { get; set; }
        /// <summary>
        /// 客户的帐号，如果没有登录，为游客-2365这样的形式
        /// </summary>
        public string CustomerUserName { get; set; }
        /// <summary>
        /// 对应ebsite的niname,如果没有登录为为游客-2365这样的形式
        /// </summary>
        public string CustomerNiName { get; set; }
        /// <summary>
        /// 客户Ip
        /// </summary>
        public string CustomerIp { get; set; }
        //public string CustomerTarget { get; set; }
        /// <summary>
        /// 是否在线
        /// </summary>
        public bool IsOnline { get; set; }
        public DateTime LastDateTime { get; set; }

        #region 实现IComparable接口,以便在List里可以使用Sort对orderid 进行排序
        /// <summary>
        /// 按orderid的降序来排序,实现这个方法，可以让List.Sort(),按这个比较大小来排序
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public int CompareTo(Customer other)
        {

            return this.CustomerUserName.CompareTo(other.CustomerUserName);
        }

        #endregion

    }
}