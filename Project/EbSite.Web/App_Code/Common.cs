using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using System.Web;

namespace EbSite
{
    public class Common
    {
        /// <summary>
        /// 输出某个内容的标签列表，建议在列表中使用，但比较占资源，如果使用，建议开启当前页面的自动静态功能,模板可以在这里随意修改
        /// </summary>
        /// <param name="contentid"></param>
        /// <param name="classid"></param>
        /// <param name="iTop">条数</param>  
        /// <param name="SiteID"></param>
        /// <param name="iNum">内容数量</param>
        /// <returns>EbSite.Common.TagHtml</returns>

        public static string TagHtml(object contentid, object classid, int iNum=2,int iTop=5)
        {
            int GetContentID = Core.Utils.ObjectToInt(contentid);
            int iClassID = Core.Utils.ObjectToInt(classid);
            StringBuilder sb = new StringBuilder();
            List<EbSite.Entity.TagKey> lst = BLL.TagKey.GetTagsIDByContentID(GetContentID, iClassID, 1, iTop, EbSite.Base.Host.Instance.GetSiteID, iNum);
            foreach (Entity.TagKey model in lst)
            {
                sb.AppendFormat("<a href=\"{0}\">{1}</a>", EbSite.Base.Host.Instance.TagsSearchList(model.id, 1), model.TagName);
            }
            return sb.ToString();
        }

        public static string TagHtmlForTagv(object contentid, object classid,int TagID, int iNum = 2, int iTop = 5)
        {
            int GetContentID = Core.Utils.ObjectToInt(contentid);
            int iClassID = Core.Utils.ObjectToInt(classid);
            StringBuilder sb = new StringBuilder();
            List<EbSite.Entity.TagKey> lst = BLL.TagKey.GetTagsIDByContentID(GetContentID, iClassID, 1, iTop, EbSite.Base.Host.Instance.GetSiteID, iNum);
            foreach (Entity.TagKey model in lst)
            {  
                if(model.id== TagID)
                    continue;

                sb.AppendFormat("<a href=\"{0}\">{1}</a>(<font color=#ff0000>{2}</font>)", EbSite.Base.Host.Instance.TagsSearchList(model.id, 1), model.TagName, model.Num);
            }
            return sb.ToString();
        }

      

        static public string GetCustomFiled(object ob, string FiledName)
        {
            string sV = string.Empty;
            StringDictionary sd = (StringDictionary)ob;
            if (sd != null)
            {
                sV = sd[FiledName];
            }
            return sV;
        }

    }
}
