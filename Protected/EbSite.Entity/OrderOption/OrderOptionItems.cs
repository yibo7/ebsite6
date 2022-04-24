using System;
namespace EbSite.Entity
{
	/// <summary>
	/// 实体类OrderOptionItems 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class OrderOptionItems: Base.Entity.EntityBase<OrderOptionItems,int>
	{
		public OrderOptionItems()
		{
			base.CurrentModel = this;
		}
		public OrderOptionItems(int ID)
		{
			base.id = ID;
			base.InitData(this);
			base.CurrentModel = this;
		}
        //protected override EbSite.Base.BLL.BllBase<OrderOptionItems, int> Bll
        //{
        //    get
        //    {
        //        return BLL.OrderOptionItems.Instance;
        //    }
        //}
		#region Model
		private int? _orderoptionid;
		private string _itemname;
		private bool _isuserinputrequired;
		private string _userinputtitle;
		private decimal _appendmoney;
		private int? _calculatemode;
		private string _remark;
		/// <summary>
		/// 关联OrderOptions中的ID
		/// </summary>
		public int? OrderOptionID
		{
			set{ _orderoptionid=value;}
			get{return _orderoptionid;}
		}
		/// <summary>
		/// 选项名称
		/// </summary>
		public string ItemName
		{
			set{ _itemname=value;}
			get{return _itemname;}
		}
		/// <summary>
		/// 是否允许用户输入
		/// </summary>
		public bool IsUserInputRequired
		{
			set{ _isuserinputrequired=value;}
			get{return _isuserinputrequired;}
		}
		/// <summary>
		/// 提示用户输入的名称
		/// </summary>
		public string UserInputTitle
		{
			set{ _userinputtitle=value;}
			get{return _userinputtitle;}
		}
		/// <summary>
		/// 当CalculateMode为0时:固定金额,为1时:购物车金额百分比
		/// </summary>
		public decimal AppendMoney
		{
			set{ _appendmoney=value;}
			get{return _appendmoney;}
		}
		/// <summary>
		/// 费用计算模式 0.固定金额 1.购物车金额百分比
		/// </summary>
		public int? CalculateMode
		{
			set{ _calculatemode=value;}
			get{return _calculatemode;}
		}
		/// <summary>
		/// 备注
		/// </summary>
		public string Remark
		{
			set{ _remark=value;}
			get{return _remark;}
		}
		#endregion Model

	}
}

