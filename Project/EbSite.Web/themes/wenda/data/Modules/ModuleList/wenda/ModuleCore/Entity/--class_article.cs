//using System;
//namespace EbSite.Modules.Wenda.ModuleCore.Entity
//{
//    /// <summary>
//    ///  ÿ3�� ץȡ ÿ������ �� ���µ�ǰ50���ʴ����ݡ���������ʱ�����ô�NewsContent �в�ѯ��
//    ///  ����� �д��� ��ȶ��
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
//        /// �����
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
//        /// ����ID
//        /// </summary>
//        public string NewsTitle
//        {
//            set { _newstitle = value; }
//            get { return _newstitle; }
//        }
//        /// <summary>
//        /// �����û�ID
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
//        /// ����ʱ��
//        /// </summary>
//        public DateTime AddTime
//        {
//            set{ _addtime=value;}
//            get{return _addtime;}
//        }
//        /// <summary>
//        /// �ش�ʱ��
//        /// </summary>
//        public DateTime AskAddTime
//        {
//            set { _askaddtime = value; }
//            get { return _askaddtime; }
//        }
//        /// <summary>
//        /// ����id
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

