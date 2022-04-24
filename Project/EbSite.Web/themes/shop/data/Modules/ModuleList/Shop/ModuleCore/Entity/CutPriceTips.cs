using System;
namespace EbSite.Modules.Shop.ModuleCore.Entity
{
	/// <summary>
	/// 实体类CutPriceTips 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class CutPriceTips: Base.Entity.EntityBase<CutPriceTips,int>
	{
		public CutPriceTips()
		{
			base.CurrentModel = this;
		}
		public CutPriceTips(int ID)
		{
			base.id = ID;
			base.InitData(this);
			base.CurrentModel = this;
		}
        protected override EbSite.Base.BLL.BllBase<CutPriceTips, int> Bll()
		{
			 
				return BLL.CutPriceTips.Instance;
			 
		}
		#region Model
		private int? _productid;
		private string _email;
		private string _mobile;
		private int? _userid;
		private DateTime? _adddatetime;
	    private bool _isnotice ;
		/// <summary>
		/// 产品 id
		/// </summary>
		public int? ProductID
		{
			set{ _productid=value;}
			get{return _productid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Email
		{
			set{ _email=value;}
			get{return _email;}
		}
		/// <summary>
		/// 手机号
		/// </summary>
		public string Mobile
		{
			set{ _mobile=value;}
			get{return _mobile;}
		}
		/// <summary>
		/// 用户id 
		/// </summary>
		public int? UserID
		{
			set{ _userid=value;}
			get{return _userid;}
		}
		/// <summary>
		/// 添加时间
		/// </summary>
		public DateTime? AddDateTime
		{
			set{ _adddatetime=value;}
			get{return _adddatetime;}
		}
        /// <summary>
        /// 是否已通知 true：通知 false:没有通知
        /// </summary>
	    public  bool IsNotice
	    {
            set { _isnotice = value; }
            get { return _isnotice; }
	    }
		#endregion Model


        //扩展

        private string _title;
        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        private string _num;
        public string Num
        {
            get { return _num; }
            set { _num = value; }
        }

	}
}

