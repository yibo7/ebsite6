using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Web;
using System.Web.UI;

namespace EbSite.Control
{
    /// <summary>
    /// div实现的tags,主要应用于前台
    /// </summary>
    [ToolboxData("<{0}:CustomTagsDiv runat=server></{0}:CustomTagsDiv>"), DefaultProperty("Text")]
    public class CustomTagsDiv : CustomTagsBase
    {
       
        protected override void Render(HtmlTextWriter output)
        {
            //base.ItemCss = "";//常规样式
            //base.CurrentCss = "current_nav";//选中样式
            if (!string.IsNullOrEmpty(this.Title))
                output.Write(string.Concat("<div class=\"UserRight_Title\">",this.Title,"</div>"));
            if (!IsCloseTagsItem)
            {
                List<TagsItemInfo> objA = this.BindList();
                if (!object.Equals(objA, null))
                {
                    output.Write(string.Concat("<div class=\"divtagbox\"> <ul class=\"divtagbox-ul\">"));
                    foreach (TagsItemInfo info in objA)
                    {
                        string sUrl = info.TagUrl;
                        if (!info.Enable)
                        {
                            sUrl = "#";
                        }
                        output.Write(string.Format("<li ><a title=\"{1}\" class=\"{0}\" href=\"{2}\"  {3} >{1}</a></li>", new object[] { this.GetClass(info.TagUrl, info.TagOrtherUrl), info.sText, sUrl, info.Orther }));
                    }
                    output.Write("</ul><div class=\"clear\"></div></div>");
                }
            }
        }

        /// <summary>
        /// 获取当前url的样式
        /// </summary>
        /// <param name="sTarget"></param>
        /// <returns></returns>
        override protected string GetClass(string sTarget, string TagOrtherUrl)
        {
            string itemCss = this.ItemCss;
            //当前访问地址
            string strMuid = HttpContext.Current.Request["muid"];//HttpContext.Current.Request.RawUrl.Trim();
            //string[] aUrl = str2.Split('?');
            if (!string.IsNullOrEmpty(strMuid))
            {
                strMuid = string.Concat("?mukey=", strMuid);
                //int index = str2.IndexOf("&p=");
                //if (index > -1)//比较忽略分页符
                //{
                //    str2 = str2.Substring(0, index);
                //}
                //Uri uri = new Uri(sTarget);

                if (sTarget.IndexOf(strMuid)>-1)
                {
                    itemCss = this.CurrentCss;
                }
                //if (!string.IsNullOrEmpty(TagOrtherUrl))
                //{
                //    if (object.Equals(str2.ToLower(), TagOrtherUrl.ToLower()))
                //    {
                //        itemCss = this.CurrentCss;
                //    }
                //}
            }
            return itemCss;
        }
    }


}
