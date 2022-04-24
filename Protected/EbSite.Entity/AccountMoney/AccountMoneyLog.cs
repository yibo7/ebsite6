using System;
namespace EbSite.Entity
{
	/// <summary>
    /// 真实入帐的预付款
	/// </summary>
	[Serializable]
	public class AccountMoneyLog: Base.Entity.EntityBase<AccountMoneyLog,int>
	{
		public AccountMoneyLog()
		{
			base.CurrentModel = this;
		}
		public AccountMoneyLog(int ID)
		{
			base.id = ID;
			base.InitData(this);
			base.CurrentModel = this;
		}
		protected override EbSite.Base.BLL.BllBase<AccountMoneyLog, int> Bll()
		{
			 
				return BLL.AccountMoneyLog.Instance;
			 
		}
		#region Model
		private int _userid;
		private string _username;
		private DateTime _tradedate;
		private int _tradetype;
		private decimal _income;
		private decimal _expenses;
		private decimal _balance;
		private string _remark;
		/// <summary>
		/// 用户Id
		/// </summary>
		public int UserId
		{
			set{ _userid=value;}
			get{return _userid;}
		}
		/// <summary>
		/// 用户名称
		/// </summary>
		public string UserName
		{
			set{ _username=value;}
			get{return _username;}
		}
		/// <summary>
		/// 交易日期
		/// </summary>
		public DateTime TradeDate
		{
			set{ _tradedate=value;}
			get{return _tradedate;}
		}
		/// <summary>
		/// 交易类型 1.自助充值 2.后台加款 3.消费 4.提现 5.订单退款 6.推荐人提成7.提现完成
		/// </summary>
		public int TradeType
		{
			set{ _tradetype=value;}
			get{return _tradetype;}
		}
		/// <summary>
		/// 转入金额
		/// </summary>
		public decimal Income
		{
			set{ _income=value;}
			get{return _income;}
		}
		/// <summary>
		/// 转出金额
		/// </summary>
		public decimal Expenses
		{
			set{ _expenses=value;}
			get{return _expenses;}
		}
		/// <summary>
		/// 帐户余额
		/// </summary>
		public decimal Balance
		{
			set{ _balance=value;}
			get{return _balance;}
		}
		/// <summary>
		/// 备注
		/// </summary>
		public string Remark
		{
			set{ _remark=value;}
			get{return _remark;}
		}
		#endregion Model

	}
}

