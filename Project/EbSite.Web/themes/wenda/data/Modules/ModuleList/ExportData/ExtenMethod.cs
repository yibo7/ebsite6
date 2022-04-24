using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using EbSite.Base.Entity;
using EbSite.Core.FSO;
using MySql.Data.MySqlClient;
using System.Collections;

namespace ExportData
{
    public class ExtenMethod
    {
        //public static string strConn = "Data Source=192.168.1.9;Port=3306;UserId=root;Password=369913836;database=ebsite_beimai;charset=utf8;";
        //public static string strConn = "Data Source=202.85.212.233;Port=3306;UserId=beimai2013;Password=bm369913836;database=ebsite_beimai;charset=utf8;";
        public static string strConn = "Data Source=202.85.208.2;Port=3306;UserId=beimai2013;Password=369913836sql;database=beimaidata;charset=utf8;";
        public void DataImportList(string txtTitle, int classid,string className,string annex14, string txtContent, string[] arryHf)
        {
            if (!string.IsNullOrEmpty(txtTitle))
            {
                string strNiName = "";
                string strReName = "";
                int fauid = RandUserID(new int[0],out strNiName,out strReName);
                if (fauid > 0)
                {
                    NewsContent newsContent = new NewsContent();

                    newsContent.ClassID = classid;
                    newsContent.ContentInfo = txtContent;
                    newsContent.NewsTitle = txtTitle;

                    newsContent.Annex1 = "0"; //悬赏分
                    newsContent.Annex2 = ""; //扩展//扩展属性：用来标实来源
                    newsContent.Annex3 = "0";
                    newsContent.Annex5 = "0";
                    newsContent.AddTime = DateTime.Now.AddMinutes(-30);
                    newsContent.Annex4 = "1"; //问题状态 1.未解决 2.已 3.无满意
                    newsContent.Annex6 = DateTime.Now.AddMinutes(-30).ToString(); //发表问题 时间 -10分钟
                    newsContent.Annex9 = DateTime.Now.AddDays(29).ToString(); //到期日期
                    newsContent.IsAuditing = true; // newsContent.Annex12 = 1; //审核 1：通过 0：不通过
                    newsContent.Annex12 = 1;//1：代表 从订单导过来的。0：手工录入的
                    newsContent.Annex14 = 0; //是否匿名 1：匿名 0：不匿名
                    newsContent.SiteID =2;
                    newsContent.TitleStyle = "";
                    newsContent.UserID = fauid; // 发表人ID 
                    newsContent.UserNiName = strNiName;
                    newsContent.UserName = strReName;

                    newsContent.ContentHtmlNameRule = "content/{#TitleSpell#}{#KeyID#}";
                    newsContent.HtmlName = EbSite.BLL.HtmlReNameRule.GetName(newsContent.ContentHtmlNameRule, newsContent.NewsTitle, newsContent.ClassName);
                    //从当前规则转换文件名
                    newsContent.IsComment = true;
                    newsContent.ContentTemID =new Guid("5050dfd5-8d35-4d05-b1d4-5011568e6c9a");

                    if (arryHf != null && arryHf.Length > 0)
                    {
                        newsContent.Annex11 = arryHf.Length;
                    }
                    else
                    {
                        newsContent.Annex11 = 0;
                    }

                    int tag = DataMySql.Instance.NewsContent_Add(newsContent);
                    //List<int> lis = new List<int>();
                    //lis.Add(fauid);
                    Random r = new Random();
                    ArrayList usedID = new ArrayList();
                    for (int i = 0; i < arryHf.Length; i++)
                    {
                        int uid1 = 0;
                        string ips1 = "";
                        //回复 数组
                        if (!string.IsNullOrEmpty(arryHf[i]))
                        {
                            //string tniname="", trename = "";
                            string[] arry = arryHf[i].Split('|');
                            //uid1 = RandUserID(lis.ToArray(),out tniname,out trename);
                            ips1 = RandIp(new string[] { });
                            //lis.Add(uid1);
                            //获取不重复的随机用户ID
                            int uIndex = GetRandID(r, usedID);
                            string tmpUID = GetRandUserID(uIndex);
                            uid1 = int.Parse(tmpUID);
                            AddHfAnwser(tag, fauid, uid1, arry[0], Convert.ToInt32(arry[1]), ips1);
                        }
                    }
                    #region 添加到 ask_class_article YHL 2013-07-01

                    EbSite.Modules.BmAsk.ModuleCore.Entity.class_article classArticlemodel = new EbSite.Modules.BmAsk.ModuleCore.Entity.class_article();

                    classArticlemodel.ClassName = className;
                    classArticlemodel.NewsTitle = txtTitle;
                    //classArticlemodel.ContentInfo = txtContent;
                    classArticlemodel.UserID = fauid;
                    classArticlemodel.AddTime = DateTime.Now;
                    classArticlemodel.Classid = classid;
                    classArticlemodel.Annex14 =EbSite.Core.Utils.StrToInt(annex14);
                    classArticlemodel.AskId = tag;
                    classArticlemodel.AskAddTime = DateTime.Now;
                    classArticlemodel.RandNum = GetRandNum();

                    DataMySql.Instance.class_article_Add(classArticlemodel);

                    #endregion 添加到 ask_class_article YHL 2013-07-01
                }
            }
        }

        public void DataImportList(int askid,int userid, int classid, string className, string annex14, string txtTitle,DateTime dt)
        {
            if (!string.IsNullOrEmpty(txtTitle))
            {
                #region 添加到 ask_class_article YHL 2013-07-01

                EbSite.Modules.BmAsk.ModuleCore.Entity.class_article classArticlemodel = new EbSite.Modules.BmAsk.ModuleCore.Entity.class_article();

                classArticlemodel.ClassName = className;
                classArticlemodel.NewsTitle = txtTitle;
                //classArticlemodel.ContentInfo = txtContent;
                classArticlemodel.UserID = userid;
                classArticlemodel.AddTime = dt;
                classArticlemodel.Classid = classid;
                classArticlemodel.Annex14 = EbSite.Core.Utils.StrToInt(annex14);
                classArticlemodel.AskId = askid;
                classArticlemodel.AskAddTime = dt;
                classArticlemodel.RandNum = GetRandNum();

                DataMySql.Instance.class_article_Add(classArticlemodel);

                #endregion 添加到 ask_class_article YHL 2013-07-01
                
            }
        }

        private static int GetRandNum()
        {
            int min = 1;
            int max = 100;
            Random a = new Random();
            int result = a.Next(min, max);
            return result;
        }


