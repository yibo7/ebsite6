using System;
namespace EbSite.Entity
{
	/// <summary>
	/// 实体类OrderOptionValue 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class OrderOptionValue: Base.Entity.EntityBase<OrderOptionValue,int>
	{
		public OrderOptionValue()
		{
			base.CurrentModel = this;
		}
		public OrderOptionValue(int ID)
		{
			base.id = ID;
			base.InitData(this);
			base.CurrentModel = this;
		}
        //protected override EbSite.Base.BLL.BllBase<OrderOptionValue, int> Bll
        //{
        //    get
        //    {
        //        return BLL.OrderOptionValue.Instance;
        //    }
        //}
		#region Model
		private string _orderid;
		private int? _lookuplistid;
		private int? _lookupitemid;
		private string _listdescription;
		private string _itemdescription;
		private decimal _adjustedprice;
		private string _customertitle;
		private string _customerdescription;
		/// <summary>
		/// 定单编号
		/// </summary>
		public string OrderId
		{
			set{ _orderid=value;}
			get{return _orderid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? LookupListId
		{
			set{ _lookuplistid=value;}
			get{return _lookuplistid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? LookupItemId
		{
			set{ _lookupitemid=value;}
			get{return _lookupitemid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ListDescription
		{
			set{ _listdescription=value;}
			get{return _listdescription;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ItemDescription
		{
			set{ _itemdescription=value;}
			get{return _itemdescription;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal AdjustedPrice
		{
			set{ _adjustedprice=value;}
			get{return _adjustedprice;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string CustomerTitle
		{
			set{ _customertitle=value;}
			get{return _customertitle;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string CustomerDescription
		{
			set{ _customerdescription=value;}
			get{return _customerdescription;}
		}
		#endregion Model

	}
}

