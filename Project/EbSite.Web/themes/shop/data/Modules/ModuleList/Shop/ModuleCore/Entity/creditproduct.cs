using System;
namespace EbSite.Modules.Shop.ModuleCore.Entity
{
	/// <summary>
	/// 实体类creditproduct 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class creditproduct: Base.Entity.EntityBase<creditproduct,int>
	{
		public creditproduct()
		{
			base.CurrentModel = this;
		}
		public creditproduct(int ID)
		{
			base.id = ID;
			base.InitData(this);
			base.CurrentModel = this;
		}
		protected override EbSite.Base.BLL.BllBase<creditproduct, int> Bll()
		{
			 
				return BLL.creditproduct.Instance;
			 
		}
		#region Model
		private string _productname;
		private string _smallimg;
		private string _bigimg;
		private string _unit;
		private decimal? _costprice;
		private decimal? _marketprice;
		private int _credit;
		private string _outline;
		private string _seodes;
		private string _seokeyword;
		private string _seotitle;
		private string _info;
		private int? _addtime;
		private int? _adduserid;
		private int? _issaling;
		private int _stock;
		private int? _classid;

        private int? _exchangenum;
		/// <summary>
        /// 商品名称
		/// </summary>
		public string ProductName
		{
			set{ _productname=value;}
			get{return _productname;}
		}
		/// <summary>
        /// 商品小图
		/// </summary>
		public string SmallImg
		{
			set{ _smallimg=value;}
			get{return EbSite.Core.Strings.GetString.GetSmallImgUrl(BigImg);}
		}
		/// <summary>
        /// 商品大图
		/// </summary>
		public string BigImg
		{
			set{ _bigimg=value;}
			get{return _bigimg;}
		}
		/// <summary>
        /// 计量单位
		/// </summary>
		public string Unit
		{
			set{ _unit=value;}
			get{return _unit;}
		}
		/// <summary>
        /// 成本价格
		/// </summary>
		public decimal? CostPrice
		{
			set{ _costprice=value;}
			get{return _costprice;}
		}
		/// <summary>
        /// 市参考价格
		/// </summary>
		public decimal? MarketPrice
		{
			set{ _marketprice=value;}
			get{return _marketprice;}
		}
		/// <summary>
        /// 需要积分
		/// </summary>
		public int Credit
		{
			set{ _credit=value;}
			get{return _credit;}
		}
		/// <summary>
        /// 简单介绍
		/// </summary>
		public string Outline
		{
			set{ _outline=value;}
			get{return _outline;}
		}
		/// <summary>
        /// 页面描述
		/// </summary>
		public string SeoDes
		{
			set{ _seodes=value;}
			get{return _seodes;}
		}
		/// <summary>
        /// 页面关键词
		/// </summary>
		public string SeoKeyWord
		{
			set{ _seokeyword=value;}
			get{return _seokeyword;}
		}
		/// <summary>
        /// 页面标题
		/// </summary>
		public string SeoTitle
		{
			set{ _seotitle=value;}
			get{return _seotitle;}
		}
		/// <summary>
        /// 商品详细介绍
		/// </summary>
		public string Info
		{
			set{ _info=value;}
			get{return _info;}
		}
		/// <summary>
        /// 添加日期时间
		/// </summary>
		public int? AddTime
		{
			set{ _addtime=value;}
			get{return _addtime;}
		}
		/// <summary>
        /// 添加用户ID
		/// </summary>
		public int? AddUserID
		{
			set{ _adduserid=value;}
			get{return _adduserid;}
		}
		/// <summary>
        /// (int 1上架,0不上架)是否上架
		/// </summary>
		public int? IsSaling
		{
			set{ _issaling=value;}
			get{return _issaling;}
		}
		/// <summary>
        /// 商品数量 数量为0 自动下架 
		/// </summary>
		public int Stock
		{
			set{ _stock=value;}
			get{return _stock;}
		}
		/// <summary>
        /// 积分分类ID 对应ebshop_creditproductClass
		/// </summary>
		public int? ClassID
		{
			set{ _classid=value;}
			get{return _classid;}
		}
        /// <summary>
        /// 兑换次数
        /// </summary>
        public int? ExchangeNum
        {
            set { _exchangenum = value; }
            get { return _exchangenum; }
        }
		#endregion Model

	}
}

