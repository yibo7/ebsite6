using System;
namespace EbSite.Entity
{
	/// <summary>
	/// 实体类SpaceTabWidget 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class SpaceTabWidget: Base.Entity.EntityBase<SpaceTabWidget,int>
	{
		public SpaceTabWidget()
		{
			base.CurrentModel = this;
		}
		public SpaceTabWidget(int ID)
		{
			base.id = ID;
			base.InitData(this);
			base.CurrentModel = this;
		}
        //protected override Base.BLL.BllBase<SpaceTabWidget, int> Bll
        //{
        //    get
        //    {
        //        return BLL.SpaceTabWidget.Instance;
        //    }
        //}
		#region Model
		private int? _tabid;
		private Guid _widgetid;
		private string _layoutpane;
		private int? _userid;
		private int? _ordernum;
        private Guid _boxstyleid;
        public Guid BoxStyleID
        {
            set { _boxstyleid = value; }
            get { return _boxstyleid; }
        }
		/// <summary>
		/// 
		/// </summary>
		public int? TabID
		{
			set{ _tabid=value;}
			get{return _tabid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public Guid WidgetID
		{
			set{ _widgetid=value;}
			get{return _widgetid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string LayoutPane
		{
			set{ _layoutpane=value;}
			get{return _layoutpane;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? UserID
		{
			set{ _userid=value;}
			get{return _userid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? OrderNum
		{
			set{ _ordernum=value;}
			get{return _ordernum;}
		}
		#endregion Model

	}
}

