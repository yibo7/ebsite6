using System;
namespace EbSite.Modules.Shop.ModuleCore.Entity
{
	/// <summary>
	/// 实体类P_UserBook 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class P_UserBook: Base.Entity.EntityBase<P_UserBook,int>
	{
		public P_UserBook()
		{
			base.CurrentModel = this;
		}
		public P_UserBook(int ID)
		{
			base.id = ID;
			base.InitData(this);
			base.CurrentModel = this;
		}
		protected override EbSite.Base.BLL.BllBase<P_UserBook, int> Bll()
		{
			 
				return BLL.P_UserBook.Instance;
			 
		}
		#region Model
		private string _title;
		private string _url;
		private int? _productid;
		private int? _orderid;
		/// <summary>
		/// 
		/// </summary>
		public string Title
		{
			set{ _title=value;}
			get{return _title;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Url
		{
			set{ _url=value;}
			get{return _url;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? ProductID
		{
			set{ _productid=value;}
			get{return _productid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? OrderID
		{
			set{ _orderid=value;}
			get{return _orderid;}
		}
		#endregion Model

	}
}

