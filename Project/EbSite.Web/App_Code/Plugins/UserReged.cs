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
[Extension("用户注册后后触发", "1.0", "<a href=\"http://www.ebsite.net\">小菜菜</a>")]
public class UserReged
{


    static protected ExtensionSettings _settings = null;
   
    /// <summary>
    /// Hooks up an event handler to the Post.Serving event.
    /// </summary>
    static UserReged()
    {

        EbSite.Base.EBSiteEvents.UserReged += new EventHandler<EbSite.Base.EBSiteEventArgs.UserActivatedEventArgs>(On_UserReged);
    }

    /**/
    /// <summary>
    /// Handles the Post.Serving event to take care of logging IP.
    /// </summary>
    private static void On_UserReged(object sender, EbSite.Base.EBSiteEventArgs.UserActivatedEventArgs e)
    {
        if (e.UserID > 0) //用户ID>0
        {
            // e.UserID 用户ID
            // e.UserName 用户名称
            //e.Email 用户email
            //执行一些处理操作
        }
    }

}