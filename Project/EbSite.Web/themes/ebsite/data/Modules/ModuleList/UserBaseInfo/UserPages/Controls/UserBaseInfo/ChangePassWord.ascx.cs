using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.Modules;
using EbSite.BLL.User;

namespace EbSite.Modules.UserBaseInfo.UserPages.Controls.UserBaseInfo
{
    public partial class ChangePassWord : MPUCBaseSaveForUser
    {

        public override string PageName
        {
            get
            {
                return "修改密码";
            }
        }
        //public override string TipsText
        //{
        //    get
        //    {
        //        return "修改密码!";

        //    }
        //}
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
            if (!IsPostBack)
            {
              
            }

        }
        /// <summary>
        /// 此权限ID不为空，将要求用户登录后才能访问此页面
        /// </summary>
        public override string Permission
        {
            get
            {
                return "6";
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
                return new Guid("af371bdd-f674-4077-a9ed-e2896f55c857");
            }
        }
       
        override protected void InitModifyCtr()
        {

            EbSite.BLL.SpaceSetting.Instance.InitModifyCtr(SID, phCtrList);
        }
        override protected void SaveModel()
        {

            string sVUserName = UserName;
            string sOldPass = txtOldPass.Text.Trim();
            string sNewPass = txtPassWord.Text.Trim();
            string sComfirPass = txtCfPassWord.Text.Trim();
            if (!string.IsNullOrEmpty(sNewPass) && !string.IsNullOrEmpty(sComfirPass) && !string.IsNullOrEmpty(sOldPass))
            {
                if (sNewPass.Equals(sComfirPass))
                {
                    MembershipUser mu = Membership.GetUser(sVUserName);
                    sOldPass = UserIdentity.PassWordEncode(sOldPass);
                    bool ischanged = mu.ChangePassword(sOldPass, sNewPass);
                    if (!ischanged)
                    {
                        Tips("失败", "密码修改失败,请联系管理员!");
                    }

                }
                else
                {
                    Tips("两次输入密码不相等", "请确认密码!");
                }
            }
            else
            {
                Tips("密码不能为空", "请输入新密码与确认新密码!");
            }
                
            
            base.ShowTipsPop("设置完成");
        }
    }
}