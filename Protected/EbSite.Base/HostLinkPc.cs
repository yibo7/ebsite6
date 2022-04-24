using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.Security;
using EbSite.Base.Configs.UserSetConfigs;
using EbSite.Base.EntityAPI;
using EbSite.Base.Modules;
using EbSite.Base.PageLink;
using EbSite.BLL;
using EbSite.BLL.Email;
using EbSite.BLL.GetLink;
using EbSite.BLL.ModulesBll;
using EbSite.BLL.User;
using EbSite.Core;
using EbSite.Core.Strings;
using EbSite.Data.User.Interface;
using EbSite.Entity;
using EbSite.Entity.Module;
using Sites = EbSite.Entity.Sites;

namespace EbSite.Base
{
    
    public partial class Host
    {

        /// <summary>
        /// 定向到登录页
        /// </summary>
        public void GoToLoginPC()
        {
            AppStartInit.UserLoginReurl();
        }
       
        /// <summary>
        /// 获取提示页面地址
        /// </summary>
        /// <param name="id">提示页面ID</param>
        /// <returns></returns>
        public string GetTipsUrl(int id)
        {
            return string.Concat(IISPath, "err", id, ".ashx");
        }

        /// <summary>
        /// 获取当前登录用户使用的控制面板页url
        /// </summary>
        public string UccUrl
        {
            get
            {
                return Base.PageLink.GetBaseLinks.GetDefault.UccIndexRw;
            }
        }
        /// <summary>
        /// 获取当前登录用户控制面板后台
        /// </summary>
        public string UccIndexRw
        {
            get
            {
                if (string.IsNullOrEmpty(ConfigsControl.Instance.UserCenter))
                {
                    return Base.PageLink.GetBaseLinks.GetDefault.UccIndexRw;
                }
                else
                {
                    return string.Concat(ConfigsControl.Instance.UserCenter, Base.PageLink.GetBaseLinks.GetDefault.UccIndexRw);
                }

            }
        }
        /// <summary>
        /// 获取网站首页的动态重写地址
        /// </summary>
        public string IndexLinkRw
        {
            get
            {
                return PageLink.GetBaseLinks.Get(GetSiteID).IndexLinkRw;
            }
        }
        /// <summary>
        /// 获致搜索页面的动态重写地址
        /// </summary>
        public string SearchRw
        {
            get
            {
                return PageLink.GetBaseLinks.Get(GetSiteID).SearchRw;
                
            }
        }

        /// <summary>
        /// 获取找回密码的地址
        /// </summary>
        public string LostpasswordRw
        {
            get
            {

                if (string.IsNullOrEmpty(ConfigsControl.Instance.UserCenter))
                {
                    return Base.PageLink.GetBaseLinks.GetDefault.LostpasswordRw;
                }
                else
                {
                    return string.Concat(ConfigsControl.Instance.UserCenter, Base.PageLink.GetBaseLinks.GetDefault.LostpasswordRw);
                }
            }
        }
        /// <summary>
        /// 获取登录页面的地址
        /// </summary>
        public string LoginRw
        {
            get
            {

                if (string.IsNullOrEmpty(ConfigsControl.Instance.UserCenter))
                {
                    return Base.PageLink.GetBaseLinks.GetDefault.LoginRw;
                }
                else
                {
                    return string.Concat(ConfigsControl.Instance.UserCenter, Base.PageLink.GetBaseLinks.GetDefault.LoginRw);
                }

            }
        }
        /// <summary>
        /// 获取退出页面的地址
        /// </summary>
        public string LogOutRw
        {
            get
            {
                if (string.IsNullOrEmpty(ConfigsControl.Instance.UserCenter))
                {

                    return string.Concat(IISPath, "LogOut.aspx");
                }
                else
                {
                    return string.Concat(ConfigsControl.Instance.UserCenter, "/", "LogOut.aspx");
                }
            }
        }
        /// <summary>
        /// 获取邀请页面的url
        /// </summary>
        public string InviteRegUrl
        {
            get
            {

                if (string.IsNullOrEmpty(ConfigsControl.Instance.UserCenter))
                {

                    return string.Concat(Domain,Base.PageLink.GetBaseLinks.GetDefault.RegRw, "?vuid=", UserID);
                }
                else
                {
                    return string.Concat(ConfigsControl.Instance.UserCenter, Base.PageLink.GetBaseLinks.GetDefault.RegRw, "?vuid=", UserID);
                }
                
            }
        }
      
