using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbSite.ApiEntity
{
    [Serializable]
    public class Content
    {
        #region Model

        private string _smallpic = "";
        private string _newstitle;
        private string _titlestyle;
        private int _classid;
        private int _hits = 0;
        private bool? _isgood = null;
        private string _contentinfo;
        private int _dayhits = 0;
        private int _weekhits = 0;
        private int _monthhits = 0;
        private DateTime? _lasthitstime = null;
        private string _tagids = string.Empty;
        //private int _userid;
        private int _orderid = 0;
        private string _htmlname;
        //private Guid _contenttemid;
        private string _contenthtmlnamerule;
        private bool _markismakehtml;
        private bool _iscomment;
        private DateTime _addtime = DateTime.Now;
        private string _username;
        private string _annex1;
        private string _annex2;
        private string _annex3;
        private string _annex4;
        private string _annex5;
        private string _annex6;
        private string _annex7;
        private string _annex8;
        private string _annex9;
        private string _annex10;

        private int _annex11;
        private int _annex12;
        private int _annex13;
        private int _annex14;
        private int _annex15;
        private decimal _annex16;
        private decimal _annex17;
        private decimal _annex18;

        private float _annex19;
        private float _annex20;


        private long _annex21;
        private long _annex22;
        private long _annex23;
        private long _annex24;
        private long _annex25;

        private string _ClassName;
        private int _commentnum;
        private int _favorablenum;
        private string _userniname;
        private int _userid;
        private int _siteid;

        private int _randnum = 0;

        private int _numbertime = 0;
        /// <summary>
        /// 时间
        /// </summary>
        public int NumberTime
        {
            get { return _numbertime; }
            set { _numbertime = value; }
        }
        /// <summary>
        /// 随机数
        /// </summary>
        public int RandNum
        {
            get { return _randnum; }
            set { _randnum = value; }
        }
        public int SiteID
        {
            get
            {
                return _siteid;
            }
            set
            {
                _siteid = value;
            }
        }
        public int UserID
        {
            set { _userid = value; }
            get { return _userid; }
        }
        public string UserNiName
        {
            set { _userniname = value; }
            get { return _userniname; }
        }

        private int _Advs = 0;
        /// <summary>
        /// 收藏的量
        /// </summary>
        public int Advs
        {

            set { _Advs = value; }
            get { return _Advs; }
        }

        private bool? _IsAuditing = null;
        public bool? IsAuditing
        {
            set { _IsAuditing = value; }
            get { return _IsAuditing; }
        }

        public string ClassName
        {
            set { _ClassName = value; }
            get { return _ClassName; }
        }

        /// <summary>
        /// 图片
        /// </summary>
        public string SmallPic
        {
            set { _smallpic = value; }
            get { return _smallpic; }
        }
        /// <summary>
        /// 名称
        /// </summary>
        public string NewsTitle
        {
            set { _newstitle = value; }
            get { return _newstitle; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string TitleStyle
        {
            set { _titlestyle = value; }
            get { return _titlestyle; }
        }
        /// <summary>
        /// 分类ID
        /// </summary>
        public int ClassID
        {
            set { _classid = value; }
            get { return _classid; }
        }
        /// <summary>
        /// 总点击数
        /// </summary>
        public int hits
        {
            set { _hits = value; }
            get { return _hits; }
        }
        /// <summary>
        /// 是否推荐，0为不推荐，1为推荐
        /// </summary>
        public bool? IsGood
        {
            set { _isgood = value; }
            get { return _isgood; }
        }
        /// <summary>
        /// 歌词文本
        /// </summary>
        public string ContentInfo
        {
            set { _contentinfo = value; }
            get { return _contentinfo; }
        }
        /// <summary>
        /// 今天访问量
        /// </summary>
        public int dayHits
        {
            set { _dayhits = value; }
            get { return _dayhits; }
        }
        /// <summary>
        /// 本周访问量
        /// </summary>
        public int weekHits
        {
            set { _weekhits = value; }
            get { return _weekhits; }
        }
        /// <summary>
        /// 本月访问量
        /// </summary>
        public int monthhits
        {
            set { _monthhits = value; }
            get { return _monthhits; }
        }
        /// <summary>
        /// 最后访问时间
        /// </summary>
        public DateTime? lasthitstime
        {
            set { _lasthitstime = value; }
            get { return _lasthitstime; }
        }
        /// <summary>
        /// 标签ID，以,号分类不同标签ID
        /// </summary>
        public string TagIDs
        {
            set { _tagids = value; }
            get { return _tagids; }
        }
        /// <summary>
        /// 
        /// </summary>
        //public int UserID
        //{
        //    set { _userid = value; }
        //    get { return _userid; }
        //}
        /// <summary>
        /// 
        /// </summary>
        public int OrderID
        {
            set { _orderid = value; }
            get { return _orderid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string HtmlName
        {
            set { _htmlname = value; }
            get { return _htmlname; }
        }
        ///// <summary>
        ///// 
        ///// </summary>
        //public Guid ContentTemID
        //{
        //    set { _contenttemid = value; }
        //    get { return _contenttemid; }
        //}
        /// <summary>
        /// 
        /// </summary>
        public string ContentHtmlNameRule
        {
            set { _contenthtmlnamerule = value; }
            get { return _contenthtmlnamerule; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool MarkIsMakeHtml
        {
            set { _markismakehtml = value; }
            get { return _markismakehtml; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool IsComment
        {
            set { _iscomment = value; }
            get { return _iscomment; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime AddTime
        {
            set { _addtime = value; }
            get { return _addtime; }
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
        public string Annex4
        {
            set { _annex4 = value; }
            get { return _annex4; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Annex5
        {
            set { _annex5 = value; }
            get { return _annex5; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Annex6
        {
            set { _annex6 = value; }
            get { return _annex6; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Annex7
        {
            set { _annex7 = value; }
            get { return _annex7; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Annex8
        {
            set { _annex8 = value; }
            get { return _annex8; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Annex9
        {
            set { _annex9 = value; }
            get { return _annex9; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Annex10
        {
            set { _annex10 = value; }
            get { return _annex10; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int Annex11
        {
            set { _annex11 = value; }
            get { return _annex11; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int Annex12
        {
            set { _annex12 = value; }
            get { return _annex12; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int Annex13
        {
            set { _annex13 = value; }
            get { return _annex13; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int Annex14
        {
            set { _annex14 = value; }
            get { return _annex14; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int Annex15
        {
            set { _annex15 = value; }
            get { return _annex15; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal Annex16
        {
            set { _annex16 = value; }
            get { return _annex16; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal Annex17
        {
            set { _annex17 = value; }
            get { return _annex17; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal Annex18
        {
            set { _annex18 = value; }
            get { return _annex18; }
        }

        public float Annex19
        {
            set { _annex19 = value; }
            get { return _annex19; }
        }
        public float Annex20
        {
            set { _annex20 = value; }
            get { return _annex20; }
        }
        public long Annex21
        {
            set { _annex21 = value; }
            get { return _annex21; }
        }
        public long Annex22
        {
            set { _annex22 = value; }
            get { return _annex22; }
        }
        public long Annex23
        {
            set { _annex23 = value; }
            get { return _annex23; }
        }
        public long Annex24
        {
            set { _annex24 = value; }
            get { return _annex24; }
        }
        public long Annex25
        {
            set { _annex25 = value; }
            get { return _annex25; }
        }
        /// <summary>
        /// 评论数量
        /// </summary>
        public int CommentNum
        {
            set { _commentnum = value; }
            get { return _commentnum; }
        }
        /// <summary>
        /// 好评数量，或顶一下，或星级
        /// </summary>
        public int FavorableNum
        {
            set { _favorablenum = value; }
            get { return _favorablenum; }
        }
        #endregion Model


        private long _Id = 0;
        /// <summary>
        /// ID
        /// </summary>
        public long ID
        {
            set { _Id = value; }
            get { return _Id; }
        }
    }
}
