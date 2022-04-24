using System;
using System.Web.Security;
using EbSite.Base.Configs.UserSetConfigs;
using EbSite.Base.ControlPage;

namespace EbSite.Web.AdminHt.Controls.Admin_Configs
{
    public partial class UserConfig : UserControlBaseSave
    {
        public override string Permission
        {
            get
            {
                return "149";
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
            throw new NotImplementedException();
        }
        override protected void SaveModel()
        {
            //ConfigsControl.Instance.UserGroup = UserGroup.SelectedValue;
            ConfigsControl.Instance.UserGroupID = int.Parse(UserGroup.SelectedValue);
            ConfigsControl.Instance.IsAllowRegister = IsAllowRegister.SelectedValue;
            ConfigsControl.Instance.IfCode = IfCode.SelectedValue;
            ConfigsControl.Instance.AllowUserType = int.Parse(drpAllowUserType.SelectedValue);
            ConfigsControl.Instance.ErrLoginNumLock = int.Parse(ErrLoginNumLock.Text);
            ConfigsControl.Instance.LockTime = int.Parse(LockTime.Text);
            ConfigsControl.Instance.NoAllowToRegInfo = NoAllowToRegInfo.Text;
            //ConfigsControl.Instance.IPRestrict = IPRestrict.Text;
            ConfigsControl.Instance.RegisterPact = RegisterPact.CtrValue;
            //ConfigsControl.Instance.GroupType = int.Parse(GroupType.SelectedValue);
            //ConfigsControl.Instance.IsAuditingNewUser = IsAuditingNewUser.Checked;
            ConfigsControl.Instance.DefaultCredits = int.Parse(DefaultCredits.Text);

            ConfigsControl.Instance.StarIP = txtStarIP.Text;
            ConfigsControl.Instance.EndIP = txtEndIP.Text;
            ConfigsControl.Instance.IPSetDateTime = DateTime.Parse(dtEndDate.Value);


            ConfigsControl.Instance.ModifyIcoInCredit = int.Parse(txtModifyIcoInCredit.Text);
            ConfigsControl.Instance.AddContentInCredit = int.Parse(txtAddContentInCredit.Text);
            ConfigsControl.Instance.InviteRegInCredit = int.Parse(txtInviteRegInCredit.Text);
            ConfigsControl.Instance.LoginInCredit = int.Parse(txtLoginInCredit.Text);
            ConfigsControl.Instance.ToCommentInCredit = int.Parse(txtToCommentInCredit.Text);
            ConfigsControl.Instance.UserCenter = txtUserCenter.Text;

            ConfigsControl.Instance.DefaultLevel = Core.Utils.StrToInt(UserLeval.CtrValue, 1);



            #region 提示语

            ConfigsControl.Instance.IsHeader = this.IsHeader.Checked;
            ConfigsControl.Instance.HeaderHint = this.HeaderHint.Text.Trim();
            ConfigsControl.Instance.OrderHeader =int.Parse( this.OrderHeader.SelectedValue);

            ConfigsControl.Instance.IsEmail = this.IsEmail.Checked;
            ConfigsControl.Instance.EmailHint = this.EmailHint.Text.Trim();
            ConfigsControl.Instance.OrderEmail = int.Parse(this.OrderEmail.SelectedValue);

            ConfigsControl.Instance.IsTel = this.IsTel.Checked;
            ConfigsControl.Instance.TelHint = this.TelHint.Text.Trim();
            ConfigsControl.Instance.OrderTel = int.Parse(this.OrderTel.SelectedValue);

            #endregion

            ConfigsControl.Instance.OnlineTimeSpan = int.Parse(txtOnlineTimeSpan.Text);
            ConfigsControl.Instance.OnlineTimeSpanModel = int.Parse(drpOnlineTimeSpanModel.Text);

            ConfigsControl.SaveConfig();


            Core.FSO.FObject.WriteFileUtf8(Server.MapPath(IISPath+ "agree.htm"), ConfigsControl.Instance.RegisterPact);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindUserGroup();
                //UserGroup.SelectedValue = ConfigsControl.Instance.UserGroup;
                UserGroup.SelectedValue = ConfigsControl.Instance.UserGroupID.ToString();
                IsAllowRegister.SelectedValue = ConfigsControl.Instance.IsAllowRegister;
                IfCode.SelectedValue = ConfigsControl.Instance.IfCode;
                //EmailVerification.SelectedValue = ConfigsControl.Instance.EmailVerification;
                ErrLoginNumLock.Text = ConfigsControl.Instance.ErrLoginNumLock.ToString();
                LockTime.Text = ConfigsControl.Instance.LockTime.ToString();
                NoAllowToRegInfo.Text = ConfigsControl.Instance.NoAllowToRegInfo;
                //IPRestrict.Text = ConfigsControl.Instance.IPRestrict;
                RegisterPact.CtrValue = ConfigsControl.Instance.RegisterPact;
                //GroupType.SelectedValue = ConfigsControl.Instance.GroupType.ToString();
                //IsAuditingNewUser.Checked = ConfigsControl.Instance.IsAuditingNewUser;
                DefaultCredits.Text = ConfigsControl.Instance.DefaultCredits.ToString();
                drpAllowUserType.SelectedValue = ConfigsControl.Instance.AllowUserType.ToString();
                txtStarIP.Text = ConfigsControl.Instance.StarIP;
                txtEndIP.Text = ConfigsControl.Instance.EndIP;
                dtEndDate.Value = ConfigsControl.Instance.IPSetDateTime.ToString();

                txtModifyIcoInCredit.Text = ConfigsControl.Instance.ModifyIcoInCredit.ToString();
                txtAddContentInCredit.Text = ConfigsControl.Instance.AddContentInCredit.ToString();
                txtInviteRegInCredit.Text = ConfigsControl.Instance.InviteRegInCredit.ToString();
                txtLoginInCredit.Text = ConfigsControl.Instance.LoginInCredit.ToString();
                txtToCommentInCredit.Text = ConfigsControl.Instance.ToCommentInCredit.ToString();
                txtUserCenter.Text = ConfigsControl.Instance.UserCenter;
                UserLeval.CtrValue = ConfigsControl.Instance.DefaultLevel.ToString();

                #region 提示语

                this.IsHeader.Checked = ConfigsControl.Instance.IsHeader;
                this.HeaderHint.Text = ConfigsControl.Instance.HeaderHint;
                this.OrderHeader.SelectedValue = ConfigsControl.Instance.OrderHeader.ToString();

                this.IsEmail.Checked = ConfigsControl.Instance.IsEmail;
                this.EmailHint.Text = ConfigsControl.Instance.EmailHint;
                this.OrderEmail.SelectedValue = ConfigsControl.Instance.OrderEmail.ToString();

                this.IsTel.Checked = ConfigsControl.Instance.IsTel;
                this.TelHint.Text = ConfigsControl.Instance.TelHint;
                this.OrderTel.SelectedValue = ConfigsControl.Instance.OrderTel.ToString();

                #endregion

                txtOnlineTimeSpan.Text = ConfigsControl.Instance.OnlineTimeSpan.ToString();
                drpOnlineTimeSpanModel.Text = ConfigsControl.Instance.OnlineTimeSpanModel.ToString();
            }
        }