        /// <summary>
        /// 获取注册页面的地址
        /// </summary>
        public string RegRw
        {
            get
            {
                if (string.IsNullOrEmpty(ConfigsControl.Instance.UserCenter))
                {
                    return Base.PageLink.GetBaseLinks.GetDefault.RegRw;
                }
                else
                {
                    return string.Concat(ConfigsControl.Instance.UserCenter, Base.PageLink.GetBaseLinks.GetDefault.RegRw);
                }
            }
        }
        /// <summary>
        /// 获取一个css文件地址
        /// </summary>
        /// <param name="vpath">css文件的路径,比如 index,那么调用到的css为当前皮肤目录下的index.css文件</param>
        /// <returns>返回一个虚拟地址，真正输出内容为index.css</returns>
        public string GetCssFileUrl(string vpath)
        {
            return string.Concat(vpath, ".ebcss.ashx");
        }
        /// <summary>
        /// 获取一个css目录地址
        /// </summary>
        /// <param name="vpath">css目录存放的路径，比如 css,那么将返回当前皮肤下的 css目录所有css文件</param>
        /// <returns>返回一个虚拟地址，真正输出内容为css目录下的合并</returns>
        public string GetCssFolderUrl(string vpath)
        {
            
            return string.Concat(vpath, "/ebcss.ashx");
        }
        /// <summary>
        /// 获取某个站点的首页地址
        /// </summary>
        /// <param name="iSiteID">站点ID</param>
        /// <returns></returns>
        public string GetMainIndexHref(int iSiteID)
        {
            return LinkOrther.Instance.GetInstance(iSiteID).GetMainIndexHref();
        }
        /// <summary>
        /// 获取讨论区的连接
        /// </summary>
        /// <param name="discuzid">讨论区分类ID</param>
        /// <param name="type">类别 1.盖楼式评论,2.好评系统 3.一问一答</param>
      /// <param name="siteid">当前站点ID</param>
      /// <param name="ipage">当前评论列表页码</param>
      /// <param name="classid">与内容对应的分类ID，（如果非内容模板里引用评论，可以设置为0，只通过contentid来区分）</param>
      /// <param name="contentid">内容ID</param>
      /// <returns></returns>
        public string GetDiscussHref(string discuzid,int type,int siteid,int ipage,int classid,long contentid)
        {
            //连接规则:评论类别ID-系统分类ID-内容ID-展示模板ID-站点ID-分内或内容标记-dc.aspx
            return string.Concat(discuzid, "_", classid, "_", contentid, "_", type, "_", siteid, "_", ipage, "dc.aspx");
        }
        /// <summary>
        /// 获取第三方登录返回绑定完成资料页面地址
        /// </summary>
        /// <param name="apptype">第三方登录插件标记,如 QQ,SINA</param>
        /// <returns></returns>
        public string LoginApiBindUrl(string apptype)
        {
            return string.Concat(Domain, LinkOrther.Instance.GetReWriteInstance(GetSiteID).GetLoginApiBackUrl(apptype));
        }


        /// <summary>
        /// 获取当前登录用户的个人主页首页url
        /// </summary>
        public string CurrentSiteUrl
        {
            get
            {
                return GetUserSiteUrl(UserID);
            }
        }
        /// <summary>
        /// 获取某个用户个人空间的地址，前提是安装了用户空间模块，和开通用户空间功能
        /// </summary>
        /// <param name="iUserID">用户ID</param>
        /// <returns></returns>
       
