using System;
namespace EbSite.Modules.Shop.ModuleCore.Entity
{
	/// <summary>
	/// 实体类P_RecommedParts 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class P_RecommedParts: Base.Entity.EntityBase<P_RecommedParts,int>
	{
		public P_RecommedParts()
		{
			base.CurrentModel = this;
		}
		public P_RecommedParts(int ID)
		{
			base.id = ID;
			base.InitData(this);
			base.CurrentModel = this;
		}
		protected override EbSite.Base.BLL.BllBase<P_RecommedParts, int> Bll()
		{
			 
				return BLL.P_RecommedParts.Instance;
			 
		}
		#region Model
		private int? _productid;
		private string _partsid;
		private string _orderid;
		private string _partsavatarsmall;
		private string _partsname;
		/// <summary>
		/// 推荐配件对应的主ID
		/// </summary>
		public int? ProductID
		{
			set{ _productid=value;}
			get{return _productid;}
		}
		/// <summary>
		/// 所选配件的ID
		/// </summary>
		public string PartsID
		{
			set{ _partsid=value;}
			get{return _partsid;}
		}
		/// <summary>
		/// 排序ID
		/// </summary>
		public string OrderiD
		{
			set{ _orderid=value;}
			get{return _orderid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PartsAvatarSmall
		{
			set{ _partsavatarsmall=value;}
			get{return _partsavatarsmall;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PartsName
		{
			set{ _partsname=value;}
			get{return _partsname;}
		}
		#endregion Model

	}
}

