using System;
namespace EbSite.Modules.Shop.ModuleCore.Entity
{
	/// <summary>
	/// 实体类buy_orderitem_img 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class buy_orderitem_img: Base.Entity.EntityBase<buy_orderitem_img,int>
	{
		public buy_orderitem_img()
		{
			base.CurrentModel = this;
		}

		#region Model
		private int? _orderitemid;
		private string _bigimg;
		private string _smallimg;
		private int? _typeid;
		/// <summary>
        /// 对应 ebshop_buy_orderitem 表 自增id
		/// </summary>
		public int? orderitemid
		{
			set{ _orderitemid=value;}
			get{return _orderitemid;}
		}
		/// <summary>
		/// 大图
		/// </summary>
		public string bigimg
		{
			set{ _bigimg=value;}
			get{return _bigimg;}
		}
		/// <summary>
		/// 小图
		/// </summary>
		public string smallimg
		{
			set{ _smallimg=value;}
			get{return _smallimg;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? typeid
		{
			set{ _typeid=value;}
			get{return _typeid;}
		}
		#endregion Model

	}
}

