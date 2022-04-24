using System;
namespace EbSite.Modules.Shop.ModuleCore.Entity
{
	/// <summary>
	/// 实体类creditproductclass 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class creditproductclass: Base.Entity.EntityBase<creditproductclass,int>
	{
		public creditproductclass()
		{
			base.CurrentModel = this;
		}
		public creditproductclass(int ID)
		{
			base.id = ID;
			base.InitData(this);
			base.CurrentModel = this;
		}
        protected override EbSite.Base.BLL.BllBase<creditproductclass, int> Bll()
        {
           
                return BLL.creditproductclass.Instance;
            
        }
		#region Model
		private string _classname;
		private DateTime? _addtime;
		private int? _orderid;
		/// <summary>
		/// 
		/// </summary>
		public string ClassName
		{
			set{ _classname=value;}
			get{return _classname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? AddTime
		{
			set{ _addtime=value;}
			get{return _addtime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? OrderID
		{
			set{ _orderid=value;}
			get{return _orderid;}
		}
		#endregion Model

	}
}

