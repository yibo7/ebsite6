using System;
namespace EbSite.Entity
{
	/// <summary>
	/// 提现申请表
	/// </summary>
	[Serializable]
	public class WithdrawList: Base.Entity.EntityBase<WithdrawList,int>
	{
		public WithdrawList()
		{
			base.CurrentModel = this;
		}
		public WithdrawList(int ID)
		{
			base.id = ID;
			base.InitData(this);
			base.CurrentModel = this;
		}
		protected override EbSite.Base.BLL.BllBase<WithdrawList, int> Bll()
		{
			 
				return BLL.WithdrawList.Instance;
			 
		}
		#region Model
		private int? _userid;
		private string _username;
		private DateTime? _requesttime;
		private decimal _amount;
		private string _accountname;
		private string _bankname;
		private string _cardnumber;
		private string _remark;
		/// <summary>
		/// 请求提现的用户ID
		/// </summary>
		public int? UserId
		{
			set{ _userid=value;}
			get{return _userid;}
		}
		/// <summary>
		/// 请求提现的用户名称
		/// </summary>
		public string UserName
		{
			set{ _username=value;}
			get{return _username;}
		}
		/// <summary>
		/// 请求日期时间
		/// </summary>
		public DateTime? RequestTime
		{
			set{ _requesttime=value;}
			get{return _requesttime;}
		}
		/// <summary>
		/// 提现金额
		/// </summary>
		public decimal Amount
		{
			set{ _amount=value;}
			get{return _amount;}
		}
		/// <summary>
		/// 银行开始人名称，个人为姓名，公司为公司名称
		/// </summary>
		public string AccountName
		{
			set{ _accountname=value;}
			get{return _accountname;}
		}
		/// <summary>
		/// 开户银行的名称
		/// </summary>
		public string BankName
		{
			set{ _bankname=value;}
			get{return _bankname;}
		}
		/// <summary>
		/// 开户银行账号
		/// </summary>
		public string CardNumber
		{
			set{ _cardnumber=value;}
			get{return _cardnumber;}
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

