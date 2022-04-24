  
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using NUnit.Framework;

namespace EbSiteTest
{


    /// <summary>
    ///This is a test class for BBSGetTest and is intended
    ///to contain all BBSGetTest Unit Tests
    ///</summary>
    [TestFixture]
    public class CustomTest
    {
        [Test]
        public void GetKey()
        {
            Dictionary<string, string> dicKeyWords = new Dictionary<string, string>(); 
            string[] aKeyWord = new[] { "了", "多", "一", "不" };
            for (int i = 0; i < aKeyWord.Length; i++)
            {
                dicKeyWords.Add(aKeyWord[i], string.Concat("hs_kw", i));
            }
            foreach (var model in dicKeyWords)
            {
                System.Console.WriteLine(model.Key+":"+ model.Value);
            }
           
        }

        [Test]
        public void GetSimpleContent()
        {
            #region str
            string ContentInfo = @"<style>.contentbox span,.contentbox a{font-size: 16x;line-height:24px;font-family:""Microsoft YaHei"",""微软雅黑"";}
.contentinfo p span{font-family:""Microsoft YaHei"",""微软雅黑""!important;font-size:14px;}
.mainright .title{height:40px;line-height:40px;border-top:1px solid #e0e0e0;}
.mainright .title b{color:#333!important;font-size:16px;font-weight:normal;}
.mainright .datalist table{border-bottom:1px solid #e3e3e3;margin-bottom:10px;}
.mainright .datalist table td img{margin-right:10px;}</style>
<p>
</p>
<p>
	<span style=""font-family:宋体;"">&nbsp; &nbsp;月圆之夜，必有大事发生！正月十五喜迎元宵节，北迈网“点灯笼，赢大奖”活动开始啦，这么好的事，怎么能缺你</span>~~<span style=""font-family:宋体;"">快邀请小伙伴一起参加吧！</span>
</p>
<p>
	&nbsp;
</p>
<p style=""text-align:center;"">
	<br />
	
</p>
<p>
	&nbsp;<img src=""/UploadFile/editebox/20160219/2pyfiuf2jme-ebbaseimg.jpg"" alt="""" />
</p>
<p>
	<strong><span style=""font-size:12.0pt;font-family:宋体;""><br />
	</span></strong>
</p>
<p>
	<strong><span style=""font-size:12.0pt;font-family:宋体;"">活动时间：</span></strong>
</p>
<p>
	&nbsp;
</p>
<p>
	2016<span style=""font-family:宋体;"">年</span>02<span style=""font-family:宋体;"">月</span>22<span style=""font-family:宋体;"">日—</span>2<span style=""font-family:宋体;"">月</span>24<span style=""font-family:宋体;"">日</span>
</p>
<p>
	&nbsp;
</p>
<p>
	<strong><span style=""font-size:12.0pt;font-family:宋体;"">参与方式：</span></strong>
</p>
<p>
	&nbsp;
</p>
<p>
	Step1<span style=""font-family:宋体;"">：打开手机，搜索<strong><span style=""color:#ff0000;"">微信公众账号</span>“<span style=""color:#ff0000;"">北迈汽配</span>”</strong>并<strong><span style=""color:#ff0000;"">添加关注</span></strong>；或者<strong><span style=""color:#ff0000;"">扫二维码</span></strong>进入公众号首页；</span>
</p>
<p>
	&nbsp;
</p>
<p>
	Step2<span style=""font-family:宋体;"">：点击<strong>微信菜单栏“<span style=""color:#ff0000;"">点灯笼</span>”</strong>开始游戏；或对话框<strong>输入关键词“<span style=""color:#ff0000;"">点灯笼</span>”</strong>，点击查看推送的图文信息开始游戏；</span>
</p>
<p>
	&nbsp;
</p>
<p>
	&nbsp;<img src=""/UploadFile/editebox/20160219/2vszld1yjv1-ebbaseimg.jpg"" alt="""" />
</p>
<p style=""text-align:center;"">
	<br />
	
</p>
<p style=""text-align:center;"">
	<span style=""font-family:宋体;""><span style=""color:#ff0000;"">扫我，参加活动吧！</span></span>
</p>
<p>
	<span style=""font-size:12.0pt;"">&nbsp;</span>
</p>
<p>
	<strong><span style=""font-size:12.0pt;font-family:宋体;"">活动规则：</span></strong>
</p>
<p>
	&nbsp;
</p>
<p>
	1、<span style=""font-family:宋体;"">本次活动共有</span>5<span style=""font-family:宋体;"">盏灯笼，自己可以单独点亮</span>1<span style=""font-family:宋体;"">盏灯笼，剩下的</span>4<span style=""font-family:宋体;"">盏灯笼则需邀请好友协助。</span>
</p>
<p>
	&nbsp;
</p>
<p>
	2<span style=""font-family:宋体;"">、本次活动只允许兑换一次奖品，先兑先得，达到兑换条件后，玩家可以选择继续点亮其他灯笼或者直接点击兑换。</span>
</p>
<p>
	<span style=""font-size:12.0pt;"">&nbsp;</span>
</p>
<p>
	<strong><span style=""font-size:12.0pt;font-family:宋体;"">兑奖说明：</span></strong>
</p>
<p>
	&nbsp;
</p>
<p>
	1、<span style=""font-family:宋体;"">兑换奖品时，请及时在“我的奖品”填写兑换密码“</span><span style=""color:#ff0000;"">beimai</span><span style=""font-family:宋体;"">”，填写完才能生效噢；</span>
</p>
<p>
	&nbsp;
</p>
<p>
	2、<span style=""font-family:宋体;"">中奖用户请及时填写个人相关信息登记，逾期将失去领奖资格；</span>
</p>
<p>
	&nbsp;
</p>
<p>
	3<span style=""font-family:宋体;"">、奖品将在活动结束后的</span>20<span style=""font-family:宋体;"">个工作日内发放，请耐心等待；</span>
</p>
<p>
	&nbsp;
</p>
<p>
	*<span style=""font-family:宋体;"">本活动最终解释权归北迈网所有</span>*
</p>
<p>
	&nbsp;
</p>
<p>
	<span style=""font-family:宋体;"">点了灯笼，才算过元宵呢！快和小伙伴一起团团圆圆嗨起来吧！</span>
</p>
<p>
	&nbsp;
</p>
<br />";
            #endregion


            if (!string.IsNullOrEmpty(ContentInfo.Trim()))
            {
                string sC = CleanHtml(ContentInfo);
                sC = EbSite.Core.Strings.GetString.NoUbb(sC);
                sC = EbSite.Core.Strings.GetString.SubStr(sC, 300);
                System.Console.WriteLine(sC);

            }
            

        }

        
        /// <summary>
        /// 去掉HTML中的所有标签,只留下纯文本
        /// </summary>
        /// <param name="strHtml"></param>
        /// <returns></returns>

        public static string CleanHtml(string strHtml)
        {
            if (string.IsNullOrEmpty(strHtml)) return strHtml;
            //删除脚本
            //Regex.Replace(strHtml, @"<script[^>]*?>.*?</script>", "", RegexOptions.IgnoreCase)
            strHtml = Regex.Replace(strHtml, "(\\<script(.+?)\\</script\\>)|(\\<style(.+?)\\</style\\>)", "", RegexOptions.IgnoreCase | RegexOptions.Singleline);
            //删除标签
            var r = new Regex(@"</?[^>]*>", RegexOptions.IgnoreCase);
            Match m;
            for (m = r.Match(strHtml); m.Success; m = m.NextMatch())
            {
                strHtml = strHtml.Replace(m.Groups[0].ToString(), "");
            }
            strHtml = strHtml.Replace("&nbsp;","").Replace("\r","").Replace("\t","").Replace("\n","");
            return strHtml.Trim();
        }
       

        [Test]
        public void GetTextUrl()
        {
            #region str
            string tem = @"大港环球英语培训  20  
        环球雅思天津滨海总校  22	
	塘沽环球雅思培训学校  51
	大港托福培训  16
(新站）www.dfjztnk.com	        0  126  
	河西区少儿美术培训课 0
	西青区少儿识字培训   0
	东方金子塔天津南开总校   14
(新站）www.tjxuanchuance.com	0     103 
	天津宣传册印刷  0
	天津礼品盒印刷厂  46
	恒昌包装盒印彩印   53
（满）(新站）www.huadongfadianji.com  0    83       华东发电机租赁公司  17   
(新站）www.tjbeiyangjiaoyu.com 	0   146     天津教育培训学校   0        	
(新站）www.tianhaishida.com	0    67     天津光缆用钢丝  46 	
(新站）www.tj-ruijia.com	yixue.koolearn.com/zyzy/	中医执业医师考试
yixue.koolearn.com/zghs/	主管护师考试
yixue.koolearn.com/kq/	 口腔医师资格考试
yixue.koolearn.com/lczy/	临床执业医师考试
yixue.koolearn.com/lczl/	临床执业助理医师考试
yixue.koolearn.com/yxzhicheng/	药学职称考试
yixue.koolearn.com/zxy/	  中西医结合执业医师考试
yixue.koolearn.com/zxyys/	中西医结合医师考试
yixue.koolearn.com/zyys/	中医医师资格考试
yixue.koolearn.com/zhiyehushi/	护士资格考试
yixue.koolearn.com/chuji/	初级护师考试
yixue.koolearn.com/zyyaoshi/	执业药师考试
yixue.koolearn.com/lc/	 临床医师资格考试
";
            #endregion

            List<string> dic = EbSite.Core.WebUtility.GetTextUrls(tem);
            foreach (var md in dic)
            {
                System.Console.WriteLine(md);
            }
        }

        /// <summary>
        ///A test for CallTask
        ///</summary>
        [Test]
        public void CallTaskTest()
        {
            string strPath = " / fsdfsdfsf/test.html";
            strPath = strPath.Remove(0, 1);
            //strPath = strPath.Replace("/", "\\");
            //string sP = System.IO.Path.Combine(@"D:\web\eBSite5.0\项目\Project\EbSite.Web\", strPath);
            //Debug.Print(obj.Count.ToString());
            System.Console.WriteLine(strPath);
        }

        [Test]
        public void IsCNTest()
        {
          bool iscn =  EbSite.Core.Strings.Validate.IsCN("你就知道ff简aaf单易懂");
            System.Console.WriteLine(iscn);
        }

        [Test]
        public void RegexFindsTest()
        {
            #region str
            string str = @"http://bbs.csdn.net/topics/340172478/abc.html";
            #endregion

            List<string> strsList = EbSite.Core.Strings.GetString.RegexFinds(@"(?<=[^/]/)[^/]+(?=/)",  str,0);

            foreach (var url in strsList)
            {
                System.Console.WriteLine(url);
            }

            
        }

    }
}