        /// <summary>
        /// 获取随机ID
        /// </summary>
        /// <param name="rom">随机对象</param>
        /// <param name="arrIDs">已经随机过的ID集合</param>
        /// <returns></returns>
        private int GetRandID(Random rom, ArrayList arrIDs)
        {
            int i = rom.Next(22);
            if (arrIDs == null || arrIDs.Count == 0)
            {
                return i;
            }
            if (arrIDs.Contains(i))
            {
                return GetRandID(rom, arrIDs);
            }
            else
            {
                return i;
            }
        }
        /// <summary>
        /// 获取随机用户ID
        /// </summary>
        /// <param name="uIndex">随机索引</param>
        /// <returns></returns>
        private string GetRandUserID(int uIndex)
        {
            string strIDs = "148,142,359,356,576,143,139,577,358,360,357,355,353,352,351,121,21,349,348,369,63,22";
            string[] strUArr = strIDs.Split(',');
            if (uIndex > 22 || uIndex < 0)
            {
                uIndex = 0;
            }
            return strUArr[uIndex];
        }
        public int RandUserID(int[] arryuid,out string niname,out string rename)
        {
            int?[] arriTemp = new int?[0];
            niname = "";
            rename = "";
            arriTemp = new int?[arryuid.Length];
            for (int i = 0; i < arryuid.Length; i++)
            {
                arriTemp[i] = arryuid[i];
            }
            List<PostUser> ls = PostUserControl.Instance.FillList();
            PostUser x = (from q in ls where !arriTemp.Contains(q.UserID) orderby Guid.NewGuid() select q).Take(1).ToList()[0];

            //bool isExist = EbSite.Base.Host.Instance.ExistsUserUserID(x.UserID);
            //if (isExist)
            //{
            niname = x.UserNiName;
            rename = x.UserName;
                return x.UserID;
           // }
           // else
            //{
                //return RandUserID(arryuid);
           // }
        }

        private string Ips = "";
        public string RandIp(string[] arryip)
        {
            string[] arriTemp = new string[] { };

            arriTemp = new string[arryip.Length];
            for (int i = 0; i < arryip.Length; i++)
            {
                arriTemp[i] = arryip[i];
            }

            string[] arryips = Ips.Split(',');
            var s = (from i in arryips where !arriTemp.Contains(i) orderby Guid.NewGuid() select i).Take(1).ToList()[0];
            return s.ToString();

        }
        /// <summary>
        ///  回复问题 ，同时给回复用户 添加 回答记录总数
        /// </summary>
        /// <param name="tag"> 问题ID</param>
        /// <param name="askuid">提问者ID</param>
        /// <param name="answeruserid">回答者ID</param>
        /// <param name="txtHf">回复内容</param>
        /// <param name="minute">时间间隔</param>
        /// <param name="ips">ip 地址</param>
        public void AddHfAnwser(int tag, int askuid, int answeruserid, string txtHf, int minute, string ips)
        {
            Answers answers = new Answers();
            answers.QID = tag;//问题ID
            answers.QUserID = askuid; //int.Parse(AskUID);
            answers.AnswerUserID = answeruserid;// int.Parse(UID);//回答用户ID
            answers.AnswerContent = txtHf;
            answers.IsAdoption = false;
            answers.AnswerTime = DateTime.Now.AddMinutes(-minute);//第一个回复 -6分
            answers.IsDel = false;
            answers.AnswerIP = ips;
            answers.ReferBook = "";
            answers.IsAnonymity = false;
            answers.AnswerUpdateTime = DateTime.Now.AddMinutes(-minute);//回答者修改时间
            answers.Score = 0;//本次得分
            answers.GoodAsk = 0;
            answers.IsApproved = 1;//审核 1：通过 0：不通过
            int i =DataMySql.Instance.Answers_Add(answers);

            //if (i > 0)
            //{
            //    //给 问题 的Annex11  加1 回答问题的总个数
            //    NewsContent mdnewcontent =DataMySql.Instance.NewsContent_GetModel(tag);
            //    mdnewcontent.Annex11 = mdnewcontent.Annex11 + 1;
            //    mdnewcontent.ID = tag;


            //    DataMySql.Instance.NewsContent_Update(mdnewcontent);

            //}

            //出使化 userhelp
            List<UserHelp> md = DataMySql.Instance.UserHelp_GetListArray(0,"userid=" + answeruserid,"");

            if (md==null||md.Count == 0)
            {
                UserHelp model = new UserHelp();
                model.UserID = answeruserid;
                model.QCount = 0;//提问总数
                model.ACount = 1;//回答总数
                model.AdoptionCount = 0;//采纳总数
                model.LikeAskClass = "";//推荐类型
                model.TotalScore = 0;
                DataMySql.Instance.UserHelp_Add(model);
            }
            else
            {
                UserHelp model = md[0];
                model.UserID = answeruserid;
                model.ACount = model.ACount + 1; //回答总数
                DataMySql.Instance.UserHelp_Update(model);
            }
        }
    }

    #region Entity
    public class NewsContent
    {
        public NewsContent()
        { }

        #region Model

        private string _smallpic = "";
        private string _newstitle;
        private string _titlestyle;
        private int _classid;
        private int _hits = 0;
        private bool _isgood = false;
        private string _contentinfo;
        private int _dayhits = 0;
        private int _weekhits = 0;
        private int _monthhits = 0;
        private DateTime _lasthitstime = DateTime.Now;
        private string _tagids;
        //private int _userid;
        private int _orderid = 0;
        private string _htmlname;
        private Guid _contenttemid;
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

        private string _ClassName;
        private int _commentnum;
        private int _favorablenum;
        private string _userniname;
        private int _userid;
        private int _siteid;
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

        private bool _IsAuditing;
        public bool IsAuditing
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
        public bool IsGood
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
        public DateTime lasthitstime
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
        /// <summary>
        /// 
        /// </summary>
        public Guid ContentTemID
        {
            set { _contenttemid = value; }
            get { return _contenttemid; }
        }
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


