using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EbSite.Modules.BBS.ModuleCore
{
    public class Comm
    {
        /// <summary>
        /// //每一个分类对应一个post表,表的命名规则 [表前缀post分类ID],如bbs_post1,bbs_post2,bbs_post3
        /// </summary>
        /// <param name="classid"></param>
        /// <returns></returns>
        public static string GetPostTableNamePre(int classid)
        {
            string tablepre = "bbs_";// SettingInfo.Instance.TablePrefix;  //表前缀

            return string.Concat(tablepre, GetPostTableNameNoPre(classid));
        }
        public static string GetPostTableNameNoPre(int classid)
        {
            return string.Concat("post", classid);
        }
        public static bool IsHaveLimit(int ClassID)
        {
            string GetManagerID =  EbSite.Base.Host.Instance.GetManagerID;
            int Mid = int.Parse(GetManagerID);

            if (Mid > 0)
            {
                return true;
            }
            return false;
        }
        public static string PostTitleFont(object Title, object TitleFont, object TitleColor, string href)
        {
            string Tem = string.Concat("<a href='", href, "' >{字体开始}{颜色开始}", Title, "{颜色结束}{字体结束}</a>");

            if (Equals(TitleFont, "1"))
            {
                Tem = Tem.Replace("{字体开始}", "<b>").Replace("{字体结束}", "</b>");
            }
            else if (Equals(TitleFont, "2"))
            {
                Tem = Tem.Replace("{字体开始}", "<em>").Replace("{字体结束}", "</em>");
            }
            else
            {
                Tem = Tem.Replace("{字体开始}", "").Replace("{字体结束}", "");
            }
           
            if (!string.IsNullOrEmpty(TitleColor.ToString()))
            {
                Tem = Tem.Replace("{颜色开始}", string.Concat("<font color='", TitleColor, "'>")).Replace("{颜色结束}", "</font>");
            }
            else
            {
                Tem = Tem.Replace("{颜色开始}", "").Replace("{颜色结束}", "");
            }
            return Tem;
        }

        static public string PostTitleLab(object labtype,string csspath,string href)
        {
            int iType = Core.Utils.StrToInt(labtype.ToString(),0);
            string TitleIco = string.Empty;
            switch (iType)
            {
                case 0:
                    TitleIco = "";
                    break;
                case 1: //精
                    TitleIco = "good.gif";
                    break;
                case 2://加火
                    TitleIco = "topic_hot.gif";
                    break;
                case 3://蓝旗
                    TitleIco = "mod.gif";
                    break;
                case 4://红旗
                    TitleIco = "flag_red.gif";
                    break;
                case 5://绿顶
                    TitleIco = "topic_sticky.gif";
                    break;
                case 6://蓝顶
                    TitleIco = "topic_pinned.gif";
                    break;
                case 7://红星
                    TitleIco = "admin.gif";
                    break;
                case 8://绿星
                    TitleIco = "sbm.gif";
                    break;
                case 9://投票
                    TitleIco = "vote.gif";
                    break;
                case 10://提问
                    TitleIco = "ask.gif";
                    break;

                    
               
            }
            if (!string.IsNullOrEmpty(TitleIco))
            {
                TitleIco = string.Format("<a href='{0}' ><img src='{1}images/icons/{2}'></a>", href, csspath, TitleIco);
            }
            return TitleIco;
        }
    }
}