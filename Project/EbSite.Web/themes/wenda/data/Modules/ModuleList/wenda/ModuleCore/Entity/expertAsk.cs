using System;
namespace EbSite.Modules.Wenda.ModuleCore.Entity
{
	/// <summary>
	/// 实体类expertAsk 向专家的提问
	/// </summary>
	[Serializable]
	public class expertAsk: Base.Entity.EntityBase<expertAsk,int>
	{
		public expertAsk()
		{
			base.CurrentModel = this;
		}
		public expertAsk(int ID)
		{
			base.id = ID;
			base.InitData(this);
			base.CurrentModel = this;
		}
		protected override EbSite.Base.BLL.BllBase<expertAsk, int> Bll()
		{
			 
				return BLL.expertAsk.Instance;
			 
		}
		#region Model
		private int? _qid;
	    private int? _classid;
		private int? _userid;
		private int? _state;
		private DateTime? _optime;
        private string _title;
        private DateTime? _askdate;

        /// <summary>
        /// 提问 标题
        /// </summary>
        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }
        /// <summary>
        /// 回答时间
        /// </summary>
        public DateTime? AskDate
        {
            get { return _askdate; }
            set { _askdate = value; }
        }

		/// <summary>
		/// 问题id
		/// </summary>
		public int? Qid
		{
			set{ _qid=value;}
			get{return _qid;}
		}
        /// <summary>
        /// 分类id
        /// </summary>
	    public int? ClassID
	    {
            get { return _classid; }
            set { _classid = value; }
	    }
		/// <summary>
		/// 用户ID
		/// </summary>
		public int? UserID
		{
			set{ _userid=value;}
			get{return _userid;}
		}
		/// <summary>
		/// 状态
		/// </summary>
		public int? State
		{
			set{ _state=value;}
			get{return _state;}
		}
		/// <summary>
		/// 提问时间
		/// </summary>
		public DateTime? OpTime
		{
			set{ _optime=value;}
			get{return _optime;}
		}
        
		#endregion Model

	}
}

