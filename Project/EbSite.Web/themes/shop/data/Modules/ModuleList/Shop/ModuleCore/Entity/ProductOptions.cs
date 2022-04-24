using System;
using System.Collections.Generic;

namespace EbSite.Modules.Shop.ModuleCore.Entity
{
	/// <summary>
	/// 实体类ProductOptions 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class ProductOptions: Base.Entity.EntityBase<ProductOptions,int>
	{
		public ProductOptions()
		{
			base.CurrentModel = this;
		}
		public ProductOptions(int ID)
		{
			base.id = ID;
			base.InitData(this);
			base.CurrentModel = this;
		}
		protected override EbSite.Base.BLL.BllBase<ProductOptions, int> Bll()
		{
			 
				return BLL.ProductOptions.Instance;
			 
		}
		#region Model
		private int? _productid;
		private string _optionname;
		private int? _selectmode;
		private string _description;
		/// <summary>
		/// 
		/// </summary>
		public int? ProductID
		{
			set{ _productid=value;}
			get{return _productid;}
		}
		/// <summary>
		/// 订单选项名称 
		/// </summary>
		public string OptionName
		{
			set{ _optionname=value;}
			get{return _optionname;}
		}
		/// <summary>
		/// 选择模式 0为列表模式 1为下拉模块
		/// </summary>
		public int? SelectMode
		{
			set{ _selectmode=value;}
			get{return _selectmode;}
		}
		/// <summary>
		/// 描述
		/// </summary>
		public string Description
		{
			set{ _description=value;}
			get{return _description;}
		}
		#endregion Model

	}

    #region 协调web服务使用


    public class ProductOption
    {
        public int id { get; set; }
        public string OptionName { get; set; }
        public List<ProductItem> ProductItems;
    }

    /// <summary>
    /// 商品费用 子项
    /// </summary>
    public class ProductItem
    {
        public int id { get; set; }
        public int ProductOptionID { get; set; }
        public string OptionName { get; set; }
        /// <summary>
        /// 选项名称
        /// </summary>
        public string ItemName { get; set; }
        /// <summary>
        /// 赠送
        /// </summary>
        public string IsGive { get; set; }
        /// <summary>
        ///  当CalculateMode为0时:固定金额,为1时:购物车金额百分比
        /// </summary>
        public decimal? AppendMoney { get; set; }
        /// <summary>
        /// 费用计算模式 0.固定金额 1.购物车金额百分比 
        /// </summary>
        public string CalculateMode { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }

    }
    
    #endregion

}

