using System;
using System.Text;
using System.Text.RegularExpressions;



namespace EbSite.Core
{
    /// <summary>
    /// UBB 的摘要说明。
    /// </summary>
    public class UBB
    {
        #region 全新

        #region 辅助方法

        static private string getSizeName(Match match)
        {
            if (match.Success)
            {
                string[] arrSize = { "10px", "13px", "16px", "18px", "24px", "32px", "48px" };

                return string.Concat("<span style=\"font-size:", match.Groups[1].Value, ";\">");
            }
            return string.Empty;
        }

        static private string getImg(Match match)
        {

            if (match.Success)
            {
                string alt = match.Groups[1].Value;
                string p1 = match.Groups[2].Value;
                string p2 = match.Groups[3].Value;
                string p3 = match.Groups[4].Value;
                string src = match.Groups[5].Value;
                string a = (!string.IsNullOrEmpty(p3)) ? p3 : (!Utils.IsNumeric(p1) ? p1 : "");

                return string.Format("<img src=\"{0}\" alt=\"{1}\" {2} {3} {4} />",
                    src,
                    alt,
                    Utils.IsNumeric(p1) ? string.Concat("width=", p1) : "",
                    Utils.IsNumeric(p2) ? string.Concat("height=", p2) : "",
                    string.IsNullOrEmpty(a) ? "" : string.Concat("align=", a)
                    );
            }
            return string.Empty;
        }

        private static string emotPath = string.Concat(EbSite.Base.AppStartInit.IISPath, "js/plugin/editbox/xheditor_emot/");
        static private string getEmot(Match match)
        {
            if (match.Success)
            {
                string[] arr = match.Groups[1].Value.Split(',');
                if (arr.Length == 2)
                {
                    return string.Format("<img src=\"{0}{1}/{2}.gif\"   />", emotPath, arr[0], arr[1]);
                }
                return string.Format("<img src=\"{0}default/{1}.gif\"   />", emotPath, arr[0]);
            }
            return "";

        }

        static private string getFlash(Match match)
        {
            if (match.Success)
            {
                string w = match.Groups[1].Value;
                string h = match.Groups[2].Value;
                string url = match.Groups[3].Value;
                if (string.IsNullOrEmpty(w))
                {
                    w = "480";
                    if (string.IsNullOrEmpty(h)) h = "400";
                }
                return string.Format("<embed type=\"application/x-shockwave-flash\" src=\"{0}\" wmode=\"opaque\" quality=\"high\" bgcolor=\"#ffffff\" menu=\"false\" play=\"true\" loop=\"true\" width=\"{1}\" height=\"{2}\" />",
                    url, w, h
                    );
            }
            return string.Empty;
        }

        static private string getMedia(Match match)
        {
            if (match.Success)
            {
                string w = match.Groups[1].Value; 
                string h = match.Groups[2].Value; 
                string play = match.Groups[3].Value; 
                string url = match.Groups[4].Value; 
                if (string.IsNullOrEmpty(w))
                {
                    w = "480";
                }
                if (string.IsNullOrEmpty(h))
                {
                    w = "400";
                }
                return string.Format("<embed type=\"application/x-mplayer2\" src=\"{0}\" enablecontextmenu=\"false\" autostart=\"{1}\" width=\"{2}\" height=\"{3}\" />",
                    url, play == "1" ? "true" : "false",
                    w, h
                    );
            }
            return string.Empty;
            
        }

        static private string getTable(Match match)
        {
            if (match.Success)
            {
                //return string.Format("<table {0} {1}>", string.IsNullOrEmpty(match.Groups[1].Value) ? "" : string.Concat("width=", match.Groups[1].Value), string.IsNullOrEmpty(match.Groups[2].Value) ? "" : string.Concat("bgcolor=", match.Groups[2].Value));

                //修改强制加入边框

                return string.Format("<table class='tbline'  {0} {1}>", string.IsNullOrEmpty(match.Groups[1].Value) ? "" : string.Concat("width=", match.Groups[1].Value), string.IsNullOrEmpty(match.Groups[2].Value) ? "" : string.Concat("bgcolor=", match.Groups[2].Value));
            }

            return string.Empty;
        }
        static private string getTR(Match match)
        {
            if (match.Success)
            {
                return string.Format("<tr {0}>", string.IsNullOrEmpty(match.Groups[1].Value) ? "" : string.Concat("bgcolor=", match.Groups[1].Value));
            }
            return string.Empty;
        }
        static private string getTD(Match match)
        {
            if (match.Success)
            {
                string col = string.IsNullOrEmpty(match.Groups[1].Value) ? "0" : match.Groups[1].Value;

                string row = string.IsNullOrEmpty(match.Groups[2].Value) ? "0" : match.Groups[2].Value;

                string w = string.IsNullOrEmpty(match.Groups[3].Value) ? "null" : match.Groups[3].Value;


                return string.Format("<td {0} {1} {2}>",
                    !Equals(col, "1") ? string.Concat("colspan=", col) : "",
                    !Equals(row, "1") ? string.Concat("rowspan=", row) : "",
                    string.IsNullOrEmpty(w) ? "" : string.Concat("width=", row)
                    );
            }
            return string.Empty;
        }
        static private string getUL(Match match)
        {
            if (match.Success)
            {
                string str = "<ul";
                if (string.IsNullOrEmpty(match.Groups[1].Value))
                {
                    str += " type=\"" + match.Groups[1].Value + "\"";
                }
                return string.Concat(str, ">");
            }
            return string.Empty;
        }
        static private string fixText(Match match)
        {
            if (match.Success)
            {
                string text = match.Groups[2].Value;
                text = Regex.Replace(text, @"\t", "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;", RegexOptions.IgnoreCase);
                text = Regex.Replace(text, @" ", "&nbsp;", RegexOptions.IgnoreCase);
                return string.Concat(match.Groups[1].Value, text);
            }
            return string.Empty;
        }
        #endregion  

