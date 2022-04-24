

using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using EbSite.Base.EBSiteEventArgs;
using EbSite.Base.Extension;
using EbSite.Base.Extension.Manager;
//using EbSite.Core.Static.OneCreatManager;

/// <summary>
/// 搜索之前可以进行一些业务处理
/// </summary>
[Extension("分类列表条件订制", "1.0", "<a href=\"http://www.ebsite.net\">小菜菜</a>")]
public class ClassListLoading
{
    static protected ExtensionSettings _settings = null;
    /**/
    /// <summary>
    /// Hooks up an event handler to the Post.Serving event.
    /// </summary>
    static ClassListLoading()
    {

        EbSite.Base.EBSiteEvents.ClassListLoading += new EventHandler<ClassListLaodingEventArgs>(On_ClassListLoading);
    }

    /**/
    /// <summary>
    /// 搜索之前可以进行一些业务处理
    /// </summary>
    private static void On_ClassListLoading(object sender, ClassListLaodingEventArgs e)
    {
        //if (e.ClassID > 0)
        //{

        //    //e.Context  当前搜索的上下文        
        //    //e.Where = ""; 订制条件
        //    //listt=123
        //    string strsql = "";
        //    string sType = e.Context.Request["listt"];
        //    string sClassId = e.Context.Request["cid"];

        //    if (!string.IsNullOrEmpty(sType))
        //    {
        //        if (sType == "1") //悬赏问题
        //        {
        //            strsql = " Annex1>= " + 30;
        //        }
        //        if (sType == "2")//待解决
        //        {
        //            strsql = " Annex4= " + 1;
        //        }
        //        if (sType == "3")//已解决
        //        {
        //            strsql = " Annex4= " + 2;
        //        }
        //        e.Where = strsql + " and classid=" + sClassId;
        //    }
        //}
    }
}