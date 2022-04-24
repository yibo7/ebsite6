using System;
namespace EbSite.Modules.BBS.ModuleCore.Entity
{
	/// <summary>
	/// 实体类toupiao 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class toupiao:Base.Entity.EntityBase<toupiao,long >
	{
		public toupiao()
		{
		    base.CurrentModel = this;
		}
        public toupiao(long ID)
        {
            base.id = ID;
            base.InitData(this);
            base.CurrentModel = this;
        }
        protected override Base.BLL.BllBase<toupiao, long> Bll
        {
            get
            {
                return BLL.toupiao.Instance;
            }
        }
		#region Model
	//	private long _id;
		private string _title;
		private string _color;
		private long _piaoshu;
		private string _bigid;
		private string _bigtitle;
		private string _shuoming;
		private string _tpusername;
		private string _tprealname;
		private string _username;
		private string _realname;
		private int? _companyid;
		/// <summary>
		/// 
		/// </summary>
        //public long id
        //{
        //    set{ _id=value;}
        //    get{return _id;}
        //}
		/// <summary>
		/// 
		/// </summary>
		public string title
		{
			set{ _title=value;}
			get{return _title;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string color
		{
			set{ _color=value;}
			get{return _color;}
		}
		/// <summary>
		/// 
		/// </summary>
		public long piaoshu
		{
			set{ _piaoshu=value;}
			get{return _piaoshu;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string bigId
		{
			set{ _bigid=value;}
			get{return _bigid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string bigtitle
		{
			set{ _bigtitle=value;}
			get{return _bigtitle;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string shuoming
		{
			set{ _shuoming=value;}
			get{return _shuoming;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string TpUsername
		{
			set{ _tpusername=value;}
			get{return _tpusername;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string TpRealname
		{
			set{ _tprealname=value;}
			get{return _tprealname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string username
		{
			set{ _username=value;}
			get{return _username;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string realname
		{
			set{ _realname=value;}
			get{return _realname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? CompanyID
		{
			set{ _companyid=value;}
			get{return _companyid;}
		}
		#endregion Model

	}
}

