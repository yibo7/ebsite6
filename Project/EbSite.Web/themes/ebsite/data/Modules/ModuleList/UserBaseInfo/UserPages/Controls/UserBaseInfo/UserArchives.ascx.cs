using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.Modules;
using EbSite.BLL.User;

namespace EbSite.Modules.UserBaseInfo.UserPages.Controls.UserBaseInfo
{
    public partial class UserArchives : MPUCBaseSaveForUser
    {
        
        public override string PageName
        {
            get
            {
                return "基础资料";
            }
        }
        public override string TipsText
        {
            get
            {
                return "以下信息请认真填写!";

            }
        }
        /// <summary>
        /// 是否添加到管理页面菜单之中
        /// </summary>
        public override bool IsAddToAdminMenus
        {
            get
            {
                return true;
            }
        }
        public override int OrderID
        {
            get
            {
                return 2;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            InitUserInfo();
            
        }
        /// <summary>
        /// 当前登录的用户的详细信息
        /// </summary>
        protected UserProfile UserInfos
        {
            get
            {
                //bool IsOk = Membership.ValidateUser(CurentUserName, Core.AplicationGlobal.UserPassDecode);
                bool IsOk = true; //以后配置是否可以查看个人信息
                if (IsOk)
                {

                    return UserProfile.GetUserProfile(UserName, UserModuleID);
                }
                return null;

            }
        }
        /// <summary>
        /// 此权限ID不为空，将要求用户登录后才能访问此页面
        /// </summary>
        public override string Permission
        {
            get
            {
                return "3";
            }
        }
        override protected string KeyColumnName
        {
            get
            {
                return "id";
            }
        }
        override public Guid ModuleMenuID
        {
            get
            {
                return new Guid("af379cdd-a674-4077-a9ed-e2896fb4c857");
            }
        }

        override protected void InitModifyCtr()
        {

            
        }
        private Guid UserModuleID
        {
            get
            {
                EbSite.BLL.User.UserGroupProfile ugp = UserGroupProfile.GetUserGroupProfile(UserGroups[0]);
                return ugp.UserModelID;
            }
        }
        /// <summary>
        /// 当前内容所属模型
        /// </summary>
        private EbSite.Entity.ModelClass mcMd;
        private List<PlaceHolder> lstPlaceHolder
        {
            get
            {
                return mcMd.GetFiledPlaceHolder(this);
            }
        }
        override protected bool IsSaveCloseWinBox
        {
            get
            {
                return false;
            }
        }
        override protected void SaveModel()
        {

            //if (IsCurrentUser)
            //{
            //    MembershipUser mu = Membership.GetUser(CurentUserName);
            //    mu.Email = txtEmail.Text.Trim();
            //    Membership.UpdateUser(mu);
            //}


            UserProfile uif;
            if (!Equals(UserInfos, null))
            {
                uif = UserInfos;
            }
            else //为空，说明是用户注册后第一次修改资料，所以先创建
            {
                uif = new UserProfile();
                uif.UserName = UserName;
                uif.UserModelID = UserModuleID;
            }

            foreach (PlaceHolder ph in mcMd.GetFiledPlaceHolder(this))
            {
                BLL.UserModel.Instance.InitSaveCtr(ph, ref uif);
            }
            

            uif.Save();
           

        }

        private void InitUserInfo()
        {
           EbSite.Base.EntityAPI.MembershipUserEb md =  HostApi.CurrentUser;

           ltUserName.Text = md.UserName;
           txtEmail.Text = md.emailAddress;
           ltLastLogin.Text = md.LastLoginDate.ToString();
           if(UserGroups.Length>0)
           {
               //EbSite.BLL.User.UserGroupProfile ugp = UserGroupProfile.GetUserGroupProfile(UserGroups[0]);

               //获取当前所属的模型
               mcMd = BLL.UserModel.Instance.GeModelByID(UserModuleID);
               
               //根据模型来输出要展示的控件
               BLL.UserModel.Instance.BindCustomControlsByModelID(this, mcMd, false);

               //if (IsCurrentUser)
               //{
               //    //根据模型来输出要展示的控件
               //    BLL.UserModel.Instance.BindCustomControlsByModelID(phCustomControls, this.Page, mcmd, false);

               //}
               //else
               //{
               //    BLL.UserModel.Instance.ShowInfoByModelID(phCustomControls, this.Page, mcmd, false);
               //    this.SaveUserInfo.Visible = false;
               //    mbs.Visible = false;
               //}


               //绑定当前用户数据
               if (!IsPostBack)
               {
                   if (!Equals(UserInfos, null))
                   {
                       foreach (PlaceHolder ph in lstPlaceHolder)
                       {
                           BLL.UserModel.Instance.InitModifyCtr(ph, UserInfos);
                       }

                       
                   }

               }
           }
           


        }
    }
}