        public static string UBBToHtml(string ubb)
        {

            if (!string.IsNullOrEmpty(ubb))
            {

                ubb = ubb.Replace("&", "&amp;");
                ubb = ubb.Replace("<", "&lt;");
                ubb = ubb.Replace(">", "&gt;");


                ubb = Regex.Replace(ubb, @"\[(\/?)(b|u|i|s|sup|sub)\]", "<$1$2>", RegexOptions.IgnoreCase);

                ubb = Regex.Replace(ubb, @"\[color\s*=\s*([^\]""]+?)(?:""[^\]]*?)?\s*\]", "<span style=\"color:$1;\">", RegexOptions.IgnoreCase);
                ubb = Regex.Replace(ubb, @"\[size\s*=\s*([^\]""]+?)(?:""[^\]]*?)?\s*\]", new MatchEvaluator(getSizeName), RegexOptions.IgnoreCase);
                ubb = Regex.Replace(ubb, @"\[font\s*=\s*([^\]""]+?)(?:""[^\]]*?)?\s*\]", "<span style=\"font-family:$1;\">", RegexOptions.IgnoreCase);
                ubb = Regex.Replace(ubb, @"\[back\s*=\s*([^\]""]+?)(?:""[^\]]*?)?\s*\]", "<span style=\"background-color:$1;\">", RegexOptions.IgnoreCase);

                ubb = Regex.Replace(ubb, @"\[\/(color|size|font|back)\]", "</span>", RegexOptions.IgnoreCase);

                ubb = Regex.Replace(ubb, @"\[align\s*=\s*([^\]""]+?)(?:""[^\]]*?)?\s*\](((?!\[align(?:\s+[^\]]+)?\])[\s\S])*?)\[\/align\]", "<p align=\"$1\">$2</p>", RegexOptions.IgnoreCase);
                ubb = Regex.Replace(ubb, @"\[img\]\s*(((?!"")[\s\S])+?)(?:""[\s\S]*?)?\s*\[\/img\]", "<img src=\"$1\" alt=\"\" />", RegexOptions.IgnoreCase);

                ubb = Regex.Replace(ubb, @"\[img\s*=([^,\]]*)(?:\s*,\s*(\d*%?)\s*,\s*(\d*%?)\s*)?(?:,?\s*(\w+))?\s*\]\s*(((?!"")[\s\S])+?)(?:""[\s\S]*)?\s*\[\/img\]", getImg, RegexOptions.IgnoreCase);

                ubb = Regex.Replace(ubb, @"\[emot\s*=\s*([^\]""]+?)(?:""[^\]]*?)?\s*\/\]", new MatchEvaluator(getEmot));

                ubb = Regex.Replace(ubb, @"\[url\]\s*(((?!"")[\s\S])*?)(?:""[\s\S]*?)?\s*\[\/url\]", "<a href=\"$1\">$1</a>", RegexOptions.IgnoreCase);

                ubb = Regex.Replace(ubb, @"\[url\s*=\s*([^\]""]+?)(?:""[^\]]*?)?\s*\]\s*([\s\S]*?)\s*\[\/url\]", "<a href=\"$1\">$2</a>", RegexOptions.IgnoreCase);

                ubb = Regex.Replace(ubb, @"\[email\]\s*(((?!"")[\s\S])+?)(?:""[\s\S]*?)?\s*\[\/email\]", "<a href=\"mailto:$1\">$1</a>", RegexOptions.IgnoreCase);

                ubb = Regex.Replace(ubb, @"\[email\s*=\s*([^\]""]+?)(?:""[^\]]*?)?\s*\]\s*([\s\S]+?)\s*\[\/email\]", "<a href=\"mailto:$1\">$2</a>", RegexOptions.IgnoreCase);

                ubb = Regex.Replace(ubb, @"\[quote\]", "<blockquote>", RegexOptions.IgnoreCase);

                ubb = Regex.Replace(ubb, @"\[\/quote\]", "</blockquote>", RegexOptions.IgnoreCase);

                ubb = Regex.Replace(ubb, @"\[flash\s*(?:=\s*(\d+)\s*,\s*(\d+)\s*)?\]\s*(((?!"")[\s\S])+?)(?:""[\s\S]*?)?\s*\[\/flash\]", getFlash, RegexOptions.IgnoreCase);


                ubb = Regex.Replace(ubb, @"\[media\s*(?:=\s*(\d+)\s*,\s*(\d+)\s*(?:,\s*(\d+)\s*)?)?\]\s*(((?!"")[\s\S])+?)(?:""[\s\S]*?)?\s*\[\/media\]", getMedia, RegexOptions.IgnoreCase);

                ubb = Regex.Replace(ubb, @"\[table\s*(?:=(\d{1,4}%?)\s*(?:,\s*([^\]""]+)(?:""[^\]]*?)?)?)?\s*\]", getTable, RegexOptions.IgnoreCase);

                ubb = Regex.Replace(ubb, @"\[tr\s*(?:=(\s*[^\]""]+))?(?:""[^\]]*?)?\s*\]", getTR, RegexOptions.IgnoreCase);

                ubb = Regex.Replace(ubb, @"\[td\s*(?:=\s*(\d{1,2})\s*,\s*(\d{1,2})\s*(?:,\s*(\d{1,4}%?))?)?\s*\]", getTD, RegexOptions.IgnoreCase);

                ubb = Regex.Replace(ubb, @"\[\/(table|tr|td)\]", "</$1>", RegexOptions.IgnoreCase);

                ubb = Regex.Replace(ubb, @"\[\*\]((?:(?!\[\*\]|\[\/list\]|\[list\s*(?:=[^\]]+)?\])[\s\S])+)", "<li>$1</li>", RegexOptions.IgnoreCase);

                ubb = Regex.Replace(ubb, @"\[list\s*(?:=\s*([^\]""]+))?(?:""[^\]]*?)?\s*\]", getUL, RegexOptions.IgnoreCase);


                ubb = Regex.Replace(ubb, @"\[\/list\]", "</ul>", RegexOptions.IgnoreCase);

                ubb = Regex.Replace(ubb, @"\[hr\/\]", "'<hr />", RegexOptions.IgnoreCase);

                ubb = Regex.Replace(ubb, @"(^|<\/?\w+(?:\s+[^>]*?)?>)([^<$]+)", fixText, RegexOptions.IgnoreCase);


                string strRule = @"\[code\s*(?:=\s*((?:(?!"")[\s\S])+?)(?:""[\s\S]*?)?)?\]([\s\S]*?)\[\/code\]";
                //Match mc;// = Regex.Match(ubb, strRule);

                for (Match mc = Regex.Match(ubb, strRule); mc.Success; mc = mc.NextMatch())
                {
                    string tem = mc.Groups[0].Value;
                    string stype = mc.Groups[1].Value;
                    string code = mc.Groups[2].Value;
                    string newcde = "";
                    code = code.Replace("<", "&lt;").Replace(">", "&gt;");
                    newcde = string.Concat("<pre class=\"prettyprint lang-", stype, "\">", code, "</pre>");
                    ubb = ubb.Replace(tem, newcde);

                }



                //if (mc.Success)
                //{
                //    mc.NextMatch()

                //    string tem = mc.Groups[0].Value;
                //    string stype = mc.Groups[1].Value;
                //    string code = mc.Groups[2].Value;
                //    string newcde = "";
                //    code = code.Replace("<", "&lt;").Replace(">", "&gt;");
                //    newcde = string.Concat("<pre class=\"prettyprint lang-", stype, "\">", code, "</pre>");
                //    ubb = ubb.Replace(tem, newcde);
                //}
                ubb = Regex.Replace(ubb, @"\r?\n", "<br />", RegexOptions.IgnoreCase);
                return ubb;
            }
            return string.Empty;

        }

        #endregion

        private static string IMG_SIGN_SIGNATURE = "<img src=\"$1\" border=\"0\" />";
        private static string IMG_SIGN = "<img src=\"$1\" border=\"0\" onload=\"thumbImg(this)\" />";
        private static RegexOptions options = RegexOptions.IgnoreCase;

        public static Regex[] r = new Regex[20];

