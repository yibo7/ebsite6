//using System;
//namespace EbSite.Modules.Wenda.ModuleCore.Entity
//{
//    /// <summary>
//    ///  每3天 抓取 每个分类 中 最新的前50条问答数据。数据量大时，不用从NewsContent 中查询。
//    ///  这个表 有待于 商榷。
//    /// </summary>
//    [Serializable]
//    public class class_article: Base.Entity.EntityBase<class_article,long>
//    {
//        public class_article()
//        {
//            base.CurrentModel = this;
//        }
//        public class_article(int ID)
//        {
//            base.id = ID;
//            base.InitData(this);
//            base.CurrentModel = this;
//        }
//        protected override EbSite.Base.BLL.BllBase<class_article, long> Bll
//        {
//            get
//            {
//                return BLL.class_article.Instance;
//            }
//        }
//        #region Model
//        private string _classname;
//        private string _newstitle;
//        private int _userid;
//        private string _contentinfo;
//        private string _htmlname;
//        private DateTime _addtime;
//        private int _classid;
//        private DateTime _askaddtime;

//        private int _randnum;
//        /// <summary>
//        /// 随机数
//        /// </summary>
//        public int RandNum
//        {
//            get { return _randnum; }
//            set { _randnum = value; }
//        }
	   
//        /// <summary>
//        /// 
//        /// </summary>
//        public string  ClassName
//        {
//            set { _classname = value; }
//            get { return _classname; }
//        }
//        /// <summary>
//        /// 问题ID
//        /// </summary>
//        public string NewsTitle
//        {
//            set { _newstitle = value; }
//            get { return _newstitle; }
//        }
//        /// <summary>
//        /// 提问用户ID
//        /// </summary>
//        public int UserID
//        {
//            set{ _userid=value;}
//            get{return _userid;}
//        }
//        /// <summary>
//        ///
//        /// </summary>
//        public string ContentInfo
//        {
//            set{ _contentinfo=value;}
//            get{return _contentinfo;}
//        }
//        /// <summary>
//        /// 
//        /// </summary>
//        public string HtmlName
//        {
//            set{ _htmlname=value;}
//            get{return _htmlname;}
//        }
		
//        /// <summary>
//        /// 导入时间
//        /// </summary>
//        public DateTime AddTime
//        {
//            set{ _addtime=value;}
//            get{return _addtime;}
//        }
//        /// <summary>
//        /// 回答时间
//        /// </summary>
//        public DateTime AskAddTime
//        {
//            set { _askaddtime = value; }
//            get { return _askaddtime; }
//        }
//        /// <summary>
//        /// 分类id
//        /// </summary>
//        public int Classid
//        {
//            set{ _classid=value;}
//            get{return _classid ;}
//        }
		
//        #endregion Model

//        private int _annex14;
//        public int Annex14
//        {
//            get { return _annex14; }
//            set { _annex14 = value; }
//        }

//        private long _askid;

//        public long AskId
//        {
//            get { return _askid; }
//            set { _askid = value; }
//        }

//    }
//}

