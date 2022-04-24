using System;
namespace EbSite.Entity
{
	/// <summary>
	/// ʵ����tool_chatlist ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	[Serializable]
	public class tool_chatlist: Base.Entity.EntityBase<tool_chatlist,long>
	{
		public tool_chatlist()
		{
			
		}
		#region Model
		private int? _saleruserid;
		private string _salername;
		private byte[] _salerusername;
		private int? _userid;
		private string _username;
		private string _userniname;
		private string _userip;
		private string _msg;
		private DateTime? _datetime;
		private int? _issalersay;
		/// <summary>
		/// 
		/// </summary>
		public int? SalerUserID
		{
			set{ _saleruserid=value;}
			get{return _saleruserid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string SalerName
		{
			set{ _salername=value;}
			get{return _salername;}
		}
		/// <summary>
		/// 
		/// </summary>
		public byte[] SalerUserName
		{
			set{ _salerusername=value;}
			get{return _salerusername;}
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
		public string UserName
		{
			set{ _username=value;}
			get{return _username;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string UserNiName
		{
			set{ _userniname=value;}
			get{return _userniname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string UserIP
		{
			set{ _userip=value;}
			get{return _userip;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Msg
		{
			set{ _msg=value;}
			get{return _msg;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? DateTime
		{
			set{ _datetime=value;}
			get{return _datetime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? IsSalerSay
		{
			set{ _issalersay=value;}
			get{return _issalersay;}
		}
		#endregion Model

	}
}

