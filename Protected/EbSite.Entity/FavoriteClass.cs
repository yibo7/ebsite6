using System;
namespace EbSite.Entity
{
    /// <summary>
    /// FavoriteClass 收藏分类，目前还未使用
    /// </summary>
    [Serializable]
    public class FavoriteClass
    {
       public FavoriteClass()
		{}
		#region Model
		private int _id;
		private string _classname;
		private string _username;
        private int _userid;
        private string _userniname;

        private DateTime _adddatetime;

        private string _annex1;
        private string _annex2;
        private string _annex3;
        private int? _annex4;
        private int? _annex5;
        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime Adddatetime
        {
            get { return _adddatetime; }
            set { _adddatetime = value; }
        }

        private int _orderid;
        /// <summary>
        /// 排序ID
        /// </summary>
        public int Orderid
        {
            get { return _orderid; }
            set { _orderid = value; }
        }

        private int _parentid;
        /// <summary>
        /// 父ID
        /// </summary>
        public int Parentid
        {
            get { return _parentid; }
            set { _parentid = value; }
        }
  
        /// <summary>
        /// 
        /// </summary>
        public int UserID
        {
            set { _userid = value; }
            get { return _userid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string UserNiName
        {
            set { _userniname = value; }
            get { return _userniname; }
        }
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
		public string ClassName
		{
			set{ _classname=value;}
			get{return _classname;}
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
        public string Annex1
        {
            set { _annex1 = value; }
            get { return _annex1; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Annex2
        {
            set { _annex2 = value; }
            get { return _annex2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Annex3
        {
            set { _annex3 = value; }
            get { return _annex3; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? Annex4
        {
            set { _annex4 = value; }
            get { return _annex4; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? Annex5
        {
            set { _annex5 = value; }
            get { return _annex5; }
        }
		#endregion Model

    }
}