        static UBB()
        {
            r[0] = new Regex(@"\s*\[code\]([\s\S]+?)\[\/code\]\s*", options);
            r[1] = new Regex(@"(\[upload=([^\]]{1,4})(,.*?\.[^\]]{1,4})?\])(.*?)(\[\/upload\])", options);
            r[2] = new Regex(@"viewfile.asp\?id=(\d{1,})", RegexOptions.IgnoreCase | RegexOptions.Singleline);
            r[3] = new Regex(@"(\[uploadimage\])(.*?)(\[\/uploadimage\])", options);
            r[4] = new Regex(@"viewfile.asp\?id=(\d{1,})", RegexOptions.IgnoreCase | RegexOptions.Singleline);
            r[5] = new Regex(@"(\[uploadfile\])(.*?)(\[\/uploadfile\])", options);
            r[6] = new Regex(@"viewfile.asp\?id=(\d{1,})", RegexOptions.IgnoreCase | RegexOptions.Singleline);
            r[7] = new Regex(@"(\[upload\])(.*?)(\[\/upload\])", options);
            r[8] = new Regex(@"viewfile.asp\?id=(\d{1,})", RegexOptions.IgnoreCase | RegexOptions.Singleline);
            r[9] = new Regex(@"(\r\n((&nbsp;)|　| )+)(?<正文>\S+)", options);
            r[10] = new Regex(@"\s*\[hide\][\n\r]*([\s\S]+?)[\n\r]*\[\/hide\]\s*", RegexOptions.IgnoreCase);
            r[11] = new Regex(@"\[table(?:=(\d{1,4}%?)(?:,([\(\)%,#\w ]+))?)?\]\s*([\s\S]+?)\s*\[\/table\]", options);
            r[12] = new Regex(@"\[media=(\w{1,4}),(\d{1,4}),(\d{1,4})(,(\d))?\]\s*([^\[\<\r\n]+?)\s*\[\/media\]", options);
            r[13] = new Regex(@"\[attach\](\d+)(\[/attach\])*", options);
            r[14] = new Regex(@"\[attachimg\](\d+)(\[/attachimg\])*", options);
            r[15] = new Regex(@"\s*\[free\][\n\r]*([\s\S]+?)[\n\r]*\[\/free\]\s*", RegexOptions.IgnoreCase);
            r[16] = new Regex(@"\s*\[hide=(\d+?)\][\n\r]*([\s\S]+?)[\n\r]*\[\/hide\]\s*", RegexOptions.IgnoreCase);
            r[17] = new Regex(@"\[audio(=(\d))?\]\s*([^\[\<\r\n]+?)\s*\[\/audio\]", options);
            r[18] = new Regex(@"\[p=(\d{1,4}), (\d{1,4}), (left|center|right)\]\s*([^\[\<\r\n]+?)\s*\[\/p\]", options);
            r[19] = new Regex(@"\[flash(=(\d{1,4}),(\d{1,4}))?\]\s*([^\[\<\r\n]+?)\s*\[\/flash\]", options);
        }