        public string GetUserSiteUrl(object iUserID)
        {
            int userid = 0;
            int.TryParse(iUserID.ToString(), out userid);

            if (userid > 0)
            {
                if (Configs.SysConfigs.ConfigsControl.Instance.IsOpenUserHome)
                {
                    int iDefaultTabID = EbSite.BLL.SpaceSetting.Instance.GetDefaultTabID(userid);
                    return string.Concat(Base.PageLink.GetBaseLinks.Get(GetSiteID).UhomeRw, "?uid=", iUserID, "&tab=", iDefaultTabID);
                }
                else
                {
                   return EbSite.BLL.GetLink.LinkOrther.Instance.GetInstance(GetSiteID).GetUserInfo(iUserID);
                    //return string.Concat(IISPath, "uinfo.ashx?uid=", iUserID);
                }
               
            }
            else
            {
                return GetTips("用户ID为小于1");
            }

           
        }

        /// <summary>
        /// 获取某个用户个人空间的地址，前提是安装了用户空间模块，和开通用户空间功能
        /// </summary>
        /// <param name="iUserName">用记帐号</param>
        /// <returns></returns>
        public string GetUserSiteUrl(string iUserName)
        {
            int iUserID = EbSite.BLL.User.MembershipUserEb.Instance.GetUserIDByUserName(iUserName);
            return GetUserSiteUrl(iUserID);
        }
        /// <summary>
        /// 获取当前登录用户的个人空间首页，与GetUserSiteUrl区别，GetUserSiteUrl可以获取某个用户
        /// </summary>
        public string UhomeRw
        {
            get
            {
                if (string.IsNullOrEmpty(ConfigsControl.Instance.UserCenter))
                {
                    return Base.PageLink.GetBaseLinks.GetDefault.UhomeRw;
                }
                else
                {
                    return string.Concat(ConfigsControl.Instance.UserCenter, Base.PageLink.GetBaseLinks.GetDefault.UhomeRw);
                }
            }
        }

        /// <summary>
        /// 获取当前登录用户的主页
        /// </summary>
        /// <returns></returns>
        public string GetUserHomePage()
        {
            return Base.PageLink.GetBaseLinks.GetDefault.UccIndexRw;

        }

        /// <summary>
        /// 某个用户主页
        /// </summary>
        /// <param name="UserID">The user identifier.</param>
        /// <returns>System.String.</returns>
        public string GetUserHomePage(string UserID)
        {
            return string.Concat(Base.PageLink.GetBaseLinks.GetDefault.UccIndexRw, "?uid=", UserID);
        }


        /// <summary>
        /// 获取充值页面地址(当前登录用户)
        /// </summary>
        public string GetMoneyInUrl
        {
            get
            {
                return GetModuleUrl(new Guid("c65f0059-b345-4c0b-a437-37363f2fa4e9"), new Guid("c79a50b4-d5d0-4dfc-a4be-03c571b90830"));
            }
        }
        ///// <summary>
        ///// 我的消息页面地址(当前登录用户)
        ///// </summary>
        //public string GetMyMsg
        //{
        //    get
        //    {
        //        return GetModuleUrl(new Guid("bf371bdd-f674-4077-a9ed-e2896fb4c857"), new Guid("67024109-4035-47eb-8f9e-e154aff35def"));
        //    }
        //}
        /// <summary>
        /// 获取账户明细地址(当前登录用户)
        /// </summary>
        public string GetAccoutInfo
        {
            get
            {
                return GetModuleUrl(new Guid("c65f0059-b345-4c0b-a437-37363f2fa4e9"), new Guid("bcf359d4-99f8-458b-b7c2-6e8edbc274fc"));
            }
        }
        /// <summary>
        /// 提现申请地址(当前登录用户)
        /// </summary>
        public string GetMoneyApply
        {
            get
            {
                return GetModuleUrl(new Guid("c65f0059-b345-4c0b-a437-37363f2fa4e9"), new Guid("fe7c0cda-ca3c-4c25-821f-7879d7ac018d"));
            }
        }

