using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.Modules;

namespace EbSite.Modules.UserBaseInfo.UserPages.Controls.UserBaseInfo
{
    public partial class UserEmail : MPUCBaseSaveForUser
    {
       
        public override string PageName
        {
            get
            {
                return "修改Email";
            }
        }
        public override string TipsText
        {
            get
            {
                return "请添写您的Email!";

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
                return 7;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtEmail.Text = EbSite.Base.Host.Instance.CurrentUser.emailAddress; 
            }

        }
        /// <summary>
        /// 此权限ID不为空，将要求用户登录后才能访问此页面
        /// </summary>
        public override string Permission
        {
            get
            {
                return "5";
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
                return new Guid("477c77b4-be69-4d37-9593-90884fabc19c");
            }
        }

        override protected void InitModifyCtr()
        {

        }
       
        override protected void SaveModel()
        {
            if (Base.Host.Instance.CurrentUser.emailAddress == txtEmail.Text.Trim())
            {
                TipsAlert("Email和原来的一样。");
            }
            else
            {
                bool isok = BLL.User.MembershipUserEb.Instance.ExistsEmail(txtEmail.Text.Trim());
                if (!isok)
                {
                    Base.EntityAPI.MembershipUserEb mdUser = HostApi.CurrentUser;
                    mdUser.emailAddress = txtEmail.Text.Trim();
                    mdUser.Save();
                    TipsAlert("修改成功！");
                }
                else
                {
                    base.TipsAlert("此Email已被注册");
                }
            }
        }
    }
}