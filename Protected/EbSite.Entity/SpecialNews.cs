using System;
namespace EbSite.Entity
{
    /// <summary>
    /// 实体类SpecialNews 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class SpecialNews
    {
        public SpecialNews()
        { }
        #region Model
        private int _id;
        private long _newsid;
        private int _specialclassid;
        private int _orderid;
        private int _classid;
        private Guid _modelid;
        /// <summary>
        /// 
        /// </summary>
        public int id
        {
            set { _id = value; }
            get { return _id; }
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
        /// 家族ID
        /// </summary>
        public int SpecialClassID
        {
            set { _specialclassid = value; }
            get { return _specialclassid; }
        }
        /// <summary>
        /// 排序ID
        /// </summary>
        public int orderid
        {
            set { _orderid = value; }
            get { return _orderid; }
        }
        /// <summary>
        /// 关联专题文章的分类id
        /// </summary>
        public int ClassID
        {
            set { _classid = value; }
            get { return _classid; }
        }
      
        public Guid ModelID
        {
            set { _modelid = value; }
            get { return _modelid; }
        }
        #endregion Model

    }
}

