//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Configuration;
//using System.IO;
//using System.Linq;
//using System.Web;
//using System.Web.Security;
//using System.Web.UI;
//using System.Web.UI.HtmlControls;
//using System.Web.UI.WebControls;
//using System.Web.UI.WebControls.WebParts;
//using System.Xml.Linq;

//namespace EbSite.Core
//{
//    public class HtmlReNameRule
//    {
//        static private string HtmlYear = "{#Year#}";
//        static private string HtmlMonth = "{#Month#}";
//        static private string HtmlDay = "{#Day#}";
//        static private string HtmlHour = "{#Hour#}";
//        static private string HtmlMinute = "{#Minute#}";
//        static private string HtmlSecond = "{#Second#}";
//        static private string HtmlTitleSpell = "{#TitleSpell#}";
//        static private string HtmlRandNum = "{#RandNum#}";
//        static private string HtmlRandFileName = "{#RandFileName#}";
//        static private string HtmlClassPath = "{#ClassPath#}";
//        static public string PageNumber = "{#PageNumber#}";
//        static public string KeyID = "{#KeyID#}";
        
//        static HtmlReNameRule()
//        {
//            BindClassList();
//        }

//        static private void BindClassList()
//        {
//            if (lst.Count < 1)
//            {
//                KeyValueModel fbi;

//                fbi = new KeyValueModel();
//                fbi.Key = HtmlYear;
//                fbi.Name = "年(适用所有)";
//                lst.Add(fbi);

//                fbi = new KeyValueModel();
//                fbi.Key = HtmlMonth;
//                fbi.Name = "月(适用所有)";
//                lst.Add(fbi);

//                fbi = new KeyValueModel();
//                fbi.Key = HtmlDay;
//                fbi.Name = "日(适用所有)";
//                lst.Add(fbi);

//                fbi = new KeyValueModel();
//                fbi.Key = HtmlHour;
//                fbi.Name = "小时(适用所有)";
//                lst.Add(fbi);

//                fbi = new KeyValueModel();
//                fbi.Key = HtmlMinute;
//                fbi.Name = "分钟(适用所有)";
//                lst.Add(fbi);

//                fbi = new KeyValueModel();
//                fbi.Key = HtmlSecond;
//                fbi.Name = "秒钟(适用所有)";
//                lst.Add(fbi);

//                fbi = new KeyValueModel();
//                fbi.Key = HtmlTitleSpell;
//                fbi.Name = "标题拼音(适用所有)";
//                lst.Add(fbi);

//                fbi = new KeyValueModel();
//                fbi.Key = HtmlRandNum;
//                fbi.Name = "随机数字(5位)(适用所有)";
//                lst.Add(fbi);

//                fbi = new KeyValueModel();
//                fbi.Key = HtmlRandFileName;
//                fbi.Name = "随机文件名(适用所有)";
//                lst.Add(fbi);

//                fbi = new KeyValueModel();
//                fbi.Key = "/";
//                fbi.Name = "目录分隔(/)(适用所有)";
//                lst.Add(fbi);

//                fbi = new KeyValueModel();
//                fbi.Key = "-";
//                fbi.Name = "中连线(-)(适用所有)";
//                lst.Add(fbi);

//                fbi = new KeyValueModel();
//                fbi.Key = "_";
//                fbi.Name = "下连线(_)(适用所有)";
//                lst.Add(fbi);

//                fbi = new KeyValueModel();
//                fbi.Key = HtmlClassPath;
//                fbi.Name = "分类目录(适用内容)";
//                lst.Add(fbi);

//                fbi = new KeyValueModel();
//                fbi.Key = PageNumber;
//                fbi.Name = "分页码(适用分类)";
//                lst.Add(fbi);

//                fbi = new KeyValueModel();
//                fbi.Key = KeyID;
//                fbi.Name = "唯一ID(适用所有)";
//                lst.Add(fbi);
//            }
//        }
//        /// <summary>
//        /// 根据命名规则获取文件名
//        /// </summary>
//        /// <param name="sRule">命名规则</param>
//        /// <param name="Title">标题</param>
//        /// <param name="sClassPath">内容面页所在分类的保存路径，只适用于内容页</param>
//        /// <returns></returns>
//        static public string GetName(string sRule, string Title, string sClassPath)
//        {
//            string sValue = string.Empty;

//            if(!string.IsNullOrEmpty(sRule))
//            {
//                sValue = sRule;
//                DateTime _DateTime = DateTime.Now;
//                string year = (_DateTime.Year).ToString();
//                string month = (_DateTime.Month).ToString();
//                string day = (_DateTime.Day).ToString();
//                string hour = (_DateTime.Hour).ToString();
//                string minute = (_DateTime.Minute).ToString();
//                string second = (_DateTime.Second).ToString();

//                sValue = sValue.Replace(HtmlYear, year);
//                sValue = sValue.Replace(HtmlMonth, month);
//                sValue = sValue.Replace(HtmlDay, day);
//                sValue = sValue.Replace(HtmlHour, hour);
//                sValue = sValue.Replace(HtmlMinute, minute);
//                sValue = sValue.Replace(HtmlSecond, second);
//                sValue = sValue.Replace(HtmlTitleSpell, GetTitleSpell(Title));
//                sValue = sValue.Replace(HtmlRandNum, GetRandNum().ToString());
//                sValue = sValue.Replace(HtmlRandFileName, Path.GetRandomFileName());
//                sValue = sValue.Replace(HtmlClassPath, sClassPath);
                
//            }

//            return sValue.ToLower();

//        }
//        static private int GetRandNum()
//        {
//            int min = 10000;
//            int max = 99999;
//            Random a = new Random();
//            int result = a.Next(min, max);

//            return result;

//        }
//        static private string GetTitleSpell(string Title)
//        {
//            if (string.IsNullOrEmpty(Title)) return string.Empty;

//            return stCommon.Strings.cConvert.GetQuanPing(Title);

//        }

//        static public List<KeyValueModel> lst = new List<KeyValueModel>();


        
    
//    }
//}