        public static  string Ubb2Html(string content)
        {
            PostpramsInfo md = new PostpramsInfo();
            md.Sdetail = content;
            md.Allowhtml =0;
            md.Bbcodemode = 1;
            md.Bbcodeoff = 0;
            md.Parseurloff = 0;
            md.Showimages = 1;
            md.Signature = 1;
            md.Smileyoff = 1;
            md.Smiliesmax = 10;
            return UBBToHTML(md);
        }
        /// <summary>
        /// UBB代码处理函数
        /// </summary>
        ///	<param name="_postpramsinfo">UBB转换参数表</param>
        /// <returns>输出字符串</returns>
        public static string UBBToHTML(PostpramsInfo _postpramsinfo)
        {
            Match m;

            string sDetail = _postpramsinfo.Sdetail;

            StringBuilder sb = new StringBuilder();
            int pcodecount = -1;
            string sbStr = "";
            string prefix = "";// _postpramsinfo.Pid.ToString();
            if (_postpramsinfo.Bbcodeoff == 0)
            {
                for (m = r[0].Match(sDetail); m.Success; m = m.NextMatch())
                {
                    sbStr = Parsecode(m.Groups[1].ToString(), prefix, ref pcodecount, _postpramsinfo.Allowhtml, ref sb);
                    sDetail = sDetail.Replace(m.Groups[0].ToString(), sbStr);
                }
            }

            //if (_postpramsinfo.Bbcodeoff == 0)
            //{
            //    sDetail = HideDetail(sDetail, _postpramsinfo.Hide, _postpramsinfo.Usercredits);
            //}


            //清除无效的smilie标签
            sDetail = Regex.Replace(sDetail, @"\[smilie\](.+?)\[\/smilie\]", "$1", options);

            //#region 建立smile表情标签

            //if (_postpramsinfo.Smileyoff == 0 && _postpramsinfo.Smiliesinfo != null)
            //{
            //    sDetail = ParseSmilies(sDetail, _postpramsinfo.Smiliesinfo, _postpramsinfo.Smiliesmax);
            //}

            //#endregion

            // [smilie]处标记
            sDetail = Regex.Replace(sDetail, @"\[smilie\](.+?)\[\/smilie\]", "<img src=\"$1\" />", options);

            if (_postpramsinfo.Bbcodeoff == 0)
            {
                if (sDetail.ToLower().Contains("[free]") || sDetail.ToLower().Contains("[/free]"))
                {
                    for (m = r[15].Match(sDetail); m.Success; m = m.NextMatch())
                    {
                        sDetail = sDetail.Replace(m.Groups[0].ToString(), "<br /><div class=\"msgheader\">免费内容:</div><div class=\"msgborder\">" + m.Groups[1].ToString() + "</div><br />");

                    }
                }

                // Bold, Italic, Underline
                sDetail = parseBold(sDetail);
                //sDetail = Regex.Replace(sDetail, @"\[b(?:\s*)\]", "<b>", options);
                //sDetail = Regex.Replace(sDetail, @"\[i(?:\s*)\]", "<i>", options);
                //sDetail = Regex.Replace(sDetail, @"\[u(?:\s*)\]", "<u>", options);
                //sDetail = Regex.Replace(sDetail, @"\[/b(?:\s*)\]", "</b>", options);
                //sDetail = Regex.Replace(sDetail, @"\[/i(?:\s*)\]", "</i>", options);
                //sDetail = Regex.Replace(sDetail, @"\[/u(?:\s*)\]", "</u>", options);

                // Sub/Sup
                sDetail = Regex.Replace(sDetail, @"\[sup(?:\s*)\]", "<sup>", options);
                sDetail = Regex.Replace(sDetail, @"\[sub(?:\s*)\]", "<sub>", options);
                sDetail = Regex.Replace(sDetail, @"\[/sup(?:\s*)\]", "</sup>", options);
                sDetail = Regex.Replace(sDetail, @"\[/sub(?:\s*)\]", "</sub>", options);

                // P
                sDetail = Regex.Replace(sDetail, @"((\r\n)*\[p\])(.*?)((\r\n)*\[\/p\])", "<p>$3</p>", RegexOptions.IgnoreCase | RegexOptions.Singleline);

                // Anchors
                sDetail = ParseUrl(sDetail);

                // Email
                sDetail = Regex.Replace(sDetail, @"\[email(?:\s*)\](.*?)\[\/email\]", "<a href=\"mailto:$1\" target=\"_blank\">$1</a>", options);
                sDetail = Regex.Replace(sDetail, @"\[email=(.[^\[]*)(?:\s*)\](.*?)\[\/email(?:\s*)\]", "<a href=\"mailto:$1\" target=\"_blank\">$2</a>", options);

                #region

                // Font
                sDetail = parseFont(sDetail);
                //sDetail = Regex.Replace(sDetail, @"\[color=([^\[\<]+?)\]", "<font color=\"$1\">", options);
                //sDetail = Regex.Replace(sDetail, @"\[size=(\d+?)\]", "<font size=\"$1\">", options);
                //sDetail = Regex.Replace(sDetail, @"\[size=(\d+(\.\d+)?(px|pt|in|cm|mm|pc|em|ex|%)+?)\]", "<font style=\"font-size: $1\">", options);
                //sDetail = Regex.Replace(sDetail, @"\[font=([^\[\<]+?)\]", "<font face=\"$1\">", options);
                //sDetail = Regex.Replace(sDetail, @"\[align=([^\[\<]+?)\]", "<p align=\"$1\">", options);
                //sDetail = Regex.Replace(sDetail, @"\[float=(left|right)\]", "<br style=\"clear: both\"><span style=\"float: $1;\">", options);
                //sDetail = Regex.Replace(sDetail, @"\[/color(?:\s*)\]", "</font>", options);
                //sDetail = Regex.Replace(sDetail, @"\[/size(?:\s*)\]", "</font>", options);
                //sDetail = Regex.Replace(sDetail, @"\[/font(?:\s*)\]", "</font>", options);
                //sDetail = Regex.Replace(sDetail, @"\[/align(?:\s*)\]", "</p>", options);
                //sDetail = Regex.Replace(sDetail, @"\[/float(?:\s*)\]", "</span>", options);

                // BlockQuote
                sDetail = Regex.Replace(sDetail, @"\[indent(?:\s*)\]", "<blockquote>", options);
                sDetail = Regex.Replace(sDetail, @"\[/indent(?:\s*)\]", "</blockquote>", options);
                sDetail = Regex.Replace(sDetail, @"\[simpletag(?:\s*)\]", "<blockquote>", options);
                sDetail = Regex.Replace(sDetail, @"\[/simpletag(?:\s*)\]", "</blockquote>", options);

                // List
                sDetail = Regex.Replace(sDetail, @"\[list\]", "<ul>", options);
                sDetail = Regex.Replace(sDetail, @"\[list=1\]", "<ul type=1 class=\"litype_1\">", options);
                sDetail = Regex.Replace(sDetail, @"\[list=a\]", "<ul type=1 class=\"litype_2\">", options);
                sDetail = Regex.Replace(sDetail, @"\[list=A\]", "<ul type=1 class=\"litype_3\">", options);
                sDetail = Regex.Replace(sDetail, @"\[\*\]", "<li>", options);
                sDetail = Regex.Replace(sDetail, @"\[/list\]", "</ul>", options);
                #endregion

                #region 循环转换table

                sDetail = ParseTable(sDetail);

                #endregion

                // shadow
                sDetail = Regex.Replace(sDetail, @"(\[SHADOW=)(\d*?),(#*\w*?),(\d*?)\]([\s]||[\s\S]+?)(\[\/SHADOW\])", "<table width='$2'  style='filter:SHADOW(COLOR=$3, STRENGTH=$4)'>$5</table>", options);

                // glow
                sDetail = Regex.Replace(sDetail, @"(\[glow=)(\d*?),(#*\w*?),(\d*?)\]([\s]||[\s\S]+?)(\[\/glow\])", "<table width='$2'  style='filter:GLOW(COLOR=$3, STRENGTH=$4)'>$5</table>", options);

                // center
                sDetail = Regex.Replace(sDetail, @"\[center\]([\s]||[\s\S]+?)\[\/center\]", "<center>$1</center>", options);

                // Media

                MatchCollection mc = r[12].Matches(sDetail);
                foreach (Match match in mc)
                {
                    sDetail = sDetail.Replace(match.Groups[0].Value, ParseMedia(match.Groups[1].Value, Utils.StrToInt(match.Groups[2].Value, 64), Utils.StrToInt(match.Groups[3].Value, 48), match.Groups[4].Value == "1" ? true : false, match.Groups[6].Value));
                }


                //Audio
                mc = r[17].Matches(sDetail);
                foreach (Match match in mc)
                {
                    sDetail = sDetail.Replace(match.Groups[0].Value, ParseAudio(match.Groups[2].Value, match.Groups[3].Value));
                }

                //p
                mc = r[18].Matches(sDetail);
                foreach (Match match in mc)
                {
                    sDetail = sDetail.Replace(match.Groups[0].Value, ParseP(match.Groups[1].Value, match.Groups[2].Value, match.Groups[3].Value, match.Groups[4].Value));
                }
                sDetail = sDetail.Replace("[p=30, 2, left][/p]", "<p style=\"line-height: 30px; text-indent: 2em; text-align: left;\"></p>");
                //flash
                mc = r[19].Matches(sDetail);
                foreach (Match match in mc)
                {
                    sDetail = sDetail.Replace(match.Groups[0].Value, ParseFlash(match.Groups[2].Value, match.Groups[3].Value, match.Groups[4].Value));
                }

                //#region 自定义标签

                //if (_postpramsinfo.Customeditorbuttoninfo != null)
                //{
                //    sDetail = ReplaceCustomTag(sDetail, _postpramsinfo.Customeditorbuttoninfo);
                //}

                //#endregion

                #region 处理[quote][/quote]标记

                int intQuoteIndexOf = sDetail.ToLower().IndexOf("[quote]");
                int quotecount = 0;
                while (intQuoteIndexOf >= 0 && sDetail.ToLower().IndexOf("[/quote]") >= 0 && quotecount < 3)
                {
                    quotecount++;
                    sDetail = Regex.Replace(sDetail, @"\[quote\]([\s\S]+?)\[/quote\]", "<table style=\"width: auto;\"><tr><td style=\"border:none;\"><div class=\"quote\"><blockquote>$1</blockquote></div></td></tr></table>", options);

                    intQuoteIndexOf = sDetail.ToLower().IndexOf("[quote]", intQuoteIndexOf + 7);
                }

                #endregion

                //处理[area]标签
                sDetail = Regex.Replace(sDetail, @"\[area=([\s\S]+?)\]([\s\S]+?)\[/area\]", "<div class=\"msgheader\">$1</div><div class=\"msgborder\">$2</div>", options);
                sDetail = Regex.Replace(sDetail, @"\[area\]([\s\S]+?)\[/area\]", "<br /><br /><div class=\"msgheader\"></div><div class=\"msgborder\">$1</div>", options);

                #region 动网兼容模式ubb
                //yhl ==begin==
                //if (_postpramsinfo.Bbcodemode == 1)
                //{
                //    ///[upload=jpg].jpg[/upload]
                //    string attachCode = "<p><img alt=\"\" src=\"{0}\" border=\"0\" /><span class=\"bold\">附件</span>: <a href=\"{1}\" target=\"_blank\">{2}</a> </p>";
                //    string replacement = "";
                //    string attachIcon = "images/attachicons/attachment.gif";
                //    for (m = r[1].Match(sDetail); m.Success; m = m.NextMatch())
                //    {

                //        Match m1 = r[2].Match(m.Groups[4].ToString().ToLower());
                //        if (m1.Success)
                //        {
                //            sDetail = sDetail.Replace(m.Groups[0].ToString(), "[attach]" + m1.Groups[1] + "[/attach]");
                //            continue;
                //        }
                //        //yhl ==begin==
                //        //string attachPath = m.Groups[4].ToString().ToLower().Replace("viewfile.asp?id", "attachment.aspx?attachmentid");
                //        //if (attachPath.IndexOf("attachment.aspx?attachmentid") == -1)
                //        //{
                //        //    attachPath = BaseConfigs.GetForumPath + "upload/" + attachPath;
                //        //}
                //        //else
                //        //{
                //        //    attachPath = BaseConfigs.GetForumPath + attachPath;
                //        //}
                //        //////end===
                //        if ("rar,zip".IndexOf(m.Groups[2].ToString().ToLower()) != -1)
                //        {
                //            attachIcon = "images/attachicons/rar.gif";
                //        }
                //        //yhl ==begin==
                //        //if ("jpg,jpeg,gif,bmp,png".IndexOf(m.Groups[2].ToString().ToLower()) != -1)
                //        //{
                //        //    if (_postpramsinfo.Showimages == 1)
                //        //    {
                //        //        sDetail = sDetail.Replace(m.Groups[0].ToString(), "<img src=\"" + attachPath + "\" border=\"0\" onload=\"if(this.width>screen.width*0.7) {this.resized=true; this.width=screen.width*0.7; this.alt=\'点击在新窗口浏览图片\\nCTRL+Mouse 滚轮可放大/缩小\';}\" onmouseover=\"if(this.width>screen.width*0.7) {this.resized=true; this.width=screen.width*0.7; this.style.cursor=\'hand\'; this.alt=\'点击在新窗口浏览图片\\nCTRL+Mouse 滚轮可放大/缩小\';}\" onclick=\"if(!this.resized) {return true;} else {window.open(this.src);}\" onmousewheel=\"return imgzoom(this);\" />");
                //        //    }
                //        //    else
                //        //    {
                //        //        replacement = attachPath;
                //        //        if (replacement.LastIndexOf("/") > 0)
                //        //        {
                //        //            replacement = Utils.CutString(replacement, replacement.LastIndexOf("/"));
                //        //        }
                //        //        replacement = string.Format(attachCode, attachIcon, attachPath);
                //        //        sDetail = sDetail.Replace(m.Groups[0].ToString(), replacement);
                //        //    }

                //        //}
                //        //else
                //        //{
                //        //    replacement = attachPath;
                //        //    if (replacement.LastIndexOf("/") > 0)
                //        //    {
                //        //        replacement = Utils.CutString(replacement, replacement.LastIndexOf("/"));
                //        //    }
                //        //    replacement = string.Format(attachCode, attachIcon, attachPath, replacement);
                //        //    sDetail = sDetail.Replace(m.Groups[0].ToString(), replacement);
                //        //}

                //        //////end===
                //    }

                //    sDetail = Regex.Replace(sDetail, @"\[uploadimage\](\d{1,})\[/uploadimage\]", "[attach]$1[/attach]", options);

                //    replacement = "";
                //    for (m = r[3].Match(sDetail); m.Success; m = m.NextMatch())
                //    {
                //        Match m1 = r[4].Match(m.Groups[2].ToString().ToLower());
                //        if (m1.Success)
                //        {
                //            sDetail = sDetail.Replace(m.Groups[0].ToString(), "[attach]" + m1.Groups[1] + "[/attach]");
                //            continue;
                //        }

                //        string attachPath = m.Groups[2].ToString().ToLower().Replace("viewfile.asp?id", "attachment.aspx?attachmentid");
                //        if (attachPath.IndexOf("attachment.aspx?attachmentid") == -1)
                //        {
                //            attachPath = BaseConfigs.GetForumPath + "upload/" + attachPath;
                //        }
                //        else
                //        {
                //            attachPath = BaseConfigs.GetForumPath + attachPath;
                //        }

                //        if (_postpramsinfo.Showimages == 1)
                //        {
                //            sDetail = sDetail.Replace(m.Groups[0].ToString(), "<img src=\"" + attachPath + "\" border=\"0\" onload=\"if(this.width>screen.width*0.7) {this.resized=true; this.width=screen.width*0.7; this.alt=\'点击在新窗口浏览图片\\nCTRL+Mouse 滚轮可放大/缩小\';}\" onmouseover=\"if(this.width>screen.width*0.7) {this.resized=true; this.width=screen.width*0.7; this.style.cursor=\'hand\'; this.alt=\'点击在新窗口浏览图片\\nCTRL+Mouse 滚轮可放大/缩小\';}\" onclick=\"if(!this.resized) {return true;} else {window.open(this.src);}\" onmousewheel=\"return imgzoom(this);\" />");
                //        }
                //        else
                //        {
                //            replacement = attachPath;
                //            if (replacement.LastIndexOf("/") > 0)
                //            {
                //                replacement = Utils.CutString(replacement, replacement.LastIndexOf("/"));
                //            }
                //            replacement = string.Format(attachCode, attachIcon, attachPath, replacement);
                //            sDetail = sDetail.Replace(m.Groups[0].ToString(), replacement);
                //        }
                //    }

                //    sDetail = Regex.Replace(sDetail, @"\[uploadfile\](\d{1,})\[/uploadfile\]", "[attach]$1[/attach]", options);

                //    replacement = "";
                //    for (m = r[5].Match(sDetail); m.Success; m = m.NextMatch())
                //    {
                //        Match m1 = r[6].Match(m.Groups[2].ToString().ToLower());
                //        if (m1.Success)
                //        {
                //            sDetail = sDetail.Replace(m.Groups[0].ToString(), "[attach]" + m1.Groups[1] + "[/attach]");
                //            continue;
                //        }

                //        replacement = m.Groups[2].ToString().ToLower().Replace("viewfile.asp?id", "attachment.aspx?attachmentid");
                //        if (replacement.IndexOf("attachment.aspx?attachmentid") == -1)
                //        {
                //            replacement = BaseConfigs.GetForumPath + "upload/" + replacement;
                //        }
                //        else
                //        {
                //            replacement = BaseConfigs.GetForumPath + replacement;
                //        }

                //        if (replacement.LastIndexOf("/") > 0)
                //        {
                //            replacement = Utils.CutString(replacement, replacement.LastIndexOf("/"));
                //        }
                //        replacement = string.Format(attachCode, attachIcon, BaseConfigs.GetForumPath + m.Groups[2].ToString().ToLower().Replace("viewfile.asp?id", "attachment.aspx?attachmentid"), replacement);
                //        sDetail = sDetail.Replace(m.Groups[0].ToString(), replacement);
                //    }

                //    sDetail = Regex.Replace(sDetail, @"\[upload\](\d{1,})\[/upload\]", "[attach]$1[/attach]", options);

                //    //[upload].*[/upload]
                //    replacement = "";
                //    for (m = r[7].Match(sDetail); m.Success; m = m.NextMatch())
                //    {
                //        Match m1 = r[8].Match(m.Groups[2].ToString().ToLower());
                //        if (m1.Success)
                //        {
                //            sDetail = sDetail.Replace(m.Groups[0].ToString(), "[attach]" + m1.Groups[1] + "[/attach]");
                //            continue;
                //        }

                //        replacement = BaseConfigs.GetForumPath + m.Groups[2].ToString().ToLower().Replace("viewfile.asp?id", "attachment.aspx?attachmentid");
                //        if (replacement.IndexOf("attachment.aspx?attachmentid") == -1)
                //        {
                //            replacement = BaseConfigs.GetForumPath + "upload/" + replacement;
                //        }
                //        else
                //        {
                //            replacement = BaseConfigs.GetForumPath + replacement;
                //        }

                //        if (replacement.LastIndexOf("/") > 0)
                //        {
                //            replacement = Utils.CutString(replacement, replacement.LastIndexOf("/"));
                //        }
                //        replacement = string.Format(attachCode, attachIcon, BaseConfigs.GetForumPath + m.Groups[2].ToString().ToLower().Replace("viewfile.asp?id", "attachment.aspx?attachmentid"), replacement);
                //        sDetail = sDetail.Replace(m.Groups[0].ToString(), replacement);
                //    }
                //}
                //yhl ==begin==
                #endregion
            }

            #region 将网址字符串转换为链接

            if (_postpramsinfo.Parseurloff == 0)
            {
                sDetail = sDetail.Replace("&amp;", "&");

                // p2p link
                sDetail = Regex.Replace(sDetail, @"^((tencent|ed2k|thunder|vagaa):\/\/[\[\]\|A-Za-z0-9\.\/=\?%\-&_~`@':+!]+)", "<a target=\"_blank\" href=\"$1\">$1</a>", options);
                sDetail = Regex.Replace(sDetail, @"((tencent|ed2k|thunder|vagaa):\/\/[\[\]\|A-Za-z0-9\.\/=\?%\-&_~`@':+!]+)$", "<a target=\"_blank\" href=\"$1\">$1</a>", options);
                sDetail = Regex.Replace(sDetail, @"[^>=\]""]((tencent|ed2k|thunder|vagaa):\/\/[\[\]\|A-Za-z0-9\.\/=\?%\-&_~`@':+!]+)", "<a target=\"_blank\" href=\"$1\">$1</a>", options);
            }

            #endregion


            #region 处理[img][/img]标记

            if (_postpramsinfo.Showimages == 1)
                sDetail = ParseImg(sDetail, _postpramsinfo.Signature);

            #endregion

            pcodecount = 0;
            foreach (string str in Utils.SplitString(sb.ToString(), "<>"))
            {
                sDetail = sDetail.Replace("[\tDISCUZ_CODE_" + prefix + "_" + pcodecount.ToString() + "\t]", str);
                pcodecount++;
            }

            // [r/]
            sDetail = Regex.Replace(sDetail, @"\[r/\]", "\r", options);

            // [n/]
            sDetail = Regex.Replace(sDetail, @"\[n/\]", "\n", options);

            #region 处理换行

            //处理换行,在每个新行的前面添加两个全角空格
            //for (m = r[9].Match(sDetail); m.Success; m = m.NextMatch())
            //{
            //    sDetail = sDetail.Replace(m.Groups[0].ToString(), "<br/>&nbsp;&nbsp;&nbsp;&nbsp;" + m.Groups["正文"].ToString());
            //}

            if (_postpramsinfo.Allowhtml == 0)
            {
                sDetail = sDetail.Replace("\r\n", "<br/>");
                sDetail = sDetail.Replace("\r", "");
                sDetail = sDetail.Replace("\n\n", "<br/><br/>");
                sDetail = sDetail.Replace("\n", "<br/>");
                sDetail = sDetail.Replace("{rn}", "\r\n");
                sDetail = sDetail.Replace("{nn}", "\n\n");
                sDetail = sDetail.Replace("{r}", "\r");
                sDetail = sDetail.Replace("{n}", "\n");
            }
            #endregion

            #region 处理空格

            sDetail = sDetail.Replace("\t", "&nbsp;&nbsp;&nbsp;&nbsp;");
            sDetail = sDetail.Replace("  ", "&nbsp;&nbsp;");

            #endregion


            #region 处理[hr]标记
            sDetail = Regex.Replace(sDetail, @"\[hr\]", "<hr/>", options);
            #endregion
            #region 处理小图片
            sDetail =   parseEmot(sDetail);
            #endregion
            return sDetail;
        }
        /// <summary>
        /// 处理img标记
        /// </summary>
        /// <param name="sDetail"></param>
        /// <returns></returns>
        private static string ParseImg(string sDetail, int Signature)
        {
            if (Signature == 1)
            {
                sDetail = Regex.Replace(sDetail, @"\[img\]\s*([^\[\<\r\n]+?)\s*\[\/img\]", IMG_SIGN_SIGNATURE, options);
                //sDetail = Regex.Replace(sDetail, @"\[img\]\s*(http://[^\[\<\r\n]+?)\s*\[\/img\]", IMG_SIGN_SIGNATURE, options);
            }
            else
            {
                sDetail = Regex.Replace(sDetail, @"\[img\]\s*([^\[\<\r\n]+?)\s*\[\/img\]", IMG_SIGN, options);

                //sDetail = Regex.Replace(sDetail, @"\[img\]\s*(http://[^\[\<\r\n]+?)\s*\[\/img\]", IMG_SIGN, options);
            }

            sDetail = Regex.Replace(sDetail, @"\[img=(\d{1,4})[x|\,](\d{1,4})\]\s*([^\[\<\r\n]+?)\s*\[\/img\]", "<img src=\"$3\" width=\"$1\" height=\"$2\" border=\"0\" onload=\"thumbImg(this)\" />", options).Replace("width=\"0\"", "").Replace("height=\"0\"", "");

            //sDetail = Regex.Replace(sDetail, @"\[img=(\d{1,4})[x|\,](\d{1,4})\]\s*(http://[^\[\<\r\n]+?)\s*\[\/img\]", "<img src=\"$3\" width=\"$1\" height=\"$2\" border=\"0\" onload=\"thumbImg(this)\" />", options);
            sDetail = Regex.Replace(sDetail, @"\[image\]([\s\S]+?)\[/image\]", "<img src=\"$1\" border=\"0\" />", options);

            //sDetail = Regex.Replace(sDetail, @"\[image\](http://[\s\S]+?)\[/image\]", "<img src=\"$1\" border=\"0\" />", options);
            return sDetail;
        }

