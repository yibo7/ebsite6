using System;
using EbSite.Base.Entity;

namespace EbSite.Modules.Shop.ModuleCore.Entity
{
	/// <summary>
	/// 商品品牌
	/// </summary>
	[Serializable]
    public class GoodsBrand : Base.Entity.EntityBase<GoodsBrand, int>
	{
		
		#region Model
		private string _brandname;
		private string _logo;
		private string _description;
		private int _orderid;
	    private int _groupid;
	
		/// <summary>
		/// 品牌 名称
		/// </summary>
		public string BrandName
		{
            set { _brandname = value; }
            get { return _brandname; }
		}
		/// <summary>
		/// 图标
		/// </summary>
		public string Logo
		{
			set{ _logo=value;}
			get{return _logo;}
		}
		/// <summary>
		/// 描述
		/// </summary>
		public string Description
		{
            set { _description = value; }
            get { return _description; }
		}
		/// <summary>
		/// 排序
		/// </summary>
		public int OrderID
		{
			set{ _orderid=value;}
			get{return _orderid;}
		}
	    public int GroupID
	    {
	        get
	        {
	            return _groupid;
	        }
            set
            {
                _groupid = value;
            }
	    }
		
		#endregion Model

	}
}