        /// <summary>
        /// 预付款开通 页面(当前登录用户)
        /// </summary>
        public string GetOpenBalance
        {
            get
            {
                return GetModuleUrl(new Guid("c65f0059-b345-4c0b-a437-37363f2fa4e9"), new Guid("e67667e0-8526-4140-b294-8bafb8fc5faf"));
            }
        }
        /// <summary>
        /// 获取个人空间开通页面地址(当前登录用户)
        /// </summary>
        public string GetSpaceSettingUrl
        {
            get
            {
                return EbSite.BLL.MenusForUser.Instance.GetSpaceSettingUrl;
            }
        }
        /// <summary>
        /// 获取修改用户昵称页面(当前登录用户)
        /// </summary>
        public string GetNiNameUrl
        {
            get
            {
                return GetModuleUrl(new Guid("bf371bdd-f674-4077-a9ed-e2896fb4c857"), new Guid("bf371bdd-a674-4097-a9ed-e2896fb4c857"));
            }
        }
        /// <summary>
        /// 获取修改用户基础资料页面的url(当前登录用户)
        /// </summary>
        public string GetBaseInfoUrl
        {
            get
            {
                return GetModuleUrl(new Guid("bf371bdd-f674-4077-a9ed-e2896fb4c857"), new Guid("af379cdd-a674-4077-a9ed-e2896fb4c857"));
            }
        }
        /// <summary>
        /// 获取修改密码的页面url(当前登录用户)
        /// </summary>
        public string GetChangePassUrl
        {
            get
            {
                return GetModuleUrl(new Guid("bf371bdd-f674-4077-a9ed-e2896fb4c857"), new Guid("af371bdd-f674-4077-a9ed-e2896f55c857"));
            }
        }
        /// <summary>
        /// 获取修改用户头像页面URL(当前登录用户)
        /// </summary>
        public string GetChangeUserICO
        {
            get
            {
                return GetModuleUrl(new Guid("bf371bdd-f674-4077-a9ed-e2896fb4c857"), new Guid("af371bdd-a674-4077-a9ed-e2896fb4c857"));
            }
        }
        /// <summary>
        /// 获取模块任何页面URL，这个ID要在开发时给定
        /// </summary>
        /// <param name="ParentID">父ID 可在 Menus_User.txt 里的第三个参数设置，可参考空间模块</param>
        /// <param name="SubID">子ID 在开发时重写 (override)  ModuleMenuID</param>
        /// <returns></returns>
        public string GetModuleUrl(Guid ParentID, Guid SubID)
        {
            return EbSite.BLL.MenusForUser.Instance.GetUrlByID(ParentID, SubID, false);
        }

        /// <summary>
        /// 获取第三方登录页面地址,比如你要在首页连接全个QQ登录，调用这个方法
        /// </summary>
        /// <param name="AppName">第三方登录插件标记，如QQ,TAOBAO</param>
        /// <returns>返回一个地址，连接倒第三方验证平台</returns>
        public string GetLoginApiUrl(string AppName)
        {
            return string.Concat(IISPath, "loginapi.ashx?t=", AppName);
        }
        /// <summary>
        /// 获取聊天窗口连接
        /// </summary>
        /// <param name="UserID"></param>
        /// <returns></returns>
        public string GetChatOnline(object UserID)
        {
            return string.Concat(GetModuleUrl("eb1e11de-5307-469d-b350-4035c4621dae", "f546355f-b540-4082-8ce0-674be18a117b"), "&uid=", UserID);
        }

