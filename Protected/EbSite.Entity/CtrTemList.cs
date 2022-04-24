using System;
using System.Collections.Generic;

namespace EbSite.Entity
{
    /// <summary>
    /// 实体类Remark 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class CtrTemClass
    {
        public CtrTemClass()
        { }
        #region Model
        private Guid _id = Guid.NewGuid();
        private string _Title;
        private string _Description;
        private DateTime _AddDate;
        public DateTime AddDate
        {
            set { _AddDate = value; }
            get { return _AddDate; }
        }
        public string Description
        {
            set { _Description = value; }
            get { return _Description; }
        }
        public string Title
        {
            set { _Title = value; }
            get { return _Title; }
        }
        public Guid ID
        {
            set { _id = value; }
            get { return _id; }
        }
        
        #endregion Model

    }
}

