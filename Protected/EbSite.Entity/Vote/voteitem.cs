using System;
namespace EbSite.Entity
{
	/// <summary>
	/// 实体类voteitem 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class voteitem: Base.Entity.EntityBase<voteitem,int>
	{
		public voteitem()
		{
			base.CurrentModel = this;
		}
		public voteitem(int ID)
		{
			base.id = ID;
			base.InitData(this);
			base.CurrentModel = this;
		}
        //protected override EbSite.Base.BLL.BllBase<voteitem, int> Bll
        //{
        //    get
        //    {
        //        return BLL.voteitem.Instance;
        //    }
        //}
		#region Model
		private string _itemname;
		private int _postcount;
		private int _voteid;
		/// <summary>
		/// 
		/// </summary>
		public string ItemName
		{
			set{ _itemname=value;}
			get{return _itemname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int PostCount
		{
			set{ _postcount=value;}
			get{return _postcount;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int VoteID
		{
			set{ _voteid=value;}
			get{return _voteid;}
		}
        //非数据库字段
        public string Percent { get; set; }
        public int ItemWidth { get; set; }
		#endregion Model

	}
}

