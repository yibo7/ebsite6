using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace EbSite.Control
{
    
    //[Serializable]
    //public class TagsItemInfo
    //{
    //    private string _Orther;
    //    private string _sText;
    //    private string _TagUrl;

    //    public string Orther
    //    {
    //        get
    //        {
    //            return this._Orther;
    //        }
    //        set
    //        {
    //            this._Orther = value;
    //        }
    //    }

    //    public string sText
    //    {
    //        get
    //        {
    //            return this._sText;
    //        }
    //        set
    //        {
    //            this._sText = value;
    //        }
    //    }
    //    /// <summary>
    //    /// 连接地址，通过对比此地址是不是当前tag
    //    /// </summary>
    //    public string TagUrl
    //    {
    //        get
    //        {
    //            return this._TagUrl;
    //        }
    //        set
    //        {
    //            this._TagUrl = value;
    //        }
    //    }
    //    private string _TagOrtherUrl;
    //    /// <summary>
    //    /// 附加的目标连接地址,通过对比此地址是不是当前tag
    //    /// </summary>
    //    public string TagOrtherUrl
    //    {
    //        get
    //        {
    //            return this._TagOrtherUrl;
    //        }
    //        set
    //        {
    //            this._TagOrtherUrl = value;
    //        }
    //    }
    //}
    /// <summary>
    /// 目前主要应用于后台
    /// </summary>
    [ToolboxData("<{0}:CustomTags runat=server></{0}:CustomTags>"), DefaultProperty("Text")]
    public class CustomTags : CustomTagsBase
    {
        

        protected override void Render(HtmlTextWriter output)
        {

            //if (!string.IsNullOrEmpty(this.Title))
            //{
            //    //output.Write(string.Format("<div class=\"TabsTitle\" ><span><img align=\"left\" src=\"{1}images/menus/arrow1.png\"  />{0}</span></div>", this.Title, Base.AppStartInit.IISPath));
            //    output.Write("<div class='boxheader'><h3>{0}</h3></div>", this.Title);

            //}
                
            if (this.Visible)
            {
                List<TagsItemInfo> objA = this.BindList();
                if (!object.Equals(objA, null))
                {
                    output.Write("<div><ul class='nav nav-tabs'>");

                    foreach (TagsItemInfo info in objA)
                    {
                        string sUrl = info.TagUrl;
                        if (!info.Enable)
                        {
                            sUrl = "#";
                        }
                        output.Write("<li class='nav-item'><a class='{0} nav-link' href = '{1}' ><span class='visible-xs'><i class='fa fa-user'></i></span><span class='hidden-xs'>{2}</span></a></li> ", new object[] { this.GetClass(info.TagUrl, info.TagOrtherUrl),  sUrl, info.sText, info.Orther });
                    }
                    output.Write("</ul></div>");
                }
                //if (!object.Equals(objA, null))
                //{
                //    output.Write("<table class=\"" + base.CssClass + "\"  border=\"0\"  cellpadding=0 cellspacing=0 ><tr><td >");

                //    foreach (TagsItemInfo info in objA)
                //    {
                //        string sUrl = info.TagUrl;
                //        if (!info.Enable)
                //        {
                //            sUrl = "#";
                //        }
                //            output.Write(string.Format("<div class=\"{0}\"><a title=\"{1}\" href=\"{2}\" {3} >{1}</a></div>", new object[] { this.GetClass(info.TagUrl, info.TagOrtherUrl), info.sText, sUrl, info.Orther }));
                //    }
                //    output.Write("</td></tr></table>");
                //}
            }
            
        }

        
    }


    
}