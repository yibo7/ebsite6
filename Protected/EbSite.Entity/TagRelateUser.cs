using System;
namespace EbSite.Entity
{
	/// <summary>
	/// 实体类TagRelateUser 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
    [Serializable]
    public class TagRelateUser
	{
		public TagRelateUser()
		{}
		#region Model
        private int _id;
        private int _tagid;
        private int _userid;
        private string _username;
        private string _userniname;
        /// <summary>
        /// 
        /// </summary>
        public int id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int TagID
        {
            set { _tagid = value; }
            get { return _tagid; }
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
        public string UserName
        {
            set { _username = value; }
            get { return _username; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string UserNiName
        {
            set { _userniname = value; }
            get { return _userniname; }
        }
		#endregion Model

	}
}

