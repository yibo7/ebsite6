using System;
using System.Collections.Generic;

namespace EbSite.Entity
{
    /// <summary>
    /// 实体类Remark 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class CtrTemList
    {
        public CtrTemList()
        { }
        #region Model
        private Guid _id = Guid.NewGuid();
        private Guid _classid = Guid.NewGuid();
        private string _Title;
        private string _Description;
        private DateTime _AddDate;
        private string _TemContent;
        //private Guid _modelclassid;
        ///// <summary>
        ///// 对应模型ID  
        ///// </summary>
        //public Guid ModelClassID
        //{
        //    get { return _modelclassid; }
        //    set { _modelclassid = value; }
        //}

        public Guid ClassId
        {
            set { _classid = value; }
            get { return _classid; }
        }

        public DateTime AddDate
        {
            set { _AddDate = value; }
            get { return _AddDate; }
        }
        public string TemContent
        {
            set { _TemContent = value; }
            get { return _TemContent; }
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

