using System;
namespace EbSite.Entity
{
	/// <summary>
	/// 实体类outlinks 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class outlinks: Base.Entity.EntityBase<outlinks,int>
	{
		public outlinks()
		{
			base.CurrentModel = this;
		}
		public outlinks(int ID)
		{
			base.id = ID;
			base.InitData(this);
			base.CurrentModel = this;
		}
        //protected override EbSite.Base.BLL.BllBase<outlinks, int> Bll
        //{
        //    get
        //    {
        //        return BLL.outlinks.Instance;
        //    }
        //}
		#region Model
		private string _sitename;
		private string _url;
		private string _logourl;
		private string _qq;
		private string _email;
		private string _tel;
		private string _mobile;
		private string _demo;
		private bool? _ishavelogo;
		private int? _orderid;
		private int? _siteid;
		private bool? _isauditing;
		/// <summary>
		/// 
		/// </summary>
		public string SiteName
		{
			set{ _sitename=value;}
			get{return _sitename;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Url
		{
			set{ _url=value;}
			get{return _url;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string LogoUrl
		{
			set{ _logourl=value;}
			get{return _logourl;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string QQ
		{
			set{ _qq=value;}
			get{return _qq;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Email
		{
			set{ _email=value;}
			get{return _email;}
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
		public string Mobile
		{
			set{ _mobile=value;}
			get{return _mobile;}
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
		/// 1: 表示 有Logo  0:没有图片
		/// </summary>
		public bool? IsHaveLogo
		{
			set{ _ishavelogo=value;}
			get{return _ishavelogo;}
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
		public int? SiteID
		{
			set{ _siteid=value;}
			get{return _siteid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool? IsAuditing
		{
			set{ _isauditing=value;}
			get{return _isauditing;}
		}
        public DateTime AddTime { get; set; }
		#endregion Model

	}
}

