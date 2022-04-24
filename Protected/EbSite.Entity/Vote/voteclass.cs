using System;
namespace EbSite.Entity
{
	/// <summary>
	/// 实体类voteclass 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class voteclass: Base.Entity.EntityBase<voteclass,int>
	{
		public voteclass()
		{
			base.CurrentModel = this;
		}
		public voteclass(int ID)
		{
			base.id = ID;
			base.InitData(this);
			base.CurrentModel = this;
		}
        //protected override EbSite.Base.BLL.BllBase<voteclass, int> Bll
        //{
        //    get
        //    {
        //        return BLL.voteclass.Instance;
        //    }
        //}
		#region Model
		private string _classname;
		private int? _adduserid;
		private string _adduserniname;
		private DateTime? _adddatetime;
		private int? _adddatetimeint;
		/// <summary>
		/// 
		/// </summary>
		public string ClassName
		{
			set{ _classname=value;}
			get{return _classname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? AddUserID
		{
			set{ _adduserid=value;}
			get{return _adduserid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string AddUserNiName
		{
			set{ _adduserniname=value;}
			get{return _adduserniname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? AddDateTime
		{
			set{ _adddatetime=value;}
			get{return _adddatetime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? AddDateTimeInt
		{
			set{ _adddatetimeint=value;}
			get{return _adddatetimeint;}
		}
		#endregion Model

	}
}

