using System;
namespace EbSite.Modules.BBS.ModuleCore.Entity
{
	/// <summary>
	/// 实体类toupiaobt 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class toupiaobt:Base.Entity.EntityBase<toupiaobt,long >
	{
		public toupiaobt()
		{
		    base.CurrentModel = this;
		}
        public toupiaobt(long ID)
        {
            base.id = ID;
            base.InitData(this);
            base.CurrentModel = this;
        }
        protected override Base.BLL.BllBase<toupiaobt, long> Bll
        {
            get
            {
                return BLL.toupiaobt.Instance;
            }
        }
		#region Model
		//private long _id;
		private string _title;
		private string _xuanze;
		private string _username;
		private string _realname;
		private string _gkusername;
		private string _gkrealname;
		private string _type;
		private string _ifopen;
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
		public string xuanze
		{
			set{ _xuanze=value;}
			get{return _xuanze;}
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
		public string Gkusername
		{
			set{ _gkusername=value;}
			get{return _gkusername;}
		}
		/// <summary>
		/// 进行中，已结束，
		/// </summary>
		public string Gkrealname
		{
			set{ _gkrealname=value;}
			get{return _gkrealname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string type
		{
			set{ _type=value;}
			get{return _type;}
		}
		/// <summary>
		/// 关闭，公开
		/// </summary>
		public string ifopen
		{
			set{ _ifopen=value;}
			get{return _ifopen;}
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