        public string GetChatOnline(Chat mdChat)
        {
            if (mdChat.SenderId >0)
            {
                return GetChatOnline(mdChat.SenderId);
                
            }
            else
            {
                return string.Concat(GetModuleUrl("eb1e11de-5307-469d-b350-4035c4621dae", "f546355f-b540-4082-8ce0-674be18a117b"), "&olid=", mdChat.SenderOnlineid);
            }
            
        }

        
        /// <summary>
        /// 获取最新消息窗口连接
        /// </summary>
        /// <param name="UserID"></param>
        /// <returns></returns>
        public string GetNewMsg(object UserID)
        {
            return string.Concat(GetModuleUrl("4cd1ac15-54b3-4364-985f-590a824f2ed5", "67024109-4035-47eb-8f9e-e154aff35def"), "&uid=", UserID);
        }
        /// <summary>
        /// 获取发送信息窗口连接
        /// </summary>
        /// <param name="UserID"></param>
        /// <returns></returns>
        public string GetSendMsg(object UserID)
        {
            return string.Concat(GetModuleUrl("4cd1ac15-54b3-4364-985f-590a824f2ed5", "156571d6-8705-419d-a7a8-cdd68a87459b"), "&uid=", UserID);
        }
        /// <summary>
        /// 获取添加好友窗口连接
        /// </summary>
        /// <param name="UserID"></param>
        /// <returns></returns>
        public string GetAddFriend(object UserID)
        {
            return string.Concat(GetModuleUrl("470ba0af-6b6d-4636-9d27-3f39c139562f", "63a7536b-dc2d-4e2a-87b4-ab2bcb8f9e34"), "&uid=", UserID);
        }
        /// <summary>
        /// 获取模块的安装路径
        /// </summary>
        /// <param name="mid"></param>
        /// <returns></returns>
        public string GetModulePath(Guid mid)
        {
            return EbSite.BLL.ModulesBll.Modules.Instance.GetModelPath(mid);
        }
        /// <summary>
        /// 获取一个模块菜单地址（尖对用户平台）
        /// </summary>
        /// <param name="ParentID"></param>
        /// <param name="SubID"></param>
        /// <returns></returns>
        public string GetModuleUrl(string ParentID, string SubID)
        {
            return EbSite.BLL.MenusForUser.Instance.GetUrlByID(new Guid(ParentID), new Guid(SubID), false);
        }
        /// <summary>
        /// 获取一个模块菜单地址（后台管理员平台）
        /// </summary>
        /// <param name="ModuleID">模块ID</param>
        /// <param name="MemuID">页面菜单ID</param>
        /// <returns></returns>
        public string GetModuleUrlForAdmin(Guid ModuleID, Guid MemuID)
        {
            if (EbSite.BLL.ModulesBll.Modules.Instance.IsHave(ModuleID))
            {
                EbSite.BLL.ModulesBll.MenusForAdminer bll = new MenusForAdminer(ModuleID);

                ModulePageInfo md = bll.GetEntity(MemuID);
                if (md != null)
                {
                    return md.GetRealUrl();
                }
            }

            return EbSite.Base.Host.Instance.GetTipsUrl(6);

        }

        public string GetModuleUrlForAdmin(string ModuleID, string MemuID)
        {
            return GetModuleUrlForAdmin(new Guid(ModuleID), new Guid(MemuID));
        }

