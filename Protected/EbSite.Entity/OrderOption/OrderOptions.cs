using System;
namespace EbSite.Entity
{
	/// <summary>
	/// 实体类OrderOptions 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class OrderOptions: Base.Entity.EntityBase<OrderOptions,int>
	{
		public OrderOptions()
		{
			base.CurrentModel = this;
		}
		public OrderOptions(int ID)
		{
			base.id = ID;
			base.InitData(this);
			base.CurrentModel = this;
		}
        //protected override EbSite.Base.BLL.BllBase<OrderOptions, int> Bll
        //{
        //    get
        //    {
        //        return BLL.OrderOptions.Instance;
        //    }
        //}
		#region Model
		private string _optionname;
		private int? _selectmode;
		private string _description;
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
}

