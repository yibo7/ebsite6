using System;
namespace EbSite.Entity
{
	/// <summary>
	/// 实体类emailsendpool 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class emailsendpool: Base.Entity.EntityBase<emailsendpool,int>
	{
		public emailsendpool()
		{
			base.CurrentModel = this;
		}
		public emailsendpool(int ID)
		{
			base.id = ID;
			base.InitData(this);
			base.CurrentModel = this;
		}
        //protected override EbSite.Base.BLL.BllBase<emailsendpool, int> Bll
        //{
        //    get
        //    {
        //        return BLL.emailsendpool.Instance;
        //    }
        //}
		#region Model
		private string _title;
		private string _msgbody;
		private int? _sendtouserid;
		private string _sendtoemail;
		private string _attaurl;
		private DateTime? _adddatetime;
		private int? _adddatetimeinc;
		private int? _adduserid;
		private string _adduserniname;
		private int? _issended;
		/// <summary>
		/// 
		/// </summary>
		public string Title
		{
			set{ _title=value;}
			get{return _title;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string MsgBody
		{
			set{ _msgbody=value;}
			get{return _msgbody;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? SendToUserID
		{
			set{ _sendtouserid=value;}
			get{return _sendtouserid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string SendToEmail
		{
			set{ _sendtoemail=value;}
			get{return _sendtoemail;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string AttaUrl
		{
			set{ _attaurl=value;}
			get{return _attaurl;}
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
		public int? AddDateTimeInc
		{
			set{ _adddatetimeinc=value;}
			get{return _adddatetimeinc;}
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
		public int? IsSended
		{
			set{ _issended=value;}
			get{return _issended;}
		}
		#endregion Model

	}
}