        /// <summary>
        /// 获取某个分类的Rss订阅地址
        /// </summary>
        /// <param name="itop">调用条数</param>
        /// <param name="itype">0排行,1推荐,2最新</param>
        /// <param name="iclassid">分类ID</param>
        /// <param name="SiteID">站点ID</param>
        /// <returns></returns>
        public string GetRss(int itop, int itype, int iclassid, int SiteID)
        {
            return string.Concat(IISPath, "rss.ashx?top=", itop, "&it=", itype, "&cid=", iclassid, "&site=", SiteID);
        }
        /// <summary>
        /// 获取数据排行版页面
        /// </summary>
        /// <param name="itype">排行榜类别，0为所有，1为月，2为周，3为日,4最新，5推荐</param>
        /// <param name="pageindex"></param>
        /// <returns></returns>
        public string GetTopHref(int itype,int pageindex)
        {
            return LinkOrther.Instance.GetInstance(GetSiteID).GetTop(itype, pageindex);
        }
        /// <summary>
        /// 所有分类页面
        /// </summary>
        /// <returns></returns>
        public string GetAllClassHref()
        {
            return LinkClass.Instance.GetInstance(GetSiteID).GetAllClassHref();
        }
        /// <summary>
        /// 获取分类连接地址
        /// </summary>
        /// <param name="iID">分类ID</param>
        /// <param name="HtmlPath">html生成名称</param>
        /// <param name="pIndex">页码</param>
        /// <returns></returns>
        public string GetClassHref(object iID, object HtmlPath, int pIndex)
        {
            return LinkClass.Instance.GetInstance(GetSiteID).GetClassHref(iID, HtmlPath, pIndex);
        }

        /// <summary>
        /// 获取分类连接地址
        /// </summary>
        /// <param name="iID">分类ID</param>
        /// <param name="HtmlPath">html生成名称</param>
        /// <param name="pIndex">页码</param>
        /// <returns></returns>
        public string GetClassHref(object iID, object HtmlPath, int pIndex, int siteid)
        {
           
            return LinkClass.Instance.GetInstance(siteid).GetClassHref(iID, HtmlPath, pIndex);
        }
        /// <summary>
        /// 获取分类连接地址
        /// </summary>
        /// <param name="iID">分类ID</param>
        /// <param name="HtmlPath">html生成名称</param>
        /// <param name="pIndex">页码</param>
        /// <param name="OutLink">外部连接</param>
        /// <returns></returns>
        public string GetClassHref(object iID, object HtmlPath, int pIndex, string OutLink)
        {
           
            return LinkClass.Instance.GetInstance(GetSiteID).GetClassHref(iID, HtmlPath, pIndex, OutLink);
        }
        /// <summary>
        /// 获取分类连接地址
        /// </summary>
        /// <param name="iID">分类ID</param>
        /// <param name="HtmlPath">html生成名称</param>
        /// <param name="pIndex">页码</param>
        /// <param name="OutLink">外部连接</param>
        /// <returns></returns>
        public string GetClassHref(object iID, object HtmlPath, int pIndex, string OutLink, int siteid)
        {
           
            return LinkClass.Instance.GetInstance(siteid).GetClassHref(iID, HtmlPath, pIndex, OutLink);
        }
        /// <summary>
        /// 获取分类连接地址
        /// </summary>
        /// <param name="iID">分类ID</param>
        /// <param name="Index">页码</param>
        /// <returns></returns>
        public string GetClassHref(int iID, int Index)
        {
          
            return LinkClass.Instance.GetInstance(GetSiteID).GetClassHref(iID, Index);
        }
        /// <summary>
        /// 获取分类连接地址
        /// </summary>
        /// <param name="iID">分类ID</param>
        /// <param name="Index">页码</param>
        /// <returns></returns>
        public string GetClassHref(int iID, int Index, int siteid)
        {
          
            return LinkClass.Instance.GetInstance(siteid).GetClassHref(iID, Index);
        }

       