        private int _id = 0;
        /// <summary>
        /// ID
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }





    }


    public class Answers
    {

        #region Model
        private int _qid;
        private int _quserid;
        private int _answeruserid;
        private string _answercontent;
        private bool _isadoption;
        private DateTime? _answertime;
        private bool _isdel;
        private string _answerip;
        private string _referbook;
        private bool _isanonymity;
        private DateTime? _answerupdatetime;
        private int? _score;
        private int? _goodask;
        private int? _isapproved;
        private string _thanksinfo;
        /// <summary>
        /// 对人有帮助的总个数
        /// </summary>
        public int? GoodAsk
        {
            set { _goodask = value; }
            get { return _goodask; }
        }
        /// <summary>
        /// 问题ID
        /// </summary>
        public int QID
        {
            set { _qid = value; }
            get { return _qid; }
        }
        /// <summary>
        /// 提问用户ID
        /// </summary>
        public int QUserID
        {
            set { _quserid = value; }
            get { return _quserid; }
        }
        /// <summary>
        /// 回答用户ID
        /// </summary>
        public int AnswerUserID
        {
            set { _answeruserid = value; }
            get { return _answeruserid; }
        }
        /// <summary>
        /// 回答内容
        /// </summary>
        public string AnswerContent
        {
            set { _answercontent = value; }
            get { return _answercontent; }
        }
        /// <summary>
        /// 是否被采纳 1:采纳 0: 没有
        /// </summary>
        public bool IsAdoption
        {
            set { _isadoption = value; }
            get { return _isadoption; }
        }
        /// <summary>
        /// 回复时间
        /// </summary>
        public DateTime? AnswerTime
        {
            set { _answertime = value; }
            get { return _answertime; }
        }
        /// <summary>
        /// 是否被删除 1:删除 0:没有
        /// </summary>
        public bool IsDel
        {
            set { _isdel = value; }
            get { return _isdel; }
        }
        /// <summary>
        /// 回复者IP
        /// </summary>
        public string AnswerIP
        {
            set { _answerip = value; }
            get { return _answerip; }
        }
        /// <summary>
        /// 参考资料
        /// </summary>
        public string ReferBook
        {
            set { _referbook = value; }
            get { return _referbook; }
        }
        /// <summary>
        /// 是否匿名 1:匿名 0: 不匿名.
        /// </summary>
        public bool IsAnonymity
        {
            set { _isanonymity = value; }
            get { return _isanonymity; }
        }
        /// <summary>
        /// 回答者修改时间
        /// </summary>
        public DateTime? AnswerUpdateTime
        {
            set { _answerupdatetime = value; }
            get { return _answerupdatetime; }
        }
        /// <summary>
        /// 本次得分
        /// </summary>
        public int? Score
        {
            set { _score = value; }
            get { return _score; }
        }
        /// <summary>
        /// 审核 1：通过 0：拒绝
        /// </summary>
        public int? IsApproved
        {
            set { _isapproved = value; }
            get { return _isapproved; }
        }
        /// <summary>
        /// 感言
        /// </summary>
        public string ThanksInfo
        {
            get { return _thanksinfo; }
            set { _thanksinfo = value; }
        }
        #endregion Model

    }

    public class UserHelp
    {

        #region Model

        private int _id;
        private int _userid;
        private int _qcount;
        private int _acount;
        private int _adoptioncount;
        private string _likeaskclass;
        private long _TotalScore;

        /// <summary>
        /// 
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int UserID
        {
            set { _userid = value; }
            get { return _userid; }
        }
        /// <summary>
        /// 提问总数
        /// </summary>
        public int QCount
        {
            set { _qcount = value; }
            get { return _qcount; }
        }
        /// <summary>
        /// 回答总数
        /// </summary>
        public int ACount
        {
            set { _acount = value; }
            get { return _acount; }
        }
        /// <summary>
        /// 采纳总数
        /// </summary>
        public int AdoptionCount
        {
            set { _adoptioncount = value; }
            get { return _adoptioncount; }
        }


        /// <summary>
        /// 喜欢回答的类型,可以做为推荐用
        /// </summary>
        public string LikeAskClass
        {
            set { _likeaskclass = value; }
            get { return _likeaskclass; }
        }
        public long TotalScore
        {
            set { _TotalScore = value; }
            get { return _TotalScore; }
        }
        #endregion Model

    }

    public class PostUser : XmlEntityBase<int>
    {
        private int _userid;
        /// <summary>
        /// 用户id
        /// </summary>
        public int UserID
        {
            get { return _userid; }
            set { _userid = value; }
        }
        private string _username;
        /// <summary>
        /// 用户名称
        /// </summary>
        public string UserName
        {
            get { return _username; }
            set { _username = value; }
        }
        private string _userniname;
        /// <summary>
        /// 用户昵称
        /// </summary>
        public string UserNiName
        {
            get { return _userniname; }
            set { _userniname = value; }
        }



    }
    #endregion

    #region Data

    public class PostUserControl : EbSite.Base.Datastore.XMLProviderBaseInt<PostUser>
    {
        public static readonly PostUserControl Instance = new PostUserControl();
        /// <summary>
        /// 重写数据的保存路径-绝对
        /// </summary>
        public override string SavePath
        {
            get
            {
                //string mpath = EbSite.Base.Host.Instance.GetModulePath(new Guid("4e0edb7e-1b30-41ad-9f74-d63c80458c35"));

                //if (!Equals(HttpContext.Current, null))
                //{
                //    return HttpContext.Current.Server.MapPath("~/" + mpath + "/DataStore/PostUser/");
                //}
                string currentPath=AppDomain.CurrentDomain.BaseDirectory+"DataStore\\PostUser\\";
                return currentPath;
            }
        }
        private PostUserControl()
        {
            if (!FObject.IsExist(SavePath, FsoMethod.Folder))
            {
                FObject.Create(SavePath, FsoMethod.Folder);
            }
        }




    }
    public class DataMySql
    {
        public static readonly DataMySql Instance = new DataMySql();
        private DataMySql()
        {
            
        }
        #region NewsContent

        DB db = new DB();

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int class_article_Add(EbSite.Modules.BmAsk.ModuleCore.Entity.class_article model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into ask_class_article(");
            strSql.Append("classname,newstitle,userid,contentinfo,htmlname,addtime,classid,annex14,askid,askaddtime,randnum)");
            strSql.Append(" values (");
            strSql.Append("?classname,?newstitle,?userid,?contentinfo,?htmlname,?addtime,?classid,?annex14,?askid,?askaddtime,?randnum)");
            strSql.Append(";SELECT @@session.identity");
            MySqlParameter[] parameters = {
					new MySqlParameter("?classname", MySqlDbType.VarChar,200),
					new MySqlParameter("?newstitle", MySqlDbType.VarChar,500),
					new MySqlParameter("?userid", MySqlDbType.Int32,11),
					new MySqlParameter("?contentinfo", MySqlDbType.Text),
					new MySqlParameter("?htmlname", MySqlDbType.VarChar,200),
					new MySqlParameter("?addtime", MySqlDbType.DateTime),
					new MySqlParameter("?classid", MySqlDbType.Int32,11),
					new MySqlParameter("?annex14", MySqlDbType.Int32,11),
					new MySqlParameter("?askid", MySqlDbType.Int64,20),
					new MySqlParameter("?askaddtime", MySqlDbType.DateTime),
                    new MySqlParameter("?randnum", MySqlDbType.Int32,11)
                                          };
            parameters[0].Value = model.ClassName;
            parameters[1].Value = model.NewsTitle;
            parameters[2].Value = model.UserID;
            parameters[3].Value = "";// model.ContentInfo;
            parameters[4].Value = "";
            parameters[5].Value = model.AddTime;
            parameters[6].Value = model.Classid;
            parameters[7].Value = model.Annex14;
            parameters[8].Value = model.AskId;
            parameters[9].Value = model.AskAddTime;
            parameters[10].Value = model.RandNum;

            object obj = db.ExecuteScalar(strSql.ToString(),parameters);
            if (obj == null)
            {
                return 1;
            }
            return Convert.ToInt32(obj);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void NewsContent_Update(NewsContent model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("update {0}NewsContent set ", "eb_");
            //strSql.Append("SmallPic=?SmallPic,");
            //strSql.Append("NewsTitle=?NewsTitle,");
            //strSql.Append("TitleStyle=?TitleStyle,");
            //strSql.Append("ClassID=?ClassID,");
            //strSql.Append("hits=?hits,");
            //strSql.Append("IsGood=?IsGood,");
            //strSql.Append("ContentInfo=?ContentInfo,");
            //strSql.Append("dayHits=?dayHits,");
            //strSql.Append("weekHits=?weekHits,");
            //strSql.Append("monthhits=?monthhits,");
            //strSql.Append("lasthitstime=?lasthitstime,");
            //strSql.Append("TagIDs=?TagIDs,");
            //strSql.Append("OrderID=?OrderID,");
            //strSql.Append("HtmlName=?HtmlName,");
            //strSql.Append("ContentHtmlNameRule=?ContentHtmlNameRule,");
            //strSql.Append("MarkIsMakeHtml=?MarkIsMakeHtml,");
            //strSql.Append("IsComment=?IsComment,");
            //strSql.Append("AddTime=?AddTime,");
            //strSql.Append("IsAuditing=?IsAuditing,");
            //strSql.Append("Annex1=?Annex1,");
            //strSql.Append("Annex2=?Annex2,");
            //strSql.Append("Annex3=?Annex3,");
            //strSql.Append("Annex4=?Annex4,");
            //strSql.Append("Annex5=?Annex5,");
            //strSql.Append("Annex6=?Annex6,");
            //strSql.Append("Annex7=?Annex7,");
            //strSql.Append("Annex8=?Annex8,");
            //strSql.Append("Annex9=?Annex9,");
            //strSql.Append("Annex10=?Annex10,");

            strSql.Append("Annex11=?Annex11");
            //strSql.Append("Annex12=?Annex12,");
            //strSql.Append("Annex13=?Annex13,");
            //strSql.Append("Annex14=?Annex14,");
            //strSql.Append("Annex15=?Annex15,");
            //strSql.Append("Annex16=?Annex16,");
            //strSql.Append("Annex17=?Annex17,");
            //strSql.Append("Annex18=?Annex18,");

            //strSql.Append("ContentTemID=?ContentTemID,");
            //strSql.Append("Advs=?Advs,");
            //strSql.Append("ClassName=?ClassName,");
            //strSql.Append("CommentNum=?CommentNum,");
            //strSql.Append("FavorableNum=?FavorableNum,");
            //strSql.Append("UserID=?UserID,");
            //strSql.Append("UserNiName=?UserNiName,");
            //strSql.Append("UserName=?UserName,");
            //strSql.Append("SiteID=?SiteID");
            strSql.Append(" where ID=?ID ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?ID",  MySqlDbType.Int32,4),
                    //new MySqlParameter("?SmallPic", MySqlDbType.VarChar,255),
                    //new MySqlParameter("?NewsTitle", MySqlDbType.VarChar,150),
                    //new MySqlParameter("?TitleStyle", MySqlDbType.VarChar,100),
                    //new MySqlParameter("?ClassID",  MySqlDbType.Int32,4),
                    //new MySqlParameter("?hits",  MySqlDbType.Int32,4),
                    //new MySqlParameter("?IsGood", MySqlDbType.Int16,1),
                    //new MySqlParameter("?ContentInfo", MySqlDbType.VarChar),
                    //new MySqlParameter("?dayHits",  MySqlDbType.Int32,4),
                    //new MySqlParameter("?weekHits",  MySqlDbType.Int32,4),
                    //new MySqlParameter("?monthhits",  MySqlDbType.Int32,4),
                    //new MySqlParameter("?lasthitstime", MySqlDbType.DateTime),
                    //new MySqlParameter("?TagIDs", MySqlDbType.VarChar,255),
                    //new MySqlParameter("?OrderID",  MySqlDbType.Int32,4),
                    //new MySqlParameter("?HtmlName", MySqlDbType.VarChar,300),
                    //new MySqlParameter("?ContentHtmlNameRule", MySqlDbType.VarChar,300),
                    //new MySqlParameter("?MarkIsMakeHtml", MySqlDbType.Int16,1),
                    //new MySqlParameter("?IsComment", MySqlDbType.Int16,1),
                    //new MySqlParameter("?AddTime", MySqlDbType.DateTime),
                    //new MySqlParameter("?IsAuditing", MySqlDbType.Int16,1),
                    //new MySqlParameter("?Annex1", MySqlDbType.VarChar,100),
                    //new MySqlParameter("?Annex2", MySqlDbType.VarChar,200),
                    //new MySqlParameter("?Annex3", MySqlDbType.VarChar,300),
                    //new MySqlParameter("?Annex4", MySqlDbType.VarChar,400),
                    //new MySqlParameter("?Annex5", MySqlDbType.VarChar,500),
                    //new MySqlParameter("?Annex6", MySqlDbType.VarChar,600),
                    //new MySqlParameter("?Annex7", MySqlDbType.VarChar,700),
                    //new MySqlParameter("?Annex8", MySqlDbType.VarChar,800),
                    //new MySqlParameter("?Annex9", MySqlDbType.VarChar,900),
                    //new MySqlParameter("?Annex10", MySqlDbType.VarChar,1000),

                    
                    new MySqlParameter("?Annex11",   MySqlDbType.Int32,4)
                                          };
                    //new MySqlParameter("?Annex12",   MySqlDbType.Int32,4),
                    //new MySqlParameter("?Annex13",   MySqlDbType.Int32,4),
                    //new MySqlParameter("?Annex14",   MySqlDbType.Int32,4),
                    //new MySqlParameter("?Annex15",   MySqlDbType.Int32,4),
                    //new MySqlParameter("?Annex16", MySqlDbType.Decimal,9),
                    //new MySqlParameter("?Annex17", MySqlDbType.Decimal,9),
                    //new MySqlParameter("?Annex18", MySqlDbType.Decimal,9),


                    //new MySqlParameter("?ContentTemID", MySqlDbType.VarChar,36),
                    //new MySqlParameter("?Advs",  MySqlDbType.Int32,4),
                    //new MySqlParameter("?ClassName", MySqlDbType.VarChar,50),
                    //new MySqlParameter("?CommentNum",  MySqlDbType.Int32,4),
                    //new MySqlParameter("?FavorableNum",  MySqlDbType.Int32,4),
                    //new MySqlParameter("?UserID",  MySqlDbType.Int32,4),
                    //new MySqlParameter("?UserNiName", MySqlDbType.VarChar,50),
                    //new MySqlParameter("?UserName", MySqlDbType.VarChar,100),
                    //new MySqlParameter("?SiteID", MySqlDbType.Int32,4) };
            parameters[0].Value = model.ID;
            //parameters[1].Value = model.SmallPic;
            //parameters[2].Value = model.NewsTitle;
            //parameters[3].Value = model.TitleStyle;
            //parameters[4].Value = model.ClassID;
            //parameters[5].Value = model.hits;
            //parameters[6].Value = model.IsGood;
            //parameters[7].Value = model.ContentInfo;
            //parameters[8].Value = model.dayHits;
            //parameters[9].Value = model.weekHits;
            //parameters[10].Value = model.monthhits;
            //parameters[11].Value = model.lasthitstime;
            //parameters[12].Value = model.TagIDs;
            //parameters[13].Value = model.OrderID;
            //parameters[14].Value = model.HtmlName;
            //parameters[15].Value = model.ContentHtmlNameRule;
            //parameters[16].Value = model.MarkIsMakeHtml;
            //parameters[17].Value = model.IsComment;
            //parameters[18].Value = model.AddTime;
            //parameters[19].Value = model.IsAuditing;
            //parameters[20].Value = model.Annex1;
            //parameters[21].Value = model.Annex2;
            //parameters[22].Value = model.Annex3;
            //parameters[23].Value = model.Annex4;
            //parameters[24].Value = model.Annex5;
            //parameters[25].Value = model.Annex6;
            //parameters[26].Value = model.Annex7;
            //parameters[27].Value = model.Annex8;
            //parameters[28].Value = model.Annex9;
            //parameters[29].Value = model.Annex10;

            parameters[1].Value = model.Annex11;
            //parameters[31].Value = model.Annex12;
            //parameters[32].Value = model.Annex13;
            //parameters[33].Value = model.Annex14;
            //parameters[34].Value = model.Annex15;
            //parameters[35].Value = model.Annex16;
            //parameters[36].Value = model.Annex17;
            //parameters[37].Value = model.Annex18;

            //parameters[38].Value = model.ContentTemID;
            //parameters[39].Value = model.Advs;
            //parameters[40].Value = model.ClassName;
            //parameters[41].Value = model.CommentNum;
            //parameters[42].Value = model.FavorableNum;
            //parameters[43].Value = model.UserID;
            //parameters[44].Value = model.UserNiName;
            //parameters[45].Value = model.UserName;
            //parameters[46].Value = model.SiteID;


            db.ExecuteNonQuery(strSql.ToString(), parameters);
        }

        public NewsContent NewsContent_GetModel(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  ID,SmallPic,NewsTitle,TitleStyle,ClassID,hits,IsGood,ContentInfo,dayHits,weekHits,monthhits,lasthitstime,TagIDs,OrderID,HtmlName,ContentHtmlNameRule,MarkIsMakeHtml,IsComment,AddTime,IsAuditing,Annex1,Annex2,Annex3,Annex4,Annex5,Annex6,Annex7,Annex8,Annex9,Annex10,Annex11,Annex12,Annex13,Annex14,Annex15,Annex16,Annex17,Annex18,ContentTemID,Advs,ClassName,CommentNum,FavorableNum,UserID,UserNiName,UserName,SiteID ");
            strSql.AppendFormat(" from  {0}NewsContent ", "eb_");
            strSql.Append(" where ID=?ID limit 1 ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?ID",  MySqlDbType.Int32,4)};
            parameters[0].Value = ID;

            NewsContent model = new NewsContent();


            using (IDataReader dataReader =db.ExecuteReader(strSql.ToString(), parameters))
            {
                if (dataReader.Read())
                {
                    model = NewsContent_ReaderBind(dataReader);
                }
            }
            return model;

        }
        public NewsContent NewsContent_ReaderBind(IDataReader dataReader)
        {
            NewsContent model = new NewsContent();

            for (int i = 0; i < dataReader.FieldCount; i++)
            {
                string sCName = dataReader.GetName(i).ToLower();

                if (Equals(sCName, "id"))
                {
                    if (dataReader["ID"].ToString() != "")
                    {
                        model.ID = int.Parse(dataReader["ID"].ToString());
                    }
                }
                if (Equals(sCName, "classname"))
                {
                    model.ClassName = dataReader["ClassName"].ToString();
                }

                if (Equals(sCName, "smallpic"))
                {
                    model.SmallPic = dataReader["SmallPic"].ToString();
                }
                if (Equals(sCName, "newstitle"))
                {
                    model.NewsTitle = dataReader["NewsTitle"].ToString();
                }
                if (Equals(sCName, "tagids"))
                {
                    model.TagIDs = dataReader["TagIDs"].ToString();
                }
                if (Equals(sCName, "titlestyle"))
                {
                    model.TitleStyle = dataReader["TitleStyle"].ToString();
                }

                if (Equals(sCName, "classid") && dataReader["ClassID"].ToString() != "")
                {
                    model.ClassID = int.Parse(dataReader["ClassID"].ToString());
                }
                if (Equals(sCName, "hits") && dataReader["hits"].ToString() != "")
                {
                    model.hits = int.Parse(dataReader["hits"].ToString());
                }
                if (Equals(sCName, "isgood") && dataReader["IsGood"].ToString() != "")
                {
                    if ((dataReader["IsGood"].ToString() == "1") || (dataReader["IsGood"].ToString().ToLower() == "true"))
                    {
                        model.IsGood = true;
                    }
                    else
                    {
                        model.IsGood = false;
                    }
                }
                if (Equals(sCName, "contentinfo"))
                {
                    model.ContentInfo = dataReader["ContentInfo"].ToString();
                }

                if (Equals(sCName, "dayhits") && dataReader["dayHits"].ToString() != "")
                {
                    model.dayHits = int.Parse(dataReader["dayHits"].ToString());
                }
                if (Equals(sCName, "weekhits") && dataReader["weekHits"].ToString() != "")
                {
                    model.weekHits = int.Parse(dataReader["weekHits"].ToString());
                }
                if (Equals(sCName, "monthhits") && dataReader["monthhits"].ToString() != "")
                {
                    model.monthhits = int.Parse(dataReader["monthhits"].ToString());
                }
                if (Equals(sCName, "lasthitstime") && dataReader["lasthitstime"].ToString() != "")
                {
                    model.lasthitstime = DateTime.Parse(dataReader["lasthitstime"].ToString());
                }
                if (Equals(sCName, "lasthitstime"))
                {
                    model.lasthitstime = DateTime.Parse(dataReader["lasthitstime"].ToString());
                }

                if (Equals(sCName, "orderid") && dataReader["OrderID"].ToString() != "")
                {
                    model.OrderID = int.Parse(dataReader["OrderID"].ToString());
                }
                if (Equals(sCName, "htmlname"))
                {
                    model.HtmlName = dataReader["HtmlName"].ToString();
                }
                if (Equals(sCName, "contenthtmlnamerule"))
                {
                    model.ContentHtmlNameRule = dataReader["ContentHtmlNameRule"].ToString();
                }

                if (Equals(sCName, "markismakehtml") && dataReader["MarkIsMakeHtml"].ToString() != "")
                {
                    if ((dataReader["MarkIsMakeHtml"].ToString() == "1") || (dataReader["MarkIsMakeHtml"].ToString().ToLower() == "true"))
                    {
                        model.MarkIsMakeHtml = true;
                    }
                    else
                    {
                        model.MarkIsMakeHtml = false;
                    }
                }
                if (Equals(sCName, "iscomment") && dataReader["IsComment"].ToString() != "")
                {
                    if ((dataReader["IsComment"].ToString() == "1") || (dataReader["IsComment"].ToString().ToLower() == "true"))
                    {
                        model.IsComment = true;
                    }
                    else
                    {
                        model.IsComment = false;
                    }
                }
                if (Equals(sCName, "addtime") && dataReader["AddTime"].ToString() != "")
                {
                    model.AddTime = DateTime.Parse(dataReader["AddTime"].ToString());
                }
                if (Equals(sCName, "isauditing") && dataReader["IsAuditing"].ToString() != "")
                {
                    if ((dataReader["IsAuditing"].ToString() == "1") || (dataReader["IsAuditing"].ToString().ToLower() == "true"))
                    {
                        model.IsAuditing = true;
                    }
                    else
                    {
                        model.IsAuditing = false;
                    }
                }
                if (Equals(sCName, "annex1"))
                {
                    model.Annex1 = dataReader["Annex1"].ToString();
                }
                if (Equals(sCName, "annex2"))
                {
                    model.Annex2 = dataReader["Annex2"].ToString();
                }
                if (Equals(sCName, "annex3"))
                {
                    model.Annex3 = dataReader["Annex3"].ToString();
                }
                if (Equals(sCName, "annex4"))
                {
                    model.Annex4 = dataReader["Annex4"].ToString();
                }
                if (Equals(sCName, "annex5"))
                {
                    model.Annex5 = dataReader["Annex5"].ToString();
                }
                if (Equals(sCName, "annex6"))
                {
                    model.Annex6 = dataReader["Annex6"].ToString();
                }
                if (Equals(sCName, "annex7"))
                {
                    model.Annex7 = dataReader["Annex7"].ToString();
                }
                if (Equals(sCName, "annex8"))
                {
                    model.Annex8 = dataReader["Annex8"].ToString();
                }
                if (Equals(sCName, "annex9"))
                {
                    model.Annex9 = dataReader["Annex9"].ToString();
                }
                if (Equals(sCName, "annex10"))
                {
                    model.Annex10 = dataReader["Annex10"].ToString();
                }


                if (Equals(sCName, "annex11"))
                {
                    model.Annex11 =EbSite.Core.Utils.StrToInt(dataReader["Annex11"].ToString(), 0);
                }
                if (Equals(sCName, "annex12"))
                {
                    model.Annex12 = EbSite.Core.Utils.StrToInt(dataReader["Annex12"].ToString(), 0);
                }
                if (Equals(sCName, "annex13"))
                {
                    model.Annex13 = EbSite.Core.Utils.StrToInt(dataReader["Annex13"].ToString(), 0);
                }
                if (Equals(sCName, "annex14"))
                {
                    model.Annex14 = EbSite.Core.Utils.StrToInt(dataReader["Annex14"].ToString(), 0);
                }
                if (Equals(sCName, "annex15"))
                {
                    model.Annex15 = EbSite.Core.Utils.StrToInt(dataReader["Annex15"].ToString(), 0);
                }
                if (Equals(sCName, "annex16"))
                {
                    if (!string.IsNullOrEmpty(dataReader["Annex16"].ToString()))
                        model.Annex16 = decimal.Parse(dataReader["Annex16"].ToString());
                }
                if (Equals(sCName, "annex17"))
                {
                    if (!string.IsNullOrEmpty(dataReader["Annex17"].ToString()))
                        model.Annex17 = decimal.Parse(dataReader["Annex17"].ToString());
                }
                if (Equals(sCName, "annex18"))
                {
                    if (!string.IsNullOrEmpty(dataReader["Annex17"].ToString()))
                        model.Annex18 = decimal.Parse(dataReader["Annex18"].ToString());
                }

                if (Equals(sCName, "contenttemid") && dataReader["ContentTemID"].ToString() != "")
                {
                    model.ContentTemID = new Guid(dataReader["ContentTemID"].ToString());
                }
                if (Equals(sCName, "advs") && dataReader["Advs"].ToString() != "")
                {
                    model.Advs = int.Parse(dataReader["Advs"].ToString());
                }
                if (Equals(sCName, "classname"))
                {
                    model.ClassName = dataReader["ClassName"].ToString();
                }

                if (Equals(sCName, "commentnum") && dataReader["CommentNum"].ToString() != "")
                {
                    model.CommentNum = int.Parse(dataReader["CommentNum"].ToString());
                }
                if (Equals(sCName, "favorablenum") && dataReader["FavorableNum"].ToString() != "")
                {
                    model.FavorableNum = int.Parse(dataReader["FavorableNum"].ToString());
                }
                if (Equals(sCName, "userid") && dataReader["UserID"].ToString() != "")
                {
                    model.UserID = int.Parse(dataReader["UserID"].ToString());
                }
                if (Equals(sCName, "userniname"))
                {
                    model.UserNiName = dataReader["UserNiName"].ToString();
                }
                if (Equals(sCName, "username"))
                {
                    model.UserName = dataReader["UserName"].ToString();
                }
                if (Equals(sCName, "siteid") && dataReader["SiteID"].ToString() != "")
                {
                    model.SiteID = int.Parse(dataReader["SiteID"].ToString());
                }

            }


            return model;
        }
       
        public int NewsContent_Add(NewsContent model)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("insert into {0}NewsContent(", "eb_");
            strSql.Append("SmallPic,NewsTitle,TitleStyle,ClassID,hits,IsGood,ContentInfo,dayHits,weekHits,monthhits,lasthitstime,TagIDs,OrderID,HtmlName,ContentHtmlNameRule,MarkIsMakeHtml,IsComment,AddTime,IsAuditing,Annex1,Annex2,Annex3,Annex4,Annex5,Annex6,Annex7,Annex8,Annex9,Annex10,Annex11,Annex12,Annex13,Annex14,Annex15,Annex16,Annex17,Annex18,ContentTemID,Advs,ClassName,CommentNum,FavorableNum,UserID,UserNiName,UserName,SiteID,annex19,annex20)");
            strSql.Append(" values (");
            strSql.Append("?SmallPic,?NewsTitle,?TitleStyle,?ClassID,?hits,?IsGood,?ContentInfo,?dayHits,?weekHits,?monthhits,?lasthitstime,?TagIDs,?OrderID,?HtmlName,?ContentHtmlNameRule,?MarkIsMakeHtml,?IsComment,?AddTime,?IsAuditing,?Annex1,?Annex2,?Annex3,?Annex4,?Annex5,?Annex6,?Annex7,?Annex8,?Annex9,?Annex10,?Annex11,?Annex12,?Annex13,?Annex14,?Annex15,?Annex16,?Annex17,?Annex18,?ContentTemID,?Advs,?ClassName,?CommentNum,?FavorableNum,?UserID,?UserNiName,?UserName,?SiteID,0,0)");
            strSql.Append(";SELECT @@session.identity");
            MySqlParameter[] parameters = {
					new MySqlParameter("?SmallPic", MySqlDbType.VarChar,255),
					new MySqlParameter("?NewsTitle", MySqlDbType.VarChar,150),
					new MySqlParameter("?TitleStyle", MySqlDbType.VarChar,100),
					new MySqlParameter("?ClassID",  MySqlDbType.Int32,4),
					new MySqlParameter("?hits",  MySqlDbType.Int32,4),
					new MySqlParameter("?IsGood", MySqlDbType.Int16,1),
					new MySqlParameter("?ContentInfo", MySqlDbType.VarChar),
					new MySqlParameter("?dayHits",  MySqlDbType.Int32,4),
					new MySqlParameter("?weekHits",  MySqlDbType.Int32,4),
					new MySqlParameter("?monthhits",  MySqlDbType.Int32,4),
					new MySqlParameter("?lasthitstime", MySqlDbType.DateTime),
					new MySqlParameter("?TagIDs", MySqlDbType.VarChar,255),
					new MySqlParameter("?OrderID",  MySqlDbType.Int32,4),
					new MySqlParameter("?HtmlName", MySqlDbType.VarChar,300),
					new MySqlParameter("?ContentHtmlNameRule", MySqlDbType.VarChar,300),
					new MySqlParameter("?MarkIsMakeHtml", MySqlDbType.Int16,1),
					new MySqlParameter("?IsComment", MySqlDbType.Int16,1),
					new MySqlParameter("?AddTime", MySqlDbType.DateTime),
					new MySqlParameter("?IsAuditing", MySqlDbType.Int16,1),
					new MySqlParameter("?Annex1", MySqlDbType.VarChar,100),
					new MySqlParameter("?Annex2", MySqlDbType.VarChar,200),
					new MySqlParameter("?Annex3", MySqlDbType.VarChar,300),
					new MySqlParameter("?Annex4", MySqlDbType.VarChar,400),
					new MySqlParameter("?Annex5", MySqlDbType.VarChar,500),
					new MySqlParameter("?Annex6", MySqlDbType.VarChar,600),
					new MySqlParameter("?Annex7", MySqlDbType.VarChar,700),
					new MySqlParameter("?Annex8", MySqlDbType.VarChar,800),
					new MySqlParameter("?Annex9", MySqlDbType.VarChar,900),
					new MySqlParameter("?Annex10", MySqlDbType.VarChar,1000),

                    new MySqlParameter("?Annex11",   MySqlDbType.Int32,4),
					new MySqlParameter("?Annex12",   MySqlDbType.Int32,4),
					new MySqlParameter("?Annex13",   MySqlDbType.Int32,4),
					new MySqlParameter("?Annex14",   MySqlDbType.Int32,4),
					new MySqlParameter("?Annex15",   MySqlDbType.Int32,4),
					new MySqlParameter("?Annex16", MySqlDbType.Decimal,9),
					new MySqlParameter("?Annex17",  MySqlDbType.Decimal,9),
					new MySqlParameter("?Annex18",  MySqlDbType.Decimal,9),

					new MySqlParameter("?ContentTemID", MySqlDbType.VarChar,36),
					new MySqlParameter("?Advs",  MySqlDbType.Int32,4),
					new MySqlParameter("?ClassName", MySqlDbType.VarChar,50),
					new MySqlParameter("?CommentNum",  MySqlDbType.Int32,4),
					new MySqlParameter("?FavorableNum",  MySqlDbType.Int32,4),
					new MySqlParameter("?UserID",  MySqlDbType.Int32,4),
					new MySqlParameter("?UserNiName", MySqlDbType.VarChar,50),
					new MySqlParameter("?UserName", MySqlDbType.VarChar,100),
                    new MySqlParameter("?SiteID", MySqlDbType.Int32,4) 
                                          };
            parameters[0].Value = model.SmallPic;
            parameters[1].Value = model.NewsTitle;
            parameters[2].Value = model.TitleStyle;
            parameters[3].Value = model.ClassID;
            parameters[4].Value = model.hits;
            parameters[5].Value = model.IsGood;
            parameters[6].Value = model.ContentInfo;
            parameters[7].Value = model.dayHits;
            parameters[8].Value = model.weekHits;
            parameters[9].Value = model.monthhits;
            parameters[10].Value = model.lasthitstime;
            parameters[11].Value = model.TagIDs;
            parameters[12].Value = model.OrderID;
            parameters[13].Value = model.HtmlName;
            parameters[14].Value = model.ContentHtmlNameRule;
            parameters[15].Value = model.MarkIsMakeHtml;
            parameters[16].Value = model.IsComment;
            parameters[17].Value = model.AddTime;
            parameters[18].Value = model.IsAuditing;
            parameters[19].Value = model.Annex1;
            parameters[20].Value = model.Annex2;
            parameters[21].Value = model.Annex3;
            parameters[22].Value = model.Annex4;
            parameters[23].Value = model.Annex5;
            parameters[24].Value = model.Annex6;
            parameters[25].Value = model.Annex7;
            parameters[26].Value = model.Annex8;
            parameters[27].Value = model.Annex9;
            parameters[28].Value = model.Annex10;

            parameters[29].Value = model.Annex11;
            parameters[30].Value = model.Annex12;
            parameters[31].Value = model.Annex13;
            parameters[32].Value = model.Annex14;
            parameters[33].Value = model.Annex15;
            parameters[34].Value = model.Annex16;
            parameters[35].Value = model.Annex17;
            parameters[36].Value = model.Annex18;

            parameters[37].Value = model.ContentTemID;
            parameters[38].Value = model.Advs;
            parameters[39].Value = model.ClassName;
            parameters[40].Value = model.CommentNum;
            parameters[41].Value = model.FavorableNum;
            parameters[42].Value = model.UserID;
            parameters[43].Value = model.UserNiName;
            parameters[44].Value = model.UserName;
            parameters[45].Value = model.SiteID;

            object obj = db.ExecuteScalar(strSql.ToString(), parameters);
            if (obj == null)
            {
                return 1;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        #endregion

        #region Answers
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Answers_Add(Answers model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("insert into {0}Answers(", "ask_");
            strSql.Append("QID,QUserID,AnswerUserID,AnswerContent,IsAdoption,AnswerTime,IsDel,AnswerIP,ReferBook,IsAnonymity,AnswerUpdateTime,Score,GoodAsk,IsApproved,ThanksInfo)");
            strSql.Append(" values (");
            strSql.Append("?QID,?QUserID,?AnswerUserID,?AnswerContent,?IsAdoption,?AnswerTime,?IsDel,?AnswerIP,?ReferBook,?IsAnonymity,?AnswerUpdateTime,?Score,?GoodAsk,?IsApproved,?ThanksInfo)");
            strSql.Append(";SELECT @@session.identity");
            MySqlParameter[] parameters = {
					
					new MySqlParameter("?QID", MySqlDbType.Int32,4),
					new MySqlParameter("?QUserID", MySqlDbType.Int32,4),
					new MySqlParameter("?AnswerUserID", MySqlDbType.Int32,4),
					new MySqlParameter("?AnswerContent", MySqlDbType.Text),
					new MySqlParameter("?IsAdoption", MySqlDbType.Bit,1),
					new MySqlParameter("?AnswerTime", MySqlDbType.DateTime),
					new MySqlParameter("?IsDel", MySqlDbType.Bit,1),
					new MySqlParameter("?AnswerIP", MySqlDbType.VarChar,100),
					new MySqlParameter("?ReferBook", MySqlDbType.VarChar,1000),
					new MySqlParameter("?IsAnonymity", MySqlDbType.Bit,1),
					new MySqlParameter("?AnswerUpdateTime", MySqlDbType.DateTime),
					new MySqlParameter("?Score", MySqlDbType.Int32,4),
                    new MySqlParameter("?GoodAsk",MySqlDbType.UInt32,4),
                    new MySqlParameter("?IsApproved",MySqlDbType.Int32,4),
                    new MySqlParameter("?ThanksInfo",MySqlDbType.Text) };

            parameters[0].Value = model.QID;
            parameters[1].Value = model.QUserID;
            parameters[2].Value = model.AnswerUserID;
            parameters[3].Value = model.AnswerContent;
            parameters[4].Value = model.IsAdoption;
            parameters[5].Value = model.AnswerTime;
            parameters[6].Value = model.IsDel;
            parameters[7].Value = model.AnswerIP;
            parameters[8].Value = model.ReferBook;
            parameters[9].Value = model.IsAnonymity;
            parameters[10].Value = model.AnswerUpdateTime;
            parameters[11].Value = model.Score;
            parameters[12].Value = model.GoodAsk;
            parameters[13].Value = model.IsApproved;
            parameters[14].Value = model.ThanksInfo;

            object obj = db.ExecuteScalar(strSql.ToString(), parameters);
            if (obj == null)
            {
                return 1;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }

        #endregion

        #region UserHelp
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int UserHelp_Add(UserHelp model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("insert into {0}UserHelp(", "ask_");
            strSql.Append("UserID,QCount,ACount,AdoptionCount,LikeAskClass,TotalScore)");
            strSql.Append(" values (");
            strSql.Append("?UserID,?QCount,?ACount,?AdoptionCount,?LikeAskClass,?TotalScore)");
            strSql.Append(";SELECT @@session.identity");
            MySqlParameter[] parameters = {
					new MySqlParameter("?UserID", MySqlDbType.Int32,4),
					new MySqlParameter("?QCount", MySqlDbType.Int32,4),
					new MySqlParameter("?ACount", MySqlDbType.Int32,4),
					new MySqlParameter("?AdoptionCount", MySqlDbType.Int32,4),
					new MySqlParameter("?LikeAskClass", MySqlDbType.VarChar,1000),
					new MySqlParameter("?TotalScore", MySqlDbType.Int64,8)};
            parameters[0].Value = model.UserID;
            parameters[1].Value = model.QCount;
            parameters[2].Value = model.ACount;
            parameters[3].Value = model.AdoptionCount;
            parameters[4].Value = model.LikeAskClass;
            parameters[5].Value = model.TotalScore;

            object obj = db.ExecuteScalar(strSql.ToString(), parameters);
            if (obj == null)
            {
                return 1;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void UserHelp_Update(UserHelp model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("update {0}UserHelp set ", "ask_");
            strSql.Append("UserID=?UserID,");
            strSql.Append("QCount=?QCount,");
            strSql.Append("ACount=?ACount,");
            strSql.Append("AdoptionCount=?AdoptionCount,");
            strSql.Append("LikeAskClass=?LikeAskClass,");
            strSql.Append("TotalScore=?TotalScore");
            strSql.Append(" where id=?id ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32,4),
					new MySqlParameter("?UserID", MySqlDbType.Int32,4),
					new MySqlParameter("?QCount", MySqlDbType.Int32,4),
					new MySqlParameter("?ACount", MySqlDbType.Int32,4),
					new MySqlParameter("?AdoptionCount", MySqlDbType.Int32,4),
					new MySqlParameter("?LikeAskClass", MySqlDbType.VarChar,1000),
					new MySqlParameter("?TotalScore", MySqlDbType.Int64,8)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.UserID;
            parameters[2].Value = model.QCount;
            parameters[3].Value = model.ACount;
            parameters[4].Value = model.AdoptionCount;
            parameters[5].Value = model.LikeAskClass;
            parameters[6].Value = model.TotalScore;

            db.ExecuteNonQuery(strSql.ToString(), parameters);
        }
        private string sFieldUserHelp = "id,UserID,QCount,ACount,AdoptionCount,LikeAskClass,TotalScore";
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public List<UserHelp> UserHelp_GetListArray(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");

            strSql.Append(sFieldUserHelp);
            strSql.AppendFormat(" FROM {0}UserHelp ", "ask_");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            if (filedOrder.Trim() != "")
            {
                strSql.Append(" order by  " + filedOrder);
            }
            if (Top > 0)
            {
                strSql.Append(" limit " + Top.ToString());
            }
            List<UserHelp> list = new List<UserHelp>();
            using (IDataReader dataReader = db.ExecuteReader(strSql.ToString(), null))
            {
                if (dataReader == null)
                {
                    return null;
                }
                while (dataReader.Read())
                {
                    list.Add(UserHelp_ReaderBind(dataReader));
                }
            }
            return list;
        }
        public UserHelp UserHelp_ReaderBind(IDataReader dataReader)
        {
            UserHelp model = new UserHelp();
            object ojb;
            ojb = dataReader["id"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.ID = (int)ojb;
            }
            ojb = dataReader["UserID"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.UserID = (int)ojb;
            }
            ojb = dataReader["QCount"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.QCount = (int)ojb;
            }
            ojb = dataReader["ACount"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.ACount = (int)ojb;
            }
            ojb = dataReader["AdoptionCount"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.AdoptionCount = (int)ojb;
            }
            model.LikeAskClass = dataReader["LikeAskClass"].ToString();
            ojb = dataReader["TotalScore"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.TotalScore = (long)ojb;
            }
            return model;
        }
        #endregion
    }

    public class DB
    {
        private MySqlConnection mySqlConn = new MySqlConnection(ExtenMethod.strConn);

        public int ExecuteNonQuery(string strSql,MySqlParameter[] paramList)
        {
            int result = 0;

            MySqlCommand cmd = new MySqlCommand();
            PrepareCommand(cmd, strSql, paramList);
            result = cmd.ExecuteNonQuery();
            if (mySqlConn.State == ConnectionState.Open)
            {
                mySqlConn.Close();
            }
            return result;
        }

        public object ExecuteScalar(string strSql, MySqlParameter[] paramList)
        {
            object result =null;
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                PrepareCommand(cmd, strSql, paramList);
                result = cmd.ExecuteScalar();
                if (mySqlConn.State == ConnectionState.Open)
                {
                    mySqlConn.Close();
                }
                return result;
            }
            catch
            {
                return null;
            }
        }

        public MySqlDataReader ExecuteReader(string strSql, MySqlParameter[] paramList)
        {
            if (mySqlConn.State != ConnectionState.Open)
            {
                mySqlConn.Open();
            }
            MySqlCommand cmd = new MySqlCommand();
            PrepareCommand(cmd, strSql, paramList);

            MySqlDataReader reader = cmd.ExecuteReader();
            
                return reader;
            
                //if (reader.Read())
                //{
                //    return reader;
                //}
                //else
                //{
                //    return null;
                //}
            
        }

        #region 创建command

        private void PrepareCommand(MySqlCommand cmd,string cmdText, MySqlParameter[] cmdParms)
        {
            if (mySqlConn.State== ConnectionState.Closed)
            {
                mySqlConn.Open();
            }
            cmd.Connection = mySqlConn;
            cmd.CommandText = cmdText;
            cmd.CommandType = CommandType.Text;//cmdType; 
            if (cmdParms != null)
            {
                foreach (MySqlParameter parameter in cmdParms)
                {
                    if ((parameter.Direction == ParameterDirection.InputOutput || parameter.Direction == ParameterDirection.Input) &&(parameter.Value == null))
                    {
                        parameter.Value = DBNull.Value;
                    }
                    cmd.Parameters.Add(parameter);
                }
            }
        }

        #endregion 创建command
    }

    #endregion
}
