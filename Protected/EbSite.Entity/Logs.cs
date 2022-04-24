using System;
using System.Collections.Generic;

namespace EbSite.Entity
{
    /// <summary>
    /// 实体类Remark 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class Logs : Base.Entity.EntityBase<Logs, int>
    {
        public Logs()
        { }

        public Logs(int ID)
		{
			base.id = ID;
			base.InitData(this);
			base.CurrentModel = this;
		}
        protected override EbSite.Base.BLL.BllBase<Logs, int> Bll()
        {
             
                return BLL.Logs.Instance;
            
        }
        #region Model
        private string _Title;
        private string _Description;
        private DateTime _AddDate;
        private string _IP;

        public string IP
        {
            set { _IP = value; }
            get { return _IP; }
        }
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
      

        private int _LogType = 0;
        /// <summary>
        ///  0.综合日志，1.登录日志,2.静态页面错误生成日志,3.系统异常日志,4.404访问错误
        /// </summary>
        public int LogType
        {
            get
            {
                return _LogType;
            }
            set
            {
                _LogType = value;
            }
        }
        #endregion Model

    }
}

