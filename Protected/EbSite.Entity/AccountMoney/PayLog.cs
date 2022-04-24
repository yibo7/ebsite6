using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EbSite.Base.Entity;

namespace EbSite.Entity
{
    /// <summary>
    /// 在跳转到第三方支付前要记录本次支付数据，以便回调时调用
    /// </summary>
    [Serializable]
    public class PayLog : Base.Entity.EntityBase<PayLog, long>
    {
        public PayLog()
        {
            base.CurrentModel = this;
        }
        public PayLog(long ID)
        {
            base.id = ID;
            base.InitData(this);
            base.CurrentModel = this;
        }
        //protected override EbSite.Base.BLL.BllBase<paylog, long> Bll
        //{
        //    get
        //    {
        //        return BLL.paylog.Instance;
        //    }
        //}
        #region Model
        private int _userid;
        private string _username;
        private decimal _income;
        private decimal _free;
        private DateTime? _adddatetime;
        private int _timenumber=Core.SqlDateTimeInt.GetSecond(DateTime.Now);
        /// <summary>
        /// 
        /// </summary>
        public int UserID
        {
            set { _userid = value; }
            get { return _userid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string UserName
        {
            set { _username = value; }
            get { return _username; }
        }
        /// <summary>
        /// 转入金额
        /// </summary>
        public decimal Income
        {
            set { _income = value; }
            get { return _income; }
        }
        /// <summary>
        /// 手续费
        /// </summary>
        public decimal Free
        {
            set { _free = value; }
            get { return _free; }
        }
        /// <summary>
        /// 添加日期
        /// </summary>
        public DateTime? AddDateTime
        {
            set { _adddatetime = value; }
            get { return _adddatetime; }
        }
        /// <summary>
        ///  日期 整形格式
        /// </summary>
        public int TimeNumber
        {
            set { _timenumber = value; }
            get { return _timenumber; }
        }
        #endregion Model

    }

}
