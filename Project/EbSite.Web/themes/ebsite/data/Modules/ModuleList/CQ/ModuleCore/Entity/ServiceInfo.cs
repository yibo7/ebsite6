using System;
using System.Collections.Generic;
using System.Web;
using EbSite.Base.Entity;

namespace EbSite.Modules.CQ.ModuleCore.Entity
{
    [Serializable]
    public class ServiceInfo : XmlEntityBase<int>
    {
        /// <summary>
        /// 客服名称
        /// </summary>
        public string ServiceName { get; set; }
        /// <summary>
        /// 职位
        /// </summary>
        public string PostName { get; set; }
        /// <summary>
        /// 联系电话
        /// </summary>
        public string Phone { get; set; }
        /// <summary>
        /// 手机
        /// </summary>
        public string Mobile { get; set; }
        /// <summary>
        /// 联系电话
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// 是否启用
        /// </summary>
        public bool IsEabled { get; set; }
        /// <summary>
        /// 排序ID
        /// </summary>
        public int OrderID { get; set; }

        /// <summary>
        /// 关联ebsite的userID 
        /// </summary>
        public int UserID { get; set; }
        /// <summary>
        /// 关联的用户帐号
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 关联的用户帐号
        /// </summary>
        public string UserNiName { get; set; }
        public string Info { get; set; }
        /// <summary>
        /// 是否在线
        /// </summary>
        public bool IsOnline { get; set; }

        public DateTime LastDateTime { get; set; }
        public int ClassID { get; set; }

        /// <summary>
        /// 非常满意
        /// </summary>
        public int StarFive { get; set; }
        /// <summary>
        /// 满意
        /// </summary>
        public int StarFour { get; set; }
        /// <summary>
        /// 一般
        /// </summary>
        public int StarThree { get; set; }
        /// <summary>
        /// 不满意
        /// </summary>
        public int StarTwo { get; set; }
        /// <summary>
        /// 差
        /// </summary>
        public int StarOne { get; set; }

        public string StarPercent
        {
            get
            {
                int icount = StarFive + StarFour + StarThree + StarTwo + StarOne;
                if(icount>0)
                    return string.Concat((((StarFive + StarFour + StarThree) * 100) / icount).ToString(),"%");
                return "没有评价";
            }
        }
    }
}