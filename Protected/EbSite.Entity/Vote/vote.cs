using System;
namespace EbSite.Entity
{
	/// <summary>
	/// 实体类vote 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class vote: Base.Entity.EntityBase<vote,int>
	{
		public vote()
		{
			base.CurrentModel = this;
		}
		public vote(int ID)
		{
			base.id = ID;
			base.InitData(this);
			base.CurrentModel = this;
		}
        //protected override EbSite.Base.BLL.BllBase<vote, int> Bll
        //{
        //    get
        //    {
        //        return BLL.vote.Instance;
        //    }
        //}
		#region Model
		private string _votename;
		private int? _allowmaxsel;
		private bool _ismoresel;
		private int? _markint;
		private string _markstr;
		private int _votecount;
		private int? _startdate;
		private int? _enddate;
		private bool _isitemcolorran;
		private string _voteinfo;
        private int? _classid;
		/// <summary>
		/// 投票名称
		/// </summary>
		public string VoteName
		{
			set{ _votename=value;}
			get{return _votename;}
		}
		/// <summary>
		/// 最多可以选择几项，只有设置为多选模式才起作用
		/// </summary>
		public int? AllowMaxSel
		{
			set{ _allowmaxsel=value;}
			get{return _allowmaxsel;}
		}
		/// <summary>
		/// 是否多选择
		/// </summary>
		public bool IsMoreSel
		{
			set{ _ismoresel=value;}
			get{return _ismoresel;}
		}
		/// <summary>
		/// 整型标记，速度比字符串标记快得多,在标记为整型数据时建议使用
		/// </summary>
		public int? MarkInt
		{
			set{ _markint=value;}
			get{return _markint;}
		}
		/// <summary>
		/// 字符串类型标记，这个使用标记一些不确认的数据类型
		/// </summary>
		public string MarkStr
		{
			set{ _markstr=value;}
			get{return _markstr;}
		}
		/// <summary>
		/// 总投票数量
		/// </summary>
		public int VoteCount
		{
			set{ _votecount=value;}
			get{return _votecount;}
		}
		/// <summary>
		/// 开始时间
		/// </summary>
		public int? StartDate
		{
			set{ _startdate=value;}
			get{return _startdate;}
		}
		/// <summary>
		/// 结束时间
		/// </summary>
		public int? EndDate
		{
			set{ _enddate=value;}
			get{return _enddate;}
		}
		/// <summary>
		/// 是否展示时，每项的颜色随机出现
		/// </summary>
		public bool IsItemColorRan
		{
			set{ _isitemcolorran=value;}
			get{return _isitemcolorran;}
		}
		/// <summary>
		/// 投票简介
		/// </summary>
		public string VoteInfo
		{
			set{ _voteinfo=value;}
			get{return _voteinfo;}
		}
        /// <summary>
        /// 分类ID
        /// </summary>
        public int? ClassID
        {
            set { _classid = value; }
            get { return _classid; }
        }
		#endregion Model

	}
}

