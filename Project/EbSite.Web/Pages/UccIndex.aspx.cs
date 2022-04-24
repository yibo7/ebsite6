using System;
using System.Collections.Generic;
using EbSite.Base;
using EbSite.Base.Modules;
using EbSite.BLL.User;
using EbSite.Pages;

namespace EbSite.Web.Pages
{
    public partial class UccIndex : MPageForUer
    {
        /// <summary>
        /// 获取当前模块所属性的站点ID
        /// </summary>
        override protected int ModuleSiteID
        {
            get
            {
                return GetSiteID;//用户主页，与模板无关，所以获取url传来的siteiD
            }
        }
        public override string PageName
        {
            get
            {
                return "控制页面首页";
            }
        }
        protected int Credits = 0; //积分
        protected decimal iBalance = 0;//余款
        protected int MsgCount = 0;//短消息总数
        protected int FavCount = 0;//收藏总数
        protected int TheThirdCount = 0;//朋友总数
        protected bool IsAdmin = false;
        protected string UserLevelName = string.Empty;
        protected EbSite.Base.EntityAPI.MembershipUserEb UserInfos;
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {
               
                //CheckUserIndex();

                inithead();

                if(UserID>0)
                {
                    Base.EBSiteEventArgs.UccIndexPageLoadEventArgs Args = new Base.EBSiteEventArgs.UccIndexPageLoadEventArgs(UserID,  this.Page);
                    Base.EBSiteEvents.OnUccIndexPageLoadEvent(null, Args);


                    UserInfos = MembershipUserEb.Instance.GetEntity(UserID);
                    
                    Credits = UserInfos.Credits;
                    IsAdmin = UserInfos.ManagerID > 0;
                    
                    EbSite.Entity.UserLevel userLevel = EbSite.BLL.UserLevel.Instance.GetEntity(UserInfos.UserLevel);
                    UserLevelName = userLevel.LevelName;

                    List<Entity.PayPass> ls = EbSite.BLL.PayPass.Instance.GetListArray(1, string.Concat("UserId=" , base.UserID), "");
                    if (ls.Count > 0)
                    {
                        iBalance = ls[0].Balance;
                    }

                    //短消息
                    MsgCount = EbSite.BLL.Msg.Msg_Count(base.UserID, true);
                    //收藏总数
                    FavCount = EbSite.BLL.Favorite.GetCount(string.Concat("userid=", base.UserID));
                    //朋友总数
                    TheThirdCount = EbSite.BLL.TheThirdLoginCode.Instance.GetCount(string.Concat("userid=", base.UserID));

                }
                else
                {

                    HostApi.GoToLoginPC();
                }

             
                

            }
        }
        //private void CheckUserIndex()
        //{
        //    if (!string.IsNullOrEmpty(HostApi.CurrentFirstGroup.GetMenuUrlForThisGroup))
        //    {
        //        Response.Redirect(HostApi.CurrentFirstGroup.GetMenuUrlForThisGroup);
        //    }

        //}
        private void inithead()
        {
            base.SeoTitle = string.Concat("管理首页-", AppStartInit.UserNiName);
            //base.SeoKeyWord = GetSeoWord(Base.Configs.ContentSet.ConfigsControl.Instance.SeoSiteIndexKeyWord, "");
            //base.SeoDes = GetSeoWord(Base.Configs.ContentSet.ConfigsControl.Instance.SeoSiteIndexDes, "");

            base.SeoKeyWord = GetSeoWord(SeoSite.SeoSiteIndexKeyWord, "");
            base.SeoDes = GetSeoWord(SeoSite.SeoSiteIndexDes, "");
        }
       override protected void MPage_LoadComplete(object sender, EventArgs e)
        {
             

        }

        override protected void BindTopTags()
        {
            
        }

        //override protected void InitStyle()
        //{
            
        //}
    }
}
