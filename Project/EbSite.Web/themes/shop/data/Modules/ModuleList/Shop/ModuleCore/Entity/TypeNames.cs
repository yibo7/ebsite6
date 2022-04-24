using System;
namespace EbSite.Modules.Shop.ModuleCore.Entity
{
	/// <summary>
	/// 实体类TypeNames 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class TypeNames: Base.Entity.EntityBase<TypeNames,int>
	{
		public TypeNames()
		{
			base.CurrentModel = this;
		}
		public TypeNames(int ID)
		{
			base.id = ID;
			base.InitData(this);
			base.CurrentModel = this;
		}
		protected override EbSite.Base.BLL.BllBase<TypeNames, int> Bll()
		{
			 
				return BLL.TypeNames.Instance;
			 
		}
		#region Model
		private string _typename;
		private int? _orderid;
		private string _brandids;

	    private bool _isspecial;
        /// <summary>
        /// 是否关联专题
        /// </summary>
	    public bool IsSpecial
	    {
	        get
	        {
	            return _isspecial;
	        }
            set
            {
                _isspecial = value;
            }
	    }
		/// <summary>
		/// 
		/// </summary>
		public string TypeName
		{
			set{ _typename=value;}
			get{return _typename;}
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
		/// 关联品牌
		/// </summary>
		public string BrandIDs
		{
			set{ _brandids=value;}
			get{return _brandids;}
		}
		#endregion Model

	}
}

