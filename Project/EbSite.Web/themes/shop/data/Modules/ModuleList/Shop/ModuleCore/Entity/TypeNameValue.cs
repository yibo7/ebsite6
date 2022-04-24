using System;
namespace EbSite.Modules.Shop.ModuleCore.Entity
{
	/// <summary>
	/// 实体类TypeNameValue 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class TypeNameValue: Base.Entity.EntityBase<TypeNameValue,int>
	{
		public TypeNameValue()
		{
			base.CurrentModel = this;
		}
		public TypeNameValue(int ID)
		{
			base.id = ID;
			base.InitData(this);
			base.CurrentModel = this;
		}
		protected override EbSite.Base.BLL.BllBase<TypeNameValue, int> Bll()
		{
			 
				return BLL.TypeNameValue.Instance;
			 
		}
		#region Model
		private string _valuename;
		private int? _orderid;
		private int? _ismoresel;
		private int? _issele;
		private string _defaultvalues;
		private int? _typenameid;
		/// <summary>
		/// 
		/// </summary>
		public string ValueName
		{
			set{ _valuename=value;}
			get{return _valuename;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? OrderID
		{
			set{ _orderid=value;}
			get{return _orderid;}
		}
		/// <summary>
        ///  1: 支持多选
		/// </summary>
		public int? IsMoreSel
		{
			set{ _ismoresel=value;}
			get{return _ismoresel;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? IsSele
		{
			set{ _issele=value;}
			get{return _issele;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string DefaultValues
		{
			set{ _defaultvalues=value;}
			get{return _defaultvalues;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? TypeNameID
		{
			set{ _typenameid=value;}
			get{return _typenameid;}
		}
		#endregion Model

	}
}