        private void BindUserGroup()
        {

            UserGroup.DataSource = BLL.User.UserGroupProfile.UserGroupProfiles;//Roles.GetAllRoles();
            UserGroup.DataTextField = "groupname";
            UserGroup.DataValueField = "id";
            UserGroup.DataBind();

            UserLeval.DataTextField = "LevelName";
            UserLeval.DataValueField = "id";
            UserLeval.DataSource = EbSite.BLL.UserLevel.Instance.GetListArray("");
            UserLeval.DataBind();

        }

        //protected void btnAdd_Click(object sender, EventArgs e)
        //{
        //    ConfigsControl.Instance.UserGroup = UserGroup.SelectedValue;
        //    ConfigsControl.Instance.IsAllowRegister = IsAllowRegister.SelectedValue;
        //    ConfigsControl.Instance.IfCode = IfCode.SelectedValue;
        //    ConfigsControl.Instance.EmailVerification = EmailVerification.SelectedValue;
        //    ConfigsControl.Instance.ErrLoginNumLock = int.Parse(ErrLoginNumLock.Text);
        //    ConfigsControl.Instance.LockTime = int.Parse(LockTime.Text);
        //    ConfigsControl.Instance.NoAllowToRegInfo = NoAllowToRegInfo.Text;
        //    ConfigsControl.Instance.IPRestrict = IPRestrict.Text;
        //    ConfigsControl.Instance.RegisterPact = RegisterPact.Text;
        //    ConfigsControl.Instance.GroupType = int.Parse(GroupType.SelectedValue);
        //    ConfigsControl.Instance.IsAuditingNewUser = IsAuditingNewUser.Checked;
        //    ConfigsControl.Instance.DefaultCredits = int.Parse(DefaultCredits.Text);
            
        //    ConfigsControl.SaveConfig();
        //}
    }
}