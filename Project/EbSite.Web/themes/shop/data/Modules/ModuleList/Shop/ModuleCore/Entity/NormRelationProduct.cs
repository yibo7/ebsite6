using System;
namespace EbSite.Modules.Shop.ModuleCore.Entity
{
	/// <summary>
	/// 实体类NormRelationProduct 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class NormRelationProduct: Base.Entity.EntityBase<NormRelationProduct,int>
	{
		public NormRelationProduct()
		{
			base.CurrentModel = this;
		}
		public NormRelationProduct(int ID)
		{
			base.id = ID;
			base.InitData(this);
			base.CurrentModel = this;
		}
		protected override EbSite.Base.BLL.BllBase<NormRelationProduct, int> Bll()
		{
			 
				return BLL.NormRelationProduct.Instance;
			 
		}
		#region Model
		private string _pnumber;
		private int _stocks;
		private decimal _saleprice;
		private decimal _costprice;
		private decimal _marketprice;
		private decimal _weight;
		private long _productid;
		private string _normsvalues;
		/// <summary>
		/// 
		/// </summary>
		public string PNumber
		{
			set{ _pnumber=value;}
			get{return _pnumber;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int Stocks
		{
			set{ _stocks=value;}
			get{return _stocks;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal SalePrice
		{
			set{ _saleprice=value;}
			get{return _saleprice;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal CostPrice
		{
			set{ _costprice=value;}
			get{return _costprice;}
		}
		/// <summary>
		/// 已经不使用，市场价格直接使用实体里的
		/// </summary>
		public decimal MarketPrice
		{
			set{ _marketprice=value;}
			get{return _marketprice;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal Weight
		{
			set{ _weight=value;}
			get{return _weight;}
		}
		/// <summary>
		/// 
		/// </summary>
		public long ProductID
		{
			set{ _productid=value;}
			get{return _productid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string NormsValues
		{
			set{ _normsvalues=value;}
			get{return _normsvalues;}
		}
		#endregion Model

        //扩展
	    public  string Annex13 { get; set; }
        public  string NewsTitle { get; set; }
        public  string ClassName { get; set; }

	}
}