        /// <summary>
        /// 获取内容页面连接地址
        /// </summary>
        /// <param name="HtmlPath">内容html命名</param>
        /// <returns></returns>
        public string UserAlbumHref(object iID,int UserID)
        {

            return LinkOrther.Instance.GetInstance(GetSiteID).UserAlbumHref(int.Parse(iID.ToString()), 1, UserID);
        }
        /// <summary>
        /// 获取内容页面连接地址
        /// </summary>
        /// <param name="HtmlPath">内容html命名</param>
        /// <returns></returns>
        public string UserAlbumHref(object iID, int siteid, int UserID)
        {

            return LinkOrther.Instance.GetInstance(siteid).UserAlbumHref(int.Parse(iID.ToString()), 1, UserID);
        }
        ///// <summary>
        ///// 兼容老版本的调用方法，使用默认内容表
        ///// </summary>
        ///// <param name="iID"></param>
        ///// <param name="siteid"></param>
        ///// <returns></returns>
        //public string GetContentLink(object iID,int siteid)
        //{
        //    return LinkContent.Instance.GetInstance(siteid).GetContentLink(iID);
        //}
        /// <summary>
        /// 获取内容页面连接地址
        /// </summary>
        /// <param name="HtmlPath">内容html命名</param>
        /// <returns></returns>
        public string GetContentLink(object iID, object HtmlPath, object iCid)
        {

            return LinkContent.Instance.GetInstance(GetSiteID).GetContentLink(iID, HtmlPath,iCid,0);
        }
        /// <summary>
        /// 获取内容页面连接地址
        /// </summary>
        /// <param name="HtmlPath">内容html命名</param>
        /// <returns></returns>
        public string GetContentLink(object iID, object HtmlPath, int siteid, object iCid)
        {
            return LinkContent.Instance.GetInstance(siteid).GetContentLink(iID, HtmlPath, iCid,0);
        }
        /// <summary>
        /// 获取内容页面连接地址
        /// </summary>
        /// <param name="iID">内容ID</param>
        /// <returns></returns>
        public string GetContentLink(object iID,object iCid)
        {
            return LinkContent.Instance.GetInstance(GetSiteID).GetContentLink(iID, iCid,0);
        }
        public string GetContentLinkPage(long iID, int iCid,int PageIndex)
        {
            return LinkContent.Instance.GetInstance(GetSiteID).GetContentLink(iID, iCid, PageIndex);
        }
        /// <summary>
        /// 获取内容页面连接地址
        /// </summary>
        /// <param name="iID">内容ID</param>
        /// <returns></returns>
        public string GetContentLink(object iID, int siteid,object iCid)
        {
            return LinkContent.Instance.GetInstance(siteid).GetContentLink(iID,iCid,0);
        }
        /// <summary>
        /// 获取列表-按排序号
        /// </summary>
        /// <param name="iID">分类ID</param>
        /// <param name="Index">页码</param>
        /// <param name="OrderBy">排序，0默认按ID排序，1按点击率排序，2按收藏排序，3按评论数排序，4好评或星级或顶一下排序，5按发布日期排序</param>
        /// <returns></returns>
        public string GetClassHref_OrderBy(int iID, int Index, int OrderBy)
        {
            return LinkClass.Instance.GetInstance(GetSiteID).GetClassHref_OrderBy(iID, Index, OrderBy);
        }
        /// <summary>
        /// 获取列表-按排序号
        /// </summary>
        /// <param name="iID">分类ID</param>
        /// <param name="Index">页码</param>
        /// <param name="OrderBy">排序，0默认按ID排序，1按点击率排序，2按收藏排序，3按评论数排序，4好评或星级或顶一下排序，5按发布日期排序</param>
        /// <returns></returns>
        public string GetClassHref_OrderBy(int iID, int Index, int OrderBy, int siteid)
        {
            return LinkClass.Instance.GetInstance(siteid).GetClassHref_OrderBy(iID, Index, OrderBy);
        }

        /// <summary>
        /// 获取专题连接
        /// </summary>
        /// <param name="iID">专题ID</param>
        /// <param name="Index">分页码</param>
        /// <returns></returns>
        public string GetSpecialHref(int iID, int Index)
        {

            return LinkSpecial.Instance.GetInstance(GetSiteID).GetSpecialHref(iID, Index);
        }
        public string GetSpecialHref(object iID, int Index)
        {
            return LinkSpecial.Instance.GetInstance(GetSiteID).GetSpecialHref(Core.Utils.StrToInt(iID.ToString(), 0), Index);
        }
        /// <summary>
        /// 获取专题连接
        /// </summary>
        /// <param name="iID">专题ID</param>
        /// <param name="Index">分页码</param>
        /// <returns></returns>
        public string GetSpecialHref(int iID, int Index, int siteid)
        {
            return LinkSpecial.Instance.GetInstance(siteid).GetSpecialHref(iID, Index);
        }

