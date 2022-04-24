using System;
namespace EbSite.Entity
{
	/// <summary>
	/// 实体类SpaceTabs 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class SpaceTabs: Base.Entity.EntityBase<SpaceTabs,int>
	{
		public SpaceTabs()
		{
			base.CurrentModel = this;
		}
		public SpaceTabs(int ID)
		{
			base.id = ID;
			base.InitData(this);
			base.CurrentModel = this;
		}
        protected override Base.BLL.BllBase<SpaceTabs, int> Bll()
        {
            
                return BLL.SpaceTabs.Instance;
            
        }
		#region Model
		private string _tabname;
		private string _layout = "";
		private int _ordernum;
		private string _icoimg;
		private int _userid;
        private int _ParentID = 0;
        private string _Mark;
        /// <summary>
        /// 
        /// </summary>
        public string Mark
        {
            set { _Mark = value; }
            get { return _Mark; }
        }
		/// <summary>
		/// 
		/// </summary>
		public string TabName
		{
			set{ _tabname=value;}
			get{return _tabname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Layout
		{
			set{ _layout=value;}
			get{return _layout;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int OrderNum
		{
			set{ _ordernum=value;}
			get{return _ordernum;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ICOImg
		{
			set{ _icoimg=value;}
			get{return _icoimg;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int UserID
		{
			set{ _userid=value;}
			get{return _userid;}
		}
        public int ParentID
        {
            set { _ParentID = value; }
            get { return _ParentID; }
        }
		#endregion Model

	}
}

