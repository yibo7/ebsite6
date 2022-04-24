using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.BLL.User;
using EbSite.Base.ControlPage;
using EbSite.Mvc.Token;

namespace EbSite.Web.AdminHt.Controls.Admin_Member
{
    public partial class MemberInfo : UserControlBaseSave
    {
        public override string Permission
        {
            get
            {
                return "76";
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
            //初始扩展模型
            EbSite.BLL.User.UserGroupProfile ugp = UserGroupProfile.GetUserGroupProfile(GetUserRolesName);
            Guid UserModuleID = ugp.UserModelID;
            UserProfile UserInfos = UserProfile.GetUserProfile(GetUserName, UserModuleID);
            //获取当前所属的模型
            EbSite.Entity.ModelClass mcMd = BLL.UserModel.Instance.GeModelByID(UserModuleID);

            UserProfile uif;
            if (!Equals(UserInfos, null))
            {
                uif = UserInfos;
            }
            else //为空，说明是用户注册后第一次修改资料，所以先创建
            {
                uif = new UserProfile();
                uif.UserName = GetUserName;
                uif.UserModelID = UserModuleID;
            }

            foreach (PlaceHolder ph in mcMd.GetFiledPlaceHolder(this))
            {
                BLL.UserModel.Instance.InitSaveCtr(ph, ref uif);
            }


            uif.Save();
            int uid = Core.Utils.StrToInt(SID);
            Base.EntityAPI.MembershipUserEb md = EbSite.Base.Host.Instance.EBMembershipInstance.Users_GetEntity(uid);


            md.emailAddress = txtEmail.Text;
            md.UserLevel = int.Parse(drpUserLv.SelectedValue);
            md.MobileNumber = txtMobileNumber.Text;
            md.IsApproved = cbIsApproved.Checked;
            md.IsLockedOut = cbIsLockedOut.Checked;
            md.Credits = int.Parse(txtCredits.Text);
            md.NiName = txtNiName.Text;
            md.Sign = txtSign.Text;
           
            
            md.UserLevel = int.Parse(drpUserLv.SelectedValue);
            md.Save();

        }
        private string GetUserRolesName;
        private string GetUserName;
        protected void Page_Load(object sender, EventArgs e)
        {
            ctbTag.EndLiteral = llTagEnd;
            ctbTag.Items = string.Format("用户基本信息#tg1|用户模型扩展信息#tg2");
           
            int uid = Core.Utils.StrToInt(SID);
            EbSite.Base.EntityAPI.MembershipUserEb mdGetU = EbSite.Base.Host.Instance.GetUserByID(uid);
            GetUserName = mdGetU.UserName;
            string[] r = Roles.GetRolesForUser(GetUserName);
            if (r.Length > 0) GetUserRolesName = r[0];
            if (string.IsNullOrEmpty(GetUserName) || string.IsNullOrEmpty(GetUserRolesName))
            {
                Tips("出错了","当前用户还没分配用户组,请先为其分配相应用户组再访问此页面!");
                return;
            }

            if(!IsPostBack)
            {
              

                Base.EntityAPI.MembershipUserEb md = EbSite.Base.Host.Instance.EBMembershipInstance.Users_GetEntity(uid);

                txtUserName.Text = md.UserName;
                txtEmail.Text = md.emailAddress;
                drpUserLv.SelectedValue = md.UserLevel.ToString();
                txtMobileNumber.Text = md.MobileNumber;
                cbIsApproved.Checked = md.IsApproved;
                cbIsLockedOut.Checked = md.IsLockedOut;
                txtCredits.Text = md.Credits.ToString();
                txtNiName.Text = md.NiName;
                txtSign.Text = md.Sign;
                llCreateDate.Text = md.CreateDate.ToString();
                llLastLockoutDate.Text = md.LastLockoutDate.ToString();
                llLastLoginDate.Text = md.LastLoginDate.ToString();
                llLastPasswordChangedDate.Text = md.LastPasswordChangedDate.ToString();
                TokenInfo tki = new TokenInfo();
                tki.GroupId = md.GroupID;
                tki.LastTime = DateTime.Now;
                tki.Pass = md.Password;
                tki.UserId = md.id;
                tki.UserName = md.UserName;
                tki.UserNiname = md.NiName;
                lbToken.Text = EbToken.GetTokenStr(tki);

            }

            if (uid > 0)
            {

                
                //初始扩展模型
                EbSite.BLL.User.UserGroupProfile ugp = UserGroupProfile.GetUserGroupProfile(GetUserRolesName);
                Guid UserModuleID = ugp.UserModelID;

                //获取当前所属的模型
                EbSite.Entity.ModelClass mcMd = BLL.UserModel.Instance.GeModelByID(UserModuleID);

                //根据模型来输出要展示的控件
                BLL.UserModel.Instance.BindCustomControlsByModelID(this, mcMd, true);

                //绑定当前用户数据
                List<PlaceHolder> lstPlaceHolder = mcMd.GetFiledPlaceHolder(this);
                UserProfile UserInfos = UserProfile.GetUserProfile(GetUserName, UserModuleID);
                if (UserInfos!=null) //第一次登录是为null,所以这里要做个验证
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