        /// <summary>
        /// 处理B标记
        /// </summary>
        /// <param name="sDetail"></param>
        /// <returns></returns>
        private static string parseBold(string sDetail)
        {
            sDetail = Regex.Replace(sDetail, @"\[b(?:\s*)\]", "<b>", options);
            sDetail = Regex.Replace(sDetail, @"\[i(?:\s*)\]", "<i>", options);
            sDetail = Regex.Replace(sDetail, @"\[s(?:\s*)\]", "<s>", options);

            sDetail = Regex.Replace(sDetail, @"\[u(?:\s*)\]", "<u>", options);

            sDetail = Regex.Replace(sDetail, @"\[/b(?:\s*)\]", "</b>", options);
            sDetail = Regex.Replace(sDetail, @"\[/i(?:\s*)\]", "</i>", options);
            sDetail = Regex.Replace(sDetail, @"\[/u(?:\s*)\]", "</u>", options);

            sDetail = Regex.Replace(sDetail, @"\[/s(?:\s*)\]", "</s>", options);
            return sDetail;
        }

        /// <summary>
        /// 处理Font标记
        /// </summary>
        /// <param name="sDetail"></param>
        /// <returns></returns>
        private static string parseFont(string sDetail)
        {
            sDetail = Regex.Replace(sDetail, @"\[color=([^\[\<]+?)\]", "<font color=\"$1\">", options);
            sDetail = Regex.Replace(sDetail, @"\[size=(\d+?)\]", "<font size=\"$1\">", options);
            sDetail = Regex.Replace(sDetail, @"\[size=(\d+(\.\d+)?(px|pt|in|cm|mm|pc|em|ex|%)+?)\]", "<font style=\"font-size: $1\">", options);
            sDetail = Regex.Replace(sDetail, @"\[font=([^\[\<]+?)\]", "<font face=\"$1\">", options);
            sDetail = Regex.Replace(sDetail, @"\[align=([^\[\<]+?)\]", "<p align=\"$1\">", options);
            sDetail = Regex.Replace(sDetail, @"\[float=(left|right)\]", "<br style=\"clear: both\"><span style=\"float: $1;\">", options);
            sDetail = Regex.Replace(sDetail, @"\[/color(?:\s*)\]", "</font>", options);
            sDetail = Regex.Replace(sDetail, @"\[/size(?:\s*)\]", "</font>", options);
            sDetail = Regex.Replace(sDetail, @"\[/font(?:\s*)\]", "</font>", options);
            sDetail = Regex.Replace(sDetail, @"\[/align(?:\s*)\]", "</p>", options);
            sDetail = Regex.Replace(sDetail, @"\[/float(?:\s*)\]", "</span>", options);
           
            sDetail = Regex.Replace(sDetail, @"\[back=([^\[\<]+?)\]", "<span style=\"background-color:$1\">", options);
            sDetail = Regex.Replace(sDetail, @"\[/back(?:\s*)\]", "</span>", options);

          
            return sDetail;
        }
        /// <summary>
        /// 处理小图片
        /// </summary>
        /// <param name="sDetail"></param>
        /// <returns></returns>
        private  static  string parseEmot(string sDetail)
        {
            //[emot=default,smile/] 
            //<img emot="default,smile" alt="微笑" src="js/plugin/editbox/xheditor_emot/default/smile.gif" />
           sDetail = Regex.Replace(sDetail, @"\[emot=.*\]", "<img emot=$0 src=\"js/plugin/editbox/xheditor_emot/default/smile.gif\" />", options);  
            //    sHtml=sHtml.replace(/\[emot\s*=\s*([^\]"]+?)(?:"[^\]]*?)?\s*\/\]/ig,function(all,emot){
            //    emot=emot.split(',');
            //    if(!emot[1]){emot[1]=emot[0];emot[0]='default';}
            //    return '<img src="'+emotPath+emot[0]+'/'+emot[1]+'.gif" alt="'+emot[1]+'" />';
            //});
            return sDetail;
        }
        /// <summary>
        /// 处理URL标记
        /// </summary>
        /// <param name="sDetail"></param>
        /// <returns></returns>
        public static string ParseUrl(string sDetail)
        {
            sDetail = Regex.Replace(sDetail, @"\[url(?:\s*)\](www\.(.*?))\[/url(?:\s*)\]", "<a href=\"http://$1\" target=\"_blank\">$1</a>", options);
            sDetail = Regex.Replace(sDetail, @"\[url(?:\s*)\]\s*(([^\[""']+?))\s*\[\/url(?:\s*)\]", "<a href=\"$1\" target=\"_blank\">$1</a>", options);

            //sDetail = Regex.Replace(sDetail, @"\[url(?:\s*)\]\s*((https?://|ftp://|gopher://|news://|telnet://|rtsp://|mms://|callto://|bctp://|ed2k://|tencent)([^\[""']+?))\s*\[\/url(?:\s*)\]", "<a href=\"$1\" target=\"_blank\">$1</a>", options);
            sDetail = Regex.Replace(sDetail, @"\[url=www.([^\[""']+?)(?:\s*)\]([\s\S]+?)\[/url(?:\s*)\]", "<a href=\"http://www.$1\" target=\"_blank\">$2</a>", options);
            sDetail = Regex.Replace(sDetail, @"\[url=(([^\[""']+?))(?:\s*)\]([\s\S]+?)\[/url(?:\s*)\]", "<a href=\"$1\" target=\"_blank\">$3</a>", options);

            //sDetail = Regex.Replace(sDetail, @"\[url=((https?://|ftp://|gopher://|news://|telnet://|rtsp://|mms://|callto://|bctp://|ed2k://|tencent://)([^\[""']+?))(?:\s*)\]([\s\S]+?)\[/url(?:\s*)\]", "<a href=\"$1\" target=\"_blank\">$4</a>", options);
            return sDetail;
        }

