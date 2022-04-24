using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EbSite.Modules.Wenda.ModuleCore.Entity
{
 /// <summary>
 /// 问答 配置表 。是否开启审核 用系统的。
 /// </summary>
    public class ConfigInfo
    {
        private int _AnswerNum;
        /// <summary>
        /// 单个问题回答的条数  热门问题判断数(条数) 
        /// </summary>
        public int AnswerNum
        {
            get { return _AnswerNum; }
            set { _AnswerNum = value; }
        }
        private int _CacheDays;
        /// <summary>
        /// 文章内容右侧 缓存的天数
        /// </summary>
        public int CacheDays
        {
            get { return _CacheDays; }
            set { _CacheDays = value; }
        }
      
        private int _AnswerDays;
        /// <summary>
        /// 回答问题的期限时间值
        /// </summary>
        public int AnswerDays
        {
            get { return _AnswerDays; }
            set { _AnswerDays = value; }
        }

        private int _answerscore;
        /// <summary>
        /// 回答一个问题 得相应的分数
        /// </summary>
        public int AnswerScore
        {
            get { return _answerscore; }
            set { _answerscore = value; }
        }

      
        private int _outtimescore;
        /// <summary>
        /// 过期问题 扣除相应的分数
        /// </summary>
        public int OutTimeScore
        {
            get { return _outtimescore; }
            set { _outtimescore = value; }
        }

        private int _askwordcount;
        /// <summary>
        /// 回答问题的最少汉字个数
        /// </summary>
        public int AskWordCount
        {
            set { _askwordcount = value; }
            get { return _askwordcount; }
        }
        private int _favlevel;
        /// <summary>
        /// 收藏级别的 积分
        /// </summary>
        public int FavLevelScore
        {
            set { _favlevel = value; }
            get { return _favlevel; }
        }
        private int _jubaolevel;
        /// <summary>
        /// 举报级别的 积分
        /// </summary>
        public int JuBaoScore
        {
            set { _jubaolevel = value; }
            get { return _jubaolevel; }
        }
        private int _days;
        /// <summary>
        /// 追加悬赏分后，可以延长关闭的天数
        /// </summary>
        public int Days
        {
            set { _days = value; }
            get { return _days; }
        }

        private int _score;
        /// <summary>
        /// 如果您一次追加悬赏 20 分以上（含 20 分）.系统会将问题在所在分类的“待解决问题”列表中显示为最新，类似于新提出的问题。
        /// </summary>
        public int Score
        {
            set { _score = value; }
            get { return _score; }
        }

        private int _nimingscore;
        /// <summary>
        /// 匿名发表 扣除的分数
        /// </summary>
        public int NiMingScore
        {
            get { return _nimingscore; }
            set { _nimingscore = value; }
        }

        private bool _niminganswer;
        /// <summary>
        ///是否 匿名回答问题
        /// </summary>
        public bool NiMingAnswer
        {
            get { return _niminganswer; }
            set { _niminganswer = value; }
        }
        private bool _IsUbb;
        /// <summary>
        ///是否 开启UBB
        /// </summary>
        public bool IsUbb
        {
            get { return _IsUbb; }
            set { _IsUbb = value; }
        }
        private int _txtTimeJg=1;
        /// <summary>
        /// 时间 间隔
        /// </summary>
        public int TimeInterval
        {
            get { return _txtTimeJg; }
            set { _txtTimeJg = value; }
        }


    }
}