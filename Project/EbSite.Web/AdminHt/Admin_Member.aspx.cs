using System;
using EbSite.Base.Page;
using EbSite.Pages;

namespace EbSite.Web.AdminHt
{
    public partial class Admin_Member : EbSite.Base.Page.ManagePage
    {
        /// <summary>
        /// 弹出窗口模式
        /// </summary>
        /// <value><c>true</c> if this instance is mini master; otherwise, <c>false</c>.</value>
        protected override MasterType eMasterType
        {
            get
            {
                if (PageType == 3)
                    return MasterType.Mini;
                return MasterType.Custom;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {

            base.SetContolsPath("Admin_Member");
        }

        /// <summary>
        /// 添加控件
        /// </summary>
        protected override void AddControl()
        {
            if (PageType == 0)
            {
                base.LoadAControl("AddMemberGroup.ascx");
            }
            else if (PageType == 1)
            {
                base.LoadAControl("AddMember.ascx");
            }
            //else if (PageType == 2)
            //{
            //    base.LoadAControl("ChangePassword.ascx");
            //}
            else if (PageType == 3)
            {
                base.LoadAControl("MemberToGroup.ascx");
            }
            else if (PageType == 8)
            {

                base.LoadAControl("AddModelOfMember.ascx");
            }
            else if (PageType == 9)
            {
                //phBody.Controls.Add(LoadControl(GetControlsPath + "/ModelMemberList.ascx"));
                base.LoadAControl("ModelMemberList.ascx");
            }
            else if (PageType == 10)
            {
                //phBody.Controls.Add(LoadControl(GetControlsPath + "/ChangePassword.ascx"));
                base.LoadAControl("ChangePassword.ascx");
            }
            else if (PageType == 11)
            {

                base.LoadAControl("UserLavelAdd.ascx");
            }
            else if (PageType == 12)
            {
                base.LoadAControl("MemberInfo.ascx");
            }
            else if (PageType == 13)
            {
                base.LoadAControl("ChangePass.ascx");
            }
            else
            {
                base.AddControl();
            }
            //if (phBody == null) return;
            //switch (GetMat)
            //{

            //    case 0:
            //        phBody.Controls.Add(LoadControl(GetControlsPath + "/MemberList.ascx"));
            //        break;
            //    case 1:
            //        phBody.Controls.Add(LoadControl(GetControlsPath + "/ManageMemberGroup.ascx"));
            //        break;
            //    case 2:
            //        phBody.Controls.Add(LoadControl(GetControlsPath + "/AddMember.ascx"));
            //        break;
            //    case 3:
            //        phBody.Controls.Add(LoadControl(GetControlsPath + "/AddMemberGroup.ascx"));
            //        break;
            //    case 4:
            //        phBody.Controls.Add(LoadControl(GetControlsPath + "/AuditingMember.ascx"));
            //        break;
            //    case 5:
            //        phBody.Controls.Add(LoadControl(GetControlsPath + "/SendEmail.ascx"));
            //        break;
            //    case 6:
            //        phBody.Controls.Add(LoadControl(GetControlsPath + "/SendMessage.ascx"));
            //        break;


            //    case 7:
            //        phBody.Controls.Add(LoadControl(GetControlsPath + "/IntegralSetting.ascx"));
            //        break;


            //    case 8:
            //        phBody.Controls.Add(LoadControl(GetControlsPath + "/AddModelOfMember.ascx"));
            //        break;
            //    case 9:
            //        phBody.Controls.Add(LoadControl(GetControlsPath + "/ModelMemberList.ascx"));
            //        break;
            //    case 10:
            //        phBody.Controls.Add(LoadControl(GetControlsPath + "/ChangePassword.ascx"));
            //        break;

            //}

        }

        //protected override void BindTopTags()
        //{
        //    ucTopTags.Index = (int)CurrentAdtion;
        //    ucTopTags.Title = "会员管理";
        //    ucTopTags.Items = "会员列表,?mat=0|管理会员组,?mat=1|添加会员,?mat=2|添加会员组,?mat=3|审核会员,?mat=4|邮件发送,?mat=5|短信发送,?mat=6|积分设置,?mat=7|添加用户模型,?mat=8|管理用户模型,?mat=9";
        //}
    }
}