        /// <summary>
        /// 替换版规中UBB的方法
        /// </summary>
        /// <param name="sDetail"></param>
        /// <returns></returns>
        public static string ParseSimpleUBB(string sDetail)
        {
            sDetail = ParseImg(sDetail, 0);
            sDetail = parseFont(sDetail);
            sDetail = parseBold(sDetail);
            sDetail = ParseUrl(sDetail);
            return sDetail;
        }




        /// <summary>
        /// 转换表格
        /// </summary>
        /// <param name="str">帖子内容</param>
        /// <returns>帖子内容</returns>
        private static string ParseTable(string str)
        {
            Match m;
            string stable = "";
            string width = "";
            string bgcolor = "";
            int intTableIndexOf = str.ToLower().IndexOf("[table");

            while (intTableIndexOf >= 0 && str.ToLower().IndexOf("[/table]") >= 0)
            {
                for (m = r[11].Match(str); m.Success; m = m.NextMatch())
                {
                    width = m.Groups[1].ToString();
                    width = Utils.CutString(width, width.Length - 1, width.Length).Equals("%") ? (Utils.StrToInt(Utils.CutString(width, 0, width.Length - 1), 100) <= 98 ? width : "98%") : (Utils.StrToInt(width, 560) <= 560 ? width : "560");

                    bgcolor = m.Groups[2].ToString();

                    stable = "<table class=\"t_table\" cellspacing=\"1\" cellpadding=\"4\" style=\"";
                    stable += width.Equals("") ? "" : ("width:" + width + ";");
                    stable += "".Equals(bgcolor) ? "" : ("background: " + bgcolor + ";");
                    stable += "\">";


                    width = m.Groups[3].ToString();
                    width = Regex.Replace(width, @"\[td=(\d{1,2}),(\d{1,2})(,(\d{1,4}%?))?\]", "<td colspan=\"$1\" rowspan=\"$2\" width=\"$4\" class=\"t_table\">", options);
                    width = Regex.Replace(width, @"\[tr\]", "<tr>", options);
                    width = Regex.Replace(width, @"\[td\]", "<td>", options);
                    width = Regex.Replace(width, @"\[\/td\]", "</td>", options);
                    width = Regex.Replace(width, @"\[\/tr\]", "</tr>", options);
                    width = Regex.Replace(width, @"\<td\>\<\/td\>", "<td>&nbsp;</td>", options);

                    stable += width;
                    stable += "</table>";

                    str = str.Replace(m.Groups[0].ToString(), stable);
                }
                intTableIndexOf = str.ToLower().IndexOf("[table", intTableIndexOf + 7);
            }

            return str;
        }


