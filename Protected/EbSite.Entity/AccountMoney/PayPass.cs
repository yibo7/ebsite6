using System;
namespace EbSite.Entity
{
	/// <summary>
	/// 实体类PayPass 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class PayPass: Base.Entity.EntityBase<PayPass,int>
	{
		public PayPass()
		{
			base.CurrentModel = this;
		}
		public PayPass(int ID)
		{
			base.id = ID;
			base.InitData(this);
			base.CurrentModel = this;
		}
        protected override EbSite.Base.BLL.BllBase<PayPass, int> Bll()
        {
            
                return BLL.PayPass.Instance;
             
        }
		#region Model
		private int? _userid;
		private string _pass;
		private int? _endtype;
        private decimal _balance;
        /// <summary>
        /// 帐户余额
        /// </summary>
        public decimal Balance
        {
            get { return _balance; }
            set { _balance = value; }
        }
        private decimal _requestbalance;
        /// <summary>
        /// 申请提现
        /// </summary>
        public decimal RequestBalance
        {
            get { return _requestbalance; }
            set { _requestbalance = value; }
        }
		/// <summary>
		/// 用户ID
		/// </summary>
		public int? UserID
		{
			set{ _userid=value;}
			get{return _userid;}
		}
		/// <summary>
		/// 交易密码
		/// </summary>
		public string Pass
		{
			set{ _pass=value;}
			get{return _pass;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? EndType
		{
			set{ _endtype=value;}
			get{return _endtype;}
		}
		#endregion Model

	}
}

