using System;
namespace EbSite.Modules.Shop.ModuleCore.Entity
{
	/// <summary>
	/// 实体类Norms 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class Norms: Base.Entity.EntityBase<Norms,int>
	{
		public Norms()
		{
			base.CurrentModel = this;
		}
		public Norms(int ID)
		{
			base.id = ID;
			base.InitData(this);
			base.CurrentModel = this;
		}
		protected override EbSite.Base.BLL.BllBase<Norms, int> Bll()
		{
			 
				return BLL.Norms.Instance;
			 
		}
		#region Model
		private string _normsname;
		private string _demo;
		private int? _orderid;
		private int? _typenameid;
		private int? _isimg;
		/// <summary>
		/// 
		/// </summary>
		public string NormsName
		{
			set{ _normsname=value;}
			get{return _normsname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Demo
		{
			set{ _demo=value;}
			get{return _demo;}
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
		public int? TypeNameID
		{
			set{ _typenameid=value;}
			get{return _typenameid;}
		}
		/// <summary>
		/// 0 文字 1 图片
		/// </summary>
		public int? IsImg
		{
			set{ _isimg=value;}
			get{return _isimg;}
		}
		#endregion Model

	}
}

