using System;
namespace EbSite.Modules.Shop.ModuleCore.Entity
{
	/// <summary>
	/// 实体类ProductsImg 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class ProductsImg: Base.Entity.EntityBase<ProductsImg,int>
	{
		public ProductsImg()
		{
			base.CurrentModel = this;
		}
		public ProductsImg(int ID)
		{
			base.id = ID;
			base.InitData(this);
			base.CurrentModel = this;
		}
		protected override EbSite.Base.BLL.BllBase<ProductsImg, int> Bll()
		{
			 
				return BLL.ProductsImg.Instance;
			 
		}
		#region Model
		private string _productname;
		private long _productid;
		private string _bigimg;
		private string _smallimg;
	    protected string _title;
		/// <summary>
		/// 
		/// </summary>
		public string ProductName
		{
			set{ _productname=value;}
			get{return _productname;}
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
		public string BigImg
		{
			set{ _bigimg=value;}
			get{return _bigimg;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string SmallImg
		{
			set{ _smallimg=value;}
			get{
			    return EbSite.Core.Strings.GetString.GetSmallImgUrl(BigImg);
            }
		}
        public string Title
        {
            set { _title = value; }
            get { return _title; }
        }
		#endregion Model

	}
}

