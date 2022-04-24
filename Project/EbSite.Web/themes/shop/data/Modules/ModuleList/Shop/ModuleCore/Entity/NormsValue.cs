using System;
namespace EbSite.Modules.Shop.ModuleCore.Entity
{
	/// <summary>
	/// 实体类NormsValue 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class NormsValue: Base.Entity.EntityBase<NormsValue,int>
	{
		public NormsValue()
		{
			base.CurrentModel = this;
		}
		public NormsValue(int ID)
		{
			base.id = ID;
			base.InitData(this);
			base.CurrentModel = this;
		}
		protected override EbSite.Base.BLL.BllBase<NormsValue, int> Bll()
		{
			 
				return BLL.NormsValue.Instance;
			 
		}
		#region Model
		private string _normsvaluename;
		private string _normsico;
		private int? _orderid;
		private int? _normid;
		/// <summary>
		/// 
		/// </summary>
		public string NormsValueName
		{
			set{ _normsvaluename=value;}
			get{return _normsvaluename;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string NormsIco
		{
			set{ _normsico=value;}
			get{return _normsico;}
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
		/// 
		/// </summary>
		public int? NormID
		{
			set{ _normid=value;}
			get{return _normid;}
		}
		#endregion Model

	}
}

