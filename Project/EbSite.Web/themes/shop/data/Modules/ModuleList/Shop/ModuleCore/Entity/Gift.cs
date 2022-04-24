using System;
namespace EbSite.Modules.Shop.ModuleCore.Entity
{
	/// <summary>
	/// 实体类Gift 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class Gift: Base.Entity.EntityBase<Gift,int>
	{
		public Gift()
		{
			base.CurrentModel = this;
		}
		public Gift(int ID)
		{
			base.id = ID;
			base.InitData(this);
			base.CurrentModel = this;
		}
		protected override EbSite.Base.BLL.BllBase<Gift, int> Bll()
		{
			 
				return BLL.Gift.Instance;
			 
		}
		#region Model
		private int? _buyproductid;
		private int _giftproductid;
		private int _quantity;
		private DateTime? _enddatetime;
		/// <summary>
		/// 关联购买产品ID
		/// </summary>
		public int? BuyProductId
		{
			set{ _buyproductid=value;}
			get{return _buyproductid;}
		}
		/// <summary>
		/// 关联赠品产品ID
		/// </summary>
		public int GiftProductId
		{
			set{ _giftproductid=value;}
			get{return _giftproductid;}
		}
		/// <summary>
		/// 赠送数量
		/// </summary>
		public int Quantity
		{
			set{ _quantity=value;}
			get{return _quantity;}
		}
		/// <summary>
		/// 结束日期  如果不选择，将永远不过期
		/// </summary>
		public DateTime? EndDateTime
		{
			set{ _enddatetime=value;}
			get{return _enddatetime;}
		}
		#endregion Model

        public string ProductName { get; set; }
        public string SmallImg { get; set; }


	}
}

