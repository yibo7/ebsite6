using System;
using System.Collections.Generic;
using System.IO;
using EbSite.Core.Strings;

namespace EbSite.BLL
{
    public class HtmlReNameRule
    {
        static private string HtmlYear = "{#Year#}";
        static private string HtmlMonth = "{#Month#}";
        static private string HtmlDay = "{#Day#}";
        static private string HtmlHour = "{#Hour#}";
        static private string HtmlMinute = "{#Minute#}";
        static private string HtmlSecond = "{#Second#}";
        static private string HtmlTitleSpell = "{#TitleSpell#}";
        static private string HtmlRandNum = "{#RandNum#}";
        static private string HtmlRandFileName = "{#RandFileName#}";
        static private string HtmlClassTitleSpell = "{#ClassTitleSpell#}";
        //static public string PageNumber = "{#PageNumber#}";
        static public string KeyID = "{#KeyID#}";
        
        static HtmlReNameRule()
        {
            BindClassList();
        }

        static private void BindClassList()
        {
            if (lst.Count < 1)
            {
                KeyValueModel fbi;

                fbi = new KeyValueModel();
                fbi.Key = HtmlYear;
                fbi.Name = "年(适用所有)";
                lst.Add(fbi);

                fbi = new KeyValueModel();
                fbi.Key = HtmlMonth;
                fbi.Name = "月(适用所有)";
                lst.Add(fbi);

                fbi = new KeyValueModel();
                fbi.Key = HtmlDay;
                fbi.Name = "日(适用所有)";
                lst.Add(fbi);

                fbi = new KeyValueModel();
                fbi.Key = HtmlHour;
                fbi.Name = "小时(适用所有)";
                lst.Add(fbi);

                fbi = new KeyValueModel();
                fbi.Key = HtmlMinute;
                fbi.Name = "分钟(适用所有)";
                lst.Add(fbi);

                fbi = new KeyValueModel();
                fbi.Key = HtmlSecond;
                fbi.Name = "秒钟(适用所有)";
                lst.Add(fbi);

                fbi = new KeyValueModel();
                fbi.Key = HtmlTitleSpell;
                fbi.Name = "标题拼音(适用所有)";
                lst.Add(fbi);

                fbi = new KeyValueModel();
                fbi.Key = HtmlRandNum;
                fbi.Name = "随机数字(5位)(适用所有)";
                lst.Add(fbi);

                fbi = new KeyValueModel();
                fbi.Key = HtmlRandFileName;
                fbi.Name = "随机文件名(适用所有)";
                lst.Add(fbi);

                fbi = new KeyValueModel();
                fbi.Key = "/";
                fbi.Name = "目录分隔(/)(适用所有)";
                lst.Add(fbi);

                fbi = new KeyValueModel();
                fbi.Key = "-";
                fbi.Name = "中连线(-)(适用所有)";
                lst.Add(fbi);

                fbi = new KeyValueModel();
                fbi.Key = "_";
                fbi.Name = "下连线(_)(适用所有)";
                lst.Add(fbi);

                fbi = new KeyValueModel();
                fbi.Key = HtmlClassTitleSpell;
                fbi.Name = "分类拼音(适用内容)";
                lst.Add(fbi);

                //fbi = new KeyValueModel();
                //fbi.Key = PageNumber;
                //fbi.Name = "分页码(适用分类)";
                //lst.Add(fbi);

                fbi = new KeyValueModel();
                fbi.Key = KeyID;
                fbi.Name = "唯一ID(适用所有)";
                lst.Add(fbi);
            }
        }
        static public string GetName(string sRule, string Title)
        {
            return GetName(sRule, Title,"");
        }

        /// <summary>
        /// 根据命名规则获取文件名
        /// </summary>
        /// <param name="sRule">命名规则</param>
        /// <param name="Title">标题</param>
        /// <param name="sClassTitle">分类名称</param>
        /// <returns></returns>
        static public string GetName(string sRule, string Title, string sClassTitle)
        {
            string sValue = string.Empty;

            if(!string.IsNullOrEmpty(sRule))
            {
                sValue = sRule;
                DateTime _DateTime = DateTime.Now;
                string year = (_DateTime.Year).ToString();
                string month = (_DateTime.Month).ToString();
                string day = (_DateTime.Day).ToString();
                string hour = (_DateTime.Hour).ToString();
                string minute = (_DateTime.Minute).ToString();
                string second = (_DateTime.Second).ToString();

                sValue = sValue.Replace(HtmlYear, year);
                sValue = sValue.Replace(HtmlMonth, month);
                sValue = sValue.Replace(HtmlDay, day);
                sValue = sValue.Replace(HtmlHour, hour);
                sValue = sValue.Replace(HtmlMinute, minute);
                sValue = sValue.Replace(HtmlSecond, second);
                sValue = sValue.Replace(HtmlTitleSpell, GetTitleSpell(Title));
                sValue = sValue.Replace(HtmlRandNum, GetRandNum().ToString());
                sValue = sValue.Replace(HtmlRandFileName, Path.GetRandomFileName());
                if (!string.IsNullOrEmpty(sClassTitle))
                    sValue = sValue.Replace(HtmlClassTitleSpell, GetTitleSpell(sClassTitle));
                
            }

            return sValue.ToLower();

        }
        static private int GetRandNum()
        {
            int min = 10000;
            int max = 99999;
            Random a = new Random();
            int result = a.Next(min, max);

            return result;

        }
        static private string GetTitleSpell(string Title)
        {
            if (string.IsNullOrEmpty(Title)) return string.Empty;

            //return stCommon.Strings.cConvert.QuanPing(Title);

            return GetString.CutLen(cConvert.GetQuanPing(Title), 20);

        }

        static public List<KeyValueModel> lst = new List<KeyValueModel>();


        
    
    }
}
