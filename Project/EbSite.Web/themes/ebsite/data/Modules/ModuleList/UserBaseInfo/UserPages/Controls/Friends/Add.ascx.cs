using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.BLL;
using EbSite.Base.Modules;
using EbSite.Entity;
using System.Collections;

namespace EbSite.Modules.UserBaseInfo.UserPages.Controls.Friends
{
    public partial class Add : MPUCBaseSaveForUser
    {

        public override Guid ModuleMenuID
        {
            get
            {
                return new Guid("63a7536b-dc2d-4e2a-87b4-ab2bcb8f9e34");
            }
        }
        public override string PageName
        {
            get
            {
                return "加好友";
            }
        }

        /// <summary>
        /// 是否添加到管理页面菜单之中
        /// </summary>
        public override bool IsAddToAdminMenus
        {
            get
            {
                return false;
            }
        }
        public override int OrderID
        {
            get
            {
                return 3;
            }
        }
        private int GetFriendUserID
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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (UserID >0)
            {
                if (UserID == GetFriendUserID)
                {
                    Tips("出错了","不能自己加自己为好友！");
                }
                txtMsg.Text = string.Format("我是{0},请加我为好友。", UserNiname);
            }
            else
            {
                Tips("请先登录", "本页面需要登录内能访问!");
            }
            


            

        }
    
        override protected string KeyColumnName
        {
            get
            {
                return "id";
            }
        }
        override protected void InitModifyCtr()
        {
             
        }

        override protected void SaveModel()
        {
            //EbSite.BLL.FriendList.GetList_ByFriendAllow()
            //Base.EntityAPI.MembershipUserEb mdUser = BLL.User.MembershipUserEb.Instance.GetEntity(GetFriendUserID);
            //0为不存在好友关系，1两人已经是好友,2对方已经邀请你,3你已经邀请过对方
            int ishave = BLL.FriendList.Exists(UserID,GetFriendUserID);
           if (ishave==0)
           {
               Base.EntityAPI.MembershipUserEb mdUser = BLL.User.MembershipUserEb.Instance.GetEntity(GetFriendUserID);
               BLL.FriendList md = new BLL.FriendList();
               md.UserID = mdUser.id;
               md.UserName = mdUser.UserName;
               md.UserNiName = mdUser.NiName;
               md.FriendID = UserID;
               md.FriendName = UserNiname;
               md.FriendNiName = UserNiname;
               md.Save();

               HostApi.SendSysMsg(string.Format("来自{0}的好友邀请", UserNiname), string.Format("来自{0}的好友邀请,<a href='{1}'>点击这里查看</a>", UserNiname, HostApi.GetModuleUrl("470ba0af-6b6d-4636-9d27-3f39c139562f", "bcf131f0-a9aa-4597-9fd4-8350ebffe171")), mdUser.id, true);
               
               Tips("您的好友邀请已经发出，等待对方审核通过！");
           }
           else if (ishave == 1)
           {
               Tips("您和TA已经是好友,请不要再添加！");
           }
           else if (ishave == 2) //定向到好友审核页面
           {
               Tips("已经存在好友","对方已经邀请过你，请您通过审核！", HostApi.GetModuleUrl("470ba0af-6b6d-4636-9d27-3f39c139562f", "bcf131f0-a9aa-4597-9fd4-8350ebffe171"));
           }
           else if (ishave == 3)
           {
               Tips("您已经邀请过对方,正在等待对方审核，请不要再邀请！");
           }
        }
       
    }
}