using System;
namespace EbSite.Modules.Shop.ModuleCore.Entity
{
	/// <summary>
	/// 实体类Promotions 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class Promotions: Base.Entity.EntityBase<Promotions,int>
	{
		public Promotions()
		{
			base.CurrentModel = this;
		}
		public Promotions(int ID)
		{
			base.id = ID;
			base.InitData(this);
			base.CurrentModel = this;
		}
		protected override EbSite.Base.BLL.BllBase<Promotions, int> Bll()
		{
			 
				return BLL.Promotions.Instance;
			 
		}
		#region Model
		private string _titlename;
		private int? _promotetype;
		private string _description;
		/// <summary>
		/// 促销活动的名称
		/// </summary>
		public string TitleName
		{
			set{ _titlename=value;}
			get{return _titlename;}
		}
		/// <summary>
		/// 促销活动类型 1.满额打折 2.买几送几 3.满额免费用 4.批发打折
		/// </summary>
		public int? PromoteType
		{
			set{ _promotetype=value;}
			get{return _promotetype;}
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

