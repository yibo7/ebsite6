using System;
namespace EbSite.Entity
{
	/// <summary>
	/// 实体类SpaceSetting 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class SpaceSetting: Base.Entity.EntityBase<SpaceSetting,int>
	{
		public SpaceSetting()
		{
			base.CurrentModel = this;
		}
		public SpaceSetting(int ID)
		{
			base.id = ID;
			base.InitData(this);
			base.CurrentModel = this;
		}
        //protected override Base.BLL.BllBase<SpaceSetting, int> Bll
        //{
        //    get
        //    {
        //        return BLL.SpaceSetting.Instance;
        //    }
        //}
		#region Model
		private int _userid;
		private string _title;
		private string _description;
		private string _rewritename;
		private int _themeid;
		private string _themepath;
		private int _defaulttabid = 0;
		private int _status;
		private DateTime _addtime;
		private DateTime _updatedatetime;
		private int _visitedtimes = 0;
		/// <summary>
		/// 
		/// </summary>
		public int UserID
		{
			set{ _userid=value;}
			get{return _userid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Title
		{
			set{ _title=value;}
			get{return _title;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Description
		{
			set{ _description=value;}
			get{return _description;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ReWriteName
		{
			set{ _rewritename=value;}
			get{return _rewritename;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int ThemeID
		{
			set{ _themeid=value;}
			get{return _themeid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ThemePath
		{
			set{ _themepath=value;}
			get{return _themepath;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int DefaultTabID
		{
			set{ _defaulttabid=value;}
			get{return _defaulttabid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int Status
		{
			set{ _status=value;}
			get{return _status;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime AddTime
		{
			set{ _addtime=value;}
			get{return _addtime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime UpdatedateTime
		{
			set{ _updatedatetime=value;}
			get{return _updatedatetime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int VisitedTimes
		{
			set{ _visitedtimes=value;}
			get{return _visitedtimes;}
		}
		#endregion Model

	}
}

