using System;
using System.Web.Security;
using EbSite.Base;
using EbSite.Base.Configs.UserSetConfigs;
using EbSite.BLL.User;
using EbSite.Core;
using EbSite.Core.Strings;
using EbSite.Pages;

namespace EbSite.Web.Pages
{

    public partial class reg : EbSite.Base.Page.CustomPage
    {
        /// <summary>
        /// 邀请人的用户ID  杨欢乐 2011-12-31 添加
        /// </summary>
        private int YQUserID
        {
            get
            {
                if (!string.IsNullOrEmpty(Request["vuid"]))
                {
                    string gid = Request["vuid"];

                    return int.Parse(gid);
                }
                else
                {
                    return -1;
                }
            }
        }

        /// <summary>
        /// 获取用户组ID，如果此ID大于0那么默认当前注册的用户将归于当前用户组
        /// </summary>
        private int GetGroupID
        {
            get
            {
                if (!string.IsNullOrEmpty(Request["gid"]))
                {
                    string gid = Request["gid"];

                    return BLL.User.UserGroupProfile.GroupIDDecode(gid);
                }
                else
                {
                    return BLL.User.UserGroupProfile.GroupIDDecode("hY7Z0/iDL3I=");
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string sTitle = "";
                //注册成功后的定向
                if (GetGroupID > 0) //指定会员组
                {
                    sTitle = BLL.User.UserGroupProfile.GetUserGroupProfile(GetGroupID).GroupName;
                }
                else //获取默认会员组
                {
                    sTitle ="会员注册";//Base.Configs.UserSetConfigs.ConfigsControl.Instance.UserGroup;

                }

                base.SeoTitle = string.Concat(sTitle, "注册-", SiteName);

            }
        }
        protected void btnAddUser_Click(object sender, EventArgs e)
        {
            //RegUser(string sUserName, string Pass, string sRpass, string sEmail, bool IsManager, int GroupID,out MembershipCreateStatus ms,out string RetunUrl,int vUserID,string FromUrl)
            //string rturl = "";
            //RegStatus ms;
            //string Ip = EbSite.Core.Utils.GetClientIP();
            //int UserID = EbSite.Base.Host.Instance.RegUser(txtUserName.Text, txtPassWord.Text, txtCfPassWord.Text, txtEmail.Text, false, GetGroupID, out ms, out rturl, YQUserID, Base.Host.Instance.GetReurl, "", 1, Ip, "reg.aspx提交注册");

           
            //if (UserID > 0) //注册成功,开始登录
            //{
            //    Response.Redirect(rturl);


            //    #region 放弃代码

            //    #region  杨欢乐添加 2011-12-31 给邀请人加积分  //还有点不完善 要验证IP 地址
            //    //if (YQUserID > 0)
            //    //{
            //    //    EbSite.Base.EntityAPI.MembershipUserEb umd =EbSite.BLL.User.MembershipUserEb.Instance.GetEntity(YQUserID);
            //    //    if (!umd.IsHaveAvatar)
            //    //    {
            //    //        //给邀请人加积分 要获得积分
            //    //        int score = int.Parse(ConfigsControl.Instance.InviteRegInCredit.ToString());
            //    //        umd.Credits += score;
            //    //        EbSite.BLL.User.MembershipUserEb.Instance.Update(umd);

            //    //    }
            //    //}

            //    #endregion


            //    //string sRdirect = "";

            //    ////如果激活方式为自动，将登录用户
            //    //if (Base.Configs.UserSetConfigs.ConfigsControl.Instance.AllowUserType == 0)
            //    //{
            //    //    string UserName = txtUserName.Text.Trim();
            //    //    string Pass = UserIdentity.PassWordEncode(txtCfPassWord.Text.Trim());
            //    //    BLL.User.UserIdentity.WriteUserIdentity(UserID.ToString(), UserName, UserName, Pass);
            //    //    //注册成功后的定向
            //    //    if (GetGroupID > 0) //指定会员组d
            //    //    {
            //    //        sRdirect = BLL.User.UserGroupProfile.GetUserGroupProfile(GetGroupID).UccUrl;
            //    //    }
            //    //    else //获取默认会员组
            //    //    {
            //    //        string GroupName = Base.Configs.UserSetConfigs.ConfigsControl.Instance.UserGroup;
            //    //        sRdirect = BLL.User.UserGroupProfile.GetUserGroupProfile(GroupName).UccUrl;

            //    //    }

            //    //    if (!string.IsNullOrEmpty(sRdirect))
            //    //    {
            //    //        Response.Redirect(sRdirect);
            //    //    }
            //    //    else
            //    //    {
            //    //        Core.AplicationGlobal.LoginToReurl();
            //    //    }
            //    //}
            //    //else if (Base.Configs.UserSetConfigs.ConfigsControl.Instance.AllowUserType == 1) //管理员激活
            //    //{
            //    //    Response.Redirect(GetTipsUrl(4));
            //    //}
            //    //else if (Base.Configs.UserSetConfigs.ConfigsControl.Instance.AllowUserType == 2)//email激活
            //    //{
            //    //    Response.Redirect(GetTipsUrl(5));
            //    //}

            //    #endregion

               
            //}
            //else
            //{
            //    if (RegStatus.已经存在此帐号 == ms)
            //    {
            //        cJavascripts.MessageShowBack("已经存在此用户名,请换一个用户名再注册!");
            //    }
            //    if (RegStatus.已经存在此Email == ms)
            //    {
            //        cJavascripts.MessageShowBack("已经存在此Email,请换一个Email再注册!");
            //    }
            //}
        }
    }
}
