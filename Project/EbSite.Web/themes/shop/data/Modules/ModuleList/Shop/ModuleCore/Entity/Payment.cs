using System;
namespace EbSite.Modules.Shop.ModuleCore.Entity
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
		private decimal? _usemoney;
		private bool _ispercent;
		private bool _isuseinpour;
		private bool _isclose;
		private int? _ordernumber;
		private string _demo;
		/// <summary>
		/// 支付插件类型
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
		public decimal? UseMoney
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
		public bool IsClose
		{
			set{ _isclose=value;}
			get{return _isclose;}
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
		#endregion Model

	}
}

