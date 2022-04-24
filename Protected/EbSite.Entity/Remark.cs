using System;
namespace EbSite.Entity
{
    /// <summary>
    /// 实体类Remark 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class Remark
    {
        public Remark()
        { }
        #region Model
        private int _id;
        private string _username;
        private string _body;
        private string _ip;
        private string _quote;
        private int _support;
        private int _discourage;
        private int _information;
        private DateTime _dateandtime;
        private bool _isniname;
        private int _remarkclassid;
        private bool _isauditing;
      //  private string _mark;
        private string _userniname;
        private int _userid;
        private int _evaluationscore;
        private int _classid;
        private int _contentid;
        private DateTime? _dateasktime;
        private bool _isasked=false;

        public int UserID
        {
            set { _userid = value; }
            get { return _userid; }
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
        /// 用户名称
        /// </summary>
        public string UserName
        {
            set { _username = value; }
            get { return _username; }
        }
        /// <summary>
        /// 内容
        /// </summary>
        public string Body
        {
            set { _body = value; }
            get { return _body; }
        }
        /// <summary>
        /// ip地址
        /// </summary>
        public string Ip
        {
            set { _ip = value; }
            get { return _ip; }
        }
        /// <summary>
        /// 引用评论 
        /// </summary>
        public string Quote
        {
            set { _quote = value; }
            get { return _quote; }
        }
        /// <summary>
        /// 支持
        /// </summary>
        public int Support
        {
            set { _support = value; }
            get { return _support; }
        }
        /// <summary>
        /// 反对
        /// </summary>
        public int Discourage
        {
            set { _discourage = value; }
            get { return _discourage; }
        }
        /// <summary>
        /// 举报
        /// </summary>
        public int Information
        {
            set { _information = value; }
            get { return _information; }
        }
        /// <summary>
        /// 操作时间
        /// </summary>
        public DateTime DateAndTime
        {
            set { _dateandtime = value; }
            get { return _dateandtime; }
        }
        /// <summary>
        /// 是否匿名
        /// </summary>
        public bool IsNiName
        {
            set { _isniname = value; }
            get { return _isniname; }
        }
        /// <summary>
        /// 分类id
        /// </summary>
        public int RemarkClassID
        {
            set { _remarkclassid = value; }
            get { return _remarkclassid; }
        }
        /// <summary>
        /// 是否审核
        /// </summary>
        public bool IsAuditing
        {
            set { _isauditing = value; }
            get { return _isauditing; }
        }
        /////// <summary>
        /////// 评论对象的唯一标记,如内容将为内容ID，用户留言将会用户名称
        /////// </summary>
        //public string Mark  //已经放弃，目前只对分类与内容评论
        //{
        //    set { _mark = value; }
        //    get { return _mark; }
        //}
        /// <summary>
        /// 用户昵称
        /// </summary>
        public string UserNiName
        {
            set { _userniname = value; }
            get { return _userniname; }
        }
        /// <summary>
        /// 评价分数（五星）
        /// </summary>
        public int EvaluationScore
        {
            get { return _evaluationscore; }
            set { _evaluationscore = value; }
        }
        /// <summary>
        /// 内容分类 ID
        /// </summary>
        public int ClassID { 
            get { return _classid; }
            set { _classid = value; }
        }
        /// <summary>
        /// 文章ID
        /// </summary>
        public int ContentID
        {
            get { return _contentid; }
            set { _contentid = value; }
        }

     
        /// <summary>
        /// 一问一答 管理员 回复时间
        /// </summary>
        public DateTime? DateAskTime
        {
            get { return _dateasktime; }
            set { _dateasktime = value; }
        }
       
        /// <summary>
        /// 一问一答 标记 1：已回答。0：未回答
        /// </summary>
        public bool IsAsked
        {
            get { return _isasked; }
            set { _isasked = value; }
        }

        public bool IsNoAuditing
        {
            get { return !IsAuditing; }
        }
        #endregion Model

    }
}

