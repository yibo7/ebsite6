using System;
namespace EbSite.Entity
{
	/// <summary>
	/// 实体类searchword 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class searchword: Base.Entity.EntityBase<searchword,Guid>
	{
		public searchword()
		{
			base.CurrentModel = this;
		}
		public searchword(Guid ID)
		{
			base.id = ID;
			base.InitData(this);
			base.CurrentModel = this;
		}
        //protected override EbSite.Base.BLL.BllBase<searchword, Guid> Bll
        //{
        //    get
        //    {
        //        return BLL.searchword.Instance;
        //    }
        //}
		#region Model
		private string _keyword;
		private int? _searchcount;
		private DateTime? _addtime;
		/// <summary>
		/// 
		/// </summary>
		public string keyword
		{
			set{ _keyword=value;}
			get{return _keyword;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? searchcount
		{
			set{ _searchcount=value;}
			get{return _searchcount;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? addtime
		{
			set{ _addtime=value;}
			get{return _addtime;}
		}
		#endregion Model

	}
}

