using System;
namespace EbSite.Entity
{
    /// <summary>
    /// 实体类Favorite 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class UserNews
    {
       public UserNews()
		{}
		#region Model
		private int _id;
        private string _UserName;
		private string _newsinfo;
		private DateTime _adddatetime;
		/// <summary>
		/// 
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
        public string UserName
		{
            set { _UserName = value; }
            get { return _UserName; }
		}
		/// <summary>
		/// 
		/// </summary>
		public string NewsInfo
		{
			set{ _newsinfo=value;}
			get{return _newsinfo;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime AddDateTime
		{
			set{ _adddatetime=value;}
			get{return _adddatetime;}
		}
		#endregion Model

    }
}

