using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using EbSite.BLL;
using EbSite.Base.Extension;
using EbSite.Base.Extension.Manager;
//using EbSite.Core.Static.OneCreatManager;

/// <summary>
    /// Converts BBCode to XHTML in the comments.
    /// </summary>
[Extension("关于发送短信的一些处理事件-如短信的自定义定制", "1.0", "<a href=\"http://www.ebsite.net\">小菜菜</a>")]
public class MsgEvent
{
    static protected ExtensionSettings _settings = null;
    /**/
    /// <summary>
    /// Hooks up an event handler to the Post.Serving event.
    /// </summary>
    static MsgEvent()
    {
        EbSite.BLL.Msg.Saving += new EventHandler<SavedEventArgs>(On_Saving);
    }

    /**/
    /// <summary>
    /// Handles the Post.Serving event to take care of logging IP.
    /// </summary>
    private static void On_Saving(object sender, SavedEventArgs e)
    {
        if (Equals(SaveAction.Insert, e.Action)) //如果当前的保存动作为添加短信
        {
            EbSite.BLL.Msg mdMsg = (EbSite.BLL.Msg)sender;
            
            if(mdMsg.MsgType>-1) //-1表示系统默认短信，大于-1是可定制短信，这里是您定制的一些信息，您可以相应的去完成您想要的短信
            {
                string sMsgHtml = "";
                string sUserNews = "";
                if (mdMsg.MsgType == 1) //动一下
                {
                    sMsgHtml = string.Format("{0}动了您一下", mdMsg.Sender);

                    sUserNews = string.Format("<a target=_blank href='/u/index.aspx?uid={0}'>{0}</a>动了<a target=_blank href='/u/index.aspx?uid={1}'>{1}</a>一下", mdMsg.Sender, mdMsg.Recipient);
                }
                else if (mdMsg.MsgType == 2) //捏一下
                {
                    sMsgHtml = string.Format("{0}捏了您一下", mdMsg.Sender);

                    sUserNews = string.Format("<a target=_blank href='/u/index.aspx?uid={0}'>{0}</a>捏了<a target=_blank href='/u/index.aspx?uid={1}'>{1}</a>一把,然后转身就跑", mdMsg.Sender, mdMsg.Recipient);
                }
                else if (mdMsg.MsgType == 3) //抛媚眼
                {
                    sMsgHtml = string.Format("{0}向你抛了个媚眼,好像有所暗示", mdMsg.Sender);
                    sUserNews = string.Format("<a target=_blank href='/u/index.aspx?uid={0}'>{0}</a>向<a target=_blank href='/u/index.aspx?uid={1}'>{1}</a>抛了个媚眼,好像有所暗示", mdMsg.Sender, mdMsg.Recipient);
                }
                else if (mdMsg.MsgType == 4)//踩一踩
                {
                    sMsgHtml = string.Format("{0}踩一踩你的脚", mdMsg.Sender);
                    sUserNews = string.Format("<a target=_blank href='/u/index.aspx?uid={0}'>{0}</a>踩一踩<a target=_blank href='/u/index.aspx?uid={1}'>{1}</a>的脚,以里不知的想什么", mdMsg.Sender, mdMsg.Recipient);
                }
                else if (mdMsg.MsgType == 5) //握个手
                {
                    sMsgHtml = string.Format("{0}跟您握个手", mdMsg.Sender);
                    sUserNews = string.Format("<a target=_blank href='/u/index.aspx?uid={0}'>{0}</a>跟<a target=_blank href='/u/index.aspx?uid={1}'>{1}</a>握手,希望成为好朋友", mdMsg.Sender, mdMsg.Recipient);
                }
                else if (mdMsg.MsgType == 6)//摸一下
                {
                    sMsgHtml = string.Format("{0}摸一下你的脸", mdMsg.Sender);
                    sUserNews = string.Format("<a target=_blank href='/u/index.aspx?uid={0}'>{0}</a>摸一下<a target=_blank href='/u/index.aspx?uid={1}'>{1}</a>的脸,不知道是故意挑逗，还是真情流露", mdMsg.Sender, mdMsg.Recipient);
                }
                else if (mdMsg.MsgType == 7)//拥抱
                {
                    sMsgHtml = string.Format("{0}拥抱了您一下", mdMsg.Sender);
                    sUserNews = string.Format("<a target=_blank href='/u/index.aspx?uid={0}'>{0}</a>拥抱了<a target=_blank href='/u/index.aspx?uid={1}'>{1}</a>一下", mdMsg.Sender, mdMsg.Recipient);
                }
                else if (mdMsg.MsgType == 8) //飞吻
                {
                    sMsgHtml = string.Format("{0}给您一个飞吻", mdMsg.Sender);
                    sUserNews = string.Format("<a target=_blank href='/u/index.aspx?uid={0}'>{0}</a>给<a target=_blank href='/u/index.aspx?uid={1}'>{1}</a>一个飞吻", mdMsg.Sender, mdMsg.Recipient);
                }
                else if (mdMsg.MsgType == 9) //打招呼
                {
                    sMsgHtml = string.Format("{0}打招呼", mdMsg.Sender);
                    sUserNews = string.Format("<a target=_blank href='/u/index.aspx?uid={0}'>{0}</a>向<a target=_blank href='/u/index.aspx?uid={1}'>{1}</a>打了个招呼", mdMsg.Sender, mdMsg.Recipient);
                }
                else if (mdMsg.MsgType == 10)//挠痒痒
                {
                    sMsgHtml = string.Format("{0}给您挠痒痒", mdMsg.Sender);
                    sUserNews = string.Format("<a target=_blank href='/u/index.aspx?uid={0}'>{0}</a>给<a target=_blank href='/u/index.aspx?uid={1}'>{1}</a>挠痒痒", mdMsg.Sender, mdMsg.Recipient);
                }
                else if (mdMsg.MsgType == 11)//给一拳
                {
                    sMsgHtml = string.Format("{0}给你一拳", mdMsg.Sender);
                    sUserNews = string.Format("<a target=_blank href='/u/index.aspx?uid={0}'>{0}</a>给<a target=_blank href='/u/index.aspx?uid={1}'>{1}</a>一拳", mdMsg.Sender, mdMsg.Recipient);
                }
                else if (mdMsg.MsgType == 12)//电一下
                {
                    sMsgHtml = string.Format("{0}电了您一下", mdMsg.Sender);
                    sUserNews = string.Format("<a target=_blank href='/u/index.aspx?uid={0}'>{0}</a>电了<a target=_blank href='/u/index.aspx?uid={1}'>{1}</a>一下", mdMsg.Sender, mdMsg.Recipient);
                }
                else if (mdMsg.MsgType == 13)//微笑
                {
                    sMsgHtml = string.Format("{0}向你微微一笑", mdMsg.Sender);
                    sUserNews = string.Format("<a target=_blank href='/u/index.aspx?uid={0}'>{0}</a>向<a target=_blank href='/u/index.aspx?uid={1}'>{1}</a>微微一笑", mdMsg.Sender, mdMsg.Recipient);
                }
                else if (mdMsg.MsgType == 14)//捏捏脚
                {
                    sMsgHtml = string.Format("{0}给您捏捏脚", mdMsg.Sender);
                    sUserNews = string.Format("<a target=_blank href='/u/index.aspx?uid={0}'>{0}</a>给<a target=_blank href='/u/index.aspx?uid={1}'>{1}</a>捏捏脚", mdMsg.Sender, mdMsg.Recipient);
                }
                else if (mdMsg.MsgType == 15)//咬一口
                {
                    sMsgHtml = string.Format("{0}咬了您一口", mdMsg.Sender);
                    sUserNews = string.Format("<a target=_blank href='/u/index.aspx?uid={0}'>{0}</a>咬了<a target=_blank href='/u/index.aspx?uid={1}'>{1}</a>您一口", mdMsg.Sender, mdMsg.Recipient);
                }

                mdMsg.MsgContent = sMsgHtml;
                
                EbSite.BLL.UserNews.Add(EbSite.Base.AppStartInit.UserName, EbSite.Core.Utils.HtmlEncode(sUserNews));
            }

        }

    }
}