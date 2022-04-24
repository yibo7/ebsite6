using System;
using EbSite.Base.Entity;

namespace EbSite.Entity
{
	/// <summary>
	/// 实体类SpaceTabs 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
    public class SpaceTabsDefault : XmlEntityBase<Guid>
	{
		
        
		#region Model
		private string _tabname;
		private string _layout = "";
		private int _ordernum;
		private string _icoimg;
		private int _usergroupid;
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
		public int UserGroupID
		{
            set { _usergroupid = value; }
            get { return _usergroupid; }
		}
		#endregion Model

	}
}

