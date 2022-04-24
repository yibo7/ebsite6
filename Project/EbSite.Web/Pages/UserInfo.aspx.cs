using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.EBSiteEventArgs;
using EbSite.Base.EntityAPI;

namespace EbSite.Web.Pages
{
    public partial class UserInfo : EbSite.Base.Page.CustomPage
    {
        protected MembershipUserEb Model;
        private int CUserID
        {
            get
            {
                if (!string.IsNullOrEmpty(Request["uid"]))
                {
                    return int.Parse(Request["uid"]);
                }
                return 0;
            }
        }

        public int PageIndex
        {
            get
            {
                if (!string.IsNullOrEmpty(Request.QueryString["p"]))
                    return Convert.ToInt32(Request.QueryString["p"]);
                else
                    return 1;
            }
        }

        protected int iSearchCount = 0;
        private int iPageSize
        {
            get
            {
                if (!Equals(pgCtr, null) && pgCtr.PageSize > 0)
                {
                    return pgCtr.PageSize;
                }
                else
                {
                    return 30;
                }

            }

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (CUserID > 0)
            {
                Model = HostApi.GetUserByID(CUserID);
                EbSite.Base.EBSiteEventArgs.UserInfoEventArgs Args = new UserInfoEventArgs(null, this.Context, base.GetSiteID, "", Model, this.Page);
                Base.EBSiteEvents.OnUserInfo(null, Args);
                if (!Equals(rpDataList, null))
                {
                    if (Args.StopLoad) //有事件阻住
                    {
                        if (!string.IsNullOrEmpty(Args.GetTemPath))
                            rpDataList.ItemTemplate = LoadTemplate(Args.GetTemPath);
                        rpDataList.DataSource = Args.ObDataSource;
                        rpDataList.DataBind();
                    }
                    else
                    {
                        rpDataList.DataSource = EbSite.Base.AppStartInit.NewsContentInstDefault.GetListPagesOFUser(PageIndex, iPageSize, CUserID, out iSearchCount, "", GetSiteID);
                        rpDataList.DataBind();
                    }

                    intpages();
                }

                //最近来访
                if (!Equals(rpVisit, null))
                {
                    rpVisit.DataSource = BLL.RecentVisitors.GetListOfNews(12, CUserID);
                    rpVisit.DataBind();
                }

                //好友列表
                if (!Equals(rpFrineds, null))
                {
                    rpFrineds.DataSource = BLL.FriendList.GetList_All(CUserID, 12);
                    rpFrineds.DataBind();
                }
                //更新来访信息,用背景线程去执行
                BLL.RecentVisitors.UpdateVisitors(CUserID);

                base.SeoTitle = string.Concat(Model.NiName, "的空间");
            }
            else
            {
                Tips("出错了", "你访问的地址有问题,找不到当前用户？");
            }
        }

        protected void intpages()
        {
            if (!Equals(pgCtr, null))
            {

                //if (string.IsNullOrEmpty(pgCtr.ReWritePatchUrl)) //外面可以自定义
                //    pgCtr.ReWritePatchUrl = string.Concat(GetClassID, "-{0}-", OrderBy, HostApi.ClassLinkRw(GetSiteID)); //{0} 页码
                pgCtr.ReWritePatchUrl = string.Concat(EbSite.Base.Host.Instance.GetUserSiteUrl(CUserID), "?p={0}");
                pgCtr.AllCount = iSearchCount;
                pgCtr.PageSize = iPageSize;
                //pgCtr.OtherPram = string.Format("cid,{0}", GetClassID);
                pgCtr.CurrentClass = "CurrentPageCoder";
                pgCtr.ParentClass = "PagesClass";
            }

        }

    }
}