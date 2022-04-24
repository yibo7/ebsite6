using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace EbSite.Entity
{
	/// <summary>
	/// 实体类thethirdlogincode 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class TheThirdLoginCode: Base.Entity.EntityBase<TheThirdLoginCode,int>
	{
		#region Model
        private int? _id;
		private int? _userid;
		private string _username;
		private string _tokencode;
		private string _appname;
        private int? _isbind;
        /// <summary>
        /// 是否手动绑定过账号
        /// </summary>
        public int? IsBind
        {
            get { return _isbind; }
            set { _isbind = value; }
        }
		private string _otherinfo;
		private DateTime? _adddate;
        /// <summary>
        /// 
        /// </summary>
        public int? ID
        {
            set { _id = value; }
            get { return _id; }
        }
		/// <summary>
		/// 
		/// </summary>
		public int? userid
		{
			set{ _userid=value;}
			get{return _userid;}
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
		public string tokencode
		{
			set{ _tokencode=value;}
			get{return _tokencode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string appname
		{
			set{ _appname=value;}
			get{return _appname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string otherinfo
		{
			set{ _otherinfo=value;}
			get{return _otherinfo;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? adddate
		{
			set{ _adddate=value;}
			get{return _adddate;}
		}
		#endregion Model

	}
}

