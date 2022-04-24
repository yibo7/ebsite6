using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Web.UI.WebControls;
using EbSite.Base;
using EbSite.Base.ExtWidgets.WidgetsManage;

namespace EbSite.Widgets.GetUsers
{
    public partial class widget : WidgetBase
    {
        public override void LoadData()
        {
            if (!base.IsPostBack)
            {
                

                int iTop = 10;
                string TemPath = "";


                StringDictionary settings = GetSettings();
                if (settings.ContainsKey("txtCount"))
                {
                    iTop = int.Parse(settings["txtCount"]);

                }

                if (settings.ContainsKey("txtTem"))
                {
                    TemPath = settings["txtTem"];
                }
                
                int itid = 0;

                //0表示父ID随参数变动，-1表示除一级分类外始终使用当前分类的父ID
                if (settings.ContainsKey("drpType"))
                {
                    itid = int.Parse(settings["drpType"]);
                }

                if (itid == 1) //最新用户
                {
                    rpAllClass.DataSource = BLL.User.MembershipUserEb.Instance.GetListOfNews(iTop);
                }
                else if (itid==2) //最新来访
                {
                    if (!string.IsNullOrEmpty(uid))
                    rpAllClass.DataSource = BLL.RecentVisitors.GetListOfNews(iTop, int.Parse(uid));
                }
                else if (itid == 3) //我的好友
                {
                    if (!string.IsNullOrEmpty(uid))
                        rpAllClass.DataSource = BLL.FriendList.GetList_All(int.Parse(uid));
                }
                else if (itid == 4) //个人动态
                {
                    if (!string.IsNullOrEmpty(uid))
                        rpAllClass.DataSource = BLL.UserNews.GetList_ByUser(uid, iTop);
                }
                else if (itid == 5) //好友动态
                {
                    if (!string.IsNullOrEmpty(uid))
                        rpAllClass.DataSource = BLL.UserNews.GetList_FriendNews(int.Parse(uid), iTop);
                }
                else if (itid == 6) //积分达人
                {
                    rpAllClass.DataSource = BLL.User.MembershipUserEb.Instance.GetListOfCrdits(iTop);
                }
                TemPath = base.TemBll.GetTemPath(TemPath);
                if (!string.IsNullOrEmpty(TemPath))
                {
                    
                    rpAllClass.ItemTemplate = LoadTemplate(TemPath);
                }
                rpAllClass.DataBind();
                
            }
        }

        public override string Name
        {
            get { return "GetUsers"; }
        }

        public override bool IsEditable
        {
            get { return true; }
        }


        //////////////////////////////////////
        protected string uid
        {
            get
            {
                if (!string.IsNullOrEmpty(Request["uid"]))
                {
                    return Request["uid"];
                }
                else
                {
                    return AppStartInit.UserName;
                }
               
            }
        }
        
    }
}