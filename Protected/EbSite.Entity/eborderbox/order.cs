using System;
namespace EbSite.Entity
{
	/// <summary>
	/// 实体类order 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class order: Base.Entity.EntityBase<order,long>
	{
		public order()
		{
			base.CurrentModel = this;
		}
        //public order(long ID)
        //{
        //    base.id = ID;
        //    base.InitData(this);
        //    base.CurrentModel = this;
        //}
        //protected override EbSite.Base.BLL.BllBase<order, long> Bll
        //{
        //    get
        //    {
        //        return BLL.order.Instance;
        //    }
        //}
		#region Model
		private string _ordernumber;
		private string _datainfo;
		private int? _adduserid;
		private string _adduserip;
		private string _addusername;
		private int? _userid;
		private DateTime? _addtime;
		/// <summary>
		/// 
		/// </summary>
		public string OrderNumber
		{
			set{ _ordernumber=value;}
			get{return _ordernumber;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string DataInfo
		{
			set{ _datainfo=value;}
			get{return _datainfo;}
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
		public string AddUserIP
		{
			set{ _adduserip=value;}
			get{return _adduserip;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string AddUserName
		{
			set{ _addusername=value;}
			get{return _addusername;}
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
		public DateTime? AddTime
		{
			set{ _addtime=value;}
			get{return _addtime;}
		}
		#endregion Model

	}
}