        /// <summary>
        /// 获取标签列表地址-用来获取分类，生成静态面页用
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public string TagsList(int p)
        {
            return LinkTags.Instance.GetInstance(GetSiteID).TagsList(p);
        }
        /// <summary>
        /// 获取标签列表地址-用来获取分类，生成静态面页用
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public string TagsList(int p, int siteid)
        {
            return LinkTags.Instance.GetInstance(siteid).TagsList(p);
        }
        /// <summary>
        /// 获取标签搜索结果列表地址
        /// </summary>
        /// <param name="id">标签ID</param>
        /// <param name="p">页码</param>
        /// <returns></returns>
        public string TagsSearchList(object id, int p)
        {
            return LinkTags.Instance.GetInstance(GetSiteID).TagsSearchList(id, p);
        }

        /// <summary>
        /// 获取标签搜索结果列表地址
        /// </summary>
        /// <param name="id">标签ID</param>
        /// <param name="p">页码</param>
        /// <returns></returns>
        public string TagsSearchList(object id, int p, int siteid)
        {
            return LinkTags.Instance.GetInstance(siteid).TagsSearchList(id, p);
        }
        /// <summary>
        /// 获取一个错误信息的连接
        /// </summary>
        /// <param name="ID">在后台添加的错误信息ID</param>
        /// <returns></returns>
        public string GetErrPageRw(string ID)
        {
            return Base.PageLink.GetBaseLinks.Get(GetSiteID).GetErrPageRw(ID);
        }
        /// <summary>
        /// 获取一个错误信息的连接
        /// </summary>
        /// <param name="ID">在后台添加的错误信息ID</param>
        /// <param name="siteid">站点ID</param>
        /// <returns></returns>
        public string GetErrPageRw(string ID, int siteid)
        {
            return Base.PageLink.GetBaseLinks.Get(siteid).GetErrPageRw(ID);
        }
        

        //public string IsOnlineImg(string UserName)
        //{
        //    bool IsOnline = AppStartInit.CheckIsOnline(UserName) > 0;

        //    if (IsOnline)
        //    {
        //        return string.Format("<img style=\"width:18px; height:15px\" title=\"在线\" src=\"/images/u_zx.gif\"  /><a href='{0}u/chatonline.aspx?suid={1}'>聊天</a>", Base.AppStartInit.IISPath, UserName);
        //    }
        //    else
        //    {
        //        return "";
        //    }
        //}

        #region 基础连接

        public string UserAlbumRw(int isiteid)
        {
            return Base.PageLink.GetBaseLinks.Get(isiteid).UserAlbumRw;
        }
        public string TaglistLinkRw(int isiteid)
        {
            return Base.PageLink.GetBaseLinks.Get(isiteid).TaglistLinkRw;
        }
        public string ClassLinkRw(int isiteid)
        {
            return Base.PageLink.GetBaseLinks.Get(isiteid).ClassLinkRw;
        }
        public string ContentLinkRw(int isiteid)
        {
            return Base.PageLink.GetBaseLinks.Get(isiteid).ContentLinkRw;
        }
        public string SpecialLinkRw(int isiteid)
        {
            return Base.PageLink.GetBaseLinks.Get(isiteid).SpecialLinkRw;
        }
        public string TopRw(int isiteid)
        {
            return Base.PageLink.GetBaseLinks.Get(isiteid).TopRw;
        }
        public string TagSearchLinkRw(int isiteid)
        {
            return Base.PageLink.GetBaseLinks.Get(isiteid).TagsSearchListLinkRw;
        }
        #endregion


    }
}