        /// <summary>
        /// 转换code标签
        /// </summary>
        /// <param name="text">帖子内容</param>
        /// <param name="pcodecount">code的数量</param>
        /// <param name="builder">转换后的内容</param>
        /// <returns>帖子内容</returns>
        private static string Parsecode(string text, string prefix, ref int pcodecount, int allowhtml, ref StringBuilder builder)
        {
            text = Regex.Replace(text, @"^[\n\r]*([\s\S]+?)[\n\r]*$", "$1", options);

            if (!builder.ToString().Equals(""))
            {
                builder.Append("<>");
            }
            builder.Append("<div class=\"blockcode\"><div id=\"code" + prefix + "_" + pcodecount.ToString() + "\"><ol>");
            foreach (string str in Utils.SplitString(text, "\r\n"))
            {
                //解决Firefox下复制代码无换行的问题
                if (allowhtml == 0)
                    builder.Append("<li>" + str + "<br/></li>{rn}");
                else
                    builder.Append("<li>" + str + "<br/></li>\r\n");
            }
            builder.Append("</ol></div><em onclick=\"copycode($('code" + prefix + "_" + pcodecount.ToString() + "'));\">复制代码</em></div>");

            pcodecount++;
            text = "[\tDISCUZ_CODE_" + prefix + "_" + pcodecount.ToString() + "\t]";
            return text;
        }

