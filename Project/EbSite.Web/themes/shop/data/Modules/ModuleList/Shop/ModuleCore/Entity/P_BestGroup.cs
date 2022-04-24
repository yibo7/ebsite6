using System;
namespace EbSite.Modules.Shop.ModuleCore.Entity
{
	/// <summary>
	/// 实体类P_BestGroup 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class P_BestGroup: Base.Entity.EntityBase<P_BestGroup,int>
	{
		public P_BestGroup()
		{
			base.CurrentModel = this;
		}
		public P_BestGroup(int ID)
		{
			base.id = ID;
			base.InitData(this);
			base.CurrentModel = this;
		}
		protected override EbSite.Base.BLL.BllBase<P_BestGroup, int> Bll()
		{
			 
				return BLL.P_BestGroup.Instance;
			 
		}
		#region Model
		private int? _productid;
		private int? _goodsid;
		private int? _orderid;
		private string _goodsname;
		private string _goodsavatarsmall;
	    private int _typeid;
		/// <summary>
        /// 产品ID（父类）
		/// </summary>
		public int? ProductID
		{
			set{ _productid=value;}
			get{return _productid;}
		}
		/// <summary>
        ///  推荐配件或最佳组合 的对应产品ID
		/// </summary>
		public int? GoodsID
		{
			set{ _goodsid=value;}
			get{return _goodsid;}
		}
		/// <summary>
        ///  排序
		/// </summary>
		public int? OrderiD
		{
			set{ _orderid=value;}
			get{return _orderid;}
		}
		/// <summary>
        ///  GoodsID对应的 商品名称
		/// </summary>
		public string GoodsName
		{
			set{ _goodsname=value;}
			get{return _goodsname;}
		}
		/// <summary>
        /// 小图路径
		/// </summary>
		public string GoodsAvatarSmall
		{
			set{ _goodsavatarsmall=value;}
			get{return _goodsavatarsmall;}
		}
        /// <summary>
        /// 1 ：最佳组合 2.推荐配件
        /// </summary>
	    public int TypeID
	    {
            get { return _typeid; }
            set { _typeid = value; }
	    }

	    private string _title;
	    public  string Title
	    {
            get { return _title; }
            set { _title = value; }
	    }
        /// <summary>
        /// 商品的价格 Annex16 销售价
        /// </summary>
	    public decimal Price
	    {
	        get
	        {
	            decimal s = 0;
                EbSite.Entity.NewsContent md = Base.AppStartInit.NewsContentInstDefault.GetModelByFiledOfDefault("annex16", " id=" + Convert.ToInt32(GoodsID));
                if (!Equals(md, null))
                {
                    s = md.Annex16;
                }
	            return s;
	        }
	    }
        /// <summary>
        /// 市场价 可以推荐配件，最佳组合时 得出获得优惠的总值
        /// </summary>
	    public string ShiChangJia
	    {
            get
            {
                string s = "0";
                EbSite.Entity.NewsContent md = Base.AppStartInit.NewsContentInstDefault.GetModelByFiledOfDefault("annex2", " id=" + Convert.ToInt32(GoodsID));
                if (!Equals(md, null))
                {
                    s = md.Annex2;
                }
                return s;
            }
	    }
		#endregion Model

	}
}

