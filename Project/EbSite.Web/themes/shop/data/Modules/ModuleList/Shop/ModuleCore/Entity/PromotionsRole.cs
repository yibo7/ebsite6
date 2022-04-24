using System;
namespace EbSite.Modules.Shop.ModuleCore.Entity
{
	/// <summary>
	/// 实体类PromotionsRole 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class PromotionsRole: Base.Entity.EntityBase<PromotionsRole,int>
	{
		public PromotionsRole()
		{
			base.CurrentModel = this;
		}
		public PromotionsRole(int ID)
		{
			base.id = ID;
			base.InitData(this);
			base.CurrentModel = this;
		}
		protected override EbSite.Base.BLL.BllBase<PromotionsRole, int> Bll()
		{
			 
				return BLL.PromotionsRole.Instance;
			 
		}
		#region Model
		private int _promotionsid;
		private int? _userroleid;
		/// <summary>
		/// 关联表Promotions的ID
		/// </summary>
		public int PromotionsID
		{
			set{ _promotionsid=value;}
			get{return _promotionsid;}
		}
		/// <summary>
		/// 关联用户角色ID
		/// </summary>
		public int? UserRoleID
		{
			set{ _userroleid=value;}
			get{return _userroleid;}
		}
		#endregion Model

	}
}

