using System;
using EbSite.Base.Plugin;

namespace EbSite.Entity
{
	/// <summary>
	/// 实体类Payment 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class Payment: Base.Entity.EntityBase<Payment,int>
	{
		public Payment()
		{
			base.CurrentModel = this;
		}
		public Payment(int ID)
		{
			base.id = ID;
			base.InitData(this);
			base.CurrentModel = this;
		}
		protected override EbSite.Base.BLL.BllBase<Payment, int> Bll()
		{
			 
				return BLL.Payment.Instance;
			 
		}
		
        #region Model
		private string _paymentapi;
		private string _paymentname;
		private decimal _usemoney;
		private bool _ispercent;
		private bool _isuseinpour;
		private bool _isopend;
		private int? _ordernumber;
		private string _demo;
		private string _showimg;
	    private int _classid;
	    private string _shortname;
		/// <summary>
        /// 支付插件类型 如 EbSite.Plugin.Payment.Alipay_Standard_Year.Payment
		/// </summary>
		public string PaymentApi
		{
			set{ _paymentapi=value;}
			get{return _paymentapi;}
		}
		/// <summary>
		/// 支付方式名称
		/// </summary>
		public string PaymentName
		{
			set{ _paymentname=value;}
			get{return _paymentname;}
		}
		/// <summary>
		/// 支付手续费(正数)，或免除费用（负数）
		/// </summary>
		public decimal UseMoney
		{
			set{ _usemoney=value;}
			get{return _usemoney;}
		}
		/// <summary>
		/// 是否百分比
		/// </summary>
		public bool IsPercent
		{
			set{ _ispercent=value;}
			get{return _ispercent;}
		}
		/// <summary>
		/// 是否用于预付款
		/// </summary>
		public bool IsUseInpour
		{
			set{ _isuseinpour=value;}
			get{return _isuseinpour;}
		}
		/// <summary>
		/// 是否关闭
		/// </summary>
		public bool IsOpend
		{
			set{ _isopend=value;}
			get{return _isopend;}
		}
		/// <summary>
		/// 显示顺序
		/// </summary>
		public int? OrderNumber
		{
			set{ _ordernumber=value;}
			get{return _ordernumber;}
		}
		/// <summary>
		/// 备注
		/// </summary>
		public string Demo
		{
			set{ _demo=value;}
			get{return _demo;}
		}
		/// <summary>
		/// 展示图片
		/// </summary>
		public string ShowImg
		{
			set{ _showimg=value;}
			get{return _showimg;}
		}
        /// <summary>
        /// 分类ID
        /// </summary>
	    public int ClassID
	    {
            get { return _classid; }
            set { _classid = value; }
	    }
        /// <summary>
        /// 简称
        /// </summary>
	    public string ShortName
	    {
            get { return _shortname; }
            set { _shortname = value; }
	    }
		#endregion Model

        /// <summary>
        /// 获取手续费
        /// </summary>
        /// <param name="OrderMoney">订单金额</param>
        /// <returns></returns>
        public decimal GetFree(decimal OrderMoney)
        {
            if(!IsPercent)
            {
                return UseMoney;
            }
            else
            {
                return OrderMoney*OrderMoney;
            }
        }

        public string GetPayLink(decimal OrderMoney, string sOrderNumber, string OrderName)
        {
            IPayment pApi = PluginManager.Instance.GetPayment(this.PaymentApi);
            decimal PayMoney = 0;
            decimal dFree = GetFree(OrderMoney);
            PayMoney = OrderMoney + dFree;
            if(pApi!=null)
            {
               return pApi.GetPayStr(OrderName, PayMoney.ToString(), sOrderNumber);
            }
            return "";
        }
	}
}

