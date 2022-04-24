using System;
namespace EbSite.Entity
{
    [Serializable]
    public class TagRelateNews
    {
        public TagRelateNews()
        { }
        #region Model
        private int _id;
        private int _tagid;
        private long _newsid;

        private int _classid;
        /// <summary>
        /// 唯一ID
        /// </summary>
        public int id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 标签ID
        /// </summary>
        public int TagID
        {
            set { _tagid = value; }
            get { return _tagid; }
        }
        /// <summary>
        /// 歌曲ID
        /// </summary>
        public long NewsID
        {
            set { _newsid = value; }
            get { return _newsid; }
        }
        /// <summary>
        /// 分表的id 
        /// </summary>
        public int ClassID
        {
            set { _classid = value; }
            get { return _classid; }
        }
        #endregion Model

    }
}

