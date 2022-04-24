using System;
namespace EbSite.Entity
{
    /// <summary>
    /// 实体类Favorite 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class Favorite
    {
        public Favorite()
        { }
        #region Model
        private int _id;
        private int _contentid;
        private int _contentclassid;
        private int _classid = 0;
        private string _username;
        private int _favtype;
        private DateTime _adddatetime;

        private int _userid;
        private string _userniname;
        private string _title;
        private string _description;
        private string _tagids;
        private string _linkurl;
        private string _annex1;
        private string _annex2;
        private string _annex3;
        private int? _annex4;
        private int? _annex5;
        /// <summary>
        /// 标签
        /// </summary>
        public string Tagids
        {
            get
            {
                return _tagids;
            }
            set
            {
                _tagids = value;
            }
        }
       /// <summary>
       /// 描述信息
       /// </summary>
        public string Description
        {
            get
            {
                return _description;
            }
            set
            {
                _description = value;
            }
        }
        /// <summary>
        /// 收藏的 链接地址
        /// </summary>
        public string LinkUrl
        {
            get
            {
                return _linkurl;
            }
            set
            {
                _linkurl = value;
            }
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
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int ContentID
        {
            set { _contentid = value; }
            get { return _contentid; }
        }
        public int ContentClassId
        {
            set { _contentclassid = value; }
            get { return _contentclassid; }
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
        /// 分类id目前还没有使用
        /// </summary>
        public int ClassID
        {
            set { _classid = value; }
            get { return _classid; }
        }
        /// <summary>
        /// 收藏类别，0为内容，1为分类
        /// </summary>
        public int FavType
        {
            set { _favtype = value; }
            get { return _favtype; }
        }
        /// <summary>
        /// 收藏日期
        /// </summary>
        public DateTime AddDateTime
        {
            set { _adddatetime = value; }
            get { return _adddatetime; }
        }
        /// <summary>
        /// 标题
        /// </summary>
        public string Title
        {
            get
            {
                return _title;
            }
            set
            {
                _title = value;
            }
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

