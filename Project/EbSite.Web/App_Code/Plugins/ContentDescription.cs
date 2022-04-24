using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using EbSite.BLL;
using EbSite.Base.Extension;
using EbSite.Base.Extension.Manager;
using NewsContent = EbSite.Entity.NewsContent;

/// <summary>
/// Converts BBCode to XHTML in the comments.
/// </summary>
[Extension("添加文章时更新简介Description", "1.0", "<a href=\"http://www.ebsite.net\">小菜菜</a>")]
public class ContentDescription
{


    static protected ExtensionSettings _settings = null;
   
    /// <summary>
    /// Hooks up an event handler to the Post.Serving event.
    /// </summary>
    static ContentDescription()
    {

        EbSite.Base.EBSiteEvents.ContentAdding += new EventHandler<EbSite.Base.EBSiteEventArgs.AddingContentEventArgs>(On_Adding); 
    }

    /**/
    /// <summary>
    /// Handles the Post.Serving event to take care of logging IP.
    /// </summary>
    private static void On_Adding(object sender, EbSite.Base.EBSiteEventArgs.AddingContentEventArgs e)
    {
        EbSite.Entity.NewsContent nc = (EbSite.Entity.NewsContent)sender;

        if (!Equals(nc, null))
        {
            //e.StopAdd = true;//阻住当前的添加操作

            if (string.IsNullOrEmpty(nc.Description) && !string.IsNullOrEmpty(nc.ContentInfo))
            {
                nc.Description = string.Concat(nc.NewsTitle, ",", EbSite.Base.Host.Instance.GetSimpleContent(nc.ContentInfo, 200));

            }


        }
    }

}