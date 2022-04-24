using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EbSite.Base.Entity;

namespace EbSite.Entity
{
    /// <summary>
    /// 实体类goods_visite 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class goods_visite : Base.Entity.EntityBase<goods_visite, int>
    {
        public goods_visite()
        {
            base.CurrentModel = this;
        }
        public goods_visite(int ID)
        {
            base.id = ID;
            base.InitData(this);
            base.CurrentModel = this;
        }
        protected override EbSite.Base.BLL.BllBase<goods_visite, int> Bll()
        {
            
                return BLL.goods_visite.Instance;
            
        }
        #region Model
        private int _userid;
        private int _contentid;
        private int _count;
        private long _ip;
        private int _numtime;
        private int _classid;
        /// <summary>
        /// 用户ID
        /// </summary>
        public int UserID
        {
            set { _userid = value; }
            get { return _userid; }
        }
        /// <summary>
        /// 产品ID
        /// </summary>
        public int ContentID
        {
            set { _contentid = value; }
            get { return _contentid; }
        }
        /// <summary>
        /// 访问总数
        /// </summary>
        public int Count
        {
            set { _count = value; }
            get { return _count; }
        }
        /// <summary>
        /// 客户的ip地址
        /// </summary>
        public long Ip
        {
            set { _ip = value; }
            get { return _ip; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int NumTime
        {
            set { _numtime = value; }
            get { return _numtime; }
        }
        public int ClassID
        {
            get { return _classid; }
            set { _classid = value; }
        }
        #endregion Model
        /// <summary>
        /// 缩略图
        /// </summary>
        public string Smallpic
        {

            get;
            set;
        }

        /// <summary>
        /// 标题
        /// </summary>
        public string NewsTitle
        {

            get;
            set;
        }

    }
}