        public static string ParseMedia(string type, int width, int height, bool autostart, string url)
        {
            if (!Utils.InArray(type, "ra,rm,wma,wmv,mp3,mov"))
                return "";
            url = url.Replace("\\\\", "\\").Replace("<", string.Empty).Replace(">", string.Empty);
            Random r = new Random(3);
            string mediaid = "media_" + r.Next();
            switch (type)
            {
                case "ra":
                    return string.Format(@"<object classid=""clsid:CFCDAA03-8BE4-11CF-B84B-0020AFBBCCFA"" width=""{0}"" height=""32""><param name=""autostart"" value=""{1}"" /><param name=""src"" value=""{2}"" /><param name=""controls"" value=""controlpanel"" /><param name=""console"" value=""{3}_"" /><embed src=""{2}"" type=""audio/x-pn-realaudio-plugin"" controls=""ControlPanel"" {4} console=""{3}_"" width=""{0}"" height=""32""></embed></object>", width, autostart ? 1 : 0, url, mediaid, autostart ? "autostart=\"true\"" : string.Empty);
                case "rm":
                    return string.Format(@"<object classid=""clsid:CFCDAA03-8BE4-11cf-B84B-0020AFBBCCFA"" width=""{0}"" height=""{1}""><param name=""autostart"" value=""{2}"" /><param name=""src"" value=""{3}"" /><param name=""controls"" value=""imagewindow"" /><param name=""console"" value=""{4}_"" /><embed src=""{3}"" type=""audio/x-pn-realaudio-plugin"" controls=""IMAGEWINDOW"" console=""{4}_"" width=""{0}"" height=""{1}""></embed></object><br /><object classid=""clsid:CFCDAA03-8BE4-11CF-B84B-0020AFBBCCFA"" width=""{0}"" height=""32""><param name=""src"" value=""{3}"" /><param name=""controls"" value=""controlpanel"" /><param name=""console"" value=""{4}_"" /><embed src=""{3}"" type=""audio/x-pn-realaudio-plugin"" controls=""ControlPanel"" {5} console=""{4}_"" width=""{0}"" height=""32""></embed></object>", width, height, autostart ? 1 : 0, url, mediaid, autostart ? "autostart=\"true\"" : string.Empty);
                case "wma":
                    return string.Format(@"<object classid=""clsid:6BF52A52-394A-11d3-B153-00C04F79FAA6"" width=""{0}"" height=""64""><param name=""autostart"" value=""{1}"" /><param name=""url"" value=""{2}"" /><embed src=""{2}"" autostart=""{1}"" type=""audio/x-ms-wma"" width=""{0}"" height=""64""></embed></object>", width, autostart ? 1 : 0, url);
                case "wmv":
                    return string.Format(@"<object classid=""clsid:6BF52A52-394A-11d3-B153-00C04F79FAA6"" width=""{0}"" height=""{1}""><param name=""autostart"" value=""{2}"" /><param name=""url"" value=""{3}"" /><embed src=""{3}"" autostart=""{2}"" type=""video/x-ms-wmv"" width=""{0}"" height=""{1}""></embed></object>", width, height, autostart ? 1 : 0, url);
                case "mp3":
                    return string.Format(@"<object classid=""clsid:6BF52A52-394A-11d3-B153-00C04F79FAA6"" width=""{0}"" height=""64""><param name=""autostart"" value=""{1}""/><param name=""url"" value=""{2}"" /><embed src=""{2}"" autostart=""{1}"" type=""application/x-mplayer2"" width=""{0}"" height=""64""></embed></object>", width, autostart ? 1 : 0, url);
                case "mov":
                    return string.Format(@"<object classid=""clsid:02BF25D5-8C17-4B23-BC80-D3488ABDDC6B"" width=""{0}"" height=""{1}""><param name=""autostart"" value=""{2}"" /><param name=""src"" value=""{3}"" /><embed controller=""true"" width=""{0}"" height=""{1}"" src=""{3}"" autostart=""{2}""></embed></object>", width, height, autostart.ToString().ToLower(), url);
            }

            return string.Empty;
        }

        public static string ParseAudio(string autostart, string url)
        {
            return string.Format(@"<object width=""400"" height=""64"" classid=""clsid:6BF52A52-394A-11d3-B153-00C04F79FAA6""><param value=""0"" name=""invokeURLs""><param value=""{0}"" name=""autostart""><param value=""{1}"" name=""url""><embed width=""400"" height=""64"" type=""application/x-mplayer2"" autostart=""{0}"" src=""{1}""></object>", autostart != "" ? "1" : "0", url);
        }

        public static string ParseP(string lineHeight, string textIndent, string textAlign, string content)
        {
            return string.Format(@"<p style=""line-height: {0}px; text-indent: {1}em; text-align: {2};"">{3}</p>", lineHeight, textIndent, textAlign, content);
        }

        public static string ParseFlash(string flashWidth, string flashHeight, string flashUrl)
        {
            flashWidth = flashWidth == "" ? "550" : flashWidth;
            flashHeight = flashHeight == "" ? "400" : flashHeight;
            return string.Format(@"<script reload=""1"" type=""text/javascript"">document.write(AC_FL_RunContent('width', '{0}', 'height', '{1}', 'allowNetworking', 'internal', 'allowScriptAccess', 'never', 'src', '{2}', 'quality', 'high', 'bgcolor', '#ffffff', 'wmode', 'transparent', 'allowfullscreen', 'true'));</script>", flashWidth, flashHeight, flashUrl);
        }

        /// <summary>
        /// 该方法已被抽到Utils类中
        /// </summary>
        /// <param name="sDetail">帖子内容</param>
        /// <returns>帖子内容</returns>
        public static string ClearUBB(string sDetail)
        {
            return Regex.Replace(sDetail, @"\[[^\]]*?\]", string.Empty, RegexOptions.IgnoreCase);
        }

        /// <summary>
        /// 清除UBB标签
        /// </summary>
        /// <param name="sDetail">帖子内容</param>
        /// <returns>帖子内容</returns>
        public static string ClearBR(string sDetail)
        {
            return Regex.Replace(sDetail, @"[\r\n]", string.Empty, RegexOptions.IgnoreCase);
        }

        /// <summary>
        /// 清除[attach][attachimg]标签
        /// </summary>
        /// <param name="sDetail"></param>
        /// <returns></returns>
        public static string ClearAttachUBB(string sDetail)
        {
            sDetail = r[13].Replace(sDetail, string.Empty);
            return r[14].Replace(sDetail, string.Empty);
        }
    }


    /// <summary>
    /// PostpramsInfo 的摘要说明。
    /// </summary>
    public class PostpramsInfo
    {


        /// <summary>
        /// 以下为ubb转换专用属性
        /// </summary>
        private string sdetail;		//帖子内容
        private int smileyoff;		//禁止笑脸显示.
        private int bbcodeoff;		//禁止Discuz!NT代码转换
        private int parseurloff;	//禁止网址自动转换
        private int showimages;		//是否对帖子中的图片标签进行解析.
        private int allowhtml;		//是否允许解析html标签.
        // private SmiliesInfo[] smiliesinfo;	//表情库
        // private CustomEditorButtonInfo[] customeditorbuttoninfo; ///自定义按钮图库
        private int smiliesmax;		//帖子中解析的单个表情最大个数.
        private int bbcodemode;		//Discuz!NT代码兼容模式(0:不兼容,1:动网兼容)
        private int signature;		//是否为签名，用于签名ubb转换



        /// <summary>
        /// 以下为ubb转换专用属性
        /// </summary>

        /// <summary>
        /// 帖子内容
        /// </summary>
        public string Sdetail
        {
            get { return sdetail == null ? "" : sdetail; }
            set { sdetail = value; }
        }

        /// <summary>
        /// 禁止笑脸显示.
        /// </summary>
        public int Smileyoff
        {
            get { return smileyoff; }
            set { smileyoff = value; }
        }

        /// <summary>
        /// 禁止ubb转换
        /// </summary>
        public int Bbcodeoff
        {
            get { return bbcodeoff; }
            set { bbcodeoff = value; }
        }

        /// <summary>
        /// 禁止网址自动转换
        /// </summary>
        public int Parseurloff
        {
            get { return parseurloff; }
            set { parseurloff = value; }
        }

        /// <summary>
        /// 是否对帖子中的图片标签进行解析.
        /// </summary>
        public int Showimages
        {
            get { return showimages; }
            set { showimages = value; }
        }

        /// <summary>
        /// 是否允许解析html标签.
        /// </summary>
        public int Allowhtml
        {
            get { return allowhtml; }
            set { allowhtml = value; }
        }

        ///// <summary>
        ///// 表情库
        ///// </summary>
        //public SmiliesInfo[] Smiliesinfo
        //{
        //    get { return smiliesinfo; }
        //    set { smiliesinfo = value; }
        //}

        ///// <summary>
        ///// 自定义按钮图库
        ///// </summary>
        //public CustomEditorButtonInfo[] Customeditorbuttoninfo
        //{
        //    get { return customeditorbuttoninfo; }
        //    set { customeditorbuttoninfo = value; }
        //}

        /// <summary>
        /// 帖子中解析的单个表情最大个数.
        /// </summary>
        public int Smiliesmax
        {
            get { return smiliesmax; }
            set { smiliesmax = value; }
        }

        /// <summary>
        /// Discuz代码兼容模式(0:不兼容,1:动网兼容)
        /// </summary>
        public int Bbcodemode
        {
            get { return bbcodemode; }
            set { bbcodemode = value; }
        }
        /// <summary>
        /// 是否为签名
        /// </summary>
        public int Signature
        {
            get { return signature; }
            set { signature = value; }
        }
    }
}