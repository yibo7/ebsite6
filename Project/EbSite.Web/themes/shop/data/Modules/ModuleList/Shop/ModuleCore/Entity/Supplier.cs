using System;
namespace EbSite.Modules.Shop.ModuleCore.Entity
{
	/// <summary>
	/// 实体类Supplier 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class Supplier: Base.Entity.EntityBase<Supplier,int>
	{
		public Supplier()
		{
			base.CurrentModel = this;
		}
		public Supplier(int ID)
		{
			base.id = ID;
			base.InitData(this);
			base.CurrentModel = this;
		}
		protected override EbSite.Base.BLL.BllBase<Supplier, int> Bll()
		{ 
				return BLL.Supplier.Instance;
			 
		}
		#region Model
		private string _suppliername;
		private string _contactuser;
		private string _phone;
		private string _tel;
		private string _adres;
		/// <summary>
		/// 
		/// </summary>
		public string SupplierName
		{
			set{ _suppliername=value;}
			get{return _suppliername;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ContactUser
		{
			set{ _contactuser=value;}
			get{return _contactuser;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Phone
		{
			set{ _phone=value;}
			get{return _phone;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Tel
		{
			set{ _tel=value;}
			get{return _tel;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Adres
		{
			set{ _adres=value;}
			get{return _adres;}
		}
		#endregion Model

	}
}

