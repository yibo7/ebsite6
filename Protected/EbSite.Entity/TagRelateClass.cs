using System;
namespace EbSite.Entity
{
	/// <summary>
	/// 实体类TagRelateClass 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class TagRelateClass: Base.Entity.EntityBase<TagRelateClass,long>
	{
		public TagRelateClass()
		{
			base.CurrentModel = this;
		}
		public TagRelateClass(long ID)
		{
			base.id = ID;
			base.InitData(this);
			base.CurrentModel = this;
		}
		//protected override Base.BLL.BllBase<TagRelateClass, long> Bll
		//{
			//get
			//{
				//return BLL.TagRelateClass.Instance;
			//}
		//}
		#region Model
		private int _tagid;
		private string _tagname;
		private int _classid;
        private int _tableid;
		/// <summary>
		/// 标签ID
		/// </summary>
		public int TagID
		{
			set
			{
				if(_tagid != value)
				{
					 _tagid=value;
					
				}
			}
			get{return _tagid;}
		}
		/// <summary>
		/// 标签名称
		/// </summary>
		public string TagName
		{
			set
			{
				if(_tagname != value)
				{
					 _tagname=value;
					
				}
			}
			get{return _tagname;}
		}
		/// <summary>
		/// 类别ID
		/// </summary>
		public int ClassID
		{
			set
			{
				if(_classid != value)
				{
					 _classid=value;
					
				}
			}
			get{return _classid;}
		}
        /// <summary>
        /// 分表的id 默认为 0
        /// </summary>
        public int TableID
        {
            set { _tableid = value; }
            get { return _tableid; }
        }
		#endregion Model

	}
